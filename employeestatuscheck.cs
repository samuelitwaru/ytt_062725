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
   public class employeestatuscheck : GXProcedure
   {
      public employeestatuscheck( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeestatuscheck( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId )
      {
         this.A106EmployeeId = aP0_EmployeeId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( long aP0_EmployeeId )
      {
         this.A106EmployeeId = aP0_EmployeeId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Employee.Load(A106EmployeeId);
         AV9GAMUser.load( AV8Employee.gxTpr_Gamuserguid);
         if ( ( AV8Employee.gxTpr_Employeeisactive ) && ( AV9GAMUser.gxTpr_Isblocked ) )
         {
            AV9GAMUser.gxTpr_Isblocked = false;
         }
         if ( ! AV8Employee.gxTpr_Employeeisactive && ! AV9GAMUser.gxTpr_Isblocked )
         {
            AV9GAMUser.gxTpr_Isblocked = true;
         }
         AV9GAMUser.save();
         if ( AV9GAMUser.success() )
         {
            context.CommitDataStores("employeestatuscheck",pr_default);
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
         AV8Employee = new SdtEmployee(context);
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.employeestatuscheck__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeestatuscheck__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private long A106EmployeeId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtEmployee AV8Employee ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
   }

   public class employeestatuscheck__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class employeestatuscheck__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
