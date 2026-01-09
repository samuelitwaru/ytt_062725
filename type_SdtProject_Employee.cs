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
   [XmlRoot(ElementName = "Project.Employee" )]
   [XmlType(TypeName =  "Project.Employee" , Namespace = "YTT_version4" )]
   [Serializable]
   public class SdtProject_Employee : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtProject_Employee( )
      {
      }

      public SdtProject_Employee( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"EmployeeId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Employee");
         metadata.Set("BT", "EmployeeProject");
         metadata.Set("PK", "[ \"EmployeeId\" ]");
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
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtProject_Employee sdt;
         sdt = (SdtProject_Employee)(source);
         gxTv_SdtProject_Employee_Employeeid = sdt.gxTv_SdtProject_Employee_Employeeid ;
         gxTv_SdtProject_Employee_Employeename = sdt.gxTv_SdtProject_Employee_Employeename ;
         gxTv_SdtProject_Employee_Mode = sdt.gxTv_SdtProject_Employee_Mode ;
         gxTv_SdtProject_Employee_Modified = sdt.gxTv_SdtProject_Employee_Modified ;
         gxTv_SdtProject_Employee_Initialized = sdt.gxTv_SdtProject_Employee_Initialized ;
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
         AddObjectProperty("EmployeeId", gxTv_SdtProject_Employee_Employeeid, false, includeNonInitialized);
         AddObjectProperty("EmployeeName", gxTv_SdtProject_Employee_Employeename, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtProject_Employee_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtProject_Employee_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProject_Employee_Initialized, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtProject_Employee sdt )
      {
         if ( sdt.IsDirty("EmployeeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProject_Employee_Employeeid = sdt.gxTv_SdtProject_Employee_Employeeid ;
         }
         if ( sdt.IsDirty("EmployeeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtProject_Employee_Employeename = sdt.gxTv_SdtProject_Employee_Employeename ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EmployeeId" )]
      [  XmlElement( ElementName = "EmployeeId"   )]
      public long gxTpr_Employeeid
      {
         get {
            return gxTv_SdtProject_Employee_Employeeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Employee_Employeeid = value;
            gxTv_SdtProject_Employee_Modified = 1;
            SetDirty("Employeeid");
         }

      }

      [  SoapElement( ElementName = "EmployeeName" )]
      [  XmlElement( ElementName = "EmployeeName"   )]
      public string gxTpr_Employeename
      {
         get {
            return gxTv_SdtProject_Employee_Employeename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Employee_Employeename = value;
            gxTv_SdtProject_Employee_Modified = 1;
            SetDirty("Employeename");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProject_Employee_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Employee_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProject_Employee_Mode_SetNull( )
      {
         gxTv_SdtProject_Employee_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProject_Employee_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtProject_Employee_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Employee_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtProject_Employee_Modified_SetNull( )
      {
         gxTv_SdtProject_Employee_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtProject_Employee_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProject_Employee_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProject_Employee_Initialized = value;
            gxTv_SdtProject_Employee_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProject_Employee_Initialized_SetNull( )
      {
         gxTv_SdtProject_Employee_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProject_Employee_Initialized_IsNull( )
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
         gxTv_SdtProject_Employee_Employeename = "";
         gxTv_SdtProject_Employee_Mode = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtProject_Employee_Modified ;
      private short gxTv_SdtProject_Employee_Initialized ;
      private long gxTv_SdtProject_Employee_Employeeid ;
      private string gxTv_SdtProject_Employee_Employeename ;
      private string gxTv_SdtProject_Employee_Mode ;
   }

   [DataContract(Name = @"Project.Employee", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtProject_Employee_RESTInterface : GxGenericCollectionItem<SdtProject_Employee>
   {
      public SdtProject_Employee_RESTInterface( ) : base()
      {
      }

      public SdtProject_Employee_RESTInterface( SdtProject_Employee psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EmployeeId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Employeeid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Employeeid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Employeeid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "EmployeeName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Employeename
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Employeename) ;
         }

         set {
            sdt.gxTpr_Employeename = value;
         }

      }

      public SdtProject_Employee sdt
      {
         get {
            return (SdtProject_Employee)Sdt ;
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
            sdt = new SdtProject_Employee() ;
         }
      }

   }

   [DataContract(Name = @"Project.Employee", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtProject_Employee_RESTLInterface : GxGenericCollectionItem<SdtProject_Employee>
   {
      public SdtProject_Employee_RESTLInterface( ) : base()
      {
      }

      public SdtProject_Employee_RESTLInterface( SdtProject_Employee psdt ) : base(psdt)
      {
      }

      public SdtProject_Employee sdt
      {
         get {
            return (SdtProject_Employee)Sdt ;
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
            sdt = new SdtProject_Employee() ;
         }
      }

   }

}
