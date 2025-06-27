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
   public class getloggedinuser : GXProcedure
   {
      public getloggedinuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getloggedinuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GeneXus.Programs.genexussecurity.SdtGAMUser aP0_GAMUser ,
                           out SdtEmployee aP1_Employee )
      {
         this.AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context) ;
         this.AV8Employee = new SdtEmployee(context) ;
         initialize();
         ExecuteImpl();
         aP0_GAMUser=this.AV11GAMUser;
         aP1_Employee=this.AV8Employee;
      }

      public SdtEmployee executeUdp( out GeneXus.Programs.genexussecurity.SdtGAMUser aP0_GAMUser )
      {
         execute(out aP0_GAMUser, out aP1_Employee);
         return AV8Employee ;
      }

      public void executeSubmit( out GeneXus.Programs.genexussecurity.SdtGAMUser aP0_GAMUser ,
                                 out SdtEmployee aP1_Employee )
      {
         this.AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context) ;
         this.AV8Employee = new SdtEmployee(context) ;
         SubmitImpl();
         aP0_GAMUser=this.AV11GAMUser;
         aP1_Employee=this.AV8Employee;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV9GAMErrors);
         AV11GAMUser = AV10GAMSession.gxTpr_User;
         /* Using cursor P005F2 */
         pr_default.execute(0, new Object[] {AV11GAMUser.gxTpr_Email, AV11GAMUser.gxTpr_Guid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A109EmployeeEmail = P005F2_A109EmployeeEmail[0];
            A111GAMUserGUID = P005F2_A111GAMUserGUID[0];
            A106EmployeeId = P005F2_A106EmployeeId[0];
            AV8Employee.Load(A106EmployeeId);
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
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV8Employee = new SdtEmployee(context);
         AV10GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV9GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         P005F2_A109EmployeeEmail = new string[] {""} ;
         P005F2_A111GAMUserGUID = new string[] {""} ;
         P005F2_A106EmployeeId = new long[1] ;
         A109EmployeeEmail = "";
         A111GAMUserGUID = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getloggedinuser__default(),
            new Object[][] {
                new Object[] {
               P005F2_A109EmployeeEmail, P005F2_A111GAMUserGUID, P005F2_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A106EmployeeId ;
      private string A109EmployeeEmail ;
      private string A111GAMUserGUID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV11GAMUser ;
      private SdtEmployee AV8Employee ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV10GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9GAMErrors ;
      private IDataStoreProvider pr_default ;
      private string[] P005F2_A109EmployeeEmail ;
      private string[] P005F2_A111GAMUserGUID ;
      private long[] P005F2_A106EmployeeId ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser aP0_GAMUser ;
      private SdtEmployee aP1_Employee ;
   }

   public class getloggedinuser__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005F2;
          prmP005F2 = new Object[] {
          new ParDef("AV11GAMUser__Email",GXType.VarChar,100,0) ,
          new ParDef("AV11GAMUser__Guid",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005F2", "SELECT EmployeeEmail, GAMUserGUID, EmployeeId FROM Employee WHERE (EmployeeEmail = ( :AV11GAMUser__Email)) AND (GAMUserGUID = ( :AV11GAMUser__Guid)) ORDER BY EmployeeEmail ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005F2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
