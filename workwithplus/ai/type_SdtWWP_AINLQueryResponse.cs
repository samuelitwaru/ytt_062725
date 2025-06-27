/*
				   File: type_SdtWWP_AINLQueryResponse
			Description: WWP_AINLQueryResponse
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
	[XmlRoot(ElementName="WWP_AINLQueryResponse")]
	[XmlType(TypeName="WWP_AINLQueryResponse" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AINLQueryResponse : GxUserType
	{
		public SdtWWP_AINLQueryResponse( )
		{
			/* Constructor for serialization */
		}

		public SdtWWP_AINLQueryResponse(IGxContext context)
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
			if (gxTv_SdtWWP_AINLQueryResponse_Sort != null)
			{
				AddObjectProperty("Sort", gxTv_SdtWWP_AINLQueryResponse_Sort, false);
			}
			if (gxTv_SdtWWP_AINLQueryResponse_Filtervalues != null)
			{
				AddObjectProperty("FilterValues", gxTv_SdtWWP_AINLQueryResponse_Filtervalues, false);
			}

			AddObjectProperty("UserIntent", gxTpr_Userintent, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Sort" )]
		[XmlElement(ElementName="Sort" )]
		public SdtWWP_AINLQueryResponse_Sort gxTpr_Sort
		{
			get {
				if ( gxTv_SdtWWP_AINLQueryResponse_Sort == null )
				{
					gxTv_SdtWWP_AINLQueryResponse_Sort = new SdtWWP_AINLQueryResponse_Sort(context);
				}
				gxTv_SdtWWP_AINLQueryResponse_Sort_N = false;
				return gxTv_SdtWWP_AINLQueryResponse_Sort;
			}
			set {
				gxTv_SdtWWP_AINLQueryResponse_Sort_N = false;
				gxTv_SdtWWP_AINLQueryResponse_Sort = value;
				SetDirty("Sort");
			}

		}

		public void gxTv_SdtWWP_AINLQueryResponse_Sort_SetNull()
		{
			gxTv_SdtWWP_AINLQueryResponse_Sort_N = true;
			gxTv_SdtWWP_AINLQueryResponse_Sort = null;
		}

		public bool gxTv_SdtWWP_AINLQueryResponse_Sort_IsNull()
		{
			return gxTv_SdtWWP_AINLQueryResponse_Sort == null;
		}
		public bool ShouldSerializegxTpr_Sort_Json()
		{
				return (gxTv_SdtWWP_AINLQueryResponse_Sort != null && gxTv_SdtWWP_AINLQueryResponse_Sort.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="FilterValues" )]
		[XmlArray(ElementName="FilterValues"  )]
		[XmlArrayItemAttribute(ElementName="FilterValue" , IsNullable=false )]
		public GXBaseCollection<SdtWWP_AINLQueryResponse_FilterValue> gxTpr_Filtervalues
		{
			get {
				if ( gxTv_SdtWWP_AINLQueryResponse_Filtervalues == null )
				{
					gxTv_SdtWWP_AINLQueryResponse_Filtervalues = new GXBaseCollection<SdtWWP_AINLQueryResponse_FilterValue>( context, "WWP_AINLQueryResponse.FilterValue", "");
				}
				return gxTv_SdtWWP_AINLQueryResponse_Filtervalues;
			}
			set {
				gxTv_SdtWWP_AINLQueryResponse_Filtervalues_N = false;
				gxTv_SdtWWP_AINLQueryResponse_Filtervalues = value;
				SetDirty("Filtervalues");
			}
		}

		public void gxTv_SdtWWP_AINLQueryResponse_Filtervalues_SetNull()
		{
			gxTv_SdtWWP_AINLQueryResponse_Filtervalues_N = true;
			gxTv_SdtWWP_AINLQueryResponse_Filtervalues = null;
		}

		public bool gxTv_SdtWWP_AINLQueryResponse_Filtervalues_IsNull()
		{
			return gxTv_SdtWWP_AINLQueryResponse_Filtervalues == null;
		}
		public bool ShouldSerializegxTpr_Filtervalues_GxSimpleCollection_Json()
		{
			return gxTv_SdtWWP_AINLQueryResponse_Filtervalues != null && gxTv_SdtWWP_AINLQueryResponse_Filtervalues.Count > 0;

		}



		[SoapElement(ElementName="UserIntent")]
		[XmlElement(ElementName="UserIntent")]
		public short gxTpr_Userintent
		{
			get {
				return gxTv_SdtWWP_AINLQueryResponse_Userintent; 
			}
			set {
				gxTv_SdtWWP_AINLQueryResponse_Userintent = value;
				SetDirty("Userintent");
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
			gxTv_SdtWWP_AINLQueryResponse_Sort_N = true;


			gxTv_SdtWWP_AINLQueryResponse_Filtervalues_N = true;


			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWWP_AINLQueryResponse_Sort_N;
		protected SdtWWP_AINLQueryResponse_Sort gxTv_SdtWWP_AINLQueryResponse_Sort = null; 

		protected bool gxTv_SdtWWP_AINLQueryResponse_Filtervalues_N;
		protected GXBaseCollection<SdtWWP_AINLQueryResponse_FilterValue> gxTv_SdtWWP_AINLQueryResponse_Filtervalues = null; 


		protected short gxTv_SdtWWP_AINLQueryResponse_Userintent;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWP_AINLQueryResponse", Namespace="YTT_version4")]
	public class SdtWWP_AINLQueryResponse_RESTInterface : GxGenericCollectionItem<SdtWWP_AINLQueryResponse>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AINLQueryResponse_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AINLQueryResponse_RESTInterface( SdtWWP_AINLQueryResponse psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Sort", Order=0, EmitDefaultValue=false)]
		public SdtWWP_AINLQueryResponse_Sort_RESTInterface gxTpr_Sort
		{
			get {
				if (sdt.ShouldSerializegxTpr_Sort_Json())
					return new SdtWWP_AINLQueryResponse_Sort_RESTInterface(sdt.gxTpr_Sort);
				else
					return null;

			}

			set {
				sdt.gxTpr_Sort = value.sdt;
			}

		}

		[DataMember(Name="FilterValues", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWWP_AINLQueryResponse_FilterValue_RESTInterface> gxTpr_Filtervalues
		{
			get {
				if (sdt.ShouldSerializegxTpr_Filtervalues_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWWP_AINLQueryResponse_FilterValue_RESTInterface>(sdt.gxTpr_Filtervalues);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Filtervalues);
			}
		}

		[DataMember(Name="UserIntent", Order=2)]
		public short gxTpr_Userintent
		{
			get { 
				return sdt.gxTpr_Userintent;

			}
			set { 
				sdt.gxTpr_Userintent = value;
			}
		}


		#endregion

		public SdtWWP_AINLQueryResponse sdt
		{
			get { 
				return (SdtWWP_AINLQueryResponse)Sdt;
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
				sdt = new SdtWWP_AINLQueryResponse() ;
			}
		}
	}
	#endregion
}