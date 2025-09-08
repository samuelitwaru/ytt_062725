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
namespace GeneXus.Programs {
   public class audit_bc : GxSilentTrn, IGxSilentTrn
   {
      public audit_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public audit_bc( IGxContext context )
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
         ReadRow0T32( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0T32( ) ;
         standaloneModal( ) ;
         AddRow0T32( ) ;
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
               Z204AuditId = A204AuditId;
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

      protected void CONFIRM_0T0( )
      {
         BeforeValidate0T32( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0T32( ) ;
            }
            else
            {
               CheckExtendedTable0T32( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0T32( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0T32( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z205AuditDate = A205AuditDate;
            Z206AuditTableName = A206AuditTableName;
            Z207AuditDescription = A207AuditDescription;
            Z208AuditShortDescription = A208AuditShortDescription;
            Z209AuditAction = A209AuditAction;
            Z210SecUserId = A210SecUserId;
         }
         if ( GX_JID == -1 )
         {
            Z204AuditId = A204AuditId;
            Z205AuditDate = A205AuditDate;
            Z206AuditTableName = A206AuditTableName;
            Z207AuditDescription = A207AuditDescription;
            Z208AuditShortDescription = A208AuditShortDescription;
            Z209AuditAction = A209AuditAction;
            Z210SecUserId = A210SecUserId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0T32( )
      {
         /* Using cursor BC000T4 */
         pr_default.execute(2, new Object[] {A204AuditId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound32 = 1;
            A205AuditDate = BC000T4_A205AuditDate[0];
            A206AuditTableName = BC000T4_A206AuditTableName[0];
            A207AuditDescription = BC000T4_A207AuditDescription[0];
            A208AuditShortDescription = BC000T4_A208AuditShortDescription[0];
            A209AuditAction = BC000T4_A209AuditAction[0];
            A210SecUserId = BC000T4_A210SecUserId[0];
            ZM0T32( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0T32( ) ;
      }

      protected void OnLoadActions0T32( )
      {
      }

      protected void CheckExtendedTable0T32( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0T32( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0T32( )
      {
         /* Using cursor BC000T5 */
         pr_default.execute(3, new Object[] {A204AuditId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound32 = 1;
         }
         else
         {
            RcdFound32 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000T3 */
         pr_default.execute(1, new Object[] {A204AuditId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0T32( 1) ;
            RcdFound32 = 1;
            A204AuditId = BC000T3_A204AuditId[0];
            A205AuditDate = BC000T3_A205AuditDate[0];
            A206AuditTableName = BC000T3_A206AuditTableName[0];
            A207AuditDescription = BC000T3_A207AuditDescription[0];
            A208AuditShortDescription = BC000T3_A208AuditShortDescription[0];
            A209AuditAction = BC000T3_A209AuditAction[0];
            A210SecUserId = BC000T3_A210SecUserId[0];
            Z204AuditId = A204AuditId;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0T32( ) ;
            if ( AnyError == 1 )
            {
               RcdFound32 = 0;
               InitializeNonKey0T32( ) ;
            }
            Gx_mode = sMode32;
         }
         else
         {
            RcdFound32 = 0;
            InitializeNonKey0T32( ) ;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode32;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0T32( ) ;
         if ( RcdFound32 == 0 )
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
         CONFIRM_0T0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0T32( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000T2 */
            pr_default.execute(0, new Object[] {A204AuditId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Audit"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z205AuditDate ) != DateTimeUtil.ResetTime ( BC000T2_A205AuditDate[0] ) ) || ( StringUtil.StrCmp(Z206AuditTableName, BC000T2_A206AuditTableName[0]) != 0 ) || ( StringUtil.StrCmp(Z207AuditDescription, BC000T2_A207AuditDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z208AuditShortDescription, BC000T2_A208AuditShortDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z209AuditAction, BC000T2_A209AuditAction[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z210SecUserId != BC000T2_A210SecUserId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Audit"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0T32( )
      {
         BeforeValidate0T32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T32( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0T32( 0) ;
            CheckOptimisticConcurrency0T32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0T32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000T6 */
                     pr_default.execute(4, new Object[] {A205AuditDate, A206AuditTableName, A207AuditDescription, A208AuditShortDescription, A209AuditAction, A210SecUserId});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000T7 */
                     pr_default.execute(5);
                     A204AuditId = BC000T7_A204AuditId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Audit");
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
               Load0T32( ) ;
            }
            EndLevel0T32( ) ;
         }
         CloseExtendedTableCursors0T32( ) ;
      }

      protected void Update0T32( )
      {
         BeforeValidate0T32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T32( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0T32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000T8 */
                     pr_default.execute(6, new Object[] {A205AuditDate, A206AuditTableName, A207AuditDescription, A208AuditShortDescription, A209AuditAction, A210SecUserId, A204AuditId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Audit");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Audit"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0T32( ) ;
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
            EndLevel0T32( ) ;
         }
         CloseExtendedTableCursors0T32( ) ;
      }

      protected void DeferredUpdate0T32( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0T32( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T32( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0T32( ) ;
            AfterConfirm0T32( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0T32( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000T9 */
                  pr_default.execute(7, new Object[] {A204AuditId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Audit");
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
         sMode32 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0T32( ) ;
         Gx_mode = sMode32;
      }

      protected void OnDeleteControls0T32( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0T32( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0T32( ) ;
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

      public void ScanKeyStart0T32( )
      {
         /* Using cursor BC000T10 */
         pr_default.execute(8, new Object[] {A204AuditId});
         RcdFound32 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound32 = 1;
            A204AuditId = BC000T10_A204AuditId[0];
            A205AuditDate = BC000T10_A205AuditDate[0];
            A206AuditTableName = BC000T10_A206AuditTableName[0];
            A207AuditDescription = BC000T10_A207AuditDescription[0];
            A208AuditShortDescription = BC000T10_A208AuditShortDescription[0];
            A209AuditAction = BC000T10_A209AuditAction[0];
            A210SecUserId = BC000T10_A210SecUserId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0T32( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound32 = 0;
         ScanKeyLoad0T32( ) ;
      }

      protected void ScanKeyLoad0T32( )
      {
         sMode32 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound32 = 1;
            A204AuditId = BC000T10_A204AuditId[0];
            A205AuditDate = BC000T10_A205AuditDate[0];
            A206AuditTableName = BC000T10_A206AuditTableName[0];
            A207AuditDescription = BC000T10_A207AuditDescription[0];
            A208AuditShortDescription = BC000T10_A208AuditShortDescription[0];
            A209AuditAction = BC000T10_A209AuditAction[0];
            A210SecUserId = BC000T10_A210SecUserId[0];
         }
         Gx_mode = sMode32;
      }

      protected void ScanKeyEnd0T32( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0T32( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0T32( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0T32( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0T32( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0T32( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0T32( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0T32( )
      {
      }

      protected void send_integrity_lvl_hashes0T32( )
      {
      }

      protected void AddRow0T32( )
      {
         VarsToRow32( bcAudit) ;
      }

      protected void ReadRow0T32( )
      {
         RowToVars32( bcAudit, 1) ;
      }

      protected void InitializeNonKey0T32( )
      {
         A205AuditDate = DateTime.MinValue;
         A206AuditTableName = "";
         A207AuditDescription = "";
         A208AuditShortDescription = "";
         A209AuditAction = "";
         A210SecUserId = 0;
         Z205AuditDate = DateTime.MinValue;
         Z206AuditTableName = "";
         Z207AuditDescription = "";
         Z208AuditShortDescription = "";
         Z209AuditAction = "";
         Z210SecUserId = 0;
      }

      protected void InitAll0T32( )
      {
         A204AuditId = 0;
         InitializeNonKey0T32( ) ;
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

      public void VarsToRow32( SdtAudit obj32 )
      {
         obj32.gxTpr_Mode = Gx_mode;
         obj32.gxTpr_Auditdate = A205AuditDate;
         obj32.gxTpr_Audittablename = A206AuditTableName;
         obj32.gxTpr_Auditdescription = A207AuditDescription;
         obj32.gxTpr_Auditshortdescription = A208AuditShortDescription;
         obj32.gxTpr_Auditaction = A209AuditAction;
         obj32.gxTpr_Secuserid = A210SecUserId;
         obj32.gxTpr_Auditid = A204AuditId;
         obj32.gxTpr_Auditid_Z = Z204AuditId;
         obj32.gxTpr_Auditdate_Z = Z205AuditDate;
         obj32.gxTpr_Audittablename_Z = Z206AuditTableName;
         obj32.gxTpr_Auditdescription_Z = Z207AuditDescription;
         obj32.gxTpr_Auditshortdescription_Z = Z208AuditShortDescription;
         obj32.gxTpr_Auditaction_Z = Z209AuditAction;
         obj32.gxTpr_Secuserid_Z = Z210SecUserId;
         obj32.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow32( SdtAudit obj32 )
      {
         obj32.gxTpr_Auditid = A204AuditId;
         return  ;
      }

      public void RowToVars32( SdtAudit obj32 ,
                               int forceLoad )
      {
         Gx_mode = obj32.gxTpr_Mode;
         A205AuditDate = obj32.gxTpr_Auditdate;
         A206AuditTableName = obj32.gxTpr_Audittablename;
         A207AuditDescription = obj32.gxTpr_Auditdescription;
         A208AuditShortDescription = obj32.gxTpr_Auditshortdescription;
         A209AuditAction = obj32.gxTpr_Auditaction;
         A210SecUserId = obj32.gxTpr_Secuserid;
         A204AuditId = obj32.gxTpr_Auditid;
         Z204AuditId = obj32.gxTpr_Auditid_Z;
         Z205AuditDate = obj32.gxTpr_Auditdate_Z;
         Z206AuditTableName = obj32.gxTpr_Audittablename_Z;
         Z207AuditDescription = obj32.gxTpr_Auditdescription_Z;
         Z208AuditShortDescription = obj32.gxTpr_Auditshortdescription_Z;
         Z209AuditAction = obj32.gxTpr_Auditaction_Z;
         Z210SecUserId = obj32.gxTpr_Secuserid_Z;
         Gx_mode = obj32.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A204AuditId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0T32( ) ;
         ScanKeyStart0T32( ) ;
         if ( RcdFound32 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z204AuditId = A204AuditId;
         }
         ZM0T32( -1) ;
         OnLoadActions0T32( ) ;
         AddRow0T32( ) ;
         ScanKeyEnd0T32( ) ;
         if ( RcdFound32 == 0 )
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
         RowToVars32( bcAudit, 0) ;
         ScanKeyStart0T32( ) ;
         if ( RcdFound32 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z204AuditId = A204AuditId;
         }
         ZM0T32( -1) ;
         OnLoadActions0T32( ) ;
         AddRow0T32( ) ;
         ScanKeyEnd0T32( ) ;
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0T32( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0T32( ) ;
         }
         else
         {
            if ( RcdFound32 == 1 )
            {
               if ( A204AuditId != Z204AuditId )
               {
                  A204AuditId = Z204AuditId;
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
                  Update0T32( ) ;
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
                  if ( A204AuditId != Z204AuditId )
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
                        Insert0T32( ) ;
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
                        Insert0T32( ) ;
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
         RowToVars32( bcAudit, 1) ;
         SaveImpl( ) ;
         VarsToRow32( bcAudit) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars32( bcAudit, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0T32( ) ;
         AfterTrn( ) ;
         VarsToRow32( bcAudit) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow32( bcAudit) ;
         }
         else
         {
            SdtAudit auxBC = new SdtAudit(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A204AuditId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcAudit);
               auxBC.Save();
               bcAudit.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars32( bcAudit, 1) ;
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
         RowToVars32( bcAudit, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0T32( ) ;
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
               VarsToRow32( bcAudit) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow32( bcAudit) ;
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
         RowToVars32( bcAudit, 0) ;
         GetKey0T32( ) ;
         if ( RcdFound32 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A204AuditId != Z204AuditId )
            {
               A204AuditId = Z204AuditId;
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
            if ( A204AuditId != Z204AuditId )
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
         context.RollbackDataStores("audit_bc",pr_default);
         VarsToRow32( bcAudit) ;
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
         Gx_mode = bcAudit.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcAudit.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcAudit )
         {
            bcAudit = (SdtAudit)(sdt);
            if ( StringUtil.StrCmp(bcAudit.gxTpr_Mode, "") == 0 )
            {
               bcAudit.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow32( bcAudit) ;
            }
            else
            {
               RowToVars32( bcAudit, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcAudit.gxTpr_Mode, "") == 0 )
            {
               bcAudit.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars32( bcAudit, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtAudit Audit_BC
      {
         get {
            return bcAudit ;
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
            return "audit_Execute" ;
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
         Z205AuditDate = DateTime.MinValue;
         A205AuditDate = DateTime.MinValue;
         Z206AuditTableName = "";
         A206AuditTableName = "";
         Z207AuditDescription = "";
         A207AuditDescription = "";
         Z208AuditShortDescription = "";
         A208AuditShortDescription = "";
         Z209AuditAction = "";
         A209AuditAction = "";
         BC000T4_A204AuditId = new long[1] ;
         BC000T4_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         BC000T4_A206AuditTableName = new string[] {""} ;
         BC000T4_A207AuditDescription = new string[] {""} ;
         BC000T4_A208AuditShortDescription = new string[] {""} ;
         BC000T4_A209AuditAction = new string[] {""} ;
         BC000T4_A210SecUserId = new long[1] ;
         BC000T5_A204AuditId = new long[1] ;
         BC000T3_A204AuditId = new long[1] ;
         BC000T3_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         BC000T3_A206AuditTableName = new string[] {""} ;
         BC000T3_A207AuditDescription = new string[] {""} ;
         BC000T3_A208AuditShortDescription = new string[] {""} ;
         BC000T3_A209AuditAction = new string[] {""} ;
         BC000T3_A210SecUserId = new long[1] ;
         sMode32 = "";
         BC000T2_A204AuditId = new long[1] ;
         BC000T2_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         BC000T2_A206AuditTableName = new string[] {""} ;
         BC000T2_A207AuditDescription = new string[] {""} ;
         BC000T2_A208AuditShortDescription = new string[] {""} ;
         BC000T2_A209AuditAction = new string[] {""} ;
         BC000T2_A210SecUserId = new long[1] ;
         BC000T7_A204AuditId = new long[1] ;
         BC000T10_A204AuditId = new long[1] ;
         BC000T10_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         BC000T10_A206AuditTableName = new string[] {""} ;
         BC000T10_A207AuditDescription = new string[] {""} ;
         BC000T10_A208AuditShortDescription = new string[] {""} ;
         BC000T10_A209AuditAction = new string[] {""} ;
         BC000T10_A210SecUserId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.audit_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.audit_bc__default(),
            new Object[][] {
                new Object[] {
               BC000T2_A204AuditId, BC000T2_A205AuditDate, BC000T2_A206AuditTableName, BC000T2_A207AuditDescription, BC000T2_A208AuditShortDescription, BC000T2_A209AuditAction, BC000T2_A210SecUserId
               }
               , new Object[] {
               BC000T3_A204AuditId, BC000T3_A205AuditDate, BC000T3_A206AuditTableName, BC000T3_A207AuditDescription, BC000T3_A208AuditShortDescription, BC000T3_A209AuditAction, BC000T3_A210SecUserId
               }
               , new Object[] {
               BC000T4_A204AuditId, BC000T4_A205AuditDate, BC000T4_A206AuditTableName, BC000T4_A207AuditDescription, BC000T4_A208AuditShortDescription, BC000T4_A209AuditAction, BC000T4_A210SecUserId
               }
               , new Object[] {
               BC000T5_A204AuditId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000T7_A204AuditId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000T10_A204AuditId, BC000T10_A205AuditDate, BC000T10_A206AuditTableName, BC000T10_A207AuditDescription, BC000T10_A208AuditShortDescription, BC000T10_A209AuditAction, BC000T10_A210SecUserId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound32 ;
      private int trnEnded ;
      private long Z204AuditId ;
      private long A204AuditId ;
      private long Z210SecUserId ;
      private long A210SecUserId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z206AuditTableName ;
      private string A206AuditTableName ;
      private string sMode32 ;
      private DateTime Z205AuditDate ;
      private DateTime A205AuditDate ;
      private bool Gx_longc ;
      private string Z207AuditDescription ;
      private string A207AuditDescription ;
      private string Z208AuditShortDescription ;
      private string A208AuditShortDescription ;
      private string Z209AuditAction ;
      private string A209AuditAction ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC000T4_A204AuditId ;
      private DateTime[] BC000T4_A205AuditDate ;
      private string[] BC000T4_A206AuditTableName ;
      private string[] BC000T4_A207AuditDescription ;
      private string[] BC000T4_A208AuditShortDescription ;
      private string[] BC000T4_A209AuditAction ;
      private long[] BC000T4_A210SecUserId ;
      private long[] BC000T5_A204AuditId ;
      private long[] BC000T3_A204AuditId ;
      private DateTime[] BC000T3_A205AuditDate ;
      private string[] BC000T3_A206AuditTableName ;
      private string[] BC000T3_A207AuditDescription ;
      private string[] BC000T3_A208AuditShortDescription ;
      private string[] BC000T3_A209AuditAction ;
      private long[] BC000T3_A210SecUserId ;
      private long[] BC000T2_A204AuditId ;
      private DateTime[] BC000T2_A205AuditDate ;
      private string[] BC000T2_A206AuditTableName ;
      private string[] BC000T2_A207AuditDescription ;
      private string[] BC000T2_A208AuditShortDescription ;
      private string[] BC000T2_A209AuditAction ;
      private long[] BC000T2_A210SecUserId ;
      private long[] BC000T7_A204AuditId ;
      private long[] BC000T10_A204AuditId ;
      private DateTime[] BC000T10_A205AuditDate ;
      private string[] BC000T10_A206AuditTableName ;
      private string[] BC000T10_A207AuditDescription ;
      private string[] BC000T10_A208AuditShortDescription ;
      private string[] BC000T10_A209AuditAction ;
      private long[] BC000T10_A210SecUserId ;
      private SdtAudit bcAudit ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class audit_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class audit_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000T2;
        prmBC000T2 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmBC000T3;
        prmBC000T3 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmBC000T4;
        prmBC000T4 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmBC000T5;
        prmBC000T5 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmBC000T6;
        prmBC000T6 = new Object[] {
        new ParDef("AuditDate",GXType.Date,8,0) ,
        new ParDef("AuditTableName",GXType.Char,100,0) ,
        new ParDef("AuditDescription",GXType.VarChar,200,0) ,
        new ParDef("AuditShortDescription",GXType.VarChar,200,0) ,
        new ParDef("AuditAction",GXType.VarChar,10,0) ,
        new ParDef("SecUserId",GXType.Int64,10,0)
        };
        Object[] prmBC000T7;
        prmBC000T7 = new Object[] {
        };
        Object[] prmBC000T8;
        prmBC000T8 = new Object[] {
        new ParDef("AuditDate",GXType.Date,8,0) ,
        new ParDef("AuditTableName",GXType.Char,100,0) ,
        new ParDef("AuditDescription",GXType.VarChar,200,0) ,
        new ParDef("AuditShortDescription",GXType.VarChar,200,0) ,
        new ParDef("AuditAction",GXType.VarChar,10,0) ,
        new ParDef("SecUserId",GXType.Int64,10,0) ,
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmBC000T9;
        prmBC000T9 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmBC000T10;
        prmBC000T10 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000T2", "SELECT AuditId, AuditDate, AuditTableName, AuditDescription, AuditShortDescription, AuditAction, SecUserId FROM Audit WHERE AuditId = :AuditId  FOR UPDATE OF Audit",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T3", "SELECT AuditId, AuditDate, AuditTableName, AuditDescription, AuditShortDescription, AuditAction, SecUserId FROM Audit WHERE AuditId = :AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T4", "SELECT TM1.AuditId, TM1.AuditDate, TM1.AuditTableName, TM1.AuditDescription, TM1.AuditShortDescription, TM1.AuditAction, TM1.SecUserId FROM Audit TM1 WHERE TM1.AuditId = :AuditId ORDER BY TM1.AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T5", "SELECT AuditId FROM Audit WHERE AuditId = :AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T6", "SAVEPOINT gxupdate;INSERT INTO Audit(AuditDate, AuditTableName, AuditDescription, AuditShortDescription, AuditAction, SecUserId) VALUES(:AuditDate, :AuditTableName, :AuditDescription, :AuditShortDescription, :AuditAction, :SecUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000T6)
           ,new CursorDef("BC000T7", "SELECT currval('AuditId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T8", "SAVEPOINT gxupdate;UPDATE Audit SET AuditDate=:AuditDate, AuditTableName=:AuditTableName, AuditDescription=:AuditDescription, AuditShortDescription=:AuditShortDescription, AuditAction=:AuditAction, SecUserId=:SecUserId  WHERE AuditId = :AuditId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000T8)
           ,new CursorDef("BC000T9", "SAVEPOINT gxupdate;DELETE FROM Audit  WHERE AuditId = :AuditId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000T9)
           ,new CursorDef("BC000T10", "SELECT TM1.AuditId, TM1.AuditDate, TM1.AuditTableName, TM1.AuditDescription, TM1.AuditShortDescription, TM1.AuditAction, TM1.SecUserId FROM Audit TM1 WHERE TM1.AuditId = :AuditId ORDER BY TM1.AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T10,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              return;
     }
  }

}

}
