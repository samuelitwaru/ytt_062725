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
   public class workhourlogwwgetfilterdata : GXProcedure
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
            return "workhourlogww_Services_Execute" ;
         }

      }

      public workhourlogwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workhourlogwwgetfilterdata( IGxContext context )
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
         this.AV45DDOName = aP0_DDOName;
         this.AV46SearchTxtParms = aP1_SearchTxtParms;
         this.AV47SearchTxtTo = aP2_SearchTxtTo;
         this.AV48OptionsJson = "" ;
         this.AV49OptionsDescJson = "" ;
         this.AV50OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV50OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV45DDOName = aP0_DDOName;
         this.AV46SearchTxtParms = aP1_SearchTxtParms;
         this.AV47SearchTxtTo = aP2_SearchTxtTo;
         this.AV48OptionsJson = "" ;
         this.AV49OptionsDescJson = "" ;
         this.AV50OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV35Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV37OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV38OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32MaxItems = 10;
         AV31PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV46SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV29SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? "" : StringUtil.Substring( AV46SearchTxtParms, 3, -1));
         AV30SkipItems = (short)(AV31PageIndex*AV32MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_WORKHOURLOGDURATION") == 0 )
         {
            /* Execute user subroutine: 'LOADWORKHOURLOGDURATIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_WORKHOURLOGDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADWORKHOURLOGDESCRIPTIONOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_EMPLOYEEFIRSTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEEFIRSTNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_PROJECTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPROJECTNAMEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV48OptionsJson = AV35Options.ToJSonString(false);
         AV49OptionsDescJson = AV37OptionsDesc.ToJSonString(false);
         AV50OptionIndexesJson = AV38OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get("WorkHourLogWWGridState"), "") == 0 )
         {
            AV42GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WorkHourLogWWGridState"), null, "", "");
         }
         else
         {
            AV42GridState.FromXml(AV40Session.Get("WorkHourLogWWGridState"), null, "", "");
         }
         AV71GXV1 = 1;
         while ( AV71GXV1 <= AV42GridState.gxTpr_Filtervalues.Count )
         {
            AV43GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV42GridState.gxTpr_Filtervalues.Item(AV71GXV1));
            if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV51FilterFullText = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "WORKHOURLOGDATE") == 0 )
            {
               AV70WorkHourLogDate = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Value, 2);
               AV68WorkHourLogDateOperator = AV43GridStateFilterValue.gxTpr_Operator;
               AV69WorkHourLogDate_To = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDATE") == 0 )
            {
               AV13TFWorkHourLogDate = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Value, 2);
               AV14TFWorkHourLogDate_To = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION") == 0 )
            {
               AV15TFWorkHourLogDuration = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION_SEL") == 0 )
            {
               AV16TFWorkHourLogDuration_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGHOUR") == 0 )
            {
               AV17TFWorkHourLogHour = (short)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV18TFWorkHourLogHour_To = (short)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGMINUTE") == 0 )
            {
               AV19TFWorkHourLogMinute = (short)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV20TFWorkHourLogMinute_To = (short)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION") == 0 )
            {
               AV21TFWorkHourLogDescription = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION_SEL") == 0 )
            {
               AV22TFWorkHourLogDescription_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEFIRSTNAME") == 0 )
            {
               AV52TFEmployeeFirstName = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEFIRSTNAME_SEL") == 0 )
            {
               AV53TFEmployeeFirstName_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME") == 0 )
            {
               AV27TFProjectName = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME_SEL") == 0 )
            {
               AV28TFProjectName_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            AV71GXV1 = (int)(AV71GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADWORKHOURLOGDURATIONOPTIONS' Routine */
         returnInSub = false;
         AV15TFWorkHourLogDuration = AV29SearchTxt;
         AV16TFWorkHourLogDuration_Sel = "";
         AV73Workhourlogwwds_1_filterfulltext = AV51FilterFullText;
         AV74Workhourlogwwds_2_workhourlogdate = AV70WorkHourLogDate;
         AV75Workhourlogwwds_3_workhourlogdate_to = AV69WorkHourLogDate_To;
         AV76Workhourlogwwds_4_tfworkhourlogdate = AV13TFWorkHourLogDate;
         AV77Workhourlogwwds_5_tfworkhourlogdate_to = AV14TFWorkHourLogDate_To;
         AV78Workhourlogwwds_6_tfworkhourlogduration = AV15TFWorkHourLogDuration;
         AV79Workhourlogwwds_7_tfworkhourlogduration_sel = AV16TFWorkHourLogDuration_Sel;
         AV80Workhourlogwwds_8_tfworkhourloghour = AV17TFWorkHourLogHour;
         AV81Workhourlogwwds_9_tfworkhourloghour_to = AV18TFWorkHourLogHour_To;
         AV82Workhourlogwwds_10_tfworkhourlogminute = AV19TFWorkHourLogMinute;
         AV83Workhourlogwwds_11_tfworkhourlogminute_to = AV20TFWorkHourLogMinute_To;
         AV84Workhourlogwwds_12_tfworkhourlogdescription = AV21TFWorkHourLogDescription;
         AV85Workhourlogwwds_13_tfworkhourlogdescription_sel = AV22TFWorkHourLogDescription_Sel;
         AV86Workhourlogwwds_14_tfemployeefirstname = AV52TFEmployeeFirstName;
         AV87Workhourlogwwds_15_tfemployeefirstname_sel = AV53TFEmployeeFirstName_Sel;
         AV88Workhourlogwwds_16_tfprojectname = AV27TFProjectName;
         AV89Workhourlogwwds_17_tfprojectname_sel = AV28TFProjectName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV73Workhourlogwwds_1_filterfulltext ,
                                              AV68WorkHourLogDateOperator ,
                                              AV74Workhourlogwwds_2_workhourlogdate ,
                                              AV75Workhourlogwwds_3_workhourlogdate_to ,
                                              AV76Workhourlogwwds_4_tfworkhourlogdate ,
                                              AV77Workhourlogwwds_5_tfworkhourlogdate_to ,
                                              AV79Workhourlogwwds_7_tfworkhourlogduration_sel ,
                                              AV78Workhourlogwwds_6_tfworkhourlogduration ,
                                              AV80Workhourlogwwds_8_tfworkhourloghour ,
                                              AV81Workhourlogwwds_9_tfworkhourloghour_to ,
                                              AV82Workhourlogwwds_10_tfworkhourlogminute ,
                                              AV83Workhourlogwwds_11_tfworkhourlogminute_to ,
                                              AV85Workhourlogwwds_13_tfworkhourlogdescription_sel ,
                                              AV84Workhourlogwwds_12_tfworkhourlogdescription ,
                                              AV87Workhourlogwwds_15_tfemployeefirstname_sel ,
                                              AV86Workhourlogwwds_14_tfemployeefirstname ,
                                              AV89Workhourlogwwds_17_tfprojectname_sel ,
                                              AV88Workhourlogwwds_16_tfprojectname ,
                                              A120WorkHourLogDuration ,
                                              A121WorkHourLogHour ,
                                              A122WorkHourLogMinute ,
                                              A123WorkHourLogDescription ,
                                              A107EmployeeFirstName ,
                                              A103ProjectName ,
                                              A119WorkHourLogDate } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.DATE
                                              }
         });
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV78Workhourlogwwds_6_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV78Workhourlogwwds_6_tfworkhourlogduration), "%", "");
         lV84Workhourlogwwds_12_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV84Workhourlogwwds_12_tfworkhourlogdescription), "%", "");
         lV86Workhourlogwwds_14_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV86Workhourlogwwds_14_tfemployeefirstname), 100, "%");
         lV88Workhourlogwwds_16_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV88Workhourlogwwds_16_tfprojectname), 100, "%");
         /* Using cursor P006D2 */
         pr_default.execute(0, new Object[] {lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, AV74Workhourlogwwds_2_workhourlogdate, AV74Workhourlogwwds_2_workhourlogdate, AV74Workhourlogwwds_2_workhourlogdate, AV75Workhourlogwwds_3_workhourlogdate_to, AV74Workhourlogwwds_2_workhourlogdate, AV76Workhourlogwwds_4_tfworkhourlogdate, AV77Workhourlogwwds_5_tfworkhourlogdate_to, lV78Workhourlogwwds_6_tfworkhourlogduration, AV79Workhourlogwwds_7_tfworkhourlogduration_sel, AV80Workhourlogwwds_8_tfworkhourloghour, AV81Workhourlogwwds_9_tfworkhourloghour_to, AV82Workhourlogwwds_10_tfworkhourlogminute, AV83Workhourlogwwds_11_tfworkhourlogminute_to, lV84Workhourlogwwds_12_tfworkhourlogdescription, AV85Workhourlogwwds_13_tfworkhourlogdescription_sel, lV86Workhourlogwwds_14_tfemployeefirstname, AV87Workhourlogwwds_15_tfemployeefirstname_sel, lV88Workhourlogwwds_16_tfprojectname, AV89Workhourlogwwds_17_tfprojectname_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6D2 = false;
            A106EmployeeId = P006D2_A106EmployeeId[0];
            A102ProjectId = P006D2_A102ProjectId[0];
            A120WorkHourLogDuration = P006D2_A120WorkHourLogDuration[0];
            A122WorkHourLogMinute = P006D2_A122WorkHourLogMinute[0];
            A121WorkHourLogHour = P006D2_A121WorkHourLogHour[0];
            A119WorkHourLogDate = P006D2_A119WorkHourLogDate[0];
            A103ProjectName = P006D2_A103ProjectName[0];
            A107EmployeeFirstName = P006D2_A107EmployeeFirstName[0];
            A123WorkHourLogDescription = P006D2_A123WorkHourLogDescription[0];
            A118WorkHourLogId = P006D2_A118WorkHourLogId[0];
            A107EmployeeFirstName = P006D2_A107EmployeeFirstName[0];
            A103ProjectName = P006D2_A103ProjectName[0];
            AV39count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006D2_A120WorkHourLogDuration[0], A120WorkHourLogDuration) == 0 ) )
            {
               BRK6D2 = false;
               A118WorkHourLogId = P006D2_A118WorkHourLogId[0];
               AV39count = (long)(AV39count+1);
               BRK6D2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A120WorkHourLogDuration)) ? "<#Empty#>" : A120WorkHourLogDuration);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK6D2 )
            {
               BRK6D2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADWORKHOURLOGDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV21TFWorkHourLogDescription = AV29SearchTxt;
         AV22TFWorkHourLogDescription_Sel = "";
         AV73Workhourlogwwds_1_filterfulltext = AV51FilterFullText;
         AV74Workhourlogwwds_2_workhourlogdate = AV70WorkHourLogDate;
         AV75Workhourlogwwds_3_workhourlogdate_to = AV69WorkHourLogDate_To;
         AV76Workhourlogwwds_4_tfworkhourlogdate = AV13TFWorkHourLogDate;
         AV77Workhourlogwwds_5_tfworkhourlogdate_to = AV14TFWorkHourLogDate_To;
         AV78Workhourlogwwds_6_tfworkhourlogduration = AV15TFWorkHourLogDuration;
         AV79Workhourlogwwds_7_tfworkhourlogduration_sel = AV16TFWorkHourLogDuration_Sel;
         AV80Workhourlogwwds_8_tfworkhourloghour = AV17TFWorkHourLogHour;
         AV81Workhourlogwwds_9_tfworkhourloghour_to = AV18TFWorkHourLogHour_To;
         AV82Workhourlogwwds_10_tfworkhourlogminute = AV19TFWorkHourLogMinute;
         AV83Workhourlogwwds_11_tfworkhourlogminute_to = AV20TFWorkHourLogMinute_To;
         AV84Workhourlogwwds_12_tfworkhourlogdescription = AV21TFWorkHourLogDescription;
         AV85Workhourlogwwds_13_tfworkhourlogdescription_sel = AV22TFWorkHourLogDescription_Sel;
         AV86Workhourlogwwds_14_tfemployeefirstname = AV52TFEmployeeFirstName;
         AV87Workhourlogwwds_15_tfemployeefirstname_sel = AV53TFEmployeeFirstName_Sel;
         AV88Workhourlogwwds_16_tfprojectname = AV27TFProjectName;
         AV89Workhourlogwwds_17_tfprojectname_sel = AV28TFProjectName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV73Workhourlogwwds_1_filterfulltext ,
                                              AV68WorkHourLogDateOperator ,
                                              AV74Workhourlogwwds_2_workhourlogdate ,
                                              AV75Workhourlogwwds_3_workhourlogdate_to ,
                                              AV76Workhourlogwwds_4_tfworkhourlogdate ,
                                              AV77Workhourlogwwds_5_tfworkhourlogdate_to ,
                                              AV79Workhourlogwwds_7_tfworkhourlogduration_sel ,
                                              AV78Workhourlogwwds_6_tfworkhourlogduration ,
                                              AV80Workhourlogwwds_8_tfworkhourloghour ,
                                              AV81Workhourlogwwds_9_tfworkhourloghour_to ,
                                              AV82Workhourlogwwds_10_tfworkhourlogminute ,
                                              AV83Workhourlogwwds_11_tfworkhourlogminute_to ,
                                              AV85Workhourlogwwds_13_tfworkhourlogdescription_sel ,
                                              AV84Workhourlogwwds_12_tfworkhourlogdescription ,
                                              AV87Workhourlogwwds_15_tfemployeefirstname_sel ,
                                              AV86Workhourlogwwds_14_tfemployeefirstname ,
                                              AV89Workhourlogwwds_17_tfprojectname_sel ,
                                              AV88Workhourlogwwds_16_tfprojectname ,
                                              A120WorkHourLogDuration ,
                                              A121WorkHourLogHour ,
                                              A122WorkHourLogMinute ,
                                              A123WorkHourLogDescription ,
                                              A107EmployeeFirstName ,
                                              A103ProjectName ,
                                              A119WorkHourLogDate } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.DATE
                                              }
         });
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV78Workhourlogwwds_6_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV78Workhourlogwwds_6_tfworkhourlogduration), "%", "");
         lV84Workhourlogwwds_12_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV84Workhourlogwwds_12_tfworkhourlogdescription), "%", "");
         lV86Workhourlogwwds_14_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV86Workhourlogwwds_14_tfemployeefirstname), 100, "%");
         lV88Workhourlogwwds_16_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV88Workhourlogwwds_16_tfprojectname), 100, "%");
         /* Using cursor P006D3 */
         pr_default.execute(1, new Object[] {lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, AV74Workhourlogwwds_2_workhourlogdate, AV74Workhourlogwwds_2_workhourlogdate, AV74Workhourlogwwds_2_workhourlogdate, AV75Workhourlogwwds_3_workhourlogdate_to, AV74Workhourlogwwds_2_workhourlogdate, AV76Workhourlogwwds_4_tfworkhourlogdate, AV77Workhourlogwwds_5_tfworkhourlogdate_to, lV78Workhourlogwwds_6_tfworkhourlogduration, AV79Workhourlogwwds_7_tfworkhourlogduration_sel, AV80Workhourlogwwds_8_tfworkhourloghour, AV81Workhourlogwwds_9_tfworkhourloghour_to, AV82Workhourlogwwds_10_tfworkhourlogminute, AV83Workhourlogwwds_11_tfworkhourlogminute_to, lV84Workhourlogwwds_12_tfworkhourlogdescription, AV85Workhourlogwwds_13_tfworkhourlogdescription_sel, lV86Workhourlogwwds_14_tfemployeefirstname, AV87Workhourlogwwds_15_tfemployeefirstname_sel, lV88Workhourlogwwds_16_tfprojectname, AV89Workhourlogwwds_17_tfprojectname_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6D4 = false;
            A106EmployeeId = P006D3_A106EmployeeId[0];
            A102ProjectId = P006D3_A102ProjectId[0];
            A123WorkHourLogDescription = P006D3_A123WorkHourLogDescription[0];
            A122WorkHourLogMinute = P006D3_A122WorkHourLogMinute[0];
            A121WorkHourLogHour = P006D3_A121WorkHourLogHour[0];
            A119WorkHourLogDate = P006D3_A119WorkHourLogDate[0];
            A103ProjectName = P006D3_A103ProjectName[0];
            A107EmployeeFirstName = P006D3_A107EmployeeFirstName[0];
            A120WorkHourLogDuration = P006D3_A120WorkHourLogDuration[0];
            A118WorkHourLogId = P006D3_A118WorkHourLogId[0];
            A107EmployeeFirstName = P006D3_A107EmployeeFirstName[0];
            A103ProjectName = P006D3_A103ProjectName[0];
            AV39count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006D3_A123WorkHourLogDescription[0], A123WorkHourLogDescription) == 0 ) )
            {
               BRK6D4 = false;
               A118WorkHourLogId = P006D3_A118WorkHourLogId[0];
               AV39count = (long)(AV39count+1);
               BRK6D4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A123WorkHourLogDescription)) ? "<#Empty#>" : A123WorkHourLogDescription);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK6D4 )
            {
               BRK6D4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADEMPLOYEEFIRSTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV52TFEmployeeFirstName = AV29SearchTxt;
         AV53TFEmployeeFirstName_Sel = "";
         AV73Workhourlogwwds_1_filterfulltext = AV51FilterFullText;
         AV74Workhourlogwwds_2_workhourlogdate = AV70WorkHourLogDate;
         AV75Workhourlogwwds_3_workhourlogdate_to = AV69WorkHourLogDate_To;
         AV76Workhourlogwwds_4_tfworkhourlogdate = AV13TFWorkHourLogDate;
         AV77Workhourlogwwds_5_tfworkhourlogdate_to = AV14TFWorkHourLogDate_To;
         AV78Workhourlogwwds_6_tfworkhourlogduration = AV15TFWorkHourLogDuration;
         AV79Workhourlogwwds_7_tfworkhourlogduration_sel = AV16TFWorkHourLogDuration_Sel;
         AV80Workhourlogwwds_8_tfworkhourloghour = AV17TFWorkHourLogHour;
         AV81Workhourlogwwds_9_tfworkhourloghour_to = AV18TFWorkHourLogHour_To;
         AV82Workhourlogwwds_10_tfworkhourlogminute = AV19TFWorkHourLogMinute;
         AV83Workhourlogwwds_11_tfworkhourlogminute_to = AV20TFWorkHourLogMinute_To;
         AV84Workhourlogwwds_12_tfworkhourlogdescription = AV21TFWorkHourLogDescription;
         AV85Workhourlogwwds_13_tfworkhourlogdescription_sel = AV22TFWorkHourLogDescription_Sel;
         AV86Workhourlogwwds_14_tfemployeefirstname = AV52TFEmployeeFirstName;
         AV87Workhourlogwwds_15_tfemployeefirstname_sel = AV53TFEmployeeFirstName_Sel;
         AV88Workhourlogwwds_16_tfprojectname = AV27TFProjectName;
         AV89Workhourlogwwds_17_tfprojectname_sel = AV28TFProjectName_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV73Workhourlogwwds_1_filterfulltext ,
                                              AV68WorkHourLogDateOperator ,
                                              AV74Workhourlogwwds_2_workhourlogdate ,
                                              AV75Workhourlogwwds_3_workhourlogdate_to ,
                                              AV76Workhourlogwwds_4_tfworkhourlogdate ,
                                              AV77Workhourlogwwds_5_tfworkhourlogdate_to ,
                                              AV79Workhourlogwwds_7_tfworkhourlogduration_sel ,
                                              AV78Workhourlogwwds_6_tfworkhourlogduration ,
                                              AV80Workhourlogwwds_8_tfworkhourloghour ,
                                              AV81Workhourlogwwds_9_tfworkhourloghour_to ,
                                              AV82Workhourlogwwds_10_tfworkhourlogminute ,
                                              AV83Workhourlogwwds_11_tfworkhourlogminute_to ,
                                              AV85Workhourlogwwds_13_tfworkhourlogdescription_sel ,
                                              AV84Workhourlogwwds_12_tfworkhourlogdescription ,
                                              AV87Workhourlogwwds_15_tfemployeefirstname_sel ,
                                              AV86Workhourlogwwds_14_tfemployeefirstname ,
                                              AV89Workhourlogwwds_17_tfprojectname_sel ,
                                              AV88Workhourlogwwds_16_tfprojectname ,
                                              A120WorkHourLogDuration ,
                                              A121WorkHourLogHour ,
                                              A122WorkHourLogMinute ,
                                              A123WorkHourLogDescription ,
                                              A107EmployeeFirstName ,
                                              A103ProjectName ,
                                              A119WorkHourLogDate } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.DATE
                                              }
         });
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV78Workhourlogwwds_6_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV78Workhourlogwwds_6_tfworkhourlogduration), "%", "");
         lV84Workhourlogwwds_12_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV84Workhourlogwwds_12_tfworkhourlogdescription), "%", "");
         lV86Workhourlogwwds_14_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV86Workhourlogwwds_14_tfemployeefirstname), 100, "%");
         lV88Workhourlogwwds_16_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV88Workhourlogwwds_16_tfprojectname), 100, "%");
         /* Using cursor P006D4 */
         pr_default.execute(2, new Object[] {lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, AV74Workhourlogwwds_2_workhourlogdate, AV74Workhourlogwwds_2_workhourlogdate, AV74Workhourlogwwds_2_workhourlogdate, AV75Workhourlogwwds_3_workhourlogdate_to, AV74Workhourlogwwds_2_workhourlogdate, AV76Workhourlogwwds_4_tfworkhourlogdate, AV77Workhourlogwwds_5_tfworkhourlogdate_to, lV78Workhourlogwwds_6_tfworkhourlogduration, AV79Workhourlogwwds_7_tfworkhourlogduration_sel, AV80Workhourlogwwds_8_tfworkhourloghour, AV81Workhourlogwwds_9_tfworkhourloghour_to, AV82Workhourlogwwds_10_tfworkhourlogminute, AV83Workhourlogwwds_11_tfworkhourlogminute_to, lV84Workhourlogwwds_12_tfworkhourlogdescription, AV85Workhourlogwwds_13_tfworkhourlogdescription_sel, lV86Workhourlogwwds_14_tfemployeefirstname, AV87Workhourlogwwds_15_tfemployeefirstname_sel, lV88Workhourlogwwds_16_tfprojectname, AV89Workhourlogwwds_17_tfprojectname_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6D6 = false;
            A102ProjectId = P006D4_A102ProjectId[0];
            A106EmployeeId = P006D4_A106EmployeeId[0];
            A122WorkHourLogMinute = P006D4_A122WorkHourLogMinute[0];
            A121WorkHourLogHour = P006D4_A121WorkHourLogHour[0];
            A119WorkHourLogDate = P006D4_A119WorkHourLogDate[0];
            A103ProjectName = P006D4_A103ProjectName[0];
            A107EmployeeFirstName = P006D4_A107EmployeeFirstName[0];
            A123WorkHourLogDescription = P006D4_A123WorkHourLogDescription[0];
            A120WorkHourLogDuration = P006D4_A120WorkHourLogDuration[0];
            A118WorkHourLogId = P006D4_A118WorkHourLogId[0];
            A103ProjectName = P006D4_A103ProjectName[0];
            A107EmployeeFirstName = P006D4_A107EmployeeFirstName[0];
            AV39count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P006D4_A106EmployeeId[0] == A106EmployeeId ) )
            {
               BRK6D6 = false;
               A118WorkHourLogId = P006D4_A118WorkHourLogId[0];
               AV39count = (long)(AV39count+1);
               BRK6D6 = true;
               pr_default.readNext(2);
            }
            AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A107EmployeeFirstName)) ? "<#Empty#>" : A107EmployeeFirstName);
            AV33InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV34Option, "<#Empty#>") != 0 ) && ( AV33InsertIndex <= AV35Options.Count ) && ( ( StringUtil.StrCmp(((string)AV35Options.Item(AV33InsertIndex)), AV34Option) < 0 ) || ( StringUtil.StrCmp(((string)AV35Options.Item(AV33InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV33InsertIndex = (int)(AV33InsertIndex+1);
            }
            AV35Options.Add(AV34Option, AV33InsertIndex);
            AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), AV33InsertIndex);
            if ( AV35Options.Count == AV30SkipItems + 11 )
            {
               AV35Options.RemoveItem(AV35Options.Count);
               AV38OptionIndexes.RemoveItem(AV38OptionIndexes.Count);
            }
            if ( ! BRK6D6 )
            {
               BRK6D6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV30SkipItems > 0 )
         {
            AV35Options.RemoveItem(1);
            AV38OptionIndexes.RemoveItem(1);
            AV30SkipItems = (short)(AV30SkipItems-1);
         }
      }

      protected void S151( )
      {
         /* 'LOADPROJECTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV27TFProjectName = AV29SearchTxt;
         AV28TFProjectName_Sel = "";
         AV73Workhourlogwwds_1_filterfulltext = AV51FilterFullText;
         AV74Workhourlogwwds_2_workhourlogdate = AV70WorkHourLogDate;
         AV75Workhourlogwwds_3_workhourlogdate_to = AV69WorkHourLogDate_To;
         AV76Workhourlogwwds_4_tfworkhourlogdate = AV13TFWorkHourLogDate;
         AV77Workhourlogwwds_5_tfworkhourlogdate_to = AV14TFWorkHourLogDate_To;
         AV78Workhourlogwwds_6_tfworkhourlogduration = AV15TFWorkHourLogDuration;
         AV79Workhourlogwwds_7_tfworkhourlogduration_sel = AV16TFWorkHourLogDuration_Sel;
         AV80Workhourlogwwds_8_tfworkhourloghour = AV17TFWorkHourLogHour;
         AV81Workhourlogwwds_9_tfworkhourloghour_to = AV18TFWorkHourLogHour_To;
         AV82Workhourlogwwds_10_tfworkhourlogminute = AV19TFWorkHourLogMinute;
         AV83Workhourlogwwds_11_tfworkhourlogminute_to = AV20TFWorkHourLogMinute_To;
         AV84Workhourlogwwds_12_tfworkhourlogdescription = AV21TFWorkHourLogDescription;
         AV85Workhourlogwwds_13_tfworkhourlogdescription_sel = AV22TFWorkHourLogDescription_Sel;
         AV86Workhourlogwwds_14_tfemployeefirstname = AV52TFEmployeeFirstName;
         AV87Workhourlogwwds_15_tfemployeefirstname_sel = AV53TFEmployeeFirstName_Sel;
         AV88Workhourlogwwds_16_tfprojectname = AV27TFProjectName;
         AV89Workhourlogwwds_17_tfprojectname_sel = AV28TFProjectName_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV73Workhourlogwwds_1_filterfulltext ,
                                              AV68WorkHourLogDateOperator ,
                                              AV74Workhourlogwwds_2_workhourlogdate ,
                                              AV75Workhourlogwwds_3_workhourlogdate_to ,
                                              AV76Workhourlogwwds_4_tfworkhourlogdate ,
                                              AV77Workhourlogwwds_5_tfworkhourlogdate_to ,
                                              AV79Workhourlogwwds_7_tfworkhourlogduration_sel ,
                                              AV78Workhourlogwwds_6_tfworkhourlogduration ,
                                              AV80Workhourlogwwds_8_tfworkhourloghour ,
                                              AV81Workhourlogwwds_9_tfworkhourloghour_to ,
                                              AV82Workhourlogwwds_10_tfworkhourlogminute ,
                                              AV83Workhourlogwwds_11_tfworkhourlogminute_to ,
                                              AV85Workhourlogwwds_13_tfworkhourlogdescription_sel ,
                                              AV84Workhourlogwwds_12_tfworkhourlogdescription ,
                                              AV87Workhourlogwwds_15_tfemployeefirstname_sel ,
                                              AV86Workhourlogwwds_14_tfemployeefirstname ,
                                              AV89Workhourlogwwds_17_tfprojectname_sel ,
                                              AV88Workhourlogwwds_16_tfprojectname ,
                                              A120WorkHourLogDuration ,
                                              A121WorkHourLogHour ,
                                              A122WorkHourLogMinute ,
                                              A123WorkHourLogDescription ,
                                              A107EmployeeFirstName ,
                                              A103ProjectName ,
                                              A119WorkHourLogDate } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.DATE
                                              }
         });
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV73Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext), "%", "");
         lV78Workhourlogwwds_6_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV78Workhourlogwwds_6_tfworkhourlogduration), "%", "");
         lV84Workhourlogwwds_12_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV84Workhourlogwwds_12_tfworkhourlogdescription), "%", "");
         lV86Workhourlogwwds_14_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV86Workhourlogwwds_14_tfemployeefirstname), 100, "%");
         lV88Workhourlogwwds_16_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV88Workhourlogwwds_16_tfprojectname), 100, "%");
         /* Using cursor P006D5 */
         pr_default.execute(3, new Object[] {lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, lV73Workhourlogwwds_1_filterfulltext, AV74Workhourlogwwds_2_workhourlogdate, AV74Workhourlogwwds_2_workhourlogdate, AV74Workhourlogwwds_2_workhourlogdate, AV75Workhourlogwwds_3_workhourlogdate_to, AV74Workhourlogwwds_2_workhourlogdate, AV76Workhourlogwwds_4_tfworkhourlogdate, AV77Workhourlogwwds_5_tfworkhourlogdate_to, lV78Workhourlogwwds_6_tfworkhourlogduration, AV79Workhourlogwwds_7_tfworkhourlogduration_sel, AV80Workhourlogwwds_8_tfworkhourloghour, AV81Workhourlogwwds_9_tfworkhourloghour_to, AV82Workhourlogwwds_10_tfworkhourlogminute, AV83Workhourlogwwds_11_tfworkhourlogminute_to, lV84Workhourlogwwds_12_tfworkhourlogdescription, AV85Workhourlogwwds_13_tfworkhourlogdescription_sel, lV86Workhourlogwwds_14_tfemployeefirstname, AV87Workhourlogwwds_15_tfemployeefirstname_sel, lV88Workhourlogwwds_16_tfprojectname, AV89Workhourlogwwds_17_tfprojectname_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK6D8 = false;
            A106EmployeeId = P006D5_A106EmployeeId[0];
            A102ProjectId = P006D5_A102ProjectId[0];
            A103ProjectName = P006D5_A103ProjectName[0];
            A122WorkHourLogMinute = P006D5_A122WorkHourLogMinute[0];
            A121WorkHourLogHour = P006D5_A121WorkHourLogHour[0];
            A119WorkHourLogDate = P006D5_A119WorkHourLogDate[0];
            A107EmployeeFirstName = P006D5_A107EmployeeFirstName[0];
            A123WorkHourLogDescription = P006D5_A123WorkHourLogDescription[0];
            A120WorkHourLogDuration = P006D5_A120WorkHourLogDuration[0];
            A118WorkHourLogId = P006D5_A118WorkHourLogId[0];
            A107EmployeeFirstName = P006D5_A107EmployeeFirstName[0];
            A103ProjectName = P006D5_A103ProjectName[0];
            AV39count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P006D5_A103ProjectName[0], A103ProjectName) == 0 ) )
            {
               BRK6D8 = false;
               A102ProjectId = P006D5_A102ProjectId[0];
               A118WorkHourLogId = P006D5_A118WorkHourLogId[0];
               AV39count = (long)(AV39count+1);
               BRK6D8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A103ProjectName)) ? "<#Empty#>" : A103ProjectName);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK6D8 )
            {
               BRK6D8 = true;
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
         AV48OptionsJson = "";
         AV49OptionsDescJson = "";
         AV50OptionIndexesJson = "";
         AV35Options = new GxSimpleCollection<string>();
         AV37OptionsDesc = new GxSimpleCollection<string>();
         AV38OptionIndexes = new GxSimpleCollection<string>();
         AV29SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV42GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV43GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV51FilterFullText = "";
         AV70WorkHourLogDate = DateTime.MinValue;
         AV69WorkHourLogDate_To = DateTime.MinValue;
         AV13TFWorkHourLogDate = DateTime.MinValue;
         AV14TFWorkHourLogDate_To = DateTime.MinValue;
         AV15TFWorkHourLogDuration = "";
         AV16TFWorkHourLogDuration_Sel = "";
         AV21TFWorkHourLogDescription = "";
         AV22TFWorkHourLogDescription_Sel = "";
         AV52TFEmployeeFirstName = "";
         AV53TFEmployeeFirstName_Sel = "";
         AV27TFProjectName = "";
         AV28TFProjectName_Sel = "";
         AV73Workhourlogwwds_1_filterfulltext = "";
         AV74Workhourlogwwds_2_workhourlogdate = DateTime.MinValue;
         AV75Workhourlogwwds_3_workhourlogdate_to = DateTime.MinValue;
         AV76Workhourlogwwds_4_tfworkhourlogdate = DateTime.MinValue;
         AV77Workhourlogwwds_5_tfworkhourlogdate_to = DateTime.MinValue;
         AV78Workhourlogwwds_6_tfworkhourlogduration = "";
         AV79Workhourlogwwds_7_tfworkhourlogduration_sel = "";
         AV84Workhourlogwwds_12_tfworkhourlogdescription = "";
         AV85Workhourlogwwds_13_tfworkhourlogdescription_sel = "";
         AV86Workhourlogwwds_14_tfemployeefirstname = "";
         AV87Workhourlogwwds_15_tfemployeefirstname_sel = "";
         AV88Workhourlogwwds_16_tfprojectname = "";
         AV89Workhourlogwwds_17_tfprojectname_sel = "";
         lV73Workhourlogwwds_1_filterfulltext = "";
         lV78Workhourlogwwds_6_tfworkhourlogduration = "";
         lV84Workhourlogwwds_12_tfworkhourlogdescription = "";
         lV86Workhourlogwwds_14_tfemployeefirstname = "";
         lV88Workhourlogwwds_16_tfprojectname = "";
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         A107EmployeeFirstName = "";
         A103ProjectName = "";
         A119WorkHourLogDate = DateTime.MinValue;
         P006D2_A106EmployeeId = new long[1] ;
         P006D2_A102ProjectId = new long[1] ;
         P006D2_A120WorkHourLogDuration = new string[] {""} ;
         P006D2_A122WorkHourLogMinute = new short[1] ;
         P006D2_A121WorkHourLogHour = new short[1] ;
         P006D2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P006D2_A103ProjectName = new string[] {""} ;
         P006D2_A107EmployeeFirstName = new string[] {""} ;
         P006D2_A123WorkHourLogDescription = new string[] {""} ;
         P006D2_A118WorkHourLogId = new long[1] ;
         AV34Option = "";
         P006D3_A106EmployeeId = new long[1] ;
         P006D3_A102ProjectId = new long[1] ;
         P006D3_A123WorkHourLogDescription = new string[] {""} ;
         P006D3_A122WorkHourLogMinute = new short[1] ;
         P006D3_A121WorkHourLogHour = new short[1] ;
         P006D3_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P006D3_A103ProjectName = new string[] {""} ;
         P006D3_A107EmployeeFirstName = new string[] {""} ;
         P006D3_A120WorkHourLogDuration = new string[] {""} ;
         P006D3_A118WorkHourLogId = new long[1] ;
         P006D4_A102ProjectId = new long[1] ;
         P006D4_A106EmployeeId = new long[1] ;
         P006D4_A122WorkHourLogMinute = new short[1] ;
         P006D4_A121WorkHourLogHour = new short[1] ;
         P006D4_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P006D4_A103ProjectName = new string[] {""} ;
         P006D4_A107EmployeeFirstName = new string[] {""} ;
         P006D4_A123WorkHourLogDescription = new string[] {""} ;
         P006D4_A120WorkHourLogDuration = new string[] {""} ;
         P006D4_A118WorkHourLogId = new long[1] ;
         P006D5_A106EmployeeId = new long[1] ;
         P006D5_A102ProjectId = new long[1] ;
         P006D5_A103ProjectName = new string[] {""} ;
         P006D5_A122WorkHourLogMinute = new short[1] ;
         P006D5_A121WorkHourLogHour = new short[1] ;
         P006D5_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P006D5_A107EmployeeFirstName = new string[] {""} ;
         P006D5_A123WorkHourLogDescription = new string[] {""} ;
         P006D5_A120WorkHourLogDuration = new string[] {""} ;
         P006D5_A118WorkHourLogId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workhourlogwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006D2_A106EmployeeId, P006D2_A102ProjectId, P006D2_A120WorkHourLogDuration, P006D2_A122WorkHourLogMinute, P006D2_A121WorkHourLogHour, P006D2_A119WorkHourLogDate, P006D2_A103ProjectName, P006D2_A107EmployeeFirstName, P006D2_A123WorkHourLogDescription, P006D2_A118WorkHourLogId
               }
               , new Object[] {
               P006D3_A106EmployeeId, P006D3_A102ProjectId, P006D3_A123WorkHourLogDescription, P006D3_A122WorkHourLogMinute, P006D3_A121WorkHourLogHour, P006D3_A119WorkHourLogDate, P006D3_A103ProjectName, P006D3_A107EmployeeFirstName, P006D3_A120WorkHourLogDuration, P006D3_A118WorkHourLogId
               }
               , new Object[] {
               P006D4_A102ProjectId, P006D4_A106EmployeeId, P006D4_A122WorkHourLogMinute, P006D4_A121WorkHourLogHour, P006D4_A119WorkHourLogDate, P006D4_A103ProjectName, P006D4_A107EmployeeFirstName, P006D4_A123WorkHourLogDescription, P006D4_A120WorkHourLogDuration, P006D4_A118WorkHourLogId
               }
               , new Object[] {
               P006D5_A106EmployeeId, P006D5_A102ProjectId, P006D5_A103ProjectName, P006D5_A122WorkHourLogMinute, P006D5_A121WorkHourLogHour, P006D5_A119WorkHourLogDate, P006D5_A107EmployeeFirstName, P006D5_A123WorkHourLogDescription, P006D5_A120WorkHourLogDuration, P006D5_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV32MaxItems ;
      private short AV31PageIndex ;
      private short AV30SkipItems ;
      private short AV68WorkHourLogDateOperator ;
      private short AV17TFWorkHourLogHour ;
      private short AV18TFWorkHourLogHour_To ;
      private short AV19TFWorkHourLogMinute ;
      private short AV20TFWorkHourLogMinute_To ;
      private short AV80Workhourlogwwds_8_tfworkhourloghour ;
      private short AV81Workhourlogwwds_9_tfworkhourloghour_to ;
      private short AV82Workhourlogwwds_10_tfworkhourlogminute ;
      private short AV83Workhourlogwwds_11_tfworkhourlogminute_to ;
      private short A121WorkHourLogHour ;
      private short A122WorkHourLogMinute ;
      private int AV71GXV1 ;
      private int AV33InsertIndex ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A118WorkHourLogId ;
      private long AV39count ;
      private string AV52TFEmployeeFirstName ;
      private string AV53TFEmployeeFirstName_Sel ;
      private string AV27TFProjectName ;
      private string AV28TFProjectName_Sel ;
      private string AV86Workhourlogwwds_14_tfemployeefirstname ;
      private string AV87Workhourlogwwds_15_tfemployeefirstname_sel ;
      private string AV88Workhourlogwwds_16_tfprojectname ;
      private string AV89Workhourlogwwds_17_tfprojectname_sel ;
      private string lV86Workhourlogwwds_14_tfemployeefirstname ;
      private string lV88Workhourlogwwds_16_tfprojectname ;
      private string A107EmployeeFirstName ;
      private string A103ProjectName ;
      private DateTime AV70WorkHourLogDate ;
      private DateTime AV69WorkHourLogDate_To ;
      private DateTime AV13TFWorkHourLogDate ;
      private DateTime AV14TFWorkHourLogDate_To ;
      private DateTime AV74Workhourlogwwds_2_workhourlogdate ;
      private DateTime AV75Workhourlogwwds_3_workhourlogdate_to ;
      private DateTime AV76Workhourlogwwds_4_tfworkhourlogdate ;
      private DateTime AV77Workhourlogwwds_5_tfworkhourlogdate_to ;
      private DateTime A119WorkHourLogDate ;
      private bool returnInSub ;
      private bool BRK6D2 ;
      private bool BRK6D4 ;
      private bool BRK6D6 ;
      private bool BRK6D8 ;
      private string AV48OptionsJson ;
      private string AV49OptionsDescJson ;
      private string AV50OptionIndexesJson ;
      private string A123WorkHourLogDescription ;
      private string AV45DDOName ;
      private string AV46SearchTxtParms ;
      private string AV47SearchTxtTo ;
      private string AV29SearchTxt ;
      private string AV51FilterFullText ;
      private string AV15TFWorkHourLogDuration ;
      private string AV16TFWorkHourLogDuration_Sel ;
      private string AV21TFWorkHourLogDescription ;
      private string AV22TFWorkHourLogDescription_Sel ;
      private string AV73Workhourlogwwds_1_filterfulltext ;
      private string AV78Workhourlogwwds_6_tfworkhourlogduration ;
      private string AV79Workhourlogwwds_7_tfworkhourlogduration_sel ;
      private string AV84Workhourlogwwds_12_tfworkhourlogdescription ;
      private string AV85Workhourlogwwds_13_tfworkhourlogdescription_sel ;
      private string lV73Workhourlogwwds_1_filterfulltext ;
      private string lV78Workhourlogwwds_6_tfworkhourlogduration ;
      private string lV84Workhourlogwwds_12_tfworkhourlogdescription ;
      private string A120WorkHourLogDuration ;
      private string AV34Option ;
      private IGxSession AV40Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV35Options ;
      private GxSimpleCollection<string> AV37OptionsDesc ;
      private GxSimpleCollection<string> AV38OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV42GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV43GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private long[] P006D2_A106EmployeeId ;
      private long[] P006D2_A102ProjectId ;
      private string[] P006D2_A120WorkHourLogDuration ;
      private short[] P006D2_A122WorkHourLogMinute ;
      private short[] P006D2_A121WorkHourLogHour ;
      private DateTime[] P006D2_A119WorkHourLogDate ;
      private string[] P006D2_A103ProjectName ;
      private string[] P006D2_A107EmployeeFirstName ;
      private string[] P006D2_A123WorkHourLogDescription ;
      private long[] P006D2_A118WorkHourLogId ;
      private long[] P006D3_A106EmployeeId ;
      private long[] P006D3_A102ProjectId ;
      private string[] P006D3_A123WorkHourLogDescription ;
      private short[] P006D3_A122WorkHourLogMinute ;
      private short[] P006D3_A121WorkHourLogHour ;
      private DateTime[] P006D3_A119WorkHourLogDate ;
      private string[] P006D3_A103ProjectName ;
      private string[] P006D3_A107EmployeeFirstName ;
      private string[] P006D3_A120WorkHourLogDuration ;
      private long[] P006D3_A118WorkHourLogId ;
      private long[] P006D4_A102ProjectId ;
      private long[] P006D4_A106EmployeeId ;
      private short[] P006D4_A122WorkHourLogMinute ;
      private short[] P006D4_A121WorkHourLogHour ;
      private DateTime[] P006D4_A119WorkHourLogDate ;
      private string[] P006D4_A103ProjectName ;
      private string[] P006D4_A107EmployeeFirstName ;
      private string[] P006D4_A123WorkHourLogDescription ;
      private string[] P006D4_A120WorkHourLogDuration ;
      private long[] P006D4_A118WorkHourLogId ;
      private long[] P006D5_A106EmployeeId ;
      private long[] P006D5_A102ProjectId ;
      private string[] P006D5_A103ProjectName ;
      private short[] P006D5_A122WorkHourLogMinute ;
      private short[] P006D5_A121WorkHourLogHour ;
      private DateTime[] P006D5_A119WorkHourLogDate ;
      private string[] P006D5_A107EmployeeFirstName ;
      private string[] P006D5_A123WorkHourLogDescription ;
      private string[] P006D5_A120WorkHourLogDuration ;
      private long[] P006D5_A118WorkHourLogId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class workhourlogwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006D2( IGxContext context ,
                                             string AV73Workhourlogwwds_1_filterfulltext ,
                                             short AV68WorkHourLogDateOperator ,
                                             DateTime AV74Workhourlogwwds_2_workhourlogdate ,
                                             DateTime AV75Workhourlogwwds_3_workhourlogdate_to ,
                                             DateTime AV76Workhourlogwwds_4_tfworkhourlogdate ,
                                             DateTime AV77Workhourlogwwds_5_tfworkhourlogdate_to ,
                                             string AV79Workhourlogwwds_7_tfworkhourlogduration_sel ,
                                             string AV78Workhourlogwwds_6_tfworkhourlogduration ,
                                             short AV80Workhourlogwwds_8_tfworkhourloghour ,
                                             short AV81Workhourlogwwds_9_tfworkhourloghour_to ,
                                             short AV82Workhourlogwwds_10_tfworkhourlogminute ,
                                             short AV83Workhourlogwwds_11_tfworkhourlogminute_to ,
                                             string AV85Workhourlogwwds_13_tfworkhourlogdescription_sel ,
                                             string AV84Workhourlogwwds_12_tfworkhourlogdescription ,
                                             string AV87Workhourlogwwds_15_tfemployeefirstname_sel ,
                                             string AV86Workhourlogwwds_14_tfemployeefirstname ,
                                             string AV89Workhourlogwwds_17_tfprojectname_sel ,
                                             string AV88Workhourlogwwds_16_tfprojectname ,
                                             string A120WorkHourLogDuration ,
                                             short A121WorkHourLogHour ,
                                             short A122WorkHourLogMinute ,
                                             string A123WorkHourLogDescription ,
                                             string A107EmployeeFirstName ,
                                             string A103ProjectName ,
                                             DateTime A119WorkHourLogDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[25];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T1.ProjectId, T1.WorkHourLogDuration, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogDate, T3.ProjectName, T2.EmployeeFirstName, T1.WorkHourLogDescription, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = T1.ProjectId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.WorkHourLogDuration like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogHour,'9999'), 2) like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogMinute,'9999'), 2) like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( T1.WorkHourLogDescription like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( T2.EmployeeFirstName like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( T3.ProjectName like '%' || :lV73Workhourlogwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
         }
         if ( ( AV68WorkHourLogDateOperator == 0 ) && ( ! (DateTime.MinValue==AV74Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate < :AV74Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ( AV68WorkHourLogDateOperator == 1 ) && ( ! (DateTime.MinValue==AV74Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate = :AV74Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ( ( AV68WorkHourLogDateOperator == 2 ) || ( AV68WorkHourLogDateOperator == 3 ) ) && ( ! (DateTime.MinValue==AV74Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate > :AV74Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ( ( AV68WorkHourLogDateOperator == 2 ) || ( AV68WorkHourLogDateOperator == 3 ) || ( AV68WorkHourLogDateOperator == 4 ) ) && ( ! (DateTime.MinValue==AV75Workhourlogwwds_3_workhourlogdate_to) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV75Workhourlogwwds_3_workhourlogdate_to)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ( AV68WorkHourLogDateOperator == 4 ) && ( ! (DateTime.MinValue==AV74Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV74Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Workhourlogwwds_4_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV76Workhourlogwwds_4_tfworkhourlogdate)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Workhourlogwwds_5_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV77Workhourlogwwds_5_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Workhourlogwwds_7_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Workhourlogwwds_6_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV78Workhourlogwwds_6_tfworkhourlogduration)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Workhourlogwwds_7_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV79Workhourlogwwds_7_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV79Workhourlogwwds_7_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV79Workhourlogwwds_7_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( ! (0==AV80Workhourlogwwds_8_tfworkhourloghour) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour >= :AV80Workhourlogwwds_8_tfworkhourloghour)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! (0==AV81Workhourlogwwds_9_tfworkhourloghour_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour <= :AV81Workhourlogwwds_9_tfworkhourloghour_to)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! (0==AV82Workhourlogwwds_10_tfworkhourlogminute) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute >= :AV82Workhourlogwwds_10_tfworkhourlogminute)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! (0==AV83Workhourlogwwds_11_tfworkhourlogminute_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute <= :AV83Workhourlogwwds_11_tfworkhourlogminute_to)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Workhourlogwwds_13_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Workhourlogwwds_12_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV84Workhourlogwwds_12_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Workhourlogwwds_13_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV85Workhourlogwwds_13_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV85Workhourlogwwds_13_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( StringUtil.StrCmp(AV85Workhourlogwwds_13_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Workhourlogwwds_15_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Workhourlogwwds_14_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeFirstName like :lV86Workhourlogwwds_14_tfemployeefirstname)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Workhourlogwwds_15_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV87Workhourlogwwds_15_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeFirstName = ( :AV87Workhourlogwwds_15_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( StringUtil.StrCmp(AV87Workhourlogwwds_15_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeFirstName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Workhourlogwwds_17_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Workhourlogwwds_16_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T3.ProjectName like :lV88Workhourlogwwds_16_tfprojectname)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Workhourlogwwds_17_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV89Workhourlogwwds_17_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProjectName = ( :AV89Workhourlogwwds_17_tfprojectname_sel))");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( StringUtil.StrCmp(AV89Workhourlogwwds_17_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProjectName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WorkHourLogDuration";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006D3( IGxContext context ,
                                             string AV73Workhourlogwwds_1_filterfulltext ,
                                             short AV68WorkHourLogDateOperator ,
                                             DateTime AV74Workhourlogwwds_2_workhourlogdate ,
                                             DateTime AV75Workhourlogwwds_3_workhourlogdate_to ,
                                             DateTime AV76Workhourlogwwds_4_tfworkhourlogdate ,
                                             DateTime AV77Workhourlogwwds_5_tfworkhourlogdate_to ,
                                             string AV79Workhourlogwwds_7_tfworkhourlogduration_sel ,
                                             string AV78Workhourlogwwds_6_tfworkhourlogduration ,
                                             short AV80Workhourlogwwds_8_tfworkhourloghour ,
                                             short AV81Workhourlogwwds_9_tfworkhourloghour_to ,
                                             short AV82Workhourlogwwds_10_tfworkhourlogminute ,
                                             short AV83Workhourlogwwds_11_tfworkhourlogminute_to ,
                                             string AV85Workhourlogwwds_13_tfworkhourlogdescription_sel ,
                                             string AV84Workhourlogwwds_12_tfworkhourlogdescription ,
                                             string AV87Workhourlogwwds_15_tfemployeefirstname_sel ,
                                             string AV86Workhourlogwwds_14_tfemployeefirstname ,
                                             string AV89Workhourlogwwds_17_tfprojectname_sel ,
                                             string AV88Workhourlogwwds_16_tfprojectname ,
                                             string A120WorkHourLogDuration ,
                                             short A121WorkHourLogHour ,
                                             short A122WorkHourLogMinute ,
                                             string A123WorkHourLogDescription ,
                                             string A107EmployeeFirstName ,
                                             string A103ProjectName ,
                                             DateTime A119WorkHourLogDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[25];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T1.ProjectId, T1.WorkHourLogDescription, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogDate, T3.ProjectName, T2.EmployeeFirstName, T1.WorkHourLogDuration, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = T1.ProjectId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.WorkHourLogDuration like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogHour,'9999'), 2) like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogMinute,'9999'), 2) like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( T1.WorkHourLogDescription like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( T2.EmployeeFirstName like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( T3.ProjectName like '%' || :lV73Workhourlogwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
         }
         if ( ( AV68WorkHourLogDateOperator == 0 ) && ( ! (DateTime.MinValue==AV74Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate < :AV74Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( AV68WorkHourLogDateOperator == 1 ) && ( ! (DateTime.MinValue==AV74Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate = :AV74Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( ( AV68WorkHourLogDateOperator == 2 ) || ( AV68WorkHourLogDateOperator == 3 ) ) && ( ! (DateTime.MinValue==AV74Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate > :AV74Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ( ( AV68WorkHourLogDateOperator == 2 ) || ( AV68WorkHourLogDateOperator == 3 ) || ( AV68WorkHourLogDateOperator == 4 ) ) && ( ! (DateTime.MinValue==AV75Workhourlogwwds_3_workhourlogdate_to) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV75Workhourlogwwds_3_workhourlogdate_to)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ( AV68WorkHourLogDateOperator == 4 ) && ( ! (DateTime.MinValue==AV74Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV74Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Workhourlogwwds_4_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV76Workhourlogwwds_4_tfworkhourlogdate)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Workhourlogwwds_5_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV77Workhourlogwwds_5_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Workhourlogwwds_7_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Workhourlogwwds_6_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV78Workhourlogwwds_6_tfworkhourlogduration)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Workhourlogwwds_7_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV79Workhourlogwwds_7_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV79Workhourlogwwds_7_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV79Workhourlogwwds_7_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( ! (0==AV80Workhourlogwwds_8_tfworkhourloghour) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour >= :AV80Workhourlogwwds_8_tfworkhourloghour)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! (0==AV81Workhourlogwwds_9_tfworkhourloghour_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour <= :AV81Workhourlogwwds_9_tfworkhourloghour_to)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! (0==AV82Workhourlogwwds_10_tfworkhourlogminute) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute >= :AV82Workhourlogwwds_10_tfworkhourlogminute)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! (0==AV83Workhourlogwwds_11_tfworkhourlogminute_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute <= :AV83Workhourlogwwds_11_tfworkhourlogminute_to)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Workhourlogwwds_13_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Workhourlogwwds_12_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV84Workhourlogwwds_12_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Workhourlogwwds_13_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV85Workhourlogwwds_13_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV85Workhourlogwwds_13_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( StringUtil.StrCmp(AV85Workhourlogwwds_13_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Workhourlogwwds_15_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Workhourlogwwds_14_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeFirstName like :lV86Workhourlogwwds_14_tfemployeefirstname)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Workhourlogwwds_15_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV87Workhourlogwwds_15_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeFirstName = ( :AV87Workhourlogwwds_15_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( StringUtil.StrCmp(AV87Workhourlogwwds_15_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeFirstName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Workhourlogwwds_17_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Workhourlogwwds_16_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T3.ProjectName like :lV88Workhourlogwwds_16_tfprojectname)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Workhourlogwwds_17_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV89Workhourlogwwds_17_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProjectName = ( :AV89Workhourlogwwds_17_tfprojectname_sel))");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( StringUtil.StrCmp(AV89Workhourlogwwds_17_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProjectName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WorkHourLogDescription";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006D4( IGxContext context ,
                                             string AV73Workhourlogwwds_1_filterfulltext ,
                                             short AV68WorkHourLogDateOperator ,
                                             DateTime AV74Workhourlogwwds_2_workhourlogdate ,
                                             DateTime AV75Workhourlogwwds_3_workhourlogdate_to ,
                                             DateTime AV76Workhourlogwwds_4_tfworkhourlogdate ,
                                             DateTime AV77Workhourlogwwds_5_tfworkhourlogdate_to ,
                                             string AV79Workhourlogwwds_7_tfworkhourlogduration_sel ,
                                             string AV78Workhourlogwwds_6_tfworkhourlogduration ,
                                             short AV80Workhourlogwwds_8_tfworkhourloghour ,
                                             short AV81Workhourlogwwds_9_tfworkhourloghour_to ,
                                             short AV82Workhourlogwwds_10_tfworkhourlogminute ,
                                             short AV83Workhourlogwwds_11_tfworkhourlogminute_to ,
                                             string AV85Workhourlogwwds_13_tfworkhourlogdescription_sel ,
                                             string AV84Workhourlogwwds_12_tfworkhourlogdescription ,
                                             string AV87Workhourlogwwds_15_tfemployeefirstname_sel ,
                                             string AV86Workhourlogwwds_14_tfemployeefirstname ,
                                             string AV89Workhourlogwwds_17_tfprojectname_sel ,
                                             string AV88Workhourlogwwds_16_tfprojectname ,
                                             string A120WorkHourLogDuration ,
                                             short A121WorkHourLogHour ,
                                             short A122WorkHourLogMinute ,
                                             string A123WorkHourLogDescription ,
                                             string A107EmployeeFirstName ,
                                             string A103ProjectName ,
                                             DateTime A119WorkHourLogDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[25];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ProjectId, T1.EmployeeId, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogDate, T2.ProjectName, T3.EmployeeFirstName, T1.WorkHourLogDescription, T1.WorkHourLogDuration, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.WorkHourLogDuration like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogHour,'9999'), 2) like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogMinute,'9999'), 2) like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( T1.WorkHourLogDescription like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( T3.EmployeeFirstName like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( T2.ProjectName like '%' || :lV73Workhourlogwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
         }
         if ( ( AV68WorkHourLogDateOperator == 0 ) && ( ! (DateTime.MinValue==AV74Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate < :AV74Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ( AV68WorkHourLogDateOperator == 1 ) && ( ! (DateTime.MinValue==AV74Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate = :AV74Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ( ( AV68WorkHourLogDateOperator == 2 ) || ( AV68WorkHourLogDateOperator == 3 ) ) && ( ! (DateTime.MinValue==AV74Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate > :AV74Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ( ( AV68WorkHourLogDateOperator == 2 ) || ( AV68WorkHourLogDateOperator == 3 ) || ( AV68WorkHourLogDateOperator == 4 ) ) && ( ! (DateTime.MinValue==AV75Workhourlogwwds_3_workhourlogdate_to) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV75Workhourlogwwds_3_workhourlogdate_to)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ( AV68WorkHourLogDateOperator == 4 ) && ( ! (DateTime.MinValue==AV74Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV74Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Workhourlogwwds_4_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV76Workhourlogwwds_4_tfworkhourlogdate)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Workhourlogwwds_5_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV77Workhourlogwwds_5_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Workhourlogwwds_7_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Workhourlogwwds_6_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV78Workhourlogwwds_6_tfworkhourlogduration)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Workhourlogwwds_7_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV79Workhourlogwwds_7_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV79Workhourlogwwds_7_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV79Workhourlogwwds_7_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( ! (0==AV80Workhourlogwwds_8_tfworkhourloghour) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour >= :AV80Workhourlogwwds_8_tfworkhourloghour)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! (0==AV81Workhourlogwwds_9_tfworkhourloghour_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour <= :AV81Workhourlogwwds_9_tfworkhourloghour_to)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! (0==AV82Workhourlogwwds_10_tfworkhourlogminute) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute >= :AV82Workhourlogwwds_10_tfworkhourlogminute)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! (0==AV83Workhourlogwwds_11_tfworkhourlogminute_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute <= :AV83Workhourlogwwds_11_tfworkhourlogminute_to)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Workhourlogwwds_13_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Workhourlogwwds_12_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV84Workhourlogwwds_12_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Workhourlogwwds_13_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV85Workhourlogwwds_13_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV85Workhourlogwwds_13_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( StringUtil.StrCmp(AV85Workhourlogwwds_13_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Workhourlogwwds_15_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Workhourlogwwds_14_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeFirstName like :lV86Workhourlogwwds_14_tfemployeefirstname)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Workhourlogwwds_15_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV87Workhourlogwwds_15_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeFirstName = ( :AV87Workhourlogwwds_15_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( StringUtil.StrCmp(AV87Workhourlogwwds_15_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeFirstName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Workhourlogwwds_17_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Workhourlogwwds_16_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName like :lV88Workhourlogwwds_16_tfprojectname)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Workhourlogwwds_17_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV89Workhourlogwwds_17_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName = ( :AV89Workhourlogwwds_17_tfprojectname_sel))");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( StringUtil.StrCmp(AV89Workhourlogwwds_17_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProjectName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P006D5( IGxContext context ,
                                             string AV73Workhourlogwwds_1_filterfulltext ,
                                             short AV68WorkHourLogDateOperator ,
                                             DateTime AV74Workhourlogwwds_2_workhourlogdate ,
                                             DateTime AV75Workhourlogwwds_3_workhourlogdate_to ,
                                             DateTime AV76Workhourlogwwds_4_tfworkhourlogdate ,
                                             DateTime AV77Workhourlogwwds_5_tfworkhourlogdate_to ,
                                             string AV79Workhourlogwwds_7_tfworkhourlogduration_sel ,
                                             string AV78Workhourlogwwds_6_tfworkhourlogduration ,
                                             short AV80Workhourlogwwds_8_tfworkhourloghour ,
                                             short AV81Workhourlogwwds_9_tfworkhourloghour_to ,
                                             short AV82Workhourlogwwds_10_tfworkhourlogminute ,
                                             short AV83Workhourlogwwds_11_tfworkhourlogminute_to ,
                                             string AV85Workhourlogwwds_13_tfworkhourlogdescription_sel ,
                                             string AV84Workhourlogwwds_12_tfworkhourlogdescription ,
                                             string AV87Workhourlogwwds_15_tfemployeefirstname_sel ,
                                             string AV86Workhourlogwwds_14_tfemployeefirstname ,
                                             string AV89Workhourlogwwds_17_tfprojectname_sel ,
                                             string AV88Workhourlogwwds_16_tfprojectname ,
                                             string A120WorkHourLogDuration ,
                                             short A121WorkHourLogHour ,
                                             short A122WorkHourLogMinute ,
                                             string A123WorkHourLogDescription ,
                                             string A107EmployeeFirstName ,
                                             string A103ProjectName ,
                                             DateTime A119WorkHourLogDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[25];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T1.ProjectId, T3.ProjectName, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogDate, T2.EmployeeFirstName, T1.WorkHourLogDescription, T1.WorkHourLogDuration, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = T1.ProjectId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Workhourlogwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.WorkHourLogDuration like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogHour,'9999'), 2) like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogMinute,'9999'), 2) like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( T1.WorkHourLogDescription like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( T2.EmployeeFirstName like '%' || :lV73Workhourlogwwds_1_filterfulltext) or ( T3.ProjectName like '%' || :lV73Workhourlogwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
         }
         if ( ( AV68WorkHourLogDateOperator == 0 ) && ( ! (DateTime.MinValue==AV74Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate < :AV74Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ( AV68WorkHourLogDateOperator == 1 ) && ( ! (DateTime.MinValue==AV74Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate = :AV74Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ( ( AV68WorkHourLogDateOperator == 2 ) || ( AV68WorkHourLogDateOperator == 3 ) ) && ( ! (DateTime.MinValue==AV74Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate > :AV74Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ( ( AV68WorkHourLogDateOperator == 2 ) || ( AV68WorkHourLogDateOperator == 3 ) || ( AV68WorkHourLogDateOperator == 4 ) ) && ( ! (DateTime.MinValue==AV75Workhourlogwwds_3_workhourlogdate_to) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV75Workhourlogwwds_3_workhourlogdate_to)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ( AV68WorkHourLogDateOperator == 4 ) && ( ! (DateTime.MinValue==AV74Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV74Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Workhourlogwwds_4_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV76Workhourlogwwds_4_tfworkhourlogdate)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Workhourlogwwds_5_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV77Workhourlogwwds_5_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Workhourlogwwds_7_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Workhourlogwwds_6_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV78Workhourlogwwds_6_tfworkhourlogduration)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Workhourlogwwds_7_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV79Workhourlogwwds_7_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV79Workhourlogwwds_7_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV79Workhourlogwwds_7_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( ! (0==AV80Workhourlogwwds_8_tfworkhourloghour) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour >= :AV80Workhourlogwwds_8_tfworkhourloghour)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! (0==AV81Workhourlogwwds_9_tfworkhourloghour_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour <= :AV81Workhourlogwwds_9_tfworkhourloghour_to)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! (0==AV82Workhourlogwwds_10_tfworkhourlogminute) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute >= :AV82Workhourlogwwds_10_tfworkhourlogminute)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! (0==AV83Workhourlogwwds_11_tfworkhourlogminute_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute <= :AV83Workhourlogwwds_11_tfworkhourlogminute_to)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Workhourlogwwds_13_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Workhourlogwwds_12_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV84Workhourlogwwds_12_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Workhourlogwwds_13_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV85Workhourlogwwds_13_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV85Workhourlogwwds_13_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( StringUtil.StrCmp(AV85Workhourlogwwds_13_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Workhourlogwwds_15_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Workhourlogwwds_14_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeFirstName like :lV86Workhourlogwwds_14_tfemployeefirstname)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Workhourlogwwds_15_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV87Workhourlogwwds_15_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeFirstName = ( :AV87Workhourlogwwds_15_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( StringUtil.StrCmp(AV87Workhourlogwwds_15_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeFirstName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Workhourlogwwds_17_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Workhourlogwwds_16_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T3.ProjectName like :lV88Workhourlogwwds_16_tfprojectname)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Workhourlogwwds_17_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV89Workhourlogwwds_17_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProjectName = ( :AV89Workhourlogwwds_17_tfprojectname_sel))");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( StringUtil.StrCmp(AV89Workhourlogwwds_17_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProjectName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.ProjectName";
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
                     return conditional_P006D2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] );
               case 1 :
                     return conditional_P006D3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] );
               case 2 :
                     return conditional_P006D4(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] );
               case 3 :
                     return conditional_P006D5(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] );
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
          Object[] prmP006D2;
          prmP006D2 = new Object[] {
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV74Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV74Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV74Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV75Workhourlogwwds_3_workhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("AV74Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV76Workhourlogwwds_4_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV77Workhourlogwwds_5_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV78Workhourlogwwds_6_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV79Workhourlogwwds_7_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("AV80Workhourlogwwds_8_tfworkhourloghour",GXType.Int16,4,0) ,
          new ParDef("AV81Workhourlogwwds_9_tfworkhourloghour_to",GXType.Int16,4,0) ,
          new ParDef("AV82Workhourlogwwds_10_tfworkhourlogminute",GXType.Int16,4,0) ,
          new ParDef("AV83Workhourlogwwds_11_tfworkhourlogminute_to",GXType.Int16,4,0) ,
          new ParDef("lV84Workhourlogwwds_12_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV85Workhourlogwwds_13_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV86Workhourlogwwds_14_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV87Workhourlogwwds_15_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("lV88Workhourlogwwds_16_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV89Workhourlogwwds_17_tfprojectname_sel",GXType.Char,100,0)
          };
          Object[] prmP006D3;
          prmP006D3 = new Object[] {
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV74Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV74Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV74Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV75Workhourlogwwds_3_workhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("AV74Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV76Workhourlogwwds_4_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV77Workhourlogwwds_5_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV78Workhourlogwwds_6_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV79Workhourlogwwds_7_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("AV80Workhourlogwwds_8_tfworkhourloghour",GXType.Int16,4,0) ,
          new ParDef("AV81Workhourlogwwds_9_tfworkhourloghour_to",GXType.Int16,4,0) ,
          new ParDef("AV82Workhourlogwwds_10_tfworkhourlogminute",GXType.Int16,4,0) ,
          new ParDef("AV83Workhourlogwwds_11_tfworkhourlogminute_to",GXType.Int16,4,0) ,
          new ParDef("lV84Workhourlogwwds_12_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV85Workhourlogwwds_13_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV86Workhourlogwwds_14_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV87Workhourlogwwds_15_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("lV88Workhourlogwwds_16_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV89Workhourlogwwds_17_tfprojectname_sel",GXType.Char,100,0)
          };
          Object[] prmP006D4;
          prmP006D4 = new Object[] {
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV74Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV74Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV74Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV75Workhourlogwwds_3_workhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("AV74Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV76Workhourlogwwds_4_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV77Workhourlogwwds_5_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV78Workhourlogwwds_6_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV79Workhourlogwwds_7_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("AV80Workhourlogwwds_8_tfworkhourloghour",GXType.Int16,4,0) ,
          new ParDef("AV81Workhourlogwwds_9_tfworkhourloghour_to",GXType.Int16,4,0) ,
          new ParDef("AV82Workhourlogwwds_10_tfworkhourlogminute",GXType.Int16,4,0) ,
          new ParDef("AV83Workhourlogwwds_11_tfworkhourlogminute_to",GXType.Int16,4,0) ,
          new ParDef("lV84Workhourlogwwds_12_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV85Workhourlogwwds_13_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV86Workhourlogwwds_14_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV87Workhourlogwwds_15_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("lV88Workhourlogwwds_16_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV89Workhourlogwwds_17_tfprojectname_sel",GXType.Char,100,0)
          };
          Object[] prmP006D5;
          prmP006D5 = new Object[] {
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV74Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV74Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV74Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV75Workhourlogwwds_3_workhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("AV74Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV76Workhourlogwwds_4_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV77Workhourlogwwds_5_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV78Workhourlogwwds_6_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV79Workhourlogwwds_7_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("AV80Workhourlogwwds_8_tfworkhourloghour",GXType.Int16,4,0) ,
          new ParDef("AV81Workhourlogwwds_9_tfworkhourloghour_to",GXType.Int16,4,0) ,
          new ParDef("AV82Workhourlogwwds_10_tfworkhourlogminute",GXType.Int16,4,0) ,
          new ParDef("AV83Workhourlogwwds_11_tfworkhourlogminute_to",GXType.Int16,4,0) ,
          new ParDef("lV84Workhourlogwwds_12_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV85Workhourlogwwds_13_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV86Workhourlogwwds_14_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV87Workhourlogwwds_15_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("lV88Workhourlogwwds_16_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV89Workhourlogwwds_17_tfprojectname_sel",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006D2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006D3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006D4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006D4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006D5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006D5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
       }
    }

 }

}
