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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class getleaveevents : GXProcedure
   {
      public getleaveevents( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getleaveevents( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_dateFrom ,
                           DateTime aP1_dateTo ,
                           out SdtSchedulerEvents aP2_events )
      {
         this.AV8dateFrom = aP0_dateFrom;
         this.AV9dateTo = aP1_dateTo;
         this.AV12events = new SdtSchedulerEvents(context) ;
         initialize();
         ExecuteImpl();
         aP2_events=this.AV12events;
      }

      public SdtSchedulerEvents executeUdp( DateTime aP0_dateFrom ,
                                            DateTime aP1_dateTo )
      {
         execute(aP0_dateFrom, aP1_dateTo, out aP2_events);
         return AV12events ;
      }

      public void executeSubmit( DateTime aP0_dateFrom ,
                                 DateTime aP1_dateTo ,
                                 out SdtSchedulerEvents aP2_events )
      {
         this.AV8dateFrom = aP0_dateFrom;
         this.AV9dateTo = aP1_dateTo;
         this.AV12events = new SdtSchedulerEvents(context) ;
         SubmitImpl();
         aP2_events=this.AV12events;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_int1 = AV20CompanyId;
         new getloggedinusercompanyid(context ).execute( out  GXt_int1) ;
         AV20CompanyId = GXt_int1;
         if ( (0==AV20CompanyId) )
         {
            AV20CompanyId = (long)(Math.Round(NumberUtil.Val( AV26Httprequest.QueryString, "."), 18, MidpointRounding.ToEven));
            AV28CompanyLocationIdValue = AV27Session.Get("LeaveCalendarCompanyLocationId");
            AV29CompanyLocationId = (long)(Math.Round(NumberUtil.Val( AV28CompanyLocationIdValue, "."), 18, MidpointRounding.ToEven));
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV29CompanyLocationId ,
                                                 A157CompanyLocationId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor P007K2 */
            pr_default.execute(0, new Object[] {AV29CompanyLocationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A157CompanyLocationId = P007K2_A157CompanyLocationId[0];
               A100CompanyId = P007K2_A100CompanyId[0];
               AV20CompanyId = A100CompanyId;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         AV12events.gxTpr_Specialdays.Clear();
         /* Using cursor P007K3 */
         pr_default.execute(1, new Object[] {AV20CompanyId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A157CompanyLocationId = P007K3_A157CompanyLocationId[0];
            A100CompanyId = P007K3_A100CompanyId[0];
            A139HolidayIsActive = P007K3_A139HolidayIsActive[0];
            A115HolidayStartDate = P007K3_A115HolidayStartDate[0];
            A113HolidayId = P007K3_A113HolidayId[0];
            A158CompanyLocationName = P007K3_A158CompanyLocationName[0];
            A114HolidayName = P007K3_A114HolidayName[0];
            A157CompanyLocationId = P007K3_A157CompanyLocationId[0];
            A158CompanyLocationName = P007K3_A158CompanyLocationName[0];
            AV19SpecialDay = new SdtSchedulerEvents_Day(context);
            AV19SpecialDay.gxTpr_Date = context.localUtil.YMDToD( DateTimeUtil.Year( A115HolidayStartDate), DateTimeUtil.Month( A115HolidayStartDate), DateTimeUtil.Day( A115HolidayStartDate));
            AV12events.gxTpr_Specialdays.Add(AV19SpecialDay, 0);
            AV11event = new SdtSchedulerEvents_event(context);
            AV11event.gxTpr_Id = StringUtil.Str( (decimal)(A113HolidayId), 10, 0);
            AV11event.gxTpr_Name = A114HolidayName+" "+((0==AV20CompanyId) ? "("+A158CompanyLocationName+")" : "");
            AV11event.gxTpr_Starttime = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( A115HolidayStartDate)), (short)(DateTimeUtil.Month( A115HolidayStartDate)), (short)(DateTimeUtil.Day( A115HolidayStartDate)), 0, 0, 0);
            AV11event.gxTpr_Endtime = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( A115HolidayStartDate)), (short)(DateTimeUtil.Month( A115HolidayStartDate)), (short)(DateTimeUtil.Day( A115HolidayStartDate)), 23, 59, 59);
            AV12events.gxTpr_Items.Add(AV11event, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV20CompanyId ,
                                              A100CompanyId ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P007K4 */
         pr_default.execute(2, new Object[] {AV20CompanyId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A124LeaveTypeId = P007K4_A124LeaveTypeId[0];
            A106EmployeeId = P007K4_A106EmployeeId[0];
            A132LeaveRequestStatus = P007K4_A132LeaveRequestStatus[0];
            A100CompanyId = P007K4_A100CompanyId[0];
            A127LeaveRequestId = P007K4_A127LeaveRequestId[0];
            A108EmployeeLastName = P007K4_A108EmployeeLastName[0];
            A107EmployeeFirstName = P007K4_A107EmployeeFirstName[0];
            A125LeaveTypeName = P007K4_A125LeaveTypeName[0];
            A133LeaveRequestDescription = P007K4_A133LeaveRequestDescription[0];
            A129LeaveRequestStartDate = P007K4_A129LeaveRequestStartDate[0];
            A130LeaveRequestEndDate = P007K4_A130LeaveRequestEndDate[0];
            A100CompanyId = P007K4_A100CompanyId[0];
            A125LeaveTypeName = P007K4_A125LeaveTypeName[0];
            A108EmployeeLastName = P007K4_A108EmployeeLastName[0];
            A107EmployeeFirstName = P007K4_A107EmployeeFirstName[0];
            AV11event = new SdtSchedulerEvents_event(context);
            AV11event.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A127LeaveRequestId), 10, 0));
            AV11event.gxTpr_Name = A125LeaveTypeName+" "+"("+A107EmployeeFirstName+" "+A108EmployeeLastName+")";
            AV11event.gxTpr_Notes = A133LeaveRequestDescription;
            AV11event.gxTpr_Link = "http://www.genexus.com";
            GXt_dtime2 = DateTimeUtil.ResetTime( A129LeaveRequestStartDate ) ;
            AV11event.gxTpr_Starttime = GXt_dtime2;
            GXt_dtime2 = DateTimeUtil.ResetTime( A130LeaveRequestEndDate ) ;
            AV11event.gxTpr_Endtime = GXt_dtime2;
            AV11event.gxTpr_Starttime = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( A129LeaveRequestStartDate)), (short)(DateTimeUtil.Month( A129LeaveRequestStartDate)), (short)(DateTimeUtil.Day( A129LeaveRequestStartDate)), 0, 0, 0);
            AV11event.gxTpr_Endtime = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( A130LeaveRequestEndDate)), (short)(DateTimeUtil.Month( A130LeaveRequestEndDate)), (short)(DateTimeUtil.Day( A130LeaveRequestEndDate)), 23, 59, 59);
            AV12events.gxTpr_Items.Add(AV11event, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
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
         AV12events = new SdtSchedulerEvents(context);
         AV26Httprequest = new GxHttpRequest( context);
         AV28CompanyLocationIdValue = "";
         AV27Session = context.GetSession();
         P007K2_A157CompanyLocationId = new long[1] ;
         P007K2_A100CompanyId = new long[1] ;
         P007K3_A157CompanyLocationId = new long[1] ;
         P007K3_A100CompanyId = new long[1] ;
         P007K3_A139HolidayIsActive = new bool[] {false} ;
         P007K3_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P007K3_A113HolidayId = new long[1] ;
         P007K3_A158CompanyLocationName = new string[] {""} ;
         P007K3_A114HolidayName = new string[] {""} ;
         A115HolidayStartDate = DateTime.MinValue;
         A158CompanyLocationName = "";
         A114HolidayName = "";
         AV19SpecialDay = new SdtSchedulerEvents_Day(context);
         AV11event = new SdtSchedulerEvents_event(context);
         A132LeaveRequestStatus = "";
         P007K4_A124LeaveTypeId = new long[1] ;
         P007K4_A106EmployeeId = new long[1] ;
         P007K4_A132LeaveRequestStatus = new string[] {""} ;
         P007K4_A100CompanyId = new long[1] ;
         P007K4_A127LeaveRequestId = new long[1] ;
         P007K4_A108EmployeeLastName = new string[] {""} ;
         P007K4_A107EmployeeFirstName = new string[] {""} ;
         P007K4_A125LeaveTypeName = new string[] {""} ;
         P007K4_A133LeaveRequestDescription = new string[] {""} ;
         P007K4_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P007K4_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         A108EmployeeLastName = "";
         A107EmployeeFirstName = "";
         A125LeaveTypeName = "";
         A133LeaveRequestDescription = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         GXt_dtime2 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getleaveevents__default(),
            new Object[][] {
                new Object[] {
               P007K2_A157CompanyLocationId, P007K2_A100CompanyId
               }
               , new Object[] {
               P007K3_A157CompanyLocationId, P007K3_A100CompanyId, P007K3_A139HolidayIsActive, P007K3_A115HolidayStartDate, P007K3_A113HolidayId, P007K3_A158CompanyLocationName, P007K3_A114HolidayName
               }
               , new Object[] {
               P007K4_A124LeaveTypeId, P007K4_A106EmployeeId, P007K4_A132LeaveRequestStatus, P007K4_A100CompanyId, P007K4_A127LeaveRequestId, P007K4_A108EmployeeLastName, P007K4_A107EmployeeFirstName, P007K4_A125LeaveTypeName, P007K4_A133LeaveRequestDescription, P007K4_A129LeaveRequestStartDate,
               P007K4_A130LeaveRequestEndDate
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV20CompanyId ;
      private long GXt_int1 ;
      private long AV29CompanyLocationId ;
      private long A157CompanyLocationId ;
      private long A100CompanyId ;
      private long A113HolidayId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long A127LeaveRequestId ;
      private string AV28CompanyLocationIdValue ;
      private string A158CompanyLocationName ;
      private string A114HolidayName ;
      private string A132LeaveRequestStatus ;
      private string A108EmployeeLastName ;
      private string A107EmployeeFirstName ;
      private string A125LeaveTypeName ;
      private DateTime GXt_dtime2 ;
      private DateTime AV8dateFrom ;
      private DateTime AV9dateTo ;
      private DateTime A115HolidayStartDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool A139HolidayIsActive ;
      private string A133LeaveRequestDescription ;
      private IGxSession AV27Session ;
      private GxHttpRequest AV26Httprequest ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSchedulerEvents AV12events ;
      private IDataStoreProvider pr_default ;
      private long[] P007K2_A157CompanyLocationId ;
      private long[] P007K2_A100CompanyId ;
      private long[] P007K3_A157CompanyLocationId ;
      private long[] P007K3_A100CompanyId ;
      private bool[] P007K3_A139HolidayIsActive ;
      private DateTime[] P007K3_A115HolidayStartDate ;
      private long[] P007K3_A113HolidayId ;
      private string[] P007K3_A158CompanyLocationName ;
      private string[] P007K3_A114HolidayName ;
      private SdtSchedulerEvents_Day AV19SpecialDay ;
      private SdtSchedulerEvents_event AV11event ;
      private long[] P007K4_A124LeaveTypeId ;
      private long[] P007K4_A106EmployeeId ;
      private string[] P007K4_A132LeaveRequestStatus ;
      private long[] P007K4_A100CompanyId ;
      private long[] P007K4_A127LeaveRequestId ;
      private string[] P007K4_A108EmployeeLastName ;
      private string[] P007K4_A107EmployeeFirstName ;
      private string[] P007K4_A125LeaveTypeName ;
      private string[] P007K4_A133LeaveRequestDescription ;
      private DateTime[] P007K4_A129LeaveRequestStartDate ;
      private DateTime[] P007K4_A130LeaveRequestEndDate ;
      private SdtSchedulerEvents aP2_events ;
   }

   public class getleaveevents__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007K2( IGxContext context ,
                                             long AV29CompanyLocationId ,
                                             long A157CompanyLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT CompanyLocationId, CompanyId FROM Company";
         if ( ! (0==AV29CompanyLocationId) )
         {
            AddWhere(sWhereString, "(CompanyLocationId = :AV29CompanyLocationId)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CompanyId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P007K4( IGxContext context ,
                                             long AV20CompanyId ,
                                             long A100CompanyId ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[1];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestStatus, T2.CompanyId, T1.LeaveRequestId, T3.EmployeeLastName, T3.EmployeeFirstName, T2.LeaveTypeName, T1.LeaveRequestDescription, T1.LeaveRequestStartDate, T1.LeaveRequestEndDate FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved'))");
         if ( ! (0==AV20CompanyId) )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV20CompanyId)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestId";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P007K2(context, (long)dynConstraints[0] , (long)dynConstraints[1] );
               case 2 :
                     return conditional_P007K4(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007K3;
          prmP007K3 = new Object[] {
          new ParDef("AV20CompanyId",GXType.Int64,10,0)
          };
          Object[] prmP007K2;
          prmP007K2 = new Object[] {
          new ParDef("AV29CompanyLocationId",GXType.Int64,10,0)
          };
          Object[] prmP007K4;
          prmP007K4 = new Object[] {
          new ParDef("AV20CompanyId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007K2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007K3", "SELECT T2.CompanyLocationId, T1.CompanyId, T1.HolidayIsActive, T1.HolidayStartDate, T1.HolidayId, T3.CompanyLocationName, T1.HolidayName FROM ((Holiday T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) INNER JOIN CompanyLocation T3 ON T3.CompanyLocationId = T2.CompanyLocationId) WHERE (T1.CompanyId = :AV20CompanyId) AND (T1.HolidayIsActive = TRUE) ORDER BY T1.CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007K3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007K4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007K4,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                return;
       }
    }

 }

}
