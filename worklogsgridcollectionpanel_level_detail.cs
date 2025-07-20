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
   public class worklogsgridcollectionpanel_level_detail : GXDataGridProcedure
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

      public worklogsgridcollectionpanel_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public worklogsgridcollectionpanel_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_gxid ,
                           out SdtWorkLogsGridCollectionPanel_Level_DetailSdt aP1_GXM1WorkLogsGridCollectionPanel_Level_DetailSdt )
      {
         this.AV29gxid = aP0_gxid;
         this.AV33GXM1WorkLogsGridCollectionPanel_Level_DetailSdt = new SdtWorkLogsGridCollectionPanel_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP1_GXM1WorkLogsGridCollectionPanel_Level_DetailSdt=this.AV33GXM1WorkLogsGridCollectionPanel_Level_DetailSdt;
      }

      public SdtWorkLogsGridCollectionPanel_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM1WorkLogsGridCollectionPanel_Level_DetailSdt);
         return AV33GXM1WorkLogsGridCollectionPanel_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtWorkLogsGridCollectionPanel_Level_DetailSdt aP1_GXM1WorkLogsGridCollectionPanel_Level_DetailSdt )
      {
         this.AV29gxid = aP0_gxid;
         this.AV33GXM1WorkLogsGridCollectionPanel_Level_DetailSdt = new SdtWorkLogsGridCollectionPanel_Level_DetailSdt(context) ;
         SubmitImpl();
         aP1_GXM1WorkLogsGridCollectionPanel_Level_DetailSdt=this.AV33GXM1WorkLogsGridCollectionPanel_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV29gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Worklogssdts__workhourlogdate\",\"Visible\",\"" + "False" + "\"]";
            Gxwebsession.Set(Gxids, "true");
         }
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV7WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV34GXV1 = 1;
         while ( AV34GXV1 <= AV16WorkLogsSDTs.Count )
         {
            AV16WorkLogsSDTs.CurrentItem = ((SdtWorkLogsSDT)AV16WorkLogsSDTs.Item(AV34GXV1));
            AV34GXV1 = (int)(AV34GXV1+1);
         }
         AV33GXM1WorkLogsGridCollectionPanel_Level_DetailSdt.gxTpr_Worklogssdts = AV16WorkLogsSDTs;
         AV33GXM1WorkLogsGridCollectionPanel_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
         Gxdynprop = "";
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
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
         AV33GXM1WorkLogsGridCollectionPanel_Level_DetailSdt = new SdtWorkLogsGridCollectionPanel_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         Gxdynprop = "";
         AV7WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV16WorkLogsSDTs = new GXBaseCollection<SdtWorkLogsSDT>( context, "WorkLogsSDT", "");
         /* GeneXus formulas. */
      }

      private int AV29gxid ;
      private int AV34GXV1 ;
      private string Gxids ;
      private bool returnInSub ;
      private string Gxdynprop ;
      private IGxSession Gxwebsession ;
      private SdtWorkLogsGridCollectionPanel_Level_DetailSdt AV33GXM1WorkLogsGridCollectionPanel_Level_DetailSdt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV7WWPContext ;
      private GXBaseCollection<SdtWorkLogsSDT> AV16WorkLogsSDTs ;
      private SdtWorkLogsGridCollectionPanel_Level_DetailSdt aP1_GXM1WorkLogsGridCollectionPanel_Level_DetailSdt ;
   }

}
