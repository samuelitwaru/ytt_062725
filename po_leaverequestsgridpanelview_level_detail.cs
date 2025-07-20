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
   public class po_leaverequestsgridpanelview_level_detail : GXDataGridProcedure
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
            return "po_leaverequestsgridpanelview_Execute" ;
         }

      }

      public po_leaverequestsgridpanelview_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public po_leaverequestsgridpanelview_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_LeaveRequestId ,
                           string aP1_TabCode ,
                           int aP2_gxid ,
                           out SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt aP3_GXM2PO_LeaveRequestsGridPanelView_Level_DetailSdt )
      {
         this.AV9LeaveRequestId = aP0_LeaveRequestId;
         this.AV7TabCode = aP1_TabCode;
         this.AV13gxid = aP2_gxid;
         this.AV18GXM2PO_LeaveRequestsGridPanelView_Level_DetailSdt = new SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP3_GXM2PO_LeaveRequestsGridPanelView_Level_DetailSdt=this.AV18GXM2PO_LeaveRequestsGridPanelView_Level_DetailSdt;
      }

      public SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt executeUdp( long aP0_LeaveRequestId ,
                                                                          string aP1_TabCode ,
                                                                          int aP2_gxid )
      {
         execute(aP0_LeaveRequestId, aP1_TabCode, aP2_gxid, out aP3_GXM2PO_LeaveRequestsGridPanelView_Level_DetailSdt);
         return AV18GXM2PO_LeaveRequestsGridPanelView_Level_DetailSdt ;
      }

      public void executeSubmit( long aP0_LeaveRequestId ,
                                 string aP1_TabCode ,
                                 int aP2_gxid ,
                                 out SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt aP3_GXM2PO_LeaveRequestsGridPanelView_Level_DetailSdt )
      {
         this.AV9LeaveRequestId = aP0_LeaveRequestId;
         this.AV7TabCode = aP1_TabCode;
         this.AV13gxid = aP2_gxid;
         this.AV18GXM2PO_LeaveRequestsGridPanelView_Level_DetailSdt = new SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt(context) ;
         SubmitImpl();
         aP3_GXM2PO_LeaveRequestsGridPanelView_Level_DetailSdt=this.AV18GXM2PO_LeaveRequestsGridPanelView_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV13gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
            AV19GXLvl4 = 0;
            /* Using cursor P00002 */
            pr_default.execute(0, new Object[] {AV9LeaveRequestId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A127LeaveRequestId = P00002_A127LeaveRequestId[0];
               A128LeaveRequestDate = P00002_A128LeaveRequestDate[0];
               AV19GXLvl4 = 1;
               Gxdynprop1 = context.localUtil.DToC( A128LeaveRequestDate, 2, "/");
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Form\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop1) + "\"]";
               AV8Exists = true;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            SetPaginationHeaders(((pr_default.getStatus(0) == 101) ? false : true));
            pr_default.close(0);
            if ( AV19GXLvl4 == 0 )
            {
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Form\",\"Caption\",\"" + StringUtil.JSONEncode( "Record not found") + "\"]";
               AV8Exists = false;
            }
            if ( AV8Exists )
            {
               AV11SelectedTabCode = 1;
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Tabs\",\"Activepage\",\"" + StringUtil.JSONEncode( StringUtil.Str( (decimal)(AV11SelectedTabCode), 4, 0)) + "\"]";
            }
            Gxwebsession.Set(Gxids, "true");
         }
         AV18GXM2PO_LeaveRequestsGridPanelView_Level_DetailSdt.gxTpr_Leaverequestid = AV9LeaveRequestId;
         AV18GXM2PO_LeaveRequestsGridPanelView_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
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
         AV18GXM2PO_LeaveRequestsGridPanelView_Level_DetailSdt = new SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00002_A127LeaveRequestId = new long[1] ;
         P00002_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         A128LeaveRequestDate = DateTime.MinValue;
         Gxdynprop1 = "";
         Gxdynprop = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.po_leaverequestsgridpanelview_level_detail__default(),
            new Object[][] {
                new Object[] {
               P00002_A127LeaveRequestId, P00002_A128LeaveRequestDate
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19GXLvl4 ;
      private short AV11SelectedTabCode ;
      private int AV13gxid ;
      private long AV9LeaveRequestId ;
      private long A127LeaveRequestId ;
      private string AV7TabCode ;
      private string Gxids ;
      private string Gxdynprop1 ;
      private DateTime A128LeaveRequestDate ;
      private bool AV8Exists ;
      private string Gxdynprop ;
      private IGxSession Gxwebsession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt AV18GXM2PO_LeaveRequestsGridPanelView_Level_DetailSdt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private IDataStoreProvider pr_default ;
      private long[] P00002_A127LeaveRequestId ;
      private DateTime[] P00002_A128LeaveRequestDate ;
      private SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt aP3_GXM2PO_LeaveRequestsGridPanelView_Level_DetailSdt ;
   }

   public class po_leaverequestsgridpanelview_level_detail__default : DataStoreHelperBase, IDataStoreHelper
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
          new ParDef("AV9LeaveRequestId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00002", "SELECT LeaveRequestId, LeaveRequestDate FROM LeaveRequest WHERE LeaveRequestId = :AV9LeaveRequestId ORDER BY LeaveRequestId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00002,1, GxCacheFrequency.OFF ,false,true )
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
