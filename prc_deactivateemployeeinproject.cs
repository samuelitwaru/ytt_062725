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
   public class prc_deactivateemployeeinproject : GXProcedure
   {
      public prc_deactivateemployeeinproject( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deactivateemployeeinproject( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           ref long aP1_ProjectId ,
                           ref bool aP2_IsSuccessful )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9ProjectId = aP1_ProjectId;
         this.AV10IsSuccessful = aP2_IsSuccessful;
         initialize();
         ExecuteImpl();
         aP1_ProjectId=this.AV9ProjectId;
         aP2_IsSuccessful=this.AV10IsSuccessful;
      }

      public bool executeUdp( long aP0_EmployeeId ,
                              ref long aP1_ProjectId )
      {
         execute(aP0_EmployeeId, ref aP1_ProjectId, ref aP2_IsSuccessful);
         return AV10IsSuccessful ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 ref long aP1_ProjectId ,
                                 ref bool aP2_IsSuccessful )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9ProjectId = aP1_ProjectId;
         this.AV10IsSuccessful = aP2_IsSuccessful;
         SubmitImpl();
         aP1_ProjectId=this.AV9ProjectId;
         aP2_IsSuccessful=this.AV10IsSuccessful;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10IsSuccessful = false;
         /* Using cursor P00C02 */
         pr_default.execute(0, new Object[] {AV8EmployeeId, AV9ProjectId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTC02 = 0;
            A102ProjectId = P00C02_A102ProjectId[0];
            A106EmployeeId = P00C02_A106EmployeeId[0];
            A184EmployeeIsActiveInProject = P00C02_A184EmployeeIsActiveInProject[0];
            A184EmployeeIsActiveInProject = false;
            GXTC02 = 1;
            AV10IsSuccessful = true;
            /* Using cursor P00C03 */
            pr_default.execute(1, new Object[] {A184EmployeeIsActiveInProject, A106EmployeeId, A102ProjectId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("EmployeeProject");
            if ( GXTC02 == 1 )
            {
               context.CommitDataStores("prc_deactivateemployeeinproject",pr_default);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deactivateemployeeinproject",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00C02_A102ProjectId = new long[1] ;
         P00C02_A106EmployeeId = new long[1] ;
         P00C02_A184EmployeeIsActiveInProject = new bool[] {false} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_deactivateemployeeinproject__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deactivateemployeeinproject__default(),
            new Object[][] {
                new Object[] {
               P00C02_A102ProjectId, P00C02_A106EmployeeId, P00C02_A184EmployeeIsActiveInProject
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTC02 ;
      private long AV8EmployeeId ;
      private long AV9ProjectId ;
      private long A102ProjectId ;
      private long A106EmployeeId ;
      private bool AV10IsSuccessful ;
      private bool A184EmployeeIsActiveInProject ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP1_ProjectId ;
      private bool aP2_IsSuccessful ;
      private IDataStoreProvider pr_default ;
      private long[] P00C02_A102ProjectId ;
      private long[] P00C02_A106EmployeeId ;
      private bool[] P00C02_A184EmployeeIsActiveInProject ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_deactivateemployeeinproject__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_deactivateemployeeinproject__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00C02;
        prmP00C02 = new Object[] {
        new ParDef("AV8EmployeeId",GXType.Int64,10,0) ,
        new ParDef("AV9ProjectId",GXType.Int64,10,0)
        };
        Object[] prmP00C03;
        prmP00C03 = new Object[] {
        new ParDef("EmployeeIsActiveInProject",GXType.Boolean,4,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00C02", "SELECT ProjectId, EmployeeId, EmployeeIsActiveInProject FROM EmployeeProject WHERE EmployeeId = :AV8EmployeeId and ProjectId = :AV9ProjectId ORDER BY EmployeeId, ProjectId  FOR UPDATE OF EmployeeProject",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C02,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00C03", "SAVEPOINT gxupdate;UPDATE EmployeeProject SET EmployeeIsActiveInProject=:EmployeeIsActiveInProject  WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00C03)
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
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
     }
  }

}

}
