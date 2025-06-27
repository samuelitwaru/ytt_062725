using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "LeaveRequest" )]
   [XmlType(TypeName =  "LeaveRequest" , Namespace = "YTT_version4" )]
   [Serializable]
   public class SdtLeaveRequest : GxSilentTrnSdt
   {
      public SdtLeaveRequest( )
      {
      }

      public SdtLeaveRequest( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( long AV127LeaveRequestId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV127LeaveRequestId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"LeaveRequestId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "LeaveRequest");
         metadata.Set("BT", "LeaveRequest");
         metadata.Set("PK", "[ \"LeaveRequestId\" ]");
         metadata.Set("PKAssigned", "[ \"LeaveRequestId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"EmployeeId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"LeaveTypeId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Leaverequestid_Z");
         state.Add("gxTpr_Leavetypeid_Z");
         state.Add("gxTpr_Leavetypename_Z");
         state.Add("gxTpr_Leaverequestdate_Z_Nullable");
         state.Add("gxTpr_Leaverequeststartdate_Z_Nullable");
         state.Add("gxTpr_Leaverequestenddate_Z_Nullable");
         state.Add("gxTpr_Leaverequesthalfday_Z");
         state.Add("gxTpr_Leaverequestduration_Z");
         state.Add("gxTpr_Leaverequeststatus_Z");
         state.Add("gxTpr_Leaverequestdescription_Z");
         state.Add("gxTpr_Leaverequestrejectionreason_Z");
         state.Add("gxTpr_Employeeid_Z");
         state.Add("gxTpr_Employeename_Z");
         state.Add("gxTpr_Employeebalance_Z");
         state.Add("gxTpr_Leavetypevacationleave_Z");
         state.Add("gxTpr_Leaverequesthalfday_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtLeaveRequest sdt;
         sdt = (SdtLeaveRequest)(source);
         gxTv_SdtLeaveRequest_Leaverequestid = sdt.gxTv_SdtLeaveRequest_Leaverequestid ;
         gxTv_SdtLeaveRequest_Leavetypeid = sdt.gxTv_SdtLeaveRequest_Leavetypeid ;
         gxTv_SdtLeaveRequest_Leavetypename = sdt.gxTv_SdtLeaveRequest_Leavetypename ;
         gxTv_SdtLeaveRequest_Leaverequestdate = sdt.gxTv_SdtLeaveRequest_Leaverequestdate ;
         gxTv_SdtLeaveRequest_Leaverequeststartdate = sdt.gxTv_SdtLeaveRequest_Leaverequeststartdate ;
         gxTv_SdtLeaveRequest_Leaverequestenddate = sdt.gxTv_SdtLeaveRequest_Leaverequestenddate ;
         gxTv_SdtLeaveRequest_Leaverequesthalfday = sdt.gxTv_SdtLeaveRequest_Leaverequesthalfday ;
         gxTv_SdtLeaveRequest_Leaverequestduration = sdt.gxTv_SdtLeaveRequest_Leaverequestduration ;
         gxTv_SdtLeaveRequest_Leaverequeststatus = sdt.gxTv_SdtLeaveRequest_Leaverequeststatus ;
         gxTv_SdtLeaveRequest_Leaverequestdescription = sdt.gxTv_SdtLeaveRequest_Leaverequestdescription ;
         gxTv_SdtLeaveRequest_Leaverequestrejectionreason = sdt.gxTv_SdtLeaveRequest_Leaverequestrejectionreason ;
         gxTv_SdtLeaveRequest_Employeeid = sdt.gxTv_SdtLeaveRequest_Employeeid ;
         gxTv_SdtLeaveRequest_Employeename = sdt.gxTv_SdtLeaveRequest_Employeename ;
         gxTv_SdtLeaveRequest_Employeebalance = sdt.gxTv_SdtLeaveRequest_Employeebalance ;
         gxTv_SdtLeaveRequest_Leavetypevacationleave = sdt.gxTv_SdtLeaveRequest_Leavetypevacationleave ;
         gxTv_SdtLeaveRequest_Mode = sdt.gxTv_SdtLeaveRequest_Mode ;
         gxTv_SdtLeaveRequest_Initialized = sdt.gxTv_SdtLeaveRequest_Initialized ;
         gxTv_SdtLeaveRequest_Leaverequestid_Z = sdt.gxTv_SdtLeaveRequest_Leaverequestid_Z ;
         gxTv_SdtLeaveRequest_Leavetypeid_Z = sdt.gxTv_SdtLeaveRequest_Leavetypeid_Z ;
         gxTv_SdtLeaveRequest_Leavetypename_Z = sdt.gxTv_SdtLeaveRequest_Leavetypename_Z ;
         gxTv_SdtLeaveRequest_Leaverequestdate_Z = sdt.gxTv_SdtLeaveRequest_Leaverequestdate_Z ;
         gxTv_SdtLeaveRequest_Leaverequeststartdate_Z = sdt.gxTv_SdtLeaveRequest_Leaverequeststartdate_Z ;
         gxTv_SdtLeaveRequest_Leaverequestenddate_Z = sdt.gxTv_SdtLeaveRequest_Leaverequestenddate_Z ;
         gxTv_SdtLeaveRequest_Leaverequesthalfday_Z = sdt.gxTv_SdtLeaveRequest_Leaverequesthalfday_Z ;
         gxTv_SdtLeaveRequest_Leaverequestduration_Z = sdt.gxTv_SdtLeaveRequest_Leaverequestduration_Z ;
         gxTv_SdtLeaveRequest_Leaverequeststatus_Z = sdt.gxTv_SdtLeaveRequest_Leaverequeststatus_Z ;
         gxTv_SdtLeaveRequest_Leaverequestdescription_Z = sdt.gxTv_SdtLeaveRequest_Leaverequestdescription_Z ;
         gxTv_SdtLeaveRequest_Leaverequestrejectionreason_Z = sdt.gxTv_SdtLeaveRequest_Leaverequestrejectionreason_Z ;
         gxTv_SdtLeaveRequest_Employeeid_Z = sdt.gxTv_SdtLeaveRequest_Employeeid_Z ;
         gxTv_SdtLeaveRequest_Employeename_Z = sdt.gxTv_SdtLeaveRequest_Employeename_Z ;
         gxTv_SdtLeaveRequest_Employeebalance_Z = sdt.gxTv_SdtLeaveRequest_Employeebalance_Z ;
         gxTv_SdtLeaveRequest_Leavetypevacationleave_Z = sdt.gxTv_SdtLeaveRequest_Leavetypevacationleave_Z ;
         gxTv_SdtLeaveRequest_Leaverequesthalfday_N = sdt.gxTv_SdtLeaveRequest_Leaverequesthalfday_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("LeaveRequestId", gxTv_SdtLeaveRequest_Leaverequestid, false, includeNonInitialized);
         AddObjectProperty("LeaveTypeId", gxTv_SdtLeaveRequest_Leavetypeid, false, includeNonInitialized);
         AddObjectProperty("LeaveTypeName", gxTv_SdtLeaveRequest_Leavetypename, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtLeaveRequest_Leaverequestdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtLeaveRequest_Leaverequestdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtLeaveRequest_Leaverequestdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("LeaveRequestDate", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtLeaveRequest_Leaverequeststartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtLeaveRequest_Leaverequeststartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtLeaveRequest_Leaverequeststartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("LeaveRequestStartDate", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtLeaveRequest_Leaverequestenddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtLeaveRequest_Leaverequestenddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtLeaveRequest_Leaverequestenddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("LeaveRequestEndDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("LeaveRequestHalfDay", gxTv_SdtLeaveRequest_Leaverequesthalfday, false, includeNonInitialized);
         AddObjectProperty("LeaveRequestHalfDay_N", gxTv_SdtLeaveRequest_Leaverequesthalfday_N, false, includeNonInitialized);
         AddObjectProperty("LeaveRequestDuration", gxTv_SdtLeaveRequest_Leaverequestduration, false, includeNonInitialized);
         AddObjectProperty("LeaveRequestStatus", gxTv_SdtLeaveRequest_Leaverequeststatus, false, includeNonInitialized);
         AddObjectProperty("LeaveRequestDescription", gxTv_SdtLeaveRequest_Leaverequestdescription, false, includeNonInitialized);
         AddObjectProperty("LeaveRequestRejectionReason", gxTv_SdtLeaveRequest_Leaverequestrejectionreason, false, includeNonInitialized);
         AddObjectProperty("EmployeeId", gxTv_SdtLeaveRequest_Employeeid, false, includeNonInitialized);
         AddObjectProperty("EmployeeName", gxTv_SdtLeaveRequest_Employeename, false, includeNonInitialized);
         AddObjectProperty("EmployeeBalance", gxTv_SdtLeaveRequest_Employeebalance, false, includeNonInitialized);
         AddObjectProperty("LeaveTypeVacationLeave", gxTv_SdtLeaveRequest_Leavetypevacationleave, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtLeaveRequest_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtLeaveRequest_Initialized, false, includeNonInitialized);
            AddObjectProperty("LeaveRequestId_Z", gxTv_SdtLeaveRequest_Leaverequestid_Z, false, includeNonInitialized);
            AddObjectProperty("LeaveTypeId_Z", gxTv_SdtLeaveRequest_Leavetypeid_Z, false, includeNonInitialized);
            AddObjectProperty("LeaveTypeName_Z", gxTv_SdtLeaveRequest_Leavetypename_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtLeaveRequest_Leaverequestdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtLeaveRequest_Leaverequestdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtLeaveRequest_Leaverequestdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("LeaveRequestDate_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtLeaveRequest_Leaverequeststartdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtLeaveRequest_Leaverequeststartdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtLeaveRequest_Leaverequeststartdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("LeaveRequestStartDate_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtLeaveRequest_Leaverequestenddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtLeaveRequest_Leaverequestenddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtLeaveRequest_Leaverequestenddate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("LeaveRequestEndDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("LeaveRequestHalfDay_Z", gxTv_SdtLeaveRequest_Leaverequesthalfday_Z, false, includeNonInitialized);
            AddObjectProperty("LeaveRequestDuration_Z", gxTv_SdtLeaveRequest_Leaverequestduration_Z, false, includeNonInitialized);
            AddObjectProperty("LeaveRequestStatus_Z", gxTv_SdtLeaveRequest_Leaverequeststatus_Z, false, includeNonInitialized);
            AddObjectProperty("LeaveRequestDescription_Z", gxTv_SdtLeaveRequest_Leaverequestdescription_Z, false, includeNonInitialized);
            AddObjectProperty("LeaveRequestRejectionReason_Z", gxTv_SdtLeaveRequest_Leaverequestrejectionreason_Z, false, includeNonInitialized);
            AddObjectProperty("EmployeeId_Z", gxTv_SdtLeaveRequest_Employeeid_Z, false, includeNonInitialized);
            AddObjectProperty("EmployeeName_Z", gxTv_SdtLeaveRequest_Employeename_Z, false, includeNonInitialized);
            AddObjectProperty("EmployeeBalance_Z", gxTv_SdtLeaveRequest_Employeebalance_Z, false, includeNonInitialized);
            AddObjectProperty("LeaveTypeVacationLeave_Z", gxTv_SdtLeaveRequest_Leavetypevacationleave_Z, false, includeNonInitialized);
            AddObjectProperty("LeaveRequestHalfDay_N", gxTv_SdtLeaveRequest_Leaverequesthalfday_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtLeaveRequest sdt )
      {
         if ( sdt.IsDirty("LeaveRequestId") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequestid = sdt.gxTv_SdtLeaveRequest_Leaverequestid ;
         }
         if ( sdt.IsDirty("LeaveTypeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leavetypeid = sdt.gxTv_SdtLeaveRequest_Leavetypeid ;
         }
         if ( sdt.IsDirty("LeaveTypeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leavetypename = sdt.gxTv_SdtLeaveRequest_Leavetypename ;
         }
         if ( sdt.IsDirty("LeaveRequestDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequestdate = sdt.gxTv_SdtLeaveRequest_Leaverequestdate ;
         }
         if ( sdt.IsDirty("LeaveRequestStartDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequeststartdate = sdt.gxTv_SdtLeaveRequest_Leaverequeststartdate ;
         }
         if ( sdt.IsDirty("LeaveRequestEndDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequestenddate = sdt.gxTv_SdtLeaveRequest_Leaverequestenddate ;
         }
         if ( sdt.IsDirty("LeaveRequestHalfDay") )
         {
            gxTv_SdtLeaveRequest_Leaverequesthalfday_N = (short)(sdt.gxTv_SdtLeaveRequest_Leaverequesthalfday_N);
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequesthalfday = sdt.gxTv_SdtLeaveRequest_Leaverequesthalfday ;
         }
         if ( sdt.IsDirty("LeaveRequestDuration") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequestduration = sdt.gxTv_SdtLeaveRequest_Leaverequestduration ;
         }
         if ( sdt.IsDirty("LeaveRequestStatus") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequeststatus = sdt.gxTv_SdtLeaveRequest_Leaverequeststatus ;
         }
         if ( sdt.IsDirty("LeaveRequestDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequestdescription = sdt.gxTv_SdtLeaveRequest_Leaverequestdescription ;
         }
         if ( sdt.IsDirty("LeaveRequestRejectionReason") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequestrejectionreason = sdt.gxTv_SdtLeaveRequest_Leaverequestrejectionreason ;
         }
         if ( sdt.IsDirty("EmployeeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Employeeid = sdt.gxTv_SdtLeaveRequest_Employeeid ;
         }
         if ( sdt.IsDirty("EmployeeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Employeename = sdt.gxTv_SdtLeaveRequest_Employeename ;
         }
         if ( sdt.IsDirty("EmployeeBalance") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Employeebalance = sdt.gxTv_SdtLeaveRequest_Employeebalance ;
         }
         if ( sdt.IsDirty("LeaveTypeVacationLeave") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leavetypevacationleave = sdt.gxTv_SdtLeaveRequest_Leavetypevacationleave ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "LeaveRequestId" )]
      [  XmlElement( ElementName = "LeaveRequestId"   )]
      public long gxTpr_Leaverequestid
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequestid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtLeaveRequest_Leaverequestid != value )
            {
               gxTv_SdtLeaveRequest_Mode = "INS";
               this.gxTv_SdtLeaveRequest_Leaverequestid_Z_SetNull( );
               this.gxTv_SdtLeaveRequest_Leavetypeid_Z_SetNull( );
               this.gxTv_SdtLeaveRequest_Leavetypename_Z_SetNull( );
               this.gxTv_SdtLeaveRequest_Leaverequestdate_Z_SetNull( );
               this.gxTv_SdtLeaveRequest_Leaverequeststartdate_Z_SetNull( );
               this.gxTv_SdtLeaveRequest_Leaverequestenddate_Z_SetNull( );
               this.gxTv_SdtLeaveRequest_Leaverequesthalfday_Z_SetNull( );
               this.gxTv_SdtLeaveRequest_Leaverequestduration_Z_SetNull( );
               this.gxTv_SdtLeaveRequest_Leaverequeststatus_Z_SetNull( );
               this.gxTv_SdtLeaveRequest_Leaverequestdescription_Z_SetNull( );
               this.gxTv_SdtLeaveRequest_Leaverequestrejectionreason_Z_SetNull( );
               this.gxTv_SdtLeaveRequest_Employeeid_Z_SetNull( );
               this.gxTv_SdtLeaveRequest_Employeename_Z_SetNull( );
               this.gxTv_SdtLeaveRequest_Employeebalance_Z_SetNull( );
               this.gxTv_SdtLeaveRequest_Leavetypevacationleave_Z_SetNull( );
            }
            gxTv_SdtLeaveRequest_Leaverequestid = value;
            SetDirty("Leaverequestid");
         }

      }

      [  SoapElement( ElementName = "LeaveTypeId" )]
      [  XmlElement( ElementName = "LeaveTypeId"   )]
      public long gxTpr_Leavetypeid
      {
         get {
            return gxTv_SdtLeaveRequest_Leavetypeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leavetypeid = value;
            SetDirty("Leavetypeid");
         }

      }

      [  SoapElement( ElementName = "LeaveTypeName" )]
      [  XmlElement( ElementName = "LeaveTypeName"   )]
      public string gxTpr_Leavetypename
      {
         get {
            return gxTv_SdtLeaveRequest_Leavetypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leavetypename = value;
            SetDirty("Leavetypename");
         }

      }

      [  SoapElement( ElementName = "LeaveRequestDate" )]
      [  XmlElement( ElementName = "LeaveRequestDate"  , IsNullable=true )]
      public string gxTpr_Leaverequestdate_Nullable
      {
         get {
            if ( gxTv_SdtLeaveRequest_Leaverequestdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtLeaveRequest_Leaverequestdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtLeaveRequest_Leaverequestdate = DateTime.MinValue;
            else
               gxTv_SdtLeaveRequest_Leaverequestdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaverequestdate
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequestdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequestdate = value;
            SetDirty("Leaverequestdate");
         }

      }

      [  SoapElement( ElementName = "LeaveRequestStartDate" )]
      [  XmlElement( ElementName = "LeaveRequestStartDate"  , IsNullable=true )]
      public string gxTpr_Leaverequeststartdate_Nullable
      {
         get {
            if ( gxTv_SdtLeaveRequest_Leaverequeststartdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtLeaveRequest_Leaverequeststartdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtLeaveRequest_Leaverequeststartdate = DateTime.MinValue;
            else
               gxTv_SdtLeaveRequest_Leaverequeststartdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaverequeststartdate
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequeststartdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequeststartdate = value;
            SetDirty("Leaverequeststartdate");
         }

      }

      [  SoapElement( ElementName = "LeaveRequestEndDate" )]
      [  XmlElement( ElementName = "LeaveRequestEndDate"  , IsNullable=true )]
      public string gxTpr_Leaverequestenddate_Nullable
      {
         get {
            if ( gxTv_SdtLeaveRequest_Leaverequestenddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtLeaveRequest_Leaverequestenddate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtLeaveRequest_Leaverequestenddate = DateTime.MinValue;
            else
               gxTv_SdtLeaveRequest_Leaverequestenddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaverequestenddate
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequestenddate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequestenddate = value;
            SetDirty("Leaverequestenddate");
         }

      }

      [  SoapElement( ElementName = "LeaveRequestHalfDay" )]
      [  XmlElement( ElementName = "LeaveRequestHalfDay"   )]
      public string gxTpr_Leaverequesthalfday
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequesthalfday ;
         }

         set {
            gxTv_SdtLeaveRequest_Leaverequesthalfday_N = 0;
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequesthalfday = value;
            SetDirty("Leaverequesthalfday");
         }

      }

      public void gxTv_SdtLeaveRequest_Leaverequesthalfday_SetNull( )
      {
         gxTv_SdtLeaveRequest_Leaverequesthalfday_N = 1;
         gxTv_SdtLeaveRequest_Leaverequesthalfday = "";
         SetDirty("Leaverequesthalfday");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Leaverequesthalfday_IsNull( )
      {
         return (gxTv_SdtLeaveRequest_Leaverequesthalfday_N==1) ;
      }

      [  SoapElement( ElementName = "LeaveRequestDuration" )]
      [  XmlElement( ElementName = "LeaveRequestDuration"   )]
      public decimal gxTpr_Leaverequestduration
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequestduration ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequestduration = value;
            SetDirty("Leaverequestduration");
         }

      }

      [  SoapElement( ElementName = "LeaveRequestStatus" )]
      [  XmlElement( ElementName = "LeaveRequestStatus"   )]
      public string gxTpr_Leaverequeststatus
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequeststatus ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequeststatus = value;
            SetDirty("Leaverequeststatus");
         }

      }

      [  SoapElement( ElementName = "LeaveRequestDescription" )]
      [  XmlElement( ElementName = "LeaveRequestDescription"   )]
      public string gxTpr_Leaverequestdescription
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequestdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequestdescription = value;
            SetDirty("Leaverequestdescription");
         }

      }

      [  SoapElement( ElementName = "LeaveRequestRejectionReason" )]
      [  XmlElement( ElementName = "LeaveRequestRejectionReason"   )]
      public string gxTpr_Leaverequestrejectionreason
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequestrejectionreason ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequestrejectionreason = value;
            SetDirty("Leaverequestrejectionreason");
         }

      }

      [  SoapElement( ElementName = "EmployeeId" )]
      [  XmlElement( ElementName = "EmployeeId"   )]
      public long gxTpr_Employeeid
      {
         get {
            return gxTv_SdtLeaveRequest_Employeeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Employeeid = value;
            SetDirty("Employeeid");
         }

      }

      [  SoapElement( ElementName = "EmployeeName" )]
      [  XmlElement( ElementName = "EmployeeName"   )]
      public string gxTpr_Employeename
      {
         get {
            return gxTv_SdtLeaveRequest_Employeename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Employeename = value;
            SetDirty("Employeename");
         }

      }

      [  SoapElement( ElementName = "EmployeeBalance" )]
      [  XmlElement( ElementName = "EmployeeBalance"   )]
      public decimal gxTpr_Employeebalance
      {
         get {
            return gxTv_SdtLeaveRequest_Employeebalance ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Employeebalance = value;
            SetDirty("Employeebalance");
         }

      }

      [  SoapElement( ElementName = "LeaveTypeVacationLeave" )]
      [  XmlElement( ElementName = "LeaveTypeVacationLeave"   )]
      public string gxTpr_Leavetypevacationleave
      {
         get {
            return gxTv_SdtLeaveRequest_Leavetypevacationleave ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leavetypevacationleave = value;
            SetDirty("Leavetypevacationleave");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtLeaveRequest_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtLeaveRequest_Mode_SetNull( )
      {
         gxTv_SdtLeaveRequest_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtLeaveRequest_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtLeaveRequest_Initialized_SetNull( )
      {
         gxTv_SdtLeaveRequest_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveRequestId_Z" )]
      [  XmlElement( ElementName = "LeaveRequestId_Z"   )]
      public long gxTpr_Leaverequestid_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequestid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequestid_Z = value;
            SetDirty("Leaverequestid_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Leaverequestid_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Leaverequestid_Z = 0;
         SetDirty("Leaverequestid_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Leaverequestid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveTypeId_Z" )]
      [  XmlElement( ElementName = "LeaveTypeId_Z"   )]
      public long gxTpr_Leavetypeid_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Leavetypeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leavetypeid_Z = value;
            SetDirty("Leavetypeid_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Leavetypeid_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Leavetypeid_Z = 0;
         SetDirty("Leavetypeid_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Leavetypeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveTypeName_Z" )]
      [  XmlElement( ElementName = "LeaveTypeName_Z"   )]
      public string gxTpr_Leavetypename_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Leavetypename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leavetypename_Z = value;
            SetDirty("Leavetypename_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Leavetypename_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Leavetypename_Z = "";
         SetDirty("Leavetypename_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Leavetypename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveRequestDate_Z" )]
      [  XmlElement( ElementName = "LeaveRequestDate_Z"  , IsNullable=true )]
      public string gxTpr_Leaverequestdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtLeaveRequest_Leaverequestdate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtLeaveRequest_Leaverequestdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtLeaveRequest_Leaverequestdate_Z = DateTime.MinValue;
            else
               gxTv_SdtLeaveRequest_Leaverequestdate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaverequestdate_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequestdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequestdate_Z = value;
            SetDirty("Leaverequestdate_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Leaverequestdate_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Leaverequestdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Leaverequestdate_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Leaverequestdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveRequestStartDate_Z" )]
      [  XmlElement( ElementName = "LeaveRequestStartDate_Z"  , IsNullable=true )]
      public string gxTpr_Leaverequeststartdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtLeaveRequest_Leaverequeststartdate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtLeaveRequest_Leaverequeststartdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtLeaveRequest_Leaverequeststartdate_Z = DateTime.MinValue;
            else
               gxTv_SdtLeaveRequest_Leaverequeststartdate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaverequeststartdate_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequeststartdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequeststartdate_Z = value;
            SetDirty("Leaverequeststartdate_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Leaverequeststartdate_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Leaverequeststartdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Leaverequeststartdate_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Leaverequeststartdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveRequestEndDate_Z" )]
      [  XmlElement( ElementName = "LeaveRequestEndDate_Z"  , IsNullable=true )]
      public string gxTpr_Leaverequestenddate_Z_Nullable
      {
         get {
            if ( gxTv_SdtLeaveRequest_Leaverequestenddate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtLeaveRequest_Leaverequestenddate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtLeaveRequest_Leaverequestenddate_Z = DateTime.MinValue;
            else
               gxTv_SdtLeaveRequest_Leaverequestenddate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaverequestenddate_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequestenddate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequestenddate_Z = value;
            SetDirty("Leaverequestenddate_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Leaverequestenddate_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Leaverequestenddate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Leaverequestenddate_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Leaverequestenddate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveRequestHalfDay_Z" )]
      [  XmlElement( ElementName = "LeaveRequestHalfDay_Z"   )]
      public string gxTpr_Leaverequesthalfday_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequesthalfday_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequesthalfday_Z = value;
            SetDirty("Leaverequesthalfday_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Leaverequesthalfday_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Leaverequesthalfday_Z = "";
         SetDirty("Leaverequesthalfday_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Leaverequesthalfday_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveRequestDuration_Z" )]
      [  XmlElement( ElementName = "LeaveRequestDuration_Z"   )]
      public decimal gxTpr_Leaverequestduration_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequestduration_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequestduration_Z = value;
            SetDirty("Leaverequestduration_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Leaverequestduration_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Leaverequestduration_Z = 0;
         SetDirty("Leaverequestduration_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Leaverequestduration_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveRequestStatus_Z" )]
      [  XmlElement( ElementName = "LeaveRequestStatus_Z"   )]
      public string gxTpr_Leaverequeststatus_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequeststatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequeststatus_Z = value;
            SetDirty("Leaverequeststatus_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Leaverequeststatus_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Leaverequeststatus_Z = "";
         SetDirty("Leaverequeststatus_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Leaverequeststatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveRequestDescription_Z" )]
      [  XmlElement( ElementName = "LeaveRequestDescription_Z"   )]
      public string gxTpr_Leaverequestdescription_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequestdescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequestdescription_Z = value;
            SetDirty("Leaverequestdescription_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Leaverequestdescription_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Leaverequestdescription_Z = "";
         SetDirty("Leaverequestdescription_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Leaverequestdescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveRequestRejectionReason_Z" )]
      [  XmlElement( ElementName = "LeaveRequestRejectionReason_Z"   )]
      public string gxTpr_Leaverequestrejectionreason_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequestrejectionreason_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequestrejectionreason_Z = value;
            SetDirty("Leaverequestrejectionreason_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Leaverequestrejectionreason_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Leaverequestrejectionreason_Z = "";
         SetDirty("Leaverequestrejectionreason_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Leaverequestrejectionreason_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeId_Z" )]
      [  XmlElement( ElementName = "EmployeeId_Z"   )]
      public long gxTpr_Employeeid_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Employeeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Employeeid_Z = value;
            SetDirty("Employeeid_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Employeeid_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Employeeid_Z = 0;
         SetDirty("Employeeid_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Employeeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeName_Z" )]
      [  XmlElement( ElementName = "EmployeeName_Z"   )]
      public string gxTpr_Employeename_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Employeename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Employeename_Z = value;
            SetDirty("Employeename_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Employeename_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Employeename_Z = "";
         SetDirty("Employeename_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Employeename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeBalance_Z" )]
      [  XmlElement( ElementName = "EmployeeBalance_Z"   )]
      public decimal gxTpr_Employeebalance_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Employeebalance_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Employeebalance_Z = value;
            SetDirty("Employeebalance_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Employeebalance_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Employeebalance_Z = 0;
         SetDirty("Employeebalance_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Employeebalance_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveTypeVacationLeave_Z" )]
      [  XmlElement( ElementName = "LeaveTypeVacationLeave_Z"   )]
      public string gxTpr_Leavetypevacationleave_Z
      {
         get {
            return gxTv_SdtLeaveRequest_Leavetypevacationleave_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leavetypevacationleave_Z = value;
            SetDirty("Leavetypevacationleave_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_Leavetypevacationleave_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_Leavetypevacationleave_Z = "";
         SetDirty("Leavetypevacationleave_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Leavetypevacationleave_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveRequestHalfDay_N" )]
      [  XmlElement( ElementName = "LeaveRequestHalfDay_N"   )]
      public short gxTpr_Leaverequesthalfday_N
      {
         get {
            return gxTv_SdtLeaveRequest_Leaverequesthalfday_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_Leaverequesthalfday_N = value;
            SetDirty("Leaverequesthalfday_N");
         }

      }

      public void gxTv_SdtLeaveRequest_Leaverequesthalfday_N_SetNull( )
      {
         gxTv_SdtLeaveRequest_Leaverequesthalfday_N = 0;
         SetDirty("Leaverequesthalfday_N");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_Leaverequesthalfday_N_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtLeaveRequest_Leavetypename = "";
         gxTv_SdtLeaveRequest_Leaverequestdate = DateTime.MinValue;
         gxTv_SdtLeaveRequest_Leaverequeststartdate = DateTime.MinValue;
         gxTv_SdtLeaveRequest_Leaverequestenddate = DateTime.MinValue;
         gxTv_SdtLeaveRequest_Leaverequesthalfday = "";
         gxTv_SdtLeaveRequest_Leaverequeststatus = "";
         gxTv_SdtLeaveRequest_Leaverequestdescription = "";
         gxTv_SdtLeaveRequest_Leaverequestrejectionreason = "";
         gxTv_SdtLeaveRequest_Employeename = "";
         gxTv_SdtLeaveRequest_Leavetypevacationleave = "";
         gxTv_SdtLeaveRequest_Mode = "";
         gxTv_SdtLeaveRequest_Leavetypename_Z = "";
         gxTv_SdtLeaveRequest_Leaverequestdate_Z = DateTime.MinValue;
         gxTv_SdtLeaveRequest_Leaverequeststartdate_Z = DateTime.MinValue;
         gxTv_SdtLeaveRequest_Leaverequestenddate_Z = DateTime.MinValue;
         gxTv_SdtLeaveRequest_Leaverequesthalfday_Z = "";
         gxTv_SdtLeaveRequest_Leaverequeststatus_Z = "";
         gxTv_SdtLeaveRequest_Leaverequestdescription_Z = "";
         gxTv_SdtLeaveRequest_Leaverequestrejectionreason_Z = "";
         gxTv_SdtLeaveRequest_Employeename_Z = "";
         gxTv_SdtLeaveRequest_Leavetypevacationleave_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "leaverequest", "GeneXus.Programs.leaverequest_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtLeaveRequest_Initialized ;
      private short gxTv_SdtLeaveRequest_Leaverequesthalfday_N ;
      private long gxTv_SdtLeaveRequest_Leaverequestid ;
      private long gxTv_SdtLeaveRequest_Leavetypeid ;
      private long gxTv_SdtLeaveRequest_Employeeid ;
      private long gxTv_SdtLeaveRequest_Leaverequestid_Z ;
      private long gxTv_SdtLeaveRequest_Leavetypeid_Z ;
      private long gxTv_SdtLeaveRequest_Employeeid_Z ;
      private decimal gxTv_SdtLeaveRequest_Leaverequestduration ;
      private decimal gxTv_SdtLeaveRequest_Employeebalance ;
      private decimal gxTv_SdtLeaveRequest_Leaverequestduration_Z ;
      private decimal gxTv_SdtLeaveRequest_Employeebalance_Z ;
      private string gxTv_SdtLeaveRequest_Leavetypename ;
      private string gxTv_SdtLeaveRequest_Leaverequesthalfday ;
      private string gxTv_SdtLeaveRequest_Leaverequeststatus ;
      private string gxTv_SdtLeaveRequest_Employeename ;
      private string gxTv_SdtLeaveRequest_Leavetypevacationleave ;
      private string gxTv_SdtLeaveRequest_Mode ;
      private string gxTv_SdtLeaveRequest_Leavetypename_Z ;
      private string gxTv_SdtLeaveRequest_Leaverequesthalfday_Z ;
      private string gxTv_SdtLeaveRequest_Leaverequeststatus_Z ;
      private string gxTv_SdtLeaveRequest_Employeename_Z ;
      private string gxTv_SdtLeaveRequest_Leavetypevacationleave_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtLeaveRequest_Leaverequestdate ;
      private DateTime gxTv_SdtLeaveRequest_Leaverequeststartdate ;
      private DateTime gxTv_SdtLeaveRequest_Leaverequestenddate ;
      private DateTime gxTv_SdtLeaveRequest_Leaverequestdate_Z ;
      private DateTime gxTv_SdtLeaveRequest_Leaverequeststartdate_Z ;
      private DateTime gxTv_SdtLeaveRequest_Leaverequestenddate_Z ;
      private string gxTv_SdtLeaveRequest_Leaverequestdescription ;
      private string gxTv_SdtLeaveRequest_Leaverequestrejectionreason ;
      private string gxTv_SdtLeaveRequest_Leaverequestdescription_Z ;
      private string gxTv_SdtLeaveRequest_Leaverequestrejectionreason_Z ;
   }

   [DataContract(Name = @"LeaveRequest", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtLeaveRequest_RESTInterface : GxGenericCollectionItem<SdtLeaveRequest>
   {
      public SdtLeaveRequest_RESTInterface( ) : base()
      {
      }

      public SdtLeaveRequest_RESTInterface( SdtLeaveRequest psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LeaveRequestId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Leaverequestid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Leaverequestid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Leaverequestid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "LeaveTypeId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Leavetypeid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Leavetypeid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "LeaveTypeName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Leavetypename
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Leavetypename) ;
         }

         set {
            sdt.gxTpr_Leavetypename = value;
         }

      }

      [DataMember( Name = "LeaveRequestDate" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Leaverequestdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Leaverequestdate) ;
         }

         set {
            sdt.gxTpr_Leaverequestdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "LeaveRequestStartDate" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Leaverequeststartdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Leaverequeststartdate) ;
         }

         set {
            sdt.gxTpr_Leaverequeststartdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "LeaveRequestEndDate" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Leaverequestenddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Leaverequestenddate) ;
         }

         set {
            sdt.gxTpr_Leaverequestenddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "LeaveRequestHalfDay" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Leaverequesthalfday
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Leaverequesthalfday) ;
         }

         set {
            sdt.gxTpr_Leaverequesthalfday = value;
         }

      }

      [DataMember( Name = "LeaveRequestDuration" , Order = 7 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Leaverequestduration
      {
         get {
            return sdt.gxTpr_Leaverequestduration ;
         }

         set {
            sdt.gxTpr_Leaverequestduration = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "LeaveRequestStatus" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Leaverequeststatus
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Leaverequeststatus) ;
         }

         set {
            sdt.gxTpr_Leaverequeststatus = value;
         }

      }

      [DataMember( Name = "LeaveRequestDescription" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Leaverequestdescription
      {
         get {
            return sdt.gxTpr_Leaverequestdescription ;
         }

         set {
            sdt.gxTpr_Leaverequestdescription = value;
         }

      }

      [DataMember( Name = "LeaveRequestRejectionReason" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Leaverequestrejectionreason
      {
         get {
            return sdt.gxTpr_Leaverequestrejectionreason ;
         }

         set {
            sdt.gxTpr_Leaverequestrejectionreason = value;
         }

      }

      [DataMember( Name = "EmployeeId" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Employeeid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Employeeid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Employeeid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "EmployeeName" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Employeename
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Employeename) ;
         }

         set {
            sdt.gxTpr_Employeename = value;
         }

      }

      [DataMember( Name = "EmployeeBalance" , Order = 13 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Employeebalance
      {
         get {
            return sdt.gxTpr_Employeebalance ;
         }

         set {
            sdt.gxTpr_Employeebalance = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "LeaveTypeVacationLeave" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Leavetypevacationleave
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Leavetypevacationleave) ;
         }

         set {
            sdt.gxTpr_Leavetypevacationleave = value;
         }

      }

      public SdtLeaveRequest sdt
      {
         get {
            return (SdtLeaveRequest)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtLeaveRequest() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 15 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"LeaveRequest", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtLeaveRequest_RESTLInterface : GxGenericCollectionItem<SdtLeaveRequest>
   {
      public SdtLeaveRequest_RESTLInterface( ) : base()
      {
      }

      public SdtLeaveRequest_RESTLInterface( SdtLeaveRequest psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LeaveRequestDate" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Leaverequestdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Leaverequestdate) ;
         }

         set {
            sdt.gxTpr_Leaverequestdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtLeaveRequest sdt
      {
         get {
            return (SdtLeaveRequest)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtLeaveRequest() ;
         }
      }

   }

}
