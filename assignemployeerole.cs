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
   public class assignemployeerole : GXProcedure
   {
      public assignemployeerole( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public assignemployeerole( IGxContext context )
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
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getbylogin("local", AV8Employee.gxTpr_Employeeemail, out  AV10GAMErrorCollection);
         AV11GAMRole = AV12GAMRepository.getrolebyexternalid("IsManager", out  AV10GAMErrorCollection);
         AV13EmployeeGAMRole = AV12GAMRepository.getrolebyexternalid("IsEmployee", out  AV10GAMErrorCollection);
         if ( AV8Employee.gxTpr_Employeeismanager )
         {
            AV9GAMUser.addrolebyid( AV11GAMRole.gxTpr_Id, out  AV10GAMErrorCollection);
            if ( AV11GAMRole.success() )
            {
               context.CommitDataStores("assignemployeerole",pr_default);
            }
         }
         else
         {
            AV9GAMUser.deleterolebyid( AV11GAMRole.gxTpr_Id, out  AV10GAMErrorCollection);
            AV9GAMUser.addrolebyid( AV13EmployeeGAMRole.gxTpr_Id, out  AV10GAMErrorCollection);
         }
         context.CommitDataStores("assignemployeerole",pr_default);
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
         AV10GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV12GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV13EmployeeGAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.assignemployeerole__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assignemployeerole__default(),
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
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV11GAMRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV12GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV13EmployeeGAMRole ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
   }

   public class assignemployeerole__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class assignemployeerole__default : DataStoreHelperBase, IDataStoreHelper
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
