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
   public class agetemployeelastloggedprojectweb : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new agetemployeelastloggedprojectweb().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
          long aP0_EmployeeId ;
          long aP1_ProjectId ;
         if ( 0 < args.Length )
         {
            aP0_EmployeeId=((long)(NumberUtil.Val( (string)(args[0]), ".")));
         }
         else
         {
            aP0_EmployeeId=0;
         }
         if ( 1 < args.Length )
         {
            aP1_ProjectId=((long)(NumberUtil.Val( (string)(args[1]), ".")));
         }
         else
         {
            aP1_ProjectId=0;
         }
         execute(aP0_EmployeeId, out aP1_ProjectId);
         return GX.GXRuntime.ExitCode ;
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public agetemployeelastloggedprojectweb( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public agetemployeelastloggedprojectweb( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           out long aP1_ProjectId )
      {
         this.AV9EmployeeId = aP0_EmployeeId;
         this.AV8ProjectId = 0 ;
         initialize();
         ExecuteImpl();
         aP1_ProjectId=this.AV8ProjectId;
      }

      public long executeUdp( long aP0_EmployeeId )
      {
         execute(aP0_EmployeeId, out aP1_ProjectId);
         return AV8ProjectId ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 out long aP1_ProjectId )
      {
         this.AV9EmployeeId = aP0_EmployeeId;
         this.AV8ProjectId = 0 ;
         SubmitImpl();
         aP1_ProjectId=this.AV8ProjectId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00B62 */
         pr_default.execute(0, new Object[] {AV9EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00B62_A106EmployeeId[0];
            A102ProjectId = P00B62_A102ProjectId[0];
            A118WorkHourLogId = P00B62_A118WorkHourLogId[0];
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
         P00B62_A106EmployeeId = new long[1] ;
         P00B62_A102ProjectId = new long[1] ;
         P00B62_A118WorkHourLogId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.agetemployeelastloggedprojectweb__default(),
            new Object[][] {
                new Object[] {
               P00B62_A106EmployeeId, P00B62_A102ProjectId, P00B62_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9EmployeeId ;
      private long AV8ProjectId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A118WorkHourLogId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00B62_A106EmployeeId ;
      private long[] P00B62_A102ProjectId ;
      private long[] P00B62_A118WorkHourLogId ;
      private long aP1_ProjectId ;
   }

   public class agetemployeelastloggedprojectweb__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00B62;
          prmP00B62 = new Object[] {
          new ParDef("AV9EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B62", "SELECT EmployeeId, ProjectId, WorkHourLogId FROM WorkHourLog WHERE EmployeeId = :AV9EmployeeId ORDER BY WorkHourLogId DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B62,1, GxCacheFrequency.OFF ,false,true )
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
