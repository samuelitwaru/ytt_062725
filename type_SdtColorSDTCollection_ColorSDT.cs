/*
				   File: type_SdtColorSDTCollection_ColorSDT
			Description: ColorSDTCollection
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
	[XmlRoot(ElementName="ColorSDT")]
	[XmlType(TypeName="ColorSDT" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtColorSDTCollection_ColorSDT : GxUserType
	{
		public SdtColorSDTCollection_ColorSDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtColorSDTCollection_ColorSDT_Color = "";

		}

		public SdtColorSDTCollection_ColorSDT(IGxContext context)
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
			AddObjectProperty("Color", gxTpr_Color, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Color")]
		[XmlElement(ElementName="Color")]
		public string gxTpr_Color
		{
			get {
				return gxTv_SdtColorSDTCollection_ColorSDT_Color; 
			}
			set {
				gxTv_SdtColorSDTCollection_ColorSDT_Color = value;
				SetDirty("Color");
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
			gxTv_SdtColorSDTCollection_ColorSDT_Color = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtColorSDTCollection_ColorSDT_Color;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"ColorSDT", Namespace="YTT_version4")]
	public class SdtColorSDTCollection_ColorSDT_RESTInterface : GxGenericCollectionItem<SdtColorSDTCollection_ColorSDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtColorSDTCollection_ColorSDT_RESTInterface( ) : base()
		{	
		}

		public SdtColorSDTCollection_ColorSDT_RESTInterface( SdtColorSDTCollection_ColorSDT psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Color", Order=0)]
		public  string gxTpr_Color
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Color);

			}
			set { 
				 sdt.gxTpr_Color = value;
			}
		}


		#endregion

		public SdtColorSDTCollection_ColorSDT sdt
		{
			get { 
				return (SdtColorSDTCollection_ColorSDT)Sdt;
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
				sdt = new SdtColorSDTCollection_ColorSDT() ;
			}
		}
	}
	#endregion
}