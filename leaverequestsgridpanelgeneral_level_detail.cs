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
   public class leaverequestsgridpanelgeneral_level_detail : GXDataGridProcedure
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
            return "leaverequestsgridpanelgeneral_Execute" ;
         }

      }

      public leaverequestsgridpanelgeneral_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public leaverequestsgridpanelgeneral_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_LeaveRequestId ,
                           int aP1_gxid ,
                           out SdtLeaveRequestsGridPanelGeneral_Level_DetailSdt aP2_GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt )
      {
         this.A127LeaveRequestId = aP0_LeaveRequestId;
         this.AV10gxid = aP1_gxid;
         this.AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt = new SdtLeaveRequestsGridPanelGeneral_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP2_GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt=this.AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt;
      }

      public SdtLeaveRequestsGridPanelGeneral_Level_DetailSdt executeUdp( long aP0_LeaveRequestId ,
                                                                          int aP1_gxid )
      {
         execute(aP0_LeaveRequestId, aP1_gxid, out aP2_GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt);
         return AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt ;
      }

      public void executeSubmit( long aP0_LeaveRequestId ,
                                 int aP1_gxid ,
                                 out SdtLeaveRequestsGridPanelGeneral_Level_DetailSdt aP2_GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt )
      {
         this.A127LeaveRequestId = aP0_LeaveRequestId;
         this.AV10gxid = aP1_gxid;
         this.AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt = new SdtLeaveRequestsGridPanelGeneral_Level_DetailSdt(context) ;
         SubmitImpl();
         aP2_GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt=this.AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV10gxid), 8, 0);
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
            A131LeaveRequestDuration = P00002_A131LeaveRequestDuration[0];
            A132LeaveRequestStatus = P00002_A132LeaveRequestStatus[0];
            A133LeaveRequestDescription = P00002_A133LeaveRequestDescription[0];
            A134LeaveRequestRejectionReason = P00002_A134LeaveRequestRejectionReason[0];
            A106EmployeeId = P00002_A106EmployeeId[0];
            A125LeaveTypeName = P00002_A125LeaveTypeName[0];
            GXt_boolean1 = AV8IsAuthorized_Update;
            new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "leaverequestsgridpaneldata_Update", out  GXt_boolean1) ;
            AV8IsAuthorized_Update = GXt_boolean1;
            if ( ! ( AV8IsAuthorized_Update ) )
            {
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Btnupdate\",\"Visible\",\"" + "False" + "\"]";
            }
            GXt_boolean1 = AV9IsAuthorized_Delete;
            new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "leaverequestsgridpaneldata_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized_Delete = GXt_boolean1;
            if ( ! ( AV9IsAuthorized_Delete ) )
            {
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Btndelete\",\"Visible\",\"" + "False" + "\"]";
            }
            AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leaverequestid = A127LeaveRequestId;
            AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leavetypeid = A124LeaveTypeId;
            AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leavetypename = A125LeaveTypeName;
            AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leaverequestdate = A128LeaveRequestDate;
            AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leaverequeststartdate = A129LeaveRequestStartDate;
            AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leaverequestenddate = A130LeaveRequestEndDate;
            AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leaverequestduration = A131LeaveRequestDuration;
            AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leaverequeststatus = A132LeaveRequestStatus;
            AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leaverequestdescription = A133LeaveRequestDescription;
            AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Leaverequestrejectionreason = A134LeaveRequestRejectionReason;
            AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Employeeid = A106EmployeeId;
            AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Isauthorized_update = AV8IsAuthorized_Update;
            AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Isauthorized_delete = AV9IsAuthorized_Delete;
            AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
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
         AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt = new SdtLeaveRequestsGridPanelGeneral_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00002_A127LeaveRequestId = new long[1] ;
         P00002_A124LeaveTypeId = new long[1] ;
         P00002_A125LeaveTypeName = new string[] {""} ;
         P00002_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         P00002_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00002_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00002_A131LeaveRequestDuration = new decimal[1] ;
         P00002_A132LeaveRequestStatus = new string[] {""} ;
         P00002_A133LeaveRequestDescription = new string[] {""} ;
         P00002_A134LeaveRequestRejectionReason = new string[] {""} ;
         P00002_A106EmployeeId = new long[1] ;
         A125LeaveTypeName = "";
         A128LeaveRequestDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         A133LeaveRequestDescription = "";
         A134LeaveRequestRejectionReason = "";
         Gxdynprop = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestsgridpanelgeneral_level_detail__default(),
            new Object[][] {
                new Object[] {
               P00002_A127LeaveRequestId, P00002_A124LeaveTypeId, P00002_A125LeaveTypeName, P00002_A128LeaveRequestDate, P00002_A129LeaveRequestStartDate, P00002_A130LeaveRequestEndDate, P00002_A131LeaveRequestDuration, P00002_A132LeaveRequestStatus, P00002_A133LeaveRequestDescription, P00002_A134LeaveRequestRejectionReason,
               P00002_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV10gxid ;
      private long A127LeaveRequestId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private decimal A131LeaveRequestDuration ;
      private string Gxids ;
      private string A125LeaveTypeName ;
      private string A132LeaveRequestStatus ;
      private DateTime A128LeaveRequestDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool AV8IsAuthorized_Update ;
      private bool AV9IsAuthorized_Delete ;
      private bool GXt_boolean1 ;
      private string A133LeaveRequestDescription ;
      private string A134LeaveRequestRejectionReason ;
      private string Gxdynprop ;
      private IGxSession Gxwebsession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtLeaveRequestsGridPanelGeneral_Level_DetailSdt AV14GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private IDataStoreProvider pr_default ;
      private long[] P00002_A127LeaveRequestId ;
      private long[] P00002_A124LeaveTypeId ;
      private string[] P00002_A125LeaveTypeName ;
      private DateTime[] P00002_A128LeaveRequestDate ;
      private DateTime[] P00002_A129LeaveRequestStartDate ;
      private DateTime[] P00002_A130LeaveRequestEndDate ;
      private decimal[] P00002_A131LeaveRequestDuration ;
      private string[] P00002_A132LeaveRequestStatus ;
      private string[] P00002_A133LeaveRequestDescription ;
      private string[] P00002_A134LeaveRequestRejectionReason ;
      private long[] P00002_A106EmployeeId ;
      private SdtLeaveRequestsGridPanelGeneral_Level_DetailSdt aP2_GXM1LeaveRequestsGridPanelGeneral_Level_DetailSdt ;
   }

   public class leaverequestsgridpanelgeneral_level_detail__default : DataStoreHelperBase, IDataStoreHelper
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
              new CursorDef("P00002", "SELECT T1.LeaveRequestId, T1.LeaveTypeId, T2.LeaveTypeName, T1.LeaveRequestDate, T1.LeaveRequestStartDate, T1.LeaveRequestEndDate, T1.LeaveRequestDuration, T1.LeaveRequestStatus, T1.LeaveRequestDescription, T1.LeaveRequestRejectionReason, T1.EmployeeId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE T1.LeaveRequestId = :LeaveRequestId ORDER BY T1.LeaveRequestId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00002,1, GxCacheFrequency.OFF ,true,true )
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
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                return;
       }
    }

 }

}
