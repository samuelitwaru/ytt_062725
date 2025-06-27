/*
				   File: type_SdtLocationHoliDayUpdateSDT_itemsItem
			Description: items
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
	[XmlRoot(ElementName="LocationHoliDayUpdateSDT.itemsItem")]
	[XmlType(TypeName="LocationHoliDayUpdateSDT.itemsItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtLocationHoliDayUpdateSDT_itemsItem : GxUserType
	{
		public SdtLocationHoliDayUpdateSDT_itemsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Kind = "";

			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Etag = "";

			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Id = "";

			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Status = "";

			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Htmllink = "";

			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Created = (DateTime)(DateTime.MinValue);

			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Updated = (DateTime)(DateTime.MinValue);

			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Summary = "";

			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Description = "";

			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Transparency = "";

			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Visibility = "";

			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Icaluid = "";

			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Eventtype = "";

		}

		public SdtLocationHoliDayUpdateSDT_itemsItem(IGxContext context)
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
			AddObjectProperty("kind", gxTpr_Kind, false);


			AddObjectProperty("etag", gxTpr_Etag, false);


			AddObjectProperty("id", gxTpr_Id, false);


			AddObjectProperty("status", gxTpr_Status, false);


			AddObjectProperty("htmlLink", gxTpr_Htmllink, false);


			datetime_STZ = gxTpr_Created;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("created", sDateCnv, false);



			datetime_STZ = gxTpr_Updated;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("updated", sDateCnv, false);



			AddObjectProperty("summary", gxTpr_Summary, false);


			AddObjectProperty("description", gxTpr_Description, false);

			if (gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator != null)
			{
				AddObjectProperty("creator", gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator, false);
			}
			if (gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer != null)
			{
				AddObjectProperty("organizer", gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer, false);
			}
			if (gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start != null)
			{
				AddObjectProperty("start", gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start, false);
			}
			if (gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End != null)
			{
				AddObjectProperty("end", gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End, false);
			}

			AddObjectProperty("transparency", gxTpr_Transparency, false);


			AddObjectProperty("visibility", gxTpr_Visibility, false);


			AddObjectProperty("iCalUID", gxTpr_Icaluid, false);


			AddObjectProperty("sequence", gxTpr_Sequence, false);

			if (gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties != null)
			{
				AddObjectProperty("extendedProperties", gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties, false);
			}

			AddObjectProperty("eventType", gxTpr_Eventtype, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="kind")]
		[XmlElement(ElementName="kind")]
		public string gxTpr_Kind
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Kind; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Kind = value;
				SetDirty("Kind");
			}
		}




		[SoapElement(ElementName="etag")]
		[XmlElement(ElementName="etag")]
		public string gxTpr_Etag
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Etag; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Etag = value;
				SetDirty("Etag");
			}
		}




		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Id; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="status")]
		[XmlElement(ElementName="status")]
		public string gxTpr_Status
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Status; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Status = value;
				SetDirty("Status");
			}
		}




		[SoapElement(ElementName="htmlLink")]
		[XmlElement(ElementName="htmlLink")]
		public string gxTpr_Htmllink
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Htmllink; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Htmllink = value;
				SetDirty("Htmllink");
			}
		}



		[SoapElement(ElementName="created")]
		[XmlElement(ElementName="created" , IsNullable=true)]
		public string gxTpr_Created_Nullable
		{
			get {
				if ( gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Created == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Created).value ;
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Created = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Created
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Created; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Created = value;
				SetDirty("Created");
			}
		}


		[SoapElement(ElementName="updated")]
		[XmlElement(ElementName="updated" , IsNullable=true)]
		public string gxTpr_Updated_Nullable
		{
			get {
				if ( gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Updated == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Updated).value ;
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Updated = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Updated
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Updated; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Updated = value;
				SetDirty("Updated");
			}
		}



		[SoapElement(ElementName="summary")]
		[XmlElement(ElementName="summary")]
		public string gxTpr_Summary
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Summary; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Summary = value;
				SetDirty("Summary");
			}
		}




		[SoapElement(ElementName="description")]
		[XmlElement(ElementName="description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Description; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Description = value;
				SetDirty("Description");
			}
		}



		[SoapElement(ElementName="creator" )]
		[XmlElement(ElementName="creator" )]
		public SdtLocationHoliDayUpdateSDT_itemsItem_creator gxTpr_Creator
		{
			get {
				if ( gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator == null )
				{
					gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator = new SdtLocationHoliDayUpdateSDT_itemsItem_creator(context);
				}
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator_N = false;
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator;
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator_N = false;
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator = value;
				SetDirty("Creator");
			}

		}

		public void gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator_SetNull()
		{
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator_N = true;
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator = null;
		}

		public bool gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator_IsNull()
		{
			return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator == null;
		}
		public bool ShouldSerializegxTpr_Creator_Json()
		{
				return (gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator != null && gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="organizer" )]
		[XmlElement(ElementName="organizer" )]
		public SdtLocationHoliDayUpdateSDT_itemsItem_organizer gxTpr_Organizer
		{
			get {
				if ( gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer == null )
				{
					gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer = new SdtLocationHoliDayUpdateSDT_itemsItem_organizer(context);
				}
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer_N = false;
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer;
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer_N = false;
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer = value;
				SetDirty("Organizer");
			}

		}

		public void gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer_SetNull()
		{
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer_N = true;
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer = null;
		}

		public bool gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer_IsNull()
		{
			return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer == null;
		}
		public bool ShouldSerializegxTpr_Organizer_Json()
		{
				return (gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer != null && gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="start" )]
		[XmlElement(ElementName="start" )]
		public SdtLocationHoliDayUpdateSDT_itemsItem_start gxTpr_Start
		{
			get {
				if ( gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start == null )
				{
					gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start = new SdtLocationHoliDayUpdateSDT_itemsItem_start(context);
				}
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start_N = false;
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start;
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start_N = false;
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start = value;
				SetDirty("Start");
			}

		}

		public void gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start_SetNull()
		{
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start_N = true;
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start = null;
		}

		public bool gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start_IsNull()
		{
			return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start == null;
		}
		public bool ShouldSerializegxTpr_Start_Json()
		{
				return (gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start != null && gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="end" )]
		[XmlElement(ElementName="end" )]
		public SdtLocationHoliDayUpdateSDT_itemsItem_end gxTpr_End
		{
			get {
				if ( gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End == null )
				{
					gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End = new SdtLocationHoliDayUpdateSDT_itemsItem_end(context);
				}
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End_N = false;
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End;
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End_N = false;
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End = value;
				SetDirty("End");
			}

		}

		public void gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End_SetNull()
		{
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End_N = true;
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End = null;
		}

		public bool gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End_IsNull()
		{
			return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End == null;
		}
		public bool ShouldSerializegxTpr_End_Json()
		{
				return (gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End != null && gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="transparency")]
		[XmlElement(ElementName="transparency")]
		public string gxTpr_Transparency
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Transparency; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Transparency = value;
				SetDirty("Transparency");
			}
		}




		[SoapElement(ElementName="visibility")]
		[XmlElement(ElementName="visibility")]
		public string gxTpr_Visibility
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Visibility; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Visibility = value;
				SetDirty("Visibility");
			}
		}




		[SoapElement(ElementName="iCalUID")]
		[XmlElement(ElementName="iCalUID")]
		public string gxTpr_Icaluid
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Icaluid; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Icaluid = value;
				SetDirty("Icaluid");
			}
		}



		[SoapElement(ElementName="sequence")]
		[XmlElement(ElementName="sequence")]
		public string gxTpr_Sequence_double
		{
			get {
				return Convert.ToString(gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Sequence, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Sequence = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Sequence
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Sequence; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Sequence = value;
				SetDirty("Sequence");
			}
		}



		[SoapElement(ElementName="extendedProperties" )]
		[XmlElement(ElementName="extendedProperties" )]
		public SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties gxTpr_Extendedproperties
		{
			get {
				if ( gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties == null )
				{
					gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties = new SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties(context);
				}
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties_N = false;
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties;
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties_N = false;
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties = value;
				SetDirty("Extendedproperties");
			}

		}

		public void gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties_SetNull()
		{
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties_N = true;
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties = null;
		}

		public bool gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties_IsNull()
		{
			return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties == null;
		}
		public bool ShouldSerializegxTpr_Extendedproperties_Json()
		{
				return (gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties != null && gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="eventType")]
		[XmlElement(ElementName="eventType")]
		public string gxTpr_Eventtype
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Eventtype; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Eventtype = value;
				SetDirty("Eventtype");
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
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Kind = "";
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Etag = "";
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Id = "";
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Status = "";
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Htmllink = "";
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Created = (DateTime)(DateTime.MinValue);
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Updated = (DateTime)(DateTime.MinValue);
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Summary = "";
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Description = "";

			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator_N = true;


			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer_N = true;


			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start_N = true;


			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End_N = true;

			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Transparency = "";
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Visibility = "";
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Icaluid = "";


			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties_N = true;

			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Eventtype = "";
			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected string gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Kind;
		 

		protected string gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Etag;
		 

		protected string gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Id;
		 

		protected string gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Status;
		 

		protected string gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Htmllink;
		 

		protected DateTime gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Created;
		 

		protected DateTime gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Updated;
		 

		protected string gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Summary;
		 

		protected string gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Description;
		 
		protected bool gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator_N;
		protected SdtLocationHoliDayUpdateSDT_itemsItem_creator gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Creator = null; 

		protected bool gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer_N;
		protected SdtLocationHoliDayUpdateSDT_itemsItem_organizer gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Organizer = null; 

		protected bool gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start_N;
		protected SdtLocationHoliDayUpdateSDT_itemsItem_start gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Start = null; 

		protected bool gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End_N;
		protected SdtLocationHoliDayUpdateSDT_itemsItem_end gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_End = null; 


		protected string gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Transparency;
		 

		protected string gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Visibility;
		 

		protected string gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Icaluid;
		 

		protected decimal gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Sequence;
		 
		protected bool gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties_N;
		protected SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Extendedproperties = null; 


		protected string gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_Eventtype;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"LocationHoliDayUpdateSDT.itemsItem", Namespace="YTT_version4")]
	public class SdtLocationHoliDayUpdateSDT_itemsItem_RESTInterface : GxGenericCollectionItem<SdtLocationHoliDayUpdateSDT_itemsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtLocationHoliDayUpdateSDT_itemsItem_RESTInterface( ) : base()
		{	
		}

		public SdtLocationHoliDayUpdateSDT_itemsItem_RESTInterface( SdtLocationHoliDayUpdateSDT_itemsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="kind", Order=0)]
		public  string gxTpr_Kind
		{
			get { 
				return sdt.gxTpr_Kind;

			}
			set { 
				 sdt.gxTpr_Kind = value;
			}
		}

		[DataMember(Name="etag", Order=1)]
		public  string gxTpr_Etag
		{
			get { 
				return sdt.gxTpr_Etag;

			}
			set { 
				 sdt.gxTpr_Etag = value;
			}
		}

		[DataMember(Name="id", Order=2)]
		public  string gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="status", Order=3)]
		public  string gxTpr_Status
		{
			get { 
				return sdt.gxTpr_Status;

			}
			set { 
				 sdt.gxTpr_Status = value;
			}
		}

		[DataMember(Name="htmlLink", Order=4)]
		public  string gxTpr_Htmllink
		{
			get { 
				return sdt.gxTpr_Htmllink;

			}
			set { 
				 sdt.gxTpr_Htmllink = value;
			}
		}

		[DataMember(Name="created", Order=5)]
		public  string gxTpr_Created
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Created,context);

			}
			set { 
				sdt.gxTpr_Created = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="updated", Order=6)]
		public  string gxTpr_Updated
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Updated,context);

			}
			set { 
				sdt.gxTpr_Updated = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="summary", Order=7)]
		public  string gxTpr_Summary
		{
			get { 
				return sdt.gxTpr_Summary;

			}
			set { 
				 sdt.gxTpr_Summary = value;
			}
		}

		[DataMember(Name="description", Order=8)]
		public  string gxTpr_Description
		{
			get { 
				return sdt.gxTpr_Description;

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}

		[DataMember(Name="creator", Order=9, EmitDefaultValue=false)]
		public SdtLocationHoliDayUpdateSDT_itemsItem_creator_RESTInterface gxTpr_Creator
		{
			get {
				if (sdt.ShouldSerializegxTpr_Creator_Json())
					return new SdtLocationHoliDayUpdateSDT_itemsItem_creator_RESTInterface(sdt.gxTpr_Creator);
				else
					return null;

			}

			set {
				sdt.gxTpr_Creator = value.sdt;
			}

		}

		[DataMember(Name="organizer", Order=10, EmitDefaultValue=false)]
		public SdtLocationHoliDayUpdateSDT_itemsItem_organizer_RESTInterface gxTpr_Organizer
		{
			get {
				if (sdt.ShouldSerializegxTpr_Organizer_Json())
					return new SdtLocationHoliDayUpdateSDT_itemsItem_organizer_RESTInterface(sdt.gxTpr_Organizer);
				else
					return null;

			}

			set {
				sdt.gxTpr_Organizer = value.sdt;
			}

		}

		[DataMember(Name="start", Order=11, EmitDefaultValue=false)]
		public SdtLocationHoliDayUpdateSDT_itemsItem_start_RESTInterface gxTpr_Start
		{
			get {
				if (sdt.ShouldSerializegxTpr_Start_Json())
					return new SdtLocationHoliDayUpdateSDT_itemsItem_start_RESTInterface(sdt.gxTpr_Start);
				else
					return null;

			}

			set {
				sdt.gxTpr_Start = value.sdt;
			}

		}

		[DataMember(Name="end", Order=12, EmitDefaultValue=false)]
		public SdtLocationHoliDayUpdateSDT_itemsItem_end_RESTInterface gxTpr_End
		{
			get {
				if (sdt.ShouldSerializegxTpr_End_Json())
					return new SdtLocationHoliDayUpdateSDT_itemsItem_end_RESTInterface(sdt.gxTpr_End);
				else
					return null;

			}

			set {
				sdt.gxTpr_End = value.sdt;
			}

		}

		[DataMember(Name="transparency", Order=13)]
		public  string gxTpr_Transparency
		{
			get { 
				return sdt.gxTpr_Transparency;

			}
			set { 
				 sdt.gxTpr_Transparency = value;
			}
		}

		[DataMember(Name="visibility", Order=14)]
		public  string gxTpr_Visibility
		{
			get { 
				return sdt.gxTpr_Visibility;

			}
			set { 
				 sdt.gxTpr_Visibility = value;
			}
		}

		[DataMember(Name="iCalUID", Order=15)]
		public  string gxTpr_Icaluid
		{
			get { 
				return sdt.gxTpr_Icaluid;

			}
			set { 
				 sdt.gxTpr_Icaluid = value;
			}
		}

		[DataMember(Name="sequence", Order=16)]
		public  string gxTpr_Sequence
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Sequence, 10, 5));

			}
			set { 
				sdt.gxTpr_Sequence =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="extendedProperties", Order=17, EmitDefaultValue=false)]
		public SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_RESTInterface gxTpr_Extendedproperties
		{
			get {
				if (sdt.ShouldSerializegxTpr_Extendedproperties_Json())
					return new SdtLocationHoliDayUpdateSDT_itemsItem_extendedProperties_RESTInterface(sdt.gxTpr_Extendedproperties);
				else
					return null;

			}

			set {
				sdt.gxTpr_Extendedproperties = value.sdt;
			}

		}

		[DataMember(Name="eventType", Order=18)]
		public  string gxTpr_Eventtype
		{
			get { 
				return sdt.gxTpr_Eventtype;

			}
			set { 
				 sdt.gxTpr_Eventtype = value;
			}
		}


		#endregion

		public SdtLocationHoliDayUpdateSDT_itemsItem sdt
		{
			get { 
				return (SdtLocationHoliDayUpdateSDT_itemsItem)Sdt;
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
				sdt = new SdtLocationHoliDayUpdateSDT_itemsItem() ;
			}
		}
	}
	#endregion
}