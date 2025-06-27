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
   [XmlRoot(ElementName = "GAMSDChangePassword_Level_DetailSdt" )]
   [XmlType(TypeName =  "GAMSDChangePassword_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtGAMSDChangePassword_Level_DetailSdt : GxUserType
   {
      public SdtGAMSDChangePassword_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Username = "";
         gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpassword = "";
         gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpasswordnew = "";
         gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpasswordnewconf = "";
      }

      public SdtGAMSDChangePassword_Level_DetailSdt( IGxContext context )
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
         AddObjectProperty("Username", gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Username, false, false);
         AddObjectProperty("Userpassword", gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpassword, false, false);
         AddObjectProperty("Userpasswordnew", gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpasswordnew, false, false);
         AddObjectProperty("Userpasswordnewconf", gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpasswordnewconf, false, false);
         AddObjectProperty("Ispasswordexpires", gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Ispasswordexpires, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Username" )]
      [  XmlElement( ElementName = "Username"   )]
      public string gxTpr_Username
      {
         get {
            return gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Username ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Username = value;
            SetDirty("Username");
         }

      }

      [  SoapElement( ElementName = "Userpassword" )]
      [  XmlElement( ElementName = "Userpassword"   )]
      public string gxTpr_Userpassword
      {
         get {
            return gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpassword ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpassword = value;
            SetDirty("Userpassword");
         }

      }

      [  SoapElement( ElementName = "Userpasswordnew" )]
      [  XmlElement( ElementName = "Userpasswordnew"   )]
      public string gxTpr_Userpasswordnew
      {
         get {
            return gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpasswordnew ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpasswordnew = value;
            SetDirty("Userpasswordnew");
         }

      }

      [  SoapElement( ElementName = "Userpasswordnewconf" )]
      [  XmlElement( ElementName = "Userpasswordnewconf"   )]
      public string gxTpr_Userpasswordnewconf
      {
         get {
            return gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpasswordnewconf ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpasswordnewconf = value;
            SetDirty("Userpasswordnewconf");
         }

      }

      [  SoapElement( ElementName = "Ispasswordexpires" )]
      [  XmlElement( ElementName = "Ispasswordexpires"   )]
      public bool gxTpr_Ispasswordexpires
      {
         get {
            return gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Ispasswordexpires ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Ispasswordexpires = value;
            SetDirty("Ispasswordexpires");
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
         gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Username = "";
         gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpassword = "";
         gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpasswordnew = "";
         gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpasswordnewconf = "";
         sdtIsNull = 1;
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected string gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpassword ;
      protected string gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpasswordnew ;
      protected string gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Userpasswordnewconf ;
      protected bool gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Ispasswordexpires ;
      protected string gxTv_SdtGAMSDChangePassword_Level_DetailSdt_Username ;
   }

   [DataContract(Name = @"GAMSDChangePassword_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtGAMSDChangePassword_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtGAMSDChangePassword_Level_DetailSdt>
   {
      public SdtGAMSDChangePassword_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtGAMSDChangePassword_Level_DetailSdt_RESTInterface( SdtGAMSDChangePassword_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Username" , Order = 0 )]
      public string gxTpr_Username
      {
         get {
            return sdt.gxTpr_Username ;
         }

         set {
            sdt.gxTpr_Username = value;
         }

      }

      [DataMember( Name = "Userpassword" , Order = 1 )]
      public string gxTpr_Userpassword
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Userpassword) ;
         }

         set {
            sdt.gxTpr_Userpassword = value;
         }

      }

      [DataMember( Name = "Userpasswordnew" , Order = 2 )]
      public string gxTpr_Userpasswordnew
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Userpasswordnew) ;
         }

         set {
            sdt.gxTpr_Userpasswordnew = value;
         }

      }

      [DataMember( Name = "Userpasswordnewconf" , Order = 3 )]
      public string gxTpr_Userpasswordnewconf
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Userpasswordnewconf) ;
         }

         set {
            sdt.gxTpr_Userpasswordnewconf = value;
         }

      }

      [DataMember( Name = "Ispasswordexpires" , Order = 4 )]
      public bool gxTpr_Ispasswordexpires
      {
         get {
            return sdt.gxTpr_Ispasswordexpires ;
         }

         set {
            sdt.gxTpr_Ispasswordexpires = value;
         }

      }

      public SdtGAMSDChangePassword_Level_DetailSdt sdt
      {
         get {
            return (SdtGAMSDChangePassword_Level_DetailSdt)Sdt ;
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
            sdt = new SdtGAMSDChangePassword_Level_DetailSdt() ;
         }
      }

   }

}
