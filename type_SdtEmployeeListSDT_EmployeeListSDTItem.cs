/*
				   File: type_SdtEmployeeListSDT_EmployeeListSDTItem
			Description: EmployeeListSDT
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
	[XmlRoot(ElementName="EmployeeListSDTItem")]
	[XmlType(TypeName="EmployeeListSDTItem" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtEmployeeListSDT_EmployeeListSDTItem : GxUserType
	{
		public SdtEmployeeListSDT_EmployeeListSDTItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtEmployeeListSDT_EmployeeListSDTItem_Firstname = "";

			gxTv_SdtEmployeeListSDT_EmployeeListSDTItem_Lastname = "";

		}

		public SdtEmployeeListSDT_EmployeeListSDTItem(IGxContext context)
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
			AddObjectProperty("firstName", gxTpr_Firstname, false);


			AddObjectProperty("lastName", gxTpr_Lastname, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="firstName")]
		[XmlElement(ElementName="firstName")]
		public string gxTpr_Firstname
		{
			get {
				return gxTv_SdtEmployeeListSDT_EmployeeListSDTItem_Firstname; 
			}
			set {
				gxTv_SdtEmployeeListSDT_EmployeeListSDTItem_Firstname = value;
				SetDirty("Firstname");
			}
		}




		[SoapElement(ElementName="lastName")]
		[XmlElement(ElementName="lastName")]
		public string gxTpr_Lastname
		{
			get {
				return gxTv_SdtEmployeeListSDT_EmployeeListSDTItem_Lastname; 
			}
			set {
				gxTv_SdtEmployeeListSDT_EmployeeListSDTItem_Lastname = value;
				SetDirty("Lastname");
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
			gxTv_SdtEmployeeListSDT_EmployeeListSDTItem_Firstname = "";
			gxTv_SdtEmployeeListSDT_EmployeeListSDTItem_Lastname = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtEmployeeListSDT_EmployeeListSDTItem_Firstname;
		 

		protected string gxTv_SdtEmployeeListSDT_EmployeeListSDTItem_Lastname;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"EmployeeListSDTItem", Namespace="YTT_version4")]
	public class SdtEmployeeListSDT_EmployeeListSDTItem_RESTInterface : GxGenericCollectionItem<SdtEmployeeListSDT_EmployeeListSDTItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtEmployeeListSDT_EmployeeListSDTItem_RESTInterface( ) : base()
		{	
		}

		public SdtEmployeeListSDT_EmployeeListSDTItem_RESTInterface( SdtEmployeeListSDT_EmployeeListSDTItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="firstName", Order=0)]
		public  string gxTpr_Firstname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Firstname);

			}
			set { 
				 sdt.gxTpr_Firstname = value;
			}
		}

		[DataMember(Name="lastName", Order=1)]
		public  string gxTpr_Lastname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Lastname);

			}
			set { 
				 sdt.gxTpr_Lastname = value;
			}
		}


		#endregion

		public SdtEmployeeListSDT_EmployeeListSDTItem sdt
		{
			get { 
				return (SdtEmployeeListSDT_EmployeeListSDTItem)Sdt;
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
				sdt = new SdtEmployeeListSDT_EmployeeListSDTItem() ;
			}
		}
	}
	#endregion
}