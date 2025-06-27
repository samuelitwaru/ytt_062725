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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_webnotification_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_webnotification_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_webnotification_bc( IGxContext context )
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
         ReadRow066( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey066( ) ;
         standaloneModal( ) ;
         AddRow066( ) ;
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
               Z47WWPWebNotificationId = A47WWPWebNotificationId;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls066( ) ;
            }
            else
            {
               CheckExtendedTable066( ) ;
               if ( AnyError == 0 )
               {
                  ZM066( 6) ;
                  ZM066( 7) ;
               }
               CloseExtendedTableCursors066( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM066( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z42WWPWebNotificationTitle = A42WWPWebNotificationTitle;
            Z43WWPWebNotificationText = A43WWPWebNotificationText;
            Z44WWPWebNotificationIcon = A44WWPWebNotificationIcon;
            Z54WWPWebNotificationStatus = A54WWPWebNotificationStatus;
            Z45WWPWebNotificationCreated = A45WWPWebNotificationCreated;
            Z58WWPWebNotificationScheduled = A58WWPWebNotificationScheduled;
            Z55WWPWebNotificationProcessed = A55WWPWebNotificationProcessed;
            Z46WWPWebNotificationRead = A46WWPWebNotificationRead;
            Z57WWPWebNotificationReceived = A57WWPWebNotificationReceived;
            Z22WWPNotificationId = A22WWPNotificationId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
            Z24WWPNotificationCreated = A24WWPNotificationCreated;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z59WWPNotificationDefinitionName = A59WWPNotificationDefinitionName;
         }
         if ( GX_JID == -5 )
         {
            Z47WWPWebNotificationId = A47WWPWebNotificationId;
            Z42WWPWebNotificationTitle = A42WWPWebNotificationTitle;
            Z43WWPWebNotificationText = A43WWPWebNotificationText;
            Z44WWPWebNotificationIcon = A44WWPWebNotificationIcon;
            Z53WWPWebNotificationClientId = A53WWPWebNotificationClientId;
            Z54WWPWebNotificationStatus = A54WWPWebNotificationStatus;
            Z45WWPWebNotificationCreated = A45WWPWebNotificationCreated;
            Z58WWPWebNotificationScheduled = A58WWPWebNotificationScheduled;
            Z55WWPWebNotificationProcessed = A55WWPWebNotificationProcessed;
            Z46WWPWebNotificationRead = A46WWPWebNotificationRead;
            Z56WWPWebNotificationDetail = A56WWPWebNotificationDetail;
            Z57WWPWebNotificationReceived = A57WWPWebNotificationReceived;
            Z22WWPNotificationId = A22WWPNotificationId;
            Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
            Z24WWPNotificationCreated = A24WWPNotificationCreated;
            Z60WWPNotificationMetadata = A60WWPNotificationMetadata;
            Z59WWPNotificationDefinitionName = A59WWPNotificationDefinitionName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A54WWPWebNotificationStatus) && ( Gx_BScreen == 0 ) )
         {
            A54WWPWebNotificationStatus = 1;
         }
         if ( IsIns( )  && (DateTime.MinValue==A45WWPWebNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A45WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A58WWPWebNotificationScheduled) && ( Gx_BScreen == 0 ) )
         {
            A58WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load066( )
      {
         /* Using cursor BC00066 */
         pr_default.execute(4, new Object[] {A47WWPWebNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound6 = 1;
            A23WWPNotificationDefinitionId = BC00066_A23WWPNotificationDefinitionId[0];
            A42WWPWebNotificationTitle = BC00066_A42WWPWebNotificationTitle[0];
            A24WWPNotificationCreated = BC00066_A24WWPNotificationCreated[0];
            A60WWPNotificationMetadata = BC00066_A60WWPNotificationMetadata[0];
            n60WWPNotificationMetadata = BC00066_n60WWPNotificationMetadata[0];
            A59WWPNotificationDefinitionName = BC00066_A59WWPNotificationDefinitionName[0];
            A43WWPWebNotificationText = BC00066_A43WWPWebNotificationText[0];
            A44WWPWebNotificationIcon = BC00066_A44WWPWebNotificationIcon[0];
            A53WWPWebNotificationClientId = BC00066_A53WWPWebNotificationClientId[0];
            A54WWPWebNotificationStatus = BC00066_A54WWPWebNotificationStatus[0];
            A45WWPWebNotificationCreated = BC00066_A45WWPWebNotificationCreated[0];
            A58WWPWebNotificationScheduled = BC00066_A58WWPWebNotificationScheduled[0];
            A55WWPWebNotificationProcessed = BC00066_A55WWPWebNotificationProcessed[0];
            A46WWPWebNotificationRead = BC00066_A46WWPWebNotificationRead[0];
            n46WWPWebNotificationRead = BC00066_n46WWPWebNotificationRead[0];
            A56WWPWebNotificationDetail = BC00066_A56WWPWebNotificationDetail[0];
            n56WWPWebNotificationDetail = BC00066_n56WWPWebNotificationDetail[0];
            A57WWPWebNotificationReceived = BC00066_A57WWPWebNotificationReceived[0];
            n57WWPWebNotificationReceived = BC00066_n57WWPWebNotificationReceived[0];
            A22WWPNotificationId = BC00066_A22WWPNotificationId[0];
            n22WWPNotificationId = BC00066_n22WWPNotificationId[0];
            ZM066( -5) ;
         }
         pr_default.close(4);
         OnLoadActions066( ) ;
      }

      protected void OnLoadActions066( )
      {
      }

      protected void CheckExtendedTable066( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00064 */
         pr_default.execute(2, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A22WWPNotificationId) ) )
            {
               GX_msglist.addItem("No matching 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
            }
         }
         A23WWPNotificationDefinitionId = BC00064_A23WWPNotificationDefinitionId[0];
         A24WWPNotificationCreated = BC00064_A24WWPNotificationCreated[0];
         A60WWPNotificationMetadata = BC00064_A60WWPNotificationMetadata[0];
         n60WWPNotificationMetadata = BC00064_n60WWPNotificationMetadata[0];
         pr_default.close(2);
         /* Using cursor BC00065 */
         pr_default.execute(3, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A23WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem("No matching 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
            }
         }
         A59WWPNotificationDefinitionName = BC00065_A59WWPNotificationDefinitionName[0];
         pr_default.close(3);
         if ( ! ( ( A54WWPWebNotificationStatus == 1 ) || ( A54WWPWebNotificationStatus == 2 ) || ( A54WWPWebNotificationStatus == 3 ) ) )
         {
            GX_msglist.addItem("Field Web Notification Status is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors066( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey066( )
      {
         /* Using cursor BC00067 */
         pr_default.execute(5, new Object[] {A47WWPWebNotificationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00063 */
         pr_default.execute(1, new Object[] {A47WWPWebNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM066( 5) ;
            RcdFound6 = 1;
            A47WWPWebNotificationId = BC00063_A47WWPWebNotificationId[0];
            A42WWPWebNotificationTitle = BC00063_A42WWPWebNotificationTitle[0];
            A43WWPWebNotificationText = BC00063_A43WWPWebNotificationText[0];
            A44WWPWebNotificationIcon = BC00063_A44WWPWebNotificationIcon[0];
            A53WWPWebNotificationClientId = BC00063_A53WWPWebNotificationClientId[0];
            A54WWPWebNotificationStatus = BC00063_A54WWPWebNotificationStatus[0];
            A45WWPWebNotificationCreated = BC00063_A45WWPWebNotificationCreated[0];
            A58WWPWebNotificationScheduled = BC00063_A58WWPWebNotificationScheduled[0];
            A55WWPWebNotificationProcessed = BC00063_A55WWPWebNotificationProcessed[0];
            A46WWPWebNotificationRead = BC00063_A46WWPWebNotificationRead[0];
            n46WWPWebNotificationRead = BC00063_n46WWPWebNotificationRead[0];
            A56WWPWebNotificationDetail = BC00063_A56WWPWebNotificationDetail[0];
            n56WWPWebNotificationDetail = BC00063_n56WWPWebNotificationDetail[0];
            A57WWPWebNotificationReceived = BC00063_A57WWPWebNotificationReceived[0];
            n57WWPWebNotificationReceived = BC00063_n57WWPWebNotificationReceived[0];
            A22WWPNotificationId = BC00063_A22WWPNotificationId[0];
            n22WWPNotificationId = BC00063_n22WWPNotificationId[0];
            Z47WWPWebNotificationId = A47WWPWebNotificationId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load066( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey066( ) ;
            }
            Gx_mode = sMode6;
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey066( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode6;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey066( ) ;
         if ( RcdFound6 == 0 )
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
         CONFIRM_060( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency066( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00062 */
            pr_default.execute(0, new Object[] {A47WWPWebNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z42WWPWebNotificationTitle, BC00062_A42WWPWebNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z43WWPWebNotificationText, BC00062_A43WWPWebNotificationText[0]) != 0 ) || ( StringUtil.StrCmp(Z44WWPWebNotificationIcon, BC00062_A44WWPWebNotificationIcon[0]) != 0 ) || ( Z54WWPWebNotificationStatus != BC00062_A54WWPWebNotificationStatus[0] ) || ( Z45WWPWebNotificationCreated != BC00062_A45WWPWebNotificationCreated[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z58WWPWebNotificationScheduled != BC00062_A58WWPWebNotificationScheduled[0] ) || ( Z55WWPWebNotificationProcessed != BC00062_A55WWPWebNotificationProcessed[0] ) || ( Z46WWPWebNotificationRead != BC00062_A46WWPWebNotificationRead[0] ) || ( Z57WWPWebNotificationReceived != BC00062_A57WWPWebNotificationReceived[0] ) || ( Z22WWPNotificationId != BC00062_A22WWPNotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_WebNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM066( 0) ;
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00068 */
                     pr_default.execute(6, new Object[] {A42WWPWebNotificationTitle, A43WWPWebNotificationText, A44WWPWebNotificationIcon, A53WWPWebNotificationClientId, A54WWPWebNotificationStatus, A45WWPWebNotificationCreated, A58WWPWebNotificationScheduled, A55WWPWebNotificationProcessed, n46WWPWebNotificationRead, A46WWPWebNotificationRead, n56WWPWebNotificationDetail, A56WWPWebNotificationDetail, n57WWPWebNotificationReceived, A57WWPWebNotificationReceived, n22WWPNotificationId, A22WWPNotificationId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00069 */
                     pr_default.execute(7);
                     A47WWPWebNotificationId = BC00069_A47WWPWebNotificationId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
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
               Load066( ) ;
            }
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void Update066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000610 */
                     pr_default.execute(8, new Object[] {A42WWPWebNotificationTitle, A43WWPWebNotificationText, A44WWPWebNotificationIcon, A53WWPWebNotificationClientId, A54WWPWebNotificationStatus, A45WWPWebNotificationCreated, A58WWPWebNotificationScheduled, A55WWPWebNotificationProcessed, n46WWPWebNotificationRead, A46WWPWebNotificationRead, n56WWPWebNotificationDetail, A56WWPWebNotificationDetail, n57WWPWebNotificationReceived, A57WWPWebNotificationReceived, n22WWPNotificationId, A22WWPNotificationId, A47WWPWebNotificationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate066( ) ;
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
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void DeferredUpdate066( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls066( ) ;
            AfterConfirm066( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete066( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000611 */
                  pr_default.execute(9, new Object[] {A47WWPWebNotificationId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel066( ) ;
         Gx_mode = sMode6;
      }

      protected void OnDeleteControls066( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000612 */
            pr_default.execute(10, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
            A23WWPNotificationDefinitionId = BC000612_A23WWPNotificationDefinitionId[0];
            A24WWPNotificationCreated = BC000612_A24WWPNotificationCreated[0];
            A60WWPNotificationMetadata = BC000612_A60WWPNotificationMetadata[0];
            n60WWPNotificationMetadata = BC000612_n60WWPNotificationMetadata[0];
            pr_default.close(10);
            /* Using cursor BC000613 */
            pr_default.execute(11, new Object[] {A23WWPNotificationDefinitionId});
            A59WWPNotificationDefinitionName = BC000613_A59WWPNotificationDefinitionName[0];
            pr_default.close(11);
         }
      }

      protected void EndLevel066( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete066( ) ;
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

      public void ScanKeyStart066( )
      {
         /* Using cursor BC000614 */
         pr_default.execute(12, new Object[] {A47WWPWebNotificationId});
         RcdFound6 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound6 = 1;
            A23WWPNotificationDefinitionId = BC000614_A23WWPNotificationDefinitionId[0];
            A47WWPWebNotificationId = BC000614_A47WWPWebNotificationId[0];
            A42WWPWebNotificationTitle = BC000614_A42WWPWebNotificationTitle[0];
            A24WWPNotificationCreated = BC000614_A24WWPNotificationCreated[0];
            A60WWPNotificationMetadata = BC000614_A60WWPNotificationMetadata[0];
            n60WWPNotificationMetadata = BC000614_n60WWPNotificationMetadata[0];
            A59WWPNotificationDefinitionName = BC000614_A59WWPNotificationDefinitionName[0];
            A43WWPWebNotificationText = BC000614_A43WWPWebNotificationText[0];
            A44WWPWebNotificationIcon = BC000614_A44WWPWebNotificationIcon[0];
            A53WWPWebNotificationClientId = BC000614_A53WWPWebNotificationClientId[0];
            A54WWPWebNotificationStatus = BC000614_A54WWPWebNotificationStatus[0];
            A45WWPWebNotificationCreated = BC000614_A45WWPWebNotificationCreated[0];
            A58WWPWebNotificationScheduled = BC000614_A58WWPWebNotificationScheduled[0];
            A55WWPWebNotificationProcessed = BC000614_A55WWPWebNotificationProcessed[0];
            A46WWPWebNotificationRead = BC000614_A46WWPWebNotificationRead[0];
            n46WWPWebNotificationRead = BC000614_n46WWPWebNotificationRead[0];
            A56WWPWebNotificationDetail = BC000614_A56WWPWebNotificationDetail[0];
            n56WWPWebNotificationDetail = BC000614_n56WWPWebNotificationDetail[0];
            A57WWPWebNotificationReceived = BC000614_A57WWPWebNotificationReceived[0];
            n57WWPWebNotificationReceived = BC000614_n57WWPWebNotificationReceived[0];
            A22WWPNotificationId = BC000614_A22WWPNotificationId[0];
            n22WWPNotificationId = BC000614_n22WWPNotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext066( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound6 = 0;
         ScanKeyLoad066( ) ;
      }

      protected void ScanKeyLoad066( )
      {
         sMode6 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound6 = 1;
            A23WWPNotificationDefinitionId = BC000614_A23WWPNotificationDefinitionId[0];
            A47WWPWebNotificationId = BC000614_A47WWPWebNotificationId[0];
            A42WWPWebNotificationTitle = BC000614_A42WWPWebNotificationTitle[0];
            A24WWPNotificationCreated = BC000614_A24WWPNotificationCreated[0];
            A60WWPNotificationMetadata = BC000614_A60WWPNotificationMetadata[0];
            n60WWPNotificationMetadata = BC000614_n60WWPNotificationMetadata[0];
            A59WWPNotificationDefinitionName = BC000614_A59WWPNotificationDefinitionName[0];
            A43WWPWebNotificationText = BC000614_A43WWPWebNotificationText[0];
            A44WWPWebNotificationIcon = BC000614_A44WWPWebNotificationIcon[0];
            A53WWPWebNotificationClientId = BC000614_A53WWPWebNotificationClientId[0];
            A54WWPWebNotificationStatus = BC000614_A54WWPWebNotificationStatus[0];
            A45WWPWebNotificationCreated = BC000614_A45WWPWebNotificationCreated[0];
            A58WWPWebNotificationScheduled = BC000614_A58WWPWebNotificationScheduled[0];
            A55WWPWebNotificationProcessed = BC000614_A55WWPWebNotificationProcessed[0];
            A46WWPWebNotificationRead = BC000614_A46WWPWebNotificationRead[0];
            n46WWPWebNotificationRead = BC000614_n46WWPWebNotificationRead[0];
            A56WWPWebNotificationDetail = BC000614_A56WWPWebNotificationDetail[0];
            n56WWPWebNotificationDetail = BC000614_n56WWPWebNotificationDetail[0];
            A57WWPWebNotificationReceived = BC000614_A57WWPWebNotificationReceived[0];
            n57WWPWebNotificationReceived = BC000614_n57WWPWebNotificationReceived[0];
            A22WWPNotificationId = BC000614_A22WWPNotificationId[0];
            n22WWPNotificationId = BC000614_n22WWPNotificationId[0];
         }
         Gx_mode = sMode6;
      }

      protected void ScanKeyEnd066( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm066( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert066( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate066( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete066( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete066( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate066( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes066( )
      {
      }

      protected void send_integrity_lvl_hashes066( )
      {
      }

      protected void AddRow066( )
      {
         VarsToRow6( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
      }

      protected void ReadRow066( )
      {
         RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
      }

      protected void InitializeNonKey066( )
      {
         A23WWPNotificationDefinitionId = 0;
         A42WWPWebNotificationTitle = "";
         A22WWPNotificationId = 0;
         n22WWPNotificationId = false;
         A24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A60WWPNotificationMetadata = "";
         n60WWPNotificationMetadata = false;
         A59WWPNotificationDefinitionName = "";
         A43WWPWebNotificationText = "";
         A44WWPWebNotificationIcon = "";
         A53WWPWebNotificationClientId = "";
         A55WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         A46WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         n46WWPWebNotificationRead = false;
         A56WWPWebNotificationDetail = "";
         n56WWPWebNotificationDetail = false;
         A57WWPWebNotificationReceived = false;
         n57WWPWebNotificationReceived = false;
         A54WWPWebNotificationStatus = 1;
         A45WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A58WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z42WWPWebNotificationTitle = "";
         Z43WWPWebNotificationText = "";
         Z44WWPWebNotificationIcon = "";
         Z54WWPWebNotificationStatus = 0;
         Z45WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z58WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z55WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z46WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         Z57WWPWebNotificationReceived = false;
         Z22WWPNotificationId = 0;
      }

      protected void InitAll066( )
      {
         A47WWPWebNotificationId = 0;
         InitializeNonKey066( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A54WWPWebNotificationStatus = i54WWPWebNotificationStatus;
         A45WWPWebNotificationCreated = i45WWPWebNotificationCreated;
         A58WWPWebNotificationScheduled = i58WWPWebNotificationScheduled;
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

      public void VarsToRow6( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification obj6 )
      {
         obj6.gxTpr_Mode = Gx_mode;
         obj6.gxTpr_Wwpwebnotificationtitle = A42WWPWebNotificationTitle;
         obj6.gxTpr_Wwpnotificationid = A22WWPNotificationId;
         obj6.gxTpr_Wwpnotificationcreated = A24WWPNotificationCreated;
         obj6.gxTpr_Wwpnotificationmetadata = A60WWPNotificationMetadata;
         obj6.gxTpr_Wwpnotificationdefinitionname = A59WWPNotificationDefinitionName;
         obj6.gxTpr_Wwpwebnotificationtext = A43WWPWebNotificationText;
         obj6.gxTpr_Wwpwebnotificationicon = A44WWPWebNotificationIcon;
         obj6.gxTpr_Wwpwebnotificationclientid = A53WWPWebNotificationClientId;
         obj6.gxTpr_Wwpwebnotificationprocessed = A55WWPWebNotificationProcessed;
         obj6.gxTpr_Wwpwebnotificationread = A46WWPWebNotificationRead;
         obj6.gxTpr_Wwpwebnotificationdetail = A56WWPWebNotificationDetail;
         obj6.gxTpr_Wwpwebnotificationreceived = A57WWPWebNotificationReceived;
         obj6.gxTpr_Wwpwebnotificationstatus = A54WWPWebNotificationStatus;
         obj6.gxTpr_Wwpwebnotificationcreated = A45WWPWebNotificationCreated;
         obj6.gxTpr_Wwpwebnotificationscheduled = A58WWPWebNotificationScheduled;
         obj6.gxTpr_Wwpwebnotificationid = A47WWPWebNotificationId;
         obj6.gxTpr_Wwpwebnotificationid_Z = Z47WWPWebNotificationId;
         obj6.gxTpr_Wwpwebnotificationtitle_Z = Z42WWPWebNotificationTitle;
         obj6.gxTpr_Wwpnotificationid_Z = Z22WWPNotificationId;
         obj6.gxTpr_Wwpnotificationcreated_Z = Z24WWPNotificationCreated;
         obj6.gxTpr_Wwpnotificationdefinitionname_Z = Z59WWPNotificationDefinitionName;
         obj6.gxTpr_Wwpwebnotificationtext_Z = Z43WWPWebNotificationText;
         obj6.gxTpr_Wwpwebnotificationicon_Z = Z44WWPWebNotificationIcon;
         obj6.gxTpr_Wwpwebnotificationstatus_Z = Z54WWPWebNotificationStatus;
         obj6.gxTpr_Wwpwebnotificationcreated_Z = Z45WWPWebNotificationCreated;
         obj6.gxTpr_Wwpwebnotificationscheduled_Z = Z58WWPWebNotificationScheduled;
         obj6.gxTpr_Wwpwebnotificationprocessed_Z = Z55WWPWebNotificationProcessed;
         obj6.gxTpr_Wwpwebnotificationread_Z = Z46WWPWebNotificationRead;
         obj6.gxTpr_Wwpwebnotificationreceived_Z = Z57WWPWebNotificationReceived;
         obj6.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n22WWPNotificationId));
         obj6.gxTpr_Wwpnotificationmetadata_N = (short)(Convert.ToInt16(n60WWPNotificationMetadata));
         obj6.gxTpr_Wwpwebnotificationread_N = (short)(Convert.ToInt16(n46WWPWebNotificationRead));
         obj6.gxTpr_Wwpwebnotificationdetail_N = (short)(Convert.ToInt16(n56WWPWebNotificationDetail));
         obj6.gxTpr_Wwpwebnotificationreceived_N = (short)(Convert.ToInt16(n57WWPWebNotificationReceived));
         obj6.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow6( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification obj6 )
      {
         obj6.gxTpr_Wwpwebnotificationid = A47WWPWebNotificationId;
         return  ;
      }

      public void RowToVars6( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification obj6 ,
                              int forceLoad )
      {
         Gx_mode = obj6.gxTpr_Mode;
         A42WWPWebNotificationTitle = obj6.gxTpr_Wwpwebnotificationtitle;
         A22WWPNotificationId = obj6.gxTpr_Wwpnotificationid;
         n22WWPNotificationId = false;
         A24WWPNotificationCreated = obj6.gxTpr_Wwpnotificationcreated;
         A60WWPNotificationMetadata = obj6.gxTpr_Wwpnotificationmetadata;
         n60WWPNotificationMetadata = false;
         A59WWPNotificationDefinitionName = obj6.gxTpr_Wwpnotificationdefinitionname;
         A43WWPWebNotificationText = obj6.gxTpr_Wwpwebnotificationtext;
         A44WWPWebNotificationIcon = obj6.gxTpr_Wwpwebnotificationicon;
         A53WWPWebNotificationClientId = obj6.gxTpr_Wwpwebnotificationclientid;
         A55WWPWebNotificationProcessed = obj6.gxTpr_Wwpwebnotificationprocessed;
         A46WWPWebNotificationRead = obj6.gxTpr_Wwpwebnotificationread;
         n46WWPWebNotificationRead = false;
         A56WWPWebNotificationDetail = obj6.gxTpr_Wwpwebnotificationdetail;
         n56WWPWebNotificationDetail = false;
         A57WWPWebNotificationReceived = obj6.gxTpr_Wwpwebnotificationreceived;
         n57WWPWebNotificationReceived = false;
         A54WWPWebNotificationStatus = obj6.gxTpr_Wwpwebnotificationstatus;
         A45WWPWebNotificationCreated = obj6.gxTpr_Wwpwebnotificationcreated;
         A58WWPWebNotificationScheduled = obj6.gxTpr_Wwpwebnotificationscheduled;
         A47WWPWebNotificationId = obj6.gxTpr_Wwpwebnotificationid;
         Z47WWPWebNotificationId = obj6.gxTpr_Wwpwebnotificationid_Z;
         Z42WWPWebNotificationTitle = obj6.gxTpr_Wwpwebnotificationtitle_Z;
         Z22WWPNotificationId = obj6.gxTpr_Wwpnotificationid_Z;
         Z24WWPNotificationCreated = obj6.gxTpr_Wwpnotificationcreated_Z;
         Z59WWPNotificationDefinitionName = obj6.gxTpr_Wwpnotificationdefinitionname_Z;
         Z43WWPWebNotificationText = obj6.gxTpr_Wwpwebnotificationtext_Z;
         Z44WWPWebNotificationIcon = obj6.gxTpr_Wwpwebnotificationicon_Z;
         Z54WWPWebNotificationStatus = obj6.gxTpr_Wwpwebnotificationstatus_Z;
         Z45WWPWebNotificationCreated = obj6.gxTpr_Wwpwebnotificationcreated_Z;
         Z58WWPWebNotificationScheduled = obj6.gxTpr_Wwpwebnotificationscheduled_Z;
         Z55WWPWebNotificationProcessed = obj6.gxTpr_Wwpwebnotificationprocessed_Z;
         Z46WWPWebNotificationRead = obj6.gxTpr_Wwpwebnotificationread_Z;
         Z57WWPWebNotificationReceived = obj6.gxTpr_Wwpwebnotificationreceived_Z;
         n22WWPNotificationId = (bool)(Convert.ToBoolean(obj6.gxTpr_Wwpnotificationid_N));
         n60WWPNotificationMetadata = (bool)(Convert.ToBoolean(obj6.gxTpr_Wwpnotificationmetadata_N));
         n46WWPWebNotificationRead = (bool)(Convert.ToBoolean(obj6.gxTpr_Wwpwebnotificationread_N));
         n56WWPWebNotificationDetail = (bool)(Convert.ToBoolean(obj6.gxTpr_Wwpwebnotificationdetail_N));
         n57WWPWebNotificationReceived = (bool)(Convert.ToBoolean(obj6.gxTpr_Wwpwebnotificationreceived_N));
         Gx_mode = obj6.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A47WWPWebNotificationId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey066( ) ;
         ScanKeyStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z47WWPWebNotificationId = A47WWPWebNotificationId;
         }
         ZM066( -5) ;
         OnLoadActions066( ) ;
         AddRow066( ) ;
         ScanKeyEnd066( ) ;
         if ( RcdFound6 == 0 )
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
         RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 0) ;
         ScanKeyStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z47WWPWebNotificationId = A47WWPWebNotificationId;
         }
         ZM066( -5) ;
         OnLoadActions066( ) ;
         AddRow066( ) ;
         ScanKeyEnd066( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey066( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert066( ) ;
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A47WWPWebNotificationId != Z47WWPWebNotificationId )
               {
                  A47WWPWebNotificationId = Z47WWPWebNotificationId;
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
                  Update066( ) ;
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
                  if ( A47WWPWebNotificationId != Z47WWPWebNotificationId )
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
                        Insert066( ) ;
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
                        Insert066( ) ;
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
         RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         SaveImpl( ) ;
         VarsToRow6( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert066( ) ;
         AfterTrn( ) ;
         VarsToRow6( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow6( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A47WWPWebNotificationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_web_WWP_WebNotification);
               auxBC.Save();
               bcwwpbaseobjects_notifications_web_WWP_WebNotification.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
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
         RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert066( ) ;
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
               VarsToRow6( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow6( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
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
         RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 0) ;
         GetKey066( ) ;
         if ( RcdFound6 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A47WWPWebNotificationId != Z47WWPWebNotificationId )
            {
               A47WWPWebNotificationId = Z47WWPWebNotificationId;
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
            if ( A47WWPWebNotificationId != Z47WWPWebNotificationId )
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
         context.RollbackDataStores("wwpbaseobjects.notifications.web.wwp_webnotification_bc",pr_default);
         VarsToRow6( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_web_WWP_WebNotification )
         {
            bcwwpbaseobjects_notifications_web_WWP_WebNotification = (GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow6( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
            }
            else
            {
               RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars6( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_WebNotification WWP_WebNotification_BC
      {
         get {
            return bcwwpbaseobjects_notifications_web_WWP_WebNotification ;
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
            return "webnotification_Execute" ;
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
         Z42WWPWebNotificationTitle = "";
         A42WWPWebNotificationTitle = "";
         Z43WWPWebNotificationText = "";
         A43WWPWebNotificationText = "";
         Z44WWPWebNotificationIcon = "";
         A44WWPWebNotificationIcon = "";
         Z45WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         A45WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z58WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         A58WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z55WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         A55WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z46WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         A46WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         Z24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z59WWPNotificationDefinitionName = "";
         A59WWPNotificationDefinitionName = "";
         Z53WWPWebNotificationClientId = "";
         A53WWPWebNotificationClientId = "";
         Z56WWPWebNotificationDetail = "";
         A56WWPWebNotificationDetail = "";
         Z60WWPNotificationMetadata = "";
         A60WWPNotificationMetadata = "";
         BC00066_A23WWPNotificationDefinitionId = new long[1] ;
         BC00066_A47WWPWebNotificationId = new long[1] ;
         BC00066_A42WWPWebNotificationTitle = new string[] {""} ;
         BC00066_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00066_A60WWPNotificationMetadata = new string[] {""} ;
         BC00066_n60WWPNotificationMetadata = new bool[] {false} ;
         BC00066_A59WWPNotificationDefinitionName = new string[] {""} ;
         BC00066_A43WWPWebNotificationText = new string[] {""} ;
         BC00066_A44WWPWebNotificationIcon = new string[] {""} ;
         BC00066_A53WWPWebNotificationClientId = new string[] {""} ;
         BC00066_A54WWPWebNotificationStatus = new short[1] ;
         BC00066_A45WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00066_A58WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC00066_A55WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC00066_A46WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC00066_n46WWPWebNotificationRead = new bool[] {false} ;
         BC00066_A56WWPWebNotificationDetail = new string[] {""} ;
         BC00066_n56WWPWebNotificationDetail = new bool[] {false} ;
         BC00066_A57WWPWebNotificationReceived = new bool[] {false} ;
         BC00066_n57WWPWebNotificationReceived = new bool[] {false} ;
         BC00066_A22WWPNotificationId = new long[1] ;
         BC00066_n22WWPNotificationId = new bool[] {false} ;
         BC00064_A23WWPNotificationDefinitionId = new long[1] ;
         BC00064_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00064_A60WWPNotificationMetadata = new string[] {""} ;
         BC00064_n60WWPNotificationMetadata = new bool[] {false} ;
         BC00065_A59WWPNotificationDefinitionName = new string[] {""} ;
         BC00067_A47WWPWebNotificationId = new long[1] ;
         BC00063_A47WWPWebNotificationId = new long[1] ;
         BC00063_A42WWPWebNotificationTitle = new string[] {""} ;
         BC00063_A43WWPWebNotificationText = new string[] {""} ;
         BC00063_A44WWPWebNotificationIcon = new string[] {""} ;
         BC00063_A53WWPWebNotificationClientId = new string[] {""} ;
         BC00063_A54WWPWebNotificationStatus = new short[1] ;
         BC00063_A45WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00063_A58WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC00063_A55WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC00063_A46WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC00063_n46WWPWebNotificationRead = new bool[] {false} ;
         BC00063_A56WWPWebNotificationDetail = new string[] {""} ;
         BC00063_n56WWPWebNotificationDetail = new bool[] {false} ;
         BC00063_A57WWPWebNotificationReceived = new bool[] {false} ;
         BC00063_n57WWPWebNotificationReceived = new bool[] {false} ;
         BC00063_A22WWPNotificationId = new long[1] ;
         BC00063_n22WWPNotificationId = new bool[] {false} ;
         sMode6 = "";
         BC00062_A47WWPWebNotificationId = new long[1] ;
         BC00062_A42WWPWebNotificationTitle = new string[] {""} ;
         BC00062_A43WWPWebNotificationText = new string[] {""} ;
         BC00062_A44WWPWebNotificationIcon = new string[] {""} ;
         BC00062_A53WWPWebNotificationClientId = new string[] {""} ;
         BC00062_A54WWPWebNotificationStatus = new short[1] ;
         BC00062_A45WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00062_A58WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC00062_A55WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC00062_A46WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC00062_n46WWPWebNotificationRead = new bool[] {false} ;
         BC00062_A56WWPWebNotificationDetail = new string[] {""} ;
         BC00062_n56WWPWebNotificationDetail = new bool[] {false} ;
         BC00062_A57WWPWebNotificationReceived = new bool[] {false} ;
         BC00062_n57WWPWebNotificationReceived = new bool[] {false} ;
         BC00062_A22WWPNotificationId = new long[1] ;
         BC00062_n22WWPNotificationId = new bool[] {false} ;
         BC00069_A47WWPWebNotificationId = new long[1] ;
         BC000612_A23WWPNotificationDefinitionId = new long[1] ;
         BC000612_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000612_A60WWPNotificationMetadata = new string[] {""} ;
         BC000612_n60WWPNotificationMetadata = new bool[] {false} ;
         BC000613_A59WWPNotificationDefinitionName = new string[] {""} ;
         BC000614_A23WWPNotificationDefinitionId = new long[1] ;
         BC000614_A47WWPWebNotificationId = new long[1] ;
         BC000614_A42WWPWebNotificationTitle = new string[] {""} ;
         BC000614_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000614_A60WWPNotificationMetadata = new string[] {""} ;
         BC000614_n60WWPNotificationMetadata = new bool[] {false} ;
         BC000614_A59WWPNotificationDefinitionName = new string[] {""} ;
         BC000614_A43WWPWebNotificationText = new string[] {""} ;
         BC000614_A44WWPWebNotificationIcon = new string[] {""} ;
         BC000614_A53WWPWebNotificationClientId = new string[] {""} ;
         BC000614_A54WWPWebNotificationStatus = new short[1] ;
         BC000614_A45WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000614_A58WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000614_A55WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000614_A46WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC000614_n46WWPWebNotificationRead = new bool[] {false} ;
         BC000614_A56WWPWebNotificationDetail = new string[] {""} ;
         BC000614_n56WWPWebNotificationDetail = new bool[] {false} ;
         BC000614_A57WWPWebNotificationReceived = new bool[] {false} ;
         BC000614_n57WWPWebNotificationReceived = new bool[] {false} ;
         BC000614_A22WWPNotificationId = new long[1] ;
         BC000614_n22WWPNotificationId = new bool[] {false} ;
         i45WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         i58WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification_bc__default(),
            new Object[][] {
                new Object[] {
               BC00062_A47WWPWebNotificationId, BC00062_A42WWPWebNotificationTitle, BC00062_A43WWPWebNotificationText, BC00062_A44WWPWebNotificationIcon, BC00062_A53WWPWebNotificationClientId, BC00062_A54WWPWebNotificationStatus, BC00062_A45WWPWebNotificationCreated, BC00062_A58WWPWebNotificationScheduled, BC00062_A55WWPWebNotificationProcessed, BC00062_A46WWPWebNotificationRead,
               BC00062_n46WWPWebNotificationRead, BC00062_A56WWPWebNotificationDetail, BC00062_n56WWPWebNotificationDetail, BC00062_A57WWPWebNotificationReceived, BC00062_n57WWPWebNotificationReceived, BC00062_A22WWPNotificationId, BC00062_n22WWPNotificationId
               }
               , new Object[] {
               BC00063_A47WWPWebNotificationId, BC00063_A42WWPWebNotificationTitle, BC00063_A43WWPWebNotificationText, BC00063_A44WWPWebNotificationIcon, BC00063_A53WWPWebNotificationClientId, BC00063_A54WWPWebNotificationStatus, BC00063_A45WWPWebNotificationCreated, BC00063_A58WWPWebNotificationScheduled, BC00063_A55WWPWebNotificationProcessed, BC00063_A46WWPWebNotificationRead,
               BC00063_n46WWPWebNotificationRead, BC00063_A56WWPWebNotificationDetail, BC00063_n56WWPWebNotificationDetail, BC00063_A57WWPWebNotificationReceived, BC00063_n57WWPWebNotificationReceived, BC00063_A22WWPNotificationId, BC00063_n22WWPNotificationId
               }
               , new Object[] {
               BC00064_A23WWPNotificationDefinitionId, BC00064_A24WWPNotificationCreated, BC00064_A60WWPNotificationMetadata, BC00064_n60WWPNotificationMetadata
               }
               , new Object[] {
               BC00065_A59WWPNotificationDefinitionName
               }
               , new Object[] {
               BC00066_A23WWPNotificationDefinitionId, BC00066_A47WWPWebNotificationId, BC00066_A42WWPWebNotificationTitle, BC00066_A24WWPNotificationCreated, BC00066_A60WWPNotificationMetadata, BC00066_n60WWPNotificationMetadata, BC00066_A59WWPNotificationDefinitionName, BC00066_A43WWPWebNotificationText, BC00066_A44WWPWebNotificationIcon, BC00066_A53WWPWebNotificationClientId,
               BC00066_A54WWPWebNotificationStatus, BC00066_A45WWPWebNotificationCreated, BC00066_A58WWPWebNotificationScheduled, BC00066_A55WWPWebNotificationProcessed, BC00066_A46WWPWebNotificationRead, BC00066_n46WWPWebNotificationRead, BC00066_A56WWPWebNotificationDetail, BC00066_n56WWPWebNotificationDetail, BC00066_A57WWPWebNotificationReceived, BC00066_n57WWPWebNotificationReceived,
               BC00066_A22WWPNotificationId, BC00066_n22WWPNotificationId
               }
               , new Object[] {
               BC00067_A47WWPWebNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00069_A47WWPWebNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000612_A23WWPNotificationDefinitionId, BC000612_A24WWPNotificationCreated, BC000612_A60WWPNotificationMetadata, BC000612_n60WWPNotificationMetadata
               }
               , new Object[] {
               BC000613_A59WWPNotificationDefinitionName
               }
               , new Object[] {
               BC000614_A23WWPNotificationDefinitionId, BC000614_A47WWPWebNotificationId, BC000614_A42WWPWebNotificationTitle, BC000614_A24WWPNotificationCreated, BC000614_A60WWPNotificationMetadata, BC000614_n60WWPNotificationMetadata, BC000614_A59WWPNotificationDefinitionName, BC000614_A43WWPWebNotificationText, BC000614_A44WWPWebNotificationIcon, BC000614_A53WWPWebNotificationClientId,
               BC000614_A54WWPWebNotificationStatus, BC000614_A45WWPWebNotificationCreated, BC000614_A58WWPWebNotificationScheduled, BC000614_A55WWPWebNotificationProcessed, BC000614_A46WWPWebNotificationRead, BC000614_n46WWPWebNotificationRead, BC000614_A56WWPWebNotificationDetail, BC000614_n56WWPWebNotificationDetail, BC000614_A57WWPWebNotificationReceived, BC000614_n57WWPWebNotificationReceived,
               BC000614_A22WWPNotificationId, BC000614_n22WWPNotificationId
               }
            }
         );
         Z58WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A58WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i58WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z45WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A45WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i45WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z54WWPWebNotificationStatus = 1;
         A54WWPWebNotificationStatus = 1;
         i54WWPWebNotificationStatus = 1;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z54WWPWebNotificationStatus ;
      private short A54WWPWebNotificationStatus ;
      private short Gx_BScreen ;
      private short RcdFound6 ;
      private short i54WWPWebNotificationStatus ;
      private int trnEnded ;
      private long Z47WWPWebNotificationId ;
      private long A47WWPWebNotificationId ;
      private long Z22WWPNotificationId ;
      private long A22WWPNotificationId ;
      private long Z23WWPNotificationDefinitionId ;
      private long A23WWPNotificationDefinitionId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode6 ;
      private DateTime Z45WWPWebNotificationCreated ;
      private DateTime A45WWPWebNotificationCreated ;
      private DateTime Z58WWPWebNotificationScheduled ;
      private DateTime A58WWPWebNotificationScheduled ;
      private DateTime Z55WWPWebNotificationProcessed ;
      private DateTime A55WWPWebNotificationProcessed ;
      private DateTime Z46WWPWebNotificationRead ;
      private DateTime A46WWPWebNotificationRead ;
      private DateTime Z24WWPNotificationCreated ;
      private DateTime A24WWPNotificationCreated ;
      private DateTime i45WWPWebNotificationCreated ;
      private DateTime i58WWPWebNotificationScheduled ;
      private bool Z57WWPWebNotificationReceived ;
      private bool A57WWPWebNotificationReceived ;
      private bool n60WWPNotificationMetadata ;
      private bool n46WWPWebNotificationRead ;
      private bool n56WWPWebNotificationDetail ;
      private bool n57WWPWebNotificationReceived ;
      private bool n22WWPNotificationId ;
      private bool Gx_longc ;
      private string Z53WWPWebNotificationClientId ;
      private string A53WWPWebNotificationClientId ;
      private string Z56WWPWebNotificationDetail ;
      private string A56WWPWebNotificationDetail ;
      private string Z60WWPNotificationMetadata ;
      private string A60WWPNotificationMetadata ;
      private string Z42WWPWebNotificationTitle ;
      private string A42WWPWebNotificationTitle ;
      private string Z43WWPWebNotificationText ;
      private string A43WWPWebNotificationText ;
      private string Z44WWPWebNotificationIcon ;
      private string A44WWPWebNotificationIcon ;
      private string Z59WWPNotificationDefinitionName ;
      private string A59WWPNotificationDefinitionName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00066_A23WWPNotificationDefinitionId ;
      private long[] BC00066_A47WWPWebNotificationId ;
      private string[] BC00066_A42WWPWebNotificationTitle ;
      private DateTime[] BC00066_A24WWPNotificationCreated ;
      private string[] BC00066_A60WWPNotificationMetadata ;
      private bool[] BC00066_n60WWPNotificationMetadata ;
      private string[] BC00066_A59WWPNotificationDefinitionName ;
      private string[] BC00066_A43WWPWebNotificationText ;
      private string[] BC00066_A44WWPWebNotificationIcon ;
      private string[] BC00066_A53WWPWebNotificationClientId ;
      private short[] BC00066_A54WWPWebNotificationStatus ;
      private DateTime[] BC00066_A45WWPWebNotificationCreated ;
      private DateTime[] BC00066_A58WWPWebNotificationScheduled ;
      private DateTime[] BC00066_A55WWPWebNotificationProcessed ;
      private DateTime[] BC00066_A46WWPWebNotificationRead ;
      private bool[] BC00066_n46WWPWebNotificationRead ;
      private string[] BC00066_A56WWPWebNotificationDetail ;
      private bool[] BC00066_n56WWPWebNotificationDetail ;
      private bool[] BC00066_A57WWPWebNotificationReceived ;
      private bool[] BC00066_n57WWPWebNotificationReceived ;
      private long[] BC00066_A22WWPNotificationId ;
      private bool[] BC00066_n22WWPNotificationId ;
      private long[] BC00064_A23WWPNotificationDefinitionId ;
      private DateTime[] BC00064_A24WWPNotificationCreated ;
      private string[] BC00064_A60WWPNotificationMetadata ;
      private bool[] BC00064_n60WWPNotificationMetadata ;
      private string[] BC00065_A59WWPNotificationDefinitionName ;
      private long[] BC00067_A47WWPWebNotificationId ;
      private long[] BC00063_A47WWPWebNotificationId ;
      private string[] BC00063_A42WWPWebNotificationTitle ;
      private string[] BC00063_A43WWPWebNotificationText ;
      private string[] BC00063_A44WWPWebNotificationIcon ;
      private string[] BC00063_A53WWPWebNotificationClientId ;
      private short[] BC00063_A54WWPWebNotificationStatus ;
      private DateTime[] BC00063_A45WWPWebNotificationCreated ;
      private DateTime[] BC00063_A58WWPWebNotificationScheduled ;
      private DateTime[] BC00063_A55WWPWebNotificationProcessed ;
      private DateTime[] BC00063_A46WWPWebNotificationRead ;
      private bool[] BC00063_n46WWPWebNotificationRead ;
      private string[] BC00063_A56WWPWebNotificationDetail ;
      private bool[] BC00063_n56WWPWebNotificationDetail ;
      private bool[] BC00063_A57WWPWebNotificationReceived ;
      private bool[] BC00063_n57WWPWebNotificationReceived ;
      private long[] BC00063_A22WWPNotificationId ;
      private bool[] BC00063_n22WWPNotificationId ;
      private long[] BC00062_A47WWPWebNotificationId ;
      private string[] BC00062_A42WWPWebNotificationTitle ;
      private string[] BC00062_A43WWPWebNotificationText ;
      private string[] BC00062_A44WWPWebNotificationIcon ;
      private string[] BC00062_A53WWPWebNotificationClientId ;
      private short[] BC00062_A54WWPWebNotificationStatus ;
      private DateTime[] BC00062_A45WWPWebNotificationCreated ;
      private DateTime[] BC00062_A58WWPWebNotificationScheduled ;
      private DateTime[] BC00062_A55WWPWebNotificationProcessed ;
      private DateTime[] BC00062_A46WWPWebNotificationRead ;
      private bool[] BC00062_n46WWPWebNotificationRead ;
      private string[] BC00062_A56WWPWebNotificationDetail ;
      private bool[] BC00062_n56WWPWebNotificationDetail ;
      private bool[] BC00062_A57WWPWebNotificationReceived ;
      private bool[] BC00062_n57WWPWebNotificationReceived ;
      private long[] BC00062_A22WWPNotificationId ;
      private bool[] BC00062_n22WWPNotificationId ;
      private long[] BC00069_A47WWPWebNotificationId ;
      private long[] BC000612_A23WWPNotificationDefinitionId ;
      private DateTime[] BC000612_A24WWPNotificationCreated ;
      private string[] BC000612_A60WWPNotificationMetadata ;
      private bool[] BC000612_n60WWPNotificationMetadata ;
      private string[] BC000613_A59WWPNotificationDefinitionName ;
      private long[] BC000614_A23WWPNotificationDefinitionId ;
      private long[] BC000614_A47WWPWebNotificationId ;
      private string[] BC000614_A42WWPWebNotificationTitle ;
      private DateTime[] BC000614_A24WWPNotificationCreated ;
      private string[] BC000614_A60WWPNotificationMetadata ;
      private bool[] BC000614_n60WWPNotificationMetadata ;
      private string[] BC000614_A59WWPNotificationDefinitionName ;
      private string[] BC000614_A43WWPWebNotificationText ;
      private string[] BC000614_A44WWPWebNotificationIcon ;
      private string[] BC000614_A53WWPWebNotificationClientId ;
      private short[] BC000614_A54WWPWebNotificationStatus ;
      private DateTime[] BC000614_A45WWPWebNotificationCreated ;
      private DateTime[] BC000614_A58WWPWebNotificationScheduled ;
      private DateTime[] BC000614_A55WWPWebNotificationProcessed ;
      private DateTime[] BC000614_A46WWPWebNotificationRead ;
      private bool[] BC000614_n46WWPWebNotificationRead ;
      private string[] BC000614_A56WWPWebNotificationDetail ;
      private bool[] BC000614_n56WWPWebNotificationDetail ;
      private bool[] BC000614_A57WWPWebNotificationReceived ;
      private bool[] BC000614_n57WWPWebNotificationReceived ;
      private long[] BC000614_A22WWPNotificationId ;
      private bool[] BC000614_n22WWPNotificationId ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification bcwwpbaseobjects_notifications_web_WWP_WebNotification ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_webnotification_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_webnotification_bc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00062;
        prmBC00062 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmBC00063;
        prmBC00063 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmBC00064;
        prmBC00064 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC00065;
        prmBC00065 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC00066;
        prmBC00066 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmBC00067;
        prmBC00067 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmBC00068;
        prmBC00068 = new Object[] {
        new ParDef("WWPWebNotificationTitle",GXType.VarChar,40,0) ,
        new ParDef("WWPWebNotificationText",GXType.VarChar,120,0) ,
        new ParDef("WWPWebNotificationIcon",GXType.VarChar,255,0) ,
        new ParDef("WWPWebNotificationClientId",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPWebNotificationStatus",GXType.Int16,4,0) ,
        new ParDef("WWPWebNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationProcessed",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationRead",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPWebNotificationDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPWebNotificationReceived",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC00069;
        prmBC00069 = new Object[] {
        };
        Object[] prmBC000610;
        prmBC000610 = new Object[] {
        new ParDef("WWPWebNotificationTitle",GXType.VarChar,40,0) ,
        new ParDef("WWPWebNotificationText",GXType.VarChar,120,0) ,
        new ParDef("WWPWebNotificationIcon",GXType.VarChar,255,0) ,
        new ParDef("WWPWebNotificationClientId",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPWebNotificationStatus",GXType.Int16,4,0) ,
        new ParDef("WWPWebNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationProcessed",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationRead",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPWebNotificationDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPWebNotificationReceived",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmBC000611;
        prmBC000611 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmBC000612;
        prmBC000612 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000613;
        prmBC000613 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000614;
        prmBC000614 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00062", "SELECT WWPWebNotificationId, WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId  FOR UPDATE OF WWP_WebNotification",true, GxErrorMask.GX_NOMASK, false, this,prmBC00062,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00063", "SELECT WWPWebNotificationId, WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00063,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00064", "SELECT WWPNotificationDefinitionId, WWPNotificationCreated, WWPNotificationMetadata FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00064,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00065", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00065,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00066", "SELECT T2.WWPNotificationDefinitionId, TM1.WWPWebNotificationId, TM1.WWPWebNotificationTitle, T2.WWPNotificationCreated, T2.WWPNotificationMetadata, T3.WWPNotificationDefinitionName, TM1.WWPWebNotificationText, TM1.WWPWebNotificationIcon, TM1.WWPWebNotificationClientId, TM1.WWPWebNotificationStatus, TM1.WWPWebNotificationCreated, TM1.WWPWebNotificationScheduled, TM1.WWPWebNotificationProcessed, TM1.WWPWebNotificationRead, TM1.WWPWebNotificationDetail, TM1.WWPWebNotificationReceived, TM1.WWPNotificationId FROM ((WWP_WebNotification TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) LEFT JOIN WWP_NotificationDefinition T3 ON T3.WWPNotificationDefinitionId = T2.WWPNotificationDefinitionId) WHERE TM1.WWPWebNotificationId = :WWPWebNotificationId ORDER BY TM1.WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00066,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00067", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00067,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00068", "SAVEPOINT gxupdate;INSERT INTO WWP_WebNotification(WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId) VALUES(:WWPWebNotificationTitle, :WWPWebNotificationText, :WWPWebNotificationIcon, :WWPWebNotificationClientId, :WWPWebNotificationStatus, :WWPWebNotificationCreated, :WWPWebNotificationScheduled, :WWPWebNotificationProcessed, :WWPWebNotificationRead, :WWPWebNotificationDetail, :WWPWebNotificationReceived, :WWPNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00068)
           ,new CursorDef("BC00069", "SELECT currval('WWPWebNotificationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00069,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000610", "SAVEPOINT gxupdate;UPDATE WWP_WebNotification SET WWPWebNotificationTitle=:WWPWebNotificationTitle, WWPWebNotificationText=:WWPWebNotificationText, WWPWebNotificationIcon=:WWPWebNotificationIcon, WWPWebNotificationClientId=:WWPWebNotificationClientId, WWPWebNotificationStatus=:WWPWebNotificationStatus, WWPWebNotificationCreated=:WWPWebNotificationCreated, WWPWebNotificationScheduled=:WWPWebNotificationScheduled, WWPWebNotificationProcessed=:WWPWebNotificationProcessed, WWPWebNotificationRead=:WWPWebNotificationRead, WWPWebNotificationDetail=:WWPWebNotificationDetail, WWPWebNotificationReceived=:WWPWebNotificationReceived, WWPNotificationId=:WWPNotificationId  WHERE WWPWebNotificationId = :WWPWebNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000610)
           ,new CursorDef("BC000611", "SAVEPOINT gxupdate;DELETE FROM WWP_WebNotification  WHERE WWPWebNotificationId = :WWPWebNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000611)
           ,new CursorDef("BC000612", "SELECT WWPNotificationDefinitionId, WWPNotificationCreated, WWPNotificationMetadata FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000612,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000613", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000613,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000614", "SELECT T2.WWPNotificationDefinitionId, TM1.WWPWebNotificationId, TM1.WWPWebNotificationTitle, T2.WWPNotificationCreated, T2.WWPNotificationMetadata, T3.WWPNotificationDefinitionName, TM1.WWPWebNotificationText, TM1.WWPWebNotificationIcon, TM1.WWPWebNotificationClientId, TM1.WWPWebNotificationStatus, TM1.WWPWebNotificationCreated, TM1.WWPWebNotificationScheduled, TM1.WWPWebNotificationProcessed, TM1.WWPWebNotificationRead, TM1.WWPWebNotificationDetail, TM1.WWPWebNotificationReceived, TM1.WWPNotificationId FROM ((WWP_WebNotification TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) LEFT JOIN WWP_NotificationDefinition T3 ON T3.WWPNotificationDefinitionId = T2.WWPNotificationDefinitionId) WHERE TM1.WWPWebNotificationId = :WWPWebNotificationId ORDER BY TM1.WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000614,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getLongVarchar(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((bool[]) buf[13])[0] = rslt.getBool(12);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              ((long[]) buf[15])[0] = rslt.getLong(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getLongVarchar(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((bool[]) buf[13])[0] = rslt.getBool(12);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              ((long[]) buf[15])[0] = rslt.getLong(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(12, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(13, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(14, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(14);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(15);
              ((bool[]) buf[17])[0] = rslt.wasNull(15);
              ((bool[]) buf[18])[0] = rslt.getBool(16);
              ((bool[]) buf[19])[0] = rslt.wasNull(16);
              ((long[]) buf[20])[0] = rslt.getLong(17);
              ((bool[]) buf[21])[0] = rslt.wasNull(17);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(12, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(13, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(14, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(14);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(15);
              ((bool[]) buf[17])[0] = rslt.wasNull(15);
              ((bool[]) buf[18])[0] = rslt.getBool(16);
              ((bool[]) buf[19])[0] = rslt.wasNull(16);
              ((long[]) buf[20])[0] = rslt.getLong(17);
              ((bool[]) buf[21])[0] = rslt.wasNull(17);
              return;
     }
  }

}

}
