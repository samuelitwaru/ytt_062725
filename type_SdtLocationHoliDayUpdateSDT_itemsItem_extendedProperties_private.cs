/*
				   File: type_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private
			Description: private
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
	[XmlRoot(ElementName="LocationHoliDayUpdateSDT.itemsItem.extendedProperties.private")]
	[XmlType(TypeName="LocationHoliDayUpdateSDT.itemsItem.extendedProperties.private" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private : GxUserType
	{
		public SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private( )
		{
			/* Constructor for serialization */
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private_Item_0 = "";

			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private_Item_1 = "";

		}

		public SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private(IGxContext context)
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
				mapper["EXTERNAL-HOLIDAY-ID"] = "Item_0";
				mapper["INTERNAL-HOLIDAY-TYPE"] = "Item_1";

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
			AddObjectProperty("EXTERNAL-HOLIDAY-ID", gxTpr_Item_0, false);


			AddObjectProperty("INTERNAL-HOLIDAY-TYPE", gxTpr_Item_1, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Item_0")]
		[XmlElement(ElementName="Item_0")]
		public string gxTpr_Item_0
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private_Item_0; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private_Item_0 = value;
				SetDirty("Item_0");
			}
		}




		[SoapElement(ElementName="Item_1")]
		[XmlElement(ElementName="Item_1")]
		public string gxTpr_Item_1
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private_Item_1; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private_Item_1 = value;
				SetDirty("Item_1");
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
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private_Item_0 = "";
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private_Item_1 = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private_Item_0;
		 

		protected string gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private_Item_1;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"LocationHoliDayUpdateSDT.itemsItem.extendedProperties.private", Namespace="YTT_version4")]
	public class SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private_RESTInterface : GxGenericCollectionItem<SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private_RESTInterface( ) : base()
		{	
		}

		public SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private_RESTInterface( SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="EXTERNAL-HOLIDAY-ID", Order=0)]
		public  string gxTpr_Item_0
		{
			get { 
				return sdt.gxTpr_Item_0;

			}
			set { 
				 sdt.gxTpr_Item_0 = value;
			}
		}

		[DataMember(Name="INTERNAL-HOLIDAY-TYPE", Order=1)]
		public  string gxTpr_Item_1
		{
			get { 
				return sdt.gxTpr_Item_1;

			}
			set { 
				 sdt.gxTpr_Item_1 = value;
			}
		}


		#endregion

		public SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private sdt
		{
			get { 
				return (SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private)Sdt;
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
				sdt = new SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private() ;
			}
		}
	}
	#endregion
}