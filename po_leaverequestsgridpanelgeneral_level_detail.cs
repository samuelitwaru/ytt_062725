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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class po_leaverequestsgridpanelgeneral_level_detail : GXDataGridProcedure
   {
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
            return "po_leaverequestsgridpanelgeneral_Execute" ;
         }

      }

      public po_leaverequestsgridpanelgeneral_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public po_leaverequestsgridpanelgeneral_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_LeaveRequestId ,
                           int aP1_gxid ,
                           out SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt aP2_GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt )
      {
         this.A127LeaveRequestId = aP0_LeaveRequestId;
         this.AV9gxid = aP1_gxid;
         this.AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt = new SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP2_GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt=this.AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt;
      }

      public SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt executeUdp( long aP0_LeaveRequestId ,
                                                                             int aP1_gxid )
      {
         execute(aP0_LeaveRequestId, aP1_gxid, out aP2_GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt);
         return AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt ;
      }

      public void executeSubmit( long aP0_LeaveRequestId ,
                                 int aP1_gxid ,
                                 out SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt aP2_GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt )
      {
         this.A127LeaveRequestId = aP0_LeaveRequestId;
         this.AV9gxid = aP1_gxid;
         this.AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt = new SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt(context) ;
         SubmitImpl();
         aP2_GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt=this.AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV9gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
            Gxwebsession.Set(Gxids, "true");
         }
         /* Using cursor P00002 */
         pr_default.execute(0, new Object[] {A127LeaveRequestId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P00002_A124LeaveTypeId[0];
            A125LeaveTypeName = P00002_A125LeaveTypeName[0];
            A128LeaveRequestDate = P00002_A128LeaveRequestDate[0];
            A129LeaveRequestStartDate = P00002_A129LeaveRequestStartDate[0];
            A130LeaveRequestEndDate = P00002_A130LeaveRequestEndDate[0];
            A171LeaveRequestHalfDay = P00002_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P00002_n171LeaveRequestHalfDay[0];
            A131LeaveRequestDuration = P00002_A131LeaveRequestDuration[0];
            A132LeaveRequestStatus = P00002_A132LeaveRequestStatus[0];
            A133LeaveRequestDescription = P00002_A133LeaveRequestDescription[0];
            A134LeaveRequestRejectionReason = P00002_A134LeaveRequestRejectionReason[0];
            A106EmployeeId = P00002_A106EmployeeId[0];
            A148EmployeeName = P00002_A148EmployeeName[0];
            A147EmployeeBalance = P00002_A147EmployeeBalance[0];
            A144LeaveTypeVacationLeave = P00002_A144LeaveTypeVacationLeave[0];
            A125LeaveTypeName = P00002_A125LeaveTypeName[0];
            A144LeaveTypeVacationLeave = P00002_A144LeaveTypeVacationLeave[0];
            A148EmployeeName = P00002_A148EmployeeName[0];
            A147EmployeeBalance = P00002_A147EmployeeBalance[0];
            GXt_boolean1 = AV7IsAuthorized_Update;
            new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "leaverequestsgridpaneldata_Update", out  GXt_boolean1) ;
            AV7IsAuthorized_Update = GXt_boolean1;
            if ( ! ( AV7IsAuthorized_Update ) )
            {
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Btnupdate\",\"Visible\",\"" + "False" + "\"]";
            }
            GXt_boolean1 = AV8IsAuthorized_Delete;
            new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "leaverequestsgridpaneldata_Delete", out  GXt_boolean1) ;
            AV8IsAuthorized_Delete = GXt_boolean1;
            if ( ! ( AV8IsAuthorized_Delete ) )
            {
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Btndelete\",\"Visible\",\"" + "False" + "\"]";
            }
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leaverequestid = A127LeaveRequestId;
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leavetypeid = A124LeaveTypeId;
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leavetypename = A125LeaveTypeName;
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leaverequestdate = A128LeaveRequestDate;
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leaverequeststartdate = A129LeaveRequestStartDate;
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leaverequestenddate = A130LeaveRequestEndDate;
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leaverequesthalfday = A171LeaveRequestHalfDay;
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leaverequestduration = A131LeaveRequestDuration;
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leaverequeststatus = A132LeaveRequestStatus;
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leaverequestdescription = A133LeaveRequestDescription;
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leaverequestrejectionreason = A134LeaveRequestRejectionReason;
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Employeeid = A106EmployeeId;
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Employeename = A148EmployeeName;
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Employeebalance = A147EmployeeBalance;
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leavetypevacationleave = A144LeaveTypeVacationLeave;
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Isauthorized_update = AV7IsAuthorized_Update;
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Isauthorized_delete = AV8IsAuthorized_Delete;
            AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
            Gxdynprop = "";
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         SetPaginationHeaders(((pr_default.getStatus(0) == 101) ? false : true));
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt = new SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00002_A127LeaveRequestId = new long[1] ;
         P00002_A124LeaveTypeId = new long[1] ;
         P00002_A125LeaveTypeName = new string[] {""} ;
         P00002_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         P00002_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00002_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00002_A171LeaveRequestHalfDay = new string[] {""} ;
         P00002_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00002_A131LeaveRequestDuration = new decimal[1] ;
         P00002_A132LeaveRequestStatus = new string[] {""} ;
         P00002_A133LeaveRequestDescription = new string[] {""} ;
         P00002_A134LeaveRequestRejectionReason = new string[] {""} ;
         P00002_A106EmployeeId = new long[1] ;
         P00002_A148EmployeeName = new string[] {""} ;
         P00002_A147EmployeeBalance = new decimal[1] ;
         P00002_A144LeaveTypeVacationLeave = new string[] {""} ;
         A125LeaveTypeName = "";
         A128LeaveRequestDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A171LeaveRequestHalfDay = "";
         A132LeaveRequestStatus = "";
         A133LeaveRequestDescription = "";
         A134LeaveRequestRejectionReason = "";
         A148EmployeeName = "";
         A144LeaveTypeVacationLeave = "";
         Gxdynprop = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.po_leaverequestsgridpanelgeneral_level_detail__default(),
            new Object[][] {
                new Object[] {
               P00002_A127LeaveRequestId, P00002_A124LeaveTypeId, P00002_A125LeaveTypeName, P00002_A128LeaveRequestDate, P00002_A129LeaveRequestStartDate, P00002_A130LeaveRequestEndDate, P00002_A171LeaveRequestHalfDay, P00002_n171LeaveRequestHalfDay, P00002_A131LeaveRequestDuration, P00002_A132LeaveRequestStatus,
               P00002_A133LeaveRequestDescription, P00002_A134LeaveRequestRejectionReason, P00002_A106EmployeeId, P00002_A148EmployeeName, P00002_A147EmployeeBalance, P00002_A144LeaveTypeVacationLeave
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV9gxid ;
      private long A127LeaveRequestId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private decimal A131LeaveRequestDuration ;
      private decimal A147EmployeeBalance ;
      private string Gxids ;
      private string A125LeaveTypeName ;
      private string A171LeaveRequestHalfDay ;
      private string A132LeaveRequestStatus ;
      private string A148EmployeeName ;
      private string A144LeaveTypeVacationLeave ;
      private DateTime A128LeaveRequestDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool n171LeaveRequestHalfDay ;
      private bool AV7IsAuthorized_Update ;
      private bool AV8IsAuthorized_Delete ;
      private bool GXt_boolean1 ;
      private string A133LeaveRequestDescription ;
      private string A134LeaveRequestRejectionReason ;
      private string Gxdynprop ;
      private IGxSession Gxwebsession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt AV13GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private IDataStoreProvider pr_default ;
      private long[] P00002_A127LeaveRequestId ;
      private long[] P00002_A124LeaveTypeId ;
      private string[] P00002_A125LeaveTypeName ;
      private DateTime[] P00002_A128LeaveRequestDate ;
      private DateTime[] P00002_A129LeaveRequestStartDate ;
      private DateTime[] P00002_A130LeaveRequestEndDate ;
      private string[] P00002_A171LeaveRequestHalfDay ;
      private bool[] P00002_n171LeaveRequestHalfDay ;
      private decimal[] P00002_A131LeaveRequestDuration ;
      private string[] P00002_A132LeaveRequestStatus ;
      private string[] P00002_A133LeaveRequestDescription ;
      private string[] P00002_A134LeaveRequestRejectionReason ;
      private long[] P00002_A106EmployeeId ;
      private string[] P00002_A148EmployeeName ;
      private decimal[] P00002_A147EmployeeBalance ;
      private string[] P00002_A144LeaveTypeVacationLeave ;
      private SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt aP2_GXM1PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt ;
   }

   public class po_leaverequestsgridpanelgeneral_level_detail__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00002;
          prmP00002 = new Object[] {
          new ParDef("LeaveRequestId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00002", "SELECT T1.LeaveRequestId, T1.LeaveTypeId, T2.LeaveTypeName, T1.LeaveRequestDate, T1.LeaveRequestStartDate, T1.LeaveRequestEndDate, T1.LeaveRequestHalfDay, T1.LeaveRequestDuration, T1.LeaveRequestStatus, T1.LeaveRequestDescription, T1.LeaveRequestRejectionReason, T1.EmployeeId, T3.EmployeeName, T3.EmployeeBalance, T2.LeaveTypeVacationLeave FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId) WHERE T1.LeaveRequestId = :LeaveRequestId ORDER BY T1.LeaveRequestId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00002,1, GxCacheFrequency.OFF ,true,true )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((long[]) buf[12])[0] = rslt.getLong(12);
                ((string[]) buf[13])[0] = rslt.getString(13, 100);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((string[]) buf[15])[0] = rslt.getString(15, 20);
                return;
       }
    }

 }

}
