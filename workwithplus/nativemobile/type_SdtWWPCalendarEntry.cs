/*
				   File: type_SdtWWPCalendarEntry
			Description: WWPCalendarEntry
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

using GeneXus.Programs;
using GeneXus.Programs.workwithplus;
namespace GeneXus.Programs.workwithplus.nativemobile
{
	[XmlRoot(ElementName="WWPCalendarEntry")]
	[XmlType(TypeName="WWPCalendarEntry" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWPCalendarEntry : GxUserType
	{
		public SdtWWPCalendarEntry( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPCalendarEntry_Color = "";

			gxTv_SdtWWPCalendarEntry_Text = "";

			gxTv_SdtWWPCalendarEntry_Content = "";

			gxTv_SdtWWPCalendarEntry_Time = (DateTime)(DateTime.MinValue);

		}

		public SdtWWPCalendarEntry(IGxContext context)
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
			AddObjectProperty("Year", gxTpr_Year, false);


			AddObjectProperty("Month", gxTpr_Month, false);


			AddObjectProperty("Day", gxTpr_Day, false);


			AddObjectProperty("Color", gxTpr_Color, false);


			AddObjectProperty("Text", gxTpr_Text, false);


			AddObjectProperty("Status", gxTpr_Status, false);


			AddObjectProperty("Content", gxTpr_Content, false);


			datetime_STZ = gxTpr_Time;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("Time", sDateCnv, false);


			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Year")]
		[XmlElement(ElementName="Year")]
		public short gxTpr_Year
		{
			get {
				return gxTv_SdtWWPCalendarEntry_Year; 
			}
			set {
				gxTv_SdtWWPCalendarEntry_Year = value;
				SetDirty("Year");
			}
		}




		[SoapElement(ElementName="Month")]
		[XmlElement(ElementName="Month")]
		public short gxTpr_Month
		{
			get {
				return gxTv_SdtWWPCalendarEntry_Month; 
			}
			set {
				gxTv_SdtWWPCalendarEntry_Month = value;
				SetDirty("Month");
			}
		}




		[SoapElement(ElementName="Day")]
		[XmlElement(ElementName="Day")]
		public short gxTpr_Day
		{
			get {
				return gxTv_SdtWWPCalendarEntry_Day; 
			}
			set {
				gxTv_SdtWWPCalendarEntry_Day = value;
				SetDirty("Day");
			}
		}




		[SoapElement(ElementName="Color")]
		[XmlElement(ElementName="Color")]
		public string gxTpr_Color
		{
			get {
				return gxTv_SdtWWPCalendarEntry_Color; 
			}
			set {
				gxTv_SdtWWPCalendarEntry_Color = value;
				SetDirty("Color");
			}
		}




		[SoapElement(ElementName="Text")]
		[XmlElement(ElementName="Text")]
		public string gxTpr_Text
		{
			get {
				return gxTv_SdtWWPCalendarEntry_Text; 
			}
			set {
				gxTv_SdtWWPCalendarEntry_Text = value;
				SetDirty("Text");
			}
		}




		[SoapElement(ElementName="Status")]
		[XmlElement(ElementName="Status")]
		public short gxTpr_Status
		{
			get {
				return gxTv_SdtWWPCalendarEntry_Status; 
			}
			set {
				gxTv_SdtWWPCalendarEntry_Status = value;
				SetDirty("Status");
			}
		}




		[SoapElement(ElementName="Content")]
		[XmlElement(ElementName="Content")]
		public string gxTpr_Content
		{
			get {
				return gxTv_SdtWWPCalendarEntry_Content; 
			}
			set {
				gxTv_SdtWWPCalendarEntry_Content = value;
				SetDirty("Content");
			}
		}



		[SoapElement(ElementName="Time")]
		[XmlElement(ElementName="Time" , IsNullable=true)]
		public string gxTpr_Time_Nullable
		{
			get {
				if ( gxTv_SdtWWPCalendarEntry_Time == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtWWPCalendarEntry_Time).value ;
			}
			set {
				gxTv_SdtWWPCalendarEntry_Time = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Time
		{
			get {
				return gxTv_SdtWWPCalendarEntry_Time; 
			}
			set {
				gxTv_SdtWWPCalendarEntry_Time = value;
				SetDirty("Time");
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
			gxTv_SdtWWPCalendarEntry_Color = "";
			gxTv_SdtWWPCalendarEntry_Text = "";

			gxTv_SdtWWPCalendarEntry_Content = "";
			gxTv_SdtWWPCalendarEntry_Time = (DateTime)(DateTime.MinValue);
			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected short gxTv_SdtWWPCalendarEntry_Year;
		 

		protected short gxTv_SdtWWPCalendarEntry_Month;
		 

		protected short gxTv_SdtWWPCalendarEntry_Day;
		 

		protected string gxTv_SdtWWPCalendarEntry_Color;
		 

		protected string gxTv_SdtWWPCalendarEntry_Text;
		 

		protected short gxTv_SdtWWPCalendarEntry_Status;
		 

		protected string gxTv_SdtWWPCalendarEntry_Content;
		 

		protected DateTime gxTv_SdtWWPCalendarEntry_Time;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWPCalendarEntry", Namespace="YTT_version4")]
	public class SdtWWPCalendarEntry_RESTInterface : GxGenericCollectionItem<SdtWWPCalendarEntry>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPCalendarEntry_RESTInterface( ) : base()
		{	
		}

		public SdtWWPCalendarEntry_RESTInterface( SdtWWPCalendarEntry psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Year", Order=0)]
		public short gxTpr_Year
		{
			get { 
				return sdt.gxTpr_Year;

			}
			set { 
				sdt.gxTpr_Year = value;
			}
		}

		[DataMember(Name="Month", Order=1)]
		public short gxTpr_Month
		{
			get { 
				return sdt.gxTpr_Month;

			}
			set { 
				sdt.gxTpr_Month = value;
			}
		}

		[DataMember(Name="Day", Order=2)]
		public short gxTpr_Day
		{
			get { 
				return sdt.gxTpr_Day;

			}
			set { 
				sdt.gxTpr_Day = value;
			}
		}

		[DataMember(Name="Color", Order=3)]
		public  string gxTpr_Color
		{
			get { 
				return sdt.gxTpr_Color;

			}
			set { 
				 sdt.gxTpr_Color = value;
			}
		}

		[DataMember(Name="Text", Order=4)]
		public  string gxTpr_Text
		{
			get { 
				return sdt.gxTpr_Text;

			}
			set { 
				 sdt.gxTpr_Text = value;
			}
		}

		[DataMember(Name="Status", Order=5)]
		public short gxTpr_Status
		{
			get { 
				return sdt.gxTpr_Status;

			}
			set { 
				sdt.gxTpr_Status = value;
			}
		}

		[DataMember(Name="Content", Order=6)]
		public  string gxTpr_Content
		{
			get { 
				return sdt.gxTpr_Content;

			}
			set { 
				 sdt.gxTpr_Content = value;
			}
		}

		[DataMember(Name="Time", Order=7)]
		public  string gxTpr_Time
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Time,context);

			}
			set { 
				sdt.gxTpr_Time = DateTimeUtil.CToT2(value,context);
			}
		}


		#endregion

		public SdtWWPCalendarEntry sdt
		{
			get { 
				return (SdtWWPCalendarEntry)Sdt;
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
				sdt = new SdtWWPCalendarEntry() ;
			}
		}
	}
	#endregion
}