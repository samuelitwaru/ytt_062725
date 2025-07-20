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
   [XmlRoot(ElementName = "PO_LeaveRequestsGridPanelView_Level_DetailSdt" )]
   [XmlType(TypeName =  "PO_LeaveRequestsGridPanelView_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt : GxUserType
   {
      public SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt_Gxdynprop = "";
      }

      public SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt( IGxContext context )
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
         AddObjectProperty("Leaverequestid", gxTv_SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt_Leaverequestid, false, false);
         AddObjectProperty("Gxdynprop", gxTv_SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt_Gxdynprop, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Leaverequestid" )]
      [  XmlElement( ElementName = "Leaverequestid"   )]
      public long gxTpr_Leaverequestid
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt_Leaverequestid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt_Leaverequestid = value;
            SetDirty("Leaverequestid");
         }

      }

      [  SoapElement( ElementName = "Gxdynprop" )]
      [  XmlElement( ElementName = "Gxdynprop"   )]
      public string gxTpr_Gxdynprop
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt_Gxdynprop ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt_Gxdynprop = value;
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
         gxTv_SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt_Gxdynprop = "";
         sdtIsNull = 1;
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected long gxTv_SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt_Leaverequestid ;
      protected string gxTv_SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt_Gxdynprop ;
   }

   [DataContract(Name = @"PO_LeaveRequestsGridPanelView_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt>
   {
      public SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt_RESTInterface( SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Leaverequestid" , Order = 0 )]
      public string gxTpr_Leaverequestid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Leaverequestid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Leaverequestid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
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

      public SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt sdt
      {
         get {
            return (SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt)Sdt ;
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
            sdt = new SdtPO_LeaveRequestsGridPanelView_Level_DetailSdt() ;
         }
      }

   }

}
