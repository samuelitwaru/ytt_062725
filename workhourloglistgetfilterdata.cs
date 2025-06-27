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
   public class workhourloglistgetfilterdata : GXProcedure
   {
      public workhourloglistgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workhourloglistgetfilterdata( IGxContext context )
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
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV46OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV31Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28MaxItems = 10;
         AV27PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV42SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV25SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? "" : StringUtil.Substring( AV42SearchTxtParms, 3, -1));
         AV26SkipItems = (short)(AV27PageIndex*AV28MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_EMPLOYEENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROJECTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPROJECTNAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_WORKHOURLOGDURATION") == 0 )
         {
            /* Execute user subroutine: 'LOADWORKHOURLOGDURATIONOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_WORKHOURLOGDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADWORKHOURLOGDESCRIPTIONOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV44OptionsJson = AV31Options.ToJSonString(false);
         AV45OptionsDescJson = AV33OptionsDesc.ToJSonString(false);
         AV46OptionIndexesJson = AV34OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get("WorkHourLogListGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WorkHourLogListGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("WorkHourLogListGridState"), null, "", "");
         }
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV52GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV11TFEmployeeName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV12TFEmployeeName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME") == 0 )
            {
               AV13TFProjectName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME_SEL") == 0 )
            {
               AV14TFProjectName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDATE") == 0 )
            {
               AV15TFWorkHourLogDate = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Value, 2);
               AV16TFWorkHourLogDate_To = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION") == 0 )
            {
               AV17TFWorkHourLogDuration = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION_SEL") == 0 )
            {
               AV18TFWorkHourLogDuration_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION") == 0 )
            {
               AV23TFWorkHourLogDescription = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION_SEL") == 0 )
            {
               AV24TFWorkHourLogDescription_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADEMPLOYEENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFEmployeeName = AV25SearchTxt;
         AV12TFEmployeeName_Sel = "";
         AV54Workhourloglistds_1_filterfulltext = AV47FilterFullText;
         AV55Workhourloglistds_2_tfemployeename = AV11TFEmployeeName;
         AV56Workhourloglistds_3_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV57Workhourloglistds_4_tfprojectname = AV13TFProjectName;
         AV58Workhourloglistds_5_tfprojectname_sel = AV14TFProjectName_Sel;
         AV59Workhourloglistds_6_tfworkhourlogdate = AV15TFWorkHourLogDate;
         AV60Workhourloglistds_7_tfworkhourlogdate_to = AV16TFWorkHourLogDate_To;
         AV61Workhourloglistds_8_tfworkhourlogduration = AV17TFWorkHourLogDuration;
         AV62Workhourloglistds_9_tfworkhourlogduration_sel = AV18TFWorkHourLogDuration_Sel;
         AV63Workhourloglistds_10_tfworkhourlogdescription = AV23TFWorkHourLogDescription;
         AV64Workhourloglistds_11_tfworkhourlogdescription_sel = AV24TFWorkHourLogDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV51ProjectIds ,
                                              AV54Workhourloglistds_1_filterfulltext ,
                                              AV56Workhourloglistds_3_tfemployeename_sel ,
                                              AV55Workhourloglistds_2_tfemployeename ,
                                              AV58Workhourloglistds_5_tfprojectname_sel ,
                                              AV57Workhourloglistds_4_tfprojectname ,
                                              AV59Workhourloglistds_6_tfworkhourlogdate ,
                                              AV60Workhourloglistds_7_tfworkhourlogdate_to ,
                                              AV62Workhourloglistds_9_tfworkhourlogduration_sel ,
                                              AV61Workhourloglistds_8_tfworkhourlogduration ,
                                              AV64Workhourloglistds_11_tfworkhourlogdescription_sel ,
                                              AV63Workhourloglistds_10_tfworkhourlogdescription ,
                                              AV50EmployeeId ,
                                              AV48FromDate ,
                                              AV49ToDate ,
                                              AV51ProjectIds.Count ,
                                              A103ProjectName ,
                                              A148EmployeeName ,
                                              A119WorkHourLogDate ,
                                              A120WorkHourLogDuration ,
                                              A123WorkHourLogDescription ,
                                              A106EmployeeId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.LONG
                                              }
         });
         lV54Workhourloglistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext), "%", "");
         lV55Workhourloglistds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV55Workhourloglistds_2_tfemployeename), 100, "%");
         lV57Workhourloglistds_4_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV57Workhourloglistds_4_tfprojectname), 100, "%");
         lV61Workhourloglistds_8_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV61Workhourloglistds_8_tfworkhourlogduration), "%", "");
         lV63Workhourloglistds_10_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV63Workhourloglistds_10_tfworkhourlogdescription), "%", "");
         /* Using cursor P00872 */
         pr_default.execute(0, new Object[] {lV54Workhourloglistds_1_filterfulltext, lV55Workhourloglistds_2_tfemployeename, AV56Workhourloglistds_3_tfemployeename_sel, lV57Workhourloglistds_4_tfprojectname, AV58Workhourloglistds_5_tfprojectname_sel, AV59Workhourloglistds_6_tfworkhourlogdate, AV60Workhourloglistds_7_tfworkhourlogdate_to, lV61Workhourloglistds_8_tfworkhourlogduration, AV62Workhourloglistds_9_tfworkhourlogduration_sel, lV63Workhourloglistds_10_tfworkhourlogdescription, AV64Workhourloglistds_11_tfworkhourlogdescription_sel, AV50EmployeeId, AV48FromDate, AV49ToDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK872 = false;
            A148EmployeeName = P00872_A148EmployeeName[0];
            A102ProjectId = P00872_A102ProjectId[0];
            A106EmployeeId = P00872_A106EmployeeId[0];
            A123WorkHourLogDescription = P00872_A123WorkHourLogDescription[0];
            A120WorkHourLogDuration = P00872_A120WorkHourLogDuration[0];
            A119WorkHourLogDate = P00872_A119WorkHourLogDate[0];
            A103ProjectName = P00872_A103ProjectName[0];
            A118WorkHourLogId = P00872_A118WorkHourLogId[0];
            A103ProjectName = P00872_A103ProjectName[0];
            A148EmployeeName = P00872_A148EmployeeName[0];
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00872_A148EmployeeName[0], A148EmployeeName) == 0 ) )
            {
               BRK872 = false;
               A106EmployeeId = P00872_A106EmployeeId[0];
               A118WorkHourLogId = P00872_A118WorkHourLogId[0];
               AV35count = (long)(AV35count+1);
               BRK872 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A148EmployeeName)) ? "<#Empty#>" : A148EmployeeName);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK872 )
            {
               BRK872 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROJECTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFProjectName = AV25SearchTxt;
         AV14TFProjectName_Sel = "";
         AV54Workhourloglistds_1_filterfulltext = AV47FilterFullText;
         AV55Workhourloglistds_2_tfemployeename = AV11TFEmployeeName;
         AV56Workhourloglistds_3_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV57Workhourloglistds_4_tfprojectname = AV13TFProjectName;
         AV58Workhourloglistds_5_tfprojectname_sel = AV14TFProjectName_Sel;
         AV59Workhourloglistds_6_tfworkhourlogdate = AV15TFWorkHourLogDate;
         AV60Workhourloglistds_7_tfworkhourlogdate_to = AV16TFWorkHourLogDate_To;
         AV61Workhourloglistds_8_tfworkhourlogduration = AV17TFWorkHourLogDuration;
         AV62Workhourloglistds_9_tfworkhourlogduration_sel = AV18TFWorkHourLogDuration_Sel;
         AV63Workhourloglistds_10_tfworkhourlogdescription = AV23TFWorkHourLogDescription;
         AV64Workhourloglistds_11_tfworkhourlogdescription_sel = AV24TFWorkHourLogDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV51ProjectIds ,
                                              AV54Workhourloglistds_1_filterfulltext ,
                                              AV56Workhourloglistds_3_tfemployeename_sel ,
                                              AV55Workhourloglistds_2_tfemployeename ,
                                              AV58Workhourloglistds_5_tfprojectname_sel ,
                                              AV57Workhourloglistds_4_tfprojectname ,
                                              AV59Workhourloglistds_6_tfworkhourlogdate ,
                                              AV60Workhourloglistds_7_tfworkhourlogdate_to ,
                                              AV62Workhourloglistds_9_tfworkhourlogduration_sel ,
                                              AV61Workhourloglistds_8_tfworkhourlogduration ,
                                              AV64Workhourloglistds_11_tfworkhourlogdescription_sel ,
                                              AV63Workhourloglistds_10_tfworkhourlogdescription ,
                                              AV50EmployeeId ,
                                              AV48FromDate ,
                                              AV49ToDate ,
                                              AV51ProjectIds.Count ,
                                              A103ProjectName ,
                                              A148EmployeeName ,
                                              A119WorkHourLogDate ,
                                              A120WorkHourLogDuration ,
                                              A123WorkHourLogDescription ,
                                              A106EmployeeId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.LONG
                                              }
         });
         lV54Workhourloglistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext), "%", "");
         lV55Workhourloglistds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV55Workhourloglistds_2_tfemployeename), 100, "%");
         lV57Workhourloglistds_4_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV57Workhourloglistds_4_tfprojectname), 100, "%");
         lV61Workhourloglistds_8_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV61Workhourloglistds_8_tfworkhourlogduration), "%", "");
         lV63Workhourloglistds_10_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV63Workhourloglistds_10_tfworkhourlogdescription), "%", "");
         /* Using cursor P00873 */
         pr_default.execute(1, new Object[] {lV54Workhourloglistds_1_filterfulltext, lV55Workhourloglistds_2_tfemployeename, AV56Workhourloglistds_3_tfemployeename_sel, lV57Workhourloglistds_4_tfprojectname, AV58Workhourloglistds_5_tfprojectname_sel, AV59Workhourloglistds_6_tfworkhourlogdate, AV60Workhourloglistds_7_tfworkhourlogdate_to, lV61Workhourloglistds_8_tfworkhourlogduration, AV62Workhourloglistds_9_tfworkhourlogduration_sel, lV63Workhourloglistds_10_tfworkhourlogdescription, AV64Workhourloglistds_11_tfworkhourlogdescription_sel, AV50EmployeeId, AV48FromDate, AV49ToDate});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK874 = false;
            A103ProjectName = P00873_A103ProjectName[0];
            A102ProjectId = P00873_A102ProjectId[0];
            A106EmployeeId = P00873_A106EmployeeId[0];
            A123WorkHourLogDescription = P00873_A123WorkHourLogDescription[0];
            A120WorkHourLogDuration = P00873_A120WorkHourLogDuration[0];
            A119WorkHourLogDate = P00873_A119WorkHourLogDate[0];
            A148EmployeeName = P00873_A148EmployeeName[0];
            A118WorkHourLogId = P00873_A118WorkHourLogId[0];
            A103ProjectName = P00873_A103ProjectName[0];
            A148EmployeeName = P00873_A148EmployeeName[0];
            AV35count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00873_A103ProjectName[0], A103ProjectName) == 0 ) )
            {
               BRK874 = false;
               A102ProjectId = P00873_A102ProjectId[0];
               A118WorkHourLogId = P00873_A118WorkHourLogId[0];
               AV35count = (long)(AV35count+1);
               BRK874 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A103ProjectName)) ? "<#Empty#>" : A103ProjectName);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK874 )
            {
               BRK874 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADWORKHOURLOGDURATIONOPTIONS' Routine */
         returnInSub = false;
         AV17TFWorkHourLogDuration = AV25SearchTxt;
         AV18TFWorkHourLogDuration_Sel = "";
         AV54Workhourloglistds_1_filterfulltext = AV47FilterFullText;
         AV55Workhourloglistds_2_tfemployeename = AV11TFEmployeeName;
         AV56Workhourloglistds_3_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV57Workhourloglistds_4_tfprojectname = AV13TFProjectName;
         AV58Workhourloglistds_5_tfprojectname_sel = AV14TFProjectName_Sel;
         AV59Workhourloglistds_6_tfworkhourlogdate = AV15TFWorkHourLogDate;
         AV60Workhourloglistds_7_tfworkhourlogdate_to = AV16TFWorkHourLogDate_To;
         AV61Workhourloglistds_8_tfworkhourlogduration = AV17TFWorkHourLogDuration;
         AV62Workhourloglistds_9_tfworkhourlogduration_sel = AV18TFWorkHourLogDuration_Sel;
         AV63Workhourloglistds_10_tfworkhourlogdescription = AV23TFWorkHourLogDescription;
         AV64Workhourloglistds_11_tfworkhourlogdescription_sel = AV24TFWorkHourLogDescription_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV51ProjectIds ,
                                              AV54Workhourloglistds_1_filterfulltext ,
                                              AV56Workhourloglistds_3_tfemployeename_sel ,
                                              AV55Workhourloglistds_2_tfemployeename ,
                                              AV58Workhourloglistds_5_tfprojectname_sel ,
                                              AV57Workhourloglistds_4_tfprojectname ,
                                              AV59Workhourloglistds_6_tfworkhourlogdate ,
                                              AV60Workhourloglistds_7_tfworkhourlogdate_to ,
                                              AV62Workhourloglistds_9_tfworkhourlogduration_sel ,
                                              AV61Workhourloglistds_8_tfworkhourlogduration ,
                                              AV64Workhourloglistds_11_tfworkhourlogdescription_sel ,
                                              AV63Workhourloglistds_10_tfworkhourlogdescription ,
                                              AV50EmployeeId ,
                                              AV48FromDate ,
                                              AV49ToDate ,
                                              AV51ProjectIds.Count ,
                                              A103ProjectName ,
                                              A148EmployeeName ,
                                              A119WorkHourLogDate ,
                                              A120WorkHourLogDuration ,
                                              A123WorkHourLogDescription ,
                                              A106EmployeeId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.LONG
                                              }
         });
         lV54Workhourloglistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext), "%", "");
         lV55Workhourloglistds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV55Workhourloglistds_2_tfemployeename), 100, "%");
         lV57Workhourloglistds_4_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV57Workhourloglistds_4_tfprojectname), 100, "%");
         lV61Workhourloglistds_8_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV61Workhourloglistds_8_tfworkhourlogduration), "%", "");
         lV63Workhourloglistds_10_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV63Workhourloglistds_10_tfworkhourlogdescription), "%", "");
         /* Using cursor P00874 */
         pr_default.execute(2, new Object[] {lV54Workhourloglistds_1_filterfulltext, lV55Workhourloglistds_2_tfemployeename, AV56Workhourloglistds_3_tfemployeename_sel, lV57Workhourloglistds_4_tfprojectname, AV58Workhourloglistds_5_tfprojectname_sel, AV59Workhourloglistds_6_tfworkhourlogdate, AV60Workhourloglistds_7_tfworkhourlogdate_to, lV61Workhourloglistds_8_tfworkhourlogduration, AV62Workhourloglistds_9_tfworkhourlogduration_sel, lV63Workhourloglistds_10_tfworkhourlogdescription, AV64Workhourloglistds_11_tfworkhourlogdescription_sel, AV50EmployeeId, AV48FromDate, AV49ToDate});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK876 = false;
            A120WorkHourLogDuration = P00874_A120WorkHourLogDuration[0];
            A102ProjectId = P00874_A102ProjectId[0];
            A106EmployeeId = P00874_A106EmployeeId[0];
            A123WorkHourLogDescription = P00874_A123WorkHourLogDescription[0];
            A119WorkHourLogDate = P00874_A119WorkHourLogDate[0];
            A148EmployeeName = P00874_A148EmployeeName[0];
            A103ProjectName = P00874_A103ProjectName[0];
            A118WorkHourLogId = P00874_A118WorkHourLogId[0];
            A103ProjectName = P00874_A103ProjectName[0];
            A148EmployeeName = P00874_A148EmployeeName[0];
            AV35count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00874_A120WorkHourLogDuration[0], A120WorkHourLogDuration) == 0 ) )
            {
               BRK876 = false;
               A118WorkHourLogId = P00874_A118WorkHourLogId[0];
               AV35count = (long)(AV35count+1);
               BRK876 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A120WorkHourLogDuration)) ? "<#Empty#>" : A120WorkHourLogDuration);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK876 )
            {
               BRK876 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADWORKHOURLOGDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV23TFWorkHourLogDescription = AV25SearchTxt;
         AV24TFWorkHourLogDescription_Sel = "";
         AV54Workhourloglistds_1_filterfulltext = AV47FilterFullText;
         AV55Workhourloglistds_2_tfemployeename = AV11TFEmployeeName;
         AV56Workhourloglistds_3_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV57Workhourloglistds_4_tfprojectname = AV13TFProjectName;
         AV58Workhourloglistds_5_tfprojectname_sel = AV14TFProjectName_Sel;
         AV59Workhourloglistds_6_tfworkhourlogdate = AV15TFWorkHourLogDate;
         AV60Workhourloglistds_7_tfworkhourlogdate_to = AV16TFWorkHourLogDate_To;
         AV61Workhourloglistds_8_tfworkhourlogduration = AV17TFWorkHourLogDuration;
         AV62Workhourloglistds_9_tfworkhourlogduration_sel = AV18TFWorkHourLogDuration_Sel;
         AV63Workhourloglistds_10_tfworkhourlogdescription = AV23TFWorkHourLogDescription;
         AV64Workhourloglistds_11_tfworkhourlogdescription_sel = AV24TFWorkHourLogDescription_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV51ProjectIds ,
                                              AV54Workhourloglistds_1_filterfulltext ,
                                              AV56Workhourloglistds_3_tfemployeename_sel ,
                                              AV55Workhourloglistds_2_tfemployeename ,
                                              AV58Workhourloglistds_5_tfprojectname_sel ,
                                              AV57Workhourloglistds_4_tfprojectname ,
                                              AV59Workhourloglistds_6_tfworkhourlogdate ,
                                              AV60Workhourloglistds_7_tfworkhourlogdate_to ,
                                              AV62Workhourloglistds_9_tfworkhourlogduration_sel ,
                                              AV61Workhourloglistds_8_tfworkhourlogduration ,
                                              AV64Workhourloglistds_11_tfworkhourlogdescription_sel ,
                                              AV63Workhourloglistds_10_tfworkhourlogdescription ,
                                              AV50EmployeeId ,
                                              AV48FromDate ,
                                              AV49ToDate ,
                                              AV51ProjectIds.Count ,
                                              A103ProjectName ,
                                              A148EmployeeName ,
                                              A119WorkHourLogDate ,
                                              A120WorkHourLogDuration ,
                                              A123WorkHourLogDescription ,
                                              A106EmployeeId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.LONG
                                              }
         });
         lV54Workhourloglistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext), "%", "");
         lV55Workhourloglistds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV55Workhourloglistds_2_tfemployeename), 100, "%");
         lV57Workhourloglistds_4_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV57Workhourloglistds_4_tfprojectname), 100, "%");
         lV61Workhourloglistds_8_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV61Workhourloglistds_8_tfworkhourlogduration), "%", "");
         lV63Workhourloglistds_10_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV63Workhourloglistds_10_tfworkhourlogdescription), "%", "");
         /* Using cursor P00875 */
         pr_default.execute(3, new Object[] {lV54Workhourloglistds_1_filterfulltext, lV55Workhourloglistds_2_tfemployeename, AV56Workhourloglistds_3_tfemployeename_sel, lV57Workhourloglistds_4_tfprojectname, AV58Workhourloglistds_5_tfprojectname_sel, AV59Workhourloglistds_6_tfworkhourlogdate, AV60Workhourloglistds_7_tfworkhourlogdate_to, lV61Workhourloglistds_8_tfworkhourlogduration, AV62Workhourloglistds_9_tfworkhourlogduration_sel, lV63Workhourloglistds_10_tfworkhourlogdescription, AV64Workhourloglistds_11_tfworkhourlogdescription_sel, AV50EmployeeId, AV48FromDate, AV49ToDate});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK878 = false;
            A123WorkHourLogDescription = P00875_A123WorkHourLogDescription[0];
            A102ProjectId = P00875_A102ProjectId[0];
            A106EmployeeId = P00875_A106EmployeeId[0];
            A120WorkHourLogDuration = P00875_A120WorkHourLogDuration[0];
            A119WorkHourLogDate = P00875_A119WorkHourLogDate[0];
            A148EmployeeName = P00875_A148EmployeeName[0];
            A103ProjectName = P00875_A103ProjectName[0];
            A118WorkHourLogId = P00875_A118WorkHourLogId[0];
            A103ProjectName = P00875_A103ProjectName[0];
            A148EmployeeName = P00875_A148EmployeeName[0];
            AV35count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00875_A123WorkHourLogDescription[0], A123WorkHourLogDescription) == 0 ) )
            {
               BRK878 = false;
               A118WorkHourLogId = P00875_A118WorkHourLogId[0];
               AV35count = (long)(AV35count+1);
               BRK878 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A123WorkHourLogDescription)) ? "<#Empty#>" : A123WorkHourLogDescription);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK878 )
            {
               BRK878 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
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
         AV44OptionsJson = "";
         AV45OptionsDescJson = "";
         AV46OptionIndexesJson = "";
         AV31Options = new GxSimpleCollection<string>();
         AV33OptionsDesc = new GxSimpleCollection<string>();
         AV34OptionIndexes = new GxSimpleCollection<string>();
         AV25SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV36Session = context.GetSession();
         AV38GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV39GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV47FilterFullText = "";
         AV11TFEmployeeName = "";
         AV12TFEmployeeName_Sel = "";
         AV13TFProjectName = "";
         AV14TFProjectName_Sel = "";
         AV15TFWorkHourLogDate = DateTime.MinValue;
         AV16TFWorkHourLogDate_To = DateTime.MinValue;
         AV17TFWorkHourLogDuration = "";
         AV18TFWorkHourLogDuration_Sel = "";
         AV23TFWorkHourLogDescription = "";
         AV24TFWorkHourLogDescription_Sel = "";
         AV54Workhourloglistds_1_filterfulltext = "";
         AV55Workhourloglistds_2_tfemployeename = "";
         AV56Workhourloglistds_3_tfemployeename_sel = "";
         AV57Workhourloglistds_4_tfprojectname = "";
         AV58Workhourloglistds_5_tfprojectname_sel = "";
         AV59Workhourloglistds_6_tfworkhourlogdate = DateTime.MinValue;
         AV60Workhourloglistds_7_tfworkhourlogdate_to = DateTime.MinValue;
         AV61Workhourloglistds_8_tfworkhourlogduration = "";
         AV62Workhourloglistds_9_tfworkhourlogduration_sel = "";
         AV63Workhourloglistds_10_tfworkhourlogdescription = "";
         AV64Workhourloglistds_11_tfworkhourlogdescription_sel = "";
         AV51ProjectIds = new GxSimpleCollection<long>();
         lV54Workhourloglistds_1_filterfulltext = "";
         lV55Workhourloglistds_2_tfemployeename = "";
         lV57Workhourloglistds_4_tfprojectname = "";
         lV61Workhourloglistds_8_tfworkhourlogduration = "";
         lV63Workhourloglistds_10_tfworkhourlogdescription = "";
         AV48FromDate = DateTime.MinValue;
         AV49ToDate = DateTime.MinValue;
         A103ProjectName = "";
         A148EmployeeName = "";
         A119WorkHourLogDate = DateTime.MinValue;
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         P00872_A148EmployeeName = new string[] {""} ;
         P00872_A102ProjectId = new long[1] ;
         P00872_A106EmployeeId = new long[1] ;
         P00872_A123WorkHourLogDescription = new string[] {""} ;
         P00872_A120WorkHourLogDuration = new string[] {""} ;
         P00872_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00872_A103ProjectName = new string[] {""} ;
         P00872_A118WorkHourLogId = new long[1] ;
         AV30Option = "";
         P00873_A103ProjectName = new string[] {""} ;
         P00873_A102ProjectId = new long[1] ;
         P00873_A106EmployeeId = new long[1] ;
         P00873_A123WorkHourLogDescription = new string[] {""} ;
         P00873_A120WorkHourLogDuration = new string[] {""} ;
         P00873_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00873_A148EmployeeName = new string[] {""} ;
         P00873_A118WorkHourLogId = new long[1] ;
         P00874_A120WorkHourLogDuration = new string[] {""} ;
         P00874_A102ProjectId = new long[1] ;
         P00874_A106EmployeeId = new long[1] ;
         P00874_A123WorkHourLogDescription = new string[] {""} ;
         P00874_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00874_A148EmployeeName = new string[] {""} ;
         P00874_A103ProjectName = new string[] {""} ;
         P00874_A118WorkHourLogId = new long[1] ;
         P00875_A123WorkHourLogDescription = new string[] {""} ;
         P00875_A102ProjectId = new long[1] ;
         P00875_A106EmployeeId = new long[1] ;
         P00875_A120WorkHourLogDuration = new string[] {""} ;
         P00875_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00875_A148EmployeeName = new string[] {""} ;
         P00875_A103ProjectName = new string[] {""} ;
         P00875_A118WorkHourLogId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workhourloglistgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00872_A148EmployeeName, P00872_A102ProjectId, P00872_A106EmployeeId, P00872_A123WorkHourLogDescription, P00872_A120WorkHourLogDuration, P00872_A119WorkHourLogDate, P00872_A103ProjectName, P00872_A118WorkHourLogId
               }
               , new Object[] {
               P00873_A103ProjectName, P00873_A102ProjectId, P00873_A106EmployeeId, P00873_A123WorkHourLogDescription, P00873_A120WorkHourLogDuration, P00873_A119WorkHourLogDate, P00873_A148EmployeeName, P00873_A118WorkHourLogId
               }
               , new Object[] {
               P00874_A120WorkHourLogDuration, P00874_A102ProjectId, P00874_A106EmployeeId, P00874_A123WorkHourLogDescription, P00874_A119WorkHourLogDate, P00874_A148EmployeeName, P00874_A103ProjectName, P00874_A118WorkHourLogId
               }
               , new Object[] {
               P00875_A123WorkHourLogDescription, P00875_A102ProjectId, P00875_A106EmployeeId, P00875_A120WorkHourLogDuration, P00875_A119WorkHourLogDate, P00875_A148EmployeeName, P00875_A103ProjectName, P00875_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private int AV52GXV1 ;
      private int AV51ProjectIds_Count ;
      private long A102ProjectId ;
      private long AV50EmployeeId ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private long AV35count ;
      private string AV11TFEmployeeName ;
      private string AV12TFEmployeeName_Sel ;
      private string AV13TFProjectName ;
      private string AV14TFProjectName_Sel ;
      private string AV55Workhourloglistds_2_tfemployeename ;
      private string AV56Workhourloglistds_3_tfemployeename_sel ;
      private string AV57Workhourloglistds_4_tfprojectname ;
      private string AV58Workhourloglistds_5_tfprojectname_sel ;
      private string lV55Workhourloglistds_2_tfemployeename ;
      private string lV57Workhourloglistds_4_tfprojectname ;
      private string A103ProjectName ;
      private string A148EmployeeName ;
      private DateTime AV15TFWorkHourLogDate ;
      private DateTime AV16TFWorkHourLogDate_To ;
      private DateTime AV59Workhourloglistds_6_tfworkhourlogdate ;
      private DateTime AV60Workhourloglistds_7_tfworkhourlogdate_to ;
      private DateTime AV48FromDate ;
      private DateTime AV49ToDate ;
      private DateTime A119WorkHourLogDate ;
      private bool returnInSub ;
      private bool BRK872 ;
      private bool BRK874 ;
      private bool BRK876 ;
      private bool BRK878 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string A123WorkHourLogDescription ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV17TFWorkHourLogDuration ;
      private string AV18TFWorkHourLogDuration_Sel ;
      private string AV23TFWorkHourLogDescription ;
      private string AV24TFWorkHourLogDescription_Sel ;
      private string AV54Workhourloglistds_1_filterfulltext ;
      private string AV61Workhourloglistds_8_tfworkhourlogduration ;
      private string AV62Workhourloglistds_9_tfworkhourlogduration_sel ;
      private string AV63Workhourloglistds_10_tfworkhourlogdescription ;
      private string AV64Workhourloglistds_11_tfworkhourlogdescription_sel ;
      private string lV54Workhourloglistds_1_filterfulltext ;
      private string lV61Workhourloglistds_8_tfworkhourlogduration ;
      private string lV63Workhourloglistds_10_tfworkhourlogdescription ;
      private string A120WorkHourLogDuration ;
      private string AV30Option ;
      private IGxSession AV36Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV33OptionsDesc ;
      private GxSimpleCollection<string> AV34OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV38GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private GxSimpleCollection<long> AV51ProjectIds ;
      private IDataStoreProvider pr_default ;
      private string[] P00872_A148EmployeeName ;
      private long[] P00872_A102ProjectId ;
      private long[] P00872_A106EmployeeId ;
      private string[] P00872_A123WorkHourLogDescription ;
      private string[] P00872_A120WorkHourLogDuration ;
      private DateTime[] P00872_A119WorkHourLogDate ;
      private string[] P00872_A103ProjectName ;
      private long[] P00872_A118WorkHourLogId ;
      private string[] P00873_A103ProjectName ;
      private long[] P00873_A102ProjectId ;
      private long[] P00873_A106EmployeeId ;
      private string[] P00873_A123WorkHourLogDescription ;
      private string[] P00873_A120WorkHourLogDuration ;
      private DateTime[] P00873_A119WorkHourLogDate ;
      private string[] P00873_A148EmployeeName ;
      private long[] P00873_A118WorkHourLogId ;
      private string[] P00874_A120WorkHourLogDuration ;
      private long[] P00874_A102ProjectId ;
      private long[] P00874_A106EmployeeId ;
      private string[] P00874_A123WorkHourLogDescription ;
      private DateTime[] P00874_A119WorkHourLogDate ;
      private string[] P00874_A148EmployeeName ;
      private string[] P00874_A103ProjectName ;
      private long[] P00874_A118WorkHourLogId ;
      private string[] P00875_A123WorkHourLogDescription ;
      private long[] P00875_A102ProjectId ;
      private long[] P00875_A106EmployeeId ;
      private string[] P00875_A120WorkHourLogDuration ;
      private DateTime[] P00875_A119WorkHourLogDate ;
      private string[] P00875_A148EmployeeName ;
      private string[] P00875_A103ProjectName ;
      private long[] P00875_A118WorkHourLogId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class workhourloglistgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00872( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV51ProjectIds ,
                                             string AV54Workhourloglistds_1_filterfulltext ,
                                             string AV56Workhourloglistds_3_tfemployeename_sel ,
                                             string AV55Workhourloglistds_2_tfemployeename ,
                                             string AV58Workhourloglistds_5_tfprojectname_sel ,
                                             string AV57Workhourloglistds_4_tfprojectname ,
                                             DateTime AV59Workhourloglistds_6_tfworkhourlogdate ,
                                             DateTime AV60Workhourloglistds_7_tfworkhourlogdate_to ,
                                             string AV62Workhourloglistds_9_tfworkhourlogduration_sel ,
                                             string AV61Workhourloglistds_8_tfworkhourlogduration ,
                                             string AV64Workhourloglistds_11_tfworkhourlogdescription_sel ,
                                             string AV63Workhourloglistds_10_tfworkhourlogdescription ,
                                             long AV50EmployeeId ,
                                             DateTime AV48FromDate ,
                                             DateTime AV49ToDate ,
                                             int AV51ProjectIds_Count ,
                                             string A103ProjectName ,
                                             string A148EmployeeName ,
                                             DateTime A119WorkHourLogDate ,
                                             string A120WorkHourLogDuration ,
                                             string A123WorkHourLogDescription ,
                                             long A106EmployeeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T3.EmployeeName, T1.ProjectId, T1.EmployeeId, T1.WorkHourLogDescription, T1.WorkHourLogDuration, T1.WorkHourLogDate, T2.ProjectName, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ProjectName like '%' || :lV54Workhourloglistds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Workhourloglistds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Workhourloglistds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName like :lV55Workhourloglistds_2_tfemployeename)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Workhourloglistds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV56Workhourloglistds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV56Workhourloglistds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV56Workhourloglistds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Workhourloglistds_5_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Workhourloglistds_4_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName like :lV57Workhourloglistds_4_tfprojectname)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Workhourloglistds_5_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV58Workhourloglistds_5_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName = ( :AV58Workhourloglistds_5_tfprojectname_sel))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV58Workhourloglistds_5_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProjectName))=0))");
         }
         if ( ! (DateTime.MinValue==AV59Workhourloglistds_6_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV59Workhourloglistds_6_tfworkhourlogdate)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV60Workhourloglistds_7_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV60Workhourloglistds_7_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Workhourloglistds_9_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Workhourloglistds_8_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV61Workhourloglistds_8_tfworkhourlogduration)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Workhourloglistds_9_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV62Workhourloglistds_9_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV62Workhourloglistds_9_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV62Workhourloglistds_9_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Workhourloglistds_11_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Workhourloglistds_10_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV63Workhourloglistds_10_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Workhourloglistds_11_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV64Workhourloglistds_11_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV64Workhourloglistds_11_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV64Workhourloglistds_11_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( ! (0==AV50EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV50EmployeeId)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV48FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV48FromDate)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV49ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV49ToDate)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV51ProjectIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV51ProjectIds, "T1.ProjectId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.EmployeeName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00873( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV51ProjectIds ,
                                             string AV54Workhourloglistds_1_filterfulltext ,
                                             string AV56Workhourloglistds_3_tfemployeename_sel ,
                                             string AV55Workhourloglistds_2_tfemployeename ,
                                             string AV58Workhourloglistds_5_tfprojectname_sel ,
                                             string AV57Workhourloglistds_4_tfprojectname ,
                                             DateTime AV59Workhourloglistds_6_tfworkhourlogdate ,
                                             DateTime AV60Workhourloglistds_7_tfworkhourlogdate_to ,
                                             string AV62Workhourloglistds_9_tfworkhourlogduration_sel ,
                                             string AV61Workhourloglistds_8_tfworkhourlogduration ,
                                             string AV64Workhourloglistds_11_tfworkhourlogdescription_sel ,
                                             string AV63Workhourloglistds_10_tfworkhourlogdescription ,
                                             long AV50EmployeeId ,
                                             DateTime AV48FromDate ,
                                             DateTime AV49ToDate ,
                                             int AV51ProjectIds_Count ,
                                             string A103ProjectName ,
                                             string A148EmployeeName ,
                                             DateTime A119WorkHourLogDate ,
                                             string A120WorkHourLogDuration ,
                                             string A123WorkHourLogDescription ,
                                             long A106EmployeeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.ProjectName, T1.ProjectId, T1.EmployeeId, T1.WorkHourLogDescription, T1.WorkHourLogDuration, T1.WorkHourLogDate, T3.EmployeeName, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ProjectName like '%' || :lV54Workhourloglistds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Workhourloglistds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Workhourloglistds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName like :lV55Workhourloglistds_2_tfemployeename)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Workhourloglistds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV56Workhourloglistds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV56Workhourloglistds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( StringUtil.StrCmp(AV56Workhourloglistds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Workhourloglistds_5_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Workhourloglistds_4_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName like :lV57Workhourloglistds_4_tfprojectname)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Workhourloglistds_5_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV58Workhourloglistds_5_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName = ( :AV58Workhourloglistds_5_tfprojectname_sel))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV58Workhourloglistds_5_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProjectName))=0))");
         }
         if ( ! (DateTime.MinValue==AV59Workhourloglistds_6_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV59Workhourloglistds_6_tfworkhourlogdate)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV60Workhourloglistds_7_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV60Workhourloglistds_7_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Workhourloglistds_9_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Workhourloglistds_8_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV61Workhourloglistds_8_tfworkhourlogduration)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Workhourloglistds_9_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV62Workhourloglistds_9_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV62Workhourloglistds_9_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV62Workhourloglistds_9_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Workhourloglistds_11_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Workhourloglistds_10_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV63Workhourloglistds_10_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Workhourloglistds_11_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV64Workhourloglistds_11_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV64Workhourloglistds_11_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV64Workhourloglistds_11_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( ! (0==AV50EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV50EmployeeId)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV48FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV48FromDate)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV49ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV49ToDate)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV51ProjectIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV51ProjectIds, "T1.ProjectId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.ProjectName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00874( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV51ProjectIds ,
                                             string AV54Workhourloglistds_1_filterfulltext ,
                                             string AV56Workhourloglistds_3_tfemployeename_sel ,
                                             string AV55Workhourloglistds_2_tfemployeename ,
                                             string AV58Workhourloglistds_5_tfprojectname_sel ,
                                             string AV57Workhourloglistds_4_tfprojectname ,
                                             DateTime AV59Workhourloglistds_6_tfworkhourlogdate ,
                                             DateTime AV60Workhourloglistds_7_tfworkhourlogdate_to ,
                                             string AV62Workhourloglistds_9_tfworkhourlogduration_sel ,
                                             string AV61Workhourloglistds_8_tfworkhourlogduration ,
                                             string AV64Workhourloglistds_11_tfworkhourlogdescription_sel ,
                                             string AV63Workhourloglistds_10_tfworkhourlogdescription ,
                                             long AV50EmployeeId ,
                                             DateTime AV48FromDate ,
                                             DateTime AV49ToDate ,
                                             int AV51ProjectIds_Count ,
                                             string A103ProjectName ,
                                             string A148EmployeeName ,
                                             DateTime A119WorkHourLogDate ,
                                             string A120WorkHourLogDuration ,
                                             string A123WorkHourLogDescription ,
                                             long A106EmployeeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[14];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.WorkHourLogDuration, T1.ProjectId, T1.EmployeeId, T1.WorkHourLogDescription, T1.WorkHourLogDate, T3.EmployeeName, T2.ProjectName, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ProjectName like '%' || :lV54Workhourloglistds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Workhourloglistds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Workhourloglistds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName like :lV55Workhourloglistds_2_tfemployeename)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Workhourloglistds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV56Workhourloglistds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV56Workhourloglistds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( StringUtil.StrCmp(AV56Workhourloglistds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Workhourloglistds_5_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Workhourloglistds_4_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName like :lV57Workhourloglistds_4_tfprojectname)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Workhourloglistds_5_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV58Workhourloglistds_5_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName = ( :AV58Workhourloglistds_5_tfprojectname_sel))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV58Workhourloglistds_5_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProjectName))=0))");
         }
         if ( ! (DateTime.MinValue==AV59Workhourloglistds_6_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV59Workhourloglistds_6_tfworkhourlogdate)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV60Workhourloglistds_7_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV60Workhourloglistds_7_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Workhourloglistds_9_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Workhourloglistds_8_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV61Workhourloglistds_8_tfworkhourlogduration)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Workhourloglistds_9_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV62Workhourloglistds_9_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV62Workhourloglistds_9_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV62Workhourloglistds_9_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Workhourloglistds_11_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Workhourloglistds_10_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV63Workhourloglistds_10_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Workhourloglistds_11_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV64Workhourloglistds_11_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV64Workhourloglistds_11_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV64Workhourloglistds_11_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( ! (0==AV50EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV50EmployeeId)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV48FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV48FromDate)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV49ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV49ToDate)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV51ProjectIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV51ProjectIds, "T1.ProjectId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WorkHourLogDuration";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00875( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV51ProjectIds ,
                                             string AV54Workhourloglistds_1_filterfulltext ,
                                             string AV56Workhourloglistds_3_tfemployeename_sel ,
                                             string AV55Workhourloglistds_2_tfemployeename ,
                                             string AV58Workhourloglistds_5_tfprojectname_sel ,
                                             string AV57Workhourloglistds_4_tfprojectname ,
                                             DateTime AV59Workhourloglistds_6_tfworkhourlogdate ,
                                             DateTime AV60Workhourloglistds_7_tfworkhourlogdate_to ,
                                             string AV62Workhourloglistds_9_tfworkhourlogduration_sel ,
                                             string AV61Workhourloglistds_8_tfworkhourlogduration ,
                                             string AV64Workhourloglistds_11_tfworkhourlogdescription_sel ,
                                             string AV63Workhourloglistds_10_tfworkhourlogdescription ,
                                             long AV50EmployeeId ,
                                             DateTime AV48FromDate ,
                                             DateTime AV49ToDate ,
                                             int AV51ProjectIds_Count ,
                                             string A103ProjectName ,
                                             string A148EmployeeName ,
                                             DateTime A119WorkHourLogDate ,
                                             string A120WorkHourLogDuration ,
                                             string A123WorkHourLogDescription ,
                                             long A106EmployeeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[14];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.WorkHourLogDescription, T1.ProjectId, T1.EmployeeId, T1.WorkHourLogDuration, T1.WorkHourLogDate, T3.EmployeeName, T2.ProjectName, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Workhourloglistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ProjectName like '%' || :lV54Workhourloglistds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Workhourloglistds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Workhourloglistds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName like :lV55Workhourloglistds_2_tfemployeename)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Workhourloglistds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV56Workhourloglistds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV56Workhourloglistds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( StringUtil.StrCmp(AV56Workhourloglistds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Workhourloglistds_5_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Workhourloglistds_4_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName like :lV57Workhourloglistds_4_tfprojectname)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Workhourloglistds_5_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV58Workhourloglistds_5_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName = ( :AV58Workhourloglistds_5_tfprojectname_sel))");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( StringUtil.StrCmp(AV58Workhourloglistds_5_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProjectName))=0))");
         }
         if ( ! (DateTime.MinValue==AV59Workhourloglistds_6_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV59Workhourloglistds_6_tfworkhourlogdate)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV60Workhourloglistds_7_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV60Workhourloglistds_7_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Workhourloglistds_9_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Workhourloglistds_8_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV61Workhourloglistds_8_tfworkhourlogduration)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Workhourloglistds_9_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV62Workhourloglistds_9_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV62Workhourloglistds_9_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( StringUtil.StrCmp(AV62Workhourloglistds_9_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Workhourloglistds_11_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Workhourloglistds_10_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV63Workhourloglistds_10_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Workhourloglistds_11_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV64Workhourloglistds_11_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV64Workhourloglistds_11_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( StringUtil.StrCmp(AV64Workhourloglistds_11_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( ! (0==AV50EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV50EmployeeId)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV48FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV48FromDate)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV49ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV49ToDate)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV51ProjectIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV51ProjectIds, "T1.ProjectId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WorkHourLogDescription";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00872(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] );
               case 1 :
                     return conditional_P00873(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] );
               case 2 :
                     return conditional_P00874(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] );
               case 3 :
                     return conditional_P00875(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00872;
          prmP00872 = new Object[] {
          new ParDef("lV54Workhourloglistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Workhourloglistds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV56Workhourloglistds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV57Workhourloglistds_4_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV58Workhourloglistds_5_tfprojectname_sel",GXType.Char,100,0) ,
          new ParDef("AV59Workhourloglistds_6_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV60Workhourloglistds_7_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV61Workhourloglistds_8_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV62Workhourloglistds_9_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("lV63Workhourloglistds_10_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV64Workhourloglistds_11_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV50EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV48FromDate",GXType.Date,8,0) ,
          new ParDef("AV49ToDate",GXType.Date,8,0)
          };
          Object[] prmP00873;
          prmP00873 = new Object[] {
          new ParDef("lV54Workhourloglistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Workhourloglistds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV56Workhourloglistds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV57Workhourloglistds_4_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV58Workhourloglistds_5_tfprojectname_sel",GXType.Char,100,0) ,
          new ParDef("AV59Workhourloglistds_6_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV60Workhourloglistds_7_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV61Workhourloglistds_8_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV62Workhourloglistds_9_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("lV63Workhourloglistds_10_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV64Workhourloglistds_11_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV50EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV48FromDate",GXType.Date,8,0) ,
          new ParDef("AV49ToDate",GXType.Date,8,0)
          };
          Object[] prmP00874;
          prmP00874 = new Object[] {
          new ParDef("lV54Workhourloglistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Workhourloglistds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV56Workhourloglistds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV57Workhourloglistds_4_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV58Workhourloglistds_5_tfprojectname_sel",GXType.Char,100,0) ,
          new ParDef("AV59Workhourloglistds_6_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV60Workhourloglistds_7_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV61Workhourloglistds_8_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV62Workhourloglistds_9_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("lV63Workhourloglistds_10_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV64Workhourloglistds_11_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV50EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV48FromDate",GXType.Date,8,0) ,
          new ParDef("AV49ToDate",GXType.Date,8,0)
          };
          Object[] prmP00875;
          prmP00875 = new Object[] {
          new ParDef("lV54Workhourloglistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Workhourloglistds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV56Workhourloglistds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV57Workhourloglistds_4_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV58Workhourloglistds_5_tfprojectname_sel",GXType.Char,100,0) ,
          new ParDef("AV59Workhourloglistds_6_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV60Workhourloglistds_7_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV61Workhourloglistds_8_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV62Workhourloglistds_9_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("lV63Workhourloglistds_10_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV64Workhourloglistds_11_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV50EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV48FromDate",GXType.Date,8,0) ,
          new ParDef("AV49ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00872", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00872,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00873", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00873,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00874", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00874,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00875", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00875,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
