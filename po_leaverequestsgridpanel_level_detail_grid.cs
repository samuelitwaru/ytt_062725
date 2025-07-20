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
   public class po_leaverequestsgridpanel_level_detail_grid : GXDataGridProcedure
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
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public po_leaverequestsgridpanel_level_detail_grid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public po_leaverequestsgridpanel_level_detail_grid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           long aP1_start ,
                           long aP2_count ,
                           int aP3_gxid ,
                           out GXBaseCollection<SdtPO_LeaveRequestsGridPanel_Level_Detail_GridSdt_Item> aP4_GXM2RootCol )
      {
         this.AV14EmployeeId = aP0_EmployeeId;
         this.AV18start = aP1_start;
         this.AV19count = aP2_count;
         this.AV15gxid = aP3_gxid;
         this.AV21GXM2RootCol = new GXBaseCollection<SdtPO_LeaveRequestsGridPanel_Level_Detail_GridSdt_Item>( context, "PO_LeaveRequestsGridPanel_Level_Detail_GridSdt.Item", "") ;
         initialize();
         ExecuteImpl();
         aP4_GXM2RootCol=this.AV21GXM2RootCol;
      }

      public GXBaseCollection<SdtPO_LeaveRequestsGridPanel_Level_Detail_GridSdt_Item> executeUdp( long aP0_EmployeeId ,
                                                                                                  long aP1_start ,
                                                                                                  long aP2_count ,
                                                                                                  int aP3_gxid )
      {
         execute(aP0_EmployeeId, aP1_start, aP2_count, aP3_gxid, out aP4_GXM2RootCol);
         return AV21GXM2RootCol ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 long aP1_start ,
                                 long aP2_count ,
                                 int aP3_gxid ,
                                 out GXBaseCollection<SdtPO_LeaveRequestsGridPanel_Level_Detail_GridSdt_Item> aP4_GXM2RootCol )
      {
         this.AV14EmployeeId = aP0_EmployeeId;
         this.AV18start = aP1_start;
         this.AV19count = aP2_count;
         this.AV15gxid = aP3_gxid;
         this.AV21GXM2RootCol = new GXBaseCollection<SdtPO_LeaveRequestsGridPanel_Level_Detail_GridSdt_Item>( context, "PO_LeaveRequestsGridPanel_Level_Detail_GridSdt.Item", "") ;
         SubmitImpl();
         aP4_GXM2RootCol=this.AV21GXM2RootCol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV15gxid), 8, 0);
         AV9LeaveInfo = Gxwebsession.Get(Gxids+"gxvar_Leaveinfo");
         AV10LeavePeriod = Gxwebsession.Get(Gxids+"gxvar_Leaveperiod");
         GXPagingFrom2 = (int)(GetPaginationStart( AV18start, AV19count));
         GXPagingTo2 = (int)(((AV19count==0) ? 0 : AV19count+1));
         /* Using cursor P00002 */
         pr_default.execute(0, new Object[] {AV14EmployeeId, GXPagingFrom2, GXPagingTo2});
         while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GXPagingTo2 == 0 ) || ( GXPagingCount2 < GXPagingTo2 - 1 ) ) )
         {
            A124LeaveTypeId = P00002_A124LeaveTypeId[0];
            A106EmployeeId = P00002_A106EmployeeId[0];
            A132LeaveRequestStatus = P00002_A132LeaveRequestStatus[0];
            A125LeaveTypeName = P00002_A125LeaveTypeName[0];
            A130LeaveRequestEndDate = P00002_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00002_A129LeaveRequestStartDate[0];
            A131LeaveRequestDuration = P00002_A131LeaveRequestDuration[0];
            A127LeaveRequestId = P00002_A127LeaveRequestId[0];
            A133LeaveRequestDescription = P00002_A133LeaveRequestDescription[0];
            A125LeaveTypeName = P00002_A125LeaveTypeName[0];
            GXPagingCount2 = (int)(GXPagingCount2+1);
            AV22GXM1PO_LeaveRequestsGridPanel_Level_Detail_GridSdt = new SdtPO_LeaveRequestsGridPanel_Level_Detail_GridSdt_Item(context);
            AV21GXM2RootCol.Add(AV22GXM1PO_LeaveRequestsGridPanel_Level_Detail_GridSdt, 0);
            if ( ! ( StringUtil.StrCmp(A132LeaveRequestStatus, "Pending") == 0 ) )
            {
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Actioniconstable\",\"Visible\",\"" + "False" + "\"]";
            }
            if ( StringUtil.StrCmp(A132LeaveRequestStatus, "Approved") == 0 )
            {
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"LeaveRequestStatus\",\"Class\",\"" + StringUtil.JSONEncode( "ApprovedTag") + "\"]";
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Infoicontable\",\"Visible\",\"" + "False" + "\"]";
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Approvedspacertable\",\"Visible\",\"" + "True" + "\"]";
            }
            if ( StringUtil.StrCmp(A132LeaveRequestStatus, "Rejected") == 0 )
            {
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"LeaveRequestStatus\",\"Class\",\"" + StringUtil.JSONEncode( "RejectedTag") + "\"]";
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Infoicontable\",\"Visible\",\"" + "True" + "\"]";
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Approvedspacertable\",\"Visible\",\"" + "False" + "\"]";
            }
            if ( StringUtil.StrCmp(A132LeaveRequestStatus, "Pending") == 0 )
            {
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"LeaveRequestStatus\",\"Class\",\"" + StringUtil.JSONEncode( "PendingTag") + "\"]";
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Infoicontable\",\"Visible\",\"" + "False" + "\"]";
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Approvedspacertable\",\"Visible\",\"" + "False" + "\"]";
            }
            AV9LeaveInfo = "<span>" + StringUtil.Trim( A125LeaveTypeName) + "</span>";
            AV10LeavePeriod = StringUtil.Trim( StringUtil.Str( A131LeaveRequestDuration, 4, 1)) + " days - From " + StringUtil.Trim( context.localUtil.DToC( A129LeaveRequestStartDate, 2, "/")) + " to " + StringUtil.Trim( context.localUtil.DToC( A130LeaveRequestEndDate, 2, "/"));
            AV22GXM1PO_LeaveRequestsGridPanel_Level_Detail_GridSdt.gxTpr_Leaverequestid = A127LeaveRequestId;
            AV22GXM1PO_LeaveRequestsGridPanel_Level_Detail_GridSdt.gxTpr_Leaverequestdescription = A133LeaveRequestDescription;
            AV22GXM1PO_LeaveRequestsGridPanel_Level_Detail_GridSdt.gxTpr_Leaverequeststatus = A132LeaveRequestStatus;
            AV22GXM1PO_LeaveRequestsGridPanel_Level_Detail_GridSdt.gxTpr_Leaveinfo = AV9LeaveInfo;
            AV22GXM1PO_LeaveRequestsGridPanel_Level_Detail_GridSdt.gxTpr_Leaveperiod = AV10LeavePeriod;
            AV22GXM1PO_LeaveRequestsGridPanel_Level_Detail_GridSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
            Gxdynprop = "";
            pr_default.readNext(0);
         }
         SetPaginationHeaders(((pr_default.getStatus(0) == 101) ? false : true));
         pr_default.close(0);
         Gxwebsession.Set(Gxids+"gxvar_Leaveinfo", AV9LeaveInfo);
         Gxwebsession.Set(Gxids+"gxvar_Leaveperiod", AV10LeavePeriod);
         cleanup();
      }

      protected override long RecordCount( )
      {
         /* Using cursor P00003 */
         pr_default.execute(1, new Object[] {AV14EmployeeId});
         GRID_nRecordCount = P00003_AGRID_nRecordCount[0];
         pr_default.close(1);
         return GRID_nRecordCount ;
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
         AV21GXM2RootCol = new GXBaseCollection<SdtPO_LeaveRequestsGridPanel_Level_Detail_GridSdt_Item>( context, "PO_LeaveRequestsGridPanel_Level_Detail_GridSdt.Item", "");
         Gxids = "";
         AV9LeaveInfo = "";
         Gxwebsession = context.GetSession();
         AV10LeavePeriod = "";
         P00002_A124LeaveTypeId = new long[1] ;
         P00002_A106EmployeeId = new long[1] ;
         P00002_A132LeaveRequestStatus = new string[] {""} ;
         P00002_A125LeaveTypeName = new string[] {""} ;
         P00002_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00002_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00002_A131LeaveRequestDuration = new decimal[1] ;
         P00002_A127LeaveRequestId = new long[1] ;
         P00002_A133LeaveRequestDescription = new string[] {""} ;
         A132LeaveRequestStatus = "";
         A125LeaveTypeName = "";
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A133LeaveRequestDescription = "";
         AV22GXM1PO_LeaveRequestsGridPanel_Level_Detail_GridSdt = new SdtPO_LeaveRequestsGridPanel_Level_Detail_GridSdt_Item(context);
         Gxdynprop = "";
         P00003_AGRID_nRecordCount = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.po_leaverequestsgridpanel_level_detail_grid__default(),
            new Object[][] {
                new Object[] {
               P00002_A124LeaveTypeId, P00002_A106EmployeeId, P00002_A132LeaveRequestStatus, P00002_A125LeaveTypeName, P00002_A130LeaveRequestEndDate, P00002_A129LeaveRequestStartDate, P00002_A131LeaveRequestDuration, P00002_A127LeaveRequestId, P00002_A133LeaveRequestDescription
               }
               , new Object[] {
               P00003_AGRID_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV15gxid ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GXPagingCount2 ;
      private long AV14EmployeeId ;
      private long AV18start ;
      private long AV19count ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long A127LeaveRequestId ;
      private long GRID_nRecordCount ;
      private decimal A131LeaveRequestDuration ;
      private string Gxids ;
      private string AV9LeaveInfo ;
      private string A132LeaveRequestStatus ;
      private string A125LeaveTypeName ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private string AV10LeavePeriod ;
      private string A133LeaveRequestDescription ;
      private string Gxdynprop ;
      private IGxSession Gxwebsession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtPO_LeaveRequestsGridPanel_Level_Detail_GridSdt_Item> AV21GXM2RootCol ;
      private IDataStoreProvider pr_default ;
      private long[] P00002_A124LeaveTypeId ;
      private long[] P00002_A106EmployeeId ;
      private string[] P00002_A132LeaveRequestStatus ;
      private string[] P00002_A125LeaveTypeName ;
      private DateTime[] P00002_A130LeaveRequestEndDate ;
      private DateTime[] P00002_A129LeaveRequestStartDate ;
      private decimal[] P00002_A131LeaveRequestDuration ;
      private long[] P00002_A127LeaveRequestId ;
      private string[] P00002_A133LeaveRequestDescription ;
      private SdtPO_LeaveRequestsGridPanel_Level_Detail_GridSdt_Item AV22GXM1PO_LeaveRequestsGridPanel_Level_Detail_GridSdt ;
      private long[] P00003_AGRID_nRecordCount ;
      private GXBaseCollection<SdtPO_LeaveRequestsGridPanel_Level_Detail_GridSdt_Item> aP4_GXM2RootCol ;
   }

   public class po_leaverequestsgridpanel_level_detail_grid__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00002;
          prmP00002 = new Object[] {
          new ParDef("AV14EmployeeId",GXType.Int64,10,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP00003;
          prmP00003 = new Object[] {
          new ParDef("AV14EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00002", "SELECT T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestStatus, T2.LeaveTypeName, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestDuration, T1.LeaveRequestId, T1.LeaveRequestDescription FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE T1.EmployeeId = :AV14EmployeeId ORDER BY T1.LeaveRequestId  OFFSET :GXPagingFrom2 LIMIT CASE WHEN :GXPagingTo2 > 0 THEN :GXPagingTo2 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00002,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00003", "SELECT COUNT(*) FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE T1.EmployeeId = :AV14EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00003,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
