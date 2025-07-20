using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class po_leaverequestsgridpanel_level_detail : GXDataGridProcedure
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
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public po_leaverequestsgridpanel_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public po_leaverequestsgridpanel_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_EmployeeId ,
                           int aP1_gxid ,
                           out SdtPO_LeaveRequestsGridPanel_Level_DetailSdt aP2_GXM1PO_LeaveRequestsGridPanel_Level_DetailSdt )
      {
         this.AV14EmployeeId = aP0_EmployeeId;
         this.AV15gxid = aP1_gxid;
         this.AV18GXM1PO_LeaveRequestsGridPanel_Level_DetailSdt = new SdtPO_LeaveRequestsGridPanel_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP2_GXM1PO_LeaveRequestsGridPanel_Level_DetailSdt=this.AV18GXM1PO_LeaveRequestsGridPanel_Level_DetailSdt;
      }

      public SdtPO_LeaveRequestsGridPanel_Level_DetailSdt executeUdp( long aP0_EmployeeId ,
                                                                      int aP1_gxid )
      {
         execute(aP0_EmployeeId, aP1_gxid, out aP2_GXM1PO_LeaveRequestsGridPanel_Level_DetailSdt);
         return AV18GXM1PO_LeaveRequestsGridPanel_Level_DetailSdt ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 int aP1_gxid ,
                                 out SdtPO_LeaveRequestsGridPanel_Level_DetailSdt aP2_GXM1PO_LeaveRequestsGridPanel_Level_DetailSdt )
      {
         this.AV14EmployeeId = aP0_EmployeeId;
         this.AV15gxid = aP1_gxid;
         this.AV18GXM1PO_LeaveRequestsGridPanel_Level_DetailSdt = new SdtPO_LeaveRequestsGridPanel_Level_DetailSdt(context) ;
         SubmitImpl();
         aP2_GXM1PO_LeaveRequestsGridPanel_Level_DetailSdt=this.AV18GXM1PO_LeaveRequestsGridPanel_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV15gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            AV13MsgVar = "Record Deleted.";
            Gxwebsession.Set(Gxids+"gxvar_Leaveinfo", AV9LeaveInfo);
            Gxwebsession.Set(Gxids+"gxvar_Leaveperiod", AV10LeavePeriod);
            Gxwebsession.Set(Gxids+"gxvar_Msgvar", AV13MsgVar);
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV13MsgVar = Gxwebsession.Get(Gxids+"gxvar_Msgvar");
         }
         AV18GXM1PO_LeaveRequestsGridPanel_Level_DetailSdt.gxTpr_Msgvar = AV13MsgVar;
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
         AV18GXM1PO_LeaveRequestsGridPanel_Level_DetailSdt = new SdtPO_LeaveRequestsGridPanel_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV13MsgVar = "";
         AV9LeaveInfo = "";
         AV10LeavePeriod = "";
         /* GeneXus formulas. */
      }

      private int AV15gxid ;
      private long AV14EmployeeId ;
      private string Gxids ;
      private string AV9LeaveInfo ;
      private string AV13MsgVar ;
      private string AV10LeavePeriod ;
      private IGxSession Gxwebsession ;
      private SdtPO_LeaveRequestsGridPanel_Level_DetailSdt AV18GXM1PO_LeaveRequestsGridPanel_Level_DetailSdt ;
      private SdtPO_LeaveRequestsGridPanel_Level_DetailSdt aP2_GXM1PO_LeaveRequestsGridPanel_Level_DetailSdt ;
   }

}
