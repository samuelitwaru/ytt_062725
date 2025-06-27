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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_notificationdefinition_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_notificationdefinition_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_notificationdefinition_bc( IGxContext context )
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
         ReadRow088( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey088( ) ;
         standaloneModal( ) ;
         AddRow088( ) ;
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
               Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
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

      protected void CONFIRM_080( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls088( ) ;
            }
            else
            {
               CheckExtendedTable088( ) ;
               if ( AnyError == 0 )
               {
                  ZM088( 5) ;
               }
               CloseExtendedTableCursors088( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM088( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z59WWPNotificationDefinitionName = A59WWPNotificationDefinitionName;
            Z30WWPNotificationDefinitionAppli = A30WWPNotificationDefinitionAppli;
            Z31WWPNotificationDefinitionAllow = A31WWPNotificationDefinitionAllow;
            Z29WWPNotificationDefinitionDescr = A29WWPNotificationDefinitionDescr;
            Z62WWPNotificationDefinitionIcon = A62WWPNotificationDefinitionIcon;
            Z63WWPNotificationDefinitionTitle = A63WWPNotificationDefinitionTitle;
            Z64WWPNotificationDefinitionShort = A64WWPNotificationDefinitionShort;
            Z65WWPNotificationDefinitionLongD = A65WWPNotificationDefinitionLongD;
            Z66WWPNotificationDefinitionLink = A66WWPNotificationDefinitionLink;
            Z67WWPNotificationDefinitionSecFu = A67WWPNotificationDefinitionSecFu;
            Z20WWPEntityId = A20WWPEntityId;
            Z68WWPNotificationDefinitionIsAut = A68WWPNotificationDefinitionIsAut;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z21WWPEntityName = A21WWPEntityName;
            Z68WWPNotificationDefinitionIsAut = A68WWPNotificationDefinitionIsAut;
         }
         if ( GX_JID == -4 )
         {
            Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
            Z59WWPNotificationDefinitionName = A59WWPNotificationDefinitionName;
            Z30WWPNotificationDefinitionAppli = A30WWPNotificationDefinitionAppli;
            Z31WWPNotificationDefinitionAllow = A31WWPNotificationDefinitionAllow;
            Z29WWPNotificationDefinitionDescr = A29WWPNotificationDefinitionDescr;
            Z62WWPNotificationDefinitionIcon = A62WWPNotificationDefinitionIcon;
            Z63WWPNotificationDefinitionTitle = A63WWPNotificationDefinitionTitle;
            Z64WWPNotificationDefinitionShort = A64WWPNotificationDefinitionShort;
            Z65WWPNotificationDefinitionLongD = A65WWPNotificationDefinitionLongD;
            Z66WWPNotificationDefinitionLink = A66WWPNotificationDefinitionLink;
            Z67WWPNotificationDefinitionSecFu = A67WWPNotificationDefinitionSecFu;
            Z20WWPEntityId = A20WWPEntityId;
            Z21WWPEntityName = A21WWPEntityName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load088( )
      {
         /* Using cursor BC00085 */
         pr_default.execute(3, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound8 = 1;
            A59WWPNotificationDefinitionName = BC00085_A59WWPNotificationDefinitionName[0];
            A30WWPNotificationDefinitionAppli = BC00085_A30WWPNotificationDefinitionAppli[0];
            A31WWPNotificationDefinitionAllow = BC00085_A31WWPNotificationDefinitionAllow[0];
            A29WWPNotificationDefinitionDescr = BC00085_A29WWPNotificationDefinitionDescr[0];
            A62WWPNotificationDefinitionIcon = BC00085_A62WWPNotificationDefinitionIcon[0];
            A63WWPNotificationDefinitionTitle = BC00085_A63WWPNotificationDefinitionTitle[0];
            A64WWPNotificationDefinitionShort = BC00085_A64WWPNotificationDefinitionShort[0];
            A65WWPNotificationDefinitionLongD = BC00085_A65WWPNotificationDefinitionLongD[0];
            A66WWPNotificationDefinitionLink = BC00085_A66WWPNotificationDefinitionLink[0];
            A21WWPEntityName = BC00085_A21WWPEntityName[0];
            A67WWPNotificationDefinitionSecFu = BC00085_A67WWPNotificationDefinitionSecFu[0];
            A20WWPEntityId = BC00085_A20WWPEntityId[0];
            ZM088( -4) ;
         }
         pr_default.close(3);
         OnLoadActions088( ) ;
      }

      protected void OnLoadActions088( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A67WWPNotificationDefinitionSecFu)) )
         {
            A68WWPNotificationDefinitionIsAut = true;
         }
         else
         {
            GXt_boolean1 = A68WWPNotificationDefinitionIsAut;
            new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A67WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A68WWPNotificationDefinitionIsAut = GXt_boolean1;
         }
      }

      protected void CheckExtendedTable088( )
      {
         standaloneModal( ) ;
         if ( ! ( ( A30WWPNotificationDefinitionAppli == 1 ) || ( A30WWPNotificationDefinitionAppli == 2 ) ) )
         {
            GX_msglist.addItem("Field Notification Definition Applies To is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A66WWPNotificationDefinitionLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem("Field Notification Definition Default Link does not match the specified pattern", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00084 */
         pr_default.execute(2, new Object[] {A20WWPEntityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'WWP_Entity'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A21WWPEntityName = BC00084_A21WWPEntityName[0];
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A67WWPNotificationDefinitionSecFu)) )
         {
            A68WWPNotificationDefinitionIsAut = true;
         }
         else
         {
            GXt_boolean1 = A68WWPNotificationDefinitionIsAut;
            new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A67WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A68WWPNotificationDefinitionIsAut = GXt_boolean1;
         }
      }

      protected void CloseExtendedTableCursors088( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey088( )
      {
         /* Using cursor BC00086 */
         pr_default.execute(4, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00083 */
         pr_default.execute(1, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM088( 4) ;
            RcdFound8 = 1;
            A23WWPNotificationDefinitionId = BC00083_A23WWPNotificationDefinitionId[0];
            A59WWPNotificationDefinitionName = BC00083_A59WWPNotificationDefinitionName[0];
            A30WWPNotificationDefinitionAppli = BC00083_A30WWPNotificationDefinitionAppli[0];
            A31WWPNotificationDefinitionAllow = BC00083_A31WWPNotificationDefinitionAllow[0];
            A29WWPNotificationDefinitionDescr = BC00083_A29WWPNotificationDefinitionDescr[0];
            A62WWPNotificationDefinitionIcon = BC00083_A62WWPNotificationDefinitionIcon[0];
            A63WWPNotificationDefinitionTitle = BC00083_A63WWPNotificationDefinitionTitle[0];
            A64WWPNotificationDefinitionShort = BC00083_A64WWPNotificationDefinitionShort[0];
            A65WWPNotificationDefinitionLongD = BC00083_A65WWPNotificationDefinitionLongD[0];
            A66WWPNotificationDefinitionLink = BC00083_A66WWPNotificationDefinitionLink[0];
            A67WWPNotificationDefinitionSecFu = BC00083_A67WWPNotificationDefinitionSecFu[0];
            A20WWPEntityId = BC00083_A20WWPEntityId[0];
            Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load088( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey088( ) ;
            }
            Gx_mode = sMode8;
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey088( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode8;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey088( ) ;
         if ( RcdFound8 == 0 )
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
         CONFIRM_080( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency088( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00082 */
            pr_default.execute(0, new Object[] {A23WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z59WWPNotificationDefinitionName, BC00082_A59WWPNotificationDefinitionName[0]) != 0 ) || ( Z30WWPNotificationDefinitionAppli != BC00082_A30WWPNotificationDefinitionAppli[0] ) || ( Z31WWPNotificationDefinitionAllow != BC00082_A31WWPNotificationDefinitionAllow[0] ) || ( StringUtil.StrCmp(Z29WWPNotificationDefinitionDescr, BC00082_A29WWPNotificationDefinitionDescr[0]) != 0 ) || ( StringUtil.StrCmp(Z62WWPNotificationDefinitionIcon, BC00082_A62WWPNotificationDefinitionIcon[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z63WWPNotificationDefinitionTitle, BC00082_A63WWPNotificationDefinitionTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z64WWPNotificationDefinitionShort, BC00082_A64WWPNotificationDefinitionShort[0]) != 0 ) || ( StringUtil.StrCmp(Z65WWPNotificationDefinitionLongD, BC00082_A65WWPNotificationDefinitionLongD[0]) != 0 ) || ( StringUtil.StrCmp(Z66WWPNotificationDefinitionLink, BC00082_A66WWPNotificationDefinitionLink[0]) != 0 ) || ( StringUtil.StrCmp(Z67WWPNotificationDefinitionSecFu, BC00082_A67WWPNotificationDefinitionSecFu[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z20WWPEntityId != BC00082_A20WWPEntityId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_NotificationDefinition"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM088( 0) ;
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00087 */
                     pr_default.execute(5, new Object[] {A59WWPNotificationDefinitionName, A30WWPNotificationDefinitionAppli, A31WWPNotificationDefinitionAllow, A29WWPNotificationDefinitionDescr, A62WWPNotificationDefinitionIcon, A63WWPNotificationDefinitionTitle, A64WWPNotificationDefinitionShort, A65WWPNotificationDefinitionLongD, A66WWPNotificationDefinitionLink, A67WWPNotificationDefinitionSecFu, A20WWPEntityId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00088 */
                     pr_default.execute(6);
                     A23WWPNotificationDefinitionId = BC00088_A23WWPNotificationDefinitionId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
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
               Load088( ) ;
            }
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void Update088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00089 */
                     pr_default.execute(7, new Object[] {A59WWPNotificationDefinitionName, A30WWPNotificationDefinitionAppli, A31WWPNotificationDefinitionAllow, A29WWPNotificationDefinitionDescr, A62WWPNotificationDefinitionIcon, A63WWPNotificationDefinitionTitle, A64WWPNotificationDefinitionShort, A65WWPNotificationDefinitionLongD, A66WWPNotificationDefinitionLink, A67WWPNotificationDefinitionSecFu, A20WWPEntityId, A23WWPNotificationDefinitionId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate088( ) ;
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
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void DeferredUpdate088( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls088( ) ;
            AfterConfirm088( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete088( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000810 */
                  pr_default.execute(8, new Object[] {A23WWPNotificationDefinitionId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel088( ) ;
         Gx_mode = sMode8;
      }

      protected void OnDeleteControls088( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000811 */
            pr_default.execute(9, new Object[] {A20WWPEntityId});
            A21WWPEntityName = BC000811_A21WWPEntityName[0];
            pr_default.close(9);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A67WWPNotificationDefinitionSecFu)) )
            {
               A68WWPNotificationDefinitionIsAut = true;
            }
            else
            {
               GXt_boolean1 = A68WWPNotificationDefinitionIsAut;
               new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A67WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
               A68WWPNotificationDefinitionIsAut = GXt_boolean1;
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000812 */
            pr_default.execute(10, new Object[] {A23WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Notification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000813 */
            pr_default.execute(11, new Object[] {A23WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Subscription"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel088( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete088( ) ;
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

      public void ScanKeyStart088( )
      {
         /* Using cursor BC000814 */
         pr_default.execute(12, new Object[] {A23WWPNotificationDefinitionId});
         RcdFound8 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound8 = 1;
            A23WWPNotificationDefinitionId = BC000814_A23WWPNotificationDefinitionId[0];
            A59WWPNotificationDefinitionName = BC000814_A59WWPNotificationDefinitionName[0];
            A30WWPNotificationDefinitionAppli = BC000814_A30WWPNotificationDefinitionAppli[0];
            A31WWPNotificationDefinitionAllow = BC000814_A31WWPNotificationDefinitionAllow[0];
            A29WWPNotificationDefinitionDescr = BC000814_A29WWPNotificationDefinitionDescr[0];
            A62WWPNotificationDefinitionIcon = BC000814_A62WWPNotificationDefinitionIcon[0];
            A63WWPNotificationDefinitionTitle = BC000814_A63WWPNotificationDefinitionTitle[0];
            A64WWPNotificationDefinitionShort = BC000814_A64WWPNotificationDefinitionShort[0];
            A65WWPNotificationDefinitionLongD = BC000814_A65WWPNotificationDefinitionLongD[0];
            A66WWPNotificationDefinitionLink = BC000814_A66WWPNotificationDefinitionLink[0];
            A21WWPEntityName = BC000814_A21WWPEntityName[0];
            A67WWPNotificationDefinitionSecFu = BC000814_A67WWPNotificationDefinitionSecFu[0];
            A20WWPEntityId = BC000814_A20WWPEntityId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext088( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound8 = 0;
         ScanKeyLoad088( ) ;
      }

      protected void ScanKeyLoad088( )
      {
         sMode8 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound8 = 1;
            A23WWPNotificationDefinitionId = BC000814_A23WWPNotificationDefinitionId[0];
            A59WWPNotificationDefinitionName = BC000814_A59WWPNotificationDefinitionName[0];
            A30WWPNotificationDefinitionAppli = BC000814_A30WWPNotificationDefinitionAppli[0];
            A31WWPNotificationDefinitionAllow = BC000814_A31WWPNotificationDefinitionAllow[0];
            A29WWPNotificationDefinitionDescr = BC000814_A29WWPNotificationDefinitionDescr[0];
            A62WWPNotificationDefinitionIcon = BC000814_A62WWPNotificationDefinitionIcon[0];
            A63WWPNotificationDefinitionTitle = BC000814_A63WWPNotificationDefinitionTitle[0];
            A64WWPNotificationDefinitionShort = BC000814_A64WWPNotificationDefinitionShort[0];
            A65WWPNotificationDefinitionLongD = BC000814_A65WWPNotificationDefinitionLongD[0];
            A66WWPNotificationDefinitionLink = BC000814_A66WWPNotificationDefinitionLink[0];
            A21WWPEntityName = BC000814_A21WWPEntityName[0];
            A67WWPNotificationDefinitionSecFu = BC000814_A67WWPNotificationDefinitionSecFu[0];
            A20WWPEntityId = BC000814_A20WWPEntityId[0];
         }
         Gx_mode = sMode8;
      }

      protected void ScanKeyEnd088( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm088( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert088( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate088( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete088( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete088( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate088( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes088( )
      {
      }

      protected void send_integrity_lvl_hashes088( )
      {
      }

      protected void AddRow088( )
      {
         VarsToRow8( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
      }

      protected void ReadRow088( )
      {
         RowToVars8( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
      }

      protected void InitializeNonKey088( )
      {
         A68WWPNotificationDefinitionIsAut = false;
         A59WWPNotificationDefinitionName = "";
         A30WWPNotificationDefinitionAppli = 0;
         A31WWPNotificationDefinitionAllow = false;
         A29WWPNotificationDefinitionDescr = "";
         A62WWPNotificationDefinitionIcon = "";
         A63WWPNotificationDefinitionTitle = "";
         A64WWPNotificationDefinitionShort = "";
         A65WWPNotificationDefinitionLongD = "";
         A66WWPNotificationDefinitionLink = "";
         A20WWPEntityId = 0;
         A21WWPEntityName = "";
         A67WWPNotificationDefinitionSecFu = "";
         Z59WWPNotificationDefinitionName = "";
         Z30WWPNotificationDefinitionAppli = 0;
         Z31WWPNotificationDefinitionAllow = false;
         Z29WWPNotificationDefinitionDescr = "";
         Z62WWPNotificationDefinitionIcon = "";
         Z63WWPNotificationDefinitionTitle = "";
         Z64WWPNotificationDefinitionShort = "";
         Z65WWPNotificationDefinitionLongD = "";
         Z66WWPNotificationDefinitionLink = "";
         Z67WWPNotificationDefinitionSecFu = "";
         Z20WWPEntityId = 0;
      }

      protected void InitAll088( )
      {
         A23WWPNotificationDefinitionId = 0;
         InitializeNonKey088( ) ;
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

      public void VarsToRow8( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition obj8 )
      {
         obj8.gxTpr_Mode = Gx_mode;
         obj8.gxTpr_Wwpnotificationdefinitionisauthorized = A68WWPNotificationDefinitionIsAut;
         obj8.gxTpr_Wwpnotificationdefinitionname = A59WWPNotificationDefinitionName;
         obj8.gxTpr_Wwpnotificationdefinitionappliesto = A30WWPNotificationDefinitionAppli;
         obj8.gxTpr_Wwpnotificationdefinitionallowusersubscription = A31WWPNotificationDefinitionAllow;
         obj8.gxTpr_Wwpnotificationdefinitiondescription = A29WWPNotificationDefinitionDescr;
         obj8.gxTpr_Wwpnotificationdefinitionicon = A62WWPNotificationDefinitionIcon;
         obj8.gxTpr_Wwpnotificationdefinitiontitle = A63WWPNotificationDefinitionTitle;
         obj8.gxTpr_Wwpnotificationdefinitionshortdescription = A64WWPNotificationDefinitionShort;
         obj8.gxTpr_Wwpnotificationdefinitionlongdescription = A65WWPNotificationDefinitionLongD;
         obj8.gxTpr_Wwpnotificationdefinitionlink = A66WWPNotificationDefinitionLink;
         obj8.gxTpr_Wwpentityid = A20WWPEntityId;
         obj8.gxTpr_Wwpentityname = A21WWPEntityName;
         obj8.gxTpr_Wwpnotificationdefinitionsecfuncionality = A67WWPNotificationDefinitionSecFu;
         obj8.gxTpr_Wwpnotificationdefinitionid = A23WWPNotificationDefinitionId;
         obj8.gxTpr_Wwpnotificationdefinitionid_Z = Z23WWPNotificationDefinitionId;
         obj8.gxTpr_Wwpnotificationdefinitionname_Z = Z59WWPNotificationDefinitionName;
         obj8.gxTpr_Wwpnotificationdefinitionappliesto_Z = Z30WWPNotificationDefinitionAppli;
         obj8.gxTpr_Wwpnotificationdefinitionallowusersubscription_Z = Z31WWPNotificationDefinitionAllow;
         obj8.gxTpr_Wwpnotificationdefinitiondescription_Z = Z29WWPNotificationDefinitionDescr;
         obj8.gxTpr_Wwpnotificationdefinitionicon_Z = Z62WWPNotificationDefinitionIcon;
         obj8.gxTpr_Wwpnotificationdefinitiontitle_Z = Z63WWPNotificationDefinitionTitle;
         obj8.gxTpr_Wwpnotificationdefinitionshortdescription_Z = Z64WWPNotificationDefinitionShort;
         obj8.gxTpr_Wwpnotificationdefinitionlongdescription_Z = Z65WWPNotificationDefinitionLongD;
         obj8.gxTpr_Wwpnotificationdefinitionlink_Z = Z66WWPNotificationDefinitionLink;
         obj8.gxTpr_Wwpentityid_Z = Z20WWPEntityId;
         obj8.gxTpr_Wwpentityname_Z = Z21WWPEntityName;
         obj8.gxTpr_Wwpnotificationdefinitionsecfuncionality_Z = Z67WWPNotificationDefinitionSecFu;
         obj8.gxTpr_Wwpnotificationdefinitionisauthorized_Z = Z68WWPNotificationDefinitionIsAut;
         obj8.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow8( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition obj8 )
      {
         obj8.gxTpr_Wwpnotificationdefinitionid = A23WWPNotificationDefinitionId;
         return  ;
      }

      public void RowToVars8( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition obj8 ,
                              int forceLoad )
      {
         Gx_mode = obj8.gxTpr_Mode;
         A68WWPNotificationDefinitionIsAut = obj8.gxTpr_Wwpnotificationdefinitionisauthorized;
         A59WWPNotificationDefinitionName = obj8.gxTpr_Wwpnotificationdefinitionname;
         A30WWPNotificationDefinitionAppli = obj8.gxTpr_Wwpnotificationdefinitionappliesto;
         A31WWPNotificationDefinitionAllow = obj8.gxTpr_Wwpnotificationdefinitionallowusersubscription;
         A29WWPNotificationDefinitionDescr = obj8.gxTpr_Wwpnotificationdefinitiondescription;
         A62WWPNotificationDefinitionIcon = obj8.gxTpr_Wwpnotificationdefinitionicon;
         A63WWPNotificationDefinitionTitle = obj8.gxTpr_Wwpnotificationdefinitiontitle;
         A64WWPNotificationDefinitionShort = obj8.gxTpr_Wwpnotificationdefinitionshortdescription;
         A65WWPNotificationDefinitionLongD = obj8.gxTpr_Wwpnotificationdefinitionlongdescription;
         A66WWPNotificationDefinitionLink = obj8.gxTpr_Wwpnotificationdefinitionlink;
         A20WWPEntityId = obj8.gxTpr_Wwpentityid;
         A21WWPEntityName = obj8.gxTpr_Wwpentityname;
         A67WWPNotificationDefinitionSecFu = obj8.gxTpr_Wwpnotificationdefinitionsecfuncionality;
         A23WWPNotificationDefinitionId = obj8.gxTpr_Wwpnotificationdefinitionid;
         Z23WWPNotificationDefinitionId = obj8.gxTpr_Wwpnotificationdefinitionid_Z;
         Z59WWPNotificationDefinitionName = obj8.gxTpr_Wwpnotificationdefinitionname_Z;
         Z30WWPNotificationDefinitionAppli = obj8.gxTpr_Wwpnotificationdefinitionappliesto_Z;
         Z31WWPNotificationDefinitionAllow = obj8.gxTpr_Wwpnotificationdefinitionallowusersubscription_Z;
         Z29WWPNotificationDefinitionDescr = obj8.gxTpr_Wwpnotificationdefinitiondescription_Z;
         Z62WWPNotificationDefinitionIcon = obj8.gxTpr_Wwpnotificationdefinitionicon_Z;
         Z63WWPNotificationDefinitionTitle = obj8.gxTpr_Wwpnotificationdefinitiontitle_Z;
         Z64WWPNotificationDefinitionShort = obj8.gxTpr_Wwpnotificationdefinitionshortdescription_Z;
         Z65WWPNotificationDefinitionLongD = obj8.gxTpr_Wwpnotificationdefinitionlongdescription_Z;
         Z66WWPNotificationDefinitionLink = obj8.gxTpr_Wwpnotificationdefinitionlink_Z;
         Z20WWPEntityId = obj8.gxTpr_Wwpentityid_Z;
         Z21WWPEntityName = obj8.gxTpr_Wwpentityname_Z;
         Z67WWPNotificationDefinitionSecFu = obj8.gxTpr_Wwpnotificationdefinitionsecfuncionality_Z;
         Z68WWPNotificationDefinitionIsAut = obj8.gxTpr_Wwpnotificationdefinitionisauthorized_Z;
         Gx_mode = obj8.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A23WWPNotificationDefinitionId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey088( ) ;
         ScanKeyStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
         }
         ZM088( -4) ;
         OnLoadActions088( ) ;
         AddRow088( ) ;
         ScanKeyEnd088( ) ;
         if ( RcdFound8 == 0 )
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
         RowToVars8( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 0) ;
         ScanKeyStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
         }
         ZM088( -4) ;
         OnLoadActions088( ) ;
         AddRow088( ) ;
         ScanKeyEnd088( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey088( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert088( ) ;
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A23WWPNotificationDefinitionId != Z23WWPNotificationDefinitionId )
               {
                  A23WWPNotificationDefinitionId = Z23WWPNotificationDefinitionId;
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
                  Update088( ) ;
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
                  if ( A23WWPNotificationDefinitionId != Z23WWPNotificationDefinitionId )
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
                        Insert088( ) ;
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
                        Insert088( ) ;
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
         RowToVars8( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         SaveImpl( ) ;
         VarsToRow8( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars8( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert088( ) ;
         AfterTrn( ) ;
         VarsToRow8( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow8( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A23WWPNotificationDefinitionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition);
               auxBC.Save();
               bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars8( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
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
         RowToVars8( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert088( ) ;
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
               VarsToRow8( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow8( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
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
         RowToVars8( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 0) ;
         GetKey088( ) ;
         if ( RcdFound8 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A23WWPNotificationDefinitionId != Z23WWPNotificationDefinitionId )
            {
               A23WWPNotificationDefinitionId = Z23WWPNotificationDefinitionId;
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
            if ( A23WWPNotificationDefinitionId != Z23WWPNotificationDefinitionId )
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
         context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notificationdefinition_bc",pr_default);
         VarsToRow8( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition )
         {
            bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition = (GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow8( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
            }
            else
            {
               RowToVars8( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars8( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_NotificationDefinition WWP_NotificationDefinition_BC
      {
         get {
            return bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition ;
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
            return "wwpnotificationdefinition_Execute" ;
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
         pr_default.close(9);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z59WWPNotificationDefinitionName = "";
         A59WWPNotificationDefinitionName = "";
         Z29WWPNotificationDefinitionDescr = "";
         A29WWPNotificationDefinitionDescr = "";
         Z62WWPNotificationDefinitionIcon = "";
         A62WWPNotificationDefinitionIcon = "";
         Z63WWPNotificationDefinitionTitle = "";
         A63WWPNotificationDefinitionTitle = "";
         Z64WWPNotificationDefinitionShort = "";
         A64WWPNotificationDefinitionShort = "";
         Z65WWPNotificationDefinitionLongD = "";
         A65WWPNotificationDefinitionLongD = "";
         Z66WWPNotificationDefinitionLink = "";
         A66WWPNotificationDefinitionLink = "";
         Z67WWPNotificationDefinitionSecFu = "";
         A67WWPNotificationDefinitionSecFu = "";
         Z21WWPEntityName = "";
         A21WWPEntityName = "";
         BC00085_A23WWPNotificationDefinitionId = new long[1] ;
         BC00085_A59WWPNotificationDefinitionName = new string[] {""} ;
         BC00085_A30WWPNotificationDefinitionAppli = new short[1] ;
         BC00085_A31WWPNotificationDefinitionAllow = new bool[] {false} ;
         BC00085_A29WWPNotificationDefinitionDescr = new string[] {""} ;
         BC00085_A62WWPNotificationDefinitionIcon = new string[] {""} ;
         BC00085_A63WWPNotificationDefinitionTitle = new string[] {""} ;
         BC00085_A64WWPNotificationDefinitionShort = new string[] {""} ;
         BC00085_A65WWPNotificationDefinitionLongD = new string[] {""} ;
         BC00085_A66WWPNotificationDefinitionLink = new string[] {""} ;
         BC00085_A21WWPEntityName = new string[] {""} ;
         BC00085_A67WWPNotificationDefinitionSecFu = new string[] {""} ;
         BC00085_A20WWPEntityId = new long[1] ;
         BC00084_A21WWPEntityName = new string[] {""} ;
         BC00086_A23WWPNotificationDefinitionId = new long[1] ;
         BC00083_A23WWPNotificationDefinitionId = new long[1] ;
         BC00083_A59WWPNotificationDefinitionName = new string[] {""} ;
         BC00083_A30WWPNotificationDefinitionAppli = new short[1] ;
         BC00083_A31WWPNotificationDefinitionAllow = new bool[] {false} ;
         BC00083_A29WWPNotificationDefinitionDescr = new string[] {""} ;
         BC00083_A62WWPNotificationDefinitionIcon = new string[] {""} ;
         BC00083_A63WWPNotificationDefinitionTitle = new string[] {""} ;
         BC00083_A64WWPNotificationDefinitionShort = new string[] {""} ;
         BC00083_A65WWPNotificationDefinitionLongD = new string[] {""} ;
         BC00083_A66WWPNotificationDefinitionLink = new string[] {""} ;
         BC00083_A67WWPNotificationDefinitionSecFu = new string[] {""} ;
         BC00083_A20WWPEntityId = new long[1] ;
         sMode8 = "";
         BC00082_A23WWPNotificationDefinitionId = new long[1] ;
         BC00082_A59WWPNotificationDefinitionName = new string[] {""} ;
         BC00082_A30WWPNotificationDefinitionAppli = new short[1] ;
         BC00082_A31WWPNotificationDefinitionAllow = new bool[] {false} ;
         BC00082_A29WWPNotificationDefinitionDescr = new string[] {""} ;
         BC00082_A62WWPNotificationDefinitionIcon = new string[] {""} ;
         BC00082_A63WWPNotificationDefinitionTitle = new string[] {""} ;
         BC00082_A64WWPNotificationDefinitionShort = new string[] {""} ;
         BC00082_A65WWPNotificationDefinitionLongD = new string[] {""} ;
         BC00082_A66WWPNotificationDefinitionLink = new string[] {""} ;
         BC00082_A67WWPNotificationDefinitionSecFu = new string[] {""} ;
         BC00082_A20WWPEntityId = new long[1] ;
         BC00088_A23WWPNotificationDefinitionId = new long[1] ;
         BC000811_A21WWPEntityName = new string[] {""} ;
         BC000812_A22WWPNotificationId = new long[1] ;
         BC000813_A25WWPSubscriptionId = new long[1] ;
         BC000814_A23WWPNotificationDefinitionId = new long[1] ;
         BC000814_A59WWPNotificationDefinitionName = new string[] {""} ;
         BC000814_A30WWPNotificationDefinitionAppli = new short[1] ;
         BC000814_A31WWPNotificationDefinitionAllow = new bool[] {false} ;
         BC000814_A29WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000814_A62WWPNotificationDefinitionIcon = new string[] {""} ;
         BC000814_A63WWPNotificationDefinitionTitle = new string[] {""} ;
         BC000814_A64WWPNotificationDefinitionShort = new string[] {""} ;
         BC000814_A65WWPNotificationDefinitionLongD = new string[] {""} ;
         BC000814_A66WWPNotificationDefinitionLink = new string[] {""} ;
         BC000814_A21WWPEntityName = new string[] {""} ;
         BC000814_A67WWPNotificationDefinitionSecFu = new string[] {""} ;
         BC000814_A20WWPEntityId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition_bc__default(),
            new Object[][] {
                new Object[] {
               BC00082_A23WWPNotificationDefinitionId, BC00082_A59WWPNotificationDefinitionName, BC00082_A30WWPNotificationDefinitionAppli, BC00082_A31WWPNotificationDefinitionAllow, BC00082_A29WWPNotificationDefinitionDescr, BC00082_A62WWPNotificationDefinitionIcon, BC00082_A63WWPNotificationDefinitionTitle, BC00082_A64WWPNotificationDefinitionShort, BC00082_A65WWPNotificationDefinitionLongD, BC00082_A66WWPNotificationDefinitionLink,
               BC00082_A67WWPNotificationDefinitionSecFu, BC00082_A20WWPEntityId
               }
               , new Object[] {
               BC00083_A23WWPNotificationDefinitionId, BC00083_A59WWPNotificationDefinitionName, BC00083_A30WWPNotificationDefinitionAppli, BC00083_A31WWPNotificationDefinitionAllow, BC00083_A29WWPNotificationDefinitionDescr, BC00083_A62WWPNotificationDefinitionIcon, BC00083_A63WWPNotificationDefinitionTitle, BC00083_A64WWPNotificationDefinitionShort, BC00083_A65WWPNotificationDefinitionLongD, BC00083_A66WWPNotificationDefinitionLink,
               BC00083_A67WWPNotificationDefinitionSecFu, BC00083_A20WWPEntityId
               }
               , new Object[] {
               BC00084_A21WWPEntityName
               }
               , new Object[] {
               BC00085_A23WWPNotificationDefinitionId, BC00085_A59WWPNotificationDefinitionName, BC00085_A30WWPNotificationDefinitionAppli, BC00085_A31WWPNotificationDefinitionAllow, BC00085_A29WWPNotificationDefinitionDescr, BC00085_A62WWPNotificationDefinitionIcon, BC00085_A63WWPNotificationDefinitionTitle, BC00085_A64WWPNotificationDefinitionShort, BC00085_A65WWPNotificationDefinitionLongD, BC00085_A66WWPNotificationDefinitionLink,
               BC00085_A21WWPEntityName, BC00085_A67WWPNotificationDefinitionSecFu, BC00085_A20WWPEntityId
               }
               , new Object[] {
               BC00086_A23WWPNotificationDefinitionId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00088_A23WWPNotificationDefinitionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000811_A21WWPEntityName
               }
               , new Object[] {
               BC000812_A22WWPNotificationId
               }
               , new Object[] {
               BC000813_A25WWPSubscriptionId
               }
               , new Object[] {
               BC000814_A23WWPNotificationDefinitionId, BC000814_A59WWPNotificationDefinitionName, BC000814_A30WWPNotificationDefinitionAppli, BC000814_A31WWPNotificationDefinitionAllow, BC000814_A29WWPNotificationDefinitionDescr, BC000814_A62WWPNotificationDefinitionIcon, BC000814_A63WWPNotificationDefinitionTitle, BC000814_A64WWPNotificationDefinitionShort, BC000814_A65WWPNotificationDefinitionLongD, BC000814_A66WWPNotificationDefinitionLink,
               BC000814_A21WWPEntityName, BC000814_A67WWPNotificationDefinitionSecFu, BC000814_A20WWPEntityId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z30WWPNotificationDefinitionAppli ;
      private short A30WWPNotificationDefinitionAppli ;
      private short RcdFound8 ;
      private int trnEnded ;
      private long Z23WWPNotificationDefinitionId ;
      private long A23WWPNotificationDefinitionId ;
      private long Z20WWPEntityId ;
      private long A20WWPEntityId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode8 ;
      private bool Z31WWPNotificationDefinitionAllow ;
      private bool A31WWPNotificationDefinitionAllow ;
      private bool Z68WWPNotificationDefinitionIsAut ;
      private bool A68WWPNotificationDefinitionIsAut ;
      private bool Gx_longc ;
      private bool GXt_boolean1 ;
      private string Z59WWPNotificationDefinitionName ;
      private string A59WWPNotificationDefinitionName ;
      private string Z29WWPNotificationDefinitionDescr ;
      private string A29WWPNotificationDefinitionDescr ;
      private string Z62WWPNotificationDefinitionIcon ;
      private string A62WWPNotificationDefinitionIcon ;
      private string Z63WWPNotificationDefinitionTitle ;
      private string A63WWPNotificationDefinitionTitle ;
      private string Z64WWPNotificationDefinitionShort ;
      private string A64WWPNotificationDefinitionShort ;
      private string Z65WWPNotificationDefinitionLongD ;
      private string A65WWPNotificationDefinitionLongD ;
      private string Z66WWPNotificationDefinitionLink ;
      private string A66WWPNotificationDefinitionLink ;
      private string Z67WWPNotificationDefinitionSecFu ;
      private string A67WWPNotificationDefinitionSecFu ;
      private string Z21WWPEntityName ;
      private string A21WWPEntityName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00085_A23WWPNotificationDefinitionId ;
      private string[] BC00085_A59WWPNotificationDefinitionName ;
      private short[] BC00085_A30WWPNotificationDefinitionAppli ;
      private bool[] BC00085_A31WWPNotificationDefinitionAllow ;
      private string[] BC00085_A29WWPNotificationDefinitionDescr ;
      private string[] BC00085_A62WWPNotificationDefinitionIcon ;
      private string[] BC00085_A63WWPNotificationDefinitionTitle ;
      private string[] BC00085_A64WWPNotificationDefinitionShort ;
      private string[] BC00085_A65WWPNotificationDefinitionLongD ;
      private string[] BC00085_A66WWPNotificationDefinitionLink ;
      private string[] BC00085_A21WWPEntityName ;
      private string[] BC00085_A67WWPNotificationDefinitionSecFu ;
      private long[] BC00085_A20WWPEntityId ;
      private string[] BC00084_A21WWPEntityName ;
      private long[] BC00086_A23WWPNotificationDefinitionId ;
      private long[] BC00083_A23WWPNotificationDefinitionId ;
      private string[] BC00083_A59WWPNotificationDefinitionName ;
      private short[] BC00083_A30WWPNotificationDefinitionAppli ;
      private bool[] BC00083_A31WWPNotificationDefinitionAllow ;
      private string[] BC00083_A29WWPNotificationDefinitionDescr ;
      private string[] BC00083_A62WWPNotificationDefinitionIcon ;
      private string[] BC00083_A63WWPNotificationDefinitionTitle ;
      private string[] BC00083_A64WWPNotificationDefinitionShort ;
      private string[] BC00083_A65WWPNotificationDefinitionLongD ;
      private string[] BC00083_A66WWPNotificationDefinitionLink ;
      private string[] BC00083_A67WWPNotificationDefinitionSecFu ;
      private long[] BC00083_A20WWPEntityId ;
      private long[] BC00082_A23WWPNotificationDefinitionId ;
      private string[] BC00082_A59WWPNotificationDefinitionName ;
      private short[] BC00082_A30WWPNotificationDefinitionAppli ;
      private bool[] BC00082_A31WWPNotificationDefinitionAllow ;
      private string[] BC00082_A29WWPNotificationDefinitionDescr ;
      private string[] BC00082_A62WWPNotificationDefinitionIcon ;
      private string[] BC00082_A63WWPNotificationDefinitionTitle ;
      private string[] BC00082_A64WWPNotificationDefinitionShort ;
      private string[] BC00082_A65WWPNotificationDefinitionLongD ;
      private string[] BC00082_A66WWPNotificationDefinitionLink ;
      private string[] BC00082_A67WWPNotificationDefinitionSecFu ;
      private long[] BC00082_A20WWPEntityId ;
      private long[] BC00088_A23WWPNotificationDefinitionId ;
      private string[] BC000811_A21WWPEntityName ;
      private long[] BC000812_A22WWPNotificationId ;
      private long[] BC000813_A25WWPSubscriptionId ;
      private long[] BC000814_A23WWPNotificationDefinitionId ;
      private string[] BC000814_A59WWPNotificationDefinitionName ;
      private short[] BC000814_A30WWPNotificationDefinitionAppli ;
      private bool[] BC000814_A31WWPNotificationDefinitionAllow ;
      private string[] BC000814_A29WWPNotificationDefinitionDescr ;
      private string[] BC000814_A62WWPNotificationDefinitionIcon ;
      private string[] BC000814_A63WWPNotificationDefinitionTitle ;
      private string[] BC000814_A64WWPNotificationDefinitionShort ;
      private string[] BC000814_A65WWPNotificationDefinitionLongD ;
      private string[] BC000814_A66WWPNotificationDefinitionLink ;
      private string[] BC000814_A21WWPEntityName ;
      private string[] BC000814_A67WWPNotificationDefinitionSecFu ;
      private long[] BC000814_A20WWPEntityId ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_notificationdefinition_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notificationdefinition_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00082;
        prmBC00082 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC00083;
        prmBC00083 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC00084;
        prmBC00084 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC00085;
        prmBC00085 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC00086;
        prmBC00086 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC00087;
        prmBC00087 = new Object[] {
        new ParDef("WWPNotificationDefinitionName",GXType.VarChar,100,0) ,
        new ParDef("WWPNotificationDefinitionAppli",GXType.Int16,1,0) ,
        new ParDef("WWPNotificationDefinitionAllow",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationDefinitionDescr",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionIcon",GXType.VarChar,40,0) ,
        new ParDef("WWPNotificationDefinitionTitle",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionShort",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionLongD",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationDefinitionLink",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationDefinitionSecFu",GXType.VarChar,200,0) ,
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC00088;
        prmBC00088 = new Object[] {
        };
        Object[] prmBC00089;
        prmBC00089 = new Object[] {
        new ParDef("WWPNotificationDefinitionName",GXType.VarChar,100,0) ,
        new ParDef("WWPNotificationDefinitionAppli",GXType.Int16,1,0) ,
        new ParDef("WWPNotificationDefinitionAllow",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationDefinitionDescr",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionIcon",GXType.VarChar,40,0) ,
        new ParDef("WWPNotificationDefinitionTitle",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionShort",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionLongD",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationDefinitionLink",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationDefinitionSecFu",GXType.VarChar,200,0) ,
        new ParDef("WWPEntityId",GXType.Int64,10,0) ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000810;
        prmBC000810 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000811;
        prmBC000811 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC000812;
        prmBC000812 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000813;
        prmBC000813 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000814;
        prmBC000814 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00082", "SELECT WWPNotificationDefinitionId, WWPNotificationDefinitionName, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu, WWPEntityId FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId  FOR UPDATE OF WWP_NotificationDefinition",true, GxErrorMask.GX_NOMASK, false, this,prmBC00082,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00083", "SELECT WWPNotificationDefinitionId, WWPNotificationDefinitionName, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu, WWPEntityId FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00083,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00084", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00084,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00085", "SELECT TM1.WWPNotificationDefinitionId, TM1.WWPNotificationDefinitionName, TM1.WWPNotificationDefinitionAppli, TM1.WWPNotificationDefinitionAllow, TM1.WWPNotificationDefinitionDescr, TM1.WWPNotificationDefinitionIcon, TM1.WWPNotificationDefinitionTitle, TM1.WWPNotificationDefinitionShort, TM1.WWPNotificationDefinitionLongD, TM1.WWPNotificationDefinitionLink, T2.WWPEntityName, TM1.WWPNotificationDefinitionSecFu, TM1.WWPEntityId FROM (WWP_NotificationDefinition TM1 INNER JOIN WWP_Entity T2 ON T2.WWPEntityId = TM1.WWPEntityId) WHERE TM1.WWPNotificationDefinitionId = :WWPNotificationDefinitionId ORDER BY TM1.WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00085,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00086", "SELECT WWPNotificationDefinitionId FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00086,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00087", "SAVEPOINT gxupdate;INSERT INTO WWP_NotificationDefinition(WWPNotificationDefinitionName, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu, WWPEntityId) VALUES(:WWPNotificationDefinitionName, :WWPNotificationDefinitionAppli, :WWPNotificationDefinitionAllow, :WWPNotificationDefinitionDescr, :WWPNotificationDefinitionIcon, :WWPNotificationDefinitionTitle, :WWPNotificationDefinitionShort, :WWPNotificationDefinitionLongD, :WWPNotificationDefinitionLink, :WWPNotificationDefinitionSecFu, :WWPEntityId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00087)
           ,new CursorDef("BC00088", "SELECT currval('WWPNotificationDefinitionId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00088,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00089", "SAVEPOINT gxupdate;UPDATE WWP_NotificationDefinition SET WWPNotificationDefinitionName=:WWPNotificationDefinitionName, WWPNotificationDefinitionAppli=:WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow=:WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr=:WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon=:WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle=:WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort=:WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD=:WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink=:WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu=:WWPNotificationDefinitionSecFu, WWPEntityId=:WWPEntityId  WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00089)
           ,new CursorDef("BC000810", "SAVEPOINT gxupdate;DELETE FROM WWP_NotificationDefinition  WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000810)
           ,new CursorDef("BC000811", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000811,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000812", "SELECT WWPNotificationId FROM WWP_Notification WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000812,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000813", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000813,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000814", "SELECT TM1.WWPNotificationDefinitionId, TM1.WWPNotificationDefinitionName, TM1.WWPNotificationDefinitionAppli, TM1.WWPNotificationDefinitionAllow, TM1.WWPNotificationDefinitionDescr, TM1.WWPNotificationDefinitionIcon, TM1.WWPNotificationDefinitionTitle, TM1.WWPNotificationDefinitionShort, TM1.WWPNotificationDefinitionLongD, TM1.WWPNotificationDefinitionLink, T2.WWPEntityName, TM1.WWPNotificationDefinitionSecFu, TM1.WWPEntityId FROM (WWP_NotificationDefinition TM1 INNER JOIN WWP_Entity T2 ON T2.WWPEntityId = TM1.WWPEntityId) WHERE TM1.WWPNotificationDefinitionId = :WWPNotificationDefinitionId ORDER BY TM1.WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000814,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((long[]) buf[12])[0] = rslt.getLong(13);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((long[]) buf[12])[0] = rslt.getLong(13);
              return;
     }
  }

}

}
