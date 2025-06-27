/*
				   File: type_SdtMenuOptions_MenuOptionsItem
			Description: MenuOptions
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
	[XmlRoot(ElementName="MenuOptionsItem")]
	[XmlType(TypeName="MenuOptionsItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtMenuOptions_MenuOptionsItem : GxUserType
	{
		public SdtMenuOptions_MenuOptionsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtMenuOptions_MenuOptionsItem_Title = "";

			gxTv_SdtMenuOptions_MenuOptionsItem_Icon = "";
			gxTv_SdtMenuOptions_MenuOptionsItem_Icon_gxi = "";
			gxTv_SdtMenuOptions_MenuOptionsItem_Componenttocall = "";

			gxTv_SdtMenuOptions_MenuOptionsItem_Id = "";

			gxTv_SdtMenuOptions_MenuOptionsItem_Information = "";

			gxTv_SdtMenuOptions_MenuOptionsItem_Fonticon = "";

			gxTv_SdtMenuOptions_MenuOptionsItem_Fonticonclass = "";

		}

		public SdtMenuOptions_MenuOptionsItem(IGxContext context)
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
			AddObjectProperty("Title", gxTpr_Title, false);


			AddObjectProperty("Icon", gxTpr_Icon, false);
			AddObjectProperty("Icon_GXI", gxTpr_Icon_gxi, false);



			AddObjectProperty("Type", gxTpr_Type, false);


			AddObjectProperty("ComponentToCall", gxTpr_Componenttocall, false);


			AddObjectProperty("Id", gxTpr_Id, false);


			AddObjectProperty("IdNum", gxTpr_Idnum, false);


			AddObjectProperty("OrderIndex", gxTpr_Orderindex, false);


			AddObjectProperty("BadgeCount", gxTpr_Badgecount, false);


			AddObjectProperty("Information", gxTpr_Information, false);


			AddObjectProperty("FontIcon", gxTpr_Fonticon, false);


			AddObjectProperty("FontIconClass", gxTpr_Fonticonclass, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Title")]
		[XmlElement(ElementName="Title")]
		public string gxTpr_Title
		{
			get {
				return gxTv_SdtMenuOptions_MenuOptionsItem_Title; 
			}
			set {
				gxTv_SdtMenuOptions_MenuOptionsItem_Title = value;
				SetDirty("Title");
			}
		}




		[SoapElement(ElementName="Icon")]
		[XmlElement(ElementName="Icon")]
		[GxUpload()]

		public string gxTpr_Icon
		{
			get {
				return gxTv_SdtMenuOptions_MenuOptionsItem_Icon; 
			}
			set {
				gxTv_SdtMenuOptions_MenuOptionsItem_Icon = value;
				SetDirty("Icon");
			}
		}


		[SoapElement(ElementName="Icon_GXI" )]
		[XmlElement(ElementName="Icon_GXI" )]
		public string gxTpr_Icon_gxi
		{
			get {
				return gxTv_SdtMenuOptions_MenuOptionsItem_Icon_gxi ;
			}
			set {
				gxTv_SdtMenuOptions_MenuOptionsItem_Icon_gxi = value;
				SetDirty("Icon_gxi");
			}
		}

		[SoapElement(ElementName="Type")]
		[XmlElement(ElementName="Type")]
		public short gxTpr_Type
		{
			get {
				return gxTv_SdtMenuOptions_MenuOptionsItem_Type; 
			}
			set {
				gxTv_SdtMenuOptions_MenuOptionsItem_Type = value;
				SetDirty("Type");
			}
		}




		[SoapElement(ElementName="ComponentToCall")]
		[XmlElement(ElementName="ComponentToCall")]
		public string gxTpr_Componenttocall
		{
			get {
				return gxTv_SdtMenuOptions_MenuOptionsItem_Componenttocall; 
			}
			set {
				gxTv_SdtMenuOptions_MenuOptionsItem_Componenttocall = value;
				SetDirty("Componenttocall");
			}
		}




		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtMenuOptions_MenuOptionsItem_Id; 
			}
			set {
				gxTv_SdtMenuOptions_MenuOptionsItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="IdNum")]
		[XmlElement(ElementName="IdNum")]
		public short gxTpr_Idnum
		{
			get {
				return gxTv_SdtMenuOptions_MenuOptionsItem_Idnum; 
			}
			set {
				gxTv_SdtMenuOptions_MenuOptionsItem_Idnum = value;
				SetDirty("Idnum");
			}
		}




		[SoapElement(ElementName="OrderIndex")]
		[XmlElement(ElementName="OrderIndex")]
		public short gxTpr_Orderindex
		{
			get {
				return gxTv_SdtMenuOptions_MenuOptionsItem_Orderindex; 
			}
			set {
				gxTv_SdtMenuOptions_MenuOptionsItem_Orderindex = value;
				SetDirty("Orderindex");
			}
		}




		[SoapElement(ElementName="BadgeCount")]
		[XmlElement(ElementName="BadgeCount")]
		public short gxTpr_Badgecount
		{
			get {
				return gxTv_SdtMenuOptions_MenuOptionsItem_Badgecount; 
			}
			set {
				gxTv_SdtMenuOptions_MenuOptionsItem_Badgecount = value;
				SetDirty("Badgecount");
			}
		}




		[SoapElement(ElementName="Information")]
		[XmlElement(ElementName="Information")]
		public string gxTpr_Information
		{
			get {
				return gxTv_SdtMenuOptions_MenuOptionsItem_Information; 
			}
			set {
				gxTv_SdtMenuOptions_MenuOptionsItem_Information = value;
				SetDirty("Information");
			}
		}




		[SoapElement(ElementName="FontIcon")]
		[XmlElement(ElementName="FontIcon")]
		public string gxTpr_Fonticon
		{
			get {
				return gxTv_SdtMenuOptions_MenuOptionsItem_Fonticon; 
			}
			set {
				gxTv_SdtMenuOptions_MenuOptionsItem_Fonticon = value;
				SetDirty("Fonticon");
			}
		}




		[SoapElement(ElementName="FontIconClass")]
		[XmlElement(ElementName="FontIconClass")]
		public string gxTpr_Fonticonclass
		{
			get {
				return gxTv_SdtMenuOptions_MenuOptionsItem_Fonticonclass; 
			}
			set {
				gxTv_SdtMenuOptions_MenuOptionsItem_Fonticonclass = value;
				SetDirty("Fonticonclass");
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
			gxTv_SdtMenuOptions_MenuOptionsItem_Title = "";
			gxTv_SdtMenuOptions_MenuOptionsItem_Icon = "";gxTv_SdtMenuOptions_MenuOptionsItem_Icon_gxi = "";

			gxTv_SdtMenuOptions_MenuOptionsItem_Componenttocall = "";
			gxTv_SdtMenuOptions_MenuOptionsItem_Id = "";



			gxTv_SdtMenuOptions_MenuOptionsItem_Information = "";
			gxTv_SdtMenuOptions_MenuOptionsItem_Fonticon = "";
			gxTv_SdtMenuOptions_MenuOptionsItem_Fonticonclass = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtMenuOptions_MenuOptionsItem_Title;
		 
		protected string gxTv_SdtMenuOptions_MenuOptionsItem_Icon_gxi;
		protected string gxTv_SdtMenuOptions_MenuOptionsItem_Icon;
		 

		protected short gxTv_SdtMenuOptions_MenuOptionsItem_Type;
		 

		protected string gxTv_SdtMenuOptions_MenuOptionsItem_Componenttocall;
		 

		protected string gxTv_SdtMenuOptions_MenuOptionsItem_Id;
		 

		protected short gxTv_SdtMenuOptions_MenuOptionsItem_Idnum;
		 

		protected short gxTv_SdtMenuOptions_MenuOptionsItem_Orderindex;
		 

		protected short gxTv_SdtMenuOptions_MenuOptionsItem_Badgecount;
		 

		protected string gxTv_SdtMenuOptions_MenuOptionsItem_Information;
		 

		protected string gxTv_SdtMenuOptions_MenuOptionsItem_Fonticon;
		 

		protected string gxTv_SdtMenuOptions_MenuOptionsItem_Fonticonclass;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"MenuOptionsItem", Namespace="YTT_version4")]
	public class SdtMenuOptions_MenuOptionsItem_RESTInterface : GxGenericCollectionItem<SdtMenuOptions_MenuOptionsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtMenuOptions_MenuOptionsItem_RESTInterface( ) : base()
		{	
		}

		public SdtMenuOptions_MenuOptionsItem_RESTInterface( SdtMenuOptions_MenuOptionsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Title", Order=0)]
		public  string gxTpr_Title
		{
			get { 
				return sdt.gxTpr_Title;

			}
			set { 
				 sdt.gxTpr_Title = value;
			}
		}

		[DataMember(Name="Icon", Order=1)]
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

		[DataMember(Name="Type", Order=2)]
		public short gxTpr_Type
		{
			get { 
				return sdt.gxTpr_Type;

			}
			set { 
				sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="ComponentToCall", Order=3)]
		public  string gxTpr_Componenttocall
		{
			get { 
				return sdt.gxTpr_Componenttocall;

			}
			set { 
				 sdt.gxTpr_Componenttocall = value;
			}
		}

		[DataMember(Name="Id", Order=4)]
		public  string gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="IdNum", Order=5)]
		public short gxTpr_Idnum
		{
			get { 
				return sdt.gxTpr_Idnum;

			}
			set { 
				sdt.gxTpr_Idnum = value;
			}
		}

		[DataMember(Name="OrderIndex", Order=6)]
		public short gxTpr_Orderindex
		{
			get { 
				return sdt.gxTpr_Orderindex;

			}
			set { 
				sdt.gxTpr_Orderindex = value;
			}
		}

		[DataMember(Name="BadgeCount", Order=7)]
		public short gxTpr_Badgecount
		{
			get { 
				return sdt.gxTpr_Badgecount;

			}
			set { 
				sdt.gxTpr_Badgecount = value;
			}
		}

		[DataMember(Name="Information", Order=8)]
		public  string gxTpr_Information
		{
			get { 
				return sdt.gxTpr_Information;

			}
			set { 
				 sdt.gxTpr_Information = value;
			}
		}

		[DataMember(Name="FontIcon", Order=9)]
		public  string gxTpr_Fonticon
		{
			get { 
				return sdt.gxTpr_Fonticon;

			}
			set { 
				 sdt.gxTpr_Fonticon = value;
			}
		}

		[DataMember(Name="FontIconClass", Order=10)]
		public  string gxTpr_Fonticonclass
		{
			get { 
				return sdt.gxTpr_Fonticonclass;

			}
			set { 
				 sdt.gxTpr_Fonticonclass = value;
			}
		}


		#endregion

		public SdtMenuOptions_MenuOptionsItem sdt
		{
			get { 
				return (SdtMenuOptions_MenuOptionsItem)Sdt;
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
				sdt = new SdtMenuOptions_MenuOptionsItem() ;
			}
		}
	}
	#endregion
}