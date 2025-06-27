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
   [XmlRoot(ElementName = "LeaveType" )]
   [XmlType(TypeName =  "LeaveType" , Namespace = "YTT_version4" )]
   [Serializable]
   public class SdtLeaveType : GxSilentTrnSdt
   {
      public SdtLeaveType( )
      {
      }

      public SdtLeaveType( IGxContext context )
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

      public void Load( long AV124LeaveTypeId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV124LeaveTypeId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"LeaveTypeId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "LeaveType");
         metadata.Set("BT", "LeaveType");
         metadata.Set("PK", "[ \"LeaveTypeId\" ]");
         metadata.Set("PKAssigned", "[ \"LeaveTypeId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CompanyId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Leavetypeid_Z");
         state.Add("gxTpr_Leavetypename_Z");
         state.Add("gxTpr_Leavetypevacationleave_Z");
         state.Add("gxTpr_Leavetypeloggingworkhours_Z");
         state.Add("gxTpr_Leavetypecolorpending_Z");
         state.Add("gxTpr_Leavetypecolorapproved_Z");
         state.Add("gxTpr_Companyid_Z");
         state.Add("gxTpr_Leavetypecolorpending_N");
         state.Add("gxTpr_Leavetypecolorapproved_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtLeaveType sdt;
         sdt = (SdtLeaveType)(source);
         gxTv_SdtLeaveType_Leavetypeid = sdt.gxTv_SdtLeaveType_Leavetypeid ;
         gxTv_SdtLeaveType_Leavetypename = sdt.gxTv_SdtLeaveType_Leavetypename ;
         gxTv_SdtLeaveType_Leavetypevacationleave = sdt.gxTv_SdtLeaveType_Leavetypevacationleave ;
         gxTv_SdtLeaveType_Leavetypeloggingworkhours = sdt.gxTv_SdtLeaveType_Leavetypeloggingworkhours ;
         gxTv_SdtLeaveType_Leavetypecolorpending = sdt.gxTv_SdtLeaveType_Leavetypecolorpending ;
         gxTv_SdtLeaveType_Leavetypecolorapproved = sdt.gxTv_SdtLeaveType_Leavetypecolorapproved ;
         gxTv_SdtLeaveType_Companyid = sdt.gxTv_SdtLeaveType_Companyid ;
         gxTv_SdtLeaveType_Mode = sdt.gxTv_SdtLeaveType_Mode ;
         gxTv_SdtLeaveType_Initialized = sdt.gxTv_SdtLeaveType_Initialized ;
         gxTv_SdtLeaveType_Leavetypeid_Z = sdt.gxTv_SdtLeaveType_Leavetypeid_Z ;
         gxTv_SdtLeaveType_Leavetypename_Z = sdt.gxTv_SdtLeaveType_Leavetypename_Z ;
         gxTv_SdtLeaveType_Leavetypevacationleave_Z = sdt.gxTv_SdtLeaveType_Leavetypevacationleave_Z ;
         gxTv_SdtLeaveType_Leavetypeloggingworkhours_Z = sdt.gxTv_SdtLeaveType_Leavetypeloggingworkhours_Z ;
         gxTv_SdtLeaveType_Leavetypecolorpending_Z = sdt.gxTv_SdtLeaveType_Leavetypecolorpending_Z ;
         gxTv_SdtLeaveType_Leavetypecolorapproved_Z = sdt.gxTv_SdtLeaveType_Leavetypecolorapproved_Z ;
         gxTv_SdtLeaveType_Companyid_Z = sdt.gxTv_SdtLeaveType_Companyid_Z ;
         gxTv_SdtLeaveType_Leavetypecolorpending_N = sdt.gxTv_SdtLeaveType_Leavetypecolorpending_N ;
         gxTv_SdtLeaveType_Leavetypecolorapproved_N = sdt.gxTv_SdtLeaveType_Leavetypecolorapproved_N ;
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
         AddObjectProperty("LeaveTypeId", gxTv_SdtLeaveType_Leavetypeid, false, includeNonInitialized);
         AddObjectProperty("LeaveTypeName", gxTv_SdtLeaveType_Leavetypename, false, includeNonInitialized);
         AddObjectProperty("LeaveTypeVacationLeave", gxTv_SdtLeaveType_Leavetypevacationleave, false, includeNonInitialized);
         AddObjectProperty("LeaveTypeLoggingWorkHours", gxTv_SdtLeaveType_Leavetypeloggingworkhours, false, includeNonInitialized);
         AddObjectProperty("LeaveTypeColorPending", gxTv_SdtLeaveType_Leavetypecolorpending, false, includeNonInitialized);
         AddObjectProperty("LeaveTypeColorPending_N", gxTv_SdtLeaveType_Leavetypecolorpending_N, false, includeNonInitialized);
         AddObjectProperty("LeaveTypeColorApproved", gxTv_SdtLeaveType_Leavetypecolorapproved, false, includeNonInitialized);
         AddObjectProperty("LeaveTypeColorApproved_N", gxTv_SdtLeaveType_Leavetypecolorapproved_N, false, includeNonInitialized);
         AddObjectProperty("CompanyId", gxTv_SdtLeaveType_Companyid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtLeaveType_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtLeaveType_Initialized, false, includeNonInitialized);
            AddObjectProperty("LeaveTypeId_Z", gxTv_SdtLeaveType_Leavetypeid_Z, false, includeNonInitialized);
            AddObjectProperty("LeaveTypeName_Z", gxTv_SdtLeaveType_Leavetypename_Z, false, includeNonInitialized);
            AddObjectProperty("LeaveTypeVacationLeave_Z", gxTv_SdtLeaveType_Leavetypevacationleave_Z, false, includeNonInitialized);
            AddObjectProperty("LeaveTypeLoggingWorkHours_Z", gxTv_SdtLeaveType_Leavetypeloggingworkhours_Z, false, includeNonInitialized);
            AddObjectProperty("LeaveTypeColorPending_Z", gxTv_SdtLeaveType_Leavetypecolorpending_Z, false, includeNonInitialized);
            AddObjectProperty("LeaveTypeColorApproved_Z", gxTv_SdtLeaveType_Leavetypecolorapproved_Z, false, includeNonInitialized);
            AddObjectProperty("CompanyId_Z", gxTv_SdtLeaveType_Companyid_Z, false, includeNonInitialized);
            AddObjectProperty("LeaveTypeColorPending_N", gxTv_SdtLeaveType_Leavetypecolorpending_N, false, includeNonInitialized);
            AddObjectProperty("LeaveTypeColorApproved_N", gxTv_SdtLeaveType_Leavetypecolorapproved_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtLeaveType sdt )
      {
         if ( sdt.IsDirty("LeaveTypeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypeid = sdt.gxTv_SdtLeaveType_Leavetypeid ;
         }
         if ( sdt.IsDirty("LeaveTypeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypename = sdt.gxTv_SdtLeaveType_Leavetypename ;
         }
         if ( sdt.IsDirty("LeaveTypeVacationLeave") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypevacationleave = sdt.gxTv_SdtLeaveType_Leavetypevacationleave ;
         }
         if ( sdt.IsDirty("LeaveTypeLoggingWorkHours") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypeloggingworkhours = sdt.gxTv_SdtLeaveType_Leavetypeloggingworkhours ;
         }
         if ( sdt.IsDirty("LeaveTypeColorPending") )
         {
            gxTv_SdtLeaveType_Leavetypecolorpending_N = (short)(sdt.gxTv_SdtLeaveType_Leavetypecolorpending_N);
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypecolorpending = sdt.gxTv_SdtLeaveType_Leavetypecolorpending ;
         }
         if ( sdt.IsDirty("LeaveTypeColorApproved") )
         {
            gxTv_SdtLeaveType_Leavetypecolorapproved_N = (short)(sdt.gxTv_SdtLeaveType_Leavetypecolorapproved_N);
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypecolorapproved = sdt.gxTv_SdtLeaveType_Leavetypecolorapproved ;
         }
         if ( sdt.IsDirty("CompanyId") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Companyid = sdt.gxTv_SdtLeaveType_Companyid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "LeaveTypeId" )]
      [  XmlElement( ElementName = "LeaveTypeId"   )]
      public long gxTpr_Leavetypeid
      {
         get {
            return gxTv_SdtLeaveType_Leavetypeid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtLeaveType_Leavetypeid != value )
            {
               gxTv_SdtLeaveType_Mode = "INS";
               this.gxTv_SdtLeaveType_Leavetypeid_Z_SetNull( );
               this.gxTv_SdtLeaveType_Leavetypename_Z_SetNull( );
               this.gxTv_SdtLeaveType_Leavetypevacationleave_Z_SetNull( );
               this.gxTv_SdtLeaveType_Leavetypeloggingworkhours_Z_SetNull( );
               this.gxTv_SdtLeaveType_Leavetypecolorpending_Z_SetNull( );
               this.gxTv_SdtLeaveType_Leavetypecolorapproved_Z_SetNull( );
               this.gxTv_SdtLeaveType_Companyid_Z_SetNull( );
            }
            gxTv_SdtLeaveType_Leavetypeid = value;
            SetDirty("Leavetypeid");
         }

      }

      [  SoapElement( ElementName = "LeaveTypeName" )]
      [  XmlElement( ElementName = "LeaveTypeName"   )]
      public string gxTpr_Leavetypename
      {
         get {
            return gxTv_SdtLeaveType_Leavetypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypename = value;
            SetDirty("Leavetypename");
         }

      }

      [  SoapElement( ElementName = "LeaveTypeVacationLeave" )]
      [  XmlElement( ElementName = "LeaveTypeVacationLeave"   )]
      public string gxTpr_Leavetypevacationleave
      {
         get {
            return gxTv_SdtLeaveType_Leavetypevacationleave ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypevacationleave = value;
            SetDirty("Leavetypevacationleave");
         }

      }

      [  SoapElement( ElementName = "LeaveTypeLoggingWorkHours" )]
      [  XmlElement( ElementName = "LeaveTypeLoggingWorkHours"   )]
      public string gxTpr_Leavetypeloggingworkhours
      {
         get {
            return gxTv_SdtLeaveType_Leavetypeloggingworkhours ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypeloggingworkhours = value;
            SetDirty("Leavetypeloggingworkhours");
         }

      }

      [  SoapElement( ElementName = "LeaveTypeColorPending" )]
      [  XmlElement( ElementName = "LeaveTypeColorPending"   )]
      public string gxTpr_Leavetypecolorpending
      {
         get {
            return gxTv_SdtLeaveType_Leavetypecolorpending ;
         }

         set {
            gxTv_SdtLeaveType_Leavetypecolorpending_N = 0;
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypecolorpending = value;
            SetDirty("Leavetypecolorpending");
         }

      }

      public void gxTv_SdtLeaveType_Leavetypecolorpending_SetNull( )
      {
         gxTv_SdtLeaveType_Leavetypecolorpending_N = 1;
         gxTv_SdtLeaveType_Leavetypecolorpending = "";
         SetDirty("Leavetypecolorpending");
         return  ;
      }

      public bool gxTv_SdtLeaveType_Leavetypecolorpending_IsNull( )
      {
         return (gxTv_SdtLeaveType_Leavetypecolorpending_N==1) ;
      }

      [  SoapElement( ElementName = "LeaveTypeColorApproved" )]
      [  XmlElement( ElementName = "LeaveTypeColorApproved"   )]
      public string gxTpr_Leavetypecolorapproved
      {
         get {
            return gxTv_SdtLeaveType_Leavetypecolorapproved ;
         }

         set {
            gxTv_SdtLeaveType_Leavetypecolorapproved_N = 0;
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypecolorapproved = value;
            SetDirty("Leavetypecolorapproved");
         }

      }

      public void gxTv_SdtLeaveType_Leavetypecolorapproved_SetNull( )
      {
         gxTv_SdtLeaveType_Leavetypecolorapproved_N = 1;
         gxTv_SdtLeaveType_Leavetypecolorapproved = "";
         SetDirty("Leavetypecolorapproved");
         return  ;
      }

      public bool gxTv_SdtLeaveType_Leavetypecolorapproved_IsNull( )
      {
         return (gxTv_SdtLeaveType_Leavetypecolorapproved_N==1) ;
      }

      [  SoapElement( ElementName = "CompanyId" )]
      [  XmlElement( ElementName = "CompanyId"   )]
      public long gxTpr_Companyid
      {
         get {
            return gxTv_SdtLeaveType_Companyid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Companyid = value;
            SetDirty("Companyid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtLeaveType_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtLeaveType_Mode_SetNull( )
      {
         gxTv_SdtLeaveType_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtLeaveType_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtLeaveType_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtLeaveType_Initialized_SetNull( )
      {
         gxTv_SdtLeaveType_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtLeaveType_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveTypeId_Z" )]
      [  XmlElement( ElementName = "LeaveTypeId_Z"   )]
      public long gxTpr_Leavetypeid_Z
      {
         get {
            return gxTv_SdtLeaveType_Leavetypeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypeid_Z = value;
            SetDirty("Leavetypeid_Z");
         }

      }

      public void gxTv_SdtLeaveType_Leavetypeid_Z_SetNull( )
      {
         gxTv_SdtLeaveType_Leavetypeid_Z = 0;
         SetDirty("Leavetypeid_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveType_Leavetypeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveTypeName_Z" )]
      [  XmlElement( ElementName = "LeaveTypeName_Z"   )]
      public string gxTpr_Leavetypename_Z
      {
         get {
            return gxTv_SdtLeaveType_Leavetypename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypename_Z = value;
            SetDirty("Leavetypename_Z");
         }

      }

      public void gxTv_SdtLeaveType_Leavetypename_Z_SetNull( )
      {
         gxTv_SdtLeaveType_Leavetypename_Z = "";
         SetDirty("Leavetypename_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveType_Leavetypename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveTypeVacationLeave_Z" )]
      [  XmlElement( ElementName = "LeaveTypeVacationLeave_Z"   )]
      public string gxTpr_Leavetypevacationleave_Z
      {
         get {
            return gxTv_SdtLeaveType_Leavetypevacationleave_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypevacationleave_Z = value;
            SetDirty("Leavetypevacationleave_Z");
         }

      }

      public void gxTv_SdtLeaveType_Leavetypevacationleave_Z_SetNull( )
      {
         gxTv_SdtLeaveType_Leavetypevacationleave_Z = "";
         SetDirty("Leavetypevacationleave_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveType_Leavetypevacationleave_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveTypeLoggingWorkHours_Z" )]
      [  XmlElement( ElementName = "LeaveTypeLoggingWorkHours_Z"   )]
      public string gxTpr_Leavetypeloggingworkhours_Z
      {
         get {
            return gxTv_SdtLeaveType_Leavetypeloggingworkhours_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypeloggingworkhours_Z = value;
            SetDirty("Leavetypeloggingworkhours_Z");
         }

      }

      public void gxTv_SdtLeaveType_Leavetypeloggingworkhours_Z_SetNull( )
      {
         gxTv_SdtLeaveType_Leavetypeloggingworkhours_Z = "";
         SetDirty("Leavetypeloggingworkhours_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveType_Leavetypeloggingworkhours_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveTypeColorPending_Z" )]
      [  XmlElement( ElementName = "LeaveTypeColorPending_Z"   )]
      public string gxTpr_Leavetypecolorpending_Z
      {
         get {
            return gxTv_SdtLeaveType_Leavetypecolorpending_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypecolorpending_Z = value;
            SetDirty("Leavetypecolorpending_Z");
         }

      }

      public void gxTv_SdtLeaveType_Leavetypecolorpending_Z_SetNull( )
      {
         gxTv_SdtLeaveType_Leavetypecolorpending_Z = "";
         SetDirty("Leavetypecolorpending_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveType_Leavetypecolorpending_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveTypeColorApproved_Z" )]
      [  XmlElement( ElementName = "LeaveTypeColorApproved_Z"   )]
      public string gxTpr_Leavetypecolorapproved_Z
      {
         get {
            return gxTv_SdtLeaveType_Leavetypecolorapproved_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypecolorapproved_Z = value;
            SetDirty("Leavetypecolorapproved_Z");
         }

      }

      public void gxTv_SdtLeaveType_Leavetypecolorapproved_Z_SetNull( )
      {
         gxTv_SdtLeaveType_Leavetypecolorapproved_Z = "";
         SetDirty("Leavetypecolorapproved_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveType_Leavetypecolorapproved_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompanyId_Z" )]
      [  XmlElement( ElementName = "CompanyId_Z"   )]
      public long gxTpr_Companyid_Z
      {
         get {
            return gxTv_SdtLeaveType_Companyid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Companyid_Z = value;
            SetDirty("Companyid_Z");
         }

      }

      public void gxTv_SdtLeaveType_Companyid_Z_SetNull( )
      {
         gxTv_SdtLeaveType_Companyid_Z = 0;
         SetDirty("Companyid_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveType_Companyid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveTypeColorPending_N" )]
      [  XmlElement( ElementName = "LeaveTypeColorPending_N"   )]
      public short gxTpr_Leavetypecolorpending_N
      {
         get {
            return gxTv_SdtLeaveType_Leavetypecolorpending_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypecolorpending_N = value;
            SetDirty("Leavetypecolorpending_N");
         }

      }

      public void gxTv_SdtLeaveType_Leavetypecolorpending_N_SetNull( )
      {
         gxTv_SdtLeaveType_Leavetypecolorpending_N = 0;
         SetDirty("Leavetypecolorpending_N");
         return  ;
      }

      public bool gxTv_SdtLeaveType_Leavetypecolorpending_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveTypeColorApproved_N" )]
      [  XmlElement( ElementName = "LeaveTypeColorApproved_N"   )]
      public short gxTpr_Leavetypecolorapproved_N
      {
         get {
            return gxTv_SdtLeaveType_Leavetypecolorapproved_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveType_Leavetypecolorapproved_N = value;
            SetDirty("Leavetypecolorapproved_N");
         }

      }

      public void gxTv_SdtLeaveType_Leavetypecolorapproved_N_SetNull( )
      {
         gxTv_SdtLeaveType_Leavetypecolorapproved_N = 0;
         SetDirty("Leavetypecolorapproved_N");
         return  ;
      }

      public bool gxTv_SdtLeaveType_Leavetypecolorapproved_N_IsNull( )
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
         gxTv_SdtLeaveType_Leavetypename = "";
         gxTv_SdtLeaveType_Leavetypevacationleave = "";
         gxTv_SdtLeaveType_Leavetypeloggingworkhours = "";
         gxTv_SdtLeaveType_Leavetypecolorpending = "";
         gxTv_SdtLeaveType_Leavetypecolorapproved = "";
         gxTv_SdtLeaveType_Mode = "";
         gxTv_SdtLeaveType_Leavetypename_Z = "";
         gxTv_SdtLeaveType_Leavetypevacationleave_Z = "";
         gxTv_SdtLeaveType_Leavetypeloggingworkhours_Z = "";
         gxTv_SdtLeaveType_Leavetypecolorpending_Z = "";
         gxTv_SdtLeaveType_Leavetypecolorapproved_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "leavetype", "GeneXus.Programs.leavetype_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtLeaveType_Initialized ;
      private short gxTv_SdtLeaveType_Leavetypecolorpending_N ;
      private short gxTv_SdtLeaveType_Leavetypecolorapproved_N ;
      private long gxTv_SdtLeaveType_Leavetypeid ;
      private long gxTv_SdtLeaveType_Companyid ;
      private long gxTv_SdtLeaveType_Leavetypeid_Z ;
      private long gxTv_SdtLeaveType_Companyid_Z ;
      private string gxTv_SdtLeaveType_Leavetypename ;
      private string gxTv_SdtLeaveType_Leavetypevacationleave ;
      private string gxTv_SdtLeaveType_Leavetypeloggingworkhours ;
      private string gxTv_SdtLeaveType_Leavetypecolorpending ;
      private string gxTv_SdtLeaveType_Leavetypecolorapproved ;
      private string gxTv_SdtLeaveType_Mode ;
      private string gxTv_SdtLeaveType_Leavetypename_Z ;
      private string gxTv_SdtLeaveType_Leavetypevacationleave_Z ;
      private string gxTv_SdtLeaveType_Leavetypeloggingworkhours_Z ;
      private string gxTv_SdtLeaveType_Leavetypecolorpending_Z ;
      private string gxTv_SdtLeaveType_Leavetypecolorapproved_Z ;
   }

   [DataContract(Name = @"LeaveType", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtLeaveType_RESTInterface : GxGenericCollectionItem<SdtLeaveType>
   {
      public SdtLeaveType_RESTInterface( ) : base()
      {
      }

      public SdtLeaveType_RESTInterface( SdtLeaveType psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LeaveTypeId" , Order = 0 )]
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

      [DataMember( Name = "LeaveTypeName" , Order = 1 )]
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

      [DataMember( Name = "LeaveTypeVacationLeave" , Order = 2 )]
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

      [DataMember( Name = "LeaveTypeLoggingWorkHours" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Leavetypeloggingworkhours
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Leavetypeloggingworkhours) ;
         }

         set {
            sdt.gxTpr_Leavetypeloggingworkhours = value;
         }

      }

      [DataMember( Name = "LeaveTypeColorPending" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Leavetypecolorpending
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Leavetypecolorpending) ;
         }

         set {
            sdt.gxTpr_Leavetypecolorpending = value;
         }

      }

      [DataMember( Name = "LeaveTypeColorApproved" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Leavetypecolorapproved
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Leavetypecolorapproved) ;
         }

         set {
            sdt.gxTpr_Leavetypecolorapproved = value;
         }

      }

      [DataMember( Name = "CompanyId" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Companyid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Companyid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Companyid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      public SdtLeaveType sdt
      {
         get {
            return (SdtLeaveType)Sdt ;
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
            sdt = new SdtLeaveType() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 7 )]
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

   [DataContract(Name = @"LeaveType", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtLeaveType_RESTLInterface : GxGenericCollectionItem<SdtLeaveType>
   {
      public SdtLeaveType_RESTLInterface( ) : base()
      {
      }

      public SdtLeaveType_RESTLInterface( SdtLeaveType psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LeaveTypeName" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtLeaveType sdt
      {
         get {
            return (SdtLeaveType)Sdt ;
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
            sdt = new SdtLeaveType() ;
         }
      }

   }

}
