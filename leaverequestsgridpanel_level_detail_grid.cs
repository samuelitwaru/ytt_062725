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
   public class leaverequestsgridpanel_level_detail_grid : GXDataGridProcedure
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

      public leaverequestsgridpanel_level_detail_grid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public leaverequestsgridpanel_level_detail_grid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SearchText ,
                           long aP1_start ,
                           long aP2_count ,
                           int aP3_gxid ,
                           out GXBaseCollection<SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item> aP4_GXM3RootCol )
      {
         this.AV28SearchText = aP0_SearchText;
         this.AV25start = aP1_start;
         this.AV26count = aP2_count;
         this.AV22gxid = aP3_gxid;
         this.AV30GXM3RootCol = new GXBaseCollection<SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item>( context, "LeaveRequestsGridPanel_Level_Detail_GridSdt.Item", "") ;
         initialize();
         ExecuteImpl();
         aP4_GXM3RootCol=this.AV30GXM3RootCol;
      }

      public GXBaseCollection<SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item> executeUdp( string aP0_SearchText ,
                                                                                               long aP1_start ,
                                                                                               long aP2_count ,
                                                                                               int aP3_gxid )
      {
         execute(aP0_SearchText, aP1_start, aP2_count, aP3_gxid, out aP4_GXM3RootCol);
         return AV30GXM3RootCol ;
      }

      public void executeSubmit( string aP0_SearchText ,
                                 long aP1_start ,
                                 long aP2_count ,
                                 int aP3_gxid ,
                                 out GXBaseCollection<SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item> aP4_GXM3RootCol )
      {
         this.AV28SearchText = aP0_SearchText;
         this.AV25start = aP1_start;
         this.AV26count = aP2_count;
         this.AV22gxid = aP3_gxid;
         this.AV30GXM3RootCol = new GXBaseCollection<SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item>( context, "LeaveRequestsGridPanel_Level_Detail_GridSdt.Item", "") ;
         SubmitImpl();
         aP4_GXM3RootCol=this.AV30GXM3RootCol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV22gxid), 8, 0);
         AV9LeaveInfo = Gxwebsession.Get(Gxids+"gxvar_Leaveinfo");
         AV20LeavePeriod = Gxwebsession.Get(Gxids+"gxvar_Leaveperiod");
         GXPagingFrom2 = (int)(GetPaginationStart( AV25start, AV26count));
         GXPagingTo2 = (int)(((AV26count==0) ? 0 : AV26count+1));
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV28SearchText ,
                                              A125LeaveTypeName ,
                                              A133LeaveRequestDescription ,
                                              A106EmployeeId ,
                                              AV27Udparg1 } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV28SearchText = StringUtil.Concat( StringUtil.RTrim( AV28SearchText), "%", "");
         lV28SearchText = StringUtil.Concat( StringUtil.RTrim( AV28SearchText), "%", "");
         /* Using cursor P00002 */
         pr_default.execute(0, new Object[] {AV27Udparg1, lV28SearchText, lV28SearchText, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
         while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GXPagingTo2 == 0 ) || ( GXPagingCount2 < GXPagingTo2 - 1 ) ) )
         {
            A124LeaveTypeId = P00002_A124LeaveTypeId[0];
            A106EmployeeId = P00002_A106EmployeeId[0];
            A125LeaveTypeName = P00002_A125LeaveTypeName[0];
            A133LeaveRequestDescription = P00002_A133LeaveRequestDescription[0];
            A132LeaveRequestStatus = P00002_A132LeaveRequestStatus[0];
            A130LeaveRequestEndDate = P00002_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00002_A129LeaveRequestStartDate[0];
            A131LeaveRequestDuration = P00002_A131LeaveRequestDuration[0];
            A127LeaveRequestId = P00002_A127LeaveRequestId[0];
            A128LeaveRequestDate = P00002_A128LeaveRequestDate[0];
            A125LeaveTypeName = P00002_A125LeaveTypeName[0];
            GXPagingCount2 = (int)(GXPagingCount2+1);
            AV31GXM2LeaveRequestsGridPanel_Level_Detail_GridSdt = new SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item(context);
            AV30GXM3RootCol.Add(AV31GXM2LeaveRequestsGridPanel_Level_Detail_GridSdt, 0);
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
            AV20LeavePeriod = StringUtil.Trim( StringUtil.Str( A131LeaveRequestDuration, 4, 1)) + " days - From " + StringUtil.Trim( context.localUtil.DToC( A129LeaveRequestStartDate, 2, "/")) + " to " + StringUtil.Trim( context.localUtil.DToC( A130LeaveRequestEndDate, 2, "/"));
            AV31GXM2LeaveRequestsGridPanel_Level_Detail_GridSdt.gxTpr_Leaverequestid = A127LeaveRequestId;
            AV31GXM2LeaveRequestsGridPanel_Level_Detail_GridSdt.gxTpr_Leaverequestdescription = A133LeaveRequestDescription;
            AV31GXM2LeaveRequestsGridPanel_Level_Detail_GridSdt.gxTpr_Leaverequeststatus = A132LeaveRequestStatus;
            AV31GXM2LeaveRequestsGridPanel_Level_Detail_GridSdt.gxTpr_Leaveinfo = AV9LeaveInfo;
            AV31GXM2LeaveRequestsGridPanel_Level_Detail_GridSdt.gxTpr_Leaveperiod = AV20LeavePeriod;
            AV31GXM2LeaveRequestsGridPanel_Level_Detail_GridSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
            Gxdynprop = "";
            pr_default.readNext(0);
         }
         SetPaginationHeaders(((pr_default.getStatus(0) == 101) ? false : true));
         pr_default.close(0);
         Gxwebsession.Set(Gxids+"gxvar_Leaveinfo", AV9LeaveInfo);
         Gxwebsession.Set(Gxids+"gxvar_Leaveperiod", AV20LeavePeriod);
         cleanup();
      }

      protected override long RecordCount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV28SearchText ,
                                              A125LeaveTypeName ,
                                              A133LeaveRequestDescription ,
                                              A106EmployeeId ,
                                              AV27Udparg1 } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV28SearchText = StringUtil.Concat( StringUtil.RTrim( AV28SearchText), "%", "");
         lV28SearchText = StringUtil.Concat( StringUtil.RTrim( AV28SearchText), "%", "");
         /* Using cursor P00003 */
         pr_default.execute(1, new Object[] {AV27Udparg1, lV28SearchText, lV28SearchText});
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
         AV30GXM3RootCol = new GXBaseCollection<SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item>( context, "LeaveRequestsGridPanel_Level_Detail_GridSdt.Item", "");
         Gxids = "";
         AV9LeaveInfo = "";
         Gxwebsession = context.GetSession();
         AV20LeavePeriod = "";
         lV28SearchText = "";
         A125LeaveTypeName = "";
         A133LeaveRequestDescription = "";
         AV27Udparg1 = new getloggedinemployeeid(context).executeUdp( );
         P00002_A124LeaveTypeId = new long[1] ;
         P00002_A106EmployeeId = new long[1] ;
         P00002_A125LeaveTypeName = new string[] {""} ;
         P00002_A133LeaveRequestDescription = new string[] {""} ;
         P00002_A132LeaveRequestStatus = new string[] {""} ;
         P00002_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00002_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00002_A131LeaveRequestDuration = new decimal[1] ;
         P00002_A127LeaveRequestId = new long[1] ;
         P00002_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         A132LeaveRequestStatus = "";
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A128LeaveRequestDate = DateTime.MinValue;
         AV31GXM2LeaveRequestsGridPanel_Level_Detail_GridSdt = new SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item(context);
         Gxdynprop = "";
         P00003_AGRID_nRecordCount = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestsgridpanel_level_detail_grid__default(),
            new Object[][] {
                new Object[] {
               P00002_A124LeaveTypeId, P00002_A106EmployeeId, P00002_A125LeaveTypeName, P00002_A133LeaveRequestDescription, P00002_A132LeaveRequestStatus, P00002_A130LeaveRequestEndDate, P00002_A129LeaveRequestStartDate, P00002_A131LeaveRequestDuration, P00002_A127LeaveRequestId, P00002_A128LeaveRequestDate
               }
               , new Object[] {
               P00003_AGRID_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV22gxid ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GXPagingCount2 ;
      private long AV25start ;
      private long AV26count ;
      private long A106EmployeeId ;
      private long AV27Udparg1 ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private long GRID_nRecordCount ;
      private decimal A131LeaveRequestDuration ;
      private string Gxids ;
      private string AV9LeaveInfo ;
      private string A125LeaveTypeName ;
      private string A132LeaveRequestStatus ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A128LeaveRequestDate ;
      private string AV28SearchText ;
      private string AV20LeavePeriod ;
      private string lV28SearchText ;
      private string A133LeaveRequestDescription ;
      private string Gxdynprop ;
      private IGxSession Gxwebsession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item> AV30GXM3RootCol ;
      private IDataStoreProvider pr_default ;
      private long[] P00002_A124LeaveTypeId ;
      private long[] P00002_A106EmployeeId ;
      private string[] P00002_A125LeaveTypeName ;
      private string[] P00002_A133LeaveRequestDescription ;
      private string[] P00002_A132LeaveRequestStatus ;
      private DateTime[] P00002_A130LeaveRequestEndDate ;
      private DateTime[] P00002_A129LeaveRequestStartDate ;
      private decimal[] P00002_A131LeaveRequestDuration ;
      private long[] P00002_A127LeaveRequestId ;
      private DateTime[] P00002_A128LeaveRequestDate ;
      private SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item AV31GXM2LeaveRequestsGridPanel_Level_Detail_GridSdt ;
      private long[] P00003_AGRID_nRecordCount ;
      private GXBaseCollection<SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item> aP4_GXM3RootCol ;
   }

   public class leaverequestsgridpanel_level_detail_grid__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00002( IGxContext context ,
                                             string AV28SearchText ,
                                             string A125LeaveTypeName ,
                                             string A133LeaveRequestDescription ,
                                             long A106EmployeeId ,
                                             long AV27Udparg1 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.LeaveTypeId, T1.EmployeeId, T2.LeaveTypeName, T1.LeaveRequestDescription, T1.LeaveRequestStatus, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestDuration, T1.LeaveRequestId, T1.LeaveRequestDate";
         sFromString = " FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV27Udparg1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28SearchText)) )
         {
            AddWhere(sWhereString, "(UPPER(T2.LeaveTypeName) like '%' || UPPER(:lV28SearchText) or UPPER(T1.LeaveRequestDescription) like '%' || UPPER(:lV28SearchText))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         sOrderString += " ORDER BY T1.LeaveRequestDate DESC, T1.LeaveRequestId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00003( IGxContext context ,
                                             string AV28SearchText ,
                                             string A125LeaveTypeName ,
                                             string A133LeaveRequestDescription ,
                                             long A106EmployeeId ,
                                             long AV27Udparg1 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[3];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV27Udparg1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28SearchText)) )
         {
            AddWhere(sWhereString, "(UPPER(T2.LeaveTypeName) like '%' || UPPER(:lV28SearchText) or UPPER(T1.LeaveRequestDescription) like '%' || UPPER(:lV28SearchText))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00002(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] );
               case 1 :
                     return conditional_P00003(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          new ParDef("AV27Udparg1",GXType.Int64,10,0) ,
          new ParDef("lV28SearchText",GXType.VarChar,1000,0) ,
          new ParDef("lV28SearchText",GXType.VarChar,1000,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP00003;
          prmP00003 = new Object[] {
          new ParDef("AV27Udparg1",GXType.Int64,10,0) ,
          new ParDef("lV28SearchText",GXType.VarChar,1000,0) ,
          new ParDef("lV28SearchText",GXType.VarChar,1000,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00002", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00002,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00003", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00003,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
