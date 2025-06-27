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
   public class leavetype_bc : GxSilentTrn, IGxSilentTrn
   {
      public leavetype_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leavetype_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public GXBCCollection<SdtLeaveType> GetAll( int Start ,
                                                  int Count )
      {
         GXPagingFrom20 = Start;
         GXPagingTo20 = Count;
         /* Using cursor BC000I5 */
         pr_default.execute(3, new Object[] {GXPagingFrom20, GXPagingTo20});
         RcdFound20 = 0;
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound20 = 1;
            A124LeaveTypeId = BC000I5_A124LeaveTypeId[0];
            A125LeaveTypeName = BC000I5_A125LeaveTypeName[0];
            A144LeaveTypeVacationLeave = BC000I5_A144LeaveTypeVacationLeave[0];
            A145LeaveTypeLoggingWorkHours = BC000I5_A145LeaveTypeLoggingWorkHours[0];
            A172LeaveTypeColorPending = BC000I5_A172LeaveTypeColorPending[0];
            n172LeaveTypeColorPending = BC000I5_n172LeaveTypeColorPending[0];
            A173LeaveTypeColorApproved = BC000I5_A173LeaveTypeColorApproved[0];
            n173LeaveTypeColorApproved = BC000I5_n173LeaveTypeColorApproved[0];
            A100CompanyId = BC000I5_A100CompanyId[0];
         }
         bcLeaveType = new SdtLeaveType(context);
         gx_restcollection.Clear();
         while ( RcdFound20 != 0 )
         {
            OnLoadActions0I20( ) ;
            AddRow0I20( ) ;
            gx_sdt_item = (SdtLeaveType)(bcLeaveType.Clone());
            gx_restcollection.Add(gx_sdt_item, 0);
            pr_default.readNext(3);
            RcdFound20 = 0;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            if ( (pr_default.getStatus(3) != 101) )
            {
               RcdFound20 = 1;
               A124LeaveTypeId = BC000I5_A124LeaveTypeId[0];
               A125LeaveTypeName = BC000I5_A125LeaveTypeName[0];
               A144LeaveTypeVacationLeave = BC000I5_A144LeaveTypeVacationLeave[0];
               A145LeaveTypeLoggingWorkHours = BC000I5_A145LeaveTypeLoggingWorkHours[0];
               A172LeaveTypeColorPending = BC000I5_A172LeaveTypeColorPending[0];
               n172LeaveTypeColorPending = BC000I5_n172LeaveTypeColorPending[0];
               A173LeaveTypeColorApproved = BC000I5_A173LeaveTypeColorApproved[0];
               n173LeaveTypeColorApproved = BC000I5_n173LeaveTypeColorApproved[0];
               A100CompanyId = BC000I5_A100CompanyId[0];
            }
            Gx_mode = sMode20;
         }
         pr_default.close(3);
         /* Load Subordinate Levels */
         return gx_restcollection ;
      }

      protected void SETSEUDOVARS( )
      {
         ZM0I20( 0) ;
      }

      public void GetInsDefault( )
      {
         ReadRow0I20( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0I20( ) ;
         standaloneModal( ) ;
         AddRow0I20( ) ;
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
            E110I2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z124LeaveTypeId = A124LeaveTypeId;
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

      protected void CONFIRM_0I0( )
      {
         BeforeValidate0I20( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0I20( ) ;
            }
            else
            {
               CheckExtendedTable0I20( ) ;
               if ( AnyError == 0 )
               {
                  ZM0I20( 12) ;
               }
               CloseExtendedTableCursors0I20( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120I2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV7WWPContext) ;
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1;
            while ( AV25GXV1 <= AV10TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV10TrnContext.gxTpr_Attributes.Item(AV25GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "CompanyId") == 0 )
               {
                  AV12Insert_CompanyId = (long)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV25GXV1 = (int)(AV25GXV1+1);
            }
         }
      }

      protected void E110I2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0I20( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z125LeaveTypeName = A125LeaveTypeName;
            Z144LeaveTypeVacationLeave = A144LeaveTypeVacationLeave;
            Z145LeaveTypeLoggingWorkHours = A145LeaveTypeLoggingWorkHours;
            Z172LeaveTypeColorPending = A172LeaveTypeColorPending;
            Z173LeaveTypeColorApproved = A173LeaveTypeColorApproved;
            Z100CompanyId = A100CompanyId;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -11 )
         {
            Z124LeaveTypeId = A124LeaveTypeId;
            Z125LeaveTypeName = A125LeaveTypeName;
            Z144LeaveTypeVacationLeave = A144LeaveTypeVacationLeave;
            Z145LeaveTypeLoggingWorkHours = A145LeaveTypeLoggingWorkHours;
            Z172LeaveTypeColorPending = A172LeaveTypeColorPending;
            Z173LeaveTypeColorApproved = A173LeaveTypeColorApproved;
            Z100CompanyId = A100CompanyId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV24Pgmname = "LeaveType_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         GXt_int1 = A100CompanyId;
         new getloggedinusercompanyid(context ).execute( out  GXt_int1) ;
         A100CompanyId = GXt_int1;
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A145LeaveTypeLoggingWorkHours)) && ( Gx_BScreen == 0 ) )
         {
            A145LeaveTypeLoggingWorkHours = "No";
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A144LeaveTypeVacationLeave)) && ( Gx_BScreen == 0 ) )
         {
            A144LeaveTypeVacationLeave = "No";
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A173LeaveTypeColorApproved)) && ( Gx_BScreen == 0 ) )
         {
            A173LeaveTypeColorApproved = "#D5DDF6";
            n173LeaveTypeColorApproved = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0I20( )
      {
         /* Using cursor BC000I6 */
         pr_default.execute(4, new Object[] {A124LeaveTypeId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound20 = 1;
            A125LeaveTypeName = BC000I6_A125LeaveTypeName[0];
            A144LeaveTypeVacationLeave = BC000I6_A144LeaveTypeVacationLeave[0];
            A145LeaveTypeLoggingWorkHours = BC000I6_A145LeaveTypeLoggingWorkHours[0];
            A172LeaveTypeColorPending = BC000I6_A172LeaveTypeColorPending[0];
            n172LeaveTypeColorPending = BC000I6_n172LeaveTypeColorPending[0];
            A173LeaveTypeColorApproved = BC000I6_A173LeaveTypeColorApproved[0];
            n173LeaveTypeColorApproved = BC000I6_n173LeaveTypeColorApproved[0];
            A100CompanyId = BC000I6_A100CompanyId[0];
            ZM0I20( -11) ;
         }
         pr_default.close(4);
         OnLoadActions0I20( ) ;
      }

      protected void OnLoadActions0I20( )
      {
      }

      protected void CheckExtendedTable0I20( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A125LeaveTypeName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Leave Type Name", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ( StringUtil.StrCmp(A145LeaveTypeLoggingWorkHours, "Yes") == 0 ) && ( StringUtil.StrCmp(A144LeaveTypeVacationLeave, "Yes") == 0 ) )
         {
            GX_msglist.addItem("You can't select both Vacation days and Work log setting on", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000I4 */
         pr_default.execute(2, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0I20( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0I20( )
      {
         /* Using cursor BC000I7 */
         pr_default.execute(5, new Object[] {A124LeaveTypeId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000I3 */
         pr_default.execute(1, new Object[] {A124LeaveTypeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0I20( 11) ;
            RcdFound20 = 1;
            A124LeaveTypeId = BC000I3_A124LeaveTypeId[0];
            A125LeaveTypeName = BC000I3_A125LeaveTypeName[0];
            A144LeaveTypeVacationLeave = BC000I3_A144LeaveTypeVacationLeave[0];
            A145LeaveTypeLoggingWorkHours = BC000I3_A145LeaveTypeLoggingWorkHours[0];
            A172LeaveTypeColorPending = BC000I3_A172LeaveTypeColorPending[0];
            n172LeaveTypeColorPending = BC000I3_n172LeaveTypeColorPending[0];
            A173LeaveTypeColorApproved = BC000I3_A173LeaveTypeColorApproved[0];
            n173LeaveTypeColorApproved = BC000I3_n173LeaveTypeColorApproved[0];
            A100CompanyId = BC000I3_A100CompanyId[0];
            Z124LeaveTypeId = A124LeaveTypeId;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0I20( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey0I20( ) ;
            }
            Gx_mode = sMode20;
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0I20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode20;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0I20( ) ;
         if ( RcdFound20 == 0 )
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
         CONFIRM_0I0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0I20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000I2 */
            pr_default.execute(0, new Object[] {A124LeaveTypeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LeaveType"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z125LeaveTypeName, BC000I2_A125LeaveTypeName[0]) != 0 ) || ( StringUtil.StrCmp(Z144LeaveTypeVacationLeave, BC000I2_A144LeaveTypeVacationLeave[0]) != 0 ) || ( StringUtil.StrCmp(Z145LeaveTypeLoggingWorkHours, BC000I2_A145LeaveTypeLoggingWorkHours[0]) != 0 ) || ( StringUtil.StrCmp(Z172LeaveTypeColorPending, BC000I2_A172LeaveTypeColorPending[0]) != 0 ) || ( StringUtil.StrCmp(Z173LeaveTypeColorApproved, BC000I2_A173LeaveTypeColorApproved[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z100CompanyId != BC000I2_A100CompanyId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"LeaveType"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0I20( )
      {
         BeforeValidate0I20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0I20( 0) ;
            CheckOptimisticConcurrency0I20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0I20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000I8 */
                     pr_default.execute(6, new Object[] {A125LeaveTypeName, A144LeaveTypeVacationLeave, A145LeaveTypeLoggingWorkHours, n172LeaveTypeColorPending, A172LeaveTypeColorPending, n173LeaveTypeColorApproved, A173LeaveTypeColorApproved, A100CompanyId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000I9 */
                     pr_default.execute(7);
                     A124LeaveTypeId = BC000I9_A124LeaveTypeId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("LeaveType");
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
               Load0I20( ) ;
            }
            EndLevel0I20( ) ;
         }
         CloseExtendedTableCursors0I20( ) ;
      }

      protected void Update0I20( )
      {
         BeforeValidate0I20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0I20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000I10 */
                     pr_default.execute(8, new Object[] {A125LeaveTypeName, A144LeaveTypeVacationLeave, A145LeaveTypeLoggingWorkHours, n172LeaveTypeColorPending, A172LeaveTypeColorPending, n173LeaveTypeColorApproved, A173LeaveTypeColorApproved, A100CompanyId, A124LeaveTypeId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("LeaveType");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LeaveType"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0I20( ) ;
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
            EndLevel0I20( ) ;
         }
         CloseExtendedTableCursors0I20( ) ;
      }

      protected void DeferredUpdate0I20( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0I20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0I20( ) ;
            AfterConfirm0I20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0I20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000I11 */
                  pr_default.execute(9, new Object[] {A124LeaveTypeId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("LeaveType");
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0I20( ) ;
         Gx_mode = sMode20;
      }

      protected void OnDeleteControls0I20( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000I12 */
            pr_default.execute(10, new Object[] {A124LeaveTypeId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"LeaveRequest"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel0I20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0I20( ) ;
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

      public void ScanKeyStart0I20( )
      {
         /* Scan By routine */
         /* Using cursor BC000I13 */
         pr_default.execute(11, new Object[] {A124LeaveTypeId});
         RcdFound20 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound20 = 1;
            A124LeaveTypeId = BC000I13_A124LeaveTypeId[0];
            A125LeaveTypeName = BC000I13_A125LeaveTypeName[0];
            A144LeaveTypeVacationLeave = BC000I13_A144LeaveTypeVacationLeave[0];
            A145LeaveTypeLoggingWorkHours = BC000I13_A145LeaveTypeLoggingWorkHours[0];
            A172LeaveTypeColorPending = BC000I13_A172LeaveTypeColorPending[0];
            n172LeaveTypeColorPending = BC000I13_n172LeaveTypeColorPending[0];
            A173LeaveTypeColorApproved = BC000I13_A173LeaveTypeColorApproved[0];
            n173LeaveTypeColorApproved = BC000I13_n173LeaveTypeColorApproved[0];
            A100CompanyId = BC000I13_A100CompanyId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0I20( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound20 = 0;
         ScanKeyLoad0I20( ) ;
      }

      protected void ScanKeyLoad0I20( )
      {
         sMode20 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound20 = 1;
            A124LeaveTypeId = BC000I13_A124LeaveTypeId[0];
            A125LeaveTypeName = BC000I13_A125LeaveTypeName[0];
            A144LeaveTypeVacationLeave = BC000I13_A144LeaveTypeVacationLeave[0];
            A145LeaveTypeLoggingWorkHours = BC000I13_A145LeaveTypeLoggingWorkHours[0];
            A172LeaveTypeColorPending = BC000I13_A172LeaveTypeColorPending[0];
            n172LeaveTypeColorPending = BC000I13_n172LeaveTypeColorPending[0];
            A173LeaveTypeColorApproved = BC000I13_A173LeaveTypeColorApproved[0];
            n173LeaveTypeColorApproved = BC000I13_n173LeaveTypeColorApproved[0];
            A100CompanyId = BC000I13_A100CompanyId[0];
         }
         Gx_mode = sMode20;
      }

      protected void ScanKeyEnd0I20( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0I20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0I20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0I20( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0I20( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0I20( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0I20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0I20( )
      {
      }

      protected void send_integrity_lvl_hashes0I20( )
      {
      }

      protected void AddRow0I20( )
      {
         VarsToRow20( bcLeaveType) ;
      }

      protected void ReadRow0I20( )
      {
         RowToVars20( bcLeaveType, 1) ;
      }

      protected void InitializeNonKey0I20( )
      {
         A100CompanyId = 0;
         A125LeaveTypeName = "";
         A172LeaveTypeColorPending = "";
         n172LeaveTypeColorPending = false;
         A144LeaveTypeVacationLeave = "No";
         A145LeaveTypeLoggingWorkHours = "No";
         A173LeaveTypeColorApproved = "#D5DDF6";
         n173LeaveTypeColorApproved = false;
         Z125LeaveTypeName = "";
         Z144LeaveTypeVacationLeave = "";
         Z145LeaveTypeLoggingWorkHours = "";
         Z172LeaveTypeColorPending = "";
         Z173LeaveTypeColorApproved = "";
         Z100CompanyId = 0;
      }

      protected void InitAll0I20( )
      {
         A124LeaveTypeId = 0;
         InitializeNonKey0I20( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A100CompanyId = i100CompanyId;
         A145LeaveTypeLoggingWorkHours = i145LeaveTypeLoggingWorkHours;
         A144LeaveTypeVacationLeave = i144LeaveTypeVacationLeave;
         A173LeaveTypeColorApproved = i173LeaveTypeColorApproved;
         n173LeaveTypeColorApproved = false;
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

      public void VarsToRow20( SdtLeaveType obj20 )
      {
         obj20.gxTpr_Mode = Gx_mode;
         obj20.gxTpr_Companyid = A100CompanyId;
         obj20.gxTpr_Leavetypename = A125LeaveTypeName;
         obj20.gxTpr_Leavetypecolorpending = A172LeaveTypeColorPending;
         obj20.gxTpr_Leavetypevacationleave = A144LeaveTypeVacationLeave;
         obj20.gxTpr_Leavetypeloggingworkhours = A145LeaveTypeLoggingWorkHours;
         obj20.gxTpr_Leavetypecolorapproved = A173LeaveTypeColorApproved;
         obj20.gxTpr_Leavetypeid = A124LeaveTypeId;
         obj20.gxTpr_Leavetypeid_Z = Z124LeaveTypeId;
         obj20.gxTpr_Leavetypename_Z = Z125LeaveTypeName;
         obj20.gxTpr_Leavetypevacationleave_Z = Z144LeaveTypeVacationLeave;
         obj20.gxTpr_Leavetypeloggingworkhours_Z = Z145LeaveTypeLoggingWorkHours;
         obj20.gxTpr_Leavetypecolorpending_Z = Z172LeaveTypeColorPending;
         obj20.gxTpr_Leavetypecolorapproved_Z = Z173LeaveTypeColorApproved;
         obj20.gxTpr_Companyid_Z = Z100CompanyId;
         obj20.gxTpr_Leavetypecolorpending_N = (short)(Convert.ToInt16(n172LeaveTypeColorPending));
         obj20.gxTpr_Leavetypecolorapproved_N = (short)(Convert.ToInt16(n173LeaveTypeColorApproved));
         obj20.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow20( SdtLeaveType obj20 )
      {
         obj20.gxTpr_Leavetypeid = A124LeaveTypeId;
         return  ;
      }

      public void RowToVars20( SdtLeaveType obj20 ,
                               int forceLoad )
      {
         Gx_mode = obj20.gxTpr_Mode;
         A100CompanyId = obj20.gxTpr_Companyid;
         A125LeaveTypeName = obj20.gxTpr_Leavetypename;
         A172LeaveTypeColorPending = obj20.gxTpr_Leavetypecolorpending;
         n172LeaveTypeColorPending = false;
         if ( ! ( ( StringUtil.StrCmp(obj20.gxTpr_Leavetypeloggingworkhours, "Yes") == 0 ) ) || ( forceLoad == 1 ) )
         {
            A144LeaveTypeVacationLeave = obj20.gxTpr_Leavetypevacationleave;
         }
         if ( ! ( ( StringUtil.StrCmp(obj20.gxTpr_Leavetypevacationleave, "Yes") == 0 ) ) || ( forceLoad == 1 ) )
         {
            A145LeaveTypeLoggingWorkHours = obj20.gxTpr_Leavetypeloggingworkhours;
         }
         A173LeaveTypeColorApproved = obj20.gxTpr_Leavetypecolorapproved;
         n173LeaveTypeColorApproved = false;
         A124LeaveTypeId = obj20.gxTpr_Leavetypeid;
         Z124LeaveTypeId = obj20.gxTpr_Leavetypeid_Z;
         Z125LeaveTypeName = obj20.gxTpr_Leavetypename_Z;
         Z144LeaveTypeVacationLeave = obj20.gxTpr_Leavetypevacationleave_Z;
         Z145LeaveTypeLoggingWorkHours = obj20.gxTpr_Leavetypeloggingworkhours_Z;
         Z172LeaveTypeColorPending = obj20.gxTpr_Leavetypecolorpending_Z;
         Z173LeaveTypeColorApproved = obj20.gxTpr_Leavetypecolorapproved_Z;
         Z100CompanyId = obj20.gxTpr_Companyid_Z;
         n172LeaveTypeColorPending = (bool)(Convert.ToBoolean(obj20.gxTpr_Leavetypecolorpending_N));
         n173LeaveTypeColorApproved = (bool)(Convert.ToBoolean(obj20.gxTpr_Leavetypecolorapproved_N));
         Gx_mode = obj20.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A124LeaveTypeId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0I20( ) ;
         ScanKeyStart0I20( ) ;
         if ( RcdFound20 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z124LeaveTypeId = A124LeaveTypeId;
         }
         ZM0I20( -11) ;
         OnLoadActions0I20( ) ;
         AddRow0I20( ) ;
         ScanKeyEnd0I20( ) ;
         if ( RcdFound20 == 0 )
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
         RowToVars20( bcLeaveType, 0) ;
         ScanKeyStart0I20( ) ;
         if ( RcdFound20 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z124LeaveTypeId = A124LeaveTypeId;
         }
         ZM0I20( -11) ;
         OnLoadActions0I20( ) ;
         AddRow0I20( ) ;
         ScanKeyEnd0I20( ) ;
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0I20( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0I20( ) ;
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( A124LeaveTypeId != Z124LeaveTypeId )
               {
                  A124LeaveTypeId = Z124LeaveTypeId;
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
                  Update0I20( ) ;
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
                  if ( A124LeaveTypeId != Z124LeaveTypeId )
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
                        Insert0I20( ) ;
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
                        Insert0I20( ) ;
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
         RowToVars20( bcLeaveType, 1) ;
         SaveImpl( ) ;
         VarsToRow20( bcLeaveType) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars20( bcLeaveType, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0I20( ) ;
         AfterTrn( ) ;
         VarsToRow20( bcLeaveType) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow20( bcLeaveType) ;
         }
         else
         {
            SdtLeaveType auxBC = new SdtLeaveType(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A124LeaveTypeId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcLeaveType);
               auxBC.Save();
               bcLeaveType.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars20( bcLeaveType, 1) ;
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
         RowToVars20( bcLeaveType, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0I20( ) ;
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
               VarsToRow20( bcLeaveType) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow20( bcLeaveType) ;
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
         RowToVars20( bcLeaveType, 0) ;
         GetKey0I20( ) ;
         if ( RcdFound20 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A124LeaveTypeId != Z124LeaveTypeId )
            {
               A124LeaveTypeId = Z124LeaveTypeId;
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
            if ( A124LeaveTypeId != Z124LeaveTypeId )
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
         context.RollbackDataStores("leavetype_bc",pr_default);
         VarsToRow20( bcLeaveType) ;
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
         Gx_mode = bcLeaveType.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcLeaveType.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcLeaveType )
         {
            bcLeaveType = (SdtLeaveType)(sdt);
            if ( StringUtil.StrCmp(bcLeaveType.gxTpr_Mode, "") == 0 )
            {
               bcLeaveType.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow20( bcLeaveType) ;
            }
            else
            {
               RowToVars20( bcLeaveType, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcLeaveType.gxTpr_Mode, "") == 0 )
            {
               bcLeaveType.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars20( bcLeaveType, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtLeaveType LeaveType_BC
      {
         get {
            return bcLeaveType ;
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
            return "leavetype_Execute" ;
         }

      }

      public override string ServiceExecutePermissionPrefix
      {
         get {
            return "leavetype_Services_Execute" ;
         }

      }

      public override string ServiceDeletePermissionPrefix
      {
         get {
            return "leavetype_Services_Delete" ;
         }

      }

      public override string ServiceInsertPermissionPrefix
      {
         get {
            return "leavetype_Services_Insert" ;
         }

      }

      public override string ServiceUpdatePermissionPrefix
      {
         get {
            return "leavetype_Services_Update" ;
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
         BC000I5_A124LeaveTypeId = new long[1] ;
         BC000I5_A125LeaveTypeName = new string[] {""} ;
         BC000I5_A144LeaveTypeVacationLeave = new string[] {""} ;
         BC000I5_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         BC000I5_A172LeaveTypeColorPending = new string[] {""} ;
         BC000I5_n172LeaveTypeColorPending = new bool[] {false} ;
         BC000I5_A173LeaveTypeColorApproved = new string[] {""} ;
         BC000I5_n173LeaveTypeColorApproved = new bool[] {false} ;
         BC000I5_A100CompanyId = new long[1] ;
         A125LeaveTypeName = "";
         A144LeaveTypeVacationLeave = "";
         A145LeaveTypeLoggingWorkHours = "";
         A172LeaveTypeColorPending = "";
         A173LeaveTypeColorApproved = "";
         gx_restcollection = new GXBCCollection<SdtLeaveType>( context, "LeaveType", "YTT_version4");
         sMode20 = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV7WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         AV24Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z125LeaveTypeName = "";
         Z144LeaveTypeVacationLeave = "";
         Z145LeaveTypeLoggingWorkHours = "";
         Z172LeaveTypeColorPending = "";
         Z173LeaveTypeColorApproved = "";
         BC000I6_A124LeaveTypeId = new long[1] ;
         BC000I6_A125LeaveTypeName = new string[] {""} ;
         BC000I6_A144LeaveTypeVacationLeave = new string[] {""} ;
         BC000I6_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         BC000I6_A172LeaveTypeColorPending = new string[] {""} ;
         BC000I6_n172LeaveTypeColorPending = new bool[] {false} ;
         BC000I6_A173LeaveTypeColorApproved = new string[] {""} ;
         BC000I6_n173LeaveTypeColorApproved = new bool[] {false} ;
         BC000I6_A100CompanyId = new long[1] ;
         BC000I4_A100CompanyId = new long[1] ;
         BC000I7_A124LeaveTypeId = new long[1] ;
         BC000I3_A124LeaveTypeId = new long[1] ;
         BC000I3_A125LeaveTypeName = new string[] {""} ;
         BC000I3_A144LeaveTypeVacationLeave = new string[] {""} ;
         BC000I3_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         BC000I3_A172LeaveTypeColorPending = new string[] {""} ;
         BC000I3_n172LeaveTypeColorPending = new bool[] {false} ;
         BC000I3_A173LeaveTypeColorApproved = new string[] {""} ;
         BC000I3_n173LeaveTypeColorApproved = new bool[] {false} ;
         BC000I3_A100CompanyId = new long[1] ;
         BC000I2_A124LeaveTypeId = new long[1] ;
         BC000I2_A125LeaveTypeName = new string[] {""} ;
         BC000I2_A144LeaveTypeVacationLeave = new string[] {""} ;
         BC000I2_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         BC000I2_A172LeaveTypeColorPending = new string[] {""} ;
         BC000I2_n172LeaveTypeColorPending = new bool[] {false} ;
         BC000I2_A173LeaveTypeColorApproved = new string[] {""} ;
         BC000I2_n173LeaveTypeColorApproved = new bool[] {false} ;
         BC000I2_A100CompanyId = new long[1] ;
         BC000I9_A124LeaveTypeId = new long[1] ;
         BC000I12_A127LeaveRequestId = new long[1] ;
         BC000I13_A124LeaveTypeId = new long[1] ;
         BC000I13_A125LeaveTypeName = new string[] {""} ;
         BC000I13_A144LeaveTypeVacationLeave = new string[] {""} ;
         BC000I13_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         BC000I13_A172LeaveTypeColorPending = new string[] {""} ;
         BC000I13_n172LeaveTypeColorPending = new bool[] {false} ;
         BC000I13_A173LeaveTypeColorApproved = new string[] {""} ;
         BC000I13_n173LeaveTypeColorApproved = new bool[] {false} ;
         BC000I13_A100CompanyId = new long[1] ;
         N144LeaveTypeVacationLeave = "";
         N145LeaveTypeLoggingWorkHours = "";
         i145LeaveTypeLoggingWorkHours = "";
         i144LeaveTypeVacationLeave = "";
         i173LeaveTypeColorApproved = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.leavetype_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leavetype_bc__default(),
            new Object[][] {
                new Object[] {
               BC000I2_A124LeaveTypeId, BC000I2_A125LeaveTypeName, BC000I2_A144LeaveTypeVacationLeave, BC000I2_A145LeaveTypeLoggingWorkHours, BC000I2_A172LeaveTypeColorPending, BC000I2_n172LeaveTypeColorPending, BC000I2_A173LeaveTypeColorApproved, BC000I2_n173LeaveTypeColorApproved, BC000I2_A100CompanyId
               }
               , new Object[] {
               BC000I3_A124LeaveTypeId, BC000I3_A125LeaveTypeName, BC000I3_A144LeaveTypeVacationLeave, BC000I3_A145LeaveTypeLoggingWorkHours, BC000I3_A172LeaveTypeColorPending, BC000I3_n172LeaveTypeColorPending, BC000I3_A173LeaveTypeColorApproved, BC000I3_n173LeaveTypeColorApproved, BC000I3_A100CompanyId
               }
               , new Object[] {
               BC000I4_A100CompanyId
               }
               , new Object[] {
               BC000I5_A124LeaveTypeId, BC000I5_A125LeaveTypeName, BC000I5_A144LeaveTypeVacationLeave, BC000I5_A145LeaveTypeLoggingWorkHours, BC000I5_A172LeaveTypeColorPending, BC000I5_n172LeaveTypeColorPending, BC000I5_A173LeaveTypeColorApproved, BC000I5_n173LeaveTypeColorApproved, BC000I5_A100CompanyId
               }
               , new Object[] {
               BC000I6_A124LeaveTypeId, BC000I6_A125LeaveTypeName, BC000I6_A144LeaveTypeVacationLeave, BC000I6_A145LeaveTypeLoggingWorkHours, BC000I6_A172LeaveTypeColorPending, BC000I6_n172LeaveTypeColorPending, BC000I6_A173LeaveTypeColorApproved, BC000I6_n173LeaveTypeColorApproved, BC000I6_A100CompanyId
               }
               , new Object[] {
               BC000I7_A124LeaveTypeId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000I9_A124LeaveTypeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000I12_A127LeaveRequestId
               }
               , new Object[] {
               BC000I13_A124LeaveTypeId, BC000I13_A125LeaveTypeName, BC000I13_A144LeaveTypeVacationLeave, BC000I13_A145LeaveTypeLoggingWorkHours, BC000I13_A172LeaveTypeColorPending, BC000I13_n172LeaveTypeColorPending, BC000I13_A173LeaveTypeColorApproved, BC000I13_n173LeaveTypeColorApproved, BC000I13_A100CompanyId
               }
            }
         );
         AV24Pgmname = "LeaveType_BC";
         A173LeaveTypeColorApproved = "#D5DDF6";
         n173LeaveTypeColorApproved = false;
         Z173LeaveTypeColorApproved = "#D5DDF6";
         n173LeaveTypeColorApproved = false;
         i173LeaveTypeColorApproved = "#D5DDF6";
         n173LeaveTypeColorApproved = false;
         A144LeaveTypeVacationLeave = "No";
         Z144LeaveTypeVacationLeave = "No";
         N144LeaveTypeVacationLeave = "No";
         i144LeaveTypeVacationLeave = "No";
         A145LeaveTypeLoggingWorkHours = "No";
         Z145LeaveTypeLoggingWorkHours = "No";
         N145LeaveTypeLoggingWorkHours = "No";
         i145LeaveTypeLoggingWorkHours = "No";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120I2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound20 ;
      private short Gx_BScreen ;
      private int trnEnded ;
      private int Start ;
      private int Count ;
      private int GXPagingFrom20 ;
      private int GXPagingTo20 ;
      private int AV25GXV1 ;
      private long A124LeaveTypeId ;
      private long A100CompanyId ;
      private long Z124LeaveTypeId ;
      private long AV12Insert_CompanyId ;
      private long Z100CompanyId ;
      private long GXt_int1 ;
      private long i100CompanyId ;
      private string A125LeaveTypeName ;
      private string A144LeaveTypeVacationLeave ;
      private string A145LeaveTypeLoggingWorkHours ;
      private string A172LeaveTypeColorPending ;
      private string A173LeaveTypeColorApproved ;
      private string sMode20 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV24Pgmname ;
      private string Z125LeaveTypeName ;
      private string Z144LeaveTypeVacationLeave ;
      private string Z145LeaveTypeLoggingWorkHours ;
      private string Z172LeaveTypeColorPending ;
      private string Z173LeaveTypeColorApproved ;
      private string N144LeaveTypeVacationLeave ;
      private string N145LeaveTypeLoggingWorkHours ;
      private string i145LeaveTypeLoggingWorkHours ;
      private string i144LeaveTypeVacationLeave ;
      private string i173LeaveTypeColorApproved ;
      private bool n172LeaveTypeColorPending ;
      private bool n173LeaveTypeColorApproved ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private IGxSession AV11WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtLeaveType bcLeaveType ;
      private IDataStoreProvider pr_default ;
      private long[] BC000I5_A124LeaveTypeId ;
      private string[] BC000I5_A125LeaveTypeName ;
      private string[] BC000I5_A144LeaveTypeVacationLeave ;
      private string[] BC000I5_A145LeaveTypeLoggingWorkHours ;
      private string[] BC000I5_A172LeaveTypeColorPending ;
      private bool[] BC000I5_n172LeaveTypeColorPending ;
      private string[] BC000I5_A173LeaveTypeColorApproved ;
      private bool[] BC000I5_n173LeaveTypeColorApproved ;
      private long[] BC000I5_A100CompanyId ;
      private SdtLeaveType gx_sdt_item ;
      private GXBCCollection<SdtLeaveType> gx_restcollection ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV7WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV10TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private long[] BC000I6_A124LeaveTypeId ;
      private string[] BC000I6_A125LeaveTypeName ;
      private string[] BC000I6_A144LeaveTypeVacationLeave ;
      private string[] BC000I6_A145LeaveTypeLoggingWorkHours ;
      private string[] BC000I6_A172LeaveTypeColorPending ;
      private bool[] BC000I6_n172LeaveTypeColorPending ;
      private string[] BC000I6_A173LeaveTypeColorApproved ;
      private bool[] BC000I6_n173LeaveTypeColorApproved ;
      private long[] BC000I6_A100CompanyId ;
      private long[] BC000I4_A100CompanyId ;
      private long[] BC000I7_A124LeaveTypeId ;
      private long[] BC000I3_A124LeaveTypeId ;
      private string[] BC000I3_A125LeaveTypeName ;
      private string[] BC000I3_A144LeaveTypeVacationLeave ;
      private string[] BC000I3_A145LeaveTypeLoggingWorkHours ;
      private string[] BC000I3_A172LeaveTypeColorPending ;
      private bool[] BC000I3_n172LeaveTypeColorPending ;
      private string[] BC000I3_A173LeaveTypeColorApproved ;
      private bool[] BC000I3_n173LeaveTypeColorApproved ;
      private long[] BC000I3_A100CompanyId ;
      private long[] BC000I2_A124LeaveTypeId ;
      private string[] BC000I2_A125LeaveTypeName ;
      private string[] BC000I2_A144LeaveTypeVacationLeave ;
      private string[] BC000I2_A145LeaveTypeLoggingWorkHours ;
      private string[] BC000I2_A172LeaveTypeColorPending ;
      private bool[] BC000I2_n172LeaveTypeColorPending ;
      private string[] BC000I2_A173LeaveTypeColorApproved ;
      private bool[] BC000I2_n173LeaveTypeColorApproved ;
      private long[] BC000I2_A100CompanyId ;
      private long[] BC000I9_A124LeaveTypeId ;
      private long[] BC000I12_A127LeaveRequestId ;
      private long[] BC000I13_A124LeaveTypeId ;
      private string[] BC000I13_A125LeaveTypeName ;
      private string[] BC000I13_A144LeaveTypeVacationLeave ;
      private string[] BC000I13_A145LeaveTypeLoggingWorkHours ;
      private string[] BC000I13_A172LeaveTypeColorPending ;
      private bool[] BC000I13_n172LeaveTypeColorPending ;
      private string[] BC000I13_A173LeaveTypeColorApproved ;
      private bool[] BC000I13_n173LeaveTypeColorApproved ;
      private long[] BC000I13_A100CompanyId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class leavetype_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class leavetype_bc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000I2;
        prmBC000I2 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmBC000I3;
        prmBC000I3 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmBC000I4;
        prmBC000I4 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000I5;
        prmBC000I5 = new Object[] {
        new ParDef("GXPagingFrom20",GXType.Int32,9,0) ,
        new ParDef("GXPagingTo20",GXType.Int32,9,0)
        };
        Object[] prmBC000I6;
        prmBC000I6 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmBC000I7;
        prmBC000I7 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmBC000I8;
        prmBC000I8 = new Object[] {
        new ParDef("LeaveTypeName",GXType.Char,100,0) ,
        new ParDef("LeaveTypeVacationLeave",GXType.Char,20,0) ,
        new ParDef("LeaveTypeLoggingWorkHours",GXType.Char,20,0) ,
        new ParDef("LeaveTypeColorPending",GXType.Char,20,0){Nullable=true} ,
        new ParDef("LeaveTypeColorApproved",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000I9;
        prmBC000I9 = new Object[] {
        };
        Object[] prmBC000I10;
        prmBC000I10 = new Object[] {
        new ParDef("LeaveTypeName",GXType.Char,100,0) ,
        new ParDef("LeaveTypeVacationLeave",GXType.Char,20,0) ,
        new ParDef("LeaveTypeLoggingWorkHours",GXType.Char,20,0) ,
        new ParDef("LeaveTypeColorPending",GXType.Char,20,0){Nullable=true} ,
        new ParDef("LeaveTypeColorApproved",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CompanyId",GXType.Int64,10,0) ,
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmBC000I11;
        prmBC000I11 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmBC000I12;
        prmBC000I12 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmBC000I13;
        prmBC000I13 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000I2", "SELECT LeaveTypeId, LeaveTypeName, LeaveTypeVacationLeave, LeaveTypeLoggingWorkHours, LeaveTypeColorPending, LeaveTypeColorApproved, CompanyId FROM LeaveType WHERE LeaveTypeId = :LeaveTypeId  FOR UPDATE OF LeaveType",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I3", "SELECT LeaveTypeId, LeaveTypeName, LeaveTypeVacationLeave, LeaveTypeLoggingWorkHours, LeaveTypeColorPending, LeaveTypeColorApproved, CompanyId FROM LeaveType WHERE LeaveTypeId = :LeaveTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I4", "SELECT CompanyId FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I5", "SELECT TM1.LeaveTypeId, TM1.LeaveTypeName, TM1.LeaveTypeVacationLeave, TM1.LeaveTypeLoggingWorkHours, TM1.LeaveTypeColorPending, TM1.LeaveTypeColorApproved, TM1.CompanyId FROM LeaveType TM1 ORDER BY TM1.LeaveTypeId  OFFSET :GXPagingFrom20 LIMIT CASE WHEN :GXPagingTo20 > 0 THEN :GXPagingTo20 ELSE 1e9 END",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I6", "SELECT TM1.LeaveTypeId, TM1.LeaveTypeName, TM1.LeaveTypeVacationLeave, TM1.LeaveTypeLoggingWorkHours, TM1.LeaveTypeColorPending, TM1.LeaveTypeColorApproved, TM1.CompanyId FROM LeaveType TM1 WHERE TM1.LeaveTypeId = :LeaveTypeId ORDER BY TM1.LeaveTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I7", "SELECT LeaveTypeId FROM LeaveType WHERE LeaveTypeId = :LeaveTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I8", "SAVEPOINT gxupdate;INSERT INTO LeaveType(LeaveTypeName, LeaveTypeVacationLeave, LeaveTypeLoggingWorkHours, LeaveTypeColorPending, LeaveTypeColorApproved, CompanyId) VALUES(:LeaveTypeName, :LeaveTypeVacationLeave, :LeaveTypeLoggingWorkHours, :LeaveTypeColorPending, :LeaveTypeColorApproved, :CompanyId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000I8)
           ,new CursorDef("BC000I9", "SELECT currval('LeaveTypeId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I10", "SAVEPOINT gxupdate;UPDATE LeaveType SET LeaveTypeName=:LeaveTypeName, LeaveTypeVacationLeave=:LeaveTypeVacationLeave, LeaveTypeLoggingWorkHours=:LeaveTypeLoggingWorkHours, LeaveTypeColorPending=:LeaveTypeColorPending, LeaveTypeColorApproved=:LeaveTypeColorApproved, CompanyId=:CompanyId  WHERE LeaveTypeId = :LeaveTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000I10)
           ,new CursorDef("BC000I11", "SAVEPOINT gxupdate;DELETE FROM LeaveType  WHERE LeaveTypeId = :LeaveTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000I11)
           ,new CursorDef("BC000I12", "SELECT LeaveRequestId FROM LeaveRequest WHERE LeaveTypeId = :LeaveTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000I13", "SELECT TM1.LeaveTypeId, TM1.LeaveTypeName, TM1.LeaveTypeVacationLeave, TM1.LeaveTypeLoggingWorkHours, TM1.LeaveTypeColorPending, TM1.LeaveTypeColorApproved, TM1.CompanyId FROM LeaveType TM1 WHERE TM1.LeaveTypeId = :LeaveTypeId ORDER BY TM1.LeaveTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I13,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((long[]) buf[8])[0] = rslt.getLong(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((long[]) buf[8])[0] = rslt.getLong(7);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((long[]) buf[8])[0] = rslt.getLong(7);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((long[]) buf[8])[0] = rslt.getLong(7);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((long[]) buf[8])[0] = rslt.getLong(7);
              return;
     }
  }

}

}
