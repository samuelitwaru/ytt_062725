/*
				   File: type_SdtSDTWorkHourLogReport_WeekCollectionItem
			Description: WeekCollection
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
	[XmlRoot(ElementName="SDTWorkHourLogReport.WeekCollectionItem")]
	[XmlType(TypeName="SDTWorkHourLogReport.WeekCollectionItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTWorkHourLogReport_WeekCollectionItem : GxUserType
	{
		public SdtSDTWorkHourLogReport_WeekCollectionItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Formattedtotal = "";

			gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Label = "";

		}

		public SdtSDTWorkHourLogReport_WeekCollectionItem(IGxContext context)
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
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Startdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Startdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Startdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("StartDate", sDateCnv, false);



			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Enddate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Enddate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Enddate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("EndDate", sDateCnv, false);



			AddObjectProperty("Mean", gxTpr_Mean, false);


			AddObjectProperty("Total", gxTpr_Total, false);


			AddObjectProperty("Number", gxTpr_Number, false);


			AddObjectProperty("FormattedTotal", gxTpr_Formattedtotal, false);


			AddObjectProperty("Label", gxTpr_Label, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="StartDate")]
		[XmlElement(ElementName="StartDate" , IsNullable=true)]
		public string gxTpr_Startdate_Nullable
		{
			get {
				if ( gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Startdate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Startdate).value ;
			}
			set {
				gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Startdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Startdate
		{
			get {
				return gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Startdate; 
			}
			set {
				gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Startdate = value;
				SetDirty("Startdate");
			}
		}


		[SoapElement(ElementName="EndDate")]
		[XmlElement(ElementName="EndDate" , IsNullable=true)]
		public string gxTpr_Enddate_Nullable
		{
			get {
				if ( gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Enddate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Enddate).value ;
			}
			set {
				gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Enddate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Enddate
		{
			get {
				return gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Enddate; 
			}
			set {
				gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Enddate = value;
				SetDirty("Enddate");
			}
		}



		[SoapElement(ElementName="Mean")]
		[XmlElement(ElementName="Mean")]
		public long gxTpr_Mean
		{
			get {
				return gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Mean; 
			}
			set {
				gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Mean = value;
				SetDirty("Mean");
			}
		}




		[SoapElement(ElementName="Total")]
		[XmlElement(ElementName="Total")]
		public long gxTpr_Total
		{
			get {
				return gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Total; 
			}
			set {
				gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Total = value;
				SetDirty("Total");
			}
		}




		[SoapElement(ElementName="Number")]
		[XmlElement(ElementName="Number")]
		public long gxTpr_Number
		{
			get {
				return gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Number; 
			}
			set {
				gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Number = value;
				SetDirty("Number");
			}
		}




		[SoapElement(ElementName="FormattedTotal")]
		[XmlElement(ElementName="FormattedTotal")]
		public string gxTpr_Formattedtotal
		{
			get {
				return gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Formattedtotal; 
			}
			set {
				gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Formattedtotal = value;
				SetDirty("Formattedtotal");
			}
		}




		[SoapElement(ElementName="Label")]
		[XmlElement(ElementName="Label")]
		public string gxTpr_Label
		{
			get {
				return gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Label; 
			}
			set {
				gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Label = value;
				SetDirty("Label");
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
			gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Formattedtotal = "";
			gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Label = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Startdate;
		 

		protected DateTime gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Enddate;
		 

		protected long gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Mean;
		 

		protected long gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Total;
		 

		protected long gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Number;
		 

		protected string gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Formattedtotal;
		 

		protected string gxTv_SdtSDTWorkHourLogReport_WeekCollectionItem_Label;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTWorkHourLogReport.WeekCollectionItem", Namespace="YTT_version4")]
	public class SdtSDTWorkHourLogReport_WeekCollectionItem_RESTInterface : GxGenericCollectionItem<SdtSDTWorkHourLogReport_WeekCollectionItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTWorkHourLogReport_WeekCollectionItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTWorkHourLogReport_WeekCollectionItem_RESTInterface( SdtSDTWorkHourLogReport_WeekCollectionItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="StartDate", Order=0)]
		public  string gxTpr_Startdate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Startdate);

			}
			set { 
				sdt.gxTpr_Startdate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="EndDate", Order=1)]
		public  string gxTpr_Enddate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Enddate);

			}
			set { 
				sdt.gxTpr_Enddate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="Mean", Order=2)]
		public  string gxTpr_Mean
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Mean, 10, 0));

			}
			set { 
				sdt.gxTpr_Mean = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Total", Order=3)]
		public  string gxTpr_Total
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Total, 10, 0));

			}
			set { 
				sdt.gxTpr_Total = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Number", Order=4)]
		public  string gxTpr_Number
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Number, 10, 0));

			}
			set { 
				sdt.gxTpr_Number = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FormattedTotal", Order=5)]
		public  string gxTpr_Formattedtotal
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Formattedtotal);

			}
			set { 
				 sdt.gxTpr_Formattedtotal = value;
			}
		}

		[DataMember(Name="Label", Order=6)]
		public  string gxTpr_Label
		{
			get { 
				return sdt.gxTpr_Label;

			}
			set { 
				 sdt.gxTpr_Label = value;
			}
		}


		#endregion

		public SdtSDTWorkHourLogReport_WeekCollectionItem sdt
		{
			get { 
				return (SdtSDTWorkHourLogReport_WeekCollectionItem)Sdt;
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
				sdt = new SdtSDTWorkHourLogReport_WeekCollectionItem() ;
			}
		}
	}
	#endregion
}