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
   [XmlRoot(ElementName = "UpdateWorkHourLog_Level_DetailSdt" )]
   [XmlType(TypeName =  "UpdateWorkHourLog_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtUpdateWorkHourLog_Level_DetailSdt : GxUserType
   {
      public SdtUpdateWorkHourLog_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdate = DateTime.MinValue;
         gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdescription = "";
         gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Today = DateTime.MinValue;
         gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Msgvar = "";
      }

      public SdtUpdateWorkHourLog_Level_DetailSdt( IGxContext context )
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
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("Worklogdate", sDateCnv, false, false);
         AddObjectProperty("Worklogproject", gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogproject, false, false);
         AddObjectProperty("Workloghour", gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Workloghour, false, false);
         AddObjectProperty("Worklogminute", gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogminute, false, false);
         AddObjectProperty("Worklogdescription", gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdescription, false, false);
         if ( gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Workhourlog != null )
         {
            AddObjectProperty("Workhourlog", gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Workhourlog, false, false);
         }
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Today)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Today)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Today)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("Today", sDateCnv, false, false);
         AddObjectProperty("Msgvar", gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Msgvar, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Worklogdate" )]
      [  XmlElement( ElementName = "Worklogdate"  , IsNullable=true )]
      public string gxTpr_Worklogdate_Nullable
      {
         get {
            if ( gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdate = DateTime.MinValue;
            else
               gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Worklogdate
      {
         get {
            return gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdate = value;
            SetDirty("Worklogdate");
         }

      }

      [  SoapElement( ElementName = "Worklogproject" )]
      [  XmlElement( ElementName = "Worklogproject"   )]
      public short gxTpr_Worklogproject
      {
         get {
            return gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogproject ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogproject = value;
            SetDirty("Worklogproject");
         }

      }

      [  SoapElement( ElementName = "Workloghour" )]
      [  XmlElement( ElementName = "Workloghour"   )]
      public short gxTpr_Workloghour
      {
         get {
            return gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Workloghour ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Workloghour = value;
            SetDirty("Workloghour");
         }

      }

      [  SoapElement( ElementName = "Worklogminute" )]
      [  XmlElement( ElementName = "Worklogminute"   )]
      public short gxTpr_Worklogminute
      {
         get {
            return gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogminute ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogminute = value;
            SetDirty("Worklogminute");
         }

      }

      [  SoapElement( ElementName = "Worklogdescription" )]
      [  XmlElement( ElementName = "Worklogdescription"   )]
      public string gxTpr_Worklogdescription
      {
         get {
            return gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdescription = value;
            SetDirty("Worklogdescription");
         }

      }

      [  SoapElement( ElementName = "Workhourlog" )]
      [  XmlElement( ElementName = "Workhourlog"   )]
      public SdtWorkHourLog gxTpr_Workhourlog
      {
         get {
            if ( gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Workhourlog == null )
            {
               gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Workhourlog = new SdtWorkHourLog(context);
            }
            sdtIsNull = 0;
            return gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Workhourlog ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Workhourlog = value;
            SetDirty("Workhourlog");
         }

      }

      public void gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Workhourlog_SetNull( )
      {
         gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Workhourlog = null;
         return  ;
      }

      public bool gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Workhourlog_IsNull( )
      {
         if ( gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Workhourlog == null )
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
            if ( gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Today == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Today).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Today = DateTime.MinValue;
            else
               gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Today = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Today
      {
         get {
            return gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Today ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Today = value;
            SetDirty("Today");
         }

      }

      [  SoapElement( ElementName = "Msgvar" )]
      [  XmlElement( ElementName = "Msgvar"   )]
      public string gxTpr_Msgvar
      {
         get {
            return gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Msgvar ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Msgvar = value;
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
         gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdate = DateTime.MinValue;
         gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdescription = "";
         gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Today = DateTime.MinValue;
         gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Msgvar = "";
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
      protected short gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogproject ;
      protected short gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Workloghour ;
      protected short gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogminute ;
      protected string gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Msgvar ;
      protected string sDateCnv ;
      protected string sNumToPad ;
      protected DateTime gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdate ;
      protected DateTime gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Today ;
      protected string gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Worklogdescription ;
      protected SdtWorkHourLog gxTv_SdtUpdateWorkHourLog_Level_DetailSdt_Workhourlog=null ;
   }

   [DataContract(Name = @"UpdateWorkHourLog_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtUpdateWorkHourLog_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtUpdateWorkHourLog_Level_DetailSdt>
   {
      public SdtUpdateWorkHourLog_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtUpdateWorkHourLog_Level_DetailSdt_RESTInterface( SdtUpdateWorkHourLog_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Worklogdate" , Order = 0 )]
      public string gxTpr_Worklogdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Worklogdate) ;
         }

         set {
            sdt.gxTpr_Worklogdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "Worklogproject" , Order = 1 )]
      public Nullable<short> gxTpr_Worklogproject
      {
         get {
            return sdt.gxTpr_Worklogproject ;
         }

         set {
            sdt.gxTpr_Worklogproject = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Workloghour" , Order = 2 )]
      public Nullable<short> gxTpr_Workloghour
      {
         get {
            return sdt.gxTpr_Workloghour ;
         }

         set {
            sdt.gxTpr_Workloghour = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Worklogminute" , Order = 3 )]
      public Nullable<short> gxTpr_Worklogminute
      {
         get {
            return sdt.gxTpr_Worklogminute ;
         }

         set {
            sdt.gxTpr_Worklogminute = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Worklogdescription" , Order = 4 )]
      public string gxTpr_Worklogdescription
      {
         get {
            return sdt.gxTpr_Worklogdescription ;
         }

         set {
            sdt.gxTpr_Worklogdescription = value;
         }

      }

      [DataMember( Name = "Workhourlog" , Order = 5 )]
      public SdtWorkHourLog_RESTInterface gxTpr_Workhourlog
      {
         get {
            return new SdtWorkHourLog_RESTInterface(sdt.gxTpr_Workhourlog) ;
         }

         set {
            sdt.gxTpr_Workhourlog = value.sdt;
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

      public SdtUpdateWorkHourLog_Level_DetailSdt sdt
      {
         get {
            return (SdtUpdateWorkHourLog_Level_DetailSdt)Sdt ;
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
            sdt = new SdtUpdateWorkHourLog_Level_DetailSdt() ;
         }
      }

   }

}
