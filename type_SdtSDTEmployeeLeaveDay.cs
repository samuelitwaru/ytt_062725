/*
				   File: type_SdtSDTEmployeeLeaveDay
			Description: SDTEmployeeLeaveDay
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
	[XmlRoot(ElementName="SDTEmployeeLeaveDay")]
	[XmlType(TypeName="SDTEmployeeLeaveDay" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTEmployeeLeaveDay : GxUserType
	{
		public SdtSDTEmployeeLeaveDay( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTEmployeeLeaveDay_Leavetype = "";

		}

		public SdtSDTEmployeeLeaveDay(IGxContext context)
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
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Date)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Date)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Date)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("Date", sDateCnv, false);



			AddObjectProperty("LeaveType", gxTpr_Leavetype, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Date")]
		[XmlElement(ElementName="Date" , IsNullable=true)]
		public string gxTpr_Date_Nullable
		{
			get {
				if ( gxTv_SdtSDTEmployeeLeaveDay_Date == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTEmployeeLeaveDay_Date).value ;
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDay_Date = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Date
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDay_Date; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDay_Date = value;
				SetDirty("Date");
			}
		}



		[SoapElement(ElementName="LeaveType")]
		[XmlElement(ElementName="LeaveType")]
		public string gxTpr_Leavetype
		{
			get {
				return gxTv_SdtSDTEmployeeLeaveDay_Leavetype; 
			}
			set {
				gxTv_SdtSDTEmployeeLeaveDay_Leavetype = value;
				SetDirty("Leavetype");
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
			gxTv_SdtSDTEmployeeLeaveDay_Leavetype = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime gxTv_SdtSDTEmployeeLeaveDay_Date;
		 

		protected string gxTv_SdtSDTEmployeeLeaveDay_Leavetype;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTEmployeeLeaveDay", Namespace="YTT_version4")]
	public class SdtSDTEmployeeLeaveDay_RESTInterface : GxGenericCollectionItem<SdtSDTEmployeeLeaveDay>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTEmployeeLeaveDay_RESTInterface( ) : base()
		{	
		}

		public SdtSDTEmployeeLeaveDay_RESTInterface( SdtSDTEmployeeLeaveDay psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Date", Order=0)]
		public  string gxTpr_Date
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Date);

			}
			set { 
				sdt.gxTpr_Date = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="LeaveType", Order=1)]
		public  string gxTpr_Leavetype
		{
			get { 
				return sdt.gxTpr_Leavetype;

			}
			set { 
				 sdt.gxTpr_Leavetype = value;
			}
		}


		#endregion

		public SdtSDTEmployeeLeaveDay sdt
		{
			get { 
				return (SdtSDTEmployeeLeaveDay)Sdt;
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
				sdt = new SdtSDTEmployeeLeaveDay() ;
			}
		}
	}
	#endregion
}