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
   public class adailyreminderua : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public adailyreminderua( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public adailyreminderua( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV17CurrentHour = (short)(DateTimeUtil.Hour( DateTimeUtil.Now( context)));
         AV21httpresponse.AddString("SomeDate: "+context.localUtil.DToC( AV22SomeDate, 2, "/")+"("+DateTimeUtil.CDow( AV22SomeDate, "eng")+")"+StringUtil.NewLine( ));
         AV21httpresponse.AddString("Today: "+context.localUtil.DToC( Gx_date, 2, "/")+"("+DateTimeUtil.CDow( Gx_date, "eng")+")"+StringUtil.NewLine( ));
         AV21httpresponse.AddString("Current Hour: "+StringUtil.Str( (decimal)(AV17CurrentHour), 4, 0)+StringUtil.NewLine( ));
         AV18HasToLogOnLeave = false;
         if ( AV17CurrentHour >= 17 )
         {
            AV15CheckDate = Gx_date;
         }
         else
         {
            AV16DayOfWeek = DateTimeUtil.Dow( Gx_date);
            AV21httpresponse.AddString("Day of Week: "+StringUtil.Str( (decimal)(AV16DayOfWeek), 4, 0)+StringUtil.NewLine( ));
            if ( AV16DayOfWeek == 7 )
            {
               AV15CheckDate = DateTimeUtil.DAdd( Gx_date, (-1));
            }
            else
            {
               if ( AV16DayOfWeek == 2 )
               {
                  AV15CheckDate = DateTimeUtil.DAdd( Gx_date, (-3));
               }
               else
               {
                  AV15CheckDate = DateTimeUtil.DAdd( Gx_date, (-1));
               }
            }
         }
         AV21httpresponse.AddString("Check Date: "+context.localUtil.DToC( AV15CheckDate, 2, "/")+" ("+DateTimeUtil.CDow( AV15CheckDate, "eng")+")"+StringUtil.NewLine( ));
         /* Using cursor P009O2 */
         pr_default.execute(0, new Object[] {AV15CheckDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P009O2_A100CompanyId[0];
            A157CompanyLocationId = P009O2_A157CompanyLocationId[0];
            A159CompanyLocationCode = P009O2_A159CompanyLocationCode[0];
            A115HolidayStartDate = P009O2_A115HolidayStartDate[0];
            A114HolidayName = P009O2_A114HolidayName[0];
            A113HolidayId = P009O2_A113HolidayId[0];
            A157CompanyLocationId = P009O2_A157CompanyLocationId[0];
            A159CompanyLocationCode = P009O2_A159CompanyLocationCode[0];
            AV21httpresponse.AddString("It's a holiday: "+StringUtil.Trim( A114HolidayName));
            context.nUserReturn = 1;
            if ( context.WillRedirect( ) )
            {
               context.Redirect( context.wjLoc );
               context.wjLoc = "";
            }
            pr_default.close(0);
            cleanup();
            if (true) return;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P009O3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A100CompanyId = P009O3_A100CompanyId[0];
            A157CompanyLocationId = P009O3_A157CompanyLocationId[0];
            A106EmployeeId = P009O3_A106EmployeeId[0];
            A159CompanyLocationCode = P009O3_A159CompanyLocationCode[0];
            A112EmployeeIsActive = P009O3_A112EmployeeIsActive[0];
            A148EmployeeName = P009O3_A148EmployeeName[0];
            A107EmployeeFirstName = P009O3_A107EmployeeFirstName[0];
            A109EmployeeEmail = P009O3_A109EmployeeEmail[0];
            A157CompanyLocationId = P009O3_A157CompanyLocationId[0];
            A159CompanyLocationCode = P009O3_A159CompanyLocationCode[0];
            AV20Data += "Employee Name: " + StringUtil.Trim( A148EmployeeName) + StringUtil.NewLine( );
            AV27GXLvl48 = 0;
            /* Using cursor P009O4 */
            pr_default.execute(2, new Object[] {A106EmployeeId, AV15CheckDate});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A124LeaveTypeId = P009O4_A124LeaveTypeId[0];
               A130LeaveRequestEndDate = P009O4_A130LeaveRequestEndDate[0];
               A129LeaveRequestStartDate = P009O4_A129LeaveRequestStartDate[0];
               A132LeaveRequestStatus = P009O4_A132LeaveRequestStatus[0];
               A145LeaveTypeLoggingWorkHours = P009O4_A145LeaveTypeLoggingWorkHours[0];
               A171LeaveRequestHalfDay = P009O4_A171LeaveRequestHalfDay[0];
               n171LeaveRequestHalfDay = P009O4_n171LeaveRequestHalfDay[0];
               A127LeaveRequestId = P009O4_A127LeaveRequestId[0];
               A145LeaveTypeLoggingWorkHours = P009O4_A145LeaveTypeLoggingWorkHours[0];
               AV27GXLvl48 = 1;
               AV19HasNoLeave = false;
               AV18HasToLogOnLeave = false;
               if ( StringUtil.StrCmp(A145LeaveTypeLoggingWorkHours, "Yes") == 0 )
               {
                  AV18HasToLogOnLeave = true;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               else if ( StringUtil.StrCmp(A171LeaveRequestHalfDay, "Morning") == 0 )
               {
                  AV18HasToLogOnLeave = true;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               else if ( StringUtil.StrCmp(A171LeaveRequestHalfDay, "Afternoon") == 0 )
               {
                  AV18HasToLogOnLeave = true;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               else
               {
                  AV18HasToLogOnLeave = false;
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( AV27GXLvl48 == 0 )
            {
               AV19HasNoLeave = true;
            }
            AV28GXLvl74 = 0;
            /* Using cursor P009O5 */
            pr_default.execute(3, new Object[] {A106EmployeeId, AV15CheckDate});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A119WorkHourLogDate = P009O5_A119WorkHourLogDate[0];
               A118WorkHourLogId = P009O5_A118WorkHourLogId[0];
               AV28GXLvl74 = 1;
               AV14HasLoggedHours = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( AV28GXLvl74 == 0 )
            {
               AV14HasLoggedHours = false;
            }
            if ( ! AV14HasLoggedHours )
            {
               if ( ( AV19HasNoLeave ) || ( AV18HasToLogOnLeave ) )
               {
                  AV10name = A107EmployeeFirstName;
                  AV9email = A109EmployeeEmail;
                  AV12Subject = "Daily Time Tracker Reminder";
                  AV8Body = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#333;color:#fff;text-align:center;padding:20px 0\"><h2>Time Tracker Reminder</h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear " + StringUtil.Trim( AV10name) + ",</p><p>Check your Time Tracker hours for today and fill them.</p><p>We think you forgot to fill them in.</p><a href=\" " + AV13HttpRequest.BaseURL + "logworkhours.aspx\" style=\"display: block; padding: 10px 20px; width: 150px;  margin: 20px auto; background-color: #FFCC00; text-align: center; border-radius: 8px; color: white; font-weight: bold; line-height: 30px; text-decoration: none;\">Fill now</a></div></div>";
                  new sendemail(context ).execute(  AV9email, ref  AV12Subject, ref  AV8Body) ;
                  new sdsendpushnotifications(context ).execute(  "Time Tracker Reminder",  "Check your time tracker hours, you may have missed a log.",  A106EmployeeId) ;
               }
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV21httpresponse.AddString(AV20Data);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV21httpresponse = new GxHttpResponse( context);
         AV22SomeDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         AV15CheckDate = DateTime.MinValue;
         P009O2_A100CompanyId = new long[1] ;
         P009O2_A157CompanyLocationId = new long[1] ;
         P009O2_A159CompanyLocationCode = new string[] {""} ;
         P009O2_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P009O2_A114HolidayName = new string[] {""} ;
         P009O2_A113HolidayId = new long[1] ;
         A159CompanyLocationCode = "";
         A115HolidayStartDate = DateTime.MinValue;
         A114HolidayName = "";
         P009O3_A100CompanyId = new long[1] ;
         P009O3_A157CompanyLocationId = new long[1] ;
         P009O3_A106EmployeeId = new long[1] ;
         P009O3_A159CompanyLocationCode = new string[] {""} ;
         P009O3_A112EmployeeIsActive = new bool[] {false} ;
         P009O3_A148EmployeeName = new string[] {""} ;
         P009O3_A107EmployeeFirstName = new string[] {""} ;
         P009O3_A109EmployeeEmail = new string[] {""} ;
         A148EmployeeName = "";
         A107EmployeeFirstName = "";
         A109EmployeeEmail = "";
         AV20Data = "";
         P009O4_A124LeaveTypeId = new long[1] ;
         P009O4_A106EmployeeId = new long[1] ;
         P009O4_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P009O4_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P009O4_A132LeaveRequestStatus = new string[] {""} ;
         P009O4_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         P009O4_A171LeaveRequestHalfDay = new string[] {""} ;
         P009O4_n171LeaveRequestHalfDay = new bool[] {false} ;
         P009O4_A127LeaveRequestId = new long[1] ;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         A145LeaveTypeLoggingWorkHours = "";
         A171LeaveRequestHalfDay = "";
         P009O5_A106EmployeeId = new long[1] ;
         P009O5_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P009O5_A118WorkHourLogId = new long[1] ;
         A119WorkHourLogDate = DateTime.MinValue;
         AV10name = "";
         AV9email = "";
         AV12Subject = "";
         AV8Body = "";
         AV13HttpRequest = new GxHttpRequest( context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.adailyreminderua__default(),
            new Object[][] {
                new Object[] {
               P009O2_A100CompanyId, P009O2_A157CompanyLocationId, P009O2_A159CompanyLocationCode, P009O2_A115HolidayStartDate, P009O2_A114HolidayName, P009O2_A113HolidayId
               }
               , new Object[] {
               P009O3_A100CompanyId, P009O3_A157CompanyLocationId, P009O3_A106EmployeeId, P009O3_A159CompanyLocationCode, P009O3_A112EmployeeIsActive, P009O3_A148EmployeeName, P009O3_A107EmployeeFirstName, P009O3_A109EmployeeEmail
               }
               , new Object[] {
               P009O4_A124LeaveTypeId, P009O4_A106EmployeeId, P009O4_A130LeaveRequestEndDate, P009O4_A129LeaveRequestStartDate, P009O4_A132LeaveRequestStatus, P009O4_A145LeaveTypeLoggingWorkHours, P009O4_A171LeaveRequestHalfDay, P009O4_n171LeaveRequestHalfDay, P009O4_A127LeaveRequestId
               }
               , new Object[] {
               P009O5_A106EmployeeId, P009O5_A119WorkHourLogDate, P009O5_A118WorkHourLogId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV17CurrentHour ;
      private short AV16DayOfWeek ;
      private short AV27GXLvl48 ;
      private short AV28GXLvl74 ;
      private long A100CompanyId ;
      private long A157CompanyLocationId ;
      private long A113HolidayId ;
      private long A106EmployeeId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private long A118WorkHourLogId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A159CompanyLocationCode ;
      private string A114HolidayName ;
      private string A148EmployeeName ;
      private string A107EmployeeFirstName ;
      private string A132LeaveRequestStatus ;
      private string A145LeaveTypeLoggingWorkHours ;
      private string A171LeaveRequestHalfDay ;
      private string AV10name ;
      private DateTime AV22SomeDate ;
      private DateTime Gx_date ;
      private DateTime AV15CheckDate ;
      private DateTime A115HolidayStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A119WorkHourLogDate ;
      private bool entryPointCalled ;
      private bool AV18HasToLogOnLeave ;
      private bool A112EmployeeIsActive ;
      private bool n171LeaveRequestHalfDay ;
      private bool AV19HasNoLeave ;
      private bool AV14HasLoggedHours ;
      private string AV20Data ;
      private string AV8Body ;
      private string A109EmployeeEmail ;
      private string AV9email ;
      private string AV12Subject ;
      private GxHttpRequest AV13HttpRequest ;
      private GxHttpResponse AV21httpresponse ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P009O2_A100CompanyId ;
      private long[] P009O2_A157CompanyLocationId ;
      private string[] P009O2_A159CompanyLocationCode ;
      private DateTime[] P009O2_A115HolidayStartDate ;
      private string[] P009O2_A114HolidayName ;
      private long[] P009O2_A113HolidayId ;
      private long[] P009O3_A100CompanyId ;
      private long[] P009O3_A157CompanyLocationId ;
      private long[] P009O3_A106EmployeeId ;
      private string[] P009O3_A159CompanyLocationCode ;
      private bool[] P009O3_A112EmployeeIsActive ;
      private string[] P009O3_A148EmployeeName ;
      private string[] P009O3_A107EmployeeFirstName ;
      private string[] P009O3_A109EmployeeEmail ;
      private long[] P009O4_A124LeaveTypeId ;
      private long[] P009O4_A106EmployeeId ;
      private DateTime[] P009O4_A130LeaveRequestEndDate ;
      private DateTime[] P009O4_A129LeaveRequestStartDate ;
      private string[] P009O4_A132LeaveRequestStatus ;
      private string[] P009O4_A145LeaveTypeLoggingWorkHours ;
      private string[] P009O4_A171LeaveRequestHalfDay ;
      private bool[] P009O4_n171LeaveRequestHalfDay ;
      private long[] P009O4_A127LeaveRequestId ;
      private long[] P009O5_A106EmployeeId ;
      private DateTime[] P009O5_A119WorkHourLogDate ;
      private long[] P009O5_A118WorkHourLogId ;
   }

   public class adailyreminderua__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009O2;
          prmP009O2 = new Object[] {
          new ParDef("AV15CheckDate",GXType.Date,8,0)
          };
          Object[] prmP009O3;
          prmP009O3 = new Object[] {
          };
          Object[] prmP009O4;
          prmP009O4 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV15CheckDate",GXType.Date,8,0)
          };
          Object[] prmP009O5;
          prmP009O5 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV15CheckDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009O2", "SELECT T1.CompanyId, T2.CompanyLocationId, T3.CompanyLocationCode, T1.HolidayStartDate, T1.HolidayName, T1.HolidayId FROM ((Holiday T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) INNER JOIN CompanyLocation T3 ON T3.CompanyLocationId = T2.CompanyLocationId) WHERE (T1.HolidayStartDate = :AV15CheckDate) AND (T3.CompanyLocationCode = ( 'ukrainian')) ORDER BY T1.HolidayId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009O2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009O3", "SELECT T1.CompanyId, T2.CompanyLocationId, T1.EmployeeId, T3.CompanyLocationCode, T1.EmployeeIsActive, T1.EmployeeName, T1.EmployeeFirstName, T1.EmployeeEmail FROM ((Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) INNER JOIN CompanyLocation T3 ON T3.CompanyLocationId = T2.CompanyLocationId) WHERE (T1.EmployeeIsActive = TRUE) AND (T3.CompanyLocationCode = ( 'ukrainian')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009O3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009O4", "SELECT T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestStatus, T2.LeaveTypeLoggingWorkHours, T1.LeaveRequestHalfDay, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :EmployeeId) AND (T1.LeaveRequestStartDate <= :AV15CheckDate) AND (T1.LeaveRequestEndDate >= :AV15CheckDate) AND (T1.LeaveRequestStatus = ( 'Approved')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009O4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009O5", "SELECT EmployeeId, WorkHourLogDate, WorkHourLogId FROM WorkHourLog WHERE (EmployeeId = :EmployeeId) AND (WorkHourLogDate = :AV15CheckDate) ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009O5,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
