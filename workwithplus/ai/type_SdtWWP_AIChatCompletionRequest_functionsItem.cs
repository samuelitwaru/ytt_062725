/*
				   File: type_SdtWWP_AIChatCompletionRequest_functionsItem
			Description: functions
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
	[XmlRoot(ElementName="WWP_AIChatCompletionRequest.functionsItem")]
	[XmlType(TypeName="WWP_AIChatCompletionRequest.functionsItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AIChatCompletionRequest_functionsItem : GxUserType
	{
		public SdtWWP_AIChatCompletionRequest_functionsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Name = "";

			gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Description = "";

		}

		public SdtWWP_AIChatCompletionRequest_functionsItem(IGxContext context)
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


			AddObjectProperty("description", gxTpr_Description, false);

			if (gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters != null)
			{
				AddObjectProperty("parameters", gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="name")]
		[XmlElement(ElementName="name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Name; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="description")]
		[XmlElement(ElementName="description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Description; 
			}
			set {
				gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Description = value;
				SetDirty("Description");
			}
		}



		[SoapElement(ElementName="parameters" )]
		[XmlElement(ElementName="parameters" )]
		public SdtWWP_AIChatCompletionRequest_functionsItem_parameters gxTpr_Parameters
		{
			get {
				if ( gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters == null )
				{
					gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters = new SdtWWP_AIChatCompletionRequest_functionsItem_parameters(context);
				}
				gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters_N = false;
				return gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters;
			}
			set {
				gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters_N = false;
				gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters = value;
				SetDirty("Parameters");
			}

		}

		public void gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters_SetNull()
		{
			gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters_N = true;
			gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters = null;
		}

		public bool gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters_IsNull()
		{
			return gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters == null;
		}
		public bool ShouldSerializegxTpr_Parameters_Json()
		{
				return (gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters != null && gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters.ShouldSerializeSdtJson());

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
			gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Name = "";
			gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Description = "";

			gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Name;
		 

		protected string gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Description;
		 
		protected bool gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters_N;
		protected SdtWWP_AIChatCompletionRequest_functionsItem_parameters gxTv_SdtWWP_AIChatCompletionRequest_functionsItem_Parameters = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WWP_AIChatCompletionRequest.functionsItem", Namespace="YTT_version4")]
	public class SdtWWP_AIChatCompletionRequest_functionsItem_RESTInterface : GxGenericCollectionItem<SdtWWP_AIChatCompletionRequest_functionsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AIChatCompletionRequest_functionsItem_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AIChatCompletionRequest_functionsItem_RESTInterface( SdtWWP_AIChatCompletionRequest_functionsItem psdt ) : base(psdt)
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

		[DataMember(Name="description", Order=1)]
		public  string gxTpr_Description
		{
			get { 
				return sdt.gxTpr_Description;

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}

		[DataMember(Name="parameters", Order=2, EmitDefaultValue=false)]
		public SdtWWP_AIChatCompletionRequest_functionsItem_parameters_RESTInterface gxTpr_Parameters
		{
			get {
				if (sdt.ShouldSerializegxTpr_Parameters_Json())
					return new SdtWWP_AIChatCompletionRequest_functionsItem_parameters_RESTInterface(sdt.gxTpr_Parameters);
				else
					return null;

			}

			set {
				sdt.gxTpr_Parameters = value.sdt;
			}

		}


		#endregion

		public SdtWWP_AIChatCompletionRequest_functionsItem sdt
		{
			get { 
				return (SdtWWP_AIChatCompletionRequest_functionsItem)Sdt;
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
				sdt = new SdtWWP_AIChatCompletionRequest_functionsItem() ;
			}
		}
	}
	#endregion
}