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
   public class workhourlog_bc : GxSilentTrn, IGxSilentTrn
   {
      public workhourlog_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workhourlog_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public GXBCCollection<SdtWorkHourLog> GetAll( int Start ,
                                                    int Count )
      {
         GXPagingFrom19 = Start;
         GXPagingTo19 = Count;
         /* Using cursor BC000H7 */
         pr_default.execute(5, new Object[] {GXPagingFrom19, GXPagingTo19});
         RcdFound19 = 0;
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound19 = 1;
            A147EmployeeBalance = BC000H7_A147EmployeeBalance[0];
            A118WorkHourLogId = BC000H7_A118WorkHourLogId[0];
            A119WorkHourLogDate = BC000H7_A119WorkHourLogDate[0];
            A120WorkHourLogDuration = BC000H7_A120WorkHourLogDuration[0];
            A121WorkHourLogHour = BC000H7_A121WorkHourLogHour[0];
            A122WorkHourLogMinute = BC000H7_A122WorkHourLogMinute[0];
            A123WorkHourLogDescription = BC000H7_A123WorkHourLogDescription[0];
            A107EmployeeFirstName = BC000H7_A107EmployeeFirstName[0];
            A103ProjectName = BC000H7_A103ProjectName[0];
            A106EmployeeId = BC000H7_A106EmployeeId[0];
            A102ProjectId = BC000H7_A102ProjectId[0];
         }
         bcWorkHourLog = new SdtWorkHourLog(context);
         gx_restcollection.Clear();
         while ( RcdFound19 != 0 )
         {
            OnLoadActions0H19( ) ;
            AddRow0H19( ) ;
            gx_sdt_item = (SdtWorkHourLog)(bcWorkHourLog.Clone());
            gx_restcollection.Add(gx_sdt_item, 0);
            pr_default.readNext(5);
            RcdFound19 = 0;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            if ( (pr_default.getStatus(5) != 101) )
            {
               RcdFound19 = 1;
               A147EmployeeBalance = BC000H7_A147EmployeeBalance[0];
               A118WorkHourLogId = BC000H7_A118WorkHourLogId[0];
               A119WorkHourLogDate = BC000H7_A119WorkHourLogDate[0];
               A120WorkHourLogDuration = BC000H7_A120WorkHourLogDuration[0];
               A121WorkHourLogHour = BC000H7_A121WorkHourLogHour[0];
               A122WorkHourLogMinute = BC000H7_A122WorkHourLogMinute[0];
               A123WorkHourLogDescription = BC000H7_A123WorkHourLogDescription[0];
               A107EmployeeFirstName = BC000H7_A107EmployeeFirstName[0];
               A103ProjectName = BC000H7_A103ProjectName[0];
               A106EmployeeId = BC000H7_A106EmployeeId[0];
               A102ProjectId = BC000H7_A102ProjectId[0];
            }
            Gx_mode = sMode19;
         }
         pr_default.close(5);
         /* Load Subordinate Levels */
         return gx_restcollection ;
      }

      protected void SETSEUDOVARS( )
      {
         ZM0H19( 0) ;
      }

      public void GetInsDefault( )
      {
         ReadRow0H19( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0H19( ) ;
         standaloneModal( ) ;
         AddRow0H19( ) ;
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
            E110H2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z118WorkHourLogId = A118WorkHourLogId;
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

      protected void CONFIRM_0H0( )
      {
         BeforeValidate0H19( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0H19( ) ;
            }
            else
            {
               CheckExtendedTable0H19( ) ;
               if ( AnyError == 0 )
               {
                  ZM0H19( 4) ;
                  ZM0H19( 5) ;
                  ZM0H19( 6) ;
               }
               CloseExtendedTableCursors0H19( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120H2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV27Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV28GXV1 = 1;
            while ( AV28GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV28GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "EmployeeId") == 0 )
               {
                  AV13Insert_EmployeeId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "ProjectId") == 0 )
               {
                  AV14Insert_ProjectId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV28GXV1 = (int)(AV28GXV1+1);
            }
         }
      }

      protected void E110H2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0H19( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z119WorkHourLogDate = A119WorkHourLogDate;
            Z120WorkHourLogDuration = A120WorkHourLogDuration;
            Z121WorkHourLogHour = A121WorkHourLogHour;
            Z122WorkHourLogMinute = A122WorkHourLogMinute;
            Z106EmployeeId = A106EmployeeId;
            Z102ProjectId = A102ProjectId;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z147EmployeeBalance = A147EmployeeBalance;
            Z107EmployeeFirstName = A107EmployeeFirstName;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z103ProjectName = A103ProjectName;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -3 )
         {
            Z118WorkHourLogId = A118WorkHourLogId;
            Z119WorkHourLogDate = A119WorkHourLogDate;
            Z120WorkHourLogDuration = A120WorkHourLogDuration;
            Z121WorkHourLogHour = A121WorkHourLogHour;
            Z122WorkHourLogMinute = A122WorkHourLogMinute;
            Z123WorkHourLogDescription = A123WorkHourLogDescription;
            Z106EmployeeId = A106EmployeeId;
            Z102ProjectId = A102ProjectId;
            Z147EmployeeBalance = A147EmployeeBalance;
            Z107EmployeeFirstName = A107EmployeeFirstName;
            Z103ProjectName = A103ProjectName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV27Pgmname = "WorkHourLog_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0H19( )
      {
         /* Using cursor BC000H8 */
         pr_default.execute(6, new Object[] {A118WorkHourLogId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound19 = 1;
            A147EmployeeBalance = BC000H8_A147EmployeeBalance[0];
            A119WorkHourLogDate = BC000H8_A119WorkHourLogDate[0];
            A120WorkHourLogDuration = BC000H8_A120WorkHourLogDuration[0];
            A121WorkHourLogHour = BC000H8_A121WorkHourLogHour[0];
            A122WorkHourLogMinute = BC000H8_A122WorkHourLogMinute[0];
            A123WorkHourLogDescription = BC000H8_A123WorkHourLogDescription[0];
            A107EmployeeFirstName = BC000H8_A107EmployeeFirstName[0];
            A103ProjectName = BC000H8_A103ProjectName[0];
            A106EmployeeId = BC000H8_A106EmployeeId[0];
            A102ProjectId = BC000H8_A102ProjectId[0];
            ZM0H19( -3) ;
         }
         pr_default.close(6);
         OnLoadActions0H19( ) ;
      }

      protected void OnLoadActions0H19( )
      {
      }

      protected void CheckExtendedTable0H19( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000H4 */
         pr_default.execute(2, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
         }
         A147EmployeeBalance = BC000H4_A147EmployeeBalance[0];
         A107EmployeeFirstName = BC000H4_A107EmployeeFirstName[0];
         pr_default.close(2);
         /* Using cursor BC000H6 */
         pr_default.execute(4, new Object[] {A106EmployeeId, A102ProjectId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "PROJECTID");
            AnyError = 1;
         }
         pr_default.close(4);
         /* Using cursor BC000H5 */
         pr_default.execute(3, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'Project'.", "ForeignKeyNotFound", 1, "PROJECTID");
            AnyError = 1;
         }
         A103ProjectName = BC000H5_A103ProjectName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0H19( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0H19( )
      {
         /* Using cursor BC000H9 */
         pr_default.execute(7, new Object[] {A118WorkHourLogId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000H3 */
         pr_default.execute(1, new Object[] {A118WorkHourLogId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0H19( 3) ;
            RcdFound19 = 1;
            A118WorkHourLogId = BC000H3_A118WorkHourLogId[0];
            A119WorkHourLogDate = BC000H3_A119WorkHourLogDate[0];
            A120WorkHourLogDuration = BC000H3_A120WorkHourLogDuration[0];
            A121WorkHourLogHour = BC000H3_A121WorkHourLogHour[0];
            A122WorkHourLogMinute = BC000H3_A122WorkHourLogMinute[0];
            A123WorkHourLogDescription = BC000H3_A123WorkHourLogDescription[0];
            A106EmployeeId = BC000H3_A106EmployeeId[0];
            A102ProjectId = BC000H3_A102ProjectId[0];
            Z118WorkHourLogId = A118WorkHourLogId;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0H19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0H19( ) ;
            }
            Gx_mode = sMode19;
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0H19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode19;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0H19( ) ;
         if ( RcdFound19 == 0 )
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
         CONFIRM_0H0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0H19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000H2 */
            pr_default.execute(0, new Object[] {A118WorkHourLogId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WorkHourLog"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z119WorkHourLogDate ) != DateTimeUtil.ResetTime ( BC000H2_A119WorkHourLogDate[0] ) ) || ( StringUtil.StrCmp(Z120WorkHourLogDuration, BC000H2_A120WorkHourLogDuration[0]) != 0 ) || ( Z121WorkHourLogHour != BC000H2_A121WorkHourLogHour[0] ) || ( Z122WorkHourLogMinute != BC000H2_A122WorkHourLogMinute[0] ) || ( Z106EmployeeId != BC000H2_A106EmployeeId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z102ProjectId != BC000H2_A102ProjectId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WorkHourLog"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H19( )
      {
         BeforeValidate0H19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H19( 0) ;
            CheckOptimisticConcurrency0H19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000H10 */
                     pr_default.execute(8, new Object[] {A119WorkHourLogDate, A120WorkHourLogDuration, A121WorkHourLogHour, A122WorkHourLogMinute, A123WorkHourLogDescription, A106EmployeeId, A102ProjectId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000H11 */
                     pr_default.execute(9);
                     A118WorkHourLogId = BC000H11_A118WorkHourLogId[0];
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WorkHourLog");
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
               Load0H19( ) ;
            }
            EndLevel0H19( ) ;
         }
         CloseExtendedTableCursors0H19( ) ;
      }

      protected void Update0H19( )
      {
         BeforeValidate0H19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0H19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000H12 */
                     pr_default.execute(10, new Object[] {A119WorkHourLogDate, A120WorkHourLogDuration, A121WorkHourLogHour, A122WorkHourLogMinute, A123WorkHourLogDescription, A106EmployeeId, A102ProjectId, A118WorkHourLogId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("WorkHourLog");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WorkHourLog"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0H19( ) ;
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
            EndLevel0H19( ) ;
         }
         CloseExtendedTableCursors0H19( ) ;
      }

      protected void DeferredUpdate0H19( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0H19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H19( ) ;
            AfterConfirm0H19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000H13 */
                  pr_default.execute(11, new Object[] {A118WorkHourLogId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("WorkHourLog");
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
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0H19( ) ;
         Gx_mode = sMode19;
      }

      protected void OnDeleteControls0H19( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000H14 */
            pr_default.execute(12, new Object[] {A106EmployeeId});
            A147EmployeeBalance = BC000H14_A147EmployeeBalance[0];
            A107EmployeeFirstName = BC000H14_A107EmployeeFirstName[0];
            pr_default.close(12);
            /* Using cursor BC000H15 */
            pr_default.execute(13, new Object[] {A102ProjectId});
            A103ProjectName = BC000H15_A103ProjectName[0];
            pr_default.close(13);
         }
      }

      protected void EndLevel0H19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0H19( ) ;
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

      public void ScanKeyStart0H19( )
      {
         /* Scan By routine */
         /* Using cursor BC000H16 */
         pr_default.execute(14, new Object[] {A118WorkHourLogId});
         RcdFound19 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound19 = 1;
            A147EmployeeBalance = BC000H16_A147EmployeeBalance[0];
            A118WorkHourLogId = BC000H16_A118WorkHourLogId[0];
            A119WorkHourLogDate = BC000H16_A119WorkHourLogDate[0];
            A120WorkHourLogDuration = BC000H16_A120WorkHourLogDuration[0];
            A121WorkHourLogHour = BC000H16_A121WorkHourLogHour[0];
            A122WorkHourLogMinute = BC000H16_A122WorkHourLogMinute[0];
            A123WorkHourLogDescription = BC000H16_A123WorkHourLogDescription[0];
            A107EmployeeFirstName = BC000H16_A107EmployeeFirstName[0];
            A103ProjectName = BC000H16_A103ProjectName[0];
            A106EmployeeId = BC000H16_A106EmployeeId[0];
            A102ProjectId = BC000H16_A102ProjectId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0H19( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound19 = 0;
         ScanKeyLoad0H19( ) ;
      }

      protected void ScanKeyLoad0H19( )
      {
         sMode19 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound19 = 1;
            A147EmployeeBalance = BC000H16_A147EmployeeBalance[0];
            A118WorkHourLogId = BC000H16_A118WorkHourLogId[0];
            A119WorkHourLogDate = BC000H16_A119WorkHourLogDate[0];
            A120WorkHourLogDuration = BC000H16_A120WorkHourLogDuration[0];
            A121WorkHourLogHour = BC000H16_A121WorkHourLogHour[0];
            A122WorkHourLogMinute = BC000H16_A122WorkHourLogMinute[0];
            A123WorkHourLogDescription = BC000H16_A123WorkHourLogDescription[0];
            A107EmployeeFirstName = BC000H16_A107EmployeeFirstName[0];
            A103ProjectName = BC000H16_A103ProjectName[0];
            A106EmployeeId = BC000H16_A106EmployeeId[0];
            A102ProjectId = BC000H16_A102ProjectId[0];
         }
         Gx_mode = sMode19;
      }

      protected void ScanKeyEnd0H19( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0H19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0H19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0H19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H19( )
      {
      }

      protected void send_integrity_lvl_hashes0H19( )
      {
      }

      protected void AddRow0H19( )
      {
         VarsToRow19( bcWorkHourLog) ;
      }

      protected void ReadRow0H19( )
      {
         RowToVars19( bcWorkHourLog, 1) ;
      }

      protected void InitializeNonKey0H19( )
      {
         A147EmployeeBalance = 0;
         A119WorkHourLogDate = DateTime.MinValue;
         A120WorkHourLogDuration = "";
         A121WorkHourLogHour = 0;
         A122WorkHourLogMinute = 0;
         A123WorkHourLogDescription = "";
         A106EmployeeId = 0;
         A107EmployeeFirstName = "";
         A102ProjectId = 0;
         A103ProjectName = "";
         Z119WorkHourLogDate = DateTime.MinValue;
         Z120WorkHourLogDuration = "";
         Z121WorkHourLogHour = 0;
         Z122WorkHourLogMinute = 0;
         Z106EmployeeId = 0;
         Z102ProjectId = 0;
      }

      protected void InitAll0H19( )
      {
         A118WorkHourLogId = 0;
         InitializeNonKey0H19( ) ;
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

      public void VarsToRow19( SdtWorkHourLog obj19 )
      {
         obj19.gxTpr_Mode = Gx_mode;
         obj19.gxTpr_Workhourlogdate = A119WorkHourLogDate;
         obj19.gxTpr_Workhourlogduration = A120WorkHourLogDuration;
         obj19.gxTpr_Workhourloghour = A121WorkHourLogHour;
         obj19.gxTpr_Workhourlogminute = A122WorkHourLogMinute;
         obj19.gxTpr_Workhourlogdescription = A123WorkHourLogDescription;
         obj19.gxTpr_Employeeid = A106EmployeeId;
         obj19.gxTpr_Employeefirstname = A107EmployeeFirstName;
         obj19.gxTpr_Projectid = A102ProjectId;
         obj19.gxTpr_Projectname = A103ProjectName;
         obj19.gxTpr_Workhourlogid = A118WorkHourLogId;
         obj19.gxTpr_Workhourlogid_Z = Z118WorkHourLogId;
         obj19.gxTpr_Workhourlogdate_Z = Z119WorkHourLogDate;
         obj19.gxTpr_Workhourlogduration_Z = Z120WorkHourLogDuration;
         obj19.gxTpr_Workhourloghour_Z = Z121WorkHourLogHour;
         obj19.gxTpr_Workhourlogminute_Z = Z122WorkHourLogMinute;
         obj19.gxTpr_Employeeid_Z = Z106EmployeeId;
         obj19.gxTpr_Employeefirstname_Z = Z107EmployeeFirstName;
         obj19.gxTpr_Projectid_Z = Z102ProjectId;
         obj19.gxTpr_Projectname_Z = Z103ProjectName;
         obj19.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow19( SdtWorkHourLog obj19 )
      {
         obj19.gxTpr_Workhourlogid = A118WorkHourLogId;
         return  ;
      }

      public void RowToVars19( SdtWorkHourLog obj19 ,
                               int forceLoad )
      {
         Gx_mode = obj19.gxTpr_Mode;
         A119WorkHourLogDate = obj19.gxTpr_Workhourlogdate;
         A120WorkHourLogDuration = obj19.gxTpr_Workhourlogduration;
         A121WorkHourLogHour = obj19.gxTpr_Workhourloghour;
         A122WorkHourLogMinute = obj19.gxTpr_Workhourlogminute;
         A123WorkHourLogDescription = obj19.gxTpr_Workhourlogdescription;
         A106EmployeeId = obj19.gxTpr_Employeeid;
         A107EmployeeFirstName = obj19.gxTpr_Employeefirstname;
         A102ProjectId = obj19.gxTpr_Projectid;
         A103ProjectName = obj19.gxTpr_Projectname;
         A118WorkHourLogId = obj19.gxTpr_Workhourlogid;
         Z118WorkHourLogId = obj19.gxTpr_Workhourlogid_Z;
         Z119WorkHourLogDate = obj19.gxTpr_Workhourlogdate_Z;
         Z120WorkHourLogDuration = obj19.gxTpr_Workhourlogduration_Z;
         Z121WorkHourLogHour = obj19.gxTpr_Workhourloghour_Z;
         Z122WorkHourLogMinute = obj19.gxTpr_Workhourlogminute_Z;
         Z106EmployeeId = obj19.gxTpr_Employeeid_Z;
         Z107EmployeeFirstName = obj19.gxTpr_Employeefirstname_Z;
         Z102ProjectId = obj19.gxTpr_Projectid_Z;
         Z103ProjectName = obj19.gxTpr_Projectname_Z;
         Gx_mode = obj19.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A118WorkHourLogId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0H19( ) ;
         ScanKeyStart0H19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z118WorkHourLogId = A118WorkHourLogId;
         }
         ZM0H19( -3) ;
         OnLoadActions0H19( ) ;
         AddRow0H19( ) ;
         ScanKeyEnd0H19( ) ;
         if ( RcdFound19 == 0 )
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
         RowToVars19( bcWorkHourLog, 0) ;
         ScanKeyStart0H19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z118WorkHourLogId = A118WorkHourLogId;
         }
         ZM0H19( -3) ;
         OnLoadActions0H19( ) ;
         AddRow0H19( ) ;
         ScanKeyEnd0H19( ) ;
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0H19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0H19( ) ;
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( A118WorkHourLogId != Z118WorkHourLogId )
               {
                  A118WorkHourLogId = Z118WorkHourLogId;
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
                  Update0H19( ) ;
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
                  if ( A118WorkHourLogId != Z118WorkHourLogId )
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
                        Insert0H19( ) ;
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
                        Insert0H19( ) ;
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
         RowToVars19( bcWorkHourLog, 1) ;
         SaveImpl( ) ;
         VarsToRow19( bcWorkHourLog) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars19( bcWorkHourLog, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H19( ) ;
         AfterTrn( ) ;
         VarsToRow19( bcWorkHourLog) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow19( bcWorkHourLog) ;
         }
         else
         {
            SdtWorkHourLog auxBC = new SdtWorkHourLog(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A118WorkHourLogId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcWorkHourLog);
               auxBC.Save();
               bcWorkHourLog.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars19( bcWorkHourLog, 1) ;
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
         RowToVars19( bcWorkHourLog, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H19( ) ;
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
               VarsToRow19( bcWorkHourLog) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow19( bcWorkHourLog) ;
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
         RowToVars19( bcWorkHourLog, 0) ;
         GetKey0H19( ) ;
         if ( RcdFound19 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A118WorkHourLogId != Z118WorkHourLogId )
            {
               A118WorkHourLogId = Z118WorkHourLogId;
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
            if ( A118WorkHourLogId != Z118WorkHourLogId )
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
         context.RollbackDataStores("workhourlog_bc",pr_default);
         VarsToRow19( bcWorkHourLog) ;
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
         Gx_mode = bcWorkHourLog.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcWorkHourLog.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcWorkHourLog )
         {
            bcWorkHourLog = (SdtWorkHourLog)(sdt);
            if ( StringUtil.StrCmp(bcWorkHourLog.gxTpr_Mode, "") == 0 )
            {
               bcWorkHourLog.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow19( bcWorkHourLog) ;
            }
            else
            {
               RowToVars19( bcWorkHourLog, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcWorkHourLog.gxTpr_Mode, "") == 0 )
            {
               bcWorkHourLog.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars19( bcWorkHourLog, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWorkHourLog WorkHourLog_BC
      {
         get {
            return bcWorkHourLog ;
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
            return "workhourlog_Execute" ;
         }

      }

      public override string ServiceExecutePermissionPrefix
      {
         get {
            return "workhourlog_Services_Execute" ;
         }

      }

      public override string ServiceDeletePermissionPrefix
      {
         get {
            return "workhourlog_Services_Delete" ;
         }

      }

      public override string ServiceInsertPermissionPrefix
      {
         get {
            return "workhourlog_Services_Insert" ;
         }

      }

      public override string ServiceUpdatePermissionPrefix
      {
         get {
            return "workhourlog_Services_Update" ;
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
         pr_default.close(12);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         BC000H7_A147EmployeeBalance = new decimal[1] ;
         BC000H7_A118WorkHourLogId = new long[1] ;
         BC000H7_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         BC000H7_A120WorkHourLogDuration = new string[] {""} ;
         BC000H7_A121WorkHourLogHour = new short[1] ;
         BC000H7_A122WorkHourLogMinute = new short[1] ;
         BC000H7_A123WorkHourLogDescription = new string[] {""} ;
         BC000H7_A107EmployeeFirstName = new string[] {""} ;
         BC000H7_A103ProjectName = new string[] {""} ;
         BC000H7_A106EmployeeId = new long[1] ;
         BC000H7_A102ProjectId = new long[1] ;
         A119WorkHourLogDate = DateTime.MinValue;
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         A107EmployeeFirstName = "";
         A103ProjectName = "";
         gx_restcollection = new GXBCCollection<SdtWorkHourLog>( context, "WorkHourLog", "YTT_version4");
         sMode19 = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV27Pgmname = "";
         AV15TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z119WorkHourLogDate = DateTime.MinValue;
         Z120WorkHourLogDuration = "";
         Z107EmployeeFirstName = "";
         Z103ProjectName = "";
         Z123WorkHourLogDescription = "";
         BC000H8_A147EmployeeBalance = new decimal[1] ;
         BC000H8_A118WorkHourLogId = new long[1] ;
         BC000H8_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         BC000H8_A120WorkHourLogDuration = new string[] {""} ;
         BC000H8_A121WorkHourLogHour = new short[1] ;
         BC000H8_A122WorkHourLogMinute = new short[1] ;
         BC000H8_A123WorkHourLogDescription = new string[] {""} ;
         BC000H8_A107EmployeeFirstName = new string[] {""} ;
         BC000H8_A103ProjectName = new string[] {""} ;
         BC000H8_A106EmployeeId = new long[1] ;
         BC000H8_A102ProjectId = new long[1] ;
         BC000H4_A147EmployeeBalance = new decimal[1] ;
         BC000H4_A107EmployeeFirstName = new string[] {""} ;
         BC000H6_A106EmployeeId = new long[1] ;
         BC000H5_A103ProjectName = new string[] {""} ;
         BC000H9_A118WorkHourLogId = new long[1] ;
         BC000H3_A118WorkHourLogId = new long[1] ;
         BC000H3_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         BC000H3_A120WorkHourLogDuration = new string[] {""} ;
         BC000H3_A121WorkHourLogHour = new short[1] ;
         BC000H3_A122WorkHourLogMinute = new short[1] ;
         BC000H3_A123WorkHourLogDescription = new string[] {""} ;
         BC000H3_A106EmployeeId = new long[1] ;
         BC000H3_A102ProjectId = new long[1] ;
         BC000H2_A118WorkHourLogId = new long[1] ;
         BC000H2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         BC000H2_A120WorkHourLogDuration = new string[] {""} ;
         BC000H2_A121WorkHourLogHour = new short[1] ;
         BC000H2_A122WorkHourLogMinute = new short[1] ;
         BC000H2_A123WorkHourLogDescription = new string[] {""} ;
         BC000H2_A106EmployeeId = new long[1] ;
         BC000H2_A102ProjectId = new long[1] ;
         BC000H11_A118WorkHourLogId = new long[1] ;
         BC000H14_A147EmployeeBalance = new decimal[1] ;
         BC000H14_A107EmployeeFirstName = new string[] {""} ;
         BC000H15_A103ProjectName = new string[] {""} ;
         BC000H16_A147EmployeeBalance = new decimal[1] ;
         BC000H16_A118WorkHourLogId = new long[1] ;
         BC000H16_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         BC000H16_A120WorkHourLogDuration = new string[] {""} ;
         BC000H16_A121WorkHourLogHour = new short[1] ;
         BC000H16_A122WorkHourLogMinute = new short[1] ;
         BC000H16_A123WorkHourLogDescription = new string[] {""} ;
         BC000H16_A107EmployeeFirstName = new string[] {""} ;
         BC000H16_A103ProjectName = new string[] {""} ;
         BC000H16_A106EmployeeId = new long[1] ;
         BC000H16_A102ProjectId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workhourlog_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workhourlog_bc__default(),
            new Object[][] {
                new Object[] {
               BC000H2_A118WorkHourLogId, BC000H2_A119WorkHourLogDate, BC000H2_A120WorkHourLogDuration, BC000H2_A121WorkHourLogHour, BC000H2_A122WorkHourLogMinute, BC000H2_A123WorkHourLogDescription, BC000H2_A106EmployeeId, BC000H2_A102ProjectId
               }
               , new Object[] {
               BC000H3_A118WorkHourLogId, BC000H3_A119WorkHourLogDate, BC000H3_A120WorkHourLogDuration, BC000H3_A121WorkHourLogHour, BC000H3_A122WorkHourLogMinute, BC000H3_A123WorkHourLogDescription, BC000H3_A106EmployeeId, BC000H3_A102ProjectId
               }
               , new Object[] {
               BC000H4_A147EmployeeBalance, BC000H4_A107EmployeeFirstName
               }
               , new Object[] {
               BC000H5_A103ProjectName
               }
               , new Object[] {
               BC000H6_A106EmployeeId
               }
               , new Object[] {
               BC000H7_A147EmployeeBalance, BC000H7_A118WorkHourLogId, BC000H7_A119WorkHourLogDate, BC000H7_A120WorkHourLogDuration, BC000H7_A121WorkHourLogHour, BC000H7_A122WorkHourLogMinute, BC000H7_A123WorkHourLogDescription, BC000H7_A107EmployeeFirstName, BC000H7_A103ProjectName, BC000H7_A106EmployeeId,
               BC000H7_A102ProjectId
               }
               , new Object[] {
               BC000H8_A147EmployeeBalance, BC000H8_A118WorkHourLogId, BC000H8_A119WorkHourLogDate, BC000H8_A120WorkHourLogDuration, BC000H8_A121WorkHourLogHour, BC000H8_A122WorkHourLogMinute, BC000H8_A123WorkHourLogDescription, BC000H8_A107EmployeeFirstName, BC000H8_A103ProjectName, BC000H8_A106EmployeeId,
               BC000H8_A102ProjectId
               }
               , new Object[] {
               BC000H9_A118WorkHourLogId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000H11_A118WorkHourLogId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000H14_A147EmployeeBalance, BC000H14_A107EmployeeFirstName
               }
               , new Object[] {
               BC000H15_A103ProjectName
               }
               , new Object[] {
               BC000H16_A147EmployeeBalance, BC000H16_A118WorkHourLogId, BC000H16_A119WorkHourLogDate, BC000H16_A120WorkHourLogDuration, BC000H16_A121WorkHourLogHour, BC000H16_A122WorkHourLogMinute, BC000H16_A123WorkHourLogDescription, BC000H16_A107EmployeeFirstName, BC000H16_A103ProjectName, BC000H16_A106EmployeeId,
               BC000H16_A102ProjectId
               }
            }
         );
         AV27Pgmname = "WorkHourLog_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120H2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound19 ;
      private short A121WorkHourLogHour ;
      private short A122WorkHourLogMinute ;
      private short Z121WorkHourLogHour ;
      private short Z122WorkHourLogMinute ;
      private int trnEnded ;
      private int Start ;
      private int Count ;
      private int GXPagingFrom19 ;
      private int GXPagingTo19 ;
      private int AV28GXV1 ;
      private long A118WorkHourLogId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long Z118WorkHourLogId ;
      private long AV13Insert_EmployeeId ;
      private long AV14Insert_ProjectId ;
      private long Z106EmployeeId ;
      private long Z102ProjectId ;
      private decimal A147EmployeeBalance ;
      private decimal Z147EmployeeBalance ;
      private string A107EmployeeFirstName ;
      private string A103ProjectName ;
      private string sMode19 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV27Pgmname ;
      private string Z107EmployeeFirstName ;
      private string Z103ProjectName ;
      private DateTime A119WorkHourLogDate ;
      private DateTime Z119WorkHourLogDate ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string A123WorkHourLogDescription ;
      private string Z123WorkHourLogDescription ;
      private string A120WorkHourLogDuration ;
      private string Z120WorkHourLogDuration ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtWorkHourLog bcWorkHourLog ;
      private IDataStoreProvider pr_default ;
      private decimal[] BC000H7_A147EmployeeBalance ;
      private long[] BC000H7_A118WorkHourLogId ;
      private DateTime[] BC000H7_A119WorkHourLogDate ;
      private string[] BC000H7_A120WorkHourLogDuration ;
      private short[] BC000H7_A121WorkHourLogHour ;
      private short[] BC000H7_A122WorkHourLogMinute ;
      private string[] BC000H7_A123WorkHourLogDescription ;
      private string[] BC000H7_A107EmployeeFirstName ;
      private string[] BC000H7_A103ProjectName ;
      private long[] BC000H7_A106EmployeeId ;
      private long[] BC000H7_A102ProjectId ;
      private SdtWorkHourLog gx_sdt_item ;
      private GXBCCollection<SdtWorkHourLog> gx_restcollection ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private decimal[] BC000H8_A147EmployeeBalance ;
      private long[] BC000H8_A118WorkHourLogId ;
      private DateTime[] BC000H8_A119WorkHourLogDate ;
      private string[] BC000H8_A120WorkHourLogDuration ;
      private short[] BC000H8_A121WorkHourLogHour ;
      private short[] BC000H8_A122WorkHourLogMinute ;
      private string[] BC000H8_A123WorkHourLogDescription ;
      private string[] BC000H8_A107EmployeeFirstName ;
      private string[] BC000H8_A103ProjectName ;
      private long[] BC000H8_A106EmployeeId ;
      private long[] BC000H8_A102ProjectId ;
      private decimal[] BC000H4_A147EmployeeBalance ;
      private string[] BC000H4_A107EmployeeFirstName ;
      private long[] BC000H6_A106EmployeeId ;
      private string[] BC000H5_A103ProjectName ;
      private long[] BC000H9_A118WorkHourLogId ;
      private long[] BC000H3_A118WorkHourLogId ;
      private DateTime[] BC000H3_A119WorkHourLogDate ;
      private string[] BC000H3_A120WorkHourLogDuration ;
      private short[] BC000H3_A121WorkHourLogHour ;
      private short[] BC000H3_A122WorkHourLogMinute ;
      private string[] BC000H3_A123WorkHourLogDescription ;
      private long[] BC000H3_A106EmployeeId ;
      private long[] BC000H3_A102ProjectId ;
      private long[] BC000H2_A118WorkHourLogId ;
      private DateTime[] BC000H2_A119WorkHourLogDate ;
      private string[] BC000H2_A120WorkHourLogDuration ;
      private short[] BC000H2_A121WorkHourLogHour ;
      private short[] BC000H2_A122WorkHourLogMinute ;
      private string[] BC000H2_A123WorkHourLogDescription ;
      private long[] BC000H2_A106EmployeeId ;
      private long[] BC000H2_A102ProjectId ;
      private long[] BC000H11_A118WorkHourLogId ;
      private decimal[] BC000H14_A147EmployeeBalance ;
      private string[] BC000H14_A107EmployeeFirstName ;
      private string[] BC000H15_A103ProjectName ;
      private decimal[] BC000H16_A147EmployeeBalance ;
      private long[] BC000H16_A118WorkHourLogId ;
      private DateTime[] BC000H16_A119WorkHourLogDate ;
      private string[] BC000H16_A120WorkHourLogDuration ;
      private short[] BC000H16_A121WorkHourLogHour ;
      private short[] BC000H16_A122WorkHourLogMinute ;
      private string[] BC000H16_A123WorkHourLogDescription ;
      private string[] BC000H16_A107EmployeeFirstName ;
      private string[] BC000H16_A103ProjectName ;
      private long[] BC000H16_A106EmployeeId ;
      private long[] BC000H16_A102ProjectId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class workhourlog_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class workhourlog_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000H2;
        prmBC000H2 = new Object[] {
        new ParDef("WorkHourLogId",GXType.Int64,10,0)
        };
        Object[] prmBC000H3;
        prmBC000H3 = new Object[] {
        new ParDef("WorkHourLogId",GXType.Int64,10,0)
        };
        Object[] prmBC000H4;
        prmBC000H4 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000H5;
        prmBC000H5 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000H6;
        prmBC000H6 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000H7;
        prmBC000H7 = new Object[] {
        new ParDef("GXPagingFrom19",GXType.Int32,9,0) ,
        new ParDef("GXPagingTo19",GXType.Int32,9,0)
        };
        Object[] prmBC000H8;
        prmBC000H8 = new Object[] {
        new ParDef("WorkHourLogId",GXType.Int64,10,0)
        };
        Object[] prmBC000H9;
        prmBC000H9 = new Object[] {
        new ParDef("WorkHourLogId",GXType.Int64,10,0)
        };
        Object[] prmBC000H10;
        prmBC000H10 = new Object[] {
        new ParDef("WorkHourLogDate",GXType.Date,8,0) ,
        new ParDef("WorkHourLogDuration",GXType.VarChar,40,3) ,
        new ParDef("WorkHourLogHour",GXType.Int16,4,0) ,
        new ParDef("WorkHourLogMinute",GXType.Int16,4,0) ,
        new ParDef("WorkHourLogDescription",GXType.LongVarChar,2097152,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000H11;
        prmBC000H11 = new Object[] {
        };
        Object[] prmBC000H12;
        prmBC000H12 = new Object[] {
        new ParDef("WorkHourLogDate",GXType.Date,8,0) ,
        new ParDef("WorkHourLogDuration",GXType.VarChar,40,3) ,
        new ParDef("WorkHourLogHour",GXType.Int16,4,0) ,
        new ParDef("WorkHourLogMinute",GXType.Int16,4,0) ,
        new ParDef("WorkHourLogDescription",GXType.LongVarChar,2097152,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0) ,
        new ParDef("WorkHourLogId",GXType.Int64,10,0)
        };
        Object[] prmBC000H13;
        prmBC000H13 = new Object[] {
        new ParDef("WorkHourLogId",GXType.Int64,10,0)
        };
        Object[] prmBC000H14;
        prmBC000H14 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000H15;
        prmBC000H15 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000H16;
        prmBC000H16 = new Object[] {
        new ParDef("WorkHourLogId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000H2", "SELECT WorkHourLogId, WorkHourLogDate, WorkHourLogDuration, WorkHourLogHour, WorkHourLogMinute, WorkHourLogDescription, EmployeeId, ProjectId FROM WorkHourLog WHERE WorkHourLogId = :WorkHourLogId  FOR UPDATE OF WorkHourLog",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H3", "SELECT WorkHourLogId, WorkHourLogDate, WorkHourLogDuration, WorkHourLogHour, WorkHourLogMinute, WorkHourLogDescription, EmployeeId, ProjectId FROM WorkHourLog WHERE WorkHourLogId = :WorkHourLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H4", "SELECT EmployeeBalance, EmployeeFirstName FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H5", "SELECT ProjectName FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H6", "SELECT EmployeeId FROM EmployeeProject WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H7", "SELECT T2.EmployeeBalance, TM1.WorkHourLogId, TM1.WorkHourLogDate, TM1.WorkHourLogDuration, TM1.WorkHourLogHour, TM1.WorkHourLogMinute, TM1.WorkHourLogDescription, T2.EmployeeFirstName, T3.ProjectName, TM1.EmployeeId, TM1.ProjectId FROM ((WorkHourLog TM1 INNER JOIN Employee T2 ON T2.EmployeeId = TM1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = TM1.ProjectId) ORDER BY TM1.WorkHourLogId  OFFSET :GXPagingFrom19 LIMIT CASE WHEN :GXPagingTo19 > 0 THEN :GXPagingTo19 ELSE 1e9 END",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H8", "SELECT T2.EmployeeBalance, TM1.WorkHourLogId, TM1.WorkHourLogDate, TM1.WorkHourLogDuration, TM1.WorkHourLogHour, TM1.WorkHourLogMinute, TM1.WorkHourLogDescription, T2.EmployeeFirstName, T3.ProjectName, TM1.EmployeeId, TM1.ProjectId FROM ((WorkHourLog TM1 INNER JOIN Employee T2 ON T2.EmployeeId = TM1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = TM1.ProjectId) WHERE TM1.WorkHourLogId = :WorkHourLogId ORDER BY TM1.WorkHourLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H9", "SELECT WorkHourLogId FROM WorkHourLog WHERE WorkHourLogId = :WorkHourLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H10", "SAVEPOINT gxupdate;INSERT INTO WorkHourLog(WorkHourLogDate, WorkHourLogDuration, WorkHourLogHour, WorkHourLogMinute, WorkHourLogDescription, EmployeeId, ProjectId) VALUES(:WorkHourLogDate, :WorkHourLogDuration, :WorkHourLogHour, :WorkHourLogMinute, :WorkHourLogDescription, :EmployeeId, :ProjectId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000H10)
           ,new CursorDef("BC000H11", "SELECT currval('WorkHourLogId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H12", "SAVEPOINT gxupdate;UPDATE WorkHourLog SET WorkHourLogDate=:WorkHourLogDate, WorkHourLogDuration=:WorkHourLogDuration, WorkHourLogHour=:WorkHourLogHour, WorkHourLogMinute=:WorkHourLogMinute, WorkHourLogDescription=:WorkHourLogDescription, EmployeeId=:EmployeeId, ProjectId=:ProjectId  WHERE WorkHourLogId = :WorkHourLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000H12)
           ,new CursorDef("BC000H13", "SAVEPOINT gxupdate;DELETE FROM WorkHourLog  WHERE WorkHourLogId = :WorkHourLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000H13)
           ,new CursorDef("BC000H14", "SELECT EmployeeBalance, EmployeeFirstName FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H15", "SELECT ProjectName FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H16", "SELECT T2.EmployeeBalance, TM1.WorkHourLogId, TM1.WorkHourLogDate, TM1.WorkHourLogDuration, TM1.WorkHourLogHour, TM1.WorkHourLogMinute, TM1.WorkHourLogDescription, T2.EmployeeFirstName, T3.ProjectName, TM1.EmployeeId, TM1.ProjectId FROM ((WorkHourLog TM1 INNER JOIN Employee T2 ON T2.EmployeeId = TM1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = TM1.ProjectId) WHERE TM1.WorkHourLogId = :WorkHourLogId ORDER BY TM1.WorkHourLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H16,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              return;
           case 2 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((string[]) buf[8])[0] = rslt.getString(9, 100);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((long[]) buf[10])[0] = rslt.getLong(11);
              return;
           case 6 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((string[]) buf[8])[0] = rslt.getString(9, 100);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((long[]) buf[10])[0] = rslt.getLong(11);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((string[]) buf[8])[0] = rslt.getString(9, 100);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((long[]) buf[10])[0] = rslt.getLong(11);
              return;
     }
  }

}

}
