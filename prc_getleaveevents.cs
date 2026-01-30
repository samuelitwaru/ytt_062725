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
   public class prc_getleaveevents : GXProcedure
   {
      public prc_getleaveevents( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getleaveevents( IGxContext context )
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
                           out GXBaseCollection<SdtSDTLeaveEvent> aP4_LeaveEvents )
      {
         this.AV8FromDate = aP0_FromDate;
         this.AV9ToDate = aP1_ToDate;
         this.AV10CompanyLocationId = aP2_CompanyLocationId;
         this.AV11EmployeeIds = aP3_EmployeeIds;
         this.AV13LeaveEvents = new GXBaseCollection<SdtSDTLeaveEvent>( context, "SDTLeaveEvent", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP4_LeaveEvents=this.AV13LeaveEvents;
      }

      public GXBaseCollection<SdtSDTLeaveEvent> executeUdp( DateTime aP0_FromDate ,
                                                            DateTime aP1_ToDate ,
                                                            long aP2_CompanyLocationId ,
                                                            GxSimpleCollection<long> aP3_EmployeeIds )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_CompanyLocationId, aP3_EmployeeIds, out aP4_LeaveEvents);
         return AV13LeaveEvents ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 long aP2_CompanyLocationId ,
                                 GxSimpleCollection<long> aP3_EmployeeIds ,
                                 out GXBaseCollection<SdtSDTLeaveEvent> aP4_LeaveEvents )
      {
         this.AV8FromDate = aP0_FromDate;
         this.AV9ToDate = aP1_ToDate;
         this.AV10CompanyLocationId = aP2_CompanyLocationId;
         this.AV11EmployeeIds = aP3_EmployeeIds;
         this.AV13LeaveEvents = new GXBaseCollection<SdtSDTLeaveEvent>( context, "SDTLeaveEvent", "YTT_version4") ;
         SubmitImpl();
         aP4_LeaveEvents=this.AV13LeaveEvents;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV11EmployeeIds ,
                                              AV11EmployeeIds.Count ,
                                              A132LeaveRequestStatus ,
                                              A157CompanyLocationId ,
                                              AV10CompanyLocationId ,
                                              A112EmployeeIsActive } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00BY2 */
         pr_default.execute(0, new Object[] {AV10CompanyLocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P00BY2_A124LeaveTypeId[0];
            A100CompanyId = P00BY2_A100CompanyId[0];
            A112EmployeeIsActive = P00BY2_A112EmployeeIsActive[0];
            A106EmployeeId = P00BY2_A106EmployeeId[0];
            A157CompanyLocationId = P00BY2_A157CompanyLocationId[0];
            A132LeaveRequestStatus = P00BY2_A132LeaveRequestStatus[0];
            A127LeaveRequestId = P00BY2_A127LeaveRequestId[0];
            A171LeaveRequestHalfDay = P00BY2_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P00BY2_n171LeaveRequestHalfDay[0];
            A129LeaveRequestStartDate = P00BY2_A129LeaveRequestStartDate[0];
            A130LeaveRequestEndDate = P00BY2_A130LeaveRequestEndDate[0];
            A173LeaveTypeColorApproved = P00BY2_A173LeaveTypeColorApproved[0];
            n173LeaveTypeColorApproved = P00BY2_n173LeaveTypeColorApproved[0];
            A100CompanyId = P00BY2_A100CompanyId[0];
            A173LeaveTypeColorApproved = P00BY2_A173LeaveTypeColorApproved[0];
            n173LeaveTypeColorApproved = P00BY2_n173LeaveTypeColorApproved[0];
            A157CompanyLocationId = P00BY2_A157CompanyLocationId[0];
            A112EmployeeIsActive = P00BY2_A112EmployeeIsActive[0];
            AV12SDTLeaveEvent = new SdtSDTLeaveEvent(context);
            AV12SDTLeaveEvent.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A127LeaveRequestId), 10, 0));
            AV12SDTLeaveEvent.gxTpr_Content = "";
            if ( StringUtil.StrCmp(A171LeaveRequestHalfDay, "Morning") == 0 )
            {
               GXt_char1 = "";
               new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "YYYY-MM-DD", out  GXt_char1) ;
               AV12SDTLeaveEvent.gxTpr_Start = GXt_char1;
               GXt_char1 = "";
               new formatdatetime(context ).execute(  A130LeaveRequestEndDate,  "YYYY-MM-DD", out  GXt_char1) ;
               AV12SDTLeaveEvent.gxTpr_End = GXt_char1+" 12:00:00";
            }
            else if ( StringUtil.StrCmp(A171LeaveRequestHalfDay, "Afternoon") == 0 )
            {
               GXt_char1 = "";
               new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "YYYY-MM-DD", out  GXt_char1) ;
               AV12SDTLeaveEvent.gxTpr_Start = GXt_char1+" 12:00:00";
               GXt_char1 = "";
               new formatdatetime(context ).execute(  DateTimeUtil.DAdd( A130LeaveRequestEndDate, (1)),  "YYYY-MM-DD", out  GXt_char1) ;
               AV12SDTLeaveEvent.gxTpr_End = GXt_char1;
            }
            else
            {
               GXt_char1 = "";
               new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "YYYY-MM-DD", out  GXt_char1) ;
               AV12SDTLeaveEvent.gxTpr_Start = GXt_char1;
               GXt_char1 = "";
               new formatdatetime(context ).execute(  DateTimeUtil.DAdd( A130LeaveRequestEndDate, (1)),  "YYYY-MM-DD", out  GXt_char1) ;
               AV12SDTLeaveEvent.gxTpr_End = GXt_char1;
            }
            AV12SDTLeaveEvent.gxTpr_Group = (short)(A106EmployeeId);
            AV12SDTLeaveEvent.gxTpr_Classname = ((StringUtil.StrCmp(A132LeaveRequestStatus, "Approved")==0) ? "ApprovedLeave "+"leave-"+StringUtil.Trim( StringUtil.Str( (decimal)(A127LeaveRequestId), 10, 0)) : "PendingLeave");
            AV12SDTLeaveEvent.gxTpr_Color = ((StringUtil.StrCmp(A132LeaveRequestStatus, "Approved")==0) ? StringUtil.Trim( A173LeaveTypeColorApproved) : "#DDDDDD");
            AV13LeaveEvents.Add(AV12SDTLeaveEvent, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         new logtofile(context ).execute(  "&LeaveEvents: "+AV13LeaveEvents.ToJSonString(false)) ;
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
         AV13LeaveEvents = new GXBaseCollection<SdtSDTLeaveEvent>( context, "SDTLeaveEvent", "YTT_version4");
         A132LeaveRequestStatus = "";
         P00BY2_A124LeaveTypeId = new long[1] ;
         P00BY2_A100CompanyId = new long[1] ;
         P00BY2_A112EmployeeIsActive = new bool[] {false} ;
         P00BY2_A106EmployeeId = new long[1] ;
         P00BY2_A157CompanyLocationId = new long[1] ;
         P00BY2_A132LeaveRequestStatus = new string[] {""} ;
         P00BY2_A127LeaveRequestId = new long[1] ;
         P00BY2_A171LeaveRequestHalfDay = new string[] {""} ;
         P00BY2_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00BY2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00BY2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00BY2_A173LeaveTypeColorApproved = new string[] {""} ;
         P00BY2_n173LeaveTypeColorApproved = new bool[] {false} ;
         A171LeaveRequestHalfDay = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A173LeaveTypeColorApproved = "";
         AV12SDTLeaveEvent = new SdtSDTLeaveEvent(context);
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getleaveevents__default(),
            new Object[][] {
                new Object[] {
               P00BY2_A124LeaveTypeId, P00BY2_A100CompanyId, P00BY2_A112EmployeeIsActive, P00BY2_A106EmployeeId, P00BY2_A157CompanyLocationId, P00BY2_A132LeaveRequestStatus, P00BY2_A127LeaveRequestId, P00BY2_A171LeaveRequestHalfDay, P00BY2_n171LeaveRequestHalfDay, P00BY2_A129LeaveRequestStartDate,
               P00BY2_A130LeaveRequestEndDate, P00BY2_A173LeaveTypeColorApproved, P00BY2_n173LeaveTypeColorApproved
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV11EmployeeIds_Count ;
      private long AV10CompanyLocationId ;
      private long A106EmployeeId ;
      private long A157CompanyLocationId ;
      private long A124LeaveTypeId ;
      private long A100CompanyId ;
      private long A127LeaveRequestId ;
      private string A132LeaveRequestStatus ;
      private string A171LeaveRequestHalfDay ;
      private string A173LeaveTypeColorApproved ;
      private string GXt_char1 ;
      private DateTime AV8FromDate ;
      private DateTime AV9ToDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool A112EmployeeIsActive ;
      private bool n171LeaveRequestHalfDay ;
      private bool n173LeaveTypeColorApproved ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV11EmployeeIds ;
      private GXBaseCollection<SdtSDTLeaveEvent> AV13LeaveEvents ;
      private IDataStoreProvider pr_default ;
      private long[] P00BY2_A124LeaveTypeId ;
      private long[] P00BY2_A100CompanyId ;
      private bool[] P00BY2_A112EmployeeIsActive ;
      private long[] P00BY2_A106EmployeeId ;
      private long[] P00BY2_A157CompanyLocationId ;
      private string[] P00BY2_A132LeaveRequestStatus ;
      private long[] P00BY2_A127LeaveRequestId ;
      private string[] P00BY2_A171LeaveRequestHalfDay ;
      private bool[] P00BY2_n171LeaveRequestHalfDay ;
      private DateTime[] P00BY2_A129LeaveRequestStartDate ;
      private DateTime[] P00BY2_A130LeaveRequestEndDate ;
      private string[] P00BY2_A173LeaveTypeColorApproved ;
      private bool[] P00BY2_n173LeaveTypeColorApproved ;
      private SdtSDTLeaveEvent AV12SDTLeaveEvent ;
      private GXBaseCollection<SdtSDTLeaveEvent> aP4_LeaveEvents ;
   }

   public class prc_getleaveevents__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BY2( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV11EmployeeIds ,
                                             int AV11EmployeeIds_Count ,
                                             string A132LeaveRequestStatus ,
                                             long A157CompanyLocationId ,
                                             long AV10CompanyLocationId ,
                                             bool A112EmployeeIsActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[1];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T2.CompanyId, T4.EmployeeIsActive, T1.EmployeeId, T3.CompanyLocationId, T1.LeaveRequestStatus, T1.LeaveRequestId, T1.LeaveRequestHalfDay, T1.LeaveRequestStartDate, T1.LeaveRequestEndDate, T2.LeaveTypeColorApproved FROM (((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId) INNER JOIN Employee T4 ON T4.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved') or T1.LeaveRequestStatus = ( 'Pending'))");
         AddWhere(sWhereString, "(T3.CompanyLocationId = :AV10CompanyLocationId)");
         AddWhere(sWhereString, "(T4.EmployeeIsActive = TRUE)");
         if ( AV11EmployeeIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV11EmployeeIds, "T1.EmployeeId IN (", ")")+")");
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
                     return conditional_P00BY2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (bool)dynConstraints[6] );
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
          Object[] prmP00BY2;
          prmP00BY2 = new Object[] {
          new ParDef("AV10CompanyLocationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BY2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BY2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 20);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                return;
       }
    }

 }

}
