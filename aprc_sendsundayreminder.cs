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
   public class aprc_sendsundayreminder : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "CompanyLocationId");
            if ( ! entryPointCalled )
            {
               AV28CompanyLocationId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aprc_sendsundayreminder( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_sendsundayreminder( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_CompanyLocationId )
      {
         this.AV28CompanyLocationId = aP0_CompanyLocationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( long aP0_CompanyLocationId )
      {
         this.AV28CompanyLocationId = aP0_CompanyLocationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Execute user subroutine: 'GETWEEKSTARTDATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Using cursor P00BQ2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A191EmailTemplateName = P00BQ2_A191EmailTemplateName[0];
            A192EmailTemplateContent = P00BQ2_A192EmailTemplateContent[0];
            A190EmailTemplateId = P00BQ2_A190EmailTemplateId[0];
            AV18EmailTemplateContent = A192EmailTemplateContent;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV28CompanyLocationId ,
                                              A157CompanyLocationId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P00BQ3 */
         pr_default.execute(1, new Object[] {AV28CompanyLocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A100CompanyId = P00BQ3_A100CompanyId[0];
            A157CompanyLocationId = P00BQ3_A157CompanyLocationId[0];
            A106EmployeeId = P00BQ3_A106EmployeeId[0];
            A107EmployeeFirstName = P00BQ3_A107EmployeeFirstName[0];
            A109EmployeeEmail = P00BQ3_A109EmployeeEmail[0];
            A157CompanyLocationId = P00BQ3_A157CompanyLocationId[0];
            AV13EmployeeIdCollection.Add(A106EmployeeId, 0);
            AV12CompanyLocationIdCollection.Add(A157CompanyLocationId, 0);
            AV11ToDate = DateTimeUtil.DAdd( Gx_date, (-1));
            DateTimeUtil.DAdd( AV10FromDate, -8) ;
            GXt_objcol_SdtSDTEmployeeWeekReport1 = AV16SDTEmployeeWeekReports;
            new prc_employeeweekreport(context ).execute( ref  AV10FromDate, ref  AV11ToDate, ref  AV12CompanyLocationIdCollection, ref  AV13EmployeeIdCollection, ref  AV14ProjectIdCollection, out  GXt_objcol_SdtSDTEmployeeWeekReport1) ;
            AV16SDTEmployeeWeekReports = GXt_objcol_SdtSDTEmployeeWeekReport1;
            AV9name = A107EmployeeFirstName;
            if ( AV16SDTEmployeeWeekReports.Count == 1 )
            {
               AV19SDTEmployeeWeekReport = ((SdtSDTEmployeeWeekReport)AV16SDTEmployeeWeekReports.Item(1));
               if ( AV19SDTEmployeeWeekReport.gxTpr_Total >= AV19SDTEmployeeWeekReport.gxTpr_Expected )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               AV24row = "<tr>";
               AV32GXV1 = 1;
               while ( AV32GXV1 <= AV19SDTEmployeeWeekReport.gxTpr_Daylogreports.Count )
               {
                  AV22SDT_DayLogReport = ((SdtSDT_DayLogReport)AV19SDTEmployeeWeekReport.gxTpr_Daylogreports.Item(AV32GXV1));
                  if ( AV22SDT_DayLogReport.gxTpr_Isholiday )
                  {
                     AV24row += "<td class=\"leave\">" + "<div>" + AV22SDT_DayLogReport.gxTpr_Formattedhours + "</div>" + "</td>";
                  }
                  else if ( AV22SDT_DayLogReport.gxTpr_Hours > 480 )
                  {
                     AV24row += "<td class=\"more-hours\">" + AV22SDT_DayLogReport.gxTpr_Formattedhours + "</td>";
                  }
                  else if ( AV22SDT_DayLogReport.gxTpr_Hours < 480 )
                  {
                     AV24row += "<td class=\"less-hours\">" + AV22SDT_DayLogReport.gxTpr_Formattedhours + "</td>";
                  }
                  else
                  {
                     AV24row += "<td>" + AV22SDT_DayLogReport.gxTpr_Formattedhours + "</td>";
                  }
                  AV32GXV1 = (int)(AV32GXV1+1);
               }
               if ( AV19SDTEmployeeWeekReport.gxTpr_Expected < AV19SDTEmployeeWeekReport.gxTpr_Total )
               {
                  AV24row += "<td class=\"more-hours\">" + AV19SDTEmployeeWeekReport.gxTpr_Total_formatted + "</td>";
               }
               else if ( AV19SDTEmployeeWeekReport.gxTpr_Expected > AV19SDTEmployeeWeekReport.gxTpr_Total )
               {
                  AV24row += "<td class=\"less-hours\">" + AV19SDTEmployeeWeekReport.gxTpr_Total_formatted + "</td>";
               }
               else
               {
                  AV24row += "<td>" + AV19SDTEmployeeWeekReport.gxTpr_Total_formatted + "</td>";
               }
               AV24row += "</tr>";
            }
            AV17Body = StringUtil.StringReplace( AV18EmailTemplateContent, "{{EmployeeName}}", StringUtil.Trim( AV9name));
            AV17Body = StringUtil.StringReplace( AV17Body, "{{ReportedHours}}", AV19SDTEmployeeWeekReport.gxTpr_Total_formatted);
            AV17Body = StringUtil.StringReplace( AV17Body, "{{ExpectedHours}}", AV19SDTEmployeeWeekReport.gxTpr_Expected_formatted);
            AV17Body = StringUtil.StringReplace( AV17Body, "{{LogHoursLink}}", AV26HttpRequest.BaseURL+formatLink("logworkhours.aspx") );
            AV17Body = StringUtil.StringReplace( AV17Body, "{{Row}}", AV24row);
            AV8email = A109EmployeeEmail;
            AV27Subject = "Time Tracker Reminder";
            new logtofile(context ).execute(  "sending email for: "+A109EmployeeEmail) ;
            new sendemail(context ).execute(  AV8email, ref  AV27Subject, ref  AV17Body) ;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'GETWEEKSTARTDATE' Routine */
         returnInSub = false;
         AV10FromDate = DateTimeUtil.DAdd( Gx_date, (-1*(DateTimeUtil.Dow( Gx_date)-2)));
         AV11ToDate = DateTimeUtil.DAdd( AV10FromDate, (6));
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
         P00BQ2_A191EmailTemplateName = new string[] {""} ;
         P00BQ2_A192EmailTemplateContent = new string[] {""} ;
         P00BQ2_A190EmailTemplateId = new long[1] ;
         A191EmailTemplateName = "";
         A192EmailTemplateContent = "";
         AV18EmailTemplateContent = "";
         P00BQ3_A100CompanyId = new long[1] ;
         P00BQ3_A157CompanyLocationId = new long[1] ;
         P00BQ3_A106EmployeeId = new long[1] ;
         P00BQ3_A107EmployeeFirstName = new string[] {""} ;
         P00BQ3_A109EmployeeEmail = new string[] {""} ;
         A107EmployeeFirstName = "";
         A109EmployeeEmail = "";
         AV13EmployeeIdCollection = new GxSimpleCollection<long>();
         AV12CompanyLocationIdCollection = new GxSimpleCollection<long>();
         AV11ToDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         AV10FromDate = DateTime.MinValue;
         AV16SDTEmployeeWeekReports = new GXBaseCollection<SdtSDTEmployeeWeekReport>( context, "SDTEmployeeWeekReport", "YTT_version4");
         GXt_objcol_SdtSDTEmployeeWeekReport1 = new GXBaseCollection<SdtSDTEmployeeWeekReport>( context, "SDTEmployeeWeekReport", "YTT_version4");
         AV14ProjectIdCollection = new GxSimpleCollection<long>();
         AV9name = "";
         AV19SDTEmployeeWeekReport = new SdtSDTEmployeeWeekReport(context);
         AV24row = "";
         AV22SDT_DayLogReport = new SdtSDT_DayLogReport(context);
         AV17Body = "";
         AV26HttpRequest = new GxHttpRequest( context);
         AV8email = "";
         AV27Subject = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_sendsundayreminder__default(),
            new Object[][] {
                new Object[] {
               P00BQ2_A191EmailTemplateName, P00BQ2_A192EmailTemplateContent, P00BQ2_A190EmailTemplateId
               }
               , new Object[] {
               P00BQ3_A100CompanyId, P00BQ3_A157CompanyLocationId, P00BQ3_A106EmployeeId, P00BQ3_A107EmployeeFirstName, P00BQ3_A109EmployeeEmail
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
      private int AV32GXV1 ;
      private long AV28CompanyLocationId ;
      private long A190EmailTemplateId ;
      private long A157CompanyLocationId ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A191EmailTemplateName ;
      private string A107EmployeeFirstName ;
      private string AV9name ;
      private DateTime AV11ToDate ;
      private DateTime Gx_date ;
      private DateTime AV10FromDate ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private string A192EmailTemplateContent ;
      private string AV18EmailTemplateContent ;
      private string AV17Body ;
      private string A109EmployeeEmail ;
      private string AV24row ;
      private string AV8email ;
      private string AV27Subject ;
      private GxHttpRequest AV26HttpRequest ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00BQ2_A191EmailTemplateName ;
      private string[] P00BQ2_A192EmailTemplateContent ;
      private long[] P00BQ2_A190EmailTemplateId ;
      private long[] P00BQ3_A100CompanyId ;
      private long[] P00BQ3_A157CompanyLocationId ;
      private long[] P00BQ3_A106EmployeeId ;
      private string[] P00BQ3_A107EmployeeFirstName ;
      private string[] P00BQ3_A109EmployeeEmail ;
      private GxSimpleCollection<long> AV13EmployeeIdCollection ;
      private GxSimpleCollection<long> AV12CompanyLocationIdCollection ;
      private GXBaseCollection<SdtSDTEmployeeWeekReport> AV16SDTEmployeeWeekReports ;
      private GXBaseCollection<SdtSDTEmployeeWeekReport> GXt_objcol_SdtSDTEmployeeWeekReport1 ;
      private GxSimpleCollection<long> AV14ProjectIdCollection ;
      private SdtSDTEmployeeWeekReport AV19SDTEmployeeWeekReport ;
      private SdtSDT_DayLogReport AV22SDT_DayLogReport ;
   }

   public class aprc_sendsundayreminder__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BQ3( IGxContext context ,
                                             long AV28CompanyLocationId ,
                                             long A157CompanyLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[1];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T2.CompanyLocationId, T1.EmployeeId, T1.EmployeeFirstName, T1.EmployeeEmail FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         if ( ! (0==AV28CompanyLocationId) )
         {
            AddWhere(sWhereString, "(T2.CompanyLocationId = :AV28CompanyLocationId)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00BQ3(context, (long)dynConstraints[0] , (long)dynConstraints[1] );
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
          Object[] prmP00BQ2;
          prmP00BQ2 = new Object[] {
          };
          Object[] prmP00BQ3;
          prmP00BQ3 = new Object[] {
          new ParDef("AV28CompanyLocationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BQ2", "SELECT EmailTemplateName, EmailTemplateContent, EmailTemplateId FROM Trn_EmailTemplate WHERE EmailTemplateName = ( 'SundayEmail') ORDER BY EmailTemplateId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BQ2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BQ3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BQ3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
