/*
				   File: type_SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call
			Description: function_call
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
	[XmlRoot(ElementName="WWP_AIChatCompletionResponse.choicesItem.message.function_call")]
	[XmlType(TypeName="WWP_AIChatCompletionResponse.choicesItem.message.function_call" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call : GxUserType
	{
		public SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call_Name = "";

			gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call_Arguments = "";

		}

		public SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call(IGxContext context)
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
			AddObjectProperty("name", gxTpr_Name, false);


			AddObjectProperty("arguments", gxTpr_Arguments, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="name")]
		[XmlElement(ElementName="name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call_Name; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="arguments")]
		[XmlElement(ElementName="arguments")]
		public string gxTpr_Arguments
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call_Arguments; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call_Arguments = value;
				SetDirty("Arguments");
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
			gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call_Name = "";
			gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call_Arguments = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call_Name;
		 

		protected string gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call_Arguments;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWP_AIChatCompletionResponse.choicesItem.message.function_call", Namespace="YTT_version4")]
	public class SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call_RESTInterface : GxGenericCollectionItem<SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call_RESTInterface( SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="arguments", Order=1)]
		public  string gxTpr_Arguments
		{
			get { 
				return sdt.gxTpr_Arguments;

			}
			set { 
				 sdt.gxTpr_Arguments = value;
			}
		}


		#endregion

		public SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call sdt
		{
			get { 
				return (SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call)Sdt;
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
				sdt = new SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call() ;
			}
		}
	}
	#endregion
}