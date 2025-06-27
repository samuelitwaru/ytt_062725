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
   public class aprocgetemployeeleavetotal : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprocgetemployeeleavetotal().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
          long aP0_EmployeeId ;
         DateTime aP1_DateFrom = new DateTime()  ;
         DateTime aP2_DateTo = new DateTime()  ;
          long aP3_TotalLeaveHours ;
         if ( 0 < args.Length )
         {
            aP0_EmployeeId=((long)(NumberUtil.Val( (string)(args[0]), ".")));
         }
         else
         {
            aP0_EmployeeId=0;
         }
         if ( 1 < args.Length )
         {
            aP1_DateFrom=((DateTime)(context.localUtil.CToD( (string)(args[1]), 2)));
         }
         else
         {
            aP1_DateFrom=DateTime.MinValue;
         }
         if ( 2 < args.Length )
         {
            aP2_DateTo=((DateTime)(context.localUtil.CToD( (string)(args[2]), 2)));
         }
         else
         {
            aP2_DateTo=DateTime.MinValue;
         }
         if ( 3 < args.Length )
         {
            aP3_TotalLeaveHours=((long)(NumberUtil.Val( (string)(args[3]), ".")));
         }
         else
         {
            aP3_TotalLeaveHours=0;
         }
         execute(aP0_EmployeeId, aP1_DateFrom, aP2_DateTo, out aP3_TotalLeaveHours);
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

      public aprocgetemployeeleavetotal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprocgetemployeeleavetotal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           DateTime aP1_DateFrom ,
                           DateTime aP2_DateTo ,
                           out long aP3_TotalLeaveHours )
      {
         this.AV11EmployeeId = aP0_EmployeeId;
         this.AV10DateFrom = aP1_DateFrom;
         this.AV9DateTo = aP2_DateTo;
         this.AV8TotalLeaveHours = 0 ;
         initialize();
         ExecuteImpl();
         aP3_TotalLeaveHours=this.AV8TotalLeaveHours;
      }

      public long executeUdp( long aP0_EmployeeId ,
                              DateTime aP1_DateFrom ,
                              DateTime aP2_DateTo )
      {
         execute(aP0_EmployeeId, aP1_DateFrom, aP2_DateTo, out aP3_TotalLeaveHours);
         return AV8TotalLeaveHours ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 DateTime aP1_DateFrom ,
                                 DateTime aP2_DateTo ,
                                 out long aP3_TotalLeaveHours )
      {
         this.AV11EmployeeId = aP0_EmployeeId;
         this.AV10DateFrom = aP1_DateFrom;
         this.AV9DateTo = aP2_DateTo;
         this.AV8TotalLeaveHours = 0 ;
         SubmitImpl();
         aP3_TotalLeaveHours=this.AV8TotalLeaveHours;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8TotalLeaveHours = 0;
         AV8TotalLeaveHours = 0;
         /* Using cursor P00642 */
         pr_default.execute(0, new Object[] {AV11EmployeeId, AV9DateTo, AV10DateFrom});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P00642_A124LeaveTypeId[0];
            A145LeaveTypeLoggingWorkHours = P00642_A145LeaveTypeLoggingWorkHours[0];
            A130LeaveRequestEndDate = P00642_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00642_A129LeaveRequestStartDate[0];
            A106EmployeeId = P00642_A106EmployeeId[0];
            A132LeaveRequestStatus = P00642_A132LeaveRequestStatus[0];
            A171LeaveRequestHalfDay = P00642_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P00642_n171LeaveRequestHalfDay[0];
            A127LeaveRequestId = P00642_A127LeaveRequestId[0];
            A145LeaveTypeLoggingWorkHours = P00642_A145LeaveTypeLoggingWorkHours[0];
            GXt_decimal1 = AV24Var;
            new getleaverequestdays(context ).execute(  A129LeaveRequestStartDate,  A130LeaveRequestEndDate,  A171LeaveRequestHalfDay,  AV11EmployeeId, out  GXt_decimal1) ;
            AV24Var = GXt_decimal1;
            AV8TotalLeaveHours = (long)(AV8TotalLeaveHours+AV24Var);
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
         P00642_A124LeaveTypeId = new long[1] ;
         P00642_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         P00642_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00642_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00642_A106EmployeeId = new long[1] ;
         P00642_A132LeaveRequestStatus = new string[] {""} ;
         P00642_A171LeaveRequestHalfDay = new string[] {""} ;
         P00642_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00642_A127LeaveRequestId = new long[1] ;
         A145LeaveTypeLoggingWorkHours = "";
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         A171LeaveRequestHalfDay = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprocgetemployeeleavetotal__default(),
            new Object[][] {
                new Object[] {
               P00642_A124LeaveTypeId, P00642_A145LeaveTypeLoggingWorkHours, P00642_A130LeaveRequestEndDate, P00642_A129LeaveRequestStartDate, P00642_A106EmployeeId, P00642_A132LeaveRequestStatus, P00642_A171LeaveRequestHalfDay, P00642_n171LeaveRequestHalfDay, P00642_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV11EmployeeId ;
      private long AV8TotalLeaveHours ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long A127LeaveRequestId ;
      private decimal AV24Var ;
      private decimal GXt_decimal1 ;
      private string A145LeaveTypeLoggingWorkHours ;
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
      private long[] P00642_A124LeaveTypeId ;
      private string[] P00642_A145LeaveTypeLoggingWorkHours ;
      private DateTime[] P00642_A130LeaveRequestEndDate ;
      private DateTime[] P00642_A129LeaveRequestStartDate ;
      private long[] P00642_A106EmployeeId ;
      private string[] P00642_A132LeaveRequestStatus ;
      private string[] P00642_A171LeaveRequestHalfDay ;
      private bool[] P00642_n171LeaveRequestHalfDay ;
      private long[] P00642_A127LeaveRequestId ;
      private long aP3_TotalLeaveHours ;
   }

   public class aprocgetemployeeleavetotal__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00642;
          prmP00642 = new Object[] {
          new ParDef("AV11EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV9DateTo",GXType.Date,8,0) ,
          new ParDef("AV10DateFrom",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00642", "SELECT T1.LeaveTypeId, T2.LeaveTypeLoggingWorkHours, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.EmployeeId, T1.LeaveRequestStatus, T1.LeaveRequestHalfDay, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :AV11EmployeeId) AND (T1.LeaveRequestStartDate < :AV9DateTo) AND (T1.LeaveRequestEndDate > :AV10DateFrom) AND (T1.LeaveRequestStatus = ( 'Approved')) AND (T2.LeaveTypeLoggingWorkHours = ( 'No')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00642,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
