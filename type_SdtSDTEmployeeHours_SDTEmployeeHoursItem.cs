/*
				   File: type_SdtSDTEmployeeHours_SDTEmployeeHoursItem
			Description: SDTEmployeeHours
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
	[XmlRoot(ElementName="SDTEmployeeHoursItem")]
	[XmlType(TypeName="SDTEmployeeHoursItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTEmployeeHours_SDTEmployeeHoursItem : GxUserType
	{
		public SdtSDTEmployeeHours_SDTEmployeeHoursItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Employeename = "";

			gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Formattedleavehours = "";

			gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Formattedworkhours = "";

		}

		public SdtSDTEmployeeHours_SDTEmployeeHoursItem(IGxContext context)
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
				mapper["Leave Hours"] = "Leavehours";
				mapper["Work Hours"] = "Workhours";

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


			AddObjectProperty("Leave Hours", gxTpr_Leavehours, false);


			AddObjectProperty("Work Hours", gxTpr_Workhours, false);


			AddObjectProperty("FormattedLeaveHours", gxTpr_Formattedleavehours, false);


			AddObjectProperty("FormattedWorkHours", gxTpr_Formattedworkhours, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="EmployeeName")]
		[XmlElement(ElementName="EmployeeName")]
		public string gxTpr_Employeename
		{
			get {
				return gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Employeename; 
			}
			set {
				gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Employeename = value;
				SetDirty("Employeename");
			}
		}




		[SoapElement(ElementName="LeaveHours")]
		[XmlElement(ElementName="LeaveHours")]
		public long gxTpr_Leavehours
		{
			get {
				return gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Leavehours; 
			}
			set {
				gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Leavehours = value;
				SetDirty("Leavehours");
			}
		}




		[SoapElement(ElementName="WorkHours")]
		[XmlElement(ElementName="WorkHours")]
		public long gxTpr_Workhours
		{
			get {
				return gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Workhours; 
			}
			set {
				gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Workhours = value;
				SetDirty("Workhours");
			}
		}




		[SoapElement(ElementName="FormattedLeaveHours")]
		[XmlElement(ElementName="FormattedLeaveHours")]
		public string gxTpr_Formattedleavehours
		{
			get {
				return gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Formattedleavehours; 
			}
			set {
				gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Formattedleavehours = value;
				SetDirty("Formattedleavehours");
			}
		}




		[SoapElement(ElementName="FormattedWorkHours")]
		[XmlElement(ElementName="FormattedWorkHours")]
		public string gxTpr_Formattedworkhours
		{
			get {
				return gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Formattedworkhours; 
			}
			set {
				gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Formattedworkhours = value;
				SetDirty("Formattedworkhours");
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
			gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Employeename = "";


			gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Formattedleavehours = "";
			gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Formattedworkhours = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Employeename;
		 

		protected long gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Leavehours;
		 

		protected long gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Workhours;
		 

		protected string gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Formattedleavehours;
		 

		protected string gxTv_SdtSDTEmployeeHours_SDTEmployeeHoursItem_Formattedworkhours;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTEmployeeHoursItem", Namespace="YTT_version4")]
	public class SdtSDTEmployeeHours_SDTEmployeeHoursItem_RESTInterface : GxGenericCollectionItem<SdtSDTEmployeeHours_SDTEmployeeHoursItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTEmployeeHours_SDTEmployeeHoursItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTEmployeeHours_SDTEmployeeHoursItem_RESTInterface( SdtSDTEmployeeHours_SDTEmployeeHoursItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="EmployeeName", Order=0)]
		public  string gxTpr_Employeename
		{
			get { 
				return sdt.gxTpr_Employeename;

			}
			set { 
				 sdt.gxTpr_Employeename = value;
			}
		}

		[DataMember(Name="Leave Hours", Order=1)]
		public  string gxTpr_Leavehours
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Leavehours, 10, 0));

			}
			set { 
				sdt.gxTpr_Leavehours = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Work Hours", Order=2)]
		public  string gxTpr_Workhours
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Workhours, 10, 0));

			}
			set { 
				sdt.gxTpr_Workhours = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FormattedLeaveHours", Order=3)]
		public  string gxTpr_Formattedleavehours
		{
			get { 
				return sdt.gxTpr_Formattedleavehours;

			}
			set { 
				 sdt.gxTpr_Formattedleavehours = value;
			}
		}

		[DataMember(Name="FormattedWorkHours", Order=4)]
		public  string gxTpr_Formattedworkhours
		{
			get { 
				return sdt.gxTpr_Formattedworkhours;

			}
			set { 
				 sdt.gxTpr_Formattedworkhours = value;
			}
		}


		#endregion

		public SdtSDTEmployeeHours_SDTEmployeeHoursItem sdt
		{
			get { 
				return (SdtSDTEmployeeHours_SDTEmployeeHoursItem)Sdt;
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
				sdt = new SdtSDTEmployeeHours_SDTEmployeeHoursItem() ;
			}
		}
	}
	#endregion
}