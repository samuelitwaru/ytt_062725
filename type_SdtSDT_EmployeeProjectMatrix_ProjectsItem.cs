/*
				   File: type_SdtSDT_EmployeeProjectMatrix_ProjectsItem
			Description: Projects
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
	[XmlRoot(ElementName="SDT_EmployeeProjectMatrix.ProjectsItem")]
	[XmlType(TypeName="SDT_EmployeeProjectMatrix.ProjectsItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDT_EmployeeProjectMatrix_ProjectsItem : GxUserType
	{
		public SdtSDT_EmployeeProjectMatrix_ProjectsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_EmployeeProjectMatrix_ProjectsItem_Projectname = "";

		}

		public SdtSDT_EmployeeProjectMatrix_ProjectsItem(IGxContext context)
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


			AddObjectProperty("ProjectHours", gxTpr_Projecthours, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProjectId")]
		[XmlElement(ElementName="ProjectId")]
		public long gxTpr_Projectid
		{
			get {
				return gxTv_SdtSDT_EmployeeProjectMatrix_ProjectsItem_Projectid; 
			}
			set {
				gxTv_SdtSDT_EmployeeProjectMatrix_ProjectsItem_Projectid = value;
				SetDirty("Projectid");
			}
		}




		[SoapElement(ElementName="ProjectName")]
		[XmlElement(ElementName="ProjectName")]
		public string gxTpr_Projectname
		{
			get {
				return gxTv_SdtSDT_EmployeeProjectMatrix_ProjectsItem_Projectname; 
			}
			set {
				gxTv_SdtSDT_EmployeeProjectMatrix_ProjectsItem_Projectname = value;
				SetDirty("Projectname");
			}
		}




		[SoapElement(ElementName="ProjectHours")]
		[XmlElement(ElementName="ProjectHours")]
		public long gxTpr_Projecthours
		{
			get {
				return gxTv_SdtSDT_EmployeeProjectMatrix_ProjectsItem_Projecthours; 
			}
			set {
				gxTv_SdtSDT_EmployeeProjectMatrix_ProjectsItem_Projecthours = value;
				SetDirty("Projecthours");
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
			gxTv_SdtSDT_EmployeeProjectMatrix_ProjectsItem_Projectname = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDT_EmployeeProjectMatrix_ProjectsItem_Projectid;
		 

		protected string gxTv_SdtSDT_EmployeeProjectMatrix_ProjectsItem_Projectname;
		 

		protected long gxTv_SdtSDT_EmployeeProjectMatrix_ProjectsItem_Projecthours;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_EmployeeProjectMatrix.ProjectsItem", Namespace="YTT_version4")]
	public class SdtSDT_EmployeeProjectMatrix_ProjectsItem_RESTInterface : GxGenericCollectionItem<SdtSDT_EmployeeProjectMatrix_ProjectsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_EmployeeProjectMatrix_ProjectsItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_EmployeeProjectMatrix_ProjectsItem_RESTInterface( SdtSDT_EmployeeProjectMatrix_ProjectsItem psdt ) : base(psdt)
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

		[DataMember(Name="ProjectHours", Order=2)]
		public  string gxTpr_Projecthours
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Projecthours, 10, 0));

			}
			set { 
				sdt.gxTpr_Projecthours = (long) NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDT_EmployeeProjectMatrix_ProjectsItem sdt
		{
			get { 
				return (SdtSDT_EmployeeProjectMatrix_ProjectsItem)Sdt;
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
				sdt = new SdtSDT_EmployeeProjectMatrix_ProjectsItem() ;
			}
		}
	}
	#endregion
}