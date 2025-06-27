/*
				   File: type_SdtLocationHoliDayUpdateSDT_itemsItem_end
			Description: end
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
	[XmlRoot(ElementName="LocationHoliDayUpdateSDT.itemsItem.end")]
	[XmlType(TypeName="LocationHoliDayUpdateSDT.itemsItem.end" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtLocationHoliDayUpdateSDT_itemsItem_end : GxUserType
	{
		public SdtLocationHoliDayUpdateSDT_itemsItem_end( )
		{
			/* Constructor for serialization */
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_end_Date = "";

		}

		public SdtLocationHoliDayUpdateSDT_itemsItem_end(IGxContext context)
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
			AddObjectProperty("date", gxTpr_Date, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="date")]
		[XmlElement(ElementName="date")]
		public string gxTpr_Date
		{
			get {
				return gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_end_Date; 
			}
			set {
				gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_end_Date = value;
				SetDirty("Date");
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
			gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_end_Date = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtLocationHoliDayUpdateSDT_itemsItem_end_Date;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"LocationHoliDayUpdateSDT.itemsItem.end", Namespace="YTT_version4")]
	public class SdtLocationHoliDayUpdateSDT_itemsItem_end_RESTInterface : GxGenericCollectionItem<SdtLocationHoliDayUpdateSDT_itemsItem_end>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtLocationHoliDayUpdateSDT_itemsItem_end_RESTInterface( ) : base()
		{	
		}

		public SdtLocationHoliDayUpdateSDT_itemsItem_end_RESTInterface( SdtLocationHoliDayUpdateSDT_itemsItem_end psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="date", Order=0)]
		public  string gxTpr_Date
		{
			get { 
				return sdt.gxTpr_Date;

			}
			set { 
				 sdt.gxTpr_Date = value;
			}
		}


		#endregion

		public SdtLocationHoliDayUpdateSDT_itemsItem_end sdt
		{
			get { 
				return (SdtLocationHoliDayUpdateSDT_itemsItem_end)Sdt;
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
				sdt = new SdtLocationHoliDayUpdateSDT_itemsItem_end() ;
			}
		}
	}
	#endregion
}