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
   [XmlRoot(ElementName = "Device" )]
   [XmlType(TypeName =  "Device" , Namespace = "YTT_version4" )]
   [Serializable]
   public class SdtDevice : GxSilentTrnSdt
   {
      public SdtDevice( )
      {
      }

      public SdtDevice( IGxContext context )
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

      public void Load( string AV151DeviceId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(string)AV151DeviceId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"DeviceId", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Device");
         metadata.Set("BT", "Device");
         metadata.Set("PK", "[ \"DeviceId\" ]");
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
         state.Add("gxTpr_Deviceid_Z");
         state.Add("gxTpr_Devicetype_Z");
         state.Add("gxTpr_Devicetoken_Z");
         state.Add("gxTpr_Devicename_Z");
         state.Add("gxTpr_Deviceuser_Z");
         state.Add("gxTpr_Deviceuser_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtDevice sdt;
         sdt = (SdtDevice)(source);
         gxTv_SdtDevice_Deviceid = sdt.gxTv_SdtDevice_Deviceid ;
         gxTv_SdtDevice_Devicetype = sdt.gxTv_SdtDevice_Devicetype ;
         gxTv_SdtDevice_Devicetoken = sdt.gxTv_SdtDevice_Devicetoken ;
         gxTv_SdtDevice_Devicename = sdt.gxTv_SdtDevice_Devicename ;
         gxTv_SdtDevice_Deviceuser = sdt.gxTv_SdtDevice_Deviceuser ;
         gxTv_SdtDevice_Mode = sdt.gxTv_SdtDevice_Mode ;
         gxTv_SdtDevice_Initialized = sdt.gxTv_SdtDevice_Initialized ;
         gxTv_SdtDevice_Deviceid_Z = sdt.gxTv_SdtDevice_Deviceid_Z ;
         gxTv_SdtDevice_Devicetype_Z = sdt.gxTv_SdtDevice_Devicetype_Z ;
         gxTv_SdtDevice_Devicetoken_Z = sdt.gxTv_SdtDevice_Devicetoken_Z ;
         gxTv_SdtDevice_Devicename_Z = sdt.gxTv_SdtDevice_Devicename_Z ;
         gxTv_SdtDevice_Deviceuser_Z = sdt.gxTv_SdtDevice_Deviceuser_Z ;
         gxTv_SdtDevice_Deviceuser_N = sdt.gxTv_SdtDevice_Deviceuser_N ;
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
         AddObjectProperty("DeviceId", gxTv_SdtDevice_Deviceid, false, includeNonInitialized);
         AddObjectProperty("DeviceType", gxTv_SdtDevice_Devicetype, false, includeNonInitialized);
         AddObjectProperty("DeviceToken", gxTv_SdtDevice_Devicetoken, false, includeNonInitialized);
         AddObjectProperty("DeviceName", gxTv_SdtDevice_Devicename, false, includeNonInitialized);
         AddObjectProperty("DeviceUser", gxTv_SdtDevice_Deviceuser, false, includeNonInitialized);
         AddObjectProperty("DeviceUser_N", gxTv_SdtDevice_Deviceuser_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDevice_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDevice_Initialized, false, includeNonInitialized);
            AddObjectProperty("DeviceId_Z", gxTv_SdtDevice_Deviceid_Z, false, includeNonInitialized);
            AddObjectProperty("DeviceType_Z", gxTv_SdtDevice_Devicetype_Z, false, includeNonInitialized);
            AddObjectProperty("DeviceToken_Z", gxTv_SdtDevice_Devicetoken_Z, false, includeNonInitialized);
            AddObjectProperty("DeviceName_Z", gxTv_SdtDevice_Devicename_Z, false, includeNonInitialized);
            AddObjectProperty("DeviceUser_Z", gxTv_SdtDevice_Deviceuser_Z, false, includeNonInitialized);
            AddObjectProperty("DeviceUser_N", gxTv_SdtDevice_Deviceuser_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtDevice sdt )
      {
         if ( sdt.IsDirty("DeviceId") )
         {
            sdtIsNull = 0;
            gxTv_SdtDevice_Deviceid = sdt.gxTv_SdtDevice_Deviceid ;
         }
         if ( sdt.IsDirty("DeviceType") )
         {
            sdtIsNull = 0;
            gxTv_SdtDevice_Devicetype = sdt.gxTv_SdtDevice_Devicetype ;
         }
         if ( sdt.IsDirty("DeviceToken") )
         {
            sdtIsNull = 0;
            gxTv_SdtDevice_Devicetoken = sdt.gxTv_SdtDevice_Devicetoken ;
         }
         if ( sdt.IsDirty("DeviceName") )
         {
            sdtIsNull = 0;
            gxTv_SdtDevice_Devicename = sdt.gxTv_SdtDevice_Devicename ;
         }
         if ( sdt.IsDirty("DeviceUser") )
         {
            gxTv_SdtDevice_Deviceuser_N = (short)(sdt.gxTv_SdtDevice_Deviceuser_N);
            sdtIsNull = 0;
            gxTv_SdtDevice_Deviceuser = sdt.gxTv_SdtDevice_Deviceuser ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "DeviceId" )]
      [  XmlElement( ElementName = "DeviceId"   )]
      public string gxTpr_Deviceid
      {
         get {
            return gxTv_SdtDevice_Deviceid ;
         }

         set {
            sdtIsNull = 0;
            if ( StringUtil.StrCmp(gxTv_SdtDevice_Deviceid, value) != 0 )
            {
               gxTv_SdtDevice_Mode = "INS";
               this.gxTv_SdtDevice_Deviceid_Z_SetNull( );
               this.gxTv_SdtDevice_Devicetype_Z_SetNull( );
               this.gxTv_SdtDevice_Devicetoken_Z_SetNull( );
               this.gxTv_SdtDevice_Devicename_Z_SetNull( );
               this.gxTv_SdtDevice_Deviceuser_Z_SetNull( );
            }
            gxTv_SdtDevice_Deviceid = value;
            SetDirty("Deviceid");
         }

      }

      [  SoapElement( ElementName = "DeviceType" )]
      [  XmlElement( ElementName = "DeviceType"   )]
      public short gxTpr_Devicetype
      {
         get {
            return gxTv_SdtDevice_Devicetype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDevice_Devicetype = value;
            SetDirty("Devicetype");
         }

      }

      [  SoapElement( ElementName = "DeviceToken" )]
      [  XmlElement( ElementName = "DeviceToken"   )]
      public string gxTpr_Devicetoken
      {
         get {
            return gxTv_SdtDevice_Devicetoken ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDevice_Devicetoken = value;
            SetDirty("Devicetoken");
         }

      }

      [  SoapElement( ElementName = "DeviceName" )]
      [  XmlElement( ElementName = "DeviceName"   )]
      public string gxTpr_Devicename
      {
         get {
            return gxTv_SdtDevice_Devicename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDevice_Devicename = value;
            SetDirty("Devicename");
         }

      }

      [  SoapElement( ElementName = "DeviceUser" )]
      [  XmlElement( ElementName = "DeviceUser"   )]
      public string gxTpr_Deviceuser
      {
         get {
            return gxTv_SdtDevice_Deviceuser ;
         }

         set {
            gxTv_SdtDevice_Deviceuser_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDevice_Deviceuser = value;
            SetDirty("Deviceuser");
         }

      }

      public void gxTv_SdtDevice_Deviceuser_SetNull( )
      {
         gxTv_SdtDevice_Deviceuser_N = 1;
         gxTv_SdtDevice_Deviceuser = "";
         SetDirty("Deviceuser");
         return  ;
      }

      public bool gxTv_SdtDevice_Deviceuser_IsNull( )
      {
         return (gxTv_SdtDevice_Deviceuser_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDevice_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDevice_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDevice_Mode_SetNull( )
      {
         gxTv_SdtDevice_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDevice_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDevice_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDevice_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDevice_Initialized_SetNull( )
      {
         gxTv_SdtDevice_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDevice_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DeviceId_Z" )]
      [  XmlElement( ElementName = "DeviceId_Z"   )]
      public string gxTpr_Deviceid_Z
      {
         get {
            return gxTv_SdtDevice_Deviceid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDevice_Deviceid_Z = value;
            SetDirty("Deviceid_Z");
         }

      }

      public void gxTv_SdtDevice_Deviceid_Z_SetNull( )
      {
         gxTv_SdtDevice_Deviceid_Z = "";
         SetDirty("Deviceid_Z");
         return  ;
      }

      public bool gxTv_SdtDevice_Deviceid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DeviceType_Z" )]
      [  XmlElement( ElementName = "DeviceType_Z"   )]
      public short gxTpr_Devicetype_Z
      {
         get {
            return gxTv_SdtDevice_Devicetype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDevice_Devicetype_Z = value;
            SetDirty("Devicetype_Z");
         }

      }

      public void gxTv_SdtDevice_Devicetype_Z_SetNull( )
      {
         gxTv_SdtDevice_Devicetype_Z = 0;
         SetDirty("Devicetype_Z");
         return  ;
      }

      public bool gxTv_SdtDevice_Devicetype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DeviceToken_Z" )]
      [  XmlElement( ElementName = "DeviceToken_Z"   )]
      public string gxTpr_Devicetoken_Z
      {
         get {
            return gxTv_SdtDevice_Devicetoken_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDevice_Devicetoken_Z = value;
            SetDirty("Devicetoken_Z");
         }

      }

      public void gxTv_SdtDevice_Devicetoken_Z_SetNull( )
      {
         gxTv_SdtDevice_Devicetoken_Z = "";
         SetDirty("Devicetoken_Z");
         return  ;
      }

      public bool gxTv_SdtDevice_Devicetoken_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DeviceName_Z" )]
      [  XmlElement( ElementName = "DeviceName_Z"   )]
      public string gxTpr_Devicename_Z
      {
         get {
            return gxTv_SdtDevice_Devicename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDevice_Devicename_Z = value;
            SetDirty("Devicename_Z");
         }

      }

      public void gxTv_SdtDevice_Devicename_Z_SetNull( )
      {
         gxTv_SdtDevice_Devicename_Z = "";
         SetDirty("Devicename_Z");
         return  ;
      }

      public bool gxTv_SdtDevice_Devicename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DeviceUser_Z" )]
      [  XmlElement( ElementName = "DeviceUser_Z"   )]
      public string gxTpr_Deviceuser_Z
      {
         get {
            return gxTv_SdtDevice_Deviceuser_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDevice_Deviceuser_Z = value;
            SetDirty("Deviceuser_Z");
         }

      }

      public void gxTv_SdtDevice_Deviceuser_Z_SetNull( )
      {
         gxTv_SdtDevice_Deviceuser_Z = "";
         SetDirty("Deviceuser_Z");
         return  ;
      }

      public bool gxTv_SdtDevice_Deviceuser_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DeviceUser_N" )]
      [  XmlElement( ElementName = "DeviceUser_N"   )]
      public short gxTpr_Deviceuser_N
      {
         get {
            return gxTv_SdtDevice_Deviceuser_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDevice_Deviceuser_N = value;
            SetDirty("Deviceuser_N");
         }

      }

      public void gxTv_SdtDevice_Deviceuser_N_SetNull( )
      {
         gxTv_SdtDevice_Deviceuser_N = 0;
         SetDirty("Deviceuser_N");
         return  ;
      }

      public bool gxTv_SdtDevice_Deviceuser_N_IsNull( )
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
         gxTv_SdtDevice_Deviceid = "";
         sdtIsNull = 1;
         gxTv_SdtDevice_Devicetoken = "";
         gxTv_SdtDevice_Devicename = "";
         gxTv_SdtDevice_Deviceuser = "";
         gxTv_SdtDevice_Mode = "";
         gxTv_SdtDevice_Deviceid_Z = "";
         gxTv_SdtDevice_Devicetoken_Z = "";
         gxTv_SdtDevice_Devicename_Z = "";
         gxTv_SdtDevice_Deviceuser_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "device", "GeneXus.Programs.device_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtDevice_Devicetype ;
      private short gxTv_SdtDevice_Initialized ;
      private short gxTv_SdtDevice_Devicetype_Z ;
      private short gxTv_SdtDevice_Deviceuser_N ;
      private string gxTv_SdtDevice_Deviceid ;
      private string gxTv_SdtDevice_Devicetoken ;
      private string gxTv_SdtDevice_Devicename ;
      private string gxTv_SdtDevice_Mode ;
      private string gxTv_SdtDevice_Deviceid_Z ;
      private string gxTv_SdtDevice_Devicetoken_Z ;
      private string gxTv_SdtDevice_Devicename_Z ;
      private string gxTv_SdtDevice_Deviceuser ;
      private string gxTv_SdtDevice_Deviceuser_Z ;
   }

   [DataContract(Name = @"Device", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtDevice_RESTInterface : GxGenericCollectionItem<SdtDevice>
   {
      public SdtDevice_RESTInterface( ) : base()
      {
      }

      public SdtDevice_RESTInterface( SdtDevice psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DeviceId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Deviceid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Deviceid) ;
         }

         set {
            sdt.gxTpr_Deviceid = value;
         }

      }

      [DataMember( Name = "DeviceType" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Devicetype
      {
         get {
            return sdt.gxTpr_Devicetype ;
         }

         set {
            sdt.gxTpr_Devicetype = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "DeviceToken" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Devicetoken
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Devicetoken) ;
         }

         set {
            sdt.gxTpr_Devicetoken = value;
         }

      }

      [DataMember( Name = "DeviceName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Devicename
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Devicename) ;
         }

         set {
            sdt.gxTpr_Devicename = value;
         }

      }

      [DataMember( Name = "DeviceUser" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Deviceuser
      {
         get {
            return sdt.gxTpr_Deviceuser ;
         }

         set {
            sdt.gxTpr_Deviceuser = value;
         }

      }

      public SdtDevice sdt
      {
         get {
            return (SdtDevice)Sdt ;
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
            sdt = new SdtDevice() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 5 )]
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

   [DataContract(Name = @"Device", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtDevice_RESTLInterface : GxGenericCollectionItem<SdtDevice>
   {
      public SdtDevice_RESTLInterface( ) : base()
      {
      }

      public SdtDevice_RESTLInterface( SdtDevice psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DeviceType" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Devicetype
      {
         get {
            return sdt.gxTpr_Devicetype ;
         }

         set {
            sdt.gxTpr_Devicetype = (short)(value.HasValue ? value.Value : 0);
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

      public SdtDevice sdt
      {
         get {
            return (SdtDevice)Sdt ;
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
            sdt = new SdtDevice() ;
         }
      }

   }

}
