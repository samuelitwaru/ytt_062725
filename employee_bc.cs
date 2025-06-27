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
   public class employee_bc : GxSilentTrn, IGxSilentTrn
   {
      public employee_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employee_bc( IGxContext context )
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
         ReadRow0F16( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0F16( ) ;
         standaloneModal( ) ;
         AddRow0F16( ) ;
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
            E110F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z106EmployeeId = A106EmployeeId;
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

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F16( ) ;
            }
            else
            {
               CheckExtendedTable0F16( ) ;
               if ( AnyError == 0 )
               {
                  ZM0F16( 27) ;
               }
               CloseExtendedTableCursors0F16( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode16 = Gx_mode;
            CONFIRM_0F27( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_0F17( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode16;
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode16;
         }
      }

      protected void CONFIRM_0F17( )
      {
         nGXsfl_17_idx = 0;
         while ( nGXsfl_17_idx < bcEmployee.gxTpr_Project.Count )
         {
            ReadRow0F17( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound17 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_17 != 0 ) )
            {
               GetKey0F17( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound17 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0F17( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0F17( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0F17( 30) ;
                        }
                        CloseExtendedTableCursors0F17( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound17 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0F17( ) ;
                        Load0F17( ) ;
                        BeforeValidate0F17( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0F17( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_17 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0F17( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0F17( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0F17( 30) ;
                              }
                              CloseExtendedTableCursors0F17( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow17( ((SdtEmployee_Project)bcEmployee.gxTpr_Project.Item(nGXsfl_17_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0F27( )
      {
         nGXsfl_27_idx = 0;
         while ( nGXsfl_27_idx < bcEmployee.gxTpr_Vacationset.Count )
         {
            ReadRow0F27( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound27 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_27 != 0 ) )
            {
               GetKey0F27( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound27 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0F27( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0F27( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0F27( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound27 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0F27( ) ;
                        Load0F27( ) ;
                        BeforeValidate0F27( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0F27( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_27 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0F27( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0F27( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0F27( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow27( ((SdtEmployee_VacationSet)bcEmployee.gxTpr_Vacationset.Item(nGXsfl_27_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120F2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV33Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV34GXV1 = 1;
            while ( AV34GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV34GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CompanyId") == 0 )
               {
                  AV13Insert_CompanyId = (long)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV34GXV1 = (int)(AV34GXV1+1);
            }
         }
      }

      protected void E110F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void E130F2( )
      {
         /* 'DoUserAction1' Routine */
         returnInSub = false;
         GXt_char1 = AV31EmployeeAPIPassword;
         new prc_setemployeepassword(context ).execute(  A106EmployeeId, out  GXt_char1) ;
         AV31EmployeeAPIPassword = GXt_char1;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void E140F2( )
      {
         /* Setvacationdaysbtn_modal_Close Routine */
         returnInSub = false;
         GXt_decimal2 = AV30EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal2) ;
         AV30EmployeeBalance = GXt_decimal2;
      }

      protected void ZM0F16( short GX_JID )
      {
         if ( ( GX_JID == 25 ) || ( GX_JID == 0 ) )
         {
            Z147EmployeeBalance = A147EmployeeBalance;
            Z148EmployeeName = A148EmployeeName;
            Z111GAMUserGUID = A111GAMUserGUID;
            Z107EmployeeFirstName = A107EmployeeFirstName;
            Z108EmployeeLastName = A108EmployeeLastName;
            Z109EmployeeEmail = A109EmployeeEmail;
            Z110EmployeeIsManager = A110EmployeeIsManager;
            Z112EmployeeIsActive = A112EmployeeIsActive;
            Z146EmployeeVactionDays = A146EmployeeVactionDays;
            Z177EmployeeVacationDaysSetDate = A177EmployeeVacationDaysSetDate;
            Z187EmployeeAPIPassword = A187EmployeeAPIPassword;
            Z188EmployeeFTEHours = A188EmployeeFTEHours;
            Z100CompanyId = A100CompanyId;
         }
         if ( ( GX_JID == 27 ) || ( GX_JID == 0 ) )
         {
            Z101CompanyName = A101CompanyName;
         }
         if ( GX_JID == -25 )
         {
            Z147EmployeeBalance = A147EmployeeBalance;
            Z106EmployeeId = A106EmployeeId;
            Z148EmployeeName = A148EmployeeName;
            Z111GAMUserGUID = A111GAMUserGUID;
            Z107EmployeeFirstName = A107EmployeeFirstName;
            Z108EmployeeLastName = A108EmployeeLastName;
            Z109EmployeeEmail = A109EmployeeEmail;
            Z110EmployeeIsManager = A110EmployeeIsManager;
            Z112EmployeeIsActive = A112EmployeeIsActive;
            Z146EmployeeVactionDays = A146EmployeeVactionDays;
            Z177EmployeeVacationDaysSetDate = A177EmployeeVacationDaysSetDate;
            Z187EmployeeAPIPassword = A187EmployeeAPIPassword;
            Z188EmployeeFTEHours = A188EmployeeFTEHours;
            Z100CompanyId = A100CompanyId;
            Z101CompanyName = A101CompanyName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV33Pgmname = "Employee_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         GXt_boolean3 = false;
         new userhasrole(context ).execute(  "Manager", out  GXt_boolean3) ;
         if ( GXt_boolean3 )
         {
            GXt_int4 = A100CompanyId;
            new getloggedinusercompanyid(context ).execute( out  GXt_int4) ;
            A100CompanyId = GXt_int4;
         }
         if ( IsIns( )  && (false==A112EmployeeIsActive) && ( Gx_BScreen == 0 ) )
         {
            A112EmployeeIsActive = false;
         }
         if ( IsIns( )  && (Convert.ToDecimal(0)==A146EmployeeVactionDays) && ( Gx_BScreen == 0 ) )
         {
            A146EmployeeVactionDays = (decimal)(21);
         }
         if ( IsIns( )  && (0==A188EmployeeFTEHours) && ( Gx_BScreen == 0 ) )
         {
            A188EmployeeFTEHours = 40;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor BC000F9 */
            pr_default.execute(7, new Object[] {A100CompanyId});
            A101CompanyName = BC000F9_A101CompanyName[0];
            pr_default.close(7);
         }
      }

      protected void Load0F16( )
      {
         /* Using cursor BC000F10 */
         pr_default.execute(8, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound16 = 1;
            A147EmployeeBalance = BC000F10_A147EmployeeBalance[0];
            A148EmployeeName = BC000F10_A148EmployeeName[0];
            A111GAMUserGUID = BC000F10_A111GAMUserGUID[0];
            A107EmployeeFirstName = BC000F10_A107EmployeeFirstName[0];
            A108EmployeeLastName = BC000F10_A108EmployeeLastName[0];
            A109EmployeeEmail = BC000F10_A109EmployeeEmail[0];
            A101CompanyName = BC000F10_A101CompanyName[0];
            A110EmployeeIsManager = BC000F10_A110EmployeeIsManager[0];
            A112EmployeeIsActive = BC000F10_A112EmployeeIsActive[0];
            A146EmployeeVactionDays = BC000F10_A146EmployeeVactionDays[0];
            A177EmployeeVacationDaysSetDate = BC000F10_A177EmployeeVacationDaysSetDate[0];
            A187EmployeeAPIPassword = BC000F10_A187EmployeeAPIPassword[0];
            A188EmployeeFTEHours = BC000F10_A188EmployeeFTEHours[0];
            A100CompanyId = BC000F10_A100CompanyId[0];
            ZM0F16( -25) ;
         }
         pr_default.close(8);
         OnLoadActions0F16( ) ;
      }

      protected void OnLoadActions0F16( )
      {
         GXt_decimal2 = A147EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal2) ;
         A147EmployeeBalance = GXt_decimal2;
         GXt_decimal2 = A147EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal2) ;
         A147EmployeeBalance = GXt_decimal2;
         GXt_decimal2 = AV30EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal2) ;
         AV30EmployeeBalance = GXt_decimal2;
         A148EmployeeName = StringUtil.Trim( A107EmployeeFirstName) + " " + StringUtil.Trim( A108EmployeeLastName);
      }

      protected void CheckExtendedTable0F16( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000F11 */
         pr_default.execute(9, new Object[] {A109EmployeeEmail, A106EmployeeId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Employee Email"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(9);
         GXt_decimal2 = A147EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal2) ;
         A147EmployeeBalance = GXt_decimal2;
         GXt_decimal2 = A147EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal2) ;
         A147EmployeeBalance = GXt_decimal2;
         GXt_decimal2 = AV30EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal2) ;
         AV30EmployeeBalance = GXt_decimal2;
         A148EmployeeName = StringUtil.Trim( A107EmployeeFirstName) + " " + StringUtil.Trim( A108EmployeeLastName);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A107EmployeeFirstName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Employee First Name", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A108EmployeeLastName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Employee Last Name", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A109EmployeeEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Employee Email does not match the specified pattern", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A109EmployeeEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Employee Email", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A109EmployeeEmail)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  "Work hours/minutes are required",  "error",  "#"+A109EmployeeEmail_Internalname,  "true",  ""), 0, "");
         }
         /* Using cursor BC000F9 */
         pr_default.execute(7, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
         }
         A101CompanyName = BC000F9_A101CompanyName[0];
         pr_default.close(7);
         if ( (0==A100CompanyId) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Company Id", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0F16( )
      {
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0F16( )
      {
         /* Using cursor BC000F12 */
         pr_default.execute(10, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000F8 */
         pr_default.execute(6, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            ZM0F16( 25) ;
            RcdFound16 = 1;
            A147EmployeeBalance = BC000F8_A147EmployeeBalance[0];
            A106EmployeeId = BC000F8_A106EmployeeId[0];
            A148EmployeeName = BC000F8_A148EmployeeName[0];
            A111GAMUserGUID = BC000F8_A111GAMUserGUID[0];
            A107EmployeeFirstName = BC000F8_A107EmployeeFirstName[0];
            A108EmployeeLastName = BC000F8_A108EmployeeLastName[0];
            A109EmployeeEmail = BC000F8_A109EmployeeEmail[0];
            A110EmployeeIsManager = BC000F8_A110EmployeeIsManager[0];
            A112EmployeeIsActive = BC000F8_A112EmployeeIsActive[0];
            A146EmployeeVactionDays = BC000F8_A146EmployeeVactionDays[0];
            A177EmployeeVacationDaysSetDate = BC000F8_A177EmployeeVacationDaysSetDate[0];
            A187EmployeeAPIPassword = BC000F8_A187EmployeeAPIPassword[0];
            A188EmployeeFTEHours = BC000F8_A188EmployeeFTEHours[0];
            A100CompanyId = BC000F8_A100CompanyId[0];
            Z106EmployeeId = A106EmployeeId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0F16( ) ;
            if ( AnyError == 1 )
            {
               RcdFound16 = 0;
               InitializeNonKey0F16( ) ;
            }
            Gx_mode = sMode16;
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0F16( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode16;
         }
         pr_default.close(6);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F16( ) ;
         if ( RcdFound16 == 0 )
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
         CONFIRM_0F0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0F16( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000F7 */
            pr_default.execute(5, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Employee"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(5) == 101) || ( Z147EmployeeBalance != BC000F7_A147EmployeeBalance[0] ) || ( StringUtil.StrCmp(Z148EmployeeName, BC000F7_A148EmployeeName[0]) != 0 ) || ( StringUtil.StrCmp(Z111GAMUserGUID, BC000F7_A111GAMUserGUID[0]) != 0 ) || ( StringUtil.StrCmp(Z107EmployeeFirstName, BC000F7_A107EmployeeFirstName[0]) != 0 ) || ( StringUtil.StrCmp(Z108EmployeeLastName, BC000F7_A108EmployeeLastName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z109EmployeeEmail, BC000F7_A109EmployeeEmail[0]) != 0 ) || ( Z110EmployeeIsManager != BC000F7_A110EmployeeIsManager[0] ) || ( Z112EmployeeIsActive != BC000F7_A112EmployeeIsActive[0] ) || ( Z146EmployeeVactionDays != BC000F7_A146EmployeeVactionDays[0] ) || ( DateTimeUtil.ResetTime ( Z177EmployeeVacationDaysSetDate ) != DateTimeUtil.ResetTime ( BC000F7_A177EmployeeVacationDaysSetDate[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z187EmployeeAPIPassword, BC000F7_A187EmployeeAPIPassword[0]) != 0 ) || ( Z188EmployeeFTEHours != BC000F7_A188EmployeeFTEHours[0] ) || ( Z100CompanyId != BC000F7_A100CompanyId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Employee"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F16( )
      {
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F16( 0) ;
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F13 */
                     pr_default.execute(11, new Object[] {A147EmployeeBalance, A148EmployeeName, A111GAMUserGUID, A107EmployeeFirstName, A108EmployeeLastName, A109EmployeeEmail, A110EmployeeIsManager, A112EmployeeIsActive, A146EmployeeVactionDays, A177EmployeeVacationDaysSetDate, A187EmployeeAPIPassword, A188EmployeeFTEHours, A100CompanyId});
                     pr_default.close(11);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000F14 */
                     pr_default.execute(12);
                     A106EmployeeId = BC000F14_A106EmployeeId[0];
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Employee");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        new assignemployeerole(context ).execute(  A106EmployeeId) ;
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0F16( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load0F16( ) ;
            }
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void Update0F16( )
      {
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F15 */
                     pr_default.execute(13, new Object[] {A147EmployeeBalance, A148EmployeeName, A111GAMUserGUID, A107EmployeeFirstName, A108EmployeeLastName, A109EmployeeEmail, A110EmployeeIsManager, A112EmployeeIsActive, A146EmployeeVactionDays, A177EmployeeVacationDaysSetDate, A187EmployeeAPIPassword, A188EmployeeFTEHours, A100CompanyId, A106EmployeeId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Employee");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Employee"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F16( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        new assignemployeerole(context ).execute(  A106EmployeeId) ;
                        new employeestatuscheck(context ).execute(  A106EmployeeId) ;
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0F16( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void DeferredUpdate0F16( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F16( ) ;
            AfterConfirm0F16( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F16( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0F27( ) ;
                  while ( RcdFound27 != 0 )
                  {
                     getByPrimaryKey0F27( ) ;
                     Delete0F27( ) ;
                     ScanKeyNext0F27( ) ;
                  }
                  ScanKeyEnd0F27( ) ;
                  ScanKeyStart0F17( ) ;
                  while ( RcdFound17 != 0 )
                  {
                     getByPrimaryKey0F17( ) ;
                     Delete0F17( ) ;
                     ScanKeyNext0F17( ) ;
                  }
                  ScanKeyEnd0F17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F16 */
                     pr_default.execute(14, new Object[] {A106EmployeeId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Employee");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        new deleteemployeeaccount(context ).execute(  A109EmployeeEmail) ;
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
         }
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0F16( ) ;
         Gx_mode = sMode16;
      }

      protected void OnDeleteControls0F16( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_decimal2 = AV30EmployeeBalance;
            new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal2) ;
            AV30EmployeeBalance = GXt_decimal2;
            /* Using cursor BC000F17 */
            pr_default.execute(15, new Object[] {A100CompanyId});
            A101CompanyName = BC000F17_A101CompanyName[0];
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000F18 */
            pr_default.execute(16, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Project"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor BC000F19 */
            pr_default.execute(17, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Support Request"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor BC000F20 */
            pr_default.execute(18, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"LeaveRequest"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor BC000F21 */
            pr_default.execute(19, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void ProcessNestedLevel0F27( )
      {
         nGXsfl_27_idx = 0;
         while ( nGXsfl_27_idx < bcEmployee.gxTpr_Vacationset.Count )
         {
            ReadRow0F27( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound27 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_27 != 0 ) )
            {
               standaloneNotModal0F27( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0F27( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0F27( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0F27( ) ;
                  }
               }
            }
            KeyVarsToRow27( ((SdtEmployee_VacationSet)bcEmployee.gxTpr_Vacationset.Item(nGXsfl_27_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_27_idx = 0;
            while ( nGXsfl_27_idx < bcEmployee.gxTpr_Vacationset.Count )
            {
               ReadRow0F27( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound27 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcEmployee.gxTpr_Vacationset.RemoveElement(nGXsfl_27_idx);
                  nGXsfl_27_idx = (int)(nGXsfl_27_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0F27( ) ;
                  VarsToRow27( ((SdtEmployee_VacationSet)bcEmployee.gxTpr_Vacationset.Item(nGXsfl_27_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0F27( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_27 = 0;
         nIsMod_27 = 0;
      }

      protected void ProcessNestedLevel0F17( )
      {
         nGXsfl_17_idx = 0;
         while ( nGXsfl_17_idx < bcEmployee.gxTpr_Project.Count )
         {
            ReadRow0F17( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound17 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_17 != 0 ) )
            {
               standaloneNotModal0F17( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0F17( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0F17( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0F17( ) ;
                  }
               }
            }
            KeyVarsToRow17( ((SdtEmployee_Project)bcEmployee.gxTpr_Project.Item(nGXsfl_17_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_17_idx = 0;
            while ( nGXsfl_17_idx < bcEmployee.gxTpr_Project.Count )
            {
               ReadRow0F17( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound17 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcEmployee.gxTpr_Project.RemoveElement(nGXsfl_17_idx);
                  nGXsfl_17_idx = (int)(nGXsfl_17_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0F17( ) ;
                  VarsToRow17( ((SdtEmployee_Project)bcEmployee.gxTpr_Project.Item(nGXsfl_17_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0F17( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_17 = 0;
         nIsMod_17 = 0;
      }

      protected void ProcessLevel0F16( )
      {
         /* Save parent mode. */
         sMode16 = Gx_mode;
         ProcessNestedLevel0F27( ) ;
         ProcessNestedLevel0F17( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode16;
         /* ' Update level parameters */
      }

      protected void EndLevel0F16( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(5);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F16( ) ;
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

      public void ScanKeyStart0F16( )
      {
         /* Scan By routine */
         /* Using cursor BC000F22 */
         pr_default.execute(20, new Object[] {A106EmployeeId});
         RcdFound16 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound16 = 1;
            A147EmployeeBalance = BC000F22_A147EmployeeBalance[0];
            A106EmployeeId = BC000F22_A106EmployeeId[0];
            A148EmployeeName = BC000F22_A148EmployeeName[0];
            A111GAMUserGUID = BC000F22_A111GAMUserGUID[0];
            A107EmployeeFirstName = BC000F22_A107EmployeeFirstName[0];
            A108EmployeeLastName = BC000F22_A108EmployeeLastName[0];
            A109EmployeeEmail = BC000F22_A109EmployeeEmail[0];
            A101CompanyName = BC000F22_A101CompanyName[0];
            A110EmployeeIsManager = BC000F22_A110EmployeeIsManager[0];
            A112EmployeeIsActive = BC000F22_A112EmployeeIsActive[0];
            A146EmployeeVactionDays = BC000F22_A146EmployeeVactionDays[0];
            A177EmployeeVacationDaysSetDate = BC000F22_A177EmployeeVacationDaysSetDate[0];
            A187EmployeeAPIPassword = BC000F22_A187EmployeeAPIPassword[0];
            A188EmployeeFTEHours = BC000F22_A188EmployeeFTEHours[0];
            A100CompanyId = BC000F22_A100CompanyId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0F16( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound16 = 0;
         ScanKeyLoad0F16( ) ;
      }

      protected void ScanKeyLoad0F16( )
      {
         sMode16 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound16 = 1;
            A147EmployeeBalance = BC000F22_A147EmployeeBalance[0];
            A106EmployeeId = BC000F22_A106EmployeeId[0];
            A148EmployeeName = BC000F22_A148EmployeeName[0];
            A111GAMUserGUID = BC000F22_A111GAMUserGUID[0];
            A107EmployeeFirstName = BC000F22_A107EmployeeFirstName[0];
            A108EmployeeLastName = BC000F22_A108EmployeeLastName[0];
            A109EmployeeEmail = BC000F22_A109EmployeeEmail[0];
            A101CompanyName = BC000F22_A101CompanyName[0];
            A110EmployeeIsManager = BC000F22_A110EmployeeIsManager[0];
            A112EmployeeIsActive = BC000F22_A112EmployeeIsActive[0];
            A146EmployeeVactionDays = BC000F22_A146EmployeeVactionDays[0];
            A177EmployeeVacationDaysSetDate = BC000F22_A177EmployeeVacationDaysSetDate[0];
            A187EmployeeAPIPassword = BC000F22_A187EmployeeAPIPassword[0];
            A188EmployeeFTEHours = BC000F22_A188EmployeeFTEHours[0];
            A100CompanyId = BC000F22_A100CompanyId[0];
         }
         Gx_mode = sMode16;
      }

      protected void ScanKeyEnd0F16( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm0F16( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F16( )
      {
         /* Before Insert Rules */
         new createemployeeaccount(context ).execute(  A109EmployeeEmail,  A107EmployeeFirstName,  A108EmployeeLastName, out  A111GAMUserGUID, out  AV24Password) ;
      }

      protected void BeforeUpdate0F16( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F16( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F16( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F16( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F16( )
      {
      }

      protected void ZM0F27( short GX_JID )
      {
         if ( ( GX_JID == 28 ) || ( GX_JID == 0 ) )
         {
            Z179VacationSetDays = A179VacationSetDays;
            Z189VacationSetDescription = A189VacationSetDescription;
         }
         if ( GX_JID == -28 )
         {
            Z106EmployeeId = A106EmployeeId;
            Z186VacationSetDate = A186VacationSetDate;
            Z179VacationSetDays = A179VacationSetDays;
            Z189VacationSetDescription = A189VacationSetDescription;
         }
      }

      protected void standaloneNotModal0F27( )
      {
      }

      protected void standaloneModal0F27( )
      {
      }

      protected void Load0F27( )
      {
         /* Using cursor BC000F23 */
         pr_default.execute(21, new Object[] {A106EmployeeId, A186VacationSetDate});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound27 = 1;
            A179VacationSetDays = BC000F23_A179VacationSetDays[0];
            A189VacationSetDescription = BC000F23_A189VacationSetDescription[0];
            n189VacationSetDescription = BC000F23_n189VacationSetDescription[0];
            ZM0F27( -28) ;
         }
         pr_default.close(21);
         OnLoadActions0F27( ) ;
      }

      protected void OnLoadActions0F27( )
      {
      }

      protected void CheckExtendedTable0F27( )
      {
         Gx_BScreen = 1;
         standaloneModal0F27( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors0F27( )
      {
      }

      protected void enableDisable0F27( )
      {
      }

      protected void GetKey0F27( )
      {
         /* Using cursor BC000F24 */
         pr_default.execute(22, new Object[] {A106EmployeeId, A186VacationSetDate});
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound27 = 1;
         }
         else
         {
            RcdFound27 = 0;
         }
         pr_default.close(22);
      }

      protected void getByPrimaryKey0F27( )
      {
         /* Using cursor BC000F6 */
         pr_default.execute(4, new Object[] {A106EmployeeId, A186VacationSetDate});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0F27( 28) ;
            RcdFound27 = 1;
            InitializeNonKey0F27( ) ;
            A186VacationSetDate = BC000F6_A186VacationSetDate[0];
            A179VacationSetDays = BC000F6_A179VacationSetDays[0];
            A189VacationSetDescription = BC000F6_A189VacationSetDescription[0];
            n189VacationSetDescription = BC000F6_n189VacationSetDescription[0];
            Z106EmployeeId = A106EmployeeId;
            Z186VacationSetDate = A186VacationSetDate;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0F27( ) ;
            Load0F27( ) ;
            Gx_mode = sMode27;
         }
         else
         {
            RcdFound27 = 0;
            InitializeNonKey0F27( ) ;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0F27( ) ;
            Gx_mode = sMode27;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0F27( ) ;
         }
         pr_default.close(4);
      }

      protected void CheckOptimisticConcurrency0F27( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000F5 */
            pr_default.execute(3, new Object[] {A106EmployeeId, A186VacationSetDate});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EmployeeVacationSet"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( Z179VacationSetDays != BC000F5_A179VacationSetDays[0] ) || ( StringUtil.StrCmp(Z189VacationSetDescription, BC000F5_A189VacationSetDescription[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EmployeeVacationSet"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F27( )
      {
         BeforeValidate0F27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F27( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F27( 0) ;
            CheckOptimisticConcurrency0F27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F25 */
                     pr_default.execute(23, new Object[] {A106EmployeeId, A186VacationSetDate, A179VacationSetDays, n189VacationSetDescription, A189VacationSetDescription});
                     pr_default.close(23);
                     pr_default.SmartCacheProvider.SetUpdated("EmployeeVacationSet");
                     if ( (pr_default.getStatus(23) == 1) )
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
               Load0F27( ) ;
            }
            EndLevel0F27( ) ;
         }
         CloseExtendedTableCursors0F27( ) ;
      }

      protected void Update0F27( )
      {
         BeforeValidate0F27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F27( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F26 */
                     pr_default.execute(24, new Object[] {A179VacationSetDays, n189VacationSetDescription, A189VacationSetDescription, A106EmployeeId, A186VacationSetDate});
                     pr_default.close(24);
                     pr_default.SmartCacheProvider.SetUpdated("EmployeeVacationSet");
                     if ( (pr_default.getStatus(24) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EmployeeVacationSet"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F27( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0F27( ) ;
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
            EndLevel0F27( ) ;
         }
         CloseExtendedTableCursors0F27( ) ;
      }

      protected void DeferredUpdate0F27( )
      {
      }

      protected void Delete0F27( )
      {
         Gx_mode = "DLT";
         BeforeValidate0F27( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F27( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F27( ) ;
            AfterConfirm0F27( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F27( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000F27 */
                  pr_default.execute(25, new Object[] {A106EmployeeId, A186VacationSetDate});
                  pr_default.close(25);
                  pr_default.SmartCacheProvider.SetUpdated("EmployeeVacationSet");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode27 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0F27( ) ;
         Gx_mode = sMode27;
      }

      protected void OnDeleteControls0F27( )
      {
         standaloneModal0F27( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0F27( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0F27( )
      {
         /* Scan By routine */
         /* Using cursor BC000F28 */
         pr_default.execute(26, new Object[] {A106EmployeeId});
         RcdFound27 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound27 = 1;
            A186VacationSetDate = BC000F28_A186VacationSetDate[0];
            A179VacationSetDays = BC000F28_A179VacationSetDays[0];
            A189VacationSetDescription = BC000F28_A189VacationSetDescription[0];
            n189VacationSetDescription = BC000F28_n189VacationSetDescription[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0F27( )
      {
         /* Scan next routine */
         pr_default.readNext(26);
         RcdFound27 = 0;
         ScanKeyLoad0F27( ) ;
      }

      protected void ScanKeyLoad0F27( )
      {
         sMode27 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound27 = 1;
            A186VacationSetDate = BC000F28_A186VacationSetDate[0];
            A179VacationSetDays = BC000F28_A179VacationSetDays[0];
            A189VacationSetDescription = BC000F28_A189VacationSetDescription[0];
            n189VacationSetDescription = BC000F28_n189VacationSetDescription[0];
         }
         Gx_mode = sMode27;
      }

      protected void ScanKeyEnd0F27( )
      {
         pr_default.close(26);
      }

      protected void AfterConfirm0F27( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F27( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F27( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F27( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F27( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F27( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F27( )
      {
      }

      protected void send_integrity_lvl_hashes0F27( )
      {
      }

      protected void ZM0F17( short GX_JID )
      {
         if ( ( GX_JID == 29 ) || ( GX_JID == 0 ) )
         {
            Z184EmployeeIsActiveInProject = A184EmployeeIsActiveInProject;
         }
         if ( ( GX_JID == 30 ) || ( GX_JID == 0 ) )
         {
            Z103ProjectName = A103ProjectName;
         }
         if ( GX_JID == -29 )
         {
            Z106EmployeeId = A106EmployeeId;
            Z184EmployeeIsActiveInProject = A184EmployeeIsActiveInProject;
            Z102ProjectId = A102ProjectId;
            Z103ProjectName = A103ProjectName;
         }
      }

      protected void standaloneNotModal0F17( )
      {
      }

      protected void standaloneModal0F17( )
      {
         if ( IsIns( )  && (false==A184EmployeeIsActiveInProject) && ( Gx_BScreen == 0 ) )
         {
            A184EmployeeIsActiveInProject = true;
         }
      }

      protected void Load0F17( )
      {
         /* Using cursor BC000F29 */
         pr_default.execute(27, new Object[] {A106EmployeeId, A102ProjectId});
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound17 = 1;
            A184EmployeeIsActiveInProject = BC000F29_A184EmployeeIsActiveInProject[0];
            A103ProjectName = BC000F29_A103ProjectName[0];
            ZM0F17( -29) ;
         }
         pr_default.close(27);
         OnLoadActions0F17( ) ;
      }

      protected void OnLoadActions0F17( )
      {
      }

      protected void CheckExtendedTable0F17( )
      {
         Gx_BScreen = 1;
         standaloneModal0F17( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000F4 */
         pr_default.execute(2, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Project'.", "ForeignKeyNotFound", 1, "PROJECTID");
            AnyError = 1;
         }
         A103ProjectName = BC000F4_A103ProjectName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0F17( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0F17( )
      {
      }

      protected void GetKey0F17( )
      {
         /* Using cursor BC000F30 */
         pr_default.execute(28, new Object[] {A106EmployeeId, A102ProjectId});
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(28);
      }

      protected void getByPrimaryKey0F17( )
      {
         /* Using cursor BC000F3 */
         pr_default.execute(1, new Object[] {A106EmployeeId, A102ProjectId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F17( 29) ;
            RcdFound17 = 1;
            InitializeNonKey0F17( ) ;
            A184EmployeeIsActiveInProject = BC000F3_A184EmployeeIsActiveInProject[0];
            A102ProjectId = BC000F3_A102ProjectId[0];
            Z106EmployeeId = A106EmployeeId;
            Z102ProjectId = A102ProjectId;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0F17( ) ;
            Load0F17( ) ;
            Gx_mode = sMode17;
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0F17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0F17( ) ;
            Gx_mode = sMode17;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0F17( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0F17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000F2 */
            pr_default.execute(0, new Object[] {A106EmployeeId, A102ProjectId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EmployeeProject"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z184EmployeeIsActiveInProject != BC000F2_A184EmployeeIsActiveInProject[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EmployeeProject"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F17( )
      {
         BeforeValidate0F17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F17( 0) ;
            CheckOptimisticConcurrency0F17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F31 */
                     pr_default.execute(29, new Object[] {A106EmployeeId, A184EmployeeIsActiveInProject, A102ProjectId});
                     pr_default.close(29);
                     pr_default.SmartCacheProvider.SetUpdated("EmployeeProject");
                     if ( (pr_default.getStatus(29) == 1) )
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
               Load0F17( ) ;
            }
            EndLevel0F17( ) ;
         }
         CloseExtendedTableCursors0F17( ) ;
      }

      protected void Update0F17( )
      {
         BeforeValidate0F17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F32 */
                     pr_default.execute(30, new Object[] {A184EmployeeIsActiveInProject, A106EmployeeId, A102ProjectId});
                     pr_default.close(30);
                     pr_default.SmartCacheProvider.SetUpdated("EmployeeProject");
                     if ( (pr_default.getStatus(30) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EmployeeProject"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F17( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0F17( ) ;
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
            EndLevel0F17( ) ;
         }
         CloseExtendedTableCursors0F17( ) ;
      }

      protected void DeferredUpdate0F17( )
      {
      }

      protected void Delete0F17( )
      {
         Gx_mode = "DLT";
         BeforeValidate0F17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F17( ) ;
            AfterConfirm0F17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F17( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000F33 */
                  pr_default.execute(31, new Object[] {A106EmployeeId, A102ProjectId});
                  pr_default.close(31);
                  pr_default.SmartCacheProvider.SetUpdated("EmployeeProject");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0F17( ) ;
         Gx_mode = sMode17;
      }

      protected void OnDeleteControls0F17( )
      {
         standaloneModal0F17( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000F34 */
            pr_default.execute(32, new Object[] {A102ProjectId});
            A103ProjectName = BC000F34_A103ProjectName[0];
            pr_default.close(32);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000F35 */
            pr_default.execute(33, new Object[] {A106EmployeeId, A102ProjectId});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Project"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor BC000F36 */
            pr_default.execute(34, new Object[] {A106EmployeeId, A102ProjectId});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
         }
      }

      protected void EndLevel0F17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0F17( )
      {
         /* Scan By routine */
         /* Using cursor BC000F37 */
         pr_default.execute(35, new Object[] {A106EmployeeId});
         RcdFound17 = 0;
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound17 = 1;
            A184EmployeeIsActiveInProject = BC000F37_A184EmployeeIsActiveInProject[0];
            A103ProjectName = BC000F37_A103ProjectName[0];
            A102ProjectId = BC000F37_A102ProjectId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0F17( )
      {
         /* Scan next routine */
         pr_default.readNext(35);
         RcdFound17 = 0;
         ScanKeyLoad0F17( ) ;
      }

      protected void ScanKeyLoad0F17( )
      {
         sMode17 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound17 = 1;
            A184EmployeeIsActiveInProject = BC000F37_A184EmployeeIsActiveInProject[0];
            A103ProjectName = BC000F37_A103ProjectName[0];
            A102ProjectId = BC000F37_A102ProjectId[0];
         }
         Gx_mode = sMode17;
      }

      protected void ScanKeyEnd0F17( )
      {
         pr_default.close(35);
      }

      protected void AfterConfirm0F17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F17( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F17( )
      {
      }

      protected void send_integrity_lvl_hashes0F17( )
      {
      }

      protected void send_integrity_lvl_hashes0F16( )
      {
      }

      protected void AddRow0F16( )
      {
         VarsToRow16( bcEmployee) ;
      }

      protected void ReadRow0F16( )
      {
         RowToVars16( bcEmployee, 1) ;
      }

      protected void AddRow0F27( )
      {
         SdtEmployee_VacationSet obj27;
         obj27 = new SdtEmployee_VacationSet(context);
         VarsToRow27( obj27) ;
         bcEmployee.gxTpr_Vacationset.Add(obj27, 0);
         obj27.gxTpr_Mode = "UPD";
         obj27.gxTpr_Modified = 0;
      }

      protected void ReadRow0F27( )
      {
         nGXsfl_27_idx = (int)(nGXsfl_27_idx+1);
         RowToVars27( ((SdtEmployee_VacationSet)bcEmployee.gxTpr_Vacationset.Item(nGXsfl_27_idx)), 1) ;
      }

      protected void AddRow0F17( )
      {
         SdtEmployee_Project obj17;
         obj17 = new SdtEmployee_Project(context);
         VarsToRow17( obj17) ;
         bcEmployee.gxTpr_Project.Add(obj17, 0);
         obj17.gxTpr_Mode = "UPD";
         obj17.gxTpr_Modified = 0;
      }

      protected void ReadRow0F17( )
      {
         nGXsfl_17_idx = (int)(nGXsfl_17_idx+1);
         RowToVars17( ((SdtEmployee_Project)bcEmployee.gxTpr_Project.Item(nGXsfl_17_idx)), 1) ;
      }

      protected void InitializeNonKey0F16( )
      {
         A148EmployeeName = "";
         A100CompanyId = 0;
         A111GAMUserGUID = "";
         AV24Password = "";
         A147EmployeeBalance = 0;
         AV30EmployeeBalance = 0;
         A107EmployeeFirstName = "";
         A108EmployeeLastName = "";
         A109EmployeeEmail = "";
         A101CompanyName = "";
         A110EmployeeIsManager = false;
         A177EmployeeVacationDaysSetDate = DateTime.MinValue;
         A187EmployeeAPIPassword = "";
         A112EmployeeIsActive = false;
         A146EmployeeVactionDays = (decimal)(21);
         A188EmployeeFTEHours = 40;
         Z147EmployeeBalance = 0;
         Z148EmployeeName = "";
         Z111GAMUserGUID = "";
         Z107EmployeeFirstName = "";
         Z108EmployeeLastName = "";
         Z109EmployeeEmail = "";
         Z110EmployeeIsManager = false;
         Z112EmployeeIsActive = false;
         Z146EmployeeVactionDays = 0;
         Z177EmployeeVacationDaysSetDate = DateTime.MinValue;
         Z187EmployeeAPIPassword = "";
         Z188EmployeeFTEHours = 0;
         Z100CompanyId = 0;
      }

      protected void InitAll0F16( )
      {
         A106EmployeeId = 0;
         InitializeNonKey0F16( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A100CompanyId = i100CompanyId;
         A112EmployeeIsActive = i112EmployeeIsActive;
         A146EmployeeVactionDays = i146EmployeeVactionDays;
         A188EmployeeFTEHours = i188EmployeeFTEHours;
      }

      protected void InitializeNonKey0F27( )
      {
         A179VacationSetDays = 0;
         A189VacationSetDescription = "";
         n189VacationSetDescription = false;
         Z179VacationSetDays = 0;
         Z189VacationSetDescription = "";
      }

      protected void InitAll0F27( )
      {
         A186VacationSetDate = DateTime.MinValue;
         InitializeNonKey0F27( ) ;
      }

      protected void StandaloneModalInsert0F27( )
      {
      }

      protected void InitializeNonKey0F17( )
      {
         A103ProjectName = "";
         A184EmployeeIsActiveInProject = true;
         Z184EmployeeIsActiveInProject = false;
      }

      protected void InitAll0F17( )
      {
         A102ProjectId = 0;
         InitializeNonKey0F17( ) ;
      }

      protected void StandaloneModalInsert0F17( )
      {
         A184EmployeeIsActiveInProject = i184EmployeeIsActiveInProject;
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

      public void VarsToRow16( SdtEmployee obj16 )
      {
         obj16.gxTpr_Mode = Gx_mode;
         obj16.gxTpr_Employeename = A148EmployeeName;
         obj16.gxTpr_Companyid = A100CompanyId;
         obj16.gxTpr_Gamuserguid = A111GAMUserGUID;
         obj16.gxTpr_Employeebalance = A147EmployeeBalance;
         obj16.gxTpr_Employeefirstname = A107EmployeeFirstName;
         obj16.gxTpr_Employeelastname = A108EmployeeLastName;
         obj16.gxTpr_Employeeemail = A109EmployeeEmail;
         obj16.gxTpr_Companyname = A101CompanyName;
         obj16.gxTpr_Employeeismanager = A110EmployeeIsManager;
         obj16.gxTpr_Employeevacationdayssetdate = A177EmployeeVacationDaysSetDate;
         obj16.gxTpr_Employeeapipassword = A187EmployeeAPIPassword;
         obj16.gxTpr_Employeeisactive = A112EmployeeIsActive;
         obj16.gxTpr_Employeevactiondays = A146EmployeeVactionDays;
         obj16.gxTpr_Employeeftehours = A188EmployeeFTEHours;
         obj16.gxTpr_Employeeid = A106EmployeeId;
         obj16.gxTpr_Employeeid_Z = Z106EmployeeId;
         obj16.gxTpr_Employeefirstname_Z = Z107EmployeeFirstName;
         obj16.gxTpr_Employeelastname_Z = Z108EmployeeLastName;
         obj16.gxTpr_Employeename_Z = Z148EmployeeName;
         obj16.gxTpr_Employeeemail_Z = Z109EmployeeEmail;
         obj16.gxTpr_Companyid_Z = Z100CompanyId;
         obj16.gxTpr_Companyname_Z = Z101CompanyName;
         obj16.gxTpr_Employeeismanager_Z = Z110EmployeeIsManager;
         obj16.gxTpr_Gamuserguid_Z = Z111GAMUserGUID;
         obj16.gxTpr_Employeeisactive_Z = Z112EmployeeIsActive;
         obj16.gxTpr_Employeevactiondays_Z = Z146EmployeeVactionDays;
         obj16.gxTpr_Employeevacationdayssetdate_Z = Z177EmployeeVacationDaysSetDate;
         obj16.gxTpr_Employeeapipassword_Z = Z187EmployeeAPIPassword;
         obj16.gxTpr_Employeeftehours_Z = Z188EmployeeFTEHours;
         obj16.gxTpr_Employeebalance_Z = Z147EmployeeBalance;
         obj16.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow16( SdtEmployee obj16 )
      {
         obj16.gxTpr_Employeeid = A106EmployeeId;
         return  ;
      }

      public void RowToVars16( SdtEmployee obj16 ,
                               int forceLoad )
      {
         Gx_mode = obj16.gxTpr_Mode;
         A148EmployeeName = obj16.gxTpr_Employeename;
         if ( ! ( new userhasrole(context).executeUdp(  "Manager") ) || ( forceLoad == 1 ) )
         {
            A100CompanyId = obj16.gxTpr_Companyid;
         }
         A111GAMUserGUID = obj16.gxTpr_Gamuserguid;
         A147EmployeeBalance = obj16.gxTpr_Employeebalance;
         A107EmployeeFirstName = obj16.gxTpr_Employeefirstname;
         A108EmployeeLastName = obj16.gxTpr_Employeelastname;
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) || ( forceLoad == 1 ) )
         {
            A109EmployeeEmail = obj16.gxTpr_Employeeemail;
         }
         A101CompanyName = obj16.gxTpr_Companyname;
         A110EmployeeIsManager = obj16.gxTpr_Employeeismanager;
         A177EmployeeVacationDaysSetDate = obj16.gxTpr_Employeevacationdayssetdate;
         A187EmployeeAPIPassword = obj16.gxTpr_Employeeapipassword;
         if ( ! ( IsIns( )  ) || ( forceLoad == 1 ) )
         {
            A112EmployeeIsActive = obj16.gxTpr_Employeeisactive;
         }
         A146EmployeeVactionDays = obj16.gxTpr_Employeevactiondays;
         A188EmployeeFTEHours = obj16.gxTpr_Employeeftehours;
         A106EmployeeId = obj16.gxTpr_Employeeid;
         Z106EmployeeId = obj16.gxTpr_Employeeid_Z;
         Z107EmployeeFirstName = obj16.gxTpr_Employeefirstname_Z;
         Z108EmployeeLastName = obj16.gxTpr_Employeelastname_Z;
         Z148EmployeeName = obj16.gxTpr_Employeename_Z;
         Z109EmployeeEmail = obj16.gxTpr_Employeeemail_Z;
         Z100CompanyId = obj16.gxTpr_Companyid_Z;
         Z101CompanyName = obj16.gxTpr_Companyname_Z;
         Z110EmployeeIsManager = obj16.gxTpr_Employeeismanager_Z;
         Z111GAMUserGUID = obj16.gxTpr_Gamuserguid_Z;
         Z112EmployeeIsActive = obj16.gxTpr_Employeeisactive_Z;
         Z146EmployeeVactionDays = obj16.gxTpr_Employeevactiondays_Z;
         Z177EmployeeVacationDaysSetDate = obj16.gxTpr_Employeevacationdayssetdate_Z;
         Z187EmployeeAPIPassword = obj16.gxTpr_Employeeapipassword_Z;
         Z188EmployeeFTEHours = obj16.gxTpr_Employeeftehours_Z;
         Z147EmployeeBalance = obj16.gxTpr_Employeebalance_Z;
         Gx_mode = obj16.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow27( SdtEmployee_VacationSet obj27 )
      {
         obj27.gxTpr_Mode = Gx_mode;
         obj27.gxTpr_Vacationsetdays = A179VacationSetDays;
         obj27.gxTpr_Vacationsetdescription = A189VacationSetDescription;
         obj27.gxTpr_Vacationsetdate = A186VacationSetDate;
         obj27.gxTpr_Vacationsetdate_Z = Z186VacationSetDate;
         obj27.gxTpr_Vacationsetdays_Z = Z179VacationSetDays;
         obj27.gxTpr_Vacationsetdescription_Z = Z189VacationSetDescription;
         obj27.gxTpr_Vacationsetdescription_N = (short)(Convert.ToInt16(n189VacationSetDescription));
         obj27.gxTpr_Modified = nIsMod_27;
         return  ;
      }

      public void KeyVarsToRow27( SdtEmployee_VacationSet obj27 )
      {
         obj27.gxTpr_Vacationsetdate = A186VacationSetDate;
         return  ;
      }

      public void RowToVars27( SdtEmployee_VacationSet obj27 ,
                               int forceLoad )
      {
         Gx_mode = obj27.gxTpr_Mode;
         A179VacationSetDays = obj27.gxTpr_Vacationsetdays;
         A189VacationSetDescription = obj27.gxTpr_Vacationsetdescription;
         n189VacationSetDescription = false;
         A186VacationSetDate = obj27.gxTpr_Vacationsetdate;
         Z186VacationSetDate = obj27.gxTpr_Vacationsetdate_Z;
         Z179VacationSetDays = obj27.gxTpr_Vacationsetdays_Z;
         Z189VacationSetDescription = obj27.gxTpr_Vacationsetdescription_Z;
         n189VacationSetDescription = (bool)(Convert.ToBoolean(obj27.gxTpr_Vacationsetdescription_N));
         nIsMod_27 = obj27.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow17( SdtEmployee_Project obj17 )
      {
         obj17.gxTpr_Mode = Gx_mode;
         obj17.gxTpr_Projectname = A103ProjectName;
         obj17.gxTpr_Employeeisactiveinproject = A184EmployeeIsActiveInProject;
         obj17.gxTpr_Projectid = A102ProjectId;
         obj17.gxTpr_Projectid_Z = Z102ProjectId;
         obj17.gxTpr_Projectname_Z = Z103ProjectName;
         obj17.gxTpr_Employeeisactiveinproject_Z = Z184EmployeeIsActiveInProject;
         obj17.gxTpr_Modified = nIsMod_17;
         return  ;
      }

      public void KeyVarsToRow17( SdtEmployee_Project obj17 )
      {
         obj17.gxTpr_Projectid = A102ProjectId;
         return  ;
      }

      public void RowToVars17( SdtEmployee_Project obj17 ,
                               int forceLoad )
      {
         Gx_mode = obj17.gxTpr_Mode;
         A103ProjectName = obj17.gxTpr_Projectname;
         A184EmployeeIsActiveInProject = obj17.gxTpr_Employeeisactiveinproject;
         A102ProjectId = obj17.gxTpr_Projectid;
         Z102ProjectId = obj17.gxTpr_Projectid_Z;
         Z103ProjectName = obj17.gxTpr_Projectname_Z;
         Z184EmployeeIsActiveInProject = obj17.gxTpr_Employeeisactiveinproject_Z;
         nIsMod_17 = obj17.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A106EmployeeId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0F16( ) ;
         ScanKeyStart0F16( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z106EmployeeId = A106EmployeeId;
         }
         ZM0F16( -25) ;
         OnLoadActions0F16( ) ;
         AddRow0F16( ) ;
         bcEmployee.gxTpr_Vacationset.ClearCollection();
         if ( RcdFound16 == 1 )
         {
            ScanKeyStart0F27( ) ;
            nGXsfl_27_idx = 1;
            while ( RcdFound27 != 0 )
            {
               Z106EmployeeId = A106EmployeeId;
               Z186VacationSetDate = A186VacationSetDate;
               ZM0F27( -28) ;
               OnLoadActions0F27( ) ;
               nRcdExists_27 = 1;
               nIsMod_27 = 0;
               AddRow0F27( ) ;
               nGXsfl_27_idx = (int)(nGXsfl_27_idx+1);
               ScanKeyNext0F27( ) ;
            }
            ScanKeyEnd0F27( ) ;
         }
         bcEmployee.gxTpr_Project.ClearCollection();
         if ( RcdFound16 == 1 )
         {
            ScanKeyStart0F17( ) ;
            nGXsfl_17_idx = 1;
            while ( RcdFound17 != 0 )
            {
               Z106EmployeeId = A106EmployeeId;
               Z102ProjectId = A102ProjectId;
               ZM0F17( -29) ;
               OnLoadActions0F17( ) ;
               nRcdExists_17 = 1;
               nIsMod_17 = 0;
               AddRow0F17( ) ;
               nGXsfl_17_idx = (int)(nGXsfl_17_idx+1);
               ScanKeyNext0F17( ) ;
            }
            ScanKeyEnd0F17( ) ;
         }
         ScanKeyEnd0F16( ) ;
         if ( RcdFound16 == 0 )
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
         RowToVars16( bcEmployee, 0) ;
         ScanKeyStart0F16( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z106EmployeeId = A106EmployeeId;
         }
         ZM0F16( -25) ;
         OnLoadActions0F16( ) ;
         AddRow0F16( ) ;
         bcEmployee.gxTpr_Vacationset.ClearCollection();
         if ( RcdFound16 == 1 )
         {
            ScanKeyStart0F27( ) ;
            nGXsfl_27_idx = 1;
            while ( RcdFound27 != 0 )
            {
               Z106EmployeeId = A106EmployeeId;
               Z186VacationSetDate = A186VacationSetDate;
               ZM0F27( -28) ;
               OnLoadActions0F27( ) ;
               nRcdExists_27 = 1;
               nIsMod_27 = 0;
               AddRow0F27( ) ;
               nGXsfl_27_idx = (int)(nGXsfl_27_idx+1);
               ScanKeyNext0F27( ) ;
            }
            ScanKeyEnd0F27( ) ;
         }
         bcEmployee.gxTpr_Project.ClearCollection();
         if ( RcdFound16 == 1 )
         {
            ScanKeyStart0F17( ) ;
            nGXsfl_17_idx = 1;
            while ( RcdFound17 != 0 )
            {
               Z106EmployeeId = A106EmployeeId;
               Z102ProjectId = A102ProjectId;
               ZM0F17( -29) ;
               OnLoadActions0F17( ) ;
               nRcdExists_17 = 1;
               nIsMod_17 = 0;
               AddRow0F17( ) ;
               nGXsfl_17_idx = (int)(nGXsfl_17_idx+1);
               ScanKeyNext0F17( ) ;
            }
            ScanKeyEnd0F17( ) ;
         }
         ScanKeyEnd0F16( ) ;
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0F16( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0F16( ) ;
         }
         else
         {
            if ( RcdFound16 == 1 )
            {
               if ( A106EmployeeId != Z106EmployeeId )
               {
                  A106EmployeeId = Z106EmployeeId;
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
                  Update0F16( ) ;
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
                  if ( A106EmployeeId != Z106EmployeeId )
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
                        Insert0F16( ) ;
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
                        Insert0F16( ) ;
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
         RowToVars16( bcEmployee, 1) ;
         SaveImpl( ) ;
         VarsToRow16( bcEmployee) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars16( bcEmployee, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F16( ) ;
         AfterTrn( ) ;
         VarsToRow16( bcEmployee) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow16( bcEmployee) ;
         }
         else
         {
            SdtEmployee auxBC = new SdtEmployee(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A106EmployeeId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcEmployee);
               auxBC.Save();
               bcEmployee.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars16( bcEmployee, 1) ;
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
         RowToVars16( bcEmployee, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F16( ) ;
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
               VarsToRow16( bcEmployee) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow16( bcEmployee) ;
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
         RowToVars16( bcEmployee, 0) ;
         GetKey0F16( ) ;
         if ( RcdFound16 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A106EmployeeId != Z106EmployeeId )
            {
               A106EmployeeId = Z106EmployeeId;
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
            if ( A106EmployeeId != Z106EmployeeId )
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
         context.RollbackDataStores("employee_bc",pr_default);
         VarsToRow16( bcEmployee) ;
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
         Gx_mode = bcEmployee.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcEmployee.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcEmployee )
         {
            bcEmployee = (SdtEmployee)(sdt);
            if ( StringUtil.StrCmp(bcEmployee.gxTpr_Mode, "") == 0 )
            {
               bcEmployee.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow16( bcEmployee) ;
            }
            else
            {
               RowToVars16( bcEmployee, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcEmployee.gxTpr_Mode, "") == 0 )
            {
               bcEmployee.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars16( bcEmployee, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtEmployee Employee_BC
      {
         get {
            return bcEmployee ;
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
            return "employee_Execute" ;
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
         pr_default.close(32);
         pr_default.close(4);
         pr_default.close(6);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode16 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV33Pgmname = "";
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV31EmployeeAPIPassword = "";
         GXt_char1 = "";
         Z148EmployeeName = "";
         A148EmployeeName = "";
         Z111GAMUserGUID = "";
         A111GAMUserGUID = "";
         Z107EmployeeFirstName = "";
         A107EmployeeFirstName = "";
         Z108EmployeeLastName = "";
         A108EmployeeLastName = "";
         Z109EmployeeEmail = "";
         A109EmployeeEmail = "";
         Z177EmployeeVacationDaysSetDate = DateTime.MinValue;
         A177EmployeeVacationDaysSetDate = DateTime.MinValue;
         Z187EmployeeAPIPassword = "";
         A187EmployeeAPIPassword = "";
         Z101CompanyName = "";
         A101CompanyName = "";
         BC000F9_A101CompanyName = new string[] {""} ;
         BC000F10_A147EmployeeBalance = new decimal[1] ;
         BC000F10_A106EmployeeId = new long[1] ;
         BC000F10_A148EmployeeName = new string[] {""} ;
         BC000F10_A111GAMUserGUID = new string[] {""} ;
         BC000F10_A107EmployeeFirstName = new string[] {""} ;
         BC000F10_A108EmployeeLastName = new string[] {""} ;
         BC000F10_A109EmployeeEmail = new string[] {""} ;
         BC000F10_A101CompanyName = new string[] {""} ;
         BC000F10_A110EmployeeIsManager = new bool[] {false} ;
         BC000F10_A112EmployeeIsActive = new bool[] {false} ;
         BC000F10_A146EmployeeVactionDays = new decimal[1] ;
         BC000F10_A177EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         BC000F10_A187EmployeeAPIPassword = new string[] {""} ;
         BC000F10_A188EmployeeFTEHours = new short[1] ;
         BC000F10_A100CompanyId = new long[1] ;
         BC000F11_A109EmployeeEmail = new string[] {""} ;
         A109EmployeeEmail_Internalname = "";
         BC000F12_A106EmployeeId = new long[1] ;
         BC000F8_A147EmployeeBalance = new decimal[1] ;
         BC000F8_A106EmployeeId = new long[1] ;
         BC000F8_A148EmployeeName = new string[] {""} ;
         BC000F8_A111GAMUserGUID = new string[] {""} ;
         BC000F8_A107EmployeeFirstName = new string[] {""} ;
         BC000F8_A108EmployeeLastName = new string[] {""} ;
         BC000F8_A109EmployeeEmail = new string[] {""} ;
         BC000F8_A110EmployeeIsManager = new bool[] {false} ;
         BC000F8_A112EmployeeIsActive = new bool[] {false} ;
         BC000F8_A146EmployeeVactionDays = new decimal[1] ;
         BC000F8_A177EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         BC000F8_A187EmployeeAPIPassword = new string[] {""} ;
         BC000F8_A188EmployeeFTEHours = new short[1] ;
         BC000F8_A100CompanyId = new long[1] ;
         BC000F7_A147EmployeeBalance = new decimal[1] ;
         BC000F7_A106EmployeeId = new long[1] ;
         BC000F7_A148EmployeeName = new string[] {""} ;
         BC000F7_A111GAMUserGUID = new string[] {""} ;
         BC000F7_A107EmployeeFirstName = new string[] {""} ;
         BC000F7_A108EmployeeLastName = new string[] {""} ;
         BC000F7_A109EmployeeEmail = new string[] {""} ;
         BC000F7_A110EmployeeIsManager = new bool[] {false} ;
         BC000F7_A112EmployeeIsActive = new bool[] {false} ;
         BC000F7_A146EmployeeVactionDays = new decimal[1] ;
         BC000F7_A177EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         BC000F7_A187EmployeeAPIPassword = new string[] {""} ;
         BC000F7_A188EmployeeFTEHours = new short[1] ;
         BC000F7_A100CompanyId = new long[1] ;
         BC000F14_A106EmployeeId = new long[1] ;
         BC000F17_A101CompanyName = new string[] {""} ;
         BC000F18_A102ProjectId = new long[1] ;
         BC000F19_A174SupportRequestId = new long[1] ;
         BC000F20_A127LeaveRequestId = new long[1] ;
         BC000F21_A118WorkHourLogId = new long[1] ;
         BC000F22_A147EmployeeBalance = new decimal[1] ;
         BC000F22_A106EmployeeId = new long[1] ;
         BC000F22_A148EmployeeName = new string[] {""} ;
         BC000F22_A111GAMUserGUID = new string[] {""} ;
         BC000F22_A107EmployeeFirstName = new string[] {""} ;
         BC000F22_A108EmployeeLastName = new string[] {""} ;
         BC000F22_A109EmployeeEmail = new string[] {""} ;
         BC000F22_A101CompanyName = new string[] {""} ;
         BC000F22_A110EmployeeIsManager = new bool[] {false} ;
         BC000F22_A112EmployeeIsActive = new bool[] {false} ;
         BC000F22_A146EmployeeVactionDays = new decimal[1] ;
         BC000F22_A177EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         BC000F22_A187EmployeeAPIPassword = new string[] {""} ;
         BC000F22_A188EmployeeFTEHours = new short[1] ;
         BC000F22_A100CompanyId = new long[1] ;
         AV24Password = "";
         Z189VacationSetDescription = "";
         A189VacationSetDescription = "";
         Z186VacationSetDate = DateTime.MinValue;
         A186VacationSetDate = DateTime.MinValue;
         BC000F23_A106EmployeeId = new long[1] ;
         BC000F23_A186VacationSetDate = new DateTime[] {DateTime.MinValue} ;
         BC000F23_A179VacationSetDays = new decimal[1] ;
         BC000F23_A189VacationSetDescription = new string[] {""} ;
         BC000F23_n189VacationSetDescription = new bool[] {false} ;
         BC000F24_A106EmployeeId = new long[1] ;
         BC000F24_A186VacationSetDate = new DateTime[] {DateTime.MinValue} ;
         BC000F6_A106EmployeeId = new long[1] ;
         BC000F6_A186VacationSetDate = new DateTime[] {DateTime.MinValue} ;
         BC000F6_A179VacationSetDays = new decimal[1] ;
         BC000F6_A189VacationSetDescription = new string[] {""} ;
         BC000F6_n189VacationSetDescription = new bool[] {false} ;
         sMode27 = "";
         BC000F5_A106EmployeeId = new long[1] ;
         BC000F5_A186VacationSetDate = new DateTime[] {DateTime.MinValue} ;
         BC000F5_A179VacationSetDays = new decimal[1] ;
         BC000F5_A189VacationSetDescription = new string[] {""} ;
         BC000F5_n189VacationSetDescription = new bool[] {false} ;
         BC000F28_A106EmployeeId = new long[1] ;
         BC000F28_A186VacationSetDate = new DateTime[] {DateTime.MinValue} ;
         BC000F28_A179VacationSetDays = new decimal[1] ;
         BC000F28_A189VacationSetDescription = new string[] {""} ;
         BC000F28_n189VacationSetDescription = new bool[] {false} ;
         Z103ProjectName = "";
         A103ProjectName = "";
         BC000F29_A106EmployeeId = new long[1] ;
         BC000F29_A184EmployeeIsActiveInProject = new bool[] {false} ;
         BC000F29_A103ProjectName = new string[] {""} ;
         BC000F29_A102ProjectId = new long[1] ;
         BC000F4_A103ProjectName = new string[] {""} ;
         BC000F30_A106EmployeeId = new long[1] ;
         BC000F30_A102ProjectId = new long[1] ;
         BC000F3_A106EmployeeId = new long[1] ;
         BC000F3_A184EmployeeIsActiveInProject = new bool[] {false} ;
         BC000F3_A102ProjectId = new long[1] ;
         sMode17 = "";
         BC000F2_A106EmployeeId = new long[1] ;
         BC000F2_A184EmployeeIsActiveInProject = new bool[] {false} ;
         BC000F2_A102ProjectId = new long[1] ;
         BC000F34_A103ProjectName = new string[] {""} ;
         BC000F35_A102ProjectId = new long[1] ;
         BC000F36_A118WorkHourLogId = new long[1] ;
         BC000F37_A106EmployeeId = new long[1] ;
         BC000F37_A184EmployeeIsActiveInProject = new bool[] {false} ;
         BC000F37_A103ProjectName = new string[] {""} ;
         BC000F37_A102ProjectId = new long[1] ;
         N109EmployeeEmail = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.employee_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employee_bc__default(),
            new Object[][] {
                new Object[] {
               BC000F2_A106EmployeeId, BC000F2_A184EmployeeIsActiveInProject, BC000F2_A102ProjectId
               }
               , new Object[] {
               BC000F3_A106EmployeeId, BC000F3_A184EmployeeIsActiveInProject, BC000F3_A102ProjectId
               }
               , new Object[] {
               BC000F4_A103ProjectName
               }
               , new Object[] {
               BC000F5_A106EmployeeId, BC000F5_A186VacationSetDate, BC000F5_A179VacationSetDays, BC000F5_A189VacationSetDescription, BC000F5_n189VacationSetDescription
               }
               , new Object[] {
               BC000F6_A106EmployeeId, BC000F6_A186VacationSetDate, BC000F6_A179VacationSetDays, BC000F6_A189VacationSetDescription, BC000F6_n189VacationSetDescription
               }
               , new Object[] {
               BC000F7_A147EmployeeBalance, BC000F7_A106EmployeeId, BC000F7_A148EmployeeName, BC000F7_A111GAMUserGUID, BC000F7_A107EmployeeFirstName, BC000F7_A108EmployeeLastName, BC000F7_A109EmployeeEmail, BC000F7_A110EmployeeIsManager, BC000F7_A112EmployeeIsActive, BC000F7_A146EmployeeVactionDays,
               BC000F7_A177EmployeeVacationDaysSetDate, BC000F7_A187EmployeeAPIPassword, BC000F7_A188EmployeeFTEHours, BC000F7_A100CompanyId
               }
               , new Object[] {
               BC000F8_A147EmployeeBalance, BC000F8_A106EmployeeId, BC000F8_A148EmployeeName, BC000F8_A111GAMUserGUID, BC000F8_A107EmployeeFirstName, BC000F8_A108EmployeeLastName, BC000F8_A109EmployeeEmail, BC000F8_A110EmployeeIsManager, BC000F8_A112EmployeeIsActive, BC000F8_A146EmployeeVactionDays,
               BC000F8_A177EmployeeVacationDaysSetDate, BC000F8_A187EmployeeAPIPassword, BC000F8_A188EmployeeFTEHours, BC000F8_A100CompanyId
               }
               , new Object[] {
               BC000F9_A101CompanyName
               }
               , new Object[] {
               BC000F10_A147EmployeeBalance, BC000F10_A106EmployeeId, BC000F10_A148EmployeeName, BC000F10_A111GAMUserGUID, BC000F10_A107EmployeeFirstName, BC000F10_A108EmployeeLastName, BC000F10_A109EmployeeEmail, BC000F10_A101CompanyName, BC000F10_A110EmployeeIsManager, BC000F10_A112EmployeeIsActive,
               BC000F10_A146EmployeeVactionDays, BC000F10_A177EmployeeVacationDaysSetDate, BC000F10_A187EmployeeAPIPassword, BC000F10_A188EmployeeFTEHours, BC000F10_A100CompanyId
               }
               , new Object[] {
               BC000F11_A109EmployeeEmail
               }
               , new Object[] {
               BC000F12_A106EmployeeId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F14_A106EmployeeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F17_A101CompanyName
               }
               , new Object[] {
               BC000F18_A102ProjectId
               }
               , new Object[] {
               BC000F19_A174SupportRequestId
               }
               , new Object[] {
               BC000F20_A127LeaveRequestId
               }
               , new Object[] {
               BC000F21_A118WorkHourLogId
               }
               , new Object[] {
               BC000F22_A147EmployeeBalance, BC000F22_A106EmployeeId, BC000F22_A148EmployeeName, BC000F22_A111GAMUserGUID, BC000F22_A107EmployeeFirstName, BC000F22_A108EmployeeLastName, BC000F22_A109EmployeeEmail, BC000F22_A101CompanyName, BC000F22_A110EmployeeIsManager, BC000F22_A112EmployeeIsActive,
               BC000F22_A146EmployeeVactionDays, BC000F22_A177EmployeeVacationDaysSetDate, BC000F22_A187EmployeeAPIPassword, BC000F22_A188EmployeeFTEHours, BC000F22_A100CompanyId
               }
               , new Object[] {
               BC000F23_A106EmployeeId, BC000F23_A186VacationSetDate, BC000F23_A179VacationSetDays, BC000F23_A189VacationSetDescription, BC000F23_n189VacationSetDescription
               }
               , new Object[] {
               BC000F24_A106EmployeeId, BC000F24_A186VacationSetDate
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F28_A106EmployeeId, BC000F28_A186VacationSetDate, BC000F28_A179VacationSetDays, BC000F28_A189VacationSetDescription, BC000F28_n189VacationSetDescription
               }
               , new Object[] {
               BC000F29_A106EmployeeId, BC000F29_A184EmployeeIsActiveInProject, BC000F29_A103ProjectName, BC000F29_A102ProjectId
               }
               , new Object[] {
               BC000F30_A106EmployeeId, BC000F30_A102ProjectId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F34_A103ProjectName
               }
               , new Object[] {
               BC000F35_A102ProjectId
               }
               , new Object[] {
               BC000F36_A118WorkHourLogId
               }
               , new Object[] {
               BC000F37_A106EmployeeId, BC000F37_A184EmployeeIsActiveInProject, BC000F37_A103ProjectName, BC000F37_A102ProjectId
               }
            }
         );
         Z184EmployeeIsActiveInProject = true;
         A184EmployeeIsActiveInProject = true;
         i184EmployeeIsActiveInProject = true;
         AV33Pgmname = "Employee_BC";
         Z188EmployeeFTEHours = 40;
         A188EmployeeFTEHours = 40;
         i188EmployeeFTEHours = 40;
         Z146EmployeeVactionDays = (decimal)(21);
         A146EmployeeVactionDays = (decimal)(21);
         i146EmployeeVactionDays = (decimal)(21);
         Z112EmployeeIsActive = false;
         A112EmployeeIsActive = false;
         i112EmployeeIsActive = false;
         Z112EmployeeIsActive = false;
         A112EmployeeIsActive = false;
         i112EmployeeIsActive = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120F2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_17 ;
      private short RcdFound17 ;
      private short nIsMod_27 ;
      private short RcdFound27 ;
      private short Z188EmployeeFTEHours ;
      private short A188EmployeeFTEHours ;
      private short Gx_BScreen ;
      private short RcdFound16 ;
      private short nRcdExists_27 ;
      private short nRcdExists_17 ;
      private short Gxremove27 ;
      private short Gxremove17 ;
      private short i188EmployeeFTEHours ;
      private int trnEnded ;
      private int nGXsfl_17_idx=1 ;
      private int nGXsfl_27_idx=1 ;
      private int AV34GXV1 ;
      private long Z106EmployeeId ;
      private long A106EmployeeId ;
      private long AV13Insert_CompanyId ;
      private long Z100CompanyId ;
      private long A100CompanyId ;
      private long GXt_int4 ;
      private long Z102ProjectId ;
      private long A102ProjectId ;
      private long i100CompanyId ;
      private decimal AV30EmployeeBalance ;
      private decimal Z147EmployeeBalance ;
      private decimal A147EmployeeBalance ;
      private decimal Z146EmployeeVactionDays ;
      private decimal A146EmployeeVactionDays ;
      private decimal GXt_decimal2 ;
      private decimal Z179VacationSetDays ;
      private decimal A179VacationSetDays ;
      private decimal i146EmployeeVactionDays ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode16 ;
      private string AV33Pgmname ;
      private string GXt_char1 ;
      private string Z148EmployeeName ;
      private string A148EmployeeName ;
      private string Z107EmployeeFirstName ;
      private string A107EmployeeFirstName ;
      private string Z108EmployeeLastName ;
      private string A108EmployeeLastName ;
      private string Z101CompanyName ;
      private string A101CompanyName ;
      private string A109EmployeeEmail_Internalname ;
      private string AV24Password ;
      private string sMode27 ;
      private string Z103ProjectName ;
      private string A103ProjectName ;
      private string sMode17 ;
      private DateTime Z177EmployeeVacationDaysSetDate ;
      private DateTime A177EmployeeVacationDaysSetDate ;
      private DateTime Z186VacationSetDate ;
      private DateTime A186VacationSetDate ;
      private bool returnInSub ;
      private bool Z110EmployeeIsManager ;
      private bool A110EmployeeIsManager ;
      private bool Z112EmployeeIsActive ;
      private bool A112EmployeeIsActive ;
      private bool GXt_boolean3 ;
      private bool Gx_longc ;
      private bool n189VacationSetDescription ;
      private bool Z184EmployeeIsActiveInProject ;
      private bool A184EmployeeIsActiveInProject ;
      private bool i112EmployeeIsActive ;
      private bool i184EmployeeIsActiveInProject ;
      private string AV31EmployeeAPIPassword ;
      private string Z111GAMUserGUID ;
      private string A111GAMUserGUID ;
      private string Z109EmployeeEmail ;
      private string A109EmployeeEmail ;
      private string Z187EmployeeAPIPassword ;
      private string A187EmployeeAPIPassword ;
      private string Z189VacationSetDescription ;
      private string A189VacationSetDescription ;
      private string N109EmployeeEmail ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtEmployee bcEmployee ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] BC000F9_A101CompanyName ;
      private decimal[] BC000F10_A147EmployeeBalance ;
      private long[] BC000F10_A106EmployeeId ;
      private string[] BC000F10_A148EmployeeName ;
      private string[] BC000F10_A111GAMUserGUID ;
      private string[] BC000F10_A107EmployeeFirstName ;
      private string[] BC000F10_A108EmployeeLastName ;
      private string[] BC000F10_A109EmployeeEmail ;
      private string[] BC000F10_A101CompanyName ;
      private bool[] BC000F10_A110EmployeeIsManager ;
      private bool[] BC000F10_A112EmployeeIsActive ;
      private decimal[] BC000F10_A146EmployeeVactionDays ;
      private DateTime[] BC000F10_A177EmployeeVacationDaysSetDate ;
      private string[] BC000F10_A187EmployeeAPIPassword ;
      private short[] BC000F10_A188EmployeeFTEHours ;
      private long[] BC000F10_A100CompanyId ;
      private string[] BC000F11_A109EmployeeEmail ;
      private long[] BC000F12_A106EmployeeId ;
      private decimal[] BC000F8_A147EmployeeBalance ;
      private long[] BC000F8_A106EmployeeId ;
      private string[] BC000F8_A148EmployeeName ;
      private string[] BC000F8_A111GAMUserGUID ;
      private string[] BC000F8_A107EmployeeFirstName ;
      private string[] BC000F8_A108EmployeeLastName ;
      private string[] BC000F8_A109EmployeeEmail ;
      private bool[] BC000F8_A110EmployeeIsManager ;
      private bool[] BC000F8_A112EmployeeIsActive ;
      private decimal[] BC000F8_A146EmployeeVactionDays ;
      private DateTime[] BC000F8_A177EmployeeVacationDaysSetDate ;
      private string[] BC000F8_A187EmployeeAPIPassword ;
      private short[] BC000F8_A188EmployeeFTEHours ;
      private long[] BC000F8_A100CompanyId ;
      private decimal[] BC000F7_A147EmployeeBalance ;
      private long[] BC000F7_A106EmployeeId ;
      private string[] BC000F7_A148EmployeeName ;
      private string[] BC000F7_A111GAMUserGUID ;
      private string[] BC000F7_A107EmployeeFirstName ;
      private string[] BC000F7_A108EmployeeLastName ;
      private string[] BC000F7_A109EmployeeEmail ;
      private bool[] BC000F7_A110EmployeeIsManager ;
      private bool[] BC000F7_A112EmployeeIsActive ;
      private decimal[] BC000F7_A146EmployeeVactionDays ;
      private DateTime[] BC000F7_A177EmployeeVacationDaysSetDate ;
      private string[] BC000F7_A187EmployeeAPIPassword ;
      private short[] BC000F7_A188EmployeeFTEHours ;
      private long[] BC000F7_A100CompanyId ;
      private long[] BC000F14_A106EmployeeId ;
      private string[] BC000F17_A101CompanyName ;
      private long[] BC000F18_A102ProjectId ;
      private long[] BC000F19_A174SupportRequestId ;
      private long[] BC000F20_A127LeaveRequestId ;
      private long[] BC000F21_A118WorkHourLogId ;
      private decimal[] BC000F22_A147EmployeeBalance ;
      private long[] BC000F22_A106EmployeeId ;
      private string[] BC000F22_A148EmployeeName ;
      private string[] BC000F22_A111GAMUserGUID ;
      private string[] BC000F22_A107EmployeeFirstName ;
      private string[] BC000F22_A108EmployeeLastName ;
      private string[] BC000F22_A109EmployeeEmail ;
      private string[] BC000F22_A101CompanyName ;
      private bool[] BC000F22_A110EmployeeIsManager ;
      private bool[] BC000F22_A112EmployeeIsActive ;
      private decimal[] BC000F22_A146EmployeeVactionDays ;
      private DateTime[] BC000F22_A177EmployeeVacationDaysSetDate ;
      private string[] BC000F22_A187EmployeeAPIPassword ;
      private short[] BC000F22_A188EmployeeFTEHours ;
      private long[] BC000F22_A100CompanyId ;
      private long[] BC000F23_A106EmployeeId ;
      private DateTime[] BC000F23_A186VacationSetDate ;
      private decimal[] BC000F23_A179VacationSetDays ;
      private string[] BC000F23_A189VacationSetDescription ;
      private bool[] BC000F23_n189VacationSetDescription ;
      private long[] BC000F24_A106EmployeeId ;
      private DateTime[] BC000F24_A186VacationSetDate ;
      private long[] BC000F6_A106EmployeeId ;
      private DateTime[] BC000F6_A186VacationSetDate ;
      private decimal[] BC000F6_A179VacationSetDays ;
      private string[] BC000F6_A189VacationSetDescription ;
      private bool[] BC000F6_n189VacationSetDescription ;
      private long[] BC000F5_A106EmployeeId ;
      private DateTime[] BC000F5_A186VacationSetDate ;
      private decimal[] BC000F5_A179VacationSetDays ;
      private string[] BC000F5_A189VacationSetDescription ;
      private bool[] BC000F5_n189VacationSetDescription ;
      private long[] BC000F28_A106EmployeeId ;
      private DateTime[] BC000F28_A186VacationSetDate ;
      private decimal[] BC000F28_A179VacationSetDays ;
      private string[] BC000F28_A189VacationSetDescription ;
      private bool[] BC000F28_n189VacationSetDescription ;
      private long[] BC000F29_A106EmployeeId ;
      private bool[] BC000F29_A184EmployeeIsActiveInProject ;
      private string[] BC000F29_A103ProjectName ;
      private long[] BC000F29_A102ProjectId ;
      private string[] BC000F4_A103ProjectName ;
      private long[] BC000F30_A106EmployeeId ;
      private long[] BC000F30_A102ProjectId ;
      private long[] BC000F3_A106EmployeeId ;
      private bool[] BC000F3_A184EmployeeIsActiveInProject ;
      private long[] BC000F3_A102ProjectId ;
      private long[] BC000F2_A106EmployeeId ;
      private bool[] BC000F2_A184EmployeeIsActiveInProject ;
      private long[] BC000F2_A102ProjectId ;
      private string[] BC000F34_A103ProjectName ;
      private long[] BC000F35_A102ProjectId ;
      private long[] BC000F36_A118WorkHourLogId ;
      private long[] BC000F37_A106EmployeeId ;
      private bool[] BC000F37_A184EmployeeIsActiveInProject ;
      private string[] BC000F37_A103ProjectName ;
      private long[] BC000F37_A102ProjectId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class employee_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class employee_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new UpdateCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new UpdateCursor(def[29])
       ,new UpdateCursor(def[30])
       ,new UpdateCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000F2;
        prmBC000F2 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F3;
        prmBC000F3 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F4;
        prmBC000F4 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F5;
        prmBC000F5 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("VacationSetDate",GXType.Date,8,0)
        };
        Object[] prmBC000F6;
        prmBC000F6 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("VacationSetDate",GXType.Date,8,0)
        };
        Object[] prmBC000F7;
        prmBC000F7 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F8;
        prmBC000F8 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F9;
        prmBC000F9 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000F10;
        prmBC000F10 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F11;
        prmBC000F11 = new Object[] {
        new ParDef("EmployeeEmail",GXType.VarChar,100,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F12;
        prmBC000F12 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F13;
        prmBC000F13 = new Object[] {
        new ParDef("EmployeeBalance",GXType.Number,4,1) ,
        new ParDef("EmployeeName",GXType.Char,100,0) ,
        new ParDef("GAMUserGUID",GXType.VarChar,100,60) ,
        new ParDef("EmployeeFirstName",GXType.Char,100,0) ,
        new ParDef("EmployeeLastName",GXType.Char,100,0) ,
        new ParDef("EmployeeEmail",GXType.VarChar,100,0) ,
        new ParDef("EmployeeIsManager",GXType.Boolean,4,0) ,
        new ParDef("EmployeeIsActive",GXType.Boolean,4,0) ,
        new ParDef("EmployeeVactionDays",GXType.Number,4,1) ,
        new ParDef("EmployeeVacationDaysSetDate",GXType.Date,8,0) ,
        new ParDef("EmployeeAPIPassword",GXType.VarChar,40,0) ,
        new ParDef("EmployeeFTEHours",GXType.Int16,4,0) ,
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000F14;
        prmBC000F14 = new Object[] {
        };
        Object[] prmBC000F15;
        prmBC000F15 = new Object[] {
        new ParDef("EmployeeBalance",GXType.Number,4,1) ,
        new ParDef("EmployeeName",GXType.Char,100,0) ,
        new ParDef("GAMUserGUID",GXType.VarChar,100,60) ,
        new ParDef("EmployeeFirstName",GXType.Char,100,0) ,
        new ParDef("EmployeeLastName",GXType.Char,100,0) ,
        new ParDef("EmployeeEmail",GXType.VarChar,100,0) ,
        new ParDef("EmployeeIsManager",GXType.Boolean,4,0) ,
        new ParDef("EmployeeIsActive",GXType.Boolean,4,0) ,
        new ParDef("EmployeeVactionDays",GXType.Number,4,1) ,
        new ParDef("EmployeeVacationDaysSetDate",GXType.Date,8,0) ,
        new ParDef("EmployeeAPIPassword",GXType.VarChar,40,0) ,
        new ParDef("EmployeeFTEHours",GXType.Int16,4,0) ,
        new ParDef("CompanyId",GXType.Int64,10,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F16;
        prmBC000F16 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F17;
        prmBC000F17 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmBC000F18;
        prmBC000F18 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F19;
        prmBC000F19 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F20;
        prmBC000F20 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F21;
        prmBC000F21 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F22;
        prmBC000F22 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F23;
        prmBC000F23 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("VacationSetDate",GXType.Date,8,0)
        };
        Object[] prmBC000F24;
        prmBC000F24 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("VacationSetDate",GXType.Date,8,0)
        };
        Object[] prmBC000F25;
        prmBC000F25 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("VacationSetDate",GXType.Date,8,0) ,
        new ParDef("VacationSetDays",GXType.Number,4,1) ,
        new ParDef("VacationSetDescription",GXType.VarChar,200,0){Nullable=true}
        };
        Object[] prmBC000F26;
        prmBC000F26 = new Object[] {
        new ParDef("VacationSetDays",GXType.Number,4,1) ,
        new ParDef("VacationSetDescription",GXType.VarChar,200,0){Nullable=true} ,
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("VacationSetDate",GXType.Date,8,0)
        };
        Object[] prmBC000F27;
        prmBC000F27 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("VacationSetDate",GXType.Date,8,0)
        };
        Object[] prmBC000F28;
        prmBC000F28 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000F29;
        prmBC000F29 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F30;
        prmBC000F30 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F31;
        prmBC000F31 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("EmployeeIsActiveInProject",GXType.Boolean,4,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F32;
        prmBC000F32 = new Object[] {
        new ParDef("EmployeeIsActiveInProject",GXType.Boolean,4,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F33;
        prmBC000F33 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F34;
        prmBC000F34 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F35;
        prmBC000F35 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F36;
        prmBC000F36 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmBC000F37;
        prmBC000F37 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000F2", "SELECT EmployeeId, EmployeeIsActiveInProject, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId  FOR UPDATE OF EmployeeProject",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F3", "SELECT EmployeeId, EmployeeIsActiveInProject, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F4", "SELECT ProjectName FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F5", "SELECT EmployeeId, VacationSetDate, VacationSetDays, VacationSetDescription FROM EmployeeVacationSet WHERE EmployeeId = :EmployeeId AND VacationSetDate = :VacationSetDate  FOR UPDATE OF EmployeeVacationSet",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F6", "SELECT EmployeeId, VacationSetDate, VacationSetDays, VacationSetDescription FROM EmployeeVacationSet WHERE EmployeeId = :EmployeeId AND VacationSetDate = :VacationSetDate ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F7", "SELECT EmployeeBalance, EmployeeId, EmployeeName, GAMUserGUID, EmployeeFirstName, EmployeeLastName, EmployeeEmail, EmployeeIsManager, EmployeeIsActive, EmployeeVactionDays, EmployeeVacationDaysSetDate, EmployeeAPIPassword, EmployeeFTEHours, CompanyId FROM Employee WHERE EmployeeId = :EmployeeId  FOR UPDATE OF Employee",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F8", "SELECT EmployeeBalance, EmployeeId, EmployeeName, GAMUserGUID, EmployeeFirstName, EmployeeLastName, EmployeeEmail, EmployeeIsManager, EmployeeIsActive, EmployeeVactionDays, EmployeeVacationDaysSetDate, EmployeeAPIPassword, EmployeeFTEHours, CompanyId FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F9", "SELECT CompanyName FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F10", "SELECT TM1.EmployeeBalance, TM1.EmployeeId, TM1.EmployeeName, TM1.GAMUserGUID, TM1.EmployeeFirstName, TM1.EmployeeLastName, TM1.EmployeeEmail, T2.CompanyName, TM1.EmployeeIsManager, TM1.EmployeeIsActive, TM1.EmployeeVactionDays, TM1.EmployeeVacationDaysSetDate, TM1.EmployeeAPIPassword, TM1.EmployeeFTEHours, TM1.CompanyId FROM (Employee TM1 INNER JOIN Company T2 ON T2.CompanyId = TM1.CompanyId) WHERE TM1.EmployeeId = :EmployeeId ORDER BY TM1.EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F11", "SELECT EmployeeEmail FROM Employee WHERE (EmployeeEmail = :EmployeeEmail) AND (Not ( EmployeeId = :EmployeeId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F12", "SELECT EmployeeId FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F13", "SAVEPOINT gxupdate;INSERT INTO Employee(EmployeeBalance, EmployeeName, GAMUserGUID, EmployeeFirstName, EmployeeLastName, EmployeeEmail, EmployeeIsManager, EmployeeIsActive, EmployeeVactionDays, EmployeeVacationDaysSetDate, EmployeeAPIPassword, EmployeeFTEHours, CompanyId) VALUES(:EmployeeBalance, :EmployeeName, :GAMUserGUID, :EmployeeFirstName, :EmployeeLastName, :EmployeeEmail, :EmployeeIsManager, :EmployeeIsActive, :EmployeeVactionDays, :EmployeeVacationDaysSetDate, :EmployeeAPIPassword, :EmployeeFTEHours, :CompanyId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000F13)
           ,new CursorDef("BC000F14", "SELECT currval('EmployeeId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F15", "SAVEPOINT gxupdate;UPDATE Employee SET EmployeeBalance=:EmployeeBalance, EmployeeName=:EmployeeName, GAMUserGUID=:GAMUserGUID, EmployeeFirstName=:EmployeeFirstName, EmployeeLastName=:EmployeeLastName, EmployeeEmail=:EmployeeEmail, EmployeeIsManager=:EmployeeIsManager, EmployeeIsActive=:EmployeeIsActive, EmployeeVactionDays=:EmployeeVactionDays, EmployeeVacationDaysSetDate=:EmployeeVacationDaysSetDate, EmployeeAPIPassword=:EmployeeAPIPassword, EmployeeFTEHours=:EmployeeFTEHours, CompanyId=:CompanyId  WHERE EmployeeId = :EmployeeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F15)
           ,new CursorDef("BC000F16", "SAVEPOINT gxupdate;DELETE FROM Employee  WHERE EmployeeId = :EmployeeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F16)
           ,new CursorDef("BC000F17", "SELECT CompanyName FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F18", "SELECT ProjectId FROM Project WHERE ProjectManagerId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000F19", "SELECT SupportRequestId FROM SupportRequest WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000F20", "SELECT LeaveRequestId FROM LeaveRequest WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000F21", "SELECT WorkHourLogId FROM WorkHourLog WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000F22", "SELECT TM1.EmployeeBalance, TM1.EmployeeId, TM1.EmployeeName, TM1.GAMUserGUID, TM1.EmployeeFirstName, TM1.EmployeeLastName, TM1.EmployeeEmail, T2.CompanyName, TM1.EmployeeIsManager, TM1.EmployeeIsActive, TM1.EmployeeVactionDays, TM1.EmployeeVacationDaysSetDate, TM1.EmployeeAPIPassword, TM1.EmployeeFTEHours, TM1.CompanyId FROM (Employee TM1 INNER JOIN Company T2 ON T2.CompanyId = TM1.CompanyId) WHERE TM1.EmployeeId = :EmployeeId ORDER BY TM1.EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F22,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F23", "SELECT EmployeeId, VacationSetDate, VacationSetDays, VacationSetDescription FROM EmployeeVacationSet WHERE EmployeeId = :EmployeeId and VacationSetDate = :VacationSetDate ORDER BY EmployeeId, VacationSetDate ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F23,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F24", "SELECT EmployeeId, VacationSetDate FROM EmployeeVacationSet WHERE EmployeeId = :EmployeeId AND VacationSetDate = :VacationSetDate ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F25", "SAVEPOINT gxupdate;INSERT INTO EmployeeVacationSet(EmployeeId, VacationSetDate, VacationSetDays, VacationSetDescription) VALUES(:EmployeeId, :VacationSetDate, :VacationSetDays, :VacationSetDescription);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000F25)
           ,new CursorDef("BC000F26", "SAVEPOINT gxupdate;UPDATE EmployeeVacationSet SET VacationSetDays=:VacationSetDays, VacationSetDescription=:VacationSetDescription  WHERE EmployeeId = :EmployeeId AND VacationSetDate = :VacationSetDate;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F26)
           ,new CursorDef("BC000F27", "SAVEPOINT gxupdate;DELETE FROM EmployeeVacationSet  WHERE EmployeeId = :EmployeeId AND VacationSetDate = :VacationSetDate;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F27)
           ,new CursorDef("BC000F28", "SELECT EmployeeId, VacationSetDate, VacationSetDays, VacationSetDescription FROM EmployeeVacationSet WHERE EmployeeId = :EmployeeId ORDER BY EmployeeId, VacationSetDate ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F28,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F29", "SELECT T1.EmployeeId, T1.EmployeeIsActiveInProject, T2.ProjectName, T1.ProjectId FROM (EmployeeProject T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) WHERE T1.EmployeeId = :EmployeeId and T1.ProjectId = :ProjectId ORDER BY T1.EmployeeId, T1.ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F29,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F30", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F30,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F31", "SAVEPOINT gxupdate;INSERT INTO EmployeeProject(EmployeeId, EmployeeIsActiveInProject, ProjectId) VALUES(:EmployeeId, :EmployeeIsActiveInProject, :ProjectId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000F31)
           ,new CursorDef("BC000F32", "SAVEPOINT gxupdate;UPDATE EmployeeProject SET EmployeeIsActiveInProject=:EmployeeIsActiveInProject  WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F32)
           ,new CursorDef("BC000F33", "SAVEPOINT gxupdate;DELETE FROM EmployeeProject  WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F33)
           ,new CursorDef("BC000F34", "SELECT ProjectName FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F34,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F35", "SELECT ProjectId FROM Project WHERE ProjectManagerId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F35,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000F36", "SELECT WorkHourLogId FROM WorkHourLog WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F36,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000F37", "SELECT T1.EmployeeId, T1.EmployeeIsActiveInProject, T2.ProjectName, T1.ProjectId FROM (EmployeeProject T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) WHERE T1.EmployeeId = :EmployeeId ORDER BY T1.EmployeeId, T1.ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F37,11, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 5 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((long[]) buf[13])[0] = rslt.getLong(14);
              return;
           case 6 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((long[]) buf[13])[0] = rslt.getLong(14);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 8 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((long[]) buf[14])[0] = rslt.getLong(15);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 20 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((long[]) buf[14])[0] = rslt.getLong(15);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 22 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              return;
           case 26 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 27 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
           case 28 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 33 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 34 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 35 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
     }
  }

}

}
