/*
				   File: type_SdtSDTEmployeeLeaveDetails
			Description: SDTEmployeeLeaveDetails
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
	[XmlRoot(ElementName="SDTEmployeeLeaveDetails")]
	[XmlType(TypeName="SDTEmployeeLeaveDetails" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTEmployeeLeaveDetails : GxUserType
	{
		public SdtSDTEmployeeLeaveDetails( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTEmployeeLeaveDetails_Employeename = "";

			gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequeststartdatestring = "";

		}

		public SdtSDTEmployeeLeaveDetails(IGxContext context)
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
			AddObjectProperty("EmployeeId", gxTpr_Employeeid, false);


			AddObjectProperty("EmployeeName", gxTpr_Employeename, false);


			AddObjectProperty("FirstLeaveTypeId", gxTpr_Firstleavetypeid, false);


			AddObjectProperty("FirstLeaveRequestId", gxTpr_Firstleaverequestid, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Firstleaverequeststartdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Firstleaverequeststartdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Firstleaverequeststartdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("FirstLeaveRequestStartDate", sDateCnv, false);



			AddObjectProperty("FirstLeaveRequestStartDateString", gxTpr_Firstleaverequeststartdatestring, false);


			AddObjectProperty("FirstLeaveRequestDuration", gxTpr_Firstleaverequestduration, false);


			AddObjectProperty("LeaveRequestCount", gxTpr_Leaverequestcount, false);


			AddObjectProperty("EmployeeBalance", gxTpr_Employeebalance, false);

			if (gxTv_SdtSDTEmployeeLeaveDetails_Leaverequest != null)
			{
				AddObjectProperty("LeaveRequest", gxTv_SdtSDTEmployeeLeaveDetails_Leaverequest, false);
			}
			if (gxTv_SdtSDTEmployeeLeaveDetails_Leavetype != null)
			{
				AddObjectProperty("LeaveType", gxTv_SdtSDTEmployeeLeaveDetails_Leavetype, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="EmployeeId")]
		[XmlElement(ElementName="EmployeeId")]
		public long gxTpr_Employeeid
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_Employeeid; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_Employeeid = value;
				SetDirty("Employeeid");
			}
		}




		[SoapElement(ElementName="EmployeeName")]
		[XmlElement(ElementName="EmployeeName")]
		public string gxTpr_Employeename
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_Employeename; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_Employeename = value;
				SetDirty("Employeename");
			}
		}




		[SoapElement(ElementName="FirstLeaveTypeId")]
		[XmlElement(ElementName="FirstLeaveTypeId")]
		public long gxTpr_Firstleavetypeid
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_Firstleavetypeid; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_Firstleavetypeid = value;
				SetDirty("Firstleavetypeid");
			}
		}




		[SoapElement(ElementName="FirstLeaveRequestId")]
		[XmlElement(ElementName="FirstLeaveRequestId")]
		public long gxTpr_Firstleaverequestid
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequestid; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequestid = value;
				SetDirty("Firstleaverequestid");
			}
		}



		[SoapElement(ElementName="FirstLeaveRequestStartDate")]
		[XmlElement(ElementName="FirstLeaveRequestStartDate" , IsNullable=true)]
		public string gxTpr_Firstleaverequeststartdate_Nullable
		{
			get {
				if ( gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequeststartdate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequeststartdate).value ;
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequeststartdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Firstleaverequeststartdate
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequeststartdate; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequeststartdate = value;
				SetDirty("Firstleaverequeststartdate");
			}
		}



		[SoapElement(ElementName="FirstLeaveRequestStartDateString")]
		[XmlElement(ElementName="FirstLeaveRequestStartDateString")]
		public string gxTpr_Firstleaverequeststartdatestring
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequeststartdatestring; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequeststartdatestring = value;
				SetDirty("Firstleaverequeststartdatestring");
			}
		}



		[SoapElement(ElementName="FirstLeaveRequestDuration")]
		[XmlElement(ElementName="FirstLeaveRequestDuration")]
		public string gxTpr_Firstleaverequestduration_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequestduration, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequestduration = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Firstleaverequestduration
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequestduration; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequestduration = value;
				SetDirty("Firstleaverequestduration");
			}
		}




		[SoapElement(ElementName="LeaveRequestCount")]
		[XmlElement(ElementName="LeaveRequestCount")]
		public short gxTpr_Leaverequestcount
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_Leaverequestcount; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_Leaverequestcount = value;
				SetDirty("Leaverequestcount");
			}
		}



		[SoapElement(ElementName="EmployeeBalance")]
		[XmlElement(ElementName="EmployeeBalance")]
		public string gxTpr_Employeebalance_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTEmployeeLeaveDetails_Employeebalance, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_Employeebalance = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Employeebalance
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_Employeebalance; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_Employeebalance = value;
				SetDirty("Employeebalance");
			}
		}




		[SoapElement(ElementName="LeaveRequest" )]
		[XmlArray(ElementName="LeaveRequest"  )]
		[XmlArrayItemAttribute(ElementName="LeaveRequestItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTEmployeeLeaveDetails_LeaveRequestItem> gxTpr_Leaverequest
		{
			get {
				if ( gxTv_SdtSDTEmployeeLeaveDetails_Leaverequest == null )
				{
					gxTv_SdtSDTEmployeeLeaveDetails_Leaverequest = new GXBaseCollection<SdtSDTEmployeeLeaveDetails_LeaveRequestItem>( context, "SDTEmployeeLeaveDetails.LeaveRequestItem", "");
				}
				return gxTv_SdtSDTEmployeeLeaveDetails_Leaverequest;
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_Leaverequest_N = false;
				gxTv_SdtSDTEmployeeLeaveDetails_Leaverequest = value;
				SetDirty("Leaverequest");
			}
		}

		public void gxTv_SdtSDTEmployeeLeaveDetails_Leaverequest_SetNull()
		{
			gxTv_SdtSDTEmployeeLeaveDetails_Leaverequest_N = true;
			gxTv_SdtSDTEmployeeLeaveDetails_Leaverequest = null;
		}

		public bool gxTv_SdtSDTEmployeeLeaveDetails_Leaverequest_IsNull()
		{
			return gxTv_SdtSDTEmployeeLeaveDetails_Leaverequest == null;
		}
		public bool ShouldSerializegxTpr_Leaverequest_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTEmployeeLeaveDetails_Leaverequest != null && gxTv_SdtSDTEmployeeLeaveDetails_Leaverequest.Count > 0;

		}



		[SoapElement(ElementName="LeaveType" )]
		[XmlArray(ElementName="LeaveType"  )]
		[XmlArrayItemAttribute(ElementName="LeaveTypeItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTEmployeeLeaveDetails_LeaveTypeItem> gxTpr_Leavetype
		{
			get {
				if ( gxTv_SdtSDTEmployeeLeaveDetails_Leavetype == null )
				{
					gxTv_SdtSDTEmployeeLeaveDetails_Leavetype = new GXBaseCollection<SdtSDTEmployeeLeaveDetails_LeaveTypeItem>( context, "SDTEmployeeLeaveDetails.LeaveTypeItem", "");
				}
				return gxTv_SdtSDTEmployeeLeaveDetails_Leavetype;
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_Leavetype_N = false;
				gxTv_SdtSDTEmployeeLeaveDetails_Leavetype = value;
				SetDirty("Leavetype");
			}
		}

		public void gxTv_SdtSDTEmployeeLeaveDetails_Leavetype_SetNull()
		{
			gxTv_SdtSDTEmployeeLeaveDetails_Leavetype_N = true;
			gxTv_SdtSDTEmployeeLeaveDetails_Leavetype = null;
		}

		public bool gxTv_SdtSDTEmployeeLeaveDetails_Leavetype_IsNull()
		{
			return gxTv_SdtSDTEmployeeLeaveDetails_Leavetype == null;
		}
		public bool ShouldSerializegxTpr_Leavetype_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTEmployeeLeaveDetails_Leavetype != null && gxTv_SdtSDTEmployeeLeaveDetails_Leavetype.Count > 0;

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
			gxTv_SdtSDTEmployeeLeaveDetails_Employeename = "";



			gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequeststartdatestring = "";




			gxTv_SdtSDTEmployeeLeaveDetails_Leaverequest_N = true;


			gxTv_SdtSDTEmployeeLeaveDetails_Leavetype_N = true;

			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected long gxTv_SdtSDTEmployeeLeaveDetails_Employeeid;
		 

		protected string gxTv_SdtSDTEmployeeLeaveDetails_Employeename;
		 

		protected long gxTv_SdtSDTEmployeeLeaveDetails_Firstleavetypeid;
		 

		protected long gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequestid;
		 

		protected DateTime gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequeststartdate;
		 

		protected string gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequeststartdatestring;
		 

		protected decimal gxTv_SdtSDTEmployeeLeaveDetails_Firstleaverequestduration;
		 

		protected short gxTv_SdtSDTEmployeeLeaveDetails_Leaverequestcount;
		 

		protected decimal gxTv_SdtSDTEmployeeLeaveDetails_Employeebalance;
		 
		protected bool gxTv_SdtSDTEmployeeLeaveDetails_Leaverequest_N;
		protected GXBaseCollection<SdtSDTEmployeeLeaveDetails_LeaveRequestItem> gxTv_SdtSDTEmployeeLeaveDetails_Leaverequest = null; 

		protected bool gxTv_SdtSDTEmployeeLeaveDetails_Leavetype_N;
		protected GXBaseCollection<SdtSDTEmployeeLeaveDetails_LeaveTypeItem> gxTv_SdtSDTEmployeeLeaveDetails_Leavetype = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTEmployeeLeaveDetails", Namespace="YTT_version4")]
	public class SdtSDTEmployeeLeaveDetails_RESTInterface : GxGenericCollectionItem<SdtSDTEmployeeLeaveDetails>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTEmployeeLeaveDetails_RESTInterface( ) : base()
		{	
		}

		public SdtSDTEmployeeLeaveDetails_RESTInterface( SdtSDTEmployeeLeaveDetails psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="EmployeeId", Order=0)]
		public  string gxTpr_Employeeid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Employeeid, 10, 0));

			}
			set { 
				sdt.gxTpr_Employeeid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="EmployeeName", Order=1)]
		public  string gxTpr_Employeename
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Employeename);

			}
			set { 
				 sdt.gxTpr_Employeename = value;
			}
		}

		[DataMember(Name="FirstLeaveTypeId", Order=2)]
		public  string gxTpr_Firstleavetypeid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Firstleavetypeid, 10, 0));

			}
			set { 
				sdt.gxTpr_Firstleavetypeid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FirstLeaveRequestId", Order=3)]
		public  string gxTpr_Firstleaverequestid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Firstleaverequestid, 10, 0));

			}
			set { 
				sdt.gxTpr_Firstleaverequestid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FirstLeaveRequestStartDate", Order=4)]
		public  string gxTpr_Firstleaverequeststartdate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Firstleaverequeststartdate);

			}
			set { 
				sdt.gxTpr_Firstleaverequeststartdate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="FirstLeaveRequestStartDateString", Order=5)]
		public  string gxTpr_Firstleaverequeststartdatestring
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Firstleaverequeststartdatestring);

			}
			set { 
				 sdt.gxTpr_Firstleaverequeststartdatestring = value;
			}
		}

		[DataMember(Name="FirstLeaveRequestDuration", Order=6)]
		public decimal gxTpr_Firstleaverequestduration
		{
			get { 
				return sdt.gxTpr_Firstleaverequestduration;

			}
			set { 
				sdt.gxTpr_Firstleaverequestduration = value;
			}
		}

		[DataMember(Name="LeaveRequestCount", Order=7)]
		public short gxTpr_Leaverequestcount
		{
			get { 
				return sdt.gxTpr_Leaverequestcount;

			}
			set { 
				sdt.gxTpr_Leaverequestcount = value;
			}
		}

		[DataMember(Name="EmployeeBalance", Order=8)]
		public decimal gxTpr_Employeebalance
		{
			get { 
				return sdt.gxTpr_Employeebalance;

			}
			set { 
				sdt.gxTpr_Employeebalance = value;
			}
		}

		[DataMember(Name="LeaveRequest", Order=9, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTEmployeeLeaveDetails_LeaveRequestItem_RESTInterface> gxTpr_Leaverequest
		{
			get {
				if (sdt.ShouldSerializegxTpr_Leaverequest_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTEmployeeLeaveDetails_LeaveRequestItem_RESTInterface>(sdt.gxTpr_Leaverequest);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Leaverequest);
			}
		}

		[DataMember(Name="LeaveType", Order=10, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTEmployeeLeaveDetails_LeaveTypeItem_RESTInterface> gxTpr_Leavetype
		{
			get {
				if (sdt.ShouldSerializegxTpr_Leavetype_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTEmployeeLeaveDetails_LeaveTypeItem_RESTInterface>(sdt.gxTpr_Leavetype);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Leavetype);
			}
		}


		#endregion

		public SdtSDTEmployeeLeaveDetails sdt
		{
			get { 
				return (SdtSDTEmployeeLeaveDetails)Sdt;
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
				sdt = new SdtSDTEmployeeLeaveDetails() ;
			}
		}
	}
	#endregion
}