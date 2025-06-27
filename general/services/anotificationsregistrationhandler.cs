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
namespace GeneXus.Programs.general.services {
   public class anotificationsregistrationhandler : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new general.services.anotificationsregistrationhandler().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
          short aP0_DeviceType ;
         string aP1_DeviceId = new string(' ',0)  ;
         string aP2_DeviceToken = new string(' ',0)  ;
         string aP3_DeviceName = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_DeviceType=((short)(NumberUtil.Val( (string)(args[0]), ".")));
         }
         else
         {
            aP0_DeviceType=0;
         }
         if ( 1 < args.Length )
         {
            aP1_DeviceId=((string)(args[1]));
         }
         else
         {
            aP1_DeviceId="";
         }
         if ( 2 < args.Length )
         {
            aP2_DeviceToken=((string)(args[2]));
         }
         else
         {
            aP2_DeviceToken="";
         }
         if ( 3 < args.Length )
         {
            aP3_DeviceName=((string)(args[3]));
         }
         else
         {
            aP3_DeviceName="";
         }
         execute(aP0_DeviceType, aP1_DeviceId, aP2_DeviceToken, aP3_DeviceName);
         return GX.GXRuntime.ExitCode ;
      }

      public anotificationsregistrationhandler( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public anotificationsregistrationhandler( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_DeviceType ,
                           string aP1_DeviceId ,
                           string aP2_DeviceToken ,
                           string aP3_DeviceName )
      {
         this.AV11DeviceType = aP0_DeviceType;
         this.AV8DeviceId = aP1_DeviceId;
         this.AV10DeviceToken = aP2_DeviceToken;
         this.AV9DeviceName = aP3_DeviceName;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( short aP0_DeviceType ,
                                 string aP1_DeviceId ,
                                 string aP2_DeviceToken ,
                                 string aP3_DeviceName )
      {
         this.AV11DeviceType = aP0_DeviceType;
         this.AV8DeviceId = aP1_DeviceId;
         this.AV10DeviceToken = aP2_DeviceToken;
         this.AV9DeviceName = aP3_DeviceName;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13AvailableUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         AV14GXLvl9 = 0;
         /* Optimized UPDATE. */
         /* Using cursor P003V2 */
         pr_default.execute(0, new Object[] {AV9DeviceName, AV10DeviceToken, AV8DeviceId, AV11DeviceType});
         if ( (pr_default.getStatus(0) != 101) )
         {
            AV14GXLvl9 = 1;
         }
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Device");
         /* End optimized UPDATE. */
         if ( AV14GXLvl9 == 0 )
         {
            /*
               INSERT RECORD ON TABLE Device

            */
            A152DeviceType = AV11DeviceType;
            A151DeviceId = AV8DeviceId;
            A149DeviceToken = AV10DeviceToken;
            A153DeviceName = AV9DeviceName;
            A150DeviceUser = AV13AvailableUser;
            n150DeviceUser = false;
            /* Using cursor P003V3 */
            pr_default.execute(1, new Object[] {A151DeviceId, A152DeviceType, A149DeviceToken, A153DeviceName, n150DeviceUser, A150DeviceUser});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Device");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("general.services.notificationsregistrationhandler",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV13AvailableUser = "";
         A153DeviceName = "";
         A149DeviceToken = "";
         A151DeviceId = "";
         A150DeviceUser = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.general.services.anotificationsregistrationhandler__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11DeviceType ;
      private short AV14GXLvl9 ;
      private short A152DeviceType ;
      private int GX_INS23 ;
      private string AV8DeviceId ;
      private string AV10DeviceToken ;
      private string AV9DeviceName ;
      private string A153DeviceName ;
      private string A149DeviceToken ;
      private string A151DeviceId ;
      private string Gx_emsg ;
      private bool n150DeviceUser ;
      private string AV13AvailableUser ;
      private string A150DeviceUser ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class anotificationsregistrationhandler__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP003V2;
          prmP003V2 = new Object[] {
          new ParDef("DeviceName",GXType.Char,100,0) ,
          new ParDef("DeviceToken",GXType.Char,1000,0) ,
          new ParDef("AV8DeviceId",GXType.Char,128,0) ,
          new ParDef("AV11DeviceType",GXType.Int16,1,0)
          };
          Object[] prmP003V3;
          prmP003V3 = new Object[] {
          new ParDef("DeviceId",GXType.Char,128,0) ,
          new ParDef("DeviceType",GXType.Int16,1,0) ,
          new ParDef("DeviceToken",GXType.Char,1000,0) ,
          new ParDef("DeviceName",GXType.Char,100,0) ,
          new ParDef("DeviceUser",GXType.VarChar,100,60){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P003V2", "UPDATE Device SET DeviceName=:DeviceName, DeviceToken=:DeviceToken  WHERE (DeviceId = ( :AV8DeviceId)) AND (DeviceType = :AV11DeviceType)", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003V2)
             ,new CursorDef("P003V3", "SAVEPOINT gxupdate;INSERT INTO Device(DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUser) VALUES(:DeviceId, :DeviceType, :DeviceToken, :DeviceName, :DeviceUser);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP003V3)
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
