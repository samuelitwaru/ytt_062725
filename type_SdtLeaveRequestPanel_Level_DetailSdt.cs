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
   [XmlRoot(ElementName = "LeaveRequestPanel_Level_DetailSdt" )]
   [XmlType(TypeName =  "LeaveRequestPanel_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtLeaveRequestPanel_Level_DetailSdt : GxUserType
   {
      public SdtLeaveRequestPanel_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequeststartdate = DateTime.MinValue;
         gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestenddate = DateTime.MinValue;
         gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequesthalfday = "";
         gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestdescription = "";
         gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Today = DateTime.MinValue;
         gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Msgvar = "";
         gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Gxdynprop = "";
         gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Gxdesc_leavetypeid = "";
      }

      public SdtLeaveRequestPanel_Level_DetailSdt( IGxContext context )
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
         AddObjectProperty("Leavetypeid", gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leavetypeid, false, false);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequeststartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequeststartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequeststartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("Leaverequeststartdate", sDateCnv, false, false);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestenddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestenddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestenddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("Leaverequestenddate", sDateCnv, false, false);
         AddObjectProperty("Leaverequesthalfday", gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequesthalfday, false, false);
         AddObjectProperty("Leaverequestduration", gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestduration, false, false);
         AddObjectProperty("Leaverequestdescription", gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestdescription, false, false);
         AddObjectProperty("Employeeid", gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Employeeid, false, false);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Today)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Today)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Today)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("Today", sDateCnv, false, false);
         AddObjectProperty("Employyeeavailablevacationdays", gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Employyeeavailablevacationdays, false, false);
         AddObjectProperty("Msgvar", gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Msgvar, false, false);
         AddObjectProperty("Gxdynprop", gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Gxdynprop, false, false);
         AddObjectProperty("Gxdesc_leavetypeid", gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Gxdesc_leavetypeid, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Leavetypeid" )]
      [  XmlElement( ElementName = "Leavetypeid"   )]
      public long gxTpr_Leavetypeid
      {
         get {
            return gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leavetypeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leavetypeid = value;
            SetDirty("Leavetypeid");
         }

      }

      [  SoapElement( ElementName = "Leaverequeststartdate" )]
      [  XmlElement( ElementName = "Leaverequeststartdate"  , IsNullable=true )]
      public string gxTpr_Leaverequeststartdate_Nullable
      {
         get {
            if ( gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequeststartdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequeststartdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequeststartdate = DateTime.MinValue;
            else
               gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequeststartdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaverequeststartdate
      {
         get {
            return gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequeststartdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequeststartdate = value;
            SetDirty("Leaverequeststartdate");
         }

      }

      [  SoapElement( ElementName = "Leaverequestenddate" )]
      [  XmlElement( ElementName = "Leaverequestenddate"  , IsNullable=true )]
      public string gxTpr_Leaverequestenddate_Nullable
      {
         get {
            if ( gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestenddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestenddate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestenddate = DateTime.MinValue;
            else
               gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestenddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaverequestenddate
      {
         get {
            return gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestenddate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestenddate = value;
            SetDirty("Leaverequestenddate");
         }

      }

      [  SoapElement( ElementName = "Leaverequesthalfday" )]
      [  XmlElement( ElementName = "Leaverequesthalfday"   )]
      public string gxTpr_Leaverequesthalfday
      {
         get {
            return gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequesthalfday ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequesthalfday = value;
            SetDirty("Leaverequesthalfday");
         }

      }

      [  SoapElement( ElementName = "Leaverequestduration" )]
      [  XmlElement( ElementName = "Leaverequestduration"   )]
      public decimal gxTpr_Leaverequestduration
      {
         get {
            return gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestduration ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestduration = value;
            SetDirty("Leaverequestduration");
         }

      }

      [  SoapElement( ElementName = "Leaverequestdescription" )]
      [  XmlElement( ElementName = "Leaverequestdescription"   )]
      public string gxTpr_Leaverequestdescription
      {
         get {
            return gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestdescription = value;
            SetDirty("Leaverequestdescription");
         }

      }

      [  SoapElement( ElementName = "Employeeid" )]
      [  XmlElement( ElementName = "Employeeid"   )]
      public long gxTpr_Employeeid
      {
         get {
            return gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Employeeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Employeeid = value;
            SetDirty("Employeeid");
         }

      }

      [  SoapElement( ElementName = "Today" )]
      [  XmlElement( ElementName = "Today"  , IsNullable=true )]
      public string gxTpr_Today_Nullable
      {
         get {
            if ( gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Today == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Today).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Today = DateTime.MinValue;
            else
               gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Today = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Today
      {
         get {
            return gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Today ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Today = value;
            SetDirty("Today");
         }

      }

      [  SoapElement( ElementName = "Employyeeavailablevacationdays" )]
      [  XmlElement( ElementName = "Employyeeavailablevacationdays"   )]
      public short gxTpr_Employyeeavailablevacationdays
      {
         get {
            return gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Employyeeavailablevacationdays ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Employyeeavailablevacationdays = value;
            SetDirty("Employyeeavailablevacationdays");
         }

      }

      [  SoapElement( ElementName = "Msgvar" )]
      [  XmlElement( ElementName = "Msgvar"   )]
      public string gxTpr_Msgvar
      {
         get {
            return gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Msgvar ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Msgvar = value;
            SetDirty("Msgvar");
         }

      }

      [  SoapElement( ElementName = "Gxdynprop" )]
      [  XmlElement( ElementName = "Gxdynprop"   )]
      public string gxTpr_Gxdynprop
      {
         get {
            return gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Gxdynprop ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Gxdynprop = value;
            SetDirty("Gxdynprop");
         }

      }

      [  SoapElement( ElementName = "Gxdesc_leavetypeid" )]
      [  XmlElement( ElementName = "Gxdesc_leavetypeid"   )]
      public string gxTpr_Gxdesc_leavetypeid
      {
         get {
            return gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Gxdesc_leavetypeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Gxdesc_leavetypeid = value;
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
         gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequeststartdate = DateTime.MinValue;
         gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestenddate = DateTime.MinValue;
         gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequesthalfday = "";
         gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestdescription = "";
         gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Today = DateTime.MinValue;
         gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Msgvar = "";
         gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Gxdynprop = "";
         gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Gxdesc_leavetypeid = "";
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
      protected short gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Employyeeavailablevacationdays ;
      protected long gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leavetypeid ;
      protected long gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Employeeid ;
      protected decimal gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestduration ;
      protected string gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequesthalfday ;
      protected string gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Msgvar ;
      protected string gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Gxdynprop ;
      protected string sDateCnv ;
      protected string sNumToPad ;
      protected DateTime gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequeststartdate ;
      protected DateTime gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestenddate ;
      protected DateTime gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Today ;
      protected string gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Leaverequestdescription ;
      protected string gxTv_SdtLeaveRequestPanel_Level_DetailSdt_Gxdesc_leavetypeid ;
   }

   [DataContract(Name = @"LeaveRequestPanel_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtLeaveRequestPanel_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtLeaveRequestPanel_Level_DetailSdt>
   {
      public SdtLeaveRequestPanel_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtLeaveRequestPanel_Level_DetailSdt_RESTInterface( SdtLeaveRequestPanel_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Leavetypeid" , Order = 0 )]
      public string gxTpr_Leavetypeid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Leavetypeid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "Leaverequeststartdate" , Order = 1 )]
      public string gxTpr_Leaverequeststartdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Leaverequeststartdate) ;
         }

         set {
            sdt.gxTpr_Leaverequeststartdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "Leaverequestenddate" , Order = 2 )]
      public string gxTpr_Leaverequestenddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Leaverequestenddate) ;
         }

         set {
            sdt.gxTpr_Leaverequestenddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "Leaverequesthalfday" , Order = 3 )]
      public string gxTpr_Leaverequesthalfday
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Leaverequesthalfday) ;
         }

         set {
            sdt.gxTpr_Leaverequesthalfday = value;
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

      [DataMember( Name = "Employeeid" , Order = 6 )]
      public string gxTpr_Employeeid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Employeeid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Employeeid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "Today" , Order = 7 )]
      public string gxTpr_Today
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Today) ;
         }

         set {
            sdt.gxTpr_Today = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "Employyeeavailablevacationdays" , Order = 8 )]
      public Nullable<short> gxTpr_Employyeeavailablevacationdays
      {
         get {
            return sdt.gxTpr_Employyeeavailablevacationdays ;
         }

         set {
            sdt.gxTpr_Employyeeavailablevacationdays = (short)(value.HasValue ? value.Value : 0);
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

      public SdtLeaveRequestPanel_Level_DetailSdt sdt
      {
         get {
            return (SdtLeaveRequestPanel_Level_DetailSdt)Sdt ;
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
            sdt = new SdtLeaveRequestPanel_Level_DetailSdt() ;
         }
      }

   }

}
