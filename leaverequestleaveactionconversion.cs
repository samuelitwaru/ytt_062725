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
   public class leaverequestleaveactionconversion : GXProcedure
   {
      public leaverequestleaveactionconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public leaverequestleaveactionconversion( IGxContext context )
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
         /* Using cursor LEAVEREQUE2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A198LeaveActionDescription = LEAVEREQUE2_A198LeaveActionDescription[0];
            A197LeaveActionDateTime = LEAVEREQUE2_A197LeaveActionDateTime[0];
            A196LeaveActionType = LEAVEREQUE2_A196LeaveActionType[0];
            A195LeaveActionId = LEAVEREQUE2_A195LeaveActionId[0];
            A127LeaveRequestId = LEAVEREQUE2_A127LeaveRequestId[0];
            /*
               INSERT RECORD ON TABLE GXA0030

            */
            AV2LeaveRequestId = A127LeaveRequestId;
            AV3LeaveActionId = A195LeaveActionId;
            AV4LeaveActionType = A196LeaveActionType;
            AV5LeaveActionDateTime = A197LeaveActionDateTime;
            AV6LeaveActionDescription = A198LeaveActionDescription;
            AV7LeaveActionGAMUserGUID = Guid.Empty;
            /* Using cursor LEAVEREQUE3 */
            pr_default.execute(1, new Object[] {AV2LeaveRequestId, AV3LeaveActionId, AV4LeaveActionType, AV5LeaveActionDateTime, AV6LeaveActionDescription, AV7LeaveActionGAMUserGUID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0030");
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
         LEAVEREQUE2_A198LeaveActionDescription = new string[] {""} ;
         LEAVEREQUE2_A197LeaveActionDateTime = new DateTime[] {DateTime.MinValue} ;
         LEAVEREQUE2_A196LeaveActionType = new string[] {""} ;
         LEAVEREQUE2_A195LeaveActionId = new long[1] ;
         LEAVEREQUE2_A127LeaveRequestId = new long[1] ;
         A198LeaveActionDescription = "";
         A197LeaveActionDateTime = (DateTime)(DateTime.MinValue);
         A196LeaveActionType = "";
         AV4LeaveActionType = "";
         AV5LeaveActionDateTime = (DateTime)(DateTime.MinValue);
         AV6LeaveActionDescription = "";
         AV7LeaveActionGAMUserGUID = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestleaveactionconversion__default(),
            new Object[][] {
                new Object[] {
               LEAVEREQUE2_A198LeaveActionDescription, LEAVEREQUE2_A197LeaveActionDateTime, LEAVEREQUE2_A196LeaveActionType, LEAVEREQUE2_A195LeaveActionId, LEAVEREQUE2_A127LeaveRequestId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0030 ;
      private long A195LeaveActionId ;
      private long A127LeaveRequestId ;
      private long AV2LeaveRequestId ;
      private long AV3LeaveActionId ;
      private string Gx_emsg ;
      private DateTime A197LeaveActionDateTime ;
      private DateTime AV5LeaveActionDateTime ;
      private string A198LeaveActionDescription ;
      private string A196LeaveActionType ;
      private string AV4LeaveActionType ;
      private string AV6LeaveActionDescription ;
      private Guid AV7LeaveActionGAMUserGUID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] LEAVEREQUE2_A198LeaveActionDescription ;
      private DateTime[] LEAVEREQUE2_A197LeaveActionDateTime ;
      private string[] LEAVEREQUE2_A196LeaveActionType ;
      private long[] LEAVEREQUE2_A195LeaveActionId ;
      private long[] LEAVEREQUE2_A127LeaveRequestId ;
   }

   public class leaverequestleaveactionconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmLEAVEREQUE2;
          prmLEAVEREQUE2 = new Object[] {
          };
          Object[] prmLEAVEREQUE3;
          prmLEAVEREQUE3 = new Object[] {
          new ParDef("AV2LeaveRequestId",GXType.Int64,10,0) ,
          new ParDef("AV3LeaveActionId",GXType.Int64,10,0) ,
          new ParDef("AV4LeaveActionType",GXType.VarChar,40,0) ,
          new ParDef("AV5LeaveActionDateTime",GXType.DateTime,8,5) ,
          new ParDef("AV6LeaveActionDescription",GXType.VarChar,200,0) ,
          new ParDef("AV7LeaveActionGAMUserGUID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("LEAVEREQUE2", "SELECT LeaveActionDescription, LeaveActionDateTime, LeaveActionType, LeaveActionId, LeaveRequestId FROM LeaveRequestLeaveAction ORDER BY LeaveRequestId, LeaveActionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLEAVEREQUE2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("LEAVEREQUE3", "INSERT INTO GXA0030(LeaveRequestId, LeaveActionId, LeaveActionType, LeaveActionDateTime, LeaveActionDescription, LeaveActionGAMUserGUID) VALUES(:AV2LeaveRequestId, :AV3LeaveActionId, :AV4LeaveActionType, :AV5LeaveActionDateTime, :AV6LeaveActionDescription, :AV7LeaveActionGAMUserGUID)", GxErrorMask.GX_NOMASK,prmLEAVEREQUE3)
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
