/*
				   File: type_SdtWWP_AIListData_RedirectToList
			Description: RedirectToList
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
	[XmlRoot(ElementName="WWP_AIListData.RedirectToList")]
	[XmlType(TypeName="WWP_AIListData.RedirectToList" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AIListData_RedirectToList : GxUserType
	{
		public SdtWWP_AIListData_RedirectToList( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_AIListData_RedirectToList_Description = "";

			gxTv_SdtWWP_AIListData_RedirectToList_Listname = "";

		}

		public SdtWWP_AIListData_RedirectToList(IGxContext context)
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
			AddObjectProperty("Description", gxTpr_Description, false);


			AddObjectProperty("ListName", gxTpr_Listname, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtWWP_AIListData_RedirectToList_Description; 
			}
			set {
				gxTv_SdtWWP_AIListData_RedirectToList_Description = value;
				SetDirty("Description");
			}
		}




		[SoapElement(ElementName="ListName")]
		[XmlElement(ElementName="ListName")]
		public string gxTpr_Listname
		{
			get {
				return gxTv_SdtWWP_AIListData_RedirectToList_Listname; 
			}
			set {
				gxTv_SdtWWP_AIListData_RedirectToList_Listname = value;
				SetDirty("Listname");
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
			gxTv_SdtWWP_AIListData_RedirectToList_Description = "";
			gxTv_SdtWWP_AIListData_RedirectToList_Listname = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWP_AIListData_RedirectToList_Description;
		 

		protected string gxTv_SdtWWP_AIListData_RedirectToList_Listname;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWP_AIListData.RedirectToList", Namespace="YTT_version4")]
	public class SdtWWP_AIListData_RedirectToList_RESTInterface : GxGenericCollectionItem<SdtWWP_AIListData_RedirectToList>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AIListData_RedirectToList_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AIListData_RedirectToList_RESTInterface( SdtWWP_AIListData_RedirectToList psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Description", Order=0)]
		public  string gxTpr_Description
		{
			get { 
				return sdt.gxTpr_Description;

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}

		[DataMember(Name="ListName", Order=1)]
		public  string gxTpr_Listname
		{
			get { 
				return sdt.gxTpr_Listname;

			}
			set { 
				 sdt.gxTpr_Listname = value;
			}
		}


		#endregion

		public SdtWWP_AIListData_RedirectToList sdt
		{
			get { 
				return (SdtWWP_AIListData_RedirectToList)Sdt;
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
				sdt = new SdtWWP_AIListData_RedirectToList() ;
			}
		}
	}
	#endregion
}