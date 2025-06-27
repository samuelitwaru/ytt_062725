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
   public class usercustomizations_bc : GxSilentTrn, IGxSilentTrn
   {
      public usercustomizations_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public usercustomizations_bc( IGxContext context )
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
         ReadRow0C13( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0C13( ) ;
         standaloneModal( ) ;
         AddRow0C13( ) ;
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
               Z94UserCustomizationsId = A94UserCustomizationsId;
               Z95UserCustomizationsKey = A95UserCustomizationsKey;
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C13( ) ;
            }
            else
            {
               CheckExtendedTable0C13( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0C13( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0C13( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z94UserCustomizationsId = A94UserCustomizationsId;
            Z95UserCustomizationsKey = A95UserCustomizationsKey;
            Z96UserCustomizationsValue = A96UserCustomizationsValue;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0C13( )
      {
         /* Using cursor BC000C4 */
         pr_default.execute(2, new Object[] {A94UserCustomizationsId, A95UserCustomizationsKey});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound13 = 1;
            A96UserCustomizationsValue = BC000C4_A96UserCustomizationsValue[0];
            ZM0C13( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0C13( ) ;
      }

      protected void OnLoadActions0C13( )
      {
      }

      protected void CheckExtendedTable0C13( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0C13( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0C13( )
      {
         /* Using cursor BC000C5 */
         pr_default.execute(3, new Object[] {A94UserCustomizationsId, A95UserCustomizationsKey});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000C3 */
         pr_default.execute(1, new Object[] {A94UserCustomizationsId, A95UserCustomizationsKey});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C13( 1) ;
            RcdFound13 = 1;
            A94UserCustomizationsId = BC000C3_A94UserCustomizationsId[0];
            A95UserCustomizationsKey = BC000C3_A95UserCustomizationsKey[0];
            A96UserCustomizationsValue = BC000C3_A96UserCustomizationsValue[0];
            Z94UserCustomizationsId = A94UserCustomizationsId;
            Z95UserCustomizationsKey = A95UserCustomizationsKey;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0C13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0C13( ) ;
            }
            Gx_mode = sMode13;
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0C13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode13;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C13( ) ;
         if ( RcdFound13 == 0 )
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
         CONFIRM_0C0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0C13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000C2 */
            pr_default.execute(0, new Object[] {A94UserCustomizationsId, A95UserCustomizationsKey});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UserCustomizations"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"UserCustomizations"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C13( 0) ;
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C6 */
                     pr_default.execute(4, new Object[] {A94UserCustomizationsId, A95UserCustomizationsKey, A96UserCustomizationsValue});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("UserCustomizations");
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
               Load0C13( ) ;
            }
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void Update0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C7 */
                     pr_default.execute(5, new Object[] {A96UserCustomizationsValue, A94UserCustomizationsId, A95UserCustomizationsKey});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("UserCustomizations");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UserCustomizations"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C13( ) ;
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
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void DeferredUpdate0C13( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C13( ) ;
            AfterConfirm0C13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000C8 */
                  pr_default.execute(6, new Object[] {A94UserCustomizationsId, A95UserCustomizationsKey});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("UserCustomizations");
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
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0C13( ) ;
         Gx_mode = sMode13;
      }

      protected void OnDeleteControls0C13( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0C13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C13( ) ;
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

      public void ScanKeyStart0C13( )
      {
         /* Using cursor BC000C9 */
         pr_default.execute(7, new Object[] {A94UserCustomizationsId, A95UserCustomizationsKey});
         RcdFound13 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound13 = 1;
            A94UserCustomizationsId = BC000C9_A94UserCustomizationsId[0];
            A95UserCustomizationsKey = BC000C9_A95UserCustomizationsKey[0];
            A96UserCustomizationsValue = BC000C9_A96UserCustomizationsValue[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0C13( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound13 = 0;
         ScanKeyLoad0C13( ) ;
      }

      protected void ScanKeyLoad0C13( )
      {
         sMode13 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound13 = 1;
            A94UserCustomizationsId = BC000C9_A94UserCustomizationsId[0];
            A95UserCustomizationsKey = BC000C9_A95UserCustomizationsKey[0];
            A96UserCustomizationsValue = BC000C9_A96UserCustomizationsValue[0];
         }
         Gx_mode = sMode13;
      }

      protected void ScanKeyEnd0C13( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0C13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C13( )
      {
      }

      protected void send_integrity_lvl_hashes0C13( )
      {
      }

      protected void AddRow0C13( )
      {
         VarsToRow13( bcwwpbaseobjects_UserCustomizations) ;
      }

      protected void ReadRow0C13( )
      {
         RowToVars13( bcwwpbaseobjects_UserCustomizations, 1) ;
      }

      protected void InitializeNonKey0C13( )
      {
         A96UserCustomizationsValue = "";
      }

      protected void InitAll0C13( )
      {
         A94UserCustomizationsId = "";
         A95UserCustomizationsKey = "";
         InitializeNonKey0C13( ) ;
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

      public void VarsToRow13( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj13 )
      {
         obj13.gxTpr_Mode = Gx_mode;
         obj13.gxTpr_Usercustomizationsvalue = A96UserCustomizationsValue;
         obj13.gxTpr_Usercustomizationsid = A94UserCustomizationsId;
         obj13.gxTpr_Usercustomizationskey = A95UserCustomizationsKey;
         obj13.gxTpr_Usercustomizationsid_Z = Z94UserCustomizationsId;
         obj13.gxTpr_Usercustomizationskey_Z = Z95UserCustomizationsKey;
         obj13.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow13( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj13 )
      {
         obj13.gxTpr_Usercustomizationsid = A94UserCustomizationsId;
         obj13.gxTpr_Usercustomizationskey = A95UserCustomizationsKey;
         return  ;
      }

      public void RowToVars13( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj13 ,
                               int forceLoad )
      {
         Gx_mode = obj13.gxTpr_Mode;
         A96UserCustomizationsValue = obj13.gxTpr_Usercustomizationsvalue;
         A94UserCustomizationsId = obj13.gxTpr_Usercustomizationsid;
         A95UserCustomizationsKey = obj13.gxTpr_Usercustomizationskey;
         Z94UserCustomizationsId = obj13.gxTpr_Usercustomizationsid_Z;
         Z95UserCustomizationsKey = obj13.gxTpr_Usercustomizationskey_Z;
         Gx_mode = obj13.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A94UserCustomizationsId = (string)getParm(obj,0);
         A95UserCustomizationsKey = (string)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0C13( ) ;
         ScanKeyStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z94UserCustomizationsId = A94UserCustomizationsId;
            Z95UserCustomizationsKey = A95UserCustomizationsKey;
         }
         ZM0C13( -1) ;
         OnLoadActions0C13( ) ;
         AddRow0C13( ) ;
         ScanKeyEnd0C13( ) ;
         if ( RcdFound13 == 0 )
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
         RowToVars13( bcwwpbaseobjects_UserCustomizations, 0) ;
         ScanKeyStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z94UserCustomizationsId = A94UserCustomizationsId;
            Z95UserCustomizationsKey = A95UserCustomizationsKey;
         }
         ZM0C13( -1) ;
         OnLoadActions0C13( ) ;
         AddRow0C13( ) ;
         ScanKeyEnd0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0C13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0C13( ) ;
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( ( StringUtil.StrCmp(A94UserCustomizationsId, Z94UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A95UserCustomizationsKey, Z95UserCustomizationsKey) != 0 ) )
               {
                  A94UserCustomizationsId = Z94UserCustomizationsId;
                  A95UserCustomizationsKey = Z95UserCustomizationsKey;
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
                  Update0C13( ) ;
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
                  if ( ( StringUtil.StrCmp(A94UserCustomizationsId, Z94UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A95UserCustomizationsKey, Z95UserCustomizationsKey) != 0 ) )
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
                        Insert0C13( ) ;
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
                        Insert0C13( ) ;
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
         RowToVars13( bcwwpbaseobjects_UserCustomizations, 1) ;
         SaveImpl( ) ;
         VarsToRow13( bcwwpbaseobjects_UserCustomizations) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars13( bcwwpbaseobjects_UserCustomizations, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C13( ) ;
         AfterTrn( ) ;
         VarsToRow13( bcwwpbaseobjects_UserCustomizations) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow13( bcwwpbaseobjects_UserCustomizations) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations auxBC = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A94UserCustomizationsId, A95UserCustomizationsKey);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_UserCustomizations);
               auxBC.Save();
               bcwwpbaseobjects_UserCustomizations.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars13( bcwwpbaseobjects_UserCustomizations, 1) ;
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
         RowToVars13( bcwwpbaseobjects_UserCustomizations, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C13( ) ;
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
               VarsToRow13( bcwwpbaseobjects_UserCustomizations) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow13( bcwwpbaseobjects_UserCustomizations) ;
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
         RowToVars13( bcwwpbaseobjects_UserCustomizations, 0) ;
         GetKey0C13( ) ;
         if ( RcdFound13 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( StringUtil.StrCmp(A94UserCustomizationsId, Z94UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A95UserCustomizationsKey, Z95UserCustomizationsKey) != 0 ) )
            {
               A94UserCustomizationsId = Z94UserCustomizationsId;
               A95UserCustomizationsKey = Z95UserCustomizationsKey;
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
            if ( ( StringUtil.StrCmp(A94UserCustomizationsId, Z94UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A95UserCustomizationsKey, Z95UserCustomizationsKey) != 0 ) )
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
         context.RollbackDataStores("wwpbaseobjects.usercustomizations_bc",pr_default);
         VarsToRow13( bcwwpbaseobjects_UserCustomizations) ;
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
         Gx_mode = bcwwpbaseobjects_UserCustomizations.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_UserCustomizations )
         {
            bcwwpbaseobjects_UserCustomizations = (GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_UserCustomizations.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow13( bcwwpbaseobjects_UserCustomizations) ;
            }
            else
            {
               RowToVars13( bcwwpbaseobjects_UserCustomizations, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_UserCustomizations.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars13( bcwwpbaseobjects_UserCustomizations, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtUserCustomizations UserCustomizations_BC
      {
         get {
            return bcwwpbaseobjects_UserCustomizations ;
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
            return "usercustomizations_Execute" ;
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
         Z94UserCustomizationsId = "";
         A94UserCustomizationsId = "";
         Z95UserCustomizationsKey = "";
         A95UserCustomizationsKey = "";
         Z96UserCustomizationsValue = "";
         A96UserCustomizationsValue = "";
         BC000C4_A94UserCustomizationsId = new string[] {""} ;
         BC000C4_A95UserCustomizationsKey = new string[] {""} ;
         BC000C4_A96UserCustomizationsValue = new string[] {""} ;
         BC000C5_A94UserCustomizationsId = new string[] {""} ;
         BC000C5_A95UserCustomizationsKey = new string[] {""} ;
         BC000C3_A94UserCustomizationsId = new string[] {""} ;
         BC000C3_A95UserCustomizationsKey = new string[] {""} ;
         BC000C3_A96UserCustomizationsValue = new string[] {""} ;
         sMode13 = "";
         BC000C2_A94UserCustomizationsId = new string[] {""} ;
         BC000C2_A95UserCustomizationsKey = new string[] {""} ;
         BC000C2_A96UserCustomizationsValue = new string[] {""} ;
         BC000C9_A94UserCustomizationsId = new string[] {""} ;
         BC000C9_A95UserCustomizationsKey = new string[] {""} ;
         BC000C9_A96UserCustomizationsValue = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.usercustomizations_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.usercustomizations_bc__default(),
            new Object[][] {
                new Object[] {
               BC000C2_A94UserCustomizationsId, BC000C2_A95UserCustomizationsKey, BC000C2_A96UserCustomizationsValue
               }
               , new Object[] {
               BC000C3_A94UserCustomizationsId, BC000C3_A95UserCustomizationsKey, BC000C3_A96UserCustomizationsValue
               }
               , new Object[] {
               BC000C4_A94UserCustomizationsId, BC000C4_A95UserCustomizationsKey, BC000C4_A96UserCustomizationsValue
               }
               , new Object[] {
               BC000C5_A94UserCustomizationsId, BC000C5_A95UserCustomizationsKey
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000C9_A94UserCustomizationsId, BC000C9_A95UserCustomizationsKey, BC000C9_A96UserCustomizationsValue
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound13 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z94UserCustomizationsId ;
      private string A94UserCustomizationsId ;
      private string sMode13 ;
      private string Z96UserCustomizationsValue ;
      private string A96UserCustomizationsValue ;
      private string Z95UserCustomizationsKey ;
      private string A95UserCustomizationsKey ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000C4_A94UserCustomizationsId ;
      private string[] BC000C4_A95UserCustomizationsKey ;
      private string[] BC000C4_A96UserCustomizationsValue ;
      private string[] BC000C5_A94UserCustomizationsId ;
      private string[] BC000C5_A95UserCustomizationsKey ;
      private string[] BC000C3_A94UserCustomizationsId ;
      private string[] BC000C3_A95UserCustomizationsKey ;
      private string[] BC000C3_A96UserCustomizationsValue ;
      private string[] BC000C2_A94UserCustomizationsId ;
      private string[] BC000C2_A95UserCustomizationsKey ;
      private string[] BC000C2_A96UserCustomizationsValue ;
      private string[] BC000C9_A94UserCustomizationsId ;
      private string[] BC000C9_A95UserCustomizationsKey ;
      private string[] BC000C9_A96UserCustomizationsValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations bcwwpbaseobjects_UserCustomizations ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class usercustomizations_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class usercustomizations_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[7])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000C2;
        prmBC000C2 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000C3;
        prmBC000C3 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000C4;
        prmBC000C4 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000C5;
        prmBC000C5 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000C6;
        prmBC000C6 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0) ,
        new ParDef("UserCustomizationsValue",GXType.LongVarChar,2097152,0)
        };
        Object[] prmBC000C7;
        prmBC000C7 = new Object[] {
        new ParDef("UserCustomizationsValue",GXType.LongVarChar,2097152,0) ,
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000C8;
        prmBC000C8 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000C9;
        prmBC000C9 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000C2", "SELECT UserCustomizationsId, UserCustomizationsKey, UserCustomizationsValue FROM UserCustomizations WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey  FOR UPDATE OF UserCustomizations",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C3", "SELECT UserCustomizationsId, UserCustomizationsKey, UserCustomizationsValue FROM UserCustomizations WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C4", "SELECT TM1.UserCustomizationsId, TM1.UserCustomizationsKey, TM1.UserCustomizationsValue FROM UserCustomizations TM1 WHERE TM1.UserCustomizationsId = ( :UserCustomizationsId) and TM1.UserCustomizationsKey = ( :UserCustomizationsKey) ORDER BY TM1.UserCustomizationsId, TM1.UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C5", "SELECT UserCustomizationsId, UserCustomizationsKey FROM UserCustomizations WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C6", "SAVEPOINT gxupdate;INSERT INTO UserCustomizations(UserCustomizationsId, UserCustomizationsKey, UserCustomizationsValue) VALUES(:UserCustomizationsId, :UserCustomizationsKey, :UserCustomizationsValue);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000C6)
           ,new CursorDef("BC000C7", "SAVEPOINT gxupdate;UPDATE UserCustomizations SET UserCustomizationsValue=:UserCustomizationsValue  WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000C7)
           ,new CursorDef("BC000C8", "SAVEPOINT gxupdate;DELETE FROM UserCustomizations  WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000C8)
           ,new CursorDef("BC000C9", "SELECT TM1.UserCustomizationsId, TM1.UserCustomizationsKey, TM1.UserCustomizationsValue FROM UserCustomizations TM1 WHERE TM1.UserCustomizationsId = ( :UserCustomizationsId) and TM1.UserCustomizationsKey = ( :UserCustomizationsKey) ORDER BY TM1.UserCustomizationsId, TM1.UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C9,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
     }
  }

}

}
