/*
				   File: type_SdtWWP_AIChatCompletionRequest_messagesItem
			Description: messages
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
	[XmlRoot(ElementName="WWP_AIChatCompletionRequest.messagesItem")]
	[XmlType(TypeName="WWP_AIChatCompletionRequest.messagesItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AIChatCompletionRequest_messagesItem : GxUserType
	{
		public SdtWWP_AIChatCompletionRequest_messagesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Role = "";

			gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Content = "";

			gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Name = "";

		}

		public SdtWWP_AIChatCompletionRequest_messagesItem(IGxContext context)
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


			if (ShouldSerializegxTpr_Name_Json())
			{	
				AddObjectProperty("name", gxTpr_Name, false);
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
				return gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Role; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Role = value;
				SetDirty("Role");
			}
		}




		[SoapElement(ElementName="content")]
		[XmlElement(ElementName="content")]
		public string gxTpr_Content
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Content; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Content = value;
				SetDirty("Content");
			}
		}




		[SoapElement(ElementName="name")]
		[XmlElement(ElementName="name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Name; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Name_N = false;
				gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Name = value;
				SetDirty("Name");
			}
		}

		public bool ShouldSerializegxTpr_Name_Json()
		{
			return !gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Name_N;

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
			gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Role = "";
			gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Content = "";
			gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Name = "";
			gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Name_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Role;
		 

		protected string gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Content;
		 

		protected string gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Name;
		protected bool gxTv_SdtWWP_AIChatCompletionRequest_messagesItem_Name_N;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WWP_AIChatCompletionRequest.messagesItem", Namespace="YTT_version4")]
	public class SdtWWP_AIChatCompletionRequest_messagesItem_RESTInterface : GxGenericCollectionItem<SdtWWP_AIChatCompletionRequest_messagesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AIChatCompletionRequest_messagesItem_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AIChatCompletionRequest_messagesItem_RESTInterface( SdtWWP_AIChatCompletionRequest_messagesItem psdt ) : base(psdt)
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

		[DataMember(Name="name", Order=2, EmitDefaultValue=false)]
		public  string gxTpr_Name
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Name_Json())
					return sdt.gxTpr_Name;
				else
					return null;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}


		#endregion

		public SdtWWP_AIChatCompletionRequest_messagesItem sdt
		{
			get { 
				return (SdtWWP_AIChatCompletionRequest_messagesItem)Sdt;
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
				sdt = new SdtWWP_AIChatCompletionRequest_messagesItem() ;
			}
		}
	}
	#endregion
}