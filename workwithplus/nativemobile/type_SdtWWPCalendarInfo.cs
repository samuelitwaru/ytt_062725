/*
				   File: type_SdtWWPCalendarInfo
			Description: WWPCalendarInfo
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
	[XmlRoot(ElementName="WWPCalendarInfo")]
	[XmlType(TypeName="WWPCalendarInfo" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWPCalendarInfo : GxUserType
	{
		public SdtWWPCalendarInfo( )
		{
			/* Constructor for serialization */
		}

		public SdtWWPCalendarInfo(IGxContext context)
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
			if (gxTv_SdtWWPCalendarInfo_Events != null)
			{
				AddObjectProperty("Events", gxTv_SdtWWPCalendarInfo_Events, false);
			}
			if (gxTv_SdtWWPCalendarInfo_Disabled != null)
			{
				AddObjectProperty("Disabled", gxTv_SdtWWPCalendarInfo_Disabled, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Events" )]
		[XmlArray(ElementName="Events"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry> gxTpr_Events_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWWPCalendarInfo_Events == null )
				{
					gxTv_SdtWWPCalendarInfo_Events = new GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry>( context, "WWPCalendarEntry", "");
				}
				return gxTv_SdtWWPCalendarInfo_Events;
			}
			set {
				gxTv_SdtWWPCalendarInfo_Events_N = false;
				gxTv_SdtWWPCalendarInfo_Events = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry> gxTpr_Events
		{
			get {
				if ( gxTv_SdtWWPCalendarInfo_Events == null )
				{
					gxTv_SdtWWPCalendarInfo_Events = new GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry>( context, "WWPCalendarEntry", "");
				}
				gxTv_SdtWWPCalendarInfo_Events_N = false;
				return gxTv_SdtWWPCalendarInfo_Events ;
			}
			set {
				gxTv_SdtWWPCalendarInfo_Events_N = false;
				gxTv_SdtWWPCalendarInfo_Events = value;
				SetDirty("Events");
			}
		}

		public void gxTv_SdtWWPCalendarInfo_Events_SetNull()
		{
			gxTv_SdtWWPCalendarInfo_Events_N = true;
			gxTv_SdtWWPCalendarInfo_Events = null;
		}

		public bool gxTv_SdtWWPCalendarInfo_Events_IsNull()
		{
			return gxTv_SdtWWPCalendarInfo_Events == null;
		}
		public bool ShouldSerializegxTpr_Events_GXBaseCollection_Json()
		{
			return gxTv_SdtWWPCalendarInfo_Events != null && gxTv_SdtWWPCalendarInfo_Events.Count > 0;

		}


		[SoapElement(ElementName="Disabled" )]
		[XmlArray(ElementName="Disabled"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry> gxTpr_Disabled_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWWPCalendarInfo_Disabled == null )
				{
					gxTv_SdtWWPCalendarInfo_Disabled = new GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry>( context, "WWPCalendarEntry", "");
				}
				return gxTv_SdtWWPCalendarInfo_Disabled;
			}
			set {
				gxTv_SdtWWPCalendarInfo_Disabled_N = false;
				gxTv_SdtWWPCalendarInfo_Disabled = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry> gxTpr_Disabled
		{
			get {
				if ( gxTv_SdtWWPCalendarInfo_Disabled == null )
				{
					gxTv_SdtWWPCalendarInfo_Disabled = new GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry>( context, "WWPCalendarEntry", "");
				}
				gxTv_SdtWWPCalendarInfo_Disabled_N = false;
				return gxTv_SdtWWPCalendarInfo_Disabled ;
			}
			set {
				gxTv_SdtWWPCalendarInfo_Disabled_N = false;
				gxTv_SdtWWPCalendarInfo_Disabled = value;
				SetDirty("Disabled");
			}
		}

		public void gxTv_SdtWWPCalendarInfo_Disabled_SetNull()
		{
			gxTv_SdtWWPCalendarInfo_Disabled_N = true;
			gxTv_SdtWWPCalendarInfo_Disabled = null;
		}

		public bool gxTv_SdtWWPCalendarInfo_Disabled_IsNull()
		{
			return gxTv_SdtWWPCalendarInfo_Disabled == null;
		}
		public bool ShouldSerializegxTpr_Disabled_GXBaseCollection_Json()
		{
			return gxTv_SdtWWPCalendarInfo_Disabled != null && gxTv_SdtWWPCalendarInfo_Disabled.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Events_GXBaseCollection_Json()|| 
				 ShouldSerializegxTpr_Disabled_GXBaseCollection_Json()||  
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
			gxTv_SdtWWPCalendarInfo_Events_N = true;


			gxTv_SdtWWPCalendarInfo_Disabled_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWWPCalendarInfo_Events_N;
		protected GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry> gxTv_SdtWWPCalendarInfo_Events = null;  
		protected bool gxTv_SdtWWPCalendarInfo_Disabled_N;
		protected GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry> gxTv_SdtWWPCalendarInfo_Disabled = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWPCalendarInfo", Namespace="YTT_version4")]
	public class SdtWWPCalendarInfo_RESTInterface : GxGenericCollectionItem<SdtWWPCalendarInfo>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPCalendarInfo_RESTInterface( ) : base()
		{	
		}

		public SdtWWPCalendarInfo_RESTInterface( SdtWWPCalendarInfo psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Events", Order=0, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry_RESTInterface> gxTpr_Events
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Events_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry_RESTInterface>(sdt.gxTpr_Events);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Events);
			}
		}

		[DataMember(Name="Disabled", Order=1, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry_RESTInterface> gxTpr_Disabled
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Disabled_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPCalendarEntry_RESTInterface>(sdt.gxTpr_Disabled);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Disabled);
			}
		}


		#endregion

		public SdtWWPCalendarInfo sdt
		{
			get { 
				return (SdtWWPCalendarInfo)Sdt;
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
				sdt = new SdtWWPCalendarInfo() ;
			}
		}
	}
	#endregion
}