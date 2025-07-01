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
   public class prc_getemployeeapprovedvacationdays : GXProcedure
   {
      public prc_getemployeeapprovedvacationdays( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getemployeeapprovedvacationdays( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           DateTime aP1_DateFrom ,
                           DateTime aP2_DateTo ,
                           out decimal aP3_Days )
      {
         this.AV11EmployeeId = aP0_EmployeeId;
         this.AV10DateFrom = aP1_DateFrom;
         this.AV9DateTo = aP2_DateTo;
         this.AV17Days = 0 ;
         initialize();
         ExecuteImpl();
         aP3_Days=this.AV17Days;
      }

      public decimal executeUdp( long aP0_EmployeeId ,
                                 DateTime aP1_DateFrom ,
                                 DateTime aP2_DateTo )
      {
         execute(aP0_EmployeeId, aP1_DateFrom, aP2_DateTo, out aP3_Days);
         return AV17Days ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 DateTime aP1_DateFrom ,
                                 DateTime aP2_DateTo ,
                                 out decimal aP3_Days )
      {
         this.AV11EmployeeId = aP0_EmployeeId;
         this.AV10DateFrom = aP1_DateFrom;
         this.AV9DateTo = aP2_DateTo;
         this.AV17Days = 0 ;
         SubmitImpl();
         aP3_Days=this.AV17Days;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00AM2 */
         pr_default.execute(0, new Object[] {AV11EmployeeId, AV9DateTo, AV10DateFrom});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P00AM2_A124LeaveTypeId[0];
            A144LeaveTypeVacationLeave = P00AM2_A144LeaveTypeVacationLeave[0];
            A132LeaveRequestStatus = P00AM2_A132LeaveRequestStatus[0];
            A130LeaveRequestEndDate = P00AM2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00AM2_A129LeaveRequestStartDate[0];
            A106EmployeeId = P00AM2_A106EmployeeId[0];
            A171LeaveRequestHalfDay = P00AM2_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P00AM2_n171LeaveRequestHalfDay[0];
            A131LeaveRequestDuration = P00AM2_A131LeaveRequestDuration[0];
            A127LeaveRequestId = P00AM2_A127LeaveRequestId[0];
            A144LeaveTypeVacationLeave = P00AM2_A144LeaveTypeVacationLeave[0];
            if ( ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( AV10DateFrom ) ) && ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) <= DateTimeUtil.ResetTime ( AV9DateTo ) ) )
            {
               GXt_decimal1 = AV19ExceptDays;
               new getleaverequestdays(context ).execute(  AV10DateFrom,  A130LeaveRequestEndDate,  A171LeaveRequestHalfDay,  AV11EmployeeId, out  GXt_decimal1) ;
               AV19ExceptDays = GXt_decimal1;
               AV17Days = (decimal)(AV17Days+AV19ExceptDays);
            }
            else if ( ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) >= DateTimeUtil.ResetTime ( AV10DateFrom ) ) && ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) > DateTimeUtil.ResetTime ( AV9DateTo ) ) )
            {
               GXt_decimal1 = AV19ExceptDays;
               new getleaverequestdays(context ).execute(  A129LeaveRequestStartDate,  AV9DateTo,  A171LeaveRequestHalfDay,  AV11EmployeeId, out  GXt_decimal1) ;
               AV19ExceptDays = GXt_decimal1;
               AV17Days = (decimal)(AV17Days+AV19ExceptDays);
            }
            else
            {
               AV17Days = (decimal)(AV17Days+A131LeaveRequestDuration);
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
         P00AM2_A124LeaveTypeId = new long[1] ;
         P00AM2_A144LeaveTypeVacationLeave = new string[] {""} ;
         P00AM2_A132LeaveRequestStatus = new string[] {""} ;
         P00AM2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00AM2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00AM2_A106EmployeeId = new long[1] ;
         P00AM2_A171LeaveRequestHalfDay = new string[] {""} ;
         P00AM2_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00AM2_A131LeaveRequestDuration = new decimal[1] ;
         P00AM2_A127LeaveRequestId = new long[1] ;
         A144LeaveTypeVacationLeave = "";
         A132LeaveRequestStatus = "";
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A171LeaveRequestHalfDay = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getemployeeapprovedvacationdays__default(),
            new Object[][] {
                new Object[] {
               P00AM2_A124LeaveTypeId, P00AM2_A144LeaveTypeVacationLeave, P00AM2_A132LeaveRequestStatus, P00AM2_A130LeaveRequestEndDate, P00AM2_A129LeaveRequestStartDate, P00AM2_A106EmployeeId, P00AM2_A171LeaveRequestHalfDay, P00AM2_n171LeaveRequestHalfDay, P00AM2_A131LeaveRequestDuration, P00AM2_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV11EmployeeId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long A127LeaveRequestId ;
      private decimal AV17Days ;
      private decimal A131LeaveRequestDuration ;
      private decimal AV19ExceptDays ;
      private decimal GXt_decimal1 ;
      private string A144LeaveTypeVacationLeave ;
      private string A132LeaveRequestStatus ;
      private string A171LeaveRequestHalfDay ;
      private DateTime AV10DateFrom ;
      private DateTime AV9DateTo ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private bool n171LeaveRequestHalfDay ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00AM2_A124LeaveTypeId ;
      private string[] P00AM2_A144LeaveTypeVacationLeave ;
      private string[] P00AM2_A132LeaveRequestStatus ;
      private DateTime[] P00AM2_A130LeaveRequestEndDate ;
      private DateTime[] P00AM2_A129LeaveRequestStartDate ;
      private long[] P00AM2_A106EmployeeId ;
      private string[] P00AM2_A171LeaveRequestHalfDay ;
      private bool[] P00AM2_n171LeaveRequestHalfDay ;
      private decimal[] P00AM2_A131LeaveRequestDuration ;
      private long[] P00AM2_A127LeaveRequestId ;
      private decimal aP3_Days ;
   }

   public class prc_getemployeeapprovedvacationdays__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AM2;
          prmP00AM2 = new Object[] {
          new ParDef("AV11EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV9DateTo",GXType.Date,8,0) ,
          new ParDef("AV10DateFrom",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AM2", "SELECT T1.LeaveTypeId, T2.LeaveTypeVacationLeave, T1.LeaveRequestStatus, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.EmployeeId, T1.LeaveRequestHalfDay, T1.LeaveRequestDuration, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :AV11EmployeeId) AND (T1.LeaveRequestStartDate < :AV9DateTo and T1.LeaveRequestEndDate > :AV10DateFrom) AND (T1.LeaveRequestStatus = ( 'Approved')) AND (T2.LeaveTypeVacationLeave = ( 'Yes')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AM2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                return;
       }
    }

 }

}
