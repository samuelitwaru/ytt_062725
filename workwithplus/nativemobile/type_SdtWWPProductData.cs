/*
				   File: type_SdtWWPProductData
			Description: WWPProductData
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
	[XmlRoot(ElementName="WWPProductData")]
	[XmlType(TypeName="WWPProductData" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWPProductData : GxUserType
	{
		public SdtWWPProductData( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPProductData_Id = "";

			gxTv_SdtWWPProductData_Title = "";

			gxTv_SdtWWPProductData_Description = "";

			gxTv_SdtWWPProductData_Image = "";
			gxTv_SdtWWPProductData_Image_gxi = "";
			gxTv_SdtWWPProductData_Subtitle = "";

			gxTv_SdtWWPProductData_Information1 = "";

			gxTv_SdtWWPProductData_Information2 = "";

			gxTv_SdtWWPProductData_Componenttocall = "";

		}

		public SdtWWPProductData(IGxContext context)
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
			AddObjectProperty("Id", gxTpr_Id, false);


			AddObjectProperty("Type", gxTpr_Type, false);


			AddObjectProperty("Title", gxTpr_Title, false);


			AddObjectProperty("Description", gxTpr_Description, false);


			AddObjectProperty("Image", gxTpr_Image, false);
			AddObjectProperty("Image_GXI", gxTpr_Image_gxi, false);



			AddObjectProperty("Subtitle", gxTpr_Subtitle, false);


			AddObjectProperty("Information1", gxTpr_Information1, false);


			AddObjectProperty("Information2", gxTpr_Information2, false);


			AddObjectProperty("ComponentToCall", gxTpr_Componenttocall, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtWWPProductData_Id; 
			}
			set {
				gxTv_SdtWWPProductData_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Type")]
		[XmlElement(ElementName="Type")]
		public short gxTpr_Type
		{
			get {
				return gxTv_SdtWWPProductData_Type; 
			}
			set {
				gxTv_SdtWWPProductData_Type = value;
				SetDirty("Type");
			}
		}




		[SoapElement(ElementName="Title")]
		[XmlElement(ElementName="Title")]
		public string gxTpr_Title
		{
			get {
				return gxTv_SdtWWPProductData_Title; 
			}
			set {
				gxTv_SdtWWPProductData_Title = value;
				SetDirty("Title");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtWWPProductData_Description; 
			}
			set {
				gxTv_SdtWWPProductData_Description = value;
				SetDirty("Description");
			}
		}




		[SoapElement(ElementName="Image")]
		[XmlElement(ElementName="Image")]
		[GxUpload()]

		public string gxTpr_Image
		{
			get {
				return gxTv_SdtWWPProductData_Image; 
			}
			set {
				gxTv_SdtWWPProductData_Image = value;
				SetDirty("Image");
			}
		}


		[SoapElement(ElementName="Image_GXI" )]
		[XmlElement(ElementName="Image_GXI" )]
		public string gxTpr_Image_gxi
		{
			get {
				return gxTv_SdtWWPProductData_Image_gxi ;
			}
			set {
				gxTv_SdtWWPProductData_Image_gxi = value;
				SetDirty("Image_gxi");
			}
		}

		[SoapElement(ElementName="Subtitle")]
		[XmlElement(ElementName="Subtitle")]
		public string gxTpr_Subtitle
		{
			get {
				return gxTv_SdtWWPProductData_Subtitle; 
			}
			set {
				gxTv_SdtWWPProductData_Subtitle = value;
				SetDirty("Subtitle");
			}
		}




		[SoapElement(ElementName="Information1")]
		[XmlElement(ElementName="Information1")]
		public string gxTpr_Information1
		{
			get {
				return gxTv_SdtWWPProductData_Information1; 
			}
			set {
				gxTv_SdtWWPProductData_Information1 = value;
				SetDirty("Information1");
			}
		}




		[SoapElement(ElementName="Information2")]
		[XmlElement(ElementName="Information2")]
		public string gxTpr_Information2
		{
			get {
				return gxTv_SdtWWPProductData_Information2; 
			}
			set {
				gxTv_SdtWWPProductData_Information2 = value;
				SetDirty("Information2");
			}
		}




		[SoapElement(ElementName="ComponentToCall")]
		[XmlElement(ElementName="ComponentToCall")]
		public string gxTpr_Componenttocall
		{
			get {
				return gxTv_SdtWWPProductData_Componenttocall; 
			}
			set {
				gxTv_SdtWWPProductData_Componenttocall = value;
				SetDirty("Componenttocall");
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
			gxTv_SdtWWPProductData_Id = "";

			gxTv_SdtWWPProductData_Title = "";
			gxTv_SdtWWPProductData_Description = "";
			gxTv_SdtWWPProductData_Image = "";gxTv_SdtWWPProductData_Image_gxi = "";
			gxTv_SdtWWPProductData_Subtitle = "";
			gxTv_SdtWWPProductData_Information1 = "";
			gxTv_SdtWWPProductData_Information2 = "";
			gxTv_SdtWWPProductData_Componenttocall = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWPProductData_Id;
		 

		protected short gxTv_SdtWWPProductData_Type;
		 

		protected string gxTv_SdtWWPProductData_Title;
		 

		protected string gxTv_SdtWWPProductData_Description;
		 
		protected string gxTv_SdtWWPProductData_Image_gxi;
		protected string gxTv_SdtWWPProductData_Image;
		 

		protected string gxTv_SdtWWPProductData_Subtitle;
		 

		protected string gxTv_SdtWWPProductData_Information1;
		 

		protected string gxTv_SdtWWPProductData_Information2;
		 

		protected string gxTv_SdtWWPProductData_Componenttocall;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWPProductData", Namespace="YTT_version4")]
	public class SdtWWPProductData_RESTInterface : GxGenericCollectionItem<SdtWWPProductData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPProductData_RESTInterface( ) : base()
		{	
		}

		public SdtWWPProductData_RESTInterface( SdtWWPProductData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="Type", Order=1)]
		public short gxTpr_Type
		{
			get { 
				return sdt.gxTpr_Type;

			}
			set { 
				sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="Title", Order=2)]
		public  string gxTpr_Title
		{
			get { 
				return sdt.gxTpr_Title;

			}
			set { 
				 sdt.gxTpr_Title = value;
			}
		}

		[DataMember(Name="Description", Order=3)]
		public  string gxTpr_Description
		{
			get { 
				return sdt.gxTpr_Description;

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}

		[DataMember(Name="Image", Order=4)]
		[GxUpload()]
		public  string gxTpr_Image
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Image)) ? PathUtil.RelativePath( sdt.gxTpr_Image) : StringUtil.RTrim( sdt.gxTpr_Image_gxi));

			}
			set { 
				 sdt.gxTpr_Image = value;
			}
		}

		[DataMember(Name="Subtitle", Order=5)]
		public  string gxTpr_Subtitle
		{
			get { 
				return sdt.gxTpr_Subtitle;

			}
			set { 
				 sdt.gxTpr_Subtitle = value;
			}
		}

		[DataMember(Name="Information1", Order=6)]
		public  string gxTpr_Information1
		{
			get { 
				return sdt.gxTpr_Information1;

			}
			set { 
				 sdt.gxTpr_Information1 = value;
			}
		}

		[DataMember(Name="Information2", Order=7)]
		public  string gxTpr_Information2
		{
			get { 
				return sdt.gxTpr_Information2;

			}
			set { 
				 sdt.gxTpr_Information2 = value;
			}
		}

		[DataMember(Name="ComponentToCall", Order=8)]
		public  string gxTpr_Componenttocall
		{
			get { 
				return sdt.gxTpr_Componenttocall;

			}
			set { 
				 sdt.gxTpr_Componenttocall = value;
			}
		}


		#endregion

		public SdtWWPProductData sdt
		{
			get { 
				return (SdtWWPProductData)Sdt;
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
				sdt = new SdtWWPProductData() ;
			}
		}
	}
	#endregion
}