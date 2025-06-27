/*
				   File: type_SdtSchedulerEvents
			Description: SchedulerEvents
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
	[XmlRoot(ElementName="data")]
	[XmlType(TypeName="data" , Namespace="" )]
	[Serializable]
	public class SdtSchedulerEvents : GxUserType
	{
		public SdtSchedulerEvents( )
		{
			/* Constructor for serialization */
		}

		public SdtSchedulerEvents(IGxContext context)
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
			if (gxTv_SdtSchedulerEvents_Items != null)
			{
				AddObjectProperty("Items", gxTv_SdtSchedulerEvents_Items, false);
			}
			if (gxTv_SdtSchedulerEvents_Specialdays != null)
			{
				AddObjectProperty("SpecialDays", gxTv_SdtSchedulerEvents_Specialdays, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName = "event" )]
		[XmlElement(ElementName = "event" )]
		public GXBaseCollection<SdtSchedulerEvents_event> gxTpr_Items
		{
			get {
				if ( gxTv_SdtSchedulerEvents_Items == null )
				{
					gxTv_SdtSchedulerEvents_Items = new GXBaseCollection<SdtSchedulerEvents_event>( context, "SchedulerEvents.event", "");
				}
				return gxTv_SdtSchedulerEvents_Items;
			}
			set {
				gxTv_SdtSchedulerEvents_Items_N = false;
				gxTv_SdtSchedulerEvents_Items = value;
				SetDirty("Items");
			}
		}

		public void gxTv_SdtSchedulerEvents_Items_SetNull()
		{
			gxTv_SdtSchedulerEvents_Items_N = true;
			gxTv_SdtSchedulerEvents_Items = null;
		}

		public bool gxTv_SdtSchedulerEvents_Items_IsNull()
		{
			return gxTv_SdtSchedulerEvents_Items == null;
		}
		public bool ShouldSerializegxTpr_Items_GxSimpleCollection_Json()
		{
			return gxTv_SdtSchedulerEvents_Items != null && gxTv_SdtSchedulerEvents_Items.Count > 0;

		}



		[SoapElement(ElementName = "Day" )]
		[XmlElement(ElementName = "Day" )]
		public GXBaseCollection<SdtSchedulerEvents_Day> gxTpr_Specialdays
		{
			get {
				if ( gxTv_SdtSchedulerEvents_Specialdays == null )
				{
					gxTv_SdtSchedulerEvents_Specialdays = new GXBaseCollection<SdtSchedulerEvents_Day>( context, "SchedulerEvents.Day", "");
				}
				return gxTv_SdtSchedulerEvents_Specialdays;
			}
			set {
				gxTv_SdtSchedulerEvents_Specialdays_N = false;
				gxTv_SdtSchedulerEvents_Specialdays = value;
				SetDirty("Specialdays");
			}
		}

		public void gxTv_SdtSchedulerEvents_Specialdays_SetNull()
		{
			gxTv_SdtSchedulerEvents_Specialdays_N = true;
			gxTv_SdtSchedulerEvents_Specialdays = null;
		}

		public bool gxTv_SdtSchedulerEvents_Specialdays_IsNull()
		{
			return gxTv_SdtSchedulerEvents_Specialdays == null;
		}
		public bool ShouldSerializegxTpr_Specialdays_GxSimpleCollection_Json()
		{
			return gxTv_SdtSchedulerEvents_Specialdays != null && gxTv_SdtSchedulerEvents_Specialdays.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Items_GxSimpleCollection_Json() ||
				ShouldSerializegxTpr_Specialdays_GxSimpleCollection_Json() || 
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
			gxTv_SdtSchedulerEvents_Items_N = true;


			gxTv_SdtSchedulerEvents_Specialdays_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSchedulerEvents_Items_N;
		protected GXBaseCollection<SdtSchedulerEvents_event> gxTv_SdtSchedulerEvents_Items = null; 

		protected bool gxTv_SdtSchedulerEvents_Specialdays_N;
		protected GXBaseCollection<SdtSchedulerEvents_Day> gxTv_SdtSchedulerEvents_Specialdays = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"data", Namespace="")]
	public class SdtSchedulerEvents_RESTInterface : GxGenericCollectionItem<SdtSchedulerEvents>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSchedulerEvents_RESTInterface( ) : base()
		{	
		}

		public SdtSchedulerEvents_RESTInterface( SdtSchedulerEvents psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Items", Order=0, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSchedulerEvents_event_RESTInterface> gxTpr_Items
		{
			get {
				if (sdt.ShouldSerializegxTpr_Items_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSchedulerEvents_event_RESTInterface>(sdt.gxTpr_Items);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Items);
			}
		}

		[DataMember(Name="SpecialDays", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSchedulerEvents_Day_RESTInterface> gxTpr_Specialdays
		{
			get {
				if (sdt.ShouldSerializegxTpr_Specialdays_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSchedulerEvents_Day_RESTInterface>(sdt.gxTpr_Specialdays);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Specialdays);
			}
		}


		#endregion

		public SdtSchedulerEvents sdt
		{
			get { 
				return (SdtSchedulerEvents)Sdt;
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
				sdt = new SdtSchedulerEvents() ;
			}
		}
	}
	#endregion
}