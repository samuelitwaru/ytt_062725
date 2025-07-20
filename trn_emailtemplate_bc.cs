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
   public class trn_emailtemplate_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_emailtemplate_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_emailtemplate_bc( IGxContext context )
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
         ReadRow0Q29( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0Q29( ) ;
         standaloneModal( ) ;
         AddRow0Q29( ) ;
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
               Z190EmailTemplateId = A190EmailTemplateId;
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

      protected void CONFIRM_0Q0( )
      {
         BeforeValidate0Q29( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Q29( ) ;
            }
            else
            {
               CheckExtendedTable0Q29( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0Q29( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0Q29( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z191EmailTemplateName = A191EmailTemplateName;
         }
         if ( GX_JID == -1 )
         {
            Z190EmailTemplateId = A190EmailTemplateId;
            Z191EmailTemplateName = A191EmailTemplateName;
            Z192EmailTemplateContent = A192EmailTemplateContent;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0Q29( )
      {
         /* Using cursor BC000Q4 */
         pr_default.execute(2, new Object[] {A190EmailTemplateId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound29 = 1;
            A191EmailTemplateName = BC000Q4_A191EmailTemplateName[0];
            A192EmailTemplateContent = BC000Q4_A192EmailTemplateContent[0];
            ZM0Q29( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0Q29( ) ;
      }

      protected void OnLoadActions0Q29( )
      {
      }

      protected void CheckExtendedTable0Q29( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0Q29( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0Q29( )
      {
         /* Using cursor BC000Q5 */
         pr_default.execute(3, new Object[] {A190EmailTemplateId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound29 = 1;
         }
         else
         {
            RcdFound29 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000Q3 */
         pr_default.execute(1, new Object[] {A190EmailTemplateId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Q29( 1) ;
            RcdFound29 = 1;
            A190EmailTemplateId = BC000Q3_A190EmailTemplateId[0];
            A191EmailTemplateName = BC000Q3_A191EmailTemplateName[0];
            A192EmailTemplateContent = BC000Q3_A192EmailTemplateContent[0];
            Z190EmailTemplateId = A190EmailTemplateId;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0Q29( ) ;
            if ( AnyError == 1 )
            {
               RcdFound29 = 0;
               InitializeNonKey0Q29( ) ;
            }
            Gx_mode = sMode29;
         }
         else
         {
            RcdFound29 = 0;
            InitializeNonKey0Q29( ) ;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode29;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Q29( ) ;
         if ( RcdFound29 == 0 )
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
         CONFIRM_0Q0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0Q29( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000Q2 */
            pr_default.execute(0, new Object[] {A190EmailTemplateId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_EmailTemplate"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z191EmailTemplateName, BC000Q2_A191EmailTemplateName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_EmailTemplate"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Q29( )
      {
         BeforeValidate0Q29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q29( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Q29( 0) ;
            CheckOptimisticConcurrency0Q29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Q29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Q6 */
                     pr_default.execute(4, new Object[] {A191EmailTemplateName, A192EmailTemplateContent});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000Q7 */
                     pr_default.execute(5);
                     A190EmailTemplateId = BC000Q7_A190EmailTemplateId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_EmailTemplate");
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
               Load0Q29( ) ;
            }
            EndLevel0Q29( ) ;
         }
         CloseExtendedTableCursors0Q29( ) ;
      }

      protected void Update0Q29( )
      {
         BeforeValidate0Q29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q29( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Q29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Q8 */
                     pr_default.execute(6, new Object[] {A191EmailTemplateName, A192EmailTemplateContent, A190EmailTemplateId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_EmailTemplate");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_EmailTemplate"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Q29( ) ;
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
            EndLevel0Q29( ) ;
         }
         CloseExtendedTableCursors0Q29( ) ;
      }

      protected void DeferredUpdate0Q29( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0Q29( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q29( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Q29( ) ;
            AfterConfirm0Q29( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Q29( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000Q9 */
                  pr_default.execute(7, new Object[] {A190EmailTemplateId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_EmailTemplate");
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
         sMode29 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0Q29( ) ;
         Gx_mode = sMode29;
      }

      protected void OnDeleteControls0Q29( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0Q29( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Q29( ) ;
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

      public void ScanKeyStart0Q29( )
      {
         /* Using cursor BC000Q10 */
         pr_default.execute(8, new Object[] {A190EmailTemplateId});
         RcdFound29 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound29 = 1;
            A190EmailTemplateId = BC000Q10_A190EmailTemplateId[0];
            A191EmailTemplateName = BC000Q10_A191EmailTemplateName[0];
            A192EmailTemplateContent = BC000Q10_A192EmailTemplateContent[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0Q29( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound29 = 0;
         ScanKeyLoad0Q29( ) ;
      }

      protected void ScanKeyLoad0Q29( )
      {
         sMode29 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound29 = 1;
            A190EmailTemplateId = BC000Q10_A190EmailTemplateId[0];
            A191EmailTemplateName = BC000Q10_A191EmailTemplateName[0];
            A192EmailTemplateContent = BC000Q10_A192EmailTemplateContent[0];
         }
         Gx_mode = sMode29;
      }

      protected void ScanKeyEnd0Q29( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0Q29( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Q29( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Q29( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Q29( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Q29( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Q29( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Q29( )
      {
      }

      protected void send_integrity_lvl_hashes0Q29( )
      {
      }

      protected void AddRow0Q29( )
      {
         VarsToRow29( bcTrn_EmailTemplate) ;
      }

      protected void ReadRow0Q29( )
      {
         RowToVars29( bcTrn_EmailTemplate, 1) ;
      }

      protected void InitializeNonKey0Q29( )
      {
         A191EmailTemplateName = "";
         A192EmailTemplateContent = "";
         Z191EmailTemplateName = "";
      }

      protected void InitAll0Q29( )
      {
         A190EmailTemplateId = 0;
         InitializeNonKey0Q29( ) ;
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

      public void VarsToRow29( SdtTrn_EmailTemplate obj29 )
      {
         obj29.gxTpr_Mode = Gx_mode;
         obj29.gxTpr_Emailtemplatename = A191EmailTemplateName;
         obj29.gxTpr_Emailtemplatecontent = A192EmailTemplateContent;
         obj29.gxTpr_Emailtemplateid = A190EmailTemplateId;
         obj29.gxTpr_Emailtemplateid_Z = Z190EmailTemplateId;
         obj29.gxTpr_Emailtemplatename_Z = Z191EmailTemplateName;
         obj29.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow29( SdtTrn_EmailTemplate obj29 )
      {
         obj29.gxTpr_Emailtemplateid = A190EmailTemplateId;
         return  ;
      }

      public void RowToVars29( SdtTrn_EmailTemplate obj29 ,
                               int forceLoad )
      {
         Gx_mode = obj29.gxTpr_Mode;
         A191EmailTemplateName = obj29.gxTpr_Emailtemplatename;
         A192EmailTemplateContent = obj29.gxTpr_Emailtemplatecontent;
         A190EmailTemplateId = obj29.gxTpr_Emailtemplateid;
         Z190EmailTemplateId = obj29.gxTpr_Emailtemplateid_Z;
         Z191EmailTemplateName = obj29.gxTpr_Emailtemplatename_Z;
         Gx_mode = obj29.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A190EmailTemplateId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0Q29( ) ;
         ScanKeyStart0Q29( ) ;
         if ( RcdFound29 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z190EmailTemplateId = A190EmailTemplateId;
         }
         ZM0Q29( -1) ;
         OnLoadActions0Q29( ) ;
         AddRow0Q29( ) ;
         ScanKeyEnd0Q29( ) ;
         if ( RcdFound29 == 0 )
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
         RowToVars29( bcTrn_EmailTemplate, 0) ;
         ScanKeyStart0Q29( ) ;
         if ( RcdFound29 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z190EmailTemplateId = A190EmailTemplateId;
         }
         ZM0Q29( -1) ;
         OnLoadActions0Q29( ) ;
         AddRow0Q29( ) ;
         ScanKeyEnd0Q29( ) ;
         if ( RcdFound29 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0Q29( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0Q29( ) ;
         }
         else
         {
            if ( RcdFound29 == 1 )
            {
               if ( A190EmailTemplateId != Z190EmailTemplateId )
               {
                  A190EmailTemplateId = Z190EmailTemplateId;
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
                  Update0Q29( ) ;
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
                  if ( A190EmailTemplateId != Z190EmailTemplateId )
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
                        Insert0Q29( ) ;
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
                        Insert0Q29( ) ;
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
         RowToVars29( bcTrn_EmailTemplate, 1) ;
         SaveImpl( ) ;
         VarsToRow29( bcTrn_EmailTemplate) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars29( bcTrn_EmailTemplate, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Q29( ) ;
         AfterTrn( ) ;
         VarsToRow29( bcTrn_EmailTemplate) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow29( bcTrn_EmailTemplate) ;
         }
         else
         {
            SdtTrn_EmailTemplate auxBC = new SdtTrn_EmailTemplate(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A190EmailTemplateId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_EmailTemplate);
               auxBC.Save();
               bcTrn_EmailTemplate.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars29( bcTrn_EmailTemplate, 1) ;
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
         RowToVars29( bcTrn_EmailTemplate, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Q29( ) ;
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
               VarsToRow29( bcTrn_EmailTemplate) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow29( bcTrn_EmailTemplate) ;
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
         RowToVars29( bcTrn_EmailTemplate, 0) ;
         GetKey0Q29( ) ;
         if ( RcdFound29 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A190EmailTemplateId != Z190EmailTemplateId )
            {
               A190EmailTemplateId = Z190EmailTemplateId;
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
            if ( A190EmailTemplateId != Z190EmailTemplateId )
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
         context.RollbackDataStores("trn_emailtemplate_bc",pr_default);
         VarsToRow29( bcTrn_EmailTemplate) ;
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
         Gx_mode = bcTrn_EmailTemplate.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_EmailTemplate.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_EmailTemplate )
         {
            bcTrn_EmailTemplate = (SdtTrn_EmailTemplate)(sdt);
            if ( StringUtil.StrCmp(bcTrn_EmailTemplate.gxTpr_Mode, "") == 0 )
            {
               bcTrn_EmailTemplate.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow29( bcTrn_EmailTemplate) ;
            }
            else
            {
               RowToVars29( bcTrn_EmailTemplate, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_EmailTemplate.gxTpr_Mode, "") == 0 )
            {
               bcTrn_EmailTemplate.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars29( bcTrn_EmailTemplate, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_EmailTemplate Trn_EmailTemplate_BC
      {
         get {
            return bcTrn_EmailTemplate ;
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
            return "trn_emailtemplate_Execute" ;
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
         Z191EmailTemplateName = "";
         A191EmailTemplateName = "";
         Z192EmailTemplateContent = "";
         A192EmailTemplateContent = "";
         BC000Q4_A190EmailTemplateId = new long[1] ;
         BC000Q4_A191EmailTemplateName = new string[] {""} ;
         BC000Q4_A192EmailTemplateContent = new string[] {""} ;
         BC000Q5_A190EmailTemplateId = new long[1] ;
         BC000Q3_A190EmailTemplateId = new long[1] ;
         BC000Q3_A191EmailTemplateName = new string[] {""} ;
         BC000Q3_A192EmailTemplateContent = new string[] {""} ;
         sMode29 = "";
         BC000Q2_A190EmailTemplateId = new long[1] ;
         BC000Q2_A191EmailTemplateName = new string[] {""} ;
         BC000Q2_A192EmailTemplateContent = new string[] {""} ;
         BC000Q7_A190EmailTemplateId = new long[1] ;
         BC000Q10_A190EmailTemplateId = new long[1] ;
         BC000Q10_A191EmailTemplateName = new string[] {""} ;
         BC000Q10_A192EmailTemplateContent = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_emailtemplate_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_emailtemplate_bc__default(),
            new Object[][] {
                new Object[] {
               BC000Q2_A190EmailTemplateId, BC000Q2_A191EmailTemplateName, BC000Q2_A192EmailTemplateContent
               }
               , new Object[] {
               BC000Q3_A190EmailTemplateId, BC000Q3_A191EmailTemplateName, BC000Q3_A192EmailTemplateContent
               }
               , new Object[] {
               BC000Q4_A190EmailTemplateId, BC000Q4_A191EmailTemplateName, BC000Q4_A192EmailTemplateContent
               }
               , new Object[] {
               BC000Q5_A190EmailTemplateId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Q7_A190EmailTemplateId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Q10_A190EmailTemplateId, BC000Q10_A191EmailTemplateName, BC000Q10_A192EmailTemplateContent
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound29 ;
      private int trnEnded ;
      private long Z190EmailTemplateId ;
      private long A190EmailTemplateId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z191EmailTemplateName ;
      private string A191EmailTemplateName ;
      private string sMode29 ;
      private string Z192EmailTemplateContent ;
      private string A192EmailTemplateContent ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC000Q4_A190EmailTemplateId ;
      private string[] BC000Q4_A191EmailTemplateName ;
      private string[] BC000Q4_A192EmailTemplateContent ;
      private long[] BC000Q5_A190EmailTemplateId ;
      private long[] BC000Q3_A190EmailTemplateId ;
      private string[] BC000Q3_A191EmailTemplateName ;
      private string[] BC000Q3_A192EmailTemplateContent ;
      private long[] BC000Q2_A190EmailTemplateId ;
      private string[] BC000Q2_A191EmailTemplateName ;
      private string[] BC000Q2_A192EmailTemplateContent ;
      private long[] BC000Q7_A190EmailTemplateId ;
      private long[] BC000Q10_A190EmailTemplateId ;
      private string[] BC000Q10_A191EmailTemplateName ;
      private string[] BC000Q10_A192EmailTemplateContent ;
      private SdtTrn_EmailTemplate bcTrn_EmailTemplate ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_emailtemplate_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_emailtemplate_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000Q2;
        prmBC000Q2 = new Object[] {
        new ParDef("EmailTemplateId",GXType.Int64,10,0)
        };
        Object[] prmBC000Q3;
        prmBC000Q3 = new Object[] {
        new ParDef("EmailTemplateId",GXType.Int64,10,0)
        };
        Object[] prmBC000Q4;
        prmBC000Q4 = new Object[] {
        new ParDef("EmailTemplateId",GXType.Int64,10,0)
        };
        Object[] prmBC000Q5;
        prmBC000Q5 = new Object[] {
        new ParDef("EmailTemplateId",GXType.Int64,10,0)
        };
        Object[] prmBC000Q6;
        prmBC000Q6 = new Object[] {
        new ParDef("EmailTemplateName",GXType.Char,100,0) ,
        new ParDef("EmailTemplateContent",GXType.LongVarChar,2097152,0)
        };
        Object[] prmBC000Q7;
        prmBC000Q7 = new Object[] {
        };
        Object[] prmBC000Q8;
        prmBC000Q8 = new Object[] {
        new ParDef("EmailTemplateName",GXType.Char,100,0) ,
        new ParDef("EmailTemplateContent",GXType.LongVarChar,2097152,0) ,
        new ParDef("EmailTemplateId",GXType.Int64,10,0)
        };
        Object[] prmBC000Q9;
        prmBC000Q9 = new Object[] {
        new ParDef("EmailTemplateId",GXType.Int64,10,0)
        };
        Object[] prmBC000Q10;
        prmBC000Q10 = new Object[] {
        new ParDef("EmailTemplateId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000Q2", "SELECT EmailTemplateId, EmailTemplateName, EmailTemplateContent FROM Trn_EmailTemplate WHERE EmailTemplateId = :EmailTemplateId  FOR UPDATE OF Trn_EmailTemplate",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Q3", "SELECT EmailTemplateId, EmailTemplateName, EmailTemplateContent FROM Trn_EmailTemplate WHERE EmailTemplateId = :EmailTemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Q4", "SELECT TM1.EmailTemplateId, TM1.EmailTemplateName, TM1.EmailTemplateContent FROM Trn_EmailTemplate TM1 WHERE TM1.EmailTemplateId = :EmailTemplateId ORDER BY TM1.EmailTemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Q5", "SELECT EmailTemplateId FROM Trn_EmailTemplate WHERE EmailTemplateId = :EmailTemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Q6", "SAVEPOINT gxupdate;INSERT INTO Trn_EmailTemplate(EmailTemplateName, EmailTemplateContent) VALUES(:EmailTemplateName, :EmailTemplateContent);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000Q6)
           ,new CursorDef("BC000Q7", "SELECT currval('EmailTemplateId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Q8", "SAVEPOINT gxupdate;UPDATE Trn_EmailTemplate SET EmailTemplateName=:EmailTemplateName, EmailTemplateContent=:EmailTemplateContent  WHERE EmailTemplateId = :EmailTemplateId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Q8)
           ,new CursorDef("BC000Q9", "SAVEPOINT gxupdate;DELETE FROM Trn_EmailTemplate  WHERE EmailTemplateId = :EmailTemplateId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Q9)
           ,new CursorDef("BC000Q10", "SELECT TM1.EmailTemplateId, TM1.EmailTemplateName, TM1.EmailTemplateContent FROM Trn_EmailTemplate TM1 WHERE TM1.EmailTemplateId = :EmailTemplateId ORDER BY TM1.EmailTemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q10,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
     }
  }

}

}
