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
   public class wwp_mailtemplate_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_mailtemplate_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_mailtemplate_bc( IGxContext context )
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
         ReadRow0A10( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0A10( ) ;
         standaloneModal( ) ;
         AddRow0A10( ) ;
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
            E110A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z88WWPMailTemplateName = A88WWPMailTemplateName;
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

      protected void CONFIRM_0A0( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0A10( ) ;
            }
            else
            {
               CheckExtendedTable0A10( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0A10( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120A2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E110A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0A10( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z89WWPMailTemplateDescription = A89WWPMailTemplateDescription;
            Z90WWPMailTemplateSubject = A90WWPMailTemplateSubject;
         }
         if ( GX_JID == -1 )
         {
            Z88WWPMailTemplateName = A88WWPMailTemplateName;
            Z89WWPMailTemplateDescription = A89WWPMailTemplateDescription;
            Z90WWPMailTemplateSubject = A90WWPMailTemplateSubject;
            Z73WWPMailTemplateBody = A73WWPMailTemplateBody;
            Z74WWPMailTemplateSenderAddress = A74WWPMailTemplateSenderAddress;
            Z75WWPMailTemplateSenderName = A75WWPMailTemplateSenderName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0A10( )
      {
         /* Using cursor BC000A4 */
         pr_default.execute(2, new Object[] {A88WWPMailTemplateName});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound10 = 1;
            A89WWPMailTemplateDescription = BC000A4_A89WWPMailTemplateDescription[0];
            A90WWPMailTemplateSubject = BC000A4_A90WWPMailTemplateSubject[0];
            A73WWPMailTemplateBody = BC000A4_A73WWPMailTemplateBody[0];
            A74WWPMailTemplateSenderAddress = BC000A4_A74WWPMailTemplateSenderAddress[0];
            A75WWPMailTemplateSenderName = BC000A4_A75WWPMailTemplateSenderName[0];
            ZM0A10( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0A10( ) ;
      }

      protected void OnLoadActions0A10( )
      {
      }

      protected void CheckExtendedTable0A10( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0A10( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0A10( )
      {
         /* Using cursor BC000A5 */
         pr_default.execute(3, new Object[] {A88WWPMailTemplateName});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000A3 */
         pr_default.execute(1, new Object[] {A88WWPMailTemplateName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A10( 1) ;
            RcdFound10 = 1;
            A88WWPMailTemplateName = BC000A3_A88WWPMailTemplateName[0];
            A89WWPMailTemplateDescription = BC000A3_A89WWPMailTemplateDescription[0];
            A90WWPMailTemplateSubject = BC000A3_A90WWPMailTemplateSubject[0];
            A73WWPMailTemplateBody = BC000A3_A73WWPMailTemplateBody[0];
            A74WWPMailTemplateSenderAddress = BC000A3_A74WWPMailTemplateSenderAddress[0];
            A75WWPMailTemplateSenderName = BC000A3_A75WWPMailTemplateSenderName[0];
            Z88WWPMailTemplateName = A88WWPMailTemplateName;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0A10( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0A10( ) ;
            }
            Gx_mode = sMode10;
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0A10( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode10;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A10( ) ;
         if ( RcdFound10 == 0 )
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
         CONFIRM_0A0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0A10( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000A2 */
            pr_default.execute(0, new Object[] {A88WWPMailTemplateName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailTemplate"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z89WWPMailTemplateDescription, BC000A2_A89WWPMailTemplateDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z90WWPMailTemplateSubject, BC000A2_A90WWPMailTemplateSubject[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_MailTemplate"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A10( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A10( 0) ;
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A6 */
                     pr_default.execute(4, new Object[] {A88WWPMailTemplateName, A89WWPMailTemplateDescription, A90WWPMailTemplateSubject, A73WWPMailTemplateBody, A74WWPMailTemplateSenderAddress, A75WWPMailTemplateSenderName});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
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
               Load0A10( ) ;
            }
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void Update0A10( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A7 */
                     pr_default.execute(5, new Object[] {A89WWPMailTemplateDescription, A90WWPMailTemplateSubject, A73WWPMailTemplateBody, A74WWPMailTemplateSenderAddress, A75WWPMailTemplateSenderName, A88WWPMailTemplateName});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailTemplate"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A10( ) ;
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
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void DeferredUpdate0A10( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A10( ) ;
            AfterConfirm0A10( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A10( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000A8 */
                  pr_default.execute(6, new Object[] {A88WWPMailTemplateName});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
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
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0A10( ) ;
         Gx_mode = sMode10;
      }

      protected void OnDeleteControls0A10( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0A10( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A10( ) ;
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

      public void ScanKeyStart0A10( )
      {
         /* Using cursor BC000A9 */
         pr_default.execute(7, new Object[] {A88WWPMailTemplateName});
         RcdFound10 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound10 = 1;
            A88WWPMailTemplateName = BC000A9_A88WWPMailTemplateName[0];
            A89WWPMailTemplateDescription = BC000A9_A89WWPMailTemplateDescription[0];
            A90WWPMailTemplateSubject = BC000A9_A90WWPMailTemplateSubject[0];
            A73WWPMailTemplateBody = BC000A9_A73WWPMailTemplateBody[0];
            A74WWPMailTemplateSenderAddress = BC000A9_A74WWPMailTemplateSenderAddress[0];
            A75WWPMailTemplateSenderName = BC000A9_A75WWPMailTemplateSenderName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0A10( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound10 = 0;
         ScanKeyLoad0A10( ) ;
      }

      protected void ScanKeyLoad0A10( )
      {
         sMode10 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound10 = 1;
            A88WWPMailTemplateName = BC000A9_A88WWPMailTemplateName[0];
            A89WWPMailTemplateDescription = BC000A9_A89WWPMailTemplateDescription[0];
            A90WWPMailTemplateSubject = BC000A9_A90WWPMailTemplateSubject[0];
            A73WWPMailTemplateBody = BC000A9_A73WWPMailTemplateBody[0];
            A74WWPMailTemplateSenderAddress = BC000A9_A74WWPMailTemplateSenderAddress[0];
            A75WWPMailTemplateSenderName = BC000A9_A75WWPMailTemplateSenderName[0];
         }
         Gx_mode = sMode10;
      }

      protected void ScanKeyEnd0A10( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0A10( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A10( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A10( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A10( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A10( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A10( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A10( )
      {
      }

      protected void send_integrity_lvl_hashes0A10( )
      {
      }

      protected void AddRow0A10( )
      {
         VarsToRow10( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
      }

      protected void ReadRow0A10( )
      {
         RowToVars10( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
      }

      protected void InitializeNonKey0A10( )
      {
         A89WWPMailTemplateDescription = "";
         A90WWPMailTemplateSubject = "";
         A73WWPMailTemplateBody = "";
         A74WWPMailTemplateSenderAddress = "";
         A75WWPMailTemplateSenderName = "";
         Z89WWPMailTemplateDescription = "";
         Z90WWPMailTemplateSubject = "";
      }

      protected void InitAll0A10( )
      {
         A88WWPMailTemplateName = "";
         InitializeNonKey0A10( ) ;
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

      public void VarsToRow10( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate obj10 )
      {
         obj10.gxTpr_Mode = Gx_mode;
         obj10.gxTpr_Wwpmailtemplatedescription = A89WWPMailTemplateDescription;
         obj10.gxTpr_Wwpmailtemplatesubject = A90WWPMailTemplateSubject;
         obj10.gxTpr_Wwpmailtemplatebody = A73WWPMailTemplateBody;
         obj10.gxTpr_Wwpmailtemplatesenderaddress = A74WWPMailTemplateSenderAddress;
         obj10.gxTpr_Wwpmailtemplatesendername = A75WWPMailTemplateSenderName;
         obj10.gxTpr_Wwpmailtemplatename = A88WWPMailTemplateName;
         obj10.gxTpr_Wwpmailtemplatename_Z = Z88WWPMailTemplateName;
         obj10.gxTpr_Wwpmailtemplatedescription_Z = Z89WWPMailTemplateDescription;
         obj10.gxTpr_Wwpmailtemplatesubject_Z = Z90WWPMailTemplateSubject;
         obj10.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow10( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate obj10 )
      {
         obj10.gxTpr_Wwpmailtemplatename = A88WWPMailTemplateName;
         return  ;
      }

      public void RowToVars10( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate obj10 ,
                               int forceLoad )
      {
         Gx_mode = obj10.gxTpr_Mode;
         A89WWPMailTemplateDescription = obj10.gxTpr_Wwpmailtemplatedescription;
         A90WWPMailTemplateSubject = obj10.gxTpr_Wwpmailtemplatesubject;
         A73WWPMailTemplateBody = obj10.gxTpr_Wwpmailtemplatebody;
         A74WWPMailTemplateSenderAddress = obj10.gxTpr_Wwpmailtemplatesenderaddress;
         A75WWPMailTemplateSenderName = obj10.gxTpr_Wwpmailtemplatesendername;
         A88WWPMailTemplateName = obj10.gxTpr_Wwpmailtemplatename;
         Z88WWPMailTemplateName = obj10.gxTpr_Wwpmailtemplatename_Z;
         Z89WWPMailTemplateDescription = obj10.gxTpr_Wwpmailtemplatedescription_Z;
         Z90WWPMailTemplateSubject = obj10.gxTpr_Wwpmailtemplatesubject_Z;
         Gx_mode = obj10.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A88WWPMailTemplateName = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0A10( ) ;
         ScanKeyStart0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z88WWPMailTemplateName = A88WWPMailTemplateName;
         }
         ZM0A10( -1) ;
         OnLoadActions0A10( ) ;
         AddRow0A10( ) ;
         ScanKeyEnd0A10( ) ;
         if ( RcdFound10 == 0 )
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
         RowToVars10( bcwwpbaseobjects_mail_WWP_MailTemplate, 0) ;
         ScanKeyStart0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z88WWPMailTemplateName = A88WWPMailTemplateName;
         }
         ZM0A10( -1) ;
         OnLoadActions0A10( ) ;
         AddRow0A10( ) ;
         ScanKeyEnd0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0A10( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0A10( ) ;
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( StringUtil.StrCmp(A88WWPMailTemplateName, Z88WWPMailTemplateName) != 0 )
               {
                  A88WWPMailTemplateName = Z88WWPMailTemplateName;
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
                  Update0A10( ) ;
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
                  if ( StringUtil.StrCmp(A88WWPMailTemplateName, Z88WWPMailTemplateName) != 0 )
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
                        Insert0A10( ) ;
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
                        Insert0A10( ) ;
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
         RowToVars10( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         SaveImpl( ) ;
         VarsToRow10( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars10( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A10( ) ;
         AfterTrn( ) ;
         VarsToRow10( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow10( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate auxBC = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A88WWPMailTemplateName);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_mail_WWP_MailTemplate);
               auxBC.Save();
               bcwwpbaseobjects_mail_WWP_MailTemplate.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars10( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
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
         RowToVars10( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A10( ) ;
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
               VarsToRow10( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow10( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
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
         RowToVars10( bcwwpbaseobjects_mail_WWP_MailTemplate, 0) ;
         GetKey0A10( ) ;
         if ( RcdFound10 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A88WWPMailTemplateName, Z88WWPMailTemplateName) != 0 )
            {
               A88WWPMailTemplateName = Z88WWPMailTemplateName;
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
            if ( StringUtil.StrCmp(A88WWPMailTemplateName, Z88WWPMailTemplateName) != 0 )
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
         context.RollbackDataStores("wwpbaseobjects.mail.wwp_mailtemplate_bc",pr_default);
         VarsToRow10( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
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
         Gx_mode = bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_mail_WWP_MailTemplate )
         {
            bcwwpbaseobjects_mail_WWP_MailTemplate = (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow10( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
            }
            else
            {
               RowToVars10( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars10( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_MailTemplate WWP_MailTemplate_BC
      {
         get {
            return bcwwpbaseobjects_mail_WWP_MailTemplate ;
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
            return "wwpmailtemplate_Execute" ;
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
         Z88WWPMailTemplateName = "";
         A88WWPMailTemplateName = "";
         Z89WWPMailTemplateDescription = "";
         A89WWPMailTemplateDescription = "";
         Z90WWPMailTemplateSubject = "";
         A90WWPMailTemplateSubject = "";
         Z73WWPMailTemplateBody = "";
         A73WWPMailTemplateBody = "";
         Z74WWPMailTemplateSenderAddress = "";
         A74WWPMailTemplateSenderAddress = "";
         Z75WWPMailTemplateSenderName = "";
         A75WWPMailTemplateSenderName = "";
         BC000A4_A88WWPMailTemplateName = new string[] {""} ;
         BC000A4_A89WWPMailTemplateDescription = new string[] {""} ;
         BC000A4_A90WWPMailTemplateSubject = new string[] {""} ;
         BC000A4_A73WWPMailTemplateBody = new string[] {""} ;
         BC000A4_A74WWPMailTemplateSenderAddress = new string[] {""} ;
         BC000A4_A75WWPMailTemplateSenderName = new string[] {""} ;
         BC000A5_A88WWPMailTemplateName = new string[] {""} ;
         BC000A3_A88WWPMailTemplateName = new string[] {""} ;
         BC000A3_A89WWPMailTemplateDescription = new string[] {""} ;
         BC000A3_A90WWPMailTemplateSubject = new string[] {""} ;
         BC000A3_A73WWPMailTemplateBody = new string[] {""} ;
         BC000A3_A74WWPMailTemplateSenderAddress = new string[] {""} ;
         BC000A3_A75WWPMailTemplateSenderName = new string[] {""} ;
         sMode10 = "";
         BC000A2_A88WWPMailTemplateName = new string[] {""} ;
         BC000A2_A89WWPMailTemplateDescription = new string[] {""} ;
         BC000A2_A90WWPMailTemplateSubject = new string[] {""} ;
         BC000A2_A73WWPMailTemplateBody = new string[] {""} ;
         BC000A2_A74WWPMailTemplateSenderAddress = new string[] {""} ;
         BC000A2_A75WWPMailTemplateSenderName = new string[] {""} ;
         BC000A9_A88WWPMailTemplateName = new string[] {""} ;
         BC000A9_A89WWPMailTemplateDescription = new string[] {""} ;
         BC000A9_A90WWPMailTemplateSubject = new string[] {""} ;
         BC000A9_A73WWPMailTemplateBody = new string[] {""} ;
         BC000A9_A74WWPMailTemplateSenderAddress = new string[] {""} ;
         BC000A9_A75WWPMailTemplateSenderName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate_bc__default(),
            new Object[][] {
                new Object[] {
               BC000A2_A88WWPMailTemplateName, BC000A2_A89WWPMailTemplateDescription, BC000A2_A90WWPMailTemplateSubject, BC000A2_A73WWPMailTemplateBody, BC000A2_A74WWPMailTemplateSenderAddress, BC000A2_A75WWPMailTemplateSenderName
               }
               , new Object[] {
               BC000A3_A88WWPMailTemplateName, BC000A3_A89WWPMailTemplateDescription, BC000A3_A90WWPMailTemplateSubject, BC000A3_A73WWPMailTemplateBody, BC000A3_A74WWPMailTemplateSenderAddress, BC000A3_A75WWPMailTemplateSenderName
               }
               , new Object[] {
               BC000A4_A88WWPMailTemplateName, BC000A4_A89WWPMailTemplateDescription, BC000A4_A90WWPMailTemplateSubject, BC000A4_A73WWPMailTemplateBody, BC000A4_A74WWPMailTemplateSenderAddress, BC000A4_A75WWPMailTemplateSenderName
               }
               , new Object[] {
               BC000A5_A88WWPMailTemplateName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000A9_A88WWPMailTemplateName, BC000A9_A89WWPMailTemplateDescription, BC000A9_A90WWPMailTemplateSubject, BC000A9_A73WWPMailTemplateBody, BC000A9_A74WWPMailTemplateSenderAddress, BC000A9_A75WWPMailTemplateSenderName
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120A2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound10 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode10 ;
      private bool returnInSub ;
      private string Z73WWPMailTemplateBody ;
      private string A73WWPMailTemplateBody ;
      private string Z74WWPMailTemplateSenderAddress ;
      private string A74WWPMailTemplateSenderAddress ;
      private string Z75WWPMailTemplateSenderName ;
      private string A75WWPMailTemplateSenderName ;
      private string Z88WWPMailTemplateName ;
      private string A88WWPMailTemplateName ;
      private string Z89WWPMailTemplateDescription ;
      private string A89WWPMailTemplateDescription ;
      private string Z90WWPMailTemplateSubject ;
      private string A90WWPMailTemplateSubject ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000A4_A88WWPMailTemplateName ;
      private string[] BC000A4_A89WWPMailTemplateDescription ;
      private string[] BC000A4_A90WWPMailTemplateSubject ;
      private string[] BC000A4_A73WWPMailTemplateBody ;
      private string[] BC000A4_A74WWPMailTemplateSenderAddress ;
      private string[] BC000A4_A75WWPMailTemplateSenderName ;
      private string[] BC000A5_A88WWPMailTemplateName ;
      private string[] BC000A3_A88WWPMailTemplateName ;
      private string[] BC000A3_A89WWPMailTemplateDescription ;
      private string[] BC000A3_A90WWPMailTemplateSubject ;
      private string[] BC000A3_A73WWPMailTemplateBody ;
      private string[] BC000A3_A74WWPMailTemplateSenderAddress ;
      private string[] BC000A3_A75WWPMailTemplateSenderName ;
      private string[] BC000A2_A88WWPMailTemplateName ;
      private string[] BC000A2_A89WWPMailTemplateDescription ;
      private string[] BC000A2_A90WWPMailTemplateSubject ;
      private string[] BC000A2_A73WWPMailTemplateBody ;
      private string[] BC000A2_A74WWPMailTemplateSenderAddress ;
      private string[] BC000A2_A75WWPMailTemplateSenderName ;
      private string[] BC000A9_A88WWPMailTemplateName ;
      private string[] BC000A9_A89WWPMailTemplateDescription ;
      private string[] BC000A9_A90WWPMailTemplateSubject ;
      private string[] BC000A9_A73WWPMailTemplateBody ;
      private string[] BC000A9_A74WWPMailTemplateSenderAddress ;
      private string[] BC000A9_A75WWPMailTemplateSenderName ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate bcwwpbaseobjects_mail_WWP_MailTemplate ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_mailtemplate_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_mailtemplate_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000A2;
        prmBC000A2 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmBC000A3;
        prmBC000A3 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmBC000A4;
        prmBC000A4 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmBC000A5;
        prmBC000A5 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmBC000A6;
        prmBC000A6 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0) ,
        new ParDef("WWPMailTemplateDescription",GXType.VarChar,100,0) ,
        new ParDef("WWPMailTemplateSubject",GXType.VarChar,80,0) ,
        new ParDef("WWPMailTemplateBody",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTemplateSenderAddress",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTemplateSenderName",GXType.LongVarChar,2097152,0)
        };
        Object[] prmBC000A7;
        prmBC000A7 = new Object[] {
        new ParDef("WWPMailTemplateDescription",GXType.VarChar,100,0) ,
        new ParDef("WWPMailTemplateSubject",GXType.VarChar,80,0) ,
        new ParDef("WWPMailTemplateBody",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTemplateSenderAddress",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTemplateSenderName",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmBC000A8;
        prmBC000A8 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmBC000A9;
        prmBC000A9 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000A2", "SELECT WWPMailTemplateName, WWPMailTemplateDescription, WWPMailTemplateSubject, WWPMailTemplateBody, WWPMailTemplateSenderAddress, WWPMailTemplateSenderName FROM WWP_MailTemplate WHERE WWPMailTemplateName = :WWPMailTemplateName  FOR UPDATE OF WWP_MailTemplate",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A3", "SELECT WWPMailTemplateName, WWPMailTemplateDescription, WWPMailTemplateSubject, WWPMailTemplateBody, WWPMailTemplateSenderAddress, WWPMailTemplateSenderName FROM WWP_MailTemplate WHERE WWPMailTemplateName = :WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A4", "SELECT TM1.WWPMailTemplateName, TM1.WWPMailTemplateDescription, TM1.WWPMailTemplateSubject, TM1.WWPMailTemplateBody, TM1.WWPMailTemplateSenderAddress, TM1.WWPMailTemplateSenderName FROM WWP_MailTemplate TM1 WHERE TM1.WWPMailTemplateName = ( :WWPMailTemplateName) ORDER BY TM1.WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A5", "SELECT WWPMailTemplateName FROM WWP_MailTemplate WHERE WWPMailTemplateName = :WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A6", "SAVEPOINT gxupdate;INSERT INTO WWP_MailTemplate(WWPMailTemplateName, WWPMailTemplateDescription, WWPMailTemplateSubject, WWPMailTemplateBody, WWPMailTemplateSenderAddress, WWPMailTemplateSenderName) VALUES(:WWPMailTemplateName, :WWPMailTemplateDescription, :WWPMailTemplateSubject, :WWPMailTemplateBody, :WWPMailTemplateSenderAddress, :WWPMailTemplateSenderName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000A6)
           ,new CursorDef("BC000A7", "SAVEPOINT gxupdate;UPDATE WWP_MailTemplate SET WWPMailTemplateDescription=:WWPMailTemplateDescription, WWPMailTemplateSubject=:WWPMailTemplateSubject, WWPMailTemplateBody=:WWPMailTemplateBody, WWPMailTemplateSenderAddress=:WWPMailTemplateSenderAddress, WWPMailTemplateSenderName=:WWPMailTemplateSenderName  WHERE WWPMailTemplateName = :WWPMailTemplateName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000A7)
           ,new CursorDef("BC000A8", "SAVEPOINT gxupdate;DELETE FROM WWP_MailTemplate  WHERE WWPMailTemplateName = :WWPMailTemplateName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000A8)
           ,new CursorDef("BC000A9", "SELECT TM1.WWPMailTemplateName, TM1.WWPMailTemplateDescription, TM1.WWPMailTemplateSubject, TM1.WWPMailTemplateBody, TM1.WWPMailTemplateSenderAddress, TM1.WWPMailTemplateSenderName FROM WWP_MailTemplate TM1 WHERE TM1.WWPMailTemplateName = ( :WWPMailTemplateName) ORDER BY TM1.WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A9,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              return;
     }
  }

}

}
