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
   public class agetlocationholidays : GXWebProcedure
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

      public agetlocationholidays( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public agetlocationholidays( IGxContext context )
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
         /* Using cursor P005A2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A159CompanyLocationCode = P005A2_A159CompanyLocationCode[0];
            A157CompanyLocationId = P005A2_A157CompanyLocationId[0];
            AV8httpClient.Host = "www.googleapis.com";
            AV9LocationCode = A159CompanyLocationCode;
            AV8httpClient.Secure = 1;
            AV8httpClient.AddHeader("Content-type", "application/json");
            AV14concat = "calendar/v3/calendars/en." + StringUtil.Trim( A159CompanyLocationCode) + "%23holiday%40group.v.calendar.google.com/events?key=AIzaSyAOlNzBsPtRxK0gBO4Fv-tgZSDliO35L2c";
            AV8httpClient.Execute("GET", AV14concat);
            AV10result = AV8httpClient.ToString();
            AV11holidays.FromJSonString(AV10result, null);
            AV13code = StringUtil.Str( (decimal)(AV8httpClient.StatusCode), 10, 2);
            if ( AV8httpClient.StatusCode == 200 )
            {
               AV16GXV1 = 1;
               while ( AV16GXV1 <= AV11holidays.gxTpr_Items.Count )
               {
                  AV12holiday = ((SdtLocationHoliDayUpdateSDT_itemsItem)AV11holidays.gxTpr_Items.Item(AV16GXV1));
                  if ( StringUtil.StrCmp(AV12holiday.gxTpr_Extendedproperties.gxTpr_Private.gxTpr_Item_1, "OFFICIAL") == 0 )
                  {
                     /*
                        INSERT RECORD ON TABLE Holiday

                     */
                     /* Using cursor P005A4 */
                     pr_default.execute(1, new Object[] {AV9LocationCode});
                     if ( (pr_default.getStatus(1) != 101) )
                     {
                        A40000CompanyId = P005A4_A40000CompanyId[0];
                        n40000CompanyId = P005A4_n40000CompanyId[0];
                     }
                     else
                     {
                        A40000CompanyId = 0;
                        n40000CompanyId = false;
                     }
                     pr_default.close(1);
                     A114HolidayName = AV12holiday.gxTpr_Summary;
                     GXt_date1 = A115HolidayStartDate;
                     new convertdate(context ).execute(  AV12holiday.gxTpr_Start.gxTpr_Date, out  GXt_date1) ;
                     A115HolidayStartDate = GXt_date1;
                     GXt_date1 = A116HolidayEndDate;
                     new convertdate(context ).execute(  AV12holiday.gxTpr_End.gxTpr_Date, out  GXt_date1) ;
                     A116HolidayEndDate = GXt_date1;
                     n116HolidayEndDate = false;
                     A117HolidayServiceId = AV12holiday.gxTpr_Id;
                     n117HolidayServiceId = false;
                     A139HolidayIsActive = true;
                     A100CompanyId = A40000CompanyId;
                     /* Using cursor P005A5 */
                     pr_default.execute(2, new Object[] {A114HolidayName, A115HolidayStartDate, n116HolidayEndDate, A116HolidayEndDate, n117HolidayServiceId, A117HolidayServiceId, A100CompanyId, A139HolidayIsActive});
                     pr_default.close(2);
                     /* Retrieving last key number assigned */
                     /* Using cursor P005A6 */
                     pr_default.execute(3);
                     A113HolidayId = P005A6_A113HolidayId[0];
                     pr_default.close(3);
                     pr_default.SmartCacheProvider.SetUpdated("Holiday");
                     if ( (pr_default.getStatus(2) == 1) )
                     {
                        context.Gx_err = 1;
                        Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                     }
                     else
                     {
                        context.Gx_err = 0;
                        Gx_emsg = "";
                     }
                     /* End Insert */
                  }
                  AV16GXV1 = (int)(AV16GXV1+1);
               }
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
         context.CommitDataStores("getlocationholidays",pr_default);
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         P005A2_A159CompanyLocationCode = new string[] {""} ;
         P005A2_A157CompanyLocationId = new long[1] ;
         A159CompanyLocationCode = "";
         AV8httpClient = new GxHttpClient( context);
         AV9LocationCode = "";
         AV14concat = "";
         AV10result = "";
         AV11holidays = new SdtLocationHoliDayUpdateSDT(context);
         AV13code = "";
         AV12holiday = new SdtLocationHoliDayUpdateSDT_itemsItem(context);
         P005A4_A40000CompanyId = new long[1] ;
         P005A4_n40000CompanyId = new bool[] {false} ;
         A114HolidayName = "";
         A115HolidayStartDate = DateTime.MinValue;
         A116HolidayEndDate = DateTime.MinValue;
         GXt_date1 = DateTime.MinValue;
         A117HolidayServiceId = "";
         P005A6_A113HolidayId = new long[1] ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.agetlocationholidays__default(),
            new Object[][] {
                new Object[] {
               P005A2_A159CompanyLocationCode, P005A2_A157CompanyLocationId
               }
               , new Object[] {
               P005A4_A40000CompanyId, P005A4_n40000CompanyId
               }
               , new Object[] {
               }
               , new Object[] {
               P005A6_A113HolidayId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private int AV16GXV1 ;
      private int GX_INS18 ;
      private long A157CompanyLocationId ;
      private long A40000CompanyId ;
      private long A100CompanyId ;
      private long A113HolidayId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A159CompanyLocationCode ;
      private string AV9LocationCode ;
      private string A114HolidayName ;
      private string A117HolidayServiceId ;
      private string Gx_emsg ;
      private DateTime A115HolidayStartDate ;
      private DateTime A116HolidayEndDate ;
      private DateTime GXt_date1 ;
      private bool entryPointCalled ;
      private bool n40000CompanyId ;
      private bool n116HolidayEndDate ;
      private bool n117HolidayServiceId ;
      private bool A139HolidayIsActive ;
      private string AV14concat ;
      private string AV10result ;
      private string AV13code ;
      private GxHttpClient AV8httpClient ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005A2_A159CompanyLocationCode ;
      private long[] P005A2_A157CompanyLocationId ;
      private SdtLocationHoliDayUpdateSDT AV11holidays ;
      private SdtLocationHoliDayUpdateSDT_itemsItem AV12holiday ;
      private long[] P005A4_A40000CompanyId ;
      private bool[] P005A4_n40000CompanyId ;
      private long[] P005A6_A113HolidayId ;
   }

   public class agetlocationholidays__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005A2;
          prmP005A2 = new Object[] {
          };
          Object[] prmP005A4;
          prmP005A4 = new Object[] {
          new ParDef("AV9LocationCode",GXType.Char,20,0)
          };
          Object[] prmP005A5;
          prmP005A5 = new Object[] {
          new ParDef("HolidayName",GXType.Char,100,0) ,
          new ParDef("HolidayStartDate",GXType.Date,8,0) ,
          new ParDef("HolidayEndDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("HolidayServiceId",GXType.Char,40,0){Nullable=true} ,
          new ParDef("CompanyId",GXType.Int64,10,0) ,
          new ParDef("HolidayIsActive",GXType.Boolean,4,0)
          };
          Object[] prmP005A6;
          prmP005A6 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P005A2", "SELECT CompanyLocationCode, CompanyLocationId FROM CompanyLocation ORDER BY CompanyLocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005A2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005A4", "SELECT COALESCE( T1.CompanyId, 0) AS CompanyId FROM (SELECT MIN(T2.CompanyId) AS CompanyId FROM (Company T2 INNER JOIN CompanyLocation T3 ON T3.CompanyLocationId = T2.CompanyLocationId) WHERE T3.CompanyLocationCode = ( :AV9LocationCode) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005A4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005A5", "SAVEPOINT gxupdate;INSERT INTO Holiday(HolidayName, HolidayStartDate, HolidayEndDate, HolidayServiceId, CompanyId, HolidayIsActive) VALUES(:HolidayName, :HolidayStartDate, :HolidayEndDate, :HolidayServiceId, :CompanyId, :HolidayIsActive);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP005A5)
             ,new CursorDef("P005A6", "SELECT currval('HolidayId') ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005A6,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
