/*
				   File: type_SdtChartData
			Description: ChartData
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
	[XmlRoot(ElementName="ChartData")]
	[XmlType(TypeName="ChartData" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtChartData : GxUserType
	{
		public SdtChartData( )
		{
			/* Constructor for serialization */
			gxTv_SdtChartData_Category = "";

		}

		public SdtChartData(IGxContext context)
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
			AddObjectProperty("Category", gxTpr_Category, false);


			AddObjectProperty("CategoryNum", gxTpr_Categorynum, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Categorydate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Categorydate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Categorydate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("CategoryDate", sDateCnv, false);



			AddObjectProperty("Serie1", gxTpr_Serie1, false);


			AddObjectProperty("Serie2", gxTpr_Serie2, false);


			AddObjectProperty("Serie3", gxTpr_Serie3, false);


			AddObjectProperty("SerieDecimal1", gxTpr_Seriedecimal1, false);


			AddObjectProperty("SerieDecimal2", gxTpr_Seriedecimal2, false);


			AddObjectProperty("SerieDecimal3", gxTpr_Seriedecimal3, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Category")]
		[XmlElement(ElementName="Category")]
		public string gxTpr_Category
		{
			get {
				return gxTv_SdtChartData_Category; 
			}
			set {
				gxTv_SdtChartData_Category = value;
				SetDirty("Category");
			}
		}




		[SoapElement(ElementName="CategoryNum")]
		[XmlElement(ElementName="CategoryNum")]
		public short gxTpr_Categorynum
		{
			get {
				return gxTv_SdtChartData_Categorynum; 
			}
			set {
				gxTv_SdtChartData_Categorynum = value;
				SetDirty("Categorynum");
			}
		}



		[SoapElement(ElementName="CategoryDate")]
		[XmlElement(ElementName="CategoryDate" , IsNullable=true)]
		public string gxTpr_Categorydate_Nullable
		{
			get {
				if ( gxTv_SdtChartData_Categorydate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtChartData_Categorydate).value ;
			}
			set {
				gxTv_SdtChartData_Categorydate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Categorydate
		{
			get {
				return gxTv_SdtChartData_Categorydate; 
			}
			set {
				gxTv_SdtChartData_Categorydate = value;
				SetDirty("Categorydate");
			}
		}



		[SoapElement(ElementName="Serie1")]
		[XmlElement(ElementName="Serie1")]
		public int gxTpr_Serie1
		{
			get {
				return gxTv_SdtChartData_Serie1; 
			}
			set {
				gxTv_SdtChartData_Serie1 = value;
				SetDirty("Serie1");
			}
		}




		[SoapElement(ElementName="Serie2")]
		[XmlElement(ElementName="Serie2")]
		public int gxTpr_Serie2
		{
			get {
				return gxTv_SdtChartData_Serie2; 
			}
			set {
				gxTv_SdtChartData_Serie2 = value;
				SetDirty("Serie2");
			}
		}




		[SoapElement(ElementName="Serie3")]
		[XmlElement(ElementName="Serie3")]
		public int gxTpr_Serie3
		{
			get {
				return gxTv_SdtChartData_Serie3; 
			}
			set {
				gxTv_SdtChartData_Serie3 = value;
				SetDirty("Serie3");
			}
		}



		[SoapElement(ElementName="SerieDecimal1")]
		[XmlElement(ElementName="SerieDecimal1")]
		public string gxTpr_Seriedecimal1_double
		{
			get {
				return Convert.ToString(gxTv_SdtChartData_Seriedecimal1, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtChartData_Seriedecimal1 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Seriedecimal1
		{
			get {
				return gxTv_SdtChartData_Seriedecimal1; 
			}
			set {
				gxTv_SdtChartData_Seriedecimal1 = value;
				SetDirty("Seriedecimal1");
			}
		}



		[SoapElement(ElementName="SerieDecimal2")]
		[XmlElement(ElementName="SerieDecimal2")]
		public string gxTpr_Seriedecimal2_double
		{
			get {
				return Convert.ToString(gxTv_SdtChartData_Seriedecimal2, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtChartData_Seriedecimal2 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Seriedecimal2
		{
			get {
				return gxTv_SdtChartData_Seriedecimal2; 
			}
			set {
				gxTv_SdtChartData_Seriedecimal2 = value;
				SetDirty("Seriedecimal2");
			}
		}



		[SoapElement(ElementName="SerieDecimal3")]
		[XmlElement(ElementName="SerieDecimal3")]
		public string gxTpr_Seriedecimal3_double
		{
			get {
				return Convert.ToString(gxTv_SdtChartData_Seriedecimal3, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtChartData_Seriedecimal3 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Seriedecimal3
		{
			get {
				return gxTv_SdtChartData_Seriedecimal3; 
			}
			set {
				gxTv_SdtChartData_Seriedecimal3 = value;
				SetDirty("Seriedecimal3");
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
			gxTv_SdtChartData_Category = "";








			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtChartData_Category;
		 

		protected short gxTv_SdtChartData_Categorynum;
		 

		protected DateTime gxTv_SdtChartData_Categorydate;
		 

		protected int gxTv_SdtChartData_Serie1;
		 

		protected int gxTv_SdtChartData_Serie2;
		 

		protected int gxTv_SdtChartData_Serie3;
		 

		protected decimal gxTv_SdtChartData_Seriedecimal1;
		 

		protected decimal gxTv_SdtChartData_Seriedecimal2;
		 

		protected decimal gxTv_SdtChartData_Seriedecimal3;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"ChartData", Namespace="YTT_version4")]
	public class SdtChartData_RESTInterface : GxGenericCollectionItem<SdtChartData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtChartData_RESTInterface( ) : base()
		{	
		}

		public SdtChartData_RESTInterface( SdtChartData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Category", Order=0)]
		public  string gxTpr_Category
		{
			get { 
				return sdt.gxTpr_Category;

			}
			set { 
				 sdt.gxTpr_Category = value;
			}
		}

		[DataMember(Name="CategoryNum", Order=1)]
		public short gxTpr_Categorynum
		{
			get { 
				return sdt.gxTpr_Categorynum;

			}
			set { 
				sdt.gxTpr_Categorynum = value;
			}
		}

		[DataMember(Name="CategoryDate", Order=2)]
		public  string gxTpr_Categorydate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Categorydate);

			}
			set { 
				sdt.gxTpr_Categorydate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="Serie1", Order=3)]
		public  string gxTpr_Serie1
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Serie1, 7, 0));

			}
			set { 
				sdt.gxTpr_Serie1 = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Serie2", Order=4)]
		public  string gxTpr_Serie2
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Serie2, 7, 0));

			}
			set { 
				sdt.gxTpr_Serie2 = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Serie3", Order=5)]
		public  string gxTpr_Serie3
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Serie3, 7, 0));

			}
			set { 
				sdt.gxTpr_Serie3 = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SerieDecimal1", Order=6)]
		public  string gxTpr_Seriedecimal1
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Seriedecimal1, 10, 2));

			}
			set { 
				sdt.gxTpr_Seriedecimal1 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SerieDecimal2", Order=7)]
		public  string gxTpr_Seriedecimal2
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Seriedecimal2, 10, 2));

			}
			set { 
				sdt.gxTpr_Seriedecimal2 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SerieDecimal3", Order=8)]
		public  string gxTpr_Seriedecimal3
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Seriedecimal3, 10, 3));

			}
			set { 
				sdt.gxTpr_Seriedecimal3 =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtChartData sdt
		{
			get { 
				return (SdtChartData)Sdt;
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
				sdt = new SdtChartData() ;
			}
		}
	}
	#endregion
}