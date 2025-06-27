/*
				   File: type_SdtWWP_AIChatCompletionResponse
			Description: WWP_AIChatCompletionResponse
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
	[XmlRoot(ElementName="WWP_AIChatCompletionResponse")]
	[XmlType(TypeName="WWP_AIChatCompletionResponse" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AIChatCompletionResponse : GxUserType
	{
		public SdtWWP_AIChatCompletionResponse( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_AIChatCompletionResponse_Id = "";

			gxTv_SdtWWP_AIChatCompletionResponse_Object = "";

			gxTv_SdtWWP_AIChatCompletionResponse_Model = "";

		}

		public SdtWWP_AIChatCompletionResponse(IGxContext context)
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
			AddObjectProperty("id", gxTpr_Id, false);


			AddObjectProperty("object", gxTpr_Object, false);


			AddObjectProperty("created", gxTpr_Created, false);


			AddObjectProperty("model", gxTpr_Model, false);

			if (gxTv_SdtWWP_AIChatCompletionResponse_Choices != null)
			{
				AddObjectProperty("choices", gxTv_SdtWWP_AIChatCompletionResponse_Choices, false);
			}
			if (gxTv_SdtWWP_AIChatCompletionResponse_Usage != null)
			{
				AddObjectProperty("usage", gxTv_SdtWWP_AIChatCompletionResponse_Usage, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionResponse_Id; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionResponse_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="object")]
		[XmlElement(ElementName="object")]
		public string gxTpr_Object
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionResponse_Object; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionResponse_Object = value;
				SetDirty("Object");
			}
		}




		[SoapElement(ElementName="created")]
		[XmlElement(ElementName="created")]
		public long gxTpr_Created
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionResponse_Created; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionResponse_Created = value;
				SetDirty("Created");
			}
		}




		[SoapElement(ElementName="model")]
		[XmlElement(ElementName="model")]
		public string gxTpr_Model
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionResponse_Model; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionResponse_Model = value;
				SetDirty("Model");
			}
		}




		[SoapElement(ElementName="choices" )]
		[XmlArray(ElementName="choices"  )]
		[XmlArrayItemAttribute(ElementName="choicesItem" , IsNullable=false )]
		public GXBaseCollection<SdtWWP_AIChatCompletionResponse_choicesItem> gxTpr_Choices
		{
			get {
				if ( gxTv_SdtWWP_AIChatCompletionResponse_Choices == null )
				{
					gxTv_SdtWWP_AIChatCompletionResponse_Choices = new GXBaseCollection<SdtWWP_AIChatCompletionResponse_choicesItem>( context, "WWP_AIChatCompletionResponse.choicesItem", "");
				}
				return gxTv_SdtWWP_AIChatCompletionResponse_Choices;
			}
			set {
				gxTv_SdtWWP_AIChatCompletionResponse_Choices_N = false;
				gxTv_SdtWWP_AIChatCompletionResponse_Choices = value;
				SetDirty("Choices");
			}
		}

		public void gxTv_SdtWWP_AIChatCompletionResponse_Choices_SetNull()
		{
			gxTv_SdtWWP_AIChatCompletionResponse_Choices_N = true;
			gxTv_SdtWWP_AIChatCompletionResponse_Choices = null;
		}

		public bool gxTv_SdtWWP_AIChatCompletionResponse_Choices_IsNull()
		{
			return gxTv_SdtWWP_AIChatCompletionResponse_Choices == null;
		}
		public bool ShouldSerializegxTpr_Choices_GxSimpleCollection_Json()
		{
			return gxTv_SdtWWP_AIChatCompletionResponse_Choices != null && gxTv_SdtWWP_AIChatCompletionResponse_Choices.Count > 0;

		}


		[SoapElement(ElementName="usage" )]
		[XmlElement(ElementName="usage" )]
		public SdtWWP_AIChatCompletionResponse_usage gxTpr_Usage
		{
			get {
				if ( gxTv_SdtWWP_AIChatCompletionResponse_Usage == null )
				{
					gxTv_SdtWWP_AIChatCompletionResponse_Usage = new SdtWWP_AIChatCompletionResponse_usage(context);
				}
				gxTv_SdtWWP_AIChatCompletionResponse_Usage_N = false;
				return gxTv_SdtWWP_AIChatCompletionResponse_Usage;
			}
			set {
				gxTv_SdtWWP_AIChatCompletionResponse_Usage_N = false;
				gxTv_SdtWWP_AIChatCompletionResponse_Usage = value;
				SetDirty("Usage");
			}

		}

		public void gxTv_SdtWWP_AIChatCompletionResponse_Usage_SetNull()
		{
			gxTv_SdtWWP_AIChatCompletionResponse_Usage_N = true;
			gxTv_SdtWWP_AIChatCompletionResponse_Usage = null;
		}

		public bool gxTv_SdtWWP_AIChatCompletionResponse_Usage_IsNull()
		{
			return gxTv_SdtWWP_AIChatCompletionResponse_Usage == null;
		}
		public bool ShouldSerializegxTpr_Usage_Json()
		{
				return (gxTv_SdtWWP_AIChatCompletionResponse_Usage != null && gxTv_SdtWWP_AIChatCompletionResponse_Usage.ShouldSerializeSdtJson());

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
			gxTv_SdtWWP_AIChatCompletionResponse_Id = "";
			gxTv_SdtWWP_AIChatCompletionResponse_Object = "";

			gxTv_SdtWWP_AIChatCompletionResponse_Model = "";

			gxTv_SdtWWP_AIChatCompletionResponse_Choices_N = true;


			gxTv_SdtWWP_AIChatCompletionResponse_Usage_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWP_AIChatCompletionResponse_Id;
		 

		protected string gxTv_SdtWWP_AIChatCompletionResponse_Object;
		 

		protected long gxTv_SdtWWP_AIChatCompletionResponse_Created;
		 

		protected string gxTv_SdtWWP_AIChatCompletionResponse_Model;
		 
		protected bool gxTv_SdtWWP_AIChatCompletionResponse_Choices_N;
		protected GXBaseCollection<SdtWWP_AIChatCompletionResponse_choicesItem> gxTv_SdtWWP_AIChatCompletionResponse_Choices = null; 

		protected bool gxTv_SdtWWP_AIChatCompletionResponse_Usage_N;
		protected SdtWWP_AIChatCompletionResponse_usage gxTv_SdtWWP_AIChatCompletionResponse_Usage = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWP_AIChatCompletionResponse", Namespace="YTT_version4")]
	public class SdtWWP_AIChatCompletionResponse_RESTInterface : GxGenericCollectionItem<SdtWWP_AIChatCompletionResponse>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AIChatCompletionResponse_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AIChatCompletionResponse_RESTInterface( SdtWWP_AIChatCompletionResponse psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="object", Order=1)]
		public  string gxTpr_Object
		{
			get { 
				return sdt.gxTpr_Object;

			}
			set { 
				 sdt.gxTpr_Object = value;
			}
		}

		[DataMember(Name="created", Order=2)]
		public  string gxTpr_Created
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Created, 10, 0));

			}
			set { 
				sdt.gxTpr_Created = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="model", Order=3)]
		public  string gxTpr_Model
		{
			get { 
				return sdt.gxTpr_Model;

			}
			set { 
				 sdt.gxTpr_Model = value;
			}
		}

		[DataMember(Name="choices", Order=4, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWWP_AIChatCompletionResponse_choicesItem_RESTInterface> gxTpr_Choices
		{
			get {
				if (sdt.ShouldSerializegxTpr_Choices_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWWP_AIChatCompletionResponse_choicesItem_RESTInterface>(sdt.gxTpr_Choices);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Choices);
			}
		}

		[DataMember(Name="usage", Order=5, EmitDefaultValue=false)]
		public SdtWWP_AIChatCompletionResponse_usage_RESTInterface gxTpr_Usage
		{
			get {
				if (sdt.ShouldSerializegxTpr_Usage_Json())
					return new SdtWWP_AIChatCompletionResponse_usage_RESTInterface(sdt.gxTpr_Usage);
				else
					return null;

			}

			set {
				sdt.gxTpr_Usage = value.sdt;
			}

		}


		#endregion

		public SdtWWP_AIChatCompletionResponse sdt
		{
			get { 
				return (SdtWWP_AIChatCompletionResponse)Sdt;
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
				sdt = new SdtWWP_AIChatCompletionResponse() ;
			}
		}
	}
	#endregion
}