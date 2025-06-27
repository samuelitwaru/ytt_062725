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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_userextended_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_userextended_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_userextended_bc( IGxContext context )
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
         ReadRow011( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey011( ) ;
         standaloneModal( ) ;
         AddRow011( ) ;
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
               Z7WWPUserExtendedId = A7WWPUserExtendedId;
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

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z16WWPUserExtendedName = A16WWPUserExtendedName;
            Z8WWPUserExtendedFullName = A8WWPUserExtendedFullName;
            Z15WWPUserExtendedPhone = A15WWPUserExtendedPhone;
            Z9WWPUserExtendedEmail = A9WWPUserExtendedEmail;
            Z11WWPUserExtendedEmaiNotif = A11WWPUserExtendedEmaiNotif;
            Z12WWPUserExtendedSMSNotif = A12WWPUserExtendedSMSNotif;
            Z13WWPUserExtendedMobileNotif = A13WWPUserExtendedMobileNotif;
            Z14WWPUserExtendedDesktopNotif = A14WWPUserExtendedDesktopNotif;
            Z17WWPUserExtendedDeleted = A17WWPUserExtendedDeleted;
            Z18WWPUserExtendedDeletedIn = A18WWPUserExtendedDeletedIn;
         }
         if ( GX_JID == -2 )
         {
            Z7WWPUserExtendedId = A7WWPUserExtendedId;
            Z10WWPUserExtendedPhoto = A10WWPUserExtendedPhoto;
            Z40000WWPUserExtendedPhoto_GXI = A40000WWPUserExtendedPhoto_GXI;
            Z16WWPUserExtendedName = A16WWPUserExtendedName;
            Z8WWPUserExtendedFullName = A8WWPUserExtendedFullName;
            Z15WWPUserExtendedPhone = A15WWPUserExtendedPhone;
            Z9WWPUserExtendedEmail = A9WWPUserExtendedEmail;
            Z11WWPUserExtendedEmaiNotif = A11WWPUserExtendedEmaiNotif;
            Z12WWPUserExtendedSMSNotif = A12WWPUserExtendedSMSNotif;
            Z13WWPUserExtendedMobileNotif = A13WWPUserExtendedMobileNotif;
            Z14WWPUserExtendedDesktopNotif = A14WWPUserExtendedDesktopNotif;
            Z17WWPUserExtendedDeleted = A17WWPUserExtendedDeleted;
            Z18WWPUserExtendedDeletedIn = A18WWPUserExtendedDeletedIn;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load011( )
      {
         /* Using cursor BC00014 */
         pr_default.execute(2, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A40000WWPUserExtendedPhoto_GXI = BC00014_A40000WWPUserExtendedPhoto_GXI[0];
            A16WWPUserExtendedName = BC00014_A16WWPUserExtendedName[0];
            A8WWPUserExtendedFullName = BC00014_A8WWPUserExtendedFullName[0];
            A15WWPUserExtendedPhone = BC00014_A15WWPUserExtendedPhone[0];
            A9WWPUserExtendedEmail = BC00014_A9WWPUserExtendedEmail[0];
            A11WWPUserExtendedEmaiNotif = BC00014_A11WWPUserExtendedEmaiNotif[0];
            A12WWPUserExtendedSMSNotif = BC00014_A12WWPUserExtendedSMSNotif[0];
            A13WWPUserExtendedMobileNotif = BC00014_A13WWPUserExtendedMobileNotif[0];
            A14WWPUserExtendedDesktopNotif = BC00014_A14WWPUserExtendedDesktopNotif[0];
            A17WWPUserExtendedDeleted = BC00014_A17WWPUserExtendedDeleted[0];
            A18WWPUserExtendedDeletedIn = BC00014_A18WWPUserExtendedDeletedIn[0];
            n18WWPUserExtendedDeletedIn = BC00014_n18WWPUserExtendedDeletedIn[0];
            A10WWPUserExtendedPhoto = BC00014_A10WWPUserExtendedPhoto[0];
            ZM011( -2) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A9WWPUserExtendedEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field User Email does not match the specified pattern", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor BC00015 */
         pr_default.execute(3, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00013 */
         pr_default.execute(1, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 2) ;
            RcdFound1 = 1;
            A7WWPUserExtendedId = BC00013_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = BC00013_n7WWPUserExtendedId[0];
            A40000WWPUserExtendedPhoto_GXI = BC00013_A40000WWPUserExtendedPhoto_GXI[0];
            A16WWPUserExtendedName = BC00013_A16WWPUserExtendedName[0];
            A8WWPUserExtendedFullName = BC00013_A8WWPUserExtendedFullName[0];
            A15WWPUserExtendedPhone = BC00013_A15WWPUserExtendedPhone[0];
            A9WWPUserExtendedEmail = BC00013_A9WWPUserExtendedEmail[0];
            A11WWPUserExtendedEmaiNotif = BC00013_A11WWPUserExtendedEmaiNotif[0];
            A12WWPUserExtendedSMSNotif = BC00013_A12WWPUserExtendedSMSNotif[0];
            A13WWPUserExtendedMobileNotif = BC00013_A13WWPUserExtendedMobileNotif[0];
            A14WWPUserExtendedDesktopNotif = BC00013_A14WWPUserExtendedDesktopNotif[0];
            A17WWPUserExtendedDeleted = BC00013_A17WWPUserExtendedDeleted[0];
            A18WWPUserExtendedDeletedIn = BC00013_A18WWPUserExtendedDeletedIn[0];
            n18WWPUserExtendedDeletedIn = BC00013_n18WWPUserExtendedDeletedIn[0];
            A10WWPUserExtendedPhoto = BC00013_A10WWPUserExtendedPhoto[0];
            Z7WWPUserExtendedId = A7WWPUserExtendedId;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode1;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
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
         CONFIRM_010( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00012 */
            pr_default.execute(0, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_UserExtended"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z16WWPUserExtendedName, BC00012_A16WWPUserExtendedName[0]) != 0 ) || ( StringUtil.StrCmp(Z8WWPUserExtendedFullName, BC00012_A8WWPUserExtendedFullName[0]) != 0 ) || ( StringUtil.StrCmp(Z15WWPUserExtendedPhone, BC00012_A15WWPUserExtendedPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z9WWPUserExtendedEmail, BC00012_A9WWPUserExtendedEmail[0]) != 0 ) || ( Z11WWPUserExtendedEmaiNotif != BC00012_A11WWPUserExtendedEmaiNotif[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z12WWPUserExtendedSMSNotif != BC00012_A12WWPUserExtendedSMSNotif[0] ) || ( Z13WWPUserExtendedMobileNotif != BC00012_A13WWPUserExtendedMobileNotif[0] ) || ( Z14WWPUserExtendedDesktopNotif != BC00012_A14WWPUserExtendedDesktopNotif[0] ) || ( Z17WWPUserExtendedDeleted != BC00012_A17WWPUserExtendedDeleted[0] ) || ( Z18WWPUserExtendedDeletedIn != BC00012_A18WWPUserExtendedDeletedIn[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_UserExtended"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00016 */
                     pr_default.execute(4, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId, A10WWPUserExtendedPhoto, A40000WWPUserExtendedPhoto_GXI, A16WWPUserExtendedName, A8WWPUserExtendedFullName, A15WWPUserExtendedPhone, A9WWPUserExtendedEmail, A11WWPUserExtendedEmaiNotif, A12WWPUserExtendedSMSNotif, A13WWPUserExtendedMobileNotif, A14WWPUserExtendedDesktopNotif, A17WWPUserExtendedDeleted, n18WWPUserExtendedDeletedIn, A18WWPUserExtendedDeletedIn});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
                     if ( (pr_default.getStatus(4) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00017 */
                     pr_default.execute(5, new Object[] {A16WWPUserExtendedName, A8WWPUserExtendedFullName, A15WWPUserExtendedPhone, A9WWPUserExtendedEmail, A11WWPUserExtendedEmaiNotif, A12WWPUserExtendedSMSNotif, A13WWPUserExtendedMobileNotif, A14WWPUserExtendedDesktopNotif, A17WWPUserExtendedDeleted, n18WWPUserExtendedDeletedIn, A18WWPUserExtendedDeletedIn, n7WWPUserExtendedId, A7WWPUserExtendedId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_UserExtended"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC00018 */
            pr_default.execute(6, new Object[] {A10WWPUserExtendedPhoto, A40000WWPUserExtendedPhoto_GXI, n7WWPUserExtendedId, A7WWPUserExtendedId});
            pr_default.close(6);
            pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00019 */
                  pr_default.execute(7, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel011( ) ;
         Gx_mode = sMode1;
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000110 */
            pr_default.execute(8, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Notification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC000111 */
            pr_default.execute(9, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_WebClient"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000112 */
            pr_default.execute(10, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Subscription"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
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

      public void ScanKeyStart011( )
      {
         /* Using cursor BC000113 */
         pr_default.execute(11, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound1 = 1;
            A7WWPUserExtendedId = BC000113_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = BC000113_n7WWPUserExtendedId[0];
            A40000WWPUserExtendedPhoto_GXI = BC000113_A40000WWPUserExtendedPhoto_GXI[0];
            A16WWPUserExtendedName = BC000113_A16WWPUserExtendedName[0];
            A8WWPUserExtendedFullName = BC000113_A8WWPUserExtendedFullName[0];
            A15WWPUserExtendedPhone = BC000113_A15WWPUserExtendedPhone[0];
            A9WWPUserExtendedEmail = BC000113_A9WWPUserExtendedEmail[0];
            A11WWPUserExtendedEmaiNotif = BC000113_A11WWPUserExtendedEmaiNotif[0];
            A12WWPUserExtendedSMSNotif = BC000113_A12WWPUserExtendedSMSNotif[0];
            A13WWPUserExtendedMobileNotif = BC000113_A13WWPUserExtendedMobileNotif[0];
            A14WWPUserExtendedDesktopNotif = BC000113_A14WWPUserExtendedDesktopNotif[0];
            A17WWPUserExtendedDeleted = BC000113_A17WWPUserExtendedDeleted[0];
            A18WWPUserExtendedDeletedIn = BC000113_A18WWPUserExtendedDeletedIn[0];
            n18WWPUserExtendedDeletedIn = BC000113_n18WWPUserExtendedDeletedIn[0];
            A10WWPUserExtendedPhoto = BC000113_A10WWPUserExtendedPhoto[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound1 = 0;
         ScanKeyLoad011( ) ;
      }

      protected void ScanKeyLoad011( )
      {
         sMode1 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound1 = 1;
            A7WWPUserExtendedId = BC000113_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = BC000113_n7WWPUserExtendedId[0];
            A40000WWPUserExtendedPhoto_GXI = BC000113_A40000WWPUserExtendedPhoto_GXI[0];
            A16WWPUserExtendedName = BC000113_A16WWPUserExtendedName[0];
            A8WWPUserExtendedFullName = BC000113_A8WWPUserExtendedFullName[0];
            A15WWPUserExtendedPhone = BC000113_A15WWPUserExtendedPhone[0];
            A9WWPUserExtendedEmail = BC000113_A9WWPUserExtendedEmail[0];
            A11WWPUserExtendedEmaiNotif = BC000113_A11WWPUserExtendedEmaiNotif[0];
            A12WWPUserExtendedSMSNotif = BC000113_A12WWPUserExtendedSMSNotif[0];
            A13WWPUserExtendedMobileNotif = BC000113_A13WWPUserExtendedMobileNotif[0];
            A14WWPUserExtendedDesktopNotif = BC000113_A14WWPUserExtendedDesktopNotif[0];
            A17WWPUserExtendedDeleted = BC000113_A17WWPUserExtendedDeleted[0];
            A18WWPUserExtendedDeletedIn = BC000113_A18WWPUserExtendedDeletedIn[0];
            n18WWPUserExtendedDeletedIn = BC000113_n18WWPUserExtendedDeletedIn[0];
            A10WWPUserExtendedPhoto = BC000113_A10WWPUserExtendedPhoto[0];
         }
         Gx_mode = sMode1;
      }

      protected void ScanKeyEnd011( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void AddRow011( )
      {
         VarsToRow1( bcwwpbaseobjects_WWP_UserExtended) ;
      }

      protected void ReadRow011( )
      {
         RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 1) ;
      }

      protected void InitializeNonKey011( )
      {
         A10WWPUserExtendedPhoto = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         A16WWPUserExtendedName = "";
         A8WWPUserExtendedFullName = "";
         A15WWPUserExtendedPhone = "";
         A9WWPUserExtendedEmail = "";
         A11WWPUserExtendedEmaiNotif = false;
         A12WWPUserExtendedSMSNotif = false;
         A13WWPUserExtendedMobileNotif = false;
         A14WWPUserExtendedDesktopNotif = false;
         A17WWPUserExtendedDeleted = false;
         A18WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
         n18WWPUserExtendedDeletedIn = false;
         Z16WWPUserExtendedName = "";
         Z8WWPUserExtendedFullName = "";
         Z15WWPUserExtendedPhone = "";
         Z9WWPUserExtendedEmail = "";
         Z11WWPUserExtendedEmaiNotif = false;
         Z12WWPUserExtendedSMSNotif = false;
         Z13WWPUserExtendedMobileNotif = false;
         Z14WWPUserExtendedDesktopNotif = false;
         Z17WWPUserExtendedDeleted = false;
         Z18WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll011( )
      {
         A7WWPUserExtendedId = "";
         n7WWPUserExtendedId = false;
         InitializeNonKey011( ) ;
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

      public void VarsToRow1( GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended obj1 )
      {
         obj1.gxTpr_Mode = Gx_mode;
         obj1.gxTpr_Wwpuserextendedphoto = A10WWPUserExtendedPhoto;
         obj1.gxTpr_Wwpuserextendedphoto_gxi = A40000WWPUserExtendedPhoto_GXI;
         obj1.gxTpr_Wwpuserextendedname = A16WWPUserExtendedName;
         obj1.gxTpr_Wwpuserextendedfullname = A8WWPUserExtendedFullName;
         obj1.gxTpr_Wwpuserextendedphone = A15WWPUserExtendedPhone;
         obj1.gxTpr_Wwpuserextendedemail = A9WWPUserExtendedEmail;
         obj1.gxTpr_Wwpuserextendedemainotif = A11WWPUserExtendedEmaiNotif;
         obj1.gxTpr_Wwpuserextendedsmsnotif = A12WWPUserExtendedSMSNotif;
         obj1.gxTpr_Wwpuserextendedmobilenotif = A13WWPUserExtendedMobileNotif;
         obj1.gxTpr_Wwpuserextendeddesktopnotif = A14WWPUserExtendedDesktopNotif;
         obj1.gxTpr_Wwpuserextendeddeleted = A17WWPUserExtendedDeleted;
         obj1.gxTpr_Wwpuserextendeddeletedin = A18WWPUserExtendedDeletedIn;
         obj1.gxTpr_Wwpuserextendedid = A7WWPUserExtendedId;
         obj1.gxTpr_Wwpuserextendedid_Z = Z7WWPUserExtendedId;
         obj1.gxTpr_Wwpuserextendedname_Z = Z16WWPUserExtendedName;
         obj1.gxTpr_Wwpuserextendedfullname_Z = Z8WWPUserExtendedFullName;
         obj1.gxTpr_Wwpuserextendedphone_Z = Z15WWPUserExtendedPhone;
         obj1.gxTpr_Wwpuserextendedemail_Z = Z9WWPUserExtendedEmail;
         obj1.gxTpr_Wwpuserextendedemainotif_Z = Z11WWPUserExtendedEmaiNotif;
         obj1.gxTpr_Wwpuserextendedsmsnotif_Z = Z12WWPUserExtendedSMSNotif;
         obj1.gxTpr_Wwpuserextendedmobilenotif_Z = Z13WWPUserExtendedMobileNotif;
         obj1.gxTpr_Wwpuserextendeddesktopnotif_Z = Z14WWPUserExtendedDesktopNotif;
         obj1.gxTpr_Wwpuserextendeddeleted_Z = Z17WWPUserExtendedDeleted;
         obj1.gxTpr_Wwpuserextendeddeletedin_Z = Z18WWPUserExtendedDeletedIn;
         obj1.gxTpr_Wwpuserextendedphoto_gxi_Z = Z40000WWPUserExtendedPhoto_GXI;
         obj1.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n7WWPUserExtendedId));
         obj1.gxTpr_Wwpuserextendeddeletedin_N = (short)(Convert.ToInt16(n18WWPUserExtendedDeletedIn));
         obj1.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow1( GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended obj1 )
      {
         obj1.gxTpr_Wwpuserextendedid = A7WWPUserExtendedId;
         return  ;
      }

      public void RowToVars1( GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended obj1 ,
                              int forceLoad )
      {
         Gx_mode = obj1.gxTpr_Mode;
         A10WWPUserExtendedPhoto = obj1.gxTpr_Wwpuserextendedphoto;
         A40000WWPUserExtendedPhoto_GXI = obj1.gxTpr_Wwpuserextendedphoto_gxi;
         A16WWPUserExtendedName = obj1.gxTpr_Wwpuserextendedname;
         A8WWPUserExtendedFullName = obj1.gxTpr_Wwpuserextendedfullname;
         A15WWPUserExtendedPhone = obj1.gxTpr_Wwpuserextendedphone;
         A9WWPUserExtendedEmail = obj1.gxTpr_Wwpuserextendedemail;
         A11WWPUserExtendedEmaiNotif = obj1.gxTpr_Wwpuserextendedemainotif;
         A12WWPUserExtendedSMSNotif = obj1.gxTpr_Wwpuserextendedsmsnotif;
         A13WWPUserExtendedMobileNotif = obj1.gxTpr_Wwpuserextendedmobilenotif;
         A14WWPUserExtendedDesktopNotif = obj1.gxTpr_Wwpuserextendeddesktopnotif;
         A17WWPUserExtendedDeleted = obj1.gxTpr_Wwpuserextendeddeleted;
         A18WWPUserExtendedDeletedIn = obj1.gxTpr_Wwpuserextendeddeletedin;
         n18WWPUserExtendedDeletedIn = false;
         A7WWPUserExtendedId = obj1.gxTpr_Wwpuserextendedid;
         n7WWPUserExtendedId = false;
         Z7WWPUserExtendedId = obj1.gxTpr_Wwpuserextendedid_Z;
         Z16WWPUserExtendedName = obj1.gxTpr_Wwpuserextendedname_Z;
         Z8WWPUserExtendedFullName = obj1.gxTpr_Wwpuserextendedfullname_Z;
         Z15WWPUserExtendedPhone = obj1.gxTpr_Wwpuserextendedphone_Z;
         Z9WWPUserExtendedEmail = obj1.gxTpr_Wwpuserextendedemail_Z;
         Z11WWPUserExtendedEmaiNotif = obj1.gxTpr_Wwpuserextendedemainotif_Z;
         Z12WWPUserExtendedSMSNotif = obj1.gxTpr_Wwpuserextendedsmsnotif_Z;
         Z13WWPUserExtendedMobileNotif = obj1.gxTpr_Wwpuserextendedmobilenotif_Z;
         Z14WWPUserExtendedDesktopNotif = obj1.gxTpr_Wwpuserextendeddesktopnotif_Z;
         Z17WWPUserExtendedDeleted = obj1.gxTpr_Wwpuserextendeddeleted_Z;
         Z18WWPUserExtendedDeletedIn = obj1.gxTpr_Wwpuserextendeddeletedin_Z;
         Z40000WWPUserExtendedPhoto_GXI = obj1.gxTpr_Wwpuserextendedphoto_gxi_Z;
         n7WWPUserExtendedId = (bool)(Convert.ToBoolean(obj1.gxTpr_Wwpuserextendedid_N));
         n18WWPUserExtendedDeletedIn = (bool)(Convert.ToBoolean(obj1.gxTpr_Wwpuserextendeddeletedin_N));
         Gx_mode = obj1.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A7WWPUserExtendedId = (string)getParm(obj,0);
         n7WWPUserExtendedId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey011( ) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z7WWPUserExtendedId = A7WWPUserExtendedId;
         }
         ZM011( -2) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
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
         RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 0) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z7WWPUserExtendedId = A7WWPUserExtendedId;
         }
         ZM011( -2) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert011( ) ;
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( StringUtil.StrCmp(A7WWPUserExtendedId, Z7WWPUserExtendedId) != 0 )
               {
                  A7WWPUserExtendedId = Z7WWPUserExtendedId;
                  n7WWPUserExtendedId = false;
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
                  Update011( ) ;
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
                  if ( StringUtil.StrCmp(A7WWPUserExtendedId, Z7WWPUserExtendedId) != 0 )
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
                        Insert011( ) ;
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
                        Insert011( ) ;
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
         RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 1) ;
         SaveImpl( ) ;
         VarsToRow1( bcwwpbaseobjects_WWP_UserExtended) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         AfterTrn( ) ;
         VarsToRow1( bcwwpbaseobjects_WWP_UserExtended) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow1( bcwwpbaseobjects_WWP_UserExtended) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended auxBC = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A7WWPUserExtendedId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_WWP_UserExtended);
               auxBC.Save();
               bcwwpbaseobjects_WWP_UserExtended.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 1) ;
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
         RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
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
               VarsToRow1( bcwwpbaseobjects_WWP_UserExtended) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow1( bcwwpbaseobjects_WWP_UserExtended) ;
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
         RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 0) ;
         GetKey011( ) ;
         if ( RcdFound1 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A7WWPUserExtendedId, Z7WWPUserExtendedId) != 0 )
            {
               A7WWPUserExtendedId = Z7WWPUserExtendedId;
               n7WWPUserExtendedId = false;
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
            if ( StringUtil.StrCmp(A7WWPUserExtendedId, Z7WWPUserExtendedId) != 0 )
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
         context.RollbackDataStores("wwpbaseobjects.wwp_userextended_bc",pr_default);
         VarsToRow1( bcwwpbaseobjects_WWP_UserExtended) ;
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
         Gx_mode = bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_WWP_UserExtended )
         {
            bcwwpbaseobjects_WWP_UserExtended = (GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow1( bcwwpbaseobjects_WWP_UserExtended) ;
            }
            else
            {
               RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars1( bcwwpbaseobjects_WWP_UserExtended, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_UserExtended WWP_UserExtended_BC
      {
         get {
            return bcwwpbaseobjects_WWP_UserExtended ;
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
            return "wwpuserextended_Execute" ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z7WWPUserExtendedId = "";
         A7WWPUserExtendedId = "";
         Z16WWPUserExtendedName = "";
         A16WWPUserExtendedName = "";
         Z8WWPUserExtendedFullName = "";
         A8WWPUserExtendedFullName = "";
         Z15WWPUserExtendedPhone = "";
         A15WWPUserExtendedPhone = "";
         Z9WWPUserExtendedEmail = "";
         A9WWPUserExtendedEmail = "";
         Z18WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
         A18WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
         Z10WWPUserExtendedPhoto = "";
         A10WWPUserExtendedPhoto = "";
         Z40000WWPUserExtendedPhoto_GXI = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         BC00014_A7WWPUserExtendedId = new string[] {""} ;
         BC00014_n7WWPUserExtendedId = new bool[] {false} ;
         BC00014_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC00014_A16WWPUserExtendedName = new string[] {""} ;
         BC00014_A8WWPUserExtendedFullName = new string[] {""} ;
         BC00014_A15WWPUserExtendedPhone = new string[] {""} ;
         BC00014_A9WWPUserExtendedEmail = new string[] {""} ;
         BC00014_A11WWPUserExtendedEmaiNotif = new bool[] {false} ;
         BC00014_A12WWPUserExtendedSMSNotif = new bool[] {false} ;
         BC00014_A13WWPUserExtendedMobileNotif = new bool[] {false} ;
         BC00014_A14WWPUserExtendedDesktopNotif = new bool[] {false} ;
         BC00014_A17WWPUserExtendedDeleted = new bool[] {false} ;
         BC00014_A18WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         BC00014_n18WWPUserExtendedDeletedIn = new bool[] {false} ;
         BC00014_A10WWPUserExtendedPhoto = new string[] {""} ;
         BC00015_A7WWPUserExtendedId = new string[] {""} ;
         BC00015_n7WWPUserExtendedId = new bool[] {false} ;
         BC00013_A7WWPUserExtendedId = new string[] {""} ;
         BC00013_n7WWPUserExtendedId = new bool[] {false} ;
         BC00013_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC00013_A16WWPUserExtendedName = new string[] {""} ;
         BC00013_A8WWPUserExtendedFullName = new string[] {""} ;
         BC00013_A15WWPUserExtendedPhone = new string[] {""} ;
         BC00013_A9WWPUserExtendedEmail = new string[] {""} ;
         BC00013_A11WWPUserExtendedEmaiNotif = new bool[] {false} ;
         BC00013_A12WWPUserExtendedSMSNotif = new bool[] {false} ;
         BC00013_A13WWPUserExtendedMobileNotif = new bool[] {false} ;
         BC00013_A14WWPUserExtendedDesktopNotif = new bool[] {false} ;
         BC00013_A17WWPUserExtendedDeleted = new bool[] {false} ;
         BC00013_A18WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         BC00013_n18WWPUserExtendedDeletedIn = new bool[] {false} ;
         BC00013_A10WWPUserExtendedPhoto = new string[] {""} ;
         sMode1 = "";
         BC00012_A7WWPUserExtendedId = new string[] {""} ;
         BC00012_n7WWPUserExtendedId = new bool[] {false} ;
         BC00012_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC00012_A16WWPUserExtendedName = new string[] {""} ;
         BC00012_A8WWPUserExtendedFullName = new string[] {""} ;
         BC00012_A15WWPUserExtendedPhone = new string[] {""} ;
         BC00012_A9WWPUserExtendedEmail = new string[] {""} ;
         BC00012_A11WWPUserExtendedEmaiNotif = new bool[] {false} ;
         BC00012_A12WWPUserExtendedSMSNotif = new bool[] {false} ;
         BC00012_A13WWPUserExtendedMobileNotif = new bool[] {false} ;
         BC00012_A14WWPUserExtendedDesktopNotif = new bool[] {false} ;
         BC00012_A17WWPUserExtendedDeleted = new bool[] {false} ;
         BC00012_A18WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         BC00012_n18WWPUserExtendedDeletedIn = new bool[] {false} ;
         BC00012_A10WWPUserExtendedPhoto = new string[] {""} ;
         BC000110_A22WWPNotificationId = new long[1] ;
         BC000111_A48WWPWebClientId = new string[] {""} ;
         BC000112_A25WWPSubscriptionId = new long[1] ;
         BC000113_A7WWPUserExtendedId = new string[] {""} ;
         BC000113_n7WWPUserExtendedId = new bool[] {false} ;
         BC000113_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000113_A16WWPUserExtendedName = new string[] {""} ;
         BC000113_A8WWPUserExtendedFullName = new string[] {""} ;
         BC000113_A15WWPUserExtendedPhone = new string[] {""} ;
         BC000113_A9WWPUserExtendedEmail = new string[] {""} ;
         BC000113_A11WWPUserExtendedEmaiNotif = new bool[] {false} ;
         BC000113_A12WWPUserExtendedSMSNotif = new bool[] {false} ;
         BC000113_A13WWPUserExtendedMobileNotif = new bool[] {false} ;
         BC000113_A14WWPUserExtendedDesktopNotif = new bool[] {false} ;
         BC000113_A17WWPUserExtendedDeleted = new bool[] {false} ;
         BC000113_A18WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         BC000113_n18WWPUserExtendedDeletedIn = new bool[] {false} ;
         BC000113_A10WWPUserExtendedPhoto = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended_bc__default(),
            new Object[][] {
                new Object[] {
               BC00012_A7WWPUserExtendedId, BC00012_A40000WWPUserExtendedPhoto_GXI, BC00012_A16WWPUserExtendedName, BC00012_A8WWPUserExtendedFullName, BC00012_A15WWPUserExtendedPhone, BC00012_A9WWPUserExtendedEmail, BC00012_A11WWPUserExtendedEmaiNotif, BC00012_A12WWPUserExtendedSMSNotif, BC00012_A13WWPUserExtendedMobileNotif, BC00012_A14WWPUserExtendedDesktopNotif,
               BC00012_A17WWPUserExtendedDeleted, BC00012_A18WWPUserExtendedDeletedIn, BC00012_n18WWPUserExtendedDeletedIn, BC00012_A10WWPUserExtendedPhoto
               }
               , new Object[] {
               BC00013_A7WWPUserExtendedId, BC00013_A40000WWPUserExtendedPhoto_GXI, BC00013_A16WWPUserExtendedName, BC00013_A8WWPUserExtendedFullName, BC00013_A15WWPUserExtendedPhone, BC00013_A9WWPUserExtendedEmail, BC00013_A11WWPUserExtendedEmaiNotif, BC00013_A12WWPUserExtendedSMSNotif, BC00013_A13WWPUserExtendedMobileNotif, BC00013_A14WWPUserExtendedDesktopNotif,
               BC00013_A17WWPUserExtendedDeleted, BC00013_A18WWPUserExtendedDeletedIn, BC00013_n18WWPUserExtendedDeletedIn, BC00013_A10WWPUserExtendedPhoto
               }
               , new Object[] {
               BC00014_A7WWPUserExtendedId, BC00014_A40000WWPUserExtendedPhoto_GXI, BC00014_A16WWPUserExtendedName, BC00014_A8WWPUserExtendedFullName, BC00014_A15WWPUserExtendedPhone, BC00014_A9WWPUserExtendedEmail, BC00014_A11WWPUserExtendedEmaiNotif, BC00014_A12WWPUserExtendedSMSNotif, BC00014_A13WWPUserExtendedMobileNotif, BC00014_A14WWPUserExtendedDesktopNotif,
               BC00014_A17WWPUserExtendedDeleted, BC00014_A18WWPUserExtendedDeletedIn, BC00014_n18WWPUserExtendedDeletedIn, BC00014_A10WWPUserExtendedPhoto
               }
               , new Object[] {
               BC00015_A7WWPUserExtendedId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000110_A22WWPNotificationId
               }
               , new Object[] {
               BC000111_A48WWPWebClientId
               }
               , new Object[] {
               BC000112_A25WWPSubscriptionId
               }
               , new Object[] {
               BC000113_A7WWPUserExtendedId, BC000113_A40000WWPUserExtendedPhoto_GXI, BC000113_A16WWPUserExtendedName, BC000113_A8WWPUserExtendedFullName, BC000113_A15WWPUserExtendedPhone, BC000113_A9WWPUserExtendedEmail, BC000113_A11WWPUserExtendedEmaiNotif, BC000113_A12WWPUserExtendedSMSNotif, BC000113_A13WWPUserExtendedMobileNotif, BC000113_A14WWPUserExtendedDesktopNotif,
               BC000113_A17WWPUserExtendedDeleted, BC000113_A18WWPUserExtendedDeletedIn, BC000113_n18WWPUserExtendedDeletedIn, BC000113_A10WWPUserExtendedPhoto
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound1 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z7WWPUserExtendedId ;
      private string A7WWPUserExtendedId ;
      private string Z15WWPUserExtendedPhone ;
      private string A15WWPUserExtendedPhone ;
      private string sMode1 ;
      private DateTime Z18WWPUserExtendedDeletedIn ;
      private DateTime A18WWPUserExtendedDeletedIn ;
      private bool Z11WWPUserExtendedEmaiNotif ;
      private bool A11WWPUserExtendedEmaiNotif ;
      private bool Z12WWPUserExtendedSMSNotif ;
      private bool A12WWPUserExtendedSMSNotif ;
      private bool Z13WWPUserExtendedMobileNotif ;
      private bool A13WWPUserExtendedMobileNotif ;
      private bool Z14WWPUserExtendedDesktopNotif ;
      private bool A14WWPUserExtendedDesktopNotif ;
      private bool Z17WWPUserExtendedDeleted ;
      private bool A17WWPUserExtendedDeleted ;
      private bool n7WWPUserExtendedId ;
      private bool n18WWPUserExtendedDeletedIn ;
      private bool Gx_longc ;
      private string Z16WWPUserExtendedName ;
      private string A16WWPUserExtendedName ;
      private string Z8WWPUserExtendedFullName ;
      private string A8WWPUserExtendedFullName ;
      private string Z9WWPUserExtendedEmail ;
      private string A9WWPUserExtendedEmail ;
      private string Z40000WWPUserExtendedPhoto_GXI ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string Z10WWPUserExtendedPhoto ;
      private string A10WWPUserExtendedPhoto ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC00014_A7WWPUserExtendedId ;
      private bool[] BC00014_n7WWPUserExtendedId ;
      private string[] BC00014_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC00014_A16WWPUserExtendedName ;
      private string[] BC00014_A8WWPUserExtendedFullName ;
      private string[] BC00014_A15WWPUserExtendedPhone ;
      private string[] BC00014_A9WWPUserExtendedEmail ;
      private bool[] BC00014_A11WWPUserExtendedEmaiNotif ;
      private bool[] BC00014_A12WWPUserExtendedSMSNotif ;
      private bool[] BC00014_A13WWPUserExtendedMobileNotif ;
      private bool[] BC00014_A14WWPUserExtendedDesktopNotif ;
      private bool[] BC00014_A17WWPUserExtendedDeleted ;
      private DateTime[] BC00014_A18WWPUserExtendedDeletedIn ;
      private bool[] BC00014_n18WWPUserExtendedDeletedIn ;
      private string[] BC00014_A10WWPUserExtendedPhoto ;
      private string[] BC00015_A7WWPUserExtendedId ;
      private bool[] BC00015_n7WWPUserExtendedId ;
      private string[] BC00013_A7WWPUserExtendedId ;
      private bool[] BC00013_n7WWPUserExtendedId ;
      private string[] BC00013_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC00013_A16WWPUserExtendedName ;
      private string[] BC00013_A8WWPUserExtendedFullName ;
      private string[] BC00013_A15WWPUserExtendedPhone ;
      private string[] BC00013_A9WWPUserExtendedEmail ;
      private bool[] BC00013_A11WWPUserExtendedEmaiNotif ;
      private bool[] BC00013_A12WWPUserExtendedSMSNotif ;
      private bool[] BC00013_A13WWPUserExtendedMobileNotif ;
      private bool[] BC00013_A14WWPUserExtendedDesktopNotif ;
      private bool[] BC00013_A17WWPUserExtendedDeleted ;
      private DateTime[] BC00013_A18WWPUserExtendedDeletedIn ;
      private bool[] BC00013_n18WWPUserExtendedDeletedIn ;
      private string[] BC00013_A10WWPUserExtendedPhoto ;
      private string[] BC00012_A7WWPUserExtendedId ;
      private bool[] BC00012_n7WWPUserExtendedId ;
      private string[] BC00012_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC00012_A16WWPUserExtendedName ;
      private string[] BC00012_A8WWPUserExtendedFullName ;
      private string[] BC00012_A15WWPUserExtendedPhone ;
      private string[] BC00012_A9WWPUserExtendedEmail ;
      private bool[] BC00012_A11WWPUserExtendedEmaiNotif ;
      private bool[] BC00012_A12WWPUserExtendedSMSNotif ;
      private bool[] BC00012_A13WWPUserExtendedMobileNotif ;
      private bool[] BC00012_A14WWPUserExtendedDesktopNotif ;
      private bool[] BC00012_A17WWPUserExtendedDeleted ;
      private DateTime[] BC00012_A18WWPUserExtendedDeletedIn ;
      private bool[] BC00012_n18WWPUserExtendedDeletedIn ;
      private string[] BC00012_A10WWPUserExtendedPhoto ;
      private long[] BC000110_A22WWPNotificationId ;
      private string[] BC000111_A48WWPWebClientId ;
      private long[] BC000112_A25WWPSubscriptionId ;
      private string[] BC000113_A7WWPUserExtendedId ;
      private bool[] BC000113_n7WWPUserExtendedId ;
      private string[] BC000113_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000113_A16WWPUserExtendedName ;
      private string[] BC000113_A8WWPUserExtendedFullName ;
      private string[] BC000113_A15WWPUserExtendedPhone ;
      private string[] BC000113_A9WWPUserExtendedEmail ;
      private bool[] BC000113_A11WWPUserExtendedEmaiNotif ;
      private bool[] BC000113_A12WWPUserExtendedSMSNotif ;
      private bool[] BC000113_A13WWPUserExtendedMobileNotif ;
      private bool[] BC000113_A14WWPUserExtendedDesktopNotif ;
      private bool[] BC000113_A17WWPUserExtendedDeleted ;
      private DateTime[] BC000113_A18WWPUserExtendedDeletedIn ;
      private bool[] BC000113_n18WWPUserExtendedDeletedIn ;
      private string[] BC000113_A10WWPUserExtendedPhoto ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended bcwwpbaseobjects_WWP_UserExtended ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_userextended_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_userextended_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00012;
        prmBC00012 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00013;
        prmBC00013 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00014;
        prmBC00014 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00015;
        prmBC00015 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00016;
        prmBC00016 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPUserExtendedPhoto",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("WWPUserExtendedPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="WWP_UserExtended", Fld="WWPUserExtendedPhoto"} ,
        new ParDef("WWPUserExtendedName",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedFullName",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedPhone",GXType.Char,20,0) ,
        new ParDef("WWPUserExtendedEmail",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedEmaiNotif",GXType.Boolean,100,0) ,
        new ParDef("WWPUserExtendedSMSNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedMobileNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDesktopNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDeleted",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDeletedIn",GXType.DateTime,8,5){Nullable=true}
        };
        Object[] prmBC00017;
        prmBC00017 = new Object[] {
        new ParDef("WWPUserExtendedName",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedFullName",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedPhone",GXType.Char,20,0) ,
        new ParDef("WWPUserExtendedEmail",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedEmaiNotif",GXType.Boolean,100,0) ,
        new ParDef("WWPUserExtendedSMSNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedMobileNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDesktopNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDeleted",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDeletedIn",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00018;
        prmBC00018 = new Object[] {
        new ParDef("WWPUserExtendedPhoto",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("WWPUserExtendedPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="WWP_UserExtended", Fld="WWPUserExtendedPhoto"} ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00019;
        prmBC00019 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000110;
        prmBC000110 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000111;
        prmBC000111 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000112;
        prmBC000112 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000113;
        prmBC000113 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC00012", "SELECT WWPUserExtendedId, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId  FOR UPDATE OF WWP_UserExtended",true, GxErrorMask.GX_NOMASK, false, this,prmBC00012,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00013", "SELECT WWPUserExtendedId, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00013,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00014", "SELECT TM1.WWPUserExtendedId, TM1.WWPUserExtendedPhoto_GXI, TM1.WWPUserExtendedName, TM1.WWPUserExtendedFullName, TM1.WWPUserExtendedPhone, TM1.WWPUserExtendedEmail, TM1.WWPUserExtendedEmaiNotif, TM1.WWPUserExtendedSMSNotif, TM1.WWPUserExtendedMobileNotif, TM1.WWPUserExtendedDesktopNotif, TM1.WWPUserExtendedDeleted, TM1.WWPUserExtendedDeletedIn, TM1.WWPUserExtendedPhoto FROM WWP_UserExtended TM1 WHERE TM1.WWPUserExtendedId = ( :WWPUserExtendedId) ORDER BY TM1.WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00014,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00015", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00015,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00016", "SAVEPOINT gxupdate;INSERT INTO WWP_UserExtended(WWPUserExtendedId, WWPUserExtendedPhoto, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn) VALUES(:WWPUserExtendedId, :WWPUserExtendedPhoto, :WWPUserExtendedPhoto_GXI, :WWPUserExtendedName, :WWPUserExtendedFullName, :WWPUserExtendedPhone, :WWPUserExtendedEmail, :WWPUserExtendedEmaiNotif, :WWPUserExtendedSMSNotif, :WWPUserExtendedMobileNotif, :WWPUserExtendedDesktopNotif, :WWPUserExtendedDeleted, :WWPUserExtendedDeletedIn);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00016)
           ,new CursorDef("BC00017", "SAVEPOINT gxupdate;UPDATE WWP_UserExtended SET WWPUserExtendedName=:WWPUserExtendedName, WWPUserExtendedFullName=:WWPUserExtendedFullName, WWPUserExtendedPhone=:WWPUserExtendedPhone, WWPUserExtendedEmail=:WWPUserExtendedEmail, WWPUserExtendedEmaiNotif=:WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif=:WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif=:WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif=:WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted=:WWPUserExtendedDeleted, WWPUserExtendedDeletedIn=:WWPUserExtendedDeletedIn  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00017)
           ,new CursorDef("BC00018", "SAVEPOINT gxupdate;UPDATE WWP_UserExtended SET WWPUserExtendedPhoto=:WWPUserExtendedPhoto, WWPUserExtendedPhoto_GXI=:WWPUserExtendedPhoto_GXI  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00018)
           ,new CursorDef("BC00019", "SAVEPOINT gxupdate;DELETE FROM WWP_UserExtended  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00019)
           ,new CursorDef("BC000110", "SELECT WWPNotificationId FROM WWP_Notification WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000110,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000111", "SELECT WWPWebClientId FROM WWP_WebClient WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000111,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000112", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000112,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000113", "SELECT TM1.WWPUserExtendedId, TM1.WWPUserExtendedPhoto_GXI, TM1.WWPUserExtendedName, TM1.WWPUserExtendedFullName, TM1.WWPUserExtendedPhone, TM1.WWPUserExtendedEmail, TM1.WWPUserExtendedEmaiNotif, TM1.WWPUserExtendedSMSNotif, TM1.WWPUserExtendedMobileNotif, TM1.WWPUserExtendedDesktopNotif, TM1.WWPUserExtendedDeleted, TM1.WWPUserExtendedDeletedIn, TM1.WWPUserExtendedPhoto FROM WWP_UserExtended TM1 WHERE TM1.WWPUserExtendedId = ( :WWPUserExtendedId) ORDER BY TM1.WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000113,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
              return;
     }
  }

}

}
