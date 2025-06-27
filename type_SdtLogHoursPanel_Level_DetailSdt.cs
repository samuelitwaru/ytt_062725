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
   [XmlRoot(ElementName = "LogHoursPanel_Level_DetailSdt" )]
   [XmlType(TypeName =  "LogHoursPanel_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtLogHoursPanel_Level_DetailSdt : GxUserType
   {
      public SdtLogHoursPanel_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdate = DateTime.MinValue;
         gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdescription = "";
         gxTv_SdtLogHoursPanel_Level_DetailSdt_Today = DateTime.MinValue;
         gxTv_SdtLogHoursPanel_Level_DetailSdt_Msgvar = "";
         gxTv_SdtLogHoursPanel_Level_DetailSdt_Gxdynprop = "";
      }

      public SdtLogHoursPanel_Level_DetailSdt( IGxContext context )
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
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("Workhourlogdate", sDateCnv, false, false);
         AddObjectProperty("Projectid", gxTv_SdtLogHoursPanel_Level_DetailSdt_Projectid, false, false);
         AddObjectProperty("Loghour", gxTv_SdtLogHoursPanel_Level_DetailSdt_Loghour, false, false);
         AddObjectProperty("Logminute", gxTv_SdtLogHoursPanel_Level_DetailSdt_Logminute, false, false);
         AddObjectProperty("Workhourlogdescription", gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdescription, false, false);
         AddObjectProperty("Employeeid", gxTv_SdtLogHoursPanel_Level_DetailSdt_Employeeid, false, false);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtLogHoursPanel_Level_DetailSdt_Today)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtLogHoursPanel_Level_DetailSdt_Today)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtLogHoursPanel_Level_DetailSdt_Today)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("Today", sDateCnv, false, false);
         AddObjectProperty("Msgvar", gxTv_SdtLogHoursPanel_Level_DetailSdt_Msgvar, false, false);
         AddObjectProperty("Gxdynprop", gxTv_SdtLogHoursPanel_Level_DetailSdt_Gxdynprop, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Workhourlogdate" )]
      [  XmlElement( ElementName = "Workhourlogdate"  , IsNullable=true )]
      public string gxTpr_Workhourlogdate_Nullable
      {
         get {
            if ( gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdate = DateTime.MinValue;
            else
               gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Workhourlogdate
      {
         get {
            return gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdate = value;
            SetDirty("Workhourlogdate");
         }

      }

      [  SoapElement( ElementName = "Projectid" )]
      [  XmlElement( ElementName = "Projectid"   )]
      public short gxTpr_Projectid
      {
         get {
            return gxTv_SdtLogHoursPanel_Level_DetailSdt_Projectid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogHoursPanel_Level_DetailSdt_Projectid = value;
            SetDirty("Projectid");
         }

      }

      [  SoapElement( ElementName = "Loghour" )]
      [  XmlElement( ElementName = "Loghour"   )]
      public short gxTpr_Loghour
      {
         get {
            return gxTv_SdtLogHoursPanel_Level_DetailSdt_Loghour ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogHoursPanel_Level_DetailSdt_Loghour = value;
            SetDirty("Loghour");
         }

      }

      [  SoapElement( ElementName = "Logminute" )]
      [  XmlElement( ElementName = "Logminute"   )]
      public short gxTpr_Logminute
      {
         get {
            return gxTv_SdtLogHoursPanel_Level_DetailSdt_Logminute ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogHoursPanel_Level_DetailSdt_Logminute = value;
            SetDirty("Logminute");
         }

      }

      [  SoapElement( ElementName = "Workhourlogdescription" )]
      [  XmlElement( ElementName = "Workhourlogdescription"   )]
      public string gxTpr_Workhourlogdescription
      {
         get {
            return gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdescription = value;
            SetDirty("Workhourlogdescription");
         }

      }

      [  SoapElement( ElementName = "Employeeid" )]
      [  XmlElement( ElementName = "Employeeid"   )]
      public long gxTpr_Employeeid
      {
         get {
            return gxTv_SdtLogHoursPanel_Level_DetailSdt_Employeeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogHoursPanel_Level_DetailSdt_Employeeid = value;
            SetDirty("Employeeid");
         }

      }

      [  SoapElement( ElementName = "Today" )]
      [  XmlElement( ElementName = "Today"  , IsNullable=true )]
      public string gxTpr_Today_Nullable
      {
         get {
            if ( gxTv_SdtLogHoursPanel_Level_DetailSdt_Today == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtLogHoursPanel_Level_DetailSdt_Today).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtLogHoursPanel_Level_DetailSdt_Today = DateTime.MinValue;
            else
               gxTv_SdtLogHoursPanel_Level_DetailSdt_Today = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Today
      {
         get {
            return gxTv_SdtLogHoursPanel_Level_DetailSdt_Today ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogHoursPanel_Level_DetailSdt_Today = value;
            SetDirty("Today");
         }

      }

      [  SoapElement( ElementName = "Msgvar" )]
      [  XmlElement( ElementName = "Msgvar"   )]
      public string gxTpr_Msgvar
      {
         get {
            return gxTv_SdtLogHoursPanel_Level_DetailSdt_Msgvar ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogHoursPanel_Level_DetailSdt_Msgvar = value;
            SetDirty("Msgvar");
         }

      }

      [  SoapElement( ElementName = "Gxdynprop" )]
      [  XmlElement( ElementName = "Gxdynprop"   )]
      public string gxTpr_Gxdynprop
      {
         get {
            return gxTv_SdtLogHoursPanel_Level_DetailSdt_Gxdynprop ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogHoursPanel_Level_DetailSdt_Gxdynprop = value;
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
         gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdate = DateTime.MinValue;
         gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdescription = "";
         gxTv_SdtLogHoursPanel_Level_DetailSdt_Today = DateTime.MinValue;
         gxTv_SdtLogHoursPanel_Level_DetailSdt_Msgvar = "";
         gxTv_SdtLogHoursPanel_Level_DetailSdt_Gxdynprop = "";
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
      protected short gxTv_SdtLogHoursPanel_Level_DetailSdt_Projectid ;
      protected short gxTv_SdtLogHoursPanel_Level_DetailSdt_Loghour ;
      protected short gxTv_SdtLogHoursPanel_Level_DetailSdt_Logminute ;
      protected long gxTv_SdtLogHoursPanel_Level_DetailSdt_Employeeid ;
      protected string gxTv_SdtLogHoursPanel_Level_DetailSdt_Msgvar ;
      protected string gxTv_SdtLogHoursPanel_Level_DetailSdt_Gxdynprop ;
      protected string sDateCnv ;
      protected string sNumToPad ;
      protected DateTime gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdate ;
      protected DateTime gxTv_SdtLogHoursPanel_Level_DetailSdt_Today ;
      protected string gxTv_SdtLogHoursPanel_Level_DetailSdt_Workhourlogdescription ;
   }

   [DataContract(Name = @"LogHoursPanel_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtLogHoursPanel_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtLogHoursPanel_Level_DetailSdt>
   {
      public SdtLogHoursPanel_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtLogHoursPanel_Level_DetailSdt_RESTInterface( SdtLogHoursPanel_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Workhourlogdate" , Order = 0 )]
      public string gxTpr_Workhourlogdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Workhourlogdate) ;
         }

         set {
            sdt.gxTpr_Workhourlogdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "Projectid" , Order = 1 )]
      public Nullable<short> gxTpr_Projectid
      {
         get {
            return sdt.gxTpr_Projectid ;
         }

         set {
            sdt.gxTpr_Projectid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Loghour" , Order = 2 )]
      public Nullable<short> gxTpr_Loghour
      {
         get {
            return sdt.gxTpr_Loghour ;
         }

         set {
            sdt.gxTpr_Loghour = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Logminute" , Order = 3 )]
      public Nullable<short> gxTpr_Logminute
      {
         get {
            return sdt.gxTpr_Logminute ;
         }

         set {
            sdt.gxTpr_Logminute = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Workhourlogdescription" , Order = 4 )]
      public string gxTpr_Workhourlogdescription
      {
         get {
            return sdt.gxTpr_Workhourlogdescription ;
         }

         set {
            sdt.gxTpr_Workhourlogdescription = value;
         }

      }

      [DataMember( Name = "Employeeid" , Order = 5 )]
      public string gxTpr_Employeeid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Employeeid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Employeeid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "Today" , Order = 6 )]
      public string gxTpr_Today
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Today) ;
         }

         set {
            sdt.gxTpr_Today = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "Msgvar" , Order = 7 )]
      public string gxTpr_Msgvar
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Msgvar) ;
         }

         set {
            sdt.gxTpr_Msgvar = value;
         }

      }

      [DataMember( Name = "Gxdynprop" , Order = 8 )]
      public string gxTpr_Gxdynprop
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gxdynprop) ;
         }

         set {
            sdt.gxTpr_Gxdynprop = value;
         }

      }

      public SdtLogHoursPanel_Level_DetailSdt sdt
      {
         get {
            return (SdtLogHoursPanel_Level_DetailSdt)Sdt ;
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
            sdt = new SdtLogHoursPanel_Level_DetailSdt() ;
         }
      }

   }

}
