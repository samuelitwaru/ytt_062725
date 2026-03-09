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
   public class prc_checkleavedateavailabilty : GXProcedure
   {
      public prc_checkleavedateavailabilty( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_checkleavedateavailabilty( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_StartDate ,
                           DateTime aP1_EndDate ,
                           ref string aP2_LeaveRequestHalfDay ,
                           ref long aP3_EmployeeId ,
                           out bool aP4_IsAvailable )
      {
         this.AV8StartDate = aP0_StartDate;
         this.AV9EndDate = aP1_EndDate;
         this.AV13LeaveRequestHalfDay = aP2_LeaveRequestHalfDay;
         this.AV11EmployeeId = aP3_EmployeeId;
         this.AV10IsAvailable = false ;
         initialize();
         ExecuteImpl();
         aP2_LeaveRequestHalfDay=this.AV13LeaveRequestHalfDay;
         aP3_EmployeeId=this.AV11EmployeeId;
         aP4_IsAvailable=this.AV10IsAvailable;
      }

      public bool executeUdp( DateTime aP0_StartDate ,
                              DateTime aP1_EndDate ,
                              ref string aP2_LeaveRequestHalfDay ,
                              ref long aP3_EmployeeId )
      {
         execute(aP0_StartDate, aP1_EndDate, ref aP2_LeaveRequestHalfDay, ref aP3_EmployeeId, out aP4_IsAvailable);
         return AV10IsAvailable ;
      }

      public void executeSubmit( DateTime aP0_StartDate ,
                                 DateTime aP1_EndDate ,
                                 ref string aP2_LeaveRequestHalfDay ,
                                 ref long aP3_EmployeeId ,
                                 out bool aP4_IsAvailable )
      {
         this.AV8StartDate = aP0_StartDate;
         this.AV9EndDate = aP1_EndDate;
         this.AV13LeaveRequestHalfDay = aP2_LeaveRequestHalfDay;
         this.AV11EmployeeId = aP3_EmployeeId;
         this.AV10IsAvailable = false ;
         SubmitImpl();
         aP2_LeaveRequestHalfDay=this.AV13LeaveRequestHalfDay;
         aP3_EmployeeId=this.AV11EmployeeId;
         aP4_IsAvailable=this.AV10IsAvailable;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new logtofile(context ).execute(  "EmployeeId: "+StringUtil.Str( (decimal)(AV11EmployeeId), 10, 0)) ;
         new logtofile(context ).execute(  "Start: "+context.localUtil.DToC( AV8StartDate, 2, "/")) ;
         new logtofile(context ).execute(  "End: "+context.localUtil.DToC( AV9EndDate, 2, "/")) ;
         AV14GXLvl5 = 0;
         /* Using cursor P00C22 */
         pr_default.execute(0, new Object[] {AV11EmployeeId, AV8StartDate, AV9EndDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P00C22_A124LeaveTypeId[0];
            A144LeaveTypeVacationLeave = P00C22_A144LeaveTypeVacationLeave[0];
            A129LeaveRequestStartDate = P00C22_A129LeaveRequestStartDate[0];
            A130LeaveRequestEndDate = P00C22_A130LeaveRequestEndDate[0];
            A106EmployeeId = P00C22_A106EmployeeId[0];
            A127LeaveRequestId = P00C22_A127LeaveRequestId[0];
            A144LeaveTypeVacationLeave = P00C22_A144LeaveTypeVacationLeave[0];
            AV14GXLvl5 = 1;
            AV10IsAvailable = false;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV14GXLvl5 == 0 )
         {
            AV10IsAvailable = true;
         }
         new logtofile(context ).execute(  "IsAvailable: "+StringUtil.BoolToStr( AV10IsAvailable)) ;
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
         P00C22_A124LeaveTypeId = new long[1] ;
         P00C22_A144LeaveTypeVacationLeave = new string[] {""} ;
         P00C22_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00C22_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00C22_A106EmployeeId = new long[1] ;
         P00C22_A127LeaveRequestId = new long[1] ;
         A144LeaveTypeVacationLeave = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_checkleavedateavailabilty__default(),
            new Object[][] {
                new Object[] {
               P00C22_A124LeaveTypeId, P00C22_A144LeaveTypeVacationLeave, P00C22_A129LeaveRequestStartDate, P00C22_A130LeaveRequestEndDate, P00C22_A106EmployeeId, P00C22_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14GXLvl5 ;
      private long AV11EmployeeId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long A127LeaveRequestId ;
      private string AV13LeaveRequestHalfDay ;
      private string A144LeaveTypeVacationLeave ;
      private DateTime AV8StartDate ;
      private DateTime AV9EndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool AV10IsAvailable ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP2_LeaveRequestHalfDay ;
      private long aP3_EmployeeId ;
      private IDataStoreProvider pr_default ;
      private long[] P00C22_A124LeaveTypeId ;
      private string[] P00C22_A144LeaveTypeVacationLeave ;
      private DateTime[] P00C22_A129LeaveRequestStartDate ;
      private DateTime[] P00C22_A130LeaveRequestEndDate ;
      private long[] P00C22_A106EmployeeId ;
      private long[] P00C22_A127LeaveRequestId ;
      private bool aP4_IsAvailable ;
   }

   public class prc_checkleavedateavailabilty__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00C22;
          prmP00C22 = new Object[] {
          new ParDef("AV11EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV8StartDate",GXType.Date,8,0) ,
          new ParDef("AV9EndDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C22", "SELECT T1.LeaveTypeId, T2.LeaveTypeVacationLeave, T1.LeaveRequestStartDate, T1.LeaveRequestEndDate, T1.EmployeeId, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :AV11EmployeeId) AND (:AV8StartDate <= T1.LeaveRequestEndDate) AND (:AV9EndDate >= T1.LeaveRequestStartDate) AND (T2.LeaveTypeVacationLeave = ( 'Yes')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C22,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
