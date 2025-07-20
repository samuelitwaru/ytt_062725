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
   [XmlRoot(ElementName = "PO_LeaveRequestsGridPanelData_Level_DetailSdt" )]
   [XmlType(TypeName =  "PO_LeaveRequestsGridPanelData_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt : GxUserType
   {
      public SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Trnmode = "";
         gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Gxdynprop = "";
      }

      public SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt( IGxContext context )
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
         if ( gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Leaverequest != null )
         {
            AddObjectProperty("Leaverequest", gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Leaverequest, false, false);
         }
         AddObjectProperty("Trnmode", gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Trnmode, false, false);
         AddObjectProperty("Leaverequestid", gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Leaverequestid, false, false);
         if ( gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Messages != null )
         {
            AddObjectProperty("Messages", gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Messages, false, false);
         }
         AddObjectProperty("Gxdynprop", gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Gxdynprop, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Leaverequest" )]
      [  XmlElement( ElementName = "Leaverequest"   )]
      public SdtLeaveRequest gxTpr_Leaverequest
      {
         get {
            if ( gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Leaverequest == null )
            {
               gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Leaverequest = new SdtLeaveRequest(context);
            }
            sdtIsNull = 0;
            return gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Leaverequest ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Leaverequest = value;
            SetDirty("Leaverequest");
         }

      }

      public void gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Leaverequest_SetNull( )
      {
         gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Leaverequest = null;
         return  ;
      }

      public bool gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Leaverequest_IsNull( )
      {
         if ( gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Leaverequest == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Trnmode" )]
      [  XmlElement( ElementName = "Trnmode"   )]
      public string gxTpr_Trnmode
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Trnmode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Trnmode = value;
            SetDirty("Trnmode");
         }

      }

      [  SoapElement( ElementName = "Leaverequestid" )]
      [  XmlElement( ElementName = "Leaverequestid"   )]
      public long gxTpr_Leaverequestid
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Leaverequestid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Leaverequestid = value;
            SetDirty("Leaverequestid");
         }

      }

      [  SoapElement( ElementName = "Messages" )]
      [  XmlArray( ElementName = "Messages"  )]
      [  XmlArrayItemAttribute( ElementName= "Messages.Message"  , IsNullable=false)]
      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> gxTpr_Messages_GXBaseCollection
      {
         get {
            if ( gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Messages == null )
            {
               gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
            }
            return gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Messages ;
         }

         set {
            if ( gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Messages == null )
            {
               gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
            }
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Messages = value;
         }

      }

      [XmlIgnore]
      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> gxTpr_Messages
      {
         get {
            if ( gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Messages == null )
            {
               gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
            }
            sdtIsNull = 0;
            return gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Messages ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Messages = value;
            SetDirty("Messages");
         }

      }

      public void gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Messages_SetNull( )
      {
         gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Messages = null;
         return  ;
      }

      public bool gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Messages_IsNull( )
      {
         if ( gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Messages == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Gxdynprop" )]
      [  XmlElement( ElementName = "Gxdynprop"   )]
      public string gxTpr_Gxdynprop
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Gxdynprop ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Gxdynprop = value;
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
         gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Trnmode = "";
         gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Gxdynprop = "";
         sdtIsNull = 1;
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected long gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Leaverequestid ;
      protected string gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Trnmode ;
      protected string gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Gxdynprop ;
      protected SdtLeaveRequest gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Leaverequest=null ;
      protected GXBaseCollection<GeneXus.Utils.SdtMessages_Message> gxTv_SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_Messages=null ;
   }

   [DataContract(Name = @"PO_LeaveRequestsGridPanelData_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt>
   {
      public SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt_RESTInterface( SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Leaverequest" , Order = 0 )]
      public SdtLeaveRequest_RESTInterface gxTpr_Leaverequest
      {
         get {
            return new SdtLeaveRequest_RESTInterface(sdt.gxTpr_Leaverequest) ;
         }

         set {
            sdt.gxTpr_Leaverequest = value.sdt;
         }

      }

      [DataMember( Name = "Trnmode" , Order = 1 )]
      public string gxTpr_Trnmode
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Trnmode) ;
         }

         set {
            sdt.gxTpr_Trnmode = value;
         }

      }

      [DataMember( Name = "Leaverequestid" , Order = 2 )]
      public string gxTpr_Leaverequestid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Leaverequestid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Leaverequestid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "Messages" , Order = 3 )]
      public GxGenericCollection<GeneXus.Utils.SdtMessages_Message_RESTInterface> gxTpr_Messages
      {
         get {
            return new GxGenericCollection<GeneXus.Utils.SdtMessages_Message_RESTInterface>(sdt.gxTpr_Messages) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Messages);
         }

      }

      [DataMember( Name = "Gxdynprop" , Order = 4 )]
      public string gxTpr_Gxdynprop
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gxdynprop) ;
         }

         set {
            sdt.gxTpr_Gxdynprop = value;
         }

      }

      public SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt sdt
      {
         get {
            return (SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt)Sdt ;
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
            sdt = new SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt() ;
         }
      }

   }

}
