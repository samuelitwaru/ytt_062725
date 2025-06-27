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
   public class sdisgamuserblocked : GXProcedure
   {
      public sdisgamuserblocked( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sdisgamuserblocked( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserEmail ,
                           out bool aP1_isInactive )
      {
         this.AV10UserEmail = aP0_UserEmail;
         this.AV14isInactive = false ;
         initialize();
         ExecuteImpl();
         aP1_isInactive=this.AV14isInactive;
      }

      public bool executeUdp( string aP0_UserEmail )
      {
         execute(aP0_UserEmail, out aP1_isInactive);
         return AV14isInactive ;
      }

      public void executeSubmit( string aP0_UserEmail ,
                                 out bool aP1_isInactive )
      {
         this.AV10UserEmail = aP0_UserEmail;
         this.AV14isInactive = false ;
         SubmitImpl();
         aP1_isInactive=this.AV14isInactive;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P009F2 */
         pr_default.execute(0, new Object[] {AV10UserEmail});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A109EmployeeEmail = P009F2_A109EmployeeEmail[0];
            A112EmployeeIsActive = P009F2_A112EmployeeIsActive[0];
            A106EmployeeId = P009F2_A106EmployeeId[0];
            AV14isInactive = A112EmployeeIsActive;
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
         P009F2_A109EmployeeEmail = new string[] {""} ;
         P009F2_A112EmployeeIsActive = new bool[] {false} ;
         P009F2_A106EmployeeId = new long[1] ;
         A109EmployeeEmail = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sdisgamuserblocked__default(),
            new Object[][] {
                new Object[] {
               P009F2_A109EmployeeEmail, P009F2_A112EmployeeIsActive, P009F2_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A106EmployeeId ;
      private bool AV14isInactive ;
      private bool A112EmployeeIsActive ;
      private string AV10UserEmail ;
      private string A109EmployeeEmail ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P009F2_A109EmployeeEmail ;
      private bool[] P009F2_A112EmployeeIsActive ;
      private long[] P009F2_A106EmployeeId ;
      private bool aP1_isInactive ;
   }

   public class sdisgamuserblocked__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009F2;
          prmP009F2 = new Object[] {
          new ParDef("AV10UserEmail",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009F2", "SELECT EmployeeEmail, EmployeeIsActive, EmployeeId FROM Employee WHERE EmployeeEmail = ( :AV10UserEmail) ORDER BY EmployeeEmail ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009F2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
