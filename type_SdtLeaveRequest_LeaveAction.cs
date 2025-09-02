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
   [XmlRoot(ElementName = "LeaveRequest.LeaveAction" )]
   [XmlType(TypeName =  "LeaveRequest.LeaveAction" , Namespace = "YTT_version4" )]
   [Serializable]
   public class SdtLeaveRequest_LeaveAction : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtLeaveRequest_LeaveAction( )
      {
      }

      public SdtLeaveRequest_LeaveAction( IGxContext context )
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

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"LeaveActionId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "LeaveAction");
         metadata.Set("BT", "LeaveRequestLeaveAction");
         metadata.Set("PK", "[ \"LeaveActionId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"LeaveRequestId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Leaveactionid_Z");
         state.Add("gxTpr_Leaveactiontype_Z");
         state.Add("gxTpr_Gamuserguid_Z");
         state.Add("gxTpr_Leaveactiondatetime_Z_Nullable");
         state.Add("gxTpr_Leaveactiondescription_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtLeaveRequest_LeaveAction sdt;
         sdt = (SdtLeaveRequest_LeaveAction)(source);
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactionid = sdt.gxTv_SdtLeaveRequest_LeaveAction_Leaveactionid ;
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype = sdt.gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype ;
         gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid = sdt.gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid ;
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime = sdt.gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime ;
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription = sdt.gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription ;
         gxTv_SdtLeaveRequest_LeaveAction_Mode = sdt.gxTv_SdtLeaveRequest_LeaveAction_Mode ;
         gxTv_SdtLeaveRequest_LeaveAction_Modified = sdt.gxTv_SdtLeaveRequest_LeaveAction_Modified ;
         gxTv_SdtLeaveRequest_LeaveAction_Initialized = sdt.gxTv_SdtLeaveRequest_LeaveAction_Initialized ;
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactionid_Z = sdt.gxTv_SdtLeaveRequest_LeaveAction_Leaveactionid_Z ;
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype_Z = sdt.gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype_Z ;
         gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid_Z = sdt.gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid_Z ;
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime_Z = sdt.gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime_Z ;
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription_Z = sdt.gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription_Z ;
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
         AddObjectProperty("LeaveActionId", gxTv_SdtLeaveRequest_LeaveAction_Leaveactionid, false, includeNonInitialized);
         AddObjectProperty("LeaveActionType", gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype, false, includeNonInitialized);
         AddObjectProperty("GAMUserGUID", gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("LeaveActionDateTime", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("LeaveActionDescription", gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtLeaveRequest_LeaveAction_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtLeaveRequest_LeaveAction_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtLeaveRequest_LeaveAction_Initialized, false, includeNonInitialized);
            AddObjectProperty("LeaveActionId_Z", gxTv_SdtLeaveRequest_LeaveAction_Leaveactionid_Z, false, includeNonInitialized);
            AddObjectProperty("LeaveActionType_Z", gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype_Z, false, includeNonInitialized);
            AddObjectProperty("GAMUserGUID_Z", gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("LeaveActionDateTime_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("LeaveActionDescription_Z", gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtLeaveRequest_LeaveAction sdt )
      {
         if ( sdt.IsDirty("LeaveActionId") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Leaveactionid = sdt.gxTv_SdtLeaveRequest_LeaveAction_Leaveactionid ;
         }
         if ( sdt.IsDirty("LeaveActionType") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype = sdt.gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype ;
         }
         if ( sdt.IsDirty("GAMUserGUID") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid = sdt.gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid ;
         }
         if ( sdt.IsDirty("LeaveActionDateTime") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime = sdt.gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime ;
         }
         if ( sdt.IsDirty("LeaveActionDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription = sdt.gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "LeaveActionId" )]
      [  XmlElement( ElementName = "LeaveActionId"   )]
      public long gxTpr_Leaveactionid
      {
         get {
            return gxTv_SdtLeaveRequest_LeaveAction_Leaveactionid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Leaveactionid = value;
            gxTv_SdtLeaveRequest_LeaveAction_Modified = 1;
            SetDirty("Leaveactionid");
         }

      }

      [  SoapElement( ElementName = "LeaveActionType" )]
      [  XmlElement( ElementName = "LeaveActionType"   )]
      public string gxTpr_Leaveactiontype
      {
         get {
            return gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype = value;
            gxTv_SdtLeaveRequest_LeaveAction_Modified = 1;
            SetDirty("Leaveactiontype");
         }

      }

      [  SoapElement( ElementName = "GAMUserGUID" )]
      [  XmlElement( ElementName = "GAMUserGUID"   )]
      public string gxTpr_Gamuserguid
      {
         get {
            return gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid = value;
            gxTv_SdtLeaveRequest_LeaveAction_Modified = 1;
            SetDirty("Gamuserguid");
         }

      }

      public void gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid_SetNull( )
      {
         gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid = "";
         SetDirty("Gamuserguid");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveActionDateTime" )]
      [  XmlElement( ElementName = "LeaveActionDateTime"  , IsNullable=true )]
      public string gxTpr_Leaveactiondatetime_Nullable
      {
         get {
            if ( gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime = DateTime.MinValue;
            else
               gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime = DateTime.Parse( value);
            gxTv_SdtLeaveRequest_LeaveAction_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaveactiondatetime
      {
         get {
            return gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime = value;
            gxTv_SdtLeaveRequest_LeaveAction_Modified = 1;
            SetDirty("Leaveactiondatetime");
         }

      }

      [  SoapElement( ElementName = "LeaveActionDescription" )]
      [  XmlElement( ElementName = "LeaveActionDescription"   )]
      public string gxTpr_Leaveactiondescription
      {
         get {
            return gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription = value;
            gxTv_SdtLeaveRequest_LeaveAction_Modified = 1;
            SetDirty("Leaveactiondescription");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtLeaveRequest_LeaveAction_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtLeaveRequest_LeaveAction_Mode_SetNull( )
      {
         gxTv_SdtLeaveRequest_LeaveAction_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_LeaveAction_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtLeaveRequest_LeaveAction_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtLeaveRequest_LeaveAction_Modified_SetNull( )
      {
         gxTv_SdtLeaveRequest_LeaveAction_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_LeaveAction_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtLeaveRequest_LeaveAction_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Initialized = value;
            gxTv_SdtLeaveRequest_LeaveAction_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtLeaveRequest_LeaveAction_Initialized_SetNull( )
      {
         gxTv_SdtLeaveRequest_LeaveAction_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_LeaveAction_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveActionId_Z" )]
      [  XmlElement( ElementName = "LeaveActionId_Z"   )]
      public long gxTpr_Leaveactionid_Z
      {
         get {
            return gxTv_SdtLeaveRequest_LeaveAction_Leaveactionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Leaveactionid_Z = value;
            gxTv_SdtLeaveRequest_LeaveAction_Modified = 1;
            SetDirty("Leaveactionid_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_LeaveAction_Leaveactionid_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactionid_Z = 0;
         SetDirty("Leaveactionid_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_LeaveAction_Leaveactionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveActionType_Z" )]
      [  XmlElement( ElementName = "LeaveActionType_Z"   )]
      public string gxTpr_Leaveactiontype_Z
      {
         get {
            return gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype_Z = value;
            gxTv_SdtLeaveRequest_LeaveAction_Modified = 1;
            SetDirty("Leaveactiontype_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype_Z = "";
         SetDirty("Leaveactiontype_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GAMUserGUID_Z" )]
      [  XmlElement( ElementName = "GAMUserGUID_Z"   )]
      public string gxTpr_Gamuserguid_Z
      {
         get {
            return gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid_Z = value;
            gxTv_SdtLeaveRequest_LeaveAction_Modified = 1;
            SetDirty("Gamuserguid_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid_Z = "";
         SetDirty("Gamuserguid_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveActionDateTime_Z" )]
      [  XmlElement( ElementName = "LeaveActionDateTime_Z"  , IsNullable=true )]
      public string gxTpr_Leaveactiondatetime_Z_Nullable
      {
         get {
            if ( gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime_Z = DateTime.MinValue;
            else
               gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime_Z = DateTime.Parse( value);
            gxTv_SdtLeaveRequest_LeaveAction_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaveactiondatetime_Z
      {
         get {
            return gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime_Z = value;
            gxTv_SdtLeaveRequest_LeaveAction_Modified = 1;
            SetDirty("Leaveactiondatetime_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Leaveactiondatetime_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LeaveActionDescription_Z" )]
      [  XmlElement( ElementName = "LeaveActionDescription_Z"   )]
      public string gxTpr_Leaveactiondescription_Z
      {
         get {
            return gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription_Z = value;
            gxTv_SdtLeaveRequest_LeaveAction_Modified = 1;
            SetDirty("Leaveactiondescription_Z");
         }

      }

      public void gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription_Z_SetNull( )
      {
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription_Z = "";
         SetDirty("Leaveactiondescription_Z");
         return  ;
      }

      public bool gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription_Z_IsNull( )
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
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype = "";
         gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid = "";
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime = (DateTime)(DateTime.MinValue);
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription = "";
         gxTv_SdtLeaveRequest_LeaveAction_Mode = "";
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype_Z = "";
         gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid_Z = "";
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtLeaveRequest_LeaveAction_Modified ;
      private short gxTv_SdtLeaveRequest_LeaveAction_Initialized ;
      private long gxTv_SdtLeaveRequest_LeaveAction_Leaveactionid ;
      private long gxTv_SdtLeaveRequest_LeaveAction_Leaveactionid_Z ;
      private string gxTv_SdtLeaveRequest_LeaveAction_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime ;
      private DateTime gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondatetime_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype ;
      private string gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid ;
      private string gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription ;
      private string gxTv_SdtLeaveRequest_LeaveAction_Leaveactiontype_Z ;
      private string gxTv_SdtLeaveRequest_LeaveAction_Gamuserguid_Z ;
      private string gxTv_SdtLeaveRequest_LeaveAction_Leaveactiondescription_Z ;
   }

   [DataContract(Name = @"LeaveRequest.LeaveAction", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtLeaveRequest_LeaveAction_RESTInterface : GxGenericCollectionItem<SdtLeaveRequest_LeaveAction>
   {
      public SdtLeaveRequest_LeaveAction_RESTInterface( ) : base()
      {
      }

      public SdtLeaveRequest_LeaveAction_RESTInterface( SdtLeaveRequest_LeaveAction psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LeaveActionId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Leaveactionid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Leaveactionid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Leaveactionid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "LeaveActionType" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Leaveactiontype
      {
         get {
            return sdt.gxTpr_Leaveactiontype ;
         }

         set {
            sdt.gxTpr_Leaveactiontype = value;
         }

      }

      [DataMember( Name = "GAMUserGUID" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Gamuserguid
      {
         get {
            return sdt.gxTpr_Gamuserguid ;
         }

         set {
            sdt.gxTpr_Gamuserguid = value;
         }

      }

      [DataMember( Name = "LeaveActionDateTime" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Leaveactiondatetime
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Leaveactiondatetime, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Leaveactiondatetime = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "LeaveActionDescription" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Leaveactiondescription
      {
         get {
            return sdt.gxTpr_Leaveactiondescription ;
         }

         set {
            sdt.gxTpr_Leaveactiondescription = value;
         }

      }

      public SdtLeaveRequest_LeaveAction sdt
      {
         get {
            return (SdtLeaveRequest_LeaveAction)Sdt ;
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
            sdt = new SdtLeaveRequest_LeaveAction() ;
         }
      }

   }

   [DataContract(Name = @"LeaveRequest.LeaveAction", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtLeaveRequest_LeaveAction_RESTLInterface : GxGenericCollectionItem<SdtLeaveRequest_LeaveAction>
   {
      public SdtLeaveRequest_LeaveAction_RESTLInterface( ) : base()
      {
      }

      public SdtLeaveRequest_LeaveAction_RESTLInterface( SdtLeaveRequest_LeaveAction psdt ) : base(psdt)
      {
      }

      public SdtLeaveRequest_LeaveAction sdt
      {
         get {
            return (SdtLeaveRequest_LeaveAction)Sdt ;
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
            sdt = new SdtLeaveRequest_LeaveAction() ;
         }
      }

   }

}
