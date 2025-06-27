/*
				   File: type_SdtWWP_AINLQueryResponse_Sort
			Description: Sort
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
	[XmlRoot(ElementName="WWP_AINLQueryResponse.Sort")]
	[XmlType(TypeName="WWP_AINLQueryResponse.Sort" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AINLQueryResponse_Sort : GxUserType
	{
		public SdtWWP_AINLQueryResponse_Sort( )
		{
			/* Constructor for serialization */
		}

		public SdtWWP_AINLQueryResponse_Sort(IGxContext context)
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
			AddObjectProperty("Index", gxTpr_Index, false);


			AddObjectProperty("Descending", gxTpr_Descending, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Index")]
		[XmlElement(ElementName="Index")]
		public short gxTpr_Index
		{
			get {
				return gxTv_SdtWWP_AINLQueryResponse_Sort_Index; 
			}
			set {
				gxTv_SdtWWP_AINLQueryResponse_Sort_Index = value;
				SetDirty("Index");
			}
		}




		[SoapElement(ElementName="Descending")]
		[XmlElement(ElementName="Descending")]
		public bool gxTpr_Descending
		{
			get {
				return gxTv_SdtWWP_AINLQueryResponse_Sort_Descending; 
			}
			set {
				gxTv_SdtWWP_AINLQueryResponse_Sort_Descending = value;
				SetDirty("Descending");
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

		protected short gxTv_SdtWWP_AINLQueryResponse_Sort_Index;
		 

		protected bool gxTv_SdtWWP_AINLQueryResponse_Sort_Descending;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWP_AINLQueryResponse.Sort", Namespace="YTT_version4")]
	public class SdtWWP_AINLQueryResponse_Sort_RESTInterface : GxGenericCollectionItem<SdtWWP_AINLQueryResponse_Sort>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AINLQueryResponse_Sort_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AINLQueryResponse_Sort_RESTInterface( SdtWWP_AINLQueryResponse_Sort psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Index", Order=0)]
		public short gxTpr_Index
		{
			get { 
				return sdt.gxTpr_Index;

			}
			set { 
				sdt.gxTpr_Index = value;
			}
		}

		[DataMember(Name="Descending", Order=1)]
		public bool gxTpr_Descending
		{
			get { 
				return sdt.gxTpr_Descending;

			}
			set { 
				sdt.gxTpr_Descending = value;
			}
		}


		#endregion

		public SdtWWP_AINLQueryResponse_Sort sdt
		{
			get { 
				return (SdtWWP_AINLQueryResponse_Sort)Sdt;
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
				sdt = new SdtWWP_AINLQueryResponse_Sort() ;
			}
		}
	}
	#endregion
}