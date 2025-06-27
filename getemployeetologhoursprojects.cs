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
   public class getemployeetologhoursprojects : GXProcedure
   {
      public getemployeetologhoursprojects( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getemployeetologhoursprojects( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           out GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> aP1_SDTEmployeeProject )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV14SDTEmployeeProject = new GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem>( context, "SDTEmployeeProjectItem", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP1_SDTEmployeeProject=this.AV14SDTEmployeeProject;
      }

      public GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> executeUdp( long aP0_EmployeeId )
      {
         execute(aP0_EmployeeId, out aP1_SDTEmployeeProject);
         return AV14SDTEmployeeProject ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 out GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> aP1_SDTEmployeeProject )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV14SDTEmployeeProject = new GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem>( context, "SDTEmployeeProjectItem", "YTT_version4") ;
         SubmitImpl();
         aP1_SDTEmployeeProject=this.AV14SDTEmployeeProject;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_int1 = AV11FormWorkHourLogEmployeeId;
         new getloggedinemployeeid(context ).execute( out  GXt_int1) ;
         AV11FormWorkHourLogEmployeeId = GXt_int1;
         AV9IsManager = AV13GAMUser.checkrole("Manager");
         AV10IsProjectManager = AV13GAMUser.checkrole("Project Manager");
         if ( ( AV11FormWorkHourLogEmployeeId == AV8EmployeeId ) || ( AV9IsManager ) )
         {
            /* Using cursor P00B12 */
            pr_default.execute(0, new Object[] {AV8EmployeeId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A184EmployeeIsActiveInProject = P00B12_A184EmployeeIsActiveInProject[0];
               A105ProjectStatus = P00B12_A105ProjectStatus[0];
               A106EmployeeId = P00B12_A106EmployeeId[0];
               A102ProjectId = P00B12_A102ProjectId[0];
               A103ProjectName = P00B12_A103ProjectName[0];
               A104ProjectDescription = P00B12_A104ProjectDescription[0];
               A105ProjectStatus = P00B12_A105ProjectStatus[0];
               A103ProjectName = P00B12_A103ProjectName[0];
               A104ProjectDescription = P00B12_A104ProjectDescription[0];
               AV12SDTEmployeeProjectItem = new SdtSDTEmployeeProject_SDTEmployeeProjectItem(context);
               AV12SDTEmployeeProjectItem.gxTpr_Projectid = A102ProjectId;
               AV12SDTEmployeeProjectItem.gxTpr_Projectname = A103ProjectName;
               AV12SDTEmployeeProjectItem.gxTpr_Projectdescription = A104ProjectDescription;
               AV12SDTEmployeeProjectItem.gxTpr_Projectstatus = A105ProjectStatus;
               AV14SDTEmployeeProject.Add(AV12SDTEmployeeProjectItem, 0);
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else if ( ( AV10IsProjectManager ) && ! AV9IsManager )
         {
            GXt_objcol_int2 = AV15projectIds;
            new projectsformanager(context ).execute(  AV11FormWorkHourLogEmployeeId, out  GXt_objcol_int2) ;
            AV15projectIds = GXt_objcol_int2;
            GXt_objcol_int2 = AV16Employees;
            new getemployeeidsbyproject(context ).execute(  AV15projectIds, out  GXt_objcol_int2) ;
            AV16Employees = GXt_objcol_int2;
            AV14SDTEmployeeProject = new GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem>( context, "SDTEmployeeProjectItem", "YTT_version4");
            AV19GXV1 = 1;
            while ( AV19GXV1 <= AV16Employees.Count )
            {
               AV17Employee = (long)(AV16Employees.GetNumeric(AV19GXV1));
               if ( AV17Employee == AV8EmployeeId )
               {
                  AV14SDTEmployeeProject = new GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem>( context, "SDTEmployeeProjectItem", "YTT_version4");
                  pr_default.dynParam(1, new Object[]{ new Object[]{
                                                       A102ProjectId ,
                                                       AV15projectIds ,
                                                       A105ProjectStatus ,
                                                       A184EmployeeIsActiveInProject ,
                                                       AV8EmployeeId ,
                                                       A106EmployeeId } ,
                                                       new int[]{
                                                       TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                                       }
                  });
                  /* Using cursor P00B13 */
                  pr_default.execute(1, new Object[] {AV8EmployeeId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A184EmployeeIsActiveInProject = P00B13_A184EmployeeIsActiveInProject[0];
                     A105ProjectStatus = P00B13_A105ProjectStatus[0];
                     A102ProjectId = P00B13_A102ProjectId[0];
                     A106EmployeeId = P00B13_A106EmployeeId[0];
                     A103ProjectName = P00B13_A103ProjectName[0];
                     A104ProjectDescription = P00B13_A104ProjectDescription[0];
                     A105ProjectStatus = P00B13_A105ProjectStatus[0];
                     A103ProjectName = P00B13_A103ProjectName[0];
                     A104ProjectDescription = P00B13_A104ProjectDescription[0];
                     AV12SDTEmployeeProjectItem = new SdtSDTEmployeeProject_SDTEmployeeProjectItem(context);
                     AV12SDTEmployeeProjectItem.gxTpr_Projectid = A102ProjectId;
                     AV12SDTEmployeeProjectItem.gxTpr_Projectname = A103ProjectName;
                     AV12SDTEmployeeProjectItem.gxTpr_Projectdescription = A104ProjectDescription;
                     AV12SDTEmployeeProjectItem.gxTpr_Projectstatus = A105ProjectStatus;
                     AV14SDTEmployeeProject.Add(AV12SDTEmployeeProjectItem, 0);
                     pr_default.readNext(1);
                  }
                  pr_default.close(1);
               }
               AV19GXV1 = (int)(AV19GXV1+1);
            }
            new logtofilecopy1(context ).execute(  AV15projectIds.ToJSonString(false)) ;
            new logtofilecopy1(context ).execute(  AV16Employees.ToJSonString(false)) ;
            new logtofilecopy1(context ).execute(  AV14SDTEmployeeProject.ToJSonString(false)) ;
         }
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
         AV14SDTEmployeeProject = new GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem>( context, "SDTEmployeeProjectItem", "YTT_version4");
         AV13GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         P00B12_A184EmployeeIsActiveInProject = new bool[] {false} ;
         P00B12_A105ProjectStatus = new string[] {""} ;
         P00B12_A106EmployeeId = new long[1] ;
         P00B12_A102ProjectId = new long[1] ;
         P00B12_A103ProjectName = new string[] {""} ;
         P00B12_A104ProjectDescription = new string[] {""} ;
         A105ProjectStatus = "";
         A103ProjectName = "";
         A104ProjectDescription = "";
         AV12SDTEmployeeProjectItem = new SdtSDTEmployeeProject_SDTEmployeeProjectItem(context);
         AV15projectIds = new GxSimpleCollection<long>();
         AV16Employees = new GxSimpleCollection<long>();
         GXt_objcol_int2 = new GxSimpleCollection<long>();
         P00B13_A184EmployeeIsActiveInProject = new bool[] {false} ;
         P00B13_A105ProjectStatus = new string[] {""} ;
         P00B13_A102ProjectId = new long[1] ;
         P00B13_A106EmployeeId = new long[1] ;
         P00B13_A103ProjectName = new string[] {""} ;
         P00B13_A104ProjectDescription = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getemployeetologhoursprojects__default(),
            new Object[][] {
                new Object[] {
               P00B12_A184EmployeeIsActiveInProject, P00B12_A105ProjectStatus, P00B12_A106EmployeeId, P00B12_A102ProjectId, P00B12_A103ProjectName, P00B12_A104ProjectDescription
               }
               , new Object[] {
               P00B13_A184EmployeeIsActiveInProject, P00B13_A105ProjectStatus, P00B13_A102ProjectId, P00B13_A106EmployeeId, P00B13_A103ProjectName, P00B13_A104ProjectDescription
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV19GXV1 ;
      private long AV8EmployeeId ;
      private long AV11FormWorkHourLogEmployeeId ;
      private long GXt_int1 ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long AV17Employee ;
      private string A105ProjectStatus ;
      private string A103ProjectName ;
      private bool AV9IsManager ;
      private bool AV10IsProjectManager ;
      private bool A184EmployeeIsActiveInProject ;
      private string A104ProjectDescription ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> AV14SDTEmployeeProject ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV13GAMUser ;
      private IDataStoreProvider pr_default ;
      private bool[] P00B12_A184EmployeeIsActiveInProject ;
      private string[] P00B12_A105ProjectStatus ;
      private long[] P00B12_A106EmployeeId ;
      private long[] P00B12_A102ProjectId ;
      private string[] P00B12_A103ProjectName ;
      private string[] P00B12_A104ProjectDescription ;
      private SdtSDTEmployeeProject_SDTEmployeeProjectItem AV12SDTEmployeeProjectItem ;
      private GxSimpleCollection<long> AV15projectIds ;
      private GxSimpleCollection<long> AV16Employees ;
      private GxSimpleCollection<long> GXt_objcol_int2 ;
      private bool[] P00B13_A184EmployeeIsActiveInProject ;
      private string[] P00B13_A105ProjectStatus ;
      private long[] P00B13_A102ProjectId ;
      private long[] P00B13_A106EmployeeId ;
      private string[] P00B13_A103ProjectName ;
      private string[] P00B13_A104ProjectDescription ;
      private GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> aP1_SDTEmployeeProject ;
   }

   public class getemployeetologhoursprojects__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00B13( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV15projectIds ,
                                             string A105ProjectStatus ,
                                             bool A184EmployeeIsActiveInProject ,
                                             long AV8EmployeeId ,
                                             long A106EmployeeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeIsActiveInProject, T2.ProjectStatus, T1.ProjectId, T1.EmployeeId, T2.ProjectName, T2.ProjectDescription FROM (EmployeeProject T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV8EmployeeId)");
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV15projectIds, "T1.ProjectId IN (", ")")+")");
         AddWhere(sWhereString, "(T2.ProjectStatus = ( 'Active'))");
         AddWhere(sWhereString, "(T1.EmployeeIsActiveInProject = TRUE)");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00B13(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] );
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
          Object[] prmP00B12;
          prmP00B12 = new Object[] {
          new ParDef("AV8EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP00B13;
          prmP00B13 = new Object[] {
          new ParDef("AV8EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B12", "SELECT T1.EmployeeIsActiveInProject, T2.ProjectStatus, T1.EmployeeId, T1.ProjectId, T2.ProjectName, T2.ProjectDescription FROM (EmployeeProject T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) WHERE (T1.EmployeeId = :AV8EmployeeId) AND (T2.ProjectStatus = ( 'Active')) AND (T1.EmployeeIsActiveInProject = TRUE) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B12,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00B13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B13,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
       }
    }

 }

}
