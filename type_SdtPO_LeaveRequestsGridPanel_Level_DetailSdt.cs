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
   [XmlRoot(ElementName = "PO_LeaveRequestsGridPanel_Level_DetailSdt" )]
   [XmlType(TypeName =  "PO_LeaveRequestsGridPanel_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtPO_LeaveRequestsGridPanel_Level_DetailSdt : GxUserType
   {
      public SdtPO_LeaveRequestsGridPanel_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtPO_LeaveRequestsGridPanel_Level_DetailSdt_Msgvar = "";
      }

      public SdtPO_LeaveRequestsGridPanel_Level_DetailSdt( IGxContext context )
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
         AddObjectProperty("Msgvar", gxTv_SdtPO_LeaveRequestsGridPanel_Level_DetailSdt_Msgvar, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Msgvar" )]
      [  XmlElement( ElementName = "Msgvar"   )]
      public string gxTpr_Msgvar
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanel_Level_DetailSdt_Msgvar ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanel_Level_DetailSdt_Msgvar = value;
            SetDirty("Msgvar");
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
         gxTv_SdtPO_LeaveRequestsGridPanel_Level_DetailSdt_Msgvar = "";
         sdtIsNull = 1;
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected string gxTv_SdtPO_LeaveRequestsGridPanel_Level_DetailSdt_Msgvar ;
   }

   [DataContract(Name = @"PO_LeaveRequestsGridPanel_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtPO_LeaveRequestsGridPanel_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtPO_LeaveRequestsGridPanel_Level_DetailSdt>
   {
      public SdtPO_LeaveRequestsGridPanel_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtPO_LeaveRequestsGridPanel_Level_DetailSdt_RESTInterface( SdtPO_LeaveRequestsGridPanel_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Msgvar" , Order = 0 )]
      public string gxTpr_Msgvar
      {
         get {
            return sdt.gxTpr_Msgvar ;
         }

         set {
            sdt.gxTpr_Msgvar = value;
         }

      }

      public SdtPO_LeaveRequestsGridPanel_Level_DetailSdt sdt
      {
         get {
            return (SdtPO_LeaveRequestsGridPanel_Level_DetailSdt)Sdt ;
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
            sdt = new SdtPO_LeaveRequestsGridPanel_Level_DetailSdt() ;
         }
      }

   }

}
