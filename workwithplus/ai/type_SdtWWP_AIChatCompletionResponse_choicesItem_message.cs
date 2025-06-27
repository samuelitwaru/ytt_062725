/*
				   File: type_SdtWWP_AIChatCompletionResponse_choicesItem_message
			Description: message
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
	[XmlRoot(ElementName="WWP_AIChatCompletionResponse.choicesItem.message")]
	[XmlType(TypeName="WWP_AIChatCompletionResponse.choicesItem.message" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AIChatCompletionResponse_choicesItem_message : GxUserType
	{
		public SdtWWP_AIChatCompletionResponse_choicesItem_message( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Role = "";

			gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Content = "";

		}

		public SdtWWP_AIChatCompletionResponse_choicesItem_message(IGxContext context)
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
			AddObjectProperty("role", gxTpr_Role, false);


			AddObjectProperty("content", gxTpr_Content, false);

			if (gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call != null)
			{
				AddObjectProperty("function_call", gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="role")]
		[XmlElement(ElementName="role")]
		public string gxTpr_Role
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Role; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Role = value;
				SetDirty("Role");
			}
		}




		[SoapElement(ElementName="content")]
		[XmlElement(ElementName="content")]
		public string gxTpr_Content
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Content; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Content = value;
				SetDirty("Content");
			}
		}



		[SoapElement(ElementName="function_call" )]
		[XmlElement(ElementName="function_call" )]
		public SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call gxTpr_Function_call
		{
			get {
				if ( gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call == null )
				{
					gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call = new SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call(context);
				}
				gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call_N = false;
				return gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call;
			}
			set {
				gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call_N = false;
				gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call = value;
				SetDirty("Function_call");
			}

		}

		public void gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call_SetNull()
		{
			gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call_N = true;
			gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call = null;
		}

		public bool gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call_IsNull()
		{
			return gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call == null;
		}
		public bool ShouldSerializegxTpr_Function_call_Json()
		{
				return (gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call != null && gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call.ShouldSerializeSdtJson());

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
			gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Role = "";
			gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Content = "";

			gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Role;
		 

		protected string gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Content;
		 
		protected bool gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call_N;
		protected SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_message_Function_call = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWP_AIChatCompletionResponse.choicesItem.message", Namespace="YTT_version4")]
	public class SdtWWP_AIChatCompletionResponse_choicesItem_message_RESTInterface : GxGenericCollectionItem<SdtWWP_AIChatCompletionResponse_choicesItem_message>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AIChatCompletionResponse_choicesItem_message_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AIChatCompletionResponse_choicesItem_message_RESTInterface( SdtWWP_AIChatCompletionResponse_choicesItem_message psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="role", Order=0)]
		public  string gxTpr_Role
		{
			get { 
				return sdt.gxTpr_Role;

			}
			set { 
				 sdt.gxTpr_Role = value;
			}
		}

		[DataMember(Name="content", Order=1)]
		public  string gxTpr_Content
		{
			get { 
				return sdt.gxTpr_Content;

			}
			set { 
				 sdt.gxTpr_Content = value;
			}
		}

		[DataMember(Name="function_call", Order=2, EmitDefaultValue=false)]
		public SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call_RESTInterface gxTpr_Function_call
		{
			get {
				if (sdt.ShouldSerializegxTpr_Function_call_Json())
					return new SdtWWP_AIChatCompletionResponse_choicesItem_message_function_call_RESTInterface(sdt.gxTpr_Function_call);
				else
					return null;

			}

			set {
				sdt.gxTpr_Function_call = value.sdt;
			}

		}


		#endregion

		public SdtWWP_AIChatCompletionResponse_choicesItem_message sdt
		{
			get { 
				return (SdtWWP_AIChatCompletionResponse_choicesItem_message)Sdt;
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
				sdt = new SdtWWP_AIChatCompletionResponse_choicesItem_message() ;
			}
		}
	}
	#endregion
}