/*
				   File: type_SdtWWP_AIChatCompletionRequest_functionsItem_parameters
			Description: parameters
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
	[XmlRoot(ElementName="WWP_AIChatCompletionRequest.functionsItem.parameters")]
	[XmlType(TypeName="WWP_AIChatCompletionRequest.functionsItem.parameters" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AIChatCompletionRequest_functionsItem_parameters : GxUserType
	{
		public SdtWWP_AIChatCompletionRequest_functionsItem_parameters( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_parameters_Type = "";

		}

		public SdtWWP_AIChatCompletionRequest_functionsItem_parameters(IGxContext context)
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
			AddObjectProperty("type", gxTpr_Type, false);

			if (gxTpr_Properties != null)
			{
				AddObjectProperty("properties", gxTpr_Properties, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="type")]
		[XmlElement(ElementName="type")]
		public string gxTpr_Type
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_parameters_Type; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_parameters_Type = value;
				SetDirty("Type");
			}
		}



		[SoapElement(ElementName="properties" )]
		[XmlElement(ElementName="properties" )]
		public SdtWWP_AIChatCompletionRequest_functionsItem_parameters_properties gxTpr_Properties
		{
			get {
				if ( gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_parameters_Properties == null )
				{
					gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_parameters_Properties = new SdtWWP_AIChatCompletionRequest_functionsItem_parameters_properties(context);
				}
				return gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_parameters_Properties;
			}
			set {
				gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_parameters_Properties = value;
				SetDirty("Properties");
			}

		}

		public void gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_parameters_Properties_SetNull()
		{
			gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_parameters_Properties = null;
		}

		public bool gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_parameters_Properties_IsNull()
		{
			return gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_parameters_Properties == null;
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
			gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_parameters_Type = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_parameters_Type;
		 

		protected SdtWWP_AIChatCompletionRequest_functionsItem_parameters_properties gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_parameters_Properties = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWP_AIChatCompletionRequest.functionsItem.parameters", Namespace="YTT_version4")]
	public class SdtWWP_AIChatCompletionRequest_functionsItem_parameters_RESTInterface : GxGenericCollectionItem<SdtWWP_AIChatCompletionRequest_functionsItem_parameters>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AIChatCompletionRequest_functionsItem_parameters_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AIChatCompletionRequest_functionsItem_parameters_RESTInterface( SdtWWP_AIChatCompletionRequest_functionsItem_parameters psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="type", Order=0)]
		public  string gxTpr_Type
		{
			get { 
				return sdt.gxTpr_Type;

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="properties", Order=1)]
		public SdtWWP_AIChatCompletionRequest_functionsItem_parameters_properties_RESTInterface gxTpr_Properties
		{
			get {
				return new SdtWWP_AIChatCompletionRequest_functionsItem_parameters_properties_RESTInterface(sdt.gxTpr_Properties);

			}

			set {
				sdt.gxTpr_Properties = value.sdt;
			}

		}


		#endregion

		public SdtWWP_AIChatCompletionRequest_functionsItem_parameters sdt
		{
			get { 
				return (SdtWWP_AIChatCompletionRequest_functionsItem_parameters)Sdt;
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
				sdt = new SdtWWP_AIChatCompletionRequest_functionsItem_parameters() ;
			}
		}
	}
	#endregion
}