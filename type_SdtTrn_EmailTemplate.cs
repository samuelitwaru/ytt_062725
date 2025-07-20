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
   [XmlRoot(ElementName = "Trn_EmailTemplate" )]
   [XmlType(TypeName =  "Trn_EmailTemplate" , Namespace = "YTT_version4" )]
   [Serializable]
   public class SdtTrn_EmailTemplate : GxSilentTrnSdt
   {
      public SdtTrn_EmailTemplate( )
      {
      }

      public SdtTrn_EmailTemplate( IGxContext context )
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

      public void Load( long AV190EmailTemplateId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV190EmailTemplateId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EmailTemplateId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_EmailTemplate");
         metadata.Set("BT", "Trn_EmailTemplate");
         metadata.Set("PK", "[ \"EmailTemplateId\" ]");
         metadata.Set("PKAssigned", "[ \"EmailTemplateId\" ]");
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
         state.Add("gxTpr_Emailtemplateid_Z");
         state.Add("gxTpr_Emailtemplatename_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_EmailTemplate sdt;
         sdt = (SdtTrn_EmailTemplate)(source);
         gxTv_SdtTrn_EmailTemplate_Emailtemplateid = sdt.gxTv_SdtTrn_EmailTemplate_Emailtemplateid ;
         gxTv_SdtTrn_EmailTemplate_Emailtemplatename = sdt.gxTv_SdtTrn_EmailTemplate_Emailtemplatename ;
         gxTv_SdtTrn_EmailTemplate_Emailtemplatecontent = sdt.gxTv_SdtTrn_EmailTemplate_Emailtemplatecontent ;
         gxTv_SdtTrn_EmailTemplate_Mode = sdt.gxTv_SdtTrn_EmailTemplate_Mode ;
         gxTv_SdtTrn_EmailTemplate_Initialized = sdt.gxTv_SdtTrn_EmailTemplate_Initialized ;
         gxTv_SdtTrn_EmailTemplate_Emailtemplateid_Z = sdt.gxTv_SdtTrn_EmailTemplate_Emailtemplateid_Z ;
         gxTv_SdtTrn_EmailTemplate_Emailtemplatename_Z = sdt.gxTv_SdtTrn_EmailTemplate_Emailtemplatename_Z ;
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
         AddObjectProperty("EmailTemplateId", gxTv_SdtTrn_EmailTemplate_Emailtemplateid, false, includeNonInitialized);
         AddObjectProperty("EmailTemplateName", gxTv_SdtTrn_EmailTemplate_Emailtemplatename, false, includeNonInitialized);
         AddObjectProperty("EmailTemplateContent", gxTv_SdtTrn_EmailTemplate_Emailtemplatecontent, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_EmailTemplate_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_EmailTemplate_Initialized, false, includeNonInitialized);
            AddObjectProperty("EmailTemplateId_Z", gxTv_SdtTrn_EmailTemplate_Emailtemplateid_Z, false, includeNonInitialized);
            AddObjectProperty("EmailTemplateName_Z", gxTv_SdtTrn_EmailTemplate_Emailtemplatename_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_EmailTemplate sdt )
      {
         if ( sdt.IsDirty("EmailTemplateId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_EmailTemplate_Emailtemplateid = sdt.gxTv_SdtTrn_EmailTemplate_Emailtemplateid ;
         }
         if ( sdt.IsDirty("EmailTemplateName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_EmailTemplate_Emailtemplatename = sdt.gxTv_SdtTrn_EmailTemplate_Emailtemplatename ;
         }
         if ( sdt.IsDirty("EmailTemplateContent") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_EmailTemplate_Emailtemplatecontent = sdt.gxTv_SdtTrn_EmailTemplate_Emailtemplatecontent ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EmailTemplateId" )]
      [  XmlElement( ElementName = "EmailTemplateId"   )]
      public long gxTpr_Emailtemplateid
      {
         get {
            return gxTv_SdtTrn_EmailTemplate_Emailtemplateid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_EmailTemplate_Emailtemplateid != value )
            {
               gxTv_SdtTrn_EmailTemplate_Mode = "INS";
               this.gxTv_SdtTrn_EmailTemplate_Emailtemplateid_Z_SetNull( );
               this.gxTv_SdtTrn_EmailTemplate_Emailtemplatename_Z_SetNull( );
            }
            gxTv_SdtTrn_EmailTemplate_Emailtemplateid = value;
            SetDirty("Emailtemplateid");
         }

      }

      [  SoapElement( ElementName = "EmailTemplateName" )]
      [  XmlElement( ElementName = "EmailTemplateName"   )]
      public string gxTpr_Emailtemplatename
      {
         get {
            return gxTv_SdtTrn_EmailTemplate_Emailtemplatename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_EmailTemplate_Emailtemplatename = value;
            SetDirty("Emailtemplatename");
         }

      }

      [  SoapElement( ElementName = "EmailTemplateContent" )]
      [  XmlElement( ElementName = "EmailTemplateContent"   )]
      public string gxTpr_Emailtemplatecontent
      {
         get {
            return gxTv_SdtTrn_EmailTemplate_Emailtemplatecontent ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_EmailTemplate_Emailtemplatecontent = value;
            SetDirty("Emailtemplatecontent");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_EmailTemplate_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_EmailTemplate_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_EmailTemplate_Mode_SetNull( )
      {
         gxTv_SdtTrn_EmailTemplate_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_EmailTemplate_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_EmailTemplate_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_EmailTemplate_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_EmailTemplate_Initialized_SetNull( )
      {
         gxTv_SdtTrn_EmailTemplate_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_EmailTemplate_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmailTemplateId_Z" )]
      [  XmlElement( ElementName = "EmailTemplateId_Z"   )]
      public long gxTpr_Emailtemplateid_Z
      {
         get {
            return gxTv_SdtTrn_EmailTemplate_Emailtemplateid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_EmailTemplate_Emailtemplateid_Z = value;
            SetDirty("Emailtemplateid_Z");
         }

      }

      public void gxTv_SdtTrn_EmailTemplate_Emailtemplateid_Z_SetNull( )
      {
         gxTv_SdtTrn_EmailTemplate_Emailtemplateid_Z = 0;
         SetDirty("Emailtemplateid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_EmailTemplate_Emailtemplateid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmailTemplateName_Z" )]
      [  XmlElement( ElementName = "EmailTemplateName_Z"   )]
      public string gxTpr_Emailtemplatename_Z
      {
         get {
            return gxTv_SdtTrn_EmailTemplate_Emailtemplatename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_EmailTemplate_Emailtemplatename_Z = value;
            SetDirty("Emailtemplatename_Z");
         }

      }

      public void gxTv_SdtTrn_EmailTemplate_Emailtemplatename_Z_SetNull( )
      {
         gxTv_SdtTrn_EmailTemplate_Emailtemplatename_Z = "";
         SetDirty("Emailtemplatename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_EmailTemplate_Emailtemplatename_Z_IsNull( )
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
         gxTv_SdtTrn_EmailTemplate_Emailtemplatename = "";
         gxTv_SdtTrn_EmailTemplate_Emailtemplatecontent = "";
         gxTv_SdtTrn_EmailTemplate_Mode = "";
         gxTv_SdtTrn_EmailTemplate_Emailtemplatename_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_emailtemplate", "GeneXus.Programs.trn_emailtemplate_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_EmailTemplate_Initialized ;
      private long gxTv_SdtTrn_EmailTemplate_Emailtemplateid ;
      private long gxTv_SdtTrn_EmailTemplate_Emailtemplateid_Z ;
      private string gxTv_SdtTrn_EmailTemplate_Emailtemplatename ;
      private string gxTv_SdtTrn_EmailTemplate_Mode ;
      private string gxTv_SdtTrn_EmailTemplate_Emailtemplatename_Z ;
      private string gxTv_SdtTrn_EmailTemplate_Emailtemplatecontent ;
   }

   [DataContract(Name = @"Trn_EmailTemplate", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtTrn_EmailTemplate_RESTInterface : GxGenericCollectionItem<SdtTrn_EmailTemplate>
   {
      public SdtTrn_EmailTemplate_RESTInterface( ) : base()
      {
      }

      public SdtTrn_EmailTemplate_RESTInterface( SdtTrn_EmailTemplate psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EmailTemplateId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Emailtemplateid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Emailtemplateid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Emailtemplateid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "EmailTemplateName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Emailtemplatename
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Emailtemplatename) ;
         }

         set {
            sdt.gxTpr_Emailtemplatename = value;
         }

      }

      [DataMember( Name = "EmailTemplateContent" , Order = 2 )]
      public string gxTpr_Emailtemplatecontent
      {
         get {
            return sdt.gxTpr_Emailtemplatecontent ;
         }

         set {
            sdt.gxTpr_Emailtemplatecontent = value;
         }

      }

      public SdtTrn_EmailTemplate sdt
      {
         get {
            return (SdtTrn_EmailTemplate)Sdt ;
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
            sdt = new SdtTrn_EmailTemplate() ;
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

   [DataContract(Name = @"Trn_EmailTemplate", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtTrn_EmailTemplate_RESTLInterface : GxGenericCollectionItem<SdtTrn_EmailTemplate>
   {
      public SdtTrn_EmailTemplate_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_EmailTemplate_RESTLInterface( SdtTrn_EmailTemplate psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EmailTemplateName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Emailtemplatename
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Emailtemplatename) ;
         }

         set {
            sdt.gxTpr_Emailtemplatename = value;
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

      public SdtTrn_EmailTemplate sdt
      {
         get {
            return (SdtTrn_EmailTemplate)Sdt ;
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
            sdt = new SdtTrn_EmailTemplate() ;
         }
      }

   }

}
