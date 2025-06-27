/*
				   File: type_SdtSDTProject
			Description: SDTProject
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
	[XmlRoot(ElementName="SDTProject")]
	[XmlType(TypeName="SDTProject" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTProject : GxUserType
	{
		public SdtSDTProject( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTProject_Projectname = "";

			gxTv_SdtSDTProject_Smallcaseprojectname = "";

			gxTv_SdtSDTProject_Projectdescription = "";

			gxTv_SdtSDTProject_Projectstatus = "";

			gxTv_SdtSDTProject_Projectformattedtime = "";

		}

		public SdtSDTProject(IGxContext context)
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


			AddObjectProperty("Id", gxTpr_Id, false);


			AddObjectProperty("ProjectName", gxTpr_Projectname, false);


			AddObjectProperty("SmallCaseProjectName", gxTpr_Smallcaseprojectname, false);


			AddObjectProperty("ProjectDescription", gxTpr_Projectdescription, false);


			AddObjectProperty("ProjectStatus", gxTpr_Projectstatus, false);


			AddObjectProperty("ProjectTime", gxTpr_Projecttime, false);


			AddObjectProperty("ProjectFormattedTime", gxTpr_Projectformattedtime, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProjectId")]
		[XmlElement(ElementName="ProjectId")]
		public long gxTpr_Projectid
		{
			get {
				return gxTv_SdtSDTProject_Projectid; 
			}
			set {
				gxTv_SdtSDTProject_Projectid = value;
				SetDirty("Projectid");
			}
		}




		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public long gxTpr_Id
		{
			get {
				return gxTv_SdtSDTProject_Id; 
			}
			set {
				gxTv_SdtSDTProject_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="ProjectName")]
		[XmlElement(ElementName="ProjectName")]
		public string gxTpr_Projectname
		{
			get {
				return gxTv_SdtSDTProject_Projectname; 
			}
			set {
				gxTv_SdtSDTProject_Projectname = value;
				SetDirty("Projectname");
			}
		}




		[SoapElement(ElementName="SmallCaseProjectName")]
		[XmlElement(ElementName="SmallCaseProjectName")]
		public string gxTpr_Smallcaseprojectname
		{
			get {
				return gxTv_SdtSDTProject_Smallcaseprojectname; 
			}
			set {
				gxTv_SdtSDTProject_Smallcaseprojectname = value;
				SetDirty("Smallcaseprojectname");
			}
		}




		[SoapElement(ElementName="ProjectDescription")]
		[XmlElement(ElementName="ProjectDescription")]
		public string gxTpr_Projectdescription
		{
			get {
				return gxTv_SdtSDTProject_Projectdescription; 
			}
			set {
				gxTv_SdtSDTProject_Projectdescription = value;
				SetDirty("Projectdescription");
			}
		}




		[SoapElement(ElementName="ProjectStatus")]
		[XmlElement(ElementName="ProjectStatus")]
		public string gxTpr_Projectstatus
		{
			get {
				return gxTv_SdtSDTProject_Projectstatus; 
			}
			set {
				gxTv_SdtSDTProject_Projectstatus = value;
				SetDirty("Projectstatus");
			}
		}




		[SoapElement(ElementName="ProjectTime")]
		[XmlElement(ElementName="ProjectTime")]
		public long gxTpr_Projecttime
		{
			get {
				return gxTv_SdtSDTProject_Projecttime; 
			}
			set {
				gxTv_SdtSDTProject_Projecttime = value;
				SetDirty("Projecttime");
			}
		}




		[SoapElement(ElementName="ProjectFormattedTime")]
		[XmlElement(ElementName="ProjectFormattedTime")]
		public string gxTpr_Projectformattedtime
		{
			get {
				return gxTv_SdtSDTProject_Projectformattedtime; 
			}
			set {
				gxTv_SdtSDTProject_Projectformattedtime = value;
				SetDirty("Projectformattedtime");
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
			gxTv_SdtSDTProject_Projectname = "";
			gxTv_SdtSDTProject_Smallcaseprojectname = "";
			gxTv_SdtSDTProject_Projectdescription = "";
			gxTv_SdtSDTProject_Projectstatus = "";

			gxTv_SdtSDTProject_Projectformattedtime = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTProject_Projectid;
		 

		protected long gxTv_SdtSDTProject_Id;
		 

		protected string gxTv_SdtSDTProject_Projectname;
		 

		protected string gxTv_SdtSDTProject_Smallcaseprojectname;
		 

		protected string gxTv_SdtSDTProject_Projectdescription;
		 

		protected string gxTv_SdtSDTProject_Projectstatus;
		 

		protected long gxTv_SdtSDTProject_Projecttime;
		 

		protected string gxTv_SdtSDTProject_Projectformattedtime;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTProject", Namespace="YTT_version4")]
	public class SdtSDTProject_RESTInterface : GxGenericCollectionItem<SdtSDTProject>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTProject_RESTInterface( ) : base()
		{	
		}

		public SdtSDTProject_RESTInterface( SdtSDTProject psdt ) : base(psdt)
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

		[DataMember(Name="Id", Order=1)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Id, 10, 0));

			}
			set { 
				sdt.gxTpr_Id = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProjectName", Order=2)]
		public  string gxTpr_Projectname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Projectname);

			}
			set { 
				 sdt.gxTpr_Projectname = value;
			}
		}

		[DataMember(Name="SmallCaseProjectName", Order=3)]
		public  string gxTpr_Smallcaseprojectname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Smallcaseprojectname);

			}
			set { 
				 sdt.gxTpr_Smallcaseprojectname = value;
			}
		}

		[DataMember(Name="ProjectDescription", Order=4)]
		public  string gxTpr_Projectdescription
		{
			get { 
				return sdt.gxTpr_Projectdescription;

			}
			set { 
				 sdt.gxTpr_Projectdescription = value;
			}
		}

		[DataMember(Name="ProjectStatus", Order=5)]
		public  string gxTpr_Projectstatus
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Projectstatus);

			}
			set { 
				 sdt.gxTpr_Projectstatus = value;
			}
		}

		[DataMember(Name="ProjectTime", Order=6)]
		public  string gxTpr_Projecttime
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Projecttime, 10, 0));

			}
			set { 
				sdt.gxTpr_Projecttime = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProjectFormattedTime", Order=7)]
		public  string gxTpr_Projectformattedtime
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Projectformattedtime);

			}
			set { 
				 sdt.gxTpr_Projectformattedtime = value;
			}
		}


		#endregion

		public SdtSDTProject sdt
		{
			get { 
				return (SdtSDTProject)Sdt;
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
				sdt = new SdtSDTProject() ;
			}
		}
	}
	#endregion
}