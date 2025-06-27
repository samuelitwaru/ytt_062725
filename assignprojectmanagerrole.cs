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
   public class assignprojectmanagerrole : GXProcedure
   {
      public assignprojectmanagerrole( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public assignprojectmanagerrole( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           long aP1_ProjectId )
      {
         this.AV19EmployeeId = aP0_EmployeeId;
         this.AV20ProjectId = aP1_ProjectId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 long aP1_ProjectId )
      {
         this.AV19EmployeeId = aP0_EmployeeId;
         this.AV20ProjectId = aP1_ProjectId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14Project.Load(AV20ProjectId);
         AV11GAMRole = AV12GAMRepository.getrolebyexternalid("IsProject Manager", out  AV10GAMErrorCollection);
         if ( ! (0==AV14Project.gxTpr_Projectmanagerid) )
         {
            AV15CurrentEmployee.Load(AV14Project.gxTpr_Projectmanagerid);
            AV21GXLvl9 = 0;
            /* Using cursor P008N2 */
            pr_default.execute(0, new Object[] {AV15CurrentEmployee.gxTpr_Employeeid, AV20ProjectId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A162ProjectManagerId = P008N2_A162ProjectManagerId[0];
               n162ProjectManagerId = P008N2_n162ProjectManagerId[0];
               A102ProjectId = P008N2_A102ProjectId[0];
               AV21GXLvl9 = 1;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV21GXLvl9 == 0 )
            {
               AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getbylogin("local", AV15CurrentEmployee.gxTpr_Employeeemail, out  AV10GAMErrorCollection);
               AV9GAMUser.deleterole( AV11GAMRole, out  AV10GAMErrorCollection);
            }
         }
         AV8Employee.Load(AV19EmployeeId);
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getbylogin("local", AV8Employee.gxTpr_Employeeemail, out  AV10GAMErrorCollection);
         AV9GAMUser.addrolebyid( AV11GAMRole.gxTpr_Id, out  AV10GAMErrorCollection);
         context.CommitDataStores("assignprojectmanagerrole",pr_default);
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
         AV14Project = new SdtProject(context);
         AV11GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV10GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV12GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV15CurrentEmployee = new SdtEmployee(context);
         P008N2_A162ProjectManagerId = new long[1] ;
         P008N2_n162ProjectManagerId = new bool[] {false} ;
         P008N2_A102ProjectId = new long[1] ;
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV8Employee = new SdtEmployee(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.assignprojectmanagerrole__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assignprojectmanagerrole__default(),
            new Object[][] {
                new Object[] {
               P008N2_A162ProjectManagerId, P008N2_n162ProjectManagerId, P008N2_A102ProjectId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21GXLvl9 ;
      private long AV19EmployeeId ;
      private long AV20ProjectId ;
      private long A162ProjectManagerId ;
      private long A102ProjectId ;
      private bool n162ProjectManagerId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtProject AV14Project ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV11GAMRole ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV12GAMRepository ;
      private SdtEmployee AV15CurrentEmployee ;
      private IDataStoreProvider pr_default ;
      private long[] P008N2_A162ProjectManagerId ;
      private bool[] P008N2_n162ProjectManagerId ;
      private long[] P008N2_A102ProjectId ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private SdtEmployee AV8Employee ;
      private IDataStoreProvider pr_gam ;
   }

   public class assignprojectmanagerrole__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class assignprojectmanagerrole__default : DataStoreHelperBase, IDataStoreHelper
 {
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
        Object[] prmP008N2;
        prmP008N2 = new Object[] {
        new ParDef("AV15Curr_1Employeeid",GXType.Int64,10,0) ,
        new ParDef("AV20ProjectId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("P008N2", "SELECT ProjectManagerId, ProjectId FROM Project WHERE (ProjectManagerId = :AV15Curr_1Employeeid) AND (ProjectId <> :AV20ProjectId) ORDER BY ProjectManagerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008N2,100, GxCacheFrequency.OFF ,false,false )
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
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((long[]) buf[2])[0] = rslt.getLong(2);
              return;
     }
  }

}

}
