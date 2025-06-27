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
   public class getleaverequestdays : GXProcedure
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
            return "getleaverequestdays_Services_Execute" ;
         }

      }

      public getleaverequestdays( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getleaverequestdays( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( [GxJsonFormat("yyyy-MM-dd")] DateTime aP0_StartDate ,
                           [GxJsonFormat("yyyy-MM-dd")] DateTime aP1_EndDate ,
                           string aP2_LeaveRequestHalfDay ,
                           long aP3_EmployeeId ,
                           out decimal aP4_FinalDuration )
      {
         this.AV14StartDate = aP0_StartDate;
         this.AV10EndDate = aP1_EndDate;
         this.AV19LeaveRequestHalfDay = aP2_LeaveRequestHalfDay;
         this.AV20EmployeeId = aP3_EmployeeId;
         this.AV17FinalDuration = 0 ;
         initialize();
         ExecuteImpl();
         aP4_FinalDuration=this.AV17FinalDuration;
      }

      public decimal executeUdp( DateTime aP0_StartDate ,
                                 DateTime aP1_EndDate ,
                                 string aP2_LeaveRequestHalfDay ,
                                 long aP3_EmployeeId )
      {
         execute(aP0_StartDate, aP1_EndDate, aP2_LeaveRequestHalfDay, aP3_EmployeeId, out aP4_FinalDuration);
         return AV17FinalDuration ;
      }

      public void executeSubmit( DateTime aP0_StartDate ,
                                 DateTime aP1_EndDate ,
                                 string aP2_LeaveRequestHalfDay ,
                                 long aP3_EmployeeId ,
                                 out decimal aP4_FinalDuration )
      {
         this.AV14StartDate = aP0_StartDate;
         this.AV10EndDate = aP1_EndDate;
         this.AV19LeaveRequestHalfDay = aP2_LeaveRequestHalfDay;
         this.AV20EmployeeId = aP3_EmployeeId;
         this.AV17FinalDuration = 0 ;
         SubmitImpl();
         aP4_FinalDuration=this.AV17FinalDuration;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16totalHoliday = 0;
         AV9Duration = 0;
         /* Using cursor P005N2 */
         pr_default.execute(0, new Object[] {AV20EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P005N2_A106EmployeeId[0];
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P005N3 */
         pr_default.execute(1, new Object[] {AV18CompanyId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A139HolidayIsActive = P005N3_A139HolidayIsActive[0];
            A100CompanyId = P005N3_A100CompanyId[0];
            A115HolidayStartDate = P005N3_A115HolidayStartDate[0];
            A113HolidayId = P005N3_A113HolidayId[0];
            AV13MyDate = A115HolidayStartDate;
            if ( ( DateTimeUtil.ResetTime ( AV13MyDate ) >= DateTimeUtil.ResetTime ( AV14StartDate ) ) && ( DateTimeUtil.ResetTime ( AV13MyDate ) <= DateTimeUtil.ResetTime ( AV10EndDate ) ) && ( DateTimeUtil.Dow( AV13MyDate) != 1 ) && ( DateTimeUtil.Dow( AV13MyDate) != 7 ) )
            {
               AV16totalHoliday = (short)(AV16totalHoliday+1);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( StringUtil.StrCmp(AV19LeaveRequestHalfDay, "") != 0 )
         {
            if ( AV16totalHoliday == 0 )
            {
               if ( ( DateTimeUtil.Dow( AV14StartDate) != 1 ) && ( DateTimeUtil.Dow( AV14StartDate) != 7 ) )
               {
                  AV17FinalDuration = 0.5m;
               }
               else
               {
                  AV17FinalDuration = 0;
               }
            }
            else
            {
               AV17FinalDuration = 0;
            }
         }
         else
         {
            while ( DateTimeUtil.ResetTime ( AV14StartDate ) <= DateTimeUtil.ResetTime ( AV10EndDate ) )
            {
               AV8dateNumber = DateTimeUtil.Dow( AV14StartDate);
               if ( ( AV8dateNumber != 1 ) && ( AV8dateNumber != 7 ) )
               {
                  AV9Duration = (short)(AV9Duration+1);
               }
               AV14StartDate = DateTimeUtil.DAdd( AV14StartDate, (1));
            }
            AV17FinalDuration = (decimal)(AV9Duration-AV16totalHoliday);
         }
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
         P005N2_A106EmployeeId = new long[1] ;
         P005N3_A139HolidayIsActive = new bool[] {false} ;
         P005N3_A100CompanyId = new long[1] ;
         P005N3_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P005N3_A113HolidayId = new long[1] ;
         A115HolidayStartDate = DateTime.MinValue;
         AV13MyDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getleaverequestdays__default(),
            new Object[][] {
                new Object[] {
               P005N2_A106EmployeeId
               }
               , new Object[] {
               P005N3_A139HolidayIsActive, P005N3_A100CompanyId, P005N3_A115HolidayStartDate, P005N3_A113HolidayId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16totalHoliday ;
      private short AV9Duration ;
      private short AV8dateNumber ;
      private long AV20EmployeeId ;
      private long A106EmployeeId ;
      private long AV18CompanyId ;
      private long A100CompanyId ;
      private long A113HolidayId ;
      private decimal AV17FinalDuration ;
      private string AV19LeaveRequestHalfDay ;
      private DateTime AV14StartDate ;
      private DateTime AV10EndDate ;
      private DateTime A115HolidayStartDate ;
      private DateTime AV13MyDate ;
      private bool A139HolidayIsActive ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P005N2_A106EmployeeId ;
      private bool[] P005N3_A139HolidayIsActive ;
      private long[] P005N3_A100CompanyId ;
      private DateTime[] P005N3_A115HolidayStartDate ;
      private long[] P005N3_A113HolidayId ;
      private decimal aP4_FinalDuration ;
   }

   public class getleaverequestdays__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005N2;
          prmP005N2 = new Object[] {
          new ParDef("AV20EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP005N3;
          prmP005N3 = new Object[] {
          new ParDef("AV18CompanyId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005N2", "SELECT EmployeeId FROM Employee WHERE EmployeeId = :AV20EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005N2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005N3", "SELECT HolidayIsActive, CompanyId, HolidayStartDate, HolidayId FROM Holiday WHERE (CompanyId = :AV18CompanyId) AND (HolidayIsActive = TRUE) ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005N3,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
