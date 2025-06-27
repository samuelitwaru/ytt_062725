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
   public class loghourspanel_level_detail : GXDataGridProcedure
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

      public loghourspanel_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public loghourspanel_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_gxid ,
                           out SdtLogHoursPanel_Level_DetailSdt aP1_GXM3LogHoursPanel_Level_DetailSdt )
      {
         this.AV36gxid = aP0_gxid;
         this.AV43GXM3LogHoursPanel_Level_DetailSdt = new SdtLogHoursPanel_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP1_GXM3LogHoursPanel_Level_DetailSdt=this.AV43GXM3LogHoursPanel_Level_DetailSdt;
      }

      public SdtLogHoursPanel_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM3LogHoursPanel_Level_DetailSdt);
         return AV43GXM3LogHoursPanel_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtLogHoursPanel_Level_DetailSdt aP1_GXM3LogHoursPanel_Level_DetailSdt )
      {
         this.AV36gxid = aP0_gxid;
         this.AV43GXM3LogHoursPanel_Level_DetailSdt = new SdtLogHoursPanel_Level_DetailSdt(context) ;
         SubmitImpl();
         aP1_GXM3LogHoursPanel_Level_DetailSdt=this.AV43GXM3LogHoursPanel_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV36gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            AV7WorkHourLogDate = Gx_date;
            GXt_int1 = AV20EmployeeId;
            new getloggedinemployeeid(context ).execute( out  GXt_int1) ;
            AV20EmployeeId = GXt_int1;
            AV29MsgVar = "Hours Logged Succesfully";
            AV23LogHour = 8;
            new sdgetweekhours(context ).execute( out  AV25WeekDuration, out  AV26WeekHours) ;
            Gxdynprop1 = "Weekly Total: " + AV25WeekDuration;
            Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Weeklyhourstxt\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop1) + "\"]";
            AV17CheckRequiredFieldsResult = false;
            Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Btnsubmitbutton\",\"Enabled\",\"" + "False" + "\"]";
            Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Btnsubmitbutton\",\"Class\",\"" + StringUtil.JSONEncode( "LogHoursSubmitBtnDisabled") + "\"]";
            GXt_int1 = AV31LastLoggedProjectId;
            new getemployeelastloggedproject(context ).execute( out  GXt_int1) ;
            AV31LastLoggedProjectId = GXt_int1;
            if ( AV31LastLoggedProjectId > 0 )
            {
               AV10ProjectId = (short)(AV31LastLoggedProjectId);
            }
            Gxwebsession.Set(Gxids+"gxvar_Workhourlogdate", context.localUtil.DToC( AV7WorkHourLogDate, 2, "/"));
            Gxwebsession.Set(Gxids+"gxvar_Projectid", StringUtil.Str( (decimal)(AV10ProjectId), 4, 0));
            Gxwebsession.Set(Gxids+"gxvar_Loghour", StringUtil.Str( (decimal)(AV23LogHour), 2, 0));
            Gxwebsession.Set(Gxids+"gxvar_Employeeid", StringUtil.Str( (decimal)(AV20EmployeeId), 10, 0));
            Gxwebsession.Set(Gxids+"gxvar_Msgvar", AV29MsgVar);
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV7WorkHourLogDate = context.localUtil.CToD( Gxwebsession.Get(Gxids+"gxvar_Workhourlogdate"), 2);
            AV20EmployeeId = (long)(Math.Round(NumberUtil.Val( Gxwebsession.Get(Gxids+"gxvar_Employeeid"), "."), 18, MidpointRounding.ToEven));
            AV29MsgVar = Gxwebsession.Get(Gxids+"gxvar_Msgvar");
            AV23LogHour = (short)(Math.Round(NumberUtil.Val( Gxwebsession.Get(Gxids+"gxvar_Loghour"), "."), 18, MidpointRounding.ToEven));
            AV10ProjectId = (short)(Math.Round(NumberUtil.Val( Gxwebsession.Get(Gxids+"gxvar_Projectid"), "."), 18, MidpointRounding.ToEven));
         }
         AV7WorkHourLogDate = Gx_date;
         new sdgetweekhours(context ).execute( out  AV25WeekDuration, out  AV26WeekHours) ;
         Gxdynprop2 = "Weekly Total: " + AV25WeekDuration;
         Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Weeklyhourstxt\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop2) + "\"]";
         AV43GXM3LogHoursPanel_Level_DetailSdt.gxTpr_Workhourlogdate = AV7WorkHourLogDate;
         AV43GXM3LogHoursPanel_Level_DetailSdt.gxTpr_Projectid = AV10ProjectId;
         AV43GXM3LogHoursPanel_Level_DetailSdt.gxTpr_Loghour = AV23LogHour;
         AV43GXM3LogHoursPanel_Level_DetailSdt.gxTpr_Logminute = AV24LogMinute;
         AV43GXM3LogHoursPanel_Level_DetailSdt.gxTpr_Workhourlogdescription = AV13WorkHourLogDescription;
         AV43GXM3LogHoursPanel_Level_DetailSdt.gxTpr_Employeeid = AV20EmployeeId;
         AV43GXM3LogHoursPanel_Level_DetailSdt.gxTpr_Today = Gx_date;
         AV43GXM3LogHoursPanel_Level_DetailSdt.gxTpr_Msgvar = AV29MsgVar;
         AV43GXM3LogHoursPanel_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
         Gxdynprop = "";
         Gxwebsession.Set(Gxids+"gxvar_Workhourlogdate", context.localUtil.DToC( AV7WorkHourLogDate, 2, "/"));
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
         AV43GXM3LogHoursPanel_Level_DetailSdt = new SdtLogHoursPanel_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV7WorkHourLogDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         AV29MsgVar = "";
         AV23LogHour = 8;
         AV25WeekDuration = "";
         Gxdynprop1 = "";
         Gxdynprop = "";
         Gxdynprop2 = "";
         AV13WorkHourLogDescription = "";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV23LogHour ;
      private short AV26WeekHours ;
      private short AV10ProjectId ;
      private short AV24LogMinute ;
      private int AV36gxid ;
      private long AV20EmployeeId ;
      private long AV31LastLoggedProjectId ;
      private long GXt_int1 ;
      private string Gxids ;
      private string AV29MsgVar ;
      private string AV25WeekDuration ;
      private string Gxdynprop1 ;
      private string Gxdynprop2 ;
      private DateTime AV7WorkHourLogDate ;
      private DateTime Gx_date ;
      private bool AV17CheckRequiredFieldsResult ;
      private string AV13WorkHourLogDescription ;
      private string Gxdynprop ;
      private IGxSession Gxwebsession ;
      private SdtLogHoursPanel_Level_DetailSdt AV43GXM3LogHoursPanel_Level_DetailSdt ;
      private SdtLogHoursPanel_Level_DetailSdt aP1_GXM3LogHoursPanel_Level_DetailSdt ;
   }

}
