/*
				   File: type_SdtSDTLeaveReport
			Description: SDTLeaveReport
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
	[XmlRoot(ElementName="SDTLeaveReport")]
	[XmlType(TypeName="SDTLeaveReport" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTLeaveReport : GxUserType
	{
		public SdtSDTLeaveReport( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTLeaveReport_Formattedtotal = "";

		}

		public SdtSDTLeaveReport(IGxContext context)
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



			AddObjectProperty("Total", gxTpr_Total, false);


			AddObjectProperty("FormattedTotal", gxTpr_Formattedtotal, false);

			if (gxTv_SdtSDTLeaveReport_Periodcollection != null)
			{
				AddObjectProperty("PeriodCollection", gxTv_SdtSDTLeaveReport_Periodcollection, false);
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
				if ( gxTv_SdtSDTLeaveReport_Fromdate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTLeaveReport_Fromdate).value ;
			}
			set {
				gxTv_SdtSDTLeaveReport_Fromdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Fromdate
		{
			get {
				return gxTv_SdtSDTLeaveReport_Fromdate; 
			}
			set {
				gxTv_SdtSDTLeaveReport_Fromdate = value;
				SetDirty("Fromdate");
			}
		}


		[SoapElement(ElementName="ToDate")]
		[XmlElement(ElementName="ToDate" , IsNullable=true)]
		public string gxTpr_Todate_Nullable
		{
			get {
				if ( gxTv_SdtSDTLeaveReport_Todate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTLeaveReport_Todate).value ;
			}
			set {
				gxTv_SdtSDTLeaveReport_Todate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Todate
		{
			get {
				return gxTv_SdtSDTLeaveReport_Todate; 
			}
			set {
				gxTv_SdtSDTLeaveReport_Todate = value;
				SetDirty("Todate");
			}
		}



		[SoapElement(ElementName="Total")]
		[XmlElement(ElementName="Total")]
		public long gxTpr_Total
		{
			get {
				return gxTv_SdtSDTLeaveReport_Total; 
			}
			set {
				gxTv_SdtSDTLeaveReport_Total = value;
				SetDirty("Total");
			}
		}




		[SoapElement(ElementName="FormattedTotal")]
		[XmlElement(ElementName="FormattedTotal")]
		public string gxTpr_Formattedtotal
		{
			get {
				return gxTv_SdtSDTLeaveReport_Formattedtotal; 
			}
			set {
				gxTv_SdtSDTLeaveReport_Formattedtotal = value;
				SetDirty("Formattedtotal");
			}
		}




		[SoapElement(ElementName="PeriodCollection" )]
		[XmlArray(ElementName="PeriodCollection"  )]
		[XmlArrayItemAttribute(ElementName="PeriodCollectionItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTLeaveReport_PeriodCollectionItem> gxTpr_Periodcollection
		{
			get {
				if ( gxTv_SdtSDTLeaveReport_Periodcollection == null )
				{
					gxTv_SdtSDTLeaveReport_Periodcollection = new GXBaseCollection<SdtSDTLeaveReport_PeriodCollectionItem>( context, "SDTLeaveReport.PeriodCollectionItem", "");
				}
				return gxTv_SdtSDTLeaveReport_Periodcollection;
			}
			set {
				gxTv_SdtSDTLeaveReport_Periodcollection_N = false;
				gxTv_SdtSDTLeaveReport_Periodcollection = value;
				SetDirty("Periodcollection");
			}
		}

		public void gxTv_SdtSDTLeaveReport_Periodcollection_SetNull()
		{
			gxTv_SdtSDTLeaveReport_Periodcollection_N = true;
			gxTv_SdtSDTLeaveReport_Periodcollection = null;
		}

		public bool gxTv_SdtSDTLeaveReport_Periodcollection_IsNull()
		{
			return gxTv_SdtSDTLeaveReport_Periodcollection == null;
		}
		public bool ShouldSerializegxTpr_Periodcollection_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTLeaveReport_Periodcollection != null && gxTv_SdtSDTLeaveReport_Periodcollection.Count > 0;

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
			gxTv_SdtSDTLeaveReport_Formattedtotal = "";

			gxTv_SdtSDTLeaveReport_Periodcollection_N = true;

			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime gxTv_SdtSDTLeaveReport_Fromdate;
		 

		protected DateTime gxTv_SdtSDTLeaveReport_Todate;
		 

		protected long gxTv_SdtSDTLeaveReport_Total;
		 

		protected string gxTv_SdtSDTLeaveReport_Formattedtotal;
		 
		protected bool gxTv_SdtSDTLeaveReport_Periodcollection_N;
		protected GXBaseCollection<SdtSDTLeaveReport_PeriodCollectionItem> gxTv_SdtSDTLeaveReport_Periodcollection = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTLeaveReport", Namespace="YTT_version4")]
	public class SdtSDTLeaveReport_RESTInterface : GxGenericCollectionItem<SdtSDTLeaveReport>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTLeaveReport_RESTInterface( ) : base()
		{	
		}

		public SdtSDTLeaveReport_RESTInterface( SdtSDTLeaveReport psdt ) : base(psdt)
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

		[DataMember(Name="Total", Order=2)]
		public  string gxTpr_Total
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Total, 10, 0));

			}
			set { 
				sdt.gxTpr_Total = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FormattedTotal", Order=3)]
		public  string gxTpr_Formattedtotal
		{
			get { 
				return sdt.gxTpr_Formattedtotal;

			}
			set { 
				 sdt.gxTpr_Formattedtotal = value;
			}
		}

		[DataMember(Name="PeriodCollection", Order=4, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTLeaveReport_PeriodCollectionItem_RESTInterface> gxTpr_Periodcollection
		{
			get {
				if (sdt.ShouldSerializegxTpr_Periodcollection_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTLeaveReport_PeriodCollectionItem_RESTInterface>(sdt.gxTpr_Periodcollection);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Periodcollection);
			}
		}


		#endregion

		public SdtSDTLeaveReport sdt
		{
			get { 
				return (SdtSDTLeaveReport)Sdt;
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
				sdt = new SdtSDTLeaveReport() ;
			}
		}
	}
	#endregion
}