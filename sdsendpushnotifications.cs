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
   public class sdsendpushnotifications : GXProcedure
   {
      public sdsendpushnotifications( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sdsendpushnotifications( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Title ,
                           string aP1_Text ,
                           long aP2_EmployeeId )
      {
         this.AV22Title = aP0_Title;
         this.AV18Text = aP1_Text;
         this.AV10EmployeeId = aP2_EmployeeId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_Title ,
                                 string aP1_Text ,
                                 long aP2_EmployeeId )
      {
         this.AV22Title = aP0_Title;
         this.AV18Text = aP1_Text;
         this.AV10EmployeeId = aP2_EmployeeId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19TheNotification.gxTpr_Title.gxTpr_Defaulttext = AV22Title;
         AV19TheNotification.gxTpr_Text.gxTpr_Defaulttext = AV18Text;
         AV21TheNotificationDelivery.gxTpr_Priority = "High";
         AV20TheNotificationConfiguration.gxTpr_Applicationid = "YTTV3SD";
         new getloggedinuser(context ).execute( out  AV11GAMUser, out  AV9Employee) ;
         if ( AV10EmployeeId != 0 )
         {
            AV15NewEmployee.Load(AV10EmployeeId);
            /* Using cursor P005Q2 */
            pr_default.execute(0, new Object[] {AV15NewEmployee.gxTpr_Gamuserguid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A150DeviceUser = P005Q2_A150DeviceUser[0];
               n150DeviceUser = P005Q2_n150DeviceUser[0];
               A149DeviceToken = P005Q2_A149DeviceToken[0];
               A151DeviceId = P005Q2_A151DeviceId[0];
               AV8DeviceToken = A149DeviceToken;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            new GeneXus.Core.genexus.common.notifications.sendnotification(context ).execute(  AV20TheNotificationConfiguration,  AV8DeviceToken,  AV19TheNotification,  AV21TheNotificationDelivery, out  AV17OutMessages, out  AV12IsSuccessful) ;
         }
         else
         {
            /* Using cursor P005Q3 */
            pr_default.execute(1, new Object[] {AV9Employee.gxTpr_Employeeid});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A106EmployeeId = P005Q3_A106EmployeeId[0];
               A102ProjectId = P005Q3_A102ProjectId[0];
               AV26ProjectIds.Add(A102ProjectId, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 A102ProjectId ,
                                                 AV26ProjectIds ,
                                                 A176ProjectManagerIsActive } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor P005Q4 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               A162ProjectManagerId = P005Q4_A162ProjectManagerId[0];
               n162ProjectManagerId = P005Q4_n162ProjectManagerId[0];
               A176ProjectManagerIsActive = P005Q4_A176ProjectManagerIsActive[0];
               A102ProjectId = P005Q4_A102ProjectId[0];
               A175ProjectManagerEmail = P005Q4_A175ProjectManagerEmail[0];
               A176ProjectManagerIsActive = P005Q4_A176ProjectManagerIsActive[0];
               A175ProjectManagerEmail = P005Q4_A175ProjectManagerEmail[0];
               AV23emails.Add(A175ProjectManagerEmail, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            /* Using cursor P005Q5 */
            pr_default.execute(3, new Object[] {AV9Employee.gxTpr_Companyid});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A112EmployeeIsActive = P005Q5_A112EmployeeIsActive[0];
               A110EmployeeIsManager = P005Q5_A110EmployeeIsManager[0];
               A100CompanyId = P005Q5_A100CompanyId[0];
               A109EmployeeEmail = P005Q5_A109EmployeeEmail[0];
               A106EmployeeId = P005Q5_A106EmployeeId[0];
               AV23emails.Add(A109EmployeeEmail, 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV32Mymessage2 = AV23emails.ToJSonString(false);
            /* Execute user subroutine: 'SENDMANAGERNOTIFICATIONS' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'SENDMANAGERNOTIFICATIONS' Routine */
         returnInSub = false;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A109EmployeeEmail ,
                                              AV23emails } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P005Q6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A109EmployeeEmail = P005Q6_A109EmployeeEmail[0];
            A111GAMUserGUID = P005Q6_A111GAMUserGUID[0];
            A106EmployeeId = P005Q6_A106EmployeeId[0];
            AV25ManagerGUIDs.Add(A111GAMUserGUID, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              A150DeviceUser ,
                                              AV25ManagerGUIDs } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P005Q7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A150DeviceUser = P005Q7_A150DeviceUser[0];
            n150DeviceUser = P005Q7_n150DeviceUser[0];
            A149DeviceToken = P005Q7_A149DeviceToken[0];
            A151DeviceId = P005Q7_A151DeviceId[0];
            AV24ManagerDeviceTokens.Add(A149DeviceToken, 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         AV35GXV1 = 1;
         while ( AV35GXV1 <= AV24ManagerDeviceTokens.Count )
         {
            AV27token = AV24ManagerDeviceTokens.GetString(AV35GXV1);
            new GeneXus.Core.genexus.common.notifications.sendnotification(context ).execute(  AV20TheNotificationConfiguration,  AV27token,  AV19TheNotification,  AV21TheNotificationDelivery, out  AV17OutMessages, out  AV12IsSuccessful) ;
            AV35GXV1 = (int)(AV35GXV1+1);
         }
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
         AV19TheNotification = new GeneXus.Core.genexus.common.notifications.SdtNotification(context);
         AV21TheNotificationDelivery = new GeneXus.Core.genexus.common.notifications.SdtDelivery(context);
         AV20TheNotificationConfiguration = new GeneXus.Core.genexus.common.notifications.SdtConfiguration(context);
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV9Employee = new SdtEmployee(context);
         AV15NewEmployee = new SdtEmployee(context);
         P005Q2_A150DeviceUser = new string[] {""} ;
         P005Q2_n150DeviceUser = new bool[] {false} ;
         P005Q2_A149DeviceToken = new string[] {""} ;
         P005Q2_A151DeviceId = new string[] {""} ;
         A150DeviceUser = "";
         A149DeviceToken = "";
         A151DeviceId = "";
         AV8DeviceToken = "";
         AV17OutMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P005Q3_A106EmployeeId = new long[1] ;
         P005Q3_A102ProjectId = new long[1] ;
         AV26ProjectIds = new GxSimpleCollection<long>();
         P005Q4_A162ProjectManagerId = new long[1] ;
         P005Q4_n162ProjectManagerId = new bool[] {false} ;
         P005Q4_A176ProjectManagerIsActive = new bool[] {false} ;
         P005Q4_A102ProjectId = new long[1] ;
         P005Q4_A175ProjectManagerEmail = new string[] {""} ;
         A175ProjectManagerEmail = "";
         AV23emails = new GxSimpleCollection<string>();
         P005Q5_A112EmployeeIsActive = new bool[] {false} ;
         P005Q5_A110EmployeeIsManager = new bool[] {false} ;
         P005Q5_A100CompanyId = new long[1] ;
         P005Q5_A109EmployeeEmail = new string[] {""} ;
         P005Q5_A106EmployeeId = new long[1] ;
         A109EmployeeEmail = "";
         AV32Mymessage2 = "";
         P005Q6_A109EmployeeEmail = new string[] {""} ;
         P005Q6_A111GAMUserGUID = new string[] {""} ;
         P005Q6_A106EmployeeId = new long[1] ;
         A111GAMUserGUID = "";
         AV25ManagerGUIDs = new GxSimpleCollection<string>();
         P005Q7_A150DeviceUser = new string[] {""} ;
         P005Q7_n150DeviceUser = new bool[] {false} ;
         P005Q7_A149DeviceToken = new string[] {""} ;
         P005Q7_A151DeviceId = new string[] {""} ;
         AV24ManagerDeviceTokens = new GxSimpleCollection<string>();
         AV27token = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sdsendpushnotifications__default(),
            new Object[][] {
                new Object[] {
               P005Q2_A150DeviceUser, P005Q2_n150DeviceUser, P005Q2_A149DeviceToken, P005Q2_A151DeviceId
               }
               , new Object[] {
               P005Q3_A106EmployeeId, P005Q3_A102ProjectId
               }
               , new Object[] {
               P005Q4_A162ProjectManagerId, P005Q4_n162ProjectManagerId, P005Q4_A176ProjectManagerIsActive, P005Q4_A102ProjectId, P005Q4_A175ProjectManagerEmail
               }
               , new Object[] {
               P005Q5_A112EmployeeIsActive, P005Q5_A110EmployeeIsManager, P005Q5_A100CompanyId, P005Q5_A109EmployeeEmail, P005Q5_A106EmployeeId
               }
               , new Object[] {
               P005Q6_A109EmployeeEmail, P005Q6_A111GAMUserGUID, P005Q6_A106EmployeeId
               }
               , new Object[] {
               P005Q7_A150DeviceUser, P005Q7_n150DeviceUser, P005Q7_A149DeviceToken, P005Q7_A151DeviceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV35GXV1 ;
      private long AV10EmployeeId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A162ProjectManagerId ;
      private long A100CompanyId ;
      private string A149DeviceToken ;
      private string A151DeviceId ;
      private string AV8DeviceToken ;
      private string AV32Mymessage2 ;
      private string AV27token ;
      private bool n150DeviceUser ;
      private bool AV12IsSuccessful ;
      private bool A176ProjectManagerIsActive ;
      private bool n162ProjectManagerId ;
      private bool A112EmployeeIsActive ;
      private bool A110EmployeeIsManager ;
      private bool returnInSub ;
      private string AV22Title ;
      private string AV18Text ;
      private string A150DeviceUser ;
      private string A175ProjectManagerEmail ;
      private string A109EmployeeEmail ;
      private string A111GAMUserGUID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Core.genexus.common.notifications.SdtNotification AV19TheNotification ;
      private GeneXus.Core.genexus.common.notifications.SdtDelivery AV21TheNotificationDelivery ;
      private GeneXus.Core.genexus.common.notifications.SdtConfiguration AV20TheNotificationConfiguration ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV11GAMUser ;
      private SdtEmployee AV9Employee ;
      private SdtEmployee AV15NewEmployee ;
      private IDataStoreProvider pr_default ;
      private string[] P005Q2_A150DeviceUser ;
      private bool[] P005Q2_n150DeviceUser ;
      private string[] P005Q2_A149DeviceToken ;
      private string[] P005Q2_A151DeviceId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV17OutMessages ;
      private long[] P005Q3_A106EmployeeId ;
      private long[] P005Q3_A102ProjectId ;
      private GxSimpleCollection<long> AV26ProjectIds ;
      private long[] P005Q4_A162ProjectManagerId ;
      private bool[] P005Q4_n162ProjectManagerId ;
      private bool[] P005Q4_A176ProjectManagerIsActive ;
      private long[] P005Q4_A102ProjectId ;
      private string[] P005Q4_A175ProjectManagerEmail ;
      private GxSimpleCollection<string> AV23emails ;
      private bool[] P005Q5_A112EmployeeIsActive ;
      private bool[] P005Q5_A110EmployeeIsManager ;
      private long[] P005Q5_A100CompanyId ;
      private string[] P005Q5_A109EmployeeEmail ;
      private long[] P005Q5_A106EmployeeId ;
      private string[] P005Q6_A109EmployeeEmail ;
      private string[] P005Q6_A111GAMUserGUID ;
      private long[] P005Q6_A106EmployeeId ;
      private GxSimpleCollection<string> AV25ManagerGUIDs ;
      private string[] P005Q7_A150DeviceUser ;
      private bool[] P005Q7_n150DeviceUser ;
      private string[] P005Q7_A149DeviceToken ;
      private string[] P005Q7_A151DeviceId ;
      private GxSimpleCollection<string> AV24ManagerDeviceTokens ;
   }

   public class sdsendpushnotifications__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005Q4( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV26ProjectIds ,
                                             bool A176ProjectManagerIsActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object1 = new Object[2];
         scmdbuf = "SELECT T1.ProjectManagerId AS ProjectManagerId, T2.EmployeeIsActive AS ProjectManagerIsActive, T1.ProjectId, T2.EmployeeEmail AS ProjectManagerEmail FROM (Project T1 LEFT JOIN Employee T2 ON T2.EmployeeId = T1.ProjectManagerId)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV26ProjectIds, "T1.ProjectId IN (", ")")+")");
         AddWhere(sWhereString, "(T2.EmployeeIsActive = TRUE)");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ProjectId";
         GXv_Object1[0] = scmdbuf;
         return GXv_Object1 ;
      }

      protected Object[] conditional_P005Q6( IGxContext context ,
                                             string A109EmployeeEmail ,
                                             GxSimpleCollection<string> AV23emails )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT EmployeeEmail, GAMUserGUID, EmployeeId FROM Employee";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV23emails, "EmployeeEmail IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmployeeId";
         GXv_Object3[0] = scmdbuf;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P005Q7( IGxContext context ,
                                             string A150DeviceUser ,
                                             GxSimpleCollection<string> AV25ManagerGUIDs )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT DeviceUser, DeviceToken, DeviceId FROM Device";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV25ManagerGUIDs, "DeviceUser IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY DeviceId";
         GXv_Object5[0] = scmdbuf;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P005Q4(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (bool)dynConstraints[2] );
               case 4 :
                     return conditional_P005Q6(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] );
               case 5 :
                     return conditional_P005Q7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005Q2;
          prmP005Q2 = new Object[] {
          new ParDef("AV15NewEmployee__Gamuserguid",GXType.VarChar,100,60)
          };
          Object[] prmP005Q3;
          prmP005Q3 = new Object[] {
          new ParDef("AV9Employee__Employeeid",GXType.Int64,10,0)
          };
          Object[] prmP005Q5;
          prmP005Q5 = new Object[] {
          new ParDef("AV9Employee__Companyid",GXType.Int64,10,0)
          };
          Object[] prmP005Q4;
          prmP005Q4 = new Object[] {
          };
          Object[] prmP005Q6;
          prmP005Q6 = new Object[] {
          };
          Object[] prmP005Q7;
          prmP005Q7 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P005Q2", "SELECT DeviceUser, DeviceToken, DeviceId FROM Device WHERE DeviceUser = ( :AV15NewEmployee__Gamuserguid) ORDER BY DeviceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Q2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005Q3", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :AV9Employee__Employeeid ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Q3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005Q4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Q4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005Q5", "SELECT EmployeeIsActive, EmployeeIsManager, CompanyId, EmployeeEmail, EmployeeId FROM Employee WHERE (CompanyId = :AV9Employee__Companyid) AND (EmployeeIsManager = TRUE) AND (EmployeeIsActive = TRUE) ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Q5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005Q6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Q6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005Q7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Q7,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 1000);
                ((string[]) buf[3])[0] = rslt.getString(3, 128);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                return;
             case 3 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 1000);
                ((string[]) buf[3])[0] = rslt.getString(3, 128);
                return;
       }
    }

 }

}
