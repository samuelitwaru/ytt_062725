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
   public class aprojectsincompanytest : GXWebProcedure
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
            return "projectsincompanytest_Execute" ;
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

      public aprojectsincompanytest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprojectsincompanytest( IGxContext context )
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
            AV11ProjectId.Add(166, 0);
            AV11ProjectId.Add(167, 0);
            AV11ProjectId.Add(151, 0);
            AV11ProjectId.Add(121, 0);
            AV11ProjectId.Add(80, 0);
            AV11ProjectId.Add(120, 0);
            /* Using cursor P008B2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A106EmployeeId = P008B2_A106EmployeeId[0];
               A102ProjectId = P008B2_A102ProjectId[0];
               A103ProjectName = P008B2_A103ProjectName[0];
               n103ProjectName = P008B2_n103ProjectName[0];
               A148EmployeeName = P008B2_A148EmployeeName[0];
               A148EmployeeName = P008B2_A148EmployeeName[0];
               A103ProjectName = P008B2_A103ProjectName[0];
               n103ProjectName = P008B2_n103ProjectName[0];
               H8B0( false, 47) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A148EmployeeName, "")), 50, Gx_line+11, 572, Gx_line+26, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+47);
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    A102ProjectId ,
                                                    AV11ProjectId ,
                                                    A106EmployeeId } ,
                                                    new int[]{
                                                    TypeConstants.LONG, TypeConstants.LONG
                                                    }
               });
               /* Using cursor P008B4 */
               pr_default.execute(1, new Object[] {A106EmployeeId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A162ProjectManagerId = P008B4_A162ProjectManagerId[0];
                  n162ProjectManagerId = P008B4_n162ProjectManagerId[0];
                  A40000GXC1 = P008B4_A40000GXC1[0];
                  n40000GXC1 = P008B4_n40000GXC1[0];
                  A40001GXC2 = P008B4_A40001GXC2[0];
                  n40001GXC2 = P008B4_n40001GXC2[0];
                  A40000GXC1 = P008B4_A40000GXC1[0];
                  n40000GXC1 = P008B4_n40000GXC1[0];
                  A40001GXC2 = P008B4_A40001GXC2[0];
                  n40001GXC2 = P008B4_n40001GXC2[0];
                  AV8Count = (short)(A40000GXC1*60+A40001GXC2);
                  AV10Name = A103ProjectName;
                  H8B0( false, 58) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8Count), "ZZZ9")), 622, Gx_line+11, 700, Gx_line+26, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A103ProjectName, "")), 89, Gx_line+11, 611, Gx_line+26, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+58);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8B0( true, 0) ;
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

      protected void H8B0( bool bFoot ,
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
         AV11ProjectId = new GxSimpleCollection<long>();
         P008B2_A106EmployeeId = new long[1] ;
         P008B2_A102ProjectId = new long[1] ;
         P008B2_A103ProjectName = new string[] {""} ;
         P008B2_n103ProjectName = new bool[] {false} ;
         P008B2_A148EmployeeName = new string[] {""} ;
         A103ProjectName = "";
         A148EmployeeName = "";
         P008B4_A162ProjectManagerId = new long[1] ;
         P008B4_n162ProjectManagerId = new bool[] {false} ;
         P008B4_A102ProjectId = new long[1] ;
         P008B4_A103ProjectName = new string[] {""} ;
         P008B4_n103ProjectName = new bool[] {false} ;
         P008B4_A106EmployeeId = new long[1] ;
         P008B4_A40000GXC1 = new short[1] ;
         P008B4_n40000GXC1 = new bool[] {false} ;
         P008B4_A40001GXC2 = new short[1] ;
         P008B4_n40001GXC2 = new bool[] {false} ;
         AV10Name = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprojectsincompanytest__default(),
            new Object[][] {
                new Object[] {
               P008B2_A106EmployeeId, P008B2_A102ProjectId, P008B2_A103ProjectName, P008B2_A148EmployeeName
               }
               , new Object[] {
               P008B4_A162ProjectManagerId, P008B4_n162ProjectManagerId, P008B4_A102ProjectId, P008B4_A103ProjectName, P008B4_n103ProjectName, P008B4_A106EmployeeId, P008B4_A40000GXC1, P008B4_n40000GXC1, P008B4_A40001GXC2, P008B4_n40001GXC2
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A40000GXC1 ;
      private short A40001GXC2 ;
      private short AV8Count ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A162ProjectManagerId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A103ProjectName ;
      private string A148EmployeeName ;
      private string AV10Name ;
      private bool entryPointCalled ;
      private bool n103ProjectName ;
      private bool n162ProjectManagerId ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV11ProjectId ;
      private IDataStoreProvider pr_default ;
      private long[] P008B2_A106EmployeeId ;
      private long[] P008B2_A102ProjectId ;
      private string[] P008B2_A103ProjectName ;
      private bool[] P008B2_n103ProjectName ;
      private string[] P008B2_A148EmployeeName ;
      private long[] P008B4_A162ProjectManagerId ;
      private bool[] P008B4_n162ProjectManagerId ;
      private long[] P008B4_A102ProjectId ;
      private string[] P008B4_A103ProjectName ;
      private bool[] P008B4_n103ProjectName ;
      private long[] P008B4_A106EmployeeId ;
      private short[] P008B4_A40000GXC1 ;
      private bool[] P008B4_n40000GXC1 ;
      private short[] P008B4_A40001GXC2 ;
      private bool[] P008B4_n40001GXC2 ;
   }

   public class aprojectsincompanytest__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008B4( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV11ProjectId ,
                                             long A106EmployeeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS ProjectManagerId, ProjectId, ProjectName, NULL AS EmployeeId, GXC1, GXC2 FROM ( SELECT T1.ProjectManagerId, T1.ProjectId, T1.ProjectName, T2.EmployeeId, COALESCE( T3.GXC1, 0) AS GXC1, COALESCE( T3.GXC2, 0) AS GXC2 FROM ((Project T1 LEFT JOIN EmployeeProject T2 ON T2.EmployeeId = T1.ProjectManagerId AND T2.ProjectId = T1.ProjectId) LEFT JOIN LATERAL (SELECT SUM(T4.WorkHourLogHour) AS GXC1, T4.ProjectId, T5.ProjectName, SUM(T4.WorkHourLogMinute) AS GXC2 FROM (WorkHourLog T4 INNER JOIN Project T5 ON T5.ProjectId = T4.ProjectId) WHERE T1.ProjectId = T4.ProjectId and T1.ProjectName = ( T5.ProjectName) GROUP BY T4.ProjectId, T5.ProjectName ) T3 ON T3.ProjectId = T1.ProjectId AND T3.ProjectName = T1.ProjectName)";
         AddWhere(sWhereString, "(T2.EmployeeId = :EmployeeId)");
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV11ProjectId, "T1.ProjectId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.EmployeeId, T1.ProjectId";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY ProjectId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P008B4(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] );
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
          Object[] prmP008B2;
          prmP008B2 = new Object[] {
          };
          Object[] prmP008B4;
          prmP008B4 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008B2", "SELECT DISTINCT EmployeeId, NULL AS ProjectId, NULL AS ProjectName, EmployeeName FROM ( SELECT T1.EmployeeId, T1.ProjectId, T3.ProjectName, T2.EmployeeName FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = T1.ProjectId) ORDER BY T1.EmployeeId) DistinctT ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008B2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008B4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008B4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((short[]) buf[8])[0] = rslt.getShort(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
