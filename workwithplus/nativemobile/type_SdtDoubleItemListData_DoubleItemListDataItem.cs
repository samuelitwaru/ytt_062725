/*
				   File: type_SdtDoubleItemListData_DoubleItemListDataItem
			Description: DoubleItemListData
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
	[XmlRoot(ElementName="DoubleItemListDataItem")]
	[XmlType(TypeName="DoubleItemListDataItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtDoubleItemListData_DoubleItemListDataItem : GxUserType
	{
		public SdtDoubleItemListData_DoubleItemListDataItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1title = "";

			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1image = "";
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1image_gxi = "";
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1subtitle = "";

			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1information1 = "";

			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1information2 = "";

			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1id = "";

			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1componenttocall = "";

			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2title = "";

			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2image = "";
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2image_gxi = "";
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2subtitle = "";

			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2id = "";

			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2componenttocall = "";

			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2information1 = "";

			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2information2 = "";

		}

		public SdtDoubleItemListData_DoubleItemListDataItem(IGxContext context)
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
			AddObjectProperty("Type", gxTpr_Type, false);


			AddObjectProperty("Option1Title", gxTpr_Option1title, false);


			AddObjectProperty("Option1Image", gxTpr_Option1image, false);
			AddObjectProperty("Option1Image_GXI", gxTpr_Option1image_gxi, false);



			AddObjectProperty("Option1Subtitle", gxTpr_Option1subtitle, false);


			AddObjectProperty("Option1Information1", gxTpr_Option1information1, false);


			AddObjectProperty("Option1Information2", gxTpr_Option1information2, false);


			AddObjectProperty("Option1Id", gxTpr_Option1id, false);


			AddObjectProperty("Option1ComponentToCall", gxTpr_Option1componenttocall, false);


			AddObjectProperty("Option2Title", gxTpr_Option2title, false);


			AddObjectProperty("Option2Image", gxTpr_Option2image, false);
			AddObjectProperty("Option2Image_GXI", gxTpr_Option2image_gxi, false);



			AddObjectProperty("Option2Subtitle", gxTpr_Option2subtitle, false);


			AddObjectProperty("Option2Id", gxTpr_Option2id, false);


			AddObjectProperty("Option2ComponentToCall", gxTpr_Option2componenttocall, false);


			AddObjectProperty("Option2Information1", gxTpr_Option2information1, false);


			AddObjectProperty("Option2Information2", gxTpr_Option2information2, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Type")]
		[XmlElement(ElementName="Type")]
		public short gxTpr_Type
		{
			get {
				return gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Type; 
			}
			set {
				gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Type = value;
				SetDirty("Type");
			}
		}




		[SoapElement(ElementName="Option1Title")]
		[XmlElement(ElementName="Option1Title")]
		public string gxTpr_Option1title
		{
			get {
				return gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1title; 
			}
			set {
				gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1title = value;
				SetDirty("Option1title");
			}
		}




		[SoapElement(ElementName="Option1Image")]
		[XmlElement(ElementName="Option1Image")]
		[GxUpload()]

		public string gxTpr_Option1image
		{
			get {
				return gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1image; 
			}
			set {
				gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1image = value;
				SetDirty("Option1image");
			}
		}


		[SoapElement(ElementName="Option1Image_GXI" )]
		[XmlElement(ElementName="Option1Image_GXI" )]
		public string gxTpr_Option1image_gxi
		{
			get {
				return gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1image_gxi ;
			}
			set {
				gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1image_gxi = value;
				SetDirty("Option1image_gxi");
			}
		}

		[SoapElement(ElementName="Option1Subtitle")]
		[XmlElement(ElementName="Option1Subtitle")]
		public string gxTpr_Option1subtitle
		{
			get {
				return gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1subtitle; 
			}
			set {
				gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1subtitle = value;
				SetDirty("Option1subtitle");
			}
		}




		[SoapElement(ElementName="Option1Information1")]
		[XmlElement(ElementName="Option1Information1")]
		public string gxTpr_Option1information1
		{
			get {
				return gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1information1; 
			}
			set {
				gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1information1 = value;
				SetDirty("Option1information1");
			}
		}




		[SoapElement(ElementName="Option1Information2")]
		[XmlElement(ElementName="Option1Information2")]
		public string gxTpr_Option1information2
		{
			get {
				return gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1information2; 
			}
			set {
				gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1information2 = value;
				SetDirty("Option1information2");
			}
		}




		[SoapElement(ElementName="Option1Id")]
		[XmlElement(ElementName="Option1Id")]
		public string gxTpr_Option1id
		{
			get {
				return gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1id; 
			}
			set {
				gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1id = value;
				SetDirty("Option1id");
			}
		}




		[SoapElement(ElementName="Option1ComponentToCall")]
		[XmlElement(ElementName="Option1ComponentToCall")]
		public string gxTpr_Option1componenttocall
		{
			get {
				return gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1componenttocall; 
			}
			set {
				gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1componenttocall = value;
				SetDirty("Option1componenttocall");
			}
		}




		[SoapElement(ElementName="Option2Title")]
		[XmlElement(ElementName="Option2Title")]
		public string gxTpr_Option2title
		{
			get {
				return gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2title; 
			}
			set {
				gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2title = value;
				SetDirty("Option2title");
			}
		}




		[SoapElement(ElementName="Option2Image")]
		[XmlElement(ElementName="Option2Image")]
		[GxUpload()]

		public string gxTpr_Option2image
		{
			get {
				return gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2image; 
			}
			set {
				gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2image = value;
				SetDirty("Option2image");
			}
		}


		[SoapElement(ElementName="Option2Image_GXI" )]
		[XmlElement(ElementName="Option2Image_GXI" )]
		public string gxTpr_Option2image_gxi
		{
			get {
				return gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2image_gxi ;
			}
			set {
				gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2image_gxi = value;
				SetDirty("Option2image_gxi");
			}
		}

		[SoapElement(ElementName="Option2Subtitle")]
		[XmlElement(ElementName="Option2Subtitle")]
		public string gxTpr_Option2subtitle
		{
			get {
				return gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2subtitle; 
			}
			set {
				gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2subtitle = value;
				SetDirty("Option2subtitle");
			}
		}




		[SoapElement(ElementName="Option2Id")]
		[XmlElement(ElementName="Option2Id")]
		public string gxTpr_Option2id
		{
			get {
				return gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2id; 
			}
			set {
				gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2id = value;
				SetDirty("Option2id");
			}
		}




		[SoapElement(ElementName="Option2ComponentToCall")]
		[XmlElement(ElementName="Option2ComponentToCall")]
		public string gxTpr_Option2componenttocall
		{
			get {
				return gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2componenttocall; 
			}
			set {
				gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2componenttocall = value;
				SetDirty("Option2componenttocall");
			}
		}




		[SoapElement(ElementName="Option2Information1")]
		[XmlElement(ElementName="Option2Information1")]
		public string gxTpr_Option2information1
		{
			get {
				return gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2information1; 
			}
			set {
				gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2information1 = value;
				SetDirty("Option2information1");
			}
		}




		[SoapElement(ElementName="Option2Information2")]
		[XmlElement(ElementName="Option2Information2")]
		public string gxTpr_Option2information2
		{
			get {
				return gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2information2; 
			}
			set {
				gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2information2 = value;
				SetDirty("Option2information2");
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
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1title = "";
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1image = "";gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1image_gxi = "";
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1subtitle = "";
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1information1 = "";
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1information2 = "";
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1id = "";
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1componenttocall = "";
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2title = "";
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2image = "";gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2image_gxi = "";
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2subtitle = "";
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2id = "";
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2componenttocall = "";
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2information1 = "";
			gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2information2 = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Type;
		 

		protected string gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1title;
		 
		protected string gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1image_gxi;
		protected string gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1image;
		 

		protected string gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1subtitle;
		 

		protected string gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1information1;
		 

		protected string gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1information2;
		 

		protected string gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1id;
		 

		protected string gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option1componenttocall;
		 

		protected string gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2title;
		 
		protected string gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2image_gxi;
		protected string gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2image;
		 

		protected string gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2subtitle;
		 

		protected string gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2id;
		 

		protected string gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2componenttocall;
		 

		protected string gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2information1;
		 

		protected string gxTv_SdtDoubleItemListData_DoubleItemListDataItem_Option2information2;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"DoubleItemListDataItem", Namespace="YTT_version4")]
	public class SdtDoubleItemListData_DoubleItemListDataItem_RESTInterface : GxGenericCollectionItem<SdtDoubleItemListData_DoubleItemListDataItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtDoubleItemListData_DoubleItemListDataItem_RESTInterface( ) : base()
		{	
		}

		public SdtDoubleItemListData_DoubleItemListDataItem_RESTInterface( SdtDoubleItemListData_DoubleItemListDataItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Type", Order=0)]
		public short gxTpr_Type
		{
			get { 
				return sdt.gxTpr_Type;

			}
			set { 
				sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="Option1Title", Order=1)]
		public  string gxTpr_Option1title
		{
			get { 
				return sdt.gxTpr_Option1title;

			}
			set { 
				 sdt.gxTpr_Option1title = value;
			}
		}

		[DataMember(Name="Option1Image", Order=2)]
		[GxUpload()]
		public  string gxTpr_Option1image
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Option1image)) ? PathUtil.RelativePath( sdt.gxTpr_Option1image) : StringUtil.RTrim( sdt.gxTpr_Option1image_gxi));

			}
			set { 
				 sdt.gxTpr_Option1image = value;
			}
		}

		[DataMember(Name="Option1Subtitle", Order=3)]
		public  string gxTpr_Option1subtitle
		{
			get { 
				return sdt.gxTpr_Option1subtitle;

			}
			set { 
				 sdt.gxTpr_Option1subtitle = value;
			}
		}

		[DataMember(Name="Option1Information1", Order=4)]
		public  string gxTpr_Option1information1
		{
			get { 
				return sdt.gxTpr_Option1information1;

			}
			set { 
				 sdt.gxTpr_Option1information1 = value;
			}
		}

		[DataMember(Name="Option1Information2", Order=5)]
		public  string gxTpr_Option1information2
		{
			get { 
				return sdt.gxTpr_Option1information2;

			}
			set { 
				 sdt.gxTpr_Option1information2 = value;
			}
		}

		[DataMember(Name="Option1Id", Order=6)]
		public  string gxTpr_Option1id
		{
			get { 
				return sdt.gxTpr_Option1id;

			}
			set { 
				 sdt.gxTpr_Option1id = value;
			}
		}

		[DataMember(Name="Option1ComponentToCall", Order=7)]
		public  string gxTpr_Option1componenttocall
		{
			get { 
				return sdt.gxTpr_Option1componenttocall;

			}
			set { 
				 sdt.gxTpr_Option1componenttocall = value;
			}
		}

		[DataMember(Name="Option2Title", Order=8)]
		public  string gxTpr_Option2title
		{
			get { 
				return sdt.gxTpr_Option2title;

			}
			set { 
				 sdt.gxTpr_Option2title = value;
			}
		}

		[DataMember(Name="Option2Image", Order=9)]
		[GxUpload()]
		public  string gxTpr_Option2image
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Option2image)) ? PathUtil.RelativePath( sdt.gxTpr_Option2image) : StringUtil.RTrim( sdt.gxTpr_Option2image_gxi));

			}
			set { 
				 sdt.gxTpr_Option2image = value;
			}
		}

		[DataMember(Name="Option2Subtitle", Order=10)]
		public  string gxTpr_Option2subtitle
		{
			get { 
				return sdt.gxTpr_Option2subtitle;

			}
			set { 
				 sdt.gxTpr_Option2subtitle = value;
			}
		}

		[DataMember(Name="Option2Id", Order=11)]
		public  string gxTpr_Option2id
		{
			get { 
				return sdt.gxTpr_Option2id;

			}
			set { 
				 sdt.gxTpr_Option2id = value;
			}
		}

		[DataMember(Name="Option2ComponentToCall", Order=12)]
		public  string gxTpr_Option2componenttocall
		{
			get { 
				return sdt.gxTpr_Option2componenttocall;

			}
			set { 
				 sdt.gxTpr_Option2componenttocall = value;
			}
		}

		[DataMember(Name="Option2Information1", Order=13)]
		public  string gxTpr_Option2information1
		{
			get { 
				return sdt.gxTpr_Option2information1;

			}
			set { 
				 sdt.gxTpr_Option2information1 = value;
			}
		}

		[DataMember(Name="Option2Information2", Order=14)]
		public  string gxTpr_Option2information2
		{
			get { 
				return sdt.gxTpr_Option2information2;

			}
			set { 
				 sdt.gxTpr_Option2information2 = value;
			}
		}


		#endregion

		public SdtDoubleItemListData_DoubleItemListDataItem sdt
		{
			get { 
				return (SdtDoubleItemListData_DoubleItemListDataItem)Sdt;
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
				sdt = new SdtDoubleItemListData_DoubleItemListDataItem() ;
			}
		}
	}
	#endregion
}