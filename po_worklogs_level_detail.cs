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
   public class po_worklogs_level_detail : GXDataGridProcedure
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

      public po_worklogs_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public po_worklogs_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( DateTime aP0_LogDate ,
                           int aP1_gxid ,
                           out SdtPO_WorkLogs_Level_DetailSdt aP2_GXM1PO_WorkLogs_Level_DetailSdt )
      {
         this.AV7LogDate = aP0_LogDate;
         this.AV22gxid = aP1_gxid;
         this.AV28GXM1PO_WorkLogs_Level_DetailSdt = new SdtPO_WorkLogs_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP2_GXM1PO_WorkLogs_Level_DetailSdt=this.AV28GXM1PO_WorkLogs_Level_DetailSdt;
      }

      public SdtPO_WorkLogs_Level_DetailSdt executeUdp( DateTime aP0_LogDate ,
                                                        int aP1_gxid )
      {
         execute(aP0_LogDate, aP1_gxid, out aP2_GXM1PO_WorkLogs_Level_DetailSdt);
         return AV28GXM1PO_WorkLogs_Level_DetailSdt ;
      }

      public void executeSubmit( DateTime aP0_LogDate ,
                                 int aP1_gxid ,
                                 out SdtPO_WorkLogs_Level_DetailSdt aP2_GXM1PO_WorkLogs_Level_DetailSdt )
      {
         this.AV7LogDate = aP0_LogDate;
         this.AV22gxid = aP1_gxid;
         this.AV28GXM1PO_WorkLogs_Level_DetailSdt = new SdtPO_WorkLogs_Level_DetailSdt(context) ;
         SubmitImpl();
         aP2_GXM1PO_WorkLogs_Level_DetailSdt=this.AV28GXM1PO_WorkLogs_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV22gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            AV16DateToday = DateTimeUtil.DAdd( Gx_date, (-2));
            AV17MsgVar = "Record Deleted.";
            AV18lateUpdateMsgVar = "This day's records cannot be updated";
            AV19lateDeleteMsgVar = "This day's records cannot be deleted";
            /* Execute user subroutine: 'SHOWLOGGEDDAYS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            Gxwebsession.Set(Gxids+"gxvar_Worklogssdts", AV6WorkLogsSDTs.ToJSonString(false));
            Gxwebsession.Set(Gxids+"gxvar_Datetoday", context.localUtil.DToC( AV16DateToday, 2, "/"));
            Gxwebsession.Set(Gxids+"gxvar_Msgvar", AV17MsgVar);
            Gxwebsession.Set(Gxids+"gxvar_Lateupdatemsgvar", AV18lateUpdateMsgVar);
            Gxwebsession.Set(Gxids+"gxvar_Latedeletemsgvar", AV19lateDeleteMsgVar);
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV6WorkLogsSDTs.FromJSonString(Gxwebsession.Get(Gxids+"gxvar_Worklogssdts"), null);
            AV16DateToday = context.localUtil.CToD( Gxwebsession.Get(Gxids+"gxvar_Datetoday"), 2);
            AV17MsgVar = Gxwebsession.Get(Gxids+"gxvar_Msgvar");
            AV18lateUpdateMsgVar = Gxwebsession.Get(Gxids+"gxvar_Lateupdatemsgvar");
            AV19lateDeleteMsgVar = Gxwebsession.Get(Gxids+"gxvar_Latedeletemsgvar");
         }
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         Gxdynpropparms = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Grid\",\"refresh\"," + Gxdynpropparms.ToJSonString(false) + "]";
         /* Execute user subroutine: 'SHOWLOGGEDDAYS' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV30GXV1 = 1;
         while ( AV30GXV1 <= AV6WorkLogsSDTs.Count )
         {
            AV6WorkLogsSDTs.CurrentItem = ((SdtWorkLogsSDT)AV6WorkLogsSDTs.Item(AV30GXV1));
            AV30GXV1 = (int)(AV30GXV1+1);
         }
         AV28GXM1PO_WorkLogs_Level_DetailSdt.gxTpr_Worklogssdts = AV6WorkLogsSDTs;
         AV28GXM1PO_WorkLogs_Level_DetailSdt.gxTpr_Datetoday = AV16DateToday;
         AV28GXM1PO_WorkLogs_Level_DetailSdt.gxTpr_Lateupdatemsgvar = AV18lateUpdateMsgVar;
         AV28GXM1PO_WorkLogs_Level_DetailSdt.gxTpr_Latedeletemsgvar = AV19lateDeleteMsgVar;
         AV28GXM1PO_WorkLogs_Level_DetailSdt.gxTpr_Msgvar = AV17MsgVar;
         AV28GXM1PO_WorkLogs_Level_DetailSdt.gxTpr_Logdate = AV7LogDate;
         AV28GXM1PO_WorkLogs_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
         Gxdynprop = "";
         AV28GXM1PO_WorkLogs_Level_DetailSdt.gxTpr_Gxdyncall = "[ "+Gxdyncall+" ]";
         Gxdyncall = "";
         Gxwebsession.Set(Gxids+"gxvar_Worklogssdts", AV6WorkLogsSDTs.ToJSonString(false));
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
         AV6WorkLogsSDTs = new GXBaseCollection<SdtWorkLogsSDT>( context, "WorkLogsSDT", "");
         GXt_objcol_SdtWorkLogsSDT1 = AV6WorkLogsSDTs;
         new sdgetloggedworkdays(context ).execute(  AV7LogDate, out  GXt_objcol_SdtWorkLogsSDT1) ;
         AV6WorkLogsSDTs = GXt_objcol_SdtWorkLogsSDT1;
         new logtofile(context ).execute(  "&WorkLogsSDTs : "+AV6WorkLogsSDTs.ToJSonString(false)) ;
      }

      protected void S121( )
      {
         /* 'SHOWLOGGEDDAYS' Routine */
         returnInSub = false;
         AV14WWPCalendarInfo = new GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarInfo(context);
         new getloggedworkdays(context ).execute( out  AV14WWPCalendarInfo) ;
         AV15WWPCalendarInfoJson = AV14WWPCalendarInfo.ToJSonString(false, true);
         Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Calendaruc\",\"Dates\",\"" + StringUtil.JSONEncode( AV15WWPCalendarInfoJson) + "\"]";
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
         AV28GXM1PO_WorkLogs_Level_DetailSdt = new SdtPO_WorkLogs_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV16DateToday = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         AV17MsgVar = "";
         AV18lateUpdateMsgVar = "";
         AV19lateDeleteMsgVar = "";
         AV6WorkLogsSDTs = new GXBaseCollection<SdtWorkLogsSDT>( context, "WorkLogsSDT", "");
         Gxdynpropparms = new GxSimpleCollection<string>();
         Gxdynprop = "";
         Gxdyncall = "";
         GXt_objcol_SdtWorkLogsSDT1 = new GXBaseCollection<SdtWorkLogsSDT>( context, "WorkLogsSDT", "");
         AV14WWPCalendarInfo = new GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarInfo(context);
         AV15WWPCalendarInfoJson = "";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private int AV22gxid ;
      private int AV30GXV1 ;
      private string Gxids ;
      private DateTime AV7LogDate ;
      private DateTime AV16DateToday ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private string AV17MsgVar ;
      private string AV18lateUpdateMsgVar ;
      private string AV19lateDeleteMsgVar ;
      private string Gxdynprop ;
      private string Gxdyncall ;
      private string AV15WWPCalendarInfoJson ;
      private IGxSession Gxwebsession ;
      private SdtPO_WorkLogs_Level_DetailSdt AV28GXM1PO_WorkLogs_Level_DetailSdt ;
      private GXBaseCollection<SdtWorkLogsSDT> AV6WorkLogsSDTs ;
      private GxSimpleCollection<string> Gxdynpropparms ;
      private GXBaseCollection<SdtWorkLogsSDT> GXt_objcol_SdtWorkLogsSDT1 ;
      private GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarInfo AV14WWPCalendarInfo ;
      private SdtPO_WorkLogs_Level_DetailSdt aP2_GXM1PO_WorkLogs_Level_DetailSdt ;
   }

}
