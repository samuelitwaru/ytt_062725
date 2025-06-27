/*
				   File: type_SdtSDT_EmployeeBalanceAction
			Description: SDT_EmployeeBalanceAction
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
	[XmlRoot(ElementName="SDT_EmployeeBalanceAction")]
	[XmlType(TypeName="SDT_EmployeeBalanceAction" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDT_EmployeeBalanceAction : GxUserType
	{
		public SdtSDT_EmployeeBalanceAction( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_EmployeeBalanceAction_Type = "";

			gxTv_SdtSDT_EmployeeBalanceAction_Description = "";

		}

		public SdtSDT_EmployeeBalanceAction(IGxContext context)
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



			AddObjectProperty("Type", gxTpr_Type, false);


			AddObjectProperty("DurationInHours", gxTpr_Durationinhours, false);


			AddObjectProperty("DurationInDays", gxTpr_Durationindays, false);


			AddObjectProperty("Description", gxTpr_Description, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="StartDate")]
		[XmlElement(ElementName="StartDate" , IsNullable=true)]
		public string gxTpr_Startdate_Nullable
		{
			get {
				if ( gxTv_SdtSDT_EmployeeBalanceAction_Startdate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDT_EmployeeBalanceAction_Startdate).value ;
			}
			set {
				gxTv_SdtSDT_EmployeeBalanceAction_Startdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Startdate
		{
			get {
				return gxTv_SdtSDT_EmployeeBalanceAction_Startdate; 
			}
			set {
				gxTv_SdtSDT_EmployeeBalanceAction_Startdate = value;
				SetDirty("Startdate");
			}
		}


		[SoapElement(ElementName="EndDate")]
		[XmlElement(ElementName="EndDate" , IsNullable=true)]
		public string gxTpr_Enddate_Nullable
		{
			get {
				if ( gxTv_SdtSDT_EmployeeBalanceAction_Enddate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDT_EmployeeBalanceAction_Enddate).value ;
			}
			set {
				gxTv_SdtSDT_EmployeeBalanceAction_Enddate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Enddate
		{
			get {
				return gxTv_SdtSDT_EmployeeBalanceAction_Enddate; 
			}
			set {
				gxTv_SdtSDT_EmployeeBalanceAction_Enddate = value;
				SetDirty("Enddate");
			}
		}



		[SoapElement(ElementName="Type")]
		[XmlElement(ElementName="Type")]
		public string gxTpr_Type
		{
			get {
				return gxTv_SdtSDT_EmployeeBalanceAction_Type; 
			}
			set {
				gxTv_SdtSDT_EmployeeBalanceAction_Type = value;
				SetDirty("Type");
			}
		}



		[SoapElement(ElementName="DurationInHours")]
		[XmlElement(ElementName="DurationInHours")]
		public string gxTpr_Durationinhours_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDT_EmployeeBalanceAction_Durationinhours, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDT_EmployeeBalanceAction_Durationinhours = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Durationinhours
		{
			get {
				return gxTv_SdtSDT_EmployeeBalanceAction_Durationinhours; 
			}
			set {
				gxTv_SdtSDT_EmployeeBalanceAction_Durationinhours = value;
				SetDirty("Durationinhours");
			}
		}



		[SoapElement(ElementName="DurationInDays")]
		[XmlElement(ElementName="DurationInDays")]
		public string gxTpr_Durationindays_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDT_EmployeeBalanceAction_Durationindays, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDT_EmployeeBalanceAction_Durationindays = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Durationindays
		{
			get {
				return gxTv_SdtSDT_EmployeeBalanceAction_Durationindays; 
			}
			set {
				gxTv_SdtSDT_EmployeeBalanceAction_Durationindays = value;
				SetDirty("Durationindays");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtSDT_EmployeeBalanceAction_Description; 
			}
			set {
				gxTv_SdtSDT_EmployeeBalanceAction_Description = value;
				SetDirty("Description");
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
			gxTv_SdtSDT_EmployeeBalanceAction_Type = "";


			gxTv_SdtSDT_EmployeeBalanceAction_Description = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime gxTv_SdtSDT_EmployeeBalanceAction_Startdate;
		 

		protected DateTime gxTv_SdtSDT_EmployeeBalanceAction_Enddate;
		 

		protected string gxTv_SdtSDT_EmployeeBalanceAction_Type;
		 

		protected decimal gxTv_SdtSDT_EmployeeBalanceAction_Durationinhours;
		 

		protected decimal gxTv_SdtSDT_EmployeeBalanceAction_Durationindays;
		 

		protected string gxTv_SdtSDT_EmployeeBalanceAction_Description;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_EmployeeBalanceAction", Namespace="YTT_version4")]
	public class SdtSDT_EmployeeBalanceAction_RESTInterface : GxGenericCollectionItem<SdtSDT_EmployeeBalanceAction>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_EmployeeBalanceAction_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_EmployeeBalanceAction_RESTInterface( SdtSDT_EmployeeBalanceAction psdt ) : base(psdt)
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

		[DataMember(Name="Type", Order=2)]
		public  string gxTpr_Type
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Type);

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="DurationInHours", Order=3)]
		public decimal gxTpr_Durationinhours
		{
			get { 
				return sdt.gxTpr_Durationinhours;

			}
			set { 
				sdt.gxTpr_Durationinhours = value;
			}
		}

		[DataMember(Name="DurationInDays", Order=4)]
		public decimal gxTpr_Durationindays
		{
			get { 
				return sdt.gxTpr_Durationindays;

			}
			set { 
				sdt.gxTpr_Durationindays = value;
			}
		}

		[DataMember(Name="Description", Order=5)]
		public  string gxTpr_Description
		{
			get { 
				return sdt.gxTpr_Description;

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}


		#endregion

		public SdtSDT_EmployeeBalanceAction sdt
		{
			get { 
				return (SdtSDT_EmployeeBalanceAction)Sdt;
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
				sdt = new SdtSDT_EmployeeBalanceAction() ;
			}
		}
	}
	#endregion
}