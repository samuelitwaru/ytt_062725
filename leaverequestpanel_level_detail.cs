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
   public class leaverequestpanel_level_detail : GXDataGridProcedure
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

      public leaverequestpanel_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public leaverequestpanel_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_gxid ,
                           out SdtLeaveRequestPanel_Level_DetailSdt aP1_GXM3LeaveRequestPanel_Level_DetailSdt )
      {
         this.AV41gxid = aP0_gxid;
         this.AV50GXM3LeaveRequestPanel_Level_DetailSdt = new SdtLeaveRequestPanel_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP1_GXM3LeaveRequestPanel_Level_DetailSdt=this.AV50GXM3LeaveRequestPanel_Level_DetailSdt;
      }

      public SdtLeaveRequestPanel_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM3LeaveRequestPanel_Level_DetailSdt);
         return AV50GXM3LeaveRequestPanel_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtLeaveRequestPanel_Level_DetailSdt aP1_GXM3LeaveRequestPanel_Level_DetailSdt )
      {
         this.AV41gxid = aP0_gxid;
         this.AV50GXM3LeaveRequestPanel_Level_DetailSdt = new SdtLeaveRequestPanel_Level_DetailSdt(context) ;
         SubmitImpl();
         aP1_GXM3LeaveRequestPanel_Level_DetailSdt=this.AV50GXM3LeaveRequestPanel_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV41gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            GXt_int1 = AV20EmployeeId;
            new getloggedinemployeeid(context ).execute( out  GXt_int1) ;
            AV20EmployeeId = GXt_int1;
            AV29MsgVar = "Leave Application Sent.";
            GXt_int2 = AV37EmployyeeAvailableVacationDays;
            new getemployeevactiondaysleft(context ).execute(  AV20EmployeeId, out  GXt_int2) ;
            AV37EmployyeeAvailableVacationDays = GXt_int2;
            Gxdynprop1 = "Vacation Days: " + StringUtil.Str( (decimal)(AV37EmployyeeAvailableVacationDays), 4, 0);
            Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Vactiondays\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop1) + "\"]";
            AV17CheckRequiredFieldsResult = false;
            Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Btnsubmitbutton\",\"Enabled\",\"" + "False" + "\"]";
            Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Btnsubmitbutton\",\"Class\",\"" + StringUtil.JSONEncode( "LogHoursSubmitBtnDisabled") + "\"]";
            AV31LeaveRequestStartDate = Gx_date;
            Gxwebsession.Set(Gxids+"gxvar_Leaverequeststartdate", context.localUtil.DToC( AV31LeaveRequestStartDate, 2, "/"));
            Gxwebsession.Set(Gxids+"gxvar_Employeeid", StringUtil.Str( (decimal)(AV20EmployeeId), 10, 0));
            Gxwebsession.Set(Gxids+"gxvar_Msgvar", AV29MsgVar);
            Gxwebsession.Set(Gxids+"gxvar_Employyeeavailablevacationdays", StringUtil.Str( (decimal)(AV37EmployyeeAvailableVacationDays), 4, 0));
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV37EmployyeeAvailableVacationDays = (short)(Math.Round(NumberUtil.Val( Gxwebsession.Get(Gxids+"gxvar_Employyeeavailablevacationdays"), "."), 18, MidpointRounding.ToEven));
            AV20EmployeeId = (long)(Math.Round(NumberUtil.Val( Gxwebsession.Get(Gxids+"gxvar_Employeeid"), "."), 18, MidpointRounding.ToEven));
            AV29MsgVar = Gxwebsession.Get(Gxids+"gxvar_Msgvar");
            AV31LeaveRequestStartDate = context.localUtil.CToD( Gxwebsession.Get(Gxids+"gxvar_Leaverequeststartdate"), 2);
         }
         Gxdynprop2 = "Vacation Days: " + StringUtil.Str( (decimal)(AV37EmployyeeAvailableVacationDays), 4, 0);
         Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Vactiondays\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop2) + "\"]";
         AV50GXM3LeaveRequestPanel_Level_DetailSdt.gxTpr_Leavetypeid = AV30LeaveTypeId;
         AV50GXM3LeaveRequestPanel_Level_DetailSdt.gxTpr_Leaverequeststartdate = AV31LeaveRequestStartDate;
         AV50GXM3LeaveRequestPanel_Level_DetailSdt.gxTpr_Leaverequestenddate = AV32LeaveRequestEndDate;
         AV50GXM3LeaveRequestPanel_Level_DetailSdt.gxTpr_Leaverequesthalfday = AV40LeaveRequestHalfDay;
         AV50GXM3LeaveRequestPanel_Level_DetailSdt.gxTpr_Leaverequestduration = AV33LeaveRequestDuration;
         AV50GXM3LeaveRequestPanel_Level_DetailSdt.gxTpr_Leaverequestdescription = AV34LeaveRequestDescription;
         AV50GXM3LeaveRequestPanel_Level_DetailSdt.gxTpr_Employeeid = AV20EmployeeId;
         AV50GXM3LeaveRequestPanel_Level_DetailSdt.gxTpr_Today = Gx_date;
         AV50GXM3LeaveRequestPanel_Level_DetailSdt.gxTpr_Employyeeavailablevacationdays = AV37EmployyeeAvailableVacationDays;
         AV50GXM3LeaveRequestPanel_Level_DetailSdt.gxTpr_Msgvar = AV29MsgVar;
         AV50GXM3LeaveRequestPanel_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
         Gxdynprop = "";
         Gxval_leavetypeid = AV30LeaveTypeId;
         /* Execute user subroutine: Gxdesc_Leavetypeid */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV50GXM3LeaveRequestPanel_Level_DetailSdt.gxTpr_Gxdesc_leavetypeid = Gxdesc_leavetypeid;
         cleanup();
      }

      protected void S111( )
      {
         /* Gxdesc_Leavetypeid Routine */
         returnInSub = false;
         AV52Udparg4 = new getloggedinusercompanyid(context).executeUdp( );
         /* Using cursor P00002 */
         pr_default.execute(0, new Object[] {Gxval_leavetypeid, AV52Udparg4});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00002_A100CompanyId[0];
            A124LeaveTypeId = P00002_A124LeaveTypeId[0];
            A125LeaveTypeName = P00002_A125LeaveTypeName[0];
            Gxdesc_leavetypeid = A125LeaveTypeName;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         SetPaginationHeaders(((pr_default.getStatus(0) == 101) ? false : true));
         pr_default.close(0);
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
         AV50GXM3LeaveRequestPanel_Level_DetailSdt = new SdtLeaveRequestPanel_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV29MsgVar = "";
         Gxdynprop1 = "";
         Gxdynprop = "";
         AV31LeaveRequestStartDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         Gxdynprop2 = "";
         AV32LeaveRequestEndDate = DateTime.MinValue;
         AV40LeaveRequestHalfDay = "";
         AV34LeaveRequestDescription = "";
         Gxdesc_leavetypeid = "";
         P00002_A100CompanyId = new long[1] ;
         P00002_A124LeaveTypeId = new long[1] ;
         P00002_A125LeaveTypeName = new string[] {""} ;
         A125LeaveTypeName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestpanel_level_detail__default(),
            new Object[][] {
                new Object[] {
               P00002_A100CompanyId, P00002_A124LeaveTypeId, P00002_A125LeaveTypeName
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV37EmployyeeAvailableVacationDays ;
      private short GXt_int2 ;
      private int AV41gxid ;
      private long AV20EmployeeId ;
      private long GXt_int1 ;
      private long AV30LeaveTypeId ;
      private long Gxval_leavetypeid ;
      private long AV52Udparg4 ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private decimal AV33LeaveRequestDuration ;
      private string Gxids ;
      private string AV29MsgVar ;
      private string Gxdynprop1 ;
      private string Gxdynprop2 ;
      private string AV40LeaveRequestHalfDay ;
      private string A125LeaveTypeName ;
      private DateTime AV31LeaveRequestStartDate ;
      private DateTime Gx_date ;
      private DateTime AV32LeaveRequestEndDate ;
      private bool AV17CheckRequiredFieldsResult ;
      private bool returnInSub ;
      private string AV34LeaveRequestDescription ;
      private string Gxdynprop ;
      private string Gxdesc_leavetypeid ;
      private IGxSession Gxwebsession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtLeaveRequestPanel_Level_DetailSdt AV50GXM3LeaveRequestPanel_Level_DetailSdt ;
      private IDataStoreProvider pr_default ;
      private long[] P00002_A100CompanyId ;
      private long[] P00002_A124LeaveTypeId ;
      private string[] P00002_A125LeaveTypeName ;
      private SdtLeaveRequestPanel_Level_DetailSdt aP1_GXM3LeaveRequestPanel_Level_DetailSdt ;
   }

   public class leaverequestpanel_level_detail__default : DataStoreHelperBase, IDataStoreHelper
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
          new ParDef("Gxval_leavetypeid",GXType.Int64,10,0) ,
          new ParDef("AV52Udparg4",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00002", "SELECT CompanyId, LeaveTypeId, LeaveTypeName FROM LeaveType WHERE (LeaveTypeId = :Gxval_leavetypeid) AND (CompanyId = :AV52Udparg4) ORDER BY LeaveTypeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00002,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
