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
namespace GeneXus.Programs.workwithplus {
   public class wwp_parameter_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_parameter_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_parameter_bc( IGxContext context )
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
         ReadRow022( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey022( ) ;
         standaloneModal( ) ;
         AddRow022( ) ;
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
            E11022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1WWPParameterKey = A1WWPParameterKey;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12022( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11022( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z3WWPParameterCategory = A3WWPParameterCategory;
            Z4WWPParameterDescription = A4WWPParameterDescription;
            Z5WWPParameterDisableDelete = A5WWPParameterDisableDelete;
            Z6WWPParameterValueTrimmed = A6WWPParameterValueTrimmed;
         }
         if ( GX_JID == -3 )
         {
            Z1WWPParameterKey = A1WWPParameterKey;
            Z3WWPParameterCategory = A3WWPParameterCategory;
            Z4WWPParameterDescription = A4WWPParameterDescription;
            Z2WWPParameterValue = A2WWPParameterValue;
            Z5WWPParameterDisableDelete = A5WWPParameterDisableDelete;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load022( )
      {
         /* Using cursor BC00024 */
         pr_default.execute(2, new Object[] {A1WWPParameterKey});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound2 = 1;
            A3WWPParameterCategory = BC00024_A3WWPParameterCategory[0];
            A4WWPParameterDescription = BC00024_A4WWPParameterDescription[0];
            A2WWPParameterValue = BC00024_A2WWPParameterValue[0];
            A5WWPParameterDisableDelete = BC00024_A5WWPParameterDisableDelete[0];
            ZM022( -3) ;
         }
         pr_default.close(2);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         if ( StringUtil.Len( A2WWPParameterValue) <= 30 )
         {
            A6WWPParameterValueTrimmed = A2WWPParameterValue;
         }
         else
         {
            A6WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A2WWPParameterValue, 1, 27)) + "...";
         }
      }

