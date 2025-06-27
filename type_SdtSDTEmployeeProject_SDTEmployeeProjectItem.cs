/*
				   File: type_SdtSDTEmployeeProject_SDTEmployeeProjectItem
			Description: SDTEmployeeProject
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
	[XmlRoot(ElementName="SDTEmployeeProjectItem")]
	[XmlType(TypeName="SDTEmployeeProjectItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTEmployeeProject_SDTEmployeeProjectItem : GxUserType
	{
		public SdtSDTEmployeeProject_SDTEmployeeProjectItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectname = "";

			gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectdescription = "";

			gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectstatus = "";

		}

		public SdtSDTEmployeeProject_SDTEmployeeProjectItem(IGxContext context)
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

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProjectId")]
		[XmlElement(ElementName="ProjectId")]
		public long gxTpr_Projectid
		{
			get {
				return gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectid; 
			}
			set {
				gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectid = value;
				SetDirty("Projectid");
			}
		}




		[SoapElement(ElementName="ProjectName")]
		[XmlElement(ElementName="ProjectName")]
		public string gxTpr_Projectname
		{
			get {
				return gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectname; 
			}
			set {
				gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectname = value;
				SetDirty("Projectname");
			}
		}




		[SoapElement(ElementName="ProjectDescription")]
		[XmlElement(ElementName="ProjectDescription")]
		public string gxTpr_Projectdescription
		{
			get {
				return gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectdescription; 
			}
			set {
				gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectdescription = value;
				SetDirty("Projectdescription");
			}
		}




		[SoapElement(ElementName="ProjectStatus")]
		[XmlElement(ElementName="ProjectStatus")]
		public string gxTpr_Projectstatus
		{
			get {
				return gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectstatus; 
			}
			set {
				gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectstatus = value;
				SetDirty("Projectstatus");
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
			gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectname = "";
			gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectdescription = "";
			gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectstatus = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectid;
		 

		protected string gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectname;
		 

		protected string gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectdescription;
		 

		protected string gxTv_SdtSDTEmployeeProject_SDTEmployeeProjectItem_Projectstatus;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTEmployeeProjectItem", Namespace="YTT_version4")]
	public class SdtSDTEmployeeProject_SDTEmployeeProjectItem_RESTInterface : GxGenericCollectionItem<SdtSDTEmployeeProject_SDTEmployeeProjectItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTEmployeeProject_SDTEmployeeProjectItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTEmployeeProject_SDTEmployeeProjectItem_RESTInterface( SdtSDTEmployeeProject_SDTEmployeeProjectItem psdt ) : base(psdt)
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


		#endregion

		public SdtSDTEmployeeProject_SDTEmployeeProjectItem sdt
		{
			get { 
				return (SdtSDTEmployeeProject_SDTEmployeeProjectItem)Sdt;
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
				sdt = new SdtSDTEmployeeProject_SDTEmployeeProjectItem() ;
			}
		}
	}
	#endregion
}