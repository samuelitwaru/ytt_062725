/*
				   File: type_SdtSDTLeaveEvent
			Description: SDTLeaveEvent
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
	[XmlRoot(ElementName="SDTLeaveEvent")]
	[XmlType(TypeName="SDTLeaveEvent" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTLeaveEvent : GxUserType
	{
		public SdtSDTLeaveEvent( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTLeaveEvent_Id = "";

			gxTv_SdtSDTLeaveEvent_Content = "";

			gxTv_SdtSDTLeaveEvent_Start = "";

			gxTv_SdtSDTLeaveEvent_End = "";

			gxTv_SdtSDTLeaveEvent_Classname = "";

			gxTv_SdtSDTLeaveEvent_Color = "";

			gxTv_SdtSDTLeaveEvent_Type = "";

		}

		public SdtSDTLeaveEvent(IGxContext context)
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


			AddObjectProperty("group", gxTpr_Group, false);


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
				return gxTv_SdtSDTLeaveEvent_Id; 
			}
			set {
				gxTv_SdtSDTLeaveEvent_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="content")]
		[XmlElement(ElementName="content")]
		public string gxTpr_Content
		{
			get {
				return gxTv_SdtSDTLeaveEvent_Content; 
			}
			set {
				gxTv_SdtSDTLeaveEvent_Content = value;
				SetDirty("Content");
			}
		}




		[SoapElement(ElementName="start")]
		[XmlElement(ElementName="start")]
		public string gxTpr_Start
		{
			get {
				return gxTv_SdtSDTLeaveEvent_Start; 
			}
			set {
				gxTv_SdtSDTLeaveEvent_Start = value;
				SetDirty("Start");
			}
		}




		[SoapElement(ElementName="end")]
		[XmlElement(ElementName="end")]
		public string gxTpr_End
		{
			get {
				return gxTv_SdtSDTLeaveEvent_End; 
			}
			set {
				gxTv_SdtSDTLeaveEvent_End = value;
				SetDirty("End");
			}
		}




		[SoapElement(ElementName="group")]
		[XmlElement(ElementName="group")]
		public short gxTpr_Group
		{
			get {
				return gxTv_SdtSDTLeaveEvent_Group; 
			}
			set {
				gxTv_SdtSDTLeaveEvent_Group = value;
				SetDirty("Group");
			}
		}




		[SoapElement(ElementName="className")]
		[XmlElement(ElementName="className")]
		public string gxTpr_Classname
		{
			get {
				return gxTv_SdtSDTLeaveEvent_Classname; 
			}
			set {
				gxTv_SdtSDTLeaveEvent_Classname = value;
				SetDirty("Classname");
			}
		}




		[SoapElement(ElementName="color")]
		[XmlElement(ElementName="color")]
		public string gxTpr_Color
		{
			get {
				return gxTv_SdtSDTLeaveEvent_Color; 
			}
			set {
				gxTv_SdtSDTLeaveEvent_Color = value;
				SetDirty("Color");
			}
		}




		[SoapElement(ElementName="type")]
		[XmlElement(ElementName="type")]
		public string gxTpr_Type
		{
			get {
				return gxTv_SdtSDTLeaveEvent_Type; 
			}
			set {
				gxTv_SdtSDTLeaveEvent_Type = value;
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
			gxTv_SdtSDTLeaveEvent_Id = "";
			gxTv_SdtSDTLeaveEvent_Content = "";
			gxTv_SdtSDTLeaveEvent_Start = "";
			gxTv_SdtSDTLeaveEvent_End = "";

			gxTv_SdtSDTLeaveEvent_Classname = "";
			gxTv_SdtSDTLeaveEvent_Color = "";
			gxTv_SdtSDTLeaveEvent_Type = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTLeaveEvent_Id;
		 

		protected string gxTv_SdtSDTLeaveEvent_Content;
		 

		protected string gxTv_SdtSDTLeaveEvent_Start;
		 

		protected string gxTv_SdtSDTLeaveEvent_End;
		 

		protected short gxTv_SdtSDTLeaveEvent_Group;
		 

		protected string gxTv_SdtSDTLeaveEvent_Classname;
		 

		protected string gxTv_SdtSDTLeaveEvent_Color;
		 

		protected string gxTv_SdtSDTLeaveEvent_Type;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTLeaveEvent", Namespace="YTT_version4")]
	public class SdtSDTLeaveEvent_RESTInterface : GxGenericCollectionItem<SdtSDTLeaveEvent>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTLeaveEvent_RESTInterface( ) : base()
		{	
		}

		public SdtSDTLeaveEvent_RESTInterface( SdtSDTLeaveEvent psdt ) : base(psdt)
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

		[DataMember(Name="group", Order=4)]
		public short gxTpr_Group
		{
			get { 
				return sdt.gxTpr_Group;

			}
			set { 
				sdt.gxTpr_Group = value;
			}
		}

		[DataMember(Name="className", Order=5)]
		public  string gxTpr_Classname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Classname);

			}
			set { 
				 sdt.gxTpr_Classname = value;
			}
		}

		[DataMember(Name="color", Order=6)]
		public  string gxTpr_Color
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Color);

			}
			set { 
				 sdt.gxTpr_Color = value;
			}
		}

		[DataMember(Name="type", Order=7)]
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

		public SdtSDTLeaveEvent sdt
		{
			get { 
				return (SdtSDTLeaveEvent)Sdt;
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
				sdt = new SdtSDTLeaveEvent() ;
			}
		}
	}
	#endregion
}