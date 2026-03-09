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
   public class prc_getprojectemployees : GXProcedure
   {
      public prc_getprojectemployees( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getprojectemployees( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProjectId ,
                           out GXBCCollection<SdtEmployee> aP1_BC_EmployeeCollection )
      {
         this.AV12ProjectId = aP0_ProjectId;
         this.AV11BC_EmployeeCollection = new GXBCCollection<SdtEmployee>( context, "Employee", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP1_BC_EmployeeCollection=this.AV11BC_EmployeeCollection;
      }

      public GXBCCollection<SdtEmployee> executeUdp( long aP0_ProjectId )
      {
         execute(aP0_ProjectId, out aP1_BC_EmployeeCollection);
         return AV11BC_EmployeeCollection ;
      }

      public void executeSubmit( long aP0_ProjectId ,
                                 out GXBCCollection<SdtEmployee> aP1_BC_EmployeeCollection )
      {
         this.AV12ProjectId = aP0_ProjectId;
         this.AV11BC_EmployeeCollection = new GXBCCollection<SdtEmployee>( context, "Employee", "YTT_version4") ;
         SubmitImpl();
         aP1_BC_EmployeeCollection=this.AV11BC_EmployeeCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00BZ2 */
         pr_default.execute(0, new Object[] {AV12ProjectId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A184EmployeeIsActiveInProject = P00BZ2_A184EmployeeIsActiveInProject[0];
            A102ProjectId = P00BZ2_A102ProjectId[0];
            A106EmployeeId = P00BZ2_A106EmployeeId[0];
            AV10BC_Employee = new SdtEmployee(context);
            AV10BC_Employee.Load(A106EmployeeId);
            AV11BC_EmployeeCollection.Add(AV10BC_Employee, 0);
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
         AV11BC_EmployeeCollection = new GXBCCollection<SdtEmployee>( context, "Employee", "YTT_version4");
         P00BZ2_A184EmployeeIsActiveInProject = new bool[] {false} ;
         P00BZ2_A102ProjectId = new long[1] ;
         P00BZ2_A106EmployeeId = new long[1] ;
         AV10BC_Employee = new SdtEmployee(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getprojectemployees__default(),
            new Object[][] {
                new Object[] {
               P00BZ2_A184EmployeeIsActiveInProject, P00BZ2_A102ProjectId, P00BZ2_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV12ProjectId ;
      private long A102ProjectId ;
      private long A106EmployeeId ;
      private bool A184EmployeeIsActiveInProject ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBCCollection<SdtEmployee> AV11BC_EmployeeCollection ;
      private IDataStoreProvider pr_default ;
      private bool[] P00BZ2_A184EmployeeIsActiveInProject ;
      private long[] P00BZ2_A102ProjectId ;
      private long[] P00BZ2_A106EmployeeId ;
      private SdtEmployee AV10BC_Employee ;
      private GXBCCollection<SdtEmployee> aP1_BC_EmployeeCollection ;
   }

   public class prc_getprojectemployees__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BZ2;
          prmP00BZ2 = new Object[] {
          new ParDef("AV12ProjectId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BZ2", "SELECT EmployeeIsActiveInProject, ProjectId, EmployeeId FROM EmployeeProject WHERE (ProjectId = :AV12ProjectId) AND (EmployeeIsActiveInProject = TRUE) ORDER BY ProjectId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BZ2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
