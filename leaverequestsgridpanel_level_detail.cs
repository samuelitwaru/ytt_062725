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
   public class leaverequestsgridpanel_level_detail : GXDataGridProcedure
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

      public leaverequestsgridpanel_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public leaverequestsgridpanel_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_gxid ,
                           out SdtLeaveRequestsGridPanel_Level_DetailSdt aP1_GXM1LeaveRequestsGridPanel_Level_DetailSdt )
      {
         this.AV22gxid = aP0_gxid;
         this.AV26GXM1LeaveRequestsGridPanel_Level_DetailSdt = new SdtLeaveRequestsGridPanel_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP1_GXM1LeaveRequestsGridPanel_Level_DetailSdt=this.AV26GXM1LeaveRequestsGridPanel_Level_DetailSdt;
      }

      public SdtLeaveRequestsGridPanel_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM1LeaveRequestsGridPanel_Level_DetailSdt);
         return AV26GXM1LeaveRequestsGridPanel_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtLeaveRequestsGridPanel_Level_DetailSdt aP1_GXM1LeaveRequestsGridPanel_Level_DetailSdt )
      {
         this.AV22gxid = aP0_gxid;
         this.AV26GXM1LeaveRequestsGridPanel_Level_DetailSdt = new SdtLeaveRequestsGridPanel_Level_DetailSdt(context) ;
         SubmitImpl();
         aP1_GXM1LeaveRequestsGridPanel_Level_DetailSdt=this.AV26GXM1LeaveRequestsGridPanel_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV22gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"LeaveRequestId\",\"Visible\",\"" + "False" + "\"]";
            AV15MsgVar = "Record Deleted.";
            Gxwebsession.Set(Gxids+"gxvar_Leaveinfo", AV9LeaveInfo);
            Gxwebsession.Set(Gxids+"gxvar_Leaveperiod", AV20LeavePeriod);
            Gxwebsession.Set(Gxids+"gxvar_Msgvar", AV15MsgVar);
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV15MsgVar = Gxwebsession.Get(Gxids+"gxvar_Msgvar");
         }
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV7WWPContext) ;
         AV26GXM1LeaveRequestsGridPanel_Level_DetailSdt.gxTpr_Msgvar = AV15MsgVar;
         AV26GXM1LeaveRequestsGridPanel_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
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
         AV26GXM1LeaveRequestsGridPanel_Level_DetailSdt = new SdtLeaveRequestsGridPanel_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         Gxdynprop = "";
         AV15MsgVar = "";
         AV9LeaveInfo = "";
         AV20LeavePeriod = "";
         AV7WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         /* GeneXus formulas. */
      }

      private int AV22gxid ;
      private string Gxids ;
      private string AV15MsgVar ;
      private string AV9LeaveInfo ;
      private string Gxdynprop ;
      private string AV20LeavePeriod ;
      private IGxSession Gxwebsession ;
      private SdtLeaveRequestsGridPanel_Level_DetailSdt AV26GXM1LeaveRequestsGridPanel_Level_DetailSdt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV7WWPContext ;
      private SdtLeaveRequestsGridPanel_Level_DetailSdt aP1_GXM1LeaveRequestsGridPanel_Level_DetailSdt ;
   }

}
