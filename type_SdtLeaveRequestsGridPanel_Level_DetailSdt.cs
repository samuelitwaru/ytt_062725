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
   [XmlRoot(ElementName = "LeaveRequestsGridPanel_Level_DetailSdt" )]
   [XmlType(TypeName =  "LeaveRequestsGridPanel_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtLeaveRequestsGridPanel_Level_DetailSdt : GxUserType
   {
      public SdtLeaveRequestsGridPanel_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtLeaveRequestsGridPanel_Level_DetailSdt_Msgvar = "";
         gxTv_SdtLeaveRequestsGridPanel_Level_DetailSdt_Gxdynprop = "";
      }

      public SdtLeaveRequestsGridPanel_Level_DetailSdt( IGxContext context )
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
         AddObjectProperty("Msgvar", gxTv_SdtLeaveRequestsGridPanel_Level_DetailSdt_Msgvar, false, false);
         AddObjectProperty("Gxdynprop", gxTv_SdtLeaveRequestsGridPanel_Level_DetailSdt_Gxdynprop, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Msgvar" )]
      [  XmlElement( ElementName = "Msgvar"   )]
      public string gxTpr_Msgvar
      {
         get {
            return gxTv_SdtLeaveRequestsGridPanel_Level_DetailSdt_Msgvar ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestsGridPanel_Level_DetailSdt_Msgvar = value;
            SetDirty("Msgvar");
         }

      }

      [  SoapElement( ElementName = "Gxdynprop" )]
      [  XmlElement( ElementName = "Gxdynprop"   )]
      public string gxTpr_Gxdynprop
      {
         get {
            return gxTv_SdtLeaveRequestsGridPanel_Level_DetailSdt_Gxdynprop ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestsGridPanel_Level_DetailSdt_Gxdynprop = value;
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
         gxTv_SdtLeaveRequestsGridPanel_Level_DetailSdt_Msgvar = "";
         gxTv_SdtLeaveRequestsGridPanel_Level_DetailSdt_Gxdynprop = "";
         sdtIsNull = 1;
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected string gxTv_SdtLeaveRequestsGridPanel_Level_DetailSdt_Msgvar ;
      protected string gxTv_SdtLeaveRequestsGridPanel_Level_DetailSdt_Gxdynprop ;
   }

   [DataContract(Name = @"LeaveRequestsGridPanel_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtLeaveRequestsGridPanel_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtLeaveRequestsGridPanel_Level_DetailSdt>
   {
      public SdtLeaveRequestsGridPanel_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtLeaveRequestsGridPanel_Level_DetailSdt_RESTInterface( SdtLeaveRequestsGridPanel_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Msgvar" , Order = 0 )]
      public string gxTpr_Msgvar
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Msgvar) ;
         }

         set {
            sdt.gxTpr_Msgvar = value;
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

      public SdtLeaveRequestsGridPanel_Level_DetailSdt sdt
      {
         get {
            return (SdtLeaveRequestsGridPanel_Level_DetailSdt)Sdt ;
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
            sdt = new SdtLeaveRequestsGridPanel_Level_DetailSdt() ;
         }
      }

   }

}
