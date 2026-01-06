/*
				   File: type_SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem
			Description: SDT_HoursFilledStatusCollection
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


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="SDT_HoursFilledStatusCollectionItem")]
	[XmlType(TypeName="SDT_HoursFilledStatusCollectionItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem : GxUserType
	{
		public SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem_Description = "";

		}

		public SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem(IGxContext context)
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
			AddObjectProperty("Value", gxTpr_Value, false);


			AddObjectProperty("Description", gxTpr_Description, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public short gxTpr_Value
		{
			get {
				return gxTv_SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem_Value; 
			}
			set {
				gxTv_SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem_Value = value;
				SetDirty("Value");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem_Description; 
			}
			set {
				gxTv_SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem_Description = value;
				SetDirty("Description");
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
			gxTv_SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem_Description = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem_Value;
		 

		protected string gxTv_SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem_Description;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_HoursFilledStatusCollectionItem", Namespace="YTT_version4")]
	public class SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem_RESTInterface : GxGenericCollectionItem<SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem_RESTInterface( SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Value", Order=0)]
		public short gxTpr_Value
		{
			get { 
				return sdt.gxTpr_Value;

			}
			set { 
				sdt.gxTpr_Value = value;
			}
		}

		[DataMember(Name="Description", Order=1)]
		public  string gxTpr_Description
		{
			get { 
				return sdt.gxTpr_Description;

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}


		#endregion

		public SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem sdt
		{
			get { 
				return (SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem)Sdt;
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
				sdt = new SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem() ;
			}
		}
	}
	#endregion
}