/*
				   File: type_SdtSDTLeaveType
			Description: SDTLeaveType
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
	[XmlRoot(ElementName="SDTLeaveType")]
	[XmlType(TypeName="SDTLeaveType" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTLeaveType : GxUserType
	{
		public SdtSDTLeaveType( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTLeaveType_Leavetypename = "";

			gxTv_SdtSDTLeaveType_Leavetypevacationleave = "";

			gxTv_SdtSDTLeaveType_Leavetypeloggingworkhours = "";

			gxTv_SdtSDTLeaveType_Leavetypecolorpending = "";

			gxTv_SdtSDTLeaveType_Leavetypecolorapproved = "";

		}

		public SdtSDTLeaveType(IGxContext context)
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


			AddObjectProperty("LeaveTypeVacationLeave", gxTpr_Leavetypevacationleave, false);


			AddObjectProperty("LeaveTypeLoggingWorkHours", gxTpr_Leavetypeloggingworkhours, false);


			AddObjectProperty("LeaveTypeColorPending", gxTpr_Leavetypecolorpending, false);


			AddObjectProperty("LeaveTypeColorApproved", gxTpr_Leavetypecolorapproved, false);


			AddObjectProperty("CompanyId", gxTpr_Companyid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="LeaveTypeId")]
		[XmlElement(ElementName="LeaveTypeId")]
		public long gxTpr_Leavetypeid
		{
			get {
				return gxTv_SdtSDTLeaveType_Leavetypeid; 
			}
			set {
				gxTv_SdtSDTLeaveType_Leavetypeid = value;
				SetDirty("Leavetypeid");
			}
		}




		[SoapElement(ElementName="LeaveTypeName")]
		[XmlElement(ElementName="LeaveTypeName")]
		public string gxTpr_Leavetypename
		{
			get {
				return gxTv_SdtSDTLeaveType_Leavetypename; 
			}
			set {
				gxTv_SdtSDTLeaveType_Leavetypename = value;
				SetDirty("Leavetypename");
			}
		}




		[SoapElement(ElementName="LeaveTypeVacationLeave")]
		[XmlElement(ElementName="LeaveTypeVacationLeave")]
		public string gxTpr_Leavetypevacationleave
		{
			get {
				return gxTv_SdtSDTLeaveType_Leavetypevacationleave; 
			}
			set {
				gxTv_SdtSDTLeaveType_Leavetypevacationleave = value;
				SetDirty("Leavetypevacationleave");
			}
		}




		[SoapElement(ElementName="LeaveTypeLoggingWorkHours")]
		[XmlElement(ElementName="LeaveTypeLoggingWorkHours")]
		public string gxTpr_Leavetypeloggingworkhours
		{
			get {
				return gxTv_SdtSDTLeaveType_Leavetypeloggingworkhours; 
			}
			set {
				gxTv_SdtSDTLeaveType_Leavetypeloggingworkhours = value;
				SetDirty("Leavetypeloggingworkhours");
			}
		}




		[SoapElement(ElementName="LeaveTypeColorPending")]
		[XmlElement(ElementName="LeaveTypeColorPending")]
		public string gxTpr_Leavetypecolorpending
		{
			get {
				return gxTv_SdtSDTLeaveType_Leavetypecolorpending; 
			}
			set {
				gxTv_SdtSDTLeaveType_Leavetypecolorpending = value;
				SetDirty("Leavetypecolorpending");
			}
		}




		[SoapElement(ElementName="LeaveTypeColorApproved")]
		[XmlElement(ElementName="LeaveTypeColorApproved")]
		public string gxTpr_Leavetypecolorapproved
		{
			get {
				return gxTv_SdtSDTLeaveType_Leavetypecolorapproved; 
			}
			set {
				gxTv_SdtSDTLeaveType_Leavetypecolorapproved = value;
				SetDirty("Leavetypecolorapproved");
			}
		}




		[SoapElement(ElementName="CompanyId")]
		[XmlElement(ElementName="CompanyId")]
		public long gxTpr_Companyid
		{
			get {
				return gxTv_SdtSDTLeaveType_Companyid; 
			}
			set {
				gxTv_SdtSDTLeaveType_Companyid = value;
				SetDirty("Companyid");
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
			gxTv_SdtSDTLeaveType_Leavetypename = "";
			gxTv_SdtSDTLeaveType_Leavetypevacationleave = "";
			gxTv_SdtSDTLeaveType_Leavetypeloggingworkhours = "";
			gxTv_SdtSDTLeaveType_Leavetypecolorpending = "";
			gxTv_SdtSDTLeaveType_Leavetypecolorapproved = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTLeaveType_Leavetypeid;
		 

		protected string gxTv_SdtSDTLeaveType_Leavetypename;
		 

		protected string gxTv_SdtSDTLeaveType_Leavetypevacationleave;
		 

		protected string gxTv_SdtSDTLeaveType_Leavetypeloggingworkhours;
		 

		protected string gxTv_SdtSDTLeaveType_Leavetypecolorpending;
		 

		protected string gxTv_SdtSDTLeaveType_Leavetypecolorapproved;
		 

		protected long gxTv_SdtSDTLeaveType_Companyid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTLeaveType", Namespace="YTT_version4")]
	public class SdtSDTLeaveType_RESTInterface : GxGenericCollectionItem<SdtSDTLeaveType>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTLeaveType_RESTInterface( ) : base()
		{	
		}

		public SdtSDTLeaveType_RESTInterface( SdtSDTLeaveType psdt ) : base(psdt)
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

		[DataMember(Name="LeaveTypeVacationLeave", Order=2)]
		public  string gxTpr_Leavetypevacationleave
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Leavetypevacationleave);

			}
			set { 
				 sdt.gxTpr_Leavetypevacationleave = value;
			}
		}

		[DataMember(Name="LeaveTypeLoggingWorkHours", Order=3)]
		public  string gxTpr_Leavetypeloggingworkhours
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Leavetypeloggingworkhours);

			}
			set { 
				 sdt.gxTpr_Leavetypeloggingworkhours = value;
			}
		}

		[DataMember(Name="LeaveTypeColorPending", Order=4)]
		public  string gxTpr_Leavetypecolorpending
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Leavetypecolorpending);

			}
			set { 
				 sdt.gxTpr_Leavetypecolorpending = value;
			}
		}

		[DataMember(Name="LeaveTypeColorApproved", Order=5)]
		public  string gxTpr_Leavetypecolorapproved
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Leavetypecolorapproved);

			}
			set { 
				 sdt.gxTpr_Leavetypecolorapproved = value;
			}
		}

		[DataMember(Name="CompanyId", Order=6)]
		public  string gxTpr_Companyid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Companyid, 10, 0));

			}
			set { 
				sdt.gxTpr_Companyid = (long) NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDTLeaveType sdt
		{
			get { 
				return (SdtSDTLeaveType)Sdt;
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
				sdt = new SdtSDTLeaveType() ;
			}
		}
	}
	#endregion
}