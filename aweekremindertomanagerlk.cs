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
   public class aweekremindertomanagerlk : GXWebProcedure
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

      public aweekremindertomanagerlk( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aweekremindertomanagerlk( IGxContext context )
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
         AV18totalEmployees = 0;
         /* Using cursor P009S3 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A157CompanyLocationId = P009S3_A157CompanyLocationId[0];
            A100CompanyId = P009S3_A100CompanyId[0];
            A159CompanyLocationCode = P009S3_A159CompanyLocationCode[0];
            A40000GXC1 = P009S3_A40000GXC1[0];
            n40000GXC1 = P009S3_n40000GXC1[0];
            A159CompanyLocationCode = P009S3_A159CompanyLocationCode[0];
            A40000GXC1 = P009S3_A40000GXC1[0];
            n40000GXC1 = P009S3_n40000GXC1[0];
            AV19TotalHour = 0;
            AV20TotalMinute = 0;
            AV18totalEmployees = (short)(A40000GXC1);
            /* Using cursor P009S4 */
            pr_default.execute(1, new Object[] {A100CompanyId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A106EmployeeId = P009S4_A106EmployeeId[0];
               A112EmployeeIsActive = P009S4_A112EmployeeIsActive[0];
               A110EmployeeIsManager = P009S4_A110EmployeeIsManager[0];
               A107EmployeeFirstName = P009S4_A107EmployeeFirstName[0];
               A109EmployeeEmail = P009S4_A109EmployeeEmail[0];
               AV19TotalHour = 0;
               AV20TotalMinute = 0;
               /* Optimized group. */
               /* Using cursor P009S5 */
               pr_default.execute(2, new Object[] {A106EmployeeId, Gx_date});
               c121WorkHourLogHour = P009S5_A121WorkHourLogHour[0];
               c122WorkHourLogMinute = P009S5_A122WorkHourLogMinute[0];
               pr_default.close(2);
               AV19TotalHour = (short)(AV19TotalHour+c121WorkHourLogHour);
               AV20TotalMinute = (short)(AV20TotalMinute+c122WorkHourLogMinute);
               /* End optimized group. */
               AV13ModTotalMinute = (short)(((int)((AV20TotalMinute) % (60))));
               AV21TotalWeeklyDuration = (short)(NumberUtil.Trunc( AV20TotalMinute/ (decimal)(60), 0)+AV19TotalHour);
               if ( ( AV21TotalWeeklyDuration * AV18totalEmployees ) < ( 40 * AV18totalEmployees ) )
               {
                  if ( A110EmployeeIsManager )
                  {
                     AV14name = A107EmployeeFirstName;
                     AV10email = A109EmployeeEmail;
                     AV17Subject = "Time Tracker Reminder";
                     AV8Body = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#333;color:#fff;text-align:center;padding:20px 0\"><h2>Time Tracker Reminder</h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear Manager,</p><p>This is a reminder that some employees do not have sufficient work hour logs for this week. Please ensure all their working hours are accurately recorded.</p><p>We appreciate your attention to this matter.</p><a href=\"" + AV22HttpRequest.BaseURL + "login.aspx\" style=\"display: block; padding: 10px 20px; width: 150px;  margin: 20px auto; background-color: #FFCC00; text-align: center; border-radius: 8px; color: white; font-weight: bold; line-height: 30px; text-decoration: none;\">View Details</a></div></div>";
                     new sendemail(context ).execute(  AV10email, ref  AV17Subject, ref  AV8Body) ;
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         P009S3_A157CompanyLocationId = new long[1] ;
         P009S3_A100CompanyId = new long[1] ;
         P009S3_A159CompanyLocationCode = new string[] {""} ;
         P009S3_A40000GXC1 = new int[1] ;
         P009S3_n40000GXC1 = new bool[] {false} ;
         A159CompanyLocationCode = "";
         P009S4_A100CompanyId = new long[1] ;
         P009S4_A106EmployeeId = new long[1] ;
         P009S4_A112EmployeeIsActive = new bool[] {false} ;
         P009S4_A110EmployeeIsManager = new bool[] {false} ;
         P009S4_A107EmployeeFirstName = new string[] {""} ;
         P009S4_A109EmployeeEmail = new string[] {""} ;
         A107EmployeeFirstName = "";
         A109EmployeeEmail = "";
         Gx_date = DateTime.MinValue;
         P009S5_A121WorkHourLogHour = new short[1] ;
         P009S5_A122WorkHourLogMinute = new short[1] ;
         AV14name = "";
         AV10email = "";
         AV17Subject = "";
         AV8Body = "";
         AV22HttpRequest = new GxHttpRequest( context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aweekremindertomanagerlk__default(),
            new Object[][] {
                new Object[] {
               P009S3_A157CompanyLocationId, P009S3_A100CompanyId, P009S3_A159CompanyLocationCode, P009S3_A40000GXC1, P009S3_n40000GXC1
               }
               , new Object[] {
               P009S4_A100CompanyId, P009S4_A106EmployeeId, P009S4_A112EmployeeIsActive, P009S4_A110EmployeeIsManager, P009S4_A107EmployeeFirstName, P009S4_A109EmployeeEmail
               }
               , new Object[] {
               P009S5_A121WorkHourLogHour, P009S5_A122WorkHourLogMinute
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
      private short AV18totalEmployees ;
      private short AV19TotalHour ;
      private short AV20TotalMinute ;
      private short c121WorkHourLogHour ;
      private short c122WorkHourLogMinute ;
      private short AV13ModTotalMinute ;
      private short AV21TotalWeeklyDuration ;
      private int A40000GXC1 ;
      private long A157CompanyLocationId ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A159CompanyLocationCode ;
      private string A107EmployeeFirstName ;
      private string AV14name ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool n40000GXC1 ;
      private bool A112EmployeeIsActive ;
      private bool A110EmployeeIsManager ;
      private string AV8Body ;
      private string A109EmployeeEmail ;
      private string AV10email ;
      private string AV17Subject ;
      private GxHttpRequest AV22HttpRequest ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P009S3_A157CompanyLocationId ;
      private long[] P009S3_A100CompanyId ;
      private string[] P009S3_A159CompanyLocationCode ;
      private int[] P009S3_A40000GXC1 ;
      private bool[] P009S3_n40000GXC1 ;
      private long[] P009S4_A100CompanyId ;
      private long[] P009S4_A106EmployeeId ;
      private bool[] P009S4_A112EmployeeIsActive ;
      private bool[] P009S4_A110EmployeeIsManager ;
      private string[] P009S4_A107EmployeeFirstName ;
      private string[] P009S4_A109EmployeeEmail ;
      private short[] P009S5_A121WorkHourLogHour ;
      private short[] P009S5_A122WorkHourLogMinute ;
   }

   public class aweekremindertomanagerlk__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP009S3;
          prmP009S3 = new Object[] {
          };
          Object[] prmP009S4;
          prmP009S4 = new Object[] {
          new ParDef("CompanyId",GXType.Int64,10,0)
          };
          Object[] prmP009S5;
          prmP009S5 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0) ,
          new ParDef("Gx_date",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009S3", "SELECT T1.CompanyLocationId, T1.CompanyId, T2.CompanyLocationCode, COALESCE( T3.GXC1, 0) AS GXC1 FROM ((Company T1 INNER JOIN CompanyLocation T2 ON T2.CompanyLocationId = T1.CompanyLocationId) LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, CompanyId FROM Employee WHERE T1.CompanyId = CompanyId GROUP BY CompanyId ) T3 ON T3.CompanyId = T1.CompanyId) WHERE T2.CompanyLocationCode = ( 'lk') ORDER BY T1.CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009S3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009S4", "SELECT CompanyId, EmployeeId, EmployeeIsActive, EmployeeIsManager, EmployeeFirstName, EmployeeEmail FROM Employee WHERE (CompanyId = :CompanyId) AND (EmployeeIsActive = TRUE) ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009S4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009S5", "SELECT SUM(WorkHourLogHour), SUM(WorkHourLogMinute) FROM WorkHourLog WHERE (EmployeeId = :EmployeeId) AND (WorkHourLogDate <= :Gx_date and WorkHourLogDate >= (CAST(:Gx_date AS date) + CAST (( -4) || ' DAY' AS INTERVAL))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009S5,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
