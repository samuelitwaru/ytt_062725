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
   [XmlRoot(ElementName = "GAMSDNotAuthorized_Level_DetailSdt" )]
   [XmlType(TypeName =  "GAMSDNotAuthorized_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtGAMSDNotAuthorized_Level_DetailSdt : GxUserType
   {
      public SdtGAMSDNotAuthorized_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_User = "";
         gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Password = "";
      }

      public SdtGAMSDNotAuthorized_Level_DetailSdt( IGxContext context )
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
         AddObjectProperty("User", gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_User, false, false);
         AddObjectProperty("Password", gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Password, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "User" )]
      [  XmlElement( ElementName = "User"   )]
      public string gxTpr_User
      {
         get {
            return gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_User ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_User = value;
            SetDirty("User");
         }

      }

      [  SoapElement( ElementName = "Password" )]
      [  XmlElement( ElementName = "Password"   )]
      public string gxTpr_Password
      {
         get {
            return gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Password ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Password = value;
            SetDirty("Password");
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
         gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_User = "";
         gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Password = "";
         sdtIsNull = 1;
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected string gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Password ;
      protected string gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_User ;
   }

   [DataContract(Name = @"GAMSDNotAuthorized_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtGAMSDNotAuthorized_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtGAMSDNotAuthorized_Level_DetailSdt>
   {
      public SdtGAMSDNotAuthorized_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtGAMSDNotAuthorized_Level_DetailSdt_RESTInterface( SdtGAMSDNotAuthorized_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "User" , Order = 0 )]
      public string gxTpr_User
      {
         get {
            return sdt.gxTpr_User ;
         }

         set {
            sdt.gxTpr_User = value;
         }

      }

      [DataMember( Name = "Password" , Order = 1 )]
      public string gxTpr_Password
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Password) ;
         }

         set {
            sdt.gxTpr_Password = value;
         }

      }

      public SdtGAMSDNotAuthorized_Level_DetailSdt sdt
      {
         get {
            return (SdtGAMSDNotAuthorized_Level_DetailSdt)Sdt ;
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
            sdt = new SdtGAMSDNotAuthorized_Level_DetailSdt() ;
         }
      }

   }

}
