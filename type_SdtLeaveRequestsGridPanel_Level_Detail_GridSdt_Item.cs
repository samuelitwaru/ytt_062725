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
   [XmlRoot(ElementName = "Item" )]
   [XmlType(TypeName =  "Item" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item : GxUserType
   {
      public SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item( )
      {
         /* Constructor for serialization */
         gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaverequestdescription = "";
         gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaverequeststatus = "";
         gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaveinfo = "";
         gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaveperiod = "";
         gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Gxdynprop = "";
      }

      public SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item( IGxContext context )
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
         AddObjectProperty("LeaveRequestId", gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaverequestid, false, false);
         AddObjectProperty("LeaveRequestDescription", gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaverequestdescription, false, false);
         AddObjectProperty("LeaveRequestStatus", gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaverequeststatus, false, false);
         AddObjectProperty("Leaveinfo", gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaveinfo, false, false);
         AddObjectProperty("Leaveperiod", gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaveperiod, false, false);
         AddObjectProperty("Gxdynprop", gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Gxdynprop, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "LeaveRequestId" )]
      [  XmlElement( ElementName = "LeaveRequestId"   )]
      public long gxTpr_Leaverequestid
      {
         get {
            return gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaverequestid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaverequestid = value;
            SetDirty("Leaverequestid");
         }

      }

      [  SoapElement( ElementName = "LeaveRequestDescription" )]
      [  XmlElement( ElementName = "LeaveRequestDescription"   )]
      public string gxTpr_Leaverequestdescription
      {
         get {
            return gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaverequestdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaverequestdescription = value;
            SetDirty("Leaverequestdescription");
         }

      }

      [  SoapElement( ElementName = "LeaveRequestStatus" )]
      [  XmlElement( ElementName = "LeaveRequestStatus"   )]
      public string gxTpr_Leaverequeststatus
      {
         get {
            return gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaverequeststatus ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaverequeststatus = value;
            SetDirty("Leaverequeststatus");
         }

      }

      [  SoapElement( ElementName = "Leaveinfo" )]
      [  XmlElement( ElementName = "Leaveinfo"   )]
      public string gxTpr_Leaveinfo
      {
         get {
            return gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaveinfo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaveinfo = value;
            SetDirty("Leaveinfo");
         }

      }

      [  SoapElement( ElementName = "Leaveperiod" )]
      [  XmlElement( ElementName = "Leaveperiod"   )]
      public string gxTpr_Leaveperiod
      {
         get {
            return gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaveperiod ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaveperiod = value;
            SetDirty("Leaveperiod");
         }

      }

      [  SoapElement( ElementName = "Gxdynprop" )]
      [  XmlElement( ElementName = "Gxdynprop"   )]
      public string gxTpr_Gxdynprop
      {
         get {
            return gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Gxdynprop ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Gxdynprop = value;
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
         gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaverequestdescription = "";
         gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaverequeststatus = "";
         gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaveinfo = "";
         gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaveperiod = "";
         gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Gxdynprop = "";
         sdtIsNull = 1;
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected long gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaverequestid ;
      protected string gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaverequeststatus ;
      protected string gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaveinfo ;
      protected string gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Gxdynprop ;
      protected string gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaverequestdescription ;
      protected string gxTv_SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_Leaveperiod ;
   }

   [DataContract(Name = @"LeaveRequestsGridPanel_Level_Detail_GridSdt.Item", Namespace = "http://tempuri.org/")]
   [GxJsonSerialization("unwrapped")]
   public class SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_RESTInterface : GxGenericCollectionItem<SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item>
   {
      public SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_RESTInterface( ) : base()
      {
      }

      public SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item_RESTInterface( SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LeaveRequestId" , Order = 0 )]
      public string gxTpr_Leaverequestid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Leaverequestid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Leaverequestid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "LeaveRequestDescription" , Order = 1 )]
      public string gxTpr_Leaverequestdescription
      {
         get {
            return sdt.gxTpr_Leaverequestdescription ;
         }

         set {
            sdt.gxTpr_Leaverequestdescription = value;
         }

      }

      [DataMember( Name = "LeaveRequestStatus" , Order = 2 )]
      public string gxTpr_Leaverequeststatus
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Leaverequeststatus) ;
         }

         set {
            sdt.gxTpr_Leaverequeststatus = value;
         }

      }

      [DataMember( Name = "Leaveinfo" , Order = 3 )]
      public string gxTpr_Leaveinfo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Leaveinfo) ;
         }

         set {
            sdt.gxTpr_Leaveinfo = value;
         }

      }

      [DataMember( Name = "Leaveperiod" , Order = 4 )]
      public string gxTpr_Leaveperiod
      {
         get {
            return sdt.gxTpr_Leaveperiod ;
         }

         set {
            sdt.gxTpr_Leaveperiod = value;
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

      public SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item sdt
      {
         get {
            return (SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item)Sdt ;
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
            sdt = new SdtLeaveRequestsGridPanel_Level_Detail_GridSdt_Item() ;
         }
      }

   }

}
