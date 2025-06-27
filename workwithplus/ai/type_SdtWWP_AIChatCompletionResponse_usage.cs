/*
				   File: type_SdtWWP_AIChatCompletionResponse_usage
			Description: usage
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
	[XmlRoot(ElementName="WWP_AIChatCompletionResponse.usage")]
	[XmlType(TypeName="WWP_AIChatCompletionResponse.usage" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AIChatCompletionResponse_usage : GxUserType
	{
		public SdtWWP_AIChatCompletionResponse_usage( )
		{
			/* Constructor for serialization */
		}

		public SdtWWP_AIChatCompletionResponse_usage(IGxContext context)
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
			AddObjectProperty("prompt_tokens", gxTpr_Prompt_tokens, false);


			AddObjectProperty("completion_tokens", gxTpr_Completion_tokens, false);


			AddObjectProperty("total_tokens", gxTpr_Total_tokens, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="prompt_tokens")]
		[XmlElement(ElementName="prompt_tokens")]
		public long gxTpr_Prompt_tokens
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionResponse_usage_Prompt_tokens; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionResponse_usage_Prompt_tokens = value;
				SetDirty("Prompt_tokens");
			}
		}




		[SoapElement(ElementName="completion_tokens")]
		[XmlElement(ElementName="completion_tokens")]
		public long gxTpr_Completion_tokens
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionResponse_usage_Completion_tokens; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionResponse_usage_Completion_tokens = value;
				SetDirty("Completion_tokens");
			}
		}




		[SoapElement(ElementName="total_tokens")]
		[XmlElement(ElementName="total_tokens")]
		public long gxTpr_Total_tokens
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionResponse_usage_Total_tokens; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionResponse_usage_Total_tokens = value;
				SetDirty("Total_tokens");
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
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtWWP_AIChatCompletionResponse_usage_Prompt_tokens;
		 

		protected long gxTv_SdtWWP_AIChatCompletionResponse_usage_Completion_tokens;
		 

		protected long gxTv_SdtWWP_AIChatCompletionResponse_usage_Total_tokens;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWP_AIChatCompletionResponse.usage", Namespace="YTT_version4")]
	public class SdtWWP_AIChatCompletionResponse_usage_RESTInterface : GxGenericCollectionItem<SdtWWP_AIChatCompletionResponse_usage>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AIChatCompletionResponse_usage_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AIChatCompletionResponse_usage_RESTInterface( SdtWWP_AIChatCompletionResponse_usage psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="prompt_tokens", Order=0)]
		public  string gxTpr_Prompt_tokens
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Prompt_tokens, 10, 0));

			}
			set { 
				sdt.gxTpr_Prompt_tokens = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="completion_tokens", Order=1)]
		public  string gxTpr_Completion_tokens
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Completion_tokens, 10, 0));

			}
			set { 
				sdt.gxTpr_Completion_tokens = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="total_tokens", Order=2)]
		public  string gxTpr_Total_tokens
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Total_tokens, 10, 0));

			}
			set { 
				sdt.gxTpr_Total_tokens = (long) NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtWWP_AIChatCompletionResponse_usage sdt
		{
			get { 
				return (SdtWWP_AIChatCompletionResponse_usage)Sdt;
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
				sdt = new SdtWWP_AIChatCompletionResponse_usage() ;
			}
		}
	}
	#endregion
}