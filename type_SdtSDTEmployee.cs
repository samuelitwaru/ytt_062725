/*
				   File: type_SdtSDTEmployee
			Description: SDTEmployee
				 Author: Nemo 🐠 for C# (.NET) version 18.0.10.184260
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="SDTEmployee")]
	[XmlType(TypeName="SDTEmployee" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTEmployee : GxUserType
	{
		public SdtSDTEmployee( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTEmployee_Employeefirstname = "";

			gxTv_SdtSDTEmployee_Employeelastname = "";

			gxTv_SdtSDTEmployee_Employeename = "";

			gxTv_SdtSDTEmployee_Employeeemail = "";

			gxTv_SdtSDTEmployee_Companyname = "";

			gxTv_SdtSDTEmployee_Gamuserguid = "";

		}

		public SdtSDTEmployee(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("EmployeeId", gxTpr_Employeeid, false);


			AddObjectProperty("EmployeeFirstName", gxTpr_Employeefirstname, false);


			AddObjectProperty("EmployeeLastName", gxTpr_Employeelastname, false);


			AddObjectProperty("EmployeeName", gxTpr_Employeename, false);


			AddObjectProperty("EmployeeEmail", gxTpr_Employeeemail, false);


			AddObjectProperty("CompanyId", gxTpr_Companyid, false);


			AddObjectProperty("CompanyName", gxTpr_Companyname, false);


			AddObjectProperty("EmployeeIsManager", gxTpr_Employeeismanager, false);


			AddObjectProperty("GAMUserGUID", gxTpr_Gamuserguid, false);


			AddObjectProperty("EmployeeIsActive", gxTpr_Employeeisactive, false);


			AddObjectProperty("EmployeeVactionDays", gxTpr_Employeevactiondays, false);


			AddObjectProperty("EmployeeBalance", gxTpr_Employeebalance, false);

			if (gxTv_SdtSDTEmployee_Project != null)
			{
				AddObjectProperty("Project", gxTv_SdtSDTEmployee_Project, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="EmployeeId")]
		[XmlElement(ElementName="EmployeeId")]
		public long gxTpr_Employeeid
		{
			get {
				return gxTv_SdtSDTEmployee_Employeeid; 
			}
			set {
				gxTv_SdtSDTEmployee_Employeeid = value;
				SetDirty("Employeeid");
			}
		}




		[SoapElement(ElementName="EmployeeFirstName")]
		[XmlElement(ElementName="EmployeeFirstName")]
		public string gxTpr_Employeefirstname
		{
			get {
				return gxTv_SdtSDTEmployee_Employeefirstname; 
			}
			set {
				gxTv_SdtSDTEmployee_Employeefirstname = value;
				SetDirty("Employeefirstname");
			}
		}




		[SoapElement(ElementName="EmployeeLastName")]
		[XmlElement(ElementName="EmployeeLastName")]
		public string gxTpr_Employeelastname
		{
			get {
				return gxTv_SdtSDTEmployee_Employeelastname; 
			}
			set {
				gxTv_SdtSDTEmployee_Employeelastname = value;
				SetDirty("Employeelastname");
			}
		}




		[SoapElement(ElementName="EmployeeName")]
		[XmlElement(ElementName="EmployeeName")]
		public string gxTpr_Employeename
		{
			get {
				return gxTv_SdtSDTEmployee_Employeename; 
			}
			set {
				gxTv_SdtSDTEmployee_Employeename = value;
				SetDirty("Employeename");
			}
		}




		[SoapElement(ElementName="EmployeeEmail")]
		[XmlElement(ElementName="EmployeeEmail")]
		public string gxTpr_Employeeemail
		{
			get {
				return gxTv_SdtSDTEmployee_Employeeemail; 
			}
			set {
				gxTv_SdtSDTEmployee_Employeeemail = value;
				SetDirty("Employeeemail");
			}
		}




		[SoapElement(ElementName="CompanyId")]
		[XmlElement(ElementName="CompanyId")]
		public long gxTpr_Companyid
		{
			get {
				return gxTv_SdtSDTEmployee_Companyid; 
			}
			set {
				gxTv_SdtSDTEmployee_Companyid = value;
				SetDirty("Companyid");
			}
		}




		[SoapElement(ElementName="CompanyName")]
		[XmlElement(ElementName="CompanyName")]
		public string gxTpr_Companyname
		{
			get {
				return gxTv_SdtSDTEmployee_Companyname; 
			}
			set {
				gxTv_SdtSDTEmployee_Companyname = value;
				SetDirty("Companyname");
			}
		}




		[SoapElement(ElementName="EmployeeIsManager")]
		[XmlElement(ElementName="EmployeeIsManager")]
		public bool gxTpr_Employeeismanager
		{
			get {
				return gxTv_SdtSDTEmployee_Employeeismanager; 
			}
			set {
				gxTv_SdtSDTEmployee_Employeeismanager = value;
				SetDirty("Employeeismanager");
			}
		}




		[SoapElement(ElementName="GAMUserGUID")]
		[XmlElement(ElementName="GAMUserGUID")]
		public string gxTpr_Gamuserguid
		{
			get {
				return gxTv_SdtSDTEmployee_Gamuserguid; 
			}
			set {
				gxTv_SdtSDTEmployee_Gamuserguid = value;
				SetDirty("Gamuserguid");
			}
		}




		[SoapElement(ElementName="EmployeeIsActive")]
		[XmlElement(ElementName="EmployeeIsActive")]
		public bool gxTpr_Employeeisactive
		{
			get {
				return gxTv_SdtSDTEmployee_Employeeisactive; 
			}
			set {
				gxTv_SdtSDTEmployee_Employeeisactive = value;
				SetDirty("Employeeisactive");
			}
		}



		[SoapElement(ElementName="EmployeeVactionDays")]
		[XmlElement(ElementName="EmployeeVactionDays")]
		public string gxTpr_Employeevactiondays_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTEmployee_Employeevactiondays, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTEmployee_Employeevactiondays = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Employeevactiondays
		{
			get {
				return gxTv_SdtSDTEmployee_Employeevactiondays; 
			}
			set {
				gxTv_SdtSDTEmployee_Employeevactiondays = value;
				SetDirty("Employeevactiondays");
			}
		}



		[SoapElement(ElementName="EmployeeBalance")]
		[XmlElement(ElementName="EmployeeBalance")]
		public string gxTpr_Employeebalance_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTEmployee_Employeebalance, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTEmployee_Employeebalance = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Employeebalance
		{
			get {
				return gxTv_SdtSDTEmployee_Employeebalance; 
			}
			set {
				gxTv_SdtSDTEmployee_Employeebalance = value;
				SetDirty("Employeebalance");
			}
		}




		[SoapElement(ElementName="Project" )]
		[XmlArray(ElementName="Project"  )]
		[XmlArrayItemAttribute(ElementName="ProjectItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTEmployee_ProjectItem> gxTpr_Project
		{
			get {
				if ( gxTv_SdtSDTEmployee_Project == null )
				{
					gxTv_SdtSDTEmployee_Project = new GXBaseCollection<SdtSDTEmployee_ProjectItem>( context, "SDTEmployee.ProjectItem", "");
				}
				return gxTv_SdtSDTEmployee_Project;
			}
			set {
				gxTv_SdtSDTEmployee_Project_N = false;
				gxTv_SdtSDTEmployee_Project = value;
				SetDirty("Project");
			}
		}

		public void gxTv_SdtSDTEmployee_Project_SetNull()
		{
			gxTv_SdtSDTEmployee_Project_N = true;
			gxTv_SdtSDTEmployee_Project = null;
		}

		public bool gxTv_SdtSDTEmployee_Project_IsNull()
		{
			return gxTv_SdtSDTEmployee_Project == null;
		}
		public bool ShouldSerializegxTpr_Project_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTEmployee_Project != null && gxTv_SdtSDTEmployee_Project.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Static Type Properties

		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTEmployee_Employeefirstname = "";
			gxTv_SdtSDTEmployee_Employeelastname = "";
			gxTv_SdtSDTEmployee_Employeename = "";
			gxTv_SdtSDTEmployee_Employeeemail = "";

			gxTv_SdtSDTEmployee_Companyname = "";

			gxTv_SdtSDTEmployee_Gamuserguid = "";




			gxTv_SdtSDTEmployee_Project_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTEmployee_Employeeid;
		 

		protected string gxTv_SdtSDTEmployee_Employeefirstname;
		 

		protected string gxTv_SdtSDTEmployee_Employeelastname;
		 

		protected string gxTv_SdtSDTEmployee_Employeename;
		 

		protected string gxTv_SdtSDTEmployee_Employeeemail;
		 

		protected long gxTv_SdtSDTEmployee_Companyid;
		 

		protected string gxTv_SdtSDTEmployee_Companyname;
		 

		protected bool gxTv_SdtSDTEmployee_Employeeismanager;
		 

		protected string gxTv_SdtSDTEmployee_Gamuserguid;
		 

		protected bool gxTv_SdtSDTEmployee_Employeeisactive;
		 

		protected decimal gxTv_SdtSDTEmployee_Employeevactiondays;
		 

		protected decimal gxTv_SdtSDTEmployee_Employeebalance;
		 
		protected bool gxTv_SdtSDTEmployee_Project_N;
		protected GXBaseCollection<SdtSDTEmployee_ProjectItem> gxTv_SdtSDTEmployee_Project = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTEmployee", Namespace="YTT_version4")]
	public class SdtSDTEmployee_RESTInterface : GxGenericCollectionItem<SdtSDTEmployee>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTEmployee_RESTInterface( ) : base()
		{	
		}

		public SdtSDTEmployee_RESTInterface( SdtSDTEmployee psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="EmployeeId", Order=0)]
		public  string gxTpr_Employeeid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Employeeid, 10, 0));

			}
			set { 
				sdt.gxTpr_Employeeid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="EmployeeFirstName", Order=1)]
		public  string gxTpr_Employeefirstname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Employeefirstname);

			}
			set { 
				 sdt.gxTpr_Employeefirstname = value;
			}
		}

		[DataMember(Name="EmployeeLastName", Order=2)]
		public  string gxTpr_Employeelastname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Employeelastname);

			}
			set { 
				 sdt.gxTpr_Employeelastname = value;
			}
		}

		[DataMember(Name="EmployeeName", Order=3)]
		public  string gxTpr_Employeename
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Employeename);

			}
			set { 
				 sdt.gxTpr_Employeename = value;
			}
		}

		[DataMember(Name="EmployeeEmail", Order=4)]
		public  string gxTpr_Employeeemail
		{
			get { 
				return sdt.gxTpr_Employeeemail;

			}
			set { 
				 sdt.gxTpr_Employeeemail = value;
			}
		}

		[DataMember(Name="CompanyId", Order=5)]
		public  string gxTpr_Companyid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Companyid, 10, 0));

			}
			set { 
				sdt.gxTpr_Companyid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="CompanyName", Order=6)]
		public  string gxTpr_Companyname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Companyname);

			}
			set { 
				 sdt.gxTpr_Companyname = value;
			}
		}

		[DataMember(Name="EmployeeIsManager", Order=7)]
		public bool gxTpr_Employeeismanager
		{
			get { 
				return sdt.gxTpr_Employeeismanager;

			}
			set { 
				sdt.gxTpr_Employeeismanager = value;
			}
		}

		[DataMember(Name="GAMUserGUID", Order=8)]
		public  string gxTpr_Gamuserguid
		{
			get { 
				return sdt.gxTpr_Gamuserguid;

			}
			set { 
				 sdt.gxTpr_Gamuserguid = value;
			}
		}

		[DataMember(Name="EmployeeIsActive", Order=9)]
		public bool gxTpr_Employeeisactive
		{
			get { 
				return sdt.gxTpr_Employeeisactive;

			}
			set { 
				sdt.gxTpr_Employeeisactive = value;
			}
		}

		[DataMember(Name="EmployeeVactionDays", Order=10)]
		public decimal gxTpr_Employeevactiondays
		{
			get { 
				return sdt.gxTpr_Employeevactiondays;

			}
			set { 
				sdt.gxTpr_Employeevactiondays = value;
			}
		}

		[DataMember(Name="EmployeeBalance", Order=11)]
		public decimal gxTpr_Employeebalance
		{
			get { 
				return sdt.gxTpr_Employeebalance;

			}
			set { 
				sdt.gxTpr_Employeebalance = value;
			}
		}

		[DataMember(Name="Project", Order=12, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTEmployee_ProjectItem_RESTInterface> gxTpr_Project
		{
			get {
				if (sdt.ShouldSerializegxTpr_Project_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTEmployee_ProjectItem_RESTInterface>(sdt.gxTpr_Project);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Project);
			}
		}


		#endregion

		public SdtSDTEmployee sdt
		{
			get { 
				return (SdtSDTEmployee)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSDTEmployee() ;
			}
		}
	}
	#endregion
}