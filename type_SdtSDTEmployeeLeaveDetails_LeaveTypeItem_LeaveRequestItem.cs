/*
				   File: type_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem
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
	[XmlRoot(ElementName="SDTEmployeeLeaveDetails.LeaveTypeItem.LeaveRequestItem")]
	[XmlType(TypeName="SDTEmployeeLeaveDetails.LeaveTypeItem.LeaveRequestItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem : GxUserType
	{
		public SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem(IGxContext context)
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



			AddObjectProperty("LeaveRequestDuration", gxTpr_Leaverequestduration, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="LeaveRequestId")]
		[XmlElement(ElementName="LeaveRequestId")]
		public long gxTpr_Leaverequestid
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_Leaverequestid; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_Leaverequestid = value;
				SetDirty("Leaverequestid");
			}
		}



		[SoapElement(ElementName="LeaveRequestStartDate")]
		[XmlElement(ElementName="LeaveRequestStartDate" , IsNullable=true)]
		public string gxTpr_Leaverequeststartdate_Nullable
		{
			get {
				if ( gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_Leaverequeststartdate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_Leaverequeststartdate).value ;
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_Leaverequeststartdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Leaverequeststartdate
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_Leaverequeststartdate; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_Leaverequeststartdate = value;
				SetDirty("Leaverequeststartdate");
			}
		}


		[SoapElement(ElementName="LeaveRequestDuration")]
		[XmlElement(ElementName="LeaveRequestDuration")]
		public string gxTpr_Leaverequestduration_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_Leaverequestduration, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_Leaverequestduration = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Leaverequestduration
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_Leaverequestduration; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_Leaverequestduration = value;
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
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected long gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_Leaverequestid;
		 

		protected DateTime gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_Leaverequeststartdate;
		 

		protected decimal gxTv_SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_Leaverequestduration;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTEmployeeLeaveDetails.LeaveTypeItem.LeaveRequestItem", Namespace="YTT_version4")]
	public class SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_RESTInterface : GxGenericCollectionItem<SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem_RESTInterface( SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="LeaveRequestId", Order=0)]
		public  string gxTpr_Leaverequestid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Leaverequestid, 10, 0));

			}
			set { 
				sdt.gxTpr_Leaverequestid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="LeaveRequestStartDate", Order=1)]
		public  string gxTpr_Leaverequeststartdate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Leaverequeststartdate);

			}
			set { 
				sdt.gxTpr_Leaverequeststartdate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="LeaveRequestDuration", Order=2)]
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

		public SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem sdt
		{
			get { 
				return (SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem)Sdt;
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
				sdt = new SdtSDTEmployeeLeaveDetails_LeaveTypeItem_LeaveRequestItem() ;
			}
		}
	}
	#endregion
}