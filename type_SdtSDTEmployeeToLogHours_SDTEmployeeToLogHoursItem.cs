/*
				   File: type_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem
			Description: SDTEmployeeToLogHours
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
	[XmlRoot(ElementName="SDTEmployeeToLogHoursItem")]
	[XmlType(TypeName="SDTEmployeeToLogHoursItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem : GxUserType
	{
		public SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem_Sdtemployeename = "";

		}

		public SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem(IGxContext context)
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
			AddObjectProperty("SDTEmployeeId", gxTpr_Sdtemployeeid, false);


			AddObjectProperty("SDTEmployeeName", gxTpr_Sdtemployeename, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SDTEmployeeId")]
		[XmlElement(ElementName="SDTEmployeeId")]
		public long gxTpr_Sdtemployeeid
		{
			get {
				return gxTv_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem_Sdtemployeeid; 
			}
			set {
				gxTv_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem_Sdtemployeeid = value;
				SetDirty("Sdtemployeeid");
			}
		}




		[SoapElement(ElementName="SDTEmployeeName")]
		[XmlElement(ElementName="SDTEmployeeName")]
		public string gxTpr_Sdtemployeename
		{
			get {
				return gxTv_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem_Sdtemployeename; 
			}
			set {
				gxTv_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem_Sdtemployeename = value;
				SetDirty("Sdtemployeename");
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
			gxTv_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem_Sdtemployeename = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem_Sdtemployeeid;
		 

		protected string gxTv_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem_Sdtemployeename;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTEmployeeToLogHoursItem", Namespace="YTT_version4")]
	public class SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem_RESTInterface : GxGenericCollectionItem<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem_RESTInterface( SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="SDTEmployeeId", Order=0)]
		public  string gxTpr_Sdtemployeeid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Sdtemployeeid, 10, 0));

			}
			set { 
				sdt.gxTpr_Sdtemployeeid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SDTEmployeeName", Order=1)]
		public  string gxTpr_Sdtemployeename
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Sdtemployeename);

			}
			set { 
				 sdt.gxTpr_Sdtemployeename = value;
			}
		}


		#endregion

		public SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem sdt
		{
			get { 
				return (SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem)Sdt;
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
				sdt = new SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem() ;
			}
		}
	}
	#endregion
}