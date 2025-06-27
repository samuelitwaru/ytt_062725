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
   public class company_bc : GxSilentTrn, IGxSilentTrn
   {
      public company_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public company_bc( IGxContext context )
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
         ReadRow0D14( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0D14( ) ;
         standaloneModal( ) ;
         AddRow0D14( ) ;
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
            E110D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z100CompanyId = A100CompanyId;
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

      protected void CONFIRM_0D0( )
      {
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0D14( ) ;
            }
            else
            {
               CheckExtendedTable0D14( ) ;
               if ( AnyError == 0 )
               {
                  ZM0D14( 6) ;
               }
               CloseExtendedTableCursors0D14( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120D2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1;
            while ( AV25GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV25GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CompanyLocationId") == 0 )
               {
                  AV23Insert_CompanyLocationId = (long)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV25GXV1 = (int)(AV25GXV1+1);
            }
         }
      }

      protected void E110D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0D14( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z101CompanyName = A101CompanyName;
            Z157CompanyLocationId = A157CompanyLocationId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z158CompanyLocationName = A158CompanyLocationName;
         }
         if ( GX_JID == -4 )
         {
            Z100CompanyId = A100CompanyId;
            Z101CompanyName = A101CompanyName;
            Z157CompanyLocationId = A157CompanyLocationId;
            Z158CompanyLocationName = A158CompanyLocationName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV24Pgmname = "Company_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0D14( )
      {
         /* Using cursor BC000D5 */
         pr_default.execute(3, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound14 = 1;
            A101CompanyName = BC000D5_A101CompanyName[0];
            A158CompanyLocationName = BC000D5_A158CompanyLocationName[0];
            A157CompanyLocationId = BC000D5_A157CompanyLocationId[0];
            ZM0D14( -4) ;
         }
         pr_default.close(3);
         OnLoadActions0D14( ) ;
      }

      protected void OnLoadActions0D14( )
      {
      }

      protected void CheckExtendedTable0D14( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000D6 */
         pr_default.execute(4, new Object[] {A101CompanyName, A100CompanyId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Company Name"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(4);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A101CompanyName)) )
         {
            GX_msglist.addItem("Company Name cannot be empty", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000D4 */
         pr_default.execute(2, new Object[] {A157CompanyLocationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'CompanyLocation'.", "ForeignKeyNotFound", 1, "COMPANYLOCATIONID");
            AnyError = 1;
         }
         A158CompanyLocationName = BC000D4_A158CompanyLocationName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0D14( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0D14( )
      {
         /* Using cursor BC000D7 */
         pr_default.execute(5, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000D3 */
         pr_default.execute(1, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D14( 4) ;
            RcdFound14 = 1;
            A100CompanyId = BC000D3_A100CompanyId[0];
            A101CompanyName = BC000D3_A101CompanyName[0];
            A157CompanyLocationId = BC000D3_A157CompanyLocationId[0];
            Z100CompanyId = A100CompanyId;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0D14( ) ;
            if ( AnyError == 1 )
            {
               RcdFound14 = 0;
               InitializeNonKey0D14( ) ;
            }
            Gx_mode = sMode14;
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0D14( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode14;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D14( ) ;
         if ( RcdFound14 == 0 )
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
         CONFIRM_0D0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0D14( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000D2 */
            pr_default.execute(0, new Object[] {A100CompanyId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Company"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z101CompanyName, BC000D2_A101CompanyName[0]) != 0 ) || ( Z157CompanyLocationId != BC000D2_A157CompanyLocationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Company"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D14( )
      {
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D14( 0) ;
            CheckOptimisticConcurrency0D14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D8 */
                     pr_default.execute(6, new Object[] {A101CompanyName, A157CompanyLocationId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000D9 */
                     pr_default.execute(7);
                     A100CompanyId = BC000D9_A100CompanyId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Company");
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
               Load0D14( ) ;
            }
            EndLevel0D14( ) ;
         }
         CloseExtendedTableCursors0D14( ) ;
      }

      protected void Update0D14( )
      {
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D10 */
                     pr_default.execute(8, new Object[] {A101CompanyName, A157CompanyLocationId, A100CompanyId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Company");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Company"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D14( ) ;
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
            EndLevel0D14( ) ;
         }
         CloseExtendedTableCursors0D14( ) ;
      }

      protected void DeferredUpdate0D14( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D14( ) ;
            AfterConfirm0D14( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D14( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000D11 */
                  pr_default.execute(9, new Object[] {A100CompanyId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Company");
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
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0D14( ) ;
         Gx_mode = sMode14;
      }

      protected void OnDeleteControls0D14( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000D12 */
            pr_default.execute(10, new Object[] {A157CompanyLocationId});
            A158CompanyLocationName = BC000D12_A158CompanyLocationName[0];
            pr_default.close(10);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000D13 */
            pr_default.execute(11, new Object[] {A100CompanyId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SiteSetting"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000D14 */
            pr_default.execute(12, new Object[] {A100CompanyId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"LeaveType"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000D15 */
            pr_default.execute(13, new Object[] {A100CompanyId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC000D16 */
            pr_default.execute(14, new Object[] {A100CompanyId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel0D14( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D14( ) ;
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

      public void ScanKeyStart0D14( )
      {
         /* Scan By routine */
         /* Using cursor BC000D17 */
         pr_default.execute(15, new Object[] {A100CompanyId});
         RcdFound14 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound14 = 1;
            A100CompanyId = BC000D17_A100CompanyId[0];
            A101CompanyName = BC000D17_A101CompanyName[0];
            A158CompanyLocationName = BC000D17_A158CompanyLocationName[0];
            A157CompanyLocationId = BC000D17_A157CompanyLocationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0D14( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound14 = 0;
         ScanKeyLoad0D14( ) ;
      }

      protected void ScanKeyLoad0D14( )
      {
         sMode14 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound14 = 1;
            A100CompanyId = BC000D17_A100CompanyId[0];
            A101CompanyName = BC000D17_A101CompanyName[0];
            A158CompanyLocationName = BC000D17_A158CompanyLocationName[0];
            A157CompanyLocationId = BC000D17_A157CompanyLocationId[0];
         }
         Gx_mode = sMode14;
      }

      protected void ScanKeyEnd0D14( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0D14( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D14( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D14( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D14( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D14( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D14( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D14( )
      {
      }

      protected void send_integrity_lvl_hashes0D14( )
      {
      }

      protected void AddRow0D14( )
      {
         VarsToRow14( bcCompany) ;
      }

      protected void ReadRow0D14( )
      {
         RowToVars14( bcCompany, 1) ;
      }

      protected void InitializeNonKey0D14( )
      {
         A101CompanyName = "";
         A157CompanyLocationId = 0;
         A158CompanyLocationName = "";
         Z101CompanyName = "";
         Z157CompanyLocationId = 0;
      }

      protected void InitAll0D14( )
      {
         A100CompanyId = 0;
         InitializeNonKey0D14( ) ;
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

      public void VarsToRow14( SdtCompany obj14 )
      {
         obj14.gxTpr_Mode = Gx_mode;
         obj14.gxTpr_Companyname = A101CompanyName;
         obj14.gxTpr_Companylocationid = A157CompanyLocationId;
         obj14.gxTpr_Companylocationname = A158CompanyLocationName;
         obj14.gxTpr_Companyid = A100CompanyId;
         obj14.gxTpr_Companyid_Z = Z100CompanyId;
         obj14.gxTpr_Companyname_Z = Z101CompanyName;
         obj14.gxTpr_Companylocationid_Z = Z157CompanyLocationId;
         obj14.gxTpr_Companylocationname_Z = Z158CompanyLocationName;
         obj14.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow14( SdtCompany obj14 )
      {
         obj14.gxTpr_Companyid = A100CompanyId;
         return  ;
      }

      public void RowToVars14( SdtCompany obj14 ,
                               int forceLoad )
      {
         Gx_mode = obj14.gxTpr_Mode;
         A101CompanyName = obj14.gxTpr_Companyname;
         A157CompanyLocationId = obj14.gxTpr_Companylocationid;
         A158CompanyLocationName = obj14.gxTpr_Companylocationname;
         A100CompanyId = obj14.gxTpr_Companyid;
         Z100CompanyId = obj14.gxTpr_Companyid_Z;
         Z101CompanyName = obj14.gxTpr_Companyname_Z;
         Z157CompanyLocationId = obj14.gxTpr_Companylocationid_Z;
         Z158CompanyLocationName = obj14.gxTpr_Companylocationname_Z;
         Gx_mode = obj14.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A100CompanyId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0D14( ) ;
         ScanKeyStart0D14( ) ;
         if ( RcdFound14 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z100CompanyId = A100CompanyId;
         }
         ZM0D14( -4) ;
         OnLoadActions0D14( ) ;
         AddRow0D14( ) ;
         ScanKeyEnd0D14( ) ;
         if ( RcdFound14 == 0 )
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
         RowToVars14( bcCompany, 0) ;
         ScanKeyStart0D14( ) ;
         if ( RcdFound14 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z100CompanyId = A100CompanyId;
         }
         ZM0D14( -4) ;
         OnLoadActions0D14( ) ;
         AddRow0D14( ) ;
         ScanKeyEnd0D14( ) ;
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0D14( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0D14( ) ;
         }
         else
         {
            if ( RcdFound14 == 1 )
            {
               if ( A100CompanyId != Z100CompanyId )
               {
                  A100CompanyId = Z100CompanyId;
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
                  Update0D14( ) ;
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
                  if ( A100CompanyId != Z100CompanyId )
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
                        Insert0D14( ) ;
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
                        Insert0D14( ) ;
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
         RowToVars14( bcCompany, 1) ;
         SaveImpl( ) ;
         VarsToRow14( bcCompany) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars14( bcCompany, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D14( ) ;
         AfterTrn( ) ;
         VarsToRow14( bcCompany) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow14( bcCompany) ;
         }
         else
         {
            SdtCompany auxBC = new SdtCompany(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A100CompanyId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCompany);
               auxBC.Save();
               bcCompany.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars14( bcCompany, 1) ;
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
         RowToVars14( bcCompany, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D14( ) ;
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
               VarsToRow14( bcCompany) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow14( bcCompany) ;
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
         RowToVars14( bcCompany, 0) ;
         GetKey0D14( ) ;
         if ( RcdFound14 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A100CompanyId != Z100CompanyId )
            {
               A100CompanyId = Z100CompanyId;
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
            if ( A100CompanyId != Z100CompanyId )
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
         context.RollbackDataStores("company_bc",pr_default);
         VarsToRow14( bcCompany) ;
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
         Gx_mode = bcCompany.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCompany.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCompany )
         {
            bcCompany = (SdtCompany)(sdt);
            if ( StringUtil.StrCmp(bcCompany.gxTpr_Mode, "") == 0 )
            {
               bcCompany.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow14( bcCompany) ;
            }
            else
            {
               RowToVars14( bcCompany, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCompany.gxTpr_Mode, "") == 0 )
            {
               bcCompany.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars14( bcCompany, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtCompany Company_BC
      {
         get {
            return bcCompany ;
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
            return "company_Execute" ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV24Pgmname = "";
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z101CompanyName = "";
         A101CompanyName = "";
         Z158CompanyLocationName = "";
         A158CompanyLocationName = "";
         BC000D5_A100CompanyId = new long[1] ;
         BC000D5_A101CompanyName = new string[] {""} ;
         BC000D5_A158CompanyLocationName = new string[] {""} ;
         BC000D5_A157CompanyLocationId = new long[1] ;
         BC000D6_A101CompanyName = new string[] {""} ;
         BC000D4_A158CompanyLocationName = new string[] {""} ;
         BC000D7_A100CompanyId = new long[1] ;
         BC000D3_A100CompanyId = new long[1] ;
         BC000D3_A101CompanyName = new string[] {""} ;
         BC000D3_A157CompanyLocationId = new long[1] ;
         sMode14 = "";
         BC000D2_A100CompanyId = new long[1] ;
         BC000D2_A101CompanyName = new string[] {""} ;
         BC000D2_A157CompanyLocationId = new long[1] ;
         BC000D9_A100CompanyId = new long[1] ;
         BC000D12_A158CompanyLocationName = new string[] {""} ;
         BC000D13_A160SiteSettingId = new long[1] ;
         BC000D14_A124LeaveTypeId = new long[1] ;
         BC000D15_A113HolidayId = new long[1] ;
         BC000D16_A106EmployeeId = new long[1] ;
         BC000D17_A100CompanyId = new long[1] ;
         BC000D17_A101CompanyName = new string[] {""} ;
         BC000D17_A158CompanyLocationName = new string[] {""} ;
         BC000D17_A157CompanyLocationId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.company_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.company_bc__default(),
            new Object[][] {
                new Object[] {
               BC000D2_A100CompanyId, BC000D2_A101CompanyName, BC000D2_A157CompanyLocationId
               }
               , new Object[] {
               BC000D3_A100CompanyId, BC000D3_A101CompanyName, BC000D3_A157CompanyLocationId
               }
               , new Object[] {
               BC000D4_A158CompanyLocationName
               }
               , new Object[] {
               BC000D5_A100CompanyId, BC000D5_A101CompanyName, BC000D5_A158CompanyLocationName, BC000D5_A157CompanyLocationId
               }
               , new Object[] {
               BC000D6_A101CompanyName
               }
               , new Object[] {
               BC000D7_A100CompanyId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000D9_A100CompanyId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000D12_A158CompanyLocationName
               }
               , new Object[] {
               BC000D13_A160SiteSettingId
               }
               , new Object[] {
               BC000D14_A124LeaveTypeId
               }
               , new Object[] {
               BC000D15_A113HolidayId
               }
               , new Object[] {
               BC000D16_A106EmployeeId
               }
               , new Object[] {
               BC000D17_A100CompanyId, BC000D17_A101CompanyName, BC000D17_A158CompanyLocationName, BC000D17_A157CompanyLocationId
               }
            }
         );
         AV24Pgmname = "Company_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120D2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound14 ;
      private int trnEnded ;
      private int AV25GXV1 ;
      private long Z100CompanyId ;
      private long A100CompanyId ;
      private long AV23Insert_CompanyLocationId ;
      private long Z157CompanyLocationId ;
      private long A157CompanyLocationId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV24Pgmname ;
      private string Z101CompanyName ;
      private string A101CompanyName ;
      private string Z158CompanyLocationName ;
      private string A158CompanyLocationName ;
      private string sMode14 ;
      private bool returnInSub ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private long[] BC000D5_A100CompanyId ;
      private string[] BC000D5_A101CompanyName ;
      private string[] BC000D5_A158CompanyLocationName ;
      private long[] BC000D5_A157CompanyLocationId ;
      private string[] BC000D6_A101CompanyName ;
      private string[] BC000D4_A158CompanyLocationName ;
      private long[] BC000D7_A100CompanyId ;
      private long[] BC000D3_A100CompanyId ;
      private string[] BC000D3_A101CompanyName ;
      private long[] BC000D3_A157CompanyLocationId ;
      private long[] BC000D2_A100CompanyId ;
      private string[] BC000D2_A101CompanyName ;
      private long[] BC000D2_A157CompanyLocationId ;
      private long[] BC000D9_A100CompanyId ;
      private string[] BC000D12_A158CompanyLocationName ;
      private long[] BC000D13_A160SiteSettingId ;
      private long[] BC000D14_A124LeaveTypeId ;
      private long[] BC000D15_A113HolidayId ;
      private long[] BC000D16_A106EmployeeId ;
      private long[] BC000D17_A100CompanyId ;
      private string[] BC000D17_A101CompanyName ;
      private string[] BC000D17_A158CompanyLocationName ;
      private long[] BC000D17_A157CompanyLocationId ;
      private SdtCompany bcCompany ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class company_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class company_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000D2;
        prmBC000D2 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000D3;
        prmBC000D3 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000D4;
        prmBC000D4 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmBC000D5;
        prmBC000D5 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000D6;
        prmBC000D6 = new Object[] {
        new ParDef("CompanyName",GXType.Char,100,0) ,
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000D7;
        prmBC000D7 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000D8;
        prmBC000D8 = new Object[] {
        new ParDef("CompanyName",GXType.Char,100,0) ,
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmBC000D9;
        prmBC000D9 = new Object[] {
        };
        Object[] prmBC000D10;
        prmBC000D10 = new Object[] {
        new ParDef("CompanyName",GXType.Char,100,0) ,
        new ParDef("CompanyLocationId",GXType.Int64,10,0) ,
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000D11;
        prmBC000D11 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000D12;
        prmBC000D12 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmBC000D13;
        prmBC000D13 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000D14;
        prmBC000D14 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000D15;
        prmBC000D15 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000D16;
        prmBC000D16 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000D17;
        prmBC000D17 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000D2", "SELECT CompanyId, CompanyName, CompanyLocationId FROM Company WHERE CompanyId = :CompanyId  FOR UPDATE OF Company",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D3", "SELECT CompanyId, CompanyName, CompanyLocationId FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D4", "SELECT CompanyLocationName FROM CompanyLocation WHERE CompanyLocationId = :CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D5", "SELECT TM1.CompanyId, TM1.CompanyName, T2.CompanyLocationName, TM1.CompanyLocationId FROM (Company TM1 INNER JOIN CompanyLocation T2 ON T2.CompanyLocationId = TM1.CompanyLocationId) WHERE TM1.CompanyId = :CompanyId ORDER BY TM1.CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D6", "SELECT CompanyName FROM Company WHERE (CompanyName = :CompanyName) AND (Not ( CompanyId = :CompanyId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D7", "SELECT CompanyId FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D8", "SAVEPOINT gxupdate;INSERT INTO Company(CompanyName, CompanyLocationId) VALUES(:CompanyName, :CompanyLocationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000D8)
           ,new CursorDef("BC000D9", "SELECT currval('CompanyId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D10", "SAVEPOINT gxupdate;UPDATE Company SET CompanyName=:CompanyName, CompanyLocationId=:CompanyLocationId  WHERE CompanyId = :CompanyId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000D10)
           ,new CursorDef("BC000D11", "SAVEPOINT gxupdate;DELETE FROM Company  WHERE CompanyId = :CompanyId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000D11)
           ,new CursorDef("BC000D12", "SELECT CompanyLocationName FROM CompanyLocation WHERE CompanyLocationId = :CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D13", "SELECT SiteSettingId FROM SiteSetting WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000D14", "SELECT LeaveTypeId FROM LeaveType WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000D15", "SELECT HolidayId FROM Holiday WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000D16", "SELECT EmployeeId FROM Employee WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000D17", "SELECT TM1.CompanyId, TM1.CompanyName, T2.CompanyLocationName, TM1.CompanyLocationId FROM (Company TM1 INNER JOIN CompanyLocation T2 ON T2.CompanyLocationId = TM1.CompanyLocationId) WHERE TM1.CompanyId = :CompanyId ORDER BY TM1.CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D17,100, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
     }
  }

}

}
