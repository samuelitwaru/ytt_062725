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
   [XmlRoot(ElementName = "YTTV3SD_Level_DetailSdt" )]
   [XmlType(TypeName =  "YTTV3SD_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtYTTV3SD_Level_DetailSdt : GxUserType
   {
      public SdtYTTV3SD_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtYTTV3SD_Level_DetailSdt_Pagetitle = "";
      }

      public SdtYTTV3SD_Level_DetailSdt( IGxContext context )
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
         AddObjectProperty("Pagetitle", gxTv_SdtYTTV3SD_Level_DetailSdt_Pagetitle, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Pagetitle" )]
      [  XmlElement( ElementName = "Pagetitle"   )]
      public string gxTpr_Pagetitle
      {
         get {
            return gxTv_SdtYTTV3SD_Level_DetailSdt_Pagetitle ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtYTTV3SD_Level_DetailSdt_Pagetitle = value;
            SetDirty("Pagetitle");
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
         gxTv_SdtYTTV3SD_Level_DetailSdt_Pagetitle = "";
         sdtIsNull = 1;
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected string gxTv_SdtYTTV3SD_Level_DetailSdt_Pagetitle ;
   }

   [DataContract(Name = @"YTTV3SD_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtYTTV3SD_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtYTTV3SD_Level_DetailSdt>
   {
      public SdtYTTV3SD_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtYTTV3SD_Level_DetailSdt_RESTInterface( SdtYTTV3SD_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Pagetitle" , Order = 0 )]
      public string gxTpr_Pagetitle
      {
         get {
            return sdt.gxTpr_Pagetitle ;
         }

         set {
            sdt.gxTpr_Pagetitle = value;
         }

      }

      public SdtYTTV3SD_Level_DetailSdt sdt
      {
         get {
            return (SdtYTTV3SD_Level_DetailSdt)Sdt ;
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
            sdt = new SdtYTTV3SD_Level_DetailSdt() ;
         }
      }

   }

}
