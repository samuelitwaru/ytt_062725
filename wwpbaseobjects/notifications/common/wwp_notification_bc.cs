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
   public class wwp_notification_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_notification_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_notification_bc( IGxContext context )
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
         ReadRow099( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey099( ) ;
         standaloneModal( ) ;
         AddRow099( ) ;
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
               Z22WWPNotificationId = A22WWPNotificationId;
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

      protected void CONFIRM_090( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls099( ) ;
            }
            else
            {
               CheckExtendedTable099( ) ;
               if ( AnyError == 0 )
               {
                  ZM099( 5) ;
                  ZM099( 6) ;
               }
               CloseExtendedTableCursors099( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM099( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z24WWPNotificationCreated = A24WWPNotificationCreated;
            Z76WWPNotificationIcon = A76WWPNotificationIcon;
            Z77WWPNotificationTitle = A77WWPNotificationTitle;
            Z78WWPNotificationShortDescriptio = A78WWPNotificationShortDescriptio;
            Z79WWPNotificationLink = A79WWPNotificationLink;
            Z82WWPNotificationIsRead = A82WWPNotificationIsRead;
            Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
            Z7WWPUserExtendedId = A7WWPUserExtendedId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z59WWPNotificationDefinitionName = A59WWPNotificationDefinitionName;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z8WWPUserExtendedFullName = A8WWPUserExtendedFullName;
         }
         if ( GX_JID == -4 )
         {
            Z22WWPNotificationId = A22WWPNotificationId;
            Z24WWPNotificationCreated = A24WWPNotificationCreated;
            Z76WWPNotificationIcon = A76WWPNotificationIcon;
            Z77WWPNotificationTitle = A77WWPNotificationTitle;
            Z78WWPNotificationShortDescriptio = A78WWPNotificationShortDescriptio;
            Z79WWPNotificationLink = A79WWPNotificationLink;
            Z82WWPNotificationIsRead = A82WWPNotificationIsRead;
            Z60WWPNotificationMetadata = A60WWPNotificationMetadata;
            Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
            Z7WWPUserExtendedId = A7WWPUserExtendedId;
            Z59WWPNotificationDefinitionName = A59WWPNotificationDefinitionName;
            Z8WWPUserExtendedFullName = A8WWPUserExtendedFullName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A24WWPNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A24WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
      }

      protected void Load099( )
      {
         /* Using cursor BC00096 */
         pr_default.execute(4, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound9 = 1;
            A59WWPNotificationDefinitionName = BC00096_A59WWPNotificationDefinitionName[0];
            A24WWPNotificationCreated = BC00096_A24WWPNotificationCreated[0];
            A76WWPNotificationIcon = BC00096_A76WWPNotificationIcon[0];
            A77WWPNotificationTitle = BC00096_A77WWPNotificationTitle[0];
            A78WWPNotificationShortDescriptio = BC00096_A78WWPNotificationShortDescriptio[0];
            A79WWPNotificationLink = BC00096_A79WWPNotificationLink[0];
            A82WWPNotificationIsRead = BC00096_A82WWPNotificationIsRead[0];
            A8WWPUserExtendedFullName = BC00096_A8WWPUserExtendedFullName[0];
            A60WWPNotificationMetadata = BC00096_A60WWPNotificationMetadata[0];
            n60WWPNotificationMetadata = BC00096_n60WWPNotificationMetadata[0];
            A23WWPNotificationDefinitionId = BC00096_A23WWPNotificationDefinitionId[0];
            A7WWPUserExtendedId = BC00096_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = BC00096_n7WWPUserExtendedId[0];
            ZM099( -4) ;
         }
         pr_default.close(4);
         OnLoadActions099( ) ;
      }

      protected void OnLoadActions099( )
      {
      }

      protected void CheckExtendedTable099( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00094 */
         pr_default.execute(2, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
         }
         A59WWPNotificationDefinitionName = BC00094_A59WWPNotificationDefinitionName[0];
         pr_default.close(2);
         if ( ! ( GxRegex.IsMatch(A79WWPNotificationLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem("Field Notification Link does not match the specified pattern", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00095 */
         pr_default.execute(3, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("No matching 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
            }
         }
         A8WWPUserExtendedFullName = BC00095_A8WWPUserExtendedFullName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors099( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey099( )
      {
         /* Using cursor BC00097 */
         pr_default.execute(5, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00093 */
         pr_default.execute(1, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM099( 4) ;
            RcdFound9 = 1;
            A22WWPNotificationId = BC00093_A22WWPNotificationId[0];
            n22WWPNotificationId = BC00093_n22WWPNotificationId[0];
            A24WWPNotificationCreated = BC00093_A24WWPNotificationCreated[0];
            A76WWPNotificationIcon = BC00093_A76WWPNotificationIcon[0];
            A77WWPNotificationTitle = BC00093_A77WWPNotificationTitle[0];
            A78WWPNotificationShortDescriptio = BC00093_A78WWPNotificationShortDescriptio[0];
            A79WWPNotificationLink = BC00093_A79WWPNotificationLink[0];
            A82WWPNotificationIsRead = BC00093_A82WWPNotificationIsRead[0];
            A60WWPNotificationMetadata = BC00093_A60WWPNotificationMetadata[0];
            n60WWPNotificationMetadata = BC00093_n60WWPNotificationMetadata[0];
            A23WWPNotificationDefinitionId = BC00093_A23WWPNotificationDefinitionId[0];
            A7WWPUserExtendedId = BC00093_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = BC00093_n7WWPUserExtendedId[0];
            Z22WWPNotificationId = A22WWPNotificationId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load099( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey099( ) ;
            }
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey099( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode9;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey099( ) ;
         if ( RcdFound9 == 0 )
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
         CONFIRM_090( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency099( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00092 */
            pr_default.execute(0, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z24WWPNotificationCreated != BC00092_A24WWPNotificationCreated[0] ) || ( StringUtil.StrCmp(Z76WWPNotificationIcon, BC00092_A76WWPNotificationIcon[0]) != 0 ) || ( StringUtil.StrCmp(Z77WWPNotificationTitle, BC00092_A77WWPNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z78WWPNotificationShortDescriptio, BC00092_A78WWPNotificationShortDescriptio[0]) != 0 ) || ( StringUtil.StrCmp(Z79WWPNotificationLink, BC00092_A79WWPNotificationLink[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z82WWPNotificationIsRead != BC00092_A82WWPNotificationIsRead[0] ) || ( Z23WWPNotificationDefinitionId != BC00092_A23WWPNotificationDefinitionId[0] ) || ( StringUtil.StrCmp(Z7WWPUserExtendedId, BC00092_A7WWPUserExtendedId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Notification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM099( 0) ;
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00098 */
                     pr_default.execute(6, new Object[] {A24WWPNotificationCreated, A76WWPNotificationIcon, A77WWPNotificationTitle, A78WWPNotificationShortDescriptio, A79WWPNotificationLink, A82WWPNotificationIsRead, n60WWPNotificationMetadata, A60WWPNotificationMetadata, A23WWPNotificationDefinitionId, n7WWPUserExtendedId, A7WWPUserExtendedId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00099 */
                     pr_default.execute(7);
                     A22WWPNotificationId = BC00099_A22WWPNotificationId[0];
                     n22WWPNotificationId = BC00099_n22WWPNotificationId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
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
               Load099( ) ;
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void Update099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000910 */
                     pr_default.execute(8, new Object[] {A24WWPNotificationCreated, A76WWPNotificationIcon, A77WWPNotificationTitle, A78WWPNotificationShortDescriptio, A79WWPNotificationLink, A82WWPNotificationIsRead, n60WWPNotificationMetadata, A60WWPNotificationMetadata, A23WWPNotificationDefinitionId, n7WWPUserExtendedId, A7WWPUserExtendedId, n22WWPNotificationId, A22WWPNotificationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate099( ) ;
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
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void DeferredUpdate099( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls099( ) ;
            AfterConfirm099( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete099( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000911 */
                  pr_default.execute(9, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel099( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls099( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000912 */
            pr_default.execute(10, new Object[] {A23WWPNotificationDefinitionId});
            A59WWPNotificationDefinitionName = BC000912_A59WWPNotificationDefinitionName[0];
            pr_default.close(10);
            /* Using cursor BC000913 */
            pr_default.execute(11, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
            A8WWPUserExtendedFullName = BC000913_A8WWPUserExtendedFullName[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000914 */
            pr_default.execute(12, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Mail"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000915 */
            pr_default.execute(13, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_WebNotification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC000916 */
            pr_default.execute(14, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_SMS"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel099( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete099( ) ;
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

      public void ScanKeyStart099( )
      {
         /* Using cursor BC000917 */
         pr_default.execute(15, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound9 = 1;
            A22WWPNotificationId = BC000917_A22WWPNotificationId[0];
            n22WWPNotificationId = BC000917_n22WWPNotificationId[0];
            A59WWPNotificationDefinitionName = BC000917_A59WWPNotificationDefinitionName[0];
            A24WWPNotificationCreated = BC000917_A24WWPNotificationCreated[0];
            A76WWPNotificationIcon = BC000917_A76WWPNotificationIcon[0];
            A77WWPNotificationTitle = BC000917_A77WWPNotificationTitle[0];
            A78WWPNotificationShortDescriptio = BC000917_A78WWPNotificationShortDescriptio[0];
            A79WWPNotificationLink = BC000917_A79WWPNotificationLink[0];
            A82WWPNotificationIsRead = BC000917_A82WWPNotificationIsRead[0];
            A8WWPUserExtendedFullName = BC000917_A8WWPUserExtendedFullName[0];
            A60WWPNotificationMetadata = BC000917_A60WWPNotificationMetadata[0];
            n60WWPNotificationMetadata = BC000917_n60WWPNotificationMetadata[0];
            A23WWPNotificationDefinitionId = BC000917_A23WWPNotificationDefinitionId[0];
            A7WWPUserExtendedId = BC000917_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = BC000917_n7WWPUserExtendedId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext099( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound9 = 0;
         ScanKeyLoad099( ) ;
      }

      protected void ScanKeyLoad099( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound9 = 1;
            A22WWPNotificationId = BC000917_A22WWPNotificationId[0];
            n22WWPNotificationId = BC000917_n22WWPNotificationId[0];
            A59WWPNotificationDefinitionName = BC000917_A59WWPNotificationDefinitionName[0];
            A24WWPNotificationCreated = BC000917_A24WWPNotificationCreated[0];
            A76WWPNotificationIcon = BC000917_A76WWPNotificationIcon[0];
            A77WWPNotificationTitle = BC000917_A77WWPNotificationTitle[0];
            A78WWPNotificationShortDescriptio = BC000917_A78WWPNotificationShortDescriptio[0];
            A79WWPNotificationLink = BC000917_A79WWPNotificationLink[0];
            A82WWPNotificationIsRead = BC000917_A82WWPNotificationIsRead[0];
            A8WWPUserExtendedFullName = BC000917_A8WWPUserExtendedFullName[0];
            A60WWPNotificationMetadata = BC000917_A60WWPNotificationMetadata[0];
            n60WWPNotificationMetadata = BC000917_n60WWPNotificationMetadata[0];
            A23WWPNotificationDefinitionId = BC000917_A23WWPNotificationDefinitionId[0];
            A7WWPUserExtendedId = BC000917_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = BC000917_n7WWPUserExtendedId[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd099( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm099( )
      {
         /* After Confirm Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) )
         {
            A7WWPUserExtendedId = "";
            n7WWPUserExtendedId = false;
            n7WWPUserExtendedId = true;
         }
      }

      protected void BeforeInsert099( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate099( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete099( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete099( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate099( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes099( )
      {
      }

      protected void send_integrity_lvl_hashes099( )
      {
      }

      protected void AddRow099( )
      {
         VarsToRow9( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
      }

      protected void ReadRow099( )
      {
         RowToVars9( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
      }

      protected void InitializeNonKey099( )
      {
         A23WWPNotificationDefinitionId = 0;
         A59WWPNotificationDefinitionName = "";
         A76WWPNotificationIcon = "";
         A77WWPNotificationTitle = "";
         A78WWPNotificationShortDescriptio = "";
         A79WWPNotificationLink = "";
         A82WWPNotificationIsRead = false;
         A7WWPUserExtendedId = "";
         n7WWPUserExtendedId = false;
         A8WWPUserExtendedFullName = "";
         A60WWPNotificationMetadata = "";
         n60WWPNotificationMetadata = false;
         A24WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z76WWPNotificationIcon = "";
         Z77WWPNotificationTitle = "";
         Z78WWPNotificationShortDescriptio = "";
         Z79WWPNotificationLink = "";
         Z82WWPNotificationIsRead = false;
         Z23WWPNotificationDefinitionId = 0;
         Z7WWPUserExtendedId = "";
      }

      protected void InitAll099( )
      {
         A22WWPNotificationId = 0;
         n22WWPNotificationId = false;
         InitializeNonKey099( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A24WWPNotificationCreated = i24WWPNotificationCreated;
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

      public void VarsToRow9( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Wwpnotificationdefinitionid = A23WWPNotificationDefinitionId;
         obj9.gxTpr_Wwpnotificationdefinitionname = A59WWPNotificationDefinitionName;
         obj9.gxTpr_Wwpnotificationicon = A76WWPNotificationIcon;
         obj9.gxTpr_Wwpnotificationtitle = A77WWPNotificationTitle;
         obj9.gxTpr_Wwpnotificationshortdescription = A78WWPNotificationShortDescriptio;
         obj9.gxTpr_Wwpnotificationlink = A79WWPNotificationLink;
         obj9.gxTpr_Wwpnotificationisread = A82WWPNotificationIsRead;
         obj9.gxTpr_Wwpuserextendedid = A7WWPUserExtendedId;
         obj9.gxTpr_Wwpuserextendedfullname = A8WWPUserExtendedFullName;
         obj9.gxTpr_Wwpnotificationmetadata = A60WWPNotificationMetadata;
         obj9.gxTpr_Wwpnotificationcreated = A24WWPNotificationCreated;
         obj9.gxTpr_Wwpnotificationid = A22WWPNotificationId;
         obj9.gxTpr_Wwpnotificationid_Z = Z22WWPNotificationId;
         obj9.gxTpr_Wwpnotificationdefinitionid_Z = Z23WWPNotificationDefinitionId;
         obj9.gxTpr_Wwpnotificationdefinitionname_Z = Z59WWPNotificationDefinitionName;
         obj9.gxTpr_Wwpnotificationcreated_Z = Z24WWPNotificationCreated;
         obj9.gxTpr_Wwpnotificationicon_Z = Z76WWPNotificationIcon;
         obj9.gxTpr_Wwpnotificationtitle_Z = Z77WWPNotificationTitle;
         obj9.gxTpr_Wwpnotificationshortdescription_Z = Z78WWPNotificationShortDescriptio;
         obj9.gxTpr_Wwpnotificationlink_Z = Z79WWPNotificationLink;
         obj9.gxTpr_Wwpnotificationisread_Z = Z82WWPNotificationIsRead;
         obj9.gxTpr_Wwpuserextendedid_Z = Z7WWPUserExtendedId;
         obj9.gxTpr_Wwpuserextendedfullname_Z = Z8WWPUserExtendedFullName;
         obj9.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n22WWPNotificationId));
         obj9.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n7WWPUserExtendedId));
         obj9.gxTpr_Wwpnotificationmetadata_N = (short)(Convert.ToInt16(n60WWPNotificationMetadata));
         obj9.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow9( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification obj9 )
      {
         obj9.gxTpr_Wwpnotificationid = A22WWPNotificationId;
         return  ;
      }

      public void RowToVars9( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A23WWPNotificationDefinitionId = obj9.gxTpr_Wwpnotificationdefinitionid;
         A59WWPNotificationDefinitionName = obj9.gxTpr_Wwpnotificationdefinitionname;
         A76WWPNotificationIcon = obj9.gxTpr_Wwpnotificationicon;
         A77WWPNotificationTitle = obj9.gxTpr_Wwpnotificationtitle;
         A78WWPNotificationShortDescriptio = obj9.gxTpr_Wwpnotificationshortdescription;
         A79WWPNotificationLink = obj9.gxTpr_Wwpnotificationlink;
         A82WWPNotificationIsRead = obj9.gxTpr_Wwpnotificationisread;
         A7WWPUserExtendedId = obj9.gxTpr_Wwpuserextendedid;
         n7WWPUserExtendedId = false;
         A8WWPUserExtendedFullName = obj9.gxTpr_Wwpuserextendedfullname;
         A60WWPNotificationMetadata = obj9.gxTpr_Wwpnotificationmetadata;
         n60WWPNotificationMetadata = false;
         A24WWPNotificationCreated = obj9.gxTpr_Wwpnotificationcreated;
         A22WWPNotificationId = obj9.gxTpr_Wwpnotificationid;
         n22WWPNotificationId = false;
         Z22WWPNotificationId = obj9.gxTpr_Wwpnotificationid_Z;
         Z23WWPNotificationDefinitionId = obj9.gxTpr_Wwpnotificationdefinitionid_Z;
         Z59WWPNotificationDefinitionName = obj9.gxTpr_Wwpnotificationdefinitionname_Z;
         Z24WWPNotificationCreated = obj9.gxTpr_Wwpnotificationcreated_Z;
         Z76WWPNotificationIcon = obj9.gxTpr_Wwpnotificationicon_Z;
         Z77WWPNotificationTitle = obj9.gxTpr_Wwpnotificationtitle_Z;
         Z78WWPNotificationShortDescriptio = obj9.gxTpr_Wwpnotificationshortdescription_Z;
         Z79WWPNotificationLink = obj9.gxTpr_Wwpnotificationlink_Z;
         Z82WWPNotificationIsRead = obj9.gxTpr_Wwpnotificationisread_Z;
         Z7WWPUserExtendedId = obj9.gxTpr_Wwpuserextendedid_Z;
         Z8WWPUserExtendedFullName = obj9.gxTpr_Wwpuserextendedfullname_Z;
         n22WWPNotificationId = (bool)(Convert.ToBoolean(obj9.gxTpr_Wwpnotificationid_N));
         n7WWPUserExtendedId = (bool)(Convert.ToBoolean(obj9.gxTpr_Wwpuserextendedid_N));
         n60WWPNotificationMetadata = (bool)(Convert.ToBoolean(obj9.gxTpr_Wwpnotificationmetadata_N));
         Gx_mode = obj9.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A22WWPNotificationId = (long)getParm(obj,0);
         n22WWPNotificationId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey099( ) ;
         ScanKeyStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z22WWPNotificationId = A22WWPNotificationId;
         }
         ZM099( -4) ;
         OnLoadActions099( ) ;
         AddRow099( ) ;
         ScanKeyEnd099( ) ;
         if ( RcdFound9 == 0 )
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
         RowToVars9( bcwwpbaseobjects_notifications_common_WWP_Notification, 0) ;
         ScanKeyStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z22WWPNotificationId = A22WWPNotificationId;
         }
         ZM099( -4) ;
         OnLoadActions099( ) ;
         AddRow099( ) ;
         ScanKeyEnd099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey099( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert099( ) ;
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A22WWPNotificationId != Z22WWPNotificationId )
               {
                  A22WWPNotificationId = Z22WWPNotificationId;
                  n22WWPNotificationId = false;
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
                  Update099( ) ;
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
                  if ( A22WWPNotificationId != Z22WWPNotificationId )
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
                        Insert099( ) ;
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
                        Insert099( ) ;
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
         RowToVars9( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         SaveImpl( ) ;
         VarsToRow9( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert099( ) ;
         AfterTrn( ) ;
         VarsToRow9( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow9( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A22WWPNotificationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_common_WWP_Notification);
               auxBC.Save();
               bcwwpbaseobjects_notifications_common_WWP_Notification.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars9( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
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
         RowToVars9( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert099( ) ;
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
               VarsToRow9( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow9( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
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
         RowToVars9( bcwwpbaseobjects_notifications_common_WWP_Notification, 0) ;
         GetKey099( ) ;
         if ( RcdFound9 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A22WWPNotificationId != Z22WWPNotificationId )
            {
               A22WWPNotificationId = Z22WWPNotificationId;
               n22WWPNotificationId = false;
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
            if ( A22WWPNotificationId != Z22WWPNotificationId )
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
         context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notification_bc",pr_default);
         VarsToRow9( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_common_WWP_Notification )
         {
            bcwwpbaseobjects_notifications_common_WWP_Notification = (GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow9( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
            }
            else
            {
               RowToVars9( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars9( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_Notification WWP_Notification_BC
      {
         get {
            return bcwwpbaseobjects_notifications_common_WWP_Notification ;
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
            return "wwp_notification_Execute" ;
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
         pr_default.close(10);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z76WWPNotificationIcon = "";
         A76WWPNotificationIcon = "";
         Z77WWPNotificationTitle = "";
         A77WWPNotificationTitle = "";
         Z78WWPNotificationShortDescriptio = "";
         A78WWPNotificationShortDescriptio = "";
         Z79WWPNotificationLink = "";
         A79WWPNotificationLink = "";
         Z7WWPUserExtendedId = "";
         A7WWPUserExtendedId = "";
         Z59WWPNotificationDefinitionName = "";
         A59WWPNotificationDefinitionName = "";
         Z8WWPUserExtendedFullName = "";
         A8WWPUserExtendedFullName = "";
         Z60WWPNotificationMetadata = "";
         A60WWPNotificationMetadata = "";
         BC00096_A22WWPNotificationId = new long[1] ;
         BC00096_n22WWPNotificationId = new bool[] {false} ;
         BC00096_A59WWPNotificationDefinitionName = new string[] {""} ;
         BC00096_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00096_A76WWPNotificationIcon = new string[] {""} ;
         BC00096_A77WWPNotificationTitle = new string[] {""} ;
         BC00096_A78WWPNotificationShortDescriptio = new string[] {""} ;
         BC00096_A79WWPNotificationLink = new string[] {""} ;
         BC00096_A82WWPNotificationIsRead = new bool[] {false} ;
         BC00096_A8WWPUserExtendedFullName = new string[] {""} ;
         BC00096_A60WWPNotificationMetadata = new string[] {""} ;
         BC00096_n60WWPNotificationMetadata = new bool[] {false} ;
         BC00096_A23WWPNotificationDefinitionId = new long[1] ;
         BC00096_A7WWPUserExtendedId = new string[] {""} ;
         BC00096_n7WWPUserExtendedId = new bool[] {false} ;
         BC00094_A59WWPNotificationDefinitionName = new string[] {""} ;
         BC00095_A8WWPUserExtendedFullName = new string[] {""} ;
         BC00097_A22WWPNotificationId = new long[1] ;
         BC00097_n22WWPNotificationId = new bool[] {false} ;
         BC00093_A22WWPNotificationId = new long[1] ;
         BC00093_n22WWPNotificationId = new bool[] {false} ;
         BC00093_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00093_A76WWPNotificationIcon = new string[] {""} ;
         BC00093_A77WWPNotificationTitle = new string[] {""} ;
         BC00093_A78WWPNotificationShortDescriptio = new string[] {""} ;
         BC00093_A79WWPNotificationLink = new string[] {""} ;
         BC00093_A82WWPNotificationIsRead = new bool[] {false} ;
         BC00093_A60WWPNotificationMetadata = new string[] {""} ;
         BC00093_n60WWPNotificationMetadata = new bool[] {false} ;
         BC00093_A23WWPNotificationDefinitionId = new long[1] ;
         BC00093_A7WWPUserExtendedId = new string[] {""} ;
         BC00093_n7WWPUserExtendedId = new bool[] {false} ;
         sMode9 = "";
         BC00092_A22WWPNotificationId = new long[1] ;
         BC00092_n22WWPNotificationId = new bool[] {false} ;
         BC00092_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00092_A76WWPNotificationIcon = new string[] {""} ;
         BC00092_A77WWPNotificationTitle = new string[] {""} ;
         BC00092_A78WWPNotificationShortDescriptio = new string[] {""} ;
         BC00092_A79WWPNotificationLink = new string[] {""} ;
         BC00092_A82WWPNotificationIsRead = new bool[] {false} ;
         BC00092_A60WWPNotificationMetadata = new string[] {""} ;
         BC00092_n60WWPNotificationMetadata = new bool[] {false} ;
         BC00092_A23WWPNotificationDefinitionId = new long[1] ;
         BC00092_A7WWPUserExtendedId = new string[] {""} ;
         BC00092_n7WWPUserExtendedId = new bool[] {false} ;
         BC00099_A22WWPNotificationId = new long[1] ;
         BC00099_n22WWPNotificationId = new bool[] {false} ;
         BC000912_A59WWPNotificationDefinitionName = new string[] {""} ;
         BC000913_A8WWPUserExtendedFullName = new string[] {""} ;
         BC000914_A80WWPMailId = new long[1] ;
         BC000915_A47WWPWebNotificationId = new long[1] ;
         BC000916_A33WWPSMSId = new long[1] ;
         BC000917_A22WWPNotificationId = new long[1] ;
         BC000917_n22WWPNotificationId = new bool[] {false} ;
         BC000917_A59WWPNotificationDefinitionName = new string[] {""} ;
         BC000917_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000917_A76WWPNotificationIcon = new string[] {""} ;
         BC000917_A77WWPNotificationTitle = new string[] {""} ;
         BC000917_A78WWPNotificationShortDescriptio = new string[] {""} ;
         BC000917_A79WWPNotificationLink = new string[] {""} ;
         BC000917_A82WWPNotificationIsRead = new bool[] {false} ;
         BC000917_A8WWPUserExtendedFullName = new string[] {""} ;
         BC000917_A60WWPNotificationMetadata = new string[] {""} ;
         BC000917_n60WWPNotificationMetadata = new bool[] {false} ;
         BC000917_A23WWPNotificationDefinitionId = new long[1] ;
         BC000917_A7WWPUserExtendedId = new string[] {""} ;
         BC000917_n7WWPUserExtendedId = new bool[] {false} ;
         i24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification_bc__default(),
            new Object[][] {
                new Object[] {
               BC00092_A22WWPNotificationId, BC00092_A24WWPNotificationCreated, BC00092_A76WWPNotificationIcon, BC00092_A77WWPNotificationTitle, BC00092_A78WWPNotificationShortDescriptio, BC00092_A79WWPNotificationLink, BC00092_A82WWPNotificationIsRead, BC00092_A60WWPNotificationMetadata, BC00092_n60WWPNotificationMetadata, BC00092_A23WWPNotificationDefinitionId,
               BC00092_A7WWPUserExtendedId, BC00092_n7WWPUserExtendedId
               }
               , new Object[] {
               BC00093_A22WWPNotificationId, BC00093_A24WWPNotificationCreated, BC00093_A76WWPNotificationIcon, BC00093_A77WWPNotificationTitle, BC00093_A78WWPNotificationShortDescriptio, BC00093_A79WWPNotificationLink, BC00093_A82WWPNotificationIsRead, BC00093_A60WWPNotificationMetadata, BC00093_n60WWPNotificationMetadata, BC00093_A23WWPNotificationDefinitionId,
               BC00093_A7WWPUserExtendedId, BC00093_n7WWPUserExtendedId
               }
               , new Object[] {
               BC00094_A59WWPNotificationDefinitionName
               }
               , new Object[] {
               BC00095_A8WWPUserExtendedFullName
               }
               , new Object[] {
               BC00096_A22WWPNotificationId, BC00096_A59WWPNotificationDefinitionName, BC00096_A24WWPNotificationCreated, BC00096_A76WWPNotificationIcon, BC00096_A77WWPNotificationTitle, BC00096_A78WWPNotificationShortDescriptio, BC00096_A79WWPNotificationLink, BC00096_A82WWPNotificationIsRead, BC00096_A8WWPUserExtendedFullName, BC00096_A60WWPNotificationMetadata,
               BC00096_n60WWPNotificationMetadata, BC00096_A23WWPNotificationDefinitionId, BC00096_A7WWPUserExtendedId, BC00096_n7WWPUserExtendedId
               }
               , new Object[] {
               BC00097_A22WWPNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00099_A22WWPNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000912_A59WWPNotificationDefinitionName
               }
               , new Object[] {
               BC000913_A8WWPUserExtendedFullName
               }
               , new Object[] {
               BC000914_A80WWPMailId
               }
               , new Object[] {
               BC000915_A47WWPWebNotificationId
               }
               , new Object[] {
               BC000916_A33WWPSMSId
               }
               , new Object[] {
               BC000917_A22WWPNotificationId, BC000917_A59WWPNotificationDefinitionName, BC000917_A24WWPNotificationCreated, BC000917_A76WWPNotificationIcon, BC000917_A77WWPNotificationTitle, BC000917_A78WWPNotificationShortDescriptio, BC000917_A79WWPNotificationLink, BC000917_A82WWPNotificationIsRead, BC000917_A8WWPUserExtendedFullName, BC000917_A60WWPNotificationMetadata,
               BC000917_n60WWPNotificationMetadata, BC000917_A23WWPNotificationDefinitionId, BC000917_A7WWPUserExtendedId, BC000917_n7WWPUserExtendedId
               }
            }
         );
         Z24WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A24WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i24WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound9 ;
      private int trnEnded ;
      private long Z22WWPNotificationId ;
      private long A22WWPNotificationId ;
      private long Z23WWPNotificationDefinitionId ;
      private long A23WWPNotificationDefinitionId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z7WWPUserExtendedId ;
      private string A7WWPUserExtendedId ;
      private string sMode9 ;
      private DateTime Z24WWPNotificationCreated ;
      private DateTime A24WWPNotificationCreated ;
      private DateTime i24WWPNotificationCreated ;
      private bool Z82WWPNotificationIsRead ;
      private bool A82WWPNotificationIsRead ;
      private bool n22WWPNotificationId ;
      private bool n60WWPNotificationMetadata ;
      private bool n7WWPUserExtendedId ;
      private bool Gx_longc ;
      private string Z60WWPNotificationMetadata ;
      private string A60WWPNotificationMetadata ;
      private string Z76WWPNotificationIcon ;
      private string A76WWPNotificationIcon ;
      private string Z77WWPNotificationTitle ;
      private string A77WWPNotificationTitle ;
      private string Z78WWPNotificationShortDescriptio ;
      private string A78WWPNotificationShortDescriptio ;
      private string Z79WWPNotificationLink ;
      private string A79WWPNotificationLink ;
      private string Z59WWPNotificationDefinitionName ;
      private string A59WWPNotificationDefinitionName ;
      private string Z8WWPUserExtendedFullName ;
      private string A8WWPUserExtendedFullName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00096_A22WWPNotificationId ;
      private bool[] BC00096_n22WWPNotificationId ;
      private string[] BC00096_A59WWPNotificationDefinitionName ;
      private DateTime[] BC00096_A24WWPNotificationCreated ;
      private string[] BC00096_A76WWPNotificationIcon ;
      private string[] BC00096_A77WWPNotificationTitle ;
      private string[] BC00096_A78WWPNotificationShortDescriptio ;
      private string[] BC00096_A79WWPNotificationLink ;
      private bool[] BC00096_A82WWPNotificationIsRead ;
      private string[] BC00096_A8WWPUserExtendedFullName ;
      private string[] BC00096_A60WWPNotificationMetadata ;
      private bool[] BC00096_n60WWPNotificationMetadata ;
      private long[] BC00096_A23WWPNotificationDefinitionId ;
      private string[] BC00096_A7WWPUserExtendedId ;
      private bool[] BC00096_n7WWPUserExtendedId ;
      private string[] BC00094_A59WWPNotificationDefinitionName ;
      private string[] BC00095_A8WWPUserExtendedFullName ;
      private long[] BC00097_A22WWPNotificationId ;
      private bool[] BC00097_n22WWPNotificationId ;
      private long[] BC00093_A22WWPNotificationId ;
      private bool[] BC00093_n22WWPNotificationId ;
      private DateTime[] BC00093_A24WWPNotificationCreated ;
      private string[] BC00093_A76WWPNotificationIcon ;
      private string[] BC00093_A77WWPNotificationTitle ;
      private string[] BC00093_A78WWPNotificationShortDescriptio ;
      private string[] BC00093_A79WWPNotificationLink ;
      private bool[] BC00093_A82WWPNotificationIsRead ;
      private string[] BC00093_A60WWPNotificationMetadata ;
      private bool[] BC00093_n60WWPNotificationMetadata ;
      private long[] BC00093_A23WWPNotificationDefinitionId ;
      private string[] BC00093_A7WWPUserExtendedId ;
      private bool[] BC00093_n7WWPUserExtendedId ;
      private long[] BC00092_A22WWPNotificationId ;
      private bool[] BC00092_n22WWPNotificationId ;
      private DateTime[] BC00092_A24WWPNotificationCreated ;
      private string[] BC00092_A76WWPNotificationIcon ;
      private string[] BC00092_A77WWPNotificationTitle ;
      private string[] BC00092_A78WWPNotificationShortDescriptio ;
      private string[] BC00092_A79WWPNotificationLink ;
      private bool[] BC00092_A82WWPNotificationIsRead ;
      private string[] BC00092_A60WWPNotificationMetadata ;
      private bool[] BC00092_n60WWPNotificationMetadata ;
      private long[] BC00092_A23WWPNotificationDefinitionId ;
      private string[] BC00092_A7WWPUserExtendedId ;
      private bool[] BC00092_n7WWPUserExtendedId ;
      private long[] BC00099_A22WWPNotificationId ;
      private bool[] BC00099_n22WWPNotificationId ;
      private string[] BC000912_A59WWPNotificationDefinitionName ;
      private string[] BC000913_A8WWPUserExtendedFullName ;
      private long[] BC000914_A80WWPMailId ;
      private long[] BC000915_A47WWPWebNotificationId ;
      private long[] BC000916_A33WWPSMSId ;
      private long[] BC000917_A22WWPNotificationId ;
      private bool[] BC000917_n22WWPNotificationId ;
      private string[] BC000917_A59WWPNotificationDefinitionName ;
      private DateTime[] BC000917_A24WWPNotificationCreated ;
      private string[] BC000917_A76WWPNotificationIcon ;
      private string[] BC000917_A77WWPNotificationTitle ;
      private string[] BC000917_A78WWPNotificationShortDescriptio ;
      private string[] BC000917_A79WWPNotificationLink ;
      private bool[] BC000917_A82WWPNotificationIsRead ;
      private string[] BC000917_A8WWPUserExtendedFullName ;
      private string[] BC000917_A60WWPNotificationMetadata ;
      private bool[] BC000917_n60WWPNotificationMetadata ;
      private long[] BC000917_A23WWPNotificationDefinitionId ;
      private string[] BC000917_A7WWPUserExtendedId ;
      private bool[] BC000917_n7WWPUserExtendedId ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification bcwwpbaseobjects_notifications_common_WWP_Notification ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_notification_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notification_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00092;
        prmBC00092 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC00093;
        prmBC00093 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC00094;
        prmBC00094 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC00095;
        prmBC00095 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00096;
        prmBC00096 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC00097;
        prmBC00097 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC00098;
        prmBC00098 = new Object[] {
        new ParDef("WWPNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPNotificationIcon",GXType.VarChar,100,0) ,
        new ParDef("WWPNotificationTitle",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationShortDescriptio",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationLink",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationIsRead",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationMetadata",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00099;
        prmBC00099 = new Object[] {
        };
        Object[] prmBC000910;
        prmBC000910 = new Object[] {
        new ParDef("WWPNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPNotificationIcon",GXType.VarChar,100,0) ,
        new ParDef("WWPNotificationTitle",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationShortDescriptio",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationLink",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationIsRead",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationMetadata",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000911;
        prmBC000911 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000912;
        prmBC000912 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000913;
        prmBC000913 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000914;
        prmBC000914 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000915;
        prmBC000915 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000916;
        prmBC000916 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000917;
        prmBC000917 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC00092", "SELECT WWPNotificationId, WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId  FOR UPDATE OF WWP_Notification",true, GxErrorMask.GX_NOMASK, false, this,prmBC00092,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00093", "SELECT WWPNotificationId, WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00093,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00094", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00094,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00095", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00095,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00096", "SELECT TM1.WWPNotificationId, T2.WWPNotificationDefinitionName, TM1.WWPNotificationCreated, TM1.WWPNotificationIcon, TM1.WWPNotificationTitle, TM1.WWPNotificationShortDescriptio, TM1.WWPNotificationLink, TM1.WWPNotificationIsRead, T3.WWPUserExtendedFullName, TM1.WWPNotificationMetadata, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM ((WWP_Notification TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) LEFT JOIN WWP_UserExtended T3 ON T3.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPNotificationId = :WWPNotificationId ORDER BY TM1.WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00096,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00097", "SELECT WWPNotificationId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00097,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00098", "SAVEPOINT gxupdate;INSERT INTO WWP_Notification(WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId) VALUES(:WWPNotificationCreated, :WWPNotificationIcon, :WWPNotificationTitle, :WWPNotificationShortDescriptio, :WWPNotificationLink, :WWPNotificationIsRead, :WWPNotificationMetadata, :WWPNotificationDefinitionId, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00098)
           ,new CursorDef("BC00099", "SELECT currval('WWPNotificationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00099,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000910", "SAVEPOINT gxupdate;UPDATE WWP_Notification SET WWPNotificationCreated=:WWPNotificationCreated, WWPNotificationIcon=:WWPNotificationIcon, WWPNotificationTitle=:WWPNotificationTitle, WWPNotificationShortDescriptio=:WWPNotificationShortDescriptio, WWPNotificationLink=:WWPNotificationLink, WWPNotificationIsRead=:WWPNotificationIsRead, WWPNotificationMetadata=:WWPNotificationMetadata, WWPNotificationDefinitionId=:WWPNotificationDefinitionId, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPNotificationId = :WWPNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000910)
           ,new CursorDef("BC000911", "SAVEPOINT gxupdate;DELETE FROM WWP_Notification  WHERE WWPNotificationId = :WWPNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000911)
           ,new CursorDef("BC000912", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000912,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000913", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000913,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000914", "SELECT WWPMailId FROM WWP_Mail WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000914,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000915", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000915,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000916", "SELECT WWPSMSId FROM WWP_SMS WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000916,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000917", "SELECT TM1.WWPNotificationId, T2.WWPNotificationDefinitionName, TM1.WWPNotificationCreated, TM1.WWPNotificationIcon, TM1.WWPNotificationTitle, TM1.WWPNotificationShortDescriptio, TM1.WWPNotificationLink, TM1.WWPNotificationIsRead, T3.WWPUserExtendedFullName, TM1.WWPNotificationMetadata, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM ((WWP_Notification TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) LEFT JOIN WWP_UserExtended T3 ON T3.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPNotificationId = :WWPNotificationId ORDER BY TM1.WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000917,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((long[]) buf[9])[0] = rslt.getLong(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 40);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((long[]) buf[9])[0] = rslt.getLong(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 40);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((long[]) buf[11])[0] = rslt.getLong(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(12);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((long[]) buf[11])[0] = rslt.getLong(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(12);
              return;
     }
  }

}

}
