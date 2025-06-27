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
   public class device_bc : GxSilentTrn, IGxSilentTrn
   {
      public device_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public device_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public GXBCCollection<SdtDevice> GetAll( int Start ,
                                               int Count )
      {
         GXPagingFrom23 = Start;
         GXPagingTo23 = Count;
         /* Using cursor BC000L4 */
         pr_default.execute(2, new Object[] {GXPagingFrom23, GXPagingTo23});
         RcdFound23 = 0;
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound23 = 1;
            A151DeviceId = BC000L4_A151DeviceId[0];
            A152DeviceType = BC000L4_A152DeviceType[0];
            A149DeviceToken = BC000L4_A149DeviceToken[0];
            A153DeviceName = BC000L4_A153DeviceName[0];
            A150DeviceUser = BC000L4_A150DeviceUser[0];
            n150DeviceUser = BC000L4_n150DeviceUser[0];
         }
         bcDevice = new SdtDevice(context);
         gx_restcollection.Clear();
         while ( RcdFound23 != 0 )
         {
            OnLoadActions0L23( ) ;
            AddRow0L23( ) ;
            gx_sdt_item = (SdtDevice)(bcDevice.Clone());
            gx_restcollection.Add(gx_sdt_item, 0);
            pr_default.readNext(2);
            RcdFound23 = 0;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            if ( (pr_default.getStatus(2) != 101) )
            {
               RcdFound23 = 1;
               A151DeviceId = BC000L4_A151DeviceId[0];
               A152DeviceType = BC000L4_A152DeviceType[0];
               A149DeviceToken = BC000L4_A149DeviceToken[0];
               A153DeviceName = BC000L4_A153DeviceName[0];
               A150DeviceUser = BC000L4_A150DeviceUser[0];
               n150DeviceUser = BC000L4_n150DeviceUser[0];
            }
            Gx_mode = sMode23;
         }
         pr_default.close(2);
         /* Load Subordinate Levels */
         return gx_restcollection ;
      }

      protected void SETSEUDOVARS( )
      {
         ZM0L23( 0) ;
      }

      public void GetInsDefault( )
      {
         ReadRow0L23( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0L23( ) ;
         standaloneModal( ) ;
         AddRow0L23( ) ;
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
               Z151DeviceId = A151DeviceId;
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

      protected void CONFIRM_0L0( )
      {
         BeforeValidate0L23( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0L23( ) ;
            }
            else
            {
               CheckExtendedTable0L23( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0L23( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0L23( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z152DeviceType = A152DeviceType;
            Z149DeviceToken = A149DeviceToken;
            Z153DeviceName = A153DeviceName;
            Z150DeviceUser = A150DeviceUser;
         }
         if ( GX_JID == -2 )
         {
            Z151DeviceId = A151DeviceId;
            Z152DeviceType = A152DeviceType;
            Z149DeviceToken = A149DeviceToken;
            Z153DeviceName = A153DeviceName;
            Z150DeviceUser = A150DeviceUser;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0L23( )
      {
         /* Using cursor BC000L5 */
         pr_default.execute(3, new Object[] {A151DeviceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound23 = 1;
            A152DeviceType = BC000L5_A152DeviceType[0];
            A149DeviceToken = BC000L5_A149DeviceToken[0];
            A153DeviceName = BC000L5_A153DeviceName[0];
            A150DeviceUser = BC000L5_A150DeviceUser[0];
            n150DeviceUser = BC000L5_n150DeviceUser[0];
            ZM0L23( -2) ;
         }
         pr_default.close(3);
         OnLoadActions0L23( ) ;
      }

      protected void OnLoadActions0L23( )
      {
      }

      protected void CheckExtendedTable0L23( )
      {
         standaloneModal( ) ;
         if ( ! ( ( A152DeviceType == 0 ) || ( A152DeviceType == 1 ) || ( A152DeviceType == 2 ) || ( A152DeviceType == 3 ) ) )
         {
            GX_msglist.addItem("Field Device Type is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0L23( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0L23( )
      {
         /* Using cursor BC000L6 */
         pr_default.execute(4, new Object[] {A151DeviceId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound23 = 1;
         }
         else
         {
            RcdFound23 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000L3 */
         pr_default.execute(1, new Object[] {A151DeviceId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0L23( 2) ;
            RcdFound23 = 1;
            A151DeviceId = BC000L3_A151DeviceId[0];
            A152DeviceType = BC000L3_A152DeviceType[0];
            A149DeviceToken = BC000L3_A149DeviceToken[0];
            A153DeviceName = BC000L3_A153DeviceName[0];
            A150DeviceUser = BC000L3_A150DeviceUser[0];
            n150DeviceUser = BC000L3_n150DeviceUser[0];
            Z151DeviceId = A151DeviceId;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0L23( ) ;
            if ( AnyError == 1 )
            {
               RcdFound23 = 0;
               InitializeNonKey0L23( ) ;
            }
            Gx_mode = sMode23;
         }
         else
         {
            RcdFound23 = 0;
            InitializeNonKey0L23( ) ;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode23;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0L23( ) ;
         if ( RcdFound23 == 0 )
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
         CONFIRM_0L0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0L23( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000L2 */
            pr_default.execute(0, new Object[] {A151DeviceId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Device"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z152DeviceType != BC000L2_A152DeviceType[0] ) || ( StringUtil.StrCmp(Z149DeviceToken, BC000L2_A149DeviceToken[0]) != 0 ) || ( StringUtil.StrCmp(Z153DeviceName, BC000L2_A153DeviceName[0]) != 0 ) || ( StringUtil.StrCmp(Z150DeviceUser, BC000L2_A150DeviceUser[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Device"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0L23( )
      {
         BeforeValidate0L23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L23( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0L23( 0) ;
            CheckOptimisticConcurrency0L23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0L23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000L7 */
                     pr_default.execute(5, new Object[] {A151DeviceId, A152DeviceType, A149DeviceToken, A153DeviceName, n150DeviceUser, A150DeviceUser});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Device");
                     if ( (pr_default.getStatus(5) == 1) )
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
               Load0L23( ) ;
            }
            EndLevel0L23( ) ;
         }
         CloseExtendedTableCursors0L23( ) ;
      }

      protected void Update0L23( )
      {
         BeforeValidate0L23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L23( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0L23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000L8 */
                     pr_default.execute(6, new Object[] {A152DeviceType, A149DeviceToken, A153DeviceName, n150DeviceUser, A150DeviceUser, A151DeviceId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Device");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Device"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0L23( ) ;
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
            EndLevel0L23( ) ;
         }
         CloseExtendedTableCursors0L23( ) ;
      }

      protected void DeferredUpdate0L23( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0L23( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L23( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0L23( ) ;
            AfterConfirm0L23( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0L23( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000L9 */
                  pr_default.execute(7, new Object[] {A151DeviceId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Device");
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
         sMode23 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0L23( ) ;
         Gx_mode = sMode23;
      }

      protected void OnDeleteControls0L23( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0L23( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0L23( ) ;
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

      public void ScanKeyStart0L23( )
      {
         /* Using cursor BC000L10 */
         pr_default.execute(8, new Object[] {A151DeviceId});
         RcdFound23 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound23 = 1;
            A151DeviceId = BC000L10_A151DeviceId[0];
            A152DeviceType = BC000L10_A152DeviceType[0];
            A149DeviceToken = BC000L10_A149DeviceToken[0];
            A153DeviceName = BC000L10_A153DeviceName[0];
            A150DeviceUser = BC000L10_A150DeviceUser[0];
            n150DeviceUser = BC000L10_n150DeviceUser[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0L23( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound23 = 0;
         ScanKeyLoad0L23( ) ;
      }

      protected void ScanKeyLoad0L23( )
      {
         sMode23 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound23 = 1;
            A151DeviceId = BC000L10_A151DeviceId[0];
            A152DeviceType = BC000L10_A152DeviceType[0];
            A149DeviceToken = BC000L10_A149DeviceToken[0];
            A153DeviceName = BC000L10_A153DeviceName[0];
            A150DeviceUser = BC000L10_A150DeviceUser[0];
            n150DeviceUser = BC000L10_n150DeviceUser[0];
         }
         Gx_mode = sMode23;
      }

      protected void ScanKeyEnd0L23( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0L23( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0L23( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0L23( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0L23( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0L23( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0L23( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0L23( )
      {
      }

      protected void send_integrity_lvl_hashes0L23( )
      {
      }

      protected void AddRow0L23( )
      {
         VarsToRow23( bcDevice) ;
      }

      protected void ReadRow0L23( )
      {
         RowToVars23( bcDevice, 1) ;
      }

      protected void InitializeNonKey0L23( )
      {
         A152DeviceType = 0;
         A149DeviceToken = "";
         A153DeviceName = "";
         A150DeviceUser = "";
         n150DeviceUser = false;
         Z152DeviceType = 0;
         Z149DeviceToken = "";
         Z153DeviceName = "";
         Z150DeviceUser = "";
      }

      protected void InitAll0L23( )
      {
         A151DeviceId = "";
         InitializeNonKey0L23( ) ;
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

      public void VarsToRow23( SdtDevice obj23 )
      {
         obj23.gxTpr_Mode = Gx_mode;
         obj23.gxTpr_Devicetype = A152DeviceType;
         obj23.gxTpr_Devicetoken = A149DeviceToken;
         obj23.gxTpr_Devicename = A153DeviceName;
         obj23.gxTpr_Deviceuser = A150DeviceUser;
         obj23.gxTpr_Deviceid = A151DeviceId;
         obj23.gxTpr_Deviceid_Z = Z151DeviceId;
         obj23.gxTpr_Devicetype_Z = Z152DeviceType;
         obj23.gxTpr_Devicetoken_Z = Z149DeviceToken;
         obj23.gxTpr_Devicename_Z = Z153DeviceName;
         obj23.gxTpr_Deviceuser_Z = Z150DeviceUser;
         obj23.gxTpr_Deviceuser_N = (short)(Convert.ToInt16(n150DeviceUser));
         obj23.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow23( SdtDevice obj23 )
      {
         obj23.gxTpr_Deviceid = A151DeviceId;
         return  ;
      }

      public void RowToVars23( SdtDevice obj23 ,
                               int forceLoad )
      {
         Gx_mode = obj23.gxTpr_Mode;
         A152DeviceType = obj23.gxTpr_Devicetype;
         A149DeviceToken = obj23.gxTpr_Devicetoken;
         A153DeviceName = obj23.gxTpr_Devicename;
         A150DeviceUser = obj23.gxTpr_Deviceuser;
         n150DeviceUser = false;
         A151DeviceId = obj23.gxTpr_Deviceid;
         Z151DeviceId = obj23.gxTpr_Deviceid_Z;
         Z152DeviceType = obj23.gxTpr_Devicetype_Z;
         Z149DeviceToken = obj23.gxTpr_Devicetoken_Z;
         Z153DeviceName = obj23.gxTpr_Devicename_Z;
         Z150DeviceUser = obj23.gxTpr_Deviceuser_Z;
         n150DeviceUser = (bool)(Convert.ToBoolean(obj23.gxTpr_Deviceuser_N));
         Gx_mode = obj23.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A151DeviceId = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0L23( ) ;
         ScanKeyStart0L23( ) ;
         if ( RcdFound23 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z151DeviceId = A151DeviceId;
         }
         ZM0L23( -2) ;
         OnLoadActions0L23( ) ;
         AddRow0L23( ) ;
         ScanKeyEnd0L23( ) ;
         if ( RcdFound23 == 0 )
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
         RowToVars23( bcDevice, 0) ;
         ScanKeyStart0L23( ) ;
         if ( RcdFound23 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z151DeviceId = A151DeviceId;
         }
         ZM0L23( -2) ;
         OnLoadActions0L23( ) ;
         AddRow0L23( ) ;
         ScanKeyEnd0L23( ) ;
         if ( RcdFound23 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0L23( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0L23( ) ;
         }
         else
         {
            if ( RcdFound23 == 1 )
            {
               if ( StringUtil.StrCmp(A151DeviceId, Z151DeviceId) != 0 )
               {
                  A151DeviceId = Z151DeviceId;
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
                  Update0L23( ) ;
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
                  if ( StringUtil.StrCmp(A151DeviceId, Z151DeviceId) != 0 )
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
                        Insert0L23( ) ;
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
                        Insert0L23( ) ;
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
         RowToVars23( bcDevice, 1) ;
         SaveImpl( ) ;
         VarsToRow23( bcDevice) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars23( bcDevice, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0L23( ) ;
         AfterTrn( ) ;
         VarsToRow23( bcDevice) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow23( bcDevice) ;
         }
         else
         {
            SdtDevice auxBC = new SdtDevice(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A151DeviceId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcDevice);
               auxBC.Save();
               bcDevice.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars23( bcDevice, 1) ;
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
         RowToVars23( bcDevice, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0L23( ) ;
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
               VarsToRow23( bcDevice) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow23( bcDevice) ;
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
         RowToVars23( bcDevice, 0) ;
         GetKey0L23( ) ;
         if ( RcdFound23 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A151DeviceId, Z151DeviceId) != 0 )
            {
               A151DeviceId = Z151DeviceId;
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
            if ( StringUtil.StrCmp(A151DeviceId, Z151DeviceId) != 0 )
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
         context.RollbackDataStores("device_bc",pr_default);
         VarsToRow23( bcDevice) ;
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
         Gx_mode = bcDevice.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcDevice.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcDevice )
         {
            bcDevice = (SdtDevice)(sdt);
            if ( StringUtil.StrCmp(bcDevice.gxTpr_Mode, "") == 0 )
            {
               bcDevice.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow23( bcDevice) ;
            }
            else
            {
               RowToVars23( bcDevice, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcDevice.gxTpr_Mode, "") == 0 )
            {
               bcDevice.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars23( bcDevice, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtDevice Device_BC
      {
         get {
            return bcDevice ;
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
            return "device_Execute" ;
         }

      }

      public override string ServiceExecutePermissionPrefix
      {
         get {
            return "device_Services_Execute" ;
         }

      }

      public override string ServiceDeletePermissionPrefix
      {
         get {
            return "device_Services_Delete" ;
         }

      }

      public override string ServiceInsertPermissionPrefix
      {
         get {
            return "device_Services_Insert" ;
         }

      }

      public override string ServiceUpdatePermissionPrefix
      {
         get {
            return "device_Services_Update" ;
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
         BC000L4_A151DeviceId = new string[] {""} ;
         BC000L4_A152DeviceType = new short[1] ;
         BC000L4_A149DeviceToken = new string[] {""} ;
         BC000L4_A153DeviceName = new string[] {""} ;
         BC000L4_A150DeviceUser = new string[] {""} ;
         BC000L4_n150DeviceUser = new bool[] {false} ;
         A151DeviceId = "";
         A149DeviceToken = "";
         A153DeviceName = "";
         A150DeviceUser = "";
         gx_restcollection = new GXBCCollection<SdtDevice>( context, "Device", "YTT_version4");
         sMode23 = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z151DeviceId = "";
         Z149DeviceToken = "";
         Z153DeviceName = "";
         Z150DeviceUser = "";
         BC000L5_A151DeviceId = new string[] {""} ;
         BC000L5_A152DeviceType = new short[1] ;
         BC000L5_A149DeviceToken = new string[] {""} ;
         BC000L5_A153DeviceName = new string[] {""} ;
         BC000L5_A150DeviceUser = new string[] {""} ;
         BC000L5_n150DeviceUser = new bool[] {false} ;
         BC000L6_A151DeviceId = new string[] {""} ;
         BC000L3_A151DeviceId = new string[] {""} ;
         BC000L3_A152DeviceType = new short[1] ;
         BC000L3_A149DeviceToken = new string[] {""} ;
         BC000L3_A153DeviceName = new string[] {""} ;
         BC000L3_A150DeviceUser = new string[] {""} ;
         BC000L3_n150DeviceUser = new bool[] {false} ;
         BC000L2_A151DeviceId = new string[] {""} ;
         BC000L2_A152DeviceType = new short[1] ;
         BC000L2_A149DeviceToken = new string[] {""} ;
         BC000L2_A153DeviceName = new string[] {""} ;
         BC000L2_A150DeviceUser = new string[] {""} ;
         BC000L2_n150DeviceUser = new bool[] {false} ;
         BC000L10_A151DeviceId = new string[] {""} ;
         BC000L10_A152DeviceType = new short[1] ;
         BC000L10_A149DeviceToken = new string[] {""} ;
         BC000L10_A153DeviceName = new string[] {""} ;
         BC000L10_A150DeviceUser = new string[] {""} ;
         BC000L10_n150DeviceUser = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.device_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.device_bc__default(),
            new Object[][] {
                new Object[] {
               BC000L2_A151DeviceId, BC000L2_A152DeviceType, BC000L2_A149DeviceToken, BC000L2_A153DeviceName, BC000L2_A150DeviceUser, BC000L2_n150DeviceUser
               }
               , new Object[] {
               BC000L3_A151DeviceId, BC000L3_A152DeviceType, BC000L3_A149DeviceToken, BC000L3_A153DeviceName, BC000L3_A150DeviceUser, BC000L3_n150DeviceUser
               }
               , new Object[] {
               BC000L4_A151DeviceId, BC000L4_A152DeviceType, BC000L4_A149DeviceToken, BC000L4_A153DeviceName, BC000L4_A150DeviceUser, BC000L4_n150DeviceUser
               }
               , new Object[] {
               BC000L5_A151DeviceId, BC000L5_A152DeviceType, BC000L5_A149DeviceToken, BC000L5_A153DeviceName, BC000L5_A150DeviceUser, BC000L5_n150DeviceUser
               }
               , new Object[] {
               BC000L6_A151DeviceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000L10_A151DeviceId, BC000L10_A152DeviceType, BC000L10_A149DeviceToken, BC000L10_A153DeviceName, BC000L10_A150DeviceUser, BC000L10_n150DeviceUser
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound23 ;
      private short A152DeviceType ;
      private short Z152DeviceType ;
      private int trnEnded ;
      private int Start ;
      private int Count ;
      private int GXPagingFrom23 ;
      private int GXPagingTo23 ;
      private string A151DeviceId ;
      private string A149DeviceToken ;
      private string A153DeviceName ;
      private string sMode23 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z151DeviceId ;
      private string Z149DeviceToken ;
      private string Z153DeviceName ;
      private bool n150DeviceUser ;
      private string A150DeviceUser ;
      private string Z150DeviceUser ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtDevice bcDevice ;
      private IDataStoreProvider pr_default ;
      private string[] BC000L4_A151DeviceId ;
      private short[] BC000L4_A152DeviceType ;
      private string[] BC000L4_A149DeviceToken ;
      private string[] BC000L4_A153DeviceName ;
      private string[] BC000L4_A150DeviceUser ;
      private bool[] BC000L4_n150DeviceUser ;
      private SdtDevice gx_sdt_item ;
      private GXBCCollection<SdtDevice> gx_restcollection ;
      private string[] BC000L5_A151DeviceId ;
      private short[] BC000L5_A152DeviceType ;
      private string[] BC000L5_A149DeviceToken ;
      private string[] BC000L5_A153DeviceName ;
      private string[] BC000L5_A150DeviceUser ;
      private bool[] BC000L5_n150DeviceUser ;
      private string[] BC000L6_A151DeviceId ;
      private string[] BC000L3_A151DeviceId ;
      private short[] BC000L3_A152DeviceType ;
      private string[] BC000L3_A149DeviceToken ;
      private string[] BC000L3_A153DeviceName ;
      private string[] BC000L3_A150DeviceUser ;
      private bool[] BC000L3_n150DeviceUser ;
      private string[] BC000L2_A151DeviceId ;
      private short[] BC000L2_A152DeviceType ;
      private string[] BC000L2_A149DeviceToken ;
      private string[] BC000L2_A153DeviceName ;
      private string[] BC000L2_A150DeviceUser ;
      private bool[] BC000L2_n150DeviceUser ;
      private string[] BC000L10_A151DeviceId ;
      private short[] BC000L10_A152DeviceType ;
      private string[] BC000L10_A149DeviceToken ;
      private string[] BC000L10_A153DeviceName ;
      private string[] BC000L10_A150DeviceUser ;
      private bool[] BC000L10_n150DeviceUser ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class device_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class device_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000L2;
        prmBC000L2 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmBC000L3;
        prmBC000L3 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmBC000L4;
        prmBC000L4 = new Object[] {
        new ParDef("GXPagingFrom23",GXType.Int32,9,0) ,
        new ParDef("GXPagingTo23",GXType.Int32,9,0)
        };
        Object[] prmBC000L5;
        prmBC000L5 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmBC000L6;
        prmBC000L6 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmBC000L7;
        prmBC000L7 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0) ,
        new ParDef("DeviceType",GXType.Int16,1,0) ,
        new ParDef("DeviceToken",GXType.Char,1000,0) ,
        new ParDef("DeviceName",GXType.Char,100,0) ,
        new ParDef("DeviceUser",GXType.VarChar,100,60){Nullable=true}
        };
        Object[] prmBC000L8;
        prmBC000L8 = new Object[] {
        new ParDef("DeviceType",GXType.Int16,1,0) ,
        new ParDef("DeviceToken",GXType.Char,1000,0) ,
        new ParDef("DeviceName",GXType.Char,100,0) ,
        new ParDef("DeviceUser",GXType.VarChar,100,60){Nullable=true} ,
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmBC000L9;
        prmBC000L9 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        Object[] prmBC000L10;
        prmBC000L10 = new Object[] {
        new ParDef("DeviceId",GXType.Char,128,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000L2", "SELECT DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUser FROM Device WHERE DeviceId = :DeviceId  FOR UPDATE OF Device",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L3", "SELECT DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUser FROM Device WHERE DeviceId = :DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L4", "SELECT TM1.DeviceId, TM1.DeviceType, TM1.DeviceToken, TM1.DeviceName, TM1.DeviceUser FROM Device TM1 ORDER BY TM1.DeviceId  OFFSET :GXPagingFrom23 LIMIT CASE WHEN :GXPagingTo23 > 0 THEN :GXPagingTo23 ELSE 1e9 END",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L5", "SELECT TM1.DeviceId, TM1.DeviceType, TM1.DeviceToken, TM1.DeviceName, TM1.DeviceUser FROM Device TM1 WHERE TM1.DeviceId = ( :DeviceId) ORDER BY TM1.DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L6", "SELECT DeviceId FROM Device WHERE DeviceId = :DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L7", "SAVEPOINT gxupdate;INSERT INTO Device(DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUser) VALUES(:DeviceId, :DeviceType, :DeviceToken, :DeviceName, :DeviceUser);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000L7)
           ,new CursorDef("BC000L8", "SAVEPOINT gxupdate;UPDATE Device SET DeviceType=:DeviceType, DeviceToken=:DeviceToken, DeviceName=:DeviceName, DeviceUser=:DeviceUser  WHERE DeviceId = :DeviceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000L8)
           ,new CursorDef("BC000L9", "SAVEPOINT gxupdate;DELETE FROM Device  WHERE DeviceId = :DeviceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000L9)
           ,new CursorDef("BC000L10", "SELECT TM1.DeviceId, TM1.DeviceType, TM1.DeviceToken, TM1.DeviceName, TM1.DeviceUser FROM Device TM1 WHERE TM1.DeviceId = ( :DeviceId) ORDER BY TM1.DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L10,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1000);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1000);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1000);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1000);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 128);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1000);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
     }
  }

}

}
