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
   public class aprc_setdays : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_setdays().MainImpl(args); ;
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

      public aprc_setdays( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_setdays( IGxContext context )
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
         /* Using cursor P00AY2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A146EmployeeVactionDays = P00AY2_A146EmployeeVactionDays[0];
            A177EmployeeVacationDaysSetDate = P00AY2_A177EmployeeVacationDaysSetDate[0];
            A106EmployeeId = P00AY2_A106EmployeeId[0];
            /*
               INSERT RECORD ON TABLE EmployeeVacationSet

            */
            A179VacationSetDays = A146EmployeeVactionDays;
            A186VacationSetDate = A177EmployeeVacationDaysSetDate;
            /* Using cursor P00AY3 */
            pr_default.execute(1, new Object[] {A106EmployeeId, A186VacationSetDate, A179VacationSetDays});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("EmployeeVacationSet");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_setdays",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00AY2_A146EmployeeVactionDays = new decimal[1] ;
         P00AY2_A177EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         P00AY2_A106EmployeeId = new long[1] ;
         A177EmployeeVacationDaysSetDate = DateTime.MinValue;
         A186VacationSetDate = DateTime.MinValue;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_setdays__default(),
            new Object[][] {
                new Object[] {
               P00AY2_A146EmployeeVactionDays, P00AY2_A177EmployeeVacationDaysSetDate, P00AY2_A106EmployeeId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GX_INS27 ;
      private long A106EmployeeId ;
      private decimal A146EmployeeVactionDays ;
      private decimal A179VacationSetDays ;
      private string Gx_emsg ;
      private DateTime A177EmployeeVacationDaysSetDate ;
      private DateTime A186VacationSetDate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] P00AY2_A146EmployeeVactionDays ;
      private DateTime[] P00AY2_A177EmployeeVacationDaysSetDate ;
      private long[] P00AY2_A106EmployeeId ;
   }

   public class aprc_setdays__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AY2;
          prmP00AY2 = new Object[] {
          };
          Object[] prmP00AY3;
          prmP00AY3 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0) ,
          new ParDef("VacationSetDate",GXType.Date,8,0) ,
          new ParDef("VacationSetDays",GXType.Number,4,1)
          };
          def= new CursorDef[] {
              new CursorDef("P00AY2", "SELECT EmployeeVactionDays, EmployeeVacationDaysSetDate, EmployeeId FROM Employee ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AY2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AY3", "SAVEPOINT gxupdate;INSERT INTO EmployeeVacationSet(EmployeeId, VacationSetDate, VacationSetDays, VacationSetDescription) VALUES(:EmployeeId, :VacationSetDate, :VacationSetDays, '');RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00AY3)
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
