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
   public class leaverequest_bc : GxSilentTrn, IGxSilentTrn
   {
      public leaverequest_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequest_bc( IGxContext context )
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
         ReadRow0J21( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0J21( ) ;
         standaloneModal( ) ;
         AddRow0J21( ) ;
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
            E110J2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z127LeaveRequestId = A127LeaveRequestId;
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

      protected void CONFIRM_0J0( )
      {
         BeforeValidate0J21( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0J21( ) ;
            }
            else
            {
               CheckExtendedTable0J21( ) ;
               if ( AnyError == 0 )
               {
                  ZM0J21( 19) ;
                  ZM0J21( 20) ;
               }
               CloseExtendedTableCursors0J21( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120J2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_decimal1 = AV35LeaveRequestDuration;
            new getleaverequestduration(context ).execute(  AV26LeaveRequestId, out  GXt_decimal1) ;
            AV35LeaveRequestDuration = GXt_decimal1;
         }
         GXt_int2 = AV17EmployeeCompany;
         new getloggedinusercompanyid(context ).execute( out  GXt_int2) ;
         AV17EmployeeCompany = (short)(GXt_int2);
         AV44LeaveTypeCompanyId = AV17EmployeeCompany;
         GXt_int2 = AV18EmployeeId;
         new getloggedinemployeeid(context ).execute( out  GXt_int2) ;
         AV18EmployeeId = GXt_int2;
         AV36ISManager = AV9GAMUser.checkrole("Manager");
         AV38IsProjectManager = AV9GAMUser.checkrole("Project Manager");
         if ( ( AV38IsProjectManager ) || ( AV36ISManager ) )
         {
            GXt_objcol_int3 = AV40projectIds;
            new projectsformanager(context ).execute(  AV18EmployeeId, out  GXt_objcol_int3) ;
            AV40projectIds = GXt_objcol_int3;
            GXt_int2 = AV42CompanyId;
            new getloggedinusercompanyid(context ).execute( out  GXt_int2) ;
            AV42CompanyId = GXt_int2;
            GXt_objcol_int3 = AV43Employees;
            new getemployeeidsbyprojectorcompany(context ).execute(  AV40projectIds,  AV42CompanyId, out  GXt_objcol_int3) ;
            AV43Employees = GXt_objcol_int3;
         }
         else
         {
            AV43Employees.Add(AV18EmployeeId, 0);
         }
         GXt_int4 = (short)(Math.Round(AV20EmployyeeAvailableVacationDays, 18, MidpointRounding.ToEven));
         new getemployeevactiondaysleft(context ).execute(  AV18EmployeeId, out  GXt_int4) ;
         AV20EmployyeeAvailableVacationDays = (decimal)(GXt_int4);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV32WWPContext) ;
         AV29TrnContext.FromXml(AV31WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV29TrnContext.gxTpr_Transactionname, AV52Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV53GXV1 = 1;
            while ( AV53GXV1 <= AV29TrnContext.gxTpr_Attributes.Count )
            {
               AV30TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV29TrnContext.gxTpr_Attributes.Item(AV53GXV1));
               if ( StringUtil.StrCmp(AV30TrnContextAtt.gxTpr_Attributename, "LeaveTypeId") == 0 )
               {
                  AV24Insert_LeaveTypeId = (long)(Math.Round(NumberUtil.Val( AV30TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV30TrnContextAtt.gxTpr_Attributename, "EmployeeId") == 0 )
               {
                  AV23Insert_EmployeeId = (long)(Math.Round(NumberUtil.Val( AV30TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV53GXV1 = (int)(AV53GXV1+1);
            }
         }
      }

      protected void E110J2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ( StringUtil.StrCmp(A132LeaveRequestStatus, "Pending") == 0 ) )
         {
            new sdsendleaverequestmail(context).executeSubmit(  A129LeaveRequestStartDate,  A130LeaveRequestEndDate,  A133LeaveRequestDescription,  A125LeaveTypeName,  A171LeaveRequestHalfDay,  A148EmployeeName,  A106EmployeeId) ;
            AV37Mesage = "Leave Request successful";
            CallWebObject(formatLink("leaverequestww.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV37Mesage))}, new string[] {"Mesage"}) );
            context.wjLocDisableFrm = 1;
         }
         if ( ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) && ( StringUtil.StrCmp(A132LeaveRequestStatus, "Pending") == 0 ) )
         {
         }
      }

      protected void E130J2( )
      {
         /* LeaveRequestEndDate_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_decimal1 = AV35LeaveRequestDuration;
         new getleaverequestdays(context ).execute(  A129LeaveRequestStartDate,  A130LeaveRequestEndDate,  A171LeaveRequestHalfDay,  AV18EmployeeId, out  GXt_decimal1) ;
         AV35LeaveRequestDuration = GXt_decimal1;
      }

      protected void E140J2( )
      {
         /* LeaveRequestStartDate_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_decimal1 = AV35LeaveRequestDuration;
         new getleaverequestdays(context ).execute(  A129LeaveRequestStartDate,  A130LeaveRequestEndDate,  A171LeaveRequestHalfDay,  AV18EmployeeId, out  GXt_decimal1) ;
         AV35LeaveRequestDuration = GXt_decimal1;
      }

      protected void E150J2( )
      {
         /* EmployeeId_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_int4 = (short)(Math.Round(AV20EmployyeeAvailableVacationDays, 18, MidpointRounding.ToEven));
         new getemployeevactiondaysleft(context ).execute(  A106EmployeeId, out  GXt_int4) ;
         AV20EmployyeeAvailableVacationDays = (decimal)(GXt_int4);
      }

      protected void E160J2( )
      {
         /* Employeeid_Controlvaluechanged Routine */
         returnInSub = false;
         AV7Employee.Load(AV18EmployeeId);
         AV44LeaveTypeCompanyId = AV7Employee.gxTpr_Companyid;
         GXt_int4 = (short)(Math.Round(AV20EmployyeeAvailableVacationDays, 18, MidpointRounding.ToEven));
         new getemployeevactiondaysleft(context ).execute(  AV18EmployeeId, out  GXt_int4) ;
         AV20EmployyeeAvailableVacationDays = (decimal)(GXt_int4);
         GXt_decimal1 = AV49EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  AV18EmployeeId, out  GXt_decimal1) ;
         AV49EmployeeBalance = GXt_decimal1;
      }

      protected void E170J2( )
      {
         /* LeaveRequestHalfDay_Click Routine */
         returnInSub = false;
         GXt_decimal1 = AV35LeaveRequestDuration;
         new getleaverequestdays(context ).execute(  A129LeaveRequestStartDate,  A130LeaveRequestEndDate,  A171LeaveRequestHalfDay,  AV18EmployeeId, out  GXt_decimal1) ;
         AV35LeaveRequestDuration = GXt_decimal1;
      }

      protected void ZM0J21( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z131LeaveRequestDuration = A131LeaveRequestDuration;
            Z130LeaveRequestEndDate = A130LeaveRequestEndDate;
            Z128LeaveRequestDate = A128LeaveRequestDate;
            Z129LeaveRequestStartDate = A129LeaveRequestStartDate;
            Z171LeaveRequestHalfDay = A171LeaveRequestHalfDay;
            Z132LeaveRequestStatus = A132LeaveRequestStatus;
            Z133LeaveRequestDescription = A133LeaveRequestDescription;
            Z134LeaveRequestRejectionReason = A134LeaveRequestRejectionReason;
            Z124LeaveTypeId = A124LeaveTypeId;
            Z106EmployeeId = A106EmployeeId;
         }
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            Z125LeaveTypeName = A125LeaveTypeName;
            Z144LeaveTypeVacationLeave = A144LeaveTypeVacationLeave;
         }
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            Z147EmployeeBalance = A147EmployeeBalance;
            Z148EmployeeName = A148EmployeeName;
         }
         if ( GX_JID == -18 )
         {
            Z127LeaveRequestId = A127LeaveRequestId;
            Z131LeaveRequestDuration = A131LeaveRequestDuration;
            Z130LeaveRequestEndDate = A130LeaveRequestEndDate;
            Z128LeaveRequestDate = A128LeaveRequestDate;
            Z129LeaveRequestStartDate = A129LeaveRequestStartDate;
            Z171LeaveRequestHalfDay = A171LeaveRequestHalfDay;
            Z132LeaveRequestStatus = A132LeaveRequestStatus;
            Z133LeaveRequestDescription = A133LeaveRequestDescription;
            Z134LeaveRequestRejectionReason = A134LeaveRequestRejectionReason;
            Z124LeaveTypeId = A124LeaveTypeId;
            Z106EmployeeId = A106EmployeeId;
            Z125LeaveTypeName = A125LeaveTypeName;
            Z144LeaveTypeVacationLeave = A144LeaveTypeVacationLeave;
            Z147EmployeeBalance = A147EmployeeBalance;
            Z148EmployeeName = A148EmployeeName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV52Pgmname = "LeaveRequest_BC";
         Gx_BScreen = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void standaloneModal( )
      {
         A128LeaveRequestDate = Gx_date;
         if ( IsIns( )  && (0==A106EmployeeId) && ( Gx_BScreen == 0 ) )
         {
            A106EmployeeId = AV18EmployeeId;
         }
         else
         {
            if ( IsIns( )  )
            {
               A106EmployeeId = AV18EmployeeId;
            }
         }
         if ( IsIns( )  && (DateTime.MinValue==A129LeaveRequestStartDate) && ( Gx_BScreen == 0 ) )
         {
            A129LeaveRequestStartDate = Gx_date;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor BC000J5 */
            pr_default.execute(3, new Object[] {A106EmployeeId});
            A147EmployeeBalance = BC000J5_A147EmployeeBalance[0];
            A148EmployeeName = BC000J5_A148EmployeeName[0];
            pr_default.close(3);
            GXt_decimal1 = AV49EmployeeBalance;
            new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal1) ;
            AV49EmployeeBalance = GXt_decimal1;
         }
      }

      protected void Load0J21( )
      {
         /* Using cursor BC000J6 */
         pr_default.execute(4, new Object[] {A127LeaveRequestId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound21 = 1;
            A147EmployeeBalance = BC000J6_A147EmployeeBalance[0];
            A131LeaveRequestDuration = BC000J6_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = BC000J6_A130LeaveRequestEndDate[0];
            A125LeaveTypeName = BC000J6_A125LeaveTypeName[0];
            A128LeaveRequestDate = BC000J6_A128LeaveRequestDate[0];
            A129LeaveRequestStartDate = BC000J6_A129LeaveRequestStartDate[0];
            A171LeaveRequestHalfDay = BC000J6_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = BC000J6_n171LeaveRequestHalfDay[0];
            A132LeaveRequestStatus = BC000J6_A132LeaveRequestStatus[0];
            A133LeaveRequestDescription = BC000J6_A133LeaveRequestDescription[0];
            A134LeaveRequestRejectionReason = BC000J6_A134LeaveRequestRejectionReason[0];
            A148EmployeeName = BC000J6_A148EmployeeName[0];
            A144LeaveTypeVacationLeave = BC000J6_A144LeaveTypeVacationLeave[0];
            A124LeaveTypeId = BC000J6_A124LeaveTypeId[0];
            A106EmployeeId = BC000J6_A106EmployeeId[0];
            ZM0J21( -18) ;
         }
         pr_default.close(4);
         OnLoadActions0J21( ) ;
      }

      protected void OnLoadActions0J21( )
      {
         if ( StringUtil.StrCmp(A171LeaveRequestHalfDay, "") != 0 )
         {
            A130LeaveRequestEndDate = A129LeaveRequestStartDate;
         }
         GXt_decimal1 = A131LeaveRequestDuration;
         new getleaverequestdays(context ).execute(  A129LeaveRequestStartDate,  A130LeaveRequestEndDate,  A171LeaveRequestHalfDay,  AV18EmployeeId, out  GXt_decimal1) ;
         A131LeaveRequestDuration = GXt_decimal1;
         GXt_decimal1 = AV49EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal1) ;
         AV49EmployeeBalance = GXt_decimal1;
      }

      protected void CheckExtendedTable0J21( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000J4 */
         pr_default.execute(2, new Object[] {A124LeaveTypeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'LeaveType'.", "ForeignKeyNotFound", 1, "LEAVETYPEID");
            AnyError = 1;
         }
         A125LeaveTypeName = BC000J4_A125LeaveTypeName[0];
         A144LeaveTypeVacationLeave = BC000J4_A144LeaveTypeVacationLeave[0];
         pr_default.close(2);
         if ( StringUtil.StrCmp(A171LeaveRequestHalfDay, "") != 0 )
         {
            A130LeaveRequestEndDate = A129LeaveRequestStartDate;
         }
         GXt_decimal1 = A131LeaveRequestDuration;
         new getleaverequestdays(context ).execute(  A129LeaveRequestStartDate,  A130LeaveRequestEndDate,  A171LeaveRequestHalfDay,  AV18EmployeeId, out  GXt_decimal1) ;
         A131LeaveRequestDuration = GXt_decimal1;
         if ( (DateTime.MinValue==A129LeaveRequestStartDate) )
         {
            GX_msglist.addItem("Start date is required", 1, "");
            AnyError = 1;
         }
         if ( ! (DateTime.MinValue==A130LeaveRequestEndDate) && ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) < DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) ) )
         {
            GX_msglist.addItem("Invalid Leave end date", 1, "");
            AnyError = 1;
         }
         if ( (DateTime.MinValue==A130LeaveRequestEndDate) )
         {
            GX_msglist.addItem("End date is required", 1, "");
            AnyError = 1;
         }
         if ( ( A131LeaveRequestDuration <= Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Invalid Leave Duration", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A132LeaveRequestStatus, "Pending") == 0 ) || ( StringUtil.StrCmp(A132LeaveRequestStatus, "Approved") == 0 ) || ( StringUtil.StrCmp(A132LeaveRequestStatus, "Rejected") == 0 ) ) )
         {
            GX_msglist.addItem("Field Leave Request Status is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A133LeaveRequestDescription)) )
         {
            GX_msglist.addItem("Leave Description is Required", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000J5 */
         pr_default.execute(3, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
         }
         A147EmployeeBalance = BC000J5_A147EmployeeBalance[0];
         A148EmployeeName = BC000J5_A148EmployeeName[0];
         pr_default.close(3);
         GXt_decimal1 = AV49EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal1) ;
         AV49EmployeeBalance = GXt_decimal1;
         if ( ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( Gx_date ) ) && ! ( new userhasrole(context).executeUdp(  "Project Manager") || new userhasrole(context).executeUdp(  "Manager") ) )
         {
            GX_msglist.addItem("Invalid Leave start date", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0J21( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0J21( )
      {
         /* Using cursor BC000J7 */
         pr_default.execute(5, new Object[] {A127LeaveRequestId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound21 = 1;
         }
         else
         {
            RcdFound21 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000J3 */
         pr_default.execute(1, new Object[] {A127LeaveRequestId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0J21( 18) ;
            RcdFound21 = 1;
            A127LeaveRequestId = BC000J3_A127LeaveRequestId[0];
            A131LeaveRequestDuration = BC000J3_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = BC000J3_A130LeaveRequestEndDate[0];
            A128LeaveRequestDate = BC000J3_A128LeaveRequestDate[0];
            A129LeaveRequestStartDate = BC000J3_A129LeaveRequestStartDate[0];
            A171LeaveRequestHalfDay = BC000J3_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = BC000J3_n171LeaveRequestHalfDay[0];
            A132LeaveRequestStatus = BC000J3_A132LeaveRequestStatus[0];
            A133LeaveRequestDescription = BC000J3_A133LeaveRequestDescription[0];
            A134LeaveRequestRejectionReason = BC000J3_A134LeaveRequestRejectionReason[0];
            A124LeaveTypeId = BC000J3_A124LeaveTypeId[0];
            A106EmployeeId = BC000J3_A106EmployeeId[0];
            Z127LeaveRequestId = A127LeaveRequestId;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0J21( ) ;
            if ( AnyError == 1 )
            {
               RcdFound21 = 0;
               InitializeNonKey0J21( ) ;
            }
            Gx_mode = sMode21;
         }
         else
         {
            RcdFound21 = 0;
            InitializeNonKey0J21( ) ;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode21;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0J21( ) ;
         if ( RcdFound21 == 0 )
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
         CONFIRM_0J0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0J21( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000J2 */
            pr_default.execute(0, new Object[] {A127LeaveRequestId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LeaveRequest"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z131LeaveRequestDuration != BC000J2_A131LeaveRequestDuration[0] ) || ( DateTimeUtil.ResetTime ( Z130LeaveRequestEndDate ) != DateTimeUtil.ResetTime ( BC000J2_A130LeaveRequestEndDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z128LeaveRequestDate ) != DateTimeUtil.ResetTime ( BC000J2_A128LeaveRequestDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z129LeaveRequestStartDate ) != DateTimeUtil.ResetTime ( BC000J2_A129LeaveRequestStartDate[0] ) ) || ( StringUtil.StrCmp(Z171LeaveRequestHalfDay, BC000J2_A171LeaveRequestHalfDay[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z132LeaveRequestStatus, BC000J2_A132LeaveRequestStatus[0]) != 0 ) || ( StringUtil.StrCmp(Z133LeaveRequestDescription, BC000J2_A133LeaveRequestDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z134LeaveRequestRejectionReason, BC000J2_A134LeaveRequestRejectionReason[0]) != 0 ) || ( Z124LeaveTypeId != BC000J2_A124LeaveTypeId[0] ) || ( Z106EmployeeId != BC000J2_A106EmployeeId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"LeaveRequest"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J21( )
      {
         BeforeValidate0J21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J21( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J21( 0) ;
            CheckOptimisticConcurrency0J21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000J8 */
                     pr_default.execute(6, new Object[] {A131LeaveRequestDuration, A130LeaveRequestEndDate, A128LeaveRequestDate, A129LeaveRequestStartDate, n171LeaveRequestHalfDay, A171LeaveRequestHalfDay, A132LeaveRequestStatus, A133LeaveRequestDescription, A134LeaveRequestRejectionReason, A124LeaveTypeId, A106EmployeeId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000J9 */
                     pr_default.execute(7);
                     A127LeaveRequestId = BC000J9_A127LeaveRequestId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("LeaveRequest");
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
               Load0J21( ) ;
            }
            EndLevel0J21( ) ;
         }
         CloseExtendedTableCursors0J21( ) ;
      }

      protected void Update0J21( )
      {
         BeforeValidate0J21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J21( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0J21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000J10 */
                     pr_default.execute(8, new Object[] {A131LeaveRequestDuration, A130LeaveRequestEndDate, A128LeaveRequestDate, A129LeaveRequestStartDate, n171LeaveRequestHalfDay, A171LeaveRequestHalfDay, A132LeaveRequestStatus, A133LeaveRequestDescription, A134LeaveRequestRejectionReason, A124LeaveTypeId, A106EmployeeId, A127LeaveRequestId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("LeaveRequest");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LeaveRequest"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0J21( ) ;
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
            EndLevel0J21( ) ;
         }
         CloseExtendedTableCursors0J21( ) ;
      }

      protected void DeferredUpdate0J21( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0J21( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J21( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J21( ) ;
            AfterConfirm0J21( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J21( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000J11 */
                  pr_default.execute(9, new Object[] {A127LeaveRequestId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("LeaveRequest");
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
         sMode21 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0J21( ) ;
         Gx_mode = sMode21;
      }

      protected void OnDeleteControls0J21( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000J12 */
            pr_default.execute(10, new Object[] {A124LeaveTypeId});
            A125LeaveTypeName = BC000J12_A125LeaveTypeName[0];
            A144LeaveTypeVacationLeave = BC000J12_A144LeaveTypeVacationLeave[0];
            pr_default.close(10);
            /* Using cursor BC000J13 */
            pr_default.execute(11, new Object[] {A106EmployeeId});
            A147EmployeeBalance = BC000J13_A147EmployeeBalance[0];
            A148EmployeeName = BC000J13_A148EmployeeName[0];
            pr_default.close(11);
            GXt_decimal1 = AV49EmployeeBalance;
            new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal1) ;
            AV49EmployeeBalance = GXt_decimal1;
         }
      }

      protected void EndLevel0J21( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0J21( ) ;
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

      public void ScanKeyStart0J21( )
      {
         /* Scan By routine */
         /* Using cursor BC000J14 */
         pr_default.execute(12, new Object[] {A127LeaveRequestId});
         RcdFound21 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound21 = 1;
            A147EmployeeBalance = BC000J14_A147EmployeeBalance[0];
            A127LeaveRequestId = BC000J14_A127LeaveRequestId[0];
            A131LeaveRequestDuration = BC000J14_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = BC000J14_A130LeaveRequestEndDate[0];
            A125LeaveTypeName = BC000J14_A125LeaveTypeName[0];
            A128LeaveRequestDate = BC000J14_A128LeaveRequestDate[0];
            A129LeaveRequestStartDate = BC000J14_A129LeaveRequestStartDate[0];
            A171LeaveRequestHalfDay = BC000J14_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = BC000J14_n171LeaveRequestHalfDay[0];
            A132LeaveRequestStatus = BC000J14_A132LeaveRequestStatus[0];
            A133LeaveRequestDescription = BC000J14_A133LeaveRequestDescription[0];
            A134LeaveRequestRejectionReason = BC000J14_A134LeaveRequestRejectionReason[0];
            A148EmployeeName = BC000J14_A148EmployeeName[0];
            A144LeaveTypeVacationLeave = BC000J14_A144LeaveTypeVacationLeave[0];
            A124LeaveTypeId = BC000J14_A124LeaveTypeId[0];
            A106EmployeeId = BC000J14_A106EmployeeId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0J21( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound21 = 0;
         ScanKeyLoad0J21( ) ;
      }

      protected void ScanKeyLoad0J21( )
      {
         sMode21 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound21 = 1;
            A147EmployeeBalance = BC000J14_A147EmployeeBalance[0];
            A127LeaveRequestId = BC000J14_A127LeaveRequestId[0];
            A131LeaveRequestDuration = BC000J14_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = BC000J14_A130LeaveRequestEndDate[0];
            A125LeaveTypeName = BC000J14_A125LeaveTypeName[0];
            A128LeaveRequestDate = BC000J14_A128LeaveRequestDate[0];
            A129LeaveRequestStartDate = BC000J14_A129LeaveRequestStartDate[0];
            A171LeaveRequestHalfDay = BC000J14_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = BC000J14_n171LeaveRequestHalfDay[0];
            A132LeaveRequestStatus = BC000J14_A132LeaveRequestStatus[0];
            A133LeaveRequestDescription = BC000J14_A133LeaveRequestDescription[0];
            A134LeaveRequestRejectionReason = BC000J14_A134LeaveRequestRejectionReason[0];
            A148EmployeeName = BC000J14_A148EmployeeName[0];
            A144LeaveTypeVacationLeave = BC000J14_A144LeaveTypeVacationLeave[0];
            A124LeaveTypeId = BC000J14_A124LeaveTypeId[0];
            A106EmployeeId = BC000J14_A106EmployeeId[0];
         }
         Gx_mode = sMode21;
      }

      protected void ScanKeyEnd0J21( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0J21( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0J21( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J21( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J21( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J21( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J21( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J21( )
      {
      }

      protected void send_integrity_lvl_hashes0J21( )
      {
      }

      protected void AddRow0J21( )
      {
         VarsToRow21( bcLeaveRequest) ;
      }

      protected void ReadRow0J21( )
      {
         RowToVars21( bcLeaveRequest, 1) ;
      }

      protected void InitializeNonKey0J21( )
      {
         A131LeaveRequestDuration = 0;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A106EmployeeId = AV18EmployeeId;
         AV49EmployeeBalance = 0;
         A147EmployeeBalance = 0;
         A124LeaveTypeId = 0;
         A125LeaveTypeName = "";
         A128LeaveRequestDate = DateTime.MinValue;
         A171LeaveRequestHalfDay = "";
         n171LeaveRequestHalfDay = false;
         A132LeaveRequestStatus = "";
         A133LeaveRequestDescription = "";
         A134LeaveRequestRejectionReason = "";
         A148EmployeeName = "";
         A144LeaveTypeVacationLeave = "";
         A129LeaveRequestStartDate = Gx_date;
         Z131LeaveRequestDuration = 0;
         Z130LeaveRequestEndDate = DateTime.MinValue;
         Z128LeaveRequestDate = DateTime.MinValue;
         Z129LeaveRequestStartDate = DateTime.MinValue;
         Z171LeaveRequestHalfDay = "";
         Z132LeaveRequestStatus = "";
         Z133LeaveRequestDescription = "";
         Z134LeaveRequestRejectionReason = "";
         Z124LeaveTypeId = 0;
         Z106EmployeeId = 0;
      }

      protected void InitAll0J21( )
      {
         A127LeaveRequestId = 0;
         InitializeNonKey0J21( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A106EmployeeId = i106EmployeeId;
         A129LeaveRequestStartDate = i129LeaveRequestStartDate;
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

      public void VarsToRow21( SdtLeaveRequest obj21 )
      {
         obj21.gxTpr_Mode = Gx_mode;
         obj21.gxTpr_Leaverequestduration = A131LeaveRequestDuration;
         obj21.gxTpr_Leaverequestenddate = A130LeaveRequestEndDate;
         obj21.gxTpr_Employeeid = A106EmployeeId;
         obj21.gxTpr_Employeebalance = A147EmployeeBalance;
         obj21.gxTpr_Leavetypeid = A124LeaveTypeId;
         obj21.gxTpr_Leavetypename = A125LeaveTypeName;
         obj21.gxTpr_Leaverequestdate = A128LeaveRequestDate;
         obj21.gxTpr_Leaverequesthalfday = A171LeaveRequestHalfDay;
         obj21.gxTpr_Leaverequeststatus = A132LeaveRequestStatus;
         obj21.gxTpr_Leaverequestdescription = A133LeaveRequestDescription;
         obj21.gxTpr_Leaverequestrejectionreason = A134LeaveRequestRejectionReason;
         obj21.gxTpr_Employeename = A148EmployeeName;
         obj21.gxTpr_Leavetypevacationleave = A144LeaveTypeVacationLeave;
         obj21.gxTpr_Leaverequeststartdate = A129LeaveRequestStartDate;
         obj21.gxTpr_Leaverequestid = A127LeaveRequestId;
         obj21.gxTpr_Leaverequestid_Z = Z127LeaveRequestId;
         obj21.gxTpr_Leavetypeid_Z = Z124LeaveTypeId;
         obj21.gxTpr_Leavetypename_Z = Z125LeaveTypeName;
         obj21.gxTpr_Leaverequestdate_Z = Z128LeaveRequestDate;
         obj21.gxTpr_Leaverequeststartdate_Z = Z129LeaveRequestStartDate;
         obj21.gxTpr_Leaverequestenddate_Z = Z130LeaveRequestEndDate;
         obj21.gxTpr_Leaverequesthalfday_Z = Z171LeaveRequestHalfDay;
         obj21.gxTpr_Leaverequestduration_Z = Z131LeaveRequestDuration;
         obj21.gxTpr_Leaverequeststatus_Z = Z132LeaveRequestStatus;
         obj21.gxTpr_Leaverequestdescription_Z = Z133LeaveRequestDescription;
         obj21.gxTpr_Leaverequestrejectionreason_Z = Z134LeaveRequestRejectionReason;
         obj21.gxTpr_Employeeid_Z = Z106EmployeeId;
         obj21.gxTpr_Employeename_Z = Z148EmployeeName;
         obj21.gxTpr_Employeebalance_Z = Z147EmployeeBalance;
         obj21.gxTpr_Leavetypevacationleave_Z = Z144LeaveTypeVacationLeave;
         obj21.gxTpr_Leaverequesthalfday_N = (short)(Convert.ToInt16(n171LeaveRequestHalfDay));
         obj21.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow21( SdtLeaveRequest obj21 )
      {
         obj21.gxTpr_Leaverequestid = A127LeaveRequestId;
         return  ;
      }

      public void RowToVars21( SdtLeaveRequest obj21 ,
                               int forceLoad )
      {
         Gx_mode = obj21.gxTpr_Mode;
         A131LeaveRequestDuration = obj21.gxTpr_Leaverequestduration;
         if ( ! ( ( StringUtil.StrCmp(obj21.gxTpr_Leaverequesthalfday, "") != 0 ) ) || ( forceLoad == 1 ) )
         {
            A130LeaveRequestEndDate = obj21.gxTpr_Leaverequestenddate;
         }
         if ( ! ( IsUpd( )  ) || ( forceLoad == 1 ) )
         {
            A106EmployeeId = obj21.gxTpr_Employeeid;
         }
         A147EmployeeBalance = obj21.gxTpr_Employeebalance;
         A124LeaveTypeId = obj21.gxTpr_Leavetypeid;
         A125LeaveTypeName = obj21.gxTpr_Leavetypename;
         A128LeaveRequestDate = obj21.gxTpr_Leaverequestdate;
         A171LeaveRequestHalfDay = obj21.gxTpr_Leaverequesthalfday;
         n171LeaveRequestHalfDay = false;
         A132LeaveRequestStatus = obj21.gxTpr_Leaverequeststatus;
         A133LeaveRequestDescription = obj21.gxTpr_Leaverequestdescription;
         A134LeaveRequestRejectionReason = obj21.gxTpr_Leaverequestrejectionreason;
         A148EmployeeName = obj21.gxTpr_Employeename;
         A144LeaveTypeVacationLeave = obj21.gxTpr_Leavetypevacationleave;
         A129LeaveRequestStartDate = obj21.gxTpr_Leaverequeststartdate;
         A127LeaveRequestId = obj21.gxTpr_Leaverequestid;
         Z127LeaveRequestId = obj21.gxTpr_Leaverequestid_Z;
         Z124LeaveTypeId = obj21.gxTpr_Leavetypeid_Z;
         Z125LeaveTypeName = obj21.gxTpr_Leavetypename_Z;
         Z128LeaveRequestDate = obj21.gxTpr_Leaverequestdate_Z;
         Z129LeaveRequestStartDate = obj21.gxTpr_Leaverequeststartdate_Z;
         Z130LeaveRequestEndDate = obj21.gxTpr_Leaverequestenddate_Z;
         Z171LeaveRequestHalfDay = obj21.gxTpr_Leaverequesthalfday_Z;
         Z131LeaveRequestDuration = obj21.gxTpr_Leaverequestduration_Z;
         Z132LeaveRequestStatus = obj21.gxTpr_Leaverequeststatus_Z;
         Z133LeaveRequestDescription = obj21.gxTpr_Leaverequestdescription_Z;
         Z134LeaveRequestRejectionReason = obj21.gxTpr_Leaverequestrejectionreason_Z;
         Z106EmployeeId = obj21.gxTpr_Employeeid_Z;
         Z148EmployeeName = obj21.gxTpr_Employeename_Z;
         Z147EmployeeBalance = obj21.gxTpr_Employeebalance_Z;
         Z144LeaveTypeVacationLeave = obj21.gxTpr_Leavetypevacationleave_Z;
         n171LeaveRequestHalfDay = (bool)(Convert.ToBoolean(obj21.gxTpr_Leaverequesthalfday_N));
         Gx_mode = obj21.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A127LeaveRequestId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0J21( ) ;
         ScanKeyStart0J21( ) ;
         if ( RcdFound21 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z127LeaveRequestId = A127LeaveRequestId;
         }
         ZM0J21( -18) ;
         OnLoadActions0J21( ) ;
         AddRow0J21( ) ;
         ScanKeyEnd0J21( ) ;
         if ( RcdFound21 == 0 )
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
         RowToVars21( bcLeaveRequest, 0) ;
         ScanKeyStart0J21( ) ;
         if ( RcdFound21 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z127LeaveRequestId = A127LeaveRequestId;
         }
         ZM0J21( -18) ;
         OnLoadActions0J21( ) ;
         AddRow0J21( ) ;
         ScanKeyEnd0J21( ) ;
         if ( RcdFound21 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0J21( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0J21( ) ;
         }
         else
         {
            if ( RcdFound21 == 1 )
            {
               if ( A127LeaveRequestId != Z127LeaveRequestId )
               {
                  A127LeaveRequestId = Z127LeaveRequestId;
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
                  Update0J21( ) ;
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
                  if ( A127LeaveRequestId != Z127LeaveRequestId )
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
                        Insert0J21( ) ;
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
                        Insert0J21( ) ;
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
         RowToVars21( bcLeaveRequest, 1) ;
         SaveImpl( ) ;
         VarsToRow21( bcLeaveRequest) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars21( bcLeaveRequest, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0J21( ) ;
         AfterTrn( ) ;
         VarsToRow21( bcLeaveRequest) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow21( bcLeaveRequest) ;
         }
         else
         {
            SdtLeaveRequest auxBC = new SdtLeaveRequest(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A127LeaveRequestId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcLeaveRequest);
               auxBC.Save();
               bcLeaveRequest.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars21( bcLeaveRequest, 1) ;
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
         RowToVars21( bcLeaveRequest, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0J21( ) ;
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
               VarsToRow21( bcLeaveRequest) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow21( bcLeaveRequest) ;
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
         RowToVars21( bcLeaveRequest, 0) ;
         GetKey0J21( ) ;
         if ( RcdFound21 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A127LeaveRequestId != Z127LeaveRequestId )
            {
               A127LeaveRequestId = Z127LeaveRequestId;
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
            if ( A127LeaveRequestId != Z127LeaveRequestId )
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
         context.RollbackDataStores("leaverequest_bc",pr_default);
         VarsToRow21( bcLeaveRequest) ;
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
         Gx_mode = bcLeaveRequest.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcLeaveRequest.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcLeaveRequest )
         {
            bcLeaveRequest = (SdtLeaveRequest)(sdt);
            if ( StringUtil.StrCmp(bcLeaveRequest.gxTpr_Mode, "") == 0 )
            {
               bcLeaveRequest.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow21( bcLeaveRequest) ;
            }
            else
            {
               RowToVars21( bcLeaveRequest, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcLeaveRequest.gxTpr_Mode, "") == 0 )
            {
               bcLeaveRequest.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars21( bcLeaveRequest, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtLeaveRequest LeaveRequest_BC
      {
         get {
            return bcLeaveRequest ;
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
            return "leaverequest_Execute" ;
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV40projectIds = new GxSimpleCollection<long>();
         AV43Employees = new GxSimpleCollection<long>();
         GXt_objcol_int3 = new GxSimpleCollection<long>();
         AV32WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV29TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV31WebSession = context.GetSession();
         AV52Pgmname = "";
         AV30TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         A132LeaveRequestStatus = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A133LeaveRequestDescription = "";
         A125LeaveTypeName = "";
         A171LeaveRequestHalfDay = "";
         A148EmployeeName = "";
         AV37Mesage = "";
         AV7Employee = new SdtEmployee(context);
         Z130LeaveRequestEndDate = DateTime.MinValue;
         Z128LeaveRequestDate = DateTime.MinValue;
         A128LeaveRequestDate = DateTime.MinValue;
         Z129LeaveRequestStartDate = DateTime.MinValue;
         Z171LeaveRequestHalfDay = "";
         Z132LeaveRequestStatus = "";
         Z133LeaveRequestDescription = "";
         Z134LeaveRequestRejectionReason = "";
         A134LeaveRequestRejectionReason = "";
         Z125LeaveTypeName = "";
         Z144LeaveTypeVacationLeave = "";
         A144LeaveTypeVacationLeave = "";
         Z148EmployeeName = "";
         Gx_date = DateTime.MinValue;
         BC000J5_A147EmployeeBalance = new decimal[1] ;
         BC000J5_A148EmployeeName = new string[] {""} ;
         BC000J6_A147EmployeeBalance = new decimal[1] ;
         BC000J6_A127LeaveRequestId = new long[1] ;
         BC000J6_A131LeaveRequestDuration = new decimal[1] ;
         BC000J6_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         BC000J6_A125LeaveTypeName = new string[] {""} ;
         BC000J6_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         BC000J6_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         BC000J6_A171LeaveRequestHalfDay = new string[] {""} ;
         BC000J6_n171LeaveRequestHalfDay = new bool[] {false} ;
         BC000J6_A132LeaveRequestStatus = new string[] {""} ;
         BC000J6_A133LeaveRequestDescription = new string[] {""} ;
         BC000J6_A134LeaveRequestRejectionReason = new string[] {""} ;
         BC000J6_A148EmployeeName = new string[] {""} ;
         BC000J6_A144LeaveTypeVacationLeave = new string[] {""} ;
         BC000J6_A124LeaveTypeId = new long[1] ;
         BC000J6_A106EmployeeId = new long[1] ;
         BC000J4_A125LeaveTypeName = new string[] {""} ;
         BC000J4_A144LeaveTypeVacationLeave = new string[] {""} ;
         BC000J7_A127LeaveRequestId = new long[1] ;
         BC000J3_A127LeaveRequestId = new long[1] ;
         BC000J3_A131LeaveRequestDuration = new decimal[1] ;
         BC000J3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         BC000J3_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         BC000J3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         BC000J3_A171LeaveRequestHalfDay = new string[] {""} ;
         BC000J3_n171LeaveRequestHalfDay = new bool[] {false} ;
         BC000J3_A132LeaveRequestStatus = new string[] {""} ;
         BC000J3_A133LeaveRequestDescription = new string[] {""} ;
         BC000J3_A134LeaveRequestRejectionReason = new string[] {""} ;
         BC000J3_A124LeaveTypeId = new long[1] ;
         BC000J3_A106EmployeeId = new long[1] ;
         sMode21 = "";
         BC000J2_A127LeaveRequestId = new long[1] ;
         BC000J2_A131LeaveRequestDuration = new decimal[1] ;
         BC000J2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         BC000J2_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         BC000J2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         BC000J2_A171LeaveRequestHalfDay = new string[] {""} ;
         BC000J2_n171LeaveRequestHalfDay = new bool[] {false} ;
         BC000J2_A132LeaveRequestStatus = new string[] {""} ;
         BC000J2_A133LeaveRequestDescription = new string[] {""} ;
         BC000J2_A134LeaveRequestRejectionReason = new string[] {""} ;
         BC000J2_A124LeaveTypeId = new long[1] ;
         BC000J2_A106EmployeeId = new long[1] ;
         BC000J9_A127LeaveRequestId = new long[1] ;
         BC000J12_A125LeaveTypeName = new string[] {""} ;
         BC000J12_A144LeaveTypeVacationLeave = new string[] {""} ;
         BC000J13_A147EmployeeBalance = new decimal[1] ;
         BC000J13_A148EmployeeName = new string[] {""} ;
         BC000J14_A147EmployeeBalance = new decimal[1] ;
         BC000J14_A127LeaveRequestId = new long[1] ;
         BC000J14_A131LeaveRequestDuration = new decimal[1] ;
         BC000J14_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         BC000J14_A125LeaveTypeName = new string[] {""} ;
         BC000J14_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         BC000J14_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         BC000J14_A171LeaveRequestHalfDay = new string[] {""} ;
         BC000J14_n171LeaveRequestHalfDay = new bool[] {false} ;
         BC000J14_A132LeaveRequestStatus = new string[] {""} ;
         BC000J14_A133LeaveRequestDescription = new string[] {""} ;
         BC000J14_A134LeaveRequestRejectionReason = new string[] {""} ;
         BC000J14_A148EmployeeName = new string[] {""} ;
         BC000J14_A144LeaveTypeVacationLeave = new string[] {""} ;
         BC000J14_A124LeaveTypeId = new long[1] ;
         BC000J14_A106EmployeeId = new long[1] ;
         N130LeaveRequestEndDate = DateTime.MinValue;
         i129LeaveRequestStartDate = DateTime.MinValue;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.leaverequest_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequest_bc__default(),
            new Object[][] {
                new Object[] {
               BC000J2_A127LeaveRequestId, BC000J2_A131LeaveRequestDuration, BC000J2_A130LeaveRequestEndDate, BC000J2_A128LeaveRequestDate, BC000J2_A129LeaveRequestStartDate, BC000J2_A171LeaveRequestHalfDay, BC000J2_n171LeaveRequestHalfDay, BC000J2_A132LeaveRequestStatus, BC000J2_A133LeaveRequestDescription, BC000J2_A134LeaveRequestRejectionReason,
               BC000J2_A124LeaveTypeId, BC000J2_A106EmployeeId
               }
               , new Object[] {
               BC000J3_A127LeaveRequestId, BC000J3_A131LeaveRequestDuration, BC000J3_A130LeaveRequestEndDate, BC000J3_A128LeaveRequestDate, BC000J3_A129LeaveRequestStartDate, BC000J3_A171LeaveRequestHalfDay, BC000J3_n171LeaveRequestHalfDay, BC000J3_A132LeaveRequestStatus, BC000J3_A133LeaveRequestDescription, BC000J3_A134LeaveRequestRejectionReason,
               BC000J3_A124LeaveTypeId, BC000J3_A106EmployeeId
               }
               , new Object[] {
               BC000J4_A125LeaveTypeName, BC000J4_A144LeaveTypeVacationLeave
               }
               , new Object[] {
               BC000J5_A147EmployeeBalance, BC000J5_A148EmployeeName
               }
               , new Object[] {
               BC000J6_A147EmployeeBalance, BC000J6_A127LeaveRequestId, BC000J6_A131LeaveRequestDuration, BC000J6_A130LeaveRequestEndDate, BC000J6_A125LeaveTypeName, BC000J6_A128LeaveRequestDate, BC000J6_A129LeaveRequestStartDate, BC000J6_A171LeaveRequestHalfDay, BC000J6_n171LeaveRequestHalfDay, BC000J6_A132LeaveRequestStatus,
               BC000J6_A133LeaveRequestDescription, BC000J6_A134LeaveRequestRejectionReason, BC000J6_A148EmployeeName, BC000J6_A144LeaveTypeVacationLeave, BC000J6_A124LeaveTypeId, BC000J6_A106EmployeeId
               }
               , new Object[] {
               BC000J7_A127LeaveRequestId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000J9_A127LeaveRequestId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000J12_A125LeaveTypeName, BC000J12_A144LeaveTypeVacationLeave
               }
               , new Object[] {
               BC000J13_A147EmployeeBalance, BC000J13_A148EmployeeName
               }
               , new Object[] {
               BC000J14_A147EmployeeBalance, BC000J14_A127LeaveRequestId, BC000J14_A131LeaveRequestDuration, BC000J14_A130LeaveRequestEndDate, BC000J14_A125LeaveTypeName, BC000J14_A128LeaveRequestDate, BC000J14_A129LeaveRequestStartDate, BC000J14_A171LeaveRequestHalfDay, BC000J14_n171LeaveRequestHalfDay, BC000J14_A132LeaveRequestStatus,
               BC000J14_A133LeaveRequestDescription, BC000J14_A134LeaveRequestRejectionReason, BC000J14_A148EmployeeName, BC000J14_A144LeaveTypeVacationLeave, BC000J14_A124LeaveTypeId, BC000J14_A106EmployeeId
               }
            }
         );
         AV52Pgmname = "LeaveRequest_BC";
         A106EmployeeId = 0;
         Z106EmployeeId = 0;
         i106EmployeeId = 0;
         A129LeaveRequestStartDate = DateTime.MinValue;
         Z129LeaveRequestStartDate = DateTime.MinValue;
         i129LeaveRequestStartDate = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120J2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short AV17EmployeeCompany ;
      private short GXt_int4 ;
      private short Gx_BScreen ;
      private short RcdFound21 ;
      private int trnEnded ;
      private int AV53GXV1 ;
      private long Z127LeaveRequestId ;
      private long A127LeaveRequestId ;
      private long AV26LeaveRequestId ;
      private long AV44LeaveTypeCompanyId ;
      private long AV18EmployeeId ;
      private long AV42CompanyId ;
      private long GXt_int2 ;
      private long AV24Insert_LeaveTypeId ;
      private long AV23Insert_EmployeeId ;
      private long A106EmployeeId ;
      private long Z124LeaveTypeId ;
      private long A124LeaveTypeId ;
      private long Z106EmployeeId ;
      private long i106EmployeeId ;
      private decimal AV35LeaveRequestDuration ;
      private decimal AV20EmployyeeAvailableVacationDays ;
      private decimal AV49EmployeeBalance ;
      private decimal Z131LeaveRequestDuration ;
      private decimal A131LeaveRequestDuration ;
      private decimal Z147EmployeeBalance ;
      private decimal A147EmployeeBalance ;
      private decimal GXt_decimal1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV52Pgmname ;
      private string A132LeaveRequestStatus ;
      private string A125LeaveTypeName ;
      private string A171LeaveRequestHalfDay ;
      private string A148EmployeeName ;
      private string AV37Mesage ;
      private string Z171LeaveRequestHalfDay ;
      private string Z132LeaveRequestStatus ;
      private string Z125LeaveTypeName ;
      private string Z144LeaveTypeVacationLeave ;
      private string A144LeaveTypeVacationLeave ;
      private string Z148EmployeeName ;
      private string sMode21 ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime Z130LeaveRequestEndDate ;
      private DateTime Z128LeaveRequestDate ;
      private DateTime A128LeaveRequestDate ;
      private DateTime Z129LeaveRequestStartDate ;
      private DateTime Gx_date ;
      private DateTime N130LeaveRequestEndDate ;
      private DateTime i129LeaveRequestStartDate ;
      private bool returnInSub ;
      private bool AV36ISManager ;
      private bool AV38IsProjectManager ;
      private bool n171LeaveRequestHalfDay ;
      private bool Gx_longc ;
      private string A133LeaveRequestDescription ;
      private string Z133LeaveRequestDescription ;
      private string Z134LeaveRequestRejectionReason ;
      private string A134LeaveRequestRejectionReason ;
      private IGxSession AV31WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private GxSimpleCollection<long> AV40projectIds ;
      private GxSimpleCollection<long> AV43Employees ;
      private GxSimpleCollection<long> GXt_objcol_int3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV32WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV29TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV30TrnContextAtt ;
      private SdtEmployee AV7Employee ;
      private IDataStoreProvider pr_default ;
      private decimal[] BC000J5_A147EmployeeBalance ;
      private string[] BC000J5_A148EmployeeName ;
      private decimal[] BC000J6_A147EmployeeBalance ;
      private long[] BC000J6_A127LeaveRequestId ;
      private decimal[] BC000J6_A131LeaveRequestDuration ;
      private DateTime[] BC000J6_A130LeaveRequestEndDate ;
      private string[] BC000J6_A125LeaveTypeName ;
      private DateTime[] BC000J6_A128LeaveRequestDate ;
      private DateTime[] BC000J6_A129LeaveRequestStartDate ;
      private string[] BC000J6_A171LeaveRequestHalfDay ;
      private bool[] BC000J6_n171LeaveRequestHalfDay ;
      private string[] BC000J6_A132LeaveRequestStatus ;
      private string[] BC000J6_A133LeaveRequestDescription ;
      private string[] BC000J6_A134LeaveRequestRejectionReason ;
      private string[] BC000J6_A148EmployeeName ;
      private string[] BC000J6_A144LeaveTypeVacationLeave ;
      private long[] BC000J6_A124LeaveTypeId ;
      private long[] BC000J6_A106EmployeeId ;
      private string[] BC000J4_A125LeaveTypeName ;
      private string[] BC000J4_A144LeaveTypeVacationLeave ;
      private long[] BC000J7_A127LeaveRequestId ;
      private long[] BC000J3_A127LeaveRequestId ;
      private decimal[] BC000J3_A131LeaveRequestDuration ;
      private DateTime[] BC000J3_A130LeaveRequestEndDate ;
      private DateTime[] BC000J3_A128LeaveRequestDate ;
      private DateTime[] BC000J3_A129LeaveRequestStartDate ;
      private string[] BC000J3_A171LeaveRequestHalfDay ;
      private bool[] BC000J3_n171LeaveRequestHalfDay ;
      private string[] BC000J3_A132LeaveRequestStatus ;
      private string[] BC000J3_A133LeaveRequestDescription ;
      private string[] BC000J3_A134LeaveRequestRejectionReason ;
      private long[] BC000J3_A124LeaveTypeId ;
      private long[] BC000J3_A106EmployeeId ;
      private long[] BC000J2_A127LeaveRequestId ;
      private decimal[] BC000J2_A131LeaveRequestDuration ;
      private DateTime[] BC000J2_A130LeaveRequestEndDate ;
      private DateTime[] BC000J2_A128LeaveRequestDate ;
      private DateTime[] BC000J2_A129LeaveRequestStartDate ;
      private string[] BC000J2_A171LeaveRequestHalfDay ;
      private bool[] BC000J2_n171LeaveRequestHalfDay ;
      private string[] BC000J2_A132LeaveRequestStatus ;
      private string[] BC000J2_A133LeaveRequestDescription ;
      private string[] BC000J2_A134LeaveRequestRejectionReason ;
      private long[] BC000J2_A124LeaveTypeId ;
      private long[] BC000J2_A106EmployeeId ;
      private long[] BC000J9_A127LeaveRequestId ;
      private string[] BC000J12_A125LeaveTypeName ;
      private string[] BC000J12_A144LeaveTypeVacationLeave ;
      private decimal[] BC000J13_A147EmployeeBalance ;
      private string[] BC000J13_A148EmployeeName ;
      private decimal[] BC000J14_A147EmployeeBalance ;
      private long[] BC000J14_A127LeaveRequestId ;
      private decimal[] BC000J14_A131LeaveRequestDuration ;
      private DateTime[] BC000J14_A130LeaveRequestEndDate ;
      private string[] BC000J14_A125LeaveTypeName ;
      private DateTime[] BC000J14_A128LeaveRequestDate ;
      private DateTime[] BC000J14_A129LeaveRequestStartDate ;
      private string[] BC000J14_A171LeaveRequestHalfDay ;
      private bool[] BC000J14_n171LeaveRequestHalfDay ;
      private string[] BC000J14_A132LeaveRequestStatus ;
      private string[] BC000J14_A133LeaveRequestDescription ;
      private string[] BC000J14_A134LeaveRequestRejectionReason ;
      private string[] BC000J14_A148EmployeeName ;
      private string[] BC000J14_A144LeaveTypeVacationLeave ;
      private long[] BC000J14_A124LeaveTypeId ;
      private long[] BC000J14_A106EmployeeId ;
      private SdtLeaveRequest bcLeaveRequest ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class leaverequest_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class leaverequest_bc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000J2;
        prmBC000J2 = new Object[] {
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmBC000J3;
        prmBC000J3 = new Object[] {
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmBC000J4;
        prmBC000J4 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmBC000J5;
        prmBC000J5 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000J6;
        prmBC000J6 = new Object[] {
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmBC000J7;
        prmBC000J7 = new Object[] {
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmBC000J8;
        prmBC000J8 = new Object[] {
        new ParDef("LeaveRequestDuration",GXType.Number,4,1) ,
        new ParDef("LeaveRequestEndDate",GXType.Date,8,0) ,
        new ParDef("LeaveRequestDate",GXType.Date,8,0) ,
        new ParDef("LeaveRequestStartDate",GXType.Date,8,0) ,
        new ParDef("LeaveRequestHalfDay",GXType.Char,20,0){Nullable=true} ,
        new ParDef("LeaveRequestStatus",GXType.Char,20,0) ,
        new ParDef("LeaveRequestDescription",GXType.VarChar,200,0) ,
        new ParDef("LeaveRequestRejectionReason",GXType.VarChar,200,0) ,
        new ParDef("LeaveTypeId",GXType.Int64,10,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000J9;
        prmBC000J9 = new Object[] {
        };
        Object[] prmBC000J10;
        prmBC000J10 = new Object[] {
        new ParDef("LeaveRequestDuration",GXType.Number,4,1) ,
        new ParDef("LeaveRequestEndDate",GXType.Date,8,0) ,
        new ParDef("LeaveRequestDate",GXType.Date,8,0) ,
        new ParDef("LeaveRequestStartDate",GXType.Date,8,0) ,
        new ParDef("LeaveRequestHalfDay",GXType.Char,20,0){Nullable=true} ,
        new ParDef("LeaveRequestStatus",GXType.Char,20,0) ,
        new ParDef("LeaveRequestDescription",GXType.VarChar,200,0) ,
        new ParDef("LeaveRequestRejectionReason",GXType.VarChar,200,0) ,
        new ParDef("LeaveTypeId",GXType.Int64,10,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmBC000J11;
        prmBC000J11 = new Object[] {
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmBC000J12;
        prmBC000J12 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmBC000J13;
        prmBC000J13 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmBC000J14;
        prmBC000J14 = new Object[] {
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000J2", "SELECT LeaveRequestId, LeaveRequestDuration, LeaveRequestEndDate, LeaveRequestDate, LeaveRequestStartDate, LeaveRequestHalfDay, LeaveRequestStatus, LeaveRequestDescription, LeaveRequestRejectionReason, LeaveTypeId, EmployeeId FROM LeaveRequest WHERE LeaveRequestId = :LeaveRequestId  FOR UPDATE OF LeaveRequest",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J3", "SELECT LeaveRequestId, LeaveRequestDuration, LeaveRequestEndDate, LeaveRequestDate, LeaveRequestStartDate, LeaveRequestHalfDay, LeaveRequestStatus, LeaveRequestDescription, LeaveRequestRejectionReason, LeaveTypeId, EmployeeId FROM LeaveRequest WHERE LeaveRequestId = :LeaveRequestId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J4", "SELECT LeaveTypeName, LeaveTypeVacationLeave FROM LeaveType WHERE LeaveTypeId = :LeaveTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J5", "SELECT EmployeeBalance, EmployeeName FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J6", "SELECT T3.EmployeeBalance, TM1.LeaveRequestId, TM1.LeaveRequestDuration, TM1.LeaveRequestEndDate, T2.LeaveTypeName, TM1.LeaveRequestDate, TM1.LeaveRequestStartDate, TM1.LeaveRequestHalfDay, TM1.LeaveRequestStatus, TM1.LeaveRequestDescription, TM1.LeaveRequestRejectionReason, T3.EmployeeName, T2.LeaveTypeVacationLeave, TM1.LeaveTypeId, TM1.EmployeeId FROM ((LeaveRequest TM1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = TM1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = TM1.EmployeeId) WHERE TM1.LeaveRequestId = :LeaveRequestId ORDER BY TM1.LeaveRequestId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J7", "SELECT LeaveRequestId FROM LeaveRequest WHERE LeaveRequestId = :LeaveRequestId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J8", "SAVEPOINT gxupdate;INSERT INTO LeaveRequest(LeaveRequestDuration, LeaveRequestEndDate, LeaveRequestDate, LeaveRequestStartDate, LeaveRequestHalfDay, LeaveRequestStatus, LeaveRequestDescription, LeaveRequestRejectionReason, LeaveTypeId, EmployeeId) VALUES(:LeaveRequestDuration, :LeaveRequestEndDate, :LeaveRequestDate, :LeaveRequestStartDate, :LeaveRequestHalfDay, :LeaveRequestStatus, :LeaveRequestDescription, :LeaveRequestRejectionReason, :LeaveTypeId, :EmployeeId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000J8)
           ,new CursorDef("BC000J9", "SELECT currval('LeaveRequestId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J10", "SAVEPOINT gxupdate;UPDATE LeaveRequest SET LeaveRequestDuration=:LeaveRequestDuration, LeaveRequestEndDate=:LeaveRequestEndDate, LeaveRequestDate=:LeaveRequestDate, LeaveRequestStartDate=:LeaveRequestStartDate, LeaveRequestHalfDay=:LeaveRequestHalfDay, LeaveRequestStatus=:LeaveRequestStatus, LeaveRequestDescription=:LeaveRequestDescription, LeaveRequestRejectionReason=:LeaveRequestRejectionReason, LeaveTypeId=:LeaveTypeId, EmployeeId=:EmployeeId  WHERE LeaveRequestId = :LeaveRequestId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000J10)
           ,new CursorDef("BC000J11", "SAVEPOINT gxupdate;DELETE FROM LeaveRequest  WHERE LeaveRequestId = :LeaveRequestId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000J11)
           ,new CursorDef("BC000J12", "SELECT LeaveTypeName, LeaveTypeVacationLeave FROM LeaveType WHERE LeaveTypeId = :LeaveTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J13", "SELECT EmployeeBalance, EmployeeName FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000J14", "SELECT T3.EmployeeBalance, TM1.LeaveRequestId, TM1.LeaveRequestDuration, TM1.LeaveRequestEndDate, T2.LeaveTypeName, TM1.LeaveRequestDate, TM1.LeaveRequestStartDate, TM1.LeaveRequestHalfDay, TM1.LeaveRequestStatus, TM1.LeaveRequestDescription, TM1.LeaveRequestRejectionReason, T3.EmployeeName, T2.LeaveTypeVacationLeave, TM1.LeaveTypeId, TM1.EmployeeId FROM ((LeaveRequest TM1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = TM1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = TM1.EmployeeId) WHERE TM1.LeaveRequestId = :LeaveRequestId ORDER BY TM1.LeaveRequestId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J14,100, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 20);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((long[]) buf[10])[0] = rslt.getLong(10);
              ((long[]) buf[11])[0] = rslt.getLong(11);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 20);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((long[]) buf[10])[0] = rslt.getLong(10);
              ((long[]) buf[11])[0] = rslt.getLong(11);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 3 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 4 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 20);
              ((string[]) buf[10])[0] = rslt.getVarchar(10);
              ((string[]) buf[11])[0] = rslt.getVarchar(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 100);
              ((string[]) buf[13])[0] = rslt.getString(13, 20);
              ((long[]) buf[14])[0] = rslt.getLong(14);
              ((long[]) buf[15])[0] = rslt.getLong(15);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 11 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 12 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 20);
              ((string[]) buf[10])[0] = rslt.getVarchar(10);
              ((string[]) buf[11])[0] = rslt.getVarchar(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 100);
              ((string[]) buf[13])[0] = rslt.getString(13, 20);
              ((long[]) buf[14])[0] = rslt.getLong(14);
              ((long[]) buf[15])[0] = rslt.getLong(15);
              return;
     }
  }

}

}
