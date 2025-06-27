/*
				   File: type_SdtWWP_AIListData_Examples
			Description: Examples
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
	[XmlRoot(ElementName="WWP_AIListData.Examples")]
	[XmlType(TypeName="WWP_AIListData.Examples" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AIListData_Examples : GxUserType
	{
		public SdtWWP_AIListData_Examples( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_AIListData_Examples_Contextinfo = "";

		}

		public SdtWWP_AIListData_Examples(IGxContext context)
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
			AddObjectProperty("ContextInfo", gxTpr_Contextinfo, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ContextInfo")]
		[XmlElement(ElementName="ContextInfo")]
		public string gxTpr_Contextinfo
		{
			get {
				return gxTv_SdtWWP_AIListData_Examples_Contextinfo; 
			}
			set {
				gxTv_SdtWWP_AIListData_Examples_Contextinfo = value;
				SetDirty("Contextinfo");
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
			gxTv_SdtWWP_AIListData_Examples_Contextinfo = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWP_AIListData_Examples_Contextinfo;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWP_AIListData.Examples", Namespace="YTT_version4")]
	public class SdtWWP_AIListData_Examples_RESTInterface : GxGenericCollectionItem<SdtWWP_AIListData_Examples>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AIListData_Examples_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AIListData_Examples_RESTInterface( SdtWWP_AIListData_Examples psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ContextInfo", Order=0)]
		public  string gxTpr_Contextinfo
		{
			get { 
				return sdt.gxTpr_Contextinfo;

			}
			set { 
				 sdt.gxTpr_Contextinfo = value;
			}
		}


		#endregion

		public SdtWWP_AIListData_Examples sdt
		{
			get { 
				return (SdtWWP_AIListData_Examples)Sdt;
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
				sdt = new SdtWWP_AIListData_Examples() ;
			}
		}
	}
	#endregion
}