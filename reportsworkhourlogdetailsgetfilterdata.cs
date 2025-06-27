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
   public class reportsworkhourlogdetailsgetfilterdata : GXProcedure
   {
      public reportsworkhourlogdetailsgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reportsworkhourlogdetailsgetfilterdata( IGxContext context )
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
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV38OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV23Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV20MaxItems = 10;
         AV19PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV34SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV17SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? "" : StringUtil.Substring( AV34SearchTxtParms, 3, -1));
         AV18SkipItems = (short)(AV19PageIndex*AV20MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_PROJECTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPROJECTNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_WORKHOURLOGDURATION") == 0 )
         {
            /* Execute user subroutine: 'LOADWORKHOURLOGDURATIONOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_WORKHOURLOGDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADWORKHOURLOGDESCRIPTIONOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV36OptionsJson = AV23Options.ToJSonString(false);
         AV37OptionsDescJson = AV25OptionsDesc.ToJSonString(false);
         AV38OptionIndexesJson = AV26OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("ReportsWorkHourLogDetailsGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "ReportsWorkHourLogDetailsGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("ReportsWorkHourLogDetailsGridState"), null, "", "");
         }
         AV45GXV1 = 1;
         while ( AV45GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV45GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDATE") == 0 )
            {
               AV11TFWorkHourLogDate = context.localUtil.CToD( AV31GridStateFilterValue.gxTpr_Value, 2);
               AV12TFWorkHourLogDate_To = context.localUtil.CToD( AV31GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME") == 0 )
            {
               AV41TFProjectName = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME_SEL") == 0 )
            {
               AV42TFProjectName_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION") == 0 )
            {
               AV13TFWorkHourLogDuration = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION_SEL") == 0 )
            {
               AV14TFWorkHourLogDuration_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION") == 0 )
            {
               AV15TFWorkHourLogDescription = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION_SEL") == 0 )
            {
               AV16TFWorkHourLogDescription_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV45GXV1 = (int)(AV45GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROJECTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV41TFProjectName = AV17SearchTxt;
         AV42TFProjectName_Sel = "";
         AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate = AV11TFWorkHourLogDate;
         AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to = AV12TFWorkHourLogDate_To;
         AV49Reportsworkhourlogdetailsds_3_tfprojectname = AV41TFProjectName;
         AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel = AV42TFProjectName_Sel;
         AV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration = AV13TFWorkHourLogDuration;
         AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel = AV14TFWorkHourLogDuration_Sel;
         AV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = AV15TFWorkHourLogDescription;
         AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel = AV16TFWorkHourLogDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate ,
                                              AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to ,
                                              AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel ,
                                              AV49Reportsworkhourlogdetailsds_3_tfprojectname ,
                                              AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel ,
                                              AV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration ,
                                              AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel ,
                                              AV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription ,
                                              AV40FromDate ,
                                              AV43ToDate ,
                                              A119WorkHourLogDate ,
                                              A103ProjectName ,
                                              A120WorkHourLogDuration ,
                                              A123WorkHourLogDescription ,
                                              A106EmployeeId ,
                                              AV39EmployeeId ,
                                              A102ProjectId ,
                                              AV44OneProjectId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV49Reportsworkhourlogdetailsds_3_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV49Reportsworkhourlogdetailsds_3_tfprojectname), 100, "%");
         lV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration), "%", "");
         lV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription), "%", "");
         /* Using cursor P009B2 */
         pr_default.execute(0, new Object[] {AV39EmployeeId, AV44OneProjectId, AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate, AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to, lV49Reportsworkhourlogdetailsds_3_tfprojectname, AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel, lV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration, AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel, lV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription, AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel, AV40FromDate, AV43ToDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK9B2 = false;
            A106EmployeeId = P009B2_A106EmployeeId[0];
            A102ProjectId = P009B2_A102ProjectId[0];
            A103ProjectName = P009B2_A103ProjectName[0];
            A123WorkHourLogDescription = P009B2_A123WorkHourLogDescription[0];
            A120WorkHourLogDuration = P009B2_A120WorkHourLogDuration[0];
            A119WorkHourLogDate = P009B2_A119WorkHourLogDate[0];
            A118WorkHourLogId = P009B2_A118WorkHourLogId[0];
            A103ProjectName = P009B2_A103ProjectName[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P009B2_A103ProjectName[0], A103ProjectName) == 0 ) )
            {
               BRK9B2 = false;
               A102ProjectId = P009B2_A102ProjectId[0];
               A118WorkHourLogId = P009B2_A118WorkHourLogId[0];
               AV27count = (long)(AV27count+1);
               BRK9B2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A103ProjectName)) ? "<#Empty#>" : A103ProjectName);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRK9B2 )
            {
               BRK9B2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADWORKHOURLOGDURATIONOPTIONS' Routine */
         returnInSub = false;
         AV13TFWorkHourLogDuration = AV17SearchTxt;
         AV14TFWorkHourLogDuration_Sel = "";
         AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate = AV11TFWorkHourLogDate;
         AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to = AV12TFWorkHourLogDate_To;
         AV49Reportsworkhourlogdetailsds_3_tfprojectname = AV41TFProjectName;
         AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel = AV42TFProjectName_Sel;
         AV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration = AV13TFWorkHourLogDuration;
         AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel = AV14TFWorkHourLogDuration_Sel;
         AV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = AV15TFWorkHourLogDescription;
         AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel = AV16TFWorkHourLogDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate ,
                                              AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to ,
                                              AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel ,
                                              AV49Reportsworkhourlogdetailsds_3_tfprojectname ,
                                              AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel ,
                                              AV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration ,
                                              AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel ,
                                              AV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription ,
                                              AV40FromDate ,
                                              AV43ToDate ,
                                              A119WorkHourLogDate ,
                                              A103ProjectName ,
                                              A120WorkHourLogDuration ,
                                              A123WorkHourLogDescription ,
                                              A106EmployeeId ,
                                              AV39EmployeeId ,
                                              A102ProjectId ,
                                              AV44OneProjectId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV49Reportsworkhourlogdetailsds_3_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV49Reportsworkhourlogdetailsds_3_tfprojectname), 100, "%");
         lV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration), "%", "");
         lV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription), "%", "");
         /* Using cursor P009B3 */
         pr_default.execute(1, new Object[] {AV39EmployeeId, AV44OneProjectId, AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate, AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to, lV49Reportsworkhourlogdetailsds_3_tfprojectname, AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel, lV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration, AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel, lV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription, AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel, AV40FromDate, AV43ToDate});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK9B4 = false;
            A106EmployeeId = P009B3_A106EmployeeId[0];
            A102ProjectId = P009B3_A102ProjectId[0];
            A120WorkHourLogDuration = P009B3_A120WorkHourLogDuration[0];
            A123WorkHourLogDescription = P009B3_A123WorkHourLogDescription[0];
            A103ProjectName = P009B3_A103ProjectName[0];
            A119WorkHourLogDate = P009B3_A119WorkHourLogDate[0];
            A118WorkHourLogId = P009B3_A118WorkHourLogId[0];
            A103ProjectName = P009B3_A103ProjectName[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P009B3_A120WorkHourLogDuration[0], A120WorkHourLogDuration) == 0 ) )
            {
               BRK9B4 = false;
               A118WorkHourLogId = P009B3_A118WorkHourLogId[0];
               AV27count = (long)(AV27count+1);
               BRK9B4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A120WorkHourLogDuration)) ? "<#Empty#>" : A120WorkHourLogDuration);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRK9B4 )
            {
               BRK9B4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADWORKHOURLOGDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV15TFWorkHourLogDescription = AV17SearchTxt;
         AV16TFWorkHourLogDescription_Sel = "";
         AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate = AV11TFWorkHourLogDate;
         AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to = AV12TFWorkHourLogDate_To;
         AV49Reportsworkhourlogdetailsds_3_tfprojectname = AV41TFProjectName;
         AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel = AV42TFProjectName_Sel;
         AV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration = AV13TFWorkHourLogDuration;
         AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel = AV14TFWorkHourLogDuration_Sel;
         AV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = AV15TFWorkHourLogDescription;
         AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel = AV16TFWorkHourLogDescription_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate ,
                                              AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to ,
                                              AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel ,
                                              AV49Reportsworkhourlogdetailsds_3_tfprojectname ,
                                              AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel ,
                                              AV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration ,
                                              AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel ,
                                              AV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription ,
                                              AV40FromDate ,
                                              AV43ToDate ,
                                              A119WorkHourLogDate ,
                                              A103ProjectName ,
                                              A120WorkHourLogDuration ,
                                              A123WorkHourLogDescription ,
                                              A106EmployeeId ,
                                              AV39EmployeeId ,
                                              A102ProjectId ,
                                              AV44OneProjectId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV49Reportsworkhourlogdetailsds_3_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV49Reportsworkhourlogdetailsds_3_tfprojectname), 100, "%");
         lV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration), "%", "");
         lV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription), "%", "");
         /* Using cursor P009B4 */
         pr_default.execute(2, new Object[] {AV39EmployeeId, AV44OneProjectId, AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate, AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to, lV49Reportsworkhourlogdetailsds_3_tfprojectname, AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel, lV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration, AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel, lV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription, AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel, AV40FromDate, AV43ToDate});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK9B6 = false;
            A106EmployeeId = P009B4_A106EmployeeId[0];
            A102ProjectId = P009B4_A102ProjectId[0];
            A123WorkHourLogDescription = P009B4_A123WorkHourLogDescription[0];
            A120WorkHourLogDuration = P009B4_A120WorkHourLogDuration[0];
            A103ProjectName = P009B4_A103ProjectName[0];
            A119WorkHourLogDate = P009B4_A119WorkHourLogDate[0];
            A118WorkHourLogId = P009B4_A118WorkHourLogId[0];
            A103ProjectName = P009B4_A103ProjectName[0];
            AV27count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P009B4_A123WorkHourLogDescription[0], A123WorkHourLogDescription) == 0 ) )
            {
               BRK9B6 = false;
               A118WorkHourLogId = P009B4_A118WorkHourLogId[0];
               AV27count = (long)(AV27count+1);
               BRK9B6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A123WorkHourLogDescription)) ? "<#Empty#>" : A123WorkHourLogDescription);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRK9B6 )
            {
               BRK9B6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV36OptionsJson = "";
         AV37OptionsDescJson = "";
         AV38OptionIndexesJson = "";
         AV23Options = new GxSimpleCollection<string>();
         AV25OptionsDesc = new GxSimpleCollection<string>();
         AV26OptionIndexes = new GxSimpleCollection<string>();
         AV17SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV28Session = context.GetSession();
         AV30GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV31GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV11TFWorkHourLogDate = DateTime.MinValue;
         AV12TFWorkHourLogDate_To = DateTime.MinValue;
         AV41TFProjectName = "";
         AV42TFProjectName_Sel = "";
         AV13TFWorkHourLogDuration = "";
         AV14TFWorkHourLogDuration_Sel = "";
         AV15TFWorkHourLogDescription = "";
         AV16TFWorkHourLogDescription_Sel = "";
         AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate = DateTime.MinValue;
         AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to = DateTime.MinValue;
         AV49Reportsworkhourlogdetailsds_3_tfprojectname = "";
         AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel = "";
         AV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration = "";
         AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel = "";
         AV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = "";
         AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel = "";
         lV49Reportsworkhourlogdetailsds_3_tfprojectname = "";
         lV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration = "";
         lV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = "";
         AV40FromDate = DateTime.MinValue;
         AV43ToDate = DateTime.MinValue;
         A119WorkHourLogDate = DateTime.MinValue;
         A103ProjectName = "";
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         P009B2_A106EmployeeId = new long[1] ;
         P009B2_A102ProjectId = new long[1] ;
         P009B2_A103ProjectName = new string[] {""} ;
         P009B2_A123WorkHourLogDescription = new string[] {""} ;
         P009B2_A120WorkHourLogDuration = new string[] {""} ;
         P009B2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P009B2_A118WorkHourLogId = new long[1] ;
         AV22Option = "";
         P009B3_A106EmployeeId = new long[1] ;
         P009B3_A102ProjectId = new long[1] ;
         P009B3_A120WorkHourLogDuration = new string[] {""} ;
         P009B3_A123WorkHourLogDescription = new string[] {""} ;
         P009B3_A103ProjectName = new string[] {""} ;
         P009B3_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P009B3_A118WorkHourLogId = new long[1] ;
         P009B4_A106EmployeeId = new long[1] ;
         P009B4_A102ProjectId = new long[1] ;
         P009B4_A123WorkHourLogDescription = new string[] {""} ;
         P009B4_A120WorkHourLogDuration = new string[] {""} ;
         P009B4_A103ProjectName = new string[] {""} ;
         P009B4_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P009B4_A118WorkHourLogId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportsworkhourlogdetailsgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P009B2_A106EmployeeId, P009B2_A102ProjectId, P009B2_A103ProjectName, P009B2_A123WorkHourLogDescription, P009B2_A120WorkHourLogDuration, P009B2_A119WorkHourLogDate, P009B2_A118WorkHourLogId
               }
               , new Object[] {
               P009B3_A106EmployeeId, P009B3_A102ProjectId, P009B3_A120WorkHourLogDuration, P009B3_A123WorkHourLogDescription, P009B3_A103ProjectName, P009B3_A119WorkHourLogDate, P009B3_A118WorkHourLogId
               }
               , new Object[] {
               P009B4_A106EmployeeId, P009B4_A102ProjectId, P009B4_A123WorkHourLogDescription, P009B4_A120WorkHourLogDuration, P009B4_A103ProjectName, P009B4_A119WorkHourLogDate, P009B4_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private int AV45GXV1 ;
      private long A106EmployeeId ;
      private long AV39EmployeeId ;
      private long A102ProjectId ;
      private long AV44OneProjectId ;
      private long A118WorkHourLogId ;
      private long AV27count ;
      private string AV41TFProjectName ;
      private string AV42TFProjectName_Sel ;
      private string AV49Reportsworkhourlogdetailsds_3_tfprojectname ;
      private string AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel ;
      private string lV49Reportsworkhourlogdetailsds_3_tfprojectname ;
      private string A103ProjectName ;
      private DateTime AV11TFWorkHourLogDate ;
      private DateTime AV12TFWorkHourLogDate_To ;
      private DateTime AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate ;
      private DateTime AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to ;
      private DateTime AV40FromDate ;
      private DateTime AV43ToDate ;
      private DateTime A119WorkHourLogDate ;
      private bool returnInSub ;
      private bool BRK9B2 ;
      private bool BRK9B4 ;
      private bool BRK9B6 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string A123WorkHourLogDescription ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV13TFWorkHourLogDuration ;
      private string AV14TFWorkHourLogDuration_Sel ;
      private string AV15TFWorkHourLogDescription ;
      private string AV16TFWorkHourLogDescription_Sel ;
      private string AV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration ;
      private string AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel ;
      private string AV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription ;
      private string AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel ;
      private string lV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration ;
      private string lV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription ;
      private string A120WorkHourLogDuration ;
      private string AV22Option ;
      private IGxSession AV28Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV25OptionsDesc ;
      private GxSimpleCollection<string> AV26OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV30GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private long[] P009B2_A106EmployeeId ;
      private long[] P009B2_A102ProjectId ;
      private string[] P009B2_A103ProjectName ;
      private string[] P009B2_A123WorkHourLogDescription ;
      private string[] P009B2_A120WorkHourLogDuration ;
      private DateTime[] P009B2_A119WorkHourLogDate ;
      private long[] P009B2_A118WorkHourLogId ;
      private long[] P009B3_A106EmployeeId ;
      private long[] P009B3_A102ProjectId ;
      private string[] P009B3_A120WorkHourLogDuration ;
      private string[] P009B3_A123WorkHourLogDescription ;
      private string[] P009B3_A103ProjectName ;
      private DateTime[] P009B3_A119WorkHourLogDate ;
      private long[] P009B3_A118WorkHourLogId ;
      private long[] P009B4_A106EmployeeId ;
      private long[] P009B4_A102ProjectId ;
      private string[] P009B4_A123WorkHourLogDescription ;
      private string[] P009B4_A120WorkHourLogDuration ;
      private string[] P009B4_A103ProjectName ;
      private DateTime[] P009B4_A119WorkHourLogDate ;
      private long[] P009B4_A118WorkHourLogId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class reportsworkhourlogdetailsgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009B2( IGxContext context ,
                                             DateTime AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate ,
                                             DateTime AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to ,
                                             string AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel ,
                                             string AV49Reportsworkhourlogdetailsds_3_tfprojectname ,
                                             string AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel ,
                                             string AV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration ,
                                             string AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel ,
                                             string AV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription ,
                                             DateTime AV40FromDate ,
                                             DateTime AV43ToDate ,
                                             DateTime A119WorkHourLogDate ,
                                             string A103ProjectName ,
                                             string A120WorkHourLogDuration ,
                                             string A123WorkHourLogDescription ,
                                             long A106EmployeeId ,
                                             long AV39EmployeeId ,
                                             long A102ProjectId ,
                                             long AV44OneProjectId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T1.ProjectId, T2.ProjectName, T1.WorkHourLogDescription, T1.WorkHourLogDuration, T1.WorkHourLogDate, T1.WorkHourLogId FROM (WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV39EmployeeId)");
         AddWhere(sWhereString, "(T1.ProjectId = :AV44OneProjectId)");
         if ( ! (DateTime.MinValue==AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Reportsworkhourlogdetailsds_3_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName like :lV49Reportsworkhourlogdetailsds_3_tfprojectname)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName = ( :AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProjectName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( ! (DateTime.MinValue==AV40FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV40FromDate)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV43ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV43ToDate)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.ProjectName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P009B3( IGxContext context ,
                                             DateTime AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate ,
                                             DateTime AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to ,
                                             string AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel ,
                                             string AV49Reportsworkhourlogdetailsds_3_tfprojectname ,
                                             string AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel ,
                                             string AV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration ,
                                             string AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel ,
                                             string AV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription ,
                                             DateTime AV40FromDate ,
                                             DateTime AV43ToDate ,
                                             DateTime A119WorkHourLogDate ,
                                             string A103ProjectName ,
                                             string A120WorkHourLogDuration ,
                                             string A123WorkHourLogDescription ,
                                             long A106EmployeeId ,
                                             long AV39EmployeeId ,
                                             long A102ProjectId ,
                                             long AV44OneProjectId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T1.ProjectId, T1.WorkHourLogDuration, T1.WorkHourLogDescription, T2.ProjectName, T1.WorkHourLogDate, T1.WorkHourLogId FROM (WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV39EmployeeId)");
         AddWhere(sWhereString, "(T1.ProjectId = :AV44OneProjectId)");
         if ( ! (DateTime.MinValue==AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Reportsworkhourlogdetailsds_3_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName like :lV49Reportsworkhourlogdetailsds_3_tfprojectname)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName = ( :AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProjectName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( ! (DateTime.MinValue==AV40FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV40FromDate)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV43ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV43ToDate)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WorkHourLogDuration";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P009B4( IGxContext context ,
                                             DateTime AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate ,
                                             DateTime AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to ,
                                             string AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel ,
                                             string AV49Reportsworkhourlogdetailsds_3_tfprojectname ,
                                             string AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel ,
                                             string AV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration ,
                                             string AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel ,
                                             string AV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription ,
                                             DateTime AV40FromDate ,
                                             DateTime AV43ToDate ,
                                             DateTime A119WorkHourLogDate ,
                                             string A103ProjectName ,
                                             string A120WorkHourLogDuration ,
                                             string A123WorkHourLogDescription ,
                                             long A106EmployeeId ,
                                             long AV39EmployeeId ,
                                             long A102ProjectId ,
                                             long AV44OneProjectId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[12];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T1.ProjectId, T1.WorkHourLogDescription, T1.WorkHourLogDuration, T2.ProjectName, T1.WorkHourLogDate, T1.WorkHourLogId FROM (WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV39EmployeeId)");
         AddWhere(sWhereString, "(T1.ProjectId = :AV44OneProjectId)");
         if ( ! (DateTime.MinValue==AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Reportsworkhourlogdetailsds_3_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName like :lV49Reportsworkhourlogdetailsds_3_tfprojectname)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName = ( :AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProjectName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( ! (DateTime.MinValue==AV40FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV40FromDate)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV43ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV43ToDate)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WorkHourLogDescription";
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
                     return conditional_P009B2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] );
               case 1 :
                     return conditional_P009B3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] );
               case 2 :
                     return conditional_P009B4(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] );
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
          Object[] prmP009B2;
          prmP009B2 = new Object[] {
          new ParDef("AV39EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV44OneProjectId",GXType.Int64,10,0) ,
          new ParDef("AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV49Reportsworkhourlogdetailsds_3_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel",GXType.Char,100,0) ,
          new ParDef("lV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("lV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV40FromDate",GXType.Date,8,0) ,
          new ParDef("AV43ToDate",GXType.Date,8,0)
          };
          Object[] prmP009B3;
          prmP009B3 = new Object[] {
          new ParDef("AV39EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV44OneProjectId",GXType.Int64,10,0) ,
          new ParDef("AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV49Reportsworkhourlogdetailsds_3_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel",GXType.Char,100,0) ,
          new ParDef("lV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("lV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV40FromDate",GXType.Date,8,0) ,
          new ParDef("AV43ToDate",GXType.Date,8,0)
          };
          Object[] prmP009B4;
          prmP009B4 = new Object[] {
          new ParDef("AV39EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV44OneProjectId",GXType.Int64,10,0) ,
          new ParDef("AV47Reportsworkhourlogdetailsds_1_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV48Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV49Reportsworkhourlogdetailsds_3_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV50Reportsworkhourlogdetailsds_4_tfprojectname_sel",GXType.Char,100,0) ,
          new ParDef("lV51Reportsworkhourlogdetailsds_5_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV52Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("lV53Reportsworkhourlogdetailsds_7_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV54Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV40FromDate",GXType.Date,8,0) ,
          new ParDef("AV43ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009B2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009B3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009B4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009B4,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
       }
    }

 }

}
