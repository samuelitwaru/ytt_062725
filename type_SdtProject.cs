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
   [XmlRoot(ElementName = "Project" )]
   [XmlType(TypeName =  "Project" , Namespace = "YTT_version4" )]
   [Serializable]
   public class SdtProject : GxSilentTrnSdt
   {
      public SdtProject( )
      {
      }

      public SdtProject( IGxContext context )
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

      public void Load( long AV102ProjectId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV102ProjectId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ProjectId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Project");
         metadata.Set("BT", "Project");
         metadata.Set("PK", "[ \"ProjectId\" ]");
         metadata.Set("PKAssigned", "[ \"ProjectId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"EmployeeId\" ],\"FKMap\":[ \"ProjectManagerId-EmployeeId\" ] },{ \"FK\":[ \"EmployeeId\",\"ProjectId\" ],\"FKMap\":[ \"ProjectManagerId-EmployeeId\" ] },{ \"FK\":[ \"ProjectId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Projectid_Z");
         state.Add("gxTpr_Projectname_Z");
         state.Add("gxTpr_Projectdescription_Z");
         state.Add("gxTpr_Projectstatus_Z");
         state.Add("gxTpr_Projectmanagerid_Z");
         state.Add("gxTpr_Projectmanagername_Z");
         state.Add("gxTpr_Projectmanageremail_Z");
         state.Add("gxTpr_Projectmanagerisactive_Z");
         state.Add("gxTpr_Projectmanagerid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtProject sdt;
         sdt = (SdtProject)(source);
         gxTv_SdtProject_Projectid = sdt.gxTv_SdtProject_Projectid ;
         gxTv_SdtProject_Projectname = sdt.gxTv_SdtProject_Projectname ;
         gxTv_SdtProject_Projectdescription = sdt.gxTv_SdtProject_Projectdescription ;
         gxTv_SdtProject_Projectstatus = sdt.gxTv_SdtProject_Projectstatus ;
         gxTv_SdtProject_Projectmanagerid = sdt.gxTv_SdtProject_Projectmanagerid ;
         gxTv_SdtProject_Projectmanagername = sdt.gxTv_SdtProject_Projectmanagername ;
         gxTv_SdtProject_Projectmanageremail = sdt.gxTv_SdtProject_Projectmanageremail ;
         gxTv_SdtProject_Projectmanagerisactive = sdt.gxTv_SdtProject_Projectmanagerisactive ;
         gxTv_SdtProject_Mode = sdt.gxTv_SdtProject_Mode ;
         gxTv_SdtProject_Initialized = sdt.gxTv_SdtProject_Initialized ;
         gxTv_SdtProject_Projectid_Z = sdt.gxTv_SdtProject_Projectid_Z ;
         gxTv_SdtProject_Projectname_Z = sdt.gxTv_SdtProject_Projectname_Z ;
         gxTv_SdtProject_Projectdescription_Z = sdt.gxTv_SdtProject_Projectdescription_Z ;
         gxTv_SdtProject_Projectstatus_Z = sdt.gxTv_SdtProject_Projectstatus_Z ;
         gxTv_SdtProject_Projectmanagerid_Z = sdt.gxTv_SdtProject_Projectmanagerid_Z ;
         gxTv_SdtProject_Projectmanagername_Z = sdt.gxTv_SdtProject_Projectmanagername_Z ;
         gxTv_SdtProject_Projectmanageremail_Z = sdt.gxTv_SdtProject_Projectmanageremail_Z ;
         gxTv_SdtProject_Projectmanagerisactive_Z = sdt.gxTv_SdtProject_Projectmanagerisactive_Z ;
         gxTv_SdtProject_Projectmanagerid_N = sdt.gxTv_SdtProject_Projectmanagerid_N ;
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
         AddObjectProperty("ProjectId", gxTv_SdtProject_Projectid, false, includeNonInitialized);
         AddObjectProperty("ProjectName", gxTv_SdtProject_Projectname, false, includeNonInitialized);
         AddObjectProperty("ProjectDescription", gxTv_SdtProject_Projectdescription, false, includeNonInitialized);
         AddObjectProperty("ProjectStatus", gxTv_SdtProject_Projectstatus, false, includeNonInitialized);
         AddObjectProperty("ProjectManagerId", gxTv_SdtProject_Projectmanagerid, false, includeNonInitialized);
         AddObjectProperty("ProjectManagerId_N", gxTv_SdtProject_Projectmanagerid_N, false, includeNonInitialized);
         AddObjectProperty("ProjectManagerName", gxTv_SdtProject_Projectmanagername, false, includeNonInitialized);
         AddObjectProperty("ProjectManagerEmail", gxTv_SdtProject_Projectmanageremail, false, includeNonInitialized);
         AddObjectProperty("ProjectManagerIsActive", gxTv_SdtProject_Projectmanagerisactive, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtProject_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProject_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProjectId_Z", gxTv_SdtProject_Projectid_Z, false, includeNonInitialized);
            AddObjectProperty("ProjectName_Z", gxTv_SdtProject_Projectname_Z, false, includeNonInitialized);
            AddObjectProperty("ProjectDescription_Z", gxTv_SdtProject_Projectdescription_Z, false, includeNonInitialized);
            AddObjectProperty("ProjectStatus_Z", gxTv_SdtProject_Projectstatus_Z, false, includeNonInitialized);
            AddObjectProperty("ProjectManagerId_Z", gxTv_SdtProject_Projectmanagerid_Z, false, includeNonInitialized);
            AddObjectProperty("ProjectManagerName_Z", gxTv_SdtProject_Projectmanagername_Z, false, includeNonInitialized);
            AddObjectProperty("ProjectManagerEmail_Z", gxTv_SdtProject_Projectmanageremail_Z, false, includeNonInitialized);
            AddObjectProperty("ProjectManagerIsActive_Z", gxTv_SdtProject_Projectmanagerisactive_Z, false, includeNonInitialized);
            AddObjectProperty("ProjectManagerId_N", gxTv_SdtProject_Projectmanagerid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtProject sdt )
      {
         if ( sdt.IsDirty("ProjectId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectid = sdt.gxTv_SdtProject_Projectid ;
         }
         if ( sdt.IsDirty("ProjectName") )
         {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectname = sdt.gxTv_SdtProject_Projectname ;
         }
         if ( sdt.IsDirty("ProjectDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectdescription = sdt.gxTv_SdtProject_Projectdescription ;
         }
         if ( sdt.IsDirty("ProjectStatus") )
         {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectstatus = sdt.gxTv_SdtProject_Projectstatus ;
         }
         if ( sdt.IsDirty("ProjectManagerId") )
         {
            gxTv_SdtProject_Projectmanagerid_N = (short)(sdt.gxTv_SdtProject_Projectmanagerid_N);
            sdtIsNull = 0;
            gxTv_SdtProject_Projectmanagerid = sdt.gxTv_SdtProject_Projectmanagerid ;
         }
         if ( sdt.IsDirty("ProjectManagerName") )
         {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectmanagername = sdt.gxTv_SdtProject_Projectmanagername ;
         }
         if ( sdt.IsDirty("ProjectManagerEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectmanageremail = sdt.gxTv_SdtProject_Projectmanageremail ;
         }
         if ( sdt.IsDirty("ProjectManagerIsActive") )
         {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectmanagerisactive = sdt.gxTv_SdtProject_Projectmanagerisactive ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProjectId" )]
      [  XmlElement( ElementName = "ProjectId"   )]
      public long gxTpr_Projectid
      {
         get {
            return gxTv_SdtProject_Projectid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtProject_Projectid != value )
            {
               gxTv_SdtProject_Mode = "INS";
               this.gxTv_SdtProject_Projectid_Z_SetNull( );
               this.gxTv_SdtProject_Projectname_Z_SetNull( );
               this.gxTv_SdtProject_Projectdescription_Z_SetNull( );
               this.gxTv_SdtProject_Projectstatus_Z_SetNull( );
               this.gxTv_SdtProject_Projectmanagerid_Z_SetNull( );
               this.gxTv_SdtProject_Projectmanagername_Z_SetNull( );
               this.gxTv_SdtProject_Projectmanageremail_Z_SetNull( );
               this.gxTv_SdtProject_Projectmanagerisactive_Z_SetNull( );
            }
            gxTv_SdtProject_Projectid = value;
            SetDirty("Projectid");
         }

      }

      [  SoapElement( ElementName = "ProjectName" )]
      [  XmlElement( ElementName = "ProjectName"   )]
      public string gxTpr_Projectname
      {
         get {
            return gxTv_SdtProject_Projectname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectname = value;
            SetDirty("Projectname");
         }

      }

      [  SoapElement( ElementName = "ProjectDescription" )]
      [  XmlElement( ElementName = "ProjectDescription"   )]
      public string gxTpr_Projectdescription
      {
         get {
            return gxTv_SdtProject_Projectdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectdescription = value;
            SetDirty("Projectdescription");
         }

      }

      [  SoapElement( ElementName = "ProjectStatus" )]
      [  XmlElement( ElementName = "ProjectStatus"   )]
      public string gxTpr_Projectstatus
      {
         get {
            return gxTv_SdtProject_Projectstatus ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectstatus = value;
            SetDirty("Projectstatus");
         }

      }

      [  SoapElement( ElementName = "ProjectManagerId" )]
      [  XmlElement( ElementName = "ProjectManagerId"   )]
      public long gxTpr_Projectmanagerid
      {
         get {
            return gxTv_SdtProject_Projectmanagerid ;
         }

         set {
            gxTv_SdtProject_Projectmanagerid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProject_Projectmanagerid = value;
            SetDirty("Projectmanagerid");
         }

      }

      public void gxTv_SdtProject_Projectmanagerid_SetNull( )
      {
         gxTv_SdtProject_Projectmanagerid_N = 1;
         gxTv_SdtProject_Projectmanagerid = 0;
         SetDirty("Projectmanagerid");
         return  ;
      }

      public bool gxTv_SdtProject_Projectmanagerid_IsNull( )
      {
         return (gxTv_SdtProject_Projectmanagerid_N==1) ;
      }

      [  SoapElement( ElementName = "ProjectManagerName" )]
      [  XmlElement( ElementName = "ProjectManagerName"   )]
      public string gxTpr_Projectmanagername
      {
         get {
            return gxTv_SdtProject_Projectmanagername ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectmanagername = value;
            SetDirty("Projectmanagername");
         }

      }

      [  SoapElement( ElementName = "ProjectManagerEmail" )]
      [  XmlElement( ElementName = "ProjectManagerEmail"   )]
      public string gxTpr_Projectmanageremail
      {
         get {
            return gxTv_SdtProject_Projectmanageremail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectmanageremail = value;
            SetDirty("Projectmanageremail");
         }

      }

      [  SoapElement( ElementName = "ProjectManagerIsActive" )]
      [  XmlElement( ElementName = "ProjectManagerIsActive"   )]
      public bool gxTpr_Projectmanagerisactive
      {
         get {
            return gxTv_SdtProject_Projectmanagerisactive ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectmanagerisactive = value;
            SetDirty("Projectmanagerisactive");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProject_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProject_Mode_SetNull( )
      {
         gxTv_SdtProject_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProject_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProject_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProject_Initialized_SetNull( )
      {
         gxTv_SdtProject_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProject_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProjectId_Z" )]
      [  XmlElement( ElementName = "ProjectId_Z"   )]
      public long gxTpr_Projectid_Z
      {
         get {
            return gxTv_SdtProject_Projectid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectid_Z = value;
            SetDirty("Projectid_Z");
         }

      }

      public void gxTv_SdtProject_Projectid_Z_SetNull( )
      {
         gxTv_SdtProject_Projectid_Z = 0;
         SetDirty("Projectid_Z");
         return  ;
      }

      public bool gxTv_SdtProject_Projectid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProjectName_Z" )]
      [  XmlElement( ElementName = "ProjectName_Z"   )]
      public string gxTpr_Projectname_Z
      {
         get {
            return gxTv_SdtProject_Projectname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectname_Z = value;
            SetDirty("Projectname_Z");
         }

      }

      public void gxTv_SdtProject_Projectname_Z_SetNull( )
      {
         gxTv_SdtProject_Projectname_Z = "";
         SetDirty("Projectname_Z");
         return  ;
      }

      public bool gxTv_SdtProject_Projectname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProjectDescription_Z" )]
      [  XmlElement( ElementName = "ProjectDescription_Z"   )]
      public string gxTpr_Projectdescription_Z
      {
         get {
            return gxTv_SdtProject_Projectdescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectdescription_Z = value;
            SetDirty("Projectdescription_Z");
         }

      }

      public void gxTv_SdtProject_Projectdescription_Z_SetNull( )
      {
         gxTv_SdtProject_Projectdescription_Z = "";
         SetDirty("Projectdescription_Z");
         return  ;
      }

      public bool gxTv_SdtProject_Projectdescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProjectStatus_Z" )]
      [  XmlElement( ElementName = "ProjectStatus_Z"   )]
      public string gxTpr_Projectstatus_Z
      {
         get {
            return gxTv_SdtProject_Projectstatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectstatus_Z = value;
            SetDirty("Projectstatus_Z");
         }

      }

      public void gxTv_SdtProject_Projectstatus_Z_SetNull( )
      {
         gxTv_SdtProject_Projectstatus_Z = "";
         SetDirty("Projectstatus_Z");
         return  ;
      }

      public bool gxTv_SdtProject_Projectstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProjectManagerId_Z" )]
      [  XmlElement( ElementName = "ProjectManagerId_Z"   )]
      public long gxTpr_Projectmanagerid_Z
      {
         get {
            return gxTv_SdtProject_Projectmanagerid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectmanagerid_Z = value;
            SetDirty("Projectmanagerid_Z");
         }

      }

      public void gxTv_SdtProject_Projectmanagerid_Z_SetNull( )
      {
         gxTv_SdtProject_Projectmanagerid_Z = 0;
         SetDirty("Projectmanagerid_Z");
         return  ;
      }

      public bool gxTv_SdtProject_Projectmanagerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProjectManagerName_Z" )]
      [  XmlElement( ElementName = "ProjectManagerName_Z"   )]
      public string gxTpr_Projectmanagername_Z
      {
         get {
            return gxTv_SdtProject_Projectmanagername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectmanagername_Z = value;
            SetDirty("Projectmanagername_Z");
         }

      }

      public void gxTv_SdtProject_Projectmanagername_Z_SetNull( )
      {
         gxTv_SdtProject_Projectmanagername_Z = "";
         SetDirty("Projectmanagername_Z");
         return  ;
      }

      public bool gxTv_SdtProject_Projectmanagername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProjectManagerEmail_Z" )]
      [  XmlElement( ElementName = "ProjectManagerEmail_Z"   )]
      public string gxTpr_Projectmanageremail_Z
      {
         get {
            return gxTv_SdtProject_Projectmanageremail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectmanageremail_Z = value;
            SetDirty("Projectmanageremail_Z");
         }

      }

      public void gxTv_SdtProject_Projectmanageremail_Z_SetNull( )
      {
         gxTv_SdtProject_Projectmanageremail_Z = "";
         SetDirty("Projectmanageremail_Z");
         return  ;
      }

      public bool gxTv_SdtProject_Projectmanageremail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProjectManagerIsActive_Z" )]
      [  XmlElement( ElementName = "ProjectManagerIsActive_Z"   )]
      public bool gxTpr_Projectmanagerisactive_Z
      {
         get {
            return gxTv_SdtProject_Projectmanagerisactive_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectmanagerisactive_Z = value;
            SetDirty("Projectmanagerisactive_Z");
         }

      }

      public void gxTv_SdtProject_Projectmanagerisactive_Z_SetNull( )
      {
         gxTv_SdtProject_Projectmanagerisactive_Z = false;
         SetDirty("Projectmanagerisactive_Z");
         return  ;
      }

      public bool gxTv_SdtProject_Projectmanagerisactive_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProjectManagerId_N" )]
      [  XmlElement( ElementName = "ProjectManagerId_N"   )]
      public short gxTpr_Projectmanagerid_N
      {
         get {
            return gxTv_SdtProject_Projectmanagerid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Projectmanagerid_N = value;
            SetDirty("Projectmanagerid_N");
         }

      }

      public void gxTv_SdtProject_Projectmanagerid_N_SetNull( )
      {
         gxTv_SdtProject_Projectmanagerid_N = 0;
         SetDirty("Projectmanagerid_N");
         return  ;
      }

      public bool gxTv_SdtProject_Projectmanagerid_N_IsNull( )
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
         gxTv_SdtProject_Projectname = "";
         gxTv_SdtProject_Projectdescription = "";
         gxTv_SdtProject_Projectstatus = "";
         gxTv_SdtProject_Projectmanagername = "";
         gxTv_SdtProject_Projectmanageremail = "";
         gxTv_SdtProject_Mode = "";
         gxTv_SdtProject_Projectname_Z = "";
         gxTv_SdtProject_Projectdescription_Z = "";
         gxTv_SdtProject_Projectstatus_Z = "";
         gxTv_SdtProject_Projectmanagername_Z = "";
         gxTv_SdtProject_Projectmanageremail_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "project", "GeneXus.Programs.project_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtProject_Initialized ;
      private short gxTv_SdtProject_Projectmanagerid_N ;
      private long gxTv_SdtProject_Projectid ;
      private long gxTv_SdtProject_Projectmanagerid ;
      private long gxTv_SdtProject_Projectid_Z ;
      private long gxTv_SdtProject_Projectmanagerid_Z ;
      private string gxTv_SdtProject_Projectname ;
      private string gxTv_SdtProject_Projectstatus ;
      private string gxTv_SdtProject_Projectmanagername ;
      private string gxTv_SdtProject_Mode ;
      private string gxTv_SdtProject_Projectname_Z ;
      private string gxTv_SdtProject_Projectstatus_Z ;
      private string gxTv_SdtProject_Projectmanagername_Z ;
      private bool gxTv_SdtProject_Projectmanagerisactive ;
      private bool gxTv_SdtProject_Projectmanagerisactive_Z ;
      private string gxTv_SdtProject_Projectdescription ;
      private string gxTv_SdtProject_Projectmanageremail ;
      private string gxTv_SdtProject_Projectdescription_Z ;
      private string gxTv_SdtProject_Projectmanageremail_Z ;
   }

   [DataContract(Name = @"Project", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtProject_RESTInterface : GxGenericCollectionItem<SdtProject>
   {
      public SdtProject_RESTInterface( ) : base()
      {
      }

      public SdtProject_RESTInterface( SdtProject psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProjectId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Projectid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Projectid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Projectid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ProjectName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Projectname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Projectname) ;
         }

         set {
            sdt.gxTpr_Projectname = value;
         }

      }

      [DataMember( Name = "ProjectDescription" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Projectdescription
      {
         get {
            return sdt.gxTpr_Projectdescription ;
         }

         set {
            sdt.gxTpr_Projectdescription = value;
         }

      }

      [DataMember( Name = "ProjectStatus" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Projectstatus
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Projectstatus) ;
         }

         set {
            sdt.gxTpr_Projectstatus = value;
         }

      }

      [DataMember( Name = "ProjectManagerId" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Projectmanagerid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Projectmanagerid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Projectmanagerid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ProjectManagerName" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Projectmanagername
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Projectmanagername) ;
         }

         set {
            sdt.gxTpr_Projectmanagername = value;
         }

      }

      [DataMember( Name = "ProjectManagerEmail" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Projectmanageremail
      {
         get {
            return sdt.gxTpr_Projectmanageremail ;
         }

         set {
            sdt.gxTpr_Projectmanageremail = value;
         }

      }

      [DataMember( Name = "ProjectManagerIsActive" , Order = 7 )]
      [GxSeudo()]
      public bool gxTpr_Projectmanagerisactive
      {
         get {
            return sdt.gxTpr_Projectmanagerisactive ;
         }

         set {
            sdt.gxTpr_Projectmanagerisactive = value;
         }

      }

      public SdtProject sdt
      {
         get {
            return (SdtProject)Sdt ;
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
            sdt = new SdtProject() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 8 )]
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

   [DataContract(Name = @"Project", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtProject_RESTLInterface : GxGenericCollectionItem<SdtProject>
   {
      public SdtProject_RESTLInterface( ) : base()
      {
      }

      public SdtProject_RESTLInterface( SdtProject psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProjectName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Projectname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Projectname) ;
         }

         set {
            sdt.gxTpr_Projectname = value;
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

      public SdtProject sdt
      {
         get {
            return (SdtProject)Sdt ;
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
            sdt = new SdtProject() ;
         }
      }

   }

}
