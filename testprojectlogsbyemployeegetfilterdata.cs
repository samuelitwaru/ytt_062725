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
   public class testprojectlogsbyemployeegetfilterdata : GXProcedure
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
            return "testprojectlogsbyemployee_Services_Execute" ;
         }

      }

      public testprojectlogsbyemployeegetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public testprojectlogsbyemployeegetfilterdata( IGxContext context )
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
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV40OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV25Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22MaxItems = 10;
         AV21PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV36SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV19SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? "" : StringUtil.Substring( AV36SearchTxtParms, 3, -1));
         AV20SkipItems = (short)(AV21PageIndex*AV22MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_WORKHOURLOGDURATION") == 0 )
         {
            /* Execute user subroutine: 'LOADWORKHOURLOGDURATIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_WORKHOURLOGDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADWORKHOURLOGDESCRIPTIONOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_PROJECTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPROJECTNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV38OptionsJson = AV25Options.ToJSonString(false);
         AV39OptionsDescJson = AV27OptionsDesc.ToJSonString(false);
         AV40OptionIndexesJson = AV28OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get("TestProjectLogsByEmployeeGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "TestProjectLogsByEmployeeGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("TestProjectLogsByEmployeeGridState"), null, "", "");
         }
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV42GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDATE") == 0 )
            {
               AV11TFWorkHourLogDate = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Value, 2);
               AV12TFWorkHourLogDate_To = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION") == 0 )
            {
               AV13TFWorkHourLogDuration = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION_SEL") == 0 )
            {
               AV14TFWorkHourLogDuration_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION") == 0 )
            {
               AV15TFWorkHourLogDescription = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION_SEL") == 0 )
            {
               AV16TFWorkHourLogDescription_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME") == 0 )
            {
               AV17TFProjectName = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME_SEL") == 0 )
            {
               AV18TFProjectName_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADWORKHOURLOGDURATIONOPTIONS' Routine */
         returnInSub = false;
         AV13TFWorkHourLogDuration = AV19SearchTxt;
         AV14TFWorkHourLogDuration_Sel = "";
         AV44Testprojectlogsbyemployeeds_1_filterfulltext = AV41FilterFullText;
         AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate = AV11TFWorkHourLogDate;
         AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to = AV12TFWorkHourLogDate_To;
         AV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration = AV13TFWorkHourLogDuration;
         AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel = AV14TFWorkHourLogDuration_Sel;
         AV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription = AV15TFWorkHourLogDescription;
         AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel = AV16TFWorkHourLogDescription_Sel;
         AV51Testprojectlogsbyemployeeds_8_tfprojectname = AV17TFProjectName;
         AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel = AV18TFProjectName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV44Testprojectlogsbyemployeeds_1_filterfulltext ,
                                              AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate ,
                                              AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to ,
                                              AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel ,
                                              AV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration ,
                                              AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel ,
                                              AV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription ,
                                              AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel ,
                                              AV51Testprojectlogsbyemployeeds_8_tfprojectname ,
                                              A120WorkHourLogDuration ,
                                              A123WorkHourLogDescription ,
                                              A103ProjectName ,
                                              A119WorkHourLogDate } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV44Testprojectlogsbyemployeeds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Testprojectlogsbyemployeeds_1_filterfulltext), "%", "");
         lV44Testprojectlogsbyemployeeds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Testprojectlogsbyemployeeds_1_filterfulltext), "%", "");
         lV44Testprojectlogsbyemployeeds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Testprojectlogsbyemployeeds_1_filterfulltext), "%", "");
         lV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration), "%", "");
         lV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription), "%", "");
         lV51Testprojectlogsbyemployeeds_8_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV51Testprojectlogsbyemployeeds_8_tfprojectname), 100, "%");
         /* Using cursor P00AF2 */
         pr_default.execute(0, new Object[] {lV44Testprojectlogsbyemployeeds_1_filterfulltext, lV44Testprojectlogsbyemployeeds_1_filterfulltext, lV44Testprojectlogsbyemployeeds_1_filterfulltext, AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate, AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to, lV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration, AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel, lV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription, AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel, lV51Testprojectlogsbyemployeeds_8_tfprojectname, AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAF2 = false;
            A102ProjectId = P00AF2_A102ProjectId[0];
            A120WorkHourLogDuration = P00AF2_A120WorkHourLogDuration[0];
            A119WorkHourLogDate = P00AF2_A119WorkHourLogDate[0];
            A103ProjectName = P00AF2_A103ProjectName[0];
            A123WorkHourLogDescription = P00AF2_A123WorkHourLogDescription[0];
            A118WorkHourLogId = P00AF2_A118WorkHourLogId[0];
            A103ProjectName = P00AF2_A103ProjectName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AF2_A120WorkHourLogDuration[0], A120WorkHourLogDuration) == 0 ) )
            {
               BRKAF2 = false;
               A118WorkHourLogId = P00AF2_A118WorkHourLogId[0];
               AV29count = (long)(AV29count+1);
               BRKAF2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A120WorkHourLogDuration)) ? "<#Empty#>" : A120WorkHourLogDuration);
               AV25Options.Add(AV24Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRKAF2 )
            {
               BRKAF2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADWORKHOURLOGDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV15TFWorkHourLogDescription = AV19SearchTxt;
         AV16TFWorkHourLogDescription_Sel = "";
         AV44Testprojectlogsbyemployeeds_1_filterfulltext = AV41FilterFullText;
         AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate = AV11TFWorkHourLogDate;
         AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to = AV12TFWorkHourLogDate_To;
         AV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration = AV13TFWorkHourLogDuration;
         AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel = AV14TFWorkHourLogDuration_Sel;
         AV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription = AV15TFWorkHourLogDescription;
         AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel = AV16TFWorkHourLogDescription_Sel;
         AV51Testprojectlogsbyemployeeds_8_tfprojectname = AV17TFProjectName;
         AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel = AV18TFProjectName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV44Testprojectlogsbyemployeeds_1_filterfulltext ,
                                              AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate ,
                                              AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to ,
                                              AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel ,
                                              AV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration ,
                                              AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel ,
                                              AV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription ,
                                              AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel ,
                                              AV51Testprojectlogsbyemployeeds_8_tfprojectname ,
                                              A120WorkHourLogDuration ,
                                              A123WorkHourLogDescription ,
                                              A103ProjectName ,
                                              A119WorkHourLogDate } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV44Testprojectlogsbyemployeeds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Testprojectlogsbyemployeeds_1_filterfulltext), "%", "");
         lV44Testprojectlogsbyemployeeds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Testprojectlogsbyemployeeds_1_filterfulltext), "%", "");
         lV44Testprojectlogsbyemployeeds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Testprojectlogsbyemployeeds_1_filterfulltext), "%", "");
         lV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration), "%", "");
         lV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription), "%", "");
         lV51Testprojectlogsbyemployeeds_8_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV51Testprojectlogsbyemployeeds_8_tfprojectname), 100, "%");
         /* Using cursor P00AF3 */
         pr_default.execute(1, new Object[] {lV44Testprojectlogsbyemployeeds_1_filterfulltext, lV44Testprojectlogsbyemployeeds_1_filterfulltext, lV44Testprojectlogsbyemployeeds_1_filterfulltext, AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate, AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to, lV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration, AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel, lV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription, AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel, lV51Testprojectlogsbyemployeeds_8_tfprojectname, AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKAF4 = false;
            A102ProjectId = P00AF3_A102ProjectId[0];
            A123WorkHourLogDescription = P00AF3_A123WorkHourLogDescription[0];
            A119WorkHourLogDate = P00AF3_A119WorkHourLogDate[0];
            A103ProjectName = P00AF3_A103ProjectName[0];
            A120WorkHourLogDuration = P00AF3_A120WorkHourLogDuration[0];
            A118WorkHourLogId = P00AF3_A118WorkHourLogId[0];
            A103ProjectName = P00AF3_A103ProjectName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00AF3_A123WorkHourLogDescription[0], A123WorkHourLogDescription) == 0 ) )
            {
               BRKAF4 = false;
               A118WorkHourLogId = P00AF3_A118WorkHourLogId[0];
               AV29count = (long)(AV29count+1);
               BRKAF4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A123WorkHourLogDescription)) ? "<#Empty#>" : A123WorkHourLogDescription);
               AV25Options.Add(AV24Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRKAF4 )
            {
               BRKAF4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPROJECTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV17TFProjectName = AV19SearchTxt;
         AV18TFProjectName_Sel = "";
         AV44Testprojectlogsbyemployeeds_1_filterfulltext = AV41FilterFullText;
         AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate = AV11TFWorkHourLogDate;
         AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to = AV12TFWorkHourLogDate_To;
         AV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration = AV13TFWorkHourLogDuration;
         AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel = AV14TFWorkHourLogDuration_Sel;
         AV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription = AV15TFWorkHourLogDescription;
         AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel = AV16TFWorkHourLogDescription_Sel;
         AV51Testprojectlogsbyemployeeds_8_tfprojectname = AV17TFProjectName;
         AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel = AV18TFProjectName_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV44Testprojectlogsbyemployeeds_1_filterfulltext ,
                                              AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate ,
                                              AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to ,
                                              AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel ,
                                              AV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration ,
                                              AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel ,
                                              AV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription ,
                                              AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel ,
                                              AV51Testprojectlogsbyemployeeds_8_tfprojectname ,
                                              A120WorkHourLogDuration ,
                                              A123WorkHourLogDescription ,
                                              A103ProjectName ,
                                              A119WorkHourLogDate } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV44Testprojectlogsbyemployeeds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Testprojectlogsbyemployeeds_1_filterfulltext), "%", "");
         lV44Testprojectlogsbyemployeeds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Testprojectlogsbyemployeeds_1_filterfulltext), "%", "");
         lV44Testprojectlogsbyemployeeds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Testprojectlogsbyemployeeds_1_filterfulltext), "%", "");
         lV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration), "%", "");
         lV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription), "%", "");
         lV51Testprojectlogsbyemployeeds_8_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV51Testprojectlogsbyemployeeds_8_tfprojectname), 100, "%");
         /* Using cursor P00AF4 */
         pr_default.execute(2, new Object[] {lV44Testprojectlogsbyemployeeds_1_filterfulltext, lV44Testprojectlogsbyemployeeds_1_filterfulltext, lV44Testprojectlogsbyemployeeds_1_filterfulltext, AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate, AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to, lV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration, AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel, lV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription, AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel, lV51Testprojectlogsbyemployeeds_8_tfprojectname, AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKAF6 = false;
            A102ProjectId = P00AF4_A102ProjectId[0];
            A103ProjectName = P00AF4_A103ProjectName[0];
            A119WorkHourLogDate = P00AF4_A119WorkHourLogDate[0];
            A123WorkHourLogDescription = P00AF4_A123WorkHourLogDescription[0];
            A120WorkHourLogDuration = P00AF4_A120WorkHourLogDuration[0];
            A118WorkHourLogId = P00AF4_A118WorkHourLogId[0];
            A103ProjectName = P00AF4_A103ProjectName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00AF4_A103ProjectName[0], A103ProjectName) == 0 ) )
            {
               BRKAF6 = false;
               A102ProjectId = P00AF4_A102ProjectId[0];
               A118WorkHourLogId = P00AF4_A118WorkHourLogId[0];
               AV29count = (long)(AV29count+1);
               BRKAF6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A103ProjectName)) ? "<#Empty#>" : A103ProjectName);
               AV25Options.Add(AV24Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRKAF6 )
            {
               BRKAF6 = true;
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
         AV38OptionsJson = "";
         AV39OptionsDescJson = "";
         AV40OptionIndexesJson = "";
         AV25Options = new GxSimpleCollection<string>();
         AV27OptionsDesc = new GxSimpleCollection<string>();
         AV28OptionIndexes = new GxSimpleCollection<string>();
         AV19SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV30Session = context.GetSession();
         AV32GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV33GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV41FilterFullText = "";
         AV11TFWorkHourLogDate = DateTime.MinValue;
         AV12TFWorkHourLogDate_To = DateTime.MinValue;
         AV13TFWorkHourLogDuration = "";
         AV14TFWorkHourLogDuration_Sel = "";
         AV15TFWorkHourLogDescription = "";
         AV16TFWorkHourLogDescription_Sel = "";
         AV17TFProjectName = "";
         AV18TFProjectName_Sel = "";
         AV44Testprojectlogsbyemployeeds_1_filterfulltext = "";
         AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate = DateTime.MinValue;
         AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to = DateTime.MinValue;
         AV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration = "";
         AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel = "";
         AV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription = "";
         AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel = "";
         AV51Testprojectlogsbyemployeeds_8_tfprojectname = "";
         AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel = "";
         lV44Testprojectlogsbyemployeeds_1_filterfulltext = "";
         lV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration = "";
         lV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription = "";
         lV51Testprojectlogsbyemployeeds_8_tfprojectname = "";
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         A103ProjectName = "";
         A119WorkHourLogDate = DateTime.MinValue;
         P00AF2_A102ProjectId = new long[1] ;
         P00AF2_A120WorkHourLogDuration = new string[] {""} ;
         P00AF2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00AF2_A103ProjectName = new string[] {""} ;
         P00AF2_A123WorkHourLogDescription = new string[] {""} ;
         P00AF2_A118WorkHourLogId = new long[1] ;
         AV24Option = "";
         P00AF3_A102ProjectId = new long[1] ;
         P00AF3_A123WorkHourLogDescription = new string[] {""} ;
         P00AF3_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00AF3_A103ProjectName = new string[] {""} ;
         P00AF3_A120WorkHourLogDuration = new string[] {""} ;
         P00AF3_A118WorkHourLogId = new long[1] ;
         P00AF4_A102ProjectId = new long[1] ;
         P00AF4_A103ProjectName = new string[] {""} ;
         P00AF4_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00AF4_A123WorkHourLogDescription = new string[] {""} ;
         P00AF4_A120WorkHourLogDuration = new string[] {""} ;
         P00AF4_A118WorkHourLogId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.testprojectlogsbyemployeegetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00AF2_A102ProjectId, P00AF2_A120WorkHourLogDuration, P00AF2_A119WorkHourLogDate, P00AF2_A103ProjectName, P00AF2_A123WorkHourLogDescription, P00AF2_A118WorkHourLogId
               }
               , new Object[] {
               P00AF3_A102ProjectId, P00AF3_A123WorkHourLogDescription, P00AF3_A119WorkHourLogDate, P00AF3_A103ProjectName, P00AF3_A120WorkHourLogDuration, P00AF3_A118WorkHourLogId
               }
               , new Object[] {
               P00AF4_A102ProjectId, P00AF4_A103ProjectName, P00AF4_A119WorkHourLogDate, P00AF4_A123WorkHourLogDescription, P00AF4_A120WorkHourLogDuration, P00AF4_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private int AV42GXV1 ;
      private long A102ProjectId ;
      private long A118WorkHourLogId ;
      private long AV29count ;
      private string AV17TFProjectName ;
      private string AV18TFProjectName_Sel ;
      private string AV51Testprojectlogsbyemployeeds_8_tfprojectname ;
      private string AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel ;
      private string lV51Testprojectlogsbyemployeeds_8_tfprojectname ;
      private string A103ProjectName ;
      private DateTime AV11TFWorkHourLogDate ;
      private DateTime AV12TFWorkHourLogDate_To ;
      private DateTime AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate ;
      private DateTime AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to ;
      private DateTime A119WorkHourLogDate ;
      private bool returnInSub ;
      private bool BRKAF2 ;
      private bool BRKAF4 ;
      private bool BRKAF6 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string A123WorkHourLogDescription ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV13TFWorkHourLogDuration ;
      private string AV14TFWorkHourLogDuration_Sel ;
      private string AV15TFWorkHourLogDescription ;
      private string AV16TFWorkHourLogDescription_Sel ;
      private string AV44Testprojectlogsbyemployeeds_1_filterfulltext ;
      private string AV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration ;
      private string AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel ;
      private string AV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription ;
      private string AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel ;
      private string lV44Testprojectlogsbyemployeeds_1_filterfulltext ;
      private string lV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration ;
      private string lV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription ;
      private string A120WorkHourLogDuration ;
      private string AV24Option ;
      private IGxSession AV30Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV27OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV32GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private long[] P00AF2_A102ProjectId ;
      private string[] P00AF2_A120WorkHourLogDuration ;
      private DateTime[] P00AF2_A119WorkHourLogDate ;
      private string[] P00AF2_A103ProjectName ;
      private string[] P00AF2_A123WorkHourLogDescription ;
      private long[] P00AF2_A118WorkHourLogId ;
      private long[] P00AF3_A102ProjectId ;
      private string[] P00AF3_A123WorkHourLogDescription ;
      private DateTime[] P00AF3_A119WorkHourLogDate ;
      private string[] P00AF3_A103ProjectName ;
      private string[] P00AF3_A120WorkHourLogDuration ;
      private long[] P00AF3_A118WorkHourLogId ;
      private long[] P00AF4_A102ProjectId ;
      private string[] P00AF4_A103ProjectName ;
      private DateTime[] P00AF4_A119WorkHourLogDate ;
      private string[] P00AF4_A123WorkHourLogDescription ;
      private string[] P00AF4_A120WorkHourLogDuration ;
      private long[] P00AF4_A118WorkHourLogId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class testprojectlogsbyemployeegetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AF2( IGxContext context ,
                                             string AV44Testprojectlogsbyemployeeds_1_filterfulltext ,
                                             DateTime AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate ,
                                             DateTime AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to ,
                                             string AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel ,
                                             string AV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration ,
                                             string AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel ,
                                             string AV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription ,
                                             string AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel ,
                                             string AV51Testprojectlogsbyemployeeds_8_tfprojectname ,
                                             string A120WorkHourLogDuration ,
                                             string A123WorkHourLogDescription ,
                                             string A103ProjectName ,
                                             DateTime A119WorkHourLogDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[11];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ProjectId, T1.WorkHourLogDuration, T1.WorkHourLogDate, T2.ProjectName, T1.WorkHourLogDescription, T1.WorkHourLogId FROM (WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Testprojectlogsbyemployeeds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.WorkHourLogDuration like '%' || :lV44Testprojectlogsbyemployeeds_1_filterfulltext) or ( T1.WorkHourLogDescription like '%' || :lV44Testprojectlogsbyemployeeds_1_filterfulltext) or ( T2.ProjectName like '%' || :lV44Testprojectlogsbyemployeeds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Testprojectlogsbyemployeeds_8_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName like :lV51Testprojectlogsbyemployeeds_8_tfprojectname)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName = ( :AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProjectName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WorkHourLogDuration";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00AF3( IGxContext context ,
                                             string AV44Testprojectlogsbyemployeeds_1_filterfulltext ,
                                             DateTime AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate ,
                                             DateTime AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to ,
                                             string AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel ,
                                             string AV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration ,
                                             string AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel ,
                                             string AV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription ,
                                             string AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel ,
                                             string AV51Testprojectlogsbyemployeeds_8_tfprojectname ,
                                             string A120WorkHourLogDuration ,
                                             string A123WorkHourLogDescription ,
                                             string A103ProjectName ,
                                             DateTime A119WorkHourLogDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[11];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ProjectId, T1.WorkHourLogDescription, T1.WorkHourLogDate, T2.ProjectName, T1.WorkHourLogDuration, T1.WorkHourLogId FROM (WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Testprojectlogsbyemployeeds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.WorkHourLogDuration like '%' || :lV44Testprojectlogsbyemployeeds_1_filterfulltext) or ( T1.WorkHourLogDescription like '%' || :lV44Testprojectlogsbyemployeeds_1_filterfulltext) or ( T2.ProjectName like '%' || :lV44Testprojectlogsbyemployeeds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Testprojectlogsbyemployeeds_8_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName like :lV51Testprojectlogsbyemployeeds_8_tfprojectname)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName = ( :AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProjectName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WorkHourLogDescription";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00AF4( IGxContext context ,
                                             string AV44Testprojectlogsbyemployeeds_1_filterfulltext ,
                                             DateTime AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate ,
                                             DateTime AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to ,
                                             string AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel ,
                                             string AV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration ,
                                             string AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel ,
                                             string AV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription ,
                                             string AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel ,
                                             string AV51Testprojectlogsbyemployeeds_8_tfprojectname ,
                                             string A120WorkHourLogDuration ,
                                             string A123WorkHourLogDescription ,
                                             string A103ProjectName ,
                                             DateTime A119WorkHourLogDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[11];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ProjectId, T2.ProjectName, T1.WorkHourLogDate, T1.WorkHourLogDescription, T1.WorkHourLogDuration, T1.WorkHourLogId FROM (WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Testprojectlogsbyemployeeds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.WorkHourLogDuration like '%' || :lV44Testprojectlogsbyemployeeds_1_filterfulltext) or ( T1.WorkHourLogDescription like '%' || :lV44Testprojectlogsbyemployeeds_1_filterfulltext) or ( T2.ProjectName like '%' || :lV44Testprojectlogsbyemployeeds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Testprojectlogsbyemployeeds_8_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName like :lV51Testprojectlogsbyemployeeds_8_tfprojectname)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName = ( :AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProjectName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.ProjectName";
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
                     return conditional_P00AF2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] );
               case 1 :
                     return conditional_P00AF3(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] );
               case 2 :
                     return conditional_P00AF4(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] );
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
          Object[] prmP00AF2;
          prmP00AF2 = new Object[] {
          new ParDef("lV44Testprojectlogsbyemployeeds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Testprojectlogsbyemployeeds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Testprojectlogsbyemployeeds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("lV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV51Testprojectlogsbyemployeeds_8_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel",GXType.Char,100,0)
          };
          Object[] prmP00AF3;
          prmP00AF3 = new Object[] {
          new ParDef("lV44Testprojectlogsbyemployeeds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Testprojectlogsbyemployeeds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Testprojectlogsbyemployeeds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("lV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV51Testprojectlogsbyemployeeds_8_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel",GXType.Char,100,0)
          };
          Object[] prmP00AF4;
          prmP00AF4 = new Object[] {
          new ParDef("lV44Testprojectlogsbyemployeeds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Testprojectlogsbyemployeeds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Testprojectlogsbyemployeeds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV45Testprojectlogsbyemployeeds_2_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV46Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV47Testprojectlogsbyemployeeds_4_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV48Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("lV49Testprojectlogsbyemployeeds_6_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV50Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV51Testprojectlogsbyemployeeds_8_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV52Testprojectlogsbyemployeeds_9_tfprojectname_sel",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AF2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AF2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AF3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AF3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AF4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AF4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
