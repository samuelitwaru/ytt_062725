/*
				   File: type_SdtSDT_HolidayEvent
			Description: SDT_HolidayEvent
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
	[XmlRoot(ElementName="SDT_HolidayEvent")]
	[XmlType(TypeName="SDT_HolidayEvent" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDT_HolidayEvent : GxUserType
	{
		public SdtSDT_HolidayEvent( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_HolidayEvent_Id = "";

			gxTv_SdtSDT_HolidayEvent_Content = "";

			gxTv_SdtSDT_HolidayEvent_Start = "";

			gxTv_SdtSDT_HolidayEvent_End = "";

			gxTv_SdtSDT_HolidayEvent_Classname = "";

			gxTv_SdtSDT_HolidayEvent_Color = "";

			gxTv_SdtSDT_HolidayEvent_Type = "";

		}

		public SdtSDT_HolidayEvent(IGxContext context)
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
			AddObjectProperty("id", gxTpr_Id, false);


			AddObjectProperty("content", gxTpr_Content, false);


			AddObjectProperty("start", gxTpr_Start, false);


			AddObjectProperty("end", gxTpr_End, false);


			AddObjectProperty("className", gxTpr_Classname, false);


			AddObjectProperty("color", gxTpr_Color, false);


			AddObjectProperty("type", gxTpr_Type, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtSDT_HolidayEvent_Id; 
			}
			set {
				gxTv_SdtSDT_HolidayEvent_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="content")]
		[XmlElement(ElementName="content")]
		public string gxTpr_Content
		{
			get {
				return gxTv_SdtSDT_HolidayEvent_Content; 
			}
			set {
				gxTv_SdtSDT_HolidayEvent_Content = value;
				SetDirty("Content");
			}
		}




		[SoapElement(ElementName="start")]
		[XmlElement(ElementName="start")]
		public string gxTpr_Start
		{
			get {
				return gxTv_SdtSDT_HolidayEvent_Start; 
			}
			set {
				gxTv_SdtSDT_HolidayEvent_Start = value;
				SetDirty("Start");
			}
		}




		[SoapElement(ElementName="end")]
		[XmlElement(ElementName="end")]
		public string gxTpr_End
		{
			get {
				return gxTv_SdtSDT_HolidayEvent_End; 
			}
			set {
				gxTv_SdtSDT_HolidayEvent_End = value;
				SetDirty("End");
			}
		}




		[SoapElement(ElementName="className")]
		[XmlElement(ElementName="className")]
		public string gxTpr_Classname
		{
			get {
				return gxTv_SdtSDT_HolidayEvent_Classname; 
			}
			set {
				gxTv_SdtSDT_HolidayEvent_Classname = value;
				SetDirty("Classname");
			}
		}




		[SoapElement(ElementName="color")]
		[XmlElement(ElementName="color")]
		public string gxTpr_Color
		{
			get {
				return gxTv_SdtSDT_HolidayEvent_Color; 
			}
			set {
				gxTv_SdtSDT_HolidayEvent_Color = value;
				SetDirty("Color");
			}
		}




		[SoapElement(ElementName="type")]
		[XmlElement(ElementName="type")]
		public string gxTpr_Type
		{
			get {
				return gxTv_SdtSDT_HolidayEvent_Type; 
			}
			set {
				gxTv_SdtSDT_HolidayEvent_Type = value;
				SetDirty("Type");
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
			gxTv_SdtSDT_HolidayEvent_Id = "";
			gxTv_SdtSDT_HolidayEvent_Content = "";
			gxTv_SdtSDT_HolidayEvent_Start = "";
			gxTv_SdtSDT_HolidayEvent_End = "";
			gxTv_SdtSDT_HolidayEvent_Classname = "";
			gxTv_SdtSDT_HolidayEvent_Color = "";
			gxTv_SdtSDT_HolidayEvent_Type = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_HolidayEvent_Id;
		 

		protected string gxTv_SdtSDT_HolidayEvent_Content;
		 

		protected string gxTv_SdtSDT_HolidayEvent_Start;
		 

		protected string gxTv_SdtSDT_HolidayEvent_End;
		 

		protected string gxTv_SdtSDT_HolidayEvent_Classname;
		 

		protected string gxTv_SdtSDT_HolidayEvent_Color;
		 

		protected string gxTv_SdtSDT_HolidayEvent_Type;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_HolidayEvent", Namespace="YTT_version4")]
	public class SdtSDT_HolidayEvent_RESTInterface : GxGenericCollectionItem<SdtSDT_HolidayEvent>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_HolidayEvent_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_HolidayEvent_RESTInterface( SdtSDT_HolidayEvent psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="content", Order=1)]
		public  string gxTpr_Content
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Content);

			}
			set { 
				 sdt.gxTpr_Content = value;
			}
		}

		[DataMember(Name="start", Order=2)]
		public  string gxTpr_Start
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Start);

			}
			set { 
				 sdt.gxTpr_Start = value;
			}
		}

		[DataMember(Name="end", Order=3)]
		public  string gxTpr_End
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_End);

			}
			set { 
				 sdt.gxTpr_End = value;
			}
		}

		[DataMember(Name="className", Order=4)]
		public  string gxTpr_Classname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Classname);

			}
			set { 
				 sdt.gxTpr_Classname = value;
			}
		}

		[DataMember(Name="color", Order=5)]
		public  string gxTpr_Color
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Color);

			}
			set { 
				 sdt.gxTpr_Color = value;
			}
		}

		[DataMember(Name="type", Order=6)]
		public  string gxTpr_Type
		{
			get { 
				return sdt.gxTpr_Type;

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}


		#endregion

		public SdtSDT_HolidayEvent sdt
		{
			get { 
				return (SdtSDT_HolidayEvent)Sdt;
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
				sdt = new SdtSDT_HolidayEvent() ;
			}
		}
	}
	#endregion
}