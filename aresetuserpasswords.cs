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
   public class aresetuserpasswords : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aresetuserpasswords().MainImpl(args); ;
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

      public aresetuserpasswords( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aresetuserpasswords( IGxContext context )
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
         /* Using cursor P00AX2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A109EmployeeEmail = P00AX2_A109EmployeeEmail[0];
            A111GAMUserGUID = P00AX2_A111GAMUserGUID[0];
            A106EmployeeId = P00AX2_A106EmployeeId[0];
            new logtofile(context ).execute(  A109EmployeeEmail) ;
            AV8GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getbyguid(A111GAMUserGUID, out  AV9GAMErrorCollection);
            new logtofile(context ).execute(  AV8GAMUser.gxTpr_Email) ;
            AV12GXV1 = 1;
            while ( AV12GXV1 <= AV9GAMErrorCollection.Count )
            {
               AV10GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV9GAMErrorCollection.Item(AV12GXV1));
               new logtofile(context ).execute(  "1. "+AV10GAMError.gxTpr_Message) ;
               AV12GXV1 = (int)(AV12GXV1+1);
            }
            AV8GAMUser.setpassword( "user123", out  AV9GAMErrorCollection);
            AV8GAMUser.save();
            AV13GXV2 = 1;
            while ( AV13GXV2 <= AV9GAMErrorCollection.Count )
            {
               AV10GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV9GAMErrorCollection.Item(AV13GXV2));
               new logtofile(context ).execute(  "2. "+AV10GAMError.gxTpr_Message) ;
               AV13GXV2 = (int)(AV13GXV2+1);
            }
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
         P00AX2_A109EmployeeEmail = new string[] {""} ;
         P00AX2_A111GAMUserGUID = new string[] {""} ;
         P00AX2_A106EmployeeId = new long[1] ;
         A109EmployeeEmail = "";
         A111GAMUserGUID = "";
         AV8GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV9GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aresetuserpasswords__default(),
            new Object[][] {
                new Object[] {
               P00AX2_A109EmployeeEmail, P00AX2_A111GAMUserGUID, P00AX2_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV12GXV1 ;
      private int AV13GXV2 ;
      private long A106EmployeeId ;
      private string A109EmployeeEmail ;
      private string A111GAMUserGUID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00AX2_A109EmployeeEmail ;
      private string[] P00AX2_A111GAMUserGUID ;
      private long[] P00AX2_A106EmployeeId ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV8GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV10GAMError ;
   }

   public class aresetuserpasswords__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AX2;
          prmP00AX2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00AX2", "SELECT EmployeeEmail, GAMUserGUID, EmployeeId FROM Employee ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AX2,100, GxCacheFrequency.OFF ,true,false )
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
