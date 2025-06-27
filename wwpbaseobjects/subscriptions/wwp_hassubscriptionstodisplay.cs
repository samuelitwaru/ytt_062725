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
   public class wwp_hassubscriptionstodisplay : GXProcedure
   {
      public wwp_hassubscriptionstodisplay( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_hassubscriptionstodisplay( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPEntityName ,
                           short aP1_WWPNotificationAppliesTo ,
                           out bool aP2_HasSubscriptions )
      {
         this.AV11WWPEntityName = aP0_WWPEntityName;
         this.AV10WWPNotificationAppliesTo = aP1_WWPNotificationAppliesTo;
         this.AV9HasSubscriptions = false ;
         initialize();
         ExecuteImpl();
         aP2_HasSubscriptions=this.AV9HasSubscriptions;
      }

      public bool executeUdp( string aP0_WWPEntityName ,
                              short aP1_WWPNotificationAppliesTo )
      {
         execute(aP0_WWPEntityName, aP1_WWPNotificationAppliesTo, out aP2_HasSubscriptions);
         return AV9HasSubscriptions ;
      }

      public void executeSubmit( string aP0_WWPEntityName ,
                                 short aP1_WWPNotificationAppliesTo ,
                                 out bool aP2_HasSubscriptions )
      {
         this.AV11WWPEntityName = aP0_WWPEntityName;
         this.AV10WWPNotificationAppliesTo = aP1_WWPNotificationAppliesTo;
         this.AV9HasSubscriptions = false ;
         SubmitImpl();
         aP2_HasSubscriptions=this.AV9HasSubscriptions;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_int1 = AV8WWPEntityId;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  AV11WWPEntityName, out  GXt_int1) ;
         AV8WWPEntityId = GXt_int1;
         AV9HasSubscriptions = false;
         /* Using cursor P003B2 */
         pr_default.execute(0, new Object[] {AV8WWPEntityId, AV10WWPNotificationAppliesTo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A20WWPEntityId = P003B2_A20WWPEntityId[0];
            A30WWPNotificationDefinitionAppli = P003B2_A30WWPNotificationDefinitionAppli[0];
            A31WWPNotificationDefinitionAllow = P003B2_A31WWPNotificationDefinitionAllow[0];
            A67WWPNotificationDefinitionSecFu = P003B2_A67WWPNotificationDefinitionSecFu[0];
            A23WWPNotificationDefinitionId = P003B2_A23WWPNotificationDefinitionId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A67WWPNotificationDefinitionSecFu)) )
            {
               A68WWPNotificationDefinitionIsAut = true;
            }
            else
            {
               GXt_boolean2 = A68WWPNotificationDefinitionIsAut;
               new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A67WWPNotificationDefinitionSecFu, out  GXt_boolean2) ;
               A68WWPNotificationDefinitionIsAut = GXt_boolean2;
            }
            if ( A68WWPNotificationDefinitionIsAut )
            {
               AV9HasSubscriptions = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
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
         P003B2_A20WWPEntityId = new long[1] ;
         P003B2_A30WWPNotificationDefinitionAppli = new short[1] ;
         P003B2_A31WWPNotificationDefinitionAllow = new bool[] {false} ;
         P003B2_A67WWPNotificationDefinitionSecFu = new string[] {""} ;
         P003B2_A23WWPNotificationDefinitionId = new long[1] ;
         A67WWPNotificationDefinitionSecFu = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay__default(),
            new Object[][] {
                new Object[] {
               P003B2_A20WWPEntityId, P003B2_A30WWPNotificationDefinitionAppli, P003B2_A31WWPNotificationDefinitionAllow, P003B2_A67WWPNotificationDefinitionSecFu, P003B2_A23WWPNotificationDefinitionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10WWPNotificationAppliesTo ;
      private short A30WWPNotificationDefinitionAppli ;
      private long AV8WWPEntityId ;
      private long GXt_int1 ;
      private long A20WWPEntityId ;
      private long A23WWPNotificationDefinitionId ;
      private bool AV9HasSubscriptions ;
      private bool A31WWPNotificationDefinitionAllow ;
      private bool A68WWPNotificationDefinitionIsAut ;
      private bool GXt_boolean2 ;
      private string AV11WWPEntityName ;
      private string A67WWPNotificationDefinitionSecFu ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P003B2_A20WWPEntityId ;
      private short[] P003B2_A30WWPNotificationDefinitionAppli ;
      private bool[] P003B2_A31WWPNotificationDefinitionAllow ;
      private string[] P003B2_A67WWPNotificationDefinitionSecFu ;
      private long[] P003B2_A23WWPNotificationDefinitionId ;
      private bool aP2_HasSubscriptions ;
   }

   public class wwp_hassubscriptionstodisplay__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003B2;
          prmP003B2 = new Object[] {
          new ParDef("AV8WWPEntityId",GXType.Int64,10,0) ,
          new ParDef("AV10WWPNotificationAppliesTo",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003B2", "SELECT WWPEntityId, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPNotificationDefinitionSecFu, WWPNotificationDefinitionId FROM WWP_NotificationDefinition WHERE (WWPEntityId = :AV8WWPEntityId) AND (WWPNotificationDefinitionAllow = TRUE) AND (WWPNotificationDefinitionAppli = :AV10WWPNotificationAppliesTo) ORDER BY WWPEntityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003B2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
