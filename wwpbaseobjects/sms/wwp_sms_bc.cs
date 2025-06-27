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
namespace GeneXus.Programs.wwpbaseobjects.sms {
   public class wwp_sms_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_sms_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_sms_bc( IGxContext context )
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
         ReadRow055( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey055( ) ;
         standaloneModal( ) ;
         AddRow055( ) ;
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
               Z33WWPSMSId = A33WWPSMSId;
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

      protected void CONFIRM_050( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls055( ) ;
            }
            else
            {
               CheckExtendedTable055( ) ;
               if ( AnyError == 0 )
               {
                  ZM055( 6) ;
               }
               CloseExtendedTableCursors055( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z34WWPSMSStatus = A34WWPSMSStatus;
            Z40WWPSMSCreated = A40WWPSMSCreated;
            Z41WWPSMSScheduled = A41WWPSMSScheduled;
            Z35WWPSMSProcessed = A35WWPSMSProcessed;
            Z22WWPNotificationId = A22WWPNotificationId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z24WWPNotificationCreated = A24WWPNotificationCreated;
         }
         if ( GX_JID == -5 )
         {
            Z33WWPSMSId = A33WWPSMSId;
            Z37WWPSMSMessage = A37WWPSMSMessage;
            Z38WWPSMSSenderNumber = A38WWPSMSSenderNumber;
            Z39WWPSMSRecipientNumbers = A39WWPSMSRecipientNumbers;
            Z34WWPSMSStatus = A34WWPSMSStatus;
            Z40WWPSMSCreated = A40WWPSMSCreated;
            Z41WWPSMSScheduled = A41WWPSMSScheduled;
            Z35WWPSMSProcessed = A35WWPSMSProcessed;
            Z36WWPSMSDetail = A36WWPSMSDetail;
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
         if ( IsIns( )  && (0==A34WWPSMSStatus) && ( Gx_BScreen == 0 ) )
         {
            A34WWPSMSStatus = 1;
         }
         if ( IsIns( )  && (DateTime.MinValue==A40WWPSMSCreated) && ( Gx_BScreen == 0 ) )
         {
            A40WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A41WWPSMSScheduled) && ( Gx_BScreen == 0 ) )
         {
            A41WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load055( )
      {
         /* Using cursor BC00055 */
         pr_default.execute(3, new Object[] {A33WWPSMSId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound5 = 1;
            A37WWPSMSMessage = BC00055_A37WWPSMSMessage[0];
            A38WWPSMSSenderNumber = BC00055_A38WWPSMSSenderNumber[0];
            A39WWPSMSRecipientNumbers = BC00055_A39WWPSMSRecipientNumbers[0];
            A34WWPSMSStatus = BC00055_A34WWPSMSStatus[0];
            A40WWPSMSCreated = BC00055_A40WWPSMSCreated[0];
            A41WWPSMSScheduled = BC00055_A41WWPSMSScheduled[0];
            A35WWPSMSProcessed = BC00055_A35WWPSMSProcessed[0];
            n35WWPSMSProcessed = BC00055_n35WWPSMSProcessed[0];
            A36WWPSMSDetail = BC00055_A36WWPSMSDetail[0];
            n36WWPSMSDetail = BC00055_n36WWPSMSDetail[0];
            A24WWPNotificationCreated = BC00055_A24WWPNotificationCreated[0];
            A22WWPNotificationId = BC00055_A22WWPNotificationId[0];
            n22WWPNotificationId = BC00055_n22WWPNotificationId[0];
            ZM055( -5) ;
         }
         pr_default.close(3);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
      }

      protected void CheckExtendedTable055( )
      {
         standaloneModal( ) ;
         if ( ! ( ( A34WWPSMSStatus == 1 ) || ( A34WWPSMSStatus == 2 ) || ( A34WWPSMSStatus == 3 ) ) )
         {
            GX_msglist.addItem("Field SMS Status is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00054 */
         pr_default.execute(2, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A22WWPNotificationId) ) )
            {
               GX_msglist.addItem("No matching 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
            }
         }
         A24WWPNotificationCreated = BC00054_A24WWPNotificationCreated[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors055( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey055( )
      {
         /* Using cursor BC00056 */
         pr_default.execute(4, new Object[] {A33WWPSMSId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00053 */
         pr_default.execute(1, new Object[] {A33WWPSMSId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 5) ;
            RcdFound5 = 1;
            A33WWPSMSId = BC00053_A33WWPSMSId[0];
            A37WWPSMSMessage = BC00053_A37WWPSMSMessage[0];
            A38WWPSMSSenderNumber = BC00053_A38WWPSMSSenderNumber[0];
            A39WWPSMSRecipientNumbers = BC00053_A39WWPSMSRecipientNumbers[0];
            A34WWPSMSStatus = BC00053_A34WWPSMSStatus[0];
            A40WWPSMSCreated = BC00053_A40WWPSMSCreated[0];
            A41WWPSMSScheduled = BC00053_A41WWPSMSScheduled[0];
            A35WWPSMSProcessed = BC00053_A35WWPSMSProcessed[0];
            n35WWPSMSProcessed = BC00053_n35WWPSMSProcessed[0];
            A36WWPSMSDetail = BC00053_A36WWPSMSDetail[0];
            n36WWPSMSDetail = BC00053_n36WWPSMSDetail[0];
            A22WWPNotificationId = BC00053_A22WWPNotificationId[0];
            n22WWPNotificationId = BC00053_n22WWPNotificationId[0];
            Z33WWPSMSId = A33WWPSMSId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode5;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
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
         CONFIRM_050( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00052 */
            pr_default.execute(0, new Object[] {A33WWPSMSId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z34WWPSMSStatus != BC00052_A34WWPSMSStatus[0] ) || ( Z40WWPSMSCreated != BC00052_A40WWPSMSCreated[0] ) || ( Z41WWPSMSScheduled != BC00052_A41WWPSMSScheduled[0] ) || ( Z35WWPSMSProcessed != BC00052_A35WWPSMSProcessed[0] ) || ( Z22WWPNotificationId != BC00052_A22WWPNotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_SMS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00057 */
                     pr_default.execute(5, new Object[] {A37WWPSMSMessage, A38WWPSMSSenderNumber, A39WWPSMSRecipientNumbers, A34WWPSMSStatus, A40WWPSMSCreated, A41WWPSMSScheduled, n35WWPSMSProcessed, A35WWPSMSProcessed, n36WWPSMSDetail, A36WWPSMSDetail, n22WWPNotificationId, A22WWPNotificationId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00058 */
                     pr_default.execute(6);
                     A33WWPSMSId = BC00058_A33WWPSMSId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
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
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00059 */
                     pr_default.execute(7, new Object[] {A37WWPSMSMessage, A38WWPSMSSenderNumber, A39WWPSMSRecipientNumbers, A34WWPSMSStatus, A40WWPSMSCreated, A41WWPSMSScheduled, n35WWPSMSProcessed, A35WWPSMSProcessed, n36WWPSMSDetail, A36WWPSMSDetail, n22WWPNotificationId, A22WWPNotificationId, A33WWPSMSId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
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
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000510 */
                  pr_default.execute(8, new Object[] {A33WWPSMSId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel055( ) ;
         Gx_mode = sMode5;
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000511 */
            pr_default.execute(9, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
            A24WWPNotificationCreated = BC000511_A24WWPNotificationCreated[0];
            pr_default.close(9);
         }
      }

      protected void EndLevel055( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
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

      public void ScanKeyStart055( )
      {
         /* Using cursor BC000512 */
         pr_default.execute(10, new Object[] {A33WWPSMSId});
         RcdFound5 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound5 = 1;
            A33WWPSMSId = BC000512_A33WWPSMSId[0];
            A37WWPSMSMessage = BC000512_A37WWPSMSMessage[0];
            A38WWPSMSSenderNumber = BC000512_A38WWPSMSSenderNumber[0];
            A39WWPSMSRecipientNumbers = BC000512_A39WWPSMSRecipientNumbers[0];
            A34WWPSMSStatus = BC000512_A34WWPSMSStatus[0];
            A40WWPSMSCreated = BC000512_A40WWPSMSCreated[0];
            A41WWPSMSScheduled = BC000512_A41WWPSMSScheduled[0];
            A35WWPSMSProcessed = BC000512_A35WWPSMSProcessed[0];
            n35WWPSMSProcessed = BC000512_n35WWPSMSProcessed[0];
            A36WWPSMSDetail = BC000512_A36WWPSMSDetail[0];
            n36WWPSMSDetail = BC000512_n36WWPSMSDetail[0];
            A24WWPNotificationCreated = BC000512_A24WWPNotificationCreated[0];
            A22WWPNotificationId = BC000512_A22WWPNotificationId[0];
            n22WWPNotificationId = BC000512_n22WWPNotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound5 = 0;
         ScanKeyLoad055( ) ;
      }

      protected void ScanKeyLoad055( )
      {
         sMode5 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound5 = 1;
            A33WWPSMSId = BC000512_A33WWPSMSId[0];
            A37WWPSMSMessage = BC000512_A37WWPSMSMessage[0];
            A38WWPSMSSenderNumber = BC000512_A38WWPSMSSenderNumber[0];
            A39WWPSMSRecipientNumbers = BC000512_A39WWPSMSRecipientNumbers[0];
            A34WWPSMSStatus = BC000512_A34WWPSMSStatus[0];
            A40WWPSMSCreated = BC000512_A40WWPSMSCreated[0];
            A41WWPSMSScheduled = BC000512_A41WWPSMSScheduled[0];
            A35WWPSMSProcessed = BC000512_A35WWPSMSProcessed[0];
            n35WWPSMSProcessed = BC000512_n35WWPSMSProcessed[0];
            A36WWPSMSDetail = BC000512_A36WWPSMSDetail[0];
            n36WWPSMSDetail = BC000512_n36WWPSMSDetail[0];
            A24WWPNotificationCreated = BC000512_A24WWPNotificationCreated[0];
            A22WWPNotificationId = BC000512_A22WWPNotificationId[0];
            n22WWPNotificationId = BC000512_n22WWPNotificationId[0];
         }
         Gx_mode = sMode5;
      }

      protected void ScanKeyEnd055( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes055( )
      {
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void AddRow055( )
      {
         VarsToRow5( bcwwpbaseobjects_sms_WWP_SMS) ;
      }

      protected void ReadRow055( )
      {
         RowToVars5( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
      }

      protected void InitializeNonKey055( )
      {
         A37WWPSMSMessage = "";
         A38WWPSMSSenderNumber = "";
         A39WWPSMSRecipientNumbers = "";
         A35WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         n35WWPSMSProcessed = false;
         A36WWPSMSDetail = "";
         n36WWPSMSDetail = false;
         A22WWPNotificationId = 0;
         n22WWPNotificationId = false;
         A24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A34WWPSMSStatus = 1;
         A40WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A41WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z34WWPSMSStatus = 0;
         Z40WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z41WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z35WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         Z22WWPNotificationId = 0;
      }

      protected void InitAll055( )
      {
         A33WWPSMSId = 0;
         InitializeNonKey055( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A34WWPSMSStatus = i34WWPSMSStatus;
         A40WWPSMSCreated = i40WWPSMSCreated;
         A41WWPSMSScheduled = i41WWPSMSScheduled;
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

      public void VarsToRow5( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS obj5 )
      {
         obj5.gxTpr_Mode = Gx_mode;
         obj5.gxTpr_Wwpsmsmessage = A37WWPSMSMessage;
         obj5.gxTpr_Wwpsmssendernumber = A38WWPSMSSenderNumber;
         obj5.gxTpr_Wwpsmsrecipientnumbers = A39WWPSMSRecipientNumbers;
         obj5.gxTpr_Wwpsmsprocessed = A35WWPSMSProcessed;
         obj5.gxTpr_Wwpsmsdetail = A36WWPSMSDetail;
         obj5.gxTpr_Wwpnotificationid = A22WWPNotificationId;
         obj5.gxTpr_Wwpnotificationcreated = A24WWPNotificationCreated;
         obj5.gxTpr_Wwpsmsstatus = A34WWPSMSStatus;
         obj5.gxTpr_Wwpsmscreated = A40WWPSMSCreated;
         obj5.gxTpr_Wwpsmsscheduled = A41WWPSMSScheduled;
         obj5.gxTpr_Wwpsmsid = A33WWPSMSId;
         obj5.gxTpr_Wwpsmsid_Z = Z33WWPSMSId;
         obj5.gxTpr_Wwpsmsstatus_Z = Z34WWPSMSStatus;
         obj5.gxTpr_Wwpsmscreated_Z = Z40WWPSMSCreated;
         obj5.gxTpr_Wwpsmsscheduled_Z = Z41WWPSMSScheduled;
         obj5.gxTpr_Wwpsmsprocessed_Z = Z35WWPSMSProcessed;
         obj5.gxTpr_Wwpnotificationid_Z = Z22WWPNotificationId;
         obj5.gxTpr_Wwpnotificationcreated_Z = Z24WWPNotificationCreated;
         obj5.gxTpr_Wwpsmsprocessed_N = (short)(Convert.ToInt16(n35WWPSMSProcessed));
         obj5.gxTpr_Wwpsmsdetail_N = (short)(Convert.ToInt16(n36WWPSMSDetail));
         obj5.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n22WWPNotificationId));
         obj5.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow5( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS obj5 )
      {
         obj5.gxTpr_Wwpsmsid = A33WWPSMSId;
         return  ;
      }

      public void RowToVars5( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS obj5 ,
                              int forceLoad )
      {
         Gx_mode = obj5.gxTpr_Mode;
         A37WWPSMSMessage = obj5.gxTpr_Wwpsmsmessage;
         A38WWPSMSSenderNumber = obj5.gxTpr_Wwpsmssendernumber;
         A39WWPSMSRecipientNumbers = obj5.gxTpr_Wwpsmsrecipientnumbers;
         A35WWPSMSProcessed = obj5.gxTpr_Wwpsmsprocessed;
         n35WWPSMSProcessed = false;
         A36WWPSMSDetail = obj5.gxTpr_Wwpsmsdetail;
         n36WWPSMSDetail = false;
         A22WWPNotificationId = obj5.gxTpr_Wwpnotificationid;
         n22WWPNotificationId = false;
         A24WWPNotificationCreated = obj5.gxTpr_Wwpnotificationcreated;
         A34WWPSMSStatus = obj5.gxTpr_Wwpsmsstatus;
         A40WWPSMSCreated = obj5.gxTpr_Wwpsmscreated;
         A41WWPSMSScheduled = obj5.gxTpr_Wwpsmsscheduled;
         A33WWPSMSId = obj5.gxTpr_Wwpsmsid;
         Z33WWPSMSId = obj5.gxTpr_Wwpsmsid_Z;
         Z34WWPSMSStatus = obj5.gxTpr_Wwpsmsstatus_Z;
         Z40WWPSMSCreated = obj5.gxTpr_Wwpsmscreated_Z;
         Z41WWPSMSScheduled = obj5.gxTpr_Wwpsmsscheduled_Z;
         Z35WWPSMSProcessed = obj5.gxTpr_Wwpsmsprocessed_Z;
         Z22WWPNotificationId = obj5.gxTpr_Wwpnotificationid_Z;
         Z24WWPNotificationCreated = obj5.gxTpr_Wwpnotificationcreated_Z;
         n35WWPSMSProcessed = (bool)(Convert.ToBoolean(obj5.gxTpr_Wwpsmsprocessed_N));
         n36WWPSMSDetail = (bool)(Convert.ToBoolean(obj5.gxTpr_Wwpsmsdetail_N));
         n22WWPNotificationId = (bool)(Convert.ToBoolean(obj5.gxTpr_Wwpnotificationid_N));
         Gx_mode = obj5.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A33WWPSMSId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey055( ) ;
         ScanKeyStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z33WWPSMSId = A33WWPSMSId;
         }
         ZM055( -5) ;
         OnLoadActions055( ) ;
         AddRow055( ) ;
         ScanKeyEnd055( ) ;
         if ( RcdFound5 == 0 )
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
         RowToVars5( bcwwpbaseobjects_sms_WWP_SMS, 0) ;
         ScanKeyStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z33WWPSMSId = A33WWPSMSId;
         }
         ZM055( -5) ;
         OnLoadActions055( ) ;
         AddRow055( ) ;
         ScanKeyEnd055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert055( ) ;
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A33WWPSMSId != Z33WWPSMSId )
               {
                  A33WWPSMSId = Z33WWPSMSId;
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
                  Update055( ) ;
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
                  if ( A33WWPSMSId != Z33WWPSMSId )
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
                        Insert055( ) ;
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
                        Insert055( ) ;
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
         RowToVars5( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         SaveImpl( ) ;
         VarsToRow5( bcwwpbaseobjects_sms_WWP_SMS) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars5( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert055( ) ;
         AfterTrn( ) ;
         VarsToRow5( bcwwpbaseobjects_sms_WWP_SMS) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow5( bcwwpbaseobjects_sms_WWP_SMS) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS auxBC = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A33WWPSMSId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_sms_WWP_SMS);
               auxBC.Save();
               bcwwpbaseobjects_sms_WWP_SMS.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars5( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
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
         RowToVars5( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert055( ) ;
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
               VarsToRow5( bcwwpbaseobjects_sms_WWP_SMS) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow5( bcwwpbaseobjects_sms_WWP_SMS) ;
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
         RowToVars5( bcwwpbaseobjects_sms_WWP_SMS, 0) ;
         GetKey055( ) ;
         if ( RcdFound5 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A33WWPSMSId != Z33WWPSMSId )
            {
               A33WWPSMSId = Z33WWPSMSId;
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
            if ( A33WWPSMSId != Z33WWPSMSId )
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
         context.RollbackDataStores("wwpbaseobjects.sms.wwp_sms_bc",pr_default);
         VarsToRow5( bcwwpbaseobjects_sms_WWP_SMS) ;
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
         Gx_mode = bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_sms_WWP_SMS )
         {
            bcwwpbaseobjects_sms_WWP_SMS = (GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow5( bcwwpbaseobjects_sms_WWP_SMS) ;
            }
            else
            {
               RowToVars5( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars5( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_SMS WWP_SMS_BC
      {
         get {
            return bcwwpbaseobjects_sms_WWP_SMS ;
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
            return "sms_Execute" ;
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
         Z40WWPSMSCreated = (DateTime)(DateTime.MinValue);
         A40WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z41WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         A41WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z35WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         A35WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         Z24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z37WWPSMSMessage = "";
         A37WWPSMSMessage = "";
         Z38WWPSMSSenderNumber = "";
         A38WWPSMSSenderNumber = "";
         Z39WWPSMSRecipientNumbers = "";
         A39WWPSMSRecipientNumbers = "";
         Z36WWPSMSDetail = "";
         A36WWPSMSDetail = "";
         BC00055_A33WWPSMSId = new long[1] ;
         BC00055_A37WWPSMSMessage = new string[] {""} ;
         BC00055_A38WWPSMSSenderNumber = new string[] {""} ;
         BC00055_A39WWPSMSRecipientNumbers = new string[] {""} ;
         BC00055_A34WWPSMSStatus = new short[1] ;
         BC00055_A40WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC00055_A41WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC00055_A35WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC00055_n35WWPSMSProcessed = new bool[] {false} ;
         BC00055_A36WWPSMSDetail = new string[] {""} ;
         BC00055_n36WWPSMSDetail = new bool[] {false} ;
         BC00055_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00055_A22WWPNotificationId = new long[1] ;
         BC00055_n22WWPNotificationId = new bool[] {false} ;
         BC00054_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00056_A33WWPSMSId = new long[1] ;
         BC00053_A33WWPSMSId = new long[1] ;
         BC00053_A37WWPSMSMessage = new string[] {""} ;
         BC00053_A38WWPSMSSenderNumber = new string[] {""} ;
         BC00053_A39WWPSMSRecipientNumbers = new string[] {""} ;
         BC00053_A34WWPSMSStatus = new short[1] ;
         BC00053_A40WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC00053_A41WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC00053_A35WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC00053_n35WWPSMSProcessed = new bool[] {false} ;
         BC00053_A36WWPSMSDetail = new string[] {""} ;
         BC00053_n36WWPSMSDetail = new bool[] {false} ;
         BC00053_A22WWPNotificationId = new long[1] ;
         BC00053_n22WWPNotificationId = new bool[] {false} ;
         sMode5 = "";
         BC00052_A33WWPSMSId = new long[1] ;
         BC00052_A37WWPSMSMessage = new string[] {""} ;
         BC00052_A38WWPSMSSenderNumber = new string[] {""} ;
         BC00052_A39WWPSMSRecipientNumbers = new string[] {""} ;
         BC00052_A34WWPSMSStatus = new short[1] ;
         BC00052_A40WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC00052_A41WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC00052_A35WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC00052_n35WWPSMSProcessed = new bool[] {false} ;
         BC00052_A36WWPSMSDetail = new string[] {""} ;
         BC00052_n36WWPSMSDetail = new bool[] {false} ;
         BC00052_A22WWPNotificationId = new long[1] ;
         BC00052_n22WWPNotificationId = new bool[] {false} ;
         BC00058_A33WWPSMSId = new long[1] ;
         BC000511_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000512_A33WWPSMSId = new long[1] ;
         BC000512_A37WWPSMSMessage = new string[] {""} ;
         BC000512_A38WWPSMSSenderNumber = new string[] {""} ;
         BC000512_A39WWPSMSRecipientNumbers = new string[] {""} ;
         BC000512_A34WWPSMSStatus = new short[1] ;
         BC000512_A40WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC000512_A41WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000512_A35WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000512_n35WWPSMSProcessed = new bool[] {false} ;
         BC000512_A36WWPSMSDetail = new string[] {""} ;
         BC000512_n36WWPSMSDetail = new bool[] {false} ;
         BC000512_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000512_A22WWPNotificationId = new long[1] ;
         BC000512_n22WWPNotificationId = new bool[] {false} ;
         i40WWPSMSCreated = (DateTime)(DateTime.MinValue);
         i41WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms_bc__default(),
            new Object[][] {
                new Object[] {
               BC00052_A33WWPSMSId, BC00052_A37WWPSMSMessage, BC00052_A38WWPSMSSenderNumber, BC00052_A39WWPSMSRecipientNumbers, BC00052_A34WWPSMSStatus, BC00052_A40WWPSMSCreated, BC00052_A41WWPSMSScheduled, BC00052_A35WWPSMSProcessed, BC00052_n35WWPSMSProcessed, BC00052_A36WWPSMSDetail,
               BC00052_n36WWPSMSDetail, BC00052_A22WWPNotificationId, BC00052_n22WWPNotificationId
               }
               , new Object[] {
               BC00053_A33WWPSMSId, BC00053_A37WWPSMSMessage, BC00053_A38WWPSMSSenderNumber, BC00053_A39WWPSMSRecipientNumbers, BC00053_A34WWPSMSStatus, BC00053_A40WWPSMSCreated, BC00053_A41WWPSMSScheduled, BC00053_A35WWPSMSProcessed, BC00053_n35WWPSMSProcessed, BC00053_A36WWPSMSDetail,
               BC00053_n36WWPSMSDetail, BC00053_A22WWPNotificationId, BC00053_n22WWPNotificationId
               }
               , new Object[] {
               BC00054_A24WWPNotificationCreated
               }
               , new Object[] {
               BC00055_A33WWPSMSId, BC00055_A37WWPSMSMessage, BC00055_A38WWPSMSSenderNumber, BC00055_A39WWPSMSRecipientNumbers, BC00055_A34WWPSMSStatus, BC00055_A40WWPSMSCreated, BC00055_A41WWPSMSScheduled, BC00055_A35WWPSMSProcessed, BC00055_n35WWPSMSProcessed, BC00055_A36WWPSMSDetail,
               BC00055_n36WWPSMSDetail, BC00055_A24WWPNotificationCreated, BC00055_A22WWPNotificationId, BC00055_n22WWPNotificationId
               }
               , new Object[] {
               BC00056_A33WWPSMSId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00058_A33WWPSMSId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000511_A24WWPNotificationCreated
               }
               , new Object[] {
               BC000512_A33WWPSMSId, BC000512_A37WWPSMSMessage, BC000512_A38WWPSMSSenderNumber, BC000512_A39WWPSMSRecipientNumbers, BC000512_A34WWPSMSStatus, BC000512_A40WWPSMSCreated, BC000512_A41WWPSMSScheduled, BC000512_A35WWPSMSProcessed, BC000512_n35WWPSMSProcessed, BC000512_A36WWPSMSDetail,
               BC000512_n36WWPSMSDetail, BC000512_A24WWPNotificationCreated, BC000512_A22WWPNotificationId, BC000512_n22WWPNotificationId
               }
            }
         );
         Z41WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A41WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i41WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z40WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A40WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i40WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z34WWPSMSStatus = 1;
         A34WWPSMSStatus = 1;
         i34WWPSMSStatus = 1;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z34WWPSMSStatus ;
      private short A34WWPSMSStatus ;
      private short Gx_BScreen ;
      private short RcdFound5 ;
      private short i34WWPSMSStatus ;
      private int trnEnded ;
      private long Z33WWPSMSId ;
      private long A33WWPSMSId ;
      private long Z22WWPNotificationId ;
      private long A22WWPNotificationId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode5 ;
      private DateTime Z40WWPSMSCreated ;
      private DateTime A40WWPSMSCreated ;
      private DateTime Z41WWPSMSScheduled ;
      private DateTime A41WWPSMSScheduled ;
      private DateTime Z35WWPSMSProcessed ;
      private DateTime A35WWPSMSProcessed ;
      private DateTime Z24WWPNotificationCreated ;
      private DateTime A24WWPNotificationCreated ;
      private DateTime i40WWPSMSCreated ;
      private DateTime i41WWPSMSScheduled ;
      private bool n35WWPSMSProcessed ;
      private bool n36WWPSMSDetail ;
      private bool n22WWPNotificationId ;
      private string Z37WWPSMSMessage ;
      private string A37WWPSMSMessage ;
      private string Z38WWPSMSSenderNumber ;
      private string A38WWPSMSSenderNumber ;
      private string Z39WWPSMSRecipientNumbers ;
      private string A39WWPSMSRecipientNumbers ;
      private string Z36WWPSMSDetail ;
      private string A36WWPSMSDetail ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00055_A33WWPSMSId ;
      private string[] BC00055_A37WWPSMSMessage ;
      private string[] BC00055_A38WWPSMSSenderNumber ;
      private string[] BC00055_A39WWPSMSRecipientNumbers ;
      private short[] BC00055_A34WWPSMSStatus ;
      private DateTime[] BC00055_A40WWPSMSCreated ;
      private DateTime[] BC00055_A41WWPSMSScheduled ;
      private DateTime[] BC00055_A35WWPSMSProcessed ;
      private bool[] BC00055_n35WWPSMSProcessed ;
      private string[] BC00055_A36WWPSMSDetail ;
      private bool[] BC00055_n36WWPSMSDetail ;
      private DateTime[] BC00055_A24WWPNotificationCreated ;
      private long[] BC00055_A22WWPNotificationId ;
      private bool[] BC00055_n22WWPNotificationId ;
      private DateTime[] BC00054_A24WWPNotificationCreated ;
      private long[] BC00056_A33WWPSMSId ;
      private long[] BC00053_A33WWPSMSId ;
      private string[] BC00053_A37WWPSMSMessage ;
      private string[] BC00053_A38WWPSMSSenderNumber ;
      private string[] BC00053_A39WWPSMSRecipientNumbers ;
      private short[] BC00053_A34WWPSMSStatus ;
      private DateTime[] BC00053_A40WWPSMSCreated ;
      private DateTime[] BC00053_A41WWPSMSScheduled ;
      private DateTime[] BC00053_A35WWPSMSProcessed ;
      private bool[] BC00053_n35WWPSMSProcessed ;
      private string[] BC00053_A36WWPSMSDetail ;
      private bool[] BC00053_n36WWPSMSDetail ;
      private long[] BC00053_A22WWPNotificationId ;
      private bool[] BC00053_n22WWPNotificationId ;
      private long[] BC00052_A33WWPSMSId ;
      private string[] BC00052_A37WWPSMSMessage ;
      private string[] BC00052_A38WWPSMSSenderNumber ;
      private string[] BC00052_A39WWPSMSRecipientNumbers ;
      private short[] BC00052_A34WWPSMSStatus ;
      private DateTime[] BC00052_A40WWPSMSCreated ;
      private DateTime[] BC00052_A41WWPSMSScheduled ;
      private DateTime[] BC00052_A35WWPSMSProcessed ;
      private bool[] BC00052_n35WWPSMSProcessed ;
      private string[] BC00052_A36WWPSMSDetail ;
      private bool[] BC00052_n36WWPSMSDetail ;
      private long[] BC00052_A22WWPNotificationId ;
      private bool[] BC00052_n22WWPNotificationId ;
      private long[] BC00058_A33WWPSMSId ;
      private DateTime[] BC000511_A24WWPNotificationCreated ;
      private long[] BC000512_A33WWPSMSId ;
      private string[] BC000512_A37WWPSMSMessage ;
      private string[] BC000512_A38WWPSMSSenderNumber ;
      private string[] BC000512_A39WWPSMSRecipientNumbers ;
      private short[] BC000512_A34WWPSMSStatus ;
      private DateTime[] BC000512_A40WWPSMSCreated ;
      private DateTime[] BC000512_A41WWPSMSScheduled ;
      private DateTime[] BC000512_A35WWPSMSProcessed ;
      private bool[] BC000512_n35WWPSMSProcessed ;
      private string[] BC000512_A36WWPSMSDetail ;
      private bool[] BC000512_n36WWPSMSDetail ;
      private DateTime[] BC000512_A24WWPNotificationCreated ;
      private long[] BC000512_A22WWPNotificationId ;
      private bool[] BC000512_n22WWPNotificationId ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS bcwwpbaseobjects_sms_WWP_SMS ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_sms_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_sms_bc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00052;
        prmBC00052 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmBC00053;
        prmBC00053 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmBC00054;
        prmBC00054 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC00055;
        prmBC00055 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmBC00056;
        prmBC00056 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmBC00057;
        prmBC00057 = new Object[] {
        new ParDef("WWPSMSMessage",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSSenderNumber",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSRecipientNumbers",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSStatus",GXType.Int16,4,0) ,
        new ParDef("WWPSMSCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPSMSScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPSMSProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPSMSDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC00058;
        prmBC00058 = new Object[] {
        };
        Object[] prmBC00059;
        prmBC00059 = new Object[] {
        new ParDef("WWPSMSMessage",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSSenderNumber",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSRecipientNumbers",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSStatus",GXType.Int16,4,0) ,
        new ParDef("WWPSMSCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPSMSScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPSMSProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPSMSDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmBC000510;
        prmBC000510 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmBC000511;
        prmBC000511 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000512;
        prmBC000512 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00052", "SELECT WWPSMSId, WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId  FOR UPDATE OF WWP_SMS",true, GxErrorMask.GX_NOMASK, false, this,prmBC00052,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00053", "SELECT WWPSMSId, WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00053,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00054", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00054,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00055", "SELECT TM1.WWPSMSId, TM1.WWPSMSMessage, TM1.WWPSMSSenderNumber, TM1.WWPSMSRecipientNumbers, TM1.WWPSMSStatus, TM1.WWPSMSCreated, TM1.WWPSMSScheduled, TM1.WWPSMSProcessed, TM1.WWPSMSDetail, T2.WWPNotificationCreated, TM1.WWPNotificationId FROM (WWP_SMS TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) WHERE TM1.WWPSMSId = :WWPSMSId ORDER BY TM1.WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00055,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00056", "SELECT WWPSMSId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00056,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00057", "SAVEPOINT gxupdate;INSERT INTO WWP_SMS(WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId) VALUES(:WWPSMSMessage, :WWPSMSSenderNumber, :WWPSMSRecipientNumbers, :WWPSMSStatus, :WWPSMSCreated, :WWPSMSScheduled, :WWPSMSProcessed, :WWPSMSDetail, :WWPNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00057)
           ,new CursorDef("BC00058", "SELECT currval('WWPSMSId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00058,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00059", "SAVEPOINT gxupdate;UPDATE WWP_SMS SET WWPSMSMessage=:WWPSMSMessage, WWPSMSSenderNumber=:WWPSMSSenderNumber, WWPSMSRecipientNumbers=:WWPSMSRecipientNumbers, WWPSMSStatus=:WWPSMSStatus, WWPSMSCreated=:WWPSMSCreated, WWPSMSScheduled=:WWPSMSScheduled, WWPSMSProcessed=:WWPSMSProcessed, WWPSMSDetail=:WWPSMSDetail, WWPNotificationId=:WWPNotificationId  WHERE WWPSMSId = :WWPSMSId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00059)
           ,new CursorDef("BC000510", "SAVEPOINT gxupdate;DELETE FROM WWP_SMS  WHERE WWPSMSId = :WWPSMSId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000510)
           ,new CursorDef("BC000511", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000511,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000512", "SELECT TM1.WWPSMSId, TM1.WWPSMSMessage, TM1.WWPSMSSenderNumber, TM1.WWPSMSRecipientNumbers, TM1.WWPSMSStatus, TM1.WWPSMSCreated, TM1.WWPSMSScheduled, TM1.WWPSMSProcessed, TM1.WWPSMSDetail, T2.WWPNotificationCreated, TM1.WWPNotificationId FROM (WWP_SMS TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) WHERE TM1.WWPSMSId = :WWPSMSId ORDER BY TM1.WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000512,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((long[]) buf[11])[0] = rslt.getLong(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((long[]) buf[11])[0] = rslt.getLong(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
              ((long[]) buf[12])[0] = rslt.getLong(11);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
              ((long[]) buf[12])[0] = rslt.getLong(11);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              return;
     }
  }

}

}
