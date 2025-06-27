/*
				   File: type_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties
			Description: extendedProperties
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
	[XmlRoot(ElementName="LocationHoliDayUpdateSDT.itemsItem.extendedProperties")]
	[XmlType(TypeName="LocationHoliDayUpdateSDT.itemsItem.extendedProperties" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties : GxUserType
	{
		public SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties( )
		{
			/* Constructor for serialization */
		}

		public SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties(IGxContext context)
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
			if (gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private != null)
			{
				AddObjectProperty("private", gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="private" )]
		[XmlElement(ElementName="private" )]
		public SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private gxTpr_Private
		{
			get {
				if ( gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private == null )
				{
					gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private = new SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private(context);
				}
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private_N = false;
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private;
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private_N = false;
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private = value;
				SetDirty("Private");
			}

		}

		public void gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private_SetNull()
		{
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private_N = true;
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private = null;
		}

		public bool gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private_IsNull()
		{
			return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private == null;
		}
		public bool ShouldSerializegxTpr_Private_Json()
		{
				return (gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private != null && gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Private_Json() || 
				false);
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
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private_N;
		protected SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_Private = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"LocationHoliDayUpdateSDT.itemsItem.extendedProperties", Namespace="YTT_version4")]
	public class SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_RESTInterface : GxGenericCollectionItem<SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_RESTInterface( ) : base()
		{	
		}

		public SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_RESTInterface( SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="private", Order=0, EmitDefaultValue=false)]
		public SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private_RESTInterface gxTpr_Private
		{
			get {
				if (sdt.ShouldSerializegxTpr_Private_Json())
					return new SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_private_RESTInterface(sdt.gxTpr_Private);
				else
					return null;

			}

			set {
				sdt.gxTpr_Private = value.sdt;
			}

		}


		#endregion

		public SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties sdt
		{
			get { 
				return (SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties)Sdt;
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
				sdt = new SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties() ;
			}
		}
	}
	#endregion
}