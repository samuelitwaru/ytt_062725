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
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class acalculateworkhourlogduration : GXWebProcedure
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
            return "calculateworkhourlogduration_Execute" ;
         }

      }

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

      public acalculateworkhourlogduration( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public acalculateworkhourlogduration( IGxContext context )
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("file.pdf");
         setOutputType("pdf");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            AV8CompanyLocationId.Add(2, 0);
            AV13ProjectId.Add(166, 0);
            AV12FromDate = context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), DateTimeUtil.Month( Gx_date), 1);
            AV11ToDate = DateTimeUtil.DateEndOfMonth( Gx_date);
            AV10total = 0;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A157CompanyLocationId ,
                                                 AV8CompanyLocationId } ,
                                                 new int[]{
                                                 TypeConstants.LONG
                                                 }
            });
            /* Using cursor P008J2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A157CompanyLocationId = P008J2_A157CompanyLocationId[0];
               /* Using cursor P008J3 */
               pr_default.execute(1, new Object[] {A157CompanyLocationId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A100CompanyId = P008J3_A100CompanyId[0];
                  /* Using cursor P008J4 */
                  pr_default.execute(2, new Object[] {A100CompanyId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A106EmployeeId = P008J4_A106EmployeeId[0];
                     AV15EmployeeId.Add(A106EmployeeId, 0);
                     pr_default.readNext(2);
                  }
                  pr_default.close(2);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV15EmployeeId.Clear();
            AV15EmployeeId.Add(338, 0);
            AV16StringEmployeeId = AV15EmployeeId.ToJSonString(false);
            AV17IsEmployeeIdEmpty = ((AV15EmployeeId.Count==0) ? true : false);
            AV18IsCompanyLocationIdEmpty = ((AV8CompanyLocationId.Count==0) ? true : false);
            AV26Dsworkhourlogs_1_companylocationid = AV8CompanyLocationId;
            AV27Dsworkhourlogs_2_employeeid = AV15EmployeeId;
            AV26Dsworkhourlogs_1_companylocationid = AV8CompanyLocationId;
            AV27Dsworkhourlogs_2_employeeid = AV15EmployeeId;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 A157CompanyLocationId ,
                                                 AV8CompanyLocationId ,
                                                 AV26Dsworkhourlogs_1_companylocationid ,
                                                 A106EmployeeId ,
                                                 AV27Dsworkhourlogs_2_employeeid ,
                                                 AV8CompanyLocationId.Count ,
                                                 AV12FromDate ,
                                                 AV11ToDate ,
                                                 A119WorkHourLogDate } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P008J6 */
            pr_default.execute(3, new Object[] {AV12FromDate, AV12FromDate, AV11ToDate, AV11ToDate, AV18IsCompanyLocationIdEmpty, AV17IsEmployeeIdEmpty, AV12FromDate, AV11ToDate});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A106EmployeeId = P008J6_A106EmployeeId[0];
               A100CompanyId = P008J6_A100CompanyId[0];
               A119WorkHourLogDate = P008J6_A119WorkHourLogDate[0];
               A157CompanyLocationId = P008J6_A157CompanyLocationId[0];
               A103ProjectName = P008J6_A103ProjectName[0];
               A102ProjectId = P008J6_A102ProjectId[0];
               n102ProjectId = P008J6_n102ProjectId[0];
               A40000GXC1 = P008J6_A40000GXC1[0];
               n40000GXC1 = P008J6_n40000GXC1[0];
               A40001GXC2 = P008J6_A40001GXC2[0];
               n40001GXC2 = P008J6_n40001GXC2[0];
               A100CompanyId = P008J6_A100CompanyId[0];
               A157CompanyLocationId = P008J6_A157CompanyLocationId[0];
               A103ProjectName = P008J6_A103ProjectName[0];
               A40000GXC1 = P008J6_A40000GXC1[0];
               n40000GXC1 = P008J6_n40000GXC1[0];
               A40001GXC2 = P008J6_A40001GXC2[0];
               n40001GXC2 = P008J6_n40001GXC2[0];
               AV10total = (long)(A40000GXC1*60+A40001GXC2);
               GXt_char1 = AV9formattedTotal;
               new procformattime(context ).execute(  AV10total, out  GXt_char1) ;
               AV9formattedTotal = GXt_char1;
               H8J0( false, 50) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10total), "ZZZZZZZZZ9")), 161, Gx_line+11, 225, Gx_line+26, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9formattedTotal, "")), 306, Gx_line+11, 411, Gx_line+26, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A103ProjectName, "")), 11, Gx_line+11, 122, Gx_line+26, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+50);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            H8J0( false, 89) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(AV16StringEmployeeId, 11, Gx_line+0, 728, Gx_line+83, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+89);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8J0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void H8J0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if (IsMain)	waitPrinterEnd();
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
         AV8CompanyLocationId = new GxSimpleCollection<long>();
         AV13ProjectId = new GxSimpleCollection<long>();
         AV12FromDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         AV11ToDate = DateTime.MinValue;
         P008J2_A157CompanyLocationId = new long[1] ;
         P008J3_A157CompanyLocationId = new long[1] ;
         P008J3_A100CompanyId = new long[1] ;
         P008J4_A100CompanyId = new long[1] ;
         P008J4_A106EmployeeId = new long[1] ;
         AV15EmployeeId = new GxSimpleCollection<long>();
         AV16StringEmployeeId = "";
         AV26Dsworkhourlogs_1_companylocationid = new GxSimpleCollection<long>();
         AV27Dsworkhourlogs_2_employeeid = new GxSimpleCollection<long>();
         A119WorkHourLogDate = DateTime.MinValue;
         P008J6_A106EmployeeId = new long[1] ;
         P008J6_A100CompanyId = new long[1] ;
         P008J6_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P008J6_A157CompanyLocationId = new long[1] ;
         P008J6_A103ProjectName = new string[] {""} ;
         P008J6_A102ProjectId = new long[1] ;
         P008J6_n102ProjectId = new bool[] {false} ;
         P008J6_A40000GXC1 = new short[1] ;
         P008J6_n40000GXC1 = new bool[] {false} ;
         P008J6_A40001GXC2 = new short[1] ;
         P008J6_n40001GXC2 = new bool[] {false} ;
         A103ProjectName = "";
         AV9formattedTotal = "";
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acalculateworkhourlogduration__default(),
            new Object[][] {
                new Object[] {
               P008J2_A157CompanyLocationId
               }
               , new Object[] {
               P008J3_A157CompanyLocationId, P008J3_A100CompanyId
               }
               , new Object[] {
               P008J4_A100CompanyId, P008J4_A106EmployeeId
               }
               , new Object[] {
               P008J6_A106EmployeeId, P008J6_A100CompanyId, P008J6_A119WorkHourLogDate, P008J6_A157CompanyLocationId, P008J6_A103ProjectName, P008J6_A102ProjectId, P008J6_n102ProjectId, P008J6_A40000GXC1, P008J6_n40000GXC1, P008J6_A40001GXC2,
               P008J6_n40001GXC2
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A40000GXC1 ;
      private short A40001GXC2 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV8CompanyLocationId_Count ;
      private int Gx_OldLine ;
      private long AV10total ;
      private long A157CompanyLocationId ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A103ProjectName ;
      private string AV9formattedTotal ;
      private string GXt_char1 ;
      private DateTime AV12FromDate ;
      private DateTime Gx_date ;
      private DateTime AV11ToDate ;
      private DateTime A119WorkHourLogDate ;
      private bool entryPointCalled ;
      private bool AV17IsEmployeeIdEmpty ;
      private bool AV18IsCompanyLocationIdEmpty ;
      private bool n102ProjectId ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private string AV16StringEmployeeId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV8CompanyLocationId ;
      private GxSimpleCollection<long> AV13ProjectId ;
      private IDataStoreProvider pr_default ;
      private long[] P008J2_A157CompanyLocationId ;
      private long[] P008J3_A157CompanyLocationId ;
      private long[] P008J3_A100CompanyId ;
      private long[] P008J4_A100CompanyId ;
      private long[] P008J4_A106EmployeeId ;
      private GxSimpleCollection<long> AV15EmployeeId ;
      private GxSimpleCollection<long> AV26Dsworkhourlogs_1_companylocationid ;
      private GxSimpleCollection<long> AV27Dsworkhourlogs_2_employeeid ;
      private long[] P008J6_A106EmployeeId ;
      private long[] P008J6_A100CompanyId ;
      private DateTime[] P008J6_A119WorkHourLogDate ;
      private long[] P008J6_A157CompanyLocationId ;
      private string[] P008J6_A103ProjectName ;
      private long[] P008J6_A102ProjectId ;
      private bool[] P008J6_n102ProjectId ;
      private short[] P008J6_A40000GXC1 ;
      private bool[] P008J6_n40000GXC1 ;
      private short[] P008J6_A40001GXC2 ;
      private bool[] P008J6_n40001GXC2 ;
   }

   public class acalculateworkhourlogduration__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008J2( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV8CompanyLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT CompanyLocationId FROM CompanyLocation";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV8CompanyLocationId, "CompanyLocationId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CompanyLocationId";
         GXv_Object2[0] = scmdbuf;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008J6( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV8CompanyLocationId ,
                                             GxSimpleCollection<long> AV26Dsworkhourlogs_1_companylocationid ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV27Dsworkhourlogs_2_employeeid ,
                                             int AV8CompanyLocationId_Count ,
                                             DateTime AV12FromDate ,
                                             DateTime AV11ToDate ,
                                             DateTime A119WorkHourLogDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[8];
         Object[] GXv_Object5 = new Object[2];
         string sRef1;
         sRef1 = (string)(new GxDbmsUtils( new GxPostgreSql()).ValueList(AV27Dsworkhourlogs_2_employeeid, "T6.EmployeeId"+" IN (", ")"));
         string sRef2;
         sRef2 = (string)(new GxDbmsUtils( new GxPostgreSql()).ValueList(AV26Dsworkhourlogs_1_companylocationid, "T8.CompanyLocationId"+" IN (", ")"));
         scmdbuf = "SELECT DISTINCT NULL AS EmployeeId, NULL AS CompanyId, NULL AS WorkHourLogDate, NULL AS CompanyLocationId, ProjectName, ProjectId, GXC1, GXC2 FROM ( SELECT T1.EmployeeId, T2.CompanyId, T1.WorkHourLogDate, T3.CompanyLocationId, T4.ProjectName, T1.ProjectId, COALESCE( T5.GXC1, 0) AS GXC1, COALESCE( T5.GXC2, 0) AS GXC2 FROM ((((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId) INNER JOIN Project T4 ON T4.ProjectId = T1.ProjectId) LEFT JOIN LATERAL (SELECT SUM(T6.WorkHourLogHour) AS GXC1, T6.ProjectId, T9.ProjectName, SUM(T6.WorkHourLogMinute) AS GXC2 FROM (((WorkHourLog T6 INNER JOIN Employee T7 ON T7.EmployeeId = T6.EmployeeId) INNER JOIN Company T8 ON T8.CompanyId = T7.CompanyId) INNER JOIN Project T9 ON T9.ProjectId = T6.ProjectId) WHERE (T1.ProjectId = T6.ProjectId and T4.ProjectName = ( T9.ProjectName)) AND (( (:AV12FromDate = DATE '00010101') or ( T6.WorkHourLogDate >= :AV12FromDate)) and ( (:AV11ToDate = DATE '00010101') or ( T6.WorkHourLogDate <= :AV11ToDate)) and ( :AV18IsCompanyLocationIdEmpty or ( ";
         scmdbuf += sRef2;
         scmdbuf += ")) and ( :AV17IsEmployeeIdEmpty or ( ";
         scmdbuf += sRef1;
         scmdbuf += "))) GROUP BY T6.ProjectId, T9.ProjectName ) T5 ON T5.ProjectId = T1.ProjectId AND T5.ProjectName = T4.ProjectName)";
         if ( AV8CompanyLocationId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV8CompanyLocationId, "T3.CompanyLocationId IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV12FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV12FromDate)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV11ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV11ToDate)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += ") DistinctT";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P008J2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] );
               case 3 :
                     return conditional_P008J6(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (GxSimpleCollection<long>)dynConstraints[2] , (long)dynConstraints[3] , (GxSimpleCollection<long>)dynConstraints[4] , (int)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] );
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
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008J3;
          prmP008J3 = new Object[] {
          new ParDef("CompanyLocationId",GXType.Int64,10,0)
          };
          Object[] prmP008J4;
          prmP008J4 = new Object[] {
          new ParDef("CompanyId",GXType.Int64,10,0)
          };
          Object[] prmP008J2;
          prmP008J2 = new Object[] {
          };
          Object[] prmP008J6;
          prmP008J6 = new Object[] {
          new ParDef("AV12FromDate",GXType.Date,8,0) ,
          new ParDef("AV12FromDate",GXType.Date,8,0) ,
          new ParDef("AV11ToDate",GXType.Date,8,0) ,
          new ParDef("AV11ToDate",GXType.Date,8,0) ,
          new ParDef("AV18IsCompanyLocationIdEmpty",GXType.Boolean,4,0) ,
          new ParDef("AV17IsEmployeeIdEmpty",GXType.Boolean,4,0) ,
          new ParDef("AV12FromDate",GXType.Date,8,0) ,
          new ParDef("AV11ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008J2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008J3", "SELECT CompanyLocationId, CompanyId FROM Company WHERE CompanyLocationId = :CompanyLocationId ORDER BY CompanyLocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008J3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008J4", "SELECT CompanyId, EmployeeId FROM Employee WHERE CompanyId = :CompanyId ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008J4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008J6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008J6,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((short[]) buf[9])[0] = rslt.getShort(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
