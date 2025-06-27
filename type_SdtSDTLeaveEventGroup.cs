/*
				   File: type_SdtSDTLeaveEventGroup
			Description: SDTLeaveEventGroup
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
	[XmlRoot(ElementName="SDTLeaveEventGroup")]
	[XmlType(TypeName="SDTLeaveEventGroup" , Namespace="YTT_version4" )]
	[Serializable]
	public class SdtSDTLeaveEventGroup : GxUserType
	{
		public SdtSDTLeaveEventGroup( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTLeaveEventGroup_Content = "";

		}

		public SdtSDTLeaveEventGroup(IGxContext context)
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
			AddObjectProperty("id", gxTpr_Id, false);


			AddObjectProperty("content", gxTpr_Content, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public short gxTpr_Id
		{
			get {
				return gxTv_SdtSDTLeaveEventGroup_Id; 
			}
			set {
				gxTv_SdtSDTLeaveEventGroup_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="content")]
		[XmlElement(ElementName="content")]
		public string gxTpr_Content
		{
			get {
				return gxTv_SdtSDTLeaveEventGroup_Content; 
			}
			set {
				gxTv_SdtSDTLeaveEventGroup_Content = value;
				SetDirty("Content");
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
			gxTv_SdtSDTLeaveEventGroup_Content = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTLeaveEventGroup_Id;
		 

		protected string gxTv_SdtSDTLeaveEventGroup_Content;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTLeaveEventGroup", Namespace="YTT_version4")]
	public class SdtSDTLeaveEventGroup_RESTInterface : GxGenericCollectionItem<SdtSDTLeaveEventGroup>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTLeaveEventGroup_RESTInterface( ) : base()
		{	
		}

		public SdtSDTLeaveEventGroup_RESTInterface( SdtSDTLeaveEventGroup psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="id", Order=0)]
		public short gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="content", Order=1)]
		public  string gxTpr_Content
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Content);

			}
			set { 
				 sdt.gxTpr_Content = value;
			}
		}


		#endregion

		public SdtSDTLeaveEventGroup sdt
		{
			get { 
				return (SdtSDTLeaveEventGroup)Sdt;
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
				sdt = new SdtSDTLeaveEventGroup() ;
			}
		}
	}
	#endregion
}