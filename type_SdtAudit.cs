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
   [XmlRoot(ElementName = "Audit" )]
   [XmlType(TypeName =  "Audit" , Namespace = "YTT_version4" )]
   [Serializable]
   public class SdtAudit : GxSilentTrnSdt
   {
      public SdtAudit( )
      {
      }

      public SdtAudit( IGxContext context )
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

      public void Load( long AV204AuditId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV204AuditId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AuditId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Audit");
         metadata.Set("BT", "Audit");
         metadata.Set("PK", "[ \"AuditId\" ]");
         metadata.Set("PKAssigned", "[ \"AuditId\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Auditid_Z");
         state.Add("gxTpr_Auditdate_Z_Nullable");
         state.Add("gxTpr_Audittablename_Z");
         state.Add("gxTpr_Auditdescription_Z");
         state.Add("gxTpr_Auditshortdescription_Z");
         state.Add("gxTpr_Auditaction_Z");
         state.Add("gxTpr_Secuserid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtAudit sdt;
         sdt = (SdtAudit)(source);
         gxTv_SdtAudit_Auditid = sdt.gxTv_SdtAudit_Auditid ;
         gxTv_SdtAudit_Auditdate = sdt.gxTv_SdtAudit_Auditdate ;
         gxTv_SdtAudit_Audittablename = sdt.gxTv_SdtAudit_Audittablename ;
         gxTv_SdtAudit_Auditdescription = sdt.gxTv_SdtAudit_Auditdescription ;
         gxTv_SdtAudit_Auditshortdescription = sdt.gxTv_SdtAudit_Auditshortdescription ;
         gxTv_SdtAudit_Auditaction = sdt.gxTv_SdtAudit_Auditaction ;
         gxTv_SdtAudit_Secuserid = sdt.gxTv_SdtAudit_Secuserid ;
         gxTv_SdtAudit_Mode = sdt.gxTv_SdtAudit_Mode ;
         gxTv_SdtAudit_Initialized = sdt.gxTv_SdtAudit_Initialized ;
         gxTv_SdtAudit_Auditid_Z = sdt.gxTv_SdtAudit_Auditid_Z ;
         gxTv_SdtAudit_Auditdate_Z = sdt.gxTv_SdtAudit_Auditdate_Z ;
         gxTv_SdtAudit_Audittablename_Z = sdt.gxTv_SdtAudit_Audittablename_Z ;
         gxTv_SdtAudit_Auditdescription_Z = sdt.gxTv_SdtAudit_Auditdescription_Z ;
         gxTv_SdtAudit_Auditshortdescription_Z = sdt.gxTv_SdtAudit_Auditshortdescription_Z ;
         gxTv_SdtAudit_Auditaction_Z = sdt.gxTv_SdtAudit_Auditaction_Z ;
         gxTv_SdtAudit_Secuserid_Z = sdt.gxTv_SdtAudit_Secuserid_Z ;
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
         AddObjectProperty("AuditId", gxTv_SdtAudit_Auditid, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtAudit_Auditdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtAudit_Auditdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtAudit_Auditdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("AuditDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("AuditTableName", gxTv_SdtAudit_Audittablename, false, includeNonInitialized);
         AddObjectProperty("AuditDescription", gxTv_SdtAudit_Auditdescription, false, includeNonInitialized);
         AddObjectProperty("AuditShortDescription", gxTv_SdtAudit_Auditshortdescription, false, includeNonInitialized);
         AddObjectProperty("AuditAction", gxTv_SdtAudit_Auditaction, false, includeNonInitialized);
         AddObjectProperty("SecUserId", gxTv_SdtAudit_Secuserid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtAudit_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtAudit_Initialized, false, includeNonInitialized);
            AddObjectProperty("AuditId_Z", gxTv_SdtAudit_Auditid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtAudit_Auditdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtAudit_Auditdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtAudit_Auditdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("AuditDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("AuditTableName_Z", gxTv_SdtAudit_Audittablename_Z, false, includeNonInitialized);
            AddObjectProperty("AuditDescription_Z", gxTv_SdtAudit_Auditdescription_Z, false, includeNonInitialized);
            AddObjectProperty("AuditShortDescription_Z", gxTv_SdtAudit_Auditshortdescription_Z, false, includeNonInitialized);
            AddObjectProperty("AuditAction_Z", gxTv_SdtAudit_Auditaction_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserId_Z", gxTv_SdtAudit_Secuserid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtAudit sdt )
      {
         if ( sdt.IsDirty("AuditId") )
         {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditid = sdt.gxTv_SdtAudit_Auditid ;
         }
         if ( sdt.IsDirty("AuditDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditdate = sdt.gxTv_SdtAudit_Auditdate ;
         }
         if ( sdt.IsDirty("AuditTableName") )
         {
            sdtIsNull = 0;
            gxTv_SdtAudit_Audittablename = sdt.gxTv_SdtAudit_Audittablename ;
         }
         if ( sdt.IsDirty("AuditDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditdescription = sdt.gxTv_SdtAudit_Auditdescription ;
         }
         if ( sdt.IsDirty("AuditShortDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditshortdescription = sdt.gxTv_SdtAudit_Auditshortdescription ;
         }
         if ( sdt.IsDirty("AuditAction") )
         {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditaction = sdt.gxTv_SdtAudit_Auditaction ;
         }
         if ( sdt.IsDirty("SecUserId") )
         {
            sdtIsNull = 0;
            gxTv_SdtAudit_Secuserid = sdt.gxTv_SdtAudit_Secuserid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AuditId" )]
      [  XmlElement( ElementName = "AuditId"   )]
      public long gxTpr_Auditid
      {
         get {
            return gxTv_SdtAudit_Auditid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtAudit_Auditid != value )
            {
               gxTv_SdtAudit_Mode = "INS";
               this.gxTv_SdtAudit_Auditid_Z_SetNull( );
               this.gxTv_SdtAudit_Auditdate_Z_SetNull( );
               this.gxTv_SdtAudit_Audittablename_Z_SetNull( );
               this.gxTv_SdtAudit_Auditdescription_Z_SetNull( );
               this.gxTv_SdtAudit_Auditshortdescription_Z_SetNull( );
               this.gxTv_SdtAudit_Auditaction_Z_SetNull( );
               this.gxTv_SdtAudit_Secuserid_Z_SetNull( );
            }
            gxTv_SdtAudit_Auditid = value;
            SetDirty("Auditid");
         }

      }

      [  SoapElement( ElementName = "AuditDate" )]
      [  XmlElement( ElementName = "AuditDate"  , IsNullable=true )]
      public string gxTpr_Auditdate_Nullable
      {
         get {
            if ( gxTv_SdtAudit_Auditdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtAudit_Auditdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtAudit_Auditdate = DateTime.MinValue;
            else
               gxTv_SdtAudit_Auditdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Auditdate
      {
         get {
            return gxTv_SdtAudit_Auditdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditdate = value;
            SetDirty("Auditdate");
         }

      }

      [  SoapElement( ElementName = "AuditTableName" )]
      [  XmlElement( ElementName = "AuditTableName"   )]
      public string gxTpr_Audittablename
      {
         get {
            return gxTv_SdtAudit_Audittablename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Audittablename = value;
            SetDirty("Audittablename");
         }

      }

      [  SoapElement( ElementName = "AuditDescription" )]
      [  XmlElement( ElementName = "AuditDescription"   )]
      public string gxTpr_Auditdescription
      {
         get {
            return gxTv_SdtAudit_Auditdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditdescription = value;
            SetDirty("Auditdescription");
         }

      }

      [  SoapElement( ElementName = "AuditShortDescription" )]
      [  XmlElement( ElementName = "AuditShortDescription"   )]
      public string gxTpr_Auditshortdescription
      {
         get {
            return gxTv_SdtAudit_Auditshortdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditshortdescription = value;
            SetDirty("Auditshortdescription");
         }

      }

      [  SoapElement( ElementName = "AuditAction" )]
      [  XmlElement( ElementName = "AuditAction"   )]
      public string gxTpr_Auditaction
      {
         get {
            return gxTv_SdtAudit_Auditaction ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditaction = value;
            SetDirty("Auditaction");
         }

      }

      [  SoapElement( ElementName = "SecUserId" )]
      [  XmlElement( ElementName = "SecUserId"   )]
      public long gxTpr_Secuserid
      {
         get {
            return gxTv_SdtAudit_Secuserid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Secuserid = value;
            SetDirty("Secuserid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtAudit_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtAudit_Mode_SetNull( )
      {
         gxTv_SdtAudit_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtAudit_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtAudit_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtAudit_Initialized_SetNull( )
      {
         gxTv_SdtAudit_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtAudit_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditId_Z" )]
      [  XmlElement( ElementName = "AuditId_Z"   )]
      public long gxTpr_Auditid_Z
      {
         get {
            return gxTv_SdtAudit_Auditid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditid_Z = value;
            SetDirty("Auditid_Z");
         }

      }

      public void gxTv_SdtAudit_Auditid_Z_SetNull( )
      {
         gxTv_SdtAudit_Auditid_Z = 0;
         SetDirty("Auditid_Z");
         return  ;
      }

      public bool gxTv_SdtAudit_Auditid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditDate_Z" )]
      [  XmlElement( ElementName = "AuditDate_Z"  , IsNullable=true )]
      public string gxTpr_Auditdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtAudit_Auditdate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtAudit_Auditdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtAudit_Auditdate_Z = DateTime.MinValue;
            else
               gxTv_SdtAudit_Auditdate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Auditdate_Z
      {
         get {
            return gxTv_SdtAudit_Auditdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditdate_Z = value;
            SetDirty("Auditdate_Z");
         }

      }

      public void gxTv_SdtAudit_Auditdate_Z_SetNull( )
      {
         gxTv_SdtAudit_Auditdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Auditdate_Z");
         return  ;
      }

      public bool gxTv_SdtAudit_Auditdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditTableName_Z" )]
      [  XmlElement( ElementName = "AuditTableName_Z"   )]
      public string gxTpr_Audittablename_Z
      {
         get {
            return gxTv_SdtAudit_Audittablename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Audittablename_Z = value;
            SetDirty("Audittablename_Z");
         }

      }

      public void gxTv_SdtAudit_Audittablename_Z_SetNull( )
      {
         gxTv_SdtAudit_Audittablename_Z = "";
         SetDirty("Audittablename_Z");
         return  ;
      }

      public bool gxTv_SdtAudit_Audittablename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditDescription_Z" )]
      [  XmlElement( ElementName = "AuditDescription_Z"   )]
      public string gxTpr_Auditdescription_Z
      {
         get {
            return gxTv_SdtAudit_Auditdescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditdescription_Z = value;
            SetDirty("Auditdescription_Z");
         }

      }

      public void gxTv_SdtAudit_Auditdescription_Z_SetNull( )
      {
         gxTv_SdtAudit_Auditdescription_Z = "";
         SetDirty("Auditdescription_Z");
         return  ;
      }

      public bool gxTv_SdtAudit_Auditdescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditShortDescription_Z" )]
      [  XmlElement( ElementName = "AuditShortDescription_Z"   )]
      public string gxTpr_Auditshortdescription_Z
      {
         get {
            return gxTv_SdtAudit_Auditshortdescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditshortdescription_Z = value;
            SetDirty("Auditshortdescription_Z");
         }

      }

      public void gxTv_SdtAudit_Auditshortdescription_Z_SetNull( )
      {
         gxTv_SdtAudit_Auditshortdescription_Z = "";
         SetDirty("Auditshortdescription_Z");
         return  ;
      }

      public bool gxTv_SdtAudit_Auditshortdescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditAction_Z" )]
      [  XmlElement( ElementName = "AuditAction_Z"   )]
      public string gxTpr_Auditaction_Z
      {
         get {
            return gxTv_SdtAudit_Auditaction_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Auditaction_Z = value;
            SetDirty("Auditaction_Z");
         }

      }

      public void gxTv_SdtAudit_Auditaction_Z_SetNull( )
      {
         gxTv_SdtAudit_Auditaction_Z = "";
         SetDirty("Auditaction_Z");
         return  ;
      }

      public bool gxTv_SdtAudit_Auditaction_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_Z" )]
      [  XmlElement( ElementName = "SecUserId_Z"   )]
      public long gxTpr_Secuserid_Z
      {
         get {
            return gxTv_SdtAudit_Secuserid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAudit_Secuserid_Z = value;
            SetDirty("Secuserid_Z");
         }

      }

      public void gxTv_SdtAudit_Secuserid_Z_SetNull( )
      {
         gxTv_SdtAudit_Secuserid_Z = 0;
         SetDirty("Secuserid_Z");
         return  ;
      }

      public bool gxTv_SdtAudit_Secuserid_Z_IsNull( )
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
         sdtIsNull = 1;
         gxTv_SdtAudit_Auditdate = DateTime.MinValue;
         gxTv_SdtAudit_Audittablename = "";
         gxTv_SdtAudit_Auditdescription = "";
         gxTv_SdtAudit_Auditshortdescription = "";
         gxTv_SdtAudit_Auditaction = "";
         gxTv_SdtAudit_Mode = "";
         gxTv_SdtAudit_Auditdate_Z = DateTime.MinValue;
         gxTv_SdtAudit_Audittablename_Z = "";
         gxTv_SdtAudit_Auditdescription_Z = "";
         gxTv_SdtAudit_Auditshortdescription_Z = "";
         gxTv_SdtAudit_Auditaction_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "audit", "GeneXus.Programs.audit_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtAudit_Initialized ;
      private long gxTv_SdtAudit_Auditid ;
      private long gxTv_SdtAudit_Secuserid ;
      private long gxTv_SdtAudit_Auditid_Z ;
      private long gxTv_SdtAudit_Secuserid_Z ;
      private string gxTv_SdtAudit_Audittablename ;
      private string gxTv_SdtAudit_Mode ;
      private string gxTv_SdtAudit_Audittablename_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtAudit_Auditdate ;
      private DateTime gxTv_SdtAudit_Auditdate_Z ;
      private string gxTv_SdtAudit_Auditdescription ;
      private string gxTv_SdtAudit_Auditshortdescription ;
      private string gxTv_SdtAudit_Auditaction ;
      private string gxTv_SdtAudit_Auditdescription_Z ;
      private string gxTv_SdtAudit_Auditshortdescription_Z ;
      private string gxTv_SdtAudit_Auditaction_Z ;
   }

   [DataContract(Name = @"Audit", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtAudit_RESTInterface : GxGenericCollectionItem<SdtAudit>
   {
      public SdtAudit_RESTInterface( ) : base()
      {
      }

      public SdtAudit_RESTInterface( SdtAudit psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AuditId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Auditid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Auditid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Auditid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "AuditDate" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Auditdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Auditdate) ;
         }

         set {
            sdt.gxTpr_Auditdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "AuditTableName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Audittablename
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Audittablename) ;
         }

         set {
            sdt.gxTpr_Audittablename = value;
         }

      }

      [DataMember( Name = "AuditDescription" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Auditdescription
      {
         get {
            return sdt.gxTpr_Auditdescription ;
         }

         set {
            sdt.gxTpr_Auditdescription = value;
         }

      }

      [DataMember( Name = "AuditShortDescription" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Auditshortdescription
      {
         get {
            return sdt.gxTpr_Auditshortdescription ;
         }

         set {
            sdt.gxTpr_Auditshortdescription = value;
         }

      }

      [DataMember( Name = "AuditAction" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Auditaction
      {
         get {
            return sdt.gxTpr_Auditaction ;
         }

         set {
            sdt.gxTpr_Auditaction = value;
         }

      }

      [DataMember( Name = "SecUserId" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Secuserid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Secuserid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Secuserid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      public SdtAudit sdt
      {
         get {
            return (SdtAudit)Sdt ;
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
            sdt = new SdtAudit() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 7 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Audit", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtAudit_RESTLInterface : GxGenericCollectionItem<SdtAudit>
   {
      public SdtAudit_RESTLInterface( ) : base()
      {
      }

      public SdtAudit_RESTLInterface( SdtAudit psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AuditDate" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Auditdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Auditdate) ;
         }

         set {
            sdt.gxTpr_Auditdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtAudit sdt
      {
         get {
            return (SdtAudit)Sdt ;
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
            sdt = new SdtAudit() ;
         }
      }

   }

}
