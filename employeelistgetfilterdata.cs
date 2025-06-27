using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class employeelistgetfilterdata : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "employeelist_Services_Execute" ;
         }

      }

      public employeelistgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeelistgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV49DDOName = aP0_DDOName;
         this.AV50SearchTxtParms = aP1_SearchTxtParms;
         this.AV51SearchTxtTo = aP2_SearchTxtTo;
         this.AV52OptionsJson = "" ;
         this.AV53OptionsDescJson = "" ;
         this.AV54OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV52OptionsJson;
         aP4_OptionsDescJson=this.AV53OptionsDescJson;
         aP5_OptionIndexesJson=this.AV54OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV54OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV49DDOName = aP0_DDOName;
         this.AV50SearchTxtParms = aP1_SearchTxtParms;
         this.AV51SearchTxtTo = aP2_SearchTxtTo;
         this.AV52OptionsJson = "" ;
         this.AV53OptionsDescJson = "" ;
         this.AV54OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV52OptionsJson;
         aP4_OptionsDescJson=this.AV53OptionsDescJson;
         aP5_OptionIndexesJson=this.AV54OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV39Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV41OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV42OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36MaxItems = 10;
         AV35PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV50SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV33SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? "" : StringUtil.Substring( AV50SearchTxtParms, 3, -1));
         AV34SkipItems = (short)(AV35PageIndex*AV36MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_EMPLOYEENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_EMPLOYEEEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEEEMAILOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_COMPANYNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMPANYNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV52OptionsJson = AV39Options.ToJSonString(false);
         AV53OptionsDescJson = AV41OptionsDesc.ToJSonString(false);
         AV54OptionIndexesJson = AV42OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV44Session.Get("EmployeeListGridState"), "") == 0 )
         {
            AV46GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "EmployeeListGridState"), null, "", "");
         }
         else
         {
            AV46GridState.FromXml(AV44Session.Get("EmployeeListGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV46GridState.gxTpr_Filtervalues.Count )
         {
            AV47GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV46GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV55FilterFullText = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV17TFEmployeeName = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV18TFEmployeeName_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL") == 0 )
            {
               AV19TFEmployeeEmail = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL_SEL") == 0 )
            {
               AV20TFEmployeeEmail_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFCOMPANYNAME") == 0 )
            {
               AV23TFCompanyName = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFCOMPANYNAME_SEL") == 0 )
            {
               AV24TFCompanyName_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISMANAGER_SEL") == 0 )
            {
               AV25TFEmployeeIsManager_Sel = (short)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISACTIVE_SEL") == 0 )
            {
               AV28TFEmployeeIsActive_Sel = (short)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEVACTIONDAYS") == 0 )
            {
               AV29TFEmployeeVactionDays = NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, ".");
               AV30TFEmployeeVactionDays_To = NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADEMPLOYEENAMEOPTIONS' Routine */
         returnInSub = false;
         AV17TFEmployeeName = AV33SearchTxt;
         AV18TFEmployeeName_Sel = "";
         AV58Employeelistds_1_filterfulltext = AV55FilterFullText;
         AV59Employeelistds_2_tfemployeename = AV17TFEmployeeName;
         AV60Employeelistds_3_tfemployeename_sel = AV18TFEmployeeName_Sel;
         AV61Employeelistds_4_tfemployeeemail = AV19TFEmployeeEmail;
         AV62Employeelistds_5_tfemployeeemail_sel = AV20TFEmployeeEmail_Sel;
         AV63Employeelistds_6_tfcompanyname = AV23TFCompanyName;
         AV64Employeelistds_7_tfcompanyname_sel = AV24TFCompanyName_Sel;
         AV65Employeelistds_8_tfemployeeismanager_sel = AV25TFEmployeeIsManager_Sel;
         AV66Employeelistds_9_tfemployeeisactive_sel = AV28TFEmployeeIsActive_Sel;
         AV67Employeelistds_10_tfemployeevactiondays = AV29TFEmployeeVactionDays;
         AV68Employeelistds_11_tfemployeevactiondays_to = AV30TFEmployeeVactionDays_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV58Employeelistds_1_filterfulltext ,
                                              AV60Employeelistds_3_tfemployeename_sel ,
                                              AV59Employeelistds_2_tfemployeename ,
                                              AV62Employeelistds_5_tfemployeeemail_sel ,
                                              AV61Employeelistds_4_tfemployeeemail ,
                                              AV64Employeelistds_7_tfcompanyname_sel ,
                                              AV63Employeelistds_6_tfcompanyname ,
                                              AV65Employeelistds_8_tfemployeeismanager_sel ,
                                              AV66Employeelistds_9_tfemployeeisactive_sel ,
                                              AV67Employeelistds_10_tfemployeevactiondays ,
                                              AV68Employeelistds_11_tfemployeevactiondays_to ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A101CompanyName ,
                                              A146EmployeeVactionDays ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV58Employeelistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Employeelistds_1_filterfulltext), "%", "");
         lV58Employeelistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Employeelistds_1_filterfulltext), "%", "");
         lV58Employeelistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Employeelistds_1_filterfulltext), "%", "");
         lV58Employeelistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Employeelistds_1_filterfulltext), "%", "");
         lV59Employeelistds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV59Employeelistds_2_tfemployeename), 100, "%");
         lV61Employeelistds_4_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV61Employeelistds_4_tfemployeeemail), "%", "");
         lV63Employeelistds_6_tfcompanyname = StringUtil.PadR( StringUtil.RTrim( AV63Employeelistds_6_tfcompanyname), 100, "%");
         /* Using cursor P007S2 */
         pr_default.execute(0, new Object[] {lV58Employeelistds_1_filterfulltext, lV58Employeelistds_1_filterfulltext, lV58Employeelistds_1_filterfulltext, lV58Employeelistds_1_filterfulltext, lV59Employeelistds_2_tfemployeename, AV60Employeelistds_3_tfemployeename_sel, lV61Employeelistds_4_tfemployeeemail, AV62Employeelistds_5_tfemployeeemail_sel, lV63Employeelistds_6_tfcompanyname, AV64Employeelistds_7_tfcompanyname_sel, AV67Employeelistds_10_tfemployeevactiondays, AV68Employeelistds_11_tfemployeevactiondays_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7S2 = false;
            A100CompanyId = P007S2_A100CompanyId[0];
            A148EmployeeName = P007S2_A148EmployeeName[0];
            A146EmployeeVactionDays = P007S2_A146EmployeeVactionDays[0];
            A112EmployeeIsActive = P007S2_A112EmployeeIsActive[0];
            A110EmployeeIsManager = P007S2_A110EmployeeIsManager[0];
            A101CompanyName = P007S2_A101CompanyName[0];
            A109EmployeeEmail = P007S2_A109EmployeeEmail[0];
            A106EmployeeId = P007S2_A106EmployeeId[0];
            A101CompanyName = P007S2_A101CompanyName[0];
            AV43count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P007S2_A148EmployeeName[0], A148EmployeeName) == 0 ) )
            {
               BRK7S2 = false;
               A106EmployeeId = P007S2_A106EmployeeId[0];
               AV43count = (long)(AV43count+1);
               BRK7S2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV34SkipItems) )
            {
               AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A148EmployeeName)) ? "<#Empty#>" : A148EmployeeName);
               AV39Options.Add(AV38Option, 0);
               AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV39Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV34SkipItems = (short)(AV34SkipItems-1);
            }
            if ( ! BRK7S2 )
            {
               BRK7S2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADEMPLOYEEEMAILOPTIONS' Routine */
         returnInSub = false;
         AV19TFEmployeeEmail = AV33SearchTxt;
         AV20TFEmployeeEmail_Sel = "";
         AV58Employeelistds_1_filterfulltext = AV55FilterFullText;
         AV59Employeelistds_2_tfemployeename = AV17TFEmployeeName;
         AV60Employeelistds_3_tfemployeename_sel = AV18TFEmployeeName_Sel;
         AV61Employeelistds_4_tfemployeeemail = AV19TFEmployeeEmail;
         AV62Employeelistds_5_tfemployeeemail_sel = AV20TFEmployeeEmail_Sel;
         AV63Employeelistds_6_tfcompanyname = AV23TFCompanyName;
         AV64Employeelistds_7_tfcompanyname_sel = AV24TFCompanyName_Sel;
         AV65Employeelistds_8_tfemployeeismanager_sel = AV25TFEmployeeIsManager_Sel;
         AV66Employeelistds_9_tfemployeeisactive_sel = AV28TFEmployeeIsActive_Sel;
         AV67Employeelistds_10_tfemployeevactiondays = AV29TFEmployeeVactionDays;
         AV68Employeelistds_11_tfemployeevactiondays_to = AV30TFEmployeeVactionDays_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV58Employeelistds_1_filterfulltext ,
                                              AV60Employeelistds_3_tfemployeename_sel ,
                                              AV59Employeelistds_2_tfemployeename ,
                                              AV62Employeelistds_5_tfemployeeemail_sel ,
                                              AV61Employeelistds_4_tfemployeeemail ,
                                              AV64Employeelistds_7_tfcompanyname_sel ,
                                              AV63Employeelistds_6_tfcompanyname ,
                                              AV65Employeelistds_8_tfemployeeismanager_sel ,
                                              AV66Employeelistds_9_tfemployeeisactive_sel ,
                                              AV67Employeelistds_10_tfemployeevactiondays ,
                                              AV68Employeelistds_11_tfemployeevactiondays_to ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A101CompanyName ,
                                              A146EmployeeVactionDays ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV58Employeelistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Employeelistds_1_filterfulltext), "%", "");
         lV58Employeelistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Employeelistds_1_filterfulltext), "%", "");
         lV58Employeelistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Employeelistds_1_filterfulltext), "%", "");
         lV58Employeelistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Employeelistds_1_filterfulltext), "%", "");
         lV59Employeelistds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV59Employeelistds_2_tfemployeename), 100, "%");
         lV61Employeelistds_4_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV61Employeelistds_4_tfemployeeemail), "%", "");
         lV63Employeelistds_6_tfcompanyname = StringUtil.PadR( StringUtil.RTrim( AV63Employeelistds_6_tfcompanyname), 100, "%");
         /* Using cursor P007S3 */
         pr_default.execute(1, new Object[] {lV58Employeelistds_1_filterfulltext, lV58Employeelistds_1_filterfulltext, lV58Employeelistds_1_filterfulltext, lV58Employeelistds_1_filterfulltext, lV59Employeelistds_2_tfemployeename, AV60Employeelistds_3_tfemployeename_sel, lV61Employeelistds_4_tfemployeeemail, AV62Employeelistds_5_tfemployeeemail_sel, lV63Employeelistds_6_tfcompanyname, AV64Employeelistds_7_tfcompanyname_sel, AV67Employeelistds_10_tfemployeevactiondays, AV68Employeelistds_11_tfemployeevactiondays_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7S4 = false;
            A100CompanyId = P007S3_A100CompanyId[0];
            A109EmployeeEmail = P007S3_A109EmployeeEmail[0];
            A146EmployeeVactionDays = P007S3_A146EmployeeVactionDays[0];
            A112EmployeeIsActive = P007S3_A112EmployeeIsActive[0];
            A110EmployeeIsManager = P007S3_A110EmployeeIsManager[0];
            A101CompanyName = P007S3_A101CompanyName[0];
            A148EmployeeName = P007S3_A148EmployeeName[0];
            A106EmployeeId = P007S3_A106EmployeeId[0];
            A101CompanyName = P007S3_A101CompanyName[0];
            AV43count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007S3_A109EmployeeEmail[0], A109EmployeeEmail) == 0 ) )
            {
               BRK7S4 = false;
               A106EmployeeId = P007S3_A106EmployeeId[0];
               AV43count = (long)(AV43count+1);
               BRK7S4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV34SkipItems) )
            {
               AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A109EmployeeEmail)) ? "<#Empty#>" : A109EmployeeEmail);
               AV39Options.Add(AV38Option, 0);
               AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV39Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV34SkipItems = (short)(AV34SkipItems-1);
            }
            if ( ! BRK7S4 )
            {
               BRK7S4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCOMPANYNAMEOPTIONS' Routine */
         returnInSub = false;
         AV23TFCompanyName = AV33SearchTxt;
         AV24TFCompanyName_Sel = "";
         AV58Employeelistds_1_filterfulltext = AV55FilterFullText;
         AV59Employeelistds_2_tfemployeename = AV17TFEmployeeName;
         AV60Employeelistds_3_tfemployeename_sel = AV18TFEmployeeName_Sel;
         AV61Employeelistds_4_tfemployeeemail = AV19TFEmployeeEmail;
         AV62Employeelistds_5_tfemployeeemail_sel = AV20TFEmployeeEmail_Sel;
         AV63Employeelistds_6_tfcompanyname = AV23TFCompanyName;
         AV64Employeelistds_7_tfcompanyname_sel = AV24TFCompanyName_Sel;
         AV65Employeelistds_8_tfemployeeismanager_sel = AV25TFEmployeeIsManager_Sel;
         AV66Employeelistds_9_tfemployeeisactive_sel = AV28TFEmployeeIsActive_Sel;
         AV67Employeelistds_10_tfemployeevactiondays = AV29TFEmployeeVactionDays;
         AV68Employeelistds_11_tfemployeevactiondays_to = AV30TFEmployeeVactionDays_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV58Employeelistds_1_filterfulltext ,
                                              AV60Employeelistds_3_tfemployeename_sel ,
                                              AV59Employeelistds_2_tfemployeename ,
                                              AV62Employeelistds_5_tfemployeeemail_sel ,
                                              AV61Employeelistds_4_tfemployeeemail ,
                                              AV64Employeelistds_7_tfcompanyname_sel ,
                                              AV63Employeelistds_6_tfcompanyname ,
                                              AV65Employeelistds_8_tfemployeeismanager_sel ,
                                              AV66Employeelistds_9_tfemployeeisactive_sel ,
                                              AV67Employeelistds_10_tfemployeevactiondays ,
                                              AV68Employeelistds_11_tfemployeevactiondays_to ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A101CompanyName ,
                                              A146EmployeeVactionDays ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV58Employeelistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Employeelistds_1_filterfulltext), "%", "");
         lV58Employeelistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Employeelistds_1_filterfulltext), "%", "");
         lV58Employeelistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Employeelistds_1_filterfulltext), "%", "");
         lV58Employeelistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Employeelistds_1_filterfulltext), "%", "");
         lV59Employeelistds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV59Employeelistds_2_tfemployeename), 100, "%");
         lV61Employeelistds_4_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV61Employeelistds_4_tfemployeeemail), "%", "");
         lV63Employeelistds_6_tfcompanyname = StringUtil.PadR( StringUtil.RTrim( AV63Employeelistds_6_tfcompanyname), 100, "%");
         /* Using cursor P007S4 */
         pr_default.execute(2, new Object[] {lV58Employeelistds_1_filterfulltext, lV58Employeelistds_1_filterfulltext, lV58Employeelistds_1_filterfulltext, lV58Employeelistds_1_filterfulltext, lV59Employeelistds_2_tfemployeename, AV60Employeelistds_3_tfemployeename_sel, lV61Employeelistds_4_tfemployeeemail, AV62Employeelistds_5_tfemployeeemail_sel, lV63Employeelistds_6_tfcompanyname, AV64Employeelistds_7_tfcompanyname_sel, AV67Employeelistds_10_tfemployeevactiondays, AV68Employeelistds_11_tfemployeevactiondays_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK7S6 = false;
            A100CompanyId = P007S4_A100CompanyId[0];
            A146EmployeeVactionDays = P007S4_A146EmployeeVactionDays[0];
            A112EmployeeIsActive = P007S4_A112EmployeeIsActive[0];
            A110EmployeeIsManager = P007S4_A110EmployeeIsManager[0];
            A101CompanyName = P007S4_A101CompanyName[0];
            A109EmployeeEmail = P007S4_A109EmployeeEmail[0];
            A148EmployeeName = P007S4_A148EmployeeName[0];
            A106EmployeeId = P007S4_A106EmployeeId[0];
            A101CompanyName = P007S4_A101CompanyName[0];
            AV43count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P007S4_A100CompanyId[0] == A100CompanyId ) )
            {
               BRK7S6 = false;
               A106EmployeeId = P007S4_A106EmployeeId[0];
               AV43count = (long)(AV43count+1);
               BRK7S6 = true;
               pr_default.readNext(2);
            }
            AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A101CompanyName)) ? "<#Empty#>" : A101CompanyName);
            AV37InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV38Option, "<#Empty#>") != 0 ) && ( AV37InsertIndex <= AV39Options.Count ) && ( ( StringUtil.StrCmp(((string)AV39Options.Item(AV37InsertIndex)), AV38Option) < 0 ) || ( StringUtil.StrCmp(((string)AV39Options.Item(AV37InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV37InsertIndex = (int)(AV37InsertIndex+1);
            }
            AV39Options.Add(AV38Option, AV37InsertIndex);
            AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), AV37InsertIndex);
            if ( AV39Options.Count == AV34SkipItems + 11 )
            {
               AV39Options.RemoveItem(AV39Options.Count);
               AV42OptionIndexes.RemoveItem(AV42OptionIndexes.Count);
            }
            if ( ! BRK7S6 )
            {
               BRK7S6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV34SkipItems > 0 )
         {
            AV39Options.RemoveItem(1);
            AV42OptionIndexes.RemoveItem(1);
            AV34SkipItems = (short)(AV34SkipItems-1);
         }
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV52OptionsJson = "";
         AV53OptionsDescJson = "";
         AV54OptionIndexesJson = "";
         AV39Options = new GxSimpleCollection<string>();
         AV41OptionsDesc = new GxSimpleCollection<string>();
         AV42OptionIndexes = new GxSimpleCollection<string>();
         AV33SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV44Session = context.GetSession();
         AV46GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV47GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV55FilterFullText = "";
         AV17TFEmployeeName = "";
         AV18TFEmployeeName_Sel = "";
         AV19TFEmployeeEmail = "";
         AV20TFEmployeeEmail_Sel = "";
         AV23TFCompanyName = "";
         AV24TFCompanyName_Sel = "";
         AV58Employeelistds_1_filterfulltext = "";
         AV59Employeelistds_2_tfemployeename = "";
         AV60Employeelistds_3_tfemployeename_sel = "";
         AV61Employeelistds_4_tfemployeeemail = "";
         AV62Employeelistds_5_tfemployeeemail_sel = "";
         AV63Employeelistds_6_tfcompanyname = "";
         AV64Employeelistds_7_tfcompanyname_sel = "";
         lV58Employeelistds_1_filterfulltext = "";
         lV59Employeelistds_2_tfemployeename = "";
         lV61Employeelistds_4_tfemployeeemail = "";
         lV63Employeelistds_6_tfcompanyname = "";
         A148EmployeeName = "";
         A109EmployeeEmail = "";
         A101CompanyName = "";
         P007S2_A100CompanyId = new long[1] ;
         P007S2_A148EmployeeName = new string[] {""} ;
         P007S2_A146EmployeeVactionDays = new decimal[1] ;
         P007S2_A112EmployeeIsActive = new bool[] {false} ;
         P007S2_A110EmployeeIsManager = new bool[] {false} ;
         P007S2_A101CompanyName = new string[] {""} ;
         P007S2_A109EmployeeEmail = new string[] {""} ;
         P007S2_A106EmployeeId = new long[1] ;
         AV38Option = "";
         P007S3_A100CompanyId = new long[1] ;
         P007S3_A109EmployeeEmail = new string[] {""} ;
         P007S3_A146EmployeeVactionDays = new decimal[1] ;
         P007S3_A112EmployeeIsActive = new bool[] {false} ;
         P007S3_A110EmployeeIsManager = new bool[] {false} ;
         P007S3_A101CompanyName = new string[] {""} ;
         P007S3_A148EmployeeName = new string[] {""} ;
         P007S3_A106EmployeeId = new long[1] ;
         P007S4_A100CompanyId = new long[1] ;
         P007S4_A146EmployeeVactionDays = new decimal[1] ;
         P007S4_A112EmployeeIsActive = new bool[] {false} ;
         P007S4_A110EmployeeIsManager = new bool[] {false} ;
         P007S4_A101CompanyName = new string[] {""} ;
         P007S4_A109EmployeeEmail = new string[] {""} ;
         P007S4_A148EmployeeName = new string[] {""} ;
         P007S4_A106EmployeeId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeelistgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007S2_A100CompanyId, P007S2_A148EmployeeName, P007S2_A146EmployeeVactionDays, P007S2_A112EmployeeIsActive, P007S2_A110EmployeeIsManager, P007S2_A101CompanyName, P007S2_A109EmployeeEmail, P007S2_A106EmployeeId
               }
               , new Object[] {
               P007S3_A100CompanyId, P007S3_A109EmployeeEmail, P007S3_A146EmployeeVactionDays, P007S3_A112EmployeeIsActive, P007S3_A110EmployeeIsManager, P007S3_A101CompanyName, P007S3_A148EmployeeName, P007S3_A106EmployeeId
               }
               , new Object[] {
               P007S4_A100CompanyId, P007S4_A146EmployeeVactionDays, P007S4_A112EmployeeIsActive, P007S4_A110EmployeeIsManager, P007S4_A101CompanyName, P007S4_A109EmployeeEmail, P007S4_A148EmployeeName, P007S4_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV36MaxItems ;
      private short AV35PageIndex ;
      private short AV34SkipItems ;
      private short AV25TFEmployeeIsManager_Sel ;
      private short AV28TFEmployeeIsActive_Sel ;
      private short AV65Employeelistds_8_tfemployeeismanager_sel ;
      private short AV66Employeelistds_9_tfemployeeisactive_sel ;
      private int AV56GXV1 ;
      private int AV37InsertIndex ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private long AV43count ;
      private decimal AV29TFEmployeeVactionDays ;
      private decimal AV30TFEmployeeVactionDays_To ;
      private decimal AV67Employeelistds_10_tfemployeevactiondays ;
      private decimal AV68Employeelistds_11_tfemployeevactiondays_to ;
      private decimal A146EmployeeVactionDays ;
      private string AV17TFEmployeeName ;
      private string AV18TFEmployeeName_Sel ;
      private string AV23TFCompanyName ;
      private string AV24TFCompanyName_Sel ;
      private string AV59Employeelistds_2_tfemployeename ;
      private string AV60Employeelistds_3_tfemployeename_sel ;
      private string AV63Employeelistds_6_tfcompanyname ;
      private string AV64Employeelistds_7_tfcompanyname_sel ;
      private string lV59Employeelistds_2_tfemployeename ;
      private string lV63Employeelistds_6_tfcompanyname ;
      private string A148EmployeeName ;
      private string A101CompanyName ;
      private bool returnInSub ;
      private bool A110EmployeeIsManager ;
      private bool A112EmployeeIsActive ;
      private bool BRK7S2 ;
      private bool BRK7S4 ;
      private bool BRK7S6 ;
      private string AV52OptionsJson ;
      private string AV53OptionsDescJson ;
      private string AV54OptionIndexesJson ;
      private string AV49DDOName ;
      private string AV50SearchTxtParms ;
      private string AV51SearchTxtTo ;
      private string AV33SearchTxt ;
      private string AV55FilterFullText ;
      private string AV19TFEmployeeEmail ;
      private string AV20TFEmployeeEmail_Sel ;
      private string AV58Employeelistds_1_filterfulltext ;
      private string AV61Employeelistds_4_tfemployeeemail ;
      private string AV62Employeelistds_5_tfemployeeemail_sel ;
      private string lV58Employeelistds_1_filterfulltext ;
      private string lV61Employeelistds_4_tfemployeeemail ;
      private string A109EmployeeEmail ;
      private string AV38Option ;
      private IGxSession AV44Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV39Options ;
      private GxSimpleCollection<string> AV41OptionsDesc ;
      private GxSimpleCollection<string> AV42OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV46GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV47GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private long[] P007S2_A100CompanyId ;
      private string[] P007S2_A148EmployeeName ;
      private decimal[] P007S2_A146EmployeeVactionDays ;
      private bool[] P007S2_A112EmployeeIsActive ;
      private bool[] P007S2_A110EmployeeIsManager ;
      private string[] P007S2_A101CompanyName ;
      private string[] P007S2_A109EmployeeEmail ;
      private long[] P007S2_A106EmployeeId ;
      private long[] P007S3_A100CompanyId ;
      private string[] P007S3_A109EmployeeEmail ;
      private decimal[] P007S3_A146EmployeeVactionDays ;
      private bool[] P007S3_A112EmployeeIsActive ;
      private bool[] P007S3_A110EmployeeIsManager ;
      private string[] P007S3_A101CompanyName ;
      private string[] P007S3_A148EmployeeName ;
      private long[] P007S3_A106EmployeeId ;
      private long[] P007S4_A100CompanyId ;
      private decimal[] P007S4_A146EmployeeVactionDays ;
      private bool[] P007S4_A112EmployeeIsActive ;
      private bool[] P007S4_A110EmployeeIsManager ;
      private string[] P007S4_A101CompanyName ;
      private string[] P007S4_A109EmployeeEmail ;
      private string[] P007S4_A148EmployeeName ;
      private long[] P007S4_A106EmployeeId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class employeelistgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007S2( IGxContext context ,
                                             string AV58Employeelistds_1_filterfulltext ,
                                             string AV60Employeelistds_3_tfemployeename_sel ,
                                             string AV59Employeelistds_2_tfemployeename ,
                                             string AV62Employeelistds_5_tfemployeeemail_sel ,
                                             string AV61Employeelistds_4_tfemployeeemail ,
                                             string AV64Employeelistds_7_tfcompanyname_sel ,
                                             string AV63Employeelistds_6_tfcompanyname ,
                                             short AV65Employeelistds_8_tfemployeeismanager_sel ,
                                             short AV66Employeelistds_9_tfemployeeisactive_sel ,
                                             decimal AV67Employeelistds_10_tfemployeevactiondays ,
                                             decimal AV68Employeelistds_11_tfemployeevactiondays_to ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             string A101CompanyName ,
                                             decimal A146EmployeeVactionDays ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T1.EmployeeName, T1.EmployeeVactionDays, T1.EmployeeIsActive, T1.EmployeeIsManager, T2.CompanyName, T1.EmployeeEmail, T1.EmployeeId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Employeelistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.EmployeeName like '%' || :lV58Employeelistds_1_filterfulltext) or ( T1.EmployeeEmail like '%' || :lV58Employeelistds_1_filterfulltext) or ( T2.CompanyName like '%' || :lV58Employeelistds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.EmployeeVactionDays,'90.9'), 2) like '%' || :lV58Employeelistds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Employeelistds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Employeelistds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName like :lV59Employeelistds_2_tfemployeename)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Employeelistds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV60Employeelistds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName = ( :AV60Employeelistds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV60Employeelistds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Employeelistds_5_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Employeelistds_4_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail like :lV61Employeelistds_4_tfemployeeemail)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Employeelistds_5_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV62Employeelistds_5_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail = ( :AV62Employeelistds_5_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV62Employeelistds_5_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Employeelistds_7_tfcompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Employeelistds_6_tfcompanyname)) ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName like :lV63Employeelistds_6_tfcompanyname)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Employeelistds_7_tfcompanyname_sel)) && ! ( StringUtil.StrCmp(AV64Employeelistds_7_tfcompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName = ( :AV64Employeelistds_7_tfcompanyname_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV64Employeelistds_7_tfcompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CompanyName))=0))");
         }
         if ( AV65Employeelistds_8_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = TRUE)");
         }
         if ( AV65Employeelistds_8_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = FALSE)");
         }
         if ( AV66Employeelistds_9_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         }
         if ( AV66Employeelistds_9_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV67Employeelistds_10_tfemployeevactiondays) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays >= :AV67Employeelistds_10_tfemployeevactiondays)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV68Employeelistds_11_tfemployeevactiondays_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays <= :AV68Employeelistds_11_tfemployeevactiondays_to)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007S3( IGxContext context ,
                                             string AV58Employeelistds_1_filterfulltext ,
                                             string AV60Employeelistds_3_tfemployeename_sel ,
                                             string AV59Employeelistds_2_tfemployeename ,
                                             string AV62Employeelistds_5_tfemployeeemail_sel ,
                                             string AV61Employeelistds_4_tfemployeeemail ,
                                             string AV64Employeelistds_7_tfcompanyname_sel ,
                                             string AV63Employeelistds_6_tfcompanyname ,
                                             short AV65Employeelistds_8_tfemployeeismanager_sel ,
                                             short AV66Employeelistds_9_tfemployeeisactive_sel ,
                                             decimal AV67Employeelistds_10_tfemployeevactiondays ,
                                             decimal AV68Employeelistds_11_tfemployeevactiondays_to ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             string A101CompanyName ,
                                             decimal A146EmployeeVactionDays ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T1.EmployeeEmail, T1.EmployeeVactionDays, T1.EmployeeIsActive, T1.EmployeeIsManager, T2.CompanyName, T1.EmployeeName, T1.EmployeeId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Employeelistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.EmployeeName like '%' || :lV58Employeelistds_1_filterfulltext) or ( T1.EmployeeEmail like '%' || :lV58Employeelistds_1_filterfulltext) or ( T2.CompanyName like '%' || :lV58Employeelistds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.EmployeeVactionDays,'90.9'), 2) like '%' || :lV58Employeelistds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Employeelistds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Employeelistds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName like :lV59Employeelistds_2_tfemployeename)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Employeelistds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV60Employeelistds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName = ( :AV60Employeelistds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV60Employeelistds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Employeelistds_5_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Employeelistds_4_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail like :lV61Employeelistds_4_tfemployeeemail)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Employeelistds_5_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV62Employeelistds_5_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail = ( :AV62Employeelistds_5_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV62Employeelistds_5_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Employeelistds_7_tfcompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Employeelistds_6_tfcompanyname)) ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName like :lV63Employeelistds_6_tfcompanyname)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Employeelistds_7_tfcompanyname_sel)) && ! ( StringUtil.StrCmp(AV64Employeelistds_7_tfcompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName = ( :AV64Employeelistds_7_tfcompanyname_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV64Employeelistds_7_tfcompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CompanyName))=0))");
         }
         if ( AV65Employeelistds_8_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = TRUE)");
         }
         if ( AV65Employeelistds_8_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = FALSE)");
         }
         if ( AV66Employeelistds_9_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         }
         if ( AV66Employeelistds_9_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV67Employeelistds_10_tfemployeevactiondays) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays >= :AV67Employeelistds_10_tfemployeevactiondays)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV68Employeelistds_11_tfemployeevactiondays_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays <= :AV68Employeelistds_11_tfemployeevactiondays_to)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeEmail";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P007S4( IGxContext context ,
                                             string AV58Employeelistds_1_filterfulltext ,
                                             string AV60Employeelistds_3_tfemployeename_sel ,
                                             string AV59Employeelistds_2_tfemployeename ,
                                             string AV62Employeelistds_5_tfemployeeemail_sel ,
                                             string AV61Employeelistds_4_tfemployeeemail ,
                                             string AV64Employeelistds_7_tfcompanyname_sel ,
                                             string AV63Employeelistds_6_tfcompanyname ,
                                             short AV65Employeelistds_8_tfemployeeismanager_sel ,
                                             short AV66Employeelistds_9_tfemployeeisactive_sel ,
                                             decimal AV67Employeelistds_10_tfemployeevactiondays ,
                                             decimal AV68Employeelistds_11_tfemployeevactiondays_to ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             string A101CompanyName ,
                                             decimal A146EmployeeVactionDays ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[12];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T1.EmployeeVactionDays, T1.EmployeeIsActive, T1.EmployeeIsManager, T2.CompanyName, T1.EmployeeEmail, T1.EmployeeName, T1.EmployeeId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Employeelistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.EmployeeName like '%' || :lV58Employeelistds_1_filterfulltext) or ( T1.EmployeeEmail like '%' || :lV58Employeelistds_1_filterfulltext) or ( T2.CompanyName like '%' || :lV58Employeelistds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.EmployeeVactionDays,'90.9'), 2) like '%' || :lV58Employeelistds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Employeelistds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Employeelistds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName like :lV59Employeelistds_2_tfemployeename)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Employeelistds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV60Employeelistds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName = ( :AV60Employeelistds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV60Employeelistds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Employeelistds_5_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Employeelistds_4_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail like :lV61Employeelistds_4_tfemployeeemail)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Employeelistds_5_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV62Employeelistds_5_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail = ( :AV62Employeelistds_5_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV62Employeelistds_5_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Employeelistds_7_tfcompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Employeelistds_6_tfcompanyname)) ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName like :lV63Employeelistds_6_tfcompanyname)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Employeelistds_7_tfcompanyname_sel)) && ! ( StringUtil.StrCmp(AV64Employeelistds_7_tfcompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName = ( :AV64Employeelistds_7_tfcompanyname_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV64Employeelistds_7_tfcompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CompanyName))=0))");
         }
         if ( AV65Employeelistds_8_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = TRUE)");
         }
         if ( AV65Employeelistds_8_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = FALSE)");
         }
         if ( AV66Employeelistds_9_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         }
         if ( AV66Employeelistds_9_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV67Employeelistds_10_tfemployeevactiondays) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays >= :AV67Employeelistds_10_tfemployeevactiondays)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV68Employeelistds_11_tfemployeevactiondays_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays <= :AV68Employeelistds_11_tfemployeevactiondays_to)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.CompanyId";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P007S2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (bool)dynConstraints[15] , (bool)dynConstraints[16] );
               case 1 :
                     return conditional_P007S3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (bool)dynConstraints[15] , (bool)dynConstraints[16] );
               case 2 :
                     return conditional_P007S4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (bool)dynConstraints[15] , (bool)dynConstraints[16] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007S2;
          prmP007S2 = new Object[] {
          new ParDef("lV58Employeelistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Employeelistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Employeelistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Employeelistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Employeelistds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV60Employeelistds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV61Employeelistds_4_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV62Employeelistds_5_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Employeelistds_6_tfcompanyname",GXType.Char,100,0) ,
          new ParDef("AV64Employeelistds_7_tfcompanyname_sel",GXType.Char,100,0) ,
          new ParDef("AV67Employeelistds_10_tfemployeevactiondays",GXType.Number,4,1) ,
          new ParDef("AV68Employeelistds_11_tfemployeevactiondays_to",GXType.Number,4,1)
          };
          Object[] prmP007S3;
          prmP007S3 = new Object[] {
          new ParDef("lV58Employeelistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Employeelistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Employeelistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Employeelistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Employeelistds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV60Employeelistds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV61Employeelistds_4_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV62Employeelistds_5_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Employeelistds_6_tfcompanyname",GXType.Char,100,0) ,
          new ParDef("AV64Employeelistds_7_tfcompanyname_sel",GXType.Char,100,0) ,
          new ParDef("AV67Employeelistds_10_tfemployeevactiondays",GXType.Number,4,1) ,
          new ParDef("AV68Employeelistds_11_tfemployeevactiondays_to",GXType.Number,4,1)
          };
          Object[] prmP007S4;
          prmP007S4 = new Object[] {
          new ParDef("lV58Employeelistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Employeelistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Employeelistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Employeelistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Employeelistds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV60Employeelistds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV61Employeelistds_4_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV62Employeelistds_5_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV63Employeelistds_6_tfcompanyname",GXType.Char,100,0) ,
          new ParDef("AV64Employeelistds_7_tfcompanyname_sel",GXType.Char,100,0) ,
          new ParDef("AV67Employeelistds_10_tfemployeevactiondays",GXType.Number,4,1) ,
          new ParDef("AV68Employeelistds_11_tfemployeevactiondays_to",GXType.Number,4,1)
          };
          def= new CursorDef[] {
              new CursorDef("P007S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007S2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007S3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007S3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007S4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007S4,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
