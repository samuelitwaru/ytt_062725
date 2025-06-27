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
   [XmlRoot(ElementName = "UpdateLeaveRequest_Level_DetailSdt" )]
   [XmlType(TypeName =  "UpdateLeaveRequest_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtUpdateLeaveRequest_Level_DetailSdt : GxUserType
   {
      public SdtUpdateLeaveRequest_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdate = DateTime.MinValue;
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequeststartdate = DateTime.MinValue;
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestenddate = DateTime.MinValue;
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequesthalfday = "";
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdescription = "";
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Today = DateTime.MinValue;
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Msgvar = "";
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Gxdynprop = "";
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Gxdesc_leavetypeid = "";
      }

      public SdtUpdateLeaveRequest_Level_DetailSdt( IGxContext context )
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
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("Leaverequestdate", sDateCnv, false, false);
         AddObjectProperty("Leavetypeid", gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leavetypeid, false, false);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequeststartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequeststartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequeststartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("Leaverequeststartdate", sDateCnv, false, false);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestenddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestenddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestenddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("Leaverequestenddate", sDateCnv, false, false);
         AddObjectProperty("Leaverequestduration", gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestduration, false, false);
         AddObjectProperty("Leaverequesthalfday", gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequesthalfday, false, false);
         AddObjectProperty("Leaverequestdescription", gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdescription, false, false);
         if ( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequest != null )
         {
            AddObjectProperty("Leaverequest", gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequest, false, false);
         }
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Today)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Today)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Today)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("Today", sDateCnv, false, false);
         AddObjectProperty("Msgvar", gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Msgvar, false, false);
         AddObjectProperty("Gxdynprop", gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Gxdynprop, false, false);
         AddObjectProperty("Gxdesc_leavetypeid", gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Gxdesc_leavetypeid, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Leaverequestdate" )]
      [  XmlElement( ElementName = "Leaverequestdate"  , IsNullable=true )]
      public string gxTpr_Leaverequestdate_Nullable
      {
         get {
            if ( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdate = DateTime.MinValue;
            else
               gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaverequestdate
      {
         get {
            return gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdate = value;
            SetDirty("Leaverequestdate");
         }

      }

      [  SoapElement( ElementName = "Leavetypeid" )]
      [  XmlElement( ElementName = "Leavetypeid"   )]
      public long gxTpr_Leavetypeid
      {
         get {
            return gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leavetypeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leavetypeid = value;
            SetDirty("Leavetypeid");
         }

      }

      [  SoapElement( ElementName = "Leaverequeststartdate" )]
      [  XmlElement( ElementName = "Leaverequeststartdate"  , IsNullable=true )]
      public string gxTpr_Leaverequeststartdate_Nullable
      {
         get {
            if ( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequeststartdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequeststartdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequeststartdate = DateTime.MinValue;
            else
               gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequeststartdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaverequeststartdate
      {
         get {
            return gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequeststartdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequeststartdate = value;
            SetDirty("Leaverequeststartdate");
         }

      }

      [  SoapElement( ElementName = "Leaverequestenddate" )]
      [  XmlElement( ElementName = "Leaverequestenddate"  , IsNullable=true )]
      public string gxTpr_Leaverequestenddate_Nullable
      {
         get {
            if ( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestenddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestenddate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestenddate = DateTime.MinValue;
            else
               gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestenddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaverequestenddate
      {
         get {
            return gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestenddate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestenddate = value;
            SetDirty("Leaverequestenddate");
         }

      }

      [  SoapElement( ElementName = "Leaverequestduration" )]
      [  XmlElement( ElementName = "Leaverequestduration"   )]
      public decimal gxTpr_Leaverequestduration
      {
         get {
            return gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestduration ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestduration = value;
            SetDirty("Leaverequestduration");
         }

      }

      [  SoapElement( ElementName = "Leaverequesthalfday" )]
      [  XmlElement( ElementName = "Leaverequesthalfday"   )]
      public string gxTpr_Leaverequesthalfday
      {
         get {
            return gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequesthalfday ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequesthalfday = value;
            SetDirty("Leaverequesthalfday");
         }

      }

      [  SoapElement( ElementName = "Leaverequestdescription" )]
      [  XmlElement( ElementName = "Leaverequestdescription"   )]
      public string gxTpr_Leaverequestdescription
      {
         get {
            return gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdescription = value;
            SetDirty("Leaverequestdescription");
         }

      }

      [  SoapElement( ElementName = "Leaverequest" )]
      [  XmlElement( ElementName = "Leaverequest"   )]
      public SdtLeaveRequest gxTpr_Leaverequest
      {
         get {
            if ( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequest == null )
            {
               gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequest = new SdtLeaveRequest(context);
            }
            sdtIsNull = 0;
            return gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequest ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequest = value;
            SetDirty("Leaverequest");
         }

      }

      public void gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequest_SetNull( )
      {
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequest = null;
         return  ;
      }

      public bool gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequest_IsNull( )
      {
         if ( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequest == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Today" )]
      [  XmlElement( ElementName = "Today"  , IsNullable=true )]
      public string gxTpr_Today_Nullable
      {
         get {
            if ( gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Today == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Today).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Today = DateTime.MinValue;
            else
               gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Today = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Today
      {
         get {
            return gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Today ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Today = value;
            SetDirty("Today");
         }

      }

      [  SoapElement( ElementName = "Msgvar" )]
      [  XmlElement( ElementName = "Msgvar"   )]
      public string gxTpr_Msgvar
      {
         get {
            return gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Msgvar ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Msgvar = value;
            SetDirty("Msgvar");
         }

      }

      [  SoapElement( ElementName = "Gxdynprop" )]
      [  XmlElement( ElementName = "Gxdynprop"   )]
      public string gxTpr_Gxdynprop
      {
         get {
            return gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Gxdynprop ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Gxdynprop = value;
            SetDirty("Gxdynprop");
         }

      }

      [  SoapElement( ElementName = "Gxdesc_leavetypeid" )]
      [  XmlElement( ElementName = "Gxdesc_leavetypeid"   )]
      public string gxTpr_Gxdesc_leavetypeid
      {
         get {
            return gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Gxdesc_leavetypeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Gxdesc_leavetypeid = value;
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
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdate = DateTime.MinValue;
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequeststartdate = DateTime.MinValue;
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestenddate = DateTime.MinValue;
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequesthalfday = "";
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdescription = "";
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Today = DateTime.MinValue;
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Msgvar = "";
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Gxdynprop = "";
         gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Gxdesc_leavetypeid = "";
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
      protected long gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leavetypeid ;
      protected decimal gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestduration ;
      protected string gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequesthalfday ;
      protected string gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Msgvar ;
      protected string gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Gxdynprop ;
      protected string sDateCnv ;
      protected string sNumToPad ;
      protected DateTime gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdate ;
      protected DateTime gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequeststartdate ;
      protected DateTime gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestenddate ;
      protected DateTime gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Today ;
      protected string gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequestdescription ;
      protected string gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Gxdesc_leavetypeid ;
      protected SdtLeaveRequest gxTv_SdtUpdateLeaveRequest_Level_DetailSdt_Leaverequest=null ;
   }

   [DataContract(Name = @"UpdateLeaveRequest_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtUpdateLeaveRequest_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtUpdateLeaveRequest_Level_DetailSdt>
   {
      public SdtUpdateLeaveRequest_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtUpdateLeaveRequest_Level_DetailSdt_RESTInterface( SdtUpdateLeaveRequest_Level_DetailSdt psdt ) : base(psdt)
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

      [DataMember( Name = "Leaverequesthalfday" , Order = 5 )]
      public string gxTpr_Leaverequesthalfday
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Leaverequesthalfday) ;
         }

         set {
            sdt.gxTpr_Leaverequesthalfday = value;
         }

      }

      [DataMember( Name = "Leaverequestdescription" , Order = 6 )]
      public string gxTpr_Leaverequestdescription
      {
         get {
            return sdt.gxTpr_Leaverequestdescription ;
         }

         set {
            sdt.gxTpr_Leaverequestdescription = value;
         }

      }

      [DataMember( Name = "Leaverequest" , Order = 7 )]
      public SdtLeaveRequest_RESTInterface gxTpr_Leaverequest
      {
         get {
            return new SdtLeaveRequest_RESTInterface(sdt.gxTpr_Leaverequest) ;
         }

         set {
            sdt.gxTpr_Leaverequest = value.sdt;
         }

      }

      [DataMember( Name = "Today" , Order = 8 )]
      public string gxTpr_Today
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Today) ;
         }

         set {
            sdt.gxTpr_Today = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "Msgvar" , Order = 9 )]
      public string gxTpr_Msgvar
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Msgvar) ;
         }

         set {
            sdt.gxTpr_Msgvar = value;
         }

      }

      [DataMember( Name = "Gxdynprop" , Order = 10 )]
      public string gxTpr_Gxdynprop
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gxdynprop) ;
         }

         set {
            sdt.gxTpr_Gxdynprop = value;
         }

      }

      [DataMember( Name = "Gxdesc_leavetypeid" , Order = 11 )]
      public string gxTpr_Gxdesc_leavetypeid
      {
         get {
            return sdt.gxTpr_Gxdesc_leavetypeid ;
         }

         set {
            sdt.gxTpr_Gxdesc_leavetypeid = value;
         }

      }

      public SdtUpdateLeaveRequest_Level_DetailSdt sdt
      {
         get {
            return (SdtUpdateLeaveRequest_Level_DetailSdt)Sdt ;
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
            sdt = new SdtUpdateLeaveRequest_Level_DetailSdt() ;
         }
      }

   }

}
