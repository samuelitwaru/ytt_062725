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
   [XmlRoot(ElementName = "Employee" )]
   [XmlType(TypeName =  "Employee" , Namespace = "YTT_version4" )]
   [Serializable]
   public class SdtEmployee : GxSilentTrnSdt
   {
      public SdtEmployee( )
      {
      }

      public SdtEmployee( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
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

      public void Load( long AV106EmployeeId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV106EmployeeId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EmployeeId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Employee");
         metadata.Set("BT", "Employee");
         metadata.Set("PK", "[ \"EmployeeId\" ]");
         metadata.Set("PKAssigned", "[ \"EmployeeId\" ]");
         metadata.Set("Levels", "[ \"Project\",\"VacationSet\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CompanyId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Employeeid_Z");
         state.Add("gxTpr_Employeefirstname_Z");
         state.Add("gxTpr_Employeelastname_Z");
         state.Add("gxTpr_Employeename_Z");
         state.Add("gxTpr_Employeeemail_Z");
         state.Add("gxTpr_Companyid_Z");
         state.Add("gxTpr_Companyname_Z");
         state.Add("gxTpr_Employeeismanager_Z");
         state.Add("gxTpr_Gamuserguid_Z");
         state.Add("gxTpr_Employeeisactive_Z");
         state.Add("gxTpr_Employeevactiondays_Z");
         state.Add("gxTpr_Employeevacationdayssetdate_Z_Nullable");
         state.Add("gxTpr_Employeeapipassword_Z");
         state.Add("gxTpr_Employeeftehours_Z");
         state.Add("gxTpr_Employeebalance_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEmployee sdt;
         sdt = (SdtEmployee)(source);
         gxTv_SdtEmployee_Employeeid = sdt.gxTv_SdtEmployee_Employeeid ;
         gxTv_SdtEmployee_Employeefirstname = sdt.gxTv_SdtEmployee_Employeefirstname ;
         gxTv_SdtEmployee_Employeelastname = sdt.gxTv_SdtEmployee_Employeelastname ;
         gxTv_SdtEmployee_Employeename = sdt.gxTv_SdtEmployee_Employeename ;
         gxTv_SdtEmployee_Employeeemail = sdt.gxTv_SdtEmployee_Employeeemail ;
         gxTv_SdtEmployee_Companyid = sdt.gxTv_SdtEmployee_Companyid ;
         gxTv_SdtEmployee_Companyname = sdt.gxTv_SdtEmployee_Companyname ;
         gxTv_SdtEmployee_Employeeismanager = sdt.gxTv_SdtEmployee_Employeeismanager ;
         gxTv_SdtEmployee_Gamuserguid = sdt.gxTv_SdtEmployee_Gamuserguid ;
         gxTv_SdtEmployee_Employeeisactive = sdt.gxTv_SdtEmployee_Employeeisactive ;
         gxTv_SdtEmployee_Employeevactiondays = sdt.gxTv_SdtEmployee_Employeevactiondays ;
         gxTv_SdtEmployee_Employeevacationdayssetdate = sdt.gxTv_SdtEmployee_Employeevacationdayssetdate ;
         gxTv_SdtEmployee_Employeeapipassword = sdt.gxTv_SdtEmployee_Employeeapipassword ;
         gxTv_SdtEmployee_Employeeftehours = sdt.gxTv_SdtEmployee_Employeeftehours ;
         gxTv_SdtEmployee_Employeebalance = sdt.gxTv_SdtEmployee_Employeebalance ;
         gxTv_SdtEmployee_Vacationset = sdt.gxTv_SdtEmployee_Vacationset ;
         gxTv_SdtEmployee_Project = sdt.gxTv_SdtEmployee_Project ;
         gxTv_SdtEmployee_Mode = sdt.gxTv_SdtEmployee_Mode ;
         gxTv_SdtEmployee_Initialized = sdt.gxTv_SdtEmployee_Initialized ;
         gxTv_SdtEmployee_Employeeid_Z = sdt.gxTv_SdtEmployee_Employeeid_Z ;
         gxTv_SdtEmployee_Employeefirstname_Z = sdt.gxTv_SdtEmployee_Employeefirstname_Z ;
         gxTv_SdtEmployee_Employeelastname_Z = sdt.gxTv_SdtEmployee_Employeelastname_Z ;
         gxTv_SdtEmployee_Employeename_Z = sdt.gxTv_SdtEmployee_Employeename_Z ;
         gxTv_SdtEmployee_Employeeemail_Z = sdt.gxTv_SdtEmployee_Employeeemail_Z ;
         gxTv_SdtEmployee_Companyid_Z = sdt.gxTv_SdtEmployee_Companyid_Z ;
         gxTv_SdtEmployee_Companyname_Z = sdt.gxTv_SdtEmployee_Companyname_Z ;
         gxTv_SdtEmployee_Employeeismanager_Z = sdt.gxTv_SdtEmployee_Employeeismanager_Z ;
         gxTv_SdtEmployee_Gamuserguid_Z = sdt.gxTv_SdtEmployee_Gamuserguid_Z ;
         gxTv_SdtEmployee_Employeeisactive_Z = sdt.gxTv_SdtEmployee_Employeeisactive_Z ;
         gxTv_SdtEmployee_Employeevactiondays_Z = sdt.gxTv_SdtEmployee_Employeevactiondays_Z ;
         gxTv_SdtEmployee_Employeevacationdayssetdate_Z = sdt.gxTv_SdtEmployee_Employeevacationdayssetdate_Z ;
         gxTv_SdtEmployee_Employeeapipassword_Z = sdt.gxTv_SdtEmployee_Employeeapipassword_Z ;
         gxTv_SdtEmployee_Employeeftehours_Z = sdt.gxTv_SdtEmployee_Employeeftehours_Z ;
         gxTv_SdtEmployee_Employeebalance_Z = sdt.gxTv_SdtEmployee_Employeebalance_Z ;
         return  ;
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
         AddObjectProperty("EmployeeId", gxTv_SdtEmployee_Employeeid, false, includeNonInitialized);
         AddObjectProperty("EmployeeFirstName", gxTv_SdtEmployee_Employeefirstname, false, includeNonInitialized);
         AddObjectProperty("EmployeeLastName", gxTv_SdtEmployee_Employeelastname, false, includeNonInitialized);
         AddObjectProperty("EmployeeName", gxTv_SdtEmployee_Employeename, false, includeNonInitialized);
         AddObjectProperty("EmployeeEmail", gxTv_SdtEmployee_Employeeemail, false, includeNonInitialized);
         AddObjectProperty("CompanyId", gxTv_SdtEmployee_Companyid, false, includeNonInitialized);
         AddObjectProperty("CompanyName", gxTv_SdtEmployee_Companyname, false, includeNonInitialized);
         AddObjectProperty("EmployeeIsManager", gxTv_SdtEmployee_Employeeismanager, false, includeNonInitialized);
         AddObjectProperty("GAMUserGUID", gxTv_SdtEmployee_Gamuserguid, false, includeNonInitialized);
         AddObjectProperty("EmployeeIsActive", gxTv_SdtEmployee_Employeeisactive, false, includeNonInitialized);
         AddObjectProperty("EmployeeVactionDays", gxTv_SdtEmployee_Employeevactiondays, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEmployee_Employeevacationdayssetdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEmployee_Employeevacationdayssetdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEmployee_Employeevacationdayssetdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("EmployeeVacationDaysSetDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("EmployeeAPIPassword", gxTv_SdtEmployee_Employeeapipassword, false, includeNonInitialized);
         AddObjectProperty("EmployeeFTEHours", gxTv_SdtEmployee_Employeeftehours, false, includeNonInitialized);
         AddObjectProperty("EmployeeBalance", gxTv_SdtEmployee_Employeebalance, false, includeNonInitialized);
         if ( gxTv_SdtEmployee_Vacationset != null )
         {
            AddObjectProperty("VacationSet", gxTv_SdtEmployee_Vacationset, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtEmployee_Project != null )
         {
            AddObjectProperty("Project", gxTv_SdtEmployee_Project, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEmployee_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEmployee_Initialized, false, includeNonInitialized);
            AddObjectProperty("EmployeeId_Z", gxTv_SdtEmployee_Employeeid_Z, false, includeNonInitialized);
            AddObjectProperty("EmployeeFirstName_Z", gxTv_SdtEmployee_Employeefirstname_Z, false, includeNonInitialized);
            AddObjectProperty("EmployeeLastName_Z", gxTv_SdtEmployee_Employeelastname_Z, false, includeNonInitialized);
            AddObjectProperty("EmployeeName_Z", gxTv_SdtEmployee_Employeename_Z, false, includeNonInitialized);
            AddObjectProperty("EmployeeEmail_Z", gxTv_SdtEmployee_Employeeemail_Z, false, includeNonInitialized);
            AddObjectProperty("CompanyId_Z", gxTv_SdtEmployee_Companyid_Z, false, includeNonInitialized);
            AddObjectProperty("CompanyName_Z", gxTv_SdtEmployee_Companyname_Z, false, includeNonInitialized);
            AddObjectProperty("EmployeeIsManager_Z", gxTv_SdtEmployee_Employeeismanager_Z, false, includeNonInitialized);
            AddObjectProperty("GAMUserGUID_Z", gxTv_SdtEmployee_Gamuserguid_Z, false, includeNonInitialized);
            AddObjectProperty("EmployeeIsActive_Z", gxTv_SdtEmployee_Employeeisactive_Z, false, includeNonInitialized);
            AddObjectProperty("EmployeeVactionDays_Z", gxTv_SdtEmployee_Employeevactiondays_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEmployee_Employeevacationdayssetdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEmployee_Employeevacationdayssetdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEmployee_Employeevacationdayssetdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("EmployeeVacationDaysSetDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("EmployeeAPIPassword_Z", gxTv_SdtEmployee_Employeeapipassword_Z, false, includeNonInitialized);
            AddObjectProperty("EmployeeFTEHours_Z", gxTv_SdtEmployee_Employeeftehours_Z, false, includeNonInitialized);
            AddObjectProperty("EmployeeBalance_Z", gxTv_SdtEmployee_Employeebalance_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEmployee sdt )
      {
         if ( sdt.IsDirty("EmployeeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeeid = sdt.gxTv_SdtEmployee_Employeeid ;
         }
         if ( sdt.IsDirty("EmployeeFirstName") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeefirstname = sdt.gxTv_SdtEmployee_Employeefirstname ;
         }
         if ( sdt.IsDirty("EmployeeLastName") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeelastname = sdt.gxTv_SdtEmployee_Employeelastname ;
         }
         if ( sdt.IsDirty("EmployeeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeename = sdt.gxTv_SdtEmployee_Employeename ;
         }
         if ( sdt.IsDirty("EmployeeEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeeemail = sdt.gxTv_SdtEmployee_Employeeemail ;
         }
         if ( sdt.IsDirty("CompanyId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Companyid = sdt.gxTv_SdtEmployee_Companyid ;
         }
         if ( sdt.IsDirty("CompanyName") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Companyname = sdt.gxTv_SdtEmployee_Companyname ;
         }
         if ( sdt.IsDirty("EmployeeIsManager") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeeismanager = sdt.gxTv_SdtEmployee_Employeeismanager ;
         }
         if ( sdt.IsDirty("GAMUserGUID") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Gamuserguid = sdt.gxTv_SdtEmployee_Gamuserguid ;
         }
         if ( sdt.IsDirty("EmployeeIsActive") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeeisactive = sdt.gxTv_SdtEmployee_Employeeisactive ;
         }
         if ( sdt.IsDirty("EmployeeVactionDays") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeevactiondays = sdt.gxTv_SdtEmployee_Employeevactiondays ;
         }
         if ( sdt.IsDirty("EmployeeVacationDaysSetDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeevacationdayssetdate = sdt.gxTv_SdtEmployee_Employeevacationdayssetdate ;
         }
         if ( sdt.IsDirty("EmployeeAPIPassword") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeeapipassword = sdt.gxTv_SdtEmployee_Employeeapipassword ;
         }
         if ( sdt.IsDirty("EmployeeFTEHours") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeeftehours = sdt.gxTv_SdtEmployee_Employeeftehours ;
         }
         if ( sdt.IsDirty("EmployeeBalance") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeebalance = sdt.gxTv_SdtEmployee_Employeebalance ;
         }
         if ( gxTv_SdtEmployee_Vacationset != null )
         {
            GXBCLevelCollection<SdtEmployee_VacationSet> newCollectionVacationset = sdt.gxTpr_Vacationset;
            SdtEmployee_VacationSet currItemVacationset;
            SdtEmployee_VacationSet newItemVacationset;
            short idx = 1;
            while ( idx <= newCollectionVacationset.Count )
            {
               newItemVacationset = ((SdtEmployee_VacationSet)newCollectionVacationset.Item(idx));
               currItemVacationset = gxTv_SdtEmployee_Vacationset.GetByKey(newItemVacationset.gxTpr_Vacationsetdate);
               if ( StringUtil.StrCmp(currItemVacationset.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemVacationset.UpdateDirties(newItemVacationset);
                  if ( StringUtil.StrCmp(newItemVacationset.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemVacationset.gxTpr_Mode = "DLT";
                  }
                  currItemVacationset.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtEmployee_Vacationset.Add(newItemVacationset, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtEmployee_Project != null )
         {
            GXBCLevelCollection<SdtEmployee_Project> newCollectionProject = sdt.gxTpr_Project;
            SdtEmployee_Project currItemProject;
            SdtEmployee_Project newItemProject;
            short idx = 1;
            while ( idx <= newCollectionProject.Count )
            {
               newItemProject = ((SdtEmployee_Project)newCollectionProject.Item(idx));
               currItemProject = gxTv_SdtEmployee_Project.GetByKey(newItemProject.gxTpr_Projectid);
               if ( StringUtil.StrCmp(currItemProject.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemProject.UpdateDirties(newItemProject);
                  if ( StringUtil.StrCmp(newItemProject.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemProject.gxTpr_Mode = "DLT";
                  }
                  currItemProject.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtEmployee_Project.Add(newItemProject, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "EmployeeId" )]
      [  XmlElement( ElementName = "EmployeeId"   )]
      public long gxTpr_Employeeid
      {
         get {
            return gxTv_SdtEmployee_Employeeid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtEmployee_Employeeid != value )
            {
               gxTv_SdtEmployee_Mode = "INS";
               this.gxTv_SdtEmployee_Employeeid_Z_SetNull( );
               this.gxTv_SdtEmployee_Employeefirstname_Z_SetNull( );
               this.gxTv_SdtEmployee_Employeelastname_Z_SetNull( );
               this.gxTv_SdtEmployee_Employeename_Z_SetNull( );
               this.gxTv_SdtEmployee_Employeeemail_Z_SetNull( );
               this.gxTv_SdtEmployee_Companyid_Z_SetNull( );
               this.gxTv_SdtEmployee_Companyname_Z_SetNull( );
               this.gxTv_SdtEmployee_Employeeismanager_Z_SetNull( );
               this.gxTv_SdtEmployee_Gamuserguid_Z_SetNull( );
               this.gxTv_SdtEmployee_Employeeisactive_Z_SetNull( );
               this.gxTv_SdtEmployee_Employeevactiondays_Z_SetNull( );
               this.gxTv_SdtEmployee_Employeevacationdayssetdate_Z_SetNull( );
               this.gxTv_SdtEmployee_Employeeapipassword_Z_SetNull( );
               this.gxTv_SdtEmployee_Employeeftehours_Z_SetNull( );
               this.gxTv_SdtEmployee_Employeebalance_Z_SetNull( );
               if ( gxTv_SdtEmployee_Vacationset != null )
               {
                  GXBCLevelCollection<SdtEmployee_VacationSet> collectionVacationset = gxTv_SdtEmployee_Vacationset;
                  SdtEmployee_VacationSet currItemVacationset;
                  short idx = 1;
                  while ( idx <= collectionVacationset.Count )
                  {
                     currItemVacationset = ((SdtEmployee_VacationSet)collectionVacationset.Item(idx));
                     currItemVacationset.gxTpr_Mode = "INS";
                     currItemVacationset.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
               if ( gxTv_SdtEmployee_Project != null )
               {
                  GXBCLevelCollection<SdtEmployee_Project> collectionProject = gxTv_SdtEmployee_Project;
                  SdtEmployee_Project currItemProject;
                  short idx = 1;
                  while ( idx <= collectionProject.Count )
                  {
                     currItemProject = ((SdtEmployee_Project)collectionProject.Item(idx));
                     currItemProject.gxTpr_Mode = "INS";
                     currItemProject.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtEmployee_Employeeid = value;
            SetDirty("Employeeid");
         }

      }

      [  SoapElement( ElementName = "EmployeeFirstName" )]
      [  XmlElement( ElementName = "EmployeeFirstName"   )]
      public string gxTpr_Employeefirstname
      {
         get {
            return gxTv_SdtEmployee_Employeefirstname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeefirstname = value;
            SetDirty("Employeefirstname");
         }

      }

      [  SoapElement( ElementName = "EmployeeLastName" )]
      [  XmlElement( ElementName = "EmployeeLastName"   )]
      public string gxTpr_Employeelastname
      {
         get {
            return gxTv_SdtEmployee_Employeelastname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeelastname = value;
            SetDirty("Employeelastname");
         }

      }

      [  SoapElement( ElementName = "EmployeeName" )]
      [  XmlElement( ElementName = "EmployeeName"   )]
      public string gxTpr_Employeename
      {
         get {
            return gxTv_SdtEmployee_Employeename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeename = value;
            SetDirty("Employeename");
         }

      }

      [  SoapElement( ElementName = "EmployeeEmail" )]
      [  XmlElement( ElementName = "EmployeeEmail"   )]
      public string gxTpr_Employeeemail
      {
         get {
            return gxTv_SdtEmployee_Employeeemail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeeemail = value;
            SetDirty("Employeeemail");
         }

      }

      [  SoapElement( ElementName = "CompanyId" )]
      [  XmlElement( ElementName = "CompanyId"   )]
      public long gxTpr_Companyid
      {
         get {
            return gxTv_SdtEmployee_Companyid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Companyid = value;
            SetDirty("Companyid");
         }

      }

      [  SoapElement( ElementName = "CompanyName" )]
      [  XmlElement( ElementName = "CompanyName"   )]
      public string gxTpr_Companyname
      {
         get {
            return gxTv_SdtEmployee_Companyname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Companyname = value;
            SetDirty("Companyname");
         }

      }

      [  SoapElement( ElementName = "EmployeeIsManager" )]
      [  XmlElement( ElementName = "EmployeeIsManager"   )]
      public bool gxTpr_Employeeismanager
      {
         get {
            return gxTv_SdtEmployee_Employeeismanager ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeeismanager = value;
            SetDirty("Employeeismanager");
         }

      }

      [  SoapElement( ElementName = "GAMUserGUID" )]
      [  XmlElement( ElementName = "GAMUserGUID"   )]
      public string gxTpr_Gamuserguid
      {
         get {
            return gxTv_SdtEmployee_Gamuserguid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Gamuserguid = value;
            SetDirty("Gamuserguid");
         }

      }

      [  SoapElement( ElementName = "EmployeeIsActive" )]
      [  XmlElement( ElementName = "EmployeeIsActive"   )]
      public bool gxTpr_Employeeisactive
      {
         get {
            return gxTv_SdtEmployee_Employeeisactive ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeeisactive = value;
            SetDirty("Employeeisactive");
         }

      }

      [  SoapElement( ElementName = "EmployeeVactionDays" )]
      [  XmlElement( ElementName = "EmployeeVactionDays"   )]
      public decimal gxTpr_Employeevactiondays
      {
         get {
            return gxTv_SdtEmployee_Employeevactiondays ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeevactiondays = value;
            SetDirty("Employeevactiondays");
         }

      }

      [  SoapElement( ElementName = "EmployeeVacationDaysSetDate" )]
      [  XmlElement( ElementName = "EmployeeVacationDaysSetDate"  , IsNullable=true )]
      public string gxTpr_Employeevacationdayssetdate_Nullable
      {
         get {
            if ( gxTv_SdtEmployee_Employeevacationdayssetdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtEmployee_Employeevacationdayssetdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtEmployee_Employeevacationdayssetdate = DateTime.MinValue;
            else
               gxTv_SdtEmployee_Employeevacationdayssetdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Employeevacationdayssetdate
      {
         get {
            return gxTv_SdtEmployee_Employeevacationdayssetdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeevacationdayssetdate = value;
            SetDirty("Employeevacationdayssetdate");
         }

      }

      [  SoapElement( ElementName = "EmployeeAPIPassword" )]
      [  XmlElement( ElementName = "EmployeeAPIPassword"   )]
      public string gxTpr_Employeeapipassword
      {
         get {
            return gxTv_SdtEmployee_Employeeapipassword ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeeapipassword = value;
            SetDirty("Employeeapipassword");
         }

      }

      [  SoapElement( ElementName = "EmployeeFTEHours" )]
      [  XmlElement( ElementName = "EmployeeFTEHours"   )]
      public short gxTpr_Employeeftehours
      {
         get {
            return gxTv_SdtEmployee_Employeeftehours ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeeftehours = value;
            SetDirty("Employeeftehours");
         }

      }

      [  SoapElement( ElementName = "EmployeeBalance" )]
      [  XmlElement( ElementName = "EmployeeBalance"   )]
      public decimal gxTpr_Employeebalance
      {
         get {
            return gxTv_SdtEmployee_Employeebalance ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeebalance = value;
            SetDirty("Employeebalance");
         }

      }

      [  SoapElement( ElementName = "VacationSet" )]
      [  XmlArray( ElementName = "VacationSet"  )]
      [  XmlArrayItemAttribute( ElementName= "Employee.VacationSet"  , IsNullable=false)]
      public GXBCLevelCollection<SdtEmployee_VacationSet> gxTpr_Vacationset_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtEmployee_Vacationset == null )
            {
               gxTv_SdtEmployee_Vacationset = new GXBCLevelCollection<SdtEmployee_VacationSet>( context, "Employee.VacationSet", "YTT_version4");
            }
            return gxTv_SdtEmployee_Vacationset ;
         }

         set {
            if ( gxTv_SdtEmployee_Vacationset == null )
            {
               gxTv_SdtEmployee_Vacationset = new GXBCLevelCollection<SdtEmployee_VacationSet>( context, "Employee.VacationSet", "YTT_version4");
            }
            sdtIsNull = 0;
            gxTv_SdtEmployee_Vacationset = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtEmployee_VacationSet> gxTpr_Vacationset
      {
         get {
            if ( gxTv_SdtEmployee_Vacationset == null )
            {
               gxTv_SdtEmployee_Vacationset = new GXBCLevelCollection<SdtEmployee_VacationSet>( context, "Employee.VacationSet", "YTT_version4");
            }
            sdtIsNull = 0;
            return gxTv_SdtEmployee_Vacationset ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Vacationset = value;
            SetDirty("Vacationset");
         }

      }

      public void gxTv_SdtEmployee_Vacationset_SetNull( )
      {
         gxTv_SdtEmployee_Vacationset = null;
         SetDirty("Vacationset");
         return  ;
      }

      public bool gxTv_SdtEmployee_Vacationset_IsNull( )
      {
         if ( gxTv_SdtEmployee_Vacationset == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Project" )]
      [  XmlArray( ElementName = "Project"  )]
      [  XmlArrayItemAttribute( ElementName= "Employee.Project"  , IsNullable=false)]
      public GXBCLevelCollection<SdtEmployee_Project> gxTpr_Project_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtEmployee_Project == null )
            {
               gxTv_SdtEmployee_Project = new GXBCLevelCollection<SdtEmployee_Project>( context, "Employee.Project", "YTT_version4");
            }
            return gxTv_SdtEmployee_Project ;
         }

         set {
            if ( gxTv_SdtEmployee_Project == null )
            {
               gxTv_SdtEmployee_Project = new GXBCLevelCollection<SdtEmployee_Project>( context, "Employee.Project", "YTT_version4");
            }
            sdtIsNull = 0;
            gxTv_SdtEmployee_Project = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtEmployee_Project> gxTpr_Project
      {
         get {
            if ( gxTv_SdtEmployee_Project == null )
            {
               gxTv_SdtEmployee_Project = new GXBCLevelCollection<SdtEmployee_Project>( context, "Employee.Project", "YTT_version4");
            }
            sdtIsNull = 0;
            return gxTv_SdtEmployee_Project ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Project = value;
            SetDirty("Project");
         }

      }

      public void gxTv_SdtEmployee_Project_SetNull( )
      {
         gxTv_SdtEmployee_Project = null;
         SetDirty("Project");
         return  ;
      }

      public bool gxTv_SdtEmployee_Project_IsNull( )
      {
         if ( gxTv_SdtEmployee_Project == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEmployee_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEmployee_Mode_SetNull( )
      {
         gxTv_SdtEmployee_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEmployee_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEmployee_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEmployee_Initialized_SetNull( )
      {
         gxTv_SdtEmployee_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEmployee_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeId_Z" )]
      [  XmlElement( ElementName = "EmployeeId_Z"   )]
      public long gxTpr_Employeeid_Z
      {
         get {
            return gxTv_SdtEmployee_Employeeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeeid_Z = value;
            SetDirty("Employeeid_Z");
         }

      }

      public void gxTv_SdtEmployee_Employeeid_Z_SetNull( )
      {
         gxTv_SdtEmployee_Employeeid_Z = 0;
         SetDirty("Employeeid_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Employeeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeFirstName_Z" )]
      [  XmlElement( ElementName = "EmployeeFirstName_Z"   )]
      public string gxTpr_Employeefirstname_Z
      {
         get {
            return gxTv_SdtEmployee_Employeefirstname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeefirstname_Z = value;
            SetDirty("Employeefirstname_Z");
         }

      }

      public void gxTv_SdtEmployee_Employeefirstname_Z_SetNull( )
      {
         gxTv_SdtEmployee_Employeefirstname_Z = "";
         SetDirty("Employeefirstname_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Employeefirstname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeLastName_Z" )]
      [  XmlElement( ElementName = "EmployeeLastName_Z"   )]
      public string gxTpr_Employeelastname_Z
      {
         get {
            return gxTv_SdtEmployee_Employeelastname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeelastname_Z = value;
            SetDirty("Employeelastname_Z");
         }

      }

      public void gxTv_SdtEmployee_Employeelastname_Z_SetNull( )
      {
         gxTv_SdtEmployee_Employeelastname_Z = "";
         SetDirty("Employeelastname_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Employeelastname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeName_Z" )]
      [  XmlElement( ElementName = "EmployeeName_Z"   )]
      public string gxTpr_Employeename_Z
      {
         get {
            return gxTv_SdtEmployee_Employeename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeename_Z = value;
            SetDirty("Employeename_Z");
         }

      }

      public void gxTv_SdtEmployee_Employeename_Z_SetNull( )
      {
         gxTv_SdtEmployee_Employeename_Z = "";
         SetDirty("Employeename_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Employeename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeEmail_Z" )]
      [  XmlElement( ElementName = "EmployeeEmail_Z"   )]
      public string gxTpr_Employeeemail_Z
      {
         get {
            return gxTv_SdtEmployee_Employeeemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeeemail_Z = value;
            SetDirty("Employeeemail_Z");
         }

      }

      public void gxTv_SdtEmployee_Employeeemail_Z_SetNull( )
      {
         gxTv_SdtEmployee_Employeeemail_Z = "";
         SetDirty("Employeeemail_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Employeeemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompanyId_Z" )]
      [  XmlElement( ElementName = "CompanyId_Z"   )]
      public long gxTpr_Companyid_Z
      {
         get {
            return gxTv_SdtEmployee_Companyid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Companyid_Z = value;
            SetDirty("Companyid_Z");
         }

      }

      public void gxTv_SdtEmployee_Companyid_Z_SetNull( )
      {
         gxTv_SdtEmployee_Companyid_Z = 0;
         SetDirty("Companyid_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Companyid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CompanyName_Z" )]
      [  XmlElement( ElementName = "CompanyName_Z"   )]
      public string gxTpr_Companyname_Z
      {
         get {
            return gxTv_SdtEmployee_Companyname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Companyname_Z = value;
            SetDirty("Companyname_Z");
         }

      }

      public void gxTv_SdtEmployee_Companyname_Z_SetNull( )
      {
         gxTv_SdtEmployee_Companyname_Z = "";
         SetDirty("Companyname_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Companyname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeIsManager_Z" )]
      [  XmlElement( ElementName = "EmployeeIsManager_Z"   )]
      public bool gxTpr_Employeeismanager_Z
      {
         get {
            return gxTv_SdtEmployee_Employeeismanager_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeeismanager_Z = value;
            SetDirty("Employeeismanager_Z");
         }

      }

      public void gxTv_SdtEmployee_Employeeismanager_Z_SetNull( )
      {
         gxTv_SdtEmployee_Employeeismanager_Z = false;
         SetDirty("Employeeismanager_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Employeeismanager_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GAMUserGUID_Z" )]
      [  XmlElement( ElementName = "GAMUserGUID_Z"   )]
      public string gxTpr_Gamuserguid_Z
      {
         get {
            return gxTv_SdtEmployee_Gamuserguid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Gamuserguid_Z = value;
            SetDirty("Gamuserguid_Z");
         }

      }

      public void gxTv_SdtEmployee_Gamuserguid_Z_SetNull( )
      {
         gxTv_SdtEmployee_Gamuserguid_Z = "";
         SetDirty("Gamuserguid_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Gamuserguid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeIsActive_Z" )]
      [  XmlElement( ElementName = "EmployeeIsActive_Z"   )]
      public bool gxTpr_Employeeisactive_Z
      {
         get {
            return gxTv_SdtEmployee_Employeeisactive_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeeisactive_Z = value;
            SetDirty("Employeeisactive_Z");
         }

      }

      public void gxTv_SdtEmployee_Employeeisactive_Z_SetNull( )
      {
         gxTv_SdtEmployee_Employeeisactive_Z = false;
         SetDirty("Employeeisactive_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Employeeisactive_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeVactionDays_Z" )]
      [  XmlElement( ElementName = "EmployeeVactionDays_Z"   )]
      public decimal gxTpr_Employeevactiondays_Z
      {
         get {
            return gxTv_SdtEmployee_Employeevactiondays_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeevactiondays_Z = value;
            SetDirty("Employeevactiondays_Z");
         }

      }

      public void gxTv_SdtEmployee_Employeevactiondays_Z_SetNull( )
      {
         gxTv_SdtEmployee_Employeevactiondays_Z = 0;
         SetDirty("Employeevactiondays_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Employeevactiondays_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeVacationDaysSetDate_Z" )]
      [  XmlElement( ElementName = "EmployeeVacationDaysSetDate_Z"  , IsNullable=true )]
      public string gxTpr_Employeevacationdayssetdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtEmployee_Employeevacationdayssetdate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtEmployee_Employeevacationdayssetdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtEmployee_Employeevacationdayssetdate_Z = DateTime.MinValue;
            else
               gxTv_SdtEmployee_Employeevacationdayssetdate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Employeevacationdayssetdate_Z
      {
         get {
            return gxTv_SdtEmployee_Employeevacationdayssetdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeevacationdayssetdate_Z = value;
            SetDirty("Employeevacationdayssetdate_Z");
         }

      }

      public void gxTv_SdtEmployee_Employeevacationdayssetdate_Z_SetNull( )
      {
         gxTv_SdtEmployee_Employeevacationdayssetdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Employeevacationdayssetdate_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Employeevacationdayssetdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeAPIPassword_Z" )]
      [  XmlElement( ElementName = "EmployeeAPIPassword_Z"   )]
      public string gxTpr_Employeeapipassword_Z
      {
         get {
            return gxTv_SdtEmployee_Employeeapipassword_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeeapipassword_Z = value;
            SetDirty("Employeeapipassword_Z");
         }

      }

      public void gxTv_SdtEmployee_Employeeapipassword_Z_SetNull( )
      {
         gxTv_SdtEmployee_Employeeapipassword_Z = "";
         SetDirty("Employeeapipassword_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Employeeapipassword_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeFTEHours_Z" )]
      [  XmlElement( ElementName = "EmployeeFTEHours_Z"   )]
      public short gxTpr_Employeeftehours_Z
      {
         get {
            return gxTv_SdtEmployee_Employeeftehours_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeeftehours_Z = value;
            SetDirty("Employeeftehours_Z");
         }

      }

      public void gxTv_SdtEmployee_Employeeftehours_Z_SetNull( )
      {
         gxTv_SdtEmployee_Employeeftehours_Z = 0;
         SetDirty("Employeeftehours_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Employeeftehours_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmployeeBalance_Z" )]
      [  XmlElement( ElementName = "EmployeeBalance_Z"   )]
      public decimal gxTpr_Employeebalance_Z
      {
         get {
            return gxTv_SdtEmployee_Employeebalance_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmployee_Employeebalance_Z = value;
            SetDirty("Employeebalance_Z");
         }

      }

      public void gxTv_SdtEmployee_Employeebalance_Z_SetNull( )
      {
         gxTv_SdtEmployee_Employeebalance_Z = 0;
         SetDirty("Employeebalance_Z");
         return  ;
      }

      public bool gxTv_SdtEmployee_Employeebalance_Z_IsNull( )
      {
         return false ;
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
         sdtIsNull = 1;
         gxTv_SdtEmployee_Employeefirstname = "";
         gxTv_SdtEmployee_Employeelastname = "";
         gxTv_SdtEmployee_Employeename = "";
         gxTv_SdtEmployee_Employeeemail = "";
         gxTv_SdtEmployee_Companyname = "";
         gxTv_SdtEmployee_Gamuserguid = "";
         gxTv_SdtEmployee_Employeevacationdayssetdate = DateTime.MinValue;
         gxTv_SdtEmployee_Employeeapipassword = "";
         gxTv_SdtEmployee_Mode = "";
         gxTv_SdtEmployee_Employeefirstname_Z = "";
         gxTv_SdtEmployee_Employeelastname_Z = "";
         gxTv_SdtEmployee_Employeename_Z = "";
         gxTv_SdtEmployee_Employeeemail_Z = "";
         gxTv_SdtEmployee_Companyname_Z = "";
         gxTv_SdtEmployee_Gamuserguid_Z = "";
         gxTv_SdtEmployee_Employeevacationdayssetdate_Z = DateTime.MinValue;
         gxTv_SdtEmployee_Employeeapipassword_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "employee", "GeneXus.Programs.employee_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtEmployee_Employeeftehours ;
      private short gxTv_SdtEmployee_Initialized ;
      private short gxTv_SdtEmployee_Employeeftehours_Z ;
      private long gxTv_SdtEmployee_Employeeid ;
      private long gxTv_SdtEmployee_Companyid ;
      private long gxTv_SdtEmployee_Employeeid_Z ;
      private long gxTv_SdtEmployee_Companyid_Z ;
      private decimal gxTv_SdtEmployee_Employeevactiondays ;
      private decimal gxTv_SdtEmployee_Employeebalance ;
      private decimal gxTv_SdtEmployee_Employeevactiondays_Z ;
      private decimal gxTv_SdtEmployee_Employeebalance_Z ;
      private string gxTv_SdtEmployee_Employeefirstname ;
      private string gxTv_SdtEmployee_Employeelastname ;
      private string gxTv_SdtEmployee_Employeename ;
      private string gxTv_SdtEmployee_Companyname ;
      private string gxTv_SdtEmployee_Mode ;
      private string gxTv_SdtEmployee_Employeefirstname_Z ;
      private string gxTv_SdtEmployee_Employeelastname_Z ;
      private string gxTv_SdtEmployee_Employeename_Z ;
      private string gxTv_SdtEmployee_Companyname_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtEmployee_Employeevacationdayssetdate ;
      private DateTime gxTv_SdtEmployee_Employeevacationdayssetdate_Z ;
      private bool gxTv_SdtEmployee_Employeeismanager ;
      private bool gxTv_SdtEmployee_Employeeisactive ;
      private bool gxTv_SdtEmployee_Employeeismanager_Z ;
      private bool gxTv_SdtEmployee_Employeeisactive_Z ;
      private string gxTv_SdtEmployee_Employeeemail ;
      private string gxTv_SdtEmployee_Gamuserguid ;
      private string gxTv_SdtEmployee_Employeeapipassword ;
      private string gxTv_SdtEmployee_Employeeemail_Z ;
      private string gxTv_SdtEmployee_Gamuserguid_Z ;
      private string gxTv_SdtEmployee_Employeeapipassword_Z ;
      private GXBCLevelCollection<SdtEmployee_VacationSet> gxTv_SdtEmployee_Vacationset=null ;
      private GXBCLevelCollection<SdtEmployee_Project> gxTv_SdtEmployee_Project=null ;
   }

   [DataContract(Name = @"Employee", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtEmployee_RESTInterface : GxGenericCollectionItem<SdtEmployee>
   {
      public SdtEmployee_RESTInterface( ) : base()
      {
      }

      public SdtEmployee_RESTInterface( SdtEmployee psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EmployeeId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Employeeid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Employeeid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Employeeid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "EmployeeFirstName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Employeefirstname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Employeefirstname) ;
         }

         set {
            sdt.gxTpr_Employeefirstname = value;
         }

      }

      [DataMember( Name = "EmployeeLastName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Employeelastname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Employeelastname) ;
         }

         set {
            sdt.gxTpr_Employeelastname = value;
         }

      }

      [DataMember( Name = "EmployeeName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Employeename
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Employeename) ;
         }

         set {
            sdt.gxTpr_Employeename = value;
         }

      }

      [DataMember( Name = "EmployeeEmail" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Employeeemail
      {
         get {
            return sdt.gxTpr_Employeeemail ;
         }

         set {
            sdt.gxTpr_Employeeemail = value;
         }

      }

      [DataMember( Name = "CompanyId" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Companyid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Companyid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Companyid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CompanyName" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Companyname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Companyname) ;
         }

         set {
            sdt.gxTpr_Companyname = value;
         }

      }

      [DataMember( Name = "EmployeeIsManager" , Order = 7 )]
      [GxSeudo()]
      public bool gxTpr_Employeeismanager
      {
         get {
            return sdt.gxTpr_Employeeismanager ;
         }

         set {
            sdt.gxTpr_Employeeismanager = value;
         }

      }

      [DataMember( Name = "GAMUserGUID" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Gamuserguid
      {
         get {
            return sdt.gxTpr_Gamuserguid ;
         }

         set {
            sdt.gxTpr_Gamuserguid = value;
         }

      }

      [DataMember( Name = "EmployeeIsActive" , Order = 9 )]
      [GxSeudo()]
      public bool gxTpr_Employeeisactive
      {
         get {
            return sdt.gxTpr_Employeeisactive ;
         }

         set {
            sdt.gxTpr_Employeeisactive = value;
         }

      }

      [DataMember( Name = "EmployeeVactionDays" , Order = 10 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Employeevactiondays
      {
         get {
            return sdt.gxTpr_Employeevactiondays ;
         }

         set {
            sdt.gxTpr_Employeevactiondays = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EmployeeVacationDaysSetDate" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Employeevacationdayssetdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Employeevacationdayssetdate) ;
         }

         set {
            sdt.gxTpr_Employeevacationdayssetdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "EmployeeAPIPassword" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Employeeapipassword
      {
         get {
            return sdt.gxTpr_Employeeapipassword ;
         }

         set {
            sdt.gxTpr_Employeeapipassword = value;
         }

      }

      [DataMember( Name = "EmployeeFTEHours" , Order = 13 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Employeeftehours
      {
         get {
            return sdt.gxTpr_Employeeftehours ;
         }

         set {
            sdt.gxTpr_Employeeftehours = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EmployeeBalance" , Order = 14 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Employeebalance
      {
         get {
            return sdt.gxTpr_Employeebalance ;
         }

         set {
            sdt.gxTpr_Employeebalance = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "VacationSet" , Order = 15 )]
      public GxGenericCollection<SdtEmployee_VacationSet_RESTInterface> gxTpr_Vacationset
      {
         get {
            return new GxGenericCollection<SdtEmployee_VacationSet_RESTInterface>(sdt.gxTpr_Vacationset) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Vacationset);
         }

      }

      [DataMember( Name = "Project" , Order = 16 )]
      public GxGenericCollection<SdtEmployee_Project_RESTInterface> gxTpr_Project
      {
         get {
            return new GxGenericCollection<SdtEmployee_Project_RESTInterface>(sdt.gxTpr_Project) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Project);
         }

      }

      public SdtEmployee sdt
      {
         get {
            return (SdtEmployee)Sdt ;
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
            sdt = new SdtEmployee() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 17 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Employee", Namespace = "YTT_version4")]
   [GxJsonSerialization("default")]
   public class SdtEmployee_RESTLInterface : GxGenericCollectionItem<SdtEmployee>
   {
      public SdtEmployee_RESTLInterface( ) : base()
      {
      }

      public SdtEmployee_RESTLInterface( SdtEmployee psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EmployeeFirstName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Employeefirstname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Employeefirstname) ;
         }

         set {
            sdt.gxTpr_Employeefirstname = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtEmployee sdt
      {
         get {
            return (SdtEmployee)Sdt ;
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
            sdt = new SdtEmployee() ;
         }
      }

   }

}
