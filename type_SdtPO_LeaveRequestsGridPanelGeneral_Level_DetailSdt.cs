using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt" )]
   [XmlType(TypeName =  "PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt : GxUserType
   {
      public SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leavetypename = "";
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdate = DateTime.MinValue;
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststartdate = DateTime.MinValue;
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestenddate = DateTime.MinValue;
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequesthalfday = "";
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststatus = "";
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdescription = "";
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestrejectionreason = "";
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Employeename = "";
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leavetypevacationleave = "";
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Gxdynprop = "";
      }

      public SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt( IGxContext context )
      {
         this.context = context;
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("LeaveRequestId", gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestid, false, false);
         AddObjectProperty("LeaveTypeId", gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leavetypeid, false, false);
         AddObjectProperty("LeaveTypeName", gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leavetypename, false, false);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("LeaveRequestDate", sDateCnv, false, false);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststartdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("LeaveRequestStartDate", sDateCnv, false, false);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestenddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestenddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestenddate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("LeaveRequestEndDate", sDateCnv, false, false);
         AddObjectProperty("LeaveRequestHalfDay", gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequesthalfday, false, false);
         AddObjectProperty("LeaveRequestDuration", gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestduration, false, false);
         AddObjectProperty("LeaveRequestStatus", gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststatus, false, false);
         AddObjectProperty("LeaveRequestDescription", gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdescription, false, false);
         AddObjectProperty("LeaveRequestRejectionReason", gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestrejectionreason, false, false);
         AddObjectProperty("EmployeeId", gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Employeeid, false, false);
         AddObjectProperty("EmployeeName", gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Employeename, false, false);
         AddObjectProperty("EmployeeBalance", gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Employeebalance, false, false);
         AddObjectProperty("LeaveTypeVacationLeave", gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leavetypevacationleave, false, false);
         AddObjectProperty("Isauthorized_update", gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Isauthorized_update, false, false);
         AddObjectProperty("Isauthorized_delete", gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Isauthorized_delete, false, false);
         AddObjectProperty("Gxdynprop", gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Gxdynprop, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "LeaveRequestId" )]
      [  XmlElement( ElementName = "LeaveRequestId"   )]
      public long gxTpr_Leaverequestid
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestid = value;
            SetDirty("Leaverequestid");
         }

      }

      [  SoapElement( ElementName = "LeaveTypeId" )]
      [  XmlElement( ElementName = "LeaveTypeId"   )]
      public long gxTpr_Leavetypeid
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leavetypeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leavetypeid = value;
            SetDirty("Leavetypeid");
         }

      }

      [  SoapElement( ElementName = "LeaveTypeName" )]
      [  XmlElement( ElementName = "LeaveTypeName"   )]
      public string gxTpr_Leavetypename
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leavetypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leavetypename = value;
            SetDirty("Leavetypename");
         }

      }

      [  SoapElement( ElementName = "LeaveRequestDate" )]
      [  XmlElement( ElementName = "LeaveRequestDate"  , IsNullable=true )]
      public string gxTpr_Leaverequestdate_Nullable
      {
         get {
            if ( gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdate = DateTime.MinValue;
            else
               gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaverequestdate
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdate = value;
            SetDirty("Leaverequestdate");
         }

      }

      [  SoapElement( ElementName = "LeaveRequestStartDate" )]
      [  XmlElement( ElementName = "LeaveRequestStartDate"  , IsNullable=true )]
      public string gxTpr_Leaverequeststartdate_Nullable
      {
         get {
            if ( gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststartdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststartdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststartdate = DateTime.MinValue;
            else
               gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststartdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaverequeststartdate
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststartdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststartdate = value;
            SetDirty("Leaverequeststartdate");
         }

      }

      [  SoapElement( ElementName = "LeaveRequestEndDate" )]
      [  XmlElement( ElementName = "LeaveRequestEndDate"  , IsNullable=true )]
      public string gxTpr_Leaverequestenddate_Nullable
      {
         get {
            if ( gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestenddate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestenddate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestenddate = DateTime.MinValue;
            else
               gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestenddate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Leaverequestenddate
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestenddate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestenddate = value;
            SetDirty("Leaverequestenddate");
         }

      }

      [  SoapElement( ElementName = "LeaveRequestHalfDay" )]
      [  XmlElement( ElementName = "LeaveRequestHalfDay"   )]
      public string gxTpr_Leaverequesthalfday
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequesthalfday ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequesthalfday = value;
            SetDirty("Leaverequesthalfday");
         }

      }

      [  SoapElement( ElementName = "LeaveRequestDuration" )]
      [  XmlElement( ElementName = "LeaveRequestDuration"   )]
      public decimal gxTpr_Leaverequestduration
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestduration ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestduration = value;
            SetDirty("Leaverequestduration");
         }

      }

      [  SoapElement( ElementName = "LeaveRequestStatus" )]
      [  XmlElement( ElementName = "LeaveRequestStatus"   )]
      public string gxTpr_Leaverequeststatus
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststatus ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststatus = value;
            SetDirty("Leaverequeststatus");
         }

      }

      [  SoapElement( ElementName = "LeaveRequestDescription" )]
      [  XmlElement( ElementName = "LeaveRequestDescription"   )]
      public string gxTpr_Leaverequestdescription
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdescription = value;
            SetDirty("Leaverequestdescription");
         }

      }

      [  SoapElement( ElementName = "LeaveRequestRejectionReason" )]
      [  XmlElement( ElementName = "LeaveRequestRejectionReason"   )]
      public string gxTpr_Leaverequestrejectionreason
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestrejectionreason ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestrejectionreason = value;
            SetDirty("Leaverequestrejectionreason");
         }

      }

      [  SoapElement( ElementName = "EmployeeId" )]
      [  XmlElement( ElementName = "EmployeeId"   )]
      public long gxTpr_Employeeid
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Employeeid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Employeeid = value;
            SetDirty("Employeeid");
         }

      }

      [  SoapElement( ElementName = "EmployeeName" )]
      [  XmlElement( ElementName = "EmployeeName"   )]
      public string gxTpr_Employeename
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Employeename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Employeename = value;
            SetDirty("Employeename");
         }

      }

      [  SoapElement( ElementName = "EmployeeBalance" )]
      [  XmlElement( ElementName = "EmployeeBalance"   )]
      public decimal gxTpr_Employeebalance
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Employeebalance ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Employeebalance = value;
            SetDirty("Employeebalance");
         }

      }

      [  SoapElement( ElementName = "LeaveTypeVacationLeave" )]
      [  XmlElement( ElementName = "LeaveTypeVacationLeave"   )]
      public string gxTpr_Leavetypevacationleave
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leavetypevacationleave ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leavetypevacationleave = value;
            SetDirty("Leavetypevacationleave");
         }

      }

      [  SoapElement( ElementName = "Isauthorized_update" )]
      [  XmlElement( ElementName = "Isauthorized_update"   )]
      public bool gxTpr_Isauthorized_update
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Isauthorized_update ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Isauthorized_update = value;
            SetDirty("Isauthorized_update");
         }

      }

      [  SoapElement( ElementName = "Isauthorized_delete" )]
      [  XmlElement( ElementName = "Isauthorized_delete"   )]
      public bool gxTpr_Isauthorized_delete
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Isauthorized_delete ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Isauthorized_delete = value;
            SetDirty("Isauthorized_delete");
         }

      }

      [  SoapElement( ElementName = "Gxdynprop" )]
      [  XmlElement( ElementName = "Gxdynprop"   )]
      public string gxTpr_Gxdynprop
      {
         get {
            return gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Gxdynprop ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Gxdynprop = value;
            SetDirty("Gxdynprop");
         }

      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leavetypename = "";
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdate = DateTime.MinValue;
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststartdate = DateTime.MinValue;
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestenddate = DateTime.MinValue;
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequesthalfday = "";
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststatus = "";
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdescription = "";
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestrejectionreason = "";
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Employeename = "";
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leavetypevacationleave = "";
         gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Gxdynprop = "";
         sdtIsNull = 1;
         sDateCnv = "";
         sNumToPad = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected long gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestid ;
      protected long gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leavetypeid ;
      protected long gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Employeeid ;
      protected decimal gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestduration ;
      protected decimal gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Employeebalance ;
      protected string gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leavetypename ;
      protected string gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequesthalfday ;
      protected string gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststatus ;
      protected string gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Employeename ;
      protected string gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leavetypevacationleave ;
      protected string gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Gxdynprop ;
      protected string sDateCnv ;
      protected string sNumToPad ;
      protected DateTime gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdate ;
      protected DateTime gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequeststartdate ;
      protected DateTime gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestenddate ;
      protected bool gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Isauthorized_update ;
      protected bool gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Isauthorized_delete ;
      protected string gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestdescription ;
      protected string gxTv_SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_Leaverequestrejectionreason ;
   }

   [DataContract(Name = @"PO_LeaveRequestsGridPanelGeneral_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt>
   {
      public SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt_RESTInterface( SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LeaveRequestId" , Order = 0 )]
      public string gxTpr_Leaverequestid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Leaverequestid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Leaverequestid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "LeaveTypeId" , Order = 1 )]
      public string gxTpr_Leavetypeid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Leavetypeid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "LeaveTypeName" , Order = 2 )]
      public string gxTpr_Leavetypename
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Leavetypename) ;
         }

         set {
            sdt.gxTpr_Leavetypename = value;
         }

      }

      [DataMember( Name = "LeaveRequestDate" , Order = 3 )]
      public string gxTpr_Leaverequestdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Leaverequestdate) ;
         }

         set {
            sdt.gxTpr_Leaverequestdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "LeaveRequestStartDate" , Order = 4 )]
      public string gxTpr_Leaverequeststartdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Leaverequeststartdate) ;
         }

         set {
            sdt.gxTpr_Leaverequeststartdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "LeaveRequestEndDate" , Order = 5 )]
      public string gxTpr_Leaverequestenddate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Leaverequestenddate) ;
         }

         set {
            sdt.gxTpr_Leaverequestenddate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "LeaveRequestHalfDay" , Order = 6 )]
      public string gxTpr_Leaverequesthalfday
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Leaverequesthalfday) ;
         }

         set {
            sdt.gxTpr_Leaverequesthalfday = value;
         }

      }

      [DataMember( Name = "LeaveRequestDuration" , Order = 7 )]
      public Nullable<decimal> gxTpr_Leaverequestduration
      {
         get {
            return sdt.gxTpr_Leaverequestduration ;
         }

         set {
            sdt.gxTpr_Leaverequestduration = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "LeaveRequestStatus" , Order = 8 )]
      public string gxTpr_Leaverequeststatus
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Leaverequeststatus) ;
         }

         set {
            sdt.gxTpr_Leaverequeststatus = value;
         }

      }

      [DataMember( Name = "LeaveRequestDescription" , Order = 9 )]
      public string gxTpr_Leaverequestdescription
      {
         get {
            return sdt.gxTpr_Leaverequestdescription ;
         }

         set {
            sdt.gxTpr_Leaverequestdescription = value;
         }

      }

      [DataMember( Name = "LeaveRequestRejectionReason" , Order = 10 )]
      public string gxTpr_Leaverequestrejectionreason
      {
         get {
            return sdt.gxTpr_Leaverequestrejectionreason ;
         }

         set {
            sdt.gxTpr_Leaverequestrejectionreason = value;
         }

      }

      [DataMember( Name = "EmployeeId" , Order = 11 )]
      public string gxTpr_Employeeid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Employeeid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Employeeid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "EmployeeName" , Order = 12 )]
      public string gxTpr_Employeename
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Employeename) ;
         }

         set {
            sdt.gxTpr_Employeename = value;
         }

      }

      [DataMember( Name = "EmployeeBalance" , Order = 13 )]
      public Nullable<decimal> gxTpr_Employeebalance
      {
         get {
            return sdt.gxTpr_Employeebalance ;
         }

         set {
            sdt.gxTpr_Employeebalance = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "LeaveTypeVacationLeave" , Order = 14 )]
      public string gxTpr_Leavetypevacationleave
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Leavetypevacationleave) ;
         }

         set {
            sdt.gxTpr_Leavetypevacationleave = value;
         }

      }

      [DataMember( Name = "Isauthorized_update" , Order = 15 )]
      public bool gxTpr_Isauthorized_update
      {
         get {
            return sdt.gxTpr_Isauthorized_update ;
         }

         set {
            sdt.gxTpr_Isauthorized_update = value;
         }

      }

      [DataMember( Name = "Isauthorized_delete" , Order = 16 )]
      public bool gxTpr_Isauthorized_delete
      {
         get {
            return sdt.gxTpr_Isauthorized_delete ;
         }

         set {
            sdt.gxTpr_Isauthorized_delete = value;
         }

      }

      [DataMember( Name = "Gxdynprop" , Order = 17 )]
      public string gxTpr_Gxdynprop
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gxdynprop) ;
         }

         set {
            sdt.gxTpr_Gxdynprop = value;
         }

      }

      public SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt sdt
      {
         get {
            return (SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtPO_LeaveRequestsGridPanelGeneral_Level_DetailSdt() ;
         }
      }

   }

}
