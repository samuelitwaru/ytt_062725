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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_roleupdatesubscription : GXProcedure
   {
      public wwp_roleupdatesubscription( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_roleupdatesubscription( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( bool aP0_Subscribe ,
                           ref long aP1_WWPSubscriptionId ,
                           long aP2_WWPNotificationDefinitionId ,
                           string aP3_WWPSubscriptionRoleId )
      {
         this.AV8Subscribe = aP0_Subscribe;
         this.AV11WWPSubscriptionId = aP1_WWPSubscriptionId;
         this.AV9WWPNotificationDefinitionId = aP2_WWPNotificationDefinitionId;
         this.AV12WWPSubscriptionRoleId = aP3_WWPSubscriptionRoleId;
         initialize();
         ExecuteImpl();
         aP1_WWPSubscriptionId=this.AV11WWPSubscriptionId;
      }

      public void executeSubmit( bool aP0_Subscribe ,
                                 ref long aP1_WWPSubscriptionId ,
                                 long aP2_WWPNotificationDefinitionId ,
                                 string aP3_WWPSubscriptionRoleId )
      {
         this.AV8Subscribe = aP0_Subscribe;
         this.AV11WWPSubscriptionId = aP1_WWPSubscriptionId;
         this.AV9WWPNotificationDefinitionId = aP2_WWPNotificationDefinitionId;
         this.AV12WWPSubscriptionRoleId = aP3_WWPSubscriptionRoleId;
         SubmitImpl();
         aP1_WWPSubscriptionId=this.AV11WWPSubscriptionId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( AV8Subscribe )
         {
            AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
            AV10WWPSubscription.gxTpr_Wwpnotificationdefinitionid = AV9WWPNotificationDefinitionId;
            AV10WWPSubscription.gxTpr_Wwpsubscriptionsubscribed = true;
            AV10WWPSubscription.gxTpr_Wwpsubscriptionroleid = AV12WWPSubscriptionRoleId;
            AV10WWPSubscription.Save();
            AV11WWPSubscriptionId = AV10WWPSubscription.gxTpr_Wwpsubscriptionid;
            GXt_objcol_char1 = AV13WWPUserExtendedIdCollection;
            new GeneXus.Programs.wwpbaseobjects.wwp_getusersfromrole(context ).execute(  AV12WWPSubscriptionRoleId, out  GXt_objcol_char1) ;
            AV13WWPUserExtendedIdCollection = GXt_objcol_char1;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A7WWPUserExtendedId ,
                                                 AV13WWPUserExtendedIdCollection ,
                                                 AV9WWPNotificationDefinitionId ,
                                                 A23WWPNotificationDefinitionId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor P002N2 */
            pr_default.execute(0, new Object[] {AV9WWPNotificationDefinitionId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A7WWPUserExtendedId = P002N2_A7WWPUserExtendedId[0];
               n7WWPUserExtendedId = P002N2_n7WWPUserExtendedId[0];
               A23WWPNotificationDefinitionId = P002N2_A23WWPNotificationDefinitionId[0];
               A25WWPSubscriptionId = P002N2_A25WWPSubscriptionId[0];
               /* Using cursor P002N3 */
               pr_default.execute(1, new Object[] {A25WWPSubscriptionId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else
         {
            AV10WWPSubscription.Load(AV11WWPSubscriptionId);
            AV10WWPSubscription.Delete();
         }
         if ( AV10WWPSubscription.Success() )
         {
            context.CommitDataStores("wwpbaseobjects.subscriptions.wwp_roleupdatesubscription",pr_default);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wwpbaseobjects.subscriptions.wwp_roleupdatesubscription",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
         AV13WWPUserExtendedIdCollection = new GxSimpleCollection<string>();
         GXt_objcol_char1 = new GxSimpleCollection<string>();
         A7WWPUserExtendedId = "";
         P002N2_A7WWPUserExtendedId = new string[] {""} ;
         P002N2_n7WWPUserExtendedId = new bool[] {false} ;
         P002N2_A23WWPNotificationDefinitionId = new long[1] ;
         P002N2_A25WWPSubscriptionId = new long[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_roleupdatesubscription__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_roleupdatesubscription__default(),
            new Object[][] {
                new Object[] {
               P002N2_A7WWPUserExtendedId, P002N2_n7WWPUserExtendedId, P002N2_A23WWPNotificationDefinitionId, P002N2_A25WWPSubscriptionId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV11WWPSubscriptionId ;
      private long AV9WWPNotificationDefinitionId ;
      private long A23WWPNotificationDefinitionId ;
      private long A25WWPSubscriptionId ;
      private string AV12WWPSubscriptionRoleId ;
      private string A7WWPUserExtendedId ;
      private bool AV8Subscribe ;
      private bool n7WWPUserExtendedId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP1_WWPSubscriptionId ;
      private GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription AV10WWPSubscription ;
      private GxSimpleCollection<string> AV13WWPUserExtendedIdCollection ;
      private GxSimpleCollection<string> GXt_objcol_char1 ;
      private IDataStoreProvider pr_default ;
      private string[] P002N2_A7WWPUserExtendedId ;
      private bool[] P002N2_n7WWPUserExtendedId ;
      private long[] P002N2_A23WWPNotificationDefinitionId ;
      private long[] P002N2_A25WWPSubscriptionId ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_roleupdatesubscription__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_roleupdatesubscription__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P002N2( IGxContext context ,
                                           string A7WWPUserExtendedId ,
                                           GxSimpleCollection<string> AV13WWPUserExtendedIdCollection ,
                                           long AV9WWPNotificationDefinitionId ,
                                           long A23WWPNotificationDefinitionId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int2 = new short[1];
       Object[] GXv_Object3 = new Object[2];
       scmdbuf = "SELECT WWPUserExtendedId, WWPNotificationDefinitionId, WWPSubscriptionId FROM WWP_Subscription";
       AddWhere(sWhereString, "(WWPNotificationDefinitionId = :AV9WWPNotificationDefinitionId)");
       AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV13WWPUserExtendedIdCollection, "WWPUserExtendedId IN (", ")")+")");
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY WWPNotificationDefinitionId";
       scmdbuf += " FOR UPDATE OF WWP_Subscription";
       GXv_Object3[0] = scmdbuf;
       GXv_Object3[1] = GXv_int2;
       return GXv_Object3 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 0 :
                   return conditional_P002N2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] );
       }
       return base.getDynamicStatement(cursor, context, dynConstraints);
    }

    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new UpdateCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP002N3;
        prmP002N3 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmP002N2;
        prmP002N2 = new Object[] {
        new ParDef("AV9WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("P002N2", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002N2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P002N3", "SAVEPOINT gxupdate;DELETE FROM WWP_Subscription  WHERE WWPSubscriptionId = :WWPSubscriptionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002N3)
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
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((long[]) buf[2])[0] = rslt.getLong(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              return;
     }
  }

}

}
