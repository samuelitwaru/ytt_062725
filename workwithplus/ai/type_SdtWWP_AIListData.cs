/*
				   File: type_SdtWWP_AIListData
			Description: WWP_AIListData
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
	[XmlRoot(ElementName="WWP_AIListData")]
	[XmlType(TypeName="WWP_AIListData" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AIListData : GxUserType
	{
		public SdtWWP_AIListData( )
		{
			/* Constructor for serialization */
		}

		public SdtWWP_AIListData(IGxContext context)
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
			if (gxTv_SdtWWP_AIListData_Listquery != null)
			{
				AddObjectProperty("ListQuery", gxTv_SdtWWP_AIListData_Listquery, false);
			}
			if (gxTv_SdtWWP_AIListData_Redirecttolist != null)
			{
				AddObjectProperty("RedirectToList", gxTv_SdtWWP_AIListData_Redirecttolist, false);
			}
			if (gxTv_SdtWWP_AIListData_Examples != null)
			{
				AddObjectProperty("Examples", gxTv_SdtWWP_AIListData_Examples, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ListQuery" )]
		[XmlElement(ElementName="ListQuery" )]
		public SdtWWP_AIListData_ListQuery gxTpr_Listquery
		{
			get {
				if ( gxTv_SdtWWP_AIListData_Listquery == null )
				{
					gxTv_SdtWWP_AIListData_Listquery = new SdtWWP_AIListData_ListQuery(context);
				}
				gxTv_SdtWWP_AIListData_Listquery_N = false;
				return gxTv_SdtWWP_AIListData_Listquery;
			}
			set {
				gxTv_SdtWWP_AIListData_Listquery_N = false;
				gxTv_SdtWWP_AIListData_Listquery = value;
				SetDirty("Listquery");
			}

		}

		public void gxTv_SdtWWP_AIListData_Listquery_SetNull()
		{
			gxTv_SdtWWP_AIListData_Listquery_N = true;
			gxTv_SdtWWP_AIListData_Listquery = null;
		}

		public bool gxTv_SdtWWP_AIListData_Listquery_IsNull()
		{
			return gxTv_SdtWWP_AIListData_Listquery == null;
		}
		public bool ShouldSerializegxTpr_Listquery_Json()
		{
				return (gxTv_SdtWWP_AIListData_Listquery != null && gxTv_SdtWWP_AIListData_Listquery.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="RedirectToList" )]
		[XmlElement(ElementName="RedirectToList" )]
		public SdtWWP_AIListData_RedirectToList gxTpr_Redirecttolist
		{
			get {
				if ( gxTv_SdtWWP_AIListData_Redirecttolist == null )
				{
					gxTv_SdtWWP_AIListData_Redirecttolist = new SdtWWP_AIListData_RedirectToList(context);
				}
				gxTv_SdtWWP_AIListData_Redirecttolist_N = false;
				return gxTv_SdtWWP_AIListData_Redirecttolist;
			}
			set {
				gxTv_SdtWWP_AIListData_Redirecttolist_N = false;
				gxTv_SdtWWP_AIListData_Redirecttolist = value;
				SetDirty("Redirecttolist");
			}

		}

		public void gxTv_SdtWWP_AIListData_Redirecttolist_SetNull()
		{
			gxTv_SdtWWP_AIListData_Redirecttolist_N = true;
			gxTv_SdtWWP_AIListData_Redirecttolist = null;
		}

		public bool gxTv_SdtWWP_AIListData_Redirecttolist_IsNull()
		{
			return gxTv_SdtWWP_AIListData_Redirecttolist == null;
		}
		public bool ShouldSerializegxTpr_Redirecttolist_Json()
		{
				return (gxTv_SdtWWP_AIListData_Redirecttolist != null && gxTv_SdtWWP_AIListData_Redirecttolist.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="Examples" )]
		[XmlElement(ElementName="Examples" )]
		public SdtWWP_AIListData_Examples gxTpr_Examples
		{
			get {
				if ( gxTv_SdtWWP_AIListData_Examples == null )
				{
					gxTv_SdtWWP_AIListData_Examples = new SdtWWP_AIListData_Examples(context);
				}
				gxTv_SdtWWP_AIListData_Examples_N = false;
				return gxTv_SdtWWP_AIListData_Examples;
			}
			set {
				gxTv_SdtWWP_AIListData_Examples_N = false;
				gxTv_SdtWWP_AIListData_Examples = value;
				SetDirty("Examples");
			}

		}

		public void gxTv_SdtWWP_AIListData_Examples_SetNull()
		{
			gxTv_SdtWWP_AIListData_Examples_N = true;
			gxTv_SdtWWP_AIListData_Examples = null;
		}

		public bool gxTv_SdtWWP_AIListData_Examples_IsNull()
		{
			return gxTv_SdtWWP_AIListData_Examples == null;
		}
		public bool ShouldSerializegxTpr_Examples_Json()
		{
				return (gxTv_SdtWWP_AIListData_Examples != null && gxTv_SdtWWP_AIListData_Examples.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Listquery_Json() ||
				ShouldSerializegxTpr_Redirecttolist_Json() ||
				ShouldSerializegxTpr_Examples_Json() || 
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
			gxTv_SdtWWP_AIListData_Listquery_N = true;


			gxTv_SdtWWP_AIListData_Redirecttolist_N = true;


			gxTv_SdtWWP_AIListData_Examples_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWWP_AIListData_Listquery_N;
		protected SdtWWP_AIListData_ListQuery gxTv_SdtWWP_AIListData_Listquery = null; 

		protected bool gxTv_SdtWWP_AIListData_Redirecttolist_N;
		protected SdtWWP_AIListData_RedirectToList gxTv_SdtWWP_AIListData_Redirecttolist = null; 

		protected bool gxTv_SdtWWP_AIListData_Examples_N;
		protected SdtWWP_AIListData_Examples gxTv_SdtWWP_AIListData_Examples = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWP_AIListData", Namespace="YTT_version4")]
	public class SdtWWP_AIListData_RESTInterface : GxGenericCollectionItem<SdtWWP_AIListData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AIListData_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AIListData_RESTInterface( SdtWWP_AIListData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ListQuery", Order=0, EmitDefaultValue=false)]
		public SdtWWP_AIListData_ListQuery_RESTInterface gxTpr_Listquery
		{
			get {
				if (sdt.ShouldSerializegxTpr_Listquery_Json())
					return new SdtWWP_AIListData_ListQuery_RESTInterface(sdt.gxTpr_Listquery);
				else
					return null;

			}

			set {
				sdt.gxTpr_Listquery = value.sdt;
			}

		}

		[DataMember(Name="RedirectToList", Order=1, EmitDefaultValue=false)]
		public SdtWWP_AIListData_RedirectToList_RESTInterface gxTpr_Redirecttolist
		{
			get {
				if (sdt.ShouldSerializegxTpr_Redirecttolist_Json())
					return new SdtWWP_AIListData_RedirectToList_RESTInterface(sdt.gxTpr_Redirecttolist);
				else
					return null;

			}

			set {
				sdt.gxTpr_Redirecttolist = value.sdt;
			}

		}

		[DataMember(Name="Examples", Order=2, EmitDefaultValue=false)]
		public SdtWWP_AIListData_Examples_RESTInterface gxTpr_Examples
		{
			get {
				if (sdt.ShouldSerializegxTpr_Examples_Json())
					return new SdtWWP_AIListData_Examples_RESTInterface(sdt.gxTpr_Examples);
				else
					return null;

			}

			set {
				sdt.gxTpr_Examples = value.sdt;
			}

		}


		#endregion

		public SdtWWP_AIListData sdt
		{
			get { 
				return (SdtWWP_AIListData)Sdt;
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
				sdt = new SdtWWP_AIListData() ;
			}
		}
	}
	#endregion
}