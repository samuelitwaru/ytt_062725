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
   [XmlRoot(ElementName = "Employee.Project" )]
   [XmlType(TypeName =  "Employee.Project" , Namespace = "YTT_version4" )]
   [Serializable]
   public class SdtEmployee_Project : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtEmployee_Project( )
      {
      }

      public SdtEmployee_Project( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"ProjectId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Project");
         metadata.Set("BT", "EmployeeProject");
         metadata.Set("PK", "[ \"ProjectId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"EmployeeId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ProjectId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Projectid_Z");
         state.Add("gxTpr_Projectname_Z");
         state.Add("gxTpr_Employeeisactiveinproject_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEmployee_Project sdt;
         sdt = (SdtEmployee_Project)(source);
         gxTv_SdtEmployee_Project_Projectid = sdt.gxTv_SdtEmployee_Project_Projectid ;
         gxTv_SdtEmployee_Project_Projectname = sdt.gxTv_SdtEmployee_Project_Projectname ;
         gxTv_SdtEmployee_Project_Employeeisactiveinproject = sdt.gxTv_SdtEmployee_Project_Employeeisactiveinproject ;
         gxTv_SdtEmployee_Project_Mode = sdt.gxTv_SdtEmployee_Project_Mode ;
         gxTv_SdtEmployee_Project_Modified = sdt.gxTv_SdtEmployee_Project_Modified ;
         gxTv_SdtEmployee_Project_Initialized = sdt.gxTv_SdtEmployee_Project_Initialized ;
         gxTv_SdtEmployee_Project_Projectid_Z = sdt.gxTv_SdtEmployee_Project_Projectid_Z ;
         gxTv_SdtEmployee_Project_Projectname_Z = sdt.gxTv_SdtEmployee_Project_Projectname_Z ;
         gxTv_SdtEmployee_Project_Employeeisactiveinproject_Z = sdt.gxTv_SdtEmployee_Project_Employeeisactiveinproject_Z ;
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
         AddObjectProperty("ProjectId", gxTv_SdtEmployee_Project_Projectid, false, includeNonInitialized);
         AddObjectProperty("ProjectName", gxTv_SdtEmployee_Project_Projectname, false, includeNonInitialized);
         AddObjectProperty("EmployeeIsActiveInProject", gxTv_SdtEmployee_Project_Employeeisactiveinproject, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEmployee_Project_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtEmployee_Project_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEmployee_Project_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProjectId_Z", gxTv_SdtEmployee_Project_Projectid_Z, false, includeNonInitialized);
            AddObjectProperty("ProjectName_Z", gxTv_SdtEmployee_Project_Projectname_Z, false, includeNonInitialized);
            AddObjectProperty("EmployeeIsActiveInProject_Z", gxTv_SdtEmployee_Project_Employeeisactiveinproject_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEmployee_Project sdt )
      {
         if ( sdt.IsDirty("ProjectId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Project_Projectid = sdt.gxTv_SdtEmployee_Project_Projectid ;
         }
         if ( sdt.IsDirty("ProjectName") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Project_Projectname = sdt.gxTv_SdtEmployee_Project_Projectname ;
         }
         if ( sdt.IsDirty("EmployeeIsActiveInProject") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Project_Employeeisactiveinproject = sdt.gxTv_SdtEmployee_Project_Employeeisactiveinproject ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProjectId" )]
      [  XmlElement( ElementName = "ProjectId"   )]
      public long gxTpr_Projectid
      {
         get {
            return gxTv_SdtEmployee_Project_Projectid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Project_Projectid = value;
            gxTv_SdtEmployee_Project_Modified = 1;
            SetDirty("Projectid");
         }

      }

      [  SoapElement( ElementName = "ProjectName" )]
      [  XmlElement( ElementName = "ProjectName"   )]
      public string gxTpr_Projectname
      {
         get {
            return gxTv_SdtEmployee_Project_Projectname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Project_Projectname = value;
            gxTv_SdtEmployee_Project_Modified = 1;
            SetDirty("Projectname");
         }

      }

      [  SoapElement( ElementName = "EmployeeIsActiveInProject" )]
      [  XmlElement( ElementName = "EmployeeIsActiveInProject"   )]
      public bool gxTpr_Employeeisactiveinproject
      {
         get {
            return gxTv_SdtEmployee_Project_Employeeisactiveinproject ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Project_Employeeisactiveinproject = value;
            gxTv_SdtEmployee_Project_Modified = 1;
            SetDirty("Employeeisactiveinproject");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEmployee_Project_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Project_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEmployee_Project_Mode_SetNull( )
      {
         gxTv_SdtEmployee_Project_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEmployee_Project_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtEmployee_Project_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Project_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtEmployee_Project_Modified_SetNull( )
      {
         gxTv_SdtEmployee_Project_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtEmployee_Project_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEmployee_Project_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Project_Initialized = value;
            gxTv_SdtEmployee_Project_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEmployee_Project_Initialized_SetNull( )
      {
         gxTv_SdtEmployee_Project_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEmployee_Project_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProjectId_Z" )]
      [  XmlElement( ElementName = "ProjectId_Z"   )]
      public long gxTpr_Projectid_Z
      {
         get {
            return gxTv_SdtEmployee_Project_Projectid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Project_Projectid_Z = value;
            gxTv_SdtEmployee_Project_Modified = 1;
            SetDirty("Projectid_Z");
         }

      }

      public void gxTv_SdtEmployee_Project_Projectid_Z_SetNull( )
      {
         gxTv_SdtEmployee_Project_Projectid_Z = 0;
         SetDirty("Projectid_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Project_Projectid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProjectName_Z" )]
      [  XmlElement( ElementName = "ProjectName_Z"   )]
      public string gxTpr_Projectname_Z
      {
         get {
            return gxTv_SdtEmployee_Project_Projectname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Project_Projectname_Z = value;
            gxTv_SdtEmployee_Project_Modified = 1;
            SetDirty("Projectname_Z");
         }

      }

      public void gxTv_SdtEmployee_Project_Projectname_Z_SetNull( )
      {
         gxTv_SdtEmployee_Project_Projectname_Z = "";
         SetDirty("Projectname_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Project_Projectname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeIsActiveInProject_Z" )]
      [  XmlElement( ElementName = "EmployeeIsActiveInProject_Z"   )]
      public bool gxTpr_Employeeisactiveinproject_Z
      {
         get {
            return gxTv_SdtEmployee_Project_Employeeisactiveinproject_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Project_Employeeisactiveinproject_Z = value;
            gxTv_SdtEmployee_Project_Modified = 1;
            SetDirty("Employeeisactiveinproject_Z");
         }

      }

      public void gxTv_SdtEmployee_Project_Employeeisactiveinproject_Z_SetNull( )
      {
         gxTv_SdtEmployee_Project_Employeeisactiveinproject_Z = false;
         SetDirty("Employeeisactiveinproject_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Project_Employeeisactiveinproject_Z_IsNull( )
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
         gxTv_SdtEmployee_Project_Projectname = "";
         gxTv_SdtEmployee_Project_Employeeisactiveinproject = true;
         gxTv_SdtEmployee_Project_Mode = "";
         gxTv_SdtEmployee_Project_Projectname_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtEmployee_Project_Modified ;
      private short gxTv_SdtEmployee_Project_Initialized ;
      private long gxTv_SdtEmployee_Project_Projectid ;
      private long gxTv_SdtEmployee_Project_Projectid_Z ;
      private string gxTv_SdtEmployee_Project_Projectname ;
      private string gxTv_SdtEmployee_Project_Mode ;
      private string gxTv_SdtEmployee_Project_Projectname_Z ;
      private bool gxTv_SdtEmployee_Project_Employeeisactiveinproject ;
      private bool gxTv_SdtEmployee_Project_Employeeisactiveinproject_Z ;
   }

   [DataContract(Name = @"Employee.Project", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtEmployee_Project_RESTInterface : GxGenericCollectionItem<SdtEmployee_Project>
   {
      public SdtEmployee_Project_RESTInterface( ) : base()
      {
      }

      public SdtEmployee_Project_RESTInterface( SdtEmployee_Project psdt ) : base(psdt)
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

      [DataMember( Name = "EmployeeIsActiveInProject" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Employeeisactiveinproject
      {
         get {
            return sdt.gxTpr_Employeeisactiveinproject ;
         }

         set {
            sdt.gxTpr_Employeeisactiveinproject = value;
         }

      }

      public SdtEmployee_Project sdt
      {
         get {
            return (SdtEmployee_Project)Sdt ;
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
            sdt = new SdtEmployee_Project() ;
         }
      }

   }

   [DataContract(Name = @"Employee.Project", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtEmployee_Project_RESTLInterface : GxGenericCollectionItem<SdtEmployee_Project>
   {
      public SdtEmployee_Project_RESTLInterface( ) : base()
      {
      }

      public SdtEmployee_Project_RESTLInterface( SdtEmployee_Project psdt ) : base(psdt)
      {
      }

      public SdtEmployee_Project sdt
      {
         get {
            return (SdtEmployee_Project)Sdt ;
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
            sdt = new SdtEmployee_Project() ;
         }
      }

   }

}
