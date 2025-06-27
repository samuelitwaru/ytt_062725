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
   public class aemployeestodelete : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aemployeestodelete().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         execute();
         return GX.GXRuntime.ExitCode ;
      }

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

      public aemployeestodelete( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aemployeestodelete( IGxContext context )
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
         AV12Count = 1;
         AV14CompanyId = 1;
         AV15StartDate = context.localUtil.YMDToD( 2024, 1, 1);
         /* Using cursor P00862 */
         pr_default.execute(0, new Object[] {AV15StartDate, AV14CompanyId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00862_A100CompanyId[0];
            A119WorkHourLogDate = P00862_A119WorkHourLogDate[0];
            A109EmployeeEmail = P00862_A109EmployeeEmail[0];
            A106EmployeeId = P00862_A106EmployeeId[0];
            A148EmployeeName = P00862_A148EmployeeName[0];
            A100CompanyId = P00862_A100CompanyId[0];
            A109EmployeeEmail = P00862_A109EmployeeEmail[0];
            A148EmployeeName = P00862_A148EmployeeName[0];
            AV11EmployeeEmails.Add(StringUtil.Trim( A109EmployeeEmail), 0);
            AV12Count = (short)(AV12Count+1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV12Count = 1;
         AV17DeleteExceptions.Add(619, 0);
         AV17DeleteExceptions.Add(615, 0);
         AV17DeleteExceptions.Add(448, 0);
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A109EmployeeEmail ,
                                              AV11EmployeeEmails ,
                                              A106EmployeeId ,
                                              AV17DeleteExceptions ,
                                              A100CompanyId ,
                                              AV14CompanyId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P00863 */
         pr_default.execute(1, new Object[] {AV14CompanyId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A100CompanyId = P00863_A100CompanyId[0];
            A106EmployeeId = P00863_A106EmployeeId[0];
            A109EmployeeEmail = P00863_A109EmployeeEmail[0];
            A111GAMUserGUID = P00863_A111GAMUserGUID[0];
            A148EmployeeName = P00863_A148EmployeeName[0];
            AV13EmployeeEmailsToDelete.Add(StringUtil.Trim( A109EmployeeEmail), 0);
            AV16EmployeeIdsToDelete.Add(A106EmployeeId, 0);
            AV18GUIDs.Add(A111GAMUserGUID, 0);
            AV12Count = (short)(AV12Count+1);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         cleanup();
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
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
         AV15StartDate = DateTime.MinValue;
         P00862_A100CompanyId = new long[1] ;
         P00862_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00862_A109EmployeeEmail = new string[] {""} ;
         P00862_A106EmployeeId = new long[1] ;
         P00862_A148EmployeeName = new string[] {""} ;
         A119WorkHourLogDate = DateTime.MinValue;
         A109EmployeeEmail = "";
         A148EmployeeName = "";
         AV11EmployeeEmails = new GxSimpleCollection<string>();
         AV17DeleteExceptions = new GxSimpleCollection<long>();
         P00863_A100CompanyId = new long[1] ;
         P00863_A106EmployeeId = new long[1] ;
         P00863_A109EmployeeEmail = new string[] {""} ;
         P00863_A111GAMUserGUID = new string[] {""} ;
         P00863_A148EmployeeName = new string[] {""} ;
         A111GAMUserGUID = "";
         AV13EmployeeEmailsToDelete = new GxSimpleCollection<string>();
         AV16EmployeeIdsToDelete = new GxSimpleCollection<long>();
         AV18GUIDs = new GxSimpleCollection<string>();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aemployeestodelete__default(),
            new Object[][] {
                new Object[] {
               P00862_A100CompanyId, P00862_A119WorkHourLogDate, P00862_A109EmployeeEmail, P00862_A106EmployeeId, P00862_A148EmployeeName
               }
               , new Object[] {
               P00863_A100CompanyId, P00863_A106EmployeeId, P00863_A109EmployeeEmail, P00863_A111GAMUserGUID, P00863_A148EmployeeName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12Count ;
      private long AV14CompanyId ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private string A148EmployeeName ;
      private DateTime AV15StartDate ;
      private DateTime A119WorkHourLogDate ;
      private string A109EmployeeEmail ;
      private string A111GAMUserGUID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00862_A100CompanyId ;
      private DateTime[] P00862_A119WorkHourLogDate ;
      private string[] P00862_A109EmployeeEmail ;
      private long[] P00862_A106EmployeeId ;
      private string[] P00862_A148EmployeeName ;
      private GxSimpleCollection<string> AV11EmployeeEmails ;
      private GxSimpleCollection<long> AV17DeleteExceptions ;
      private long[] P00863_A100CompanyId ;
      private long[] P00863_A106EmployeeId ;
      private string[] P00863_A109EmployeeEmail ;
      private string[] P00863_A111GAMUserGUID ;
      private string[] P00863_A148EmployeeName ;
      private GxSimpleCollection<string> AV13EmployeeEmailsToDelete ;
      private GxSimpleCollection<long> AV16EmployeeIdsToDelete ;
      private GxSimpleCollection<string> AV18GUIDs ;
   }

   public class aemployeestodelete__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00863( IGxContext context ,
                                             string A109EmployeeEmail ,
                                             GxSimpleCollection<string> AV11EmployeeEmails ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV17DeleteExceptions ,
                                             long A100CompanyId ,
                                             long AV14CompanyId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT CompanyId, EmployeeId, EmployeeEmail, GAMUserGUID, EmployeeName FROM Employee";
         AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV11EmployeeEmails, "EmployeeEmail IN (", ")")+")");
         AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV17DeleteExceptions, "EmployeeId IN (", ")")+")");
         AddWhere(sWhereString, "(CompanyId = :AV14CompanyId)");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmployeeName";
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
                     return conditional_P00863(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] );
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
          Object[] prmP00862;
          prmP00862 = new Object[] {
          new ParDef("AV15StartDate",GXType.Date,8,0) ,
          new ParDef("AV14CompanyId",GXType.Int64,10,0)
          };
          Object[] prmP00863;
          prmP00863 = new Object[] {
          new ParDef("AV14CompanyId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00862", "SELECT DISTINCT NULL AS CompanyId, NULL AS WorkHourLogDate, EmployeeEmail, EmployeeId, NULL AS EmployeeName FROM ( SELECT T2.CompanyId, T1.WorkHourLogDate, T2.EmployeeEmail, T1.EmployeeId, T2.EmployeeName FROM (WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) WHERE (T1.WorkHourLogDate > :AV15StartDate) AND (T2.CompanyId = :AV14CompanyId) ORDER BY T2.EmployeeName) DistinctT ORDER BY EmployeeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00862,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00863", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00863,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
