/*
				   File: type_SdtLocationHoliDayUpdateSDT_itemsItem_creator
			Description: creator
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
	[XmlRoot(ElementName="LocationHoliDayUpdateSDT.itemsItem.creator")]
	[XmlType(TypeName="LocationHoliDayUpdateSDT.itemsItem.creator" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtLocationHoliDayUpdateSDT_itemsItem_creator : GxUserType
	{
		public SdtLocationHoliDayUpdateSDT_itemsItem_creator( )
		{
			/* Constructor for serialization */
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_creator_Email = "";

			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_creator_Displayname = "";

		}

		public SdtLocationHoliDayUpdateSDT_itemsItem_creator(IGxContext context)
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
			AddObjectProperty("email", gxTpr_Email, false);


			AddObjectProperty("displayName", gxTpr_Displayname, false);


			AddObjectProperty("self", gxTpr_Self, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="email")]
		[XmlElement(ElementName="email")]
		public string gxTpr_Email
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_creator_Email; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_creator_Email = value;
				SetDirty("Email");
			}
		}




		[SoapElement(ElementName="displayName")]
		[XmlElement(ElementName="displayName")]
		public string gxTpr_Displayname
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_creator_Displayname; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_creator_Displayname = value;
				SetDirty("Displayname");
			}
		}




		[SoapElement(ElementName="self")]
		[XmlElement(ElementName="self")]
		public bool gxTpr_Self
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_creator_Self; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_creator_Self = value;
				SetDirty("Self");
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
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_creator_Email = "";
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_creator_Displayname = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_creator_Email;
		 

		protected string gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_creator_Displayname;
		 

		protected bool gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_creator_Self;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"LocationHoliDayUpdateSDT.itemsItem.creator", Namespace="YTT_version4")]
	public class SdtLocationHoliDayUpdateSDT_itemsItem_creator_RESTInterface : GxGenericCollectionItem<SdtLocationHoliDayUpdateSDT_itemsItem_creator>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtLocationHoliDayUpdateSDT_itemsItem_creator_RESTInterface( ) : base()
		{	
		}

		public SdtLocationHoliDayUpdateSDT_itemsItem_creator_RESTInterface( SdtLocationHoliDayUpdateSDT_itemsItem_creator psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="email", Order=0)]
		public  string gxTpr_Email
		{
			get { 
				return sdt.gxTpr_Email;

			}
			set { 
				 sdt.gxTpr_Email = value;
			}
		}

		[DataMember(Name="displayName", Order=1)]
		public  string gxTpr_Displayname
		{
			get { 
				return sdt.gxTpr_Displayname;

			}
			set { 
				 sdt.gxTpr_Displayname = value;
			}
		}

		[DataMember(Name="self", Order=2)]
		public bool gxTpr_Self
		{
			get { 
				return sdt.gxTpr_Self;

			}
			set { 
				sdt.gxTpr_Self = value;
			}
		}


		#endregion

		public SdtLocationHoliDayUpdateSDT_itemsItem_creator sdt
		{
			get { 
				return (SdtLocationHoliDayUpdateSDT_itemsItem_creator)Sdt;
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
				sdt = new SdtLocationHoliDayUpdateSDT_itemsItem_creator() ;
			}
		}
	}
	#endregion
}