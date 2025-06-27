/*
				   File: type_SdtWWP_AIListData_ListQuery
			Description: ListQuery
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
	[XmlRoot(ElementName="WWP_AIListData.ListQuery")]
	[XmlType(TypeName="WWP_AIListData.ListQuery" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AIListData_ListQuery : GxUserType
	{
		public SdtWWP_AIListData_ListQuery( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_AIListData_ListQuery_Contextinfo = "";

			gxTv_SdtWWP_AIListData_ListQuery_Link = "";

		}

		public SdtWWP_AIListData_ListQuery(IGxContext context)
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


			AddObjectProperty("Link", gxTpr_Link, false);

			if (gxTv_SdtWWP_AIListData_ListQuery_Filterstofix != null)
			{
				AddObjectProperty("FiltersToFix", gxTv_SdtWWP_AIListData_ListQuery_Filterstofix, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ContextInfo")]
		[XmlElement(ElementName="ContextInfo")]
		public string gxTpr_Contextinfo
		{
			get {
				return gxTv_SdtWWP_AIListData_ListQuery_Contextinfo; 
			}
			set {
				gxTv_SdtWWP_AIListData_ListQuery_Contextinfo = value;
				SetDirty("Contextinfo");
			}
		}




		[SoapElement(ElementName="Link")]
		[XmlElement(ElementName="Link")]
		public string gxTpr_Link
		{
			get {
				return gxTv_SdtWWP_AIListData_ListQuery_Link; 
			}
			set {
				gxTv_SdtWWP_AIListData_ListQuery_Link = value;
				SetDirty("Link");
			}
		}




		[SoapElement(ElementName="FiltersToFix" )]
		[XmlArray(ElementName="FiltersToFix"  )]
		[XmlArrayItemAttribute(ElementName="FiltersToFixItem" , IsNullable=false )]
		public GXBaseCollection<SdtWWP_AIListData_ListQuery_FiltersToFixItem> gxTpr_Filterstofix
		{
			get {
				if ( gxTv_SdtWWP_AIListData_ListQuery_Filterstofix == null )
				{
					gxTv_SdtWWP_AIListData_ListQuery_Filterstofix = new GXBaseCollection<SdtWWP_AIListData_ListQuery_FiltersToFixItem>( context, "WWP_AIListData.ListQuery.FiltersToFixItem", "");
				}
				return gxTv_SdtWWP_AIListData_ListQuery_Filterstofix;
			}
			set {
				gxTv_SdtWWP_AIListData_ListQuery_Filterstofix_N = false;
				gxTv_SdtWWP_AIListData_ListQuery_Filterstofix = value;
				SetDirty("Filterstofix");
			}
		}

		public void gxTv_SdtWWP_AIListData_ListQuery_Filterstofix_SetNull()
		{
			gxTv_SdtWWP_AIListData_ListQuery_Filterstofix_N = true;
			gxTv_SdtWWP_AIListData_ListQuery_Filterstofix = null;
		}

		public bool gxTv_SdtWWP_AIListData_ListQuery_Filterstofix_IsNull()
		{
			return gxTv_SdtWWP_AIListData_ListQuery_Filterstofix == null;
		}
		public bool ShouldSerializegxTpr_Filterstofix_GxSimpleCollection_Json()
		{
			return gxTv_SdtWWP_AIListData_ListQuery_Filterstofix != null && gxTv_SdtWWP_AIListData_ListQuery_Filterstofix.Count > 0;

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
			gxTv_SdtWWP_AIListData_ListQuery_Contextinfo = "";
			gxTv_SdtWWP_AIListData_ListQuery_Link = "";

			gxTv_SdtWWP_AIListData_ListQuery_Filterstofix_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWP_AIListData_ListQuery_Contextinfo;
		 

		protected string gxTv_SdtWWP_AIListData_ListQuery_Link;
		 
		protected bool gxTv_SdtWWP_AIListData_ListQuery_Filterstofix_N;
		protected GXBaseCollection<SdtWWP_AIListData_ListQuery_FiltersToFixItem> gxTv_SdtWWP_AIListData_ListQuery_Filterstofix = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWP_AIListData.ListQuery", Namespace="YTT_version4")]
	public class SdtWWP_AIListData_ListQuery_RESTInterface : GxGenericCollectionItem<SdtWWP_AIListData_ListQuery>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AIListData_ListQuery_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AIListData_ListQuery_RESTInterface( SdtWWP_AIListData_ListQuery psdt ) : base(psdt)
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

		[DataMember(Name="Link", Order=1)]
		public  string gxTpr_Link
		{
			get { 
				return sdt.gxTpr_Link;

			}
			set { 
				 sdt.gxTpr_Link = value;
			}
		}

		[DataMember(Name="FiltersToFix", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWWP_AIListData_ListQuery_FiltersToFixItem_RESTInterface> gxTpr_Filterstofix
		{
			get {
				if (sdt.ShouldSerializegxTpr_Filterstofix_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWWP_AIListData_ListQuery_FiltersToFixItem_RESTInterface>(sdt.gxTpr_Filterstofix);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Filterstofix);
			}
		}


		#endregion

		public SdtWWP_AIListData_ListQuery sdt
		{
			get { 
				return (SdtWWP_AIListData_ListQuery)Sdt;
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
				sdt = new SdtWWP_AIListData_ListQuery() ;
			}
		}
	}
	#endregion
}