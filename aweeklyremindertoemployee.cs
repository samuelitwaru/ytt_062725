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
   public class aweeklyremindertoemployee : GXWebProcedure
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

      public aweeklyremindertoemployee( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aweeklyremindertoemployee( IGxContext context )
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
         AV21TotalWeeklyDuration = 0;
         /* Using cursor P005W2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P005W2_A106EmployeeId[0];
            A112EmployeeIsActive = P005W2_A112EmployeeIsActive[0];
            A107EmployeeFirstName = P005W2_A107EmployeeFirstName[0];
            A109EmployeeEmail = P005W2_A109EmployeeEmail[0];
            AV18TotalHour = 0;
            AV20TotalMinute = 0;
            /* Optimized group. */
            /* Using cursor P005W3 */
            pr_default.execute(1, new Object[] {A106EmployeeId, Gx_date});
            c121WorkHourLogHour = P005W3_A121WorkHourLogHour[0];
            c122WorkHourLogMinute = P005W3_A122WorkHourLogMinute[0];
            pr_default.close(1);
            AV18TotalHour = (short)(AV18TotalHour+c121WorkHourLogHour);
            AV20TotalMinute = (short)(AV20TotalMinute+c122WorkHourLogMinute);
            /* End optimized group. */
            AV12ModTotalMinute = (short)(((int)((AV20TotalMinute) % (60))));
            AV21TotalWeeklyDuration = (short)(NumberUtil.Trunc( AV20TotalMinute/ (decimal)(60), 0)+AV18TotalHour);
            if ( AV21TotalWeeklyDuration < 40 )
            {
               AV13name = A107EmployeeFirstName;
               AV9email = A109EmployeeEmail;
               AV16Subject = "Weekly Time Tracker Reminder";
               AV8Body = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#333;color:#fff;text-align:center;padding:20px 0\"><h2>Time Tracker Reminder</h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear " + AV13name + ",</p><p>This is a reminder that you do not have sufficient work hour logs for this week. Please ensure all your working hours are accurately recorded.</p><p>We appreciate your attention to this matter.</p><a href=\" " + AV22HttpRequest.BaseURL + "logworkhours.aspx\" style=\"display: block; padding: 10px 20px; width: 150px;  margin: 20px auto; background-color: #FFCC00; text-align: center; border-radius: 8px; color: white; font-weight: bold; line-height: 30px; text-decoration: none;\">Update Now</a><p>Empower customer’s success!</p><p>Yukon Software</p></div></div>";
               new sendemail(context ).execute(  AV9email, ref  AV16Subject, ref  AV8Body) ;
               new sdsendpushnotifications(context ).execute(  "Weekly Time Tracker Reminder:",  "This is a reminder that you do not have sufficient work hour logs for this week. Please ensure all your working hours are accurately recorded.",  A106EmployeeId) ;
            }
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
         P005W2_A106EmployeeId = new long[1] ;
         P005W2_A112EmployeeIsActive = new bool[] {false} ;
         P005W2_A107EmployeeFirstName = new string[] {""} ;
         P005W2_A109EmployeeEmail = new string[] {""} ;
         A107EmployeeFirstName = "";
         A109EmployeeEmail = "";
         Gx_date = DateTime.MinValue;
         P005W3_A121WorkHourLogHour = new short[1] ;
         P005W3_A122WorkHourLogMinute = new short[1] ;
         AV13name = "";
         AV9email = "";
         AV16Subject = "";
         AV8Body = "";
         AV22HttpRequest = new GxHttpRequest( context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aweeklyremindertoemployee__default(),
            new Object[][] {
                new Object[] {
               P005W2_A106EmployeeId, P005W2_A112EmployeeIsActive, P005W2_A107EmployeeFirstName, P005W2_A109EmployeeEmail
               }
               , new Object[] {
               P005W3_A121WorkHourLogHour, P005W3_A122WorkHourLogMinute
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
      private short AV21TotalWeeklyDuration ;
      private short AV18TotalHour ;
      private short AV20TotalMinute ;
      private short c121WorkHourLogHour ;
      private short c122WorkHourLogMinute ;
      private short AV12ModTotalMinute ;
      private long A106EmployeeId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A107EmployeeFirstName ;
      private string AV13name ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool A112EmployeeIsActive ;
      private string AV8Body ;
      private string A109EmployeeEmail ;
      private string AV9email ;
      private string AV16Subject ;
      private GxHttpRequest AV22HttpRequest ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P005W2_A106EmployeeId ;
      private bool[] P005W2_A112EmployeeIsActive ;
      private string[] P005W2_A107EmployeeFirstName ;
      private string[] P005W2_A109EmployeeEmail ;
      private short[] P005W3_A121WorkHourLogHour ;
      private short[] P005W3_A122WorkHourLogMinute ;
   }

   public class aweeklyremindertoemployee__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005W2;
          prmP005W2 = new Object[] {
          };
          Object[] prmP005W3;
          prmP005W3 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0) ,
          new ParDef("Gx_date",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005W2", "SELECT EmployeeId, EmployeeIsActive, EmployeeFirstName, EmployeeEmail FROM Employee WHERE EmployeeIsActive = TRUE ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005W2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005W3", "SELECT SUM(WorkHourLogHour), SUM(WorkHourLogMinute) FROM WorkHourLog WHERE (EmployeeId = :EmployeeId) AND (WorkHourLogDate <= :Gx_date and WorkHourLogDate >= (CAST(:Gx_date AS date) + CAST (( -4) || ' DAY' AS INTERVAL))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005W3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
