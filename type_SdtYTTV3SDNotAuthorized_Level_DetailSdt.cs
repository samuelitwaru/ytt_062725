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
   [XmlRoot(ElementName = "YTTV3SDNotAuthorized_Level_DetailSdt" )]
   [XmlType(TypeName =  "YTTV3SDNotAuthorized_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtYTTV3SDNotAuthorized_Level_DetailSdt : GxUserType
   {
      public SdtYTTV3SDNotAuthorized_Level_DetailSdt( )
      {
         /* Constructor for serialization */
      }

      public SdtYTTV3SDNotAuthorized_Level_DetailSdt( IGxContext context )
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
         return  ;
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
         return  ;
      }

   }

   [DataContract(Name = @"YTTV3SDNotAuthorized_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtYTTV3SDNotAuthorized_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtYTTV3SDNotAuthorized_Level_DetailSdt>
   {
      public SdtYTTV3SDNotAuthorized_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtYTTV3SDNotAuthorized_Level_DetailSdt_RESTInterface( SdtYTTV3SDNotAuthorized_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      public SdtYTTV3SDNotAuthorized_Level_DetailSdt sdt
      {
         get {
            return (SdtYTTV3SDNotAuthorized_Level_DetailSdt)Sdt ;
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
            sdt = new SdtYTTV3SDNotAuthorized_Level_DetailSdt() ;
         }
      }

   }

}
