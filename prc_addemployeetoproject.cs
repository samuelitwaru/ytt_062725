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
   public class prc_addemployeetoproject : GXProcedure
   {
      public prc_addemployeetoproject( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_addemployeetoproject( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           ref long aP1_ProjectId ,
                           ref bool aP2_IsSuccessful )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9ProjectId = aP1_ProjectId;
         this.AV10IsSuccessful = aP2_IsSuccessful;
         initialize();
         ExecuteImpl();
         aP1_ProjectId=this.AV9ProjectId;
         aP2_IsSuccessful=this.AV10IsSuccessful;
      }

      public bool executeUdp( long aP0_EmployeeId ,
                              ref long aP1_ProjectId )
      {
         execute(aP0_EmployeeId, ref aP1_ProjectId, ref aP2_IsSuccessful);
         return AV10IsSuccessful ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 ref long aP1_ProjectId ,
                                 ref bool aP2_IsSuccessful )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9ProjectId = aP1_ProjectId;
         this.AV10IsSuccessful = aP2_IsSuccessful;
         SubmitImpl();
         aP1_ProjectId=this.AV9ProjectId;
         aP2_IsSuccessful=this.AV10IsSuccessful;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10IsSuccessful = false;
         AV15GXLvl2 = 0;
         /* Using cursor P00C12 */
         pr_default.execute(0, new Object[] {AV8EmployeeId, AV9ProjectId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTC12 = 0;
            A102ProjectId = P00C12_A102ProjectId[0];
            A106EmployeeId = P00C12_A106EmployeeId[0];
            A184EmployeeIsActiveInProject = P00C12_A184EmployeeIsActiveInProject[0];
            AV15GXLvl2 = 1;
            A184EmployeeIsActiveInProject = true;
            GXTC12 = 1;
            AV10IsSuccessful = true;
            /* Using cursor P00C13 */
            pr_default.execute(1, new Object[] {A184EmployeeIsActiveInProject, A106EmployeeId, A102ProjectId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("EmployeeProject");
            if ( GXTC12 == 1 )
            {
               context.CommitDataStores("prc_addemployeetoproject",pr_default);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV15GXLvl2 == 0 )
         {
            AV12BC_Employee = new SdtEmployee(context);
            AV12BC_Employee.Load(AV8EmployeeId);
            /* Using cursor P00C14 */
            pr_default.execute(2, new Object[] {AV9ProjectId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A102ProjectId = P00C14_A102ProjectId[0];
               AV13BC_EmployeeProject = new SdtEmployee_Project(context);
               AV13BC_EmployeeProject.gxTpr_Projectid = A102ProjectId;
               AV13BC_EmployeeProject.gxTpr_Employeeisactiveinproject = true;
               new logtofile(context ).execute(  "&BC_EmployeeProject: "+AV13BC_EmployeeProject.ToJSonString(true, true)) ;
               AV12BC_Employee.gxTpr_Project.Add(AV13BC_EmployeeProject, 0);
               AV12BC_Employee.Save();
               if ( AV12BC_Employee.Success() )
               {
                  context.CommitDataStores("prc_addemployeetoproject",pr_default);
                  AV10IsSuccessful = true;
               }
               else
               {
                  AV18GXV2 = 1;
                  AV17GXV1 = AV12BC_Employee.GetMessages();
                  while ( AV18GXV2 <= AV17GXV1.Count )
                  {
                     AV14Message = ((GeneXus.Utils.SdtMessages_Message)AV17GXV1.Item(AV18GXV2));
                     GX_msglist.addItem(AV14Message.gxTpr_Description);
                     AV18GXV2 = (int)(AV18GXV2+1);
                  }
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_addemployeetoproject",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00C12_A102ProjectId = new long[1] ;
         P00C12_A106EmployeeId = new long[1] ;
         P00C12_A184EmployeeIsActiveInProject = new bool[] {false} ;
         AV12BC_Employee = new SdtEmployee(context);
         P00C14_A102ProjectId = new long[1] ;
         AV13BC_EmployeeProject = new SdtEmployee_Project(context);
         AV17GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_addemployeetoproject__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_addemployeetoproject__default(),
            new Object[][] {
                new Object[] {
               P00C12_A102ProjectId, P00C12_A106EmployeeId, P00C12_A184EmployeeIsActiveInProject
               }
               , new Object[] {
               }
               , new Object[] {
               P00C14_A102ProjectId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV15GXLvl2 ;
      private short GXTC12 ;
      private int AV18GXV2 ;
      private long AV8EmployeeId ;
      private long AV9ProjectId ;
      private long A102ProjectId ;
      private long A106EmployeeId ;
      private bool AV10IsSuccessful ;
      private bool A184EmployeeIsActiveInProject ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP1_ProjectId ;
      private bool aP2_IsSuccessful ;
      private IDataStoreProvider pr_default ;
      private long[] P00C12_A102ProjectId ;
      private long[] P00C12_A106EmployeeId ;
      private bool[] P00C12_A184EmployeeIsActiveInProject ;
      private SdtEmployee AV12BC_Employee ;
      private long[] P00C14_A102ProjectId ;
      private SdtEmployee_Project AV13BC_EmployeeProject ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV17GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV14Message ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_addemployeetoproject__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_addemployeetoproject__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new ForEachCursor(def[2])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00C12;
        prmP00C12 = new Object[] {
        new ParDef("AV8EmployeeId",GXType.Int64,10,0) ,
        new ParDef("AV9ProjectId",GXType.Int64,10,0)
        };
        Object[] prmP00C13;
        prmP00C13 = new Object[] {
        new ParDef("EmployeeIsActiveInProject",GXType.Boolean,4,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmP00C14;
        prmP00C14 = new Object[] {
        new ParDef("AV9ProjectId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00C12", "SELECT ProjectId, EmployeeId, EmployeeIsActiveInProject FROM EmployeeProject WHERE EmployeeId = :AV8EmployeeId and ProjectId = :AV9ProjectId ORDER BY EmployeeId, ProjectId  FOR UPDATE OF EmployeeProject",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00C13", "SAVEPOINT gxupdate;UPDATE EmployeeProject SET EmployeeIsActiveInProject=:EmployeeIsActiveInProject  WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00C13)
           ,new CursorDef("P00C14", "SELECT ProjectId FROM Project WHERE ProjectId = :AV9ProjectId ORDER BY ProjectId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C14,1, GxCacheFrequency.OFF ,true,true )
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
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
