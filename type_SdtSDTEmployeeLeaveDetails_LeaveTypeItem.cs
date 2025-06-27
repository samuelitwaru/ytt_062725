/*
				   File: type_SdtSDTEmployeeLeaveDetails_LeaveTypeItem
			Description: LeaveType
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
	[XmlRoot(ElementName="SDTEmployeeLeaveDetails.LeaveTypeItem")]
	[XmlType(TypeName="SDTEmployeeLeaveDetails.LeaveTypeItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTEmployeeLeaveDetails_LeaveTypeItem : GxUserType
	{
		public SdtSDTEmployeeLeaveDetails_LeaveTypeItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leavetypename = "";

		}

		public SdtSDTEmployeeLeaveDetails_LeaveTypeItem(IGxContext context)
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
			AddObjectProperty("LeaveTypeId", gxTpr_Leavetypeid, false);


			AddObjectProperty("LeaveTypeName", gxTpr_Leavetypename, false);


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



			AddObjectProperty("FirstLeaveRequestDuration", gxTpr_Firstleaverequestduration, false);


			AddObjectProperty("LeaveRequestCount", gxTpr_Leaverequestcount, false);

			if (gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequest != null)
			{
				AddObjectProperty("LeaveRequest", gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequest, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="LeaveTypeId")]
		[XmlElement(ElementName="LeaveTypeId")]
		public long gxTpr_Leavetypeid
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leavetypeid; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leavetypeid = value;
				SetDirty("Leavetypeid");
			}
		}




		[SoapElement(ElementName="LeaveTypeName")]
		[XmlElement(ElementName="LeaveTypeName")]
		public string gxTpr_Leavetypename
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leavetypename; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leavetypename = value;
				SetDirty("Leavetypename");
			}
		}




		[SoapElement(ElementName="FirstLeaveRequestId")]
		[XmlElement(ElementName="FirstLeaveRequestId")]
		public long gxTpr_Firstleaverequestid
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Firstleaverequestid; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Firstleaverequestid = value;
				SetDirty("Firstleaverequestid");
			}
		}



		[SoapElement(ElementName="FirstLeaveRequestStartDate")]
		[XmlElement(ElementName="FirstLeaveRequestStartDate" , IsNullable=true)]
		public string gxTpr_Firstleaverequeststartdate_Nullable
		{
			get {
				if ( gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Firstleaverequeststartdate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Firstleaverequeststartdate).value ;
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Firstleaverequeststartdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Firstleaverequeststartdate
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Firstleaverequeststartdate; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Firstleaverequeststartdate = value;
				SetDirty("Firstleaverequeststartdate");
			}
		}


		[SoapElement(ElementName="FirstLeaveRequestDuration")]
		[XmlElement(ElementName="FirstLeaveRequestDuration")]
		public string gxTpr_Firstleaverequestduration_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Firstleaverequestduration, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Firstleaverequestduration = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Firstleaverequestduration
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Firstleaverequestduration; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Firstleaverequestduration = value;
				SetDirty("Firstleaverequestduration");
			}
		}




		[SoapElement(ElementName="LeaveRequestCount")]
		[XmlElement(ElementName="LeaveRequestCount")]
		public short gxTpr_Leaverequestcount
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequestcount; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequestcount = value;
				SetDirty("Leaverequestcount");
			}
		}




		[SoapElement(ElementName="LeaveRequest" )]
		[XmlArray(ElementName="LeaveRequest"  )]
		[XmlArrayItemAttribute(ElementName="LeaveRequestItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem> gxTpr_Leaverequest
		{
			get {
				if ( gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequest == null )
				{
					gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequest = new GXBaseCollection<SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem>( context, "SDTEmployeeLeaveDetails.LeaveTypeItem.LeaveRequestItem", "");
				}
				return gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequest;
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequest_N = false;
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequest = value;
				SetDirty("Leaverequest");
			}
		}

		public void gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequest_SetNull()
		{
			gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequest_N = true;
			gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequest = null;
		}

		public bool gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequest_IsNull()
		{
			return gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequest == null;
		}
		public bool ShouldSerializegxTpr_Leaverequest_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequest != null && gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequest.Count > 0;

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
			gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leavetypename = "";





			gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequest_N = true;

			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected long gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leavetypeid;
		 

		protected string gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leavetypename;
		 

		protected long gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Firstleaverequestid;
		 

		protected DateTime gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Firstleaverequeststartdate;
		 

		protected decimal gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Firstleaverequestduration;
		 

		protected short gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequestcount;
		 
		protected bool gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequest_N;
		protected GXBaseCollection<SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem> gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_Leaverequest = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTEmployeeLeaveDetails.LeaveTypeItem", Namespace="YTT_version4")]
	public class SdtSDTEmployeeLeaveDetails_LeaveTypeItem_RESTInterface : GxGenericCollectionItem<SdtSDTEmployeeLeaveDetails_LeaveTypeItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTEmployeeLeaveDetails_LeaveTypeItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTEmployeeLeaveDetails_LeaveTypeItem_RESTInterface( SdtSDTEmployeeLeaveDetails_LeaveTypeItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="LeaveTypeId", Order=0)]
		public  string gxTpr_Leavetypeid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Leavetypeid, 10, 0));

			}
			set { 
				sdt.gxTpr_Leavetypeid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="LeaveTypeName", Order=1)]
		public  string gxTpr_Leavetypename
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Leavetypename);

			}
			set { 
				 sdt.gxTpr_Leavetypename = value;
			}
		}

		[DataMember(Name="FirstLeaveRequestId", Order=2)]
		public  string gxTpr_Firstleaverequestid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Firstleaverequestid, 10, 0));

			}
			set { 
				sdt.gxTpr_Firstleaverequestid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FirstLeaveRequestStartDate", Order=3)]
		public  string gxTpr_Firstleaverequeststartdate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Firstleaverequeststartdate);

			}
			set { 
				sdt.gxTpr_Firstleaverequeststartdate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="FirstLeaveRequestDuration", Order=4)]
		public decimal gxTpr_Firstleaverequestduration
		{
			get { 
				return sdt.gxTpr_Firstleaverequestduration;

			}
			set { 
				sdt.gxTpr_Firstleaverequestduration = value;
			}
		}

		[DataMember(Name="LeaveRequestCount", Order=5)]
		public short gxTpr_Leaverequestcount
		{
			get { 
				return sdt.gxTpr_Leaverequestcount;

			}
			set { 
				sdt.gxTpr_Leaverequestcount = value;
			}
		}

		[DataMember(Name="LeaveRequest", Order=6, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_RESTInterface> gxTpr_Leaverequest
		{
			get {
				if (sdt.ShouldSerializegxTpr_Leaverequest_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_RESTInterface>(sdt.gxTpr_Leaverequest);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Leaverequest);
			}
		}


		#endregion

		public SdtSDTEmployeeLeaveDetails_LeaveTypeItem sdt
		{
			get { 
				return (SdtSDTEmployeeLeaveDetails_LeaveTypeItem)Sdt;
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
				sdt = new SdtSDTEmployeeLeaveDetails_LeaveTypeItem() ;
			}
		}
	}
	#endregion
}