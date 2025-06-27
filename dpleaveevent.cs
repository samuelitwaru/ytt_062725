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
   public class dpleaveevent : GXProcedure
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

      public dpleaveevent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpleaveevent( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           long aP2_CompanyLocationId ,
                           GxSimpleCollection<long> aP3_EmployeeIds ,
                           out GXBaseCollection<SdtSDTLeaveEvent> aP4_Gxm2rootcol )
      {
         this.AV5FromDate = aP0_FromDate;
         this.AV6ToDate = aP1_ToDate;
         this.AV7CompanyLocationId = aP2_CompanyLocationId;
         this.AV8EmployeeIds = aP3_EmployeeIds;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTLeaveEvent>( context, "SDTLeaveEvent", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTLeaveEvent> executeUdp( DateTime aP0_FromDate ,
                                                            DateTime aP1_ToDate ,
                                                            long aP2_CompanyLocationId ,
                                                            GxSimpleCollection<long> aP3_EmployeeIds )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_CompanyLocationId, aP3_EmployeeIds, out aP4_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 long aP2_CompanyLocationId ,
                                 GxSimpleCollection<long> aP3_EmployeeIds ,
                                 out GXBaseCollection<SdtSDTLeaveEvent> aP4_Gxm2rootcol )
      {
         this.AV5FromDate = aP0_FromDate;
         this.AV6ToDate = aP1_ToDate;
         this.AV7CompanyLocationId = aP2_CompanyLocationId;
         this.AV8EmployeeIds = aP3_EmployeeIds;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTLeaveEvent>( context, "SDTLeaveEvent", "YTT_version4") ;
         SubmitImpl();
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV8EmployeeIds ,
                                              AV8EmployeeIds.Count ,
                                              A132LeaveRequestStatus ,
                                              A157CompanyLocationId ,
                                              AV7CompanyLocationId ,
                                              A112EmployeeIsActive } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00172 */
         pr_default.execute(0, new Object[] {AV7CompanyLocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P00172_A124LeaveTypeId[0];
            A100CompanyId = P00172_A100CompanyId[0];
            A112EmployeeIsActive = P00172_A112EmployeeIsActive[0];
            A106EmployeeId = P00172_A106EmployeeId[0];
            A157CompanyLocationId = P00172_A157CompanyLocationId[0];
            A132LeaveRequestStatus = P00172_A132LeaveRequestStatus[0];
            A127LeaveRequestId = P00172_A127LeaveRequestId[0];
            A129LeaveRequestStartDate = P00172_A129LeaveRequestStartDate[0];
            A130LeaveRequestEndDate = P00172_A130LeaveRequestEndDate[0];
            A173LeaveTypeColorApproved = P00172_A173LeaveTypeColorApproved[0];
            n173LeaveTypeColorApproved = P00172_n173LeaveTypeColorApproved[0];
            A100CompanyId = P00172_A100CompanyId[0];
            A173LeaveTypeColorApproved = P00172_A173LeaveTypeColorApproved[0];
            n173LeaveTypeColorApproved = P00172_n173LeaveTypeColorApproved[0];
            A157CompanyLocationId = P00172_A157CompanyLocationId[0];
            A112EmployeeIsActive = P00172_A112EmployeeIsActive[0];
            Gxm1sdtleaveevent = new SdtSDTLeaveEvent(context);
            Gxm2rootcol.Add(Gxm1sdtleaveevent, 0);
            Gxm1sdtleaveevent.gxTpr_Id = StringUtil.Str( (decimal)(A127LeaveRequestId), 10, 0);
            Gxm1sdtleaveevent.gxTpr_Content = "";
            GXt_char1 = "";
            new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "YYYY-MM-DD", out  GXt_char1) ;
            Gxm1sdtleaveevent.gxTpr_Start = GXt_char1;
            GXt_char1 = "";
            new formatdatetime(context ).execute(  DateTimeUtil.DAdd( A130LeaveRequestEndDate, (1)),  "YYYY-MM-DD", out  GXt_char1) ;
            Gxm1sdtleaveevent.gxTpr_End = GXt_char1;
            Gxm1sdtleaveevent.gxTpr_Group = (short)(A106EmployeeId);
            Gxm1sdtleaveevent.gxTpr_Classname = ((StringUtil.StrCmp(A132LeaveRequestStatus, "Approved")==0) ? "ApprovedLeave "+StringUtil.Str( (decimal)(A127LeaveRequestId), 10, 0) : "PendingLeave");
            Gxm1sdtleaveevent.gxTpr_Color = ((StringUtil.StrCmp(A132LeaveRequestStatus, "Approved")==0) ? StringUtil.Trim( A173LeaveTypeColorApproved) : "#DDDDDD");
            pr_default.readNext(0);
         }
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
         A132LeaveRequestStatus = "";
         P00172_A124LeaveTypeId = new long[1] ;
         P00172_A100CompanyId = new long[1] ;
         P00172_A112EmployeeIsActive = new bool[] {false} ;
         P00172_A106EmployeeId = new long[1] ;
         P00172_A157CompanyLocationId = new long[1] ;
         P00172_A132LeaveRequestStatus = new string[] {""} ;
         P00172_A127LeaveRequestId = new long[1] ;
         P00172_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00172_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00172_A173LeaveTypeColorApproved = new string[] {""} ;
         P00172_n173LeaveTypeColorApproved = new bool[] {false} ;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A173LeaveTypeColorApproved = "";
         Gxm1sdtleaveevent = new SdtSDTLeaveEvent(context);
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpleaveevent__default(),
            new Object[][] {
                new Object[] {
               P00172_A124LeaveTypeId, P00172_A100CompanyId, P00172_A112EmployeeIsActive, P00172_A106EmployeeId, P00172_A157CompanyLocationId, P00172_A132LeaveRequestStatus, P00172_A127LeaveRequestId, P00172_A129LeaveRequestStartDate, P00172_A130LeaveRequestEndDate, P00172_A173LeaveTypeColorApproved,
               P00172_n173LeaveTypeColorApproved
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV8EmployeeIds_Count ;
      private long AV7CompanyLocationId ;
      private long A106EmployeeId ;
      private long A157CompanyLocationId ;
      private long A124LeaveTypeId ;
      private long A100CompanyId ;
      private long A127LeaveRequestId ;
      private string A132LeaveRequestStatus ;
      private string A173LeaveTypeColorApproved ;
      private string GXt_char1 ;
      private DateTime AV5FromDate ;
      private DateTime AV6ToDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool A112EmployeeIsActive ;
      private bool n173LeaveTypeColorApproved ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV8EmployeeIds ;
      private GXBaseCollection<SdtSDTLeaveEvent> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private long[] P00172_A124LeaveTypeId ;
      private long[] P00172_A100CompanyId ;
      private bool[] P00172_A112EmployeeIsActive ;
      private long[] P00172_A106EmployeeId ;
      private long[] P00172_A157CompanyLocationId ;
      private string[] P00172_A132LeaveRequestStatus ;
      private long[] P00172_A127LeaveRequestId ;
      private DateTime[] P00172_A129LeaveRequestStartDate ;
      private DateTime[] P00172_A130LeaveRequestEndDate ;
      private string[] P00172_A173LeaveTypeColorApproved ;
      private bool[] P00172_n173LeaveTypeColorApproved ;
      private SdtSDTLeaveEvent Gxm1sdtleaveevent ;
      private GXBaseCollection<SdtSDTLeaveEvent> aP4_Gxm2rootcol ;
   }

   public class dpleaveevent__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00172( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV8EmployeeIds ,
                                             int AV8EmployeeIds_Count ,
                                             string A132LeaveRequestStatus ,
                                             long A157CompanyLocationId ,
                                             long AV7CompanyLocationId ,
                                             bool A112EmployeeIsActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[1];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T2.CompanyId, T4.EmployeeIsActive, T1.EmployeeId, T3.CompanyLocationId, T1.LeaveRequestStatus, T1.LeaveRequestId, T1.LeaveRequestStartDate, T1.LeaveRequestEndDate, T2.LeaveTypeColorApproved FROM (((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId) INNER JOIN Employee T4 ON T4.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved') or T1.LeaveRequestStatus = ( 'Pending'))");
         AddWhere(sWhereString, "(T3.CompanyLocationId = :AV7CompanyLocationId)");
         AddWhere(sWhereString, "(T4.EmployeeIsActive = TRUE)");
         if ( AV8EmployeeIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV8EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestId";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00172(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (bool)dynConstraints[6] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00172;
          prmP00172 = new Object[] {
          new ParDef("AV7CompanyLocationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00172", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00172,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
