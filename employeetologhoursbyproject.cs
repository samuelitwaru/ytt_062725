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
   public class employeetologhoursbyproject : GXProcedure
   {
      public employeetologhoursbyproject( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeetologhoursbyproject( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem> aP0_Employees )
      {
         this.AV9Employees = new GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem>( context, "SDTEmployeeToLogHoursItem", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP0_Employees=this.AV9Employees;
      }

      public GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem> executeUdp( )
      {
         execute(out aP0_Employees);
         return AV9Employees ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem> aP0_Employees )
      {
         this.AV9Employees = new GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem>( context, "SDTEmployeeToLogHoursItem", "YTT_version4") ;
         SubmitImpl();
         aP0_Employees=this.AV9Employees;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_int1 = AV15FormWorkHourLogEmployeeId;
         new getloggedinemployeeid(context ).execute( out  GXt_int1) ;
         AV15FormWorkHourLogEmployeeId = GXt_int1;
         GXt_int1 = AV16CompanyId;
         new getloggedinusercompanyid(context ).execute( out  GXt_int1) ;
         AV16CompanyId = GXt_int1;
         AV14IsManager = AV17GAMUser.checkrole("Manager");
         AV10IsProjectManager = AV17GAMUser.checkrole("Project Manager");
         if ( AV10IsProjectManager )
         {
            GXt_objcol_int2 = AV11ProjectIds;
            new projectsformanager(context ).execute(  AV15FormWorkHourLogEmployeeId, out  GXt_objcol_int2) ;
            AV11ProjectIds = GXt_objcol_int2;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A102ProjectId ,
                                                 AV11ProjectIds ,
                                                 A184EmployeeIsActiveInProject ,
                                                 A112EmployeeIsActive } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor P00B02 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A112EmployeeIsActive = P00B02_A112EmployeeIsActive[0];
               A184EmployeeIsActiveInProject = P00B02_A184EmployeeIsActiveInProject[0];
               A102ProjectId = P00B02_A102ProjectId[0];
               A106EmployeeId = P00B02_A106EmployeeId[0];
               A112EmployeeIsActive = P00B02_A112EmployeeIsActive[0];
               AV12EmployeeIds.Add(A106EmployeeId, 0);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A106EmployeeId ,
                                                 AV12EmployeeIds ,
                                                 A112EmployeeIsActive } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor P00B03 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               A112EmployeeIsActive = P00B03_A112EmployeeIsActive[0];
               A106EmployeeId = P00B03_A106EmployeeId[0];
               A148EmployeeName = P00B03_A148EmployeeName[0];
               AV8Employee = new SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem(context);
               AV8Employee.gxTpr_Sdtemployeeid = A106EmployeeId;
               AV8Employee.gxTpr_Sdtemployeename = A148EmployeeName;
               AV9Employees.Add(AV8Employee, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         if ( AV14IsManager )
         {
            GXt_int1 = AV16CompanyId;
            new getloggedinusercompanyid(context ).execute( out  GXt_int1) ;
            AV16CompanyId = GXt_int1;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 A106EmployeeId ,
                                                 AV12EmployeeIds ,
                                                 A112EmployeeIsActive ,
                                                 AV16CompanyId ,
                                                 A100CompanyId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor P00B04 */
            pr_default.execute(2, new Object[] {AV16CompanyId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A106EmployeeId = P00B04_A106EmployeeId[0];
               A112EmployeeIsActive = P00B04_A112EmployeeIsActive[0];
               A100CompanyId = P00B04_A100CompanyId[0];
               A148EmployeeName = P00B04_A148EmployeeName[0];
               AV8Employee = new SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem(context);
               AV8Employee.gxTpr_Sdtemployeeid = A106EmployeeId;
               AV8Employee.gxTpr_Sdtemployeename = A148EmployeeName;
               AV9Employees.Add(AV8Employee, 0);
               AV12EmployeeIds.Add(A106EmployeeId, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV12EmployeeIds ,
                                              AV15FormWorkHourLogEmployeeId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P00B05 */
         pr_default.execute(3, new Object[] {AV15FormWorkHourLogEmployeeId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A106EmployeeId = P00B05_A106EmployeeId[0];
            A148EmployeeName = P00B05_A148EmployeeName[0];
            AV8Employee = new SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem(context);
            AV8Employee.gxTpr_Sdtemployeeid = A106EmployeeId;
            AV8Employee.gxTpr_Sdtemployeename = A148EmployeeName;
            AV9Employees.Add(AV8Employee, 0);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
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
         AV9Employees = new GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem>( context, "SDTEmployeeToLogHoursItem", "YTT_version4");
         AV17GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV11ProjectIds = new GxSimpleCollection<long>();
         GXt_objcol_int2 = new GxSimpleCollection<long>();
         P00B02_A112EmployeeIsActive = new bool[] {false} ;
         P00B02_A184EmployeeIsActiveInProject = new bool[] {false} ;
         P00B02_A102ProjectId = new long[1] ;
         P00B02_A106EmployeeId = new long[1] ;
         AV12EmployeeIds = new GxSimpleCollection<long>();
         P00B03_A112EmployeeIsActive = new bool[] {false} ;
         P00B03_A106EmployeeId = new long[1] ;
         P00B03_A148EmployeeName = new string[] {""} ;
         A148EmployeeName = "";
         AV8Employee = new SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem(context);
         P00B04_A106EmployeeId = new long[1] ;
         P00B04_A112EmployeeIsActive = new bool[] {false} ;
         P00B04_A100CompanyId = new long[1] ;
         P00B04_A148EmployeeName = new string[] {""} ;
         P00B05_A106EmployeeId = new long[1] ;
         P00B05_A148EmployeeName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeetologhoursbyproject__default(),
            new Object[][] {
                new Object[] {
               P00B02_A112EmployeeIsActive, P00B02_A184EmployeeIsActiveInProject, P00B02_A102ProjectId, P00B02_A106EmployeeId
               }
               , new Object[] {
               P00B03_A112EmployeeIsActive, P00B03_A106EmployeeId, P00B03_A148EmployeeName
               }
               , new Object[] {
               P00B04_A106EmployeeId, P00B04_A112EmployeeIsActive, P00B04_A100CompanyId, P00B04_A148EmployeeName
               }
               , new Object[] {
               P00B05_A106EmployeeId, P00B05_A148EmployeeName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV15FormWorkHourLogEmployeeId ;
      private long AV16CompanyId ;
      private long A102ProjectId ;
      private long A106EmployeeId ;
      private long GXt_int1 ;
      private long A100CompanyId ;
      private string A148EmployeeName ;
      private bool AV14IsManager ;
      private bool AV10IsProjectManager ;
      private bool A184EmployeeIsActiveInProject ;
      private bool A112EmployeeIsActive ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem> AV9Employees ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV17GAMUser ;
      private GxSimpleCollection<long> AV11ProjectIds ;
      private GxSimpleCollection<long> GXt_objcol_int2 ;
      private IDataStoreProvider pr_default ;
      private bool[] P00B02_A112EmployeeIsActive ;
      private bool[] P00B02_A184EmployeeIsActiveInProject ;
      private long[] P00B02_A102ProjectId ;
      private long[] P00B02_A106EmployeeId ;
      private GxSimpleCollection<long> AV12EmployeeIds ;
      private bool[] P00B03_A112EmployeeIsActive ;
      private long[] P00B03_A106EmployeeId ;
      private string[] P00B03_A148EmployeeName ;
      private SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem AV8Employee ;
      private long[] P00B04_A106EmployeeId ;
      private bool[] P00B04_A112EmployeeIsActive ;
      private long[] P00B04_A100CompanyId ;
      private string[] P00B04_A148EmployeeName ;
      private long[] P00B05_A106EmployeeId ;
      private string[] P00B05_A148EmployeeName ;
      private GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem> aP0_Employees ;
   }

   public class employeetologhoursbyproject__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00B02( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV11ProjectIds ,
                                             bool A184EmployeeIsActiveInProject ,
                                             bool A112EmployeeIsActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T2.EmployeeIsActive, T1.EmployeeIsActiveInProject, T1.ProjectId, T1.EmployeeId FROM (EmployeeProject T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV11ProjectIds, "T1.ProjectId IN (", ")")+")");
         AddWhere(sWhereString, "(T1.EmployeeIsActiveInProject = TRUE)");
         AddWhere(sWhereString, "(T2.EmployeeIsActive = TRUE)");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ProjectId";
         GXv_Object3[0] = scmdbuf;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00B03( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV12EmployeeIds ,
                                             bool A112EmployeeIsActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT EmployeeIsActive, EmployeeId, EmployeeName FROM Employee";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV12EmployeeIds, "EmployeeId IN (", ")")+")");
         AddWhere(sWhereString, "(EmployeeIsActive = TRUE)");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmployeeId";
         GXv_Object5[0] = scmdbuf;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00B04( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV12EmployeeIds ,
                                             bool A112EmployeeIsActive ,
                                             long AV16CompanyId ,
                                             long A100CompanyId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[1];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT EmployeeId, EmployeeIsActive, CompanyId, EmployeeName FROM Employee";
         AddWhere(sWhereString, "(CompanyId = :AV16CompanyId)");
         AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV12EmployeeIds, "EmployeeId IN (", ")")+")");
         AddWhere(sWhereString, "(EmployeeIsActive = TRUE)");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CompanyId";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00B05( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV12EmployeeIds ,
                                             long AV15FormWorkHourLogEmployeeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[1];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT EmployeeId, EmployeeName FROM Employee";
         AddWhere(sWhereString, "(EmployeeId = :AV15FormWorkHourLogEmployeeId)");
         AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV12EmployeeIds, "EmployeeId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmployeeId";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00B02(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (bool)dynConstraints[2] , (bool)dynConstraints[3] );
               case 1 :
                     return conditional_P00B03(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (bool)dynConstraints[2] );
               case 2 :
                     return conditional_P00B04(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (bool)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] );
               case 3 :
                     return conditional_P00B05(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] );
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
          Object[] prmP00B02;
          prmP00B02 = new Object[] {
          };
          Object[] prmP00B03;
          prmP00B03 = new Object[] {
          };
          Object[] prmP00B04;
          prmP00B04 = new Object[] {
          new ParDef("AV16CompanyId",GXType.Int64,10,0)
          };
          Object[] prmP00B05;
          prmP00B05 = new Object[] {
          new ParDef("AV15FormWorkHourLogEmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B02", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B02,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00B03", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B03,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00B04", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B04,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00B05", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B05,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
