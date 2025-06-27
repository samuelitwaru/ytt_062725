/*
				   File: type_SdtWWP_AIChatCompletionResponse_choicesItem
			Description: choices
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
	[XmlRoot(ElementName="WWP_AIChatCompletionResponse.choicesItem")]
	[XmlType(TypeName="WWP_AIChatCompletionResponse.choicesItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AIChatCompletionResponse_choicesItem : GxUserType
	{
		public SdtWWP_AIChatCompletionResponse_choicesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Finish_reason = "";

		}

		public SdtWWP_AIChatCompletionResponse_choicesItem(IGxContext context)
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
			AddObjectProperty("index", gxTpr_Index, false);

			if (gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message != null)
			{
				AddObjectProperty("message", gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message, false);
			}

			AddObjectProperty("finish_reason", gxTpr_Finish_reason, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="index")]
		[XmlElement(ElementName="index")]
		public long gxTpr_Index
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Index; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Index = value;
				SetDirty("Index");
			}
		}



		[SoapElement(ElementName="message" )]
		[XmlElement(ElementName="message" )]
		public SdtWWP_AIChatCompletionResponse_choicesItem_message gxTpr_Message
		{
			get {
				if ( gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message == null )
				{
					gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message = new SdtWWP_AIChatCompletionResponse_choicesItem_message(context);
				}
				gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message_N = false;
				return gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message;
			}
			set {
				gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message_N = false;
				gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message = value;
				SetDirty("Message");
			}

		}

		public void gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message_SetNull()
		{
			gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message_N = true;
			gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message = null;
		}

		public bool gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message_IsNull()
		{
			return gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message == null;
		}
		public bool ShouldSerializegxTpr_Message_Json()
		{
				return (gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message != null && gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="finish_reason")]
		[XmlElement(ElementName="finish_reason")]
		public string gxTpr_Finish_reason
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Finish_reason; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Finish_reason = value;
				SetDirty("Finish_reason");
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
			gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message_N = true;

			gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Finish_reason = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Index;
		 
		protected bool gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message_N;
		protected SdtWWP_AIChatCompletionResponse_choicesItem_message gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Message = null; 


		protected string gxTv_SdtWWP_AIChatCompletionResponse_choicesItem_Finish_reason;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WWP_AIChatCompletionResponse.choicesItem", Namespace="YTT_version4")]
	public class SdtWWP_AIChatCompletionResponse_choicesItem_RESTInterface : GxGenericCollectionItem<SdtWWP_AIChatCompletionResponse_choicesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AIChatCompletionResponse_choicesItem_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AIChatCompletionResponse_choicesItem_RESTInterface( SdtWWP_AIChatCompletionResponse_choicesItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="index", Order=0)]
		public  string gxTpr_Index
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Index, 10, 0));

			}
			set { 
				sdt.gxTpr_Index = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="message", Order=1, EmitDefaultValue=false)]
		public SdtWWP_AIChatCompletionResponse_choicesItem_message_RESTInterface gxTpr_Message
		{
			get {
				if (sdt.ShouldSerializegxTpr_Message_Json())
					return new SdtWWP_AIChatCompletionResponse_choicesItem_message_RESTInterface(sdt.gxTpr_Message);
				else
					return null;

			}

			set {
				sdt.gxTpr_Message = value.sdt;
			}

		}

		[DataMember(Name="finish_reason", Order=2)]
		public  string gxTpr_Finish_reason
		{
			get { 
				return sdt.gxTpr_Finish_reason;

			}
			set { 
				 sdt.gxTpr_Finish_reason = value;
			}
		}


		#endregion

		public SdtWWP_AIChatCompletionResponse_choicesItem sdt
		{
			get { 
				return (SdtWWP_AIChatCompletionResponse_choicesItem)Sdt;
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
				sdt = new SdtWWP_AIChatCompletionResponse_choicesItem() ;
			}
		}
	}
	#endregion
}