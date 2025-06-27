/*
				   File: type_SdtLaunchpadOptions_Option
			Description: LaunchpadOptions
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

using GeneXus.Programs;
using GeneXus.Programs.workwithplus;
namespace GeneXus.Programs.workwithplus.nativemobile
{
	[XmlRoot(ElementName="Option")]
	[XmlType(TypeName="Option" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtLaunchpadOptions_Option : GxUserType
	{
		public SdtLaunchpadOptions_Option( )
		{
			/* Constructor for serialization */
			gxTv_SdtLaunchpadOptions_Option_Name = "";

			gxTv_SdtLaunchpadOptions_Option_Description = "";

			gxTv_SdtLaunchpadOptions_Option_Information = "";

			gxTv_SdtLaunchpadOptions_Option_Link = "";

			gxTv_SdtLaunchpadOptions_Option_Icon = "";
			gxTv_SdtLaunchpadOptions_Option_Icon_gxi = "";
		}

		public SdtLaunchpadOptions_Option(IGxContext context)
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
			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("Description", gxTpr_Description, false);


			AddObjectProperty("Information", gxTpr_Information, false);


			AddObjectProperty("Link", gxTpr_Link, false);


			AddObjectProperty("Icon", gxTpr_Icon, false);
			AddObjectProperty("Icon_GXI", gxTpr_Icon_gxi, false);



			AddObjectProperty("OrderIndex", gxTpr_Orderindex, false);


			AddObjectProperty("TileSize", gxTpr_Tilesize, false);


			AddObjectProperty("TileType", gxTpr_Tiletype, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtLaunchpadOptions_Option_Name; 
			}
			set {
				gxTv_SdtLaunchpadOptions_Option_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtLaunchpadOptions_Option_Description; 
			}
			set {
				gxTv_SdtLaunchpadOptions_Option_Description = value;
				SetDirty("Description");
			}
		}




		[SoapElement(ElementName="Information")]
		[XmlElement(ElementName="Information")]
		public string gxTpr_Information
		{
			get {
				return gxTv_SdtLaunchpadOptions_Option_Information; 
			}
			set {
				gxTv_SdtLaunchpadOptions_Option_Information = value;
				SetDirty("Information");
			}
		}




		[SoapElement(ElementName="Link")]
		[XmlElement(ElementName="Link")]
		public string gxTpr_Link
		{
			get {
				return gxTv_SdtLaunchpadOptions_Option_Link; 
			}
			set {
				gxTv_SdtLaunchpadOptions_Option_Link = value;
				SetDirty("Link");
			}
		}




		[SoapElement(ElementName="Icon")]
		[XmlElement(ElementName="Icon")]
		[GxUpload()]

		public string gxTpr_Icon
		{
			get {
				return gxTv_SdtLaunchpadOptions_Option_Icon; 
			}
			set {
				gxTv_SdtLaunchpadOptions_Option_Icon = value;
				SetDirty("Icon");
			}
		}


		[SoapElement(ElementName="Icon_GXI" )]
		[XmlElement(ElementName="Icon_GXI" )]
		public string gxTpr_Icon_gxi
		{
			get {
				return gxTv_SdtLaunchpadOptions_Option_Icon_gxi ;
			}
			set {
				gxTv_SdtLaunchpadOptions_Option_Icon_gxi = value;
				SetDirty("Icon_gxi");
			}
		}

		[SoapElement(ElementName="OrderIndex")]
		[XmlElement(ElementName="OrderIndex")]
		public int gxTpr_Orderindex
		{
			get {
				return gxTv_SdtLaunchpadOptions_Option_Orderindex; 
			}
			set {
				gxTv_SdtLaunchpadOptions_Option_Orderindex = value;
				SetDirty("Orderindex");
			}
		}




		[SoapElement(ElementName="TileSize")]
		[XmlElement(ElementName="TileSize")]
		public short gxTpr_Tilesize
		{
			get {
				return gxTv_SdtLaunchpadOptions_Option_Tilesize; 
			}
			set {
				gxTv_SdtLaunchpadOptions_Option_Tilesize = value;
				SetDirty("Tilesize");
			}
		}




		[SoapElement(ElementName="TileType")]
		[XmlElement(ElementName="TileType")]
		public short gxTpr_Tiletype
		{
			get {
				return gxTv_SdtLaunchpadOptions_Option_Tiletype; 
			}
			set {
				gxTv_SdtLaunchpadOptions_Option_Tiletype = value;
				SetDirty("Tiletype");
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
			gxTv_SdtLaunchpadOptions_Option_Name = "";
			gxTv_SdtLaunchpadOptions_Option_Description = "";
			gxTv_SdtLaunchpadOptions_Option_Information = "";
			gxTv_SdtLaunchpadOptions_Option_Link = "";
			gxTv_SdtLaunchpadOptions_Option_Icon = "";gxTv_SdtLaunchpadOptions_Option_Icon_gxi = "";



			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtLaunchpadOptions_Option_Name;
		 

		protected string gxTv_SdtLaunchpadOptions_Option_Description;
		 

		protected string gxTv_SdtLaunchpadOptions_Option_Information;
		 

		protected string gxTv_SdtLaunchpadOptions_Option_Link;
		 
		protected string gxTv_SdtLaunchpadOptions_Option_Icon_gxi;
		protected string gxTv_SdtLaunchpadOptions_Option_Icon;
		 

		protected int gxTv_SdtLaunchpadOptions_Option_Orderindex;
		 

		protected short gxTv_SdtLaunchpadOptions_Option_Tilesize;
		 

		protected short gxTv_SdtLaunchpadOptions_Option_Tiletype;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"Option", Namespace="YTT_version4")]
	public class SdtLaunchpadOptions_Option_RESTInterface : GxGenericCollectionItem<SdtLaunchpadOptions_Option>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtLaunchpadOptions_Option_RESTInterface( ) : base()
		{	
		}

		public SdtLaunchpadOptions_Option_RESTInterface( SdtLaunchpadOptions_Option psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Description", Order=1)]
		public  string gxTpr_Description
		{
			get { 
				return sdt.gxTpr_Description;

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}

		[DataMember(Name="Information", Order=2)]
		public  string gxTpr_Information
		{
			get { 
				return sdt.gxTpr_Information;

			}
			set { 
				 sdt.gxTpr_Information = value;
			}
		}

		[DataMember(Name="Link", Order=3)]
		public  string gxTpr_Link
		{
			get { 
				return sdt.gxTpr_Link;

			}
			set { 
				 sdt.gxTpr_Link = value;
			}
		}

		[DataMember(Name="Icon", Order=4)]
		[GxUpload()]
		public  string gxTpr_Icon
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Icon)) ? PathUtil.RelativePath( sdt.gxTpr_Icon) : StringUtil.RTrim( sdt.gxTpr_Icon_gxi));

			}
			set { 
				 sdt.gxTpr_Icon = value;
			}
		}

		[DataMember(Name="OrderIndex", Order=5)]
		public int gxTpr_Orderindex
		{
			get { 
				return sdt.gxTpr_Orderindex;

			}
			set { 
				sdt.gxTpr_Orderindex = value;
			}
		}

		[DataMember(Name="TileSize", Order=6)]
		public short gxTpr_Tilesize
		{
			get { 
				return sdt.gxTpr_Tilesize;

			}
			set { 
				sdt.gxTpr_Tilesize = value;
			}
		}

		[DataMember(Name="TileType", Order=7)]
		public short gxTpr_Tiletype
		{
			get { 
				return sdt.gxTpr_Tiletype;

			}
			set { 
				sdt.gxTpr_Tiletype = value;
			}
		}


		#endregion

		public SdtLaunchpadOptions_Option sdt
		{
			get { 
				return (SdtLaunchpadOptions_Option)Sdt;
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
				sdt = new SdtLaunchpadOptions_Option() ;
			}
		}
	}
	#endregion
}