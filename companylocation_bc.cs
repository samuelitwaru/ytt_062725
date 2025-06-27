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
   public class companylocation_bc : GxSilentTrn, IGxSilentTrn
   {
      public companylocation_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public companylocation_bc( IGxContext context )
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
         ReadRow0M24( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0M24( ) ;
         standaloneModal( ) ;
         AddRow0M24( ) ;
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
            /* Execute user event: After Trn */
            E110M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z157CompanyLocationId = A157CompanyLocationId;
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

      protected void CONFIRM_0M0( )
      {
         BeforeValidate0M24( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0M24( ) ;
            }
            else
            {
               CheckExtendedTable0M24( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0M24( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120M2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0M24( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z158CompanyLocationName = A158CompanyLocationName;
            Z159CompanyLocationCode = A159CompanyLocationCode;
         }
         if ( GX_JID == -4 )
         {
            Z157CompanyLocationId = A157CompanyLocationId;
            Z158CompanyLocationName = A158CompanyLocationName;
            Z159CompanyLocationCode = A159CompanyLocationCode;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0M24( )
      {
         /* Using cursor BC000M4 */
         pr_default.execute(2, new Object[] {A157CompanyLocationId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound24 = 1;
            A158CompanyLocationName = BC000M4_A158CompanyLocationName[0];
            A159CompanyLocationCode = BC000M4_A159CompanyLocationCode[0];
            ZM0M24( -4) ;
         }
         pr_default.close(2);
         OnLoadActions0M24( ) ;
      }

      protected void OnLoadActions0M24( )
      {
      }

      protected void CheckExtendedTable0M24( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000M5 */
         pr_default.execute(3, new Object[] {A158CompanyLocationName, A157CompanyLocationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Company Location Name"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A158CompanyLocationName)) )
         {
            GX_msglist.addItem("Country Name cannot be empty", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A159CompanyLocationCode)) )
         {
            GX_msglist.addItem("Country Code cannot be empty", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0M24( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0M24( )
      {
         /* Using cursor BC000M6 */
         pr_default.execute(4, new Object[] {A157CompanyLocationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound24 = 1;
         }
         else
         {
            RcdFound24 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000M3 */
         pr_default.execute(1, new Object[] {A157CompanyLocationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0M24( 4) ;
            RcdFound24 = 1;
            A157CompanyLocationId = BC000M3_A157CompanyLocationId[0];
            A158CompanyLocationName = BC000M3_A158CompanyLocationName[0];
            A159CompanyLocationCode = BC000M3_A159CompanyLocationCode[0];
            Z157CompanyLocationId = A157CompanyLocationId;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0M24( ) ;
            if ( AnyError == 1 )
            {
               RcdFound24 = 0;
               InitializeNonKey0M24( ) ;
            }
            Gx_mode = sMode24;
         }
         else
         {
            RcdFound24 = 0;
            InitializeNonKey0M24( ) ;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode24;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0M24( ) ;
         if ( RcdFound24 == 0 )
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
         CONFIRM_0M0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0M24( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000M2 */
            pr_default.execute(0, new Object[] {A157CompanyLocationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CompanyLocation"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z158CompanyLocationName, BC000M2_A158CompanyLocationName[0]) != 0 ) || ( StringUtil.StrCmp(Z159CompanyLocationCode, BC000M2_A159CompanyLocationCode[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CompanyLocation"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0M24( )
      {
         BeforeValidate0M24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M24( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0M24( 0) ;
            CheckOptimisticConcurrency0M24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0M24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000M7 */
                     pr_default.execute(5, new Object[] {A158CompanyLocationName, A159CompanyLocationCode});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000M8 */
                     pr_default.execute(6);
                     A157CompanyLocationId = BC000M8_A157CompanyLocationId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("CompanyLocation");
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
               Load0M24( ) ;
            }
            EndLevel0M24( ) ;
         }
         CloseExtendedTableCursors0M24( ) ;
      }

      protected void Update0M24( )
      {
         BeforeValidate0M24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M24( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0M24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000M9 */
                     pr_default.execute(7, new Object[] {A158CompanyLocationName, A159CompanyLocationCode, A157CompanyLocationId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("CompanyLocation");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CompanyLocation"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0M24( ) ;
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
            EndLevel0M24( ) ;
         }
         CloseExtendedTableCursors0M24( ) ;
      }

      protected void DeferredUpdate0M24( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0M24( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M24( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0M24( ) ;
            AfterConfirm0M24( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0M24( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000M10 */
                  pr_default.execute(8, new Object[] {A157CompanyLocationId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("CompanyLocation");
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
         sMode24 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0M24( ) ;
         Gx_mode = sMode24;
      }

      protected void OnDeleteControls0M24( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000M11 */
            pr_default.execute(9, new Object[] {A157CompanyLocationId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0M24( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0M24( ) ;
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

      public void ScanKeyStart0M24( )
      {
         /* Scan By routine */
         /* Using cursor BC000M12 */
         pr_default.execute(10, new Object[] {A157CompanyLocationId});
         RcdFound24 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound24 = 1;
            A157CompanyLocationId = BC000M12_A157CompanyLocationId[0];
            A158CompanyLocationName = BC000M12_A158CompanyLocationName[0];
            A159CompanyLocationCode = BC000M12_A159CompanyLocationCode[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0M24( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound24 = 0;
         ScanKeyLoad0M24( ) ;
      }

      protected void ScanKeyLoad0M24( )
      {
         sMode24 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound24 = 1;
            A157CompanyLocationId = BC000M12_A157CompanyLocationId[0];
            A158CompanyLocationName = BC000M12_A158CompanyLocationName[0];
            A159CompanyLocationCode = BC000M12_A159CompanyLocationCode[0];
         }
         Gx_mode = sMode24;
      }

      protected void ScanKeyEnd0M24( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0M24( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0M24( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0M24( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0M24( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0M24( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0M24( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0M24( )
      {
      }

      protected void send_integrity_lvl_hashes0M24( )
      {
      }

      protected void AddRow0M24( )
      {
         VarsToRow24( bcCompanyLocation) ;
      }

      protected void ReadRow0M24( )
      {
         RowToVars24( bcCompanyLocation, 1) ;
      }

      protected void InitializeNonKey0M24( )
      {
         A158CompanyLocationName = "";
         A159CompanyLocationCode = "";
         Z158CompanyLocationName = "";
         Z159CompanyLocationCode = "";
      }

      protected void InitAll0M24( )
      {
         A157CompanyLocationId = 0;
         InitializeNonKey0M24( ) ;
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

      public void VarsToRow24( SdtCompanyLocation obj24 )
      {
         obj24.gxTpr_Mode = Gx_mode;
         obj24.gxTpr_Companylocationname = A158CompanyLocationName;
         obj24.gxTpr_Companylocationcode = A159CompanyLocationCode;
         obj24.gxTpr_Companylocationid = A157CompanyLocationId;
         obj24.gxTpr_Companylocationid_Z = Z157CompanyLocationId;
         obj24.gxTpr_Companylocationname_Z = Z158CompanyLocationName;
         obj24.gxTpr_Companylocationcode_Z = Z159CompanyLocationCode;
         obj24.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow24( SdtCompanyLocation obj24 )
      {
         obj24.gxTpr_Companylocationid = A157CompanyLocationId;
         return  ;
      }

      public void RowToVars24( SdtCompanyLocation obj24 ,
                               int forceLoad )
      {
         Gx_mode = obj24.gxTpr_Mode;
         A158CompanyLocationName = obj24.gxTpr_Companylocationname;
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) || ( forceLoad == 1 ) )
         {
            A159CompanyLocationCode = obj24.gxTpr_Companylocationcode;
         }
         A157CompanyLocationId = obj24.gxTpr_Companylocationid;
         Z157CompanyLocationId = obj24.gxTpr_Companylocationid_Z;
         Z158CompanyLocationName = obj24.gxTpr_Companylocationname_Z;
         Z159CompanyLocationCode = obj24.gxTpr_Companylocationcode_Z;
         Gx_mode = obj24.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A157CompanyLocationId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0M24( ) ;
         ScanKeyStart0M24( ) ;
         if ( RcdFound24 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z157CompanyLocationId = A157CompanyLocationId;
         }
         ZM0M24( -4) ;
         OnLoadActions0M24( ) ;
         AddRow0M24( ) ;
         ScanKeyEnd0M24( ) ;
         if ( RcdFound24 == 0 )
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
         RowToVars24( bcCompanyLocation, 0) ;
         ScanKeyStart0M24( ) ;
         if ( RcdFound24 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z157CompanyLocationId = A157CompanyLocationId;
         }
         ZM0M24( -4) ;
         OnLoadActions0M24( ) ;
         AddRow0M24( ) ;
         ScanKeyEnd0M24( ) ;
         if ( RcdFound24 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0M24( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0M24( ) ;
         }
         else
         {
            if ( RcdFound24 == 1 )
            {
               if ( A157CompanyLocationId != Z157CompanyLocationId )
               {
                  A157CompanyLocationId = Z157CompanyLocationId;
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
                  Update0M24( ) ;
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
                  if ( A157CompanyLocationId != Z157CompanyLocationId )
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
                        Insert0M24( ) ;
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
                        Insert0M24( ) ;
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
         RowToVars24( bcCompanyLocation, 1) ;
         SaveImpl( ) ;
         VarsToRow24( bcCompanyLocation) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars24( bcCompanyLocation, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0M24( ) ;
         AfterTrn( ) ;
         VarsToRow24( bcCompanyLocation) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow24( bcCompanyLocation) ;
         }
         else
         {
            SdtCompanyLocation auxBC = new SdtCompanyLocation(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A157CompanyLocationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCompanyLocation);
               auxBC.Save();
               bcCompanyLocation.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars24( bcCompanyLocation, 1) ;
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
         RowToVars24( bcCompanyLocation, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0M24( ) ;
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
               VarsToRow24( bcCompanyLocation) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow24( bcCompanyLocation) ;
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
         RowToVars24( bcCompanyLocation, 0) ;
         GetKey0M24( ) ;
         if ( RcdFound24 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A157CompanyLocationId != Z157CompanyLocationId )
            {
               A157CompanyLocationId = Z157CompanyLocationId;
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
            if ( A157CompanyLocationId != Z157CompanyLocationId )
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
         context.RollbackDataStores("companylocation_bc",pr_default);
         VarsToRow24( bcCompanyLocation) ;
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
         Gx_mode = bcCompanyLocation.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCompanyLocation.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCompanyLocation )
         {
            bcCompanyLocation = (SdtCompanyLocation)(sdt);
            if ( StringUtil.StrCmp(bcCompanyLocation.gxTpr_Mode, "") == 0 )
            {
               bcCompanyLocation.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow24( bcCompanyLocation) ;
            }
            else
            {
               RowToVars24( bcCompanyLocation, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCompanyLocation.gxTpr_Mode, "") == 0 )
            {
               bcCompanyLocation.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars24( bcCompanyLocation, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtCompanyLocation CompanyLocation_BC
      {
         get {
            return bcCompanyLocation ;
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
            return "companylocation_Execute" ;
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z158CompanyLocationName = "";
         A158CompanyLocationName = "";
         Z159CompanyLocationCode = "";
         A159CompanyLocationCode = "";
         BC000M4_A157CompanyLocationId = new long[1] ;
         BC000M4_A158CompanyLocationName = new string[] {""} ;
         BC000M4_A159CompanyLocationCode = new string[] {""} ;
         BC000M5_A158CompanyLocationName = new string[] {""} ;
         BC000M6_A157CompanyLocationId = new long[1] ;
         BC000M3_A157CompanyLocationId = new long[1] ;
         BC000M3_A158CompanyLocationName = new string[] {""} ;
         BC000M3_A159CompanyLocationCode = new string[] {""} ;
         sMode24 = "";
         BC000M2_A157CompanyLocationId = new long[1] ;
         BC000M2_A158CompanyLocationName = new string[] {""} ;
         BC000M2_A159CompanyLocationCode = new string[] {""} ;
         BC000M8_A157CompanyLocationId = new long[1] ;
         BC000M11_A100CompanyId = new long[1] ;
         BC000M12_A157CompanyLocationId = new long[1] ;
         BC000M12_A158CompanyLocationName = new string[] {""} ;
         BC000M12_A159CompanyLocationCode = new string[] {""} ;
         N159CompanyLocationCode = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.companylocation_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.companylocation_bc__default(),
            new Object[][] {
                new Object[] {
               BC000M2_A157CompanyLocationId, BC000M2_A158CompanyLocationName, BC000M2_A159CompanyLocationCode
               }
               , new Object[] {
               BC000M3_A157CompanyLocationId, BC000M3_A158CompanyLocationName, BC000M3_A159CompanyLocationCode
               }
               , new Object[] {
               BC000M4_A157CompanyLocationId, BC000M4_A158CompanyLocationName, BC000M4_A159CompanyLocationCode
               }
               , new Object[] {
               BC000M5_A158CompanyLocationName
               }
               , new Object[] {
               BC000M6_A157CompanyLocationId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000M8_A157CompanyLocationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000M11_A100CompanyId
               }
               , new Object[] {
               BC000M12_A157CompanyLocationId, BC000M12_A158CompanyLocationName, BC000M12_A159CompanyLocationCode
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120M2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound24 ;
      private int trnEnded ;
      private long Z157CompanyLocationId ;
      private long A157CompanyLocationId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z158CompanyLocationName ;
      private string A158CompanyLocationName ;
      private string Z159CompanyLocationCode ;
      private string A159CompanyLocationCode ;
      private string sMode24 ;
      private string N159CompanyLocationCode ;
      private bool returnInSub ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] BC000M4_A157CompanyLocationId ;
      private string[] BC000M4_A158CompanyLocationName ;
      private string[] BC000M4_A159CompanyLocationCode ;
      private string[] BC000M5_A158CompanyLocationName ;
      private long[] BC000M6_A157CompanyLocationId ;
      private long[] BC000M3_A157CompanyLocationId ;
      private string[] BC000M3_A158CompanyLocationName ;
      private string[] BC000M3_A159CompanyLocationCode ;
      private long[] BC000M2_A157CompanyLocationId ;
      private string[] BC000M2_A158CompanyLocationName ;
      private string[] BC000M2_A159CompanyLocationCode ;
      private long[] BC000M8_A157CompanyLocationId ;
      private long[] BC000M11_A100CompanyId ;
      private long[] BC000M12_A157CompanyLocationId ;
      private string[] BC000M12_A158CompanyLocationName ;
      private string[] BC000M12_A159CompanyLocationCode ;
      private SdtCompanyLocation bcCompanyLocation ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class companylocation_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class companylocation_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000M2;
        prmBC000M2 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmBC000M3;
        prmBC000M3 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmBC000M4;
        prmBC000M4 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmBC000M5;
        prmBC000M5 = new Object[] {
        new ParDef("CompanyLocationName",GXType.Char,100,0) ,
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmBC000M6;
        prmBC000M6 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmBC000M7;
        prmBC000M7 = new Object[] {
        new ParDef("CompanyLocationName",GXType.Char,100,0) ,
        new ParDef("CompanyLocationCode",GXType.Char,20,0)
        };
        Object[] prmBC000M8;
        prmBC000M8 = new Object[] {
        };
        Object[] prmBC000M9;
        prmBC000M9 = new Object[] {
        new ParDef("CompanyLocationName",GXType.Char,100,0) ,
        new ParDef("CompanyLocationCode",GXType.Char,20,0) ,
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmBC000M10;
        prmBC000M10 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmBC000M11;
        prmBC000M11 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmBC000M12;
        prmBC000M12 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000M2", "SELECT CompanyLocationId, CompanyLocationName, CompanyLocationCode FROM CompanyLocation WHERE CompanyLocationId = :CompanyLocationId  FOR UPDATE OF CompanyLocation",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M3", "SELECT CompanyLocationId, CompanyLocationName, CompanyLocationCode FROM CompanyLocation WHERE CompanyLocationId = :CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M4", "SELECT TM1.CompanyLocationId, TM1.CompanyLocationName, TM1.CompanyLocationCode FROM CompanyLocation TM1 WHERE TM1.CompanyLocationId = :CompanyLocationId ORDER BY TM1.CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M5", "SELECT CompanyLocationName FROM CompanyLocation WHERE (CompanyLocationName = :CompanyLocationName) AND (Not ( CompanyLocationId = :CompanyLocationId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M6", "SELECT CompanyLocationId FROM CompanyLocation WHERE CompanyLocationId = :CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M7", "SAVEPOINT gxupdate;INSERT INTO CompanyLocation(CompanyLocationName, CompanyLocationCode) VALUES(:CompanyLocationName, :CompanyLocationCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000M7)
           ,new CursorDef("BC000M8", "SELECT currval('CompanyLocationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M9", "SAVEPOINT gxupdate;UPDATE CompanyLocation SET CompanyLocationName=:CompanyLocationName, CompanyLocationCode=:CompanyLocationCode  WHERE CompanyLocationId = :CompanyLocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000M9)
           ,new CursorDef("BC000M10", "SAVEPOINT gxupdate;DELETE FROM CompanyLocation  WHERE CompanyLocationId = :CompanyLocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000M10)
           ,new CursorDef("BC000M11", "SELECT CompanyId FROM Company WHERE CompanyLocationId = :CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000M12", "SELECT TM1.CompanyLocationId, TM1.CompanyLocationName, TM1.CompanyLocationCode FROM CompanyLocation TM1 WHERE TM1.CompanyLocationId = :CompanyLocationId ORDER BY TM1.CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M12,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
     }
  }

}

}
