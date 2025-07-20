/*
				   File: type_SdtSDT_DayLogReport
			Description: SDT_DayLogReport
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
	[XmlRoot(ElementName="SDT_DayLogReport")]
	[XmlType(TypeName="SDT_DayLogReport" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDT_DayLogReport : GxUserType
	{
		public SdtSDT_DayLogReport( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_DayLogReport_Formattedhours = "";

		}

		public SdtSDT_DayLogReport(IGxContext context)
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
			AddObjectProperty("Hours", gxTpr_Hours, false);


			AddObjectProperty("IsHoliday", gxTpr_Isholiday, false);


			AddObjectProperty("FormattedHours", gxTpr_Formattedhours, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Hours")]
		[XmlElement(ElementName="Hours")]
		public long gxTpr_Hours
		{
			get {
				return gxTv_SdtSDT_DayLogReport_Hours; 
			}
			set {
				gxTv_SdtSDT_DayLogReport_Hours = value;
				SetDirty("Hours");
			}
		}




		[SoapElement(ElementName="IsHoliday")]
		[XmlElement(ElementName="IsHoliday")]
		public bool gxTpr_Isholiday
		{
			get {
				return gxTv_SdtSDT_DayLogReport_Isholiday; 
			}
			set {
				gxTv_SdtSDT_DayLogReport_Isholiday = value;
				SetDirty("Isholiday");
			}
		}




		[SoapElement(ElementName="FormattedHours")]
		[XmlElement(ElementName="FormattedHours")]
		public string gxTpr_Formattedhours
		{
			get {
				return gxTv_SdtSDT_DayLogReport_Formattedhours; 
			}
			set {
				gxTv_SdtSDT_DayLogReport_Formattedhours = value;
				SetDirty("Formattedhours");
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
			gxTv_SdtSDT_DayLogReport_Formattedhours = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDT_DayLogReport_Hours;
		 

		protected bool gxTv_SdtSDT_DayLogReport_Isholiday;
		 

		protected string gxTv_SdtSDT_DayLogReport_Formattedhours;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_DayLogReport", Namespace="YTT_version4")]
	public class SdtSDT_DayLogReport_RESTInterface : GxGenericCollectionItem<SdtSDT_DayLogReport>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_DayLogReport_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_DayLogReport_RESTInterface( SdtSDT_DayLogReport psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Hours", Order=0)]
		public  string gxTpr_Hours
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Hours, 10, 0));

			}
			set { 
				sdt.gxTpr_Hours = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="IsHoliday", Order=1)]
		public bool gxTpr_Isholiday
		{
			get { 
				return sdt.gxTpr_Isholiday;

			}
			set { 
				sdt.gxTpr_Isholiday = value;
			}
		}

		[DataMember(Name="FormattedHours", Order=2)]
		public  string gxTpr_Formattedhours
		{
			get { 
				return sdt.gxTpr_Formattedhours;

			}
			set { 
				 sdt.gxTpr_Formattedhours = value;
			}
		}


		#endregion

		public SdtSDT_DayLogReport sdt
		{
			get { 
				return (SdtSDT_DayLogReport)Sdt;
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
				sdt = new SdtSDT_DayLogReport() ;
			}
		}
	}
	#endregion
}