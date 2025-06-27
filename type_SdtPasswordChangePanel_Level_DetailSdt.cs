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
   [XmlRoot(ElementName = "PasswordChangePanel_Level_DetailSdt" )]
   [XmlType(TypeName =  "PasswordChangePanel_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtPasswordChangePanel_Level_DetailSdt : GxUserType
   {
      public SdtPasswordChangePanel_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtPasswordChangePanel_Level_DetailSdt_Oldpassword = "";
         gxTv_SdtPasswordChangePanel_Level_DetailSdt_Newpassword = "";
         gxTv_SdtPasswordChangePanel_Level_DetailSdt_Confirmpassword = "";
         gxTv_SdtPasswordChangePanel_Level_DetailSdt_Username = "";
         gxTv_SdtPasswordChangePanel_Level_DetailSdt_Gxdynprop = "";
      }

      public SdtPasswordChangePanel_Level_DetailSdt( IGxContext context )
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
         AddObjectProperty("Oldpassword", gxTv_SdtPasswordChangePanel_Level_DetailSdt_Oldpassword, false, false);
         AddObjectProperty("Newpassword", gxTv_SdtPasswordChangePanel_Level_DetailSdt_Newpassword, false, false);
         AddObjectProperty("Confirmpassword", gxTv_SdtPasswordChangePanel_Level_DetailSdt_Confirmpassword, false, false);
         AddObjectProperty("Ispasswordexpires", gxTv_SdtPasswordChangePanel_Level_DetailSdt_Ispasswordexpires, false, false);
         AddObjectProperty("Username", gxTv_SdtPasswordChangePanel_Level_DetailSdt_Username, false, false);
         AddObjectProperty("Gxdynprop", gxTv_SdtPasswordChangePanel_Level_DetailSdt_Gxdynprop, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Oldpassword" )]
      [  XmlElement( ElementName = "Oldpassword"   )]
      public string gxTpr_Oldpassword
      {
         get {
            return gxTv_SdtPasswordChangePanel_Level_DetailSdt_Oldpassword ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPasswordChangePanel_Level_DetailSdt_Oldpassword = value;
            SetDirty("Oldpassword");
         }

      }

      [  SoapElement( ElementName = "Newpassword" )]
      [  XmlElement( ElementName = "Newpassword"   )]
      public string gxTpr_Newpassword
      {
         get {
            return gxTv_SdtPasswordChangePanel_Level_DetailSdt_Newpassword ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPasswordChangePanel_Level_DetailSdt_Newpassword = value;
            SetDirty("Newpassword");
         }

      }

      [  SoapElement( ElementName = "Confirmpassword" )]
      [  XmlElement( ElementName = "Confirmpassword"   )]
      public string gxTpr_Confirmpassword
      {
         get {
            return gxTv_SdtPasswordChangePanel_Level_DetailSdt_Confirmpassword ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPasswordChangePanel_Level_DetailSdt_Confirmpassword = value;
            SetDirty("Confirmpassword");
         }

      }

      [  SoapElement( ElementName = "Ispasswordexpires" )]
      [  XmlElement( ElementName = "Ispasswordexpires"   )]
      public bool gxTpr_Ispasswordexpires
      {
         get {
            return gxTv_SdtPasswordChangePanel_Level_DetailSdt_Ispasswordexpires ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPasswordChangePanel_Level_DetailSdt_Ispasswordexpires = value;
            SetDirty("Ispasswordexpires");
         }

      }

      [  SoapElement( ElementName = "Username" )]
      [  XmlElement( ElementName = "Username"   )]
      public string gxTpr_Username
      {
         get {
            return gxTv_SdtPasswordChangePanel_Level_DetailSdt_Username ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPasswordChangePanel_Level_DetailSdt_Username = value;
            SetDirty("Username");
         }

      }

      [  SoapElement( ElementName = "Gxdynprop" )]
      [  XmlElement( ElementName = "Gxdynprop"   )]
      public string gxTpr_Gxdynprop
      {
         get {
            return gxTv_SdtPasswordChangePanel_Level_DetailSdt_Gxdynprop ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPasswordChangePanel_Level_DetailSdt_Gxdynprop = value;
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
         gxTv_SdtPasswordChangePanel_Level_DetailSdt_Oldpassword = "";
         gxTv_SdtPasswordChangePanel_Level_DetailSdt_Newpassword = "";
         gxTv_SdtPasswordChangePanel_Level_DetailSdt_Confirmpassword = "";
         gxTv_SdtPasswordChangePanel_Level_DetailSdt_Username = "";
         gxTv_SdtPasswordChangePanel_Level_DetailSdt_Gxdynprop = "";
         sdtIsNull = 1;
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected string gxTv_SdtPasswordChangePanel_Level_DetailSdt_Gxdynprop ;
      protected bool gxTv_SdtPasswordChangePanel_Level_DetailSdt_Ispasswordexpires ;
      protected string gxTv_SdtPasswordChangePanel_Level_DetailSdt_Oldpassword ;
      protected string gxTv_SdtPasswordChangePanel_Level_DetailSdt_Newpassword ;
      protected string gxTv_SdtPasswordChangePanel_Level_DetailSdt_Confirmpassword ;
      protected string gxTv_SdtPasswordChangePanel_Level_DetailSdt_Username ;
   }

   [DataContract(Name = @"PasswordChangePanel_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtPasswordChangePanel_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtPasswordChangePanel_Level_DetailSdt>
   {
      public SdtPasswordChangePanel_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtPasswordChangePanel_Level_DetailSdt_RESTInterface( SdtPasswordChangePanel_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Oldpassword" , Order = 0 )]
      public string gxTpr_Oldpassword
      {
         get {
            return sdt.gxTpr_Oldpassword ;
         }

         set {
            sdt.gxTpr_Oldpassword = value;
         }

      }

      [DataMember( Name = "Newpassword" , Order = 1 )]
      public string gxTpr_Newpassword
      {
         get {
            return sdt.gxTpr_Newpassword ;
         }

         set {
            sdt.gxTpr_Newpassword = value;
         }

      }

      [DataMember( Name = "Confirmpassword" , Order = 2 )]
      public string gxTpr_Confirmpassword
      {
         get {
            return sdt.gxTpr_Confirmpassword ;
         }

         set {
            sdt.gxTpr_Confirmpassword = value;
         }

      }

      [DataMember( Name = "Ispasswordexpires" , Order = 3 )]
      public bool gxTpr_Ispasswordexpires
      {
         get {
            return sdt.gxTpr_Ispasswordexpires ;
         }

         set {
            sdt.gxTpr_Ispasswordexpires = value;
         }

      }

      [DataMember( Name = "Username" , Order = 4 )]
      public string gxTpr_Username
      {
         get {
            return sdt.gxTpr_Username ;
         }

         set {
            sdt.gxTpr_Username = value;
         }

      }

      [DataMember( Name = "Gxdynprop" , Order = 5 )]
      public string gxTpr_Gxdynprop
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gxdynprop) ;
         }

         set {
            sdt.gxTpr_Gxdynprop = value;
         }

      }

      public SdtPasswordChangePanel_Level_DetailSdt sdt
      {
         get {
            return (SdtPasswordChangePanel_Level_DetailSdt)Sdt ;
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
            sdt = new SdtPasswordChangePanel_Level_DetailSdt() ;
         }
      }

   }

}
