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
   public class dpemployeesbyproject : GXProcedure
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

      public dpemployeesbyproject( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpemployeesbyproject( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GxSimpleCollection<long> aP0_EmployeeIds ,
                           out GXBaseCollection<SdtSDTEmployee> aP1_Gxm2rootcol )
      {
         this.AV5EmployeeIds = aP0_EmployeeIds;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTEmployee>( context, "SDTEmployee", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTEmployee> executeUdp( GxSimpleCollection<long> aP0_EmployeeIds )
      {
         execute(aP0_EmployeeIds, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( GxSimpleCollection<long> aP0_EmployeeIds ,
                                 out GXBaseCollection<SdtSDTEmployee> aP1_Gxm2rootcol )
      {
         this.AV5EmployeeIds = aP0_EmployeeIds;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTEmployee>( context, "SDTEmployee", "YTT_version4") ;
         SubmitImpl();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV5EmployeeIds ,
                                              AV5EmployeeIds.Count } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT
                                              }
         });
         /* Using cursor P00132 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00132_A106EmployeeId[0];
            A107EmployeeFirstName = P00132_A107EmployeeFirstName[0];
            A108EmployeeLastName = P00132_A108EmployeeLastName[0];
            A148EmployeeName = P00132_A148EmployeeName[0];
            A109EmployeeEmail = P00132_A109EmployeeEmail[0];
            A100CompanyId = P00132_A100CompanyId[0];
            A101CompanyName = P00132_A101CompanyName[0];
            A110EmployeeIsManager = P00132_A110EmployeeIsManager[0];
            A111GAMUserGUID = P00132_A111GAMUserGUID[0];
            A112EmployeeIsActive = P00132_A112EmployeeIsActive[0];
            A146EmployeeVactionDays = P00132_A146EmployeeVactionDays[0];
            A147EmployeeBalance = P00132_A147EmployeeBalance[0];
            A101CompanyName = P00132_A101CompanyName[0];
            Gxm1sdtemployee = new SdtSDTEmployee(context);
            Gxm2rootcol.Add(Gxm1sdtemployee, 0);
            Gxm1sdtemployee.gxTpr_Employeeid = A106EmployeeId;
            Gxm1sdtemployee.gxTpr_Employeefirstname = A107EmployeeFirstName;
            Gxm1sdtemployee.gxTpr_Employeelastname = A108EmployeeLastName;
            Gxm1sdtemployee.gxTpr_Employeename = A148EmployeeName;
            Gxm1sdtemployee.gxTpr_Employeeemail = A109EmployeeEmail;
            Gxm1sdtemployee.gxTpr_Companyid = A100CompanyId;
            Gxm1sdtemployee.gxTpr_Companyname = A101CompanyName;
            Gxm1sdtemployee.gxTpr_Employeeismanager = A110EmployeeIsManager;
            Gxm1sdtemployee.gxTpr_Gamuserguid = A111GAMUserGUID;
            Gxm1sdtemployee.gxTpr_Employeeisactive = A112EmployeeIsActive;
            Gxm1sdtemployee.gxTpr_Employeevactiondays = A146EmployeeVactionDays;
            Gxm1sdtemployee.gxTpr_Employeebalance = A147EmployeeBalance;
            /* Using cursor P00133 */
            pr_default.execute(1, new Object[] {A106EmployeeId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A162ProjectManagerId = P00133_A162ProjectManagerId[0];
               n162ProjectManagerId = P00133_n162ProjectManagerId[0];
               A102ProjectId = P00133_A102ProjectId[0];
               A103ProjectName = P00133_A103ProjectName[0];
               Gxm3sdtemployee_project = new SdtSDTEmployee_ProjectItem(context);
               Gxm1sdtemployee.gxTpr_Project.Add(Gxm3sdtemployee_project, 0);
               Gxm3sdtemployee_project.gxTpr_Projectid = A102ProjectId;
               Gxm3sdtemployee_project.gxTpr_Projectname = A103ProjectName;
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
         P00132_A106EmployeeId = new long[1] ;
         P00132_A107EmployeeFirstName = new string[] {""} ;
         P00132_A108EmployeeLastName = new string[] {""} ;
         P00132_A148EmployeeName = new string[] {""} ;
         P00132_A109EmployeeEmail = new string[] {""} ;
         P00132_A100CompanyId = new long[1] ;
         P00132_A101CompanyName = new string[] {""} ;
         P00132_A110EmployeeIsManager = new bool[] {false} ;
         P00132_A111GAMUserGUID = new string[] {""} ;
         P00132_A112EmployeeIsActive = new bool[] {false} ;
         P00132_A146EmployeeVactionDays = new decimal[1] ;
         P00132_A147EmployeeBalance = new decimal[1] ;
         A107EmployeeFirstName = "";
         A108EmployeeLastName = "";
         A148EmployeeName = "";
         A109EmployeeEmail = "";
         A101CompanyName = "";
         A111GAMUserGUID = "";
         Gxm1sdtemployee = new SdtSDTEmployee(context);
         P00133_A162ProjectManagerId = new long[1] ;
         P00133_n162ProjectManagerId = new bool[] {false} ;
         P00133_A102ProjectId = new long[1] ;
         P00133_A103ProjectName = new string[] {""} ;
         A103ProjectName = "";
         Gxm3sdtemployee_project = new SdtSDTEmployee_ProjectItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpemployeesbyproject__default(),
            new Object[][] {
                new Object[] {
               P00132_A106EmployeeId, P00132_A107EmployeeFirstName, P00132_A108EmployeeLastName, P00132_A148EmployeeName, P00132_A109EmployeeEmail, P00132_A100CompanyId, P00132_A101CompanyName, P00132_A110EmployeeIsManager, P00132_A111GAMUserGUID, P00132_A112EmployeeIsActive,
               P00132_A146EmployeeVactionDays, P00132_A147EmployeeBalance
               }
               , new Object[] {
               P00133_A162ProjectManagerId, P00133_n162ProjectManagerId, P00133_A102ProjectId, P00133_A103ProjectName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV5EmployeeIds_Count ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long A162ProjectManagerId ;
      private long A102ProjectId ;
      private decimal A146EmployeeVactionDays ;
      private decimal A147EmployeeBalance ;
      private string A107EmployeeFirstName ;
      private string A108EmployeeLastName ;
      private string A148EmployeeName ;
      private string A101CompanyName ;
      private string A103ProjectName ;
      private bool A110EmployeeIsManager ;
      private bool A112EmployeeIsActive ;
      private bool n162ProjectManagerId ;
      private string A109EmployeeEmail ;
      private string A111GAMUserGUID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV5EmployeeIds ;
      private GXBaseCollection<SdtSDTEmployee> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private long[] P00132_A106EmployeeId ;
      private string[] P00132_A107EmployeeFirstName ;
      private string[] P00132_A108EmployeeLastName ;
      private string[] P00132_A148EmployeeName ;
      private string[] P00132_A109EmployeeEmail ;
      private long[] P00132_A100CompanyId ;
      private string[] P00132_A101CompanyName ;
      private bool[] P00132_A110EmployeeIsManager ;
      private string[] P00132_A111GAMUserGUID ;
      private bool[] P00132_A112EmployeeIsActive ;
      private decimal[] P00132_A146EmployeeVactionDays ;
      private decimal[] P00132_A147EmployeeBalance ;
      private SdtSDTEmployee Gxm1sdtemployee ;
      private long[] P00133_A162ProjectManagerId ;
      private bool[] P00133_n162ProjectManagerId ;
      private long[] P00133_A102ProjectId ;
      private string[] P00133_A103ProjectName ;
      private SdtSDTEmployee_ProjectItem Gxm3sdtemployee_project ;
      private GXBaseCollection<SdtSDTEmployee> aP1_Gxm2rootcol ;
   }

   public class dpemployeesbyproject__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00132( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV5EmployeeIds ,
                                             int AV5EmployeeIds_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object1 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T1.EmployeeFirstName, T1.EmployeeLastName, T1.EmployeeName, T1.EmployeeEmail, T1.CompanyId, T2.CompanyName, T1.EmployeeIsManager, T1.GAMUserGUID, T1.EmployeeIsActive, T1.EmployeeVactionDays, T1.EmployeeBalance FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         if ( AV5EmployeeIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV5EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId";
         GXv_Object1[0] = scmdbuf;
         return GXv_Object1 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00132(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] );
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
          Object[] prmP00133;
          prmP00133 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP00132;
          prmP00132 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00132", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00132,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00133", "SELECT ProjectManagerId, ProjectId, ProjectName FROM Project WHERE ProjectManagerId = :EmployeeId ORDER BY ProjectManagerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00133,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((bool[]) buf[9])[0] = rslt.getBool(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
