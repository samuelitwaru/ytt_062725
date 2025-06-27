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
using GeneXus.Mail;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class adailyremindertomanagerlk : GXWebProcedure
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

      public adailyremindertomanagerlk( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public adailyremindertomanagerlk( IGxContext context )
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
         AV26DayOfWeek = DateTimeUtil.Dow( Gx_date);
         if ( AV26DayOfWeek == 7 )
         {
            AV23CheckDate = DateTimeUtil.DAdd( Gx_date, (-1));
         }
         else
         {
            if ( AV26DayOfWeek == 1 )
            {
               AV23CheckDate = DateTimeUtil.DAdd( Gx_date, (-2));
            }
            else
            {
               AV23CheckDate = DateTimeUtil.DAdd( Gx_date, (-1));
            }
         }
         /* Using cursor P00A92 */
         pr_default.execute(0, new Object[] {AV23CheckDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00A92_A100CompanyId[0];
            A157CompanyLocationId = P00A92_A157CompanyLocationId[0];
            A159CompanyLocationCode = P00A92_A159CompanyLocationCode[0];
            A115HolidayStartDate = P00A92_A115HolidayStartDate[0];
            A113HolidayId = P00A92_A113HolidayId[0];
            A157CompanyLocationId = P00A92_A157CompanyLocationId[0];
            A159CompanyLocationCode = P00A92_A159CompanyLocationCode[0];
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
         AV27AffectedEmployees = new GXBaseCollection<SdtEmployeeListSDT_EmployeeListSDTItem>( context, "EmployeeListSDTItem", "YTT_version4");
         /* Using cursor P00A93 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A100CompanyId = P00A93_A100CompanyId[0];
            A157CompanyLocationId = P00A93_A157CompanyLocationId[0];
            A106EmployeeId = P00A93_A106EmployeeId[0];
            A159CompanyLocationCode = P00A93_A159CompanyLocationCode[0];
            A112EmployeeIsActive = P00A93_A112EmployeeIsActive[0];
            A107EmployeeFirstName = P00A93_A107EmployeeFirstName[0];
            A108EmployeeLastName = P00A93_A108EmployeeLastName[0];
            A157CompanyLocationId = P00A93_A157CompanyLocationId[0];
            A159CompanyLocationCode = P00A93_A159CompanyLocationCode[0];
            AV40GXLvl28 = 0;
            /* Using cursor P00A94 */
            pr_default.execute(2, new Object[] {A106EmployeeId, AV23CheckDate});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A124LeaveTypeId = P00A94_A124LeaveTypeId[0];
               A130LeaveRequestEndDate = P00A94_A130LeaveRequestEndDate[0];
               A129LeaveRequestStartDate = P00A94_A129LeaveRequestStartDate[0];
               A132LeaveRequestStatus = P00A94_A132LeaveRequestStatus[0];
               A145LeaveTypeLoggingWorkHours = P00A94_A145LeaveTypeLoggingWorkHours[0];
               A171LeaveRequestHalfDay = P00A94_A171LeaveRequestHalfDay[0];
               n171LeaveRequestHalfDay = P00A94_n171LeaveRequestHalfDay[0];
               A127LeaveRequestId = P00A94_A127LeaveRequestId[0];
               A145LeaveTypeLoggingWorkHours = P00A94_A145LeaveTypeLoggingWorkHours[0];
               AV40GXLvl28 = 1;
               AV34HasNoLeave = false;
               AV35HasToLogOnLeave = false;
               if ( StringUtil.StrCmp(A145LeaveTypeLoggingWorkHours, "Yes") == 0 )
               {
                  AV35HasToLogOnLeave = true;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               else if ( StringUtil.StrCmp(A171LeaveRequestHalfDay, "Morning") == 0 )
               {
                  AV35HasToLogOnLeave = true;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               else if ( StringUtil.StrCmp(A171LeaveRequestHalfDay, "Afternoon") == 0 )
               {
                  AV35HasToLogOnLeave = true;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               else
               {
                  AV35HasToLogOnLeave = false;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( AV40GXLvl28 == 0 )
            {
               AV34HasNoLeave = true;
            }
            AV41GXLvl58 = 0;
            /* Using cursor P00A95 */
            pr_default.execute(3, new Object[] {A106EmployeeId, AV23CheckDate});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A119WorkHourLogDate = P00A95_A119WorkHourLogDate[0];
               A118WorkHourLogId = P00A95_A118WorkHourLogId[0];
               AV41GXLvl58 = 1;
               AV36HasLoggedHours = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( AV41GXLvl58 == 0 )
            {
               AV36HasLoggedHours = false;
            }
            if ( ! AV36HasLoggedHours )
            {
               if ( ( AV34HasNoLeave ) || ( AV35HasToLogOnLeave ) )
               {
                  AV24AffectedEmployee = new SdtEmployeeListSDT_EmployeeListSDTItem(context);
                  AV24AffectedEmployee.gxTpr_Firstname = A107EmployeeFirstName;
                  AV24AffectedEmployee.gxTpr_Lastname = A108EmployeeLastName;
                  AV27AffectedEmployees.Add(AV24AffectedEmployee, 0);
               }
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P00A96 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A100CompanyId = P00A96_A100CompanyId[0];
            A157CompanyLocationId = P00A96_A157CompanyLocationId[0];
            A110EmployeeIsManager = P00A96_A110EmployeeIsManager[0];
            A159CompanyLocationCode = P00A96_A159CompanyLocationCode[0];
            A112EmployeeIsActive = P00A96_A112EmployeeIsActive[0];
            A107EmployeeFirstName = P00A96_A107EmployeeFirstName[0];
            A109EmployeeEmail = P00A96_A109EmployeeEmail[0];
            A106EmployeeId = P00A96_A106EmployeeId[0];
            A157CompanyLocationId = P00A96_A157CompanyLocationId[0];
            A159CompanyLocationCode = P00A96_A159CompanyLocationCode[0];
            AV14name = A107EmployeeFirstName;
            AV10email = A109EmployeeEmail;
            AV17Subject = "Time Tracker Reminder";
            AV29BodyStart = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\">" + "<div style=\"background-color:#333;color:#fff;text-align:center;padding:20px 0\"><h2>Time Tracker Reminder</h2></div>" + "<div style=\"padding:20px;line-height:1.5\">" + "<p>Dear " + StringUtil.Trim( AV14name) + ",</p>" + "<p>This is a reminder that some employees did not fill in their logs for yesterday. Please ensure all their working hours are accurately recorded.</p>" + "<p>The affected employees are:</p>" + "<ol style=\"list-style-type: decimal;\">";
            AV30BodyEnd = "</ol>" + "<p>We appreciate your attention to this matter.</p>" + "<a href=\"" + AV22HttpRequest.BaseURL + "login.aspx\" style=\"display: block; padding: 10px 20px; width: 150px; margin: 20px auto; background-color: #FFCC00; text-align: center; border-radius: 8px; color: white; font-weight: bold; line-height: 30px; text-decoration: none;\">View Details</a>" + "</div></div>";
            AV8Body = AV29BodyStart;
            AV43GXV1 = 1;
            while ( AV43GXV1 <= AV27AffectedEmployees.Count )
            {
               AV32AffectedEmployeeItem = ((SdtEmployeeListSDT_EmployeeListSDTItem)AV27AffectedEmployees.Item(AV43GXV1));
               AV8Body += "<li>" + AV32AffectedEmployeeItem.gxTpr_Firstname + " " + AV32AffectedEmployeeItem.gxTpr_Lastname + "</li>";
               AV43GXV1 = (int)(AV43GXV1+1);
            }
            AV8Body += AV30BodyEnd;
            new sendemail(context ).execute(  AV10email, ref  AV17Subject, ref  AV8Body) ;
            pr_default.readNext(4);
         }
         pr_default.close(4);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
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
         Gx_date = DateTime.MinValue;
         AV23CheckDate = DateTime.MinValue;
         P00A92_A100CompanyId = new long[1] ;
         P00A92_A157CompanyLocationId = new long[1] ;
         P00A92_A159CompanyLocationCode = new string[] {""} ;
         P00A92_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P00A92_A113HolidayId = new long[1] ;
         A159CompanyLocationCode = "";
         A115HolidayStartDate = DateTime.MinValue;
         AV27AffectedEmployees = new GXBaseCollection<SdtEmployeeListSDT_EmployeeListSDTItem>( context, "EmployeeListSDTItem", "YTT_version4");
         P00A93_A100CompanyId = new long[1] ;
         P00A93_A157CompanyLocationId = new long[1] ;
         P00A93_A106EmployeeId = new long[1] ;
         P00A93_A159CompanyLocationCode = new string[] {""} ;
         P00A93_A112EmployeeIsActive = new bool[] {false} ;
         P00A93_A107EmployeeFirstName = new string[] {""} ;
         P00A93_A108EmployeeLastName = new string[] {""} ;
         A107EmployeeFirstName = "";
         A108EmployeeLastName = "";
         P00A94_A124LeaveTypeId = new long[1] ;
         P00A94_A106EmployeeId = new long[1] ;
         P00A94_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00A94_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00A94_A132LeaveRequestStatus = new string[] {""} ;
         P00A94_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         P00A94_A171LeaveRequestHalfDay = new string[] {""} ;
         P00A94_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00A94_A127LeaveRequestId = new long[1] ;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         A145LeaveTypeLoggingWorkHours = "";
         A171LeaveRequestHalfDay = "";
         P00A95_A106EmployeeId = new long[1] ;
         P00A95_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00A95_A118WorkHourLogId = new long[1] ;
         A119WorkHourLogDate = DateTime.MinValue;
         AV24AffectedEmployee = new SdtEmployeeListSDT_EmployeeListSDTItem(context);
         P00A96_A100CompanyId = new long[1] ;
         P00A96_A157CompanyLocationId = new long[1] ;
         P00A96_A110EmployeeIsManager = new bool[] {false} ;
         P00A96_A159CompanyLocationCode = new string[] {""} ;
         P00A96_A112EmployeeIsActive = new bool[] {false} ;
         P00A96_A107EmployeeFirstName = new string[] {""} ;
         P00A96_A109EmployeeEmail = new string[] {""} ;
         P00A96_A106EmployeeId = new long[1] ;
         A109EmployeeEmail = "";
         AV14name = "";
         AV10email = "";
         AV17Subject = "";
         AV29BodyStart = "";
         AV30BodyEnd = "";
         AV22HttpRequest = new GxHttpRequest( context);
         AV8Body = "";
         AV32AffectedEmployeeItem = new SdtEmployeeListSDT_EmployeeListSDTItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.adailyremindertomanagerlk__default(),
            new Object[][] {
                new Object[] {
               P00A92_A100CompanyId, P00A92_A157CompanyLocationId, P00A92_A159CompanyLocationCode, P00A92_A115HolidayStartDate, P00A92_A113HolidayId
               }
               , new Object[] {
               P00A93_A100CompanyId, P00A93_A157CompanyLocationId, P00A93_A106EmployeeId, P00A93_A159CompanyLocationCode, P00A93_A112EmployeeIsActive, P00A93_A107EmployeeFirstName, P00A93_A108EmployeeLastName
               }
               , new Object[] {
               P00A94_A124LeaveTypeId, P00A94_A106EmployeeId, P00A94_A130LeaveRequestEndDate, P00A94_A129LeaveRequestStartDate, P00A94_A132LeaveRequestStatus, P00A94_A145LeaveTypeLoggingWorkHours, P00A94_A171LeaveRequestHalfDay, P00A94_n171LeaveRequestHalfDay, P00A94_A127LeaveRequestId
               }
               , new Object[] {
               P00A95_A106EmployeeId, P00A95_A119WorkHourLogDate, P00A95_A118WorkHourLogId
               }
               , new Object[] {
               P00A96_A100CompanyId, P00A96_A157CompanyLocationId, P00A96_A110EmployeeIsManager, P00A96_A159CompanyLocationCode, P00A96_A112EmployeeIsActive, P00A96_A107EmployeeFirstName, P00A96_A109EmployeeEmail, P00A96_A106EmployeeId
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
      private short AV26DayOfWeek ;
      private short AV40GXLvl28 ;
      private short AV41GXLvl58 ;
      private int AV43GXV1 ;
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
      private string A107EmployeeFirstName ;
      private string A108EmployeeLastName ;
      private string A132LeaveRequestStatus ;
      private string A145LeaveTypeLoggingWorkHours ;
      private string A171LeaveRequestHalfDay ;
      private string AV14name ;
      private DateTime Gx_date ;
      private DateTime AV23CheckDate ;
      private DateTime A115HolidayStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A119WorkHourLogDate ;
      private bool entryPointCalled ;
      private bool A112EmployeeIsActive ;
      private bool n171LeaveRequestHalfDay ;
      private bool AV34HasNoLeave ;
      private bool AV35HasToLogOnLeave ;
      private bool AV36HasLoggedHours ;
      private bool A110EmployeeIsManager ;
      private string AV29BodyStart ;
      private string AV30BodyEnd ;
      private string AV8Body ;
      private string A109EmployeeEmail ;
      private string AV10email ;
      private string AV17Subject ;
      private GxHttpRequest AV22HttpRequest ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00A92_A100CompanyId ;
      private long[] P00A92_A157CompanyLocationId ;
      private string[] P00A92_A159CompanyLocationCode ;
      private DateTime[] P00A92_A115HolidayStartDate ;
      private long[] P00A92_A113HolidayId ;
      private GXBaseCollection<SdtEmployeeListSDT_EmployeeListSDTItem> AV27AffectedEmployees ;
      private long[] P00A93_A100CompanyId ;
      private long[] P00A93_A157CompanyLocationId ;
      private long[] P00A93_A106EmployeeId ;
      private string[] P00A93_A159CompanyLocationCode ;
      private bool[] P00A93_A112EmployeeIsActive ;
      private string[] P00A93_A107EmployeeFirstName ;
      private string[] P00A93_A108EmployeeLastName ;
      private long[] P00A94_A124LeaveTypeId ;
      private long[] P00A94_A106EmployeeId ;
      private DateTime[] P00A94_A130LeaveRequestEndDate ;
      private DateTime[] P00A94_A129LeaveRequestStartDate ;
      private string[] P00A94_A132LeaveRequestStatus ;
      private string[] P00A94_A145LeaveTypeLoggingWorkHours ;
      private string[] P00A94_A171LeaveRequestHalfDay ;
      private bool[] P00A94_n171LeaveRequestHalfDay ;
      private long[] P00A94_A127LeaveRequestId ;
      private long[] P00A95_A106EmployeeId ;
      private DateTime[] P00A95_A119WorkHourLogDate ;
      private long[] P00A95_A118WorkHourLogId ;
      private SdtEmployeeListSDT_EmployeeListSDTItem AV24AffectedEmployee ;
      private long[] P00A96_A100CompanyId ;
      private long[] P00A96_A157CompanyLocationId ;
      private bool[] P00A96_A110EmployeeIsManager ;
      private string[] P00A96_A159CompanyLocationCode ;
      private bool[] P00A96_A112EmployeeIsActive ;
      private string[] P00A96_A107EmployeeFirstName ;
      private string[] P00A96_A109EmployeeEmail ;
      private long[] P00A96_A106EmployeeId ;
      private SdtEmployeeListSDT_EmployeeListSDTItem AV32AffectedEmployeeItem ;
   }

   public class adailyremindertomanagerlk__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00A92;
          prmP00A92 = new Object[] {
          new ParDef("AV23CheckDate",GXType.Date,8,0)
          };
          Object[] prmP00A93;
          prmP00A93 = new Object[] {
          };
          Object[] prmP00A94;
          prmP00A94 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV23CheckDate",GXType.Date,8,0)
          };
          Object[] prmP00A95;
          prmP00A95 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV23CheckDate",GXType.Date,8,0)
          };
          Object[] prmP00A96;
          prmP00A96 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00A92", "SELECT T1.CompanyId, T2.CompanyLocationId, T3.CompanyLocationCode, T1.HolidayStartDate, T1.HolidayId FROM ((Holiday T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) INNER JOIN CompanyLocation T3 ON T3.CompanyLocationId = T2.CompanyLocationId) WHERE (T1.HolidayStartDate = :AV23CheckDate) AND (T3.CompanyLocationCode = ( 'lk')) ORDER BY T1.HolidayId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A92,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00A93", "SELECT T1.CompanyId, T2.CompanyLocationId, T1.EmployeeId, T3.CompanyLocationCode, T1.EmployeeIsActive, T1.EmployeeFirstName, T1.EmployeeLastName FROM ((Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) INNER JOIN CompanyLocation T3 ON T3.CompanyLocationId = T2.CompanyLocationId) WHERE (T1.EmployeeIsActive = TRUE) AND (T3.CompanyLocationCode = ( 'lk')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A93,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00A94", "SELECT T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestStatus, T2.LeaveTypeLoggingWorkHours, T1.LeaveRequestHalfDay, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :EmployeeId) AND (T1.LeaveRequestStartDate <= :AV23CheckDate) AND (T1.LeaveRequestEndDate >= :AV23CheckDate) AND (T1.LeaveRequestStatus = ( 'Approved')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A94,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00A95", "SELECT EmployeeId, WorkHourLogDate, WorkHourLogId FROM WorkHourLog WHERE (EmployeeId = :EmployeeId) AND (WorkHourLogDate = :AV23CheckDate) ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A95,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00A96", "SELECT T1.CompanyId, T2.CompanyLocationId, T1.EmployeeIsManager, T3.CompanyLocationCode, T1.EmployeeIsActive, T1.EmployeeFirstName, T1.EmployeeEmail, T1.EmployeeId FROM ((Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) INNER JOIN CompanyLocation T3 ON T3.CompanyLocationId = T2.CompanyLocationId) WHERE (T1.EmployeeIsActive = TRUE) AND (T3.CompanyLocationCode = ( 'lk')) AND (T1.EmployeeIsManager = TRUE) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A96,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
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
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
