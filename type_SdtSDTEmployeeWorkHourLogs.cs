/*
				   File: type_SdtSDTEmployeeWorkHourLogs
			Description: SDTEmployeeWorkHourLogs
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
	[XmlRoot(ElementName="SDTEmployeeWorkHourLogs")]
	[XmlType(TypeName="SDTEmployeeWorkHourLogs" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTEmployeeWorkHourLogs : GxUserType
	{
		public SdtSDTEmployeeWorkHourLogs( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTEmployeeWorkHourLogs_Employeename = "";

		}

		public SdtSDTEmployeeWorkHourLogs(IGxContext context)
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

			if (gxTv_SdtSDTEmployeeWorkHourLogs_Workhourlog != null)
			{
				AddObjectProperty("WorkHourLog", gxTv_SdtSDTEmployeeWorkHourLogs_Workhourlog, false);
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
				return gxTv_SdtSDTEmployeeWorkHourLogs_Employeeid; 
			}
			set {
				gxTv_SdtSDTEmployeeWorkHourLogs_Employeeid = value;
				SetDirty("Employeeid");
			}
		}




		[SoapElement(ElementName="EmployeeName")]
		[XmlElement(ElementName="EmployeeName")]
		public string gxTpr_Employeename
		{
			get {
				return gxTv_SdtSDTEmployeeWorkHourLogs_Employeename; 
			}
			set {
				gxTv_SdtSDTEmployeeWorkHourLogs_Employeename = value;
				SetDirty("Employeename");
			}
		}




		[SoapElement(ElementName="WorkHourLog" )]
		[XmlArray(ElementName="WorkHourLog"  )]
		[XmlArrayItemAttribute(ElementName="WorkHourLogItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTEmployeeWorkHourLogs_WorkHourLogItem> gxTpr_Workhourlog
		{
			get {
				if ( gxTv_SdtSDTEmployeeWorkHourLogs_Workhourlog == null )
				{
					gxTv_SdtSDTEmployeeWorkHourLogs_Workhourlog = new GXBaseCollection<SdtSDTEmployeeWorkHourLogs_WorkHourLogItem>( context, "SDTEmployeeWorkHourLogs.WorkHourLogItem", "");
				}
				return gxTv_SdtSDTEmployeeWorkHourLogs_Workhourlog;
			}
			set {
				gxTv_SdtSDTEmployeeWorkHourLogs_Workhourlog_N = false;
				gxTv_SdtSDTEmployeeWorkHourLogs_Workhourlog = value;
				SetDirty("Workhourlog");
			}
		}

		public void gxTv_SdtSDTEmployeeWorkHourLogs_Workhourlog_SetNull()
		{
			gxTv_SdtSDTEmployeeWorkHourLogs_Workhourlog_N = true;
			gxTv_SdtSDTEmployeeWorkHourLogs_Workhourlog = null;
		}

		public bool gxTv_SdtSDTEmployeeWorkHourLogs_Workhourlog_IsNull()
		{
			return gxTv_SdtSDTEmployeeWorkHourLogs_Workhourlog == null;
		}
		public bool ShouldSerializegxTpr_Workhourlog_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTEmployeeWorkHourLogs_Workhourlog != null && gxTv_SdtSDTEmployeeWorkHourLogs_Workhourlog.Count > 0;

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
			gxTv_SdtSDTEmployeeWorkHourLogs_Employeename = "";

			gxTv_SdtSDTEmployeeWorkHourLogs_Workhourlog_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTEmployeeWorkHourLogs_Employeeid;
		 

		protected string gxTv_SdtSDTEmployeeWorkHourLogs_Employeename;
		 
		protected bool gxTv_SdtSDTEmployeeWorkHourLogs_Workhourlog_N;
		protected GXBaseCollection<SdtSDTEmployeeWorkHourLogs_WorkHourLogItem> gxTv_SdtSDTEmployeeWorkHourLogs_Workhourlog = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTEmployeeWorkHourLogs", Namespace="YTT_version4")]
	public class SdtSDTEmployeeWorkHourLogs_RESTInterface : GxGenericCollectionItem<SdtSDTEmployeeWorkHourLogs>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTEmployeeWorkHourLogs_RESTInterface( ) : base()
		{	
		}

		public SdtSDTEmployeeWorkHourLogs_RESTInterface( SdtSDTEmployeeWorkHourLogs psdt ) : base(psdt)
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

		[DataMember(Name="WorkHourLog", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTEmployeeWorkHourLogs_WorkHourLogItem_RESTInterface> gxTpr_Workhourlog
		{
			get {
				if (sdt.ShouldSerializegxTpr_Workhourlog_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTEmployeeWorkHourLogs_WorkHourLogItem_RESTInterface>(sdt.gxTpr_Workhourlog);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Workhourlog);
			}
		}


		#endregion

		public SdtSDTEmployeeWorkHourLogs sdt
		{
			get { 
				return (SdtSDTEmployeeWorkHourLogs)Sdt;
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
				sdt = new SdtSDTEmployeeWorkHourLogs() ;
			}
		}
	}
	#endregion
}