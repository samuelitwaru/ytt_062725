/*
				   File: type_SdtWWP_AINLQueryResponse_FilterValue
			Description: FilterValues
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
namespace GeneXus.Programs.workwithplus.ai
{
	[XmlRoot(ElementName="WWP_AINLQueryResponse.FilterValue")]
	[XmlType(TypeName="WWP_AINLQueryResponse.FilterValue" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AINLQueryResponse_FilterValue : GxUserType
	{
		public SdtWWP_AINLQueryResponse_FilterValue( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_AINLQueryResponse_FilterValue_Name = "";

			gxTv_SdtWWP_AINLQueryResponse_FilterValue_Dsc = "";

			gxTv_SdtWWP_AINLQueryResponse_FilterValue_Value = "";

			gxTv_SdtWWP_AINLQueryResponse_FilterValue_Valuefrom = "";

			gxTv_SdtWWP_AINLQueryResponse_FilterValue_Valueto = "";

		}

		public SdtWWP_AINLQueryResponse_FilterValue(IGxContext context)
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
			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("Dsc", gxTpr_Dsc, false);


			AddObjectProperty("Value", gxTpr_Value, false);


			AddObjectProperty("ValueFrom", gxTpr_Valuefrom, false);


			AddObjectProperty("Operator", gxTpr_Operator, false);


			AddObjectProperty("ValueTo", gxTpr_Valueto, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtWWP_AINLQueryResponse_FilterValue_Name; 
			}
			set {
				gxTv_SdtWWP_AINLQueryResponse_FilterValue_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Dsc")]
		[XmlElement(ElementName="Dsc")]
		public string gxTpr_Dsc
		{
			get {
				return gxTv_SdtWWP_AINLQueryResponse_FilterValue_Dsc; 
			}
			set {
				gxTv_SdtWWP_AINLQueryResponse_FilterValue_Dsc_N = false;
				gxTv_SdtWWP_AINLQueryResponse_FilterValue_Dsc = value;
				SetDirty("Dsc");
			}
		}

		public bool ShouldSerializegxTpr_Dsc()

		{
			return !gxTv_SdtWWP_AINLQueryResponse_FilterValue_Dsc_N;

		}



		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get {
				return gxTv_SdtWWP_AINLQueryResponse_FilterValue_Value; 
			}
			set {
				gxTv_SdtWWP_AINLQueryResponse_FilterValue_Value = value;
				SetDirty("Value");
			}
		}




		[SoapElement(ElementName="ValueFrom")]
		[XmlElement(ElementName="ValueFrom")]
		public string gxTpr_Valuefrom
		{
			get {
				return gxTv_SdtWWP_AINLQueryResponse_FilterValue_Valuefrom; 
			}
			set {
				gxTv_SdtWWP_AINLQueryResponse_FilterValue_Valuefrom = value;
				SetDirty("Valuefrom");
			}
		}




		[SoapElement(ElementName="Operator")]
		[XmlElement(ElementName="Operator")]
		public short gxTpr_Operator
		{
			get {
				return gxTv_SdtWWP_AINLQueryResponse_FilterValue_Operator; 
			}
			set {
				gxTv_SdtWWP_AINLQueryResponse_FilterValue_Operator = value;
				SetDirty("Operator");
			}
		}




		[SoapElement(ElementName="ValueTo")]
		[XmlElement(ElementName="ValueTo")]
		public string gxTpr_Valueto
		{
			get {
				return gxTv_SdtWWP_AINLQueryResponse_FilterValue_Valueto; 
			}
			set {
				gxTv_SdtWWP_AINLQueryResponse_FilterValue_Valueto = value;
				SetDirty("Valueto");
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
			gxTv_SdtWWP_AINLQueryResponse_FilterValue_Name = "";
			gxTv_SdtWWP_AINLQueryResponse_FilterValue_Dsc = "";
			gxTv_SdtWWP_AINLQueryResponse_FilterValue_Dsc_N = true;

			gxTv_SdtWWP_AINLQueryResponse_FilterValue_Value = "";
			gxTv_SdtWWP_AINLQueryResponse_FilterValue_Valuefrom = "";

			gxTv_SdtWWP_AINLQueryResponse_FilterValue_Valueto = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWP_AINLQueryResponse_FilterValue_Name;
		 

		protected string gxTv_SdtWWP_AINLQueryResponse_FilterValue_Dsc;
		protected bool gxTv_SdtWWP_AINLQueryResponse_FilterValue_Dsc_N;
		 

		protected string gxTv_SdtWWP_AINLQueryResponse_FilterValue_Value;
		 

		protected string gxTv_SdtWWP_AINLQueryResponse_FilterValue_Valuefrom;
		 

		protected short gxTv_SdtWWP_AINLQueryResponse_FilterValue_Operator;
		 

		protected string gxTv_SdtWWP_AINLQueryResponse_FilterValue_Valueto;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WWP_AINLQueryResponse.FilterValue", Namespace="YTT_version4")]
	public class SdtWWP_AINLQueryResponse_FilterValue_RESTInterface : GxGenericCollectionItem<SdtWWP_AINLQueryResponse_FilterValue>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AINLQueryResponse_FilterValue_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AINLQueryResponse_FilterValue_RESTInterface( SdtWWP_AINLQueryResponse_FilterValue psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Dsc", Order=1)]
		public  string gxTpr_Dsc
		{
			get { 
				return sdt.gxTpr_Dsc;

			}
			set { 
				 sdt.gxTpr_Dsc = value;
			}
		}

		[DataMember(Name="Value", Order=2)]
		public  string gxTpr_Value
		{
			get { 
				return sdt.gxTpr_Value;

			}
			set { 
				 sdt.gxTpr_Value = value;
			}
		}

		[DataMember(Name="ValueFrom", Order=3)]
		public  string gxTpr_Valuefrom
		{
			get { 
				return sdt.gxTpr_Valuefrom;

			}
			set { 
				 sdt.gxTpr_Valuefrom = value;
			}
		}

		[DataMember(Name="Operator", Order=4)]
		public short gxTpr_Operator
		{
			get { 
				return sdt.gxTpr_Operator;

			}
			set { 
				sdt.gxTpr_Operator = value;
			}
		}

		[DataMember(Name="ValueTo", Order=5)]
		public  string gxTpr_Valueto
		{
			get { 
				return sdt.gxTpr_Valueto;

			}
			set { 
				 sdt.gxTpr_Valueto = value;
			}
		}


		#endregion

		public SdtWWP_AINLQueryResponse_FilterValue sdt
		{
			get { 
				return (SdtWWP_AINLQueryResponse_FilterValue)Sdt;
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
				sdt = new SdtWWP_AINLQueryResponse_FilterValue() ;
			}
		}
	}
	#endregion
}