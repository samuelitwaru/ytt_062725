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
   public class aprc_icsleaveexport : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "ProjectId");
            if ( ! entryPointCalled )
            {
               AV16ProjectId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV15LeaveTypeId = (long)(Math.Round(NumberUtil.Val( GetPar( "LeaveTypeId"), "."), 18, MidpointRounding.ToEven));
                  AV20Token = GetPar( "Token");
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprc_icsleaveexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_icsleaveexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProjectId ,
                           long aP1_LeaveTypeId ,
                           string aP2_Token )
      {
         this.AV16ProjectId = aP0_ProjectId;
         this.AV15LeaveTypeId = aP1_LeaveTypeId;
         this.AV20Token = aP2_Token;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( long aP0_ProjectId ,
                                 long aP1_LeaveTypeId ,
                                 string aP2_Token )
      {
         this.AV16ProjectId = aP0_ProjectId;
         this.AV15LeaveTypeId = aP1_LeaveTypeId;
         this.AV20Token = aP2_Token;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new logtofile(context ).execute(  StringUtil.Trim( StringUtil.Str( (decimal)(AV15LeaveTypeId), 10, 0))+" : "+StringUtil.Trim( StringUtil.Str( (decimal)(AV16ProjectId), 10, 0))) ;
         new logtofile(context ).execute(  "Token: "+AV20Token) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20Token)) )
         {
            /* Execute user subroutine: 'AUTHFAILED' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV21GXLvl8 = 0;
         /* Using cursor P00BB2 */
         pr_default.execute(0, new Object[] {AV20Token});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A187EmployeeAPIPassword = P00BB2_A187EmployeeAPIPassword[0];
            A106EmployeeId = P00BB2_A106EmployeeId[0];
            AV21GXLvl8 = 1;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV21GXLvl8 == 0 )
         {
            /* Execute user subroutine: 'AUTHFAILED' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV14ICSLeaveExport = "";
         AV14ICSLeaveExport += "BEGIN:VCALENDAR" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "PRODID:-//Yukon Software//APiCalConverter//EN" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "VERSION:2.0" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "CALSCALE:GREGORIAN" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "BEGIN:VTIMEZONE" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "TZID:EET" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "LAST-MODIFIED:20240422T053450Z" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "TZURL:https://www.tzurl.org/zoneinfo/EET" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "X-LIC-LOCATION:EET" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "X-PROLEPTIC-TZNAME;X-NO-BIG-BANG=TRUE:EET" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "BEGIN:DAYLIGHT" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "TZNAME:EEST" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "TZOFFSETFROM:+0200" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "TZOFFSETTO:+0300" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "DTSTART:19770403T030000" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "RRULE:FREQ=YEARLY;UNTIL=19800406T010000Z;BYMONTH=4;BYDAY=1SU" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "END:DAYLIGHT" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "BEGIN:STANDARD" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "TZNAME:EET" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "TZOFFSETFROM:+0300" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "TZOFFSETTO:+0200" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "DTSTART:19770925T040000" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "RDATE:19781001T040000" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "END:STANDARD" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "BEGIN:STANDARD" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "TZNAME:EET" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "TZOFFSETFROM:+0300" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "TZOFFSETTO:+0200" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "DTSTART:19790930T040000" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "RRULE:FREQ=YEARLY;UNTIL=19950924T010000Z;BYMONTH=9;BYDAY=-1SU" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "END:STANDARD" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "BEGIN:DAYLIGHT" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "TZNAME:EEST" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "TZOFFSETFROM:+0200" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "TZOFFSETTO:+0300" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "DTSTART:19810329T030000" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "RRULE:FREQ=YEARLY;BYMONTH=3;BYDAY=-1SU" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "END:DAYLIGHT" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "BEGIN:STANDARD" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "TZNAME:EET" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "TZOFFSETFROM:+0300" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "TZOFFSETTO:+0200" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "DTSTART:19961027T040000" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "RRULE:FREQ=YEARLY;BYMONTH=10;BYDAY=-1SU" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "END:STANDARD" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "END:VTIMEZONE" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "X-WR-TIMEZONE:Europe/Bucharest" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "X-WR-CALNAME:Absence" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "X-WR-CALDESC:" + StringUtil.NewLine( );
         AV14ICSLeaveExport += "METHOD:PUBLISH" + StringUtil.NewLine( );
         AV17ProjectIdCollection.Add(AV16ProjectId, 0);
         GXt_objcol_int1 = AV12EmployeeIdCollection;
         new getemployeeidsbyproject(context ).execute(  AV17ProjectIdCollection, out  GXt_objcol_int1) ;
         AV12EmployeeIdCollection = GXt_objcol_int1;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV12EmployeeIdCollection ,
                                              AV16ProjectId ,
                                              AV12EmployeeIdCollection.Count } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT
                                              }
         });
         /* Using cursor P00BB3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A106EmployeeId = P00BB3_A106EmployeeId[0];
            A124LeaveTypeId = P00BB3_A124LeaveTypeId[0];
            A128LeaveRequestDate = P00BB3_A128LeaveRequestDate[0];
            A171LeaveRequestHalfDay = P00BB3_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P00BB3_n171LeaveRequestHalfDay[0];
            A129LeaveRequestStartDate = P00BB3_A129LeaveRequestStartDate[0];
            A130LeaveRequestEndDate = P00BB3_A130LeaveRequestEndDate[0];
            A125LeaveTypeName = P00BB3_A125LeaveTypeName[0];
            A148EmployeeName = P00BB3_A148EmployeeName[0];
            A109EmployeeEmail = P00BB3_A109EmployeeEmail[0];
            A127LeaveRequestId = P00BB3_A127LeaveRequestId[0];
            A148EmployeeName = P00BB3_A148EmployeeName[0];
            A109EmployeeEmail = P00BB3_A109EmployeeEmail[0];
            A125LeaveTypeName = P00BB3_A125LeaveTypeName[0];
            if ( A124LeaveTypeId == AV15LeaveTypeId )
            {
               AV14ICSLeaveExport += "BEGIN:VEVENT" + StringUtil.NewLine( );
               GXt_char2 = AV14ICSLeaveExport;
               new formatdatetime(context ).execute(  A128LeaveRequestDate,  "YYYYMMDD", out  GXt_char2) ;
               AV14ICSLeaveExport += "DTSTAMP:" + GXt_char2 + "T000000Z" + StringUtil.NewLine( );
               if ( StringUtil.StrCmp(A171LeaveRequestHalfDay, "Morning") == 0 )
               {
                  GXt_char2 = AV14ICSLeaveExport;
                  new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "YYYYMMDD", out  GXt_char2) ;
                  AV14ICSLeaveExport += "DTSTART;TZID=Europe/Bucharest:" + GXt_char2 + "T090000Z" + StringUtil.NewLine( );
                  GXt_char2 = AV14ICSLeaveExport;
                  new formatdatetime(context ).execute(  A130LeaveRequestEndDate,  "YYYYMMDD", out  GXt_char2) ;
                  AV14ICSLeaveExport += "DTEND;TZID=Europe/Bucharest:" + GXt_char2 + "T130000Z" + StringUtil.NewLine( );
               }
               else if ( StringUtil.StrCmp(A171LeaveRequestHalfDay, "Afternoon") == 0 )
               {
                  GXt_char2 = AV14ICSLeaveExport;
                  new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "YYYYMMDD", out  GXt_char2) ;
                  AV14ICSLeaveExport += "DTSTART;TZID=Europe/Bucharest:" + GXt_char2 + "T130000Z" + StringUtil.NewLine( );
                  GXt_char2 = AV14ICSLeaveExport;
                  new formatdatetime(context ).execute(  A130LeaveRequestEndDate,  "YYYYMMDD", out  GXt_char2) ;
                  AV14ICSLeaveExport += "DTEND;TZID=Europe/Bucharest:" + GXt_char2 + "T170000Z" + StringUtil.NewLine( );
               }
               else
               {
                  GXt_char2 = AV14ICSLeaveExport;
                  new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "YYYYMMDD", out  GXt_char2) ;
                  AV14ICSLeaveExport += "DTSTART;VALUE=DATE:" + GXt_char2 + "T000000Z" + StringUtil.NewLine( );
                  GXt_char2 = AV14ICSLeaveExport;
                  new formatdatetime(context ).execute(  A130LeaveRequestEndDate,  "YYYYMMDD", out  GXt_char2) ;
                  AV14ICSLeaveExport += "DTEND;VALUE=DATE:" + GXt_char2 + "T235959Z" + StringUtil.NewLine( );
               }
               AV14ICSLeaveExport += "SUMMARY:" + StringUtil.Trim( A148EmployeeName) + " | " + StringUtil.Trim( A125LeaveTypeName) + StringUtil.NewLine( );
               AV14ICSLeaveExport += "UID:" + StringUtil.Trim( StringUtil.Str( (decimal)(A127LeaveRequestId), 10, 0)) + StringUtil.Trim( A109EmployeeEmail) + StringUtil.NewLine( );
               AV14ICSLeaveExport += "END:VEVENT" + StringUtil.NewLine( );
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         new logtofile(context ).execute(  AV14ICSLeaveExport) ;
         new logtofile(context ).execute(  "----------------------------------------------------------") ;
         AV14ICSLeaveExport += "END:VCALENDAR" + StringUtil.NewLine( );
         AV18HttpResponse.AddString(AV14ICSLeaveExport);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'AUTHFAILED' Routine */
         returnInSub = false;
         AV19ErrorMessage = "ERROR: AUTH FAILED";
         AV18HttpResponse.AddString(AV19ErrorMessage);
         new logtofile(context ).execute(  AV19ErrorMessage) ;
         context.nUserReturn = 1;
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         returnInSub = true;
         if (true) return;
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
         P00BB2_A187EmployeeAPIPassword = new string[] {""} ;
         P00BB2_A106EmployeeId = new long[1] ;
         A187EmployeeAPIPassword = "";
         AV14ICSLeaveExport = "";
         AV17ProjectIdCollection = new GxSimpleCollection<long>();
         AV12EmployeeIdCollection = new GxSimpleCollection<long>();
         GXt_objcol_int1 = new GxSimpleCollection<long>();
         P00BB3_A106EmployeeId = new long[1] ;
         P00BB3_A124LeaveTypeId = new long[1] ;
         P00BB3_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         P00BB3_A171LeaveRequestHalfDay = new string[] {""} ;
         P00BB3_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00BB3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00BB3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00BB3_A125LeaveTypeName = new string[] {""} ;
         P00BB3_A148EmployeeName = new string[] {""} ;
         P00BB3_A109EmployeeEmail = new string[] {""} ;
         P00BB3_A127LeaveRequestId = new long[1] ;
         A128LeaveRequestDate = DateTime.MinValue;
         A171LeaveRequestHalfDay = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A125LeaveTypeName = "";
         A148EmployeeName = "";
         A109EmployeeEmail = "";
         GXt_char2 = "";
         AV18HttpResponse = new GxHttpResponse( context);
         AV19ErrorMessage = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_icsleaveexport__default(),
            new Object[][] {
                new Object[] {
               P00BB2_A187EmployeeAPIPassword, P00BB2_A106EmployeeId
               }
               , new Object[] {
               P00BB3_A106EmployeeId, P00BB3_A124LeaveTypeId, P00BB3_A128LeaveRequestDate, P00BB3_A171LeaveRequestHalfDay, P00BB3_n171LeaveRequestHalfDay, P00BB3_A129LeaveRequestStartDate, P00BB3_A130LeaveRequestEndDate, P00BB3_A125LeaveTypeName, P00BB3_A148EmployeeName, P00BB3_A109EmployeeEmail,
               P00BB3_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV21GXLvl8 ;
      private int AV12EmployeeIdCollection_Count ;
      private long AV16ProjectId ;
      private long AV15LeaveTypeId ;
      private long A106EmployeeId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A171LeaveRequestHalfDay ;
      private string A125LeaveTypeName ;
      private string A148EmployeeName ;
      private string GXt_char2 ;
      private DateTime A128LeaveRequestDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool n171LeaveRequestHalfDay ;
      private string AV14ICSLeaveExport ;
      private string AV20Token ;
      private string A187EmployeeAPIPassword ;
      private string A109EmployeeEmail ;
      private string AV19ErrorMessage ;
      private GxHttpResponse AV18HttpResponse ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00BB2_A187EmployeeAPIPassword ;
      private long[] P00BB2_A106EmployeeId ;
      private GxSimpleCollection<long> AV17ProjectIdCollection ;
      private GxSimpleCollection<long> AV12EmployeeIdCollection ;
      private GxSimpleCollection<long> GXt_objcol_int1 ;
      private long[] P00BB3_A106EmployeeId ;
      private long[] P00BB3_A124LeaveTypeId ;
      private DateTime[] P00BB3_A128LeaveRequestDate ;
      private string[] P00BB3_A171LeaveRequestHalfDay ;
      private bool[] P00BB3_n171LeaveRequestHalfDay ;
      private DateTime[] P00BB3_A129LeaveRequestStartDate ;
      private DateTime[] P00BB3_A130LeaveRequestEndDate ;
      private string[] P00BB3_A125LeaveTypeName ;
      private string[] P00BB3_A148EmployeeName ;
      private string[] P00BB3_A109EmployeeEmail ;
      private long[] P00BB3_A127LeaveRequestId ;
   }

   public class aprc_icsleaveexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BB3( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV12EmployeeIdCollection ,
                                             long AV16ProjectId ,
                                             int AV12EmployeeIdCollection_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T1.LeaveTypeId, T1.LeaveRequestDate, T1.LeaveRequestHalfDay, T1.LeaveRequestStartDate, T1.LeaveRequestEndDate, T3.LeaveTypeName, T2.EmployeeName, T2.EmployeeEmail, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN LeaveType T3 ON T3.LeaveTypeId = T1.LeaveTypeId)";
         if ( AV12EmployeeIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV12EmployeeIdCollection, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestId";
         GXv_Object3[0] = scmdbuf;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00BB3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (int)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00BB2;
          prmP00BB2 = new Object[] {
          new ParDef("AV20Token",GXType.VarChar,40,0)
          };
          Object[] prmP00BB3;
          prmP00BB3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00BB2", "SELECT EmployeeAPIPassword, EmployeeId FROM Employee WHERE EmployeeAPIPassword = ( :AV20Token) ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BB2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BB3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BB3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                return;
       }
    }

 }

}
