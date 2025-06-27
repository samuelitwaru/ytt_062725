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

      public void execute( DateTime aP0_LogDate ,
                           int aP1_gxid ,
                           out SdtWorkLogsGridCollectionPanel_Level_DetailSdt aP2_GXM1WorkLogsGridCollectionPanel_Level_DetailSdt )
      {
         this.AV10LogDate = aP0_LogDate;
         this.AV29gxid = aP1_gxid;
         this.AV35GXM1WorkLogsGridCollectionPanel_Level_DetailSdt = new SdtWorkLogsGridCollectionPanel_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP2_GXM1WorkLogsGridCollectionPanel_Level_DetailSdt=this.AV35GXM1WorkLogsGridCollectionPanel_Level_DetailSdt;
      }

      public SdtWorkLogsGridCollectionPanel_Level_DetailSdt executeUdp( DateTime aP0_LogDate ,
                                                                        int aP1_gxid )
      {
         execute(aP0_LogDate, aP1_gxid, out aP2_GXM1WorkLogsGridCollectionPanel_Level_DetailSdt);
         return AV35GXM1WorkLogsGridCollectionPanel_Level_DetailSdt ;
      }

      public void executeSubmit( DateTime aP0_LogDate ,
                                 int aP1_gxid ,
                                 out SdtWorkLogsGridCollectionPanel_Level_DetailSdt aP2_GXM1WorkLogsGridCollectionPanel_Level_DetailSdt )
      {
         this.AV10LogDate = aP0_LogDate;
         this.AV29gxid = aP1_gxid;
         this.AV35GXM1WorkLogsGridCollectionPanel_Level_DetailSdt = new SdtWorkLogsGridCollectionPanel_Level_DetailSdt(context) ;
         SubmitImpl();
         aP2_GXM1WorkLogsGridCollectionPanel_Level_DetailSdt=this.AV35GXM1WorkLogsGridCollectionPanel_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV29gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Worklogssdts__workhourlogdate\",\"Visible\",\"" + "False" + "\"]";
            AV21DateToday = DateTimeUtil.DAdd( Gx_date, (-2));
            AV15MsgVar = "Record Deleted.";
            AV22lateUpdateMsgVar = "This day's records cannot be updated";
            AV23lateDeleteMsgVar = "This day's records cannot be deleted";
            /* Execute user subroutine: 'SHOWLOGGEDDAYS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            Gxwebsession.Set(Gxids+"gxvar_Worklogssdts", AV16WorkLogsSDTs.ToJSonString(false));
            Gxwebsession.Set(Gxids+"gxvar_Datetoday", context.localUtil.DToC( AV21DateToday, 2, "/"));
            Gxwebsession.Set(Gxids+"gxvar_Msgvar", AV15MsgVar);
            Gxwebsession.Set(Gxids+"gxvar_Lateupdatemsgvar", AV22lateUpdateMsgVar);
            Gxwebsession.Set(Gxids+"gxvar_Latedeletemsgvar", AV23lateDeleteMsgVar);
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV16WorkLogsSDTs.FromJSonString(Gxwebsession.Get(Gxids+"gxvar_Worklogssdts"), null);
            AV21DateToday = context.localUtil.CToD( Gxwebsession.Get(Gxids+"gxvar_Datetoday"), 2);
            AV15MsgVar = Gxwebsession.Get(Gxids+"gxvar_Msgvar");
            AV22lateUpdateMsgVar = Gxwebsession.Get(Gxids+"gxvar_Lateupdatemsgvar");
            AV23lateDeleteMsgVar = Gxwebsession.Get(Gxids+"gxvar_Latedeletemsgvar");
         }
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV7WWPContext) ;
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
         AV37GXV1 = 1;
         while ( AV37GXV1 <= AV16WorkLogsSDTs.Count )
         {
            AV16WorkLogsSDTs.CurrentItem = ((SdtWorkLogsSDT)AV16WorkLogsSDTs.Item(AV37GXV1));
            AV37GXV1 = (int)(AV37GXV1+1);
         }
         AV35GXM1WorkLogsGridCollectionPanel_Level_DetailSdt.gxTpr_Worklogssdts = AV16WorkLogsSDTs;
         AV35GXM1WorkLogsGridCollectionPanel_Level_DetailSdt.gxTpr_Logdate = AV10LogDate;
         AV35GXM1WorkLogsGridCollectionPanel_Level_DetailSdt.gxTpr_Datetoday = AV21DateToday;
         AV35GXM1WorkLogsGridCollectionPanel_Level_DetailSdt.gxTpr_Lateupdatemsgvar = AV22lateUpdateMsgVar;
         AV35GXM1WorkLogsGridCollectionPanel_Level_DetailSdt.gxTpr_Latedeletemsgvar = AV23lateDeleteMsgVar;
         AV35GXM1WorkLogsGridCollectionPanel_Level_DetailSdt.gxTpr_Msgvar = AV15MsgVar;
         AV35GXM1WorkLogsGridCollectionPanel_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
         Gxdynprop = "";
         AV35GXM1WorkLogsGridCollectionPanel_Level_DetailSdt.gxTpr_Gxdyncall = "[ "+Gxdyncall+" ]";
         Gxdyncall = "";
         Gxwebsession.Set(Gxids+"gxvar_Worklogssdts", AV16WorkLogsSDTs.ToJSonString(false));
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
         AV16WorkLogsSDTs = new GXBaseCollection<SdtWorkLogsSDT>( context, "WorkLogsSDT", "");
         GXt_objcol_SdtWorkLogsSDT1 = AV16WorkLogsSDTs;
         new sdgetloggedworkdays(context ).execute(  AV10LogDate, out  GXt_objcol_SdtWorkLogsSDT1) ;
         AV16WorkLogsSDTs = GXt_objcol_SdtWorkLogsSDT1;
      }

      protected void S121( )
      {
         /* 'SHOWLOGGEDDAYS' Routine */
         returnInSub = false;
         AV19WWPCalendarInfo = new GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarInfo(context);
         new getloggedworkdays(context ).execute( out  AV19WWPCalendarInfo) ;
         AV20WWPCalendarInfoJson = AV19WWPCalendarInfo.ToJSonString(false, true);
         Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Calendaruc\",\"Dates\",\"" + StringUtil.JSONEncode( AV20WWPCalendarInfoJson) + "\"]";
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
         AV35GXM1WorkLogsGridCollectionPanel_Level_DetailSdt = new SdtWorkLogsGridCollectionPanel_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         Gxdynprop = "";
         AV21DateToday = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         AV15MsgVar = "";
         AV22lateUpdateMsgVar = "";
         AV23lateDeleteMsgVar = "";
         AV16WorkLogsSDTs = new GXBaseCollection<SdtWorkLogsSDT>( context, "WorkLogsSDT", "");
         AV7WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         Gxdynpropparms = new GxSimpleCollection<string>();
         Gxdyncall = "";
         GXt_objcol_SdtWorkLogsSDT1 = new GXBaseCollection<SdtWorkLogsSDT>( context, "WorkLogsSDT", "");
         AV19WWPCalendarInfo = new GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarInfo(context);
         AV20WWPCalendarInfoJson = "";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private int AV29gxid ;
      private int AV37GXV1 ;
      private string Gxids ;
      private string AV15MsgVar ;
      private string AV22lateUpdateMsgVar ;
      private string AV23lateDeleteMsgVar ;
      private string AV20WWPCalendarInfoJson ;
      private DateTime AV10LogDate ;
      private DateTime AV21DateToday ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private string Gxdynprop ;
      private string Gxdyncall ;
      private IGxSession Gxwebsession ;
      private SdtWorkLogsGridCollectionPanel_Level_DetailSdt AV35GXM1WorkLogsGridCollectionPanel_Level_DetailSdt ;
      private GXBaseCollection<SdtWorkLogsSDT> AV16WorkLogsSDTs ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV7WWPContext ;
      private GxSimpleCollection<string> Gxdynpropparms ;
      private GXBaseCollection<SdtWorkLogsSDT> GXt_objcol_SdtWorkLogsSDT1 ;
      private GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarInfo AV19WWPCalendarInfo ;
      private SdtWorkLogsGridCollectionPanel_Level_DetailSdt aP2_GXM1WorkLogsGridCollectionPanel_Level_DetailSdt ;
   }

}
