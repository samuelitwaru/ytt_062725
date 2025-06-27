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
   [XmlRoot(ElementName = "WorkHourLog" )]
   [XmlType(TypeName =  "WorkHourLog" , Namespace = "YTT_version4" )]
   [Serializable]
   public class SdtWorkHourLog : GxSilentTrnSdt
   {
      public SdtWorkHourLog( )
      {
      }

      public SdtWorkHourLog( IGxContext context )
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

      public void Load( long AV118WorkHourLogId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV118WorkHourLogId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WorkHourLogId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WorkHourLog");
         metadata.Set("BT", "WorkHourLog");
         metadata.Set("PK", "[ \"WorkHourLogId\" ]");
         metadata.Set("PKAssigned", "[ \"WorkHourLogId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"EmployeeId\",\"ProjectId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Workhourlogid_Z");
         state.Add("gxTpr_Workhourlogdate_Z_Nullable");
         state.Add("gxTpr_Workhourlogduration_Z");
         state.Add("gxTpr_Workhourloghour_Z");
         state.Add("gxTpr_Workhourlogminute_Z");
         state.Add("gxTpr_Employeeid_Z");
         state.Add("gxTpr_Employeefirstname_Z");
         state.Add("gxTpr_Projectid_Z");
         state.Add("gxTpr_Projectname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtWorkHourLog sdt;
         sdt = (SdtWorkHourLog)(source);
         gxTv_SdtWorkHourLog_Workhourlogid = sdt.gxTv_SdtWorkHourLog_Workhourlogid ;
         gxTv_SdtWorkHourLog_Workhourlogdate = sdt.gxTv_SdtWorkHourLog_Workhourlogdate ;
         gxTv_SdtWorkHourLog_Workhourlogduration = sdt.gxTv_SdtWorkHourLog_Workhourlogduration ;
         gxTv_SdtWorkHourLog_Workhourloghour = sdt.gxTv_SdtWorkHourLog_Workhourloghour ;
         gxTv_SdtWorkHourLog_Workhourlogminute = sdt.gxTv_SdtWorkHourLog_Workhourlogminute ;
         gxTv_SdtWorkHourLog_Workhourlogdescription = sdt.gxTv_SdtWorkHourLog_Workhourlogdescription ;
         gxTv_SdtWorkHourLog_Employeeid = sdt.gxTv_SdtWorkHourLog_Employeeid ;
         gxTv_SdtWorkHourLog_Employeefirstname = sdt.gxTv_SdtWorkHourLog_Employeefirstname ;
         gxTv_SdtWorkHourLog_Projectid = sdt.gxTv_SdtWorkHourLog_Projectid ;
         gxTv_SdtWorkHourLog_Projectname = sdt.gxTv_SdtWorkHourLog_Projectname ;
         gxTv_SdtWorkHourLog_Mode = sdt.gxTv_SdtWorkHourLog_Mode ;
         gxTv_SdtWorkHourLog_Initialized = sdt.gxTv_SdtWorkHourLog_Initialized ;
         gxTv_SdtWorkHourLog_Workhourlogid_Z = sdt.gxTv_SdtWorkHourLog_Workhourlogid_Z ;
         gxTv_SdtWorkHourLog_Workhourlogdate_Z = sdt.gxTv_SdtWorkHourLog_Workhourlogdate_Z ;
         gxTv_SdtWorkHourLog_Workhourlogduration_Z = sdt.gxTv_SdtWorkHourLog_Workhourlogduration_Z ;
         gxTv_SdtWorkHourLog_Workhourloghour_Z = sdt.gxTv_SdtWorkHourLog_Workhourloghour_Z ;
         gxTv_SdtWorkHourLog_Workhourlogminute_Z = sdt.gxTv_SdtWorkHourLog_Workhourlogminute_Z ;
         gxTv_SdtWorkHourLog_Employeeid_Z = sdt.gxTv_SdtWorkHourLog_Employeeid_Z ;
         gxTv_SdtWorkHourLog_Employeefirstname_Z = sdt.gxTv_SdtWorkHourLog_Employeefirstname_Z ;
         gxTv_SdtWorkHourLog_Projectid_Z = sdt.gxTv_SdtWorkHourLog_Projectid_Z ;
         gxTv_SdtWorkHourLog_Projectname_Z = sdt.gxTv_SdtWorkHourLog_Projectname_Z ;
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
         AddObjectProperty("WorkHourLogId", gxTv_SdtWorkHourLog_Workhourlogid, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtWorkHourLog_Workhourlogdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtWorkHourLog_Workhourlogdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtWorkHourLog_Workhourlogdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("WorkHourLogDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("WorkHourLogDuration", gxTv_SdtWorkHourLog_Workhourlogduration, false, includeNonInitialized);
         AddObjectProperty("WorkHourLogHour", gxTv_SdtWorkHourLog_Workhourloghour, false, includeNonInitialized);
         AddObjectProperty("WorkHourLogMinute", gxTv_SdtWorkHourLog_Workhourlogminute, false, includeNonInitialized);
         AddObjectProperty("WorkHourLogDescription", gxTv_SdtWorkHourLog_Workhourlogdescription, false, includeNonInitialized);
         AddObjectProperty("EmployeeId", gxTv_SdtWorkHourLog_Employeeid, false, includeNonInitialized);
         AddObjectProperty("EmployeeFirstName", gxTv_SdtWorkHourLog_Employeefirstname, false, includeNonInitialized);
         AddObjectProperty("ProjectId", gxTv_SdtWorkHourLog_Projectid, false, includeNonInitialized);
         AddObjectProperty("ProjectName", gxTv_SdtWorkHourLog_Projectname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWorkHourLog_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWorkHourLog_Initialized, false, includeNonInitialized);
            AddObjectProperty("WorkHourLogId_Z", gxTv_SdtWorkHourLog_Workhourlogid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtWorkHourLog_Workhourlogdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtWorkHourLog_Workhourlogdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtWorkHourLog_Workhourlogdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("WorkHourLogDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("WorkHourLogDuration_Z", gxTv_SdtWorkHourLog_Workhourlogduration_Z, false, includeNonInitialized);
            AddObjectProperty("WorkHourLogHour_Z", gxTv_SdtWorkHourLog_Workhourloghour_Z, false, includeNonInitialized);
            AddObjectProperty("WorkHourLogMinute_Z", gxTv_SdtWorkHourLog_Workhourlogminute_Z, false, includeNonInitialized);
            AddObjectProperty("EmployeeId_Z", gxTv_SdtWorkHourLog_Employeeid_Z, false, includeNonInitialized);
            AddObjectProperty("EmployeeFirstName_Z", gxTv_SdtWorkHourLog_Employeefirstname_Z, false, includeNonInitialized);
            AddObjectProperty("ProjectId_Z", gxTv_SdtWorkHourLog_Projectid_Z, false, includeNonInitialized);
            AddObjectProperty("ProjectName_Z", gxTv_SdtWorkHourLog_Projectname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtWorkHourLog sdt )
      {
         if ( sdt.IsDirty("WorkHourLogId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Workhourlogid = sdt.gxTv_SdtWorkHourLog_Workhourlogid ;
         }
         if ( sdt.IsDirty("WorkHourLogDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Workhourlogdate = sdt.gxTv_SdtWorkHourLog_Workhourlogdate ;
         }
         if ( sdt.IsDirty("WorkHourLogDuration") )
         {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Workhourlogduration = sdt.gxTv_SdtWorkHourLog_Workhourlogduration ;
         }
         if ( sdt.IsDirty("WorkHourLogHour") )
         {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Workhourloghour = sdt.gxTv_SdtWorkHourLog_Workhourloghour ;
         }
         if ( sdt.IsDirty("WorkHourLogMinute") )
         {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Workhourlogminute = sdt.gxTv_SdtWorkHourLog_Workhourlogminute ;
         }
         if ( sdt.IsDirty("WorkHourLogDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Workhourlogdescription = sdt.gxTv_SdtWorkHourLog_Workhourlogdescription ;
         }
         if ( sdt.IsDirty("EmployeeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Employeeid = sdt.gxTv_SdtWorkHourLog_Employeeid ;
         }
         if ( sdt.IsDirty("EmployeeFirstName") )
         {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Employeefirstname = sdt.gxTv_SdtWorkHourLog_Employeefirstname ;
         }
         if ( sdt.IsDirty("ProjectId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Projectid = sdt.gxTv_SdtWorkHourLog_Projectid ;
         }
         if ( sdt.IsDirty("ProjectName") )
         {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Projectname = sdt.gxTv_SdtWorkHourLog_Projectname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WorkHourLogId" )]
      [  XmlElement( ElementName = "WorkHourLogId"   )]
      public long gxTpr_Workhourlogid
      {
         get {
            return gxTv_SdtWorkHourLog_Workhourlogid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtWorkHourLog_Workhourlogid != value )
            {
               gxTv_SdtWorkHourLog_Mode = "INS";
               this.gxTv_SdtWorkHourLog_Workhourlogid_Z_SetNull( );
               this.gxTv_SdtWorkHourLog_Workhourlogdate_Z_SetNull( );
               this.gxTv_SdtWorkHourLog_Workhourlogduration_Z_SetNull( );
               this.gxTv_SdtWorkHourLog_Workhourloghour_Z_SetNull( );
               this.gxTv_SdtWorkHourLog_Workhourlogminute_Z_SetNull( );
               this.gxTv_SdtWorkHourLog_Employeeid_Z_SetNull( );
               this.gxTv_SdtWorkHourLog_Employeefirstname_Z_SetNull( );
               this.gxTv_SdtWorkHourLog_Projectid_Z_SetNull( );
               this.gxTv_SdtWorkHourLog_Projectname_Z_SetNull( );
            }
            gxTv_SdtWorkHourLog_Workhourlogid = value;
            SetDirty("Workhourlogid");
         }

      }

      [  SoapElement( ElementName = "WorkHourLogDate" )]
      [  XmlElement( ElementName = "WorkHourLogDate"  , IsNullable=true )]
      public string gxTpr_Workhourlogdate_Nullable
      {
         get {
            if ( gxTv_SdtWorkHourLog_Workhourlogdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtWorkHourLog_Workhourlogdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtWorkHourLog_Workhourlogdate = DateTime.MinValue;
            else
               gxTv_SdtWorkHourLog_Workhourlogdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Workhourlogdate
      {
         get {
            return gxTv_SdtWorkHourLog_Workhourlogdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Workhourlogdate = value;
            SetDirty("Workhourlogdate");
         }

      }

      [  SoapElement( ElementName = "WorkHourLogDuration" )]
      [  XmlElement( ElementName = "WorkHourLogDuration"   )]
      public string gxTpr_Workhourlogduration
      {
         get {
            return gxTv_SdtWorkHourLog_Workhourlogduration ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Workhourlogduration = value;
            SetDirty("Workhourlogduration");
         }

      }

      [  SoapElement( ElementName = "WorkHourLogHour" )]
      [  XmlElement( ElementName = "WorkHourLogHour"   )]
      public short gxTpr_Workhourloghour
      {
         get {
            return gxTv_SdtWorkHourLog_Workhourloghour ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Workhourloghour = value;
            SetDirty("Workhourloghour");
         }

      }

      [  SoapElement( ElementName = "WorkHourLogMinute" )]
      [  XmlElement( ElementName = "WorkHourLogMinute"   )]
      public short gxTpr_Workhourlogminute
      {
         get {
            return gxTv_SdtWorkHourLog_Workhourlogminute ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Workhourlogminute = value;
            SetDirty("Workhourlogminute");
         }

      }

      [  SoapElement( ElementName = "WorkHourLogDescription" )]
      [  XmlElement( ElementName = "WorkHourLogDescription"   )]
      public string gxTpr_Workhourlogdescription
      {
         get {
            return gxTv_SdtWorkHourLog_Workhourlogdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Workhourlogdescription = value;
            SetDirty("Workhourlogdescription");
         }

      }

      [  SoapElement( ElementName = "EmployeeId" )]
      [  XmlElement( ElementName = "EmployeeId"   )]
      public long gxTpr_Employeeid
      {
         get {
            return gxTv_SdtWorkHourLog_Employeeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Employeeid = value;
            SetDirty("Employeeid");
         }

      }

      [  SoapElement( ElementName = "EmployeeFirstName" )]
      [  XmlElement( ElementName = "EmployeeFirstName"   )]
      public string gxTpr_Employeefirstname
      {
         get {
            return gxTv_SdtWorkHourLog_Employeefirstname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Employeefirstname = value;
            SetDirty("Employeefirstname");
         }

      }

      [  SoapElement( ElementName = "ProjectId" )]
      [  XmlElement( ElementName = "ProjectId"   )]
      public long gxTpr_Projectid
      {
         get {
            return gxTv_SdtWorkHourLog_Projectid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Projectid = value;
            SetDirty("Projectid");
         }

      }

      [  SoapElement( ElementName = "ProjectName" )]
      [  XmlElement( ElementName = "ProjectName"   )]
      public string gxTpr_Projectname
      {
         get {
            return gxTv_SdtWorkHourLog_Projectname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Projectname = value;
            SetDirty("Projectname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWorkHourLog_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWorkHourLog_Mode_SetNull( )
      {
         gxTv_SdtWorkHourLog_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtWorkHourLog_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWorkHourLog_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWorkHourLog_Initialized_SetNull( )
      {
         gxTv_SdtWorkHourLog_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtWorkHourLog_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkHourLogId_Z" )]
      [  XmlElement( ElementName = "WorkHourLogId_Z"   )]
      public long gxTpr_Workhourlogid_Z
      {
         get {
            return gxTv_SdtWorkHourLog_Workhourlogid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Workhourlogid_Z = value;
            SetDirty("Workhourlogid_Z");
         }

      }

      public void gxTv_SdtWorkHourLog_Workhourlogid_Z_SetNull( )
      {
         gxTv_SdtWorkHourLog_Workhourlogid_Z = 0;
         SetDirty("Workhourlogid_Z");
         return  ;
      }

      public bool gxTv_SdtWorkHourLog_Workhourlogid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkHourLogDate_Z" )]
      [  XmlElement( ElementName = "WorkHourLogDate_Z"  , IsNullable=true )]
      public string gxTpr_Workhourlogdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtWorkHourLog_Workhourlogdate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtWorkHourLog_Workhourlogdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtWorkHourLog_Workhourlogdate_Z = DateTime.MinValue;
            else
               gxTv_SdtWorkHourLog_Workhourlogdate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Workhourlogdate_Z
      {
         get {
            return gxTv_SdtWorkHourLog_Workhourlogdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Workhourlogdate_Z = value;
            SetDirty("Workhourlogdate_Z");
         }

      }

      public void gxTv_SdtWorkHourLog_Workhourlogdate_Z_SetNull( )
      {
         gxTv_SdtWorkHourLog_Workhourlogdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Workhourlogdate_Z");
         return  ;
      }

      public bool gxTv_SdtWorkHourLog_Workhourlogdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkHourLogDuration_Z" )]
      [  XmlElement( ElementName = "WorkHourLogDuration_Z"   )]
      public string gxTpr_Workhourlogduration_Z
      {
         get {
            return gxTv_SdtWorkHourLog_Workhourlogduration_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Workhourlogduration_Z = value;
            SetDirty("Workhourlogduration_Z");
         }

      }

      public void gxTv_SdtWorkHourLog_Workhourlogduration_Z_SetNull( )
      {
         gxTv_SdtWorkHourLog_Workhourlogduration_Z = "";
         SetDirty("Workhourlogduration_Z");
         return  ;
      }

      public bool gxTv_SdtWorkHourLog_Workhourlogduration_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkHourLogHour_Z" )]
      [  XmlElement( ElementName = "WorkHourLogHour_Z"   )]
      public short gxTpr_Workhourloghour_Z
      {
         get {
            return gxTv_SdtWorkHourLog_Workhourloghour_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Workhourloghour_Z = value;
            SetDirty("Workhourloghour_Z");
         }

      }

      public void gxTv_SdtWorkHourLog_Workhourloghour_Z_SetNull( )
      {
         gxTv_SdtWorkHourLog_Workhourloghour_Z = 0;
         SetDirty("Workhourloghour_Z");
         return  ;
      }

      public bool gxTv_SdtWorkHourLog_Workhourloghour_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkHourLogMinute_Z" )]
      [  XmlElement( ElementName = "WorkHourLogMinute_Z"   )]
      public short gxTpr_Workhourlogminute_Z
      {
         get {
            return gxTv_SdtWorkHourLog_Workhourlogminute_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Workhourlogminute_Z = value;
            SetDirty("Workhourlogminute_Z");
         }

      }

      public void gxTv_SdtWorkHourLog_Workhourlogminute_Z_SetNull( )
      {
         gxTv_SdtWorkHourLog_Workhourlogminute_Z = 0;
         SetDirty("Workhourlogminute_Z");
         return  ;
      }

      public bool gxTv_SdtWorkHourLog_Workhourlogminute_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeId_Z" )]
      [  XmlElement( ElementName = "EmployeeId_Z"   )]
      public long gxTpr_Employeeid_Z
      {
         get {
            return gxTv_SdtWorkHourLog_Employeeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Employeeid_Z = value;
            SetDirty("Employeeid_Z");
         }

      }

      public void gxTv_SdtWorkHourLog_Employeeid_Z_SetNull( )
      {
         gxTv_SdtWorkHourLog_Employeeid_Z = 0;
         SetDirty("Employeeid_Z");
         return  ;
      }

      public bool gxTv_SdtWorkHourLog_Employeeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeFirstName_Z" )]
      [  XmlElement( ElementName = "EmployeeFirstName_Z"   )]
      public string gxTpr_Employeefirstname_Z
      {
         get {
            return gxTv_SdtWorkHourLog_Employeefirstname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Employeefirstname_Z = value;
            SetDirty("Employeefirstname_Z");
         }

      }

      public void gxTv_SdtWorkHourLog_Employeefirstname_Z_SetNull( )
      {
         gxTv_SdtWorkHourLog_Employeefirstname_Z = "";
         SetDirty("Employeefirstname_Z");
         return  ;
      }

      public bool gxTv_SdtWorkHourLog_Employeefirstname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProjectId_Z" )]
      [  XmlElement( ElementName = "ProjectId_Z"   )]
      public long gxTpr_Projectid_Z
      {
         get {
            return gxTv_SdtWorkHourLog_Projectid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Projectid_Z = value;
            SetDirty("Projectid_Z");
         }

      }

      public void gxTv_SdtWorkHourLog_Projectid_Z_SetNull( )
      {
         gxTv_SdtWorkHourLog_Projectid_Z = 0;
         SetDirty("Projectid_Z");
         return  ;
      }

      public bool gxTv_SdtWorkHourLog_Projectid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProjectName_Z" )]
      [  XmlElement( ElementName = "ProjectName_Z"   )]
      public string gxTpr_Projectname_Z
      {
         get {
            return gxTv_SdtWorkHourLog_Projectname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkHourLog_Projectname_Z = value;
            SetDirty("Projectname_Z");
         }

      }

      public void gxTv_SdtWorkHourLog_Projectname_Z_SetNull( )
      {
         gxTv_SdtWorkHourLog_Projectname_Z = "";
         SetDirty("Projectname_Z");
         return  ;
      }

      public bool gxTv_SdtWorkHourLog_Projectname_Z_IsNull( )
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
         gxTv_SdtWorkHourLog_Workhourlogdate = DateTime.MinValue;
         gxTv_SdtWorkHourLog_Workhourlogduration = "";
         gxTv_SdtWorkHourLog_Workhourlogdescription = "";
         gxTv_SdtWorkHourLog_Employeefirstname = "";
         gxTv_SdtWorkHourLog_Projectname = "";
         gxTv_SdtWorkHourLog_Mode = "";
         gxTv_SdtWorkHourLog_Workhourlogdate_Z = DateTime.MinValue;
         gxTv_SdtWorkHourLog_Workhourlogduration_Z = "";
         gxTv_SdtWorkHourLog_Employeefirstname_Z = "";
         gxTv_SdtWorkHourLog_Projectname_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "workhourlog", "GeneXus.Programs.workhourlog_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtWorkHourLog_Workhourloghour ;
      private short gxTv_SdtWorkHourLog_Workhourlogminute ;
      private short gxTv_SdtWorkHourLog_Initialized ;
      private short gxTv_SdtWorkHourLog_Workhourloghour_Z ;
      private short gxTv_SdtWorkHourLog_Workhourlogminute_Z ;
      private long gxTv_SdtWorkHourLog_Workhourlogid ;
      private long gxTv_SdtWorkHourLog_Employeeid ;
      private long gxTv_SdtWorkHourLog_Projectid ;
      private long gxTv_SdtWorkHourLog_Workhourlogid_Z ;
      private long gxTv_SdtWorkHourLog_Employeeid_Z ;
      private long gxTv_SdtWorkHourLog_Projectid_Z ;
      private string gxTv_SdtWorkHourLog_Employeefirstname ;
      private string gxTv_SdtWorkHourLog_Projectname ;
      private string gxTv_SdtWorkHourLog_Mode ;
      private string gxTv_SdtWorkHourLog_Employeefirstname_Z ;
      private string gxTv_SdtWorkHourLog_Projectname_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtWorkHourLog_Workhourlogdate ;
      private DateTime gxTv_SdtWorkHourLog_Workhourlogdate_Z ;
      private string gxTv_SdtWorkHourLog_Workhourlogdescription ;
      private string gxTv_SdtWorkHourLog_Workhourlogduration ;
      private string gxTv_SdtWorkHourLog_Workhourlogduration_Z ;
   }

   [DataContract(Name = @"WorkHourLog", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtWorkHourLog_RESTInterface : GxGenericCollectionItem<SdtWorkHourLog>
   {
      public SdtWorkHourLog_RESTInterface( ) : base()
      {
      }

      public SdtWorkHourLog_RESTInterface( SdtWorkHourLog psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WorkHourLogId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Workhourlogid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Workhourlogid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Workhourlogid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "WorkHourLogDate" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Workhourlogdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Workhourlogdate) ;
         }

         set {
            sdt.gxTpr_Workhourlogdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "WorkHourLogDuration" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Workhourlogduration
      {
         get {
            return sdt.gxTpr_Workhourlogduration ;
         }

         set {
            sdt.gxTpr_Workhourlogduration = value;
         }

      }

      [DataMember( Name = "WorkHourLogHour" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Workhourloghour
      {
         get {
            return sdt.gxTpr_Workhourloghour ;
         }

         set {
            sdt.gxTpr_Workhourloghour = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WorkHourLogMinute" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Workhourlogminute
      {
         get {
            return sdt.gxTpr_Workhourlogminute ;
         }

         set {
            sdt.gxTpr_Workhourlogminute = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WorkHourLogDescription" , Order = 5 )]
      public string gxTpr_Workhourlogdescription
      {
         get {
            return sdt.gxTpr_Workhourlogdescription ;
         }

         set {
            sdt.gxTpr_Workhourlogdescription = value;
         }

      }

      [DataMember( Name = "EmployeeId" , Order = 6 )]
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

      [DataMember( Name = "EmployeeFirstName" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Employeefirstname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Employeefirstname) ;
         }

         set {
            sdt.gxTpr_Employeefirstname = value;
         }

      }

      [DataMember( Name = "ProjectId" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Projectid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Projectid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Projectid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ProjectName" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Projectname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Projectname) ;
         }

         set {
            sdt.gxTpr_Projectname = value;
         }

      }

      public SdtWorkHourLog sdt
      {
         get {
            return (SdtWorkHourLog)Sdt ;
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
            sdt = new SdtWorkHourLog() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 10 )]
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

   [DataContract(Name = @"WorkHourLog", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtWorkHourLog_RESTLInterface : GxGenericCollectionItem<SdtWorkHourLog>
   {
      public SdtWorkHourLog_RESTLInterface( ) : base()
      {
      }

      public SdtWorkHourLog_RESTLInterface( SdtWorkHourLog psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WorkHourLogDate" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Workhourlogdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Workhourlogdate) ;
         }

         set {
            sdt.gxTpr_Workhourlogdate = DateTimeUtil.CToD2( value);
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

      public SdtWorkHourLog sdt
      {
         get {
            return (SdtWorkHourLog)Sdt ;
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
            sdt = new SdtWorkHourLog() ;
         }
      }

   }

}
