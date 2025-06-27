/*
				   File: type_SdtSDTEmployeeWeekReport
			Description: SDTEmployeeWeekReport
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
	[XmlRoot(ElementName="SDTEmployeeWeekReport")]
	[XmlType(TypeName="SDTEmployeeWeekReport" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTEmployeeWeekReport : GxUserType
	{
		public SdtSDTEmployeeWeekReport( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTEmployeeWeekReport_Employeename = "";

			gxTv_SdtSDTEmployeeWeekReport_Mon_formatted = "";

			gxTv_SdtSDTEmployeeWeekReport_Tue_formatted = "";

			gxTv_SdtSDTEmployeeWeekReport_Wed_formatted = "";

			gxTv_SdtSDTEmployeeWeekReport_Thu_formatted = "";

			gxTv_SdtSDTEmployeeWeekReport_Fri_formatted = "";

			gxTv_SdtSDTEmployeeWeekReport_Sat_formatted = "";

			gxTv_SdtSDTEmployeeWeekReport_Sun_formatted = "";

			gxTv_SdtSDTEmployeeWeekReport_Leave_formatted = "";

			gxTv_SdtSDTEmployeeWeekReport_Total_formatted = "";

			gxTv_SdtSDTEmployeeWeekReport_Expected_formatted = "";

		}

		public SdtSDTEmployeeWeekReport(IGxContext context)
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
			AddObjectProperty("EmployeeName", gxTpr_Employeename, false);


			AddObjectProperty("Mon", gxTpr_Mon, false);


			AddObjectProperty("Tue", gxTpr_Tue, false);


			AddObjectProperty("Wed", gxTpr_Wed, false);


			AddObjectProperty("Thu", gxTpr_Thu, false);


			AddObjectProperty("Fri", gxTpr_Fri, false);


			AddObjectProperty("Sat", gxTpr_Sat, false);


			AddObjectProperty("Sun", gxTpr_Sun, false);


			AddObjectProperty("Leave", gxTpr_Leave, false);


			AddObjectProperty("Expected", gxTpr_Expected, false);


			AddObjectProperty("Total", gxTpr_Total, false);


			AddObjectProperty("Mon_IsHoliday", gxTpr_Mon_isholiday, false);


			AddObjectProperty("Tue_IsHoliday", gxTpr_Tue_isholiday, false);


			AddObjectProperty("Wed_IsHoliday", gxTpr_Wed_isholiday, false);


			AddObjectProperty("Thu_IsHoliday", gxTpr_Thu_isholiday, false);


			AddObjectProperty("Fri_IsHoliday", gxTpr_Fri_isholiday, false);


			AddObjectProperty("Sat_IsHoliday", gxTpr_Sat_isholiday, false);


			AddObjectProperty("Sun_IsHoliday", gxTpr_Sun_isholiday, false);


			AddObjectProperty("Mon_Formatted", gxTpr_Mon_formatted, false);


			AddObjectProperty("Tue_Formatted", gxTpr_Tue_formatted, false);


			AddObjectProperty("Wed_Formatted", gxTpr_Wed_formatted, false);


			AddObjectProperty("Thu_Formatted", gxTpr_Thu_formatted, false);


			AddObjectProperty("Fri_Formatted", gxTpr_Fri_formatted, false);


			AddObjectProperty("Sat_Formatted", gxTpr_Sat_formatted, false);


			AddObjectProperty("Sun_Formatted", gxTpr_Sun_formatted, false);


			AddObjectProperty("Leave_Formatted", gxTpr_Leave_formatted, false);


			AddObjectProperty("Total_Formatted", gxTpr_Total_formatted, false);


			AddObjectProperty("Expected_Formatted", gxTpr_Expected_formatted, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="EmployeeName")]
		[XmlElement(ElementName="EmployeeName")]
		public string gxTpr_Employeename
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Employeename; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Employeename = value;
				SetDirty("Employeename");
			}
		}




		[SoapElement(ElementName="Mon")]
		[XmlElement(ElementName="Mon")]
		public long gxTpr_Mon
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Mon; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Mon = value;
				SetDirty("Mon");
			}
		}




		[SoapElement(ElementName="Tue")]
		[XmlElement(ElementName="Tue")]
		public long gxTpr_Tue
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Tue; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Tue = value;
				SetDirty("Tue");
			}
		}




		[SoapElement(ElementName="Wed")]
		[XmlElement(ElementName="Wed")]
		public long gxTpr_Wed
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Wed; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Wed = value;
				SetDirty("Wed");
			}
		}




		[SoapElement(ElementName="Thu")]
		[XmlElement(ElementName="Thu")]
		public long gxTpr_Thu
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Thu; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Thu = value;
				SetDirty("Thu");
			}
		}




		[SoapElement(ElementName="Fri")]
		[XmlElement(ElementName="Fri")]
		public long gxTpr_Fri
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Fri; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Fri = value;
				SetDirty("Fri");
			}
		}




		[SoapElement(ElementName="Sat")]
		[XmlElement(ElementName="Sat")]
		public long gxTpr_Sat
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Sat; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Sat = value;
				SetDirty("Sat");
			}
		}




		[SoapElement(ElementName="Sun")]
		[XmlElement(ElementName="Sun")]
		public long gxTpr_Sun
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Sun; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Sun = value;
				SetDirty("Sun");
			}
		}




		[SoapElement(ElementName="Leave")]
		[XmlElement(ElementName="Leave")]
		public long gxTpr_Leave
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Leave; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Leave = value;
				SetDirty("Leave");
			}
		}




		[SoapElement(ElementName="Expected")]
		[XmlElement(ElementName="Expected")]
		public long gxTpr_Expected
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Expected; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Expected = value;
				SetDirty("Expected");
			}
		}




		[SoapElement(ElementName="Total")]
		[XmlElement(ElementName="Total")]
		public long gxTpr_Total
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Total; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Total = value;
				SetDirty("Total");
			}
		}




		[SoapElement(ElementName="Mon_IsHoliday")]
		[XmlElement(ElementName="Mon_IsHoliday")]
		public bool gxTpr_Mon_isholiday
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Mon_isholiday; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Mon_isholiday = value;
				SetDirty("Mon_isholiday");
			}
		}




		[SoapElement(ElementName="Tue_IsHoliday")]
		[XmlElement(ElementName="Tue_IsHoliday")]
		public bool gxTpr_Tue_isholiday
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Tue_isholiday; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Tue_isholiday = value;
				SetDirty("Tue_isholiday");
			}
		}




		[SoapElement(ElementName="Wed_IsHoliday")]
		[XmlElement(ElementName="Wed_IsHoliday")]
		public bool gxTpr_Wed_isholiday
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Wed_isholiday; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Wed_isholiday = value;
				SetDirty("Wed_isholiday");
			}
		}




		[SoapElement(ElementName="Thu_IsHoliday")]
		[XmlElement(ElementName="Thu_IsHoliday")]
		public bool gxTpr_Thu_isholiday
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Thu_isholiday; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Thu_isholiday = value;
				SetDirty("Thu_isholiday");
			}
		}




		[SoapElement(ElementName="Fri_IsHoliday")]
		[XmlElement(ElementName="Fri_IsHoliday")]
		public bool gxTpr_Fri_isholiday
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Fri_isholiday; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Fri_isholiday = value;
				SetDirty("Fri_isholiday");
			}
		}




		[SoapElement(ElementName="Sat_IsHoliday")]
		[XmlElement(ElementName="Sat_IsHoliday")]
		public bool gxTpr_Sat_isholiday
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Sat_isholiday; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Sat_isholiday = value;
				SetDirty("Sat_isholiday");
			}
		}




		[SoapElement(ElementName="Sun_IsHoliday")]
		[XmlElement(ElementName="Sun_IsHoliday")]
		public bool gxTpr_Sun_isholiday
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Sun_isholiday; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Sun_isholiday = value;
				SetDirty("Sun_isholiday");
			}
		}




		[SoapElement(ElementName="Mon_Formatted")]
		[XmlElement(ElementName="Mon_Formatted")]
		public string gxTpr_Mon_formatted
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Mon_formatted; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Mon_formatted = value;
				SetDirty("Mon_formatted");
			}
		}




		[SoapElement(ElementName="Tue_Formatted")]
		[XmlElement(ElementName="Tue_Formatted")]
		public string gxTpr_Tue_formatted
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Tue_formatted; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Tue_formatted = value;
				SetDirty("Tue_formatted");
			}
		}




		[SoapElement(ElementName="Wed_Formatted")]
		[XmlElement(ElementName="Wed_Formatted")]
		public string gxTpr_Wed_formatted
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Wed_formatted; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Wed_formatted = value;
				SetDirty("Wed_formatted");
			}
		}




		[SoapElement(ElementName="Thu_Formatted")]
		[XmlElement(ElementName="Thu_Formatted")]
		public string gxTpr_Thu_formatted
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Thu_formatted; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Thu_formatted = value;
				SetDirty("Thu_formatted");
			}
		}




		[SoapElement(ElementName="Fri_Formatted")]
		[XmlElement(ElementName="Fri_Formatted")]
		public string gxTpr_Fri_formatted
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Fri_formatted; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Fri_formatted = value;
				SetDirty("Fri_formatted");
			}
		}




		[SoapElement(ElementName="Sat_Formatted")]
		[XmlElement(ElementName="Sat_Formatted")]
		public string gxTpr_Sat_formatted
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Sat_formatted; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Sat_formatted = value;
				SetDirty("Sat_formatted");
			}
		}




		[SoapElement(ElementName="Sun_Formatted")]
		[XmlElement(ElementName="Sun_Formatted")]
		public string gxTpr_Sun_formatted
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Sun_formatted; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Sun_formatted = value;
				SetDirty("Sun_formatted");
			}
		}




		[SoapElement(ElementName="Leave_Formatted")]
		[XmlElement(ElementName="Leave_Formatted")]
		public string gxTpr_Leave_formatted
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Leave_formatted; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Leave_formatted = value;
				SetDirty("Leave_formatted");
			}
		}




		[SoapElement(ElementName="Total_Formatted")]
		[XmlElement(ElementName="Total_Formatted")]
		public string gxTpr_Total_formatted
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Total_formatted; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Total_formatted = value;
				SetDirty("Total_formatted");
			}
		}




		[SoapElement(ElementName="Expected_Formatted")]
		[XmlElement(ElementName="Expected_Formatted")]
		public string gxTpr_Expected_formatted
		{
			get {
				return gxTv_SdtSDTEmployeeWeekReport_Expected_formatted; 
			}
			set {
				gxTv_SdtSDTEmployeeWeekReport_Expected_formatted = value;
				SetDirty("Expected_formatted");
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
			gxTv_SdtSDTEmployeeWeekReport_Employeename = "";

















			gxTv_SdtSDTEmployeeWeekReport_Mon_formatted = "";
			gxTv_SdtSDTEmployeeWeekReport_Tue_formatted = "";
			gxTv_SdtSDTEmployeeWeekReport_Wed_formatted = "";
			gxTv_SdtSDTEmployeeWeekReport_Thu_formatted = "";
			gxTv_SdtSDTEmployeeWeekReport_Fri_formatted = "";
			gxTv_SdtSDTEmployeeWeekReport_Sat_formatted = "";
			gxTv_SdtSDTEmployeeWeekReport_Sun_formatted = "";
			gxTv_SdtSDTEmployeeWeekReport_Leave_formatted = "";
			gxTv_SdtSDTEmployeeWeekReport_Total_formatted = "";
			gxTv_SdtSDTEmployeeWeekReport_Expected_formatted = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTEmployeeWeekReport_Employeename;
		 

		protected long gxTv_SdtSDTEmployeeWeekReport_Mon;
		 

		protected long gxTv_SdtSDTEmployeeWeekReport_Tue;
		 

		protected long gxTv_SdtSDTEmployeeWeekReport_Wed;
		 

		protected long gxTv_SdtSDTEmployeeWeekReport_Thu;
		 

		protected long gxTv_SdtSDTEmployeeWeekReport_Fri;
		 

		protected long gxTv_SdtSDTEmployeeWeekReport_Sat;
		 

		protected long gxTv_SdtSDTEmployeeWeekReport_Sun;
		 

		protected long gxTv_SdtSDTEmployeeWeekReport_Leave;
		 

		protected long gxTv_SdtSDTEmployeeWeekReport_Expected;
		 

		protected long gxTv_SdtSDTEmployeeWeekReport_Total;
		 

		protected bool gxTv_SdtSDTEmployeeWeekReport_Mon_isholiday;
		 

		protected bool gxTv_SdtSDTEmployeeWeekReport_Tue_isholiday;
		 

		protected bool gxTv_SdtSDTEmployeeWeekReport_Wed_isholiday;
		 

		protected bool gxTv_SdtSDTEmployeeWeekReport_Thu_isholiday;
		 

		protected bool gxTv_SdtSDTEmployeeWeekReport_Fri_isholiday;
		 

		protected bool gxTv_SdtSDTEmployeeWeekReport_Sat_isholiday;
		 

		protected bool gxTv_SdtSDTEmployeeWeekReport_Sun_isholiday;
		 

		protected string gxTv_SdtSDTEmployeeWeekReport_Mon_formatted;
		 

		protected string gxTv_SdtSDTEmployeeWeekReport_Tue_formatted;
		 

		protected string gxTv_SdtSDTEmployeeWeekReport_Wed_formatted;
		 

		protected string gxTv_SdtSDTEmployeeWeekReport_Thu_formatted;
		 

		protected string gxTv_SdtSDTEmployeeWeekReport_Fri_formatted;
		 

		protected string gxTv_SdtSDTEmployeeWeekReport_Sat_formatted;
		 

		protected string gxTv_SdtSDTEmployeeWeekReport_Sun_formatted;
		 

		protected string gxTv_SdtSDTEmployeeWeekReport_Leave_formatted;
		 

		protected string gxTv_SdtSDTEmployeeWeekReport_Total_formatted;
		 

		protected string gxTv_SdtSDTEmployeeWeekReport_Expected_formatted;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTEmployeeWeekReport", Namespace="YTT_version4")]
	public class SdtSDTEmployeeWeekReport_RESTInterface : GxGenericCollectionItem<SdtSDTEmployeeWeekReport>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTEmployeeWeekReport_RESTInterface( ) : base()
		{	
		}

		public SdtSDTEmployeeWeekReport_RESTInterface( SdtSDTEmployeeWeekReport psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="EmployeeName", Order=0)]
		public  string gxTpr_Employeename
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Employeename);

			}
			set { 
				 sdt.gxTpr_Employeename = value;
			}
		}

		[DataMember(Name="Mon", Order=1)]
		public  string gxTpr_Mon
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Mon, 10, 0));

			}
			set { 
				sdt.gxTpr_Mon = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Tue", Order=2)]
		public  string gxTpr_Tue
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Tue, 10, 0));

			}
			set { 
				sdt.gxTpr_Tue = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Wed", Order=3)]
		public  string gxTpr_Wed
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Wed, 10, 0));

			}
			set { 
				sdt.gxTpr_Wed = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Thu", Order=4)]
		public  string gxTpr_Thu
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Thu, 10, 0));

			}
			set { 
				sdt.gxTpr_Thu = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Fri", Order=5)]
		public  string gxTpr_Fri
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Fri, 10, 0));

			}
			set { 
				sdt.gxTpr_Fri = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Sat", Order=6)]
		public  string gxTpr_Sat
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Sat, 10, 0));

			}
			set { 
				sdt.gxTpr_Sat = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Sun", Order=7)]
		public  string gxTpr_Sun
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Sun, 10, 0));

			}
			set { 
				sdt.gxTpr_Sun = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Leave", Order=8)]
		public  string gxTpr_Leave
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Leave, 10, 0));

			}
			set { 
				sdt.gxTpr_Leave = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Expected", Order=9)]
		public  string gxTpr_Expected
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Expected, 10, 0));

			}
			set { 
				sdt.gxTpr_Expected = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Total", Order=10)]
		public  string gxTpr_Total
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Total, 10, 0));

			}
			set { 
				sdt.gxTpr_Total = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Mon_IsHoliday", Order=11)]
		public bool gxTpr_Mon_isholiday
		{
			get { 
				return sdt.gxTpr_Mon_isholiday;

			}
			set { 
				sdt.gxTpr_Mon_isholiday = value;
			}
		}

		[DataMember(Name="Tue_IsHoliday", Order=12)]
		public bool gxTpr_Tue_isholiday
		{
			get { 
				return sdt.gxTpr_Tue_isholiday;

			}
			set { 
				sdt.gxTpr_Tue_isholiday = value;
			}
		}

		[DataMember(Name="Wed_IsHoliday", Order=13)]
		public bool gxTpr_Wed_isholiday
		{
			get { 
				return sdt.gxTpr_Wed_isholiday;

			}
			set { 
				sdt.gxTpr_Wed_isholiday = value;
			}
		}

		[DataMember(Name="Thu_IsHoliday", Order=14)]
		public bool gxTpr_Thu_isholiday
		{
			get { 
				return sdt.gxTpr_Thu_isholiday;

			}
			set { 
				sdt.gxTpr_Thu_isholiday = value;
			}
		}

		[DataMember(Name="Fri_IsHoliday", Order=15)]
		public bool gxTpr_Fri_isholiday
		{
			get { 
				return sdt.gxTpr_Fri_isholiday;

			}
			set { 
				sdt.gxTpr_Fri_isholiday = value;
			}
		}

		[DataMember(Name="Sat_IsHoliday", Order=16)]
		public bool gxTpr_Sat_isholiday
		{
			get { 
				return sdt.gxTpr_Sat_isholiday;

			}
			set { 
				sdt.gxTpr_Sat_isholiday = value;
			}
		}

		[DataMember(Name="Sun_IsHoliday", Order=17)]
		public bool gxTpr_Sun_isholiday
		{
			get { 
				return sdt.gxTpr_Sun_isholiday;

			}
			set { 
				sdt.gxTpr_Sun_isholiday = value;
			}
		}

		[DataMember(Name="Mon_Formatted", Order=18)]
		public  string gxTpr_Mon_formatted
		{
			get { 
				return sdt.gxTpr_Mon_formatted;

			}
			set { 
				 sdt.gxTpr_Mon_formatted = value;
			}
		}

		[DataMember(Name="Tue_Formatted", Order=19)]
		public  string gxTpr_Tue_formatted
		{
			get { 
				return sdt.gxTpr_Tue_formatted;

			}
			set { 
				 sdt.gxTpr_Tue_formatted = value;
			}
		}

		[DataMember(Name="Wed_Formatted", Order=20)]
		public  string gxTpr_Wed_formatted
		{
			get { 
				return sdt.gxTpr_Wed_formatted;

			}
			set { 
				 sdt.gxTpr_Wed_formatted = value;
			}
		}

		[DataMember(Name="Thu_Formatted", Order=21)]
		public  string gxTpr_Thu_formatted
		{
			get { 
				return sdt.gxTpr_Thu_formatted;

			}
			set { 
				 sdt.gxTpr_Thu_formatted = value;
			}
		}

		[DataMember(Name="Fri_Formatted", Order=22)]
		public  string gxTpr_Fri_formatted
		{
			get { 
				return sdt.gxTpr_Fri_formatted;

			}
			set { 
				 sdt.gxTpr_Fri_formatted = value;
			}
		}

		[DataMember(Name="Sat_Formatted", Order=23)]
		public  string gxTpr_Sat_formatted
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Sat_formatted);

			}
			set { 
				 sdt.gxTpr_Sat_formatted = value;
			}
		}

		[DataMember(Name="Sun_Formatted", Order=24)]
		public  string gxTpr_Sun_formatted
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Sun_formatted);

			}
			set { 
				 sdt.gxTpr_Sun_formatted = value;
			}
		}

		[DataMember(Name="Leave_Formatted", Order=25)]
		public  string gxTpr_Leave_formatted
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Leave_formatted);

			}
			set { 
				 sdt.gxTpr_Leave_formatted = value;
			}
		}

		[DataMember(Name="Total_Formatted", Order=26)]
		public  string gxTpr_Total_formatted
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Total_formatted);

			}
			set { 
				 sdt.gxTpr_Total_formatted = value;
			}
		}

		[DataMember(Name="Expected_Formatted", Order=27)]
		public  string gxTpr_Expected_formatted
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Expected_formatted);

			}
			set { 
				 sdt.gxTpr_Expected_formatted = value;
			}
		}


		#endregion

		public SdtSDTEmployeeWeekReport sdt
		{
			get { 
				return (SdtSDTEmployeeWeekReport)Sdt;
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
				sdt = new SdtSDTEmployeeWeekReport() ;
			}
		}
	}
	#endregion
}