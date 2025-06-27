/*
				   File: type_SdtRangedRadialGaugeConfig
			Description: RangedRadialGaugeConfig
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
	[XmlRoot(ElementName="RangedRadialGaugeConfig")]
	[XmlType(TypeName="RangedRadialGaugeConfig" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtRangedRadialGaugeConfig : GxUserType
	{
		public SdtRangedRadialGaugeConfig( )
		{
			/* Constructor for serialization */
			gxTv_SdtRangedRadialGaugeConfig_Text = "";

			gxTv_SdtRangedRadialGaugeConfig_Range1colorstart = "";

			gxTv_SdtRangedRadialGaugeConfig_Range1colorend = "";

			gxTv_SdtRangedRadialGaugeConfig_Range2colorstart = "";

			gxTv_SdtRangedRadialGaugeConfig_Range2colorend = "";

			gxTv_SdtRangedRadialGaugeConfig_Range3colorstart = "";

			gxTv_SdtRangedRadialGaugeConfig_Range3colorend = "";

			gxTv_SdtRangedRadialGaugeConfig_Range4colorstart = "";

			gxTv_SdtRangedRadialGaugeConfig_Range4colorend = "";

			gxTv_SdtRangedRadialGaugeConfig_Range5colorstart = "";

			gxTv_SdtRangedRadialGaugeConfig_Range5colorend = "";

			gxTv_SdtRangedRadialGaugeConfig_Valuemarkercolor = "";

		}

		public SdtRangedRadialGaugeConfig(IGxContext context)
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
			AddObjectProperty("Value", gxTpr_Value, false);


			AddObjectProperty("Text", gxTpr_Text, false);


			AddObjectProperty("Width", gxTpr_Width, false);


			AddObjectProperty("Height", gxTpr_Height, false);


			AddObjectProperty("Range1ColorStart", gxTpr_Range1colorstart, false);


			AddObjectProperty("Range1ColorEnd", gxTpr_Range1colorend, false);


			AddObjectProperty("Range2ColorStart", gxTpr_Range2colorstart, false);


			AddObjectProperty("Range2ColorEnd", gxTpr_Range2colorend, false);


			AddObjectProperty("Range3ColorStart", gxTpr_Range3colorstart, false);


			AddObjectProperty("Range3ColorEnd", gxTpr_Range3colorend, false);


			AddObjectProperty("Range4ColorStart", gxTpr_Range4colorstart, false);


			AddObjectProperty("Range4ColorEnd", gxTpr_Range4colorend, false);


			AddObjectProperty("Range5ColorStart", gxTpr_Range5colorstart, false);


			AddObjectProperty("Range5ColorEnd", gxTpr_Range5colorend, false);


			AddObjectProperty("ValueMarkerColor", gxTpr_Valuemarkercolor, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public short gxTpr_Value
		{
			get {
				return gxTv_SdtRangedRadialGaugeConfig_Value; 
			}
			set {
				gxTv_SdtRangedRadialGaugeConfig_Value = value;
				SetDirty("Value");
			}
		}




		[SoapElement(ElementName="Text")]
		[XmlElement(ElementName="Text")]
		public string gxTpr_Text
		{
			get {
				return gxTv_SdtRangedRadialGaugeConfig_Text; 
			}
			set {
				gxTv_SdtRangedRadialGaugeConfig_Text = value;
				SetDirty("Text");
			}
		}




		[SoapElement(ElementName="Width")]
		[XmlElement(ElementName="Width")]
		public short gxTpr_Width
		{
			get {
				return gxTv_SdtRangedRadialGaugeConfig_Width; 
			}
			set {
				gxTv_SdtRangedRadialGaugeConfig_Width = value;
				SetDirty("Width");
			}
		}




		[SoapElement(ElementName="Height")]
		[XmlElement(ElementName="Height")]
		public short gxTpr_Height
		{
			get {
				return gxTv_SdtRangedRadialGaugeConfig_Height; 
			}
			set {
				gxTv_SdtRangedRadialGaugeConfig_Height = value;
				SetDirty("Height");
			}
		}




		[SoapElement(ElementName="Range1ColorStart")]
		[XmlElement(ElementName="Range1ColorStart")]
		public string gxTpr_Range1colorstart
		{
			get {
				return gxTv_SdtRangedRadialGaugeConfig_Range1colorstart; 
			}
			set {
				gxTv_SdtRangedRadialGaugeConfig_Range1colorstart = value;
				SetDirty("Range1colorstart");
			}
		}




		[SoapElement(ElementName="Range1ColorEnd")]
		[XmlElement(ElementName="Range1ColorEnd")]
		public string gxTpr_Range1colorend
		{
			get {
				return gxTv_SdtRangedRadialGaugeConfig_Range1colorend; 
			}
			set {
				gxTv_SdtRangedRadialGaugeConfig_Range1colorend = value;
				SetDirty("Range1colorend");
			}
		}




		[SoapElement(ElementName="Range2ColorStart")]
		[XmlElement(ElementName="Range2ColorStart")]
		public string gxTpr_Range2colorstart
		{
			get {
				return gxTv_SdtRangedRadialGaugeConfig_Range2colorstart; 
			}
			set {
				gxTv_SdtRangedRadialGaugeConfig_Range2colorstart = value;
				SetDirty("Range2colorstart");
			}
		}




		[SoapElement(ElementName="Range2ColorEnd")]
		[XmlElement(ElementName="Range2ColorEnd")]
		public string gxTpr_Range2colorend
		{
			get {
				return gxTv_SdtRangedRadialGaugeConfig_Range2colorend; 
			}
			set {
				gxTv_SdtRangedRadialGaugeConfig_Range2colorend = value;
				SetDirty("Range2colorend");
			}
		}




		[SoapElement(ElementName="Range3ColorStart")]
		[XmlElement(ElementName="Range3ColorStart")]
		public string gxTpr_Range3colorstart
		{
			get {
				return gxTv_SdtRangedRadialGaugeConfig_Range3colorstart; 
			}
			set {
				gxTv_SdtRangedRadialGaugeConfig_Range3colorstart = value;
				SetDirty("Range3colorstart");
			}
		}




		[SoapElement(ElementName="Range3ColorEnd")]
		[XmlElement(ElementName="Range3ColorEnd")]
		public string gxTpr_Range3colorend
		{
			get {
				return gxTv_SdtRangedRadialGaugeConfig_Range3colorend; 
			}
			set {
				gxTv_SdtRangedRadialGaugeConfig_Range3colorend = value;
				SetDirty("Range3colorend");
			}
		}




		[SoapElement(ElementName="Range4ColorStart")]
		[XmlElement(ElementName="Range4ColorStart")]
		public string gxTpr_Range4colorstart
		{
			get {
				return gxTv_SdtRangedRadialGaugeConfig_Range4colorstart; 
			}
			set {
				gxTv_SdtRangedRadialGaugeConfig_Range4colorstart = value;
				SetDirty("Range4colorstart");
			}
		}




		[SoapElement(ElementName="Range4ColorEnd")]
		[XmlElement(ElementName="Range4ColorEnd")]
		public string gxTpr_Range4colorend
		{
			get {
				return gxTv_SdtRangedRadialGaugeConfig_Range4colorend; 
			}
			set {
				gxTv_SdtRangedRadialGaugeConfig_Range4colorend = value;
				SetDirty("Range4colorend");
			}
		}




		[SoapElement(ElementName="Range5ColorStart")]
		[XmlElement(ElementName="Range5ColorStart")]
		public string gxTpr_Range5colorstart
		{
			get {
				return gxTv_SdtRangedRadialGaugeConfig_Range5colorstart; 
			}
			set {
				gxTv_SdtRangedRadialGaugeConfig_Range5colorstart = value;
				SetDirty("Range5colorstart");
			}
		}




		[SoapElement(ElementName="Range5ColorEnd")]
		[XmlElement(ElementName="Range5ColorEnd")]
		public string gxTpr_Range5colorend
		{
			get {
				return gxTv_SdtRangedRadialGaugeConfig_Range5colorend; 
			}
			set {
				gxTv_SdtRangedRadialGaugeConfig_Range5colorend = value;
				SetDirty("Range5colorend");
			}
		}




		[SoapElement(ElementName="ValueMarkerColor")]
		[XmlElement(ElementName="ValueMarkerColor")]
		public string gxTpr_Valuemarkercolor
		{
			get {
				return gxTv_SdtRangedRadialGaugeConfig_Valuemarkercolor; 
			}
			set {
				gxTv_SdtRangedRadialGaugeConfig_Valuemarkercolor = value;
				SetDirty("Valuemarkercolor");
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
			gxTv_SdtRangedRadialGaugeConfig_Text = "";


			gxTv_SdtRangedRadialGaugeConfig_Range1colorstart = "";
			gxTv_SdtRangedRadialGaugeConfig_Range1colorend = "";
			gxTv_SdtRangedRadialGaugeConfig_Range2colorstart = "";
			gxTv_SdtRangedRadialGaugeConfig_Range2colorend = "";
			gxTv_SdtRangedRadialGaugeConfig_Range3colorstart = "";
			gxTv_SdtRangedRadialGaugeConfig_Range3colorend = "";
			gxTv_SdtRangedRadialGaugeConfig_Range4colorstart = "";
			gxTv_SdtRangedRadialGaugeConfig_Range4colorend = "";
			gxTv_SdtRangedRadialGaugeConfig_Range5colorstart = "";
			gxTv_SdtRangedRadialGaugeConfig_Range5colorend = "";
			gxTv_SdtRangedRadialGaugeConfig_Valuemarkercolor = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtRangedRadialGaugeConfig_Value;
		 

		protected string gxTv_SdtRangedRadialGaugeConfig_Text;
		 

		protected short gxTv_SdtRangedRadialGaugeConfig_Width;
		 

		protected short gxTv_SdtRangedRadialGaugeConfig_Height;
		 

		protected string gxTv_SdtRangedRadialGaugeConfig_Range1colorstart;
		 

		protected string gxTv_SdtRangedRadialGaugeConfig_Range1colorend;
		 

		protected string gxTv_SdtRangedRadialGaugeConfig_Range2colorstart;
		 

		protected string gxTv_SdtRangedRadialGaugeConfig_Range2colorend;
		 

		protected string gxTv_SdtRangedRadialGaugeConfig_Range3colorstart;
		 

		protected string gxTv_SdtRangedRadialGaugeConfig_Range3colorend;
		 

		protected string gxTv_SdtRangedRadialGaugeConfig_Range4colorstart;
		 

		protected string gxTv_SdtRangedRadialGaugeConfig_Range4colorend;
		 

		protected string gxTv_SdtRangedRadialGaugeConfig_Range5colorstart;
		 

		protected string gxTv_SdtRangedRadialGaugeConfig_Range5colorend;
		 

		protected string gxTv_SdtRangedRadialGaugeConfig_Valuemarkercolor;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"RangedRadialGaugeConfig", Namespace="YTT_version4")]
	public class SdtRangedRadialGaugeConfig_RESTInterface : GxGenericCollectionItem<SdtRangedRadialGaugeConfig>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtRangedRadialGaugeConfig_RESTInterface( ) : base()
		{	
		}

		public SdtRangedRadialGaugeConfig_RESTInterface( SdtRangedRadialGaugeConfig psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Value", Order=0)]
		public short gxTpr_Value
		{
			get { 
				return sdt.gxTpr_Value;

			}
			set { 
				sdt.gxTpr_Value = value;
			}
		}

		[DataMember(Name="Text", Order=1)]
		public  string gxTpr_Text
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Text);

			}
			set { 
				 sdt.gxTpr_Text = value;
			}
		}

		[DataMember(Name="Width", Order=2)]
		public short gxTpr_Width
		{
			get { 
				return sdt.gxTpr_Width;

			}
			set { 
				sdt.gxTpr_Width = value;
			}
		}

		[DataMember(Name="Height", Order=3)]
		public short gxTpr_Height
		{
			get { 
				return sdt.gxTpr_Height;

			}
			set { 
				sdt.gxTpr_Height = value;
			}
		}

		[DataMember(Name="Range1ColorStart", Order=4)]
		public  string gxTpr_Range1colorstart
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Range1colorstart);

			}
			set { 
				 sdt.gxTpr_Range1colorstart = value;
			}
		}

		[DataMember(Name="Range1ColorEnd", Order=5)]
		public  string gxTpr_Range1colorend
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Range1colorend);

			}
			set { 
				 sdt.gxTpr_Range1colorend = value;
			}
		}

		[DataMember(Name="Range2ColorStart", Order=6)]
		public  string gxTpr_Range2colorstart
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Range2colorstart);

			}
			set { 
				 sdt.gxTpr_Range2colorstart = value;
			}
		}

		[DataMember(Name="Range2ColorEnd", Order=7)]
		public  string gxTpr_Range2colorend
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Range2colorend);

			}
			set { 
				 sdt.gxTpr_Range2colorend = value;
			}
		}

		[DataMember(Name="Range3ColorStart", Order=8)]
		public  string gxTpr_Range3colorstart
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Range3colorstart);

			}
			set { 
				 sdt.gxTpr_Range3colorstart = value;
			}
		}

		[DataMember(Name="Range3ColorEnd", Order=9)]
		public  string gxTpr_Range3colorend
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Range3colorend);

			}
			set { 
				 sdt.gxTpr_Range3colorend = value;
			}
		}

		[DataMember(Name="Range4ColorStart", Order=10)]
		public  string gxTpr_Range4colorstart
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Range4colorstart);

			}
			set { 
				 sdt.gxTpr_Range4colorstart = value;
			}
		}

		[DataMember(Name="Range4ColorEnd", Order=11)]
		public  string gxTpr_Range4colorend
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Range4colorend);

			}
			set { 
				 sdt.gxTpr_Range4colorend = value;
			}
		}

		[DataMember(Name="Range5ColorStart", Order=12)]
		public  string gxTpr_Range5colorstart
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Range5colorstart);

			}
			set { 
				 sdt.gxTpr_Range5colorstart = value;
			}
		}

		[DataMember(Name="Range5ColorEnd", Order=13)]
		public  string gxTpr_Range5colorend
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Range5colorend);

			}
			set { 
				 sdt.gxTpr_Range5colorend = value;
			}
		}

		[DataMember(Name="ValueMarkerColor", Order=14)]
		public  string gxTpr_Valuemarkercolor
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Valuemarkercolor);

			}
			set { 
				 sdt.gxTpr_Valuemarkercolor = value;
			}
		}


		#endregion

		public SdtRangedRadialGaugeConfig sdt
		{
			get { 
				return (SdtRangedRadialGaugeConfig)Sdt;
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
				sdt = new SdtRangedRadialGaugeConfig() ;
			}
		}
	}
	#endregion
}