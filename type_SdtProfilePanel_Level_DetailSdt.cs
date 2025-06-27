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
   [XmlRoot(ElementName = "ProfilePanel_Level_DetailSdt" )]
   [XmlType(TypeName =  "ProfilePanel_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtProfilePanel_Level_DetailSdt : GxUserType
   {
      public SdtProfilePanel_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtProfilePanel_Level_DetailSdt_Gxprops_menuoptions = "";
         gxTv_SdtProfilePanel_Level_DetailSdt_Name = "";
         gxTv_SdtProfilePanel_Level_DetailSdt_Email = "";
         gxTv_SdtProfilePanel_Level_DetailSdt_Usercompany = "";
         gxTv_SdtProfilePanel_Level_DetailSdt_Role = "";
      }

      public SdtProfilePanel_Level_DetailSdt( IGxContext context )
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
         AddObjectProperty("Gxprops_menuoptions", gxTv_SdtProfilePanel_Level_DetailSdt_Gxprops_menuoptions, false, false);
         if ( gxTv_SdtProfilePanel_Level_DetailSdt_Menuoptions != null )
         {
            AddObjectProperty("Menuoptions", gxTv_SdtProfilePanel_Level_DetailSdt_Menuoptions, false, false);
         }
         AddObjectProperty("Name", gxTv_SdtProfilePanel_Level_DetailSdt_Name, false, false);
         AddObjectProperty("Email", gxTv_SdtProfilePanel_Level_DetailSdt_Email, false, false);
         AddObjectProperty("Usercompany", gxTv_SdtProfilePanel_Level_DetailSdt_Usercompany, false, false);
         AddObjectProperty("Role", gxTv_SdtProfilePanel_Level_DetailSdt_Role, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Gxprops_menuoptions" )]
      [  XmlElement( ElementName = "Gxprops_menuoptions"   )]
      public string gxTpr_Gxprops_menuoptions
      {
         get {
            return gxTv_SdtProfilePanel_Level_DetailSdt_Gxprops_menuoptions ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfilePanel_Level_DetailSdt_Gxprops_menuoptions = value;
            SetDirty("Gxprops_menuoptions");
         }

      }

      [  SoapElement( ElementName = "Menuoptions" )]
      [  XmlArray( ElementName = "Menuoptions"  )]
      [  XmlArrayItemAttribute( ElementName= "MenuOptions.MenuOptionsItem"  , IsNullable=false)]
      public GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem> gxTpr_Menuoptions_GXBaseCollection
      {
         get {
            if ( gxTv_SdtProfilePanel_Level_DetailSdt_Menuoptions == null )
            {
               gxTv_SdtProfilePanel_Level_DetailSdt_Menuoptions = new GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem>( context, "MenuOptionsItem", "YTT_version4");
            }
            return gxTv_SdtProfilePanel_Level_DetailSdt_Menuoptions ;
         }

         set {
            if ( gxTv_SdtProfilePanel_Level_DetailSdt_Menuoptions == null )
            {
               gxTv_SdtProfilePanel_Level_DetailSdt_Menuoptions = new GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem>( context, "MenuOptionsItem", "YTT_version4");
            }
            sdtIsNull = 0;
            gxTv_SdtProfilePanel_Level_DetailSdt_Menuoptions = value;
         }

      }

      [XmlIgnore]
      public GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem> gxTpr_Menuoptions
      {
         get {
            if ( gxTv_SdtProfilePanel_Level_DetailSdt_Menuoptions == null )
            {
               gxTv_SdtProfilePanel_Level_DetailSdt_Menuoptions = new GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem>( context, "MenuOptionsItem", "YTT_version4");
            }
            sdtIsNull = 0;
            return gxTv_SdtProfilePanel_Level_DetailSdt_Menuoptions ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfilePanel_Level_DetailSdt_Menuoptions = value;
            SetDirty("Menuoptions");
         }

      }

      public void gxTv_SdtProfilePanel_Level_DetailSdt_Menuoptions_SetNull( )
      {
         gxTv_SdtProfilePanel_Level_DetailSdt_Menuoptions = null;
         return  ;
      }

      public bool gxTv_SdtProfilePanel_Level_DetailSdt_Menuoptions_IsNull( )
      {
         if ( gxTv_SdtProfilePanel_Level_DetailSdt_Menuoptions == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Name" )]
      [  XmlElement( ElementName = "Name"   )]
      public string gxTpr_Name
      {
         get {
            return gxTv_SdtProfilePanel_Level_DetailSdt_Name ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfilePanel_Level_DetailSdt_Name = value;
            SetDirty("Name");
         }

      }

      [  SoapElement( ElementName = "Email" )]
      [  XmlElement( ElementName = "Email"   )]
      public string gxTpr_Email
      {
         get {
            return gxTv_SdtProfilePanel_Level_DetailSdt_Email ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfilePanel_Level_DetailSdt_Email = value;
            SetDirty("Email");
         }

      }

      [  SoapElement( ElementName = "Usercompany" )]
      [  XmlElement( ElementName = "Usercompany"   )]
      public string gxTpr_Usercompany
      {
         get {
            return gxTv_SdtProfilePanel_Level_DetailSdt_Usercompany ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfilePanel_Level_DetailSdt_Usercompany = value;
            SetDirty("Usercompany");
         }

      }

      [  SoapElement( ElementName = "Role" )]
      [  XmlElement( ElementName = "Role"   )]
      public string gxTpr_Role
      {
         get {
            return gxTv_SdtProfilePanel_Level_DetailSdt_Role ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfilePanel_Level_DetailSdt_Role = value;
            SetDirty("Role");
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
         gxTv_SdtProfilePanel_Level_DetailSdt_Gxprops_menuoptions = "";
         gxTv_SdtProfilePanel_Level_DetailSdt_Name = "";
         gxTv_SdtProfilePanel_Level_DetailSdt_Email = "";
         gxTv_SdtProfilePanel_Level_DetailSdt_Usercompany = "";
         gxTv_SdtProfilePanel_Level_DetailSdt_Role = "";
         sdtIsNull = 1;
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected string gxTv_SdtProfilePanel_Level_DetailSdt_Gxprops_menuoptions ;
      protected string gxTv_SdtProfilePanel_Level_DetailSdt_Name ;
      protected string gxTv_SdtProfilePanel_Level_DetailSdt_Usercompany ;
      protected string gxTv_SdtProfilePanel_Level_DetailSdt_Role ;
      protected string gxTv_SdtProfilePanel_Level_DetailSdt_Email ;
      protected GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem> gxTv_SdtProfilePanel_Level_DetailSdt_Menuoptions=null ;
   }

   [DataContract(Name = @"ProfilePanel_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtProfilePanel_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtProfilePanel_Level_DetailSdt>
   {
      public SdtProfilePanel_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtProfilePanel_Level_DetailSdt_RESTInterface( SdtProfilePanel_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Gxprops_menuoptions" , Order = 0 )]
      public string gxTpr_Gxprops_menuoptions
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gxprops_menuoptions) ;
         }

         set {
            sdt.gxTpr_Gxprops_menuoptions = value;
         }

      }

      [DataMember( Name = "Menuoptions" , Order = 1 )]
      public GxGenericCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem_RESTInterface> gxTpr_Menuoptions
      {
         get {
            return new GxGenericCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem_RESTInterface>(sdt.gxTpr_Menuoptions) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Menuoptions);
         }

      }

      [DataMember( Name = "Name" , Order = 2 )]
      public string gxTpr_Name
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Name) ;
         }

         set {
            sdt.gxTpr_Name = value;
         }

      }

      [DataMember( Name = "Email" , Order = 3 )]
      public string gxTpr_Email
      {
         get {
            return sdt.gxTpr_Email ;
         }

         set {
            sdt.gxTpr_Email = value;
         }

      }

      [DataMember( Name = "Usercompany" , Order = 4 )]
      public string gxTpr_Usercompany
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usercompany) ;
         }

         set {
            sdt.gxTpr_Usercompany = value;
         }

      }

      [DataMember( Name = "Role" , Order = 5 )]
      public string gxTpr_Role
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Role) ;
         }

         set {
            sdt.gxTpr_Role = value;
         }

      }

      public SdtProfilePanel_Level_DetailSdt sdt
      {
         get {
            return (SdtProfilePanel_Level_DetailSdt)Sdt ;
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
            sdt = new SdtProfilePanel_Level_DetailSdt() ;
         }
      }

   }

}
