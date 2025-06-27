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
   public class prc_getemployeetotalhours : GXProcedure
   {
      public prc_getemployeetotalhours( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getemployeetotalhours( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_EmployeeId ,
                           ref DateTime aP1_FromDate ,
                           ref DateTime aP2_ToDate ,
                           ref GxSimpleCollection<long> aP3_ProjectIdCollection ,
                           out long aP4_TotalHours )
      {
         this.AV12EmployeeId = aP0_EmployeeId;
         this.AV10FromDate = aP1_FromDate;
         this.AV11ToDate = aP2_ToDate;
         this.AV8ProjectIdCollection = aP3_ProjectIdCollection;
         this.AV9TotalHours = 0 ;
         initialize();
         ExecuteImpl();
         aP0_EmployeeId=this.AV12EmployeeId;
         aP1_FromDate=this.AV10FromDate;
         aP2_ToDate=this.AV11ToDate;
         aP3_ProjectIdCollection=this.AV8ProjectIdCollection;
         aP4_TotalHours=this.AV9TotalHours;
      }

      public long executeUdp( ref long aP0_EmployeeId ,
                              ref DateTime aP1_FromDate ,
                              ref DateTime aP2_ToDate ,
                              ref GxSimpleCollection<long> aP3_ProjectIdCollection )
      {
         execute(ref aP0_EmployeeId, ref aP1_FromDate, ref aP2_ToDate, ref aP3_ProjectIdCollection, out aP4_TotalHours);
         return AV9TotalHours ;
      }

      public void executeSubmit( ref long aP0_EmployeeId ,
                                 ref DateTime aP1_FromDate ,
                                 ref DateTime aP2_ToDate ,
                                 ref GxSimpleCollection<long> aP3_ProjectIdCollection ,
                                 out long aP4_TotalHours )
      {
         this.AV12EmployeeId = aP0_EmployeeId;
         this.AV10FromDate = aP1_FromDate;
         this.AV11ToDate = aP2_ToDate;
         this.AV8ProjectIdCollection = aP3_ProjectIdCollection;
         this.AV9TotalHours = 0 ;
         SubmitImpl();
         aP0_EmployeeId=this.AV12EmployeeId;
         aP1_FromDate=this.AV10FromDate;
         aP2_ToDate=this.AV11ToDate;
         aP3_ProjectIdCollection=this.AV8ProjectIdCollection;
         aP4_TotalHours=this.AV9TotalHours;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9TotalHours = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV8ProjectIdCollection ,
                                              AV8ProjectIdCollection.Count ,
                                              A119WorkHourLogDate ,
                                              AV10FromDate ,
                                              AV11ToDate ,
                                              AV12EmployeeId ,
                                              A106EmployeeId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P00BO2 */
         pr_default.execute(0, new Object[] {AV12EmployeeId, AV10FromDate, AV11ToDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A119WorkHourLogDate = P00BO2_A119WorkHourLogDate[0];
            A102ProjectId = P00BO2_A102ProjectId[0];
            A106EmployeeId = P00BO2_A106EmployeeId[0];
            A148EmployeeName = P00BO2_A148EmployeeName[0];
            A103ProjectName = P00BO2_A103ProjectName[0];
            A122WorkHourLogMinute = P00BO2_A122WorkHourLogMinute[0];
            A121WorkHourLogHour = P00BO2_A121WorkHourLogHour[0];
            A118WorkHourLogId = P00BO2_A118WorkHourLogId[0];
            A103ProjectName = P00BO2_A103ProjectName[0];
            A148EmployeeName = P00BO2_A148EmployeeName[0];
            new logtofile(context ).execute(  StringUtil.Trim( A148EmployeeName)) ;
            new logtofile(context ).execute(  "    "+StringUtil.Trim( A103ProjectName)) ;
            AV9TotalHours = (long)(AV9TotalHours+((A121WorkHourLogHour*60)+A122WorkHourLogMinute));
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
         A119WorkHourLogDate = DateTime.MinValue;
         P00BO2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00BO2_A102ProjectId = new long[1] ;
         P00BO2_A106EmployeeId = new long[1] ;
         P00BO2_A148EmployeeName = new string[] {""} ;
         P00BO2_A103ProjectName = new string[] {""} ;
         P00BO2_A122WorkHourLogMinute = new short[1] ;
         P00BO2_A121WorkHourLogHour = new short[1] ;
         P00BO2_A118WorkHourLogId = new long[1] ;
         A148EmployeeName = "";
         A103ProjectName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getemployeetotalhours__default(),
            new Object[][] {
                new Object[] {
               P00BO2_A119WorkHourLogDate, P00BO2_A102ProjectId, P00BO2_A106EmployeeId, P00BO2_A148EmployeeName, P00BO2_A103ProjectName, P00BO2_A122WorkHourLogMinute, P00BO2_A121WorkHourLogHour, P00BO2_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A122WorkHourLogMinute ;
      private short A121WorkHourLogHour ;
      private int AV8ProjectIdCollection_Count ;
      private long AV12EmployeeId ;
      private long AV9TotalHours ;
      private long A102ProjectId ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private string A148EmployeeName ;
      private string A103ProjectName ;
      private DateTime AV10FromDate ;
      private DateTime AV11ToDate ;
      private DateTime A119WorkHourLogDate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_EmployeeId ;
      private DateTime aP1_FromDate ;
      private DateTime aP2_ToDate ;
      private GxSimpleCollection<long> AV8ProjectIdCollection ;
      private GxSimpleCollection<long> aP3_ProjectIdCollection ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00BO2_A119WorkHourLogDate ;
      private long[] P00BO2_A102ProjectId ;
      private long[] P00BO2_A106EmployeeId ;
      private string[] P00BO2_A148EmployeeName ;
      private string[] P00BO2_A103ProjectName ;
      private short[] P00BO2_A122WorkHourLogMinute ;
      private short[] P00BO2_A121WorkHourLogHour ;
      private long[] P00BO2_A118WorkHourLogId ;
      private long aP4_TotalHours ;
   }

   public class prc_getemployeetotalhours__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BO2( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV8ProjectIdCollection ,
                                             int AV8ProjectIdCollection_Count ,
                                             DateTime A119WorkHourLogDate ,
                                             DateTime AV10FromDate ,
                                             DateTime AV11ToDate ,
                                             long AV12EmployeeId ,
                                             long A106EmployeeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.WorkHourLogDate, T1.ProjectId, T1.EmployeeId, T3.EmployeeName, T2.ProjectName, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV12EmployeeId)");
         AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV10FromDate)");
         AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV11ToDate)");
         if ( AV8ProjectIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV8ProjectIdCollection, "T1.ProjectId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId";
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
               case 0 :
                     return conditional_P00BO2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BO2;
          prmP00BO2 = new Object[] {
          new ParDef("AV12EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV10FromDate",GXType.Date,8,0) ,
          new ParDef("AV11ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BO2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BO2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
