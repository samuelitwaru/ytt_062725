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
   [XmlRoot(ElementName = "Company" )]
   [XmlType(TypeName =  "Company" , Namespace = "YTT_version4" )]
   [Serializable]
   public class SdtCompany : GxSilentTrnSdt
   {
      public SdtCompany( )
      {
      }

      public SdtCompany( IGxContext context )
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

      public void Load( long AV100CompanyId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV100CompanyId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CompanyId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Company");
         metadata.Set("BT", "Company");
         metadata.Set("PK", "[ \"CompanyId\" ]");
         metadata.Set("PKAssigned", "[ \"CompanyId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CompanyLocationId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Companyid_Z");
         state.Add("gxTpr_Companyname_Z");
         state.Add("gxTpr_Companylocationid_Z");
         state.Add("gxTpr_Companylocationname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCompany sdt;
         sdt = (SdtCompany)(source);
         gxTv_SdtCompany_Companyid = sdt.gxTv_SdtCompany_Companyid ;
         gxTv_SdtCompany_Companyname = sdt.gxTv_SdtCompany_Companyname ;
         gxTv_SdtCompany_Companylocationid = sdt.gxTv_SdtCompany_Companylocationid ;
         gxTv_SdtCompany_Companylocationname = sdt.gxTv_SdtCompany_Companylocationname ;
         gxTv_SdtCompany_Mode = sdt.gxTv_SdtCompany_Mode ;
         gxTv_SdtCompany_Initialized = sdt.gxTv_SdtCompany_Initialized ;
         gxTv_SdtCompany_Companyid_Z = sdt.gxTv_SdtCompany_Companyid_Z ;
         gxTv_SdtCompany_Companyname_Z = sdt.gxTv_SdtCompany_Companyname_Z ;
         gxTv_SdtCompany_Companylocationid_Z = sdt.gxTv_SdtCompany_Companylocationid_Z ;
         gxTv_SdtCompany_Companylocationname_Z = sdt.gxTv_SdtCompany_Companylocationname_Z ;
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
         AddObjectProperty("CompanyId", gxTv_SdtCompany_Companyid, false, includeNonInitialized);
         AddObjectProperty("CompanyName", gxTv_SdtCompany_Companyname, false, includeNonInitialized);
         AddObjectProperty("CompanyLocationId", gxTv_SdtCompany_Companylocationid, false, includeNonInitialized);
         AddObjectProperty("CompanyLocationName", gxTv_SdtCompany_Companylocationname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCompany_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCompany_Initialized, false, includeNonInitialized);
            AddObjectProperty("CompanyId_Z", gxTv_SdtCompany_Companyid_Z, false, includeNonInitialized);
            AddObjectProperty("CompanyName_Z", gxTv_SdtCompany_Companyname_Z, false, includeNonInitialized);
            AddObjectProperty("CompanyLocationId_Z", gxTv_SdtCompany_Companylocationid_Z, false, includeNonInitialized);
            AddObjectProperty("CompanyLocationName_Z", gxTv_SdtCompany_Companylocationname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCompany sdt )
      {
         if ( sdt.IsDirty("CompanyId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCompany_Companyid = sdt.gxTv_SdtCompany_Companyid ;
         }
         if ( sdt.IsDirty("CompanyName") )
         {
            sdtIsNull = 0;
            gxTv_SdtCompany_Companyname = sdt.gxTv_SdtCompany_Companyname ;
         }
         if ( sdt.IsDirty("CompanyLocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCompany_Companylocationid = sdt.gxTv_SdtCompany_Companylocationid ;
         }
         if ( sdt.IsDirty("CompanyLocationName") )
         {
            sdtIsNull = 0;
            gxTv_SdtCompany_Companylocationname = sdt.gxTv_SdtCompany_Companylocationname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CompanyId" )]
      [  XmlElement( ElementName = "CompanyId"   )]
      public long gxTpr_Companyid
      {
         get {
            return gxTv_SdtCompany_Companyid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtCompany_Companyid != value )
            {
               gxTv_SdtCompany_Mode = "INS";
               this.gxTv_SdtCompany_Companyid_Z_SetNull( );
               this.gxTv_SdtCompany_Companyname_Z_SetNull( );
               this.gxTv_SdtCompany_Companylocationid_Z_SetNull( );
               this.gxTv_SdtCompany_Companylocationname_Z_SetNull( );
            }
            gxTv_SdtCompany_Companyid = value;
            SetDirty("Companyid");
         }

      }

      [  SoapElement( ElementName = "CompanyName" )]
      [  XmlElement( ElementName = "CompanyName"   )]
      public string gxTpr_Companyname
      {
         get {
            return gxTv_SdtCompany_Companyname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCompany_Companyname = value;
            SetDirty("Companyname");
         }

      }

      [  SoapElement( ElementName = "CompanyLocationId" )]
      [  XmlElement( ElementName = "CompanyLocationId"   )]
      public long gxTpr_Companylocationid
      {
         get {
            return gxTv_SdtCompany_Companylocationid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCompany_Companylocationid = value;
            SetDirty("Companylocationid");
         }

      }

      [  SoapElement( ElementName = "CompanyLocationName" )]
      [  XmlElement( ElementName = "CompanyLocationName"   )]
      public string gxTpr_Companylocationname
      {
         get {
            return gxTv_SdtCompany_Companylocationname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCompany_Companylocationname = value;
            SetDirty("Companylocationname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCompany_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCompany_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCompany_Mode_SetNull( )
      {
         gxTv_SdtCompany_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCompany_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCompany_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCompany_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCompany_Initialized_SetNull( )
      {
         gxTv_SdtCompany_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCompany_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompanyId_Z" )]
      [  XmlElement( ElementName = "CompanyId_Z"   )]
      public long gxTpr_Companyid_Z
      {
         get {
            return gxTv_SdtCompany_Companyid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCompany_Companyid_Z = value;
            SetDirty("Companyid_Z");
         }

      }

      public void gxTv_SdtCompany_Companyid_Z_SetNull( )
      {
         gxTv_SdtCompany_Companyid_Z = 0;
         SetDirty("Companyid_Z");
         return  ;
      }

      public bool gxTv_SdtCompany_Companyid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompanyName_Z" )]
      [  XmlElement( ElementName = "CompanyName_Z"   )]
      public string gxTpr_Companyname_Z
      {
         get {
            return gxTv_SdtCompany_Companyname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCompany_Companyname_Z = value;
            SetDirty("Companyname_Z");
         }

      }

      public void gxTv_SdtCompany_Companyname_Z_SetNull( )
      {
         gxTv_SdtCompany_Companyname_Z = "";
         SetDirty("Companyname_Z");
         return  ;
      }

      public bool gxTv_SdtCompany_Companyname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompanyLocationId_Z" )]
      [  XmlElement( ElementName = "CompanyLocationId_Z"   )]
      public long gxTpr_Companylocationid_Z
      {
         get {
            return gxTv_SdtCompany_Companylocationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCompany_Companylocationid_Z = value;
            SetDirty("Companylocationid_Z");
         }

      }

      public void gxTv_SdtCompany_Companylocationid_Z_SetNull( )
      {
         gxTv_SdtCompany_Companylocationid_Z = 0;
         SetDirty("Companylocationid_Z");
         return  ;
      }

      public bool gxTv_SdtCompany_Companylocationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompanyLocationName_Z" )]
      [  XmlElement( ElementName = "CompanyLocationName_Z"   )]
      public string gxTpr_Companylocationname_Z
      {
         get {
            return gxTv_SdtCompany_Companylocationname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCompany_Companylocationname_Z = value;
            SetDirty("Companylocationname_Z");
         }

      }

      public void gxTv_SdtCompany_Companylocationname_Z_SetNull( )
      {
         gxTv_SdtCompany_Companylocationname_Z = "";
         SetDirty("Companylocationname_Z");
         return  ;
      }

      public bool gxTv_SdtCompany_Companylocationname_Z_IsNull( )
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
         gxTv_SdtCompany_Companyname = "";
         gxTv_SdtCompany_Companylocationname = "";
         gxTv_SdtCompany_Mode = "";
         gxTv_SdtCompany_Companyname_Z = "";
         gxTv_SdtCompany_Companylocationname_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "company", "GeneXus.Programs.company_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtCompany_Initialized ;
      private long gxTv_SdtCompany_Companyid ;
      private long gxTv_SdtCompany_Companylocationid ;
      private long gxTv_SdtCompany_Companyid_Z ;
      private long gxTv_SdtCompany_Companylocationid_Z ;
      private string gxTv_SdtCompany_Companyname ;
      private string gxTv_SdtCompany_Companylocationname ;
      private string gxTv_SdtCompany_Mode ;
      private string gxTv_SdtCompany_Companyname_Z ;
      private string gxTv_SdtCompany_Companylocationname_Z ;
   }

   [DataContract(Name = @"Company", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtCompany_RESTInterface : GxGenericCollectionItem<SdtCompany>
   {
      public SdtCompany_RESTInterface( ) : base()
      {
      }

      public SdtCompany_RESTInterface( SdtCompany psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CompanyId" , Order = 0 )]
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

      [DataMember( Name = "CompanyName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Companyname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Companyname) ;
         }

         set {
            sdt.gxTpr_Companyname = value;
         }

      }

      [DataMember( Name = "CompanyLocationId" , Order = 2 )]
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

      [DataMember( Name = "CompanyLocationName" , Order = 3 )]
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

      public SdtCompany sdt
      {
         get {
            return (SdtCompany)Sdt ;
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
            sdt = new SdtCompany() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 4 )]
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

   [DataContract(Name = @"Company", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtCompany_RESTLInterface : GxGenericCollectionItem<SdtCompany>
   {
      public SdtCompany_RESTLInterface( ) : base()
      {
      }

      public SdtCompany_RESTLInterface( SdtCompany psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CompanyName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Companyname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Companyname) ;
         }

         set {
            sdt.gxTpr_Companyname = value;
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

      public SdtCompany sdt
      {
         get {
            return (SdtCompany)Sdt ;
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
            sdt = new SdtCompany() ;
         }
      }

   }

}
