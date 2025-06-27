/*
				   File: type_SdtRoleSDT
			Description: RoleSDT
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
	[XmlRoot(ElementName="RoleSDT")]
	[XmlType(TypeName="RoleSDT" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtRoleSDT : GxUserType
	{
		public SdtRoleSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtRoleSDT_Name = "";

			gxTv_SdtRoleSDT_Description = "";

			gxTv_SdtRoleSDT_Externalid = "";

		}

		public SdtRoleSDT(IGxContext context)
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


			AddObjectProperty("Description", gxTpr_Description, false);


			AddObjectProperty("ExternalId", gxTpr_Externalid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtRoleSDT_Name; 
			}
			set {
				gxTv_SdtRoleSDT_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public string gxTpr_Description
		{
			get {
				return gxTv_SdtRoleSDT_Description; 
			}
			set {
				gxTv_SdtRoleSDT_Description = value;
				SetDirty("Description");
			}
		}




		[SoapElement(ElementName="ExternalId")]
		[XmlElement(ElementName="ExternalId")]
		public string gxTpr_Externalid
		{
			get {
				return gxTv_SdtRoleSDT_Externalid; 
			}
			set {
				gxTv_SdtRoleSDT_Externalid = value;
				SetDirty("Externalid");
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
			gxTv_SdtRoleSDT_Name = "";
			gxTv_SdtRoleSDT_Description = "";
			gxTv_SdtRoleSDT_Externalid = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtRoleSDT_Name;
		 

		protected string gxTv_SdtRoleSDT_Description;
		 

		protected string gxTv_SdtRoleSDT_Externalid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"RoleSDT", Namespace="YTT_version4")]
	public class SdtRoleSDT_RESTInterface : GxGenericCollectionItem<SdtRoleSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtRoleSDT_RESTInterface( ) : base()
		{	
		}

		public SdtRoleSDT_RESTInterface( SdtRoleSDT psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
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

		[DataMember(Name="ExternalId", Order=2)]
		public  string gxTpr_Externalid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Externalid);

			}
			set { 
				 sdt.gxTpr_Externalid = value;
			}
		}


		#endregion

		public SdtRoleSDT sdt
		{
			get { 
				return (SdtRoleSDT)Sdt;
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
				sdt = new SdtRoleSDT() ;
			}
		}
	}
	#endregion
}