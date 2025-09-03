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
   public class prc_employeehasleave : GXProcedure
   {
      public prc_employeehasleave( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_employeehasleave( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           long aP1_LeaveRequestId ,
                           DateTime aP2_FromDate ,
                           DateTime aP3_ToDate ,
                           out bool aP4_HasLeave )
      {
         this.AV10EmployeeId = aP0_EmployeeId;
         this.AV13LeaveRequestId = aP1_LeaveRequestId;
         this.AV8FromDate = aP2_FromDate;
         this.AV9ToDate = aP3_ToDate;
         this.AV11HasLeave = false ;
         initialize();
         ExecuteImpl();
         aP4_HasLeave=this.AV11HasLeave;
      }

      public bool executeUdp( long aP0_EmployeeId ,
                              long aP1_LeaveRequestId ,
                              DateTime aP2_FromDate ,
                              DateTime aP3_ToDate )
      {
         execute(aP0_EmployeeId, aP1_LeaveRequestId, aP2_FromDate, aP3_ToDate, out aP4_HasLeave);
         return AV11HasLeave ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 long aP1_LeaveRequestId ,
                                 DateTime aP2_FromDate ,
                                 DateTime aP3_ToDate ,
                                 out bool aP4_HasLeave )
      {
         this.AV10EmployeeId = aP0_EmployeeId;
         this.AV13LeaveRequestId = aP1_LeaveRequestId;
         this.AV8FromDate = aP2_FromDate;
         this.AV9ToDate = aP3_ToDate;
         this.AV11HasLeave = false ;
         SubmitImpl();
         aP4_HasLeave=this.AV11HasLeave;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11HasLeave = false;
         AV14GXLvl2 = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV13LeaveRequestId ,
                                              A127LeaveRequestId ,
                                              A129LeaveRequestStartDate ,
                                              AV9ToDate ,
                                              A130LeaveRequestEndDate ,
                                              AV8FromDate ,
                                              AV10EmployeeId ,
                                              A106EmployeeId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P00BR2 */
         pr_default.execute(0, new Object[] {AV10EmployeeId, AV9ToDate, AV8FromDate, AV13LeaveRequestId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A130LeaveRequestEndDate = P00BR2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00BR2_A129LeaveRequestStartDate[0];
            A127LeaveRequestId = P00BR2_A127LeaveRequestId[0];
            A106EmployeeId = P00BR2_A106EmployeeId[0];
            AV14GXLvl2 = 1;
            AV11HasLeave = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV14GXLvl2 == 0 )
         {
            AV11HasLeave = false;
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
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         P00BR2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00BR2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00BR2_A127LeaveRequestId = new long[1] ;
         P00BR2_A106EmployeeId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_employeehasleave__default(),
            new Object[][] {
                new Object[] {
               P00BR2_A130LeaveRequestEndDate, P00BR2_A129LeaveRequestStartDate, P00BR2_A127LeaveRequestId, P00BR2_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14GXLvl2 ;
      private long AV10EmployeeId ;
      private long AV13LeaveRequestId ;
      private long A127LeaveRequestId ;
      private long A106EmployeeId ;
      private DateTime AV8FromDate ;
      private DateTime AV9ToDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool AV11HasLeave ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00BR2_A130LeaveRequestEndDate ;
      private DateTime[] P00BR2_A129LeaveRequestStartDate ;
      private long[] P00BR2_A127LeaveRequestId ;
      private long[] P00BR2_A106EmployeeId ;
      private bool aP4_HasLeave ;
   }

   public class prc_employeehasleave__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BR2( IGxContext context ,
                                             long AV13LeaveRequestId ,
                                             long A127LeaveRequestId ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime AV9ToDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             DateTime AV8FromDate ,
                                             long AV10EmployeeId ,
                                             long A106EmployeeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT LeaveRequestEndDate, LeaveRequestStartDate, LeaveRequestId, EmployeeId FROM LeaveRequest";
         AddWhere(sWhereString, "(EmployeeId = :AV10EmployeeId)");
         AddWhere(sWhereString, "(LeaveRequestStartDate <= :AV9ToDate)");
         AddWhere(sWhereString, "(LeaveRequestEndDate >= :AV8FromDate)");
         if ( ! (0==AV13LeaveRequestId) )
         {
            AddWhere(sWhereString, "(Not LeaveRequestId = :AV13LeaveRequestId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmployeeId";
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
                     return conditional_P00BR2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] );
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
          Object[] prmP00BR2;
          prmP00BR2 = new Object[] {
          new ParDef("AV10EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV9ToDate",GXType.Date,8,0) ,
          new ParDef("AV8FromDate",GXType.Date,8,0) ,
          new ParDef("AV13LeaveRequestId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BR2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BR2,1, GxCacheFrequency.OFF ,false,true )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
