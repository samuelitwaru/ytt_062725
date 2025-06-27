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
   [XmlRoot(ElementName = "Employee.VacationSet" )]
   [XmlType(TypeName =  "Employee.VacationSet" , Namespace = "YTT_version4" )]
   [Serializable]
   public class SdtEmployee_VacationSet : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtEmployee_VacationSet( )
      {
      }

      public SdtEmployee_VacationSet( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
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

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"VacationSetDate", typeof(DateTime)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "VacationSet");
         metadata.Set("BT", "EmployeeVacationSet");
         metadata.Set("PK", "[ \"VacationSetDate\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"EmployeeId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Vacationsetdate_Z_Nullable");
         state.Add("gxTpr_Vacationsetdays_Z");
         state.Add("gxTpr_Vacationsetdescription_Z");
         state.Add("gxTpr_Vacationsetdescription_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEmployee_VacationSet sdt;
         sdt = (SdtEmployee_VacationSet)(source);
         gxTv_SdtEmployee_VacationSet_Vacationsetdate = sdt.gxTv_SdtEmployee_VacationSet_Vacationsetdate ;
         gxTv_SdtEmployee_VacationSet_Vacationsetdays = sdt.gxTv_SdtEmployee_VacationSet_Vacationsetdays ;
         gxTv_SdtEmployee_VacationSet_Vacationsetdescription = sdt.gxTv_SdtEmployee_VacationSet_Vacationsetdescription ;
         gxTv_SdtEmployee_VacationSet_Mode = sdt.gxTv_SdtEmployee_VacationSet_Mode ;
         gxTv_SdtEmployee_VacationSet_Modified = sdt.gxTv_SdtEmployee_VacationSet_Modified ;
         gxTv_SdtEmployee_VacationSet_Initialized = sdt.gxTv_SdtEmployee_VacationSet_Initialized ;
         gxTv_SdtEmployee_VacationSet_Vacationsetdate_Z = sdt.gxTv_SdtEmployee_VacationSet_Vacationsetdate_Z ;
         gxTv_SdtEmployee_VacationSet_Vacationsetdays_Z = sdt.gxTv_SdtEmployee_VacationSet_Vacationsetdays_Z ;
         gxTv_SdtEmployee_VacationSet_Vacationsetdescription_Z = sdt.gxTv_SdtEmployee_VacationSet_Vacationsetdescription_Z ;
         gxTv_SdtEmployee_VacationSet_Vacationsetdescription_N = sdt.gxTv_SdtEmployee_VacationSet_Vacationsetdescription_N ;
         return  ;
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
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEmployee_VacationSet_Vacationsetdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEmployee_VacationSet_Vacationsetdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEmployee_VacationSet_Vacationsetdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("VacationSetDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("VacationSetDays", gxTv_SdtEmployee_VacationSet_Vacationsetdays, false, includeNonInitialized);
         AddObjectProperty("VacationSetDescription", gxTv_SdtEmployee_VacationSet_Vacationsetdescription, false, includeNonInitialized);
         AddObjectProperty("VacationSetDescription_N", gxTv_SdtEmployee_VacationSet_Vacationsetdescription_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEmployee_VacationSet_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtEmployee_VacationSet_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEmployee_VacationSet_Initialized, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEmployee_VacationSet_Vacationsetdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEmployee_VacationSet_Vacationsetdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEmployee_VacationSet_Vacationsetdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("VacationSetDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("VacationSetDays_Z", gxTv_SdtEmployee_VacationSet_Vacationsetdays_Z, false, includeNonInitialized);
            AddObjectProperty("VacationSetDescription_Z", gxTv_SdtEmployee_VacationSet_Vacationsetdescription_Z, false, includeNonInitialized);
            AddObjectProperty("VacationSetDescription_N", gxTv_SdtEmployee_VacationSet_Vacationsetdescription_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEmployee_VacationSet sdt )
      {
         if ( sdt.IsDirty("VacationSetDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_VacationSet_Vacationsetdate = sdt.gxTv_SdtEmployee_VacationSet_Vacationsetdate ;
         }
         if ( sdt.IsDirty("VacationSetDays") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_VacationSet_Vacationsetdays = sdt.gxTv_SdtEmployee_VacationSet_Vacationsetdays ;
         }
         if ( sdt.IsDirty("VacationSetDescription") )
         {
            gxTv_SdtEmployee_VacationSet_Vacationsetdescription_N = (short)(sdt.gxTv_SdtEmployee_VacationSet_Vacationsetdescription_N);
            sdtIsNull = 0;
            gxTv_SdtEmployee_VacationSet_Vacationsetdescription = sdt.gxTv_SdtEmployee_VacationSet_Vacationsetdescription ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "VacationSetDate" )]
      [  XmlElement( ElementName = "VacationSetDate"  , IsNullable=true )]
      public string gxTpr_Vacationsetdate_Nullable
      {
         get {
            if ( gxTv_SdtEmployee_VacationSet_Vacationsetdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtEmployee_VacationSet_Vacationsetdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtEmployee_VacationSet_Vacationsetdate = DateTime.MinValue;
            else
               gxTv_SdtEmployee_VacationSet_Vacationsetdate = DateTime.Parse( value);
            gxTv_SdtEmployee_VacationSet_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vacationsetdate
      {
         get {
            return gxTv_SdtEmployee_VacationSet_Vacationsetdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_VacationSet_Vacationsetdate = value;
            gxTv_SdtEmployee_VacationSet_Modified = 1;
            SetDirty("Vacationsetdate");
         }

      }

      [  SoapElement( ElementName = "VacationSetDays" )]
      [  XmlElement( ElementName = "VacationSetDays"   )]
      public decimal gxTpr_Vacationsetdays
      {
         get {
            return gxTv_SdtEmployee_VacationSet_Vacationsetdays ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_VacationSet_Vacationsetdays = value;
            gxTv_SdtEmployee_VacationSet_Modified = 1;
            SetDirty("Vacationsetdays");
         }

      }

      [  SoapElement( ElementName = "VacationSetDescription" )]
      [  XmlElement( ElementName = "VacationSetDescription"   )]
      public string gxTpr_Vacationsetdescription
      {
         get {
            return gxTv_SdtEmployee_VacationSet_Vacationsetdescription ;
         }

         set {
            gxTv_SdtEmployee_VacationSet_Vacationsetdescription_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmployee_VacationSet_Vacationsetdescription = value;
            gxTv_SdtEmployee_VacationSet_Modified = 1;
            SetDirty("Vacationsetdescription");
         }

      }

      public void gxTv_SdtEmployee_VacationSet_Vacationsetdescription_SetNull( )
      {
         gxTv_SdtEmployee_VacationSet_Vacationsetdescription_N = 1;
         gxTv_SdtEmployee_VacationSet_Vacationsetdescription = "";
         SetDirty("Vacationsetdescription");
         return  ;
      }

      public bool gxTv_SdtEmployee_VacationSet_Vacationsetdescription_IsNull( )
      {
         return (gxTv_SdtEmployee_VacationSet_Vacationsetdescription_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEmployee_VacationSet_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_VacationSet_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEmployee_VacationSet_Mode_SetNull( )
      {
         gxTv_SdtEmployee_VacationSet_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEmployee_VacationSet_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtEmployee_VacationSet_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_VacationSet_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtEmployee_VacationSet_Modified_SetNull( )
      {
         gxTv_SdtEmployee_VacationSet_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtEmployee_VacationSet_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEmployee_VacationSet_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_VacationSet_Initialized = value;
            gxTv_SdtEmployee_VacationSet_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEmployee_VacationSet_Initialized_SetNull( )
      {
         gxTv_SdtEmployee_VacationSet_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEmployee_VacationSet_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VacationSetDate_Z" )]
      [  XmlElement( ElementName = "VacationSetDate_Z"  , IsNullable=true )]
      public string gxTpr_Vacationsetdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtEmployee_VacationSet_Vacationsetdate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtEmployee_VacationSet_Vacationsetdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtEmployee_VacationSet_Vacationsetdate_Z = DateTime.MinValue;
            else
               gxTv_SdtEmployee_VacationSet_Vacationsetdate_Z = DateTime.Parse( value);
            gxTv_SdtEmployee_VacationSet_Modified = 1;
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vacationsetdate_Z
      {
         get {
            return gxTv_SdtEmployee_VacationSet_Vacationsetdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_VacationSet_Vacationsetdate_Z = value;
            gxTv_SdtEmployee_VacationSet_Modified = 1;
            SetDirty("Vacationsetdate_Z");
         }

      }

      public void gxTv_SdtEmployee_VacationSet_Vacationsetdate_Z_SetNull( )
      {
         gxTv_SdtEmployee_VacationSet_Vacationsetdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Vacationsetdate_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_VacationSet_Vacationsetdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VacationSetDays_Z" )]
      [  XmlElement( ElementName = "VacationSetDays_Z"   )]
      public decimal gxTpr_Vacationsetdays_Z
      {
         get {
            return gxTv_SdtEmployee_VacationSet_Vacationsetdays_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_VacationSet_Vacationsetdays_Z = value;
            gxTv_SdtEmployee_VacationSet_Modified = 1;
            SetDirty("Vacationsetdays_Z");
         }

      }

      public void gxTv_SdtEmployee_VacationSet_Vacationsetdays_Z_SetNull( )
      {
         gxTv_SdtEmployee_VacationSet_Vacationsetdays_Z = 0;
         SetDirty("Vacationsetdays_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_VacationSet_Vacationsetdays_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VacationSetDescription_Z" )]
      [  XmlElement( ElementName = "VacationSetDescription_Z"   )]
      public string gxTpr_Vacationsetdescription_Z
      {
         get {
            return gxTv_SdtEmployee_VacationSet_Vacationsetdescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_VacationSet_Vacationsetdescription_Z = value;
            gxTv_SdtEmployee_VacationSet_Modified = 1;
            SetDirty("Vacationsetdescription_Z");
         }

      }

      public void gxTv_SdtEmployee_VacationSet_Vacationsetdescription_Z_SetNull( )
      {
         gxTv_SdtEmployee_VacationSet_Vacationsetdescription_Z = "";
         SetDirty("Vacationsetdescription_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_VacationSet_Vacationsetdescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VacationSetDescription_N" )]
      [  XmlElement( ElementName = "VacationSetDescription_N"   )]
      public short gxTpr_Vacationsetdescription_N
      {
         get {
            return gxTv_SdtEmployee_VacationSet_Vacationsetdescription_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_VacationSet_Vacationsetdescription_N = value;
            gxTv_SdtEmployee_VacationSet_Modified = 1;
            SetDirty("Vacationsetdescription_N");
         }

      }

      public void gxTv_SdtEmployee_VacationSet_Vacationsetdescription_N_SetNull( )
      {
         gxTv_SdtEmployee_VacationSet_Vacationsetdescription_N = 0;
         SetDirty("Vacationsetdescription_N");
         return  ;
      }

      public bool gxTv_SdtEmployee_VacationSet_Vacationsetdescription_N_IsNull( )
      {
         return false ;
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
         gxTv_SdtEmployee_VacationSet_Vacationsetdate = DateTime.MinValue;
         sdtIsNull = 1;
         gxTv_SdtEmployee_VacationSet_Vacationsetdescription = "";
         gxTv_SdtEmployee_VacationSet_Mode = "";
         gxTv_SdtEmployee_VacationSet_Vacationsetdate_Z = DateTime.MinValue;
         gxTv_SdtEmployee_VacationSet_Vacationsetdescription_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtEmployee_VacationSet_Modified ;
      private short gxTv_SdtEmployee_VacationSet_Initialized ;
      private short gxTv_SdtEmployee_VacationSet_Vacationsetdescription_N ;
      private decimal gxTv_SdtEmployee_VacationSet_Vacationsetdays ;
      private decimal gxTv_SdtEmployee_VacationSet_Vacationsetdays_Z ;
      private string gxTv_SdtEmployee_VacationSet_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtEmployee_VacationSet_Vacationsetdate ;
      private DateTime gxTv_SdtEmployee_VacationSet_Vacationsetdate_Z ;
      private string gxTv_SdtEmployee_VacationSet_Vacationsetdescription ;
      private string gxTv_SdtEmployee_VacationSet_Vacationsetdescription_Z ;
   }

   [DataContract(Name = @"Employee.VacationSet", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtEmployee_VacationSet_RESTInterface : GxGenericCollectionItem<SdtEmployee_VacationSet>
   {
      public SdtEmployee_VacationSet_RESTInterface( ) : base()
      {
      }

      public SdtEmployee_VacationSet_RESTInterface( SdtEmployee_VacationSet psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "VacationSetDate" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Vacationsetdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Vacationsetdate) ;
         }

         set {
            sdt.gxTpr_Vacationsetdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "VacationSetDays" , Order = 1 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Vacationsetdays
      {
         get {
            return sdt.gxTpr_Vacationsetdays ;
         }

         set {
            sdt.gxTpr_Vacationsetdays = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "VacationSetDescription" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Vacationsetdescription
      {
         get {
            return sdt.gxTpr_Vacationsetdescription ;
         }

         set {
            sdt.gxTpr_Vacationsetdescription = value;
         }

      }

      public SdtEmployee_VacationSet sdt
      {
         get {
            return (SdtEmployee_VacationSet)Sdt ;
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
            sdt = new SdtEmployee_VacationSet() ;
         }
      }

   }

   [DataContract(Name = @"Employee.VacationSet", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtEmployee_VacationSet_RESTLInterface : GxGenericCollectionItem<SdtEmployee_VacationSet>
   {
      public SdtEmployee_VacationSet_RESTLInterface( ) : base()
      {
      }

      public SdtEmployee_VacationSet_RESTLInterface( SdtEmployee_VacationSet psdt ) : base(psdt)
      {
      }

      public SdtEmployee_VacationSet sdt
      {
         get {
            return (SdtEmployee_VacationSet)Sdt ;
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
            sdt = new SdtEmployee_VacationSet() ;
         }
      }

   }

}
