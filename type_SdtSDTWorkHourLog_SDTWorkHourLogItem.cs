/*
				   File: type_SdtSDTWorkHourLog_SDTWorkHourLogItem
			Description: SDTWorkHourLog
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
	[XmlRoot(ElementName="SDTWorkHourLogItem")]
	[XmlType(TypeName="SDTWorkHourLogItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTWorkHourLog_SDTWorkHourLogItem : GxUserType
	{
		public SdtSDTWorkHourLog_SDTWorkHourLogItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogduration = "";

			gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogdescription = "";

			gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Employeename = "";

			gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Projectname = "";

		}

		public SdtSDTWorkHourLog_SDTWorkHourLogItem(IGxContext context)
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
			AddObjectProperty("WorkHourLogId", gxTpr_Workhourlogid, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Workhourlogdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Workhourlogdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Workhourlogdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("WorkHourLogDate", sDateCnv, false);



			AddObjectProperty("WorkHourLogDuration", gxTpr_Workhourlogduration, false);


			AddObjectProperty("WorkHourLogHour", gxTpr_Workhourloghour, false);


			AddObjectProperty("WorkHourLogMinute", gxTpr_Workhourlogminute, false);


			AddObjectProperty("WorkHourLogDescription", gxTpr_Workhourlogdescription, false);


			AddObjectProperty("EmployeeId", gxTpr_Employeeid, false);


			AddObjectProperty("EmployeeName", gxTpr_Employeename, false);


			AddObjectProperty("ProjectId", gxTpr_Projectid, false);


			AddObjectProperty("ProjectName", gxTpr_Projectname, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="WorkHourLogId")]
		[XmlElement(ElementName="WorkHourLogId")]
		public long gxTpr_Workhourlogid
		{
			get {
				return gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogid; 
			}
			set {
				gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogid = value;
				SetDirty("Workhourlogid");
			}
		}



		[SoapElement(ElementName="WorkHourLogDate")]
		[XmlElement(ElementName="WorkHourLogDate" , IsNullable=true)]
		public string gxTpr_Workhourlogdate_Nullable
		{
			get {
				if ( gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogdate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogdate).value ;
			}
			set {
				gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Workhourlogdate
		{
			get {
				return gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogdate; 
			}
			set {
				gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogdate = value;
				SetDirty("Workhourlogdate");
			}
		}



		[SoapElement(ElementName="WorkHourLogDuration")]
		[XmlElement(ElementName="WorkHourLogDuration")]
		public string gxTpr_Workhourlogduration
		{
			get {
				return gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogduration; 
			}
			set {
				gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogduration = value;
				SetDirty("Workhourlogduration");
			}
		}




		[SoapElement(ElementName="WorkHourLogHour")]
		[XmlElement(ElementName="WorkHourLogHour")]
		public short gxTpr_Workhourloghour
		{
			get {
				return gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourloghour; 
			}
			set {
				gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourloghour = value;
				SetDirty("Workhourloghour");
			}
		}




		[SoapElement(ElementName="WorkHourLogMinute")]
		[XmlElement(ElementName="WorkHourLogMinute")]
		public short gxTpr_Workhourlogminute
		{
			get {
				return gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogminute; 
			}
			set {
				gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogminute = value;
				SetDirty("Workhourlogminute");
			}
		}




		[SoapElement(ElementName="WorkHourLogDescription")]
		[XmlElement(ElementName="WorkHourLogDescription")]
		public string gxTpr_Workhourlogdescription
		{
			get {
				return gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogdescription; 
			}
			set {
				gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogdescription = value;
				SetDirty("Workhourlogdescription");
			}
		}




		[SoapElement(ElementName="EmployeeId")]
		[XmlElement(ElementName="EmployeeId")]
		public long gxTpr_Employeeid
		{
			get {
				return gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Employeeid; 
			}
			set {
				gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Employeeid = value;
				SetDirty("Employeeid");
			}
		}




		[SoapElement(ElementName="EmployeeName")]
		[XmlElement(ElementName="EmployeeName")]
		public string gxTpr_Employeename
		{
			get {
				return gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Employeename; 
			}
			set {
				gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Employeename = value;
				SetDirty("Employeename");
			}
		}




		[SoapElement(ElementName="ProjectId")]
		[XmlElement(ElementName="ProjectId")]
		public long gxTpr_Projectid
		{
			get {
				return gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Projectid; 
			}
			set {
				gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Projectid = value;
				SetDirty("Projectid");
			}
		}




		[SoapElement(ElementName="ProjectName")]
		[XmlElement(ElementName="ProjectName")]
		public string gxTpr_Projectname
		{
			get {
				return gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Projectname; 
			}
			set {
				gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Projectname = value;
				SetDirty("Projectname");
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
			gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogduration = "";


			gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogdescription = "";

			gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Employeename = "";

			gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Projectname = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected long gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogid;
		 

		protected DateTime gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogdate;
		 

		protected string gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogduration;
		 

		protected short gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourloghour;
		 

		protected short gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogminute;
		 

		protected string gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Workhourlogdescription;
		 

		protected long gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Employeeid;
		 

		protected string gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Employeename;
		 

		protected long gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Projectid;
		 

		protected string gxTv_SdtSDTWorkHourLog_SDTWorkHourLogItem_Projectname;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTWorkHourLogItem", Namespace="YTT_version4")]
	public class SdtSDTWorkHourLog_SDTWorkHourLogItem_RESTInterface : GxGenericCollectionItem<SdtSDTWorkHourLog_SDTWorkHourLogItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTWorkHourLog_SDTWorkHourLogItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTWorkHourLog_SDTWorkHourLogItem_RESTInterface( SdtSDTWorkHourLog_SDTWorkHourLogItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="WorkHourLogId", Order=0)]
		public  string gxTpr_Workhourlogid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Workhourlogid, 10, 0));

			}
			set { 
				sdt.gxTpr_Workhourlogid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="WorkHourLogDate", Order=1)]
		public  string gxTpr_Workhourlogdate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Workhourlogdate);

			}
			set { 
				sdt.gxTpr_Workhourlogdate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="WorkHourLogDuration", Order=2)]
		public  string gxTpr_Workhourlogduration
		{
			get { 
				return sdt.gxTpr_Workhourlogduration;

			}
			set { 
				 sdt.gxTpr_Workhourlogduration = value;
			}
		}

		[DataMember(Name="WorkHourLogHour", Order=3)]
		public short gxTpr_Workhourloghour
		{
			get { 
				return sdt.gxTpr_Workhourloghour;

			}
			set { 
				sdt.gxTpr_Workhourloghour = value;
			}
		}

		[DataMember(Name="WorkHourLogMinute", Order=4)]
		public short gxTpr_Workhourlogminute
		{
			get { 
				return sdt.gxTpr_Workhourlogminute;

			}
			set { 
				sdt.gxTpr_Workhourlogminute = value;
			}
		}

		[DataMember(Name="WorkHourLogDescription", Order=5)]
		public  string gxTpr_Workhourlogdescription
		{
			get { 
				return sdt.gxTpr_Workhourlogdescription;

			}
			set { 
				 sdt.gxTpr_Workhourlogdescription = value;
			}
		}

		[DataMember(Name="EmployeeId", Order=6)]
		public  string gxTpr_Employeeid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Employeeid, 10, 0));

			}
			set { 
				sdt.gxTpr_Employeeid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="EmployeeName", Order=7)]
		public  string gxTpr_Employeename
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Employeename);

			}
			set { 
				 sdt.gxTpr_Employeename = value;
			}
		}

		[DataMember(Name="ProjectId", Order=8)]
		public  string gxTpr_Projectid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Projectid, 10, 0));

			}
			set { 
				sdt.gxTpr_Projectid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProjectName", Order=9)]
		public  string gxTpr_Projectname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Projectname);

			}
			set { 
				 sdt.gxTpr_Projectname = value;
			}
		}


		#endregion

		public SdtSDTWorkHourLog_SDTWorkHourLogItem sdt
		{
			get { 
				return (SdtSDTWorkHourLog_SDTWorkHourLogItem)Sdt;
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
				sdt = new SdtSDTWorkHourLog_SDTWorkHourLogItem() ;
			}
		}
	}
	#endregion
}