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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_subscription_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_subscription_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_subscription_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow044( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey044( ) ;
         standaloneModal( ) ;
         AddRow044( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z25WWPSubscriptionId = A25WWPSubscriptionId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_040( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls044( ) ;
            }
            else
            {
               CheckExtendedTable044( ) ;
               if ( AnyError == 0 )
               {
                  ZM044( 3) ;
                  ZM044( 4) ;
                  ZM044( 5) ;
               }
               CloseExtendedTableCursors044( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z26WWPSubscriptionEntityRecordId = A26WWPSubscriptionEntityRecordId;
            Z28WWPSubscriptionEntityRecordDes = A28WWPSubscriptionEntityRecordDes;
            Z19WWPSubscriptionRoleId = A19WWPSubscriptionRoleId;
            Z27WWPSubscriptionSubscribed = A27WWPSubscriptionSubscribed;
            Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
            Z7WWPUserExtendedId = A7WWPUserExtendedId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z20WWPEntityId = A20WWPEntityId;
            Z29WWPNotificationDefinitionDescr = A29WWPNotificationDefinitionDescr;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z8WWPUserExtendedFullName = A8WWPUserExtendedFullName;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z21WWPEntityName = A21WWPEntityName;
         }
         if ( GX_JID == -2 )
         {
            Z25WWPSubscriptionId = A25WWPSubscriptionId;
            Z26WWPSubscriptionEntityRecordId = A26WWPSubscriptionEntityRecordId;
            Z28WWPSubscriptionEntityRecordDes = A28WWPSubscriptionEntityRecordDes;
            Z19WWPSubscriptionRoleId = A19WWPSubscriptionRoleId;
            Z27WWPSubscriptionSubscribed = A27WWPSubscriptionSubscribed;
            Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
            Z7WWPUserExtendedId = A7WWPUserExtendedId;
            Z20WWPEntityId = A20WWPEntityId;
            Z29WWPNotificationDefinitionDescr = A29WWPNotificationDefinitionDescr;
            Z21WWPEntityName = A21WWPEntityName;
            Z8WWPUserExtendedFullName = A8WWPUserExtendedFullName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load044( )
      {
         /* Using cursor BC00047 */
         pr_default.execute(5, new Object[] {A25WWPSubscriptionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound4 = 1;
            A20WWPEntityId = BC00047_A20WWPEntityId[0];
            A29WWPNotificationDefinitionDescr = BC00047_A29WWPNotificationDefinitionDescr[0];
            A21WWPEntityName = BC00047_A21WWPEntityName[0];
            A8WWPUserExtendedFullName = BC00047_A8WWPUserExtendedFullName[0];
            A26WWPSubscriptionEntityRecordId = BC00047_A26WWPSubscriptionEntityRecordId[0];
            A28WWPSubscriptionEntityRecordDes = BC00047_A28WWPSubscriptionEntityRecordDes[0];
            A19WWPSubscriptionRoleId = BC00047_A19WWPSubscriptionRoleId[0];
            n19WWPSubscriptionRoleId = BC00047_n19WWPSubscriptionRoleId[0];
            A27WWPSubscriptionSubscribed = BC00047_A27WWPSubscriptionSubscribed[0];
            A23WWPNotificationDefinitionId = BC00047_A23WWPNotificationDefinitionId[0];
            A7WWPUserExtendedId = BC00047_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = BC00047_n7WWPUserExtendedId[0];
            ZM044( -2) ;
         }
         pr_default.close(5);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
      }

      protected void CheckExtendedTable044( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00044 */
         pr_default.execute(2, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
         }
         A20WWPEntityId = BC00044_A20WWPEntityId[0];
         A29WWPNotificationDefinitionDescr = BC00044_A29WWPNotificationDefinitionDescr[0];
         pr_default.close(2);
         /* Using cursor BC00046 */
         pr_default.execute(4, new Object[] {A20WWPEntityId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'WWP_Entity'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A21WWPEntityName = BC00046_A21WWPEntityName[0];
         pr_default.close(4);
         /* Using cursor BC00045 */
         pr_default.execute(3, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("No matching 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
            }
         }
         A8WWPUserExtendedFullName = BC00045_A8WWPUserExtendedFullName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors044( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey044( )
      {
         /* Using cursor BC00048 */
         pr_default.execute(6, new Object[] {A25WWPSubscriptionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00043 */
         pr_default.execute(1, new Object[] {A25WWPSubscriptionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 2) ;
            RcdFound4 = 1;
            A25WWPSubscriptionId = BC00043_A25WWPSubscriptionId[0];
            A26WWPSubscriptionEntityRecordId = BC00043_A26WWPSubscriptionEntityRecordId[0];
            A28WWPSubscriptionEntityRecordDes = BC00043_A28WWPSubscriptionEntityRecordDes[0];
            A19WWPSubscriptionRoleId = BC00043_A19WWPSubscriptionRoleId[0];
            n19WWPSubscriptionRoleId = BC00043_n19WWPSubscriptionRoleId[0];
            A27WWPSubscriptionSubscribed = BC00043_A27WWPSubscriptionSubscribed[0];
            A23WWPNotificationDefinitionId = BC00043_A23WWPNotificationDefinitionId[0];
            A7WWPUserExtendedId = BC00043_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = BC00043_n7WWPUserExtendedId[0];
            Z25WWPSubscriptionId = A25WWPSubscriptionId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode4;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_040( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00042 */
            pr_default.execute(0, new Object[] {A25WWPSubscriptionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z26WWPSubscriptionEntityRecordId, BC00042_A26WWPSubscriptionEntityRecordId[0]) != 0 ) || ( StringUtil.StrCmp(Z28WWPSubscriptionEntityRecordDes, BC00042_A28WWPSubscriptionEntityRecordDes[0]) != 0 ) || ( StringUtil.StrCmp(Z19WWPSubscriptionRoleId, BC00042_A19WWPSubscriptionRoleId[0]) != 0 ) || ( Z27WWPSubscriptionSubscribed != BC00042_A27WWPSubscriptionSubscribed[0] ) || ( Z23WWPNotificationDefinitionId != BC00042_A23WWPNotificationDefinitionId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z7WWPUserExtendedId, BC00042_A7WWPUserExtendedId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Subscription"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00049 */
                     pr_default.execute(7, new Object[] {A26WWPSubscriptionEntityRecordId, A28WWPSubscriptionEntityRecordDes, n19WWPSubscriptionRoleId, A19WWPSubscriptionRoleId, A27WWPSubscriptionSubscribed, A23WWPNotificationDefinitionId, n7WWPUserExtendedId, A7WWPUserExtendedId});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000410 */
                     pr_default.execute(8);
                     A25WWPSubscriptionId = BC000410_A25WWPSubscriptionId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000411 */
                     pr_default.execute(9, new Object[] {A26WWPSubscriptionEntityRecordId, A28WWPSubscriptionEntityRecordDes, n19WWPSubscriptionRoleId, A19WWPSubscriptionRoleId, A27WWPSubscriptionSubscribed, A23WWPNotificationDefinitionId, n7WWPUserExtendedId, A7WWPUserExtendedId, A25WWPSubscriptionId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000412 */
                  pr_default.execute(10, new Object[] {A25WWPSubscriptionId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel044( ) ;
         Gx_mode = sMode4;
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000413 */
            pr_default.execute(11, new Object[] {A23WWPNotificationDefinitionId});
            A20WWPEntityId = BC000413_A20WWPEntityId[0];
            A29WWPNotificationDefinitionDescr = BC000413_A29WWPNotificationDefinitionDescr[0];
            pr_default.close(11);
            /* Using cursor BC000414 */
            pr_default.execute(12, new Object[] {A20WWPEntityId});
            A21WWPEntityName = BC000414_A21WWPEntityName[0];
            pr_default.close(12);
            /* Using cursor BC000415 */
            pr_default.execute(13, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
            A8WWPUserExtendedFullName = BC000415_A8WWPUserExtendedFullName[0];
            pr_default.close(13);
         }
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart044( )
      {
         /* Using cursor BC000416 */
         pr_default.execute(14, new Object[] {A25WWPSubscriptionId});
         RcdFound4 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound4 = 1;
            A20WWPEntityId = BC000416_A20WWPEntityId[0];
            A25WWPSubscriptionId = BC000416_A25WWPSubscriptionId[0];
            A29WWPNotificationDefinitionDescr = BC000416_A29WWPNotificationDefinitionDescr[0];
            A21WWPEntityName = BC000416_A21WWPEntityName[0];
            A8WWPUserExtendedFullName = BC000416_A8WWPUserExtendedFullName[0];
            A26WWPSubscriptionEntityRecordId = BC000416_A26WWPSubscriptionEntityRecordId[0];
            A28WWPSubscriptionEntityRecordDes = BC000416_A28WWPSubscriptionEntityRecordDes[0];
            A19WWPSubscriptionRoleId = BC000416_A19WWPSubscriptionRoleId[0];
            n19WWPSubscriptionRoleId = BC000416_n19WWPSubscriptionRoleId[0];
            A27WWPSubscriptionSubscribed = BC000416_A27WWPSubscriptionSubscribed[0];
            A23WWPNotificationDefinitionId = BC000416_A23WWPNotificationDefinitionId[0];
            A7WWPUserExtendedId = BC000416_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = BC000416_n7WWPUserExtendedId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound4 = 0;
         ScanKeyLoad044( ) ;
      }

      protected void ScanKeyLoad044( )
      {
         sMode4 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound4 = 1;
            A20WWPEntityId = BC000416_A20WWPEntityId[0];
            A25WWPSubscriptionId = BC000416_A25WWPSubscriptionId[0];
            A29WWPNotificationDefinitionDescr = BC000416_A29WWPNotificationDefinitionDescr[0];
            A21WWPEntityName = BC000416_A21WWPEntityName[0];
            A8WWPUserExtendedFullName = BC000416_A8WWPUserExtendedFullName[0];
            A26WWPSubscriptionEntityRecordId = BC000416_A26WWPSubscriptionEntityRecordId[0];
            A28WWPSubscriptionEntityRecordDes = BC000416_A28WWPSubscriptionEntityRecordDes[0];
            A19WWPSubscriptionRoleId = BC000416_A19WWPSubscriptionRoleId[0];
            n19WWPSubscriptionRoleId = BC000416_n19WWPSubscriptionRoleId[0];
            A27WWPSubscriptionSubscribed = BC000416_A27WWPSubscriptionSubscribed[0];
            A23WWPNotificationDefinitionId = BC000416_A23WWPNotificationDefinitionId[0];
            A7WWPUserExtendedId = BC000416_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = BC000416_n7WWPUserExtendedId[0];
         }
         Gx_mode = sMode4;
      }

      protected void ScanKeyEnd044( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) )
         {
            A7WWPUserExtendedId = "";
            n7WWPUserExtendedId = false;
            n7WWPUserExtendedId = true;
         }
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void AddRow044( )
      {
         VarsToRow4( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
      }

      protected void ReadRow044( )
      {
         RowToVars4( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
      }

      protected void InitializeNonKey044( )
      {
         A20WWPEntityId = 0;
         A23WWPNotificationDefinitionId = 0;
         A29WWPNotificationDefinitionDescr = "";
         A21WWPEntityName = "";
         A7WWPUserExtendedId = "";
         n7WWPUserExtendedId = false;
         A8WWPUserExtendedFullName = "";
         A26WWPSubscriptionEntityRecordId = "";
         A28WWPSubscriptionEntityRecordDes = "";
         A19WWPSubscriptionRoleId = "";
         n19WWPSubscriptionRoleId = false;
         A27WWPSubscriptionSubscribed = false;
         Z26WWPSubscriptionEntityRecordId = "";
         Z28WWPSubscriptionEntityRecordDes = "";
         Z19WWPSubscriptionRoleId = "";
         Z27WWPSubscriptionSubscribed = false;
         Z23WWPNotificationDefinitionId = 0;
         Z7WWPUserExtendedId = "";
      }

      protected void InitAll044( )
      {
         A25WWPSubscriptionId = 0;
         InitializeNonKey044( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow4( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription obj4 )
      {
         obj4.gxTpr_Mode = Gx_mode;
         obj4.gxTpr_Wwpnotificationdefinitionid = A23WWPNotificationDefinitionId;
         obj4.gxTpr_Wwpnotificationdefinitiondescription = A29WWPNotificationDefinitionDescr;
         obj4.gxTpr_Wwpentityname = A21WWPEntityName;
         obj4.gxTpr_Wwpuserextendedid = A7WWPUserExtendedId;
         obj4.gxTpr_Wwpuserextendedfullname = A8WWPUserExtendedFullName;
         obj4.gxTpr_Wwpsubscriptionentityrecordid = A26WWPSubscriptionEntityRecordId;
         obj4.gxTpr_Wwpsubscriptionentityrecorddescription = A28WWPSubscriptionEntityRecordDes;
         obj4.gxTpr_Wwpsubscriptionroleid = A19WWPSubscriptionRoleId;
         obj4.gxTpr_Wwpsubscriptionsubscribed = A27WWPSubscriptionSubscribed;
         obj4.gxTpr_Wwpsubscriptionid = A25WWPSubscriptionId;
         obj4.gxTpr_Wwpsubscriptionid_Z = Z25WWPSubscriptionId;
         obj4.gxTpr_Wwpnotificationdefinitionid_Z = Z23WWPNotificationDefinitionId;
         obj4.gxTpr_Wwpnotificationdefinitiondescription_Z = Z29WWPNotificationDefinitionDescr;
         obj4.gxTpr_Wwpentityname_Z = Z21WWPEntityName;
         obj4.gxTpr_Wwpuserextendedid_Z = Z7WWPUserExtendedId;
         obj4.gxTpr_Wwpuserextendedfullname_Z = Z8WWPUserExtendedFullName;
         obj4.gxTpr_Wwpsubscriptionentityrecordid_Z = Z26WWPSubscriptionEntityRecordId;
         obj4.gxTpr_Wwpsubscriptionentityrecorddescription_Z = Z28WWPSubscriptionEntityRecordDes;
         obj4.gxTpr_Wwpsubscriptionroleid_Z = Z19WWPSubscriptionRoleId;
         obj4.gxTpr_Wwpsubscriptionsubscribed_Z = Z27WWPSubscriptionSubscribed;
         obj4.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n7WWPUserExtendedId));
         obj4.gxTpr_Wwpsubscriptionroleid_N = (short)(Convert.ToInt16(n19WWPSubscriptionRoleId));
         obj4.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow4( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription obj4 )
      {
         obj4.gxTpr_Wwpsubscriptionid = A25WWPSubscriptionId;
         return  ;
      }

      public void RowToVars4( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription obj4 ,
                              int forceLoad )
      {
         Gx_mode = obj4.gxTpr_Mode;
         A23WWPNotificationDefinitionId = obj4.gxTpr_Wwpnotificationdefinitionid;
         A29WWPNotificationDefinitionDescr = obj4.gxTpr_Wwpnotificationdefinitiondescription;
         A21WWPEntityName = obj4.gxTpr_Wwpentityname;
         A7WWPUserExtendedId = obj4.gxTpr_Wwpuserextendedid;
         n7WWPUserExtendedId = false;
         A8WWPUserExtendedFullName = obj4.gxTpr_Wwpuserextendedfullname;
         A26WWPSubscriptionEntityRecordId = obj4.gxTpr_Wwpsubscriptionentityrecordid;
         A28WWPSubscriptionEntityRecordDes = obj4.gxTpr_Wwpsubscriptionentityrecorddescription;
         A19WWPSubscriptionRoleId = obj4.gxTpr_Wwpsubscriptionroleid;
         n19WWPSubscriptionRoleId = false;
         A27WWPSubscriptionSubscribed = obj4.gxTpr_Wwpsubscriptionsubscribed;
         A25WWPSubscriptionId = obj4.gxTpr_Wwpsubscriptionid;
         Z25WWPSubscriptionId = obj4.gxTpr_Wwpsubscriptionid_Z;
         Z23WWPNotificationDefinitionId = obj4.gxTpr_Wwpnotificationdefinitionid_Z;
         Z29WWPNotificationDefinitionDescr = obj4.gxTpr_Wwpnotificationdefinitiondescription_Z;
         Z21WWPEntityName = obj4.gxTpr_Wwpentityname_Z;
         Z7WWPUserExtendedId = obj4.gxTpr_Wwpuserextendedid_Z;
         Z8WWPUserExtendedFullName = obj4.gxTpr_Wwpuserextendedfullname_Z;
         Z26WWPSubscriptionEntityRecordId = obj4.gxTpr_Wwpsubscriptionentityrecordid_Z;
         Z28WWPSubscriptionEntityRecordDes = obj4.gxTpr_Wwpsubscriptionentityrecorddescription_Z;
         Z19WWPSubscriptionRoleId = obj4.gxTpr_Wwpsubscriptionroleid_Z;
         Z27WWPSubscriptionSubscribed = obj4.gxTpr_Wwpsubscriptionsubscribed_Z;
         n7WWPUserExtendedId = (bool)(Convert.ToBoolean(obj4.gxTpr_Wwpuserextendedid_N));
         n19WWPSubscriptionRoleId = (bool)(Convert.ToBoolean(obj4.gxTpr_Wwpsubscriptionroleid_N));
         Gx_mode = obj4.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A25WWPSubscriptionId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey044( ) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z25WWPSubscriptionId = A25WWPSubscriptionId;
         }
         ZM044( -2) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars4( bcwwpbaseobjects_subscriptions_WWP_Subscription, 0) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z25WWPSubscriptionId = A25WWPSubscriptionId;
         }
         ZM044( -2) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert044( ) ;
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A25WWPSubscriptionId != Z25WWPSubscriptionId )
               {
                  A25WWPSubscriptionId = Z25WWPSubscriptionId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update044( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A25WWPSubscriptionId != Z25WWPSubscriptionId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert044( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert044( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         SaveImpl( ) ;
         VarsToRow4( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
         AfterTrn( ) ;
         VarsToRow4( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow4( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription auxBC = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A25WWPSubscriptionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_subscriptions_WWP_Subscription);
               auxBC.Save();
               bcwwpbaseobjects_subscriptions_WWP_Subscription.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow4( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow4( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcwwpbaseobjects_subscriptions_WWP_Subscription, 0) ;
         GetKey044( ) ;
         if ( RcdFound4 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A25WWPSubscriptionId != Z25WWPSubscriptionId )
            {
               A25WWPSubscriptionId = Z25WWPSubscriptionId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A25WWPSubscriptionId != Z25WWPSubscriptionId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("wwpbaseobjects.subscriptions.wwp_subscription_bc",pr_default);
         VarsToRow4( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_subscriptions_WWP_Subscription )
         {
            bcwwpbaseobjects_subscriptions_WWP_Subscription = (GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow4( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
            }
            else
            {
               RowToVars4( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars4( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_Subscription WWP_Subscription_BC
      {
         get {
            return bcwwpbaseobjects_subscriptions_WWP_Subscription ;
         }

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

      protected override string ExecutePermissionPrefix
      {
         get {
            return "wwpsubscription_Execute" ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(11);
         pr_default.close(13);
         pr_default.close(12);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z26WWPSubscriptionEntityRecordId = "";
         A26WWPSubscriptionEntityRecordId = "";
         Z28WWPSubscriptionEntityRecordDes = "";
         A28WWPSubscriptionEntityRecordDes = "";
         Z19WWPSubscriptionRoleId = "";
         A19WWPSubscriptionRoleId = "";
         Z7WWPUserExtendedId = "";
         A7WWPUserExtendedId = "";
         Z29WWPNotificationDefinitionDescr = "";
         A29WWPNotificationDefinitionDescr = "";
         Z8WWPUserExtendedFullName = "";
         A8WWPUserExtendedFullName = "";
         Z21WWPEntityName = "";
         A21WWPEntityName = "";
         BC00047_A20WWPEntityId = new long[1] ;
         BC00047_A25WWPSubscriptionId = new long[1] ;
         BC00047_A29WWPNotificationDefinitionDescr = new string[] {""} ;
         BC00047_A21WWPEntityName = new string[] {""} ;
         BC00047_A8WWPUserExtendedFullName = new string[] {""} ;
         BC00047_A26WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC00047_A28WWPSubscriptionEntityRecordDes = new string[] {""} ;
         BC00047_A19WWPSubscriptionRoleId = new string[] {""} ;
         BC00047_n19WWPSubscriptionRoleId = new bool[] {false} ;
         BC00047_A27WWPSubscriptionSubscribed = new bool[] {false} ;
         BC00047_A23WWPNotificationDefinitionId = new long[1] ;
         BC00047_A7WWPUserExtendedId = new string[] {""} ;
         BC00047_n7WWPUserExtendedId = new bool[] {false} ;
         BC00044_A20WWPEntityId = new long[1] ;
         BC00044_A29WWPNotificationDefinitionDescr = new string[] {""} ;
         BC00046_A21WWPEntityName = new string[] {""} ;
         BC00045_A8WWPUserExtendedFullName = new string[] {""} ;
         BC00048_A25WWPSubscriptionId = new long[1] ;
         BC00043_A25WWPSubscriptionId = new long[1] ;
         BC00043_A26WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC00043_A28WWPSubscriptionEntityRecordDes = new string[] {""} ;
         BC00043_A19WWPSubscriptionRoleId = new string[] {""} ;
         BC00043_n19WWPSubscriptionRoleId = new bool[] {false} ;
         BC00043_A27WWPSubscriptionSubscribed = new bool[] {false} ;
         BC00043_A23WWPNotificationDefinitionId = new long[1] ;
         BC00043_A7WWPUserExtendedId = new string[] {""} ;
         BC00043_n7WWPUserExtendedId = new bool[] {false} ;
         sMode4 = "";
         BC00042_A25WWPSubscriptionId = new long[1] ;
         BC00042_A26WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC00042_A28WWPSubscriptionEntityRecordDes = new string[] {""} ;
         BC00042_A19WWPSubscriptionRoleId = new string[] {""} ;
         BC00042_n19WWPSubscriptionRoleId = new bool[] {false} ;
         BC00042_A27WWPSubscriptionSubscribed = new bool[] {false} ;
         BC00042_A23WWPNotificationDefinitionId = new long[1] ;
         BC00042_A7WWPUserExtendedId = new string[] {""} ;
         BC00042_n7WWPUserExtendedId = new bool[] {false} ;
         BC000410_A25WWPSubscriptionId = new long[1] ;
         BC000413_A20WWPEntityId = new long[1] ;
         BC000413_A29WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000414_A21WWPEntityName = new string[] {""} ;
         BC000415_A8WWPUserExtendedFullName = new string[] {""} ;
         BC000416_A20WWPEntityId = new long[1] ;
         BC000416_A25WWPSubscriptionId = new long[1] ;
         BC000416_A29WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000416_A21WWPEntityName = new string[] {""} ;
         BC000416_A8WWPUserExtendedFullName = new string[] {""} ;
         BC000416_A26WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC000416_A28WWPSubscriptionEntityRecordDes = new string[] {""} ;
         BC000416_A19WWPSubscriptionRoleId = new string[] {""} ;
         BC000416_n19WWPSubscriptionRoleId = new bool[] {false} ;
         BC000416_A27WWPSubscriptionSubscribed = new bool[] {false} ;
         BC000416_A23WWPNotificationDefinitionId = new long[1] ;
         BC000416_A7WWPUserExtendedId = new string[] {""} ;
         BC000416_n7WWPUserExtendedId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription_bc__default(),
            new Object[][] {
                new Object[] {
               BC00042_A25WWPSubscriptionId, BC00042_A26WWPSubscriptionEntityRecordId, BC00042_A28WWPSubscriptionEntityRecordDes, BC00042_A19WWPSubscriptionRoleId, BC00042_n19WWPSubscriptionRoleId, BC00042_A27WWPSubscriptionSubscribed, BC00042_A23WWPNotificationDefinitionId, BC00042_A7WWPUserExtendedId, BC00042_n7WWPUserExtendedId
               }
               , new Object[] {
               BC00043_A25WWPSubscriptionId, BC00043_A26WWPSubscriptionEntityRecordId, BC00043_A28WWPSubscriptionEntityRecordDes, BC00043_A19WWPSubscriptionRoleId, BC00043_n19WWPSubscriptionRoleId, BC00043_A27WWPSubscriptionSubscribed, BC00043_A23WWPNotificationDefinitionId, BC00043_A7WWPUserExtendedId, BC00043_n7WWPUserExtendedId
               }
               , new Object[] {
               BC00044_A20WWPEntityId, BC00044_A29WWPNotificationDefinitionDescr
               }
               , new Object[] {
               BC00045_A8WWPUserExtendedFullName
               }
               , new Object[] {
               BC00046_A21WWPEntityName
               }
               , new Object[] {
               BC00047_A20WWPEntityId, BC00047_A25WWPSubscriptionId, BC00047_A29WWPNotificationDefinitionDescr, BC00047_A21WWPEntityName, BC00047_A8WWPUserExtendedFullName, BC00047_A26WWPSubscriptionEntityRecordId, BC00047_A28WWPSubscriptionEntityRecordDes, BC00047_A19WWPSubscriptionRoleId, BC00047_n19WWPSubscriptionRoleId, BC00047_A27WWPSubscriptionSubscribed,
               BC00047_A23WWPNotificationDefinitionId, BC00047_A7WWPUserExtendedId, BC00047_n7WWPUserExtendedId
               }
               , new Object[] {
               BC00048_A25WWPSubscriptionId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000410_A25WWPSubscriptionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000413_A20WWPEntityId, BC000413_A29WWPNotificationDefinitionDescr
               }
               , new Object[] {
               BC000414_A21WWPEntityName
               }
               , new Object[] {
               BC000415_A8WWPUserExtendedFullName
               }
               , new Object[] {
               BC000416_A20WWPEntityId, BC000416_A25WWPSubscriptionId, BC000416_A29WWPNotificationDefinitionDescr, BC000416_A21WWPEntityName, BC000416_A8WWPUserExtendedFullName, BC000416_A26WWPSubscriptionEntityRecordId, BC000416_A28WWPSubscriptionEntityRecordDes, BC000416_A19WWPSubscriptionRoleId, BC000416_n19WWPSubscriptionRoleId, BC000416_A27WWPSubscriptionSubscribed,
               BC000416_A23WWPNotificationDefinitionId, BC000416_A7WWPUserExtendedId, BC000416_n7WWPUserExtendedId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound4 ;
      private int trnEnded ;
      private long Z25WWPSubscriptionId ;
      private long A25WWPSubscriptionId ;
      private long Z23WWPNotificationDefinitionId ;
      private long A23WWPNotificationDefinitionId ;
      private long Z20WWPEntityId ;
      private long A20WWPEntityId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z19WWPSubscriptionRoleId ;
      private string A19WWPSubscriptionRoleId ;
      private string Z7WWPUserExtendedId ;
      private string A7WWPUserExtendedId ;
      private string sMode4 ;
      private bool Z27WWPSubscriptionSubscribed ;
      private bool A27WWPSubscriptionSubscribed ;
      private bool n19WWPSubscriptionRoleId ;
      private bool n7WWPUserExtendedId ;
      private bool Gx_longc ;
      private string Z26WWPSubscriptionEntityRecordId ;
      private string A26WWPSubscriptionEntityRecordId ;
      private string Z28WWPSubscriptionEntityRecordDes ;
      private string A28WWPSubscriptionEntityRecordDes ;
      private string Z29WWPNotificationDefinitionDescr ;
      private string A29WWPNotificationDefinitionDescr ;
      private string Z8WWPUserExtendedFullName ;
      private string A8WWPUserExtendedFullName ;
      private string Z21WWPEntityName ;
      private string A21WWPEntityName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00047_A20WWPEntityId ;
      private long[] BC00047_A25WWPSubscriptionId ;
      private string[] BC00047_A29WWPNotificationDefinitionDescr ;
      private string[] BC00047_A21WWPEntityName ;
      private string[] BC00047_A8WWPUserExtendedFullName ;
      private string[] BC00047_A26WWPSubscriptionEntityRecordId ;
      private string[] BC00047_A28WWPSubscriptionEntityRecordDes ;
      private string[] BC00047_A19WWPSubscriptionRoleId ;
      private bool[] BC00047_n19WWPSubscriptionRoleId ;
      private bool[] BC00047_A27WWPSubscriptionSubscribed ;
      private long[] BC00047_A23WWPNotificationDefinitionId ;
      private string[] BC00047_A7WWPUserExtendedId ;
      private bool[] BC00047_n7WWPUserExtendedId ;
      private long[] BC00044_A20WWPEntityId ;
      private string[] BC00044_A29WWPNotificationDefinitionDescr ;
      private string[] BC00046_A21WWPEntityName ;
      private string[] BC00045_A8WWPUserExtendedFullName ;
      private long[] BC00048_A25WWPSubscriptionId ;
      private long[] BC00043_A25WWPSubscriptionId ;
      private string[] BC00043_A26WWPSubscriptionEntityRecordId ;
      private string[] BC00043_A28WWPSubscriptionEntityRecordDes ;
      private string[] BC00043_A19WWPSubscriptionRoleId ;
      private bool[] BC00043_n19WWPSubscriptionRoleId ;
      private bool[] BC00043_A27WWPSubscriptionSubscribed ;
      private long[] BC00043_A23WWPNotificationDefinitionId ;
      private string[] BC00043_A7WWPUserExtendedId ;
      private bool[] BC00043_n7WWPUserExtendedId ;
      private long[] BC00042_A25WWPSubscriptionId ;
      private string[] BC00042_A26WWPSubscriptionEntityRecordId ;
      private string[] BC00042_A28WWPSubscriptionEntityRecordDes ;
      private string[] BC00042_A19WWPSubscriptionRoleId ;
      private bool[] BC00042_n19WWPSubscriptionRoleId ;
      private bool[] BC00042_A27WWPSubscriptionSubscribed ;
      private long[] BC00042_A23WWPNotificationDefinitionId ;
      private string[] BC00042_A7WWPUserExtendedId ;
      private bool[] BC00042_n7WWPUserExtendedId ;
      private long[] BC000410_A25WWPSubscriptionId ;
      private long[] BC000413_A20WWPEntityId ;
      private string[] BC000413_A29WWPNotificationDefinitionDescr ;
      private string[] BC000414_A21WWPEntityName ;
      private string[] BC000415_A8WWPUserExtendedFullName ;
      private long[] BC000416_A20WWPEntityId ;
      private long[] BC000416_A25WWPSubscriptionId ;
      private string[] BC000416_A29WWPNotificationDefinitionDescr ;
      private string[] BC000416_A21WWPEntityName ;
      private string[] BC000416_A8WWPUserExtendedFullName ;
      private string[] BC000416_A26WWPSubscriptionEntityRecordId ;
      private string[] BC000416_A28WWPSubscriptionEntityRecordDes ;
      private string[] BC000416_A19WWPSubscriptionRoleId ;
      private bool[] BC000416_n19WWPSubscriptionRoleId ;
      private bool[] BC000416_A27WWPSubscriptionSubscribed ;
      private long[] BC000416_A23WWPNotificationDefinitionId ;
      private string[] BC000416_A7WWPUserExtendedId ;
      private bool[] BC000416_n7WWPUserExtendedId ;
      private GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription bcwwpbaseobjects_subscriptions_WWP_Subscription ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_subscription_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_subscription_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
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
       ,new ForEachCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00042;
        prmBC00042 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmBC00043;
        prmBC00043 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmBC00044;
        prmBC00044 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC00045;
        prmBC00045 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00046;
        prmBC00046 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC00047;
        prmBC00047 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmBC00048;
        prmBC00048 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmBC00049;
        prmBC00049 = new Object[] {
        new ParDef("WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0) ,
        new ParDef("WWPSubscriptionEntityRecordDes",GXType.VarChar,200,0) ,
        new ParDef("WWPSubscriptionRoleId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPSubscriptionSubscribed",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000410;
        prmBC000410 = new Object[] {
        };
        Object[] prmBC000411;
        prmBC000411 = new Object[] {
        new ParDef("WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0) ,
        new ParDef("WWPSubscriptionEntityRecordDes",GXType.VarChar,200,0) ,
        new ParDef("WWPSubscriptionRoleId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPSubscriptionSubscribed",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmBC000412;
        prmBC000412 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmBC000413;
        prmBC000413 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000414;
        prmBC000414 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC000415;
        prmBC000415 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000416;
        prmBC000416 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00042", "SELECT WWPSubscriptionId, WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId  FOR UPDATE OF WWP_Subscription",true, GxErrorMask.GX_NOMASK, false, this,prmBC00042,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00043", "SELECT WWPSubscriptionId, WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00043,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00044", "SELECT WWPEntityId, WWPNotificationDefinitionDescr FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00044,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00045", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00045,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00046", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00046,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00047", "SELECT T2.WWPEntityId, TM1.WWPSubscriptionId, T2.WWPNotificationDefinitionDescr, T3.WWPEntityName, T4.WWPUserExtendedFullName, TM1.WWPSubscriptionEntityRecordId, TM1.WWPSubscriptionEntityRecordDes, TM1.WWPSubscriptionRoleId, TM1.WWPSubscriptionSubscribed, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM (((WWP_Subscription TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) INNER JOIN WWP_Entity T3 ON T3.WWPEntityId = T2.WWPEntityId) LEFT JOIN WWP_UserExtended T4 ON T4.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPSubscriptionId = :WWPSubscriptionId ORDER BY TM1.WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00047,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00048", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00048,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00049", "SAVEPOINT gxupdate;INSERT INTO WWP_Subscription(WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId) VALUES(:WWPSubscriptionEntityRecordId, :WWPSubscriptionEntityRecordDes, :WWPSubscriptionRoleId, :WWPSubscriptionSubscribed, :WWPNotificationDefinitionId, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00049)
           ,new CursorDef("BC000410", "SELECT currval('WWPSubscriptionId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000410,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000411", "SAVEPOINT gxupdate;UPDATE WWP_Subscription SET WWPSubscriptionEntityRecordId=:WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes=:WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId=:WWPSubscriptionRoleId, WWPSubscriptionSubscribed=:WWPSubscriptionSubscribed, WWPNotificationDefinitionId=:WWPNotificationDefinitionId, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPSubscriptionId = :WWPSubscriptionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000411)
           ,new CursorDef("BC000412", "SAVEPOINT gxupdate;DELETE FROM WWP_Subscription  WHERE WWPSubscriptionId = :WWPSubscriptionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000412)
           ,new CursorDef("BC000413", "SELECT WWPEntityId, WWPNotificationDefinitionDescr FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000413,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000414", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000414,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000415", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000415,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000416", "SELECT T2.WWPEntityId, TM1.WWPSubscriptionId, T2.WWPNotificationDefinitionDescr, T3.WWPEntityName, T4.WWPUserExtendedFullName, TM1.WWPSubscriptionEntityRecordId, TM1.WWPSubscriptionEntityRecordDes, TM1.WWPSubscriptionRoleId, TM1.WWPSubscriptionSubscribed, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM (((WWP_Subscription TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) INNER JOIN WWP_Entity T3 ON T3.WWPEntityId = T2.WWPEntityId) LEFT JOIN WWP_UserExtended T4 ON T4.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPSubscriptionId = :WWPSubscriptionId ORDER BY TM1.WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000416,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((bool[]) buf[5])[0] = rslt.getBool(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((bool[]) buf[5])[0] = rslt.getBool(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((bool[]) buf[9])[0] = rslt.getBool(9);
              ((long[]) buf[10])[0] = rslt.getLong(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 40);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((bool[]) buf[9])[0] = rslt.getBool(9);
              ((long[]) buf[10])[0] = rslt.getLong(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 40);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              return;
     }
  }

}

}
