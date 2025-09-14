using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class auditconversion : GXProcedure
   {
      public auditconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public auditconversion( IGxContext context )
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
         /* Using cursor AUDITCONVE2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A211Trn_Id = AUDITCONVE2_A211Trn_Id[0];
            A106EmployeeId = AUDITCONVE2_A106EmployeeId[0];
            n106EmployeeId = AUDITCONVE2_n106EmployeeId[0];
            A210SecUserId = AUDITCONVE2_A210SecUserId[0];
            A209AuditAction = AUDITCONVE2_A209AuditAction[0];
            A208AuditShortDescription = AUDITCONVE2_A208AuditShortDescription[0];
            A207AuditDescription = AUDITCONVE2_A207AuditDescription[0];
            A206AuditTableName = AUDITCONVE2_A206AuditTableName[0];
            A205AuditDate = AUDITCONVE2_A205AuditDate[0];
            A204AuditId = AUDITCONVE2_A204AuditId[0];
            /*
               INSERT RECORD ON TABLE GXA0032

            */
            AV2AuditId = A204AuditId;
            AV3AuditDate = A205AuditDate;
            AV4AuditTableName = A206AuditTableName;
            AV5AuditDescription = A207AuditDescription;
            AV6AuditShortDescription = A208AuditShortDescription;
            AV7AuditAction = A209AuditAction;
            AV8SecUserId = A210SecUserId;
            if ( AUDITCONVE2_n106EmployeeId[0] )
            {
               AV9EmployeeId = 0;
            }
            else
            {
               AV9EmployeeId = A106EmployeeId;
            }
            AV10Trn_Id = A211Trn_Id;
            /* Using cursor AUDITCONVE3 */
            pr_default.execute(1, new Object[] {AV2AuditId, AV3AuditDate, AV4AuditTableName, AV5AuditDescription, AV6AuditShortDescription, AV7AuditAction, AV8SecUserId, AV9EmployeeId, AV10Trn_Id});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0032");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
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
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AUDITCONVE2_A211Trn_Id = new string[] {""} ;
         AUDITCONVE2_A106EmployeeId = new long[1] ;
         AUDITCONVE2_n106EmployeeId = new bool[] {false} ;
         AUDITCONVE2_A210SecUserId = new long[1] ;
         AUDITCONVE2_A209AuditAction = new string[] {""} ;
         AUDITCONVE2_A208AuditShortDescription = new string[] {""} ;
         AUDITCONVE2_A207AuditDescription = new string[] {""} ;
         AUDITCONVE2_A206AuditTableName = new string[] {""} ;
         AUDITCONVE2_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         AUDITCONVE2_A204AuditId = new long[1] ;
         A211Trn_Id = "";
         A209AuditAction = "";
         A208AuditShortDescription = "";
         A207AuditDescription = "";
         A206AuditTableName = "";
         A205AuditDate = DateTime.MinValue;
         AV3AuditDate = DateTime.MinValue;
         AV4AuditTableName = "";
         AV5AuditDescription = "";
         AV6AuditShortDescription = "";
         AV7AuditAction = "";
         AV10Trn_Id = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.auditconversion__default(),
            new Object[][] {
                new Object[] {
               AUDITCONVE2_A211Trn_Id, AUDITCONVE2_A106EmployeeId, AUDITCONVE2_n106EmployeeId, AUDITCONVE2_A210SecUserId, AUDITCONVE2_A209AuditAction, AUDITCONVE2_A208AuditShortDescription, AUDITCONVE2_A207AuditDescription, AUDITCONVE2_A206AuditTableName, AUDITCONVE2_A205AuditDate, AUDITCONVE2_A204AuditId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0032 ;
      private long A106EmployeeId ;
      private long A210SecUserId ;
      private long A204AuditId ;
      private long AV2AuditId ;
      private long AV8SecUserId ;
      private long AV9EmployeeId ;
      private string A206AuditTableName ;
      private string AV4AuditTableName ;
      private string Gx_emsg ;
      private DateTime A205AuditDate ;
      private DateTime AV3AuditDate ;
      private bool n106EmployeeId ;
      private string A211Trn_Id ;
      private string A209AuditAction ;
      private string A208AuditShortDescription ;
      private string A207AuditDescription ;
      private string AV5AuditDescription ;
      private string AV6AuditShortDescription ;
      private string AV7AuditAction ;
      private string AV10Trn_Id ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] AUDITCONVE2_A211Trn_Id ;
      private long[] AUDITCONVE2_A106EmployeeId ;
      private bool[] AUDITCONVE2_n106EmployeeId ;
      private long[] AUDITCONVE2_A210SecUserId ;
      private string[] AUDITCONVE2_A209AuditAction ;
      private string[] AUDITCONVE2_A208AuditShortDescription ;
      private string[] AUDITCONVE2_A207AuditDescription ;
      private string[] AUDITCONVE2_A206AuditTableName ;
      private DateTime[] AUDITCONVE2_A205AuditDate ;
      private long[] AUDITCONVE2_A204AuditId ;
   }

   public class auditconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmAUDITCONVE2;
          prmAUDITCONVE2 = new Object[] {
          };
          Object[] prmAUDITCONVE3;
          prmAUDITCONVE3 = new Object[] {
          new ParDef("AV2AuditId",GXType.Int64,10,0) ,
          new ParDef("AV3AuditDate",GXType.Date,8,0) ,
          new ParDef("AV4AuditTableName",GXType.Char,100,0) ,
          new ParDef("AV5AuditDescription",GXType.VarChar,200,0) ,
          new ParDef("AV6AuditShortDescription",GXType.VarChar,200,0) ,
          new ParDef("AV7AuditAction",GXType.VarChar,10,0) ,
          new ParDef("AV8SecUserId",GXType.Int64,10,0) ,
          new ParDef("AV9EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV10Trn_Id",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("AUDITCONVE2", "SELECT Trn_Id, EmployeeId, SecUserId, AuditAction, AuditShortDescription, AuditDescription, AuditTableName, AuditDate, AuditId FROM Audit ORDER BY AuditId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmAUDITCONVE2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("AUDITCONVE3", "INSERT INTO GXA0032(AuditId, AuditDate, AuditTableName, AuditDescription, AuditShortDescription, AuditAction, SecUserId, EmployeeId, Trn_Id) VALUES(:AV2AuditId, :AV3AuditDate, :AV4AuditTableName, :AV5AuditDescription, :AV6AuditShortDescription, :AV7AuditAction, :AV8SecUserId, :AV9EmployeeId, :AV10Trn_Id)", GxErrorMask.GX_NOMASK,prmAUDITCONVE3)
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                return;
       }
    }

 }

}
