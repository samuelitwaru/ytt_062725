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
   public class auditwwgetfilterdata : GXProcedure
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
            return "auditww_Services_Execute" ;
         }

      }

      public auditwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public auditwwgetfilterdata( IGxContext context )
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
         this.AV44DDOName = aP0_DDOName;
         this.AV45SearchTxtParms = aP1_SearchTxtParms;
         this.AV46SearchTxtTo = aP2_SearchTxtTo;
         this.AV47OptionsJson = "" ;
         this.AV48OptionsDescJson = "" ;
         this.AV49OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV47OptionsJson;
         aP4_OptionsDescJson=this.AV48OptionsDescJson;
         aP5_OptionIndexesJson=this.AV49OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV49OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV44DDOName = aP0_DDOName;
         this.AV45SearchTxtParms = aP1_SearchTxtParms;
         this.AV46SearchTxtTo = aP2_SearchTxtTo;
         this.AV47OptionsJson = "" ;
         this.AV48OptionsDescJson = "" ;
         this.AV49OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV47OptionsJson;
         aP4_OptionsDescJson=this.AV48OptionsDescJson;
         aP5_OptionIndexesJson=this.AV49OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV34Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV37OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31MaxItems = 10;
         AV30PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV45SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV45SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV28SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV45SearchTxtParms)) ? "" : StringUtil.Substring( AV45SearchTxtParms, 3, -1));
         AV29SkipItems = (short)(AV30PageIndex*AV31MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_AUDITTABLENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADAUDITTABLENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_AUDITDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADAUDITDESCRIPTIONOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_AUDITSHORTDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADAUDITSHORTDESCRIPTIONOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_AUDITACTION") == 0 )
         {
            /* Execute user subroutine: 'LOADAUDITACTIONOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_EMPLOYEENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEENAMEOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV47OptionsJson = AV34Options.ToJSonString(false);
         AV48OptionsDescJson = AV36OptionsDesc.ToJSonString(false);
         AV49OptionIndexesJson = AV37OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV39Session.Get("AuditWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "AuditWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV39Session.Get("AuditWWGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV50FilterFullText = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFAUDITID") == 0 )
            {
               AV10TFAuditId = (long)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV11TFAuditId_To = (long)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFAUDITDATE") == 0 )
            {
               AV12TFAuditDate = context.localUtil.CToD( AV42GridStateFilterValue.gxTpr_Value, 2);
               AV13TFAuditDate_To = context.localUtil.CToD( AV42GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFAUDITTABLENAME") == 0 )
            {
               AV14TFAuditTableName = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFAUDITTABLENAME_SEL") == 0 )
            {
               AV15TFAuditTableName_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFAUDITDESCRIPTION") == 0 )
            {
               AV16TFAuditDescription = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFAUDITDESCRIPTION_SEL") == 0 )
            {
               AV17TFAuditDescription_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION") == 0 )
            {
               AV18TFAuditShortDescription = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION_SEL") == 0 )
            {
               AV19TFAuditShortDescription_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFAUDITACTION") == 0 )
            {
               AV20TFAuditAction = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFAUDITACTION_SEL") == 0 )
            {
               AV21TFAuditAction_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECUSERID") == 0 )
            {
               AV22TFSecUserId = (long)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV23TFSecUserId_To = (long)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEID") == 0 )
            {
               AV24TFEmployeeId = (long)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV25TFEmployeeId_To = (long)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV26TFEmployeeName = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV27TFEmployeeName_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADAUDITTABLENAMEOPTIONS' Routine */
         returnInSub = false;
         AV14TFAuditTableName = AV28SearchTxt;
         AV15TFAuditTableName_Sel = "";
         AV53Auditwwds_1_filterfulltext = AV50FilterFullText;
         AV54Auditwwds_2_tfauditid = AV10TFAuditId;
         AV55Auditwwds_3_tfauditid_to = AV11TFAuditId_To;
         AV56Auditwwds_4_tfauditdate = AV12TFAuditDate;
         AV57Auditwwds_5_tfauditdate_to = AV13TFAuditDate_To;
         AV58Auditwwds_6_tfaudittablename = AV14TFAuditTableName;
         AV59Auditwwds_7_tfaudittablename_sel = AV15TFAuditTableName_Sel;
         AV60Auditwwds_8_tfauditdescription = AV16TFAuditDescription;
         AV61Auditwwds_9_tfauditdescription_sel = AV17TFAuditDescription_Sel;
         AV62Auditwwds_10_tfauditshortdescription = AV18TFAuditShortDescription;
         AV63Auditwwds_11_tfauditshortdescription_sel = AV19TFAuditShortDescription_Sel;
         AV64Auditwwds_12_tfauditaction = AV20TFAuditAction;
         AV65Auditwwds_13_tfauditaction_sel = AV21TFAuditAction_Sel;
         AV66Auditwwds_14_tfsecuserid = AV22TFSecUserId;
         AV67Auditwwds_15_tfsecuserid_to = AV23TFSecUserId_To;
         AV68Auditwwds_16_tfemployeeid = AV24TFEmployeeId;
         AV69Auditwwds_17_tfemployeeid_to = AV25TFEmployeeId_To;
         AV70Auditwwds_18_tfemployeename = AV26TFEmployeeName;
         AV71Auditwwds_19_tfemployeename_sel = AV27TFEmployeeName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV53Auditwwds_1_filterfulltext ,
                                              AV54Auditwwds_2_tfauditid ,
                                              AV55Auditwwds_3_tfauditid_to ,
                                              AV56Auditwwds_4_tfauditdate ,
                                              AV57Auditwwds_5_tfauditdate_to ,
                                              AV59Auditwwds_7_tfaudittablename_sel ,
                                              AV58Auditwwds_6_tfaudittablename ,
                                              AV61Auditwwds_9_tfauditdescription_sel ,
                                              AV60Auditwwds_8_tfauditdescription ,
                                              AV63Auditwwds_11_tfauditshortdescription_sel ,
                                              AV62Auditwwds_10_tfauditshortdescription ,
                                              AV65Auditwwds_13_tfauditaction_sel ,
                                              AV64Auditwwds_12_tfauditaction ,
                                              AV66Auditwwds_14_tfsecuserid ,
                                              AV67Auditwwds_15_tfsecuserid_to ,
                                              AV68Auditwwds_16_tfemployeeid ,
                                              AV69Auditwwds_17_tfemployeeid_to ,
                                              AV71Auditwwds_19_tfemployeename_sel ,
                                              AV70Auditwwds_18_tfemployeename ,
                                              A204AuditId ,
                                              A206AuditTableName ,
                                              A207AuditDescription ,
                                              A208AuditShortDescription ,
                                              A209AuditAction ,
                                              A210SecUserId ,
                                              A106EmployeeId ,
                                              A148EmployeeName ,
                                              A205AuditDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.DATE
                                              }
         });
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV58Auditwwds_6_tfaudittablename = StringUtil.PadR( StringUtil.RTrim( AV58Auditwwds_6_tfaudittablename), 100, "%");
         lV60Auditwwds_8_tfauditdescription = StringUtil.Concat( StringUtil.RTrim( AV60Auditwwds_8_tfauditdescription), "%", "");
         lV62Auditwwds_10_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_10_tfauditshortdescription), "%", "");
         lV64Auditwwds_12_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV64Auditwwds_12_tfauditaction), "%", "");
         lV70Auditwwds_18_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV70Auditwwds_18_tfemployeename), 100, "%");
         /* Using cursor P00BU2 */
         pr_default.execute(0, new Object[] {lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, AV54Auditwwds_2_tfauditid, AV55Auditwwds_3_tfauditid_to, AV56Auditwwds_4_tfauditdate, AV57Auditwwds_5_tfauditdate_to, lV58Auditwwds_6_tfaudittablename, AV59Auditwwds_7_tfaudittablename_sel, lV60Auditwwds_8_tfauditdescription, AV61Auditwwds_9_tfauditdescription_sel, lV62Auditwwds_10_tfauditshortdescription, AV63Auditwwds_11_tfauditshortdescription_sel, lV64Auditwwds_12_tfauditaction, AV65Auditwwds_13_tfauditaction_sel, AV66Auditwwds_14_tfsecuserid, AV67Auditwwds_15_tfsecuserid_to, AV68Auditwwds_16_tfemployeeid, AV69Auditwwds_17_tfemployeeid_to, lV70Auditwwds_18_tfemployeename, AV71Auditwwds_19_tfemployeename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKBU2 = false;
            A206AuditTableName = P00BU2_A206AuditTableName[0];
            A148EmployeeName = P00BU2_A148EmployeeName[0];
            A106EmployeeId = P00BU2_A106EmployeeId[0];
            A210SecUserId = P00BU2_A210SecUserId[0];
            A209AuditAction = P00BU2_A209AuditAction[0];
            A208AuditShortDescription = P00BU2_A208AuditShortDescription[0];
            A207AuditDescription = P00BU2_A207AuditDescription[0];
            A205AuditDate = P00BU2_A205AuditDate[0];
            A204AuditId = P00BU2_A204AuditId[0];
            A148EmployeeName = P00BU2_A148EmployeeName[0];
            AV38count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00BU2_A206AuditTableName[0], A206AuditTableName) == 0 ) )
            {
               BRKBU2 = false;
               A204AuditId = P00BU2_A204AuditId[0];
               AV38count = (long)(AV38count+1);
               BRKBU2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A206AuditTableName)) ? "<#Empty#>" : A206AuditTableName);
               AV34Options.Add(AV33Option, 0);
               AV37OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV34Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV29SkipItems = (short)(AV29SkipItems-1);
            }
            if ( ! BRKBU2 )
            {
               BRKBU2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADAUDITDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV16TFAuditDescription = AV28SearchTxt;
         AV17TFAuditDescription_Sel = "";
         AV53Auditwwds_1_filterfulltext = AV50FilterFullText;
         AV54Auditwwds_2_tfauditid = AV10TFAuditId;
         AV55Auditwwds_3_tfauditid_to = AV11TFAuditId_To;
         AV56Auditwwds_4_tfauditdate = AV12TFAuditDate;
         AV57Auditwwds_5_tfauditdate_to = AV13TFAuditDate_To;
         AV58Auditwwds_6_tfaudittablename = AV14TFAuditTableName;
         AV59Auditwwds_7_tfaudittablename_sel = AV15TFAuditTableName_Sel;
         AV60Auditwwds_8_tfauditdescription = AV16TFAuditDescription;
         AV61Auditwwds_9_tfauditdescription_sel = AV17TFAuditDescription_Sel;
         AV62Auditwwds_10_tfauditshortdescription = AV18TFAuditShortDescription;
         AV63Auditwwds_11_tfauditshortdescription_sel = AV19TFAuditShortDescription_Sel;
         AV64Auditwwds_12_tfauditaction = AV20TFAuditAction;
         AV65Auditwwds_13_tfauditaction_sel = AV21TFAuditAction_Sel;
         AV66Auditwwds_14_tfsecuserid = AV22TFSecUserId;
         AV67Auditwwds_15_tfsecuserid_to = AV23TFSecUserId_To;
         AV68Auditwwds_16_tfemployeeid = AV24TFEmployeeId;
         AV69Auditwwds_17_tfemployeeid_to = AV25TFEmployeeId_To;
         AV70Auditwwds_18_tfemployeename = AV26TFEmployeeName;
         AV71Auditwwds_19_tfemployeename_sel = AV27TFEmployeeName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV53Auditwwds_1_filterfulltext ,
                                              AV54Auditwwds_2_tfauditid ,
                                              AV55Auditwwds_3_tfauditid_to ,
                                              AV56Auditwwds_4_tfauditdate ,
                                              AV57Auditwwds_5_tfauditdate_to ,
                                              AV59Auditwwds_7_tfaudittablename_sel ,
                                              AV58Auditwwds_6_tfaudittablename ,
                                              AV61Auditwwds_9_tfauditdescription_sel ,
                                              AV60Auditwwds_8_tfauditdescription ,
                                              AV63Auditwwds_11_tfauditshortdescription_sel ,
                                              AV62Auditwwds_10_tfauditshortdescription ,
                                              AV65Auditwwds_13_tfauditaction_sel ,
                                              AV64Auditwwds_12_tfauditaction ,
                                              AV66Auditwwds_14_tfsecuserid ,
                                              AV67Auditwwds_15_tfsecuserid_to ,
                                              AV68Auditwwds_16_tfemployeeid ,
                                              AV69Auditwwds_17_tfemployeeid_to ,
                                              AV71Auditwwds_19_tfemployeename_sel ,
                                              AV70Auditwwds_18_tfemployeename ,
                                              A204AuditId ,
                                              A206AuditTableName ,
                                              A207AuditDescription ,
                                              A208AuditShortDescription ,
                                              A209AuditAction ,
                                              A210SecUserId ,
                                              A106EmployeeId ,
                                              A148EmployeeName ,
                                              A205AuditDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.DATE
                                              }
         });
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV58Auditwwds_6_tfaudittablename = StringUtil.PadR( StringUtil.RTrim( AV58Auditwwds_6_tfaudittablename), 100, "%");
         lV60Auditwwds_8_tfauditdescription = StringUtil.Concat( StringUtil.RTrim( AV60Auditwwds_8_tfauditdescription), "%", "");
         lV62Auditwwds_10_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_10_tfauditshortdescription), "%", "");
         lV64Auditwwds_12_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV64Auditwwds_12_tfauditaction), "%", "");
         lV70Auditwwds_18_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV70Auditwwds_18_tfemployeename), 100, "%");
         /* Using cursor P00BU3 */
         pr_default.execute(1, new Object[] {lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, AV54Auditwwds_2_tfauditid, AV55Auditwwds_3_tfauditid_to, AV56Auditwwds_4_tfauditdate, AV57Auditwwds_5_tfauditdate_to, lV58Auditwwds_6_tfaudittablename, AV59Auditwwds_7_tfaudittablename_sel, lV60Auditwwds_8_tfauditdescription, AV61Auditwwds_9_tfauditdescription_sel, lV62Auditwwds_10_tfauditshortdescription, AV63Auditwwds_11_tfauditshortdescription_sel, lV64Auditwwds_12_tfauditaction, AV65Auditwwds_13_tfauditaction_sel, AV66Auditwwds_14_tfsecuserid, AV67Auditwwds_15_tfsecuserid_to, AV68Auditwwds_16_tfemployeeid, AV69Auditwwds_17_tfemployeeid_to, lV70Auditwwds_18_tfemployeename, AV71Auditwwds_19_tfemployeename_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKBU4 = false;
            A207AuditDescription = P00BU3_A207AuditDescription[0];
            A148EmployeeName = P00BU3_A148EmployeeName[0];
            A106EmployeeId = P00BU3_A106EmployeeId[0];
            A210SecUserId = P00BU3_A210SecUserId[0];
            A209AuditAction = P00BU3_A209AuditAction[0];
            A208AuditShortDescription = P00BU3_A208AuditShortDescription[0];
            A206AuditTableName = P00BU3_A206AuditTableName[0];
            A205AuditDate = P00BU3_A205AuditDate[0];
            A204AuditId = P00BU3_A204AuditId[0];
            A148EmployeeName = P00BU3_A148EmployeeName[0];
            AV38count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00BU3_A207AuditDescription[0], A207AuditDescription) == 0 ) )
            {
               BRKBU4 = false;
               A204AuditId = P00BU3_A204AuditId[0];
               AV38count = (long)(AV38count+1);
               BRKBU4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A207AuditDescription)) ? "<#Empty#>" : A207AuditDescription);
               AV34Options.Add(AV33Option, 0);
               AV37OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV34Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV29SkipItems = (short)(AV29SkipItems-1);
            }
            if ( ! BRKBU4 )
            {
               BRKBU4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADAUDITSHORTDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV18TFAuditShortDescription = AV28SearchTxt;
         AV19TFAuditShortDescription_Sel = "";
         AV53Auditwwds_1_filterfulltext = AV50FilterFullText;
         AV54Auditwwds_2_tfauditid = AV10TFAuditId;
         AV55Auditwwds_3_tfauditid_to = AV11TFAuditId_To;
         AV56Auditwwds_4_tfauditdate = AV12TFAuditDate;
         AV57Auditwwds_5_tfauditdate_to = AV13TFAuditDate_To;
         AV58Auditwwds_6_tfaudittablename = AV14TFAuditTableName;
         AV59Auditwwds_7_tfaudittablename_sel = AV15TFAuditTableName_Sel;
         AV60Auditwwds_8_tfauditdescription = AV16TFAuditDescription;
         AV61Auditwwds_9_tfauditdescription_sel = AV17TFAuditDescription_Sel;
         AV62Auditwwds_10_tfauditshortdescription = AV18TFAuditShortDescription;
         AV63Auditwwds_11_tfauditshortdescription_sel = AV19TFAuditShortDescription_Sel;
         AV64Auditwwds_12_tfauditaction = AV20TFAuditAction;
         AV65Auditwwds_13_tfauditaction_sel = AV21TFAuditAction_Sel;
         AV66Auditwwds_14_tfsecuserid = AV22TFSecUserId;
         AV67Auditwwds_15_tfsecuserid_to = AV23TFSecUserId_To;
         AV68Auditwwds_16_tfemployeeid = AV24TFEmployeeId;
         AV69Auditwwds_17_tfemployeeid_to = AV25TFEmployeeId_To;
         AV70Auditwwds_18_tfemployeename = AV26TFEmployeeName;
         AV71Auditwwds_19_tfemployeename_sel = AV27TFEmployeeName_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV53Auditwwds_1_filterfulltext ,
                                              AV54Auditwwds_2_tfauditid ,
                                              AV55Auditwwds_3_tfauditid_to ,
                                              AV56Auditwwds_4_tfauditdate ,
                                              AV57Auditwwds_5_tfauditdate_to ,
                                              AV59Auditwwds_7_tfaudittablename_sel ,
                                              AV58Auditwwds_6_tfaudittablename ,
                                              AV61Auditwwds_9_tfauditdescription_sel ,
                                              AV60Auditwwds_8_tfauditdescription ,
                                              AV63Auditwwds_11_tfauditshortdescription_sel ,
                                              AV62Auditwwds_10_tfauditshortdescription ,
                                              AV65Auditwwds_13_tfauditaction_sel ,
                                              AV64Auditwwds_12_tfauditaction ,
                                              AV66Auditwwds_14_tfsecuserid ,
                                              AV67Auditwwds_15_tfsecuserid_to ,
                                              AV68Auditwwds_16_tfemployeeid ,
                                              AV69Auditwwds_17_tfemployeeid_to ,
                                              AV71Auditwwds_19_tfemployeename_sel ,
                                              AV70Auditwwds_18_tfemployeename ,
                                              A204AuditId ,
                                              A206AuditTableName ,
                                              A207AuditDescription ,
                                              A208AuditShortDescription ,
                                              A209AuditAction ,
                                              A210SecUserId ,
                                              A106EmployeeId ,
                                              A148EmployeeName ,
                                              A205AuditDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.DATE
                                              }
         });
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV58Auditwwds_6_tfaudittablename = StringUtil.PadR( StringUtil.RTrim( AV58Auditwwds_6_tfaudittablename), 100, "%");
         lV60Auditwwds_8_tfauditdescription = StringUtil.Concat( StringUtil.RTrim( AV60Auditwwds_8_tfauditdescription), "%", "");
         lV62Auditwwds_10_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_10_tfauditshortdescription), "%", "");
         lV64Auditwwds_12_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV64Auditwwds_12_tfauditaction), "%", "");
         lV70Auditwwds_18_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV70Auditwwds_18_tfemployeename), 100, "%");
         /* Using cursor P00BU4 */
         pr_default.execute(2, new Object[] {lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, AV54Auditwwds_2_tfauditid, AV55Auditwwds_3_tfauditid_to, AV56Auditwwds_4_tfauditdate, AV57Auditwwds_5_tfauditdate_to, lV58Auditwwds_6_tfaudittablename, AV59Auditwwds_7_tfaudittablename_sel, lV60Auditwwds_8_tfauditdescription, AV61Auditwwds_9_tfauditdescription_sel, lV62Auditwwds_10_tfauditshortdescription, AV63Auditwwds_11_tfauditshortdescription_sel, lV64Auditwwds_12_tfauditaction, AV65Auditwwds_13_tfauditaction_sel, AV66Auditwwds_14_tfsecuserid, AV67Auditwwds_15_tfsecuserid_to, AV68Auditwwds_16_tfemployeeid, AV69Auditwwds_17_tfemployeeid_to, lV70Auditwwds_18_tfemployeename, AV71Auditwwds_19_tfemployeename_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKBU6 = false;
            A208AuditShortDescription = P00BU4_A208AuditShortDescription[0];
            A148EmployeeName = P00BU4_A148EmployeeName[0];
            A106EmployeeId = P00BU4_A106EmployeeId[0];
            A210SecUserId = P00BU4_A210SecUserId[0];
            A209AuditAction = P00BU4_A209AuditAction[0];
            A207AuditDescription = P00BU4_A207AuditDescription[0];
            A206AuditTableName = P00BU4_A206AuditTableName[0];
            A205AuditDate = P00BU4_A205AuditDate[0];
            A204AuditId = P00BU4_A204AuditId[0];
            A148EmployeeName = P00BU4_A148EmployeeName[0];
            AV38count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00BU4_A208AuditShortDescription[0], A208AuditShortDescription) == 0 ) )
            {
               BRKBU6 = false;
               A204AuditId = P00BU4_A204AuditId[0];
               AV38count = (long)(AV38count+1);
               BRKBU6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A208AuditShortDescription)) ? "<#Empty#>" : A208AuditShortDescription);
               AV34Options.Add(AV33Option, 0);
               AV37OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV34Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV29SkipItems = (short)(AV29SkipItems-1);
            }
            if ( ! BRKBU6 )
            {
               BRKBU6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADAUDITACTIONOPTIONS' Routine */
         returnInSub = false;
         AV20TFAuditAction = AV28SearchTxt;
         AV21TFAuditAction_Sel = "";
         AV53Auditwwds_1_filterfulltext = AV50FilterFullText;
         AV54Auditwwds_2_tfauditid = AV10TFAuditId;
         AV55Auditwwds_3_tfauditid_to = AV11TFAuditId_To;
         AV56Auditwwds_4_tfauditdate = AV12TFAuditDate;
         AV57Auditwwds_5_tfauditdate_to = AV13TFAuditDate_To;
         AV58Auditwwds_6_tfaudittablename = AV14TFAuditTableName;
         AV59Auditwwds_7_tfaudittablename_sel = AV15TFAuditTableName_Sel;
         AV60Auditwwds_8_tfauditdescription = AV16TFAuditDescription;
         AV61Auditwwds_9_tfauditdescription_sel = AV17TFAuditDescription_Sel;
         AV62Auditwwds_10_tfauditshortdescription = AV18TFAuditShortDescription;
         AV63Auditwwds_11_tfauditshortdescription_sel = AV19TFAuditShortDescription_Sel;
         AV64Auditwwds_12_tfauditaction = AV20TFAuditAction;
         AV65Auditwwds_13_tfauditaction_sel = AV21TFAuditAction_Sel;
         AV66Auditwwds_14_tfsecuserid = AV22TFSecUserId;
         AV67Auditwwds_15_tfsecuserid_to = AV23TFSecUserId_To;
         AV68Auditwwds_16_tfemployeeid = AV24TFEmployeeId;
         AV69Auditwwds_17_tfemployeeid_to = AV25TFEmployeeId_To;
         AV70Auditwwds_18_tfemployeename = AV26TFEmployeeName;
         AV71Auditwwds_19_tfemployeename_sel = AV27TFEmployeeName_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV53Auditwwds_1_filterfulltext ,
                                              AV54Auditwwds_2_tfauditid ,
                                              AV55Auditwwds_3_tfauditid_to ,
                                              AV56Auditwwds_4_tfauditdate ,
                                              AV57Auditwwds_5_tfauditdate_to ,
                                              AV59Auditwwds_7_tfaudittablename_sel ,
                                              AV58Auditwwds_6_tfaudittablename ,
                                              AV61Auditwwds_9_tfauditdescription_sel ,
                                              AV60Auditwwds_8_tfauditdescription ,
                                              AV63Auditwwds_11_tfauditshortdescription_sel ,
                                              AV62Auditwwds_10_tfauditshortdescription ,
                                              AV65Auditwwds_13_tfauditaction_sel ,
                                              AV64Auditwwds_12_tfauditaction ,
                                              AV66Auditwwds_14_tfsecuserid ,
                                              AV67Auditwwds_15_tfsecuserid_to ,
                                              AV68Auditwwds_16_tfemployeeid ,
                                              AV69Auditwwds_17_tfemployeeid_to ,
                                              AV71Auditwwds_19_tfemployeename_sel ,
                                              AV70Auditwwds_18_tfemployeename ,
                                              A204AuditId ,
                                              A206AuditTableName ,
                                              A207AuditDescription ,
                                              A208AuditShortDescription ,
                                              A209AuditAction ,
                                              A210SecUserId ,
                                              A106EmployeeId ,
                                              A148EmployeeName ,
                                              A205AuditDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.DATE
                                              }
         });
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV58Auditwwds_6_tfaudittablename = StringUtil.PadR( StringUtil.RTrim( AV58Auditwwds_6_tfaudittablename), 100, "%");
         lV60Auditwwds_8_tfauditdescription = StringUtil.Concat( StringUtil.RTrim( AV60Auditwwds_8_tfauditdescription), "%", "");
         lV62Auditwwds_10_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_10_tfauditshortdescription), "%", "");
         lV64Auditwwds_12_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV64Auditwwds_12_tfauditaction), "%", "");
         lV70Auditwwds_18_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV70Auditwwds_18_tfemployeename), 100, "%");
         /* Using cursor P00BU5 */
         pr_default.execute(3, new Object[] {lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, AV54Auditwwds_2_tfauditid, AV55Auditwwds_3_tfauditid_to, AV56Auditwwds_4_tfauditdate, AV57Auditwwds_5_tfauditdate_to, lV58Auditwwds_6_tfaudittablename, AV59Auditwwds_7_tfaudittablename_sel, lV60Auditwwds_8_tfauditdescription, AV61Auditwwds_9_tfauditdescription_sel, lV62Auditwwds_10_tfauditshortdescription, AV63Auditwwds_11_tfauditshortdescription_sel, lV64Auditwwds_12_tfauditaction, AV65Auditwwds_13_tfauditaction_sel, AV66Auditwwds_14_tfsecuserid, AV67Auditwwds_15_tfsecuserid_to, AV68Auditwwds_16_tfemployeeid, AV69Auditwwds_17_tfemployeeid_to, lV70Auditwwds_18_tfemployeename, AV71Auditwwds_19_tfemployeename_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKBU8 = false;
            A209AuditAction = P00BU5_A209AuditAction[0];
            A148EmployeeName = P00BU5_A148EmployeeName[0];
            A106EmployeeId = P00BU5_A106EmployeeId[0];
            A210SecUserId = P00BU5_A210SecUserId[0];
            A208AuditShortDescription = P00BU5_A208AuditShortDescription[0];
            A207AuditDescription = P00BU5_A207AuditDescription[0];
            A206AuditTableName = P00BU5_A206AuditTableName[0];
            A205AuditDate = P00BU5_A205AuditDate[0];
            A204AuditId = P00BU5_A204AuditId[0];
            A148EmployeeName = P00BU5_A148EmployeeName[0];
            AV38count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00BU5_A209AuditAction[0], A209AuditAction) == 0 ) )
            {
               BRKBU8 = false;
               A204AuditId = P00BU5_A204AuditId[0];
               AV38count = (long)(AV38count+1);
               BRKBU8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A209AuditAction)) ? "<#Empty#>" : A209AuditAction);
               AV34Options.Add(AV33Option, 0);
               AV37OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV34Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV29SkipItems = (short)(AV29SkipItems-1);
            }
            if ( ! BRKBU8 )
            {
               BRKBU8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADEMPLOYEENAMEOPTIONS' Routine */
         returnInSub = false;
         AV26TFEmployeeName = AV28SearchTxt;
         AV27TFEmployeeName_Sel = "";
         AV53Auditwwds_1_filterfulltext = AV50FilterFullText;
         AV54Auditwwds_2_tfauditid = AV10TFAuditId;
         AV55Auditwwds_3_tfauditid_to = AV11TFAuditId_To;
         AV56Auditwwds_4_tfauditdate = AV12TFAuditDate;
         AV57Auditwwds_5_tfauditdate_to = AV13TFAuditDate_To;
         AV58Auditwwds_6_tfaudittablename = AV14TFAuditTableName;
         AV59Auditwwds_7_tfaudittablename_sel = AV15TFAuditTableName_Sel;
         AV60Auditwwds_8_tfauditdescription = AV16TFAuditDescription;
         AV61Auditwwds_9_tfauditdescription_sel = AV17TFAuditDescription_Sel;
         AV62Auditwwds_10_tfauditshortdescription = AV18TFAuditShortDescription;
         AV63Auditwwds_11_tfauditshortdescription_sel = AV19TFAuditShortDescription_Sel;
         AV64Auditwwds_12_tfauditaction = AV20TFAuditAction;
         AV65Auditwwds_13_tfauditaction_sel = AV21TFAuditAction_Sel;
         AV66Auditwwds_14_tfsecuserid = AV22TFSecUserId;
         AV67Auditwwds_15_tfsecuserid_to = AV23TFSecUserId_To;
         AV68Auditwwds_16_tfemployeeid = AV24TFEmployeeId;
         AV69Auditwwds_17_tfemployeeid_to = AV25TFEmployeeId_To;
         AV70Auditwwds_18_tfemployeename = AV26TFEmployeeName;
         AV71Auditwwds_19_tfemployeename_sel = AV27TFEmployeeName_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV53Auditwwds_1_filterfulltext ,
                                              AV54Auditwwds_2_tfauditid ,
                                              AV55Auditwwds_3_tfauditid_to ,
                                              AV56Auditwwds_4_tfauditdate ,
                                              AV57Auditwwds_5_tfauditdate_to ,
                                              AV59Auditwwds_7_tfaudittablename_sel ,
                                              AV58Auditwwds_6_tfaudittablename ,
                                              AV61Auditwwds_9_tfauditdescription_sel ,
                                              AV60Auditwwds_8_tfauditdescription ,
                                              AV63Auditwwds_11_tfauditshortdescription_sel ,
                                              AV62Auditwwds_10_tfauditshortdescription ,
                                              AV65Auditwwds_13_tfauditaction_sel ,
                                              AV64Auditwwds_12_tfauditaction ,
                                              AV66Auditwwds_14_tfsecuserid ,
                                              AV67Auditwwds_15_tfsecuserid_to ,
                                              AV68Auditwwds_16_tfemployeeid ,
                                              AV69Auditwwds_17_tfemployeeid_to ,
                                              AV71Auditwwds_19_tfemployeename_sel ,
                                              AV70Auditwwds_18_tfemployeename ,
                                              A204AuditId ,
                                              A206AuditTableName ,
                                              A207AuditDescription ,
                                              A208AuditShortDescription ,
                                              A209AuditAction ,
                                              A210SecUserId ,
                                              A106EmployeeId ,
                                              A148EmployeeName ,
                                              A205AuditDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.DATE
                                              }
         });
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV53Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Auditwwds_1_filterfulltext), "%", "");
         lV58Auditwwds_6_tfaudittablename = StringUtil.PadR( StringUtil.RTrim( AV58Auditwwds_6_tfaudittablename), 100, "%");
         lV60Auditwwds_8_tfauditdescription = StringUtil.Concat( StringUtil.RTrim( AV60Auditwwds_8_tfauditdescription), "%", "");
         lV62Auditwwds_10_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_10_tfauditshortdescription), "%", "");
         lV64Auditwwds_12_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV64Auditwwds_12_tfauditaction), "%", "");
         lV70Auditwwds_18_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV70Auditwwds_18_tfemployeename), 100, "%");
         /* Using cursor P00BU6 */
         pr_default.execute(4, new Object[] {lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, lV53Auditwwds_1_filterfulltext, AV54Auditwwds_2_tfauditid, AV55Auditwwds_3_tfauditid_to, AV56Auditwwds_4_tfauditdate, AV57Auditwwds_5_tfauditdate_to, lV58Auditwwds_6_tfaudittablename, AV59Auditwwds_7_tfaudittablename_sel, lV60Auditwwds_8_tfauditdescription, AV61Auditwwds_9_tfauditdescription_sel, lV62Auditwwds_10_tfauditshortdescription, AV63Auditwwds_11_tfauditshortdescription_sel, lV64Auditwwds_12_tfauditaction, AV65Auditwwds_13_tfauditaction_sel, AV66Auditwwds_14_tfsecuserid, AV67Auditwwds_15_tfsecuserid_to, AV68Auditwwds_16_tfemployeeid, AV69Auditwwds_17_tfemployeeid_to, lV70Auditwwds_18_tfemployeename, AV71Auditwwds_19_tfemployeename_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKBU10 = false;
            A148EmployeeName = P00BU6_A148EmployeeName[0];
            A106EmployeeId = P00BU6_A106EmployeeId[0];
            A210SecUserId = P00BU6_A210SecUserId[0];
            A209AuditAction = P00BU6_A209AuditAction[0];
            A208AuditShortDescription = P00BU6_A208AuditShortDescription[0];
            A207AuditDescription = P00BU6_A207AuditDescription[0];
            A206AuditTableName = P00BU6_A206AuditTableName[0];
            A205AuditDate = P00BU6_A205AuditDate[0];
            A204AuditId = P00BU6_A204AuditId[0];
            A148EmployeeName = P00BU6_A148EmployeeName[0];
            AV38count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00BU6_A148EmployeeName[0], A148EmployeeName) == 0 ) )
            {
               BRKBU10 = false;
               A106EmployeeId = P00BU6_A106EmployeeId[0];
               A204AuditId = P00BU6_A204AuditId[0];
               AV38count = (long)(AV38count+1);
               BRKBU10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A148EmployeeName)) ? "<#Empty#>" : A148EmployeeName);
               AV34Options.Add(AV33Option, 0);
               AV37OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV34Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV29SkipItems = (short)(AV29SkipItems-1);
            }
            if ( ! BRKBU10 )
            {
               BRKBU10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
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
         AV47OptionsJson = "";
         AV48OptionsDescJson = "";
         AV49OptionIndexesJson = "";
         AV34Options = new GxSimpleCollection<string>();
         AV36OptionsDesc = new GxSimpleCollection<string>();
         AV37OptionIndexes = new GxSimpleCollection<string>();
         AV28SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV39Session = context.GetSession();
         AV41GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV42GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV50FilterFullText = "";
         AV12TFAuditDate = DateTime.MinValue;
         AV13TFAuditDate_To = DateTime.MinValue;
         AV14TFAuditTableName = "";
         AV15TFAuditTableName_Sel = "";
         AV16TFAuditDescription = "";
         AV17TFAuditDescription_Sel = "";
         AV18TFAuditShortDescription = "";
         AV19TFAuditShortDescription_Sel = "";
         AV20TFAuditAction = "";
         AV21TFAuditAction_Sel = "";
         AV26TFEmployeeName = "";
         AV27TFEmployeeName_Sel = "";
         AV53Auditwwds_1_filterfulltext = "";
         AV56Auditwwds_4_tfauditdate = DateTime.MinValue;
         AV57Auditwwds_5_tfauditdate_to = DateTime.MinValue;
         AV58Auditwwds_6_tfaudittablename = "";
         AV59Auditwwds_7_tfaudittablename_sel = "";
         AV60Auditwwds_8_tfauditdescription = "";
         AV61Auditwwds_9_tfauditdescription_sel = "";
         AV62Auditwwds_10_tfauditshortdescription = "";
         AV63Auditwwds_11_tfauditshortdescription_sel = "";
         AV64Auditwwds_12_tfauditaction = "";
         AV65Auditwwds_13_tfauditaction_sel = "";
         AV70Auditwwds_18_tfemployeename = "";
         AV71Auditwwds_19_tfemployeename_sel = "";
         lV53Auditwwds_1_filterfulltext = "";
         lV58Auditwwds_6_tfaudittablename = "";
         lV60Auditwwds_8_tfauditdescription = "";
         lV62Auditwwds_10_tfauditshortdescription = "";
         lV64Auditwwds_12_tfauditaction = "";
         lV70Auditwwds_18_tfemployeename = "";
         A206AuditTableName = "";
         A207AuditDescription = "";
         A208AuditShortDescription = "";
         A209AuditAction = "";
         A148EmployeeName = "";
         A205AuditDate = DateTime.MinValue;
         P00BU2_A206AuditTableName = new string[] {""} ;
         P00BU2_A148EmployeeName = new string[] {""} ;
         P00BU2_A106EmployeeId = new long[1] ;
         P00BU2_A210SecUserId = new long[1] ;
         P00BU2_A209AuditAction = new string[] {""} ;
         P00BU2_A208AuditShortDescription = new string[] {""} ;
         P00BU2_A207AuditDescription = new string[] {""} ;
         P00BU2_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         P00BU2_A204AuditId = new long[1] ;
         AV33Option = "";
         P00BU3_A207AuditDescription = new string[] {""} ;
         P00BU3_A148EmployeeName = new string[] {""} ;
         P00BU3_A106EmployeeId = new long[1] ;
         P00BU3_A210SecUserId = new long[1] ;
         P00BU3_A209AuditAction = new string[] {""} ;
         P00BU3_A208AuditShortDescription = new string[] {""} ;
         P00BU3_A206AuditTableName = new string[] {""} ;
         P00BU3_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         P00BU3_A204AuditId = new long[1] ;
         P00BU4_A208AuditShortDescription = new string[] {""} ;
         P00BU4_A148EmployeeName = new string[] {""} ;
         P00BU4_A106EmployeeId = new long[1] ;
         P00BU4_A210SecUserId = new long[1] ;
         P00BU4_A209AuditAction = new string[] {""} ;
         P00BU4_A207AuditDescription = new string[] {""} ;
         P00BU4_A206AuditTableName = new string[] {""} ;
         P00BU4_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         P00BU4_A204AuditId = new long[1] ;
         P00BU5_A209AuditAction = new string[] {""} ;
         P00BU5_A148EmployeeName = new string[] {""} ;
         P00BU5_A106EmployeeId = new long[1] ;
         P00BU5_A210SecUserId = new long[1] ;
         P00BU5_A208AuditShortDescription = new string[] {""} ;
         P00BU5_A207AuditDescription = new string[] {""} ;
         P00BU5_A206AuditTableName = new string[] {""} ;
         P00BU5_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         P00BU5_A204AuditId = new long[1] ;
         P00BU6_A148EmployeeName = new string[] {""} ;
         P00BU6_A106EmployeeId = new long[1] ;
         P00BU6_A210SecUserId = new long[1] ;
         P00BU6_A209AuditAction = new string[] {""} ;
         P00BU6_A208AuditShortDescription = new string[] {""} ;
         P00BU6_A207AuditDescription = new string[] {""} ;
         P00BU6_A206AuditTableName = new string[] {""} ;
         P00BU6_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         P00BU6_A204AuditId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.auditwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00BU2_A206AuditTableName, P00BU2_A148EmployeeName, P00BU2_A106EmployeeId, P00BU2_A210SecUserId, P00BU2_A209AuditAction, P00BU2_A208AuditShortDescription, P00BU2_A207AuditDescription, P00BU2_A205AuditDate, P00BU2_A204AuditId
               }
               , new Object[] {
               P00BU3_A207AuditDescription, P00BU3_A148EmployeeName, P00BU3_A106EmployeeId, P00BU3_A210SecUserId, P00BU3_A209AuditAction, P00BU3_A208AuditShortDescription, P00BU3_A206AuditTableName, P00BU3_A205AuditDate, P00BU3_A204AuditId
               }
               , new Object[] {
               P00BU4_A208AuditShortDescription, P00BU4_A148EmployeeName, P00BU4_A106EmployeeId, P00BU4_A210SecUserId, P00BU4_A209AuditAction, P00BU4_A207AuditDescription, P00BU4_A206AuditTableName, P00BU4_A205AuditDate, P00BU4_A204AuditId
               }
               , new Object[] {
               P00BU5_A209AuditAction, P00BU5_A148EmployeeName, P00BU5_A106EmployeeId, P00BU5_A210SecUserId, P00BU5_A208AuditShortDescription, P00BU5_A207AuditDescription, P00BU5_A206AuditTableName, P00BU5_A205AuditDate, P00BU5_A204AuditId
               }
               , new Object[] {
               P00BU6_A148EmployeeName, P00BU6_A106EmployeeId, P00BU6_A210SecUserId, P00BU6_A209AuditAction, P00BU6_A208AuditShortDescription, P00BU6_A207AuditDescription, P00BU6_A206AuditTableName, P00BU6_A205AuditDate, P00BU6_A204AuditId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV31MaxItems ;
      private short AV30PageIndex ;
      private short AV29SkipItems ;
      private int AV51GXV1 ;
      private long AV10TFAuditId ;
      private long AV11TFAuditId_To ;
      private long AV22TFSecUserId ;
      private long AV23TFSecUserId_To ;
      private long AV24TFEmployeeId ;
      private long AV25TFEmployeeId_To ;
      private long AV54Auditwwds_2_tfauditid ;
      private long AV55Auditwwds_3_tfauditid_to ;
      private long AV66Auditwwds_14_tfsecuserid ;
      private long AV67Auditwwds_15_tfsecuserid_to ;
      private long AV68Auditwwds_16_tfemployeeid ;
      private long AV69Auditwwds_17_tfemployeeid_to ;
      private long A204AuditId ;
      private long A210SecUserId ;
      private long A106EmployeeId ;
      private long AV38count ;
      private string AV14TFAuditTableName ;
      private string AV15TFAuditTableName_Sel ;
      private string AV26TFEmployeeName ;
      private string AV27TFEmployeeName_Sel ;
      private string AV58Auditwwds_6_tfaudittablename ;
      private string AV59Auditwwds_7_tfaudittablename_sel ;
      private string AV70Auditwwds_18_tfemployeename ;
      private string AV71Auditwwds_19_tfemployeename_sel ;
      private string lV58Auditwwds_6_tfaudittablename ;
      private string lV70Auditwwds_18_tfemployeename ;
      private string A206AuditTableName ;
      private string A148EmployeeName ;
      private DateTime AV12TFAuditDate ;
      private DateTime AV13TFAuditDate_To ;
      private DateTime AV56Auditwwds_4_tfauditdate ;
      private DateTime AV57Auditwwds_5_tfauditdate_to ;
      private DateTime A205AuditDate ;
      private bool returnInSub ;
      private bool BRKBU2 ;
      private bool BRKBU4 ;
      private bool BRKBU6 ;
      private bool BRKBU8 ;
      private bool BRKBU10 ;
      private string AV47OptionsJson ;
      private string AV48OptionsDescJson ;
      private string AV49OptionIndexesJson ;
      private string AV44DDOName ;
      private string AV45SearchTxtParms ;
      private string AV46SearchTxtTo ;
      private string AV28SearchTxt ;
      private string AV50FilterFullText ;
      private string AV16TFAuditDescription ;
      private string AV17TFAuditDescription_Sel ;
      private string AV18TFAuditShortDescription ;
      private string AV19TFAuditShortDescription_Sel ;
      private string AV20TFAuditAction ;
      private string AV21TFAuditAction_Sel ;
      private string AV53Auditwwds_1_filterfulltext ;
      private string AV60Auditwwds_8_tfauditdescription ;
      private string AV61Auditwwds_9_tfauditdescription_sel ;
      private string AV62Auditwwds_10_tfauditshortdescription ;
      private string AV63Auditwwds_11_tfauditshortdescription_sel ;
      private string AV64Auditwwds_12_tfauditaction ;
      private string AV65Auditwwds_13_tfauditaction_sel ;
      private string lV53Auditwwds_1_filterfulltext ;
      private string lV60Auditwwds_8_tfauditdescription ;
      private string lV62Auditwwds_10_tfauditshortdescription ;
      private string lV64Auditwwds_12_tfauditaction ;
      private string A207AuditDescription ;
      private string A208AuditShortDescription ;
      private string A209AuditAction ;
      private string AV33Option ;
      private IGxSession AV39Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV34Options ;
      private GxSimpleCollection<string> AV36OptionsDesc ;
      private GxSimpleCollection<string> AV37OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV41GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00BU2_A206AuditTableName ;
      private string[] P00BU2_A148EmployeeName ;
      private long[] P00BU2_A106EmployeeId ;
      private long[] P00BU2_A210SecUserId ;
      private string[] P00BU2_A209AuditAction ;
      private string[] P00BU2_A208AuditShortDescription ;
      private string[] P00BU2_A207AuditDescription ;
      private DateTime[] P00BU2_A205AuditDate ;
      private long[] P00BU2_A204AuditId ;
      private string[] P00BU3_A207AuditDescription ;
      private string[] P00BU3_A148EmployeeName ;
      private long[] P00BU3_A106EmployeeId ;
      private long[] P00BU3_A210SecUserId ;
      private string[] P00BU3_A209AuditAction ;
      private string[] P00BU3_A208AuditShortDescription ;
      private string[] P00BU3_A206AuditTableName ;
      private DateTime[] P00BU3_A205AuditDate ;
      private long[] P00BU3_A204AuditId ;
      private string[] P00BU4_A208AuditShortDescription ;
      private string[] P00BU4_A148EmployeeName ;
      private long[] P00BU4_A106EmployeeId ;
      private long[] P00BU4_A210SecUserId ;
      private string[] P00BU4_A209AuditAction ;
      private string[] P00BU4_A207AuditDescription ;
      private string[] P00BU4_A206AuditTableName ;
      private DateTime[] P00BU4_A205AuditDate ;
      private long[] P00BU4_A204AuditId ;
      private string[] P00BU5_A209AuditAction ;
      private string[] P00BU5_A148EmployeeName ;
      private long[] P00BU5_A106EmployeeId ;
      private long[] P00BU5_A210SecUserId ;
      private string[] P00BU5_A208AuditShortDescription ;
      private string[] P00BU5_A207AuditDescription ;
      private string[] P00BU5_A206AuditTableName ;
      private DateTime[] P00BU5_A205AuditDate ;
      private long[] P00BU5_A204AuditId ;
      private string[] P00BU6_A148EmployeeName ;
      private long[] P00BU6_A106EmployeeId ;
      private long[] P00BU6_A210SecUserId ;
      private string[] P00BU6_A209AuditAction ;
      private string[] P00BU6_A208AuditShortDescription ;
      private string[] P00BU6_A207AuditDescription ;
      private string[] P00BU6_A206AuditTableName ;
      private DateTime[] P00BU6_A205AuditDate ;
      private long[] P00BU6_A204AuditId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class auditwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BU2( IGxContext context ,
                                             string AV53Auditwwds_1_filterfulltext ,
                                             long AV54Auditwwds_2_tfauditid ,
                                             long AV55Auditwwds_3_tfauditid_to ,
                                             DateTime AV56Auditwwds_4_tfauditdate ,
                                             DateTime AV57Auditwwds_5_tfauditdate_to ,
                                             string AV59Auditwwds_7_tfaudittablename_sel ,
                                             string AV58Auditwwds_6_tfaudittablename ,
                                             string AV61Auditwwds_9_tfauditdescription_sel ,
                                             string AV60Auditwwds_8_tfauditdescription ,
                                             string AV63Auditwwds_11_tfauditshortdescription_sel ,
                                             string AV62Auditwwds_10_tfauditshortdescription ,
                                             string AV65Auditwwds_13_tfauditaction_sel ,
                                             string AV64Auditwwds_12_tfauditaction ,
                                             long AV66Auditwwds_14_tfsecuserid ,
                                             long AV67Auditwwds_15_tfsecuserid_to ,
                                             long AV68Auditwwds_16_tfemployeeid ,
                                             long AV69Auditwwds_17_tfemployeeid_to ,
                                             string AV71Auditwwds_19_tfemployeename_sel ,
                                             string AV70Auditwwds_18_tfemployeename ,
                                             long A204AuditId ,
                                             string A206AuditTableName ,
                                             string A207AuditDescription ,
                                             string A208AuditShortDescription ,
                                             string A209AuditAction ,
                                             long A210SecUserId ,
                                             long A106EmployeeId ,
                                             string A148EmployeeName ,
                                             DateTime A205AuditDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[26];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.AuditTableName, T2.EmployeeName, T1.EmployeeId, T1.SecUserId, T1.AuditAction, T1.AuditShortDescription, T1.AuditDescription, T1.AuditDate, T1.AuditId FROM (Audit T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.AuditId,'9999999999'), 2) like '%' || :lV53Auditwwds_1_filterfulltext) or ( LOWER(T1.AuditTableName) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditDescription) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditShortDescription) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditAction) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.SecUserId,'9999999999'), 2) like '%' || :lV53Auditwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV53Auditwwds_1_filterfulltext) or ( LOWER(T2.EmployeeName) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV54Auditwwds_2_tfauditid) )
         {
            AddWhere(sWhereString, "(T1.AuditId >= :AV54Auditwwds_2_tfauditid)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV55Auditwwds_3_tfauditid_to) )
         {
            AddWhere(sWhereString, "(T1.AuditId <= :AV55Auditwwds_3_tfauditid_to)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Auditwwds_4_tfauditdate) )
         {
            AddWhere(sWhereString, "(T1.AuditDate >= :AV56Auditwwds_4_tfauditdate)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Auditwwds_5_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(T1.AuditDate <= :AV57Auditwwds_5_tfauditdate_to)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Auditwwds_7_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Auditwwds_6_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditTableName like :lV58Auditwwds_6_tfaudittablename)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Auditwwds_7_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV59Auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditTableName = ( :AV59Auditwwds_7_tfaudittablename_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV59Auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Auditwwds_9_tfauditdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Auditwwds_8_tfauditdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditDescription like :lV60Auditwwds_8_tfauditdescription)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Auditwwds_9_tfauditdescription_sel)) && ! ( StringUtil.StrCmp(AV61Auditwwds_9_tfauditdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditDescription = ( :AV61Auditwwds_9_tfauditdescription_sel))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV61Auditwwds_9_tfauditdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Auditwwds_11_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Auditwwds_10_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditShortDescription like :lV62Auditwwds_10_tfauditshortdescription)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Auditwwds_11_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV63Auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditShortDescription = ( :AV63Auditwwds_11_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( StringUtil.StrCmp(AV63Auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditShortDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Auditwwds_13_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Auditwwds_12_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditAction like :lV64Auditwwds_12_tfauditaction)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Auditwwds_13_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV65Auditwwds_13_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditAction = ( :AV65Auditwwds_13_tfauditaction_sel))");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( StringUtil.StrCmp(AV65Auditwwds_13_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditAction))=0))");
         }
         if ( ! (0==AV66Auditwwds_14_tfsecuserid) )
         {
            AddWhere(sWhereString, "(T1.SecUserId >= :AV66Auditwwds_14_tfsecuserid)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! (0==AV67Auditwwds_15_tfsecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.SecUserId <= :AV67Auditwwds_15_tfsecuserid_to)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! (0==AV68Auditwwds_16_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV68Auditwwds_16_tfemployeeid)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! (0==AV69Auditwwds_17_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV69Auditwwds_17_tfemployeeid_to)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Auditwwds_19_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Auditwwds_18_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName like :lV70Auditwwds_18_tfemployeename)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Auditwwds_19_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV71Auditwwds_19_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV71Auditwwds_19_tfemployeename_sel))");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( StringUtil.StrCmp(AV71Auditwwds_19_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.AuditTableName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00BU3( IGxContext context ,
                                             string AV53Auditwwds_1_filterfulltext ,
                                             long AV54Auditwwds_2_tfauditid ,
                                             long AV55Auditwwds_3_tfauditid_to ,
                                             DateTime AV56Auditwwds_4_tfauditdate ,
                                             DateTime AV57Auditwwds_5_tfauditdate_to ,
                                             string AV59Auditwwds_7_tfaudittablename_sel ,
                                             string AV58Auditwwds_6_tfaudittablename ,
                                             string AV61Auditwwds_9_tfauditdescription_sel ,
                                             string AV60Auditwwds_8_tfauditdescription ,
                                             string AV63Auditwwds_11_tfauditshortdescription_sel ,
                                             string AV62Auditwwds_10_tfauditshortdescription ,
                                             string AV65Auditwwds_13_tfauditaction_sel ,
                                             string AV64Auditwwds_12_tfauditaction ,
                                             long AV66Auditwwds_14_tfsecuserid ,
                                             long AV67Auditwwds_15_tfsecuserid_to ,
                                             long AV68Auditwwds_16_tfemployeeid ,
                                             long AV69Auditwwds_17_tfemployeeid_to ,
                                             string AV71Auditwwds_19_tfemployeename_sel ,
                                             string AV70Auditwwds_18_tfemployeename ,
                                             long A204AuditId ,
                                             string A206AuditTableName ,
                                             string A207AuditDescription ,
                                             string A208AuditShortDescription ,
                                             string A209AuditAction ,
                                             long A210SecUserId ,
                                             long A106EmployeeId ,
                                             string A148EmployeeName ,
                                             DateTime A205AuditDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[26];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.AuditDescription, T2.EmployeeName, T1.EmployeeId, T1.SecUserId, T1.AuditAction, T1.AuditShortDescription, T1.AuditTableName, T1.AuditDate, T1.AuditId FROM (Audit T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.AuditId,'9999999999'), 2) like '%' || :lV53Auditwwds_1_filterfulltext) or ( LOWER(T1.AuditTableName) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditDescription) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditShortDescription) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditAction) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.SecUserId,'9999999999'), 2) like '%' || :lV53Auditwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV53Auditwwds_1_filterfulltext) or ( LOWER(T2.EmployeeName) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
         }
         if ( ! (0==AV54Auditwwds_2_tfauditid) )
         {
            AddWhere(sWhereString, "(T1.AuditId >= :AV54Auditwwds_2_tfauditid)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (0==AV55Auditwwds_3_tfauditid_to) )
         {
            AddWhere(sWhereString, "(T1.AuditId <= :AV55Auditwwds_3_tfauditid_to)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Auditwwds_4_tfauditdate) )
         {
            AddWhere(sWhereString, "(T1.AuditDate >= :AV56Auditwwds_4_tfauditdate)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Auditwwds_5_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(T1.AuditDate <= :AV57Auditwwds_5_tfauditdate_to)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Auditwwds_7_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Auditwwds_6_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditTableName like :lV58Auditwwds_6_tfaudittablename)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Auditwwds_7_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV59Auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditTableName = ( :AV59Auditwwds_7_tfaudittablename_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV59Auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Auditwwds_9_tfauditdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Auditwwds_8_tfauditdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditDescription like :lV60Auditwwds_8_tfauditdescription)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Auditwwds_9_tfauditdescription_sel)) && ! ( StringUtil.StrCmp(AV61Auditwwds_9_tfauditdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditDescription = ( :AV61Auditwwds_9_tfauditdescription_sel))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV61Auditwwds_9_tfauditdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Auditwwds_11_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Auditwwds_10_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditShortDescription like :lV62Auditwwds_10_tfauditshortdescription)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Auditwwds_11_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV63Auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditShortDescription = ( :AV63Auditwwds_11_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( StringUtil.StrCmp(AV63Auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditShortDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Auditwwds_13_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Auditwwds_12_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditAction like :lV64Auditwwds_12_tfauditaction)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Auditwwds_13_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV65Auditwwds_13_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditAction = ( :AV65Auditwwds_13_tfauditaction_sel))");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( StringUtil.StrCmp(AV65Auditwwds_13_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditAction))=0))");
         }
         if ( ! (0==AV66Auditwwds_14_tfsecuserid) )
         {
            AddWhere(sWhereString, "(T1.SecUserId >= :AV66Auditwwds_14_tfsecuserid)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! (0==AV67Auditwwds_15_tfsecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.SecUserId <= :AV67Auditwwds_15_tfsecuserid_to)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! (0==AV68Auditwwds_16_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV68Auditwwds_16_tfemployeeid)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! (0==AV69Auditwwds_17_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV69Auditwwds_17_tfemployeeid_to)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Auditwwds_19_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Auditwwds_18_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName like :lV70Auditwwds_18_tfemployeename)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Auditwwds_19_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV71Auditwwds_19_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV71Auditwwds_19_tfemployeename_sel))");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( StringUtil.StrCmp(AV71Auditwwds_19_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.AuditDescription";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00BU4( IGxContext context ,
                                             string AV53Auditwwds_1_filterfulltext ,
                                             long AV54Auditwwds_2_tfauditid ,
                                             long AV55Auditwwds_3_tfauditid_to ,
                                             DateTime AV56Auditwwds_4_tfauditdate ,
                                             DateTime AV57Auditwwds_5_tfauditdate_to ,
                                             string AV59Auditwwds_7_tfaudittablename_sel ,
                                             string AV58Auditwwds_6_tfaudittablename ,
                                             string AV61Auditwwds_9_tfauditdescription_sel ,
                                             string AV60Auditwwds_8_tfauditdescription ,
                                             string AV63Auditwwds_11_tfauditshortdescription_sel ,
                                             string AV62Auditwwds_10_tfauditshortdescription ,
                                             string AV65Auditwwds_13_tfauditaction_sel ,
                                             string AV64Auditwwds_12_tfauditaction ,
                                             long AV66Auditwwds_14_tfsecuserid ,
                                             long AV67Auditwwds_15_tfsecuserid_to ,
                                             long AV68Auditwwds_16_tfemployeeid ,
                                             long AV69Auditwwds_17_tfemployeeid_to ,
                                             string AV71Auditwwds_19_tfemployeename_sel ,
                                             string AV70Auditwwds_18_tfemployeename ,
                                             long A204AuditId ,
                                             string A206AuditTableName ,
                                             string A207AuditDescription ,
                                             string A208AuditShortDescription ,
                                             string A209AuditAction ,
                                             long A210SecUserId ,
                                             long A106EmployeeId ,
                                             string A148EmployeeName ,
                                             DateTime A205AuditDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[26];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.AuditShortDescription, T2.EmployeeName, T1.EmployeeId, T1.SecUserId, T1.AuditAction, T1.AuditDescription, T1.AuditTableName, T1.AuditDate, T1.AuditId FROM (Audit T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.AuditId,'9999999999'), 2) like '%' || :lV53Auditwwds_1_filterfulltext) or ( LOWER(T1.AuditTableName) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditDescription) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditShortDescription) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditAction) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.SecUserId,'9999999999'), 2) like '%' || :lV53Auditwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV53Auditwwds_1_filterfulltext) or ( LOWER(T2.EmployeeName) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
         }
         if ( ! (0==AV54Auditwwds_2_tfauditid) )
         {
            AddWhere(sWhereString, "(T1.AuditId >= :AV54Auditwwds_2_tfauditid)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (0==AV55Auditwwds_3_tfauditid_to) )
         {
            AddWhere(sWhereString, "(T1.AuditId <= :AV55Auditwwds_3_tfauditid_to)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Auditwwds_4_tfauditdate) )
         {
            AddWhere(sWhereString, "(T1.AuditDate >= :AV56Auditwwds_4_tfauditdate)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Auditwwds_5_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(T1.AuditDate <= :AV57Auditwwds_5_tfauditdate_to)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Auditwwds_7_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Auditwwds_6_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditTableName like :lV58Auditwwds_6_tfaudittablename)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Auditwwds_7_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV59Auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditTableName = ( :AV59Auditwwds_7_tfaudittablename_sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV59Auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Auditwwds_9_tfauditdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Auditwwds_8_tfauditdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditDescription like :lV60Auditwwds_8_tfauditdescription)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Auditwwds_9_tfauditdescription_sel)) && ! ( StringUtil.StrCmp(AV61Auditwwds_9_tfauditdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditDescription = ( :AV61Auditwwds_9_tfauditdescription_sel))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV61Auditwwds_9_tfauditdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Auditwwds_11_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Auditwwds_10_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditShortDescription like :lV62Auditwwds_10_tfauditshortdescription)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Auditwwds_11_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV63Auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditShortDescription = ( :AV63Auditwwds_11_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( StringUtil.StrCmp(AV63Auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditShortDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Auditwwds_13_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Auditwwds_12_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditAction like :lV64Auditwwds_12_tfauditaction)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Auditwwds_13_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV65Auditwwds_13_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditAction = ( :AV65Auditwwds_13_tfauditaction_sel))");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( StringUtil.StrCmp(AV65Auditwwds_13_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditAction))=0))");
         }
         if ( ! (0==AV66Auditwwds_14_tfsecuserid) )
         {
            AddWhere(sWhereString, "(T1.SecUserId >= :AV66Auditwwds_14_tfsecuserid)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! (0==AV67Auditwwds_15_tfsecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.SecUserId <= :AV67Auditwwds_15_tfsecuserid_to)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! (0==AV68Auditwwds_16_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV68Auditwwds_16_tfemployeeid)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! (0==AV69Auditwwds_17_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV69Auditwwds_17_tfemployeeid_to)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Auditwwds_19_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Auditwwds_18_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName like :lV70Auditwwds_18_tfemployeename)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Auditwwds_19_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV71Auditwwds_19_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV71Auditwwds_19_tfemployeename_sel))");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( StringUtil.StrCmp(AV71Auditwwds_19_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.AuditShortDescription";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00BU5( IGxContext context ,
                                             string AV53Auditwwds_1_filterfulltext ,
                                             long AV54Auditwwds_2_tfauditid ,
                                             long AV55Auditwwds_3_tfauditid_to ,
                                             DateTime AV56Auditwwds_4_tfauditdate ,
                                             DateTime AV57Auditwwds_5_tfauditdate_to ,
                                             string AV59Auditwwds_7_tfaudittablename_sel ,
                                             string AV58Auditwwds_6_tfaudittablename ,
                                             string AV61Auditwwds_9_tfauditdescription_sel ,
                                             string AV60Auditwwds_8_tfauditdescription ,
                                             string AV63Auditwwds_11_tfauditshortdescription_sel ,
                                             string AV62Auditwwds_10_tfauditshortdescription ,
                                             string AV65Auditwwds_13_tfauditaction_sel ,
                                             string AV64Auditwwds_12_tfauditaction ,
                                             long AV66Auditwwds_14_tfsecuserid ,
                                             long AV67Auditwwds_15_tfsecuserid_to ,
                                             long AV68Auditwwds_16_tfemployeeid ,
                                             long AV69Auditwwds_17_tfemployeeid_to ,
                                             string AV71Auditwwds_19_tfemployeename_sel ,
                                             string AV70Auditwwds_18_tfemployeename ,
                                             long A204AuditId ,
                                             string A206AuditTableName ,
                                             string A207AuditDescription ,
                                             string A208AuditShortDescription ,
                                             string A209AuditAction ,
                                             long A210SecUserId ,
                                             long A106EmployeeId ,
                                             string A148EmployeeName ,
                                             DateTime A205AuditDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[26];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.AuditAction, T2.EmployeeName, T1.EmployeeId, T1.SecUserId, T1.AuditShortDescription, T1.AuditDescription, T1.AuditTableName, T1.AuditDate, T1.AuditId FROM (Audit T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.AuditId,'9999999999'), 2) like '%' || :lV53Auditwwds_1_filterfulltext) or ( LOWER(T1.AuditTableName) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditDescription) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditShortDescription) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditAction) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.SecUserId,'9999999999'), 2) like '%' || :lV53Auditwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV53Auditwwds_1_filterfulltext) or ( LOWER(T2.EmployeeName) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
         }
         if ( ! (0==AV54Auditwwds_2_tfauditid) )
         {
            AddWhere(sWhereString, "(T1.AuditId >= :AV54Auditwwds_2_tfauditid)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! (0==AV55Auditwwds_3_tfauditid_to) )
         {
            AddWhere(sWhereString, "(T1.AuditId <= :AV55Auditwwds_3_tfauditid_to)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Auditwwds_4_tfauditdate) )
         {
            AddWhere(sWhereString, "(T1.AuditDate >= :AV56Auditwwds_4_tfauditdate)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Auditwwds_5_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(T1.AuditDate <= :AV57Auditwwds_5_tfauditdate_to)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Auditwwds_7_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Auditwwds_6_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditTableName like :lV58Auditwwds_6_tfaudittablename)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Auditwwds_7_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV59Auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditTableName = ( :AV59Auditwwds_7_tfaudittablename_sel))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV59Auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Auditwwds_9_tfauditdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Auditwwds_8_tfauditdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditDescription like :lV60Auditwwds_8_tfauditdescription)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Auditwwds_9_tfauditdescription_sel)) && ! ( StringUtil.StrCmp(AV61Auditwwds_9_tfauditdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditDescription = ( :AV61Auditwwds_9_tfauditdescription_sel))");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( StringUtil.StrCmp(AV61Auditwwds_9_tfauditdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Auditwwds_11_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Auditwwds_10_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditShortDescription like :lV62Auditwwds_10_tfauditshortdescription)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Auditwwds_11_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV63Auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditShortDescription = ( :AV63Auditwwds_11_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( StringUtil.StrCmp(AV63Auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditShortDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Auditwwds_13_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Auditwwds_12_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditAction like :lV64Auditwwds_12_tfauditaction)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Auditwwds_13_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV65Auditwwds_13_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditAction = ( :AV65Auditwwds_13_tfauditaction_sel))");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( StringUtil.StrCmp(AV65Auditwwds_13_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditAction))=0))");
         }
         if ( ! (0==AV66Auditwwds_14_tfsecuserid) )
         {
            AddWhere(sWhereString, "(T1.SecUserId >= :AV66Auditwwds_14_tfsecuserid)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! (0==AV67Auditwwds_15_tfsecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.SecUserId <= :AV67Auditwwds_15_tfsecuserid_to)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! (0==AV68Auditwwds_16_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV68Auditwwds_16_tfemployeeid)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! (0==AV69Auditwwds_17_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV69Auditwwds_17_tfemployeeid_to)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Auditwwds_19_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Auditwwds_18_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName like :lV70Auditwwds_18_tfemployeename)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Auditwwds_19_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV71Auditwwds_19_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV71Auditwwds_19_tfemployeename_sel))");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( StringUtil.StrCmp(AV71Auditwwds_19_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.AuditAction";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00BU6( IGxContext context ,
                                             string AV53Auditwwds_1_filterfulltext ,
                                             long AV54Auditwwds_2_tfauditid ,
                                             long AV55Auditwwds_3_tfauditid_to ,
                                             DateTime AV56Auditwwds_4_tfauditdate ,
                                             DateTime AV57Auditwwds_5_tfauditdate_to ,
                                             string AV59Auditwwds_7_tfaudittablename_sel ,
                                             string AV58Auditwwds_6_tfaudittablename ,
                                             string AV61Auditwwds_9_tfauditdescription_sel ,
                                             string AV60Auditwwds_8_tfauditdescription ,
                                             string AV63Auditwwds_11_tfauditshortdescription_sel ,
                                             string AV62Auditwwds_10_tfauditshortdescription ,
                                             string AV65Auditwwds_13_tfauditaction_sel ,
                                             string AV64Auditwwds_12_tfauditaction ,
                                             long AV66Auditwwds_14_tfsecuserid ,
                                             long AV67Auditwwds_15_tfsecuserid_to ,
                                             long AV68Auditwwds_16_tfemployeeid ,
                                             long AV69Auditwwds_17_tfemployeeid_to ,
                                             string AV71Auditwwds_19_tfemployeename_sel ,
                                             string AV70Auditwwds_18_tfemployeename ,
                                             long A204AuditId ,
                                             string A206AuditTableName ,
                                             string A207AuditDescription ,
                                             string A208AuditShortDescription ,
                                             string A209AuditAction ,
                                             long A210SecUserId ,
                                             long A106EmployeeId ,
                                             string A148EmployeeName ,
                                             DateTime A205AuditDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[26];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T2.EmployeeName, T1.EmployeeId, T1.SecUserId, T1.AuditAction, T1.AuditShortDescription, T1.AuditDescription, T1.AuditTableName, T1.AuditDate, T1.AuditId FROM (Audit T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.AuditId,'9999999999'), 2) like '%' || :lV53Auditwwds_1_filterfulltext) or ( LOWER(T1.AuditTableName) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditDescription) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditShortDescription) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditAction) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.SecUserId,'9999999999'), 2) like '%' || :lV53Auditwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV53Auditwwds_1_filterfulltext) or ( LOWER(T2.EmployeeName) like '%' || LOWER(:lV53Auditwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
            GXv_int9[7] = 1;
         }
         if ( ! (0==AV54Auditwwds_2_tfauditid) )
         {
            AddWhere(sWhereString, "(T1.AuditId >= :AV54Auditwwds_2_tfauditid)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! (0==AV55Auditwwds_3_tfauditid_to) )
         {
            AddWhere(sWhereString, "(T1.AuditId <= :AV55Auditwwds_3_tfauditid_to)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Auditwwds_4_tfauditdate) )
         {
            AddWhere(sWhereString, "(T1.AuditDate >= :AV56Auditwwds_4_tfauditdate)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Auditwwds_5_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(T1.AuditDate <= :AV57Auditwwds_5_tfauditdate_to)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Auditwwds_7_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Auditwwds_6_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditTableName like :lV58Auditwwds_6_tfaudittablename)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Auditwwds_7_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV59Auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditTableName = ( :AV59Auditwwds_7_tfaudittablename_sel))");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( StringUtil.StrCmp(AV59Auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Auditwwds_9_tfauditdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Auditwwds_8_tfauditdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditDescription like :lV60Auditwwds_8_tfauditdescription)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Auditwwds_9_tfauditdescription_sel)) && ! ( StringUtil.StrCmp(AV61Auditwwds_9_tfauditdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditDescription = ( :AV61Auditwwds_9_tfauditdescription_sel))");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( StringUtil.StrCmp(AV61Auditwwds_9_tfauditdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Auditwwds_11_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Auditwwds_10_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditShortDescription like :lV62Auditwwds_10_tfauditshortdescription)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Auditwwds_11_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV63Auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditShortDescription = ( :AV63Auditwwds_11_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( StringUtil.StrCmp(AV63Auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditShortDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Auditwwds_13_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Auditwwds_12_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditAction like :lV64Auditwwds_12_tfauditaction)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Auditwwds_13_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV65Auditwwds_13_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditAction = ( :AV65Auditwwds_13_tfauditaction_sel))");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( StringUtil.StrCmp(AV65Auditwwds_13_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditAction))=0))");
         }
         if ( ! (0==AV66Auditwwds_14_tfsecuserid) )
         {
            AddWhere(sWhereString, "(T1.SecUserId >= :AV66Auditwwds_14_tfsecuserid)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ! (0==AV67Auditwwds_15_tfsecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.SecUserId <= :AV67Auditwwds_15_tfsecuserid_to)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ! (0==AV68Auditwwds_16_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV68Auditwwds_16_tfemployeeid)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( ! (0==AV69Auditwwds_17_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV69Auditwwds_17_tfemployeeid_to)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Auditwwds_19_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Auditwwds_18_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName like :lV70Auditwwds_18_tfemployeename)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Auditwwds_19_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV71Auditwwds_19_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV71Auditwwds_19_tfemployeename_sel))");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( StringUtil.StrCmp(AV71Auditwwds_19_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.EmployeeName";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00BU2(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] );
               case 1 :
                     return conditional_P00BU3(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] );
               case 2 :
                     return conditional_P00BU4(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] );
               case 3 :
                     return conditional_P00BU5(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] );
               case 4 :
                     return conditional_P00BU6(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] );
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
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BU2;
          prmP00BU2 = new Object[] {
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV54Auditwwds_2_tfauditid",GXType.Int64,10,0) ,
          new ParDef("AV55Auditwwds_3_tfauditid_to",GXType.Int64,10,0) ,
          new ParDef("AV56Auditwwds_4_tfauditdate",GXType.Date,8,0) ,
          new ParDef("AV57Auditwwds_5_tfauditdate_to",GXType.Date,8,0) ,
          new ParDef("lV58Auditwwds_6_tfaudittablename",GXType.Char,100,0) ,
          new ParDef("AV59Auditwwds_7_tfaudittablename_sel",GXType.Char,100,0) ,
          new ParDef("lV60Auditwwds_8_tfauditdescription",GXType.VarChar,200,0) ,
          new ParDef("AV61Auditwwds_9_tfauditdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV62Auditwwds_10_tfauditshortdescription",GXType.VarChar,200,0) ,
          new ParDef("AV63Auditwwds_11_tfauditshortdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV64Auditwwds_12_tfauditaction",GXType.VarChar,10,0) ,
          new ParDef("AV65Auditwwds_13_tfauditaction_sel",GXType.VarChar,10,0) ,
          new ParDef("AV66Auditwwds_14_tfsecuserid",GXType.Int64,10,0) ,
          new ParDef("AV67Auditwwds_15_tfsecuserid_to",GXType.Int64,10,0) ,
          new ParDef("AV68Auditwwds_16_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV69Auditwwds_17_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV70Auditwwds_18_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV71Auditwwds_19_tfemployeename_sel",GXType.Char,100,0)
          };
          Object[] prmP00BU3;
          prmP00BU3 = new Object[] {
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV54Auditwwds_2_tfauditid",GXType.Int64,10,0) ,
          new ParDef("AV55Auditwwds_3_tfauditid_to",GXType.Int64,10,0) ,
          new ParDef("AV56Auditwwds_4_tfauditdate",GXType.Date,8,0) ,
          new ParDef("AV57Auditwwds_5_tfauditdate_to",GXType.Date,8,0) ,
          new ParDef("lV58Auditwwds_6_tfaudittablename",GXType.Char,100,0) ,
          new ParDef("AV59Auditwwds_7_tfaudittablename_sel",GXType.Char,100,0) ,
          new ParDef("lV60Auditwwds_8_tfauditdescription",GXType.VarChar,200,0) ,
          new ParDef("AV61Auditwwds_9_tfauditdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV62Auditwwds_10_tfauditshortdescription",GXType.VarChar,200,0) ,
          new ParDef("AV63Auditwwds_11_tfauditshortdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV64Auditwwds_12_tfauditaction",GXType.VarChar,10,0) ,
          new ParDef("AV65Auditwwds_13_tfauditaction_sel",GXType.VarChar,10,0) ,
          new ParDef("AV66Auditwwds_14_tfsecuserid",GXType.Int64,10,0) ,
          new ParDef("AV67Auditwwds_15_tfsecuserid_to",GXType.Int64,10,0) ,
          new ParDef("AV68Auditwwds_16_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV69Auditwwds_17_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV70Auditwwds_18_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV71Auditwwds_19_tfemployeename_sel",GXType.Char,100,0)
          };
          Object[] prmP00BU4;
          prmP00BU4 = new Object[] {
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV54Auditwwds_2_tfauditid",GXType.Int64,10,0) ,
          new ParDef("AV55Auditwwds_3_tfauditid_to",GXType.Int64,10,0) ,
          new ParDef("AV56Auditwwds_4_tfauditdate",GXType.Date,8,0) ,
          new ParDef("AV57Auditwwds_5_tfauditdate_to",GXType.Date,8,0) ,
          new ParDef("lV58Auditwwds_6_tfaudittablename",GXType.Char,100,0) ,
          new ParDef("AV59Auditwwds_7_tfaudittablename_sel",GXType.Char,100,0) ,
          new ParDef("lV60Auditwwds_8_tfauditdescription",GXType.VarChar,200,0) ,
          new ParDef("AV61Auditwwds_9_tfauditdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV62Auditwwds_10_tfauditshortdescription",GXType.VarChar,200,0) ,
          new ParDef("AV63Auditwwds_11_tfauditshortdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV64Auditwwds_12_tfauditaction",GXType.VarChar,10,0) ,
          new ParDef("AV65Auditwwds_13_tfauditaction_sel",GXType.VarChar,10,0) ,
          new ParDef("AV66Auditwwds_14_tfsecuserid",GXType.Int64,10,0) ,
          new ParDef("AV67Auditwwds_15_tfsecuserid_to",GXType.Int64,10,0) ,
          new ParDef("AV68Auditwwds_16_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV69Auditwwds_17_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV70Auditwwds_18_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV71Auditwwds_19_tfemployeename_sel",GXType.Char,100,0)
          };
          Object[] prmP00BU5;
          prmP00BU5 = new Object[] {
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV54Auditwwds_2_tfauditid",GXType.Int64,10,0) ,
          new ParDef("AV55Auditwwds_3_tfauditid_to",GXType.Int64,10,0) ,
          new ParDef("AV56Auditwwds_4_tfauditdate",GXType.Date,8,0) ,
          new ParDef("AV57Auditwwds_5_tfauditdate_to",GXType.Date,8,0) ,
          new ParDef("lV58Auditwwds_6_tfaudittablename",GXType.Char,100,0) ,
          new ParDef("AV59Auditwwds_7_tfaudittablename_sel",GXType.Char,100,0) ,
          new ParDef("lV60Auditwwds_8_tfauditdescription",GXType.VarChar,200,0) ,
          new ParDef("AV61Auditwwds_9_tfauditdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV62Auditwwds_10_tfauditshortdescription",GXType.VarChar,200,0) ,
          new ParDef("AV63Auditwwds_11_tfauditshortdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV64Auditwwds_12_tfauditaction",GXType.VarChar,10,0) ,
          new ParDef("AV65Auditwwds_13_tfauditaction_sel",GXType.VarChar,10,0) ,
          new ParDef("AV66Auditwwds_14_tfsecuserid",GXType.Int64,10,0) ,
          new ParDef("AV67Auditwwds_15_tfsecuserid_to",GXType.Int64,10,0) ,
          new ParDef("AV68Auditwwds_16_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV69Auditwwds_17_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV70Auditwwds_18_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV71Auditwwds_19_tfemployeename_sel",GXType.Char,100,0)
          };
          Object[] prmP00BU6;
          prmP00BU6 = new Object[] {
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV54Auditwwds_2_tfauditid",GXType.Int64,10,0) ,
          new ParDef("AV55Auditwwds_3_tfauditid_to",GXType.Int64,10,0) ,
          new ParDef("AV56Auditwwds_4_tfauditdate",GXType.Date,8,0) ,
          new ParDef("AV57Auditwwds_5_tfauditdate_to",GXType.Date,8,0) ,
          new ParDef("lV58Auditwwds_6_tfaudittablename",GXType.Char,100,0) ,
          new ParDef("AV59Auditwwds_7_tfaudittablename_sel",GXType.Char,100,0) ,
          new ParDef("lV60Auditwwds_8_tfauditdescription",GXType.VarChar,200,0) ,
          new ParDef("AV61Auditwwds_9_tfauditdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV62Auditwwds_10_tfauditshortdescription",GXType.VarChar,200,0) ,
          new ParDef("AV63Auditwwds_11_tfauditshortdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV64Auditwwds_12_tfauditaction",GXType.VarChar,10,0) ,
          new ParDef("AV65Auditwwds_13_tfauditaction_sel",GXType.VarChar,10,0) ,
          new ParDef("AV66Auditwwds_14_tfsecuserid",GXType.Int64,10,0) ,
          new ParDef("AV67Auditwwds_15_tfsecuserid_to",GXType.Int64,10,0) ,
          new ParDef("AV68Auditwwds_16_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV69Auditwwds_17_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV70Auditwwds_18_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV71Auditwwds_19_tfemployeename_sel",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BU2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BU2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BU3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BU3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BU4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BU4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BU5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BU5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BU6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BU6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                return;
       }
    }

 }

}
