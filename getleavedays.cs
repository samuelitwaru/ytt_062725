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
   public class getleavedays : GXProcedure
   {
      public getleavedays( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getleavedays( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           out GXBaseCollection<SdtSDTEmployeeLeaveDay> aP1_EmployeeLeaveDays )
      {
         this.AV9EmployeeId = aP0_EmployeeId;
         this.AV10EmployeeLeaveDays = new GXBaseCollection<SdtSDTEmployeeLeaveDay>( context, "SDTEmployeeLeaveDay", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP1_EmployeeLeaveDays=this.AV10EmployeeLeaveDays;
      }

      public GXBaseCollection<SdtSDTEmployeeLeaveDay> executeUdp( long aP0_EmployeeId )
      {
         execute(aP0_EmployeeId, out aP1_EmployeeLeaveDays);
         return AV10EmployeeLeaveDays ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 out GXBaseCollection<SdtSDTEmployeeLeaveDay> aP1_EmployeeLeaveDays )
      {
         this.AV9EmployeeId = aP0_EmployeeId;
         this.AV10EmployeeLeaveDays = new GXBaseCollection<SdtSDTEmployeeLeaveDay>( context, "SDTEmployeeLeaveDay", "YTT_version4") ;
         SubmitImpl();
         aP1_EmployeeLeaveDays=this.AV10EmployeeLeaveDays;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00A52 */
         pr_default.execute(0, new Object[] {AV9EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P00A52_A124LeaveTypeId[0];
            A132LeaveRequestStatus = P00A52_A132LeaveRequestStatus[0];
            A106EmployeeId = P00A52_A106EmployeeId[0];
            A129LeaveRequestStartDate = P00A52_A129LeaveRequestStartDate[0];
            A130LeaveRequestEndDate = P00A52_A130LeaveRequestEndDate[0];
            A125LeaveTypeName = P00A52_A125LeaveTypeName[0];
            A127LeaveRequestId = P00A52_A127LeaveRequestId[0];
            A125LeaveTypeName = P00A52_A125LeaveTypeName[0];
            AV8CurrentDAte = A129LeaveRequestStartDate;
            while ( DateTimeUtil.ResetTime ( AV8CurrentDAte ) <= DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) )
            {
               AV11day = new SdtSDTEmployeeLeaveDay(context);
               AV11day.gxTpr_Date = AV8CurrentDAte;
               AV11day.gxTpr_Leavetype = A125LeaveTypeName;
               AV10EmployeeLeaveDays.Add(AV11day, 0);
               AV8CurrentDAte = DateTimeUtil.DAdd( AV8CurrentDAte, (1));
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
         AV10EmployeeLeaveDays = new GXBaseCollection<SdtSDTEmployeeLeaveDay>( context, "SDTEmployeeLeaveDay", "YTT_version4");
         P00A52_A124LeaveTypeId = new long[1] ;
         P00A52_A132LeaveRequestStatus = new string[] {""} ;
         P00A52_A106EmployeeId = new long[1] ;
         P00A52_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00A52_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00A52_A125LeaveTypeName = new string[] {""} ;
         P00A52_A127LeaveRequestId = new long[1] ;
         A132LeaveRequestStatus = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A125LeaveTypeName = "";
         AV8CurrentDAte = DateTime.MinValue;
         AV11day = new SdtSDTEmployeeLeaveDay(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getleavedays__default(),
            new Object[][] {
                new Object[] {
               P00A52_A124LeaveTypeId, P00A52_A132LeaveRequestStatus, P00A52_A106EmployeeId, P00A52_A129LeaveRequestStartDate, P00A52_A130LeaveRequestEndDate, P00A52_A125LeaveTypeName, P00A52_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9EmployeeId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long A127LeaveRequestId ;
      private string A132LeaveRequestStatus ;
      private string A125LeaveTypeName ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime AV8CurrentDAte ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDay> AV10EmployeeLeaveDays ;
      private IDataStoreProvider pr_default ;
      private long[] P00A52_A124LeaveTypeId ;
      private string[] P00A52_A132LeaveRequestStatus ;
      private long[] P00A52_A106EmployeeId ;
      private DateTime[] P00A52_A129LeaveRequestStartDate ;
      private DateTime[] P00A52_A130LeaveRequestEndDate ;
      private string[] P00A52_A125LeaveTypeName ;
      private long[] P00A52_A127LeaveRequestId ;
      private SdtSDTEmployeeLeaveDay AV11day ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDay> aP1_EmployeeLeaveDays ;
   }

   public class getleavedays__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00A52;
          prmP00A52 = new Object[] {
          new ParDef("AV9EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A52", "SELECT T1.LeaveTypeId, T1.LeaveRequestStatus, T1.EmployeeId, T1.LeaveRequestStartDate, T1.LeaveRequestEndDate, T2.LeaveTypeName, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :AV9EmployeeId) AND (T1.LeaveRequestStatus = ( 'Approved')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A52,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
       }
    }

 }

}