      protected void CheckExtendedTable022( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPParameterKey)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Parameter Key", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A2WWPParameterValue) <= 30 )
         {
            A6WWPParameterValueTrimmed = A2WWPParameterValue;
         }
         else
         {
            A6WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A2WWPParameterValue, 1, 27)) + "...";
         }
      }

      protected void CloseExtendedTableCursors022( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey022( )
      {
         /* Using cursor BC00025 */
         pr_default.execute(3, new Object[] {A1WWPParameterKey});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00023 */
         pr_default.execute(1, new Object[] {A1WWPParameterKey});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 3) ;
            RcdFound2 = 1;
            A1WWPParameterKey = BC00023_A1WWPParameterKey[0];
            A3WWPParameterCategory = BC00023_A3WWPParameterCategory[0];
            A4WWPParameterDescription = BC00023_A4WWPParameterDescription[0];
            A2WWPParameterValue = BC00023_A2WWPParameterValue[0];
            A5WWPParameterDisableDelete = BC00023_A5WWPParameterDisableDelete[0];
            Z1WWPParameterKey = A1WWPParameterKey;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode2;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
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
         CONFIRM_020( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00022 */
            pr_default.execute(0, new Object[] {A1WWPParameterKey});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Parameter"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z3WWPParameterCategory, BC00022_A3WWPParameterCategory[0]) != 0 ) || ( StringUtil.StrCmp(Z4WWPParameterDescription, BC00022_A4WWPParameterDescription[0]) != 0 ) || ( Z5WWPParameterDisableDelete != BC00022_A5WWPParameterDisableDelete[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Parameter"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00026 */
                     pr_default.execute(4, new Object[] {A1WWPParameterKey, A3WWPParameterCategory, A4WWPParameterDescription, A2WWPParameterValue, A5WWPParameterDisableDelete});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Parameter");
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00027 */
                     pr_default.execute(5, new Object[] {A3WWPParameterCategory, A4WWPParameterDescription, A2WWPParameterValue, A5WWPParameterDisableDelete, A1WWPParameterKey});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Parameter");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Parameter"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00028 */
                  pr_default.execute(6, new Object[] {A1WWPParameterKey});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Parameter");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel022( ) ;
         Gx_mode = sMode2;
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( StringUtil.Len( A2WWPParameterValue) <= 30 )
            {
               A6WWPParameterValueTrimmed = A2WWPParameterValue;
            }
            else
            {
               A6WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A2WWPParameterValue, 1, 27)) + "...";
            }
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
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

      public void ScanKeyStart022( )
      {
         /* Scan By routine */
         /* Using cursor BC00029 */
         pr_default.execute(7, new Object[] {A1WWPParameterKey});
         RcdFound2 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound2 = 1;
            A1WWPParameterKey = BC00029_A1WWPParameterKey[0];
            A3WWPParameterCategory = BC00029_A3WWPParameterCategory[0];
            A4WWPParameterDescription = BC00029_A4WWPParameterDescription[0];
            A2WWPParameterValue = BC00029_A2WWPParameterValue[0];
            A5WWPParameterDisableDelete = BC00029_A5WWPParameterDisableDelete[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound2 = 0;
         ScanKeyLoad022( ) ;
      }

      protected void ScanKeyLoad022( )
      {
         sMode2 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound2 = 1;
            A1WWPParameterKey = BC00029_A1WWPParameterKey[0];
            A3WWPParameterCategory = BC00029_A3WWPParameterCategory[0];
            A4WWPParameterDescription = BC00029_A4WWPParameterDescription[0];
            A2WWPParameterValue = BC00029_A2WWPParameterValue[0];
            A5WWPParameterDisableDelete = BC00029_A5WWPParameterDisableDelete[0];
         }
         Gx_mode = sMode2;
      }

      protected void ScanKeyEnd022( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void AddRow022( )
      {
         VarsToRow2( bcworkwithplus_WWP_Parameter) ;
      }

      protected void ReadRow022( )
      {
         RowToVars2( bcworkwithplus_WWP_Parameter, 1) ;
      }

      protected void InitializeNonKey022( )
      {
         A6WWPParameterValueTrimmed = "";
         A3WWPParameterCategory = "";
         A4WWPParameterDescription = "";
         A2WWPParameterValue = "";
         A5WWPParameterDisableDelete = false;
         Z3WWPParameterCategory = "";
         Z4WWPParameterDescription = "";
         Z5WWPParameterDisableDelete = false;
      }

      protected void InitAll022( )
      {
         A1WWPParameterKey = "";
         InitializeNonKey022( ) ;
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

      public void VarsToRow2( GeneXus.Programs.workwithplus.SdtWWP_Parameter obj2 )
      {
         obj2.gxTpr_Mode = Gx_mode;
         obj2.gxTpr_Wwpparametervaluetrimmed = A6WWPParameterValueTrimmed;
         obj2.gxTpr_Wwpparametercategory = A3WWPParameterCategory;
         obj2.gxTpr_Wwpparameterdescription = A4WWPParameterDescription;
         obj2.gxTpr_Wwpparametervalue = A2WWPParameterValue;
         obj2.gxTpr_Wwpparameterdisabledelete = A5WWPParameterDisableDelete;
         obj2.gxTpr_Wwpparameterkey = A1WWPParameterKey;
         obj2.gxTpr_Wwpparameterkey_Z = Z1WWPParameterKey;
         obj2.gxTpr_Wwpparametercategory_Z = Z3WWPParameterCategory;
         obj2.gxTpr_Wwpparameterdescription_Z = Z4WWPParameterDescription;
         obj2.gxTpr_Wwpparametervaluetrimmed_Z = Z6WWPParameterValueTrimmed;
         obj2.gxTpr_Wwpparameterdisabledelete_Z = Z5WWPParameterDisableDelete;
         obj2.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow2( GeneXus.Programs.workwithplus.SdtWWP_Parameter obj2 )
      {
         obj2.gxTpr_Wwpparameterkey = A1WWPParameterKey;
         return  ;
      }

      public void RowToVars2( GeneXus.Programs.workwithplus.SdtWWP_Parameter obj2 ,
                              int forceLoad )
      {
         Gx_mode = obj2.gxTpr_Mode;
         A6WWPParameterValueTrimmed = obj2.gxTpr_Wwpparametervaluetrimmed;
         A3WWPParameterCategory = obj2.gxTpr_Wwpparametercategory;
         A4WWPParameterDescription = obj2.gxTpr_Wwpparameterdescription;
         A2WWPParameterValue = obj2.gxTpr_Wwpparametervalue;
         A5WWPParameterDisableDelete = obj2.gxTpr_Wwpparameterdisabledelete;
         A1WWPParameterKey = obj2.gxTpr_Wwpparameterkey;
         Z1WWPParameterKey = obj2.gxTpr_Wwpparameterkey_Z;
         Z3WWPParameterCategory = obj2.gxTpr_Wwpparametercategory_Z;
         Z4WWPParameterDescription = obj2.gxTpr_Wwpparameterdescription_Z;
         Z6WWPParameterValueTrimmed = obj2.gxTpr_Wwpparametervaluetrimmed_Z;
         Z5WWPParameterDisableDelete = obj2.gxTpr_Wwpparameterdisabledelete_Z;
         Gx_mode = obj2.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1WWPParameterKey = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey022( ) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1WWPParameterKey = A1WWPParameterKey;
         }
         ZM022( -3) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
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
         RowToVars2( bcworkwithplus_WWP_Parameter, 0) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1WWPParameterKey = A1WWPParameterKey;
         }
         ZM022( -3) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert022( ) ;
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( StringUtil.StrCmp(A1WWPParameterKey, Z1WWPParameterKey) != 0 )
               {
                  A1WWPParameterKey = Z1WWPParameterKey;
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
                  Update022( ) ;
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
                  if ( StringUtil.StrCmp(A1WWPParameterKey, Z1WWPParameterKey) != 0 )
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
                        Insert022( ) ;
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
                        Insert022( ) ;
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
         RowToVars2( bcworkwithplus_WWP_Parameter, 1) ;
         SaveImpl( ) ;
         VarsToRow2( bcworkwithplus_WWP_Parameter) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars2( bcworkwithplus_WWP_Parameter, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
         AfterTrn( ) ;
         VarsToRow2( bcworkwithplus_WWP_Parameter) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow2( bcworkwithplus_WWP_Parameter) ;
         }
         else
         {
            GeneXus.Programs.workwithplus.SdtWWP_Parameter auxBC = new GeneXus.Programs.workwithplus.SdtWWP_Parameter(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1WWPParameterKey);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcworkwithplus_WWP_Parameter);
               auxBC.Save();
               bcworkwithplus_WWP_Parameter.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars2( bcworkwithplus_WWP_Parameter, 1) ;
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
         RowToVars2( bcworkwithplus_WWP_Parameter, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
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
               VarsToRow2( bcworkwithplus_WWP_Parameter) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow2( bcworkwithplus_WWP_Parameter) ;
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
         RowToVars2( bcworkwithplus_WWP_Parameter, 0) ;
         GetKey022( ) ;
         if ( RcdFound2 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A1WWPParameterKey, Z1WWPParameterKey) != 0 )
            {
               A1WWPParameterKey = Z1WWPParameterKey;
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
            if ( StringUtil.StrCmp(A1WWPParameterKey, Z1WWPParameterKey) != 0 )
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
         context.RollbackDataStores("workwithplus.wwp_parameter_bc",pr_default);
         VarsToRow2( bcworkwithplus_WWP_Parameter) ;
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
         Gx_mode = bcworkwithplus_WWP_Parameter.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcworkwithplus_WWP_Parameter.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcworkwithplus_WWP_Parameter )
         {
            bcworkwithplus_WWP_Parameter = (GeneXus.Programs.workwithplus.SdtWWP_Parameter)(sdt);
            if ( StringUtil.StrCmp(bcworkwithplus_WWP_Parameter.gxTpr_Mode, "") == 0 )
            {
               bcworkwithplus_WWP_Parameter.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow2( bcworkwithplus_WWP_Parameter) ;
            }
            else
            {
               RowToVars2( bcworkwithplus_WWP_Parameter, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcworkwithplus_WWP_Parameter.gxTpr_Mode, "") == 0 )
            {
               bcworkwithplus_WWP_Parameter.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars2( bcworkwithplus_WWP_Parameter, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_Parameter WWP_Parameter_BC
      {
         get {
            return bcworkwithplus_WWP_Parameter ;
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
            return "wwp_parameter_Execute" ;
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
         Z1WWPParameterKey = "";
         A1WWPParameterKey = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z3WWPParameterCategory = "";
         A3WWPParameterCategory = "";
         Z4WWPParameterDescription = "";
         A4WWPParameterDescription = "";
         Z6WWPParameterValueTrimmed = "";
         A6WWPParameterValueTrimmed = "";
         Z2WWPParameterValue = "";
         A2WWPParameterValue = "";
         BC00024_A1WWPParameterKey = new string[] {""} ;
         BC00024_A3WWPParameterCategory = new string[] {""} ;
         BC00024_A4WWPParameterDescription = new string[] {""} ;
         BC00024_A2WWPParameterValue = new string[] {""} ;
         BC00024_A5WWPParameterDisableDelete = new bool[] {false} ;
         BC00025_A1WWPParameterKey = new string[] {""} ;
         BC00023_A1WWPParameterKey = new string[] {""} ;
         BC00023_A3WWPParameterCategory = new string[] {""} ;
         BC00023_A4WWPParameterDescription = new string[] {""} ;
         BC00023_A2WWPParameterValue = new string[] {""} ;
         BC00023_A5WWPParameterDisableDelete = new bool[] {false} ;
         sMode2 = "";
         BC00022_A1WWPParameterKey = new string[] {""} ;
         BC00022_A3WWPParameterCategory = new string[] {""} ;
         BC00022_A4WWPParameterDescription = new string[] {""} ;
         BC00022_A2WWPParameterValue = new string[] {""} ;
         BC00022_A5WWPParameterDisableDelete = new bool[] {false} ;
         BC00029_A1WWPParameterKey = new string[] {""} ;
         BC00029_A3WWPParameterCategory = new string[] {""} ;
         BC00029_A4WWPParameterDescription = new string[] {""} ;
         BC00029_A2WWPParameterValue = new string[] {""} ;
         BC00029_A5WWPParameterDisableDelete = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_parameter_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_parameter_bc__default(),
            new Object[][] {
                new Object[] {
               BC00022_A1WWPParameterKey, BC00022_A3WWPParameterCategory, BC00022_A4WWPParameterDescription, BC00022_A2WWPParameterValue, BC00022_A5WWPParameterDisableDelete
               }
               , new Object[] {
               BC00023_A1WWPParameterKey, BC00023_A3WWPParameterCategory, BC00023_A4WWPParameterDescription, BC00023_A2WWPParameterValue, BC00023_A5WWPParameterDisableDelete
               }
               , new Object[] {
               BC00024_A1WWPParameterKey, BC00024_A3WWPParameterCategory, BC00024_A4WWPParameterDescription, BC00024_A2WWPParameterValue, BC00024_A5WWPParameterDisableDelete
               }
               , new Object[] {
               BC00025_A1WWPParameterKey
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00029_A1WWPParameterKey, BC00029_A3WWPParameterCategory, BC00029_A4WWPParameterDescription, BC00029_A2WWPParameterValue, BC00029_A5WWPParameterDisableDelete
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12022 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound2 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode2 ;
      private bool returnInSub ;
      private bool Z5WWPParameterDisableDelete ;
      private bool A5WWPParameterDisableDelete ;
      private string Z2WWPParameterValue ;
      private string A2WWPParameterValue ;
      private string Z1WWPParameterKey ;
      private string A1WWPParameterKey ;
      private string Z3WWPParameterCategory ;
      private string A3WWPParameterCategory ;
      private string Z4WWPParameterDescription ;
      private string A4WWPParameterDescription ;
      private string Z6WWPParameterValueTrimmed ;
      private string A6WWPParameterValueTrimmed ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private string[] BC00024_A1WWPParameterKey ;
      private string[] BC00024_A3WWPParameterCategory ;
      private string[] BC00024_A4WWPParameterDescription ;
      private string[] BC00024_A2WWPParameterValue ;
      private bool[] BC00024_A5WWPParameterDisableDelete ;
      private string[] BC00025_A1WWPParameterKey ;
      private string[] BC00023_A1WWPParameterKey ;
      private string[] BC00023_A3WWPParameterCategory ;
      private string[] BC00023_A4WWPParameterDescription ;
      private string[] BC00023_A2WWPParameterValue ;
      private bool[] BC00023_A5WWPParameterDisableDelete ;
      private string[] BC00022_A1WWPParameterKey ;
      private string[] BC00022_A3WWPParameterCategory ;
      private string[] BC00022_A4WWPParameterDescription ;
      private string[] BC00022_A2WWPParameterValue ;
      private bool[] BC00022_A5WWPParameterDisableDelete ;
      private string[] BC00029_A1WWPParameterKey ;
      private string[] BC00029_A3WWPParameterCategory ;
      private string[] BC00029_A4WWPParameterDescription ;
      private string[] BC00029_A2WWPParameterValue ;
      private bool[] BC00029_A5WWPParameterDisableDelete ;
      private GeneXus.Programs.workwithplus.SdtWWP_Parameter bcworkwithplus_WWP_Parameter ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_parameter_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_parameter_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00022;
        prmBC00022 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmBC00023;
        prmBC00023 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmBC00024;
        prmBC00024 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmBC00025;
        prmBC00025 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmBC00026;
        prmBC00026 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0) ,
        new ParDef("WWPParameterCategory",GXType.VarChar,200,0) ,
        new ParDef("WWPParameterDescription",GXType.VarChar,200,0) ,
        new ParDef("WWPParameterValue",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPParameterDisableDelete",GXType.Boolean,4,0)
        };
        Object[] prmBC00027;
        prmBC00027 = new Object[] {
        new ParDef("WWPParameterCategory",GXType.VarChar,200,0) ,
        new ParDef("WWPParameterDescription",GXType.VarChar,200,0) ,
        new ParDef("WWPParameterValue",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPParameterDisableDelete",GXType.Boolean,4,0) ,
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmBC00028;
        prmBC00028 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        Object[] prmBC00029;
        prmBC00029 = new Object[] {
        new ParDef("WWPParameterKey",GXType.VarChar,300,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00022", "SELECT WWPParameterKey, WWPParameterCategory, WWPParameterDescription, WWPParameterValue, WWPParameterDisableDelete FROM WWP_Parameter WHERE WWPParameterKey = :WWPParameterKey  FOR UPDATE OF WWP_Parameter",true, GxErrorMask.GX_NOMASK, false, this,prmBC00022,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00023", "SELECT WWPParameterKey, WWPParameterCategory, WWPParameterDescription, WWPParameterValue, WWPParameterDisableDelete FROM WWP_Parameter WHERE WWPParameterKey = :WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00023,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00024", "SELECT TM1.WWPParameterKey, TM1.WWPParameterCategory, TM1.WWPParameterDescription, TM1.WWPParameterValue, TM1.WWPParameterDisableDelete FROM WWP_Parameter TM1 WHERE TM1.WWPParameterKey = ( :WWPParameterKey) ORDER BY TM1.WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00024,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00025", "SELECT WWPParameterKey FROM WWP_Parameter WHERE WWPParameterKey = :WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00025,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00026", "SAVEPOINT gxupdate;INSERT INTO WWP_Parameter(WWPParameterKey, WWPParameterCategory, WWPParameterDescription, WWPParameterValue, WWPParameterDisableDelete) VALUES(:WWPParameterKey, :WWPParameterCategory, :WWPParameterDescription, :WWPParameterValue, :WWPParameterDisableDelete);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00026)
           ,new CursorDef("BC00027", "SAVEPOINT gxupdate;UPDATE WWP_Parameter SET WWPParameterCategory=:WWPParameterCategory, WWPParameterDescription=:WWPParameterDescription, WWPParameterValue=:WWPParameterValue, WWPParameterDisableDelete=:WWPParameterDisableDelete  WHERE WWPParameterKey = :WWPParameterKey;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00027)
           ,new CursorDef("BC00028", "SAVEPOINT gxupdate;DELETE FROM WWP_Parameter  WHERE WWPParameterKey = :WWPParameterKey;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00028)
           ,new CursorDef("BC00029", "SELECT TM1.WWPParameterKey, TM1.WWPParameterCategory, TM1.WWPParameterDescription, TM1.WWPParameterValue, TM1.WWPParameterDisableDelete FROM WWP_Parameter TM1 WHERE TM1.WWPParameterKey = ( :WWPParameterKey) ORDER BY TM1.WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00029,100, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.getBool(5);
              return;
     }
  }

}

}
