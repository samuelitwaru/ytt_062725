/*
				   File: type_SdtSDT_EmployeeProjectMatrix
			Description: SDT_EmployeeProjectMatrix
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
	[XmlRoot(ElementName="SDT_EmployeeProjectMatrix")]
	[XmlType(TypeName="SDT_EmployeeProjectMatrix" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDT_EmployeeProjectMatrix : GxUserType
	{
		public SdtSDT_EmployeeProjectMatrix( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_EmployeeProjectMatrix_Employeename = "";

			gxTv_SdtSDT_EmployeeProjectMatrix_Formattedemployeehours = "";

			gxTv_SdtSDT_EmployeeProjectMatrix_Formattedleavehours = "";

			gxTv_SdtSDT_EmployeeProjectMatrix_Formattedworkhours = "";

			gxTv_SdtSDT_EmployeeProjectMatrix_Formattedexpectedworkhours = "";

		}

		public SdtSDT_EmployeeProjectMatrix(IGxContext context)
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


			AddObjectProperty("EmployeeName", gxTpr_Employeename, false);


			AddObjectProperty("EmployeeHours", gxTpr_Employeehours, false);


			AddObjectProperty("FormattedEmployeeHours", gxTpr_Formattedemployeehours, false);


			AddObjectProperty("LeaveHours", gxTpr_Leavehours, false);


			AddObjectProperty("FormattedLeaveHours", gxTpr_Formattedleavehours, false);


			AddObjectProperty("WorkHours", gxTpr_Workhours, false);


			AddObjectProperty("FormattedWorkHours", gxTpr_Formattedworkhours, false);


			AddObjectProperty("ExpectedWorkHours", gxTpr_Expectedworkhours, false);


			AddObjectProperty("FormattedExpectedWorkHours", gxTpr_Formattedexpectedworkhours, false);


			AddObjectProperty("IsOptimal", gxTpr_Isoptimal, false);

			if (gxTv_SdtSDT_EmployeeProjectMatrix_Projects != null)
			{
				AddObjectProperty("Projects", gxTv_SdtSDT_EmployeeProjectMatrix_Projects, false);
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
				return gxTv_SdtSDT_EmployeeProjectMatrix_Employeeid; 
			}
			set {
				gxTv_SdtSDT_EmployeeProjectMatrix_Employeeid = value;
				SetDirty("Employeeid");
			}
		}




		[SoapElement(ElementName="EmployeeName")]
		[XmlElement(ElementName="EmployeeName")]
		public string gxTpr_Employeename
		{
			get {
				return gxTv_SdtSDT_EmployeeProjectMatrix_Employeename; 
			}
			set {
				gxTv_SdtSDT_EmployeeProjectMatrix_Employeename = value;
				SetDirty("Employeename");
			}
		}




		[SoapElement(ElementName="EmployeeHours")]
		[XmlElement(ElementName="EmployeeHours")]
		public long gxTpr_Employeehours
		{
			get {
				return gxTv_SdtSDT_EmployeeProjectMatrix_Employeehours; 
			}
			set {
				gxTv_SdtSDT_EmployeeProjectMatrix_Employeehours = value;
				SetDirty("Employeehours");
			}
		}




		[SoapElement(ElementName="FormattedEmployeeHours")]
		[XmlElement(ElementName="FormattedEmployeeHours")]
		public string gxTpr_Formattedemployeehours
		{
			get {
				return gxTv_SdtSDT_EmployeeProjectMatrix_Formattedemployeehours; 
			}
			set {
				gxTv_SdtSDT_EmployeeProjectMatrix_Formattedemployeehours = value;
				SetDirty("Formattedemployeehours");
			}
		}




		[SoapElement(ElementName="LeaveHours")]
		[XmlElement(ElementName="LeaveHours")]
		public long gxTpr_Leavehours
		{
			get {
				return gxTv_SdtSDT_EmployeeProjectMatrix_Leavehours; 
			}
			set {
				gxTv_SdtSDT_EmployeeProjectMatrix_Leavehours = value;
				SetDirty("Leavehours");
			}
		}




		[SoapElement(ElementName="FormattedLeaveHours")]
		[XmlElement(ElementName="FormattedLeaveHours")]
		public string gxTpr_Formattedleavehours
		{
			get {
				return gxTv_SdtSDT_EmployeeProjectMatrix_Formattedleavehours; 
			}
			set {
				gxTv_SdtSDT_EmployeeProjectMatrix_Formattedleavehours = value;
				SetDirty("Formattedleavehours");
			}
		}




		[SoapElement(ElementName="WorkHours")]
		[XmlElement(ElementName="WorkHours")]
		public long gxTpr_Workhours
		{
			get {
				return gxTv_SdtSDT_EmployeeProjectMatrix_Workhours; 
			}
			set {
				gxTv_SdtSDT_EmployeeProjectMatrix_Workhours = value;
				SetDirty("Workhours");
			}
		}




		[SoapElement(ElementName="FormattedWorkHours")]
		[XmlElement(ElementName="FormattedWorkHours")]
		public string gxTpr_Formattedworkhours
		{
			get {
				return gxTv_SdtSDT_EmployeeProjectMatrix_Formattedworkhours; 
			}
			set {
				gxTv_SdtSDT_EmployeeProjectMatrix_Formattedworkhours = value;
				SetDirty("Formattedworkhours");
			}
		}




		[SoapElement(ElementName="ExpectedWorkHours")]
		[XmlElement(ElementName="ExpectedWorkHours")]
		public long gxTpr_Expectedworkhours
		{
			get {
				return gxTv_SdtSDT_EmployeeProjectMatrix_Expectedworkhours; 
			}
			set {
				gxTv_SdtSDT_EmployeeProjectMatrix_Expectedworkhours = value;
				SetDirty("Expectedworkhours");
			}
		}




		[SoapElement(ElementName="FormattedExpectedWorkHours")]
		[XmlElement(ElementName="FormattedExpectedWorkHours")]
		public string gxTpr_Formattedexpectedworkhours
		{
			get {
				return gxTv_SdtSDT_EmployeeProjectMatrix_Formattedexpectedworkhours; 
			}
			set {
				gxTv_SdtSDT_EmployeeProjectMatrix_Formattedexpectedworkhours = value;
				SetDirty("Formattedexpectedworkhours");
			}
		}




		[SoapElement(ElementName="IsOptimal")]
		[XmlElement(ElementName="IsOptimal")]
		public bool gxTpr_Isoptimal
		{
			get {
				return gxTv_SdtSDT_EmployeeProjectMatrix_Isoptimal; 
			}
			set {
				gxTv_SdtSDT_EmployeeProjectMatrix_Isoptimal = value;
				SetDirty("Isoptimal");
			}
		}




		[SoapElement(ElementName="Projects" )]
		[XmlArray(ElementName="Projects"  )]
		[XmlArrayItemAttribute(ElementName="ProjectsItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_EmployeeProjectMatrix_ProjectsItem> gxTpr_Projects
		{
			get {
				if ( gxTv_SdtSDT_EmployeeProjectMatrix_Projects == null )
				{
					gxTv_SdtSDT_EmployeeProjectMatrix_Projects = new GXBaseCollection<SdtSDT_EmployeeProjectMatrix_ProjectsItem>( context, "SDT_EmployeeProjectMatrix.ProjectsItem", "");
				}
				return gxTv_SdtSDT_EmployeeProjectMatrix_Projects;
			}
			set {
				gxTv_SdtSDT_EmployeeProjectMatrix_Projects_N = false;
				gxTv_SdtSDT_EmployeeProjectMatrix_Projects = value;
				SetDirty("Projects");
			}
		}

		public void gxTv_SdtSDT_EmployeeProjectMatrix_Projects_SetNull()
		{
			gxTv_SdtSDT_EmployeeProjectMatrix_Projects_N = true;
			gxTv_SdtSDT_EmployeeProjectMatrix_Projects = null;
		}

		public bool gxTv_SdtSDT_EmployeeProjectMatrix_Projects_IsNull()
		{
			return gxTv_SdtSDT_EmployeeProjectMatrix_Projects == null;
		}
		public bool ShouldSerializegxTpr_Projects_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_EmployeeProjectMatrix_Projects != null && gxTv_SdtSDT_EmployeeProjectMatrix_Projects.Count > 0;

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
			gxTv_SdtSDT_EmployeeProjectMatrix_Employeename = "";

			gxTv_SdtSDT_EmployeeProjectMatrix_Formattedemployeehours = "";

			gxTv_SdtSDT_EmployeeProjectMatrix_Formattedleavehours = "";

			gxTv_SdtSDT_EmployeeProjectMatrix_Formattedworkhours = "";

			gxTv_SdtSDT_EmployeeProjectMatrix_Formattedexpectedworkhours = "";


			gxTv_SdtSDT_EmployeeProjectMatrix_Projects_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDT_EmployeeProjectMatrix_Employeeid;
		 

		protected string gxTv_SdtSDT_EmployeeProjectMatrix_Employeename;
		 

		protected long gxTv_SdtSDT_EmployeeProjectMatrix_Employeehours;
		 

		protected string gxTv_SdtSDT_EmployeeProjectMatrix_Formattedemployeehours;
		 

		protected long gxTv_SdtSDT_EmployeeProjectMatrix_Leavehours;
		 

		protected string gxTv_SdtSDT_EmployeeProjectMatrix_Formattedleavehours;
		 

		protected long gxTv_SdtSDT_EmployeeProjectMatrix_Workhours;
		 

		protected string gxTv_SdtSDT_EmployeeProjectMatrix_Formattedworkhours;
		 

		protected long gxTv_SdtSDT_EmployeeProjectMatrix_Expectedworkhours;
		 

		protected string gxTv_SdtSDT_EmployeeProjectMatrix_Formattedexpectedworkhours;
		 

		protected bool gxTv_SdtSDT_EmployeeProjectMatrix_Isoptimal;
		 
		protected bool gxTv_SdtSDT_EmployeeProjectMatrix_Projects_N;
		protected GXBaseCollection<SdtSDT_EmployeeProjectMatrix_ProjectsItem> gxTv_SdtSDT_EmployeeProjectMatrix_Projects = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_EmployeeProjectMatrix", Namespace="YTT_version4")]
	public class SdtSDT_EmployeeProjectMatrix_RESTInterface : GxGenericCollectionItem<SdtSDT_EmployeeProjectMatrix>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_EmployeeProjectMatrix_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_EmployeeProjectMatrix_RESTInterface( SdtSDT_EmployeeProjectMatrix psdt ) : base(psdt)
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

		[DataMember(Name="EmployeeName", Order=1)]
		public  string gxTpr_Employeename
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Employeename);

			}
			set { 
				 sdt.gxTpr_Employeename = value;
			}
		}

		[DataMember(Name="EmployeeHours", Order=2)]
		public  string gxTpr_Employeehours
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Employeehours, 10, 0));

			}
			set { 
				sdt.gxTpr_Employeehours = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FormattedEmployeeHours", Order=3)]
		public  string gxTpr_Formattedemployeehours
		{
			get { 
				return sdt.gxTpr_Formattedemployeehours;

			}
			set { 
				 sdt.gxTpr_Formattedemployeehours = value;
			}
		}

		[DataMember(Name="LeaveHours", Order=4)]
		public  string gxTpr_Leavehours
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Leavehours, 10, 0));

			}
			set { 
				sdt.gxTpr_Leavehours = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FormattedLeaveHours", Order=5)]
		public  string gxTpr_Formattedleavehours
		{
			get { 
				return sdt.gxTpr_Formattedleavehours;

			}
			set { 
				 sdt.gxTpr_Formattedleavehours = value;
			}
		}

		[DataMember(Name="WorkHours", Order=6)]
		public  string gxTpr_Workhours
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Workhours, 10, 0));

			}
			set { 
				sdt.gxTpr_Workhours = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FormattedWorkHours", Order=7)]
		public  string gxTpr_Formattedworkhours
		{
			get { 
				return sdt.gxTpr_Formattedworkhours;

			}
			set { 
				 sdt.gxTpr_Formattedworkhours = value;
			}
		}

		[DataMember(Name="ExpectedWorkHours", Order=8)]
		public  string gxTpr_Expectedworkhours
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Expectedworkhours, 10, 0));

			}
			set { 
				sdt.gxTpr_Expectedworkhours = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FormattedExpectedWorkHours", Order=9)]
		public  string gxTpr_Formattedexpectedworkhours
		{
			get { 
				return sdt.gxTpr_Formattedexpectedworkhours;

			}
			set { 
				 sdt.gxTpr_Formattedexpectedworkhours = value;
			}
		}

		[DataMember(Name="IsOptimal", Order=10)]
		public bool gxTpr_Isoptimal
		{
			get { 
				return sdt.gxTpr_Isoptimal;

			}
			set { 
				sdt.gxTpr_Isoptimal = value;
			}
		}

		[DataMember(Name="Projects", Order=11, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_EmployeeProjectMatrix_ProjectsItem_RESTInterface> gxTpr_Projects
		{
			get {
				if (sdt.ShouldSerializegxTpr_Projects_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_EmployeeProjectMatrix_ProjectsItem_RESTInterface>(sdt.gxTpr_Projects);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Projects);
			}
		}


		#endregion

		public SdtSDT_EmployeeProjectMatrix sdt
		{
			get { 
				return (SdtSDT_EmployeeProjectMatrix)Sdt;
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
				sdt = new SdtSDT_EmployeeProjectMatrix() ;
			}
		}
	}
	#endregion
}