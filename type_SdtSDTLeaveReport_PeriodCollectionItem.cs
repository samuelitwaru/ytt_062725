/*
				   File: type_SdtSDTLeaveReport_PeriodCollectionItem
			Description: PeriodCollection
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
	[XmlRoot(ElementName="SDTLeaveReport.PeriodCollectionItem")]
	[XmlType(TypeName="SDTLeaveReport.PeriodCollectionItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTLeaveReport_PeriodCollectionItem : GxUserType
	{
		public SdtSDTLeaveReport_PeriodCollectionItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Label = "";

			gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Formattedtotalleave = "";

			gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Formattedtotalwork = "";

		}

		public SdtSDTLeaveReport_PeriodCollectionItem(IGxContext context)
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



			AddObjectProperty("Label", gxTpr_Label, false);


			AddObjectProperty("Mean", gxTpr_Mean, false);


			AddObjectProperty("Number", gxTpr_Number, false);


			AddObjectProperty("TotalLeave", gxTpr_Totalleave, false);


			AddObjectProperty("FormattedTotalLeave", gxTpr_Formattedtotalleave, false);


			AddObjectProperty("TotalWork", gxTpr_Totalwork, false);


			AddObjectProperty("FormattedTotalWork", gxTpr_Formattedtotalwork, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="FromDate")]
		[XmlElement(ElementName="FromDate" , IsNullable=true)]
		public string gxTpr_Fromdate_Nullable
		{
			get {
				if ( gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Fromdate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Fromdate).value ;
			}
			set {
				gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Fromdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Fromdate
		{
			get {
				return gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Fromdate; 
			}
			set {
				gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Fromdate = value;
				SetDirty("Fromdate");
			}
		}


		[SoapElement(ElementName="ToDate")]
		[XmlElement(ElementName="ToDate" , IsNullable=true)]
		public string gxTpr_Todate_Nullable
		{
			get {
				if ( gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Todate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Todate).value ;
			}
			set {
				gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Todate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Todate
		{
			get {
				return gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Todate; 
			}
			set {
				gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Todate = value;
				SetDirty("Todate");
			}
		}



		[SoapElement(ElementName="Label")]
		[XmlElement(ElementName="Label")]
		public string gxTpr_Label
		{
			get {
				return gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Label; 
			}
			set {
				gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Label = value;
				SetDirty("Label");
			}
		}




		[SoapElement(ElementName="Mean")]
		[XmlElement(ElementName="Mean")]
		public long gxTpr_Mean
		{
			get {
				return gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Mean; 
			}
			set {
				gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Mean = value;
				SetDirty("Mean");
			}
		}




		[SoapElement(ElementName="Number")]
		[XmlElement(ElementName="Number")]
		public long gxTpr_Number
		{
			get {
				return gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Number; 
			}
			set {
				gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Number = value;
				SetDirty("Number");
			}
		}




		[SoapElement(ElementName="TotalLeave")]
		[XmlElement(ElementName="TotalLeave")]
		public long gxTpr_Totalleave
		{
			get {
				return gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Totalleave; 
			}
			set {
				gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Totalleave = value;
				SetDirty("Totalleave");
			}
		}




		[SoapElement(ElementName="FormattedTotalLeave")]
		[XmlElement(ElementName="FormattedTotalLeave")]
		public string gxTpr_Formattedtotalleave
		{
			get {
				return gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Formattedtotalleave; 
			}
			set {
				gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Formattedtotalleave = value;
				SetDirty("Formattedtotalleave");
			}
		}




		[SoapElement(ElementName="TotalWork")]
		[XmlElement(ElementName="TotalWork")]
		public long gxTpr_Totalwork
		{
			get {
				return gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Totalwork; 
			}
			set {
				gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Totalwork = value;
				SetDirty("Totalwork");
			}
		}




		[SoapElement(ElementName="FormattedTotalWork")]
		[XmlElement(ElementName="FormattedTotalWork")]
		public string gxTpr_Formattedtotalwork
		{
			get {
				return gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Formattedtotalwork; 
			}
			set {
				gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Formattedtotalwork = value;
				SetDirty("Formattedtotalwork");
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
			gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Label = "";



			gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Formattedtotalleave = "";

			gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Formattedtotalwork = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Fromdate;
		 

		protected DateTime gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Todate;
		 

		protected string gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Label;
		 

		protected long gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Mean;
		 

		protected long gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Number;
		 

		protected long gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Totalleave;
		 

		protected string gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Formattedtotalleave;
		 

		protected long gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Totalwork;
		 

		protected string gxTv_SdtSDTLeaveReport_PeriodCollectionItem_Formattedtotalwork;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTLeaveReport.PeriodCollectionItem", Namespace="YTT_version4")]
	public class SdtSDTLeaveReport_PeriodCollectionItem_RESTInterface : GxGenericCollectionItem<SdtSDTLeaveReport_PeriodCollectionItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTLeaveReport_PeriodCollectionItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTLeaveReport_PeriodCollectionItem_RESTInterface( SdtSDTLeaveReport_PeriodCollectionItem psdt ) : base(psdt)
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

		[DataMember(Name="Label", Order=2)]
		public  string gxTpr_Label
		{
			get { 
				return sdt.gxTpr_Label;

			}
			set { 
				 sdt.gxTpr_Label = value;
			}
		}

		[DataMember(Name="Mean", Order=3)]
		public  string gxTpr_Mean
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Mean, 10, 0));

			}
			set { 
				sdt.gxTpr_Mean = (long) NumberUtil.Val( value, ".");
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

		[DataMember(Name="TotalLeave", Order=5)]
		public  string gxTpr_Totalleave
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Totalleave, 10, 0));

			}
			set { 
				sdt.gxTpr_Totalleave = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FormattedTotalLeave", Order=6)]
		public  string gxTpr_Formattedtotalleave
		{
			get { 
				return sdt.gxTpr_Formattedtotalleave;

			}
			set { 
				 sdt.gxTpr_Formattedtotalleave = value;
			}
		}

		[DataMember(Name="TotalWork", Order=7)]
		public  string gxTpr_Totalwork
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Totalwork, 10, 0));

			}
			set { 
				sdt.gxTpr_Totalwork = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FormattedTotalWork", Order=8)]
		public  string gxTpr_Formattedtotalwork
		{
			get { 
				return sdt.gxTpr_Formattedtotalwork;

			}
			set { 
				 sdt.gxTpr_Formattedtotalwork = value;
			}
		}


		#endregion

		public SdtSDTLeaveReport_PeriodCollectionItem sdt
		{
			get { 
				return (SdtSDTLeaveReport_PeriodCollectionItem)Sdt;
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
				sdt = new SdtSDTLeaveReport_PeriodCollectionItem() ;
			}
		}
	}
	#endregion
}