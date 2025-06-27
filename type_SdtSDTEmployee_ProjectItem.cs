/*
				   File: type_SdtSDTEmployee_ProjectItem
			Description: Project
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
	[XmlRoot(ElementName="SDTEmployee.ProjectItem")]
	[XmlType(TypeName="SDTEmployee.ProjectItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTEmployee_ProjectItem : GxUserType
	{
		public SdtSDTEmployee_ProjectItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTEmployee_ProjectItem_Projectname = "";

		}

		public SdtSDTEmployee_ProjectItem(IGxContext context)
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

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProjectId")]
		[XmlElement(ElementName="ProjectId")]
		public long gxTpr_Projectid
		{
			get {
				return gxTv_SdtSDTEmployee_ProjectItem_Projectid; 
			}
			set {
				gxTv_SdtSDTEmployee_ProjectItem_Projectid = value;
				SetDirty("Projectid");
			}
		}




		[SoapElement(ElementName="ProjectName")]
		[XmlElement(ElementName="ProjectName")]
		public string gxTpr_Projectname
		{
			get {
				return gxTv_SdtSDTEmployee_ProjectItem_Projectname; 
			}
			set {
				gxTv_SdtSDTEmployee_ProjectItem_Projectname = value;
				SetDirty("Projectname");
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
			gxTv_SdtSDTEmployee_ProjectItem_Projectname = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTEmployee_ProjectItem_Projectid;
		 

		protected string gxTv_SdtSDTEmployee_ProjectItem_Projectname;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTEmployee.ProjectItem", Namespace="YTT_version4")]
	public class SdtSDTEmployee_ProjectItem_RESTInterface : GxGenericCollectionItem<SdtSDTEmployee_ProjectItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTEmployee_ProjectItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTEmployee_ProjectItem_RESTInterface( SdtSDTEmployee_ProjectItem psdt ) : base(psdt)
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


		#endregion

		public SdtSDTEmployee_ProjectItem sdt
		{
			get { 
				return (SdtSDTEmployee_ProjectItem)Sdt;
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
				sdt = new SdtSDTEmployee_ProjectItem() ;
			}
		}
	}
	#endregion
}