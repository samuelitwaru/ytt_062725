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
   public class leaverequestsgridpanelview_level_detail : GXDataGridProcedure
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

      protected override string ExecutePermissionPrefix
      {
         get {
            return "leaverequestsgridpanelview_Execute" ;
         }

      }

      public leaverequestsgridpanelview_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public leaverequestsgridpanelview_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_LeaveRequestId ,
                           string aP1_TabCode ,
                           int aP2_gxid ,
                           out SdtLeaveRequestsGridPanelView_Level_DetailSdt aP3_GXM2LeaveRequestsGridPanelView_Level_DetailSdt )
      {
         this.AV10LeaveRequestId = aP0_LeaveRequestId;
         this.AV8TabCode = aP1_TabCode;
         this.AV14gxid = aP2_gxid;
         this.AV19GXM2LeaveRequestsGridPanelView_Level_DetailSdt = new SdtLeaveRequestsGridPanelView_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP3_GXM2LeaveRequestsGridPanelView_Level_DetailSdt=this.AV19GXM2LeaveRequestsGridPanelView_Level_DetailSdt;
      }

      public SdtLeaveRequestsGridPanelView_Level_DetailSdt executeUdp( long aP0_LeaveRequestId ,
                                                                       string aP1_TabCode ,
                                                                       int aP2_gxid )
      {
         execute(aP0_LeaveRequestId, aP1_TabCode, aP2_gxid, out aP3_GXM2LeaveRequestsGridPanelView_Level_DetailSdt);
         return AV19GXM2LeaveRequestsGridPanelView_Level_DetailSdt ;
      }

      public void executeSubmit( long aP0_LeaveRequestId ,
                                 string aP1_TabCode ,
                                 int aP2_gxid ,
                                 out SdtLeaveRequestsGridPanelView_Level_DetailSdt aP3_GXM2LeaveRequestsGridPanelView_Level_DetailSdt )
      {
         this.AV10LeaveRequestId = aP0_LeaveRequestId;
         this.AV8TabCode = aP1_TabCode;
         this.AV14gxid = aP2_gxid;
         this.AV19GXM2LeaveRequestsGridPanelView_Level_DetailSdt = new SdtLeaveRequestsGridPanelView_Level_DetailSdt(context) ;
         SubmitImpl();
         aP3_GXM2LeaveRequestsGridPanelView_Level_DetailSdt=this.AV19GXM2LeaveRequestsGridPanelView_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV14gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
            AV20GXLvl4 = 0;
            /* Using cursor P00002 */
            pr_default.execute(0, new Object[] {AV10LeaveRequestId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A127LeaveRequestId = P00002_A127LeaveRequestId[0];
               A128LeaveRequestDate = P00002_A128LeaveRequestDate[0];
               AV20GXLvl4 = 1;
               Gxdynprop1 = context.localUtil.DToC( A128LeaveRequestDate, 2, "/");
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Form\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop1) + "\"]";
               AV9Exists = true;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            SetPaginationHeaders(((pr_default.getStatus(0) == 101) ? false : true));
            pr_default.close(0);
            if ( AV20GXLvl4 == 0 )
            {
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Form\",\"Caption\",\"" + StringUtil.JSONEncode( "Record not found") + "\"]";
               AV9Exists = false;
            }
            if ( AV9Exists )
            {
               AV12SelectedTabCode = 1;
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Tabs\",\"Activepage\",\"" + StringUtil.JSONEncode( StringUtil.Str( (decimal)(AV12SelectedTabCode), 4, 0)) + "\"]";
            }
            Gxwebsession.Set(Gxids, "true");
         }
         AV19GXM2LeaveRequestsGridPanelView_Level_DetailSdt.gxTpr_Leaverequestid = AV10LeaveRequestId;
         AV19GXM2LeaveRequestsGridPanelView_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
         Gxdynprop = "";
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
         AV19GXM2LeaveRequestsGridPanelView_Level_DetailSdt = new SdtLeaveRequestsGridPanelView_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00002_A127LeaveRequestId = new long[1] ;
         P00002_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         A128LeaveRequestDate = DateTime.MinValue;
         Gxdynprop1 = "";
         Gxdynprop = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestsgridpanelview_level_detail__default(),
            new Object[][] {
                new Object[] {
               P00002_A127LeaveRequestId, P00002_A128LeaveRequestDate
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20GXLvl4 ;
      private short AV12SelectedTabCode ;
      private int AV14gxid ;
      private long AV10LeaveRequestId ;
      private long A127LeaveRequestId ;
      private string AV8TabCode ;
      private string Gxids ;
      private string Gxdynprop1 ;
      private DateTime A128LeaveRequestDate ;
      private bool AV9Exists ;
      private string Gxdynprop ;
      private IGxSession Gxwebsession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtLeaveRequestsGridPanelView_Level_DetailSdt AV19GXM2LeaveRequestsGridPanelView_Level_DetailSdt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private IDataStoreProvider pr_default ;
      private long[] P00002_A127LeaveRequestId ;
      private DateTime[] P00002_A128LeaveRequestDate ;
      private SdtLeaveRequestsGridPanelView_Level_DetailSdt aP3_GXM2LeaveRequestsGridPanelView_Level_DetailSdt ;
   }

   public class leaverequestsgridpanelview_level_detail__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00002;
          prmP00002 = new Object[] {
          new ParDef("AV10LeaveRequestId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00002", "SELECT LeaveRequestId, LeaveRequestDate FROM LeaveRequest WHERE LeaveRequestId = :AV10LeaveRequestId ORDER BY LeaveRequestId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00002,1, GxCacheFrequency.OFF ,false,true )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                return;
       }
    }

 }

}
