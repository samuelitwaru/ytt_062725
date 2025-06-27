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
   public class acreategamroles : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new acreategamroles().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         execute();
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

      public acreategamroles( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public acreategamroles( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8RoleNames = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV9RolesString = "Manager,Employee,General Manager,Project Manager";
         AV8RoleNames = GxRegex.Split(AV9RolesString,",");
         AV18GXV1 = 1;
         while ( AV18GXV1 <= AV8RoleNames.Count )
         {
            AV14RoleName = AV8RoleNames.GetString(AV18GXV1);
            AV10GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
            AV10GAMRole.gxTpr_Name = AV14RoleName;
            AV10GAMRole.gxTpr_Description = AV14RoleName;
            AV10GAMRole.gxTpr_Externalid = "Is"+AV14RoleName;
            AV10GAMRole.save();
            if ( AV10GAMRole.success() )
            {
               context.CommitDataStores("creategamroles",pr_default);
            }
            AV18GXV1 = (int)(AV18GXV1+1);
         }
         AV15GAMRepository.gxTpr_Defaultroleid = AV10GAMRole.getbyexternalid("IsEmployee", out  AV16GAMErrorCollection).gxTpr_Id;
         AV15GAMRepository.save();
         AV16GAMErrorCollection = AV15GAMRepository.geterrors();
         context.CommitDataStores("creategamroles",pr_default);
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
         AV8RoleNames = new GxSimpleCollection<string>();
         AV9RolesString = "";
         AV14RoleName = "";
         AV10GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV15GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV16GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.acreategamroles__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acreategamroles__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV18GXV1 ;
      private string AV14RoleName ;
      private string AV9RolesString ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV8RoleNames ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV10GAMRole ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV15GAMRepository ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV16GAMErrorCollection ;
      private IDataStoreProvider pr_gam ;
   }

   public class acreategamroles__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class acreategamroles__default : DataStoreHelperBase, IDataStoreHelper
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
