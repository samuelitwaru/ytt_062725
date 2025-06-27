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
   [XmlRoot(ElementName = "WorkLogsGridCollectionPanel_Level_DetailSdt" )]
   [XmlType(TypeName =  "WorkLogsGridCollectionPanel_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtWorkLogsGridCollectionPanel_Level_DetailSdt : GxUserType
   {
      public SdtWorkLogsGridCollectionPanel_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Logdate = DateTime.MinValue;
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Datetoday = DateTime.MinValue;
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Lateupdatemsgvar = "";
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Latedeletemsgvar = "";
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Msgvar = "";
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdynprop = "";
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdyncall = "";
      }

      public SdtWorkLogsGridCollectionPanel_Level_DetailSdt( IGxContext context )
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
         if ( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts != null )
         {
            AddObjectProperty("Worklogssdts", gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts, false, false);
         }
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Logdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Logdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Logdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("Logdate", sDateCnv, false, false);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Datetoday)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Datetoday)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Datetoday)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("Datetoday", sDateCnv, false, false);
         AddObjectProperty("Lateupdatemsgvar", gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Lateupdatemsgvar, false, false);
         AddObjectProperty("Latedeletemsgvar", gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Latedeletemsgvar, false, false);
         AddObjectProperty("Msgvar", gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Msgvar, false, false);
         AddObjectProperty("Gxdynprop", gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdynprop, false, false);
         AddObjectProperty("Gxdyncall", gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdyncall, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Worklogssdts" )]
      [  XmlArray( ElementName = "Worklogssdts"  )]
      [  XmlArrayItemAttribute( ElementName= "WorkLogsSDT"  , IsNullable=false)]
      public GXBaseCollection<SdtWorkLogsSDT> gxTpr_Worklogssdts_GXBaseCollection
      {
         get {
            if ( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts == null )
            {
               gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts = new GXBaseCollection<SdtWorkLogsSDT>( context, "WorkLogsSDT", "");
            }
            return gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts ;
         }

         set {
            if ( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts == null )
            {
               gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts = new GXBaseCollection<SdtWorkLogsSDT>( context, "WorkLogsSDT", "");
            }
            sdtIsNull = 0;
            gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts = value;
         }

      }

      [XmlIgnore]
      public GXBaseCollection<SdtWorkLogsSDT> gxTpr_Worklogssdts
      {
         get {
            if ( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts == null )
            {
               gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts = new GXBaseCollection<SdtWorkLogsSDT>( context, "WorkLogsSDT", "");
            }
            sdtIsNull = 0;
            return gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts = value;
            SetDirty("Worklogssdts");
         }

      }

      public void gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts_SetNull( )
      {
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts = null;
         return  ;
      }

      public bool gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts_IsNull( )
      {
         if ( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Logdate" )]
      [  XmlElement( ElementName = "Logdate"  , IsNullable=true )]
      public string gxTpr_Logdate_Nullable
      {
         get {
            if ( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Logdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Logdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Logdate = DateTime.MinValue;
            else
               gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Logdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Logdate
      {
         get {
            return gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Logdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Logdate = value;
            SetDirty("Logdate");
         }

      }

      [  SoapElement( ElementName = "Datetoday" )]
      [  XmlElement( ElementName = "Datetoday"  , IsNullable=true )]
      public string gxTpr_Datetoday_Nullable
      {
         get {
            if ( gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Datetoday == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Datetoday).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Datetoday = DateTime.MinValue;
            else
               gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Datetoday = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Datetoday
      {
         get {
            return gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Datetoday ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Datetoday = value;
            SetDirty("Datetoday");
         }

      }

      [  SoapElement( ElementName = "Lateupdatemsgvar" )]
      [  XmlElement( ElementName = "Lateupdatemsgvar"   )]
      public string gxTpr_Lateupdatemsgvar
      {
         get {
            return gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Lateupdatemsgvar ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Lateupdatemsgvar = value;
            SetDirty("Lateupdatemsgvar");
         }

      }

      [  SoapElement( ElementName = "Latedeletemsgvar" )]
      [  XmlElement( ElementName = "Latedeletemsgvar"   )]
      public string gxTpr_Latedeletemsgvar
      {
         get {
            return gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Latedeletemsgvar ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Latedeletemsgvar = value;
            SetDirty("Latedeletemsgvar");
         }

      }

      [  SoapElement( ElementName = "Msgvar" )]
      [  XmlElement( ElementName = "Msgvar"   )]
      public string gxTpr_Msgvar
      {
         get {
            return gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Msgvar ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Msgvar = value;
            SetDirty("Msgvar");
         }

      }

      [  SoapElement( ElementName = "Gxdynprop" )]
      [  XmlElement( ElementName = "Gxdynprop"   )]
      public string gxTpr_Gxdynprop
      {
         get {
            return gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdynprop ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdynprop = value;
            SetDirty("Gxdynprop");
         }

      }

      [  SoapElement( ElementName = "Gxdyncall" )]
      [  XmlElement( ElementName = "Gxdyncall"   )]
      public string gxTpr_Gxdyncall
      {
         get {
            return gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdyncall ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdyncall = value;
            SetDirty("Gxdyncall");
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
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Logdate = DateTime.MinValue;
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Datetoday = DateTime.MinValue;
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Lateupdatemsgvar = "";
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Latedeletemsgvar = "";
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Msgvar = "";
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdynprop = "";
         gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdyncall = "";
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
      protected string gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Lateupdatemsgvar ;
      protected string gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Latedeletemsgvar ;
      protected string gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Msgvar ;
      protected string gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdynprop ;
      protected string gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Gxdyncall ;
      protected string sDateCnv ;
      protected string sNumToPad ;
      protected DateTime gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Logdate ;
      protected DateTime gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Datetoday ;
      protected GXBaseCollection<SdtWorkLogsSDT> gxTv_SdtWorkLogsGridCollectionPanel_Level_DetailSdt_Worklogssdts=null ;
   }

   [DataContract(Name = @"WorkLogsGridCollectionPanel_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtWorkLogsGridCollectionPanel_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtWorkLogsGridCollectionPanel_Level_DetailSdt>
   {
      public SdtWorkLogsGridCollectionPanel_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtWorkLogsGridCollectionPanel_Level_DetailSdt_RESTInterface( SdtWorkLogsGridCollectionPanel_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Worklogssdts" , Order = 0 )]
      public GxGenericCollection<SdtWorkLogsSDT_RESTInterface> gxTpr_Worklogssdts
      {
         get {
            return new GxGenericCollection<SdtWorkLogsSDT_RESTInterface>(sdt.gxTpr_Worklogssdts) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Worklogssdts);
         }

      }

      [DataMember( Name = "Logdate" , Order = 1 )]
      public string gxTpr_Logdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Logdate) ;
         }

         set {
            sdt.gxTpr_Logdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "Datetoday" , Order = 2 )]
      public string gxTpr_Datetoday
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Datetoday) ;
         }

         set {
            sdt.gxTpr_Datetoday = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "Lateupdatemsgvar" , Order = 3 )]
      public string gxTpr_Lateupdatemsgvar
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Lateupdatemsgvar) ;
         }

         set {
            sdt.gxTpr_Lateupdatemsgvar = value;
         }

      }

      [DataMember( Name = "Latedeletemsgvar" , Order = 4 )]
      public string gxTpr_Latedeletemsgvar
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Latedeletemsgvar) ;
         }

         set {
            sdt.gxTpr_Latedeletemsgvar = value;
         }

      }

      [DataMember( Name = "Msgvar" , Order = 5 )]
      public string gxTpr_Msgvar
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Msgvar) ;
         }

         set {
            sdt.gxTpr_Msgvar = value;
         }

      }

      [DataMember( Name = "Gxdynprop" , Order = 6 )]
      public string gxTpr_Gxdynprop
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gxdynprop) ;
         }

         set {
            sdt.gxTpr_Gxdynprop = value;
         }

      }

      [DataMember( Name = "Gxdyncall" , Order = 7 )]
      public string gxTpr_Gxdyncall
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gxdyncall) ;
         }

         set {
            sdt.gxTpr_Gxdyncall = value;
         }

      }

      public SdtWorkLogsGridCollectionPanel_Level_DetailSdt sdt
      {
         get {
            return (SdtWorkLogsGridCollectionPanel_Level_DetailSdt)Sdt ;
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
            sdt = new SdtWorkLogsGridCollectionPanel_Level_DetailSdt() ;
         }
      }

   }

}
