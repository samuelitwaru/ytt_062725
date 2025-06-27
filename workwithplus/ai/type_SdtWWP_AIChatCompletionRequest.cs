/*
				   File: type_SdtWWP_AIChatCompletionRequest
			Description: WWP_AIChatCompletionRequest
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
	[XmlRoot(ElementName="WWP_AIChatCompletionRequest")]
	[XmlType(TypeName="WWP_AIChatCompletionRequest" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AIChatCompletionRequest : GxUserType
	{
		public SdtWWP_AIChatCompletionRequest( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_AIChatCompletionRequest_Model = "";

		}

		public SdtWWP_AIChatCompletionRequest(IGxContext context)
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
			AddObjectProperty("model", gxTpr_Model, false);


			if (ShouldSerializegxTpr_Temperature_Json())
			{	
				AddObjectProperty("temperature", gxTpr_Temperature, false);
			}


			if (ShouldSerializegxTpr_Top_p_Json())
			{	
				AddObjectProperty("top_p", gxTpr_Top_p, false);
			}


			if (ShouldSerializegxTpr_N_Json())
			{	
				AddObjectProperty("n", gxTpr_N, false);
			}


			if (ShouldSerializegxTpr_Max_tokens_Json())
			{	
				AddObjectProperty("max_tokens", gxTpr_Max_tokens, false);
			}

			if (gxTv_SdtWWP_AIChatCompletionRequest_Functions != null)
			{
				AddObjectProperty("functions", gxTv_SdtWWP_AIChatCompletionRequest_Functions, false);
			}
			if (gxTv_SdtWWP_AIChatCompletionRequest_Messages != null)
			{
				AddObjectProperty("messages", gxTv_SdtWWP_AIChatCompletionRequest_Messages, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="model")]
		[XmlElement(ElementName="model")]
		public string gxTpr_Model
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionRequest_Model; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionRequest_Model = value;
				SetDirty("Model");
			}
		}



		[SoapElement(ElementName="temperature")]
		[XmlElement(ElementName="temperature")]
		public string gxTpr_Temperature_double
		{
			get {
				return Convert.ToString(gxTv_SdtWWP_AIChatCompletionRequest_Temperature, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtWWP_AIChatCompletionRequest_Temperature = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Temperature
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionRequest_Temperature; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionRequest_Temperature_N = false;
				gxTv_SdtWWP_AIChatCompletionRequest_Temperature = value;
				SetDirty("Temperature");
			}
		}

		public bool ShouldSerializegxTpr_Temperature_Json()
		{
			return !gxTv_SdtWWP_AIChatCompletionRequest_Temperature_N;

		}


		[SoapElement(ElementName="top_p")]
		[XmlElement(ElementName="top_p")]
		public string gxTpr_Top_p_double
		{
			get {
				return Convert.ToString(gxTv_SdtWWP_AIChatCompletionRequest_Top_p, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtWWP_AIChatCompletionRequest_Top_p = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Top_p
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionRequest_Top_p; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionRequest_Top_p_N = false;
				gxTv_SdtWWP_AIChatCompletionRequest_Top_p = value;
				SetDirty("Top_p");
			}
		}

		public bool ShouldSerializegxTpr_Top_p_Json()
		{
			return !gxTv_SdtWWP_AIChatCompletionRequest_Top_p_N;

		}



		[SoapElement(ElementName="n")]
		[XmlElement(ElementName="n")]
		public short gxTpr_N
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionRequest_N; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionRequest_N_N = false;
				gxTv_SdtWWP_AIChatCompletionRequest_N = value;
				SetDirty("N");
			}
		}

		public bool ShouldSerializegxTpr_N_Json()
		{
			return !gxTv_SdtWWP_AIChatCompletionRequest_N_N;

		}



		[SoapElement(ElementName="max_tokens")]
		[XmlElement(ElementName="max_tokens")]
		public long gxTpr_Max_tokens
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionRequest_Max_tokens; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionRequest_Max_tokens_N = false;
				gxTv_SdtWWP_AIChatCompletionRequest_Max_tokens = value;
				SetDirty("Max_tokens");
			}
		}

		public bool ShouldSerializegxTpr_Max_tokens_Json()
		{
			return !gxTv_SdtWWP_AIChatCompletionRequest_Max_tokens_N;

		}



		[SoapElement(ElementName="functions" )]
		[XmlArray(ElementName="functions"  )]
		[XmlArrayItemAttribute(ElementName="functionsItem" , IsNullable=false )]
		public GXBaseCollection<SdtWWP_AIChatCompletionRequest_functionsItem> gxTpr_Functions
		{
			get {
				if ( gxTv_SdtWWP_AIChatCompletionRequest_Functions == null )
				{
					gxTv_SdtWWP_AIChatCompletionRequest_Functions = new GXBaseCollection<SdtWWP_AIChatCompletionRequest_functionsItem>( context, "WWP_AIChatCompletionRequest.functionsItem", "");
				}
				return gxTv_SdtWWP_AIChatCompletionRequest_Functions;
			}
			set {
				gxTv_SdtWWP_AIChatCompletionRequest_Functions_N = false;
				gxTv_SdtWWP_AIChatCompletionRequest_Functions = value;
				SetDirty("Functions");
			}
		}

		public void gxTv_SdtWWP_AIChatCompletionRequest_Functions_SetNull()
		{
			gxTv_SdtWWP_AIChatCompletionRequest_Functions_N = true;
			gxTv_SdtWWP_AIChatCompletionRequest_Functions = null;
		}

		public bool gxTv_SdtWWP_AIChatCompletionRequest_Functions_IsNull()
		{
			return gxTv_SdtWWP_AIChatCompletionRequest_Functions == null;
		}
		public bool ShouldSerializegxTpr_Functions_GxSimpleCollection_Json()
		{
			return gxTv_SdtWWP_AIChatCompletionRequest_Functions != null && gxTv_SdtWWP_AIChatCompletionRequest_Functions.Count > 0;

		}



		[SoapElement(ElementName="messages" )]
		[XmlArray(ElementName="messages"  )]
		[XmlArrayItemAttribute(ElementName="messagesItem" , IsNullable=false )]
		public GXBaseCollection<SdtWWP_AIChatCompletionRequest_messagesItem> gxTpr_Messages
		{
			get {
				if ( gxTv_SdtWWP_AIChatCompletionRequest_Messages == null )
				{
					gxTv_SdtWWP_AIChatCompletionRequest_Messages = new GXBaseCollection<SdtWWP_AIChatCompletionRequest_messagesItem>( context, "WWP_AIChatCompletionRequest.messagesItem", "");
				}
				return gxTv_SdtWWP_AIChatCompletionRequest_Messages;
			}
			set {
				gxTv_SdtWWP_AIChatCompletionRequest_Messages_N = false;
				gxTv_SdtWWP_AIChatCompletionRequest_Messages = value;
				SetDirty("Messages");
			}
		}

		public void gxTv_SdtWWP_AIChatCompletionRequest_Messages_SetNull()
		{
			gxTv_SdtWWP_AIChatCompletionRequest_Messages_N = true;
			gxTv_SdtWWP_AIChatCompletionRequest_Messages = null;
		}

		public bool gxTv_SdtWWP_AIChatCompletionRequest_Messages_IsNull()
		{
			return gxTv_SdtWWP_AIChatCompletionRequest_Messages == null;
		}
		public bool ShouldSerializegxTpr_Messages_GxSimpleCollection_Json()
		{
			return gxTv_SdtWWP_AIChatCompletionRequest_Messages != null && gxTv_SdtWWP_AIChatCompletionRequest_Messages.Count > 0;

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
			gxTv_SdtWWP_AIChatCompletionRequest_Model = "";

			gxTv_SdtWWP_AIChatCompletionRequest_Temperature_N = true;


			gxTv_SdtWWP_AIChatCompletionRequest_Top_p_N = true;


			gxTv_SdtWWP_AIChatCompletionRequest_N_N = true;


			gxTv_SdtWWP_AIChatCompletionRequest_Max_tokens_N = true;


			gxTv_SdtWWP_AIChatCompletionRequest_Functions_N = true;


			gxTv_SdtWWP_AIChatCompletionRequest_Messages_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWP_AIChatCompletionRequest_Model;
		 

		protected decimal gxTv_SdtWWP_AIChatCompletionRequest_Temperature;
		protected bool gxTv_SdtWWP_AIChatCompletionRequest_Temperature_N;
		 

		protected decimal gxTv_SdtWWP_AIChatCompletionRequest_Top_p;
		protected bool gxTv_SdtWWP_AIChatCompletionRequest_Top_p_N;
		 

		protected short gxTv_SdtWWP_AIChatCompletionRequest_N;
		protected bool gxTv_SdtWWP_AIChatCompletionRequest_N_N;
		 

		protected long gxTv_SdtWWP_AIChatCompletionRequest_Max_tokens;
		protected bool gxTv_SdtWWP_AIChatCompletionRequest_Max_tokens_N;
		 
		protected bool gxTv_SdtWWP_AIChatCompletionRequest_Functions_N;
		protected GXBaseCollection<SdtWWP_AIChatCompletionRequest_functionsItem> gxTv_SdtWWP_AIChatCompletionRequest_Functions = null; 

		protected bool gxTv_SdtWWP_AIChatCompletionRequest_Messages_N;
		protected GXBaseCollection<SdtWWP_AIChatCompletionRequest_messagesItem> gxTv_SdtWWP_AIChatCompletionRequest_Messages = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWP_AIChatCompletionRequest", Namespace="YTT_version4")]
	public class SdtWWP_AIChatCompletionRequest_RESTInterface : GxGenericCollectionItem<SdtWWP_AIChatCompletionRequest>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AIChatCompletionRequest_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AIChatCompletionRequest_RESTInterface( SdtWWP_AIChatCompletionRequest psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="model", Order=0)]
		public  string gxTpr_Model
		{
			get { 
				return sdt.gxTpr_Model;

			}
			set { 
				 sdt.gxTpr_Model = value;
			}
		}

		[DataMember(Name="temperature", Order=1, EmitDefaultValue=false)]
		public  string gxTpr_Temperature
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Temperature_Json())
					return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Temperature, 10, 5));
				else
					return null;

			}
			set { 
				sdt.gxTpr_Temperature =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="top_p", Order=2, EmitDefaultValue=false)]
		public  string gxTpr_Top_p
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Top_p_Json())
					return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Top_p, 10, 5));
				else
					return null;

			}
			set { 
				sdt.gxTpr_Top_p =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="n", Order=3, EmitDefaultValue=false)]
		public  Nullable<short> gxTpr_N
		{
			get { 
				if (sdt.ShouldSerializegxTpr_N_Json())
					return sdt.gxTpr_N;
				else
					return null;

			}
			set { 
				sdt.gxTpr_N = (short) (value.HasValue ? value.Value : 0);
			}
		}

		[DataMember(Name="max_tokens", Order=4, EmitDefaultValue=false)]
		public  string gxTpr_Max_tokens
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Max_tokens_Json())
					return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Max_tokens, 10, 0));
				else
					return null;

			}
			set { 
				sdt.gxTpr_Max_tokens = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="functions", Order=5, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWWP_AIChatCompletionRequest_functionsItem_RESTInterface> gxTpr_Functions
		{
			get {
				if (sdt.ShouldSerializegxTpr_Functions_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWWP_AIChatCompletionRequest_functionsItem_RESTInterface>(sdt.gxTpr_Functions);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Functions);
			}
		}

		[DataMember(Name="messages", Order=6, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWWP_AIChatCompletionRequest_messagesItem_RESTInterface> gxTpr_Messages
		{
			get {
				if (sdt.ShouldSerializegxTpr_Messages_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWWP_AIChatCompletionRequest_messagesItem_RESTInterface>(sdt.gxTpr_Messages);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Messages);
			}
		}


		#endregion

		public SdtWWP_AIChatCompletionRequest sdt
		{
			get { 
				return (SdtWWP_AIChatCompletionRequest)Sdt;
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
				sdt = new SdtWWP_AIChatCompletionRequest() ;
			}
		}
	}
	#endregion
}