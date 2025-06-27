/*
				   File: type_SdtSDTPage
			Description: SDTPage
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
	[XmlRoot(ElementName="SDTPage")]
	[XmlType(TypeName="SDTPage" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTPage : GxUserType
	{
		public SdtSDTPage( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTPage(IGxContext context)
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
			AddObjectProperty("Page", gxTpr_Page, false);


			AddObjectProperty("IsCurrent", gxTpr_Iscurrent, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Page")]
		[XmlElement(ElementName="Page")]
		public short gxTpr_Page
		{
			get {
				return gxTv_SdtSDTPage_Page; 
			}
			set {
				gxTv_SdtSDTPage_Page = value;
				SetDirty("Page");
			}
		}




		[SoapElement(ElementName="IsCurrent")]
		[XmlElement(ElementName="IsCurrent")]
		public bool gxTpr_Iscurrent
		{
			get {
				return gxTv_SdtSDTPage_Iscurrent; 
			}
			set {
				gxTv_SdtSDTPage_Iscurrent = value;
				SetDirty("Iscurrent");
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
			gxTv_SdtSDTPage_Iscurrent = false;
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTPage_Page;
		 

		protected bool gxTv_SdtSDTPage_Iscurrent;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTPage", Namespace="YTT_version4")]
	public class SdtSDTPage_RESTInterface : GxGenericCollectionItem<SdtSDTPage>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTPage_RESTInterface( ) : base()
		{	
		}

		public SdtSDTPage_RESTInterface( SdtSDTPage psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Page", Order=0)]
		public short gxTpr_Page
		{
			get { 
				return sdt.gxTpr_Page;

			}
			set { 
				sdt.gxTpr_Page = value;
			}
		}

		[DataMember(Name="IsCurrent", Order=1)]
		public bool gxTpr_Iscurrent
		{
			get { 
				return sdt.gxTpr_Iscurrent;

			}
			set { 
				sdt.gxTpr_Iscurrent = value;
			}
		}


		#endregion

		public SdtSDTPage sdt
		{
			get { 
				return (SdtSDTPage)Sdt;
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
				sdt = new SdtSDTPage() ;
			}
		}
	}
	#endregion
}