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
   [XmlRoot(ElementName = "ViewLeaveRequest_Level_DetailSdt" )]
   [XmlType(TypeName =  "ViewLeaveRequest_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtViewLeaveRequest_Level_DetailSdt : GxUserType
   {
      public SdtViewLeaveRequest_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdate = DateTime.MinValue;
         gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequeststartdate = DateTime.MinValue;
         gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestenddate = DateTime.MinValue;
         gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdescription = "";
         gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverejectionreason = "";
         gxTv_SdtViewLeaveRequest_Level_DetailSdt_Gxdesc_leavetypeid = "";
      }

      public SdtViewLeaveRequest_Level_DetailSdt( IGxContext context )
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
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("Leaverequestdate", sDateCnv, false, false);
         AddObjectProperty("Leavetypeid", gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leavetypeid, false, false);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequeststartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequeststartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequeststartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("Leaverequeststartdate", sDateCnv, false, false);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestenddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestenddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestenddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("Leaverequestenddate", sDateCnv, false, false);
         AddObjectProperty("Leaverequestduration", gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestduration, false, false);
         AddObjectProperty("Leaverequestdescription", gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdescription, false, false);
         AddObjectProperty("Leaverejectionreason", gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverejectionreason, false, false);
         AddObjectProperty("Gxdesc_leavetypeid", gxTv_SdtViewLeaveRequest_Level_DetailSdt_Gxdesc_leavetypeid, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Leaverequestdate" )]
      [  XmlElement( ElementName = "Leaverequestdate"  , IsNullable=true )]
      public string gxTpr_Leaverequestdate_Nullable
      {
         get {
            if ( gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdate = DateTime.MinValue;
            else
               gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaverequestdate
      {
         get {
            return gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdate = value;
            SetDirty("Leaverequestdate");
         }

      }

      [  SoapElement( ElementName = "Leavetypeid" )]
      [  XmlElement( ElementName = "Leavetypeid"   )]
      public long gxTpr_Leavetypeid
      {
         get {
            return gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leavetypeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leavetypeid = value;
            SetDirty("Leavetypeid");
         }

      }

      [  SoapElement( ElementName = "Leaverequeststartdate" )]
      [  XmlElement( ElementName = "Leaverequeststartdate"  , IsNullable=true )]
      public string gxTpr_Leaverequeststartdate_Nullable
      {
         get {
            if ( gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequeststartdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequeststartdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequeststartdate = DateTime.MinValue;
            else
               gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequeststartdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaverequeststartdate
      {
         get {
            return gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequeststartdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequeststartdate = value;
            SetDirty("Leaverequeststartdate");
         }

      }

      [  SoapElement( ElementName = "Leaverequestenddate" )]
      [  XmlElement( ElementName = "Leaverequestenddate"  , IsNullable=true )]
      public string gxTpr_Leaverequestenddate_Nullable
      {
         get {
            if ( gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestenddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestenddate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestenddate = DateTime.MinValue;
            else
               gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestenddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaverequestenddate
      {
         get {
            return gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestenddate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestenddate = value;
            SetDirty("Leaverequestenddate");
         }

      }

      [  SoapElement( ElementName = "Leaverequestduration" )]
      [  XmlElement( ElementName = "Leaverequestduration"   )]
      public decimal gxTpr_Leaverequestduration
      {
         get {
            return gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestduration ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestduration = value;
            SetDirty("Leaverequestduration");
         }

      }

      [  SoapElement( ElementName = "Leaverequestdescription" )]
      [  XmlElement( ElementName = "Leaverequestdescription"   )]
      public string gxTpr_Leaverequestdescription
      {
         get {
            return gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdescription = value;
            SetDirty("Leaverequestdescription");
         }

      }

      [  SoapElement( ElementName = "Leaverejectionreason" )]
      [  XmlElement( ElementName = "Leaverejectionreason"   )]
      public string gxTpr_Leaverejectionreason
      {
         get {
            return gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverejectionreason ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverejectionreason = value;
            SetDirty("Leaverejectionreason");
         }

      }

      [  SoapElement( ElementName = "Gxdesc_leavetypeid" )]
      [  XmlElement( ElementName = "Gxdesc_leavetypeid"   )]
      public string gxTpr_Gxdesc_leavetypeid
      {
         get {
            return gxTv_SdtViewLeaveRequest_Level_DetailSdt_Gxdesc_leavetypeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtViewLeaveRequest_Level_DetailSdt_Gxdesc_leavetypeid = value;
            SetDirty("Gxdesc_leavetypeid");
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
         gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdate = DateTime.MinValue;
         gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequeststartdate = DateTime.MinValue;
         gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestenddate = DateTime.MinValue;
         gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdescription = "";
         gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverejectionreason = "";
         gxTv_SdtViewLeaveRequest_Level_DetailSdt_Gxdesc_leavetypeid = "";
         sdtIsNull = 1;
         sDateCnv = "";
         sNumToPad = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected long gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leavetypeid ;
      protected decimal gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestduration ;
      protected string sDateCnv ;
      protected string sNumToPad ;
      protected DateTime gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdate ;
      protected DateTime gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequeststartdate ;
      protected DateTime gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestenddate ;
      protected string gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverequestdescription ;
      protected string gxTv_SdtViewLeaveRequest_Level_DetailSdt_Leaverejectionreason ;
      protected string gxTv_SdtViewLeaveRequest_Level_DetailSdt_Gxdesc_leavetypeid ;
   }

   [DataContract(Name = @"ViewLeaveRequest_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtViewLeaveRequest_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtViewLeaveRequest_Level_DetailSdt>
   {
      public SdtViewLeaveRequest_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtViewLeaveRequest_Level_DetailSdt_RESTInterface( SdtViewLeaveRequest_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Leaverequestdate" , Order = 0 )]
      public string gxTpr_Leaverequestdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Leaverequestdate) ;
         }

         set {
            sdt.gxTpr_Leaverequestdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "Leavetypeid" , Order = 1 )]
      public string gxTpr_Leavetypeid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Leavetypeid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "Leaverequeststartdate" , Order = 2 )]
      public string gxTpr_Leaverequeststartdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Leaverequeststartdate) ;
         }

         set {
            sdt.gxTpr_Leaverequeststartdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "Leaverequestenddate" , Order = 3 )]
      public string gxTpr_Leaverequestenddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Leaverequestenddate) ;
         }

         set {
            sdt.gxTpr_Leaverequestenddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "Leaverequestduration" , Order = 4 )]
      public Nullable<decimal> gxTpr_Leaverequestduration
      {
         get {
            return sdt.gxTpr_Leaverequestduration ;
         }

         set {
            sdt.gxTpr_Leaverequestduration = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Leaverequestdescription" , Order = 5 )]
      public string gxTpr_Leaverequestdescription
      {
         get {
            return sdt.gxTpr_Leaverequestdescription ;
         }

         set {
            sdt.gxTpr_Leaverequestdescription = value;
         }

      }

      [DataMember( Name = "Leaverejectionreason" , Order = 6 )]
      public string gxTpr_Leaverejectionreason
      {
         get {
            return sdt.gxTpr_Leaverejectionreason ;
         }

         set {
            sdt.gxTpr_Leaverejectionreason = value;
         }

      }

      [DataMember( Name = "Gxdesc_leavetypeid" , Order = 7 )]
      public string gxTpr_Gxdesc_leavetypeid
      {
         get {
            return sdt.gxTpr_Gxdesc_leavetypeid ;
         }

         set {
            sdt.gxTpr_Gxdesc_leavetypeid = value;
         }

      }

      public SdtViewLeaveRequest_Level_DetailSdt sdt
      {
         get {
            return (SdtViewLeaveRequest_Level_DetailSdt)Sdt ;
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
            sdt = new SdtViewLeaveRequest_Level_DetailSdt() ;
         }
      }

   }

}
