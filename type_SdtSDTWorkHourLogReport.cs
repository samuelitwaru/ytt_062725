/*
				   File: type_SdtSDTWorkHourLogReport
			Description: SDTWorkHourLogReport
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
	[XmlRoot(ElementName="SDTWorkHourLogReport")]
	[XmlType(TypeName="SDTWorkHourLogReport" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTWorkHourLogReport : GxUserType
	{
		public SdtSDTWorkHourLogReport( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTWorkHourLogReport(IGxContext context)
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
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Fromdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Fromdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Fromdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("FromDate", sDateCnv, false);



			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Todate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Todate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Todate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ToDate", sDateCnv, false);


			if (gxTv_SdtSDTWorkHourLogReport_Weekcollection != null)
			{
				AddObjectProperty("WeekCollection", gxTv_SdtSDTWorkHourLogReport_Weekcollection, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="FromDate")]
		[XmlElement(ElementName="FromDate" , IsNullable=true)]
		public string gxTpr_Fromdate_Nullable
		{
			get {
				if ( gxTv_SdtSDTWorkHourLogReport_Fromdate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTWorkHourLogReport_Fromdate).value ;
			}
			set {
				gxTv_SdtSDTWorkHourLogReport_Fromdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Fromdate
		{
			get {
				return gxTv_SdtSDTWorkHourLogReport_Fromdate; 
			}
			set {
				gxTv_SdtSDTWorkHourLogReport_Fromdate = value;
				SetDirty("Fromdate");
			}
		}


		[SoapElement(ElementName="ToDate")]
		[XmlElement(ElementName="ToDate" , IsNullable=true)]
		public string gxTpr_Todate_Nullable
		{
			get {
				if ( gxTv_SdtSDTWorkHourLogReport_Todate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTWorkHourLogReport_Todate).value ;
			}
			set {
				gxTv_SdtSDTWorkHourLogReport_Todate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Todate
		{
			get {
				return gxTv_SdtSDTWorkHourLogReport_Todate; 
			}
			set {
				gxTv_SdtSDTWorkHourLogReport_Todate = value;
				SetDirty("Todate");
			}
		}



		[SoapElement(ElementName="WeekCollection" )]
		[XmlArray(ElementName="WeekCollection"  )]
		[XmlArrayItemAttribute(ElementName="WeekCollectionItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTWorkHourLogReport_WeekCollectionItem> gxTpr_Weekcollection
		{
			get {
				if ( gxTv_SdtSDTWorkHourLogReport_Weekcollection == null )
				{
					gxTv_SdtSDTWorkHourLogReport_Weekcollection = new GXBaseCollection<SdtSDTWorkHourLogReport_WeekCollectionItem>( context, "SDTWorkHourLogReport.WeekCollectionItem", "");
				}
				return gxTv_SdtSDTWorkHourLogReport_Weekcollection;
			}
			set {
				gxTv_SdtSDTWorkHourLogReport_Weekcollection_N = false;
				gxTv_SdtSDTWorkHourLogReport_Weekcollection = value;
				SetDirty("Weekcollection");
			}
		}

		public void gxTv_SdtSDTWorkHourLogReport_Weekcollection_SetNull()
		{
			gxTv_SdtSDTWorkHourLogReport_Weekcollection_N = true;
			gxTv_SdtSDTWorkHourLogReport_Weekcollection = null;
		}

		public bool gxTv_SdtSDTWorkHourLogReport_Weekcollection_IsNull()
		{
			return gxTv_SdtSDTWorkHourLogReport_Weekcollection == null;
		}
		public bool ShouldSerializegxTpr_Weekcollection_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTWorkHourLogReport_Weekcollection != null && gxTv_SdtSDTWorkHourLogReport_Weekcollection.Count > 0;

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
			gxTv_SdtSDTWorkHourLogReport_Weekcollection_N = true;

			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime gxTv_SdtSDTWorkHourLogReport_Fromdate;
		 

		protected DateTime gxTv_SdtSDTWorkHourLogReport_Todate;
		 
		protected bool gxTv_SdtSDTWorkHourLogReport_Weekcollection_N;
		protected GXBaseCollection<SdtSDTWorkHourLogReport_WeekCollectionItem> gxTv_SdtSDTWorkHourLogReport_Weekcollection = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTWorkHourLogReport", Namespace="YTT_version4")]
	public class SdtSDTWorkHourLogReport_RESTInterface : GxGenericCollectionItem<SdtSDTWorkHourLogReport>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTWorkHourLogReport_RESTInterface( ) : base()
		{	
		}

		public SdtSDTWorkHourLogReport_RESTInterface( SdtSDTWorkHourLogReport psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="FromDate", Order=0)]
		public  string gxTpr_Fromdate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Fromdate);

			}
			set { 
				sdt.gxTpr_Fromdate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="ToDate", Order=1)]
		public  string gxTpr_Todate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Todate);

			}
			set { 
				sdt.gxTpr_Todate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="WeekCollection", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTWorkHourLogReport_WeekCollectionItem_RESTInterface> gxTpr_Weekcollection
		{
			get {
				if (sdt.ShouldSerializegxTpr_Weekcollection_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTWorkHourLogReport_WeekCollectionItem_RESTInterface>(sdt.gxTpr_Weekcollection);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Weekcollection);
			}
		}


		#endregion

		public SdtSDTWorkHourLogReport sdt
		{
			get { 
				return (SdtSDTWorkHourLogReport)Sdt;
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
				sdt = new SdtSDTWorkHourLogReport() ;
			}
		}
	}
	#endregion
}