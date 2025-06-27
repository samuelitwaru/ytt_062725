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
   public class updateleaverequest_level_detail : GXDataGridProcedure
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

      public updateleaverequest_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public updateleaverequest_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_LeaveRequestId ,
                           int aP1_gxid ,
                           out SdtUpdateLeaveRequest_Level_DetailSdt aP2_GXM1UpdateLeaveRequest_Level_DetailSdt )
      {
         this.A127LeaveRequestId = aP0_LeaveRequestId;
         this.AV28gxid = aP1_gxid;
         this.AV35GXM1UpdateLeaveRequest_Level_DetailSdt = new SdtUpdateLeaveRequest_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP2_GXM1UpdateLeaveRequest_Level_DetailSdt=this.AV35GXM1UpdateLeaveRequest_Level_DetailSdt;
      }

      public SdtUpdateLeaveRequest_Level_DetailSdt executeUdp( long aP0_LeaveRequestId ,
                                                               int aP1_gxid )
      {
         execute(aP0_LeaveRequestId, aP1_gxid, out aP2_GXM1UpdateLeaveRequest_Level_DetailSdt);
         return AV35GXM1UpdateLeaveRequest_Level_DetailSdt ;
      }

      public void executeSubmit( long aP0_LeaveRequestId ,
                                 int aP1_gxid ,
                                 out SdtUpdateLeaveRequest_Level_DetailSdt aP2_GXM1UpdateLeaveRequest_Level_DetailSdt )
      {
         this.A127LeaveRequestId = aP0_LeaveRequestId;
         this.AV28gxid = aP1_gxid;
         this.AV35GXM1UpdateLeaveRequest_Level_DetailSdt = new SdtUpdateLeaveRequest_Level_DetailSdt(context) ;
         SubmitImpl();
         aP2_GXM1UpdateLeaveRequest_Level_DetailSdt=this.AV35GXM1UpdateLeaveRequest_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV28gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            AV20LeaveRequest = new SdtLeaveRequest(context);
            AV20LeaveRequest.Load(A127LeaveRequestId);
            AV20LeaveRequest.gxTpr_Leaverequestdate = Gx_date;
            AV26LeaveTypeId = AV20LeaveRequest.gxTpr_Leavetypeid;
            AV21LeaveRequestDate = AV20LeaveRequest.gxTpr_Leaverequestdate;
            AV25LeaveRequestStartDate = AV20LeaveRequest.gxTpr_Leaverequeststartdate;
            AV24LeaveRequestEndDate = AV20LeaveRequest.gxTpr_Leaverequestenddate;
            AV27LeaveRequestHalfDay = AV20LeaveRequest.gxTpr_Leaverequesthalfday;
            AV22LeaveRequestDescription = AV20LeaveRequest.gxTpr_Leaverequestdescription;
            AV23LeaveRequestDuration = AV20LeaveRequest.gxTpr_Leaverequestduration;
            if ( StringUtil.StrCmp(AV27LeaveRequestHalfDay, "") != 0 )
            {
               AV24LeaveRequestEndDate = AV25LeaveRequestStartDate;
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"&Leaverequestenddate\",\"Enabled\",\"" + "False" + "\"]";
            }
            else
            {
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"&Leaverequestenddate\",\"Enabled\",\"" + "True" + "\"]";
            }
            AV19MsgVar = "Record Updated.";
            Gxwebsession.Set(Gxids+"gxvar_Leaverequestdate", context.localUtil.DToC( AV21LeaveRequestDate, 2, "/"));
            Gxwebsession.Set(Gxids+"gxvar_Leavetypeid", StringUtil.Str( (decimal)(AV26LeaveTypeId), 10, 0));
            Gxwebsession.Set(Gxids+"gxvar_Leaverequeststartdate", context.localUtil.DToC( AV25LeaveRequestStartDate, 2, "/"));
            Gxwebsession.Set(Gxids+"gxvar_Leaverequestenddate", context.localUtil.DToC( AV24LeaveRequestEndDate, 2, "/"));
            Gxwebsession.Set(Gxids+"gxvar_Leaverequestduration", StringUtil.Str( AV23LeaveRequestDuration, 4, 1));
            Gxwebsession.Set(Gxids+"gxvar_Leaverequesthalfday", AV27LeaveRequestHalfDay);
            Gxwebsession.Set(Gxids+"gxvar_Leaverequestdescription", AV22LeaveRequestDescription);
            Gxwebsession.Set(Gxids+"gxvar_Leaverequest", AV20LeaveRequest.ToJSonString(true, true));
            Gxwebsession.Set(Gxids+"gxvar_Msgvar", AV19MsgVar);
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV20LeaveRequest.FromJSonString(Gxwebsession.Get(Gxids+"gxvar_Leaverequest"), null);
            AV26LeaveTypeId = (long)(Math.Round(NumberUtil.Val( Gxwebsession.Get(Gxids+"gxvar_Leavetypeid"), "."), 18, MidpointRounding.ToEven));
            AV21LeaveRequestDate = context.localUtil.CToD( Gxwebsession.Get(Gxids+"gxvar_Leaverequestdate"), 2);
            AV25LeaveRequestStartDate = context.localUtil.CToD( Gxwebsession.Get(Gxids+"gxvar_Leaverequeststartdate"), 2);
            AV24LeaveRequestEndDate = context.localUtil.CToD( Gxwebsession.Get(Gxids+"gxvar_Leaverequestenddate"), 2);
            AV27LeaveRequestHalfDay = Gxwebsession.Get(Gxids+"gxvar_Leaverequesthalfday");
            AV22LeaveRequestDescription = Gxwebsession.Get(Gxids+"gxvar_Leaverequestdescription");
            AV23LeaveRequestDuration = NumberUtil.Val( Gxwebsession.Get(Gxids+"gxvar_Leaverequestduration"), ".");
            AV19MsgVar = Gxwebsession.Get(Gxids+"gxvar_Msgvar");
         }
         AV35GXM1UpdateLeaveRequest_Level_DetailSdt.gxTpr_Leaverequestdate = AV21LeaveRequestDate;
         AV35GXM1UpdateLeaveRequest_Level_DetailSdt.gxTpr_Leavetypeid = AV26LeaveTypeId;
         AV35GXM1UpdateLeaveRequest_Level_DetailSdt.gxTpr_Leaverequeststartdate = AV25LeaveRequestStartDate;
         AV35GXM1UpdateLeaveRequest_Level_DetailSdt.gxTpr_Leaverequestenddate = AV24LeaveRequestEndDate;
         AV35GXM1UpdateLeaveRequest_Level_DetailSdt.gxTpr_Leaverequestduration = AV23LeaveRequestDuration;
         AV35GXM1UpdateLeaveRequest_Level_DetailSdt.gxTpr_Leaverequesthalfday = AV27LeaveRequestHalfDay;
         AV35GXM1UpdateLeaveRequest_Level_DetailSdt.gxTpr_Leaverequestdescription = AV22LeaveRequestDescription;
         AV35GXM1UpdateLeaveRequest_Level_DetailSdt.gxTpr_Leaverequest = AV20LeaveRequest;
         AV35GXM1UpdateLeaveRequest_Level_DetailSdt.gxTpr_Today = Gx_date;
         AV35GXM1UpdateLeaveRequest_Level_DetailSdt.gxTpr_Msgvar = AV19MsgVar;
         AV35GXM1UpdateLeaveRequest_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
         Gxdynprop = "";
         Gxval_leavetypeid = AV26LeaveTypeId;
         /* Execute user subroutine: Gxdesc_Leavetypeid */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV35GXM1UpdateLeaveRequest_Level_DetailSdt.gxTpr_Gxdesc_leavetypeid = Gxdesc_leavetypeid;
         cleanup();
      }

      protected void S111( )
      {
         /* Gxdesc_Leavetypeid Routine */
         returnInSub = false;
         AV37Udparg2 = new getloggedinusercompanyid(context).executeUdp( );
         /* Using cursor P00002 */
         pr_default.execute(0, new Object[] {Gxval_leavetypeid, AV37Udparg2});
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
         AV35GXM1UpdateLeaveRequest_Level_DetailSdt = new SdtUpdateLeaveRequest_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV20LeaveRequest = new SdtLeaveRequest(context);
         Gx_date = DateTime.MinValue;
         AV21LeaveRequestDate = DateTime.MinValue;
         AV25LeaveRequestStartDate = DateTime.MinValue;
         AV24LeaveRequestEndDate = DateTime.MinValue;
         AV27LeaveRequestHalfDay = "";
         AV22LeaveRequestDescription = "";
         Gxdynprop = "";
         AV19MsgVar = "";
         Gxdesc_leavetypeid = "";
         P00002_A100CompanyId = new long[1] ;
         P00002_A124LeaveTypeId = new long[1] ;
         P00002_A125LeaveTypeName = new string[] {""} ;
         A125LeaveTypeName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.updateleaverequest_level_detail__default(),
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

      private int AV28gxid ;
      private long A127LeaveRequestId ;
      private long AV26LeaveTypeId ;
      private long Gxval_leavetypeid ;
      private long AV37Udparg2 ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private decimal AV23LeaveRequestDuration ;
      private string Gxids ;
      private string AV27LeaveRequestHalfDay ;
      private string AV19MsgVar ;
      private string A125LeaveTypeName ;
      private DateTime Gx_date ;
      private DateTime AV21LeaveRequestDate ;
      private DateTime AV25LeaveRequestStartDate ;
      private DateTime AV24LeaveRequestEndDate ;
      private bool returnInSub ;
      private string AV22LeaveRequestDescription ;
      private string Gxdynprop ;
      private string Gxdesc_leavetypeid ;
      private IGxSession Gxwebsession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtUpdateLeaveRequest_Level_DetailSdt AV35GXM1UpdateLeaveRequest_Level_DetailSdt ;
      private SdtLeaveRequest AV20LeaveRequest ;
      private IDataStoreProvider pr_default ;
      private long[] P00002_A100CompanyId ;
      private long[] P00002_A124LeaveTypeId ;
      private string[] P00002_A125LeaveTypeName ;
      private SdtUpdateLeaveRequest_Level_DetailSdt aP2_GXM1UpdateLeaveRequest_Level_DetailSdt ;
   }

   public class updateleaverequest_level_detail__default : DataStoreHelperBase, IDataStoreHelper
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
          new ParDef("AV37Udparg2",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00002", "SELECT CompanyId, LeaveTypeId, LeaveTypeName FROM LeaveType WHERE (LeaveTypeId = :Gxval_leavetypeid) AND (CompanyId = :AV37Udparg2) ORDER BY LeaveTypeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00002,1, GxCacheFrequency.OFF ,false,true )
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
