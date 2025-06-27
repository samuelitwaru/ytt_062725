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
   public class aemployeeleavedetailsreport : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aemployeeleavedetailsreport().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
         return GX.GXRuntime.ExitCode ;
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

      public aemployeeleavedetailsreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aemployeeleavedetailsreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           GxSimpleCollection<long> aP2_EmployeeIdCollection ,
                           long aP3_CompanyLocationId ,
                           out GXBaseCollection<SdtSDTEmployeeLeaveDetails> aP4_SDTEmployeeLeaveDetailsCollection )
      {
         this.AV9FromDate = aP0_FromDate;
         this.AV10ToDate = aP1_ToDate;
         this.AV25EmployeeIdCollection = aP2_EmployeeIdCollection;
         this.AV24CompanyLocationId = aP3_CompanyLocationId;
         this.AV18SDTEmployeeLeaveDetailsCollection = new GXBaseCollection<SdtSDTEmployeeLeaveDetails>( context, "SDTEmployeeLeaveDetails", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP4_SDTEmployeeLeaveDetailsCollection=this.AV18SDTEmployeeLeaveDetailsCollection;
      }

      public GXBaseCollection<SdtSDTEmployeeLeaveDetails> executeUdp( DateTime aP0_FromDate ,
                                                                      DateTime aP1_ToDate ,
                                                                      GxSimpleCollection<long> aP2_EmployeeIdCollection ,
                                                                      long aP3_CompanyLocationId )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_EmployeeIdCollection, aP3_CompanyLocationId, out aP4_SDTEmployeeLeaveDetailsCollection);
         return AV18SDTEmployeeLeaveDetailsCollection ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<long> aP2_EmployeeIdCollection ,
                                 long aP3_CompanyLocationId ,
                                 out GXBaseCollection<SdtSDTEmployeeLeaveDetails> aP4_SDTEmployeeLeaveDetailsCollection )
      {
         this.AV9FromDate = aP0_FromDate;
         this.AV10ToDate = aP1_ToDate;
         this.AV25EmployeeIdCollection = aP2_EmployeeIdCollection;
         this.AV24CompanyLocationId = aP3_CompanyLocationId;
         this.AV18SDTEmployeeLeaveDetailsCollection = new GXBaseCollection<SdtSDTEmployeeLeaveDetails>( context, "SDTEmployeeLeaveDetails", "YTT_version4") ;
         SubmitImpl();
         aP4_SDTEmployeeLeaveDetailsCollection=this.AV18SDTEmployeeLeaveDetailsCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV25EmployeeIdCollection ,
                                              AV24CompanyLocationId ,
                                              A157CompanyLocationId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P00AN2 */
         pr_default.execute(0, new Object[] {AV24CompanyLocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00AN2_A100CompanyId[0];
            A106EmployeeId = P00AN2_A106EmployeeId[0];
            A157CompanyLocationId = P00AN2_A157CompanyLocationId[0];
            A147EmployeeBalance = P00AN2_A147EmployeeBalance[0];
            A148EmployeeName = P00AN2_A148EmployeeName[0];
            A157CompanyLocationId = P00AN2_A157CompanyLocationId[0];
            AV8EmployeeId = A106EmployeeId;
            AV17SDTEmployeeLeaveDetails = new SdtSDTEmployeeLeaveDetails(context);
            AV17SDTEmployeeLeaveDetails.gxTpr_Employeeid = A106EmployeeId;
            AV17SDTEmployeeLeaveDetails.gxTpr_Employeename = StringUtil.Trim( A148EmployeeName);
            AV17SDTEmployeeLeaveDetails.gxTpr_Employeebalance = A147EmployeeBalance;
            AV21LeaveRequestCount = 0;
            AV27GXLvl11 = 0;
            /* Using cursor P00AN3 */
            pr_default.execute(1, new Object[] {AV10ToDate, AV9FromDate, AV8EmployeeId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A106EmployeeId = P00AN3_A106EmployeeId[0];
               A130LeaveRequestEndDate = P00AN3_A130LeaveRequestEndDate[0];
               A129LeaveRequestStartDate = P00AN3_A129LeaveRequestStartDate[0];
               A127LeaveRequestId = P00AN3_A127LeaveRequestId[0];
               A124LeaveTypeId = P00AN3_A124LeaveTypeId[0];
               A171LeaveRequestHalfDay = P00AN3_A171LeaveRequestHalfDay[0];
               n171LeaveRequestHalfDay = P00AN3_n171LeaveRequestHalfDay[0];
               A131LeaveRequestDuration = P00AN3_A131LeaveRequestDuration[0];
               AV27GXLvl11 = 1;
               AV21LeaveRequestCount = (short)(AV21LeaveRequestCount+1);
               AV20LeaveRequestItem = new SdtSDTEmployeeLeaveDetails_LeaveRequestItem(context);
               AV20LeaveRequestItem.gxTpr_Leaverequestid = A127LeaveRequestId;
               AV20LeaveRequestItem.gxTpr_Leaverequeststartdate = A129LeaveRequestStartDate;
               AV20LeaveRequestItem.gxTpr_Leavetypeid = A124LeaveTypeId;
               GXt_char1 = "";
               new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "DD/MM/YYYY", out  GXt_char1) ;
               AV20LeaveRequestItem.gxTpr_Leaverequeststartdatestring = GXt_char1;
               if ( ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( AV9FromDate ) ) || ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) > DateTimeUtil.ResetTime ( AV10ToDate ) ) )
               {
                  AV13LeaveRequestStartDate = A129LeaveRequestStartDate;
                  AV16LeaveRequestEndDate = A130LeaveRequestEndDate;
                  if ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( AV9FromDate ) )
                  {
                     AV13LeaveRequestStartDate = AV9FromDate;
                  }
                  if ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) > DateTimeUtil.ResetTime ( AV10ToDate ) )
                  {
                     AV16LeaveRequestEndDate = AV10ToDate;
                  }
                  GXt_decimal2 = AV12LeaveRequestDuration;
                  new getleaverequestdays(context ).execute(  AV13LeaveRequestStartDate,  AV16LeaveRequestEndDate,  A171LeaveRequestHalfDay,  AV8EmployeeId, out  GXt_decimal2) ;
                  AV12LeaveRequestDuration = GXt_decimal2;
                  AV20LeaveRequestItem.gxTpr_Leaverequestduration = AV12LeaveRequestDuration;
               }
               else
               {
                  AV12LeaveRequestDuration = A131LeaveRequestDuration;
                  AV20LeaveRequestItem.gxTpr_Leaverequestduration = A131LeaveRequestDuration;
               }
               if ( AV21LeaveRequestCount == 1 )
               {
                  AV17SDTEmployeeLeaveDetails.gxTpr_Firstleaverequestid = A127LeaveRequestId;
                  AV17SDTEmployeeLeaveDetails.gxTpr_Firstleaverequeststartdate = A129LeaveRequestStartDate;
                  AV17SDTEmployeeLeaveDetails.gxTpr_Firstleaverequestduration = AV12LeaveRequestDuration;
                  AV17SDTEmployeeLeaveDetails.gxTpr_Firstleavetypeid = A124LeaveTypeId;
                  GXt_char1 = "";
                  new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "DD/MM/YYYY", out  GXt_char1) ;
                  AV17SDTEmployeeLeaveDetails.gxTpr_Firstleaverequeststartdatestring = GXt_char1;
               }
               else
               {
                  AV17SDTEmployeeLeaveDetails.gxTpr_Leaverequest.Add(AV20LeaveRequestItem, 0);
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( AV27GXLvl11 == 0 )
            {
               AV21LeaveRequestCount = 1;
            }
            AV17SDTEmployeeLeaveDetails.gxTpr_Leaverequestcount = AV21LeaveRequestCount;
            if ( ! (0==AV17SDTEmployeeLeaveDetails.gxTpr_Firstleaverequestid) )
            {
               AV18SDTEmployeeLeaveDetailsCollection.Add(AV17SDTEmployeeLeaveDetails, 0);
            }
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
         AV18SDTEmployeeLeaveDetailsCollection = new GXBaseCollection<SdtSDTEmployeeLeaveDetails>( context, "SDTEmployeeLeaveDetails", "YTT_version4");
         P00AN2_A100CompanyId = new long[1] ;
         P00AN2_A106EmployeeId = new long[1] ;
         P00AN2_A157CompanyLocationId = new long[1] ;
         P00AN2_A147EmployeeBalance = new decimal[1] ;
         P00AN2_A148EmployeeName = new string[] {""} ;
         A148EmployeeName = "";
         AV17SDTEmployeeLeaveDetails = new SdtSDTEmployeeLeaveDetails(context);
         P00AN3_A106EmployeeId = new long[1] ;
         P00AN3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00AN3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00AN3_A127LeaveRequestId = new long[1] ;
         P00AN3_A124LeaveTypeId = new long[1] ;
         P00AN3_A171LeaveRequestHalfDay = new string[] {""} ;
         P00AN3_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00AN3_A131LeaveRequestDuration = new decimal[1] ;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A171LeaveRequestHalfDay = "";
         AV20LeaveRequestItem = new SdtSDTEmployeeLeaveDetails_LeaveRequestItem(context);
         AV13LeaveRequestStartDate = DateTime.MinValue;
         AV16LeaveRequestEndDate = DateTime.MinValue;
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aemployeeleavedetailsreport__default(),
            new Object[][] {
                new Object[] {
               P00AN2_A100CompanyId, P00AN2_A106EmployeeId, P00AN2_A157CompanyLocationId, P00AN2_A147EmployeeBalance, P00AN2_A148EmployeeName
               }
               , new Object[] {
               P00AN3_A106EmployeeId, P00AN3_A130LeaveRequestEndDate, P00AN3_A129LeaveRequestStartDate, P00AN3_A127LeaveRequestId, P00AN3_A124LeaveTypeId, P00AN3_A171LeaveRequestHalfDay, P00AN3_n171LeaveRequestHalfDay, P00AN3_A131LeaveRequestDuration
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21LeaveRequestCount ;
      private short AV27GXLvl11 ;
      private long AV24CompanyLocationId ;
      private long A106EmployeeId ;
      private long A157CompanyLocationId ;
      private long A100CompanyId ;
      private long AV8EmployeeId ;
      private long A127LeaveRequestId ;
      private long A124LeaveTypeId ;
      private decimal A147EmployeeBalance ;
      private decimal A131LeaveRequestDuration ;
      private decimal AV12LeaveRequestDuration ;
      private decimal GXt_decimal2 ;
      private string A148EmployeeName ;
      private string A171LeaveRequestHalfDay ;
      private string GXt_char1 ;
      private DateTime AV9FromDate ;
      private DateTime AV10ToDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime AV13LeaveRequestStartDate ;
      private DateTime AV16LeaveRequestEndDate ;
      private bool n171LeaveRequestHalfDay ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV25EmployeeIdCollection ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDetails> AV18SDTEmployeeLeaveDetailsCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P00AN2_A100CompanyId ;
      private long[] P00AN2_A106EmployeeId ;
      private long[] P00AN2_A157CompanyLocationId ;
      private decimal[] P00AN2_A147EmployeeBalance ;
      private string[] P00AN2_A148EmployeeName ;
      private SdtSDTEmployeeLeaveDetails AV17SDTEmployeeLeaveDetails ;
      private long[] P00AN3_A106EmployeeId ;
      private DateTime[] P00AN3_A130LeaveRequestEndDate ;
      private DateTime[] P00AN3_A129LeaveRequestStartDate ;
      private long[] P00AN3_A127LeaveRequestId ;
      private long[] P00AN3_A124LeaveTypeId ;
      private string[] P00AN3_A171LeaveRequestHalfDay ;
      private bool[] P00AN3_n171LeaveRequestHalfDay ;
      private decimal[] P00AN3_A131LeaveRequestDuration ;
      private SdtSDTEmployeeLeaveDetails_LeaveRequestItem AV20LeaveRequestItem ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDetails> aP4_SDTEmployeeLeaveDetailsCollection ;
   }

   public class aemployeeleavedetailsreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AN2( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV25EmployeeIdCollection ,
                                             long AV24CompanyLocationId ,
                                             long A157CompanyLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T1.EmployeeId, T2.CompanyLocationId, T1.EmployeeBalance, T1.EmployeeName FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV25EmployeeIdCollection, "T1.EmployeeId IN (", ")")+")");
         if ( ! (0==AV24CompanyLocationId) )
         {
            AddWhere(sWhereString, "(T2.CompanyLocationId = :AV24CompanyLocationId)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeName";
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
                     return conditional_P00AN2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] );
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
          Object[] prmP00AN3;
          prmP00AN3 = new Object[] {
          new ParDef("AV10ToDate",GXType.Date,8,0) ,
          new ParDef("AV9FromDate",GXType.Date,8,0) ,
          new ParDef("AV8EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP00AN2;
          prmP00AN2 = new Object[] {
          new ParDef("AV24CompanyLocationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AN2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AN2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AN3", "SELECT EmployeeId, LeaveRequestEndDate, LeaveRequestStartDate, LeaveRequestId, LeaveTypeId, LeaveRequestHalfDay, LeaveRequestDuration FROM LeaveRequest WHERE (( LeaveRequestStartDate < :AV10ToDate and LeaveRequestEndDate > :AV9FromDate)) AND (EmployeeId = :AV8EmployeeId) ORDER BY LeaveRequestStartDate ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AN3,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                return;
       }
    }

 }

}
