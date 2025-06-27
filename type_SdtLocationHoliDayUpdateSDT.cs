/*
				   File: type_SdtLocationHoliDayUpdateSDT
			Description: LocationHoliDayUpdateSDT
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
	[XmlRoot(ElementName="LocationHoliDayUpdateSDT")]
	[XmlType(TypeName="LocationHoliDayUpdateSDT" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtLocationHoliDayUpdateSDT : GxUserType
	{
		public SdtLocationHoliDayUpdateSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtLocationHoliDayUpdateSDT_Kind = "";

			gxTv_SdtLocationHoliDayUpdateSDT_Etag = "";

			gxTv_SdtLocationHoliDayUpdateSDT_Summary = "";

			gxTv_SdtLocationHoliDayUpdateSDT_Description = "";

			gxTv_SdtLocationHoliDayUpdateSDT_Updated = (DateTime)(DateTime.MinValue);

			gxTv_SdtLocationHoliDayUpdateSDT_Timezone = "";

			gxTv_SdtLocationHoliDayUpdateSDT_Accessrole = "";

			gxTv_SdtLocationHoliDayUpdateSDT_Nextpagetoken = "";

		}

		public SdtLocationHoliDayUpdateSDT(IGxContext context)
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


			AddObjectProperty("summary", gxTpr_Summary, false);


			AddObjectProperty("description", gxTpr_Description, false);


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



			AddObjectProperty("timeZone", gxTpr_Timezone, false);


			AddObjectProperty("accessRole", gxTpr_Accessrole, false);


			AddObjectProperty("nextPageToken", gxTpr_Nextpagetoken, false);

			if (gxTv_SdtLocationHoliDayUpdateSDT_Items != null)
			{
				AddObjectProperty("items", gxTv_SdtLocationHoliDayUpdateSDT_Items, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="kind")]
		[XmlElement(ElementName="kind")]
		public string gxTpr_Kind
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_Kind; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_Kind = value;
				SetDirty("Kind");
			}
		}




		[SoapElement(ElementName="etag")]
		[XmlElement(ElementName="etag")]
		public string gxTpr_Etag
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_Etag; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_Etag = value;
				SetDirty("Etag");
			}
		}




		[SoapElement(ElementName="summary")]
		[XmlElement(ElementName="summary")]
		public string gxTpr_Summary
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_Summary; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_Summary = value;
				SetDirty("Summary");
			}
		}




		[SoapElement(ElementName="description")]
		[XmlElement(ElementName="description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_Description; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_Description = value;
				SetDirty("Description");
			}
		}



		[SoapElement(ElementName="updated")]
		[XmlElement(ElementName="updated" , IsNullable=true)]
		public string gxTpr_Updated_Nullable
		{
			get {
				if ( gxTv_SdtLocationHoliDayUpdateSDT_Updated == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtLocationHoliDayUpdateSDT_Updated).value ;
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_Updated = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Updated
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_Updated; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_Updated = value;
				SetDirty("Updated");
			}
		}



		[SoapElement(ElementName="timeZone")]
		[XmlElement(ElementName="timeZone")]
		public string gxTpr_Timezone
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_Timezone; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_Timezone = value;
				SetDirty("Timezone");
			}
		}




		[SoapElement(ElementName="accessRole")]
		[XmlElement(ElementName="accessRole")]
		public string gxTpr_Accessrole
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_Accessrole; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_Accessrole = value;
				SetDirty("Accessrole");
			}
		}




		[SoapElement(ElementName="nextPageToken")]
		[XmlElement(ElementName="nextPageToken")]
		public string gxTpr_Nextpagetoken
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_Nextpagetoken; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_Nextpagetoken = value;
				SetDirty("Nextpagetoken");
			}
		}




		[SoapElement(ElementName="items" )]
		[XmlArray(ElementName="items"  )]
		[XmlArrayItemAttribute(ElementName="itemsItem" , IsNullable=false )]
		public GXBaseCollection<SdtLocationHoliDayUpdateSDT_itemsItem> gxTpr_Items
		{
			get {
				if ( gxTv_SdtLocationHoliDayUpdateSDT_Items == null )
				{
					gxTv_SdtLocationHoliDayUpdateSDT_Items = new GXBaseCollection<SdtLocationHoliDayUpdateSDT_itemsItem>( context, "LocationHoliDayUpdateSDT.itemsItem", "");
				}
				return gxTv_SdtLocationHoliDayUpdateSDT_Items;
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_Items_N = false;
				gxTv_SdtLocationHoliDayUpdateSDT_Items = value;
				SetDirty("Items");
			}
		}

		public void gxTv_SdtLocationHoliDayUpdateSDT_Items_SetNull()
		{
			gxTv_SdtLocationHoliDayUpdateSDT_Items_N = true;
			gxTv_SdtLocationHoliDayUpdateSDT_Items = null;
		}

		public bool gxTv_SdtLocationHoliDayUpdateSDT_Items_IsNull()
		{
			return gxTv_SdtLocationHoliDayUpdateSDT_Items == null;
		}
		public bool ShouldSerializegxTpr_Items_GxSimpleCollection_Json()
		{
			return gxTv_SdtLocationHoliDayUpdateSDT_Items != null && gxTv_SdtLocationHoliDayUpdateSDT_Items.Count > 0;

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
			gxTv_SdtLocationHoliDayUpdateSDT_Kind = "";
			gxTv_SdtLocationHoliDayUpdateSDT_Etag = "";
			gxTv_SdtLocationHoliDayUpdateSDT_Summary = "";
			gxTv_SdtLocationHoliDayUpdateSDT_Description = "";
			gxTv_SdtLocationHoliDayUpdateSDT_Updated = (DateTime)(DateTime.MinValue);
			gxTv_SdtLocationHoliDayUpdateSDT_Timezone = "";
			gxTv_SdtLocationHoliDayUpdateSDT_Accessrole = "";
			gxTv_SdtLocationHoliDayUpdateSDT_Nextpagetoken = "";

			gxTv_SdtLocationHoliDayUpdateSDT_Items_N = true;

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

		protected string gxTv_SdtLocationHoliDayUpdateSDT_Kind;
		 

		protected string gxTv_SdtLocationHoliDayUpdateSDT_Etag;
		 

		protected string gxTv_SdtLocationHoliDayUpdateSDT_Summary;
		 

		protected string gxTv_SdtLocationHoliDayUpdateSDT_Description;
		 

		protected DateTime gxTv_SdtLocationHoliDayUpdateSDT_Updated;
		 

		protected string gxTv_SdtLocationHoliDayUpdateSDT_Timezone;
		 

		protected string gxTv_SdtLocationHoliDayUpdateSDT_Accessrole;
		 

		protected string gxTv_SdtLocationHoliDayUpdateSDT_Nextpagetoken;
		 
		protected bool gxTv_SdtLocationHoliDayUpdateSDT_Items_N;
		protected GXBaseCollection<SdtLocationHoliDayUpdateSDT_itemsItem> gxTv_SdtLocationHoliDayUpdateSDT_Items = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"LocationHoliDayUpdateSDT", Namespace="YTT_version4")]
	public class SdtLocationHoliDayUpdateSDT_RESTInterface : GxGenericCollectionItem<SdtLocationHoliDayUpdateSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtLocationHoliDayUpdateSDT_RESTInterface( ) : base()
		{	
		}

		public SdtLocationHoliDayUpdateSDT_RESTInterface( SdtLocationHoliDayUpdateSDT psdt ) : base(psdt)
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

		[DataMember(Name="summary", Order=2)]
		public  string gxTpr_Summary
		{
			get { 
				return sdt.gxTpr_Summary;

			}
			set { 
				 sdt.gxTpr_Summary = value;
			}
		}

		[DataMember(Name="description", Order=3)]
		public  string gxTpr_Description
		{
			get { 
				return sdt.gxTpr_Description;

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}

		[DataMember(Name="updated", Order=4)]
		public  string gxTpr_Updated
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Updated,context);

			}
			set { 
				sdt.gxTpr_Updated = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="timeZone", Order=5)]
		public  string gxTpr_Timezone
		{
			get { 
				return sdt.gxTpr_Timezone;

			}
			set { 
				 sdt.gxTpr_Timezone = value;
			}
		}

		[DataMember(Name="accessRole", Order=6)]
		public  string gxTpr_Accessrole
		{
			get { 
				return sdt.gxTpr_Accessrole;

			}
			set { 
				 sdt.gxTpr_Accessrole = value;
			}
		}

		[DataMember(Name="nextPageToken", Order=7)]
		public  string gxTpr_Nextpagetoken
		{
			get { 
				return sdt.gxTpr_Nextpagetoken;

			}
			set { 
				 sdt.gxTpr_Nextpagetoken = value;
			}
		}

		[DataMember(Name="items", Order=8, EmitDefaultValue=false)]
		public GxGenericCollection<SdtLocationHoliDayUpdateSDT_itemsItem_RESTInterface> gxTpr_Items
		{
			get {
				if (sdt.ShouldSerializegxTpr_Items_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtLocationHoliDayUpdateSDT_itemsItem_RESTInterface>(sdt.gxTpr_Items);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Items);
			}
		}


		#endregion

		public SdtLocationHoliDayUpdateSDT sdt
		{
			get { 
				return (SdtLocationHoliDayUpdateSDT)Sdt;
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
				sdt = new SdtLocationHoliDayUpdateSDT() ;
			}
		}
	}
	#endregion
}