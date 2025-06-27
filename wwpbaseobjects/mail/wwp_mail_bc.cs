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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_mail_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_mail_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_mail_bc( IGxContext context )
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
         ReadRow0B11( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0B11( ) ;
         standaloneModal( ) ;
         AddRow0B11( ) ;
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
               Z80WWPMailId = A80WWPMailId;
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

      protected void CONFIRM_0B0( )
      {
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0B11( ) ;
            }
            else
            {
               CheckExtendedTable0B11( ) ;
               if ( AnyError == 0 )
               {
                  ZM0B11( 6) ;
               }
               CloseExtendedTableCursors0B11( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode11 = Gx_mode;
            CONFIRM_0B12( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode11;
            }
            /* Restore parent mode. */
            Gx_mode = sMode11;
         }
      }

      protected void CONFIRM_0B12( )
      {
         nGXsfl_12_idx = 0;
         while ( nGXsfl_12_idx < bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Count )
         {
            ReadRow0B12( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound12 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_12 != 0 ) )
            {
               GetKey0B12( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound12 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0B12( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0B12( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0B12( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound12 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0B12( ) ;
                        Load0B12( ) ;
                        BeforeValidate0B12( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0B12( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_12 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0B12( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0B12( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0B12( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow12( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_12_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ZM0B11( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z69WWPMailSubject = A69WWPMailSubject;
            Z81WWPMailStatus = A81WWPMailStatus;
            Z91WWPMailCreated = A91WWPMailCreated;
            Z92WWPMailScheduled = A92WWPMailScheduled;
            Z86WWPMailProcessed = A86WWPMailProcessed;
            Z22WWPNotificationId = A22WWPNotificationId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z24WWPNotificationCreated = A24WWPNotificationCreated;
         }
         if ( GX_JID == -5 )
         {
            Z80WWPMailId = A80WWPMailId;
            Z69WWPMailSubject = A69WWPMailSubject;
            Z61WWPMailBody = A61WWPMailBody;
            Z70WWPMailTo = A70WWPMailTo;
            Z83WWPMailCC = A83WWPMailCC;
            Z84WWPMailBCC = A84WWPMailBCC;
            Z71WWPMailSenderAddress = A71WWPMailSenderAddress;
            Z72WWPMailSenderName = A72WWPMailSenderName;
            Z81WWPMailStatus = A81WWPMailStatus;
            Z91WWPMailCreated = A91WWPMailCreated;
            Z92WWPMailScheduled = A92WWPMailScheduled;
            Z86WWPMailProcessed = A86WWPMailProcessed;
            Z87WWPMailDetail = A87WWPMailDetail;
            Z22WWPNotificationId = A22WWPNotificationId;
            Z24WWPNotificationCreated = A24WWPNotificationCreated;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A81WWPMailStatus) && ( Gx_BScreen == 0 ) )
         {
            A81WWPMailStatus = 1;
         }
         if ( IsIns( )  && (DateTime.MinValue==A91WWPMailCreated) && ( Gx_BScreen == 0 ) )
         {
            A91WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A92WWPMailScheduled) && ( Gx_BScreen == 0 ) )
         {
            A92WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0B11( )
      {
         /* Using cursor BC000B7 */
         pr_default.execute(5, new Object[] {A80WWPMailId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound11 = 1;
            A69WWPMailSubject = BC000B7_A69WWPMailSubject[0];
            A61WWPMailBody = BC000B7_A61WWPMailBody[0];
            A70WWPMailTo = BC000B7_A70WWPMailTo[0];
            n70WWPMailTo = BC000B7_n70WWPMailTo[0];
            A83WWPMailCC = BC000B7_A83WWPMailCC[0];
            n83WWPMailCC = BC000B7_n83WWPMailCC[0];
            A84WWPMailBCC = BC000B7_A84WWPMailBCC[0];
            n84WWPMailBCC = BC000B7_n84WWPMailBCC[0];
            A71WWPMailSenderAddress = BC000B7_A71WWPMailSenderAddress[0];
            A72WWPMailSenderName = BC000B7_A72WWPMailSenderName[0];
            A81WWPMailStatus = BC000B7_A81WWPMailStatus[0];
            A91WWPMailCreated = BC000B7_A91WWPMailCreated[0];
            A92WWPMailScheduled = BC000B7_A92WWPMailScheduled[0];
            A86WWPMailProcessed = BC000B7_A86WWPMailProcessed[0];
            n86WWPMailProcessed = BC000B7_n86WWPMailProcessed[0];
            A87WWPMailDetail = BC000B7_A87WWPMailDetail[0];
            n87WWPMailDetail = BC000B7_n87WWPMailDetail[0];
            A24WWPNotificationCreated = BC000B7_A24WWPNotificationCreated[0];
            A22WWPNotificationId = BC000B7_A22WWPNotificationId[0];
            n22WWPNotificationId = BC000B7_n22WWPNotificationId[0];
            ZM0B11( -5) ;
         }
         pr_default.close(5);
         OnLoadActions0B11( ) ;
      }

      protected void OnLoadActions0B11( )
      {
      }

      protected void CheckExtendedTable0B11( )
      {
         standaloneModal( ) ;
         if ( ! ( ( A81WWPMailStatus == 1 ) || ( A81WWPMailStatus == 2 ) || ( A81WWPMailStatus == 3 ) ) )
         {
            GX_msglist.addItem("Field Mail Status is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000B6 */
         pr_default.execute(4, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A22WWPNotificationId) ) )
            {
               GX_msglist.addItem("No matching 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
            }
         }
         A24WWPNotificationCreated = BC000B6_A24WWPNotificationCreated[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0B11( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0B11( )
      {
         /* Using cursor BC000B8 */
         pr_default.execute(6, new Object[] {A80WWPMailId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000B5 */
         pr_default.execute(3, new Object[] {A80WWPMailId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0B11( 5) ;
            RcdFound11 = 1;
            A80WWPMailId = BC000B5_A80WWPMailId[0];
            A69WWPMailSubject = BC000B5_A69WWPMailSubject[0];
            A61WWPMailBody = BC000B5_A61WWPMailBody[0];
            A70WWPMailTo = BC000B5_A70WWPMailTo[0];
            n70WWPMailTo = BC000B5_n70WWPMailTo[0];
            A83WWPMailCC = BC000B5_A83WWPMailCC[0];
            n83WWPMailCC = BC000B5_n83WWPMailCC[0];
            A84WWPMailBCC = BC000B5_A84WWPMailBCC[0];
            n84WWPMailBCC = BC000B5_n84WWPMailBCC[0];
            A71WWPMailSenderAddress = BC000B5_A71WWPMailSenderAddress[0];
            A72WWPMailSenderName = BC000B5_A72WWPMailSenderName[0];
            A81WWPMailStatus = BC000B5_A81WWPMailStatus[0];
            A91WWPMailCreated = BC000B5_A91WWPMailCreated[0];
            A92WWPMailScheduled = BC000B5_A92WWPMailScheduled[0];
            A86WWPMailProcessed = BC000B5_A86WWPMailProcessed[0];
            n86WWPMailProcessed = BC000B5_n86WWPMailProcessed[0];
            A87WWPMailDetail = BC000B5_A87WWPMailDetail[0];
            n87WWPMailDetail = BC000B5_n87WWPMailDetail[0];
            A22WWPNotificationId = BC000B5_A22WWPNotificationId[0];
            n22WWPNotificationId = BC000B5_n22WWPNotificationId[0];
            Z80WWPMailId = A80WWPMailId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0B11( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0B11( ) ;
            }
            Gx_mode = sMode11;
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0B11( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode11;
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B11( ) ;
         if ( RcdFound11 == 0 )
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
         CONFIRM_0B0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0B11( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000B4 */
            pr_default.execute(2, new Object[] {A80WWPMailId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z69WWPMailSubject, BC000B4_A69WWPMailSubject[0]) != 0 ) || ( Z81WWPMailStatus != BC000B4_A81WWPMailStatus[0] ) || ( Z91WWPMailCreated != BC000B4_A91WWPMailCreated[0] ) || ( Z92WWPMailScheduled != BC000B4_A92WWPMailScheduled[0] ) || ( Z86WWPMailProcessed != BC000B4_A86WWPMailProcessed[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z22WWPNotificationId != BC000B4_A22WWPNotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Mail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B11( )
      {
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B11( 0) ;
            CheckOptimisticConcurrency0B11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B9 */
                     pr_default.execute(7, new Object[] {A69WWPMailSubject, A61WWPMailBody, n70WWPMailTo, A70WWPMailTo, n83WWPMailCC, A83WWPMailCC, n84WWPMailBCC, A84WWPMailBCC, A71WWPMailSenderAddress, A72WWPMailSenderName, A81WWPMailStatus, A91WWPMailCreated, A92WWPMailScheduled, n86WWPMailProcessed, A86WWPMailProcessed, n87WWPMailDetail, A87WWPMailDetail, n22WWPNotificationId, A22WWPNotificationId});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000B10 */
                     pr_default.execute(8);
                     A80WWPMailId = BC000B10_A80WWPMailId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0B11( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load0B11( ) ;
            }
            EndLevel0B11( ) ;
         }
         CloseExtendedTableCursors0B11( ) ;
      }

      protected void Update0B11( )
      {
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B11 */
                     pr_default.execute(9, new Object[] {A69WWPMailSubject, A61WWPMailBody, n70WWPMailTo, A70WWPMailTo, n83WWPMailCC, A83WWPMailCC, n84WWPMailBCC, A84WWPMailBCC, A71WWPMailSenderAddress, A72WWPMailSenderName, A81WWPMailStatus, A91WWPMailCreated, A92WWPMailScheduled, n86WWPMailProcessed, A86WWPMailProcessed, n87WWPMailDetail, A87WWPMailDetail, n22WWPNotificationId, A22WWPNotificationId, A80WWPMailId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B11( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0B11( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel0B11( ) ;
         }
         CloseExtendedTableCursors0B11( ) ;
      }

      protected void DeferredUpdate0B11( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B11( ) ;
            AfterConfirm0B11( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B11( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0B12( ) ;
                  while ( RcdFound12 != 0 )
                  {
                     getByPrimaryKey0B12( ) ;
                     Delete0B12( ) ;
                     ScanKeyNext0B12( ) ;
                  }
                  ScanKeyEnd0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B12 */
                     pr_default.execute(10, new Object[] {A80WWPMailId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
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
         }
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0B11( ) ;
         Gx_mode = sMode11;
      }

      protected void OnDeleteControls0B11( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000B13 */
            pr_default.execute(11, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
            A24WWPNotificationCreated = BC000B13_A24WWPNotificationCreated[0];
            pr_default.close(11);
         }
      }

      protected void ProcessNestedLevel0B12( )
      {
         nGXsfl_12_idx = 0;
         while ( nGXsfl_12_idx < bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Count )
         {
            ReadRow0B12( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound12 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_12 != 0 ) )
            {
               standaloneNotModal0B12( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0B12( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0B12( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0B12( ) ;
                  }
               }
            }
            KeyVarsToRow12( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_12_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_12_idx = 0;
            while ( nGXsfl_12_idx < bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Count )
            {
               ReadRow0B12( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound12 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.RemoveElement(nGXsfl_12_idx);
                  nGXsfl_12_idx = (int)(nGXsfl_12_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0B12( ) ;
                  VarsToRow12( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_12_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0B12( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_12 = 0;
         nIsMod_12 = 0;
      }

      protected void ProcessLevel0B11( )
      {
         /* Save parent mode. */
         sMode11 = Gx_mode;
         ProcessNestedLevel0B12( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode11;
         /* ' Update level parameters */
      }

      protected void EndLevel0B11( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B11( ) ;
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

      public void ScanKeyStart0B11( )
      {
         /* Using cursor BC000B14 */
         pr_default.execute(12, new Object[] {A80WWPMailId});
         RcdFound11 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound11 = 1;
            A80WWPMailId = BC000B14_A80WWPMailId[0];
            A69WWPMailSubject = BC000B14_A69WWPMailSubject[0];
            A61WWPMailBody = BC000B14_A61WWPMailBody[0];
            A70WWPMailTo = BC000B14_A70WWPMailTo[0];
            n70WWPMailTo = BC000B14_n70WWPMailTo[0];
            A83WWPMailCC = BC000B14_A83WWPMailCC[0];
            n83WWPMailCC = BC000B14_n83WWPMailCC[0];
            A84WWPMailBCC = BC000B14_A84WWPMailBCC[0];
            n84WWPMailBCC = BC000B14_n84WWPMailBCC[0];
            A71WWPMailSenderAddress = BC000B14_A71WWPMailSenderAddress[0];
            A72WWPMailSenderName = BC000B14_A72WWPMailSenderName[0];
            A81WWPMailStatus = BC000B14_A81WWPMailStatus[0];
            A91WWPMailCreated = BC000B14_A91WWPMailCreated[0];
            A92WWPMailScheduled = BC000B14_A92WWPMailScheduled[0];
            A86WWPMailProcessed = BC000B14_A86WWPMailProcessed[0];
            n86WWPMailProcessed = BC000B14_n86WWPMailProcessed[0];
            A87WWPMailDetail = BC000B14_A87WWPMailDetail[0];
            n87WWPMailDetail = BC000B14_n87WWPMailDetail[0];
            A24WWPNotificationCreated = BC000B14_A24WWPNotificationCreated[0];
            A22WWPNotificationId = BC000B14_A22WWPNotificationId[0];
            n22WWPNotificationId = BC000B14_n22WWPNotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0B11( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound11 = 0;
         ScanKeyLoad0B11( ) ;
      }

      protected void ScanKeyLoad0B11( )
      {
         sMode11 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound11 = 1;
            A80WWPMailId = BC000B14_A80WWPMailId[0];
            A69WWPMailSubject = BC000B14_A69WWPMailSubject[0];
            A61WWPMailBody = BC000B14_A61WWPMailBody[0];
            A70WWPMailTo = BC000B14_A70WWPMailTo[0];
            n70WWPMailTo = BC000B14_n70WWPMailTo[0];
            A83WWPMailCC = BC000B14_A83WWPMailCC[0];
            n83WWPMailCC = BC000B14_n83WWPMailCC[0];
            A84WWPMailBCC = BC000B14_A84WWPMailBCC[0];
            n84WWPMailBCC = BC000B14_n84WWPMailBCC[0];
            A71WWPMailSenderAddress = BC000B14_A71WWPMailSenderAddress[0];
            A72WWPMailSenderName = BC000B14_A72WWPMailSenderName[0];
            A81WWPMailStatus = BC000B14_A81WWPMailStatus[0];
            A91WWPMailCreated = BC000B14_A91WWPMailCreated[0];
            A92WWPMailScheduled = BC000B14_A92WWPMailScheduled[0];
            A86WWPMailProcessed = BC000B14_A86WWPMailProcessed[0];
            n86WWPMailProcessed = BC000B14_n86WWPMailProcessed[0];
            A87WWPMailDetail = BC000B14_A87WWPMailDetail[0];
            n87WWPMailDetail = BC000B14_n87WWPMailDetail[0];
            A24WWPNotificationCreated = BC000B14_A24WWPNotificationCreated[0];
            A22WWPNotificationId = BC000B14_A22WWPNotificationId[0];
            n22WWPNotificationId = BC000B14_n22WWPNotificationId[0];
         }
         Gx_mode = sMode11;
      }

      protected void ScanKeyEnd0B11( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0B11( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B11( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B11( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B11( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B11( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B11( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B11( )
      {
      }

      protected void ZM0B12( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -7 )
         {
            Z80WWPMailId = A80WWPMailId;
            Z93WWPMailAttachmentName = A93WWPMailAttachmentName;
            Z85WWPMailAttachmentFile = A85WWPMailAttachmentFile;
         }
      }

      protected void standaloneNotModal0B12( )
      {
      }

      protected void standaloneModal0B12( )
      {
      }

      protected void Load0B12( )
      {
         /* Using cursor BC000B15 */
         pr_default.execute(13, new Object[] {A80WWPMailId, A93WWPMailAttachmentName});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound12 = 1;
            A85WWPMailAttachmentFile = BC000B15_A85WWPMailAttachmentFile[0];
            ZM0B12( -7) ;
         }
         pr_default.close(13);
         OnLoadActions0B12( ) ;
      }

      protected void OnLoadActions0B12( )
      {
      }

      protected void CheckExtendedTable0B12( )
      {
         Gx_BScreen = 1;
         standaloneModal0B12( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors0B12( )
      {
      }

      protected void enableDisable0B12( )
      {
      }

      protected void GetKey0B12( )
      {
         /* Using cursor BC000B16 */
         pr_default.execute(14, new Object[] {A80WWPMailId, A93WWPMailAttachmentName});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey0B12( )
      {
         /* Using cursor BC000B3 */
         pr_default.execute(1, new Object[] {A80WWPMailId, A93WWPMailAttachmentName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B12( 7) ;
            RcdFound12 = 1;
            InitializeNonKey0B12( ) ;
            A93WWPMailAttachmentName = BC000B3_A93WWPMailAttachmentName[0];
            A85WWPMailAttachmentFile = BC000B3_A85WWPMailAttachmentFile[0];
            Z80WWPMailId = A80WWPMailId;
            Z93WWPMailAttachmentName = A93WWPMailAttachmentName;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0B12( ) ;
            Load0B12( ) ;
            Gx_mode = sMode12;
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0B12( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0B12( ) ;
            Gx_mode = sMode12;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0B12( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0B12( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000B2 */
            pr_default.execute(0, new Object[] {A80WWPMailId, A93WWPMailAttachmentName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_MailAttachments"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B12( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B12( 0) ;
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B17 */
                     pr_default.execute(15, new Object[] {A80WWPMailId, A93WWPMailAttachmentName, A85WWPMailAttachmentFile});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                     if ( (pr_default.getStatus(15) == 1) )
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
               Load0B12( ) ;
            }
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void Update0B12( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B18 */
                     pr_default.execute(16, new Object[] {A85WWPMailAttachmentFile, A80WWPMailId, A93WWPMailAttachmentName});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B12( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0B12( ) ;
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
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void DeferredUpdate0B12( )
      {
      }

      protected void Delete0B12( )
      {
         Gx_mode = "DLT";
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B12( ) ;
            AfterConfirm0B12( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B12( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000B19 */
                  pr_default.execute(17, new Object[] {A80WWPMailId, A93WWPMailAttachmentName});
                  pr_default.close(17);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0B12( ) ;
         Gx_mode = sMode12;
      }

      protected void OnDeleteControls0B12( )
      {
         standaloneModal0B12( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0B12( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0B12( )
      {
         /* Scan By routine */
         /* Using cursor BC000B20 */
         pr_default.execute(18, new Object[] {A80WWPMailId});
         RcdFound12 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound12 = 1;
            A93WWPMailAttachmentName = BC000B20_A93WWPMailAttachmentName[0];
            A85WWPMailAttachmentFile = BC000B20_A85WWPMailAttachmentFile[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0B12( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound12 = 0;
         ScanKeyLoad0B12( ) ;
      }

      protected void ScanKeyLoad0B12( )
      {
         sMode12 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound12 = 1;
            A93WWPMailAttachmentName = BC000B20_A93WWPMailAttachmentName[0];
            A85WWPMailAttachmentFile = BC000B20_A85WWPMailAttachmentFile[0];
         }
         Gx_mode = sMode12;
      }

      protected void ScanKeyEnd0B12( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0B12( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B12( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B12( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B12( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B12( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B12( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B12( )
      {
      }

      protected void send_integrity_lvl_hashes0B12( )
      {
      }

      protected void send_integrity_lvl_hashes0B11( )
      {
      }

      protected void AddRow0B11( )
      {
         VarsToRow11( bcwwpbaseobjects_mail_WWP_Mail) ;
      }

      protected void ReadRow0B11( )
      {
         RowToVars11( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
      }

      protected void AddRow0B12( )
      {
         GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj12;
         obj12 = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments(context);
         VarsToRow12( obj12) ;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Add(obj12, 0);
         obj12.gxTpr_Mode = "UPD";
         obj12.gxTpr_Modified = 0;
      }

      protected void ReadRow0B12( )
      {
         nGXsfl_12_idx = (int)(nGXsfl_12_idx+1);
         RowToVars12( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_12_idx)), 1) ;
      }

      protected void InitializeNonKey0B11( )
      {
         A69WWPMailSubject = "";
         A61WWPMailBody = "";
         A70WWPMailTo = "";
         n70WWPMailTo = false;
         A83WWPMailCC = "";
         n83WWPMailCC = false;
         A84WWPMailBCC = "";
         n84WWPMailBCC = false;
         A71WWPMailSenderAddress = "";
         A72WWPMailSenderName = "";
         A86WWPMailProcessed = (DateTime)(DateTime.MinValue);
         n86WWPMailProcessed = false;
         A87WWPMailDetail = "";
         n87WWPMailDetail = false;
         A22WWPNotificationId = 0;
         n22WWPNotificationId = false;
         A24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A81WWPMailStatus = 1;
         A91WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A92WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z69WWPMailSubject = "";
         Z81WWPMailStatus = 0;
         Z91WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z92WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z86WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z22WWPNotificationId = 0;
      }

      protected void InitAll0B11( )
      {
         A80WWPMailId = 0;
         InitializeNonKey0B11( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A81WWPMailStatus = i81WWPMailStatus;
         A91WWPMailCreated = i91WWPMailCreated;
         A92WWPMailScheduled = i92WWPMailScheduled;
      }

      protected void InitializeNonKey0B12( )
      {
         A85WWPMailAttachmentFile = "";
      }

      protected void InitAll0B12( )
      {
         A93WWPMailAttachmentName = "";
         InitializeNonKey0B12( ) ;
      }

      protected void StandaloneModalInsert0B12( )
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

      public void VarsToRow11( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail obj11 )
      {
         obj11.gxTpr_Mode = Gx_mode;
         obj11.gxTpr_Wwpmailsubject = A69WWPMailSubject;
         obj11.gxTpr_Wwpmailbody = A61WWPMailBody;
         obj11.gxTpr_Wwpmailto = A70WWPMailTo;
         obj11.gxTpr_Wwpmailcc = A83WWPMailCC;
         obj11.gxTpr_Wwpmailbcc = A84WWPMailBCC;
         obj11.gxTpr_Wwpmailsenderaddress = A71WWPMailSenderAddress;
         obj11.gxTpr_Wwpmailsendername = A72WWPMailSenderName;
         obj11.gxTpr_Wwpmailprocessed = A86WWPMailProcessed;
         obj11.gxTpr_Wwpmaildetail = A87WWPMailDetail;
         obj11.gxTpr_Wwpnotificationid = A22WWPNotificationId;
         obj11.gxTpr_Wwpnotificationcreated = A24WWPNotificationCreated;
         obj11.gxTpr_Wwpmailstatus = A81WWPMailStatus;
         obj11.gxTpr_Wwpmailcreated = A91WWPMailCreated;
         obj11.gxTpr_Wwpmailscheduled = A92WWPMailScheduled;
         obj11.gxTpr_Wwpmailid = A80WWPMailId;
         obj11.gxTpr_Wwpmailid_Z = Z80WWPMailId;
         obj11.gxTpr_Wwpmailsubject_Z = Z69WWPMailSubject;
         obj11.gxTpr_Wwpmailstatus_Z = Z81WWPMailStatus;
         obj11.gxTpr_Wwpmailcreated_Z = Z91WWPMailCreated;
         obj11.gxTpr_Wwpmailscheduled_Z = Z92WWPMailScheduled;
         obj11.gxTpr_Wwpmailprocessed_Z = Z86WWPMailProcessed;
         obj11.gxTpr_Wwpnotificationid_Z = Z22WWPNotificationId;
         obj11.gxTpr_Wwpnotificationcreated_Z = Z24WWPNotificationCreated;
         obj11.gxTpr_Wwpmailto_N = (short)(Convert.ToInt16(n70WWPMailTo));
         obj11.gxTpr_Wwpmailcc_N = (short)(Convert.ToInt16(n83WWPMailCC));
         obj11.gxTpr_Wwpmailbcc_N = (short)(Convert.ToInt16(n84WWPMailBCC));
         obj11.gxTpr_Wwpmailprocessed_N = (short)(Convert.ToInt16(n86WWPMailProcessed));
         obj11.gxTpr_Wwpmaildetail_N = (short)(Convert.ToInt16(n87WWPMailDetail));
         obj11.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n22WWPNotificationId));
         obj11.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow11( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail obj11 )
      {
         obj11.gxTpr_Wwpmailid = A80WWPMailId;
         return  ;
      }

      public void RowToVars11( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail obj11 ,
                               int forceLoad )
      {
         Gx_mode = obj11.gxTpr_Mode;
         A69WWPMailSubject = obj11.gxTpr_Wwpmailsubject;
         A61WWPMailBody = obj11.gxTpr_Wwpmailbody;
         A70WWPMailTo = obj11.gxTpr_Wwpmailto;
         n70WWPMailTo = false;
         A83WWPMailCC = obj11.gxTpr_Wwpmailcc;
         n83WWPMailCC = false;
         A84WWPMailBCC = obj11.gxTpr_Wwpmailbcc;
         n84WWPMailBCC = false;
         A71WWPMailSenderAddress = obj11.gxTpr_Wwpmailsenderaddress;
         A72WWPMailSenderName = obj11.gxTpr_Wwpmailsendername;
         A86WWPMailProcessed = obj11.gxTpr_Wwpmailprocessed;
         n86WWPMailProcessed = false;
         A87WWPMailDetail = obj11.gxTpr_Wwpmaildetail;
         n87WWPMailDetail = false;
         A22WWPNotificationId = obj11.gxTpr_Wwpnotificationid;
         n22WWPNotificationId = false;
         A24WWPNotificationCreated = obj11.gxTpr_Wwpnotificationcreated;
         A81WWPMailStatus = obj11.gxTpr_Wwpmailstatus;
         A91WWPMailCreated = obj11.gxTpr_Wwpmailcreated;
         A92WWPMailScheduled = obj11.gxTpr_Wwpmailscheduled;
         A80WWPMailId = obj11.gxTpr_Wwpmailid;
         Z80WWPMailId = obj11.gxTpr_Wwpmailid_Z;
         Z69WWPMailSubject = obj11.gxTpr_Wwpmailsubject_Z;
         Z81WWPMailStatus = obj11.gxTpr_Wwpmailstatus_Z;
         Z91WWPMailCreated = obj11.gxTpr_Wwpmailcreated_Z;
         Z92WWPMailScheduled = obj11.gxTpr_Wwpmailscheduled_Z;
         Z86WWPMailProcessed = obj11.gxTpr_Wwpmailprocessed_Z;
         Z22WWPNotificationId = obj11.gxTpr_Wwpnotificationid_Z;
         Z24WWPNotificationCreated = obj11.gxTpr_Wwpnotificationcreated_Z;
         n70WWPMailTo = (bool)(Convert.ToBoolean(obj11.gxTpr_Wwpmailto_N));
         n83WWPMailCC = (bool)(Convert.ToBoolean(obj11.gxTpr_Wwpmailcc_N));
         n84WWPMailBCC = (bool)(Convert.ToBoolean(obj11.gxTpr_Wwpmailbcc_N));
         n86WWPMailProcessed = (bool)(Convert.ToBoolean(obj11.gxTpr_Wwpmailprocessed_N));
         n87WWPMailDetail = (bool)(Convert.ToBoolean(obj11.gxTpr_Wwpmaildetail_N));
         n22WWPNotificationId = (bool)(Convert.ToBoolean(obj11.gxTpr_Wwpnotificationid_N));
         Gx_mode = obj11.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow12( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj12 )
      {
         obj12.gxTpr_Mode = Gx_mode;
         obj12.gxTpr_Wwpmailattachmentfile = A85WWPMailAttachmentFile;
         obj12.gxTpr_Wwpmailattachmentname = A93WWPMailAttachmentName;
         obj12.gxTpr_Wwpmailattachmentname_Z = Z93WWPMailAttachmentName;
         obj12.gxTpr_Modified = nIsMod_12;
         return  ;
      }

      public void KeyVarsToRow12( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj12 )
      {
         obj12.gxTpr_Wwpmailattachmentname = A93WWPMailAttachmentName;
         return  ;
      }

      public void RowToVars12( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj12 ,
                               int forceLoad )
      {
         Gx_mode = obj12.gxTpr_Mode;
         A85WWPMailAttachmentFile = obj12.gxTpr_Wwpmailattachmentfile;
         A93WWPMailAttachmentName = obj12.gxTpr_Wwpmailattachmentname;
         Z93WWPMailAttachmentName = obj12.gxTpr_Wwpmailattachmentname_Z;
         nIsMod_12 = obj12.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A80WWPMailId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0B11( ) ;
         ScanKeyStart0B11( ) ;
         if ( RcdFound11 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z80WWPMailId = A80WWPMailId;
         }
         ZM0B11( -5) ;
         OnLoadActions0B11( ) ;
         AddRow0B11( ) ;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.ClearCollection();
         if ( RcdFound11 == 1 )
         {
            ScanKeyStart0B12( ) ;
            nGXsfl_12_idx = 1;
            while ( RcdFound12 != 0 )
            {
               Z80WWPMailId = A80WWPMailId;
               Z93WWPMailAttachmentName = A93WWPMailAttachmentName;
               ZM0B12( -7) ;
               OnLoadActions0B12( ) ;
               nRcdExists_12 = 1;
               nIsMod_12 = 0;
               AddRow0B12( ) ;
               nGXsfl_12_idx = (int)(nGXsfl_12_idx+1);
               ScanKeyNext0B12( ) ;
            }
            ScanKeyEnd0B12( ) ;
         }
         ScanKeyEnd0B11( ) ;
         if ( RcdFound11 == 0 )
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
         RowToVars11( bcwwpbaseobjects_mail_WWP_Mail, 0) ;
         ScanKeyStart0B11( ) ;
         if ( RcdFound11 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z80WWPMailId = A80WWPMailId;
         }
         ZM0B11( -5) ;
         OnLoadActions0B11( ) ;
         AddRow0B11( ) ;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.ClearCollection();
         if ( RcdFound11 == 1 )
         {
            ScanKeyStart0B12( ) ;
            nGXsfl_12_idx = 1;
            while ( RcdFound12 != 0 )
            {
               Z80WWPMailId = A80WWPMailId;
               Z93WWPMailAttachmentName = A93WWPMailAttachmentName;
               ZM0B12( -7) ;
               OnLoadActions0B12( ) ;
               nRcdExists_12 = 1;
               nIsMod_12 = 0;
               AddRow0B12( ) ;
               nGXsfl_12_idx = (int)(nGXsfl_12_idx+1);
               ScanKeyNext0B12( ) ;
            }
            ScanKeyEnd0B12( ) ;
         }
         ScanKeyEnd0B11( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0B11( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0B11( ) ;
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( A80WWPMailId != Z80WWPMailId )
               {
                  A80WWPMailId = Z80WWPMailId;
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
                  Update0B11( ) ;
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
                  if ( A80WWPMailId != Z80WWPMailId )
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
                        Insert0B11( ) ;
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
                        Insert0B11( ) ;
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
         RowToVars11( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         SaveImpl( ) ;
         VarsToRow11( bcwwpbaseobjects_mail_WWP_Mail) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars11( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B11( ) ;
         AfterTrn( ) ;
         VarsToRow11( bcwwpbaseobjects_mail_WWP_Mail) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow11( bcwwpbaseobjects_mail_WWP_Mail) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail auxBC = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A80WWPMailId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_mail_WWP_Mail);
               auxBC.Save();
               bcwwpbaseobjects_mail_WWP_Mail.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars11( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
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
         RowToVars11( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B11( ) ;
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
               VarsToRow11( bcwwpbaseobjects_mail_WWP_Mail) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow11( bcwwpbaseobjects_mail_WWP_Mail) ;
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
         RowToVars11( bcwwpbaseobjects_mail_WWP_Mail, 0) ;
         GetKey0B11( ) ;
         if ( RcdFound11 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A80WWPMailId != Z80WWPMailId )
            {
               A80WWPMailId = Z80WWPMailId;
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
            if ( A80WWPMailId != Z80WWPMailId )
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
         context.RollbackDataStores("wwpbaseobjects.mail.wwp_mail_bc",pr_default);
         VarsToRow11( bcwwpbaseobjects_mail_WWP_Mail) ;
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
         Gx_mode = bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_mail_WWP_Mail )
         {
            bcwwpbaseobjects_mail_WWP_Mail = (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow11( bcwwpbaseobjects_mail_WWP_Mail) ;
            }
            else
            {
               RowToVars11( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars11( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_Mail WWP_Mail_BC
      {
         get {
            return bcwwpbaseobjects_mail_WWP_Mail ;
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
            return "wwpmail_Execute" ;
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
         pr_default.close(3);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode11 = "";
         Z69WWPMailSubject = "";
         A69WWPMailSubject = "";
         Z91WWPMailCreated = (DateTime)(DateTime.MinValue);
         A91WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z92WWPMailScheduled = (DateTime)(DateTime.MinValue);
         A92WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z86WWPMailProcessed = (DateTime)(DateTime.MinValue);
         A86WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z61WWPMailBody = "";
         A61WWPMailBody = "";
         Z70WWPMailTo = "";
         A70WWPMailTo = "";
         Z83WWPMailCC = "";
         A83WWPMailCC = "";
         Z84WWPMailBCC = "";
         A84WWPMailBCC = "";
         Z71WWPMailSenderAddress = "";
         A71WWPMailSenderAddress = "";
         Z72WWPMailSenderName = "";
         A72WWPMailSenderName = "";
         Z87WWPMailDetail = "";
         A87WWPMailDetail = "";
         BC000B7_A80WWPMailId = new long[1] ;
         BC000B7_A69WWPMailSubject = new string[] {""} ;
         BC000B7_A61WWPMailBody = new string[] {""} ;
         BC000B7_A70WWPMailTo = new string[] {""} ;
         BC000B7_n70WWPMailTo = new bool[] {false} ;
         BC000B7_A83WWPMailCC = new string[] {""} ;
         BC000B7_n83WWPMailCC = new bool[] {false} ;
         BC000B7_A84WWPMailBCC = new string[] {""} ;
         BC000B7_n84WWPMailBCC = new bool[] {false} ;
         BC000B7_A71WWPMailSenderAddress = new string[] {""} ;
         BC000B7_A72WWPMailSenderName = new string[] {""} ;
         BC000B7_A81WWPMailStatus = new short[1] ;
         BC000B7_A91WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000B7_A92WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000B7_A86WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000B7_n86WWPMailProcessed = new bool[] {false} ;
         BC000B7_A87WWPMailDetail = new string[] {""} ;
         BC000B7_n87WWPMailDetail = new bool[] {false} ;
         BC000B7_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000B7_A22WWPNotificationId = new long[1] ;
         BC000B7_n22WWPNotificationId = new bool[] {false} ;
         BC000B6_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000B8_A80WWPMailId = new long[1] ;
         BC000B5_A80WWPMailId = new long[1] ;
         BC000B5_A69WWPMailSubject = new string[] {""} ;
         BC000B5_A61WWPMailBody = new string[] {""} ;
         BC000B5_A70WWPMailTo = new string[] {""} ;
         BC000B5_n70WWPMailTo = new bool[] {false} ;
         BC000B5_A83WWPMailCC = new string[] {""} ;
         BC000B5_n83WWPMailCC = new bool[] {false} ;
         BC000B5_A84WWPMailBCC = new string[] {""} ;
         BC000B5_n84WWPMailBCC = new bool[] {false} ;
         BC000B5_A71WWPMailSenderAddress = new string[] {""} ;
         BC000B5_A72WWPMailSenderName = new string[] {""} ;
         BC000B5_A81WWPMailStatus = new short[1] ;
         BC000B5_A91WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000B5_A92WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000B5_A86WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000B5_n86WWPMailProcessed = new bool[] {false} ;
         BC000B5_A87WWPMailDetail = new string[] {""} ;
         BC000B5_n87WWPMailDetail = new bool[] {false} ;
         BC000B5_A22WWPNotificationId = new long[1] ;
         BC000B5_n22WWPNotificationId = new bool[] {false} ;
         BC000B4_A80WWPMailId = new long[1] ;
         BC000B4_A69WWPMailSubject = new string[] {""} ;
         BC000B4_A61WWPMailBody = new string[] {""} ;
         BC000B4_A70WWPMailTo = new string[] {""} ;
         BC000B4_n70WWPMailTo = new bool[] {false} ;
         BC000B4_A83WWPMailCC = new string[] {""} ;
         BC000B4_n83WWPMailCC = new bool[] {false} ;
         BC000B4_A84WWPMailBCC = new string[] {""} ;
         BC000B4_n84WWPMailBCC = new bool[] {false} ;
         BC000B4_A71WWPMailSenderAddress = new string[] {""} ;
         BC000B4_A72WWPMailSenderName = new string[] {""} ;
         BC000B4_A81WWPMailStatus = new short[1] ;
         BC000B4_A91WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000B4_A92WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000B4_A86WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000B4_n86WWPMailProcessed = new bool[] {false} ;
         BC000B4_A87WWPMailDetail = new string[] {""} ;
         BC000B4_n87WWPMailDetail = new bool[] {false} ;
         BC000B4_A22WWPNotificationId = new long[1] ;
         BC000B4_n22WWPNotificationId = new bool[] {false} ;
         BC000B10_A80WWPMailId = new long[1] ;
         BC000B13_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000B14_A80WWPMailId = new long[1] ;
         BC000B14_A69WWPMailSubject = new string[] {""} ;
         BC000B14_A61WWPMailBody = new string[] {""} ;
         BC000B14_A70WWPMailTo = new string[] {""} ;
         BC000B14_n70WWPMailTo = new bool[] {false} ;
         BC000B14_A83WWPMailCC = new string[] {""} ;
         BC000B14_n83WWPMailCC = new bool[] {false} ;
         BC000B14_A84WWPMailBCC = new string[] {""} ;
         BC000B14_n84WWPMailBCC = new bool[] {false} ;
         BC000B14_A71WWPMailSenderAddress = new string[] {""} ;
         BC000B14_A72WWPMailSenderName = new string[] {""} ;
         BC000B14_A81WWPMailStatus = new short[1] ;
         BC000B14_A91WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000B14_A92WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000B14_A86WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000B14_n86WWPMailProcessed = new bool[] {false} ;
         BC000B14_A87WWPMailDetail = new string[] {""} ;
         BC000B14_n87WWPMailDetail = new bool[] {false} ;
         BC000B14_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000B14_A22WWPNotificationId = new long[1] ;
         BC000B14_n22WWPNotificationId = new bool[] {false} ;
         Z93WWPMailAttachmentName = "";
         A93WWPMailAttachmentName = "";
         Z85WWPMailAttachmentFile = "";
         A85WWPMailAttachmentFile = "";
         BC000B15_A80WWPMailId = new long[1] ;
         BC000B15_A93WWPMailAttachmentName = new string[] {""} ;
         BC000B15_A85WWPMailAttachmentFile = new string[] {""} ;
         BC000B16_A80WWPMailId = new long[1] ;
         BC000B16_A93WWPMailAttachmentName = new string[] {""} ;
         BC000B3_A80WWPMailId = new long[1] ;
         BC000B3_A93WWPMailAttachmentName = new string[] {""} ;
         BC000B3_A85WWPMailAttachmentFile = new string[] {""} ;
         sMode12 = "";
         BC000B2_A80WWPMailId = new long[1] ;
         BC000B2_A93WWPMailAttachmentName = new string[] {""} ;
         BC000B2_A85WWPMailAttachmentFile = new string[] {""} ;
         BC000B20_A80WWPMailId = new long[1] ;
         BC000B20_A93WWPMailAttachmentName = new string[] {""} ;
         BC000B20_A85WWPMailAttachmentFile = new string[] {""} ;
         i91WWPMailCreated = (DateTime)(DateTime.MinValue);
         i92WWPMailScheduled = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail_bc__default(),
            new Object[][] {
                new Object[] {
               BC000B2_A80WWPMailId, BC000B2_A93WWPMailAttachmentName, BC000B2_A85WWPMailAttachmentFile
               }
               , new Object[] {
               BC000B3_A80WWPMailId, BC000B3_A93WWPMailAttachmentName, BC000B3_A85WWPMailAttachmentFile
               }
               , new Object[] {
               BC000B4_A80WWPMailId, BC000B4_A69WWPMailSubject, BC000B4_A61WWPMailBody, BC000B4_A70WWPMailTo, BC000B4_n70WWPMailTo, BC000B4_A83WWPMailCC, BC000B4_n83WWPMailCC, BC000B4_A84WWPMailBCC, BC000B4_n84WWPMailBCC, BC000B4_A71WWPMailSenderAddress,
               BC000B4_A72WWPMailSenderName, BC000B4_A81WWPMailStatus, BC000B4_A91WWPMailCreated, BC000B4_A92WWPMailScheduled, BC000B4_A86WWPMailProcessed, BC000B4_n86WWPMailProcessed, BC000B4_A87WWPMailDetail, BC000B4_n87WWPMailDetail, BC000B4_A22WWPNotificationId, BC000B4_n22WWPNotificationId
               }
               , new Object[] {
               BC000B5_A80WWPMailId, BC000B5_A69WWPMailSubject, BC000B5_A61WWPMailBody, BC000B5_A70WWPMailTo, BC000B5_n70WWPMailTo, BC000B5_A83WWPMailCC, BC000B5_n83WWPMailCC, BC000B5_A84WWPMailBCC, BC000B5_n84WWPMailBCC, BC000B5_A71WWPMailSenderAddress,
               BC000B5_A72WWPMailSenderName, BC000B5_A81WWPMailStatus, BC000B5_A91WWPMailCreated, BC000B5_A92WWPMailScheduled, BC000B5_A86WWPMailProcessed, BC000B5_n86WWPMailProcessed, BC000B5_A87WWPMailDetail, BC000B5_n87WWPMailDetail, BC000B5_A22WWPNotificationId, BC000B5_n22WWPNotificationId
               }
               , new Object[] {
               BC000B6_A24WWPNotificationCreated
               }
               , new Object[] {
               BC000B7_A80WWPMailId, BC000B7_A69WWPMailSubject, BC000B7_A61WWPMailBody, BC000B7_A70WWPMailTo, BC000B7_n70WWPMailTo, BC000B7_A83WWPMailCC, BC000B7_n83WWPMailCC, BC000B7_A84WWPMailBCC, BC000B7_n84WWPMailBCC, BC000B7_A71WWPMailSenderAddress,
               BC000B7_A72WWPMailSenderName, BC000B7_A81WWPMailStatus, BC000B7_A91WWPMailCreated, BC000B7_A92WWPMailScheduled, BC000B7_A86WWPMailProcessed, BC000B7_n86WWPMailProcessed, BC000B7_A87WWPMailDetail, BC000B7_n87WWPMailDetail, BC000B7_A24WWPNotificationCreated, BC000B7_A22WWPNotificationId,
               BC000B7_n22WWPNotificationId
               }
               , new Object[] {
               BC000B8_A80WWPMailId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000B10_A80WWPMailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000B13_A24WWPNotificationCreated
               }
               , new Object[] {
               BC000B14_A80WWPMailId, BC000B14_A69WWPMailSubject, BC000B14_A61WWPMailBody, BC000B14_A70WWPMailTo, BC000B14_n70WWPMailTo, BC000B14_A83WWPMailCC, BC000B14_n83WWPMailCC, BC000B14_A84WWPMailBCC, BC000B14_n84WWPMailBCC, BC000B14_A71WWPMailSenderAddress,
               BC000B14_A72WWPMailSenderName, BC000B14_A81WWPMailStatus, BC000B14_A91WWPMailCreated, BC000B14_A92WWPMailScheduled, BC000B14_A86WWPMailProcessed, BC000B14_n86WWPMailProcessed, BC000B14_A87WWPMailDetail, BC000B14_n87WWPMailDetail, BC000B14_A24WWPNotificationCreated, BC000B14_A22WWPNotificationId,
               BC000B14_n22WWPNotificationId
               }
               , new Object[] {
               BC000B15_A80WWPMailId, BC000B15_A93WWPMailAttachmentName, BC000B15_A85WWPMailAttachmentFile
               }
               , new Object[] {
               BC000B16_A80WWPMailId, BC000B16_A93WWPMailAttachmentName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000B20_A80WWPMailId, BC000B20_A93WWPMailAttachmentName, BC000B20_A85WWPMailAttachmentFile
               }
            }
         );
         Z92WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A92WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i92WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z91WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A91WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i91WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z81WWPMailStatus = 1;
         A81WWPMailStatus = 1;
         i81WWPMailStatus = 1;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_12 ;
      private short RcdFound12 ;
      private short Z81WWPMailStatus ;
      private short A81WWPMailStatus ;
      private short Gx_BScreen ;
      private short RcdFound11 ;
      private short nRcdExists_12 ;
      private short Gxremove12 ;
      private short i81WWPMailStatus ;
      private int trnEnded ;
      private int nGXsfl_12_idx=1 ;
      private long Z80WWPMailId ;
      private long A80WWPMailId ;
      private long Z22WWPNotificationId ;
      private long A22WWPNotificationId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode11 ;
      private string sMode12 ;
      private DateTime Z91WWPMailCreated ;
      private DateTime A91WWPMailCreated ;
      private DateTime Z92WWPMailScheduled ;
      private DateTime A92WWPMailScheduled ;
      private DateTime Z86WWPMailProcessed ;
      private DateTime A86WWPMailProcessed ;
      private DateTime Z24WWPNotificationCreated ;
      private DateTime A24WWPNotificationCreated ;
      private DateTime i91WWPMailCreated ;
      private DateTime i92WWPMailScheduled ;
      private bool n70WWPMailTo ;
      private bool n83WWPMailCC ;
      private bool n84WWPMailBCC ;
      private bool n86WWPMailProcessed ;
      private bool n87WWPMailDetail ;
      private bool n22WWPNotificationId ;
      private bool Gx_longc ;
      private string Z61WWPMailBody ;
      private string A61WWPMailBody ;
      private string Z70WWPMailTo ;
      private string A70WWPMailTo ;
      private string Z83WWPMailCC ;
      private string A83WWPMailCC ;
      private string Z84WWPMailBCC ;
      private string A84WWPMailBCC ;
      private string Z71WWPMailSenderAddress ;
      private string A71WWPMailSenderAddress ;
      private string Z72WWPMailSenderName ;
      private string A72WWPMailSenderName ;
      private string Z87WWPMailDetail ;
      private string A87WWPMailDetail ;
      private string Z85WWPMailAttachmentFile ;
      private string A85WWPMailAttachmentFile ;
      private string Z69WWPMailSubject ;
      private string A69WWPMailSubject ;
      private string Z93WWPMailAttachmentName ;
      private string A93WWPMailAttachmentName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail bcwwpbaseobjects_mail_WWP_Mail ;
      private IDataStoreProvider pr_default ;
      private long[] BC000B7_A80WWPMailId ;
      private string[] BC000B7_A69WWPMailSubject ;
      private string[] BC000B7_A61WWPMailBody ;
      private string[] BC000B7_A70WWPMailTo ;
      private bool[] BC000B7_n70WWPMailTo ;
      private string[] BC000B7_A83WWPMailCC ;
      private bool[] BC000B7_n83WWPMailCC ;
      private string[] BC000B7_A84WWPMailBCC ;
      private bool[] BC000B7_n84WWPMailBCC ;
      private string[] BC000B7_A71WWPMailSenderAddress ;
      private string[] BC000B7_A72WWPMailSenderName ;
      private short[] BC000B7_A81WWPMailStatus ;
      private DateTime[] BC000B7_A91WWPMailCreated ;
      private DateTime[] BC000B7_A92WWPMailScheduled ;
      private DateTime[] BC000B7_A86WWPMailProcessed ;
      private bool[] BC000B7_n86WWPMailProcessed ;
      private string[] BC000B7_A87WWPMailDetail ;
      private bool[] BC000B7_n87WWPMailDetail ;
      private DateTime[] BC000B7_A24WWPNotificationCreated ;
      private long[] BC000B7_A22WWPNotificationId ;
      private bool[] BC000B7_n22WWPNotificationId ;
      private DateTime[] BC000B6_A24WWPNotificationCreated ;
      private long[] BC000B8_A80WWPMailId ;
      private long[] BC000B5_A80WWPMailId ;
      private string[] BC000B5_A69WWPMailSubject ;
      private string[] BC000B5_A61WWPMailBody ;
      private string[] BC000B5_A70WWPMailTo ;
      private bool[] BC000B5_n70WWPMailTo ;
      private string[] BC000B5_A83WWPMailCC ;
      private bool[] BC000B5_n83WWPMailCC ;
      private string[] BC000B5_A84WWPMailBCC ;
      private bool[] BC000B5_n84WWPMailBCC ;
      private string[] BC000B5_A71WWPMailSenderAddress ;
      private string[] BC000B5_A72WWPMailSenderName ;
      private short[] BC000B5_A81WWPMailStatus ;
      private DateTime[] BC000B5_A91WWPMailCreated ;
      private DateTime[] BC000B5_A92WWPMailScheduled ;
      private DateTime[] BC000B5_A86WWPMailProcessed ;
      private bool[] BC000B5_n86WWPMailProcessed ;
      private string[] BC000B5_A87WWPMailDetail ;
      private bool[] BC000B5_n87WWPMailDetail ;
      private long[] BC000B5_A22WWPNotificationId ;
      private bool[] BC000B5_n22WWPNotificationId ;
      private long[] BC000B4_A80WWPMailId ;
      private string[] BC000B4_A69WWPMailSubject ;
      private string[] BC000B4_A61WWPMailBody ;
      private string[] BC000B4_A70WWPMailTo ;
      private bool[] BC000B4_n70WWPMailTo ;
      private string[] BC000B4_A83WWPMailCC ;
      private bool[] BC000B4_n83WWPMailCC ;
      private string[] BC000B4_A84WWPMailBCC ;
      private bool[] BC000B4_n84WWPMailBCC ;
      private string[] BC000B4_A71WWPMailSenderAddress ;
      private string[] BC000B4_A72WWPMailSenderName ;
      private short[] BC000B4_A81WWPMailStatus ;
      private DateTime[] BC000B4_A91WWPMailCreated ;
      private DateTime[] BC000B4_A92WWPMailScheduled ;
      private DateTime[] BC000B4_A86WWPMailProcessed ;
      private bool[] BC000B4_n86WWPMailProcessed ;
      private string[] BC000B4_A87WWPMailDetail ;
      private bool[] BC000B4_n87WWPMailDetail ;
      private long[] BC000B4_A22WWPNotificationId ;
      private bool[] BC000B4_n22WWPNotificationId ;
      private long[] BC000B10_A80WWPMailId ;
      private DateTime[] BC000B13_A24WWPNotificationCreated ;
      private long[] BC000B14_A80WWPMailId ;
      private string[] BC000B14_A69WWPMailSubject ;
      private string[] BC000B14_A61WWPMailBody ;
      private string[] BC000B14_A70WWPMailTo ;
      private bool[] BC000B14_n70WWPMailTo ;
      private string[] BC000B14_A83WWPMailCC ;
      private bool[] BC000B14_n83WWPMailCC ;
      private string[] BC000B14_A84WWPMailBCC ;
      private bool[] BC000B14_n84WWPMailBCC ;
      private string[] BC000B14_A71WWPMailSenderAddress ;
      private string[] BC000B14_A72WWPMailSenderName ;
      private short[] BC000B14_A81WWPMailStatus ;
      private DateTime[] BC000B14_A91WWPMailCreated ;
      private DateTime[] BC000B14_A92WWPMailScheduled ;
      private DateTime[] BC000B14_A86WWPMailProcessed ;
      private bool[] BC000B14_n86WWPMailProcessed ;
      private string[] BC000B14_A87WWPMailDetail ;
      private bool[] BC000B14_n87WWPMailDetail ;
      private DateTime[] BC000B14_A24WWPNotificationCreated ;
      private long[] BC000B14_A22WWPNotificationId ;
      private bool[] BC000B14_n22WWPNotificationId ;
      private long[] BC000B15_A80WWPMailId ;
      private string[] BC000B15_A93WWPMailAttachmentName ;
      private string[] BC000B15_A85WWPMailAttachmentFile ;
      private long[] BC000B16_A80WWPMailId ;
      private string[] BC000B16_A93WWPMailAttachmentName ;
      private long[] BC000B3_A80WWPMailId ;
      private string[] BC000B3_A93WWPMailAttachmentName ;
      private string[] BC000B3_A85WWPMailAttachmentFile ;
      private long[] BC000B2_A80WWPMailId ;
      private string[] BC000B2_A93WWPMailAttachmentName ;
      private string[] BC000B2_A85WWPMailAttachmentFile ;
      private long[] BC000B20_A80WWPMailId ;
      private string[] BC000B20_A93WWPMailAttachmentName ;
      private string[] BC000B20_A85WWPMailAttachmentFile ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_mail_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_mail_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new ForEachCursor(def[18])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000B2;
        prmBC000B2 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmBC000B3;
        prmBC000B3 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmBC000B4;
        prmBC000B4 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmBC000B5;
        prmBC000B5 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmBC000B6;
        prmBC000B6 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000B7;
        prmBC000B7 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmBC000B8;
        prmBC000B8 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmBC000B9;
        prmBC000B9 = new Object[] {
        new ParDef("WWPMailSubject",GXType.VarChar,80,0) ,
        new ParDef("WWPMailBody",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTo",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailBCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailSenderAddress",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailSenderName",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailStatus",GXType.Int16,4,0) ,
        new ParDef("WWPMailCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPMailScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPMailProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPMailDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000B10;
        prmBC000B10 = new Object[] {
        };
        Object[] prmBC000B11;
        prmBC000B11 = new Object[] {
        new ParDef("WWPMailSubject",GXType.VarChar,80,0) ,
        new ParDef("WWPMailBody",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTo",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailBCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailSenderAddress",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailSenderName",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailStatus",GXType.Int16,4,0) ,
        new ParDef("WWPMailCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPMailScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPMailProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPMailDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmBC000B12;
        prmBC000B12 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmBC000B13;
        prmBC000B13 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000B14;
        prmBC000B14 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmBC000B15;
        prmBC000B15 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmBC000B16;
        prmBC000B16 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmBC000B17;
        prmBC000B17 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0) ,
        new ParDef("WWPMailAttachmentFile",GXType.LongVarChar,2097152,0)
        };
        Object[] prmBC000B18;
        prmBC000B18 = new Object[] {
        new ParDef("WWPMailAttachmentFile",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmBC000B19;
        prmBC000B19 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmBC000B20;
        prmBC000B20 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000B2", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName  FOR UPDATE OF WWP_MailAttachments",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B3", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B4", "SELECT WWPMailId, WWPMailSubject, WWPMailBody, WWPMailTo, WWPMailCC, WWPMailBCC, WWPMailSenderAddress, WWPMailSenderName, WWPMailStatus, WWPMailCreated, WWPMailScheduled, WWPMailProcessed, WWPMailDetail, WWPNotificationId FROM WWP_Mail WHERE WWPMailId = :WWPMailId  FOR UPDATE OF WWP_Mail",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B5", "SELECT WWPMailId, WWPMailSubject, WWPMailBody, WWPMailTo, WWPMailCC, WWPMailBCC, WWPMailSenderAddress, WWPMailSenderName, WWPMailStatus, WWPMailCreated, WWPMailScheduled, WWPMailProcessed, WWPMailDetail, WWPNotificationId FROM WWP_Mail WHERE WWPMailId = :WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B6", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B7", "SELECT TM1.WWPMailId, TM1.WWPMailSubject, TM1.WWPMailBody, TM1.WWPMailTo, TM1.WWPMailCC, TM1.WWPMailBCC, TM1.WWPMailSenderAddress, TM1.WWPMailSenderName, TM1.WWPMailStatus, TM1.WWPMailCreated, TM1.WWPMailScheduled, TM1.WWPMailProcessed, TM1.WWPMailDetail, T2.WWPNotificationCreated, TM1.WWPNotificationId FROM (WWP_Mail TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) WHERE TM1.WWPMailId = :WWPMailId ORDER BY TM1.WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B8", "SELECT WWPMailId FROM WWP_Mail WHERE WWPMailId = :WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B9", "SAVEPOINT gxupdate;INSERT INTO WWP_Mail(WWPMailSubject, WWPMailBody, WWPMailTo, WWPMailCC, WWPMailBCC, WWPMailSenderAddress, WWPMailSenderName, WWPMailStatus, WWPMailCreated, WWPMailScheduled, WWPMailProcessed, WWPMailDetail, WWPNotificationId) VALUES(:WWPMailSubject, :WWPMailBody, :WWPMailTo, :WWPMailCC, :WWPMailBCC, :WWPMailSenderAddress, :WWPMailSenderName, :WWPMailStatus, :WWPMailCreated, :WWPMailScheduled, :WWPMailProcessed, :WWPMailDetail, :WWPNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000B9)
           ,new CursorDef("BC000B10", "SELECT currval('WWPMailId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B11", "SAVEPOINT gxupdate;UPDATE WWP_Mail SET WWPMailSubject=:WWPMailSubject, WWPMailBody=:WWPMailBody, WWPMailTo=:WWPMailTo, WWPMailCC=:WWPMailCC, WWPMailBCC=:WWPMailBCC, WWPMailSenderAddress=:WWPMailSenderAddress, WWPMailSenderName=:WWPMailSenderName, WWPMailStatus=:WWPMailStatus, WWPMailCreated=:WWPMailCreated, WWPMailScheduled=:WWPMailScheduled, WWPMailProcessed=:WWPMailProcessed, WWPMailDetail=:WWPMailDetail, WWPNotificationId=:WWPNotificationId  WHERE WWPMailId = :WWPMailId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000B11)
           ,new CursorDef("BC000B12", "SAVEPOINT gxupdate;DELETE FROM WWP_Mail  WHERE WWPMailId = :WWPMailId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000B12)
           ,new CursorDef("BC000B13", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B14", "SELECT TM1.WWPMailId, TM1.WWPMailSubject, TM1.WWPMailBody, TM1.WWPMailTo, TM1.WWPMailCC, TM1.WWPMailBCC, TM1.WWPMailSenderAddress, TM1.WWPMailSenderName, TM1.WWPMailStatus, TM1.WWPMailCreated, TM1.WWPMailScheduled, TM1.WWPMailProcessed, TM1.WWPMailDetail, T2.WWPNotificationCreated, TM1.WWPNotificationId FROM (WWP_Mail TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) WHERE TM1.WWPMailId = :WWPMailId ORDER BY TM1.WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B15", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId and WWPMailAttachmentName = ( :WWPMailAttachmentName) ORDER BY WWPMailId, WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B15,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B16", "SELECT WWPMailId, WWPMailAttachmentName FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B17", "SAVEPOINT gxupdate;INSERT INTO WWP_MailAttachments(WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile) VALUES(:WWPMailId, :WWPMailAttachmentName, :WWPMailAttachmentFile);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000B17)
           ,new CursorDef("BC000B18", "SAVEPOINT gxupdate;UPDATE WWP_MailAttachments SET WWPMailAttachmentFile=:WWPMailAttachmentFile  WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000B18)
           ,new CursorDef("BC000B19", "SAVEPOINT gxupdate;DELETE FROM WWP_MailAttachments  WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000B19)
           ,new CursorDef("BC000B20", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId ORDER BY WWPMailId, WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B20,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((long[]) buf[18])[0] = rslt.getLong(14);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((long[]) buf[18])[0] = rslt.getLong(14);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              return;
           case 4 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(14, true);
              ((long[]) buf[19])[0] = rslt.getLong(15);
              ((bool[]) buf[20])[0] = rslt.wasNull(15);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(14, true);
              ((long[]) buf[19])[0] = rslt.getLong(15);
              ((bool[]) buf[20])[0] = rslt.wasNull(15);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
     }
  }

}

}
