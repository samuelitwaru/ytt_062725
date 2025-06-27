/*
				   File: type_SdtWWP_AIListData_ListQuery_FiltersToFixItem
			Description: FiltersToFix
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
	[XmlRoot(ElementName="WWP_AIListData.ListQuery.FiltersToFixItem")]
	[XmlType(TypeName="WWP_AIListData.ListQuery.FiltersToFixItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtWWP_AIListData_ListQuery_FiltersToFixItem : GxUserType
	{
		public SdtWWP_AIListData_ListQuery_FiltersToFixItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Name = "";

			gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Type = "";

		}

		public SdtWWP_AIListData_ListQuery_FiltersToFixItem(IGxContext context)
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
			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("Type", gxTpr_Type, false);


			AddObjectProperty("MultipleValues", gxTpr_Multiplevalues, false);


			AddObjectProperty("ValuesHasComma", gxTpr_Valueshascomma, false);


			AddObjectProperty("FixType", gxTpr_Fixtype, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Name; 
			}
			set {
				gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Type")]
		[XmlElement(ElementName="Type")]
		public string gxTpr_Type
		{
			get {
				return gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Type; 
			}
			set {
				gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Type = value;
				SetDirty("Type");
			}
		}




		[SoapElement(ElementName="MultipleValues")]
		[XmlElement(ElementName="MultipleValues")]
		public bool gxTpr_Multiplevalues
		{
			get {
				return gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Multiplevalues; 
			}
			set {
				gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Multiplevalues = value;
				SetDirty("Multiplevalues");
			}
		}




		[SoapElement(ElementName="ValuesHasComma")]
		[XmlElement(ElementName="ValuesHasComma")]
		public bool gxTpr_Valueshascomma
		{
			get {
				return gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Valueshascomma; 
			}
			set {
				gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Valueshascomma = value;
				SetDirty("Valueshascomma");
			}
		}




		[SoapElement(ElementName="FixType")]
		[XmlElement(ElementName="FixType")]
		public short gxTpr_Fixtype
		{
			get {
				return gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Fixtype; 
			}
			set {
				gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Fixtype = value;
				SetDirty("Fixtype");
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
			gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Name = "";
			gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Type = "";



			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Name;
		 

		protected string gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Type;
		 

		protected bool gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Multiplevalues;
		 

		protected bool gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Valueshascomma;
		 

		protected short gxTv_SdtWWP_AIListData_ListQuery_FiltersToFixItem_Fixtype;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"WWP_AIListData.ListQuery.FiltersToFixItem", Namespace="YTT_version4")]
	public class SdtWWP_AIListData_ListQuery_FiltersToFixItem_RESTInterface : GxGenericCollectionItem<SdtWWP_AIListData_ListQuery_FiltersToFixItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWP_AIListData_ListQuery_FiltersToFixItem_RESTInterface( ) : base()
		{	
		}

		public SdtWWP_AIListData_ListQuery_FiltersToFixItem_RESTInterface( SdtWWP_AIListData_ListQuery_FiltersToFixItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Type", Order=1)]
		public  string gxTpr_Type
		{
			get { 
				return sdt.gxTpr_Type;

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="MultipleValues", Order=2)]
		public bool gxTpr_Multiplevalues
		{
			get { 
				return sdt.gxTpr_Multiplevalues;

			}
			set { 
				sdt.gxTpr_Multiplevalues = value;
			}
		}

		[DataMember(Name="ValuesHasComma", Order=3)]
		public bool gxTpr_Valueshascomma
		{
			get { 
				return sdt.gxTpr_Valueshascomma;

			}
			set { 
				sdt.gxTpr_Valueshascomma = value;
			}
		}

		[DataMember(Name="FixType", Order=4)]
		public short gxTpr_Fixtype
		{
			get { 
				return sdt.gxTpr_Fixtype;

			}
			set { 
				sdt.gxTpr_Fixtype = value;
			}
		}


		#endregion

		public SdtWWP_AIListData_ListQuery_FiltersToFixItem sdt
		{
			get { 
				return (SdtWWP_AIListData_ListQuery_FiltersToFixItem)Sdt;
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
				sdt = new SdtWWP_AIListData_ListQuery_FiltersToFixItem() ;
			}
		}
	}
	#endregion
}