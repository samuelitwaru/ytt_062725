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
   public class acreateemployeeaccounts : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new acreateemployeeaccounts().MainImpl(args); ;
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

      public acreateemployeeaccounts( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public acreateemployeeaccounts( IGxContext context )
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
         new creategamroles(context ).execute( ) ;
         /* Using cursor P00A72 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A109EmployeeEmail = P00A72_A109EmployeeEmail[0];
            A107EmployeeFirstName = P00A72_A107EmployeeFirstName[0];
            A108EmployeeLastName = P00A72_A108EmployeeLastName[0];
            A106EmployeeId = P00A72_A106EmployeeId[0];
            new createemployeeaccount1(context ).execute(  StringUtil.Trim( A109EmployeeEmail),  StringUtil.Trim( A107EmployeeFirstName),  StringUtil.Trim( A108EmployeeLastName),  "IsEmployee", out  AV8GAMUserGUID) ;
            AV9Employee.Load(A106EmployeeId);
            AV9Employee.gxTpr_Gamuserguid = AV8GAMUserGUID;
            AV9Employee.Save();
            context.CommitDataStores("createemployeeaccounts",pr_default);
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
         P00A72_A109EmployeeEmail = new string[] {""} ;
         P00A72_A107EmployeeFirstName = new string[] {""} ;
         P00A72_A108EmployeeLastName = new string[] {""} ;
         P00A72_A106EmployeeId = new long[1] ;
         A109EmployeeEmail = "";
         A107EmployeeFirstName = "";
         A108EmployeeLastName = "";
         AV8GAMUserGUID = "";
         AV9Employee = new SdtEmployee(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.acreateemployeeaccounts__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acreateemployeeaccounts__default(),
            new Object[][] {
                new Object[] {
               P00A72_A109EmployeeEmail, P00A72_A107EmployeeFirstName, P00A72_A108EmployeeLastName, P00A72_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A106EmployeeId ;
      private string A107EmployeeFirstName ;
      private string A108EmployeeLastName ;
      private string A109EmployeeEmail ;
      private string AV8GAMUserGUID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00A72_A109EmployeeEmail ;
      private string[] P00A72_A107EmployeeFirstName ;
      private string[] P00A72_A108EmployeeLastName ;
      private long[] P00A72_A106EmployeeId ;
      private SdtEmployee AV9Employee ;
      private IDataStoreProvider pr_gam ;
   }

   public class acreateemployeeaccounts__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class acreateemployeeaccounts__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00A72;
        prmP00A72 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("P00A72", "SELECT EmployeeEmail, EmployeeFirstName, EmployeeLastName, EmployeeId FROM Employee ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A72,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
     }
  }

}

}
