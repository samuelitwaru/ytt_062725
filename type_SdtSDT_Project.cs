/*
				   File: type_SdtSDT_Project
			Description: SDT_Project
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
	[XmlRoot(ElementName="SDT_Project")]
	[XmlType(TypeName="SDT_Project" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDT_Project : GxUserType
	{
		public SdtSDT_Project( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Project_Projectname = "";

			gxTv_SdtSDT_Project_Projectdescription = "";

			gxTv_SdtSDT_Project_Projectstatus = "";

			gxTv_SdtSDT_Project_Projectmanagername = "";

			gxTv_SdtSDT_Project_Projectmanageremail = "";

		}

		public SdtSDT_Project(IGxContext context)
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
			AddObjectProperty("ProjectId", gxTpr_Projectid, false);


			AddObjectProperty("ProjectName", gxTpr_Projectname, false);


			AddObjectProperty("ProjectDescription", gxTpr_Projectdescription, false);


			AddObjectProperty("ProjectStatus", gxTpr_Projectstatus, false);


			AddObjectProperty("ProjectManagerId", gxTpr_Projectmanagerid, false);


			AddObjectProperty("ProjectManagerName", gxTpr_Projectmanagername, false);


			AddObjectProperty("ProjectManagerEmail", gxTpr_Projectmanageremail, false);


			AddObjectProperty("ProjectManagerIsActive", gxTpr_Projectmanagerisactive, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProjectId")]
		[XmlElement(ElementName="ProjectId")]
		public long gxTpr_Projectid
		{
			get {
				return gxTv_SdtSDT_Project_Projectid; 
			}
			set {
				gxTv_SdtSDT_Project_Projectid = value;
				SetDirty("Projectid");
			}
		}




		[SoapElement(ElementName="ProjectName")]
		[XmlElement(ElementName="ProjectName")]
		public string gxTpr_Projectname
		{
			get {
				return gxTv_SdtSDT_Project_Projectname; 
			}
			set {
				gxTv_SdtSDT_Project_Projectname = value;
				SetDirty("Projectname");
			}
		}




		[SoapElement(ElementName="ProjectDescription")]
		[XmlElement(ElementName="ProjectDescription")]
		public string gxTpr_Projectdescription
		{
			get {
				return gxTv_SdtSDT_Project_Projectdescription; 
			}
			set {
				gxTv_SdtSDT_Project_Projectdescription = value;
				SetDirty("Projectdescription");
			}
		}




		[SoapElement(ElementName="ProjectStatus")]
		[XmlElement(ElementName="ProjectStatus")]
		public string gxTpr_Projectstatus
		{
			get {
				return gxTv_SdtSDT_Project_Projectstatus; 
			}
			set {
				gxTv_SdtSDT_Project_Projectstatus = value;
				SetDirty("Projectstatus");
			}
		}




		[SoapElement(ElementName="ProjectManagerId")]
		[XmlElement(ElementName="ProjectManagerId")]
		public long gxTpr_Projectmanagerid
		{
			get {
				return gxTv_SdtSDT_Project_Projectmanagerid; 
			}
			set {
				gxTv_SdtSDT_Project_Projectmanagerid = value;
				SetDirty("Projectmanagerid");
			}
		}




		[SoapElement(ElementName="ProjectManagerName")]
		[XmlElement(ElementName="ProjectManagerName")]
		public string gxTpr_Projectmanagername
		{
			get {
				return gxTv_SdtSDT_Project_Projectmanagername; 
			}
			set {
				gxTv_SdtSDT_Project_Projectmanagername = value;
				SetDirty("Projectmanagername");
			}
		}




		[SoapElement(ElementName="ProjectManagerEmail")]
		[XmlElement(ElementName="ProjectManagerEmail")]
		public string gxTpr_Projectmanageremail
		{
			get {
				return gxTv_SdtSDT_Project_Projectmanageremail; 
			}
			set {
				gxTv_SdtSDT_Project_Projectmanageremail = value;
				SetDirty("Projectmanageremail");
			}
		}




		[SoapElement(ElementName="ProjectManagerIsActive")]
		[XmlElement(ElementName="ProjectManagerIsActive")]
		public bool gxTpr_Projectmanagerisactive
		{
			get {
				return gxTv_SdtSDT_Project_Projectmanagerisactive; 
			}
			set {
				gxTv_SdtSDT_Project_Projectmanagerisactive = value;
				SetDirty("Projectmanagerisactive");
			}
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
			gxTv_SdtSDT_Project_Projectname = "";
			gxTv_SdtSDT_Project_Projectdescription = "";
			gxTv_SdtSDT_Project_Projectstatus = "";

			gxTv_SdtSDT_Project_Projectmanagername = "";
			gxTv_SdtSDT_Project_Projectmanageremail = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDT_Project_Projectid;
		 

		protected string gxTv_SdtSDT_Project_Projectname;
		 

		protected string gxTv_SdtSDT_Project_Projectdescription;
		 

		protected string gxTv_SdtSDT_Project_Projectstatus;
		 

		protected long gxTv_SdtSDT_Project_Projectmanagerid;
		 

		protected string gxTv_SdtSDT_Project_Projectmanagername;
		 

		protected string gxTv_SdtSDT_Project_Projectmanageremail;
		 

		protected bool gxTv_SdtSDT_Project_Projectmanagerisactive;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Project", Namespace="YTT_version4")]
	public class SdtSDT_Project_RESTInterface : GxGenericCollectionItem<SdtSDT_Project>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Project_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Project_RESTInterface( SdtSDT_Project psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProjectId", Order=0)]
		public  string gxTpr_Projectid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Projectid, 10, 0));

			}
			set { 
				sdt.gxTpr_Projectid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProjectName", Order=1)]
		public  string gxTpr_Projectname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Projectname);

			}
			set { 
				 sdt.gxTpr_Projectname = value;
			}
		}

		[DataMember(Name="ProjectDescription", Order=2)]
		public  string gxTpr_Projectdescription
		{
			get { 
				return sdt.gxTpr_Projectdescription;

			}
			set { 
				 sdt.gxTpr_Projectdescription = value;
			}
		}

		[DataMember(Name="ProjectStatus", Order=3)]
		public  string gxTpr_Projectstatus
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Projectstatus);

			}
			set { 
				 sdt.gxTpr_Projectstatus = value;
			}
		}

		[DataMember(Name="ProjectManagerId", Order=4)]
		public  string gxTpr_Projectmanagerid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Projectmanagerid, 10, 0));

			}
			set { 
				sdt.gxTpr_Projectmanagerid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProjectManagerName", Order=5)]
		public  string gxTpr_Projectmanagername
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Projectmanagername);

			}
			set { 
				 sdt.gxTpr_Projectmanagername = value;
			}
		}

		[DataMember(Name="ProjectManagerEmail", Order=6)]
		public  string gxTpr_Projectmanageremail
		{
			get { 
				return sdt.gxTpr_Projectmanageremail;

			}
			set { 
				 sdt.gxTpr_Projectmanageremail = value;
			}
		}

		[DataMember(Name="ProjectManagerIsActive", Order=7)]
		public bool gxTpr_Projectmanagerisactive
		{
			get { 
				return sdt.gxTpr_Projectmanagerisactive;

			}
			set { 
				sdt.gxTpr_Projectmanagerisactive = value;
			}
		}


		#endregion

		public SdtSDT_Project sdt
		{
			get { 
				return (SdtSDT_Project)Sdt;
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
				sdt = new SdtSDT_Project() ;
			}
		}
	}
	#endregion
}