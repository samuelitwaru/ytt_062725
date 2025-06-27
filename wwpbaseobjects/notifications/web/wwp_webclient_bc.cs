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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_webclient_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_webclient_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_webclient_bc( IGxContext context )
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
         ReadRow077( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey077( ) ;
         standaloneModal( ) ;
         AddRow077( ) ;
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
               Z48WWPWebClientId = A48WWPWebClientId;
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

      protected void CONFIRM_070( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls077( ) ;
            }
            else
            {
               CheckExtendedTable077( ) ;
               if ( AnyError == 0 )
               {
                  ZM077( 5) ;
               }
               CloseExtendedTableCursors077( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM077( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z49WWPWebClientBrowserId = A49WWPWebClientBrowserId;
            Z51WWPWebClientFirstRegistered = A51WWPWebClientFirstRegistered;
            Z52WWPWebClientLastRegistered = A52WWPWebClientLastRegistered;
            Z7WWPUserExtendedId = A7WWPUserExtendedId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -4 )
         {
            Z48WWPWebClientId = A48WWPWebClientId;
            Z49WWPWebClientBrowserId = A49WWPWebClientBrowserId;
            Z50WWPWebClientBrowserVersion = A50WWPWebClientBrowserVersion;
            Z51WWPWebClientFirstRegistered = A51WWPWebClientFirstRegistered;
            Z52WWPWebClientLastRegistered = A52WWPWebClientLastRegistered;
            Z7WWPUserExtendedId = A7WWPUserExtendedId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A51WWPWebClientFirstRegistered) && ( Gx_BScreen == 0 ) )
         {
            A51WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A52WWPWebClientLastRegistered) && ( Gx_BScreen == 0 ) )
         {
            A52WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         }
      }

      protected void Load077( )
      {
         /* Using cursor BC00075 */
         pr_default.execute(3, new Object[] {A48WWPWebClientId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound7 = 1;
            A49WWPWebClientBrowserId = BC00075_A49WWPWebClientBrowserId[0];
            A50WWPWebClientBrowserVersion = BC00075_A50WWPWebClientBrowserVersion[0];
            A51WWPWebClientFirstRegistered = BC00075_A51WWPWebClientFirstRegistered[0];
            A52WWPWebClientLastRegistered = BC00075_A52WWPWebClientLastRegistered[0];
            A7WWPUserExtendedId = BC00075_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = BC00075_n7WWPUserExtendedId[0];
            ZM077( -4) ;
         }
         pr_default.close(3);
         OnLoadActions077( ) ;
      }

      protected void OnLoadActions077( )
      {
      }

      protected void CheckExtendedTable077( )
      {
         standaloneModal( ) ;
         if ( ! ( ( A49WWPWebClientBrowserId == 0 ) || ( A49WWPWebClientBrowserId == 1 ) || ( A49WWPWebClientBrowserId == 2 ) || ( A49WWPWebClientBrowserId == 3 ) || ( A49WWPWebClientBrowserId == 5 ) || ( A49WWPWebClientBrowserId == 6 ) || ( A49WWPWebClientBrowserId == 7 ) || ( A49WWPWebClientBrowserId == 8 ) || ( A49WWPWebClientBrowserId == 9 ) ) )
         {
            GX_msglist.addItem("Field Web Client Browser Id is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00074 */
         pr_default.execute(2, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("No matching 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors077( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey077( )
      {
         /* Using cursor BC00076 */
         pr_default.execute(4, new Object[] {A48WWPWebClientId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00073 */
         pr_default.execute(1, new Object[] {A48WWPWebClientId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM077( 4) ;
            RcdFound7 = 1;
            A48WWPWebClientId = BC00073_A48WWPWebClientId[0];
            A49WWPWebClientBrowserId = BC00073_A49WWPWebClientBrowserId[0];
            A50WWPWebClientBrowserVersion = BC00073_A50WWPWebClientBrowserVersion[0];
            A51WWPWebClientFirstRegistered = BC00073_A51WWPWebClientFirstRegistered[0];
            A52WWPWebClientLastRegistered = BC00073_A52WWPWebClientLastRegistered[0];
            A7WWPUserExtendedId = BC00073_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = BC00073_n7WWPUserExtendedId[0];
            Z48WWPWebClientId = A48WWPWebClientId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load077( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey077( ) ;
            }
            Gx_mode = sMode7;
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey077( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode7;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey077( ) ;
         if ( RcdFound7 == 0 )
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
         CONFIRM_070( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency077( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00072 */
            pr_default.execute(0, new Object[] {A48WWPWebClientId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebClient"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z49WWPWebClientBrowserId != BC00072_A49WWPWebClientBrowserId[0] ) || ( Z51WWPWebClientFirstRegistered != BC00072_A51WWPWebClientFirstRegistered[0] ) || ( Z52WWPWebClientLastRegistered != BC00072_A52WWPWebClientLastRegistered[0] ) || ( StringUtil.StrCmp(Z7WWPUserExtendedId, BC00072_A7WWPUserExtendedId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_WebClient"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM077( 0) ;
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00077 */
                     pr_default.execute(5, new Object[] {A48WWPWebClientId, A49WWPWebClientBrowserId, A50WWPWebClientBrowserVersion, A51WWPWebClientFirstRegistered, A52WWPWebClientLastRegistered, n7WWPUserExtendedId, A7WWPUserExtendedId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
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
               Load077( ) ;
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void Update077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00078 */
                     pr_default.execute(6, new Object[] {A49WWPWebClientBrowserId, A50WWPWebClientBrowserVersion, A51WWPWebClientFirstRegistered, A52WWPWebClientLastRegistered, n7WWPUserExtendedId, A7WWPUserExtendedId, A48WWPWebClientId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebClient"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate077( ) ;
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
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void DeferredUpdate077( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls077( ) ;
            AfterConfirm077( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete077( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00079 */
                  pr_default.execute(7, new Object[] {A48WWPWebClientId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel077( ) ;
         Gx_mode = sMode7;
      }

      protected void OnDeleteControls077( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel077( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete077( ) ;
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

      public void ScanKeyStart077( )
      {
         /* Using cursor BC000710 */
         pr_default.execute(8, new Object[] {A48WWPWebClientId});
         RcdFound7 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound7 = 1;
            A48WWPWebClientId = BC000710_A48WWPWebClientId[0];
            A49WWPWebClientBrowserId = BC000710_A49WWPWebClientBrowserId[0];
            A50WWPWebClientBrowserVersion = BC000710_A50WWPWebClientBrowserVersion[0];
            A51WWPWebClientFirstRegistered = BC000710_A51WWPWebClientFirstRegistered[0];
            A52WWPWebClientLastRegistered = BC000710_A52WWPWebClientLastRegistered[0];
            A7WWPUserExtendedId = BC000710_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = BC000710_n7WWPUserExtendedId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext077( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound7 = 0;
         ScanKeyLoad077( ) ;
      }

      protected void ScanKeyLoad077( )
      {
         sMode7 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound7 = 1;
            A48WWPWebClientId = BC000710_A48WWPWebClientId[0];
            A49WWPWebClientBrowserId = BC000710_A49WWPWebClientBrowserId[0];
            A50WWPWebClientBrowserVersion = BC000710_A50WWPWebClientBrowserVersion[0];
            A51WWPWebClientFirstRegistered = BC000710_A51WWPWebClientFirstRegistered[0];
            A52WWPWebClientLastRegistered = BC000710_A52WWPWebClientLastRegistered[0];
            A7WWPUserExtendedId = BC000710_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = BC000710_n7WWPUserExtendedId[0];
         }
         Gx_mode = sMode7;
      }

      protected void ScanKeyEnd077( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm077( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert077( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate077( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete077( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete077( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate077( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes077( )
      {
      }

      protected void send_integrity_lvl_hashes077( )
      {
      }

      protected void AddRow077( )
      {
         VarsToRow7( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
      }

      protected void ReadRow077( )
      {
         RowToVars7( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
      }

      protected void InitializeNonKey077( )
      {
         A49WWPWebClientBrowserId = 0;
         A50WWPWebClientBrowserVersion = "";
         A7WWPUserExtendedId = "";
         n7WWPUserExtendedId = false;
         A51WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A52WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         Z49WWPWebClientBrowserId = 0;
         Z51WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Z52WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         Z7WWPUserExtendedId = "";
      }

      protected void InitAll077( )
      {
         A48WWPWebClientId = "";
         InitializeNonKey077( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A51WWPWebClientFirstRegistered = i51WWPWebClientFirstRegistered;
         A52WWPWebClientLastRegistered = i52WWPWebClientLastRegistered;
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

      public void VarsToRow7( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient obj7 )
      {
         obj7.gxTpr_Mode = Gx_mode;
         obj7.gxTpr_Wwpwebclientbrowserid = A49WWPWebClientBrowserId;
         obj7.gxTpr_Wwpwebclientbrowserversion = A50WWPWebClientBrowserVersion;
         obj7.gxTpr_Wwpuserextendedid = A7WWPUserExtendedId;
         obj7.gxTpr_Wwpwebclientfirstregistered = A51WWPWebClientFirstRegistered;
         obj7.gxTpr_Wwpwebclientlastregistered = A52WWPWebClientLastRegistered;
         obj7.gxTpr_Wwpwebclientid = A48WWPWebClientId;
         obj7.gxTpr_Wwpwebclientid_Z = Z48WWPWebClientId;
         obj7.gxTpr_Wwpwebclientbrowserid_Z = Z49WWPWebClientBrowserId;
         obj7.gxTpr_Wwpwebclientfirstregistered_Z = Z51WWPWebClientFirstRegistered;
         obj7.gxTpr_Wwpwebclientlastregistered_Z = Z52WWPWebClientLastRegistered;
         obj7.gxTpr_Wwpuserextendedid_Z = Z7WWPUserExtendedId;
         obj7.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n7WWPUserExtendedId));
         obj7.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow7( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient obj7 )
      {
         obj7.gxTpr_Wwpwebclientid = A48WWPWebClientId;
         return  ;
      }

      public void RowToVars7( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient obj7 ,
                              int forceLoad )
      {
         Gx_mode = obj7.gxTpr_Mode;
         A49WWPWebClientBrowserId = obj7.gxTpr_Wwpwebclientbrowserid;
         A50WWPWebClientBrowserVersion = obj7.gxTpr_Wwpwebclientbrowserversion;
         A7WWPUserExtendedId = obj7.gxTpr_Wwpuserextendedid;
         n7WWPUserExtendedId = false;
         A51WWPWebClientFirstRegistered = obj7.gxTpr_Wwpwebclientfirstregistered;
         A52WWPWebClientLastRegistered = obj7.gxTpr_Wwpwebclientlastregistered;
         A48WWPWebClientId = obj7.gxTpr_Wwpwebclientid;
         Z48WWPWebClientId = obj7.gxTpr_Wwpwebclientid_Z;
         Z49WWPWebClientBrowserId = obj7.gxTpr_Wwpwebclientbrowserid_Z;
         Z51WWPWebClientFirstRegistered = obj7.gxTpr_Wwpwebclientfirstregistered_Z;
         Z52WWPWebClientLastRegistered = obj7.gxTpr_Wwpwebclientlastregistered_Z;
         Z7WWPUserExtendedId = obj7.gxTpr_Wwpuserextendedid_Z;
         n7WWPUserExtendedId = (bool)(Convert.ToBoolean(obj7.gxTpr_Wwpuserextendedid_N));
         Gx_mode = obj7.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A48WWPWebClientId = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey077( ) ;
         ScanKeyStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z48WWPWebClientId = A48WWPWebClientId;
         }
         ZM077( -4) ;
         OnLoadActions077( ) ;
         AddRow077( ) ;
         ScanKeyEnd077( ) ;
         if ( RcdFound7 == 0 )
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
         RowToVars7( bcwwpbaseobjects_notifications_web_WWP_WebClient, 0) ;
         ScanKeyStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z48WWPWebClientId = A48WWPWebClientId;
         }
         ZM077( -4) ;
         OnLoadActions077( ) ;
         AddRow077( ) ;
         ScanKeyEnd077( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey077( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert077( ) ;
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( StringUtil.StrCmp(A48WWPWebClientId, Z48WWPWebClientId) != 0 )
               {
                  A48WWPWebClientId = Z48WWPWebClientId;
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
                  Update077( ) ;
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
                  if ( StringUtil.StrCmp(A48WWPWebClientId, Z48WWPWebClientId) != 0 )
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
                        Insert077( ) ;
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
                        Insert077( ) ;
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
         RowToVars7( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         SaveImpl( ) ;
         VarsToRow7( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars7( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert077( ) ;
         AfterTrn( ) ;
         VarsToRow7( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow7( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A48WWPWebClientId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_web_WWP_WebClient);
               auxBC.Save();
               bcwwpbaseobjects_notifications_web_WWP_WebClient.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars7( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
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
         RowToVars7( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert077( ) ;
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
               VarsToRow7( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow7( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
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
         RowToVars7( bcwwpbaseobjects_notifications_web_WWP_WebClient, 0) ;
         GetKey077( ) ;
         if ( RcdFound7 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A48WWPWebClientId, Z48WWPWebClientId) != 0 )
            {
               A48WWPWebClientId = Z48WWPWebClientId;
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
            if ( StringUtil.StrCmp(A48WWPWebClientId, Z48WWPWebClientId) != 0 )
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
         context.RollbackDataStores("wwpbaseobjects.notifications.web.wwp_webclient_bc",pr_default);
         VarsToRow7( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_web_WWP_WebClient )
         {
            bcwwpbaseobjects_notifications_web_WWP_WebClient = (GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow7( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
            }
            else
            {
               RowToVars7( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars7( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_WebClient WWP_WebClient_BC
      {
         get {
            return bcwwpbaseobjects_notifications_web_WWP_WebClient ;
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
            return "webclient_Execute" ;
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
         Z48WWPWebClientId = "";
         A48WWPWebClientId = "";
         Z51WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         A51WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Z52WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         A52WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         Z7WWPUserExtendedId = "";
         A7WWPUserExtendedId = "";
         Z50WWPWebClientBrowserVersion = "";
         A50WWPWebClientBrowserVersion = "";
         BC00075_A48WWPWebClientId = new string[] {""} ;
         BC00075_A49WWPWebClientBrowserId = new short[1] ;
         BC00075_A50WWPWebClientBrowserVersion = new string[] {""} ;
         BC00075_A51WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC00075_A52WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC00075_A7WWPUserExtendedId = new string[] {""} ;
         BC00075_n7WWPUserExtendedId = new bool[] {false} ;
         BC00074_A7WWPUserExtendedId = new string[] {""} ;
         BC00074_n7WWPUserExtendedId = new bool[] {false} ;
         BC00076_A48WWPWebClientId = new string[] {""} ;
         BC00073_A48WWPWebClientId = new string[] {""} ;
         BC00073_A49WWPWebClientBrowserId = new short[1] ;
         BC00073_A50WWPWebClientBrowserVersion = new string[] {""} ;
         BC00073_A51WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC00073_A52WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC00073_A7WWPUserExtendedId = new string[] {""} ;
         BC00073_n7WWPUserExtendedId = new bool[] {false} ;
         sMode7 = "";
         BC00072_A48WWPWebClientId = new string[] {""} ;
         BC00072_A49WWPWebClientBrowserId = new short[1] ;
         BC00072_A50WWPWebClientBrowserVersion = new string[] {""} ;
         BC00072_A51WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC00072_A52WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC00072_A7WWPUserExtendedId = new string[] {""} ;
         BC00072_n7WWPUserExtendedId = new bool[] {false} ;
         BC000710_A48WWPWebClientId = new string[] {""} ;
         BC000710_A49WWPWebClientBrowserId = new short[1] ;
         BC000710_A50WWPWebClientBrowserVersion = new string[] {""} ;
         BC000710_A51WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000710_A52WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000710_A7WWPUserExtendedId = new string[] {""} ;
         BC000710_n7WWPUserExtendedId = new bool[] {false} ;
         i51WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         i52WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webclient_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webclient_bc__default(),
            new Object[][] {
                new Object[] {
               BC00072_A48WWPWebClientId, BC00072_A49WWPWebClientBrowserId, BC00072_A50WWPWebClientBrowserVersion, BC00072_A51WWPWebClientFirstRegistered, BC00072_A52WWPWebClientLastRegistered, BC00072_A7WWPUserExtendedId, BC00072_n7WWPUserExtendedId
               }
               , new Object[] {
               BC00073_A48WWPWebClientId, BC00073_A49WWPWebClientBrowserId, BC00073_A50WWPWebClientBrowserVersion, BC00073_A51WWPWebClientFirstRegistered, BC00073_A52WWPWebClientLastRegistered, BC00073_A7WWPUserExtendedId, BC00073_n7WWPUserExtendedId
               }
               , new Object[] {
               BC00074_A7WWPUserExtendedId
               }
               , new Object[] {
               BC00075_A48WWPWebClientId, BC00075_A49WWPWebClientBrowserId, BC00075_A50WWPWebClientBrowserVersion, BC00075_A51WWPWebClientFirstRegistered, BC00075_A52WWPWebClientLastRegistered, BC00075_A7WWPUserExtendedId, BC00075_n7WWPUserExtendedId
               }
               , new Object[] {
               BC00076_A48WWPWebClientId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000710_A48WWPWebClientId, BC000710_A49WWPWebClientBrowserId, BC000710_A50WWPWebClientBrowserVersion, BC000710_A51WWPWebClientFirstRegistered, BC000710_A52WWPWebClientLastRegistered, BC000710_A7WWPUserExtendedId, BC000710_n7WWPUserExtendedId
               }
            }
         );
         Z52WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A52WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         i52WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         Z51WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A51WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         i51WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z49WWPWebClientBrowserId ;
      private short A49WWPWebClientBrowserId ;
      private short Gx_BScreen ;
      private short RcdFound7 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z48WWPWebClientId ;
      private string A48WWPWebClientId ;
      private string Z7WWPUserExtendedId ;
      private string A7WWPUserExtendedId ;
      private string sMode7 ;
      private DateTime Z51WWPWebClientFirstRegistered ;
      private DateTime A51WWPWebClientFirstRegistered ;
      private DateTime Z52WWPWebClientLastRegistered ;
      private DateTime A52WWPWebClientLastRegistered ;
      private DateTime i51WWPWebClientFirstRegistered ;
      private DateTime i52WWPWebClientLastRegistered ;
      private bool n7WWPUserExtendedId ;
      private string Z50WWPWebClientBrowserVersion ;
      private string A50WWPWebClientBrowserVersion ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC00075_A48WWPWebClientId ;
      private short[] BC00075_A49WWPWebClientBrowserId ;
      private string[] BC00075_A50WWPWebClientBrowserVersion ;
      private DateTime[] BC00075_A51WWPWebClientFirstRegistered ;
      private DateTime[] BC00075_A52WWPWebClientLastRegistered ;
      private string[] BC00075_A7WWPUserExtendedId ;
      private bool[] BC00075_n7WWPUserExtendedId ;
      private string[] BC00074_A7WWPUserExtendedId ;
      private bool[] BC00074_n7WWPUserExtendedId ;
      private string[] BC00076_A48WWPWebClientId ;
      private string[] BC00073_A48WWPWebClientId ;
      private short[] BC00073_A49WWPWebClientBrowserId ;
      private string[] BC00073_A50WWPWebClientBrowserVersion ;
      private DateTime[] BC00073_A51WWPWebClientFirstRegistered ;
      private DateTime[] BC00073_A52WWPWebClientLastRegistered ;
      private string[] BC00073_A7WWPUserExtendedId ;
      private bool[] BC00073_n7WWPUserExtendedId ;
      private string[] BC00072_A48WWPWebClientId ;
      private short[] BC00072_A49WWPWebClientBrowserId ;
      private string[] BC00072_A50WWPWebClientBrowserVersion ;
      private DateTime[] BC00072_A51WWPWebClientFirstRegistered ;
      private DateTime[] BC00072_A52WWPWebClientLastRegistered ;
      private string[] BC00072_A7WWPUserExtendedId ;
      private bool[] BC00072_n7WWPUserExtendedId ;
      private string[] BC000710_A48WWPWebClientId ;
      private short[] BC000710_A49WWPWebClientBrowserId ;
      private string[] BC000710_A50WWPWebClientBrowserVersion ;
      private DateTime[] BC000710_A51WWPWebClientFirstRegistered ;
      private DateTime[] BC000710_A52WWPWebClientLastRegistered ;
      private string[] BC000710_A7WWPUserExtendedId ;
      private bool[] BC000710_n7WWPUserExtendedId ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient bcwwpbaseobjects_notifications_web_WWP_WebClient ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_webclient_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_webclient_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00072;
        prmBC00072 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmBC00073;
        prmBC00073 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmBC00074;
        prmBC00074 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00075;
        prmBC00075 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmBC00076;
        prmBC00076 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmBC00077;
        prmBC00077 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0) ,
        new ParDef("WWPWebClientBrowserId",GXType.Int16,4,0) ,
        new ParDef("WWPWebClientBrowserVersion",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPWebClientFirstRegistered",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00078;
        prmBC00078 = new Object[] {
        new ParDef("WWPWebClientBrowserId",GXType.Int16,4,0) ,
        new ParDef("WWPWebClientBrowserVersion",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPWebClientFirstRegistered",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmBC00079;
        prmBC00079 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmBC000710;
        prmBC000710 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00072", "SELECT WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientFirstRegistered, WWPWebClientLastRegistered, WWPUserExtendedId FROM WWP_WebClient WHERE WWPWebClientId = :WWPWebClientId  FOR UPDATE OF WWP_WebClient",true, GxErrorMask.GX_NOMASK, false, this,prmBC00072,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00073", "SELECT WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientFirstRegistered, WWPWebClientLastRegistered, WWPUserExtendedId FROM WWP_WebClient WHERE WWPWebClientId = :WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00073,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00074", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00074,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00075", "SELECT TM1.WWPWebClientId, TM1.WWPWebClientBrowserId, TM1.WWPWebClientBrowserVersion, TM1.WWPWebClientFirstRegistered, TM1.WWPWebClientLastRegistered, TM1.WWPUserExtendedId FROM WWP_WebClient TM1 WHERE TM1.WWPWebClientId = ( :WWPWebClientId) ORDER BY TM1.WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00075,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00076", "SELECT WWPWebClientId FROM WWP_WebClient WHERE WWPWebClientId = :WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00076,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00077", "SAVEPOINT gxupdate;INSERT INTO WWP_WebClient(WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientFirstRegistered, WWPWebClientLastRegistered, WWPUserExtendedId) VALUES(:WWPWebClientId, :WWPWebClientBrowserId, :WWPWebClientBrowserVersion, :WWPWebClientFirstRegistered, :WWPWebClientLastRegistered, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00077)
           ,new CursorDef("BC00078", "SAVEPOINT gxupdate;UPDATE WWP_WebClient SET WWPWebClientBrowserId=:WWPWebClientBrowserId, WWPWebClientBrowserVersion=:WWPWebClientBrowserVersion, WWPWebClientFirstRegistered=:WWPWebClientFirstRegistered, WWPWebClientLastRegistered=:WWPWebClientLastRegistered, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPWebClientId = :WWPWebClientId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00078)
           ,new CursorDef("BC00079", "SAVEPOINT gxupdate;DELETE FROM WWP_WebClient  WHERE WWPWebClientId = :WWPWebClientId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00079)
           ,new CursorDef("BC000710", "SELECT TM1.WWPWebClientId, TM1.WWPWebClientBrowserId, TM1.WWPWebClientBrowserVersion, TM1.WWPWebClientFirstRegistered, TM1.WWPWebClientLastRegistered, TM1.WWPUserExtendedId FROM WWP_WebClient TM1 WHERE TM1.WWPWebClientId = ( :WWPWebClientId) ORDER BY TM1.WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000710,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
     }
  }

}

}
