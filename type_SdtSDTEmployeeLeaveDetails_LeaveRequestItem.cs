/*
				   File: type_SdtSDTEmployeeLeaveDetails_LeaveRequestItem
			Description: LeaveRequest
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
	[XmlRoot(ElementName="SDTEmployeeLeaveDetails.LeaveRequestItem")]
	[XmlType(TypeName="SDTEmployeeLeaveDetails.LeaveRequestItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTEmployeeLeaveDetails_LeaveRequestItem : GxUserType
	{
		public SdtSDTEmployeeLeaveDetails_LeaveRequestItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequeststartdatestring = "";

		}

		public SdtSDTEmployeeLeaveDetails_LeaveRequestItem(IGxContext context)
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


			AddObjectProperty("LeaveRequestId", gxTpr_Leaverequestid, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Leaverequeststartdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Leaverequeststartdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Leaverequeststartdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("LeaveRequestStartDate", sDateCnv, false);



			AddObjectProperty("LeaveRequestStartDateString", gxTpr_Leaverequeststartdatestring, false);


			AddObjectProperty("LeaveRequestDuration", gxTpr_Leaverequestduration, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="LeaveTypeId")]
		[XmlElement(ElementName="LeaveTypeId")]
		public long gxTpr_Leavetypeid
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leavetypeid; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leavetypeid = value;
				SetDirty("Leavetypeid");
			}
		}




		[SoapElement(ElementName="LeaveRequestId")]
		[XmlElement(ElementName="LeaveRequestId")]
		public long gxTpr_Leaverequestid
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequestid; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequestid = value;
				SetDirty("Leaverequestid");
			}
		}



		[SoapElement(ElementName="LeaveRequestStartDate")]
		[XmlElement(ElementName="LeaveRequestStartDate" , IsNullable=true)]
		public string gxTpr_Leaverequeststartdate_Nullable
		{
			get {
				if ( gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequeststartdate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequeststartdate).value ;
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequeststartdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Leaverequeststartdate
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequeststartdate; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequeststartdate = value;
				SetDirty("Leaverequeststartdate");
			}
		}



		[SoapElement(ElementName="LeaveRequestStartDateString")]
		[XmlElement(ElementName="LeaveRequestStartDateString")]
		public string gxTpr_Leaverequeststartdatestring
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequeststartdatestring; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequeststartdatestring = value;
				SetDirty("Leaverequeststartdatestring");
			}
		}



		[SoapElement(ElementName="LeaveRequestDuration")]
		[XmlElement(ElementName="LeaveRequestDuration")]
		public string gxTpr_Leaverequestduration_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequestduration, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequestduration = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Leaverequestduration
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequestduration; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequestduration = value;
				SetDirty("Leaverequestduration");
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
			gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequeststartdatestring = "";

			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected long gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leavetypeid;
		 

		protected long gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequestid;
		 

		protected DateTime gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequeststartdate;
		 

		protected string gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequeststartdatestring;
		 

		protected decimal gxTv_SdtSDTEmployeeLeaveDetails_LeaveRequestItem_Leaverequestduration;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTEmployeeLeaveDetails.LeaveRequestItem", Namespace="YTT_version4")]
	public class SdtSDTEmployeeLeaveDetails_LeaveRequestItem_RESTInterface : GxGenericCollectionItem<SdtSDTEmployeeLeaveDetails_LeaveRequestItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTEmployeeLeaveDetails_LeaveRequestItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTEmployeeLeaveDetails_LeaveRequestItem_RESTInterface( SdtSDTEmployeeLeaveDetails_LeaveRequestItem psdt ) : base(psdt)
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

		[DataMember(Name="LeaveRequestId", Order=1)]
		public  string gxTpr_Leaverequestid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Leaverequestid, 10, 0));

			}
			set { 
				sdt.gxTpr_Leaverequestid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="LeaveRequestStartDate", Order=2)]
		public  string gxTpr_Leaverequeststartdate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Leaverequeststartdate);

			}
			set { 
				sdt.gxTpr_Leaverequeststartdate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="LeaveRequestStartDateString", Order=3)]
		public  string gxTpr_Leaverequeststartdatestring
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Leaverequeststartdatestring);

			}
			set { 
				 sdt.gxTpr_Leaverequeststartdatestring = value;
			}
		}

		[DataMember(Name="LeaveRequestDuration", Order=4)]
		public decimal gxTpr_Leaverequestduration
		{
			get { 
				return sdt.gxTpr_Leaverequestduration;

			}
			set { 
				sdt.gxTpr_Leaverequestduration = value;
			}
		}


		#endregion

		public SdtSDTEmployeeLeaveDetails_LeaveRequestItem sdt
		{
			get { 
				return (SdtSDTEmployeeLeaveDetails_LeaveRequestItem)Sdt;
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
				sdt = new SdtSDTEmployeeLeaveDetails_LeaveRequestItem() ;
			}
		}
	}
	#endregion
}