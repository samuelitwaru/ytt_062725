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
   public class prc_employeeweekreport : GXProcedure
   {
      public prc_employeeweekreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_employeeweekreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FromDate ,
                           ref DateTime aP1_ToDate ,
                           ref GxSimpleCollection<long> aP2_CompanyLocationIdCollection ,
                           ref GxSimpleCollection<long> aP3_EmployeeIdCollection ,
                           ref GxSimpleCollection<long> aP4_ProjectIdCollection ,
                           out GXBaseCollection<SdtSDTEmployeeWeekReport> aP5_SDTEmployeeWeekReportCollection )
      {
         this.AV11FromDate = aP0_FromDate;
         this.AV10ToDate = aP1_ToDate;
         this.AV32CompanyLocationIdCollection = aP2_CompanyLocationIdCollection;
         this.AV12EmployeeIdCollection = aP3_EmployeeIdCollection;
         this.AV8ProjectIdCollection = aP4_ProjectIdCollection;
         this.AV24SDTEmployeeWeekReportCollection = new GXBaseCollection<SdtSDTEmployeeWeekReport>( context, "SDTEmployeeWeekReport", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP0_FromDate=this.AV11FromDate;
         aP1_ToDate=this.AV10ToDate;
         aP2_CompanyLocationIdCollection=this.AV32CompanyLocationIdCollection;
         aP3_EmployeeIdCollection=this.AV12EmployeeIdCollection;
         aP4_ProjectIdCollection=this.AV8ProjectIdCollection;
         aP5_SDTEmployeeWeekReportCollection=this.AV24SDTEmployeeWeekReportCollection;
      }

      public GXBaseCollection<SdtSDTEmployeeWeekReport> executeUdp( ref DateTime aP0_FromDate ,
                                                                    ref DateTime aP1_ToDate ,
                                                                    ref GxSimpleCollection<long> aP2_CompanyLocationIdCollection ,
                                                                    ref GxSimpleCollection<long> aP3_EmployeeIdCollection ,
                                                                    ref GxSimpleCollection<long> aP4_ProjectIdCollection )
      {
         execute(ref aP0_FromDate, ref aP1_ToDate, ref aP2_CompanyLocationIdCollection, ref aP3_EmployeeIdCollection, ref aP4_ProjectIdCollection, out aP5_SDTEmployeeWeekReportCollection);
         return AV24SDTEmployeeWeekReportCollection ;
      }

      public void executeSubmit( ref DateTime aP0_FromDate ,
                                 ref DateTime aP1_ToDate ,
                                 ref GxSimpleCollection<long> aP2_CompanyLocationIdCollection ,
                                 ref GxSimpleCollection<long> aP3_EmployeeIdCollection ,
                                 ref GxSimpleCollection<long> aP4_ProjectIdCollection ,
                                 out GXBaseCollection<SdtSDTEmployeeWeekReport> aP5_SDTEmployeeWeekReportCollection )
      {
         this.AV11FromDate = aP0_FromDate;
         this.AV10ToDate = aP1_ToDate;
         this.AV32CompanyLocationIdCollection = aP2_CompanyLocationIdCollection;
         this.AV12EmployeeIdCollection = aP3_EmployeeIdCollection;
         this.AV8ProjectIdCollection = aP4_ProjectIdCollection;
         this.AV24SDTEmployeeWeekReportCollection = new GXBaseCollection<SdtSDTEmployeeWeekReport>( context, "SDTEmployeeWeekReport", "YTT_version4") ;
         SubmitImpl();
         aP0_FromDate=this.AV11FromDate;
         aP1_ToDate=this.AV10ToDate;
         aP2_CompanyLocationIdCollection=this.AV32CompanyLocationIdCollection;
         aP3_EmployeeIdCollection=this.AV12EmployeeIdCollection;
         aP4_ProjectIdCollection=this.AV8ProjectIdCollection;
         aP5_SDTEmployeeWeekReportCollection=this.AV24SDTEmployeeWeekReportCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new logtofile(context ).execute(  "projects: "+AV8ProjectIdCollection.ToJSonString(false)) ;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A157CompanyLocationId ,
                                              AV32CompanyLocationIdCollection ,
                                              A106EmployeeId ,
                                              AV12EmployeeIdCollection ,
                                              AV32CompanyLocationIdCollection.Count ,
                                              AV12EmployeeIdCollection.Count ,
                                              A112EmployeeIsActive } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00BN2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00BN2_A100CompanyId[0];
            A106EmployeeId = P00BN2_A106EmployeeId[0];
            A188EmployeeFTEHours = P00BN2_A188EmployeeFTEHours[0];
            A148EmployeeName = P00BN2_A148EmployeeName[0];
            A112EmployeeIsActive = P00BN2_A112EmployeeIsActive[0];
            A157CompanyLocationId = P00BN2_A157CompanyLocationId[0];
            A157CompanyLocationId = P00BN2_A157CompanyLocationId[0];
            /* Using cursor P00BN3 */
            pr_default.execute(1, new Object[] {A106EmployeeId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A102ProjectId = P00BN3_A102ProjectId[0];
               AV23SDTEmployeeWeekReport = new SdtSDTEmployeeWeekReport(context);
               GXt_int1 = AV13Mon;
               new prc_getemployeetotalhours(context ).execute( ref  A106EmployeeId, ref  AV11FromDate, ref  AV11FromDate, ref  AV8ProjectIdCollection, out  GXt_int1) ;
               AV13Mon = GXt_int1;
               GXt_int1 = AV14Tue;
               GXt_date2 = DateTimeUtil.DAdd( AV11FromDate, (1));
               GXt_date3 = DateTimeUtil.DAdd( AV11FromDate, (1));
               new prc_getemployeetotalhours(context ).execute( ref  A106EmployeeId, ref  GXt_date2, ref  GXt_date3, ref  AV8ProjectIdCollection, out  GXt_int1) ;
               AV14Tue = GXt_int1;
               GXt_int1 = AV15Wed;
               GXt_date3 = DateTimeUtil.DAdd( AV11FromDate, (2));
               GXt_date2 = DateTimeUtil.DAdd( AV11FromDate, (2));
               new prc_getemployeetotalhours(context ).execute( ref  A106EmployeeId, ref  GXt_date3, ref  GXt_date2, ref  AV8ProjectIdCollection, out  GXt_int1) ;
               AV15Wed = GXt_int1;
               GXt_int1 = AV16Thu;
               GXt_date3 = DateTimeUtil.DAdd( AV11FromDate, (3));
               GXt_date2 = DateTimeUtil.DAdd( AV11FromDate, (3));
               new prc_getemployeetotalhours(context ).execute( ref  A106EmployeeId, ref  GXt_date3, ref  GXt_date2, ref  AV8ProjectIdCollection, out  GXt_int1) ;
               AV16Thu = GXt_int1;
               GXt_int1 = AV17Fri;
               GXt_date3 = DateTimeUtil.DAdd( AV11FromDate, (4));
               GXt_date2 = DateTimeUtil.DAdd( AV11FromDate, (4));
               new prc_getemployeetotalhours(context ).execute( ref  A106EmployeeId, ref  GXt_date3, ref  GXt_date2, ref  AV8ProjectIdCollection, out  GXt_int1) ;
               AV17Fri = GXt_int1;
               GXt_int1 = AV18Sat;
               GXt_date3 = DateTimeUtil.DAdd( AV11FromDate, (5));
               GXt_date2 = DateTimeUtil.DAdd( AV11FromDate, (5));
               new prc_getemployeetotalhours(context ).execute( ref  A106EmployeeId, ref  GXt_date3, ref  GXt_date2, ref  AV8ProjectIdCollection, out  GXt_int1) ;
               AV18Sat = (short)(GXt_int1);
               GXt_int1 = AV19Sun;
               GXt_date3 = DateTimeUtil.DAdd( AV11FromDate, (6));
               GXt_date2 = DateTimeUtil.DAdd( AV11FromDate, (6));
               new prc_getemployeetotalhours(context ).execute( ref  A106EmployeeId, ref  GXt_date3, ref  GXt_date2, ref  AV8ProjectIdCollection, out  GXt_int1) ;
               AV19Sun = GXt_int1;
               GXt_int4 = (short)(AV20Blank);
               GXt_int5 = (short)(AV33Leave);
               new employeeleavetotal(context ).execute(  A106EmployeeId,  AV11FromDate,  DateTimeUtil.DAdd( AV11FromDate, (6)), out  GXt_int5) ;
               AV33Leave = GXt_int5;
               AV20Blank = GXt_int4;
               AV21Total = (short)(AV13Mon+AV14Tue+AV15Wed+AV16Thu+AV17Fri+AV18Sat+AV19Sun);
               AV22Expected = (long)((A188EmployeeFTEHours*60)-AV33Leave);
               AV23SDTEmployeeWeekReport.gxTpr_Employeename = StringUtil.Trim( A148EmployeeName);
               AV23SDTEmployeeWeekReport.gxTpr_Mon = AV13Mon;
               AV23SDTEmployeeWeekReport.gxTpr_Tue = AV14Tue;
               AV23SDTEmployeeWeekReport.gxTpr_Wed = AV15Wed;
               AV23SDTEmployeeWeekReport.gxTpr_Thu = AV16Thu;
               AV23SDTEmployeeWeekReport.gxTpr_Fri = AV17Fri;
               AV23SDTEmployeeWeekReport.gxTpr_Sat = AV18Sat;
               AV23SDTEmployeeWeekReport.gxTpr_Sun = AV19Sun;
               AV23SDTEmployeeWeekReport.gxTpr_Leave = AV33Leave;
               AV23SDTEmployeeWeekReport.gxTpr_Total = AV21Total;
               AV23SDTEmployeeWeekReport.gxTpr_Expected = AV22Expected;
               GXt_boolean6 = false;
               new isdateholiday(context ).execute(  AV11FromDate,  A106EmployeeId, out  AV25MonHolidayName, out  GXt_boolean6) ;
               AV23SDTEmployeeWeekReport.gxTpr_Mon_isholiday = GXt_boolean6;
               GXt_boolean6 = false;
               new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV11FromDate, (1)),  A106EmployeeId, out  AV26TueHolidayName, out  GXt_boolean6) ;
               AV23SDTEmployeeWeekReport.gxTpr_Tue_isholiday = GXt_boolean6;
               GXt_boolean6 = false;
               new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV11FromDate, (2)),  A106EmployeeId, out  AV27WedHolidayName, out  GXt_boolean6) ;
               AV23SDTEmployeeWeekReport.gxTpr_Wed_isholiday = GXt_boolean6;
               GXt_boolean6 = false;
               new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV11FromDate, (3)),  A106EmployeeId, out  AV28ThuHolidayName, out  GXt_boolean6) ;
               AV23SDTEmployeeWeekReport.gxTpr_Thu_isholiday = GXt_boolean6;
               GXt_boolean6 = false;
               new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV11FromDate, (4)),  A106EmployeeId, out  AV29FriHolidayName, out  GXt_boolean6) ;
               AV23SDTEmployeeWeekReport.gxTpr_Fri_isholiday = GXt_boolean6;
               GXt_boolean6 = false;
               new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV11FromDate, (5)),  A106EmployeeId, out  AV30SatHolidayName, out  GXt_boolean6) ;
               AV23SDTEmployeeWeekReport.gxTpr_Sat_isholiday = GXt_boolean6;
               GXt_boolean6 = false;
               new isdateholiday(context ).execute(  DateTimeUtil.DAdd( AV11FromDate, (6)),  A106EmployeeId, out  AV31SunHolidayName, out  GXt_boolean6) ;
               AV23SDTEmployeeWeekReport.gxTpr_Sun_isholiday = GXt_boolean6;
               GXt_char7 = "";
               new formattime(context ).execute(  AV13Mon, out  GXt_char7) ;
               GXt_char8 = "";
               new formattime(context ).execute(  AV13Mon, out  GXt_char8) ;
               GXt_char9 = "";
               new formattime(context ).execute(  AV13Mon, out  GXt_char9) ;
               AV23SDTEmployeeWeekReport.gxTpr_Mon_formatted = (!String.IsNullOrEmpty(StringUtil.RTrim( AV25MonHolidayName)) ? GXt_char8+"<br /><small>"+AV25MonHolidayName+"</small>" : GXt_char9);
               GXt_char9 = "";
               new formattime(context ).execute(  AV14Tue, out  GXt_char9) ;
               GXt_char8 = "";
               new formattime(context ).execute(  AV14Tue, out  GXt_char8) ;
               GXt_char7 = "";
               new formattime(context ).execute(  AV14Tue, out  GXt_char7) ;
               AV23SDTEmployeeWeekReport.gxTpr_Tue_formatted = (!String.IsNullOrEmpty(StringUtil.RTrim( AV26TueHolidayName)) ? GXt_char8+"<br /><small>"+AV26TueHolidayName+"</small>" : GXt_char7);
               GXt_char9 = "";
               new formattime(context ).execute(  AV15Wed, out  GXt_char9) ;
               GXt_char8 = "";
               new formattime(context ).execute(  AV15Wed, out  GXt_char8) ;
               GXt_char7 = "";
               new formattime(context ).execute(  AV15Wed, out  GXt_char7) ;
               AV23SDTEmployeeWeekReport.gxTpr_Wed_formatted = (!String.IsNullOrEmpty(StringUtil.RTrim( AV27WedHolidayName)) ? GXt_char8+"<br /><small>"+AV27WedHolidayName+"</small>" : GXt_char7);
               GXt_char9 = "";
               new formattime(context ).execute(  AV16Thu, out  GXt_char9) ;
               GXt_char8 = "";
               new formattime(context ).execute(  AV16Thu, out  GXt_char8) ;
               GXt_char7 = "";
               new formattime(context ).execute(  AV16Thu, out  GXt_char7) ;
               AV23SDTEmployeeWeekReport.gxTpr_Thu_formatted = (!String.IsNullOrEmpty(StringUtil.RTrim( AV28ThuHolidayName)) ? GXt_char8+"<br /><small>"+AV28ThuHolidayName+"</small>" : GXt_char7);
               GXt_char9 = "";
               new formattime(context ).execute(  AV17Fri, out  GXt_char9) ;
               GXt_char8 = "";
               new formattime(context ).execute(  AV17Fri, out  GXt_char8) ;
               GXt_char7 = "";
               new formattime(context ).execute(  AV17Fri, out  GXt_char7) ;
               AV23SDTEmployeeWeekReport.gxTpr_Fri_formatted = (!String.IsNullOrEmpty(StringUtil.RTrim( AV29FriHolidayName)) ? GXt_char8+"<br /><small>"+AV29FriHolidayName+"</small>" : GXt_char7);
               GXt_char9 = "";
               new formattime(context ).execute(  AV18Sat, out  GXt_char9) ;
               AV23SDTEmployeeWeekReport.gxTpr_Sat_formatted = GXt_char9;
               GXt_char9 = "";
               new formattime(context ).execute(  AV19Sun, out  GXt_char9) ;
               AV23SDTEmployeeWeekReport.gxTpr_Sun_formatted = GXt_char9;
               GXt_char9 = "";
               new formattime(context ).execute(  AV33Leave, out  GXt_char9) ;
               AV23SDTEmployeeWeekReport.gxTpr_Leave_formatted = GXt_char9;
               GXt_char9 = "";
               new formattime(context ).execute(  AV21Total, out  GXt_char9) ;
               AV23SDTEmployeeWeekReport.gxTpr_Total_formatted = GXt_char9;
               GXt_char9 = "";
               new formattime(context ).execute(  AV22Expected, out  GXt_char9) ;
               AV23SDTEmployeeWeekReport.gxTpr_Expected_formatted = GXt_char9;
               if ( AV8ProjectIdCollection.Count == 0 )
               {
                  AV24SDTEmployeeWeekReportCollection.Add(AV23SDTEmployeeWeekReport, 0);
               }
               else
               {
                  if ( ( AV8ProjectIdCollection.Count > 0 ) && ( AV21Total > 0 ) )
                  {
                     AV24SDTEmployeeWeekReportCollection.Add(AV23SDTEmployeeWeekReport, 0);
                  }
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV24SDTEmployeeWeekReportCollection = new GXBaseCollection<SdtSDTEmployeeWeekReport>( context, "SDTEmployeeWeekReport", "YTT_version4");
         P00BN2_A100CompanyId = new long[1] ;
         P00BN2_A106EmployeeId = new long[1] ;
         P00BN2_A188EmployeeFTEHours = new short[1] ;
         P00BN2_A148EmployeeName = new string[] {""} ;
         P00BN2_A112EmployeeIsActive = new bool[] {false} ;
         P00BN2_A157CompanyLocationId = new long[1] ;
         A148EmployeeName = "";
         P00BN3_A106EmployeeId = new long[1] ;
         P00BN3_A102ProjectId = new long[1] ;
         AV23SDTEmployeeWeekReport = new SdtSDTEmployeeWeekReport(context);
         GXt_date3 = DateTime.MinValue;
         GXt_date2 = DateTime.MinValue;
         AV25MonHolidayName = "";
         AV26TueHolidayName = "";
         AV27WedHolidayName = "";
         AV28ThuHolidayName = "";
         AV29FriHolidayName = "";
         AV30SatHolidayName = "";
         AV31SunHolidayName = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char9 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_employeeweekreport__default(),
            new Object[][] {
                new Object[] {
               P00BN2_A100CompanyId, P00BN2_A106EmployeeId, P00BN2_A188EmployeeFTEHours, P00BN2_A148EmployeeName, P00BN2_A112EmployeeIsActive, P00BN2_A157CompanyLocationId
               }
               , new Object[] {
               P00BN3_A106EmployeeId, P00BN3_A102ProjectId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A188EmployeeFTEHours ;
      private short AV18Sat ;
      private short GXt_int4 ;
      private short GXt_int5 ;
      private short AV21Total ;
      private int AV32CompanyLocationIdCollection_Count ;
      private int AV12EmployeeIdCollection_Count ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long A102ProjectId ;
      private long AV13Mon ;
      private long AV14Tue ;
      private long AV15Wed ;
      private long AV16Thu ;
      private long AV17Fri ;
      private long AV19Sun ;
      private long GXt_int1 ;
      private long AV20Blank ;
      private long AV33Leave ;
      private long AV22Expected ;
      private string A148EmployeeName ;
      private string AV25MonHolidayName ;
      private string AV26TueHolidayName ;
      private string AV27WedHolidayName ;
      private string AV28ThuHolidayName ;
      private string AV29FriHolidayName ;
      private string AV30SatHolidayName ;
      private string AV31SunHolidayName ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char9 ;
      private DateTime AV11FromDate ;
      private DateTime AV10ToDate ;
      private DateTime GXt_date3 ;
      private DateTime GXt_date2 ;
      private bool A112EmployeeIsActive ;
      private bool GXt_boolean6 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FromDate ;
      private DateTime aP1_ToDate ;
      private GxSimpleCollection<long> AV32CompanyLocationIdCollection ;
      private GxSimpleCollection<long> aP2_CompanyLocationIdCollection ;
      private GxSimpleCollection<long> AV12EmployeeIdCollection ;
      private GxSimpleCollection<long> aP3_EmployeeIdCollection ;
      private GxSimpleCollection<long> AV8ProjectIdCollection ;
      private GxSimpleCollection<long> aP4_ProjectIdCollection ;
      private GXBaseCollection<SdtSDTEmployeeWeekReport> AV24SDTEmployeeWeekReportCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P00BN2_A100CompanyId ;
      private long[] P00BN2_A106EmployeeId ;
      private short[] P00BN2_A188EmployeeFTEHours ;
      private string[] P00BN2_A148EmployeeName ;
      private bool[] P00BN2_A112EmployeeIsActive ;
      private long[] P00BN2_A157CompanyLocationId ;
      private long[] P00BN3_A106EmployeeId ;
      private long[] P00BN3_A102ProjectId ;
      private SdtSDTEmployeeWeekReport AV23SDTEmployeeWeekReport ;
      private GXBaseCollection<SdtSDTEmployeeWeekReport> aP5_SDTEmployeeWeekReportCollection ;
   }

   public class prc_employeeweekreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BN2( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV32CompanyLocationIdCollection ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV12EmployeeIdCollection ,
                                             int AV32CompanyLocationIdCollection_Count ,
                                             int AV12EmployeeIdCollection_Count ,
                                             bool A112EmployeeIsActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T1.EmployeeId, T1.EmployeeFTEHours, T1.EmployeeName, T1.EmployeeIsActive, T2.CompanyLocationId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         if ( AV32CompanyLocationIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV32CompanyLocationIdCollection, "T2.CompanyLocationId IN (", ")")+")");
         }
         if ( AV12EmployeeIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV12EmployeeIdCollection, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeName";
         GXv_Object10[0] = scmdbuf;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00BN2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (bool)dynConstraints[6] );
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
          Object[] prmP00BN3;
          prmP00BN3 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP00BN2;
          prmP00BN2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00BN2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BN2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BN3", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BN3,1, GxCacheFrequency.OFF ,true,true )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
