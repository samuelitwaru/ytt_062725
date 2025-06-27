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
   public class updateworkhourlog_level_detail : GXDataGridProcedure
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

      public updateworkhourlog_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public updateworkhourlog_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_WorkHourLogId ,
                           int aP1_gxid ,
                           out SdtUpdateWorkHourLog_Level_DetailSdt aP2_GXM1UpdateWorkHourLog_Level_DetailSdt )
      {
         this.A118WorkHourLogId = aP0_WorkHourLogId;
         this.AV20gxid = aP1_gxid;
         this.AV24GXM1UpdateWorkHourLog_Level_DetailSdt = new SdtUpdateWorkHourLog_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP2_GXM1UpdateWorkHourLog_Level_DetailSdt=this.AV24GXM1UpdateWorkHourLog_Level_DetailSdt;
      }

      public SdtUpdateWorkHourLog_Level_DetailSdt executeUdp( long aP0_WorkHourLogId ,
                                                              int aP1_gxid )
      {
         execute(aP0_WorkHourLogId, aP1_gxid, out aP2_GXM1UpdateWorkHourLog_Level_DetailSdt);
         return AV24GXM1UpdateWorkHourLog_Level_DetailSdt ;
      }

      public void executeSubmit( long aP0_WorkHourLogId ,
                                 int aP1_gxid ,
                                 out SdtUpdateWorkHourLog_Level_DetailSdt aP2_GXM1UpdateWorkHourLog_Level_DetailSdt )
      {
         this.A118WorkHourLogId = aP0_WorkHourLogId;
         this.AV20gxid = aP1_gxid;
         this.AV24GXM1UpdateWorkHourLog_Level_DetailSdt = new SdtUpdateWorkHourLog_Level_DetailSdt(context) ;
         SubmitImpl();
         aP2_GXM1UpdateWorkHourLog_Level_DetailSdt=this.AV24GXM1UpdateWorkHourLog_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV20gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            AV8WorkHourLog = new SdtWorkHourLog(context);
            AV8WorkHourLog.Load(A118WorkHourLogId);
            AV15WorkLogProject = (short)(AV8WorkHourLog.gxTpr_Projectid);
            AV14WorkLogDate = AV8WorkHourLog.gxTpr_Workhourlogdate;
            AV16WorkLogHour = AV8WorkHourLog.gxTpr_Workhourloghour;
            AV17WorkLogMinute = AV8WorkHourLog.gxTpr_Workhourlogminute;
            AV18WorkLogDescription = AV8WorkHourLog.gxTpr_Workhourlogdescription;
            AV19MsgVar = "Record Updated.";
            Gxwebsession.Set(Gxids+"gxvar_Worklogdate", context.localUtil.DToC( AV14WorkLogDate, 2, "/"));
            Gxwebsession.Set(Gxids+"gxvar_Worklogproject", StringUtil.Str( (decimal)(AV15WorkLogProject), 4, 0));
            Gxwebsession.Set(Gxids+"gxvar_Workloghour", StringUtil.Str( (decimal)(AV16WorkLogHour), 2, 0));
            Gxwebsession.Set(Gxids+"gxvar_Worklogminute", StringUtil.Str( (decimal)(AV17WorkLogMinute), 2, 0));
            Gxwebsession.Set(Gxids+"gxvar_Worklogdescription", AV18WorkLogDescription);
            Gxwebsession.Set(Gxids+"gxvar_Workhourlog", AV8WorkHourLog.ToJSonString(true, true));
            Gxwebsession.Set(Gxids+"gxvar_Msgvar", AV19MsgVar);
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV8WorkHourLog.FromJSonString(Gxwebsession.Get(Gxids+"gxvar_Workhourlog"), null);
            AV15WorkLogProject = (short)(Math.Round(NumberUtil.Val( Gxwebsession.Get(Gxids+"gxvar_Worklogproject"), "."), 18, MidpointRounding.ToEven));
            AV14WorkLogDate = context.localUtil.CToD( Gxwebsession.Get(Gxids+"gxvar_Worklogdate"), 2);
            AV16WorkLogHour = (short)(Math.Round(NumberUtil.Val( Gxwebsession.Get(Gxids+"gxvar_Workloghour"), "."), 18, MidpointRounding.ToEven));
            AV17WorkLogMinute = (short)(Math.Round(NumberUtil.Val( Gxwebsession.Get(Gxids+"gxvar_Worklogminute"), "."), 18, MidpointRounding.ToEven));
            AV18WorkLogDescription = Gxwebsession.Get(Gxids+"gxvar_Worklogdescription");
            AV19MsgVar = Gxwebsession.Get(Gxids+"gxvar_Msgvar");
         }
         AV24GXM1UpdateWorkHourLog_Level_DetailSdt.gxTpr_Worklogdate = AV14WorkLogDate;
         AV24GXM1UpdateWorkHourLog_Level_DetailSdt.gxTpr_Worklogproject = AV15WorkLogProject;
         AV24GXM1UpdateWorkHourLog_Level_DetailSdt.gxTpr_Workloghour = AV16WorkLogHour;
         AV24GXM1UpdateWorkHourLog_Level_DetailSdt.gxTpr_Worklogminute = AV17WorkLogMinute;
         AV24GXM1UpdateWorkHourLog_Level_DetailSdt.gxTpr_Worklogdescription = AV18WorkLogDescription;
         AV24GXM1UpdateWorkHourLog_Level_DetailSdt.gxTpr_Workhourlog = AV8WorkHourLog;
         AV24GXM1UpdateWorkHourLog_Level_DetailSdt.gxTpr_Today = Gx_date;
         AV24GXM1UpdateWorkHourLog_Level_DetailSdt.gxTpr_Msgvar = AV19MsgVar;
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
         AV24GXM1UpdateWorkHourLog_Level_DetailSdt = new SdtUpdateWorkHourLog_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV8WorkHourLog = new SdtWorkHourLog(context);
         AV14WorkLogDate = DateTime.MinValue;
         AV18WorkLogDescription = "";
         AV19MsgVar = "";
         Gx_date = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV15WorkLogProject ;
      private short AV16WorkLogHour ;
      private short AV17WorkLogMinute ;
      private int AV20gxid ;
      private long A118WorkHourLogId ;
      private string Gxids ;
      private string AV19MsgVar ;
      private DateTime AV14WorkLogDate ;
      private DateTime Gx_date ;
      private string AV18WorkLogDescription ;
      private IGxSession Gxwebsession ;
      private SdtUpdateWorkHourLog_Level_DetailSdt AV24GXM1UpdateWorkHourLog_Level_DetailSdt ;
      private SdtWorkHourLog AV8WorkHourLog ;
      private SdtUpdateWorkHourLog_Level_DetailSdt aP2_GXM1UpdateWorkHourLog_Level_DetailSdt ;
   }

}
