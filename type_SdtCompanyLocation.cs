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
   [XmlRoot(ElementName = "CompanyLocation" )]
   [XmlType(TypeName =  "CompanyLocation" , Namespace = "YTT_version4" )]
   [Serializable]
   public class SdtCompanyLocation : GxSilentTrnSdt
   {
      public SdtCompanyLocation( )
      {
      }

      public SdtCompanyLocation( IGxContext context )
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

      public void Load( long AV157CompanyLocationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV157CompanyLocationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CompanyLocationId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "CompanyLocation");
         metadata.Set("BT", "CompanyLocation");
         metadata.Set("PK", "[ \"CompanyLocationId\" ]");
         metadata.Set("PKAssigned", "[ \"CompanyLocationId\" ]");
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
         state.Add("gxTpr_Companylocationid_Z");
         state.Add("gxTpr_Companylocationname_Z");
         state.Add("gxTpr_Companylocationcode_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCompanyLocation sdt;
         sdt = (SdtCompanyLocation)(source);
         gxTv_SdtCompanyLocation_Companylocationid = sdt.gxTv_SdtCompanyLocation_Companylocationid ;
         gxTv_SdtCompanyLocation_Companylocationname = sdt.gxTv_SdtCompanyLocation_Companylocationname ;
         gxTv_SdtCompanyLocation_Companylocationcode = sdt.gxTv_SdtCompanyLocation_Companylocationcode ;
         gxTv_SdtCompanyLocation_Mode = sdt.gxTv_SdtCompanyLocation_Mode ;
         gxTv_SdtCompanyLocation_Initialized = sdt.gxTv_SdtCompanyLocation_Initialized ;
         gxTv_SdtCompanyLocation_Companylocationid_Z = sdt.gxTv_SdtCompanyLocation_Companylocationid_Z ;
         gxTv_SdtCompanyLocation_Companylocationname_Z = sdt.gxTv_SdtCompanyLocation_Companylocationname_Z ;
         gxTv_SdtCompanyLocation_Companylocationcode_Z = sdt.gxTv_SdtCompanyLocation_Companylocationcode_Z ;
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
         AddObjectProperty("CompanyLocationId", gxTv_SdtCompanyLocation_Companylocationid, false, includeNonInitialized);
         AddObjectProperty("CompanyLocationName", gxTv_SdtCompanyLocation_Companylocationname, false, includeNonInitialized);
         AddObjectProperty("CompanyLocationCode", gxTv_SdtCompanyLocation_Companylocationcode, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCompanyLocation_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCompanyLocation_Initialized, false, includeNonInitialized);
            AddObjectProperty("CompanyLocationId_Z", gxTv_SdtCompanyLocation_Companylocationid_Z, false, includeNonInitialized);
            AddObjectProperty("CompanyLocationName_Z", gxTv_SdtCompanyLocation_Companylocationname_Z, false, includeNonInitialized);
            AddObjectProperty("CompanyLocationCode_Z", gxTv_SdtCompanyLocation_Companylocationcode_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCompanyLocation sdt )
      {
         if ( sdt.IsDirty("CompanyLocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCompanyLocation_Companylocationid = sdt.gxTv_SdtCompanyLocation_Companylocationid ;
         }
         if ( sdt.IsDirty("CompanyLocationName") )
         {
            sdtIsNull = 0;
            gxTv_SdtCompanyLocation_Companylocationname = sdt.gxTv_SdtCompanyLocation_Companylocationname ;
         }
         if ( sdt.IsDirty("CompanyLocationCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtCompanyLocation_Companylocationcode = sdt.gxTv_SdtCompanyLocation_Companylocationcode ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CompanyLocationId" )]
      [  XmlElement( ElementName = "CompanyLocationId"   )]
      public long gxTpr_Companylocationid
      {
         get {
            return gxTv_SdtCompanyLocation_Companylocationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtCompanyLocation_Companylocationid != value )
            {
               gxTv_SdtCompanyLocation_Mode = "INS";
               this.gxTv_SdtCompanyLocation_Companylocationid_Z_SetNull( );
               this.gxTv_SdtCompanyLocation_Companylocationname_Z_SetNull( );
               this.gxTv_SdtCompanyLocation_Companylocationcode_Z_SetNull( );
            }
            gxTv_SdtCompanyLocation_Companylocationid = value;
            SetDirty("Companylocationid");
         }

      }

      [  SoapElement( ElementName = "CompanyLocationName" )]
      [  XmlElement( ElementName = "CompanyLocationName"   )]
      public string gxTpr_Companylocationname
      {
         get {
            return gxTv_SdtCompanyLocation_Companylocationname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCompanyLocation_Companylocationname = value;
            SetDirty("Companylocationname");
         }

      }

      [  SoapElement( ElementName = "CompanyLocationCode" )]
      [  XmlElement( ElementName = "CompanyLocationCode"   )]
      public string gxTpr_Companylocationcode
      {
         get {
            return gxTv_SdtCompanyLocation_Companylocationcode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCompanyLocation_Companylocationcode = value;
            SetDirty("Companylocationcode");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCompanyLocation_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCompanyLocation_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCompanyLocation_Mode_SetNull( )
      {
         gxTv_SdtCompanyLocation_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCompanyLocation_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCompanyLocation_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCompanyLocation_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCompanyLocation_Initialized_SetNull( )
      {
         gxTv_SdtCompanyLocation_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCompanyLocation_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompanyLocationId_Z" )]
      [  XmlElement( ElementName = "CompanyLocationId_Z"   )]
      public long gxTpr_Companylocationid_Z
      {
         get {
            return gxTv_SdtCompanyLocation_Companylocationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCompanyLocation_Companylocationid_Z = value;
            SetDirty("Companylocationid_Z");
         }

      }

      public void gxTv_SdtCompanyLocation_Companylocationid_Z_SetNull( )
      {
         gxTv_SdtCompanyLocation_Companylocationid_Z = 0;
         SetDirty("Companylocationid_Z");
         return  ;
      }

      public bool gxTv_SdtCompanyLocation_Companylocationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompanyLocationName_Z" )]
      [  XmlElement( ElementName = "CompanyLocationName_Z"   )]
      public string gxTpr_Companylocationname_Z
      {
         get {
            return gxTv_SdtCompanyLocation_Companylocationname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCompanyLocation_Companylocationname_Z = value;
            SetDirty("Companylocationname_Z");
         }

      }

      public void gxTv_SdtCompanyLocation_Companylocationname_Z_SetNull( )
      {
         gxTv_SdtCompanyLocation_Companylocationname_Z = "";
         SetDirty("Companylocationname_Z");
         return  ;
      }

      public bool gxTv_SdtCompanyLocation_Companylocationname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompanyLocationCode_Z" )]
      [  XmlElement( ElementName = "CompanyLocationCode_Z"   )]
      public string gxTpr_Companylocationcode_Z
      {
         get {
            return gxTv_SdtCompanyLocation_Companylocationcode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCompanyLocation_Companylocationcode_Z = value;
            SetDirty("Companylocationcode_Z");
         }

      }

      public void gxTv_SdtCompanyLocation_Companylocationcode_Z_SetNull( )
      {
         gxTv_SdtCompanyLocation_Companylocationcode_Z = "";
         SetDirty("Companylocationcode_Z");
         return  ;
      }

      public bool gxTv_SdtCompanyLocation_Companylocationcode_Z_IsNull( )
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
         gxTv_SdtCompanyLocation_Companylocationname = "";
         gxTv_SdtCompanyLocation_Companylocationcode = "";
         gxTv_SdtCompanyLocation_Mode = "";
         gxTv_SdtCompanyLocation_Companylocationname_Z = "";
         gxTv_SdtCompanyLocation_Companylocationcode_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "companylocation", "GeneXus.Programs.companylocation_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtCompanyLocation_Initialized ;
      private long gxTv_SdtCompanyLocation_Companylocationid ;
      private long gxTv_SdtCompanyLocation_Companylocationid_Z ;
      private string gxTv_SdtCompanyLocation_Companylocationname ;
      private string gxTv_SdtCompanyLocation_Companylocationcode ;
      private string gxTv_SdtCompanyLocation_Mode ;
      private string gxTv_SdtCompanyLocation_Companylocationname_Z ;
      private string gxTv_SdtCompanyLocation_Companylocationcode_Z ;
   }

   [DataContract(Name = @"CompanyLocation", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtCompanyLocation_RESTInterface : GxGenericCollectionItem<SdtCompanyLocation>
   {
      public SdtCompanyLocation_RESTInterface( ) : base()
      {
      }

      public SdtCompanyLocation_RESTInterface( SdtCompanyLocation psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CompanyLocationId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Companylocationid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Companylocationid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Companylocationid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CompanyLocationName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Companylocationname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Companylocationname) ;
         }

         set {
            sdt.gxTpr_Companylocationname = value;
         }

      }

      [DataMember( Name = "CompanyLocationCode" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Companylocationcode
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Companylocationcode) ;
         }

         set {
            sdt.gxTpr_Companylocationcode = value;
         }

      }

      public SdtCompanyLocation sdt
      {
         get {
            return (SdtCompanyLocation)Sdt ;
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
            sdt = new SdtCompanyLocation() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 3 )]
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

   [DataContract(Name = @"CompanyLocation", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtCompanyLocation_RESTLInterface : GxGenericCollectionItem<SdtCompanyLocation>
   {
      public SdtCompanyLocation_RESTLInterface( ) : base()
      {
      }

      public SdtCompanyLocation_RESTLInterface( SdtCompanyLocation psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CompanyLocationName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Companylocationname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Companylocationname) ;
         }

         set {
            sdt.gxTpr_Companylocationname = value;
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

      public SdtCompanyLocation sdt
      {
         get {
            return (SdtCompanyLocation)Sdt ;
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
            sdt = new SdtCompanyLocation() ;
         }
      }

   }

}
