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
   [XmlRoot(ElementName = "WorkLogsGridCollectionPanel_Level_DetailSdt" )]
   [XmlType(TypeName =  "WorkLogsGridCollectionPanel_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtWorkLogsGridCollectionPanel_Level_DetailSdt : GxUserType
   {
      public SdtWorkLogsGridCollectionPanel_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdynprop = "";
      }

      public SdtWorkLogsGridCollectionPanel_Level_DetailSdt( IGxContext context )
      {
         this.context = context;
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
         if ( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts != null )
         {
            AddObjectProperty("Worklogssdts", gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts, false, false);
         }
         AddObjectProperty("Gxdynprop", gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdynprop, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Worklogssdts" )]
      [  XmlArray( ElementName = "Worklogssdts"  )]
      [  XmlArrayItemAttribute( ElementName= "WorkLogsSDT"  , IsNullable=false)]
      public GXBaseCollection<SdtWorkLogsSDT> gxTpr_Worklogssdts_GXBaseCollection
      {
         get {
            if ( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts == null )
            {
               gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts = new GXBaseCollection<SdtWorkLogsSDT>( context, "WorkLogsSDT", "");
            }
            return gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts ;
         }

         set {
            if ( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts == null )
            {
               gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts = new GXBaseCollection<SdtWorkLogsSDT>( context, "WorkLogsSDT", "");
            }
            sdtIsNull = 0;
            gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts = value;
         }

      }

      [XmlIgnore]
      public GXBaseCollection<SdtWorkLogsSDT> gxTpr_Worklogssdts
      {
         get {
            if ( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts == null )
            {
               gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts = new GXBaseCollection<SdtWorkLogsSDT>( context, "WorkLogsSDT", "");
            }
            sdtIsNull = 0;
            return gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts = value;
            SetDirty("Worklogssdts");
         }

      }

      public void gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts_SetNull( )
      {
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts = null;
         return  ;
      }

      public bool gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts_IsNull( )
      {
         if ( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Gxdynprop" )]
      [  XmlElement( ElementName = "Gxdynprop"   )]
      public string gxTpr_Gxdynprop
      {
         get {
            return gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdynprop ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdynprop = value;
            SetDirty("Gxdynprop");
         }

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
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdynprop = "";
         sdtIsNull = 1;
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected string gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdynprop ;
      protected GXBaseCollection<SdtWorkLogsSDT> gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts=null ;
   }

   [DataContract(Name = @"WorkLogsGridCollectionPanel_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtWorkLogsGridCollectionPanel_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtWorkLogsGridCollectionPanel_Level_DetailSdt>
   {
      public SdtWorkLogsGridCollectionPanel_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtWorkLogsGridCollectionPanel_Level_DetailSdt_RESTInterface( SdtWorkLogsGridCollectionPanel_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Worklogssdts" , Order = 0 )]
      public GxGenericCollection<SdtWorkLogsSDT_RESTInterface> gxTpr_Worklogssdts
      {
         get {
            return new GxGenericCollection<SdtWorkLogsSDT_RESTInterface>(sdt.gxTpr_Worklogssdts) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Worklogssdts);
         }

      }

      [DataMember( Name = "Gxdynprop" , Order = 1 )]
      public string gxTpr_Gxdynprop
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gxdynprop) ;
         }

         set {
            sdt.gxTpr_Gxdynprop = value;
         }

      }

      public SdtWorkLogsGridCollectionPanel_Level_DetailSdt sdt
      {
         get {
            return (SdtWorkLogsGridCollectionPanel_Level_DetailSdt)Sdt ;
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
            sdt = new SdtWorkLogsGridCollectionPanel_Level_DetailSdt() ;
         }
      }

   }

}
