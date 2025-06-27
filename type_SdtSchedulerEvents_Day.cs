/*
				   File: type_SdtSchedulerEvents_Day
			Description: SpecialDays
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
	[XmlRoot(ElementName="SchedulerEvents.Day")]
	[XmlType(TypeName="SchedulerEvents.Day" , Namespace="" )]
	[Serializable]
	public class SdtSchedulerEvents_Day : GxUserType
	{
		public SdtSchedulerEvents_Day( )
		{
			/* Constructor for serialization */
			gxTv_SdtSchedulerEvents_Day_Color = "";

		}

		public SdtSchedulerEvents_Day(IGxContext context)
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



			AddObjectProperty("Color", gxTpr_Color, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Date")]
		[XmlElement(ElementName="Date" , IsNullable=true)]
		public string gxTpr_Date_Nullable
		{
			get {
				if ( gxTv_SdtSchedulerEvents_Day_Date == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSchedulerEvents_Day_Date).value ;
			}
			set {
				gxTv_SdtSchedulerEvents_Day_Date = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Date
		{
			get {
				return gxTv_SdtSchedulerEvents_Day_Date; 
			}
			set {
				gxTv_SdtSchedulerEvents_Day_Date = value;
				SetDirty("Date");
			}
		}



		[SoapElement(ElementName="Color")]
		[XmlElement(ElementName="Color")]
		public string gxTpr_Color
		{
			get {
				return gxTv_SdtSchedulerEvents_Day_Color; 
			}
			set {
				gxTv_SdtSchedulerEvents_Day_Color = value;
				SetDirty("Color");
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
			gxTv_SdtSchedulerEvents_Day_Color = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime gxTv_SdtSchedulerEvents_Day_Date;
		 

		protected string gxTv_SdtSchedulerEvents_Day_Color;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SchedulerEvents.Day", Namespace="")]
	public class SdtSchedulerEvents_Day_RESTInterface : GxGenericCollectionItem<SdtSchedulerEvents_Day>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSchedulerEvents_Day_RESTInterface( ) : base()
		{	
		}

		public SdtSchedulerEvents_Day_RESTInterface( SdtSchedulerEvents_Day psdt ) : base(psdt)
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

		[DataMember(Name="Color", Order=1)]
		public  string gxTpr_Color
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Color);

			}
			set { 
				 sdt.gxTpr_Color = value;
			}
		}


		#endregion

		public SdtSchedulerEvents_Day sdt
		{
			get { 
				return (SdtSchedulerEvents_Day)Sdt;
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
				sdt = new SdtSchedulerEvents_Day() ;
			}
		}
	}
	#endregion
}