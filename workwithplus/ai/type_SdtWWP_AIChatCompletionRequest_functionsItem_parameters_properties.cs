/*
				   File: type_SdtWWP_AIChatCompletionRequest_functionsItem_parameters_properties
			Description: properties
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
	[XmlRoot(ElementName="WWP_AIChatCompletionRequest.functionsItem.parameters.properties")]
	[XmlType(TypeName="WWP_AIChatCompletionRequest.functionsItem.parameters.properties" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AIChatCompletionRequest_functionsItem_parameters_properties : GxUserType
	{
		public SdtWWP_AIChatCompletionRequest_functionsItem_parameters_properties( )
		{
			/* Constructor for serialization */
		}

		public SdtWWP_AIChatCompletionRequest_functionsItem_parameters_properties(IGxContext context)
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
			return;
		}
		#endregion

		#region Properties

		public override bool ShouldSerializeSdtJson()
		{
			return (
		 
				false);
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


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWP_AIChatCompletionRequest.functionsItem.parameters.properties", Namespace="YTT_version4")]
	public class SdtWWP_AIChatCompletionRequest_functionsItem_parameters_properties_RESTInterface : GxGenericCollectionItem<SdtWWP_AIChatCompletionRequest_functionsItem_parameters_properties>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AIChatCompletionRequest_functionsItem_parameters_properties_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AIChatCompletionRequest_functionsItem_parameters_properties_RESTInterface( SdtWWP_AIChatCompletionRequest_functionsItem_parameters_properties psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		#endregion

		public SdtWWP_AIChatCompletionRequest_functionsItem_parameters_properties sdt
		{
			get { 
				return (SdtWWP_AIChatCompletionRequest_functionsItem_parameters_properties)Sdt;
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
				sdt = new SdtWWP_AIChatCompletionRequest_functionsItem_parameters_properties() ;
			}
		}
	}
	#endregion
}