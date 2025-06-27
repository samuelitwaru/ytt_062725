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
   public class workhourlogbyemployeegetfilterdata : GXProcedure
   {
      public workhourlogbyemployeegetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workhourlogbyemployeegetfilterdata( IGxContext context )
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
         this.AV47DDOName = aP0_DDOName;
         this.AV48SearchTxtParms = aP1_SearchTxtParms;
         this.AV49SearchTxtTo = aP2_SearchTxtTo;
         this.AV50OptionsJson = "" ;
         this.AV51OptionsDescJson = "" ;
         this.AV52OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV52OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV47DDOName = aP0_DDOName;
         this.AV48SearchTxtParms = aP1_SearchTxtParms;
         this.AV49SearchTxtTo = aP2_SearchTxtTo;
         this.AV50OptionsJson = "" ;
         this.AV51OptionsDescJson = "" ;
         this.AV52OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV37Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV39OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34MaxItems = 10;
         AV33PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV48SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV31SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? "" : StringUtil.Substring( AV48SearchTxtParms, 3, -1));
         AV32SkipItems = (short)(AV33PageIndex*AV34MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_WORKHOURLOGDURATION") == 0 )
         {
            /* Execute user subroutine: 'LOADWORKHOURLOGDURATIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_WORKHOURLOGDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADWORKHOURLOGDESCRIPTIONOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_EMPLOYEEFIRSTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEEFIRSTNAMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_PROJECTNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADPROJECTNAMEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV50OptionsJson = AV37Options.ToJSonString(false);
         AV51OptionsDescJson = AV39OptionsDesc.ToJSonString(false);
         AV52OptionIndexesJson = AV40OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV42Session.Get("WorkHourLogByEmployeeGridState"), "") == 0 )
         {
            AV44GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WorkHourLogByEmployeeGridState"), null, "", "");
         }
         else
         {
            AV44GridState.FromXml(AV42Session.Get("WorkHourLogByEmployeeGridState"), null, "", "");
         }
         AV57GXV1 = 1;
         while ( AV57GXV1 <= AV44GridState.gxTpr_Filtervalues.Count )
         {
            AV45GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV44GridState.gxTpr_Filtervalues.Item(AV57GXV1));
            if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV53FilterFullText = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGID") == 0 )
            {
               AV11TFWorkHourLogId = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFWorkHourLogId_To = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDATE") == 0 )
            {
               AV13TFWorkHourLogDate = context.localUtil.CToD( AV45GridStateFilterValue.gxTpr_Value, 2);
               AV14TFWorkHourLogDate_To = context.localUtil.CToD( AV45GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION") == 0 )
            {
               AV15TFWorkHourLogDuration = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION_SEL") == 0 )
            {
               AV16TFWorkHourLogDuration_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGHOUR") == 0 )
            {
               AV17TFWorkHourLogHour = (short)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV18TFWorkHourLogHour_To = (short)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGMINUTE") == 0 )
            {
               AV19TFWorkHourLogMinute = (short)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV20TFWorkHourLogMinute_To = (short)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION") == 0 )
            {
               AV21TFWorkHourLogDescription = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION_SEL") == 0 )
            {
               AV22TFWorkHourLogDescription_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEID") == 0 )
            {
               AV23TFEmployeeId = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV24TFEmployeeId_To = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEFIRSTNAME") == 0 )
            {
               AV25TFEmployeeFirstName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEFIRSTNAME_SEL") == 0 )
            {
               AV26TFEmployeeFirstName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROJECTID") == 0 )
            {
               AV27TFProjectId = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV28TFProjectId_To = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME") == 0 )
            {
               AV29TFProjectName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME_SEL") == 0 )
            {
               AV30TFProjectName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "PARM_&EMPLOYEEID") == 0 )
            {
               AV54EmployeeId = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV57GXV1 = (int)(AV57GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADWORKHOURLOGDURATIONOPTIONS' Routine */
         returnInSub = false;
         AV15TFWorkHourLogDuration = AV31SearchTxt;
         AV16TFWorkHourLogDuration_Sel = "";
         AV59Workhourlogbyemployeeds_1_employeeid = AV54EmployeeId;
         AV60Workhourlogbyemployeeds_2_filterfulltext = AV53FilterFullText;
         AV61Workhourlogbyemployeeds_3_tfworkhourlogid = AV11TFWorkHourLogId;
         AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to = AV12TFWorkHourLogId_To;
         AV63Workhourlogbyemployeeds_5_tfworkhourlogdate = AV13TFWorkHourLogDate;
         AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to = AV14TFWorkHourLogDate_To;
         AV65Workhourlogbyemployeeds_7_tfworkhourlogduration = AV15TFWorkHourLogDuration;
         AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel = AV16TFWorkHourLogDuration_Sel;
         AV67Workhourlogbyemployeeds_9_tfworkhourloghour = AV17TFWorkHourLogHour;
         AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to = AV18TFWorkHourLogHour_To;
         AV69Workhourlogbyemployeeds_11_tfworkhourlogminute = AV19TFWorkHourLogMinute;
         AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to = AV20TFWorkHourLogMinute_To;
         AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription = AV21TFWorkHourLogDescription;
         AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel = AV22TFWorkHourLogDescription_Sel;
         AV73Workhourlogbyemployeeds_15_tfemployeeid = AV23TFEmployeeId;
         AV74Workhourlogbyemployeeds_16_tfemployeeid_to = AV24TFEmployeeId_To;
         AV75Workhourlogbyemployeeds_17_tfemployeefirstname = AV25TFEmployeeFirstName;
         AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel = AV26TFEmployeeFirstName_Sel;
         AV77Workhourlogbyemployeeds_19_tfprojectid = AV27TFProjectId;
         AV78Workhourlogbyemployeeds_20_tfprojectid_to = AV28TFProjectId_To;
         AV79Workhourlogbyemployeeds_21_tfprojectname = AV29TFProjectName;
         AV80Workhourlogbyemployeeds_22_tfprojectname_sel = AV30TFProjectName_Sel;
         AV81Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV81Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV81Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV81Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV81Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV81Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV81Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV81Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV81Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         AV81Udparg23 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV60Workhourlogbyemployeeds_2_filterfulltext ,
                                              AV61Workhourlogbyemployeeds_3_tfworkhourlogid ,
                                              AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to ,
                                              AV63Workhourlogbyemployeeds_5_tfworkhourlogdate ,
                                              AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to ,
                                              AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel ,
                                              AV65Workhourlogbyemployeeds_7_tfworkhourlogduration ,
                                              AV67Workhourlogbyemployeeds_9_tfworkhourloghour ,
                                              AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to ,
                                              AV69Workhourlogbyemployeeds_11_tfworkhourlogminute ,
                                              AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to ,
                                              AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel ,
                                              AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription ,
                                              AV73Workhourlogbyemployeeds_15_tfemployeeid ,
                                              AV74Workhourlogbyemployeeds_16_tfemployeeid_to ,
                                              AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel ,
                                              AV75Workhourlogbyemployeeds_17_tfemployeefirstname ,
                                              AV77Workhourlogbyemployeeds_19_tfprojectid ,
                                              AV78Workhourlogbyemployeeds_20_tfprojectid_to ,
                                              AV80Workhourlogbyemployeeds_22_tfprojectname_sel ,
                                              AV79Workhourlogbyemployeeds_21_tfprojectname ,
                                              A118WorkHourLogId ,
                                              A120WorkHourLogDuration ,
                                              A121WorkHourLogHour ,
                                              A122WorkHourLogMinute ,
                                              A123WorkHourLogDescription ,
                                              A106EmployeeId ,
                                              A107EmployeeFirstName ,
                                              A102ProjectId ,
                                              A103ProjectName ,
                                              A119WorkHourLogDate ,
                                              A100CompanyId ,
                                              AV81Udparg23 ,
                                              AV54EmployeeId ,
                                              AV59Workhourlogbyemployeeds_1_employeeid } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV65Workhourlogbyemployeeds_7_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV65Workhourlogbyemployeeds_7_tfworkhourlogduration), "%", "");
         lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription), "%", "");
         lV75Workhourlogbyemployeeds_17_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV75Workhourlogbyemployeeds_17_tfemployeefirstname), 100, "%");
         lV79Workhourlogbyemployeeds_21_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV79Workhourlogbyemployeeds_21_tfprojectname), 100, "%");
         /* Using cursor P00992 */
         pr_default.execute(0, new Object[] {AV59Workhourlogbyemployeeds_1_employeeid, AV81Udparg23, AV54EmployeeId, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, AV61Workhourlogbyemployeeds_3_tfworkhourlogid, AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to, AV63Workhourlogbyemployeeds_5_tfworkhourlogdate, AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to, lV65Workhourlogbyemployeeds_7_tfworkhourlogduration, AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel, AV67Workhourlogbyemployeeds_9_tfworkhourloghour, AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to, AV69Workhourlogbyemployeeds_11_tfworkhourlogminute, AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to, lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription, AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel, AV73Workhourlogbyemployeeds_15_tfemployeeid, AV74Workhourlogbyemployeeds_16_tfemployeeid_to, lV75Workhourlogbyemployeeds_17_tfemployeefirstname, AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel, AV77Workhourlogbyemployeeds_19_tfprojectid, AV78Workhourlogbyemployeeds_20_tfprojectid_to, lV79Workhourlogbyemployeeds_21_tfprojectname, AV80Workhourlogbyemployeeds_22_tfprojectname_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK992 = false;
            A106EmployeeId = P00992_A106EmployeeId[0];
            A100CompanyId = P00992_A100CompanyId[0];
            A120WorkHourLogDuration = P00992_A120WorkHourLogDuration[0];
            A103ProjectName = P00992_A103ProjectName[0];
            A102ProjectId = P00992_A102ProjectId[0];
            A107EmployeeFirstName = P00992_A107EmployeeFirstName[0];
            A123WorkHourLogDescription = P00992_A123WorkHourLogDescription[0];
            A122WorkHourLogMinute = P00992_A122WorkHourLogMinute[0];
            A121WorkHourLogHour = P00992_A121WorkHourLogHour[0];
            A119WorkHourLogDate = P00992_A119WorkHourLogDate[0];
            A118WorkHourLogId = P00992_A118WorkHourLogId[0];
            A100CompanyId = P00992_A100CompanyId[0];
            A107EmployeeFirstName = P00992_A107EmployeeFirstName[0];
            A103ProjectName = P00992_A103ProjectName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00992_A106EmployeeId[0] == A106EmployeeId ) && ( StringUtil.StrCmp(P00992_A120WorkHourLogDuration[0], A120WorkHourLogDuration) == 0 ) )
            {
               BRK992 = false;
               A118WorkHourLogId = P00992_A118WorkHourLogId[0];
               AV41count = (long)(AV41count+1);
               BRK992 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A120WorkHourLogDuration)) ? "<#Empty#>" : A120WorkHourLogDuration);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK992 )
            {
               BRK992 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADWORKHOURLOGDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV21TFWorkHourLogDescription = AV31SearchTxt;
         AV22TFWorkHourLogDescription_Sel = "";
         AV59Workhourlogbyemployeeds_1_employeeid = AV54EmployeeId;
         AV60Workhourlogbyemployeeds_2_filterfulltext = AV53FilterFullText;
         AV61Workhourlogbyemployeeds_3_tfworkhourlogid = AV11TFWorkHourLogId;
         AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to = AV12TFWorkHourLogId_To;
         AV63Workhourlogbyemployeeds_5_tfworkhourlogdate = AV13TFWorkHourLogDate;
         AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to = AV14TFWorkHourLogDate_To;
         AV65Workhourlogbyemployeeds_7_tfworkhourlogduration = AV15TFWorkHourLogDuration;
         AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel = AV16TFWorkHourLogDuration_Sel;
         AV67Workhourlogbyemployeeds_9_tfworkhourloghour = AV17TFWorkHourLogHour;
         AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to = AV18TFWorkHourLogHour_To;
         AV69Workhourlogbyemployeeds_11_tfworkhourlogminute = AV19TFWorkHourLogMinute;
         AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to = AV20TFWorkHourLogMinute_To;
         AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription = AV21TFWorkHourLogDescription;
         AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel = AV22TFWorkHourLogDescription_Sel;
         AV73Workhourlogbyemployeeds_15_tfemployeeid = AV23TFEmployeeId;
         AV74Workhourlogbyemployeeds_16_tfemployeeid_to = AV24TFEmployeeId_To;
         AV75Workhourlogbyemployeeds_17_tfemployeefirstname = AV25TFEmployeeFirstName;
         AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel = AV26TFEmployeeFirstName_Sel;
         AV77Workhourlogbyemployeeds_19_tfprojectid = AV27TFProjectId;
         AV78Workhourlogbyemployeeds_20_tfprojectid_to = AV28TFProjectId_To;
         AV79Workhourlogbyemployeeds_21_tfprojectname = AV29TFProjectName;
         AV80Workhourlogbyemployeeds_22_tfprojectname_sel = AV30TFProjectName_Sel;
         AV84Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         AV84Udparg24 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV60Workhourlogbyemployeeds_2_filterfulltext ,
                                              AV61Workhourlogbyemployeeds_3_tfworkhourlogid ,
                                              AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to ,
                                              AV63Workhourlogbyemployeeds_5_tfworkhourlogdate ,
                                              AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to ,
                                              AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel ,
                                              AV65Workhourlogbyemployeeds_7_tfworkhourlogduration ,
                                              AV67Workhourlogbyemployeeds_9_tfworkhourloghour ,
                                              AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to ,
                                              AV69Workhourlogbyemployeeds_11_tfworkhourlogminute ,
                                              AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to ,
                                              AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel ,
                                              AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription ,
                                              AV73Workhourlogbyemployeeds_15_tfemployeeid ,
                                              AV74Workhourlogbyemployeeds_16_tfemployeeid_to ,
                                              AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel ,
                                              AV75Workhourlogbyemployeeds_17_tfemployeefirstname ,
                                              AV77Workhourlogbyemployeeds_19_tfprojectid ,
                                              AV78Workhourlogbyemployeeds_20_tfprojectid_to ,
                                              AV80Workhourlogbyemployeeds_22_tfprojectname_sel ,
                                              AV79Workhourlogbyemployeeds_21_tfprojectname ,
                                              A118WorkHourLogId ,
                                              A120WorkHourLogDuration ,
                                              A121WorkHourLogHour ,
                                              A122WorkHourLogMinute ,
                                              A123WorkHourLogDescription ,
                                              A106EmployeeId ,
                                              A107EmployeeFirstName ,
                                              A102ProjectId ,
                                              A103ProjectName ,
                                              A119WorkHourLogDate ,
                                              A100CompanyId ,
                                              AV84Udparg24 ,
                                              AV54EmployeeId ,
                                              AV59Workhourlogbyemployeeds_1_employeeid } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV65Workhourlogbyemployeeds_7_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV65Workhourlogbyemployeeds_7_tfworkhourlogduration), "%", "");
         lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription), "%", "");
         lV75Workhourlogbyemployeeds_17_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV75Workhourlogbyemployeeds_17_tfemployeefirstname), 100, "%");
         lV79Workhourlogbyemployeeds_21_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV79Workhourlogbyemployeeds_21_tfprojectname), 100, "%");
         /* Using cursor P00993 */
         pr_default.execute(1, new Object[] {AV59Workhourlogbyemployeeds_1_employeeid, AV84Udparg24, AV54EmployeeId, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, AV61Workhourlogbyemployeeds_3_tfworkhourlogid, AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to, AV63Workhourlogbyemployeeds_5_tfworkhourlogdate, AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to, lV65Workhourlogbyemployeeds_7_tfworkhourlogduration, AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel, AV67Workhourlogbyemployeeds_9_tfworkhourloghour, AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to, AV69Workhourlogbyemployeeds_11_tfworkhourlogminute, AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to, lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription, AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel, AV73Workhourlogbyemployeeds_15_tfemployeeid, AV74Workhourlogbyemployeeds_16_tfemployeeid_to, lV75Workhourlogbyemployeeds_17_tfemployeefirstname, AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel, AV77Workhourlogbyemployeeds_19_tfprojectid, AV78Workhourlogbyemployeeds_20_tfprojectid_to, lV79Workhourlogbyemployeeds_21_tfprojectname, AV80Workhourlogbyemployeeds_22_tfprojectname_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK994 = false;
            A106EmployeeId = P00993_A106EmployeeId[0];
            A100CompanyId = P00993_A100CompanyId[0];
            A123WorkHourLogDescription = P00993_A123WorkHourLogDescription[0];
            A103ProjectName = P00993_A103ProjectName[0];
            A102ProjectId = P00993_A102ProjectId[0];
            A107EmployeeFirstName = P00993_A107EmployeeFirstName[0];
            A122WorkHourLogMinute = P00993_A122WorkHourLogMinute[0];
            A121WorkHourLogHour = P00993_A121WorkHourLogHour[0];
            A120WorkHourLogDuration = P00993_A120WorkHourLogDuration[0];
            A119WorkHourLogDate = P00993_A119WorkHourLogDate[0];
            A118WorkHourLogId = P00993_A118WorkHourLogId[0];
            A100CompanyId = P00993_A100CompanyId[0];
            A107EmployeeFirstName = P00993_A107EmployeeFirstName[0];
            A103ProjectName = P00993_A103ProjectName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00993_A106EmployeeId[0] == A106EmployeeId ) && ( StringUtil.StrCmp(P00993_A123WorkHourLogDescription[0], A123WorkHourLogDescription) == 0 ) )
            {
               BRK994 = false;
               A118WorkHourLogId = P00993_A118WorkHourLogId[0];
               AV41count = (long)(AV41count+1);
               BRK994 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A123WorkHourLogDescription)) ? "<#Empty#>" : A123WorkHourLogDescription);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK994 )
            {
               BRK994 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADEMPLOYEEFIRSTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV25TFEmployeeFirstName = AV31SearchTxt;
         AV26TFEmployeeFirstName_Sel = "";
         AV59Workhourlogbyemployeeds_1_employeeid = AV54EmployeeId;
         AV60Workhourlogbyemployeeds_2_filterfulltext = AV53FilterFullText;
         AV61Workhourlogbyemployeeds_3_tfworkhourlogid = AV11TFWorkHourLogId;
         AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to = AV12TFWorkHourLogId_To;
         AV63Workhourlogbyemployeeds_5_tfworkhourlogdate = AV13TFWorkHourLogDate;
         AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to = AV14TFWorkHourLogDate_To;
         AV65Workhourlogbyemployeeds_7_tfworkhourlogduration = AV15TFWorkHourLogDuration;
         AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel = AV16TFWorkHourLogDuration_Sel;
         AV67Workhourlogbyemployeeds_9_tfworkhourloghour = AV17TFWorkHourLogHour;
         AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to = AV18TFWorkHourLogHour_To;
         AV69Workhourlogbyemployeeds_11_tfworkhourlogminute = AV19TFWorkHourLogMinute;
         AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to = AV20TFWorkHourLogMinute_To;
         AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription = AV21TFWorkHourLogDescription;
         AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel = AV22TFWorkHourLogDescription_Sel;
         AV73Workhourlogbyemployeeds_15_tfemployeeid = AV23TFEmployeeId;
         AV74Workhourlogbyemployeeds_16_tfemployeeid_to = AV24TFEmployeeId_To;
         AV75Workhourlogbyemployeeds_17_tfemployeefirstname = AV25TFEmployeeFirstName;
         AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel = AV26TFEmployeeFirstName_Sel;
         AV77Workhourlogbyemployeeds_19_tfprojectid = AV27TFProjectId;
         AV78Workhourlogbyemployeeds_20_tfprojectid_to = AV28TFProjectId_To;
         AV79Workhourlogbyemployeeds_21_tfprojectname = AV29TFProjectName;
         AV80Workhourlogbyemployeeds_22_tfprojectname_sel = AV30TFProjectName_Sel;
         AV87Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV87Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV87Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV87Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV87Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV87Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV87Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV87Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV87Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         AV87Udparg25 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV60Workhourlogbyemployeeds_2_filterfulltext ,
                                              AV61Workhourlogbyemployeeds_3_tfworkhourlogid ,
                                              AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to ,
                                              AV63Workhourlogbyemployeeds_5_tfworkhourlogdate ,
                                              AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to ,
                                              AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel ,
                                              AV65Workhourlogbyemployeeds_7_tfworkhourlogduration ,
                                              AV67Workhourlogbyemployeeds_9_tfworkhourloghour ,
                                              AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to ,
                                              AV69Workhourlogbyemployeeds_11_tfworkhourlogminute ,
                                              AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to ,
                                              AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel ,
                                              AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription ,
                                              AV73Workhourlogbyemployeeds_15_tfemployeeid ,
                                              AV74Workhourlogbyemployeeds_16_tfemployeeid_to ,
                                              AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel ,
                                              AV75Workhourlogbyemployeeds_17_tfemployeefirstname ,
                                              AV77Workhourlogbyemployeeds_19_tfprojectid ,
                                              AV78Workhourlogbyemployeeds_20_tfprojectid_to ,
                                              AV80Workhourlogbyemployeeds_22_tfprojectname_sel ,
                                              AV79Workhourlogbyemployeeds_21_tfprojectname ,
                                              A118WorkHourLogId ,
                                              A120WorkHourLogDuration ,
                                              A121WorkHourLogHour ,
                                              A122WorkHourLogMinute ,
                                              A123WorkHourLogDescription ,
                                              A106EmployeeId ,
                                              A107EmployeeFirstName ,
                                              A102ProjectId ,
                                              A103ProjectName ,
                                              A119WorkHourLogDate ,
                                              A100CompanyId ,
                                              AV87Udparg25 ,
                                              AV54EmployeeId ,
                                              AV59Workhourlogbyemployeeds_1_employeeid } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV65Workhourlogbyemployeeds_7_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV65Workhourlogbyemployeeds_7_tfworkhourlogduration), "%", "");
         lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription), "%", "");
         lV75Workhourlogbyemployeeds_17_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV75Workhourlogbyemployeeds_17_tfemployeefirstname), 100, "%");
         lV79Workhourlogbyemployeeds_21_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV79Workhourlogbyemployeeds_21_tfprojectname), 100, "%");
         /* Using cursor P00994 */
         pr_default.execute(2, new Object[] {AV59Workhourlogbyemployeeds_1_employeeid, AV87Udparg25, AV54EmployeeId, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, AV61Workhourlogbyemployeeds_3_tfworkhourlogid, AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to, AV63Workhourlogbyemployeeds_5_tfworkhourlogdate, AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to, lV65Workhourlogbyemployeeds_7_tfworkhourlogduration, AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel, AV67Workhourlogbyemployeeds_9_tfworkhourloghour, AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to, AV69Workhourlogbyemployeeds_11_tfworkhourlogminute, AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to, lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription, AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel, AV73Workhourlogbyemployeeds_15_tfemployeeid, AV74Workhourlogbyemployeeds_16_tfemployeeid_to, lV75Workhourlogbyemployeeds_17_tfemployeefirstname, AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel, AV77Workhourlogbyemployeeds_19_tfprojectid, AV78Workhourlogbyemployeeds_20_tfprojectid_to, lV79Workhourlogbyemployeeds_21_tfprojectname, AV80Workhourlogbyemployeeds_22_tfprojectname_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK996 = false;
            A106EmployeeId = P00994_A106EmployeeId[0];
            A100CompanyId = P00994_A100CompanyId[0];
            A103ProjectName = P00994_A103ProjectName[0];
            A102ProjectId = P00994_A102ProjectId[0];
            A107EmployeeFirstName = P00994_A107EmployeeFirstName[0];
            A123WorkHourLogDescription = P00994_A123WorkHourLogDescription[0];
            A122WorkHourLogMinute = P00994_A122WorkHourLogMinute[0];
            A121WorkHourLogHour = P00994_A121WorkHourLogHour[0];
            A120WorkHourLogDuration = P00994_A120WorkHourLogDuration[0];
            A119WorkHourLogDate = P00994_A119WorkHourLogDate[0];
            A118WorkHourLogId = P00994_A118WorkHourLogId[0];
            A100CompanyId = P00994_A100CompanyId[0];
            A107EmployeeFirstName = P00994_A107EmployeeFirstName[0];
            A103ProjectName = P00994_A103ProjectName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00994_A106EmployeeId[0] == A106EmployeeId ) )
            {
               BRK996 = false;
               A118WorkHourLogId = P00994_A118WorkHourLogId[0];
               AV41count = (long)(AV41count+1);
               BRK996 = true;
               pr_default.readNext(2);
            }
            AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A107EmployeeFirstName)) ? "<#Empty#>" : A107EmployeeFirstName);
            AV35InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV36Option, "<#Empty#>") != 0 ) && ( AV35InsertIndex <= AV37Options.Count ) && ( ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), AV36Option) < 0 ) || ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV35InsertIndex = (int)(AV35InsertIndex+1);
            }
            AV37Options.Add(AV36Option, AV35InsertIndex);
            AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), AV35InsertIndex);
            if ( AV37Options.Count == AV32SkipItems + 11 )
            {
               AV37Options.RemoveItem(AV37Options.Count);
               AV40OptionIndexes.RemoveItem(AV40OptionIndexes.Count);
            }
            if ( ! BRK996 )
            {
               BRK996 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV32SkipItems > 0 )
         {
            AV37Options.RemoveItem(1);
            AV40OptionIndexes.RemoveItem(1);
            AV32SkipItems = (short)(AV32SkipItems-1);
         }
      }

      protected void S151( )
      {
         /* 'LOADPROJECTNAMEOPTIONS' Routine */
         returnInSub = false;
         AV29TFProjectName = AV31SearchTxt;
         AV30TFProjectName_Sel = "";
         AV59Workhourlogbyemployeeds_1_employeeid = AV54EmployeeId;
         AV60Workhourlogbyemployeeds_2_filterfulltext = AV53FilterFullText;
         AV61Workhourlogbyemployeeds_3_tfworkhourlogid = AV11TFWorkHourLogId;
         AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to = AV12TFWorkHourLogId_To;
         AV63Workhourlogbyemployeeds_5_tfworkhourlogdate = AV13TFWorkHourLogDate;
         AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to = AV14TFWorkHourLogDate_To;
         AV65Workhourlogbyemployeeds_7_tfworkhourlogduration = AV15TFWorkHourLogDuration;
         AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel = AV16TFWorkHourLogDuration_Sel;
         AV67Workhourlogbyemployeeds_9_tfworkhourloghour = AV17TFWorkHourLogHour;
         AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to = AV18TFWorkHourLogHour_To;
         AV69Workhourlogbyemployeeds_11_tfworkhourlogminute = AV19TFWorkHourLogMinute;
         AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to = AV20TFWorkHourLogMinute_To;
         AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription = AV21TFWorkHourLogDescription;
         AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel = AV22TFWorkHourLogDescription_Sel;
         AV73Workhourlogbyemployeeds_15_tfemployeeid = AV23TFEmployeeId;
         AV74Workhourlogbyemployeeds_16_tfemployeeid_to = AV24TFEmployeeId_To;
         AV75Workhourlogbyemployeeds_17_tfemployeefirstname = AV25TFEmployeeFirstName;
         AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel = AV26TFEmployeeFirstName_Sel;
         AV77Workhourlogbyemployeeds_19_tfprojectid = AV27TFProjectId;
         AV78Workhourlogbyemployeeds_20_tfprojectid_to = AV28TFProjectId_To;
         AV79Workhourlogbyemployeeds_21_tfprojectname = AV29TFProjectName;
         AV80Workhourlogbyemployeeds_22_tfprojectname_sel = AV30TFProjectName_Sel;
         AV90Udparg26 = new getloggedinusercompanyid(context).executeUdp( );
         AV90Udparg26 = new getloggedinusercompanyid(context).executeUdp( );
         AV90Udparg26 = new getloggedinusercompanyid(context).executeUdp( );
         AV90Udparg26 = new getloggedinusercompanyid(context).executeUdp( );
         AV90Udparg26 = new getloggedinusercompanyid(context).executeUdp( );
         AV90Udparg26 = new getloggedinusercompanyid(context).executeUdp( );
         AV90Udparg26 = new getloggedinusercompanyid(context).executeUdp( );
         AV90Udparg26 = new getloggedinusercompanyid(context).executeUdp( );
         AV90Udparg26 = new getloggedinusercompanyid(context).executeUdp( );
         AV90Udparg26 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV60Workhourlogbyemployeeds_2_filterfulltext ,
                                              AV61Workhourlogbyemployeeds_3_tfworkhourlogid ,
                                              AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to ,
                                              AV63Workhourlogbyemployeeds_5_tfworkhourlogdate ,
                                              AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to ,
                                              AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel ,
                                              AV65Workhourlogbyemployeeds_7_tfworkhourlogduration ,
                                              AV67Workhourlogbyemployeeds_9_tfworkhourloghour ,
                                              AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to ,
                                              AV69Workhourlogbyemployeeds_11_tfworkhourlogminute ,
                                              AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to ,
                                              AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel ,
                                              AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription ,
                                              AV73Workhourlogbyemployeeds_15_tfemployeeid ,
                                              AV74Workhourlogbyemployeeds_16_tfemployeeid_to ,
                                              AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel ,
                                              AV75Workhourlogbyemployeeds_17_tfemployeefirstname ,
                                              AV77Workhourlogbyemployeeds_19_tfprojectid ,
                                              AV78Workhourlogbyemployeeds_20_tfprojectid_to ,
                                              AV80Workhourlogbyemployeeds_22_tfprojectname_sel ,
                                              AV79Workhourlogbyemployeeds_21_tfprojectname ,
                                              A118WorkHourLogId ,
                                              A120WorkHourLogDuration ,
                                              A121WorkHourLogHour ,
                                              A122WorkHourLogMinute ,
                                              A123WorkHourLogDescription ,
                                              A106EmployeeId ,
                                              A107EmployeeFirstName ,
                                              A102ProjectId ,
                                              A103ProjectName ,
                                              A119WorkHourLogDate ,
                                              A100CompanyId ,
                                              AV90Udparg26 ,
                                              AV54EmployeeId ,
                                              AV59Workhourlogbyemployeeds_1_employeeid } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV60Workhourlogbyemployeeds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext), "%", "");
         lV65Workhourlogbyemployeeds_7_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV65Workhourlogbyemployeeds_7_tfworkhourlogduration), "%", "");
         lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription), "%", "");
         lV75Workhourlogbyemployeeds_17_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV75Workhourlogbyemployeeds_17_tfemployeefirstname), 100, "%");
         lV79Workhourlogbyemployeeds_21_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV79Workhourlogbyemployeeds_21_tfprojectname), 100, "%");
         /* Using cursor P00995 */
         pr_default.execute(3, new Object[] {AV59Workhourlogbyemployeeds_1_employeeid, AV90Udparg26, AV54EmployeeId, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, lV60Workhourlogbyemployeeds_2_filterfulltext, AV61Workhourlogbyemployeeds_3_tfworkhourlogid, AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to, AV63Workhourlogbyemployeeds_5_tfworkhourlogdate, AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to, lV65Workhourlogbyemployeeds_7_tfworkhourlogduration, AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel, AV67Workhourlogbyemployeeds_9_tfworkhourloghour, AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to, AV69Workhourlogbyemployeeds_11_tfworkhourlogminute, AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to, lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription, AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel, AV73Workhourlogbyemployeeds_15_tfemployeeid, AV74Workhourlogbyemployeeds_16_tfemployeeid_to, lV75Workhourlogbyemployeeds_17_tfemployeefirstname, AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel, AV77Workhourlogbyemployeeds_19_tfprojectid, AV78Workhourlogbyemployeeds_20_tfprojectid_to, lV79Workhourlogbyemployeeds_21_tfprojectname, AV80Workhourlogbyemployeeds_22_tfprojectname_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK998 = false;
            A106EmployeeId = P00995_A106EmployeeId[0];
            A100CompanyId = P00995_A100CompanyId[0];
            A103ProjectName = P00995_A103ProjectName[0];
            A102ProjectId = P00995_A102ProjectId[0];
            A107EmployeeFirstName = P00995_A107EmployeeFirstName[0];
            A123WorkHourLogDescription = P00995_A123WorkHourLogDescription[0];
            A122WorkHourLogMinute = P00995_A122WorkHourLogMinute[0];
            A121WorkHourLogHour = P00995_A121WorkHourLogHour[0];
            A120WorkHourLogDuration = P00995_A120WorkHourLogDuration[0];
            A119WorkHourLogDate = P00995_A119WorkHourLogDate[0];
            A118WorkHourLogId = P00995_A118WorkHourLogId[0];
            A100CompanyId = P00995_A100CompanyId[0];
            A107EmployeeFirstName = P00995_A107EmployeeFirstName[0];
            A103ProjectName = P00995_A103ProjectName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( P00995_A106EmployeeId[0] == A106EmployeeId ) && ( StringUtil.StrCmp(P00995_A103ProjectName[0], A103ProjectName) == 0 ) )
            {
               BRK998 = false;
               A102ProjectId = P00995_A102ProjectId[0];
               A118WorkHourLogId = P00995_A118WorkHourLogId[0];
               AV41count = (long)(AV41count+1);
               BRK998 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A103ProjectName)) ? "<#Empty#>" : A103ProjectName);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK998 )
            {
               BRK998 = true;
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
         AV50OptionsJson = "";
         AV51OptionsDescJson = "";
         AV52OptionIndexesJson = "";
         AV37Options = new GxSimpleCollection<string>();
         AV39OptionsDesc = new GxSimpleCollection<string>();
         AV40OptionIndexes = new GxSimpleCollection<string>();
         AV31SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV42Session = context.GetSession();
         AV44GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV45GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV53FilterFullText = "";
         AV13TFWorkHourLogDate = DateTime.MinValue;
         AV14TFWorkHourLogDate_To = DateTime.MinValue;
         AV15TFWorkHourLogDuration = "";
         AV16TFWorkHourLogDuration_Sel = "";
         AV21TFWorkHourLogDescription = "";
         AV22TFWorkHourLogDescription_Sel = "";
         AV25TFEmployeeFirstName = "";
         AV26TFEmployeeFirstName_Sel = "";
         AV29TFProjectName = "";
         AV30TFProjectName_Sel = "";
         AV60Workhourlogbyemployeeds_2_filterfulltext = "";
         AV63Workhourlogbyemployeeds_5_tfworkhourlogdate = DateTime.MinValue;
         AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to = DateTime.MinValue;
         AV65Workhourlogbyemployeeds_7_tfworkhourlogduration = "";
         AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel = "";
         AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription = "";
         AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel = "";
         AV75Workhourlogbyemployeeds_17_tfemployeefirstname = "";
         AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel = "";
         AV79Workhourlogbyemployeeds_21_tfprojectname = "";
         AV80Workhourlogbyemployeeds_22_tfprojectname_sel = "";
         lV60Workhourlogbyemployeeds_2_filterfulltext = "";
         lV65Workhourlogbyemployeeds_7_tfworkhourlogduration = "";
         lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription = "";
         lV75Workhourlogbyemployeeds_17_tfemployeefirstname = "";
         lV79Workhourlogbyemployeeds_21_tfprojectname = "";
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         A107EmployeeFirstName = "";
         A103ProjectName = "";
         A119WorkHourLogDate = DateTime.MinValue;
         P00992_A106EmployeeId = new long[1] ;
         P00992_A100CompanyId = new long[1] ;
         P00992_A120WorkHourLogDuration = new string[] {""} ;
         P00992_A103ProjectName = new string[] {""} ;
         P00992_A102ProjectId = new long[1] ;
         P00992_A107EmployeeFirstName = new string[] {""} ;
         P00992_A123WorkHourLogDescription = new string[] {""} ;
         P00992_A122WorkHourLogMinute = new short[1] ;
         P00992_A121WorkHourLogHour = new short[1] ;
         P00992_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00992_A118WorkHourLogId = new long[1] ;
         AV36Option = "";
         P00993_A106EmployeeId = new long[1] ;
         P00993_A100CompanyId = new long[1] ;
         P00993_A123WorkHourLogDescription = new string[] {""} ;
         P00993_A103ProjectName = new string[] {""} ;
         P00993_A102ProjectId = new long[1] ;
         P00993_A107EmployeeFirstName = new string[] {""} ;
         P00993_A122WorkHourLogMinute = new short[1] ;
         P00993_A121WorkHourLogHour = new short[1] ;
         P00993_A120WorkHourLogDuration = new string[] {""} ;
         P00993_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00993_A118WorkHourLogId = new long[1] ;
         P00994_A106EmployeeId = new long[1] ;
         P00994_A100CompanyId = new long[1] ;
         P00994_A103ProjectName = new string[] {""} ;
         P00994_A102ProjectId = new long[1] ;
         P00994_A107EmployeeFirstName = new string[] {""} ;
         P00994_A123WorkHourLogDescription = new string[] {""} ;
         P00994_A122WorkHourLogMinute = new short[1] ;
         P00994_A121WorkHourLogHour = new short[1] ;
         P00994_A120WorkHourLogDuration = new string[] {""} ;
         P00994_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00994_A118WorkHourLogId = new long[1] ;
         P00995_A106EmployeeId = new long[1] ;
         P00995_A100CompanyId = new long[1] ;
         P00995_A103ProjectName = new string[] {""} ;
         P00995_A102ProjectId = new long[1] ;
         P00995_A107EmployeeFirstName = new string[] {""} ;
         P00995_A123WorkHourLogDescription = new string[] {""} ;
         P00995_A122WorkHourLogMinute = new short[1] ;
         P00995_A121WorkHourLogHour = new short[1] ;
         P00995_A120WorkHourLogDuration = new string[] {""} ;
         P00995_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00995_A118WorkHourLogId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workhourlogbyemployeegetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00992_A106EmployeeId, P00992_A100CompanyId, P00992_A120WorkHourLogDuration, P00992_A103ProjectName, P00992_A102ProjectId, P00992_A107EmployeeFirstName, P00992_A123WorkHourLogDescription, P00992_A122WorkHourLogMinute, P00992_A121WorkHourLogHour, P00992_A119WorkHourLogDate,
               P00992_A118WorkHourLogId
               }
               , new Object[] {
               P00993_A106EmployeeId, P00993_A100CompanyId, P00993_A123WorkHourLogDescription, P00993_A103ProjectName, P00993_A102ProjectId, P00993_A107EmployeeFirstName, P00993_A122WorkHourLogMinute, P00993_A121WorkHourLogHour, P00993_A120WorkHourLogDuration, P00993_A119WorkHourLogDate,
               P00993_A118WorkHourLogId
               }
               , new Object[] {
               P00994_A106EmployeeId, P00994_A100CompanyId, P00994_A103ProjectName, P00994_A102ProjectId, P00994_A107EmployeeFirstName, P00994_A123WorkHourLogDescription, P00994_A122WorkHourLogMinute, P00994_A121WorkHourLogHour, P00994_A120WorkHourLogDuration, P00994_A119WorkHourLogDate,
               P00994_A118WorkHourLogId
               }
               , new Object[] {
               P00995_A106EmployeeId, P00995_A100CompanyId, P00995_A103ProjectName, P00995_A102ProjectId, P00995_A107EmployeeFirstName, P00995_A123WorkHourLogDescription, P00995_A122WorkHourLogMinute, P00995_A121WorkHourLogHour, P00995_A120WorkHourLogDuration, P00995_A119WorkHourLogDate,
               P00995_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV34MaxItems ;
      private short AV33PageIndex ;
      private short AV32SkipItems ;
      private short AV17TFWorkHourLogHour ;
      private short AV18TFWorkHourLogHour_To ;
      private short AV19TFWorkHourLogMinute ;
      private short AV20TFWorkHourLogMinute_To ;
      private short AV67Workhourlogbyemployeeds_9_tfworkhourloghour ;
      private short AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to ;
      private short AV69Workhourlogbyemployeeds_11_tfworkhourlogminute ;
      private short AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to ;
      private short A121WorkHourLogHour ;
      private short A122WorkHourLogMinute ;
      private int AV57GXV1 ;
      private int AV35InsertIndex ;
      private long AV11TFWorkHourLogId ;
      private long AV12TFWorkHourLogId_To ;
      private long AV23TFEmployeeId ;
      private long AV24TFEmployeeId_To ;
      private long AV27TFProjectId ;
      private long AV28TFProjectId_To ;
      private long AV54EmployeeId ;
      private long AV59Workhourlogbyemployeeds_1_employeeid ;
      private long AV61Workhourlogbyemployeeds_3_tfworkhourlogid ;
      private long AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to ;
      private long AV73Workhourlogbyemployeeds_15_tfemployeeid ;
      private long AV74Workhourlogbyemployeeds_16_tfemployeeid_to ;
      private long AV77Workhourlogbyemployeeds_19_tfprojectid ;
      private long AV78Workhourlogbyemployeeds_20_tfprojectid_to ;
      private long AV81Udparg23 ;
      private long A118WorkHourLogId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A100CompanyId ;
      private long AV41count ;
      private long AV84Udparg24 ;
      private long AV87Udparg25 ;
      private long AV90Udparg26 ;
      private string AV25TFEmployeeFirstName ;
      private string AV26TFEmployeeFirstName_Sel ;
      private string AV29TFProjectName ;
      private string AV30TFProjectName_Sel ;
      private string AV75Workhourlogbyemployeeds_17_tfemployeefirstname ;
      private string AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel ;
      private string AV79Workhourlogbyemployeeds_21_tfprojectname ;
      private string AV80Workhourlogbyemployeeds_22_tfprojectname_sel ;
      private string lV75Workhourlogbyemployeeds_17_tfemployeefirstname ;
      private string lV79Workhourlogbyemployeeds_21_tfprojectname ;
      private string A107EmployeeFirstName ;
      private string A103ProjectName ;
      private DateTime AV13TFWorkHourLogDate ;
      private DateTime AV14TFWorkHourLogDate_To ;
      private DateTime AV63Workhourlogbyemployeeds_5_tfworkhourlogdate ;
      private DateTime AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to ;
      private DateTime A119WorkHourLogDate ;
      private bool returnInSub ;
      private bool BRK992 ;
      private bool BRK994 ;
      private bool BRK996 ;
      private bool BRK998 ;
      private string AV50OptionsJson ;
      private string AV51OptionsDescJson ;
      private string AV52OptionIndexesJson ;
      private string A123WorkHourLogDescription ;
      private string AV47DDOName ;
      private string AV48SearchTxtParms ;
      private string AV49SearchTxtTo ;
      private string AV31SearchTxt ;
      private string AV53FilterFullText ;
      private string AV15TFWorkHourLogDuration ;
      private string AV16TFWorkHourLogDuration_Sel ;
      private string AV21TFWorkHourLogDescription ;
      private string AV22TFWorkHourLogDescription_Sel ;
      private string AV60Workhourlogbyemployeeds_2_filterfulltext ;
      private string AV65Workhourlogbyemployeeds_7_tfworkhourlogduration ;
      private string AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel ;
      private string AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription ;
      private string AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel ;
      private string lV60Workhourlogbyemployeeds_2_filterfulltext ;
      private string lV65Workhourlogbyemployeeds_7_tfworkhourlogduration ;
      private string lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription ;
      private string A120WorkHourLogDuration ;
      private string AV36Option ;
      private IGxSession AV42Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV37Options ;
      private GxSimpleCollection<string> AV39OptionsDesc ;
      private GxSimpleCollection<string> AV40OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV44GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV45GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private long[] P00992_A106EmployeeId ;
      private long[] P00992_A100CompanyId ;
      private string[] P00992_A120WorkHourLogDuration ;
      private string[] P00992_A103ProjectName ;
      private long[] P00992_A102ProjectId ;
      private string[] P00992_A107EmployeeFirstName ;
      private string[] P00992_A123WorkHourLogDescription ;
      private short[] P00992_A122WorkHourLogMinute ;
      private short[] P00992_A121WorkHourLogHour ;
      private DateTime[] P00992_A119WorkHourLogDate ;
      private long[] P00992_A118WorkHourLogId ;
      private long[] P00993_A106EmployeeId ;
      private long[] P00993_A100CompanyId ;
      private string[] P00993_A123WorkHourLogDescription ;
      private string[] P00993_A103ProjectName ;
      private long[] P00993_A102ProjectId ;
      private string[] P00993_A107EmployeeFirstName ;
      private short[] P00993_A122WorkHourLogMinute ;
      private short[] P00993_A121WorkHourLogHour ;
      private string[] P00993_A120WorkHourLogDuration ;
      private DateTime[] P00993_A119WorkHourLogDate ;
      private long[] P00993_A118WorkHourLogId ;
      private long[] P00994_A106EmployeeId ;
      private long[] P00994_A100CompanyId ;
      private string[] P00994_A103ProjectName ;
      private long[] P00994_A102ProjectId ;
      private string[] P00994_A107EmployeeFirstName ;
      private string[] P00994_A123WorkHourLogDescription ;
      private short[] P00994_A122WorkHourLogMinute ;
      private short[] P00994_A121WorkHourLogHour ;
      private string[] P00994_A120WorkHourLogDuration ;
      private DateTime[] P00994_A119WorkHourLogDate ;
      private long[] P00994_A118WorkHourLogId ;
      private long[] P00995_A106EmployeeId ;
      private long[] P00995_A100CompanyId ;
      private string[] P00995_A103ProjectName ;
      private long[] P00995_A102ProjectId ;
      private string[] P00995_A107EmployeeFirstName ;
      private string[] P00995_A123WorkHourLogDescription ;
      private short[] P00995_A122WorkHourLogMinute ;
      private short[] P00995_A121WorkHourLogHour ;
      private string[] P00995_A120WorkHourLogDuration ;
      private DateTime[] P00995_A119WorkHourLogDate ;
      private long[] P00995_A118WorkHourLogId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class workhourlogbyemployeegetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00992( IGxContext context ,
                                             string AV60Workhourlogbyemployeeds_2_filterfulltext ,
                                             long AV61Workhourlogbyemployeeds_3_tfworkhourlogid ,
                                             long AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to ,
                                             DateTime AV63Workhourlogbyemployeeds_5_tfworkhourlogdate ,
                                             DateTime AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to ,
                                             string AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel ,
                                             string AV65Workhourlogbyemployeeds_7_tfworkhourlogduration ,
                                             short AV67Workhourlogbyemployeeds_9_tfworkhourloghour ,
                                             short AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to ,
                                             short AV69Workhourlogbyemployeeds_11_tfworkhourlogminute ,
                                             short AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to ,
                                             string AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel ,
                                             string AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription ,
                                             long AV73Workhourlogbyemployeeds_15_tfemployeeid ,
                                             long AV74Workhourlogbyemployeeds_16_tfemployeeid_to ,
                                             string AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel ,
                                             string AV75Workhourlogbyemployeeds_17_tfemployeefirstname ,
                                             long AV77Workhourlogbyemployeeds_19_tfprojectid ,
                                             long AV78Workhourlogbyemployeeds_20_tfprojectid_to ,
                                             string AV80Workhourlogbyemployeeds_22_tfprojectname_sel ,
                                             string AV79Workhourlogbyemployeeds_21_tfprojectname ,
                                             long A118WorkHourLogId ,
                                             string A120WorkHourLogDuration ,
                                             short A121WorkHourLogHour ,
                                             short A122WorkHourLogMinute ,
                                             string A123WorkHourLogDescription ,
                                             long A106EmployeeId ,
                                             string A107EmployeeFirstName ,
                                             long A102ProjectId ,
                                             string A103ProjectName ,
                                             DateTime A119WorkHourLogDate ,
                                             long A100CompanyId ,
                                             long AV81Udparg23 ,
                                             long AV54EmployeeId ,
                                             long AV59Workhourlogbyemployeeds_1_employeeid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[32];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T2.CompanyId, T1.WorkHourLogDuration, T3.ProjectName, T1.ProjectId, T2.EmployeeFirstName, T1.WorkHourLogDescription, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogDate, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = T1.ProjectId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV59Workhourlogbyemployeeds_1_employeeid)");
         AddWhere(sWhereString, "(T2.CompanyId = :AV81Udparg23)");
         AddWhere(sWhereString, "(T1.EmployeeId = :AV54EmployeeId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.WorkHourLogId,'9999999999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( LOWER(T1.WorkHourLogDuration) like '%' || LOWER(:lV60Workhourlogbyemployeeds_2_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.WorkHourLogHour,'9999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogMinute,'9999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( LOWER(T1.WorkHourLogDescription) like '%' || LOWER(:lV60Workhourlogbyemployeeds_2_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( LOWER(T2.EmployeeFirstName) like '%' || LOWER(:lV60Workhourlogbyemployeeds_2_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.ProjectId,'9999999999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( LOWER(T3.ProjectName) like '%' || LOWER(:lV60Workhourlogbyemployeeds_2_filterfulltext)))");
         }
         else
         {
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
            GXv_int1[9] = 1;
            GXv_int1[10] = 1;
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV61Workhourlogbyemployeeds_3_tfworkhourlogid) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogId >= :AV61Workhourlogbyemployeeds_3_tfworkhourlogid)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogId <= :AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV63Workhourlogbyemployeeds_5_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV63Workhourlogbyemployeeds_5_tfworkhourlogdate)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Workhourlogbyemployeeds_7_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.WorkHourLogDuration) like LOWER(:lV65Workhourlogbyemployeeds_7_tfworkhourlogduration))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( ! (0==AV67Workhourlogbyemployeeds_9_tfworkhourloghour) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour >= :AV67Workhourlogbyemployeeds_9_tfworkhourloghour)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! (0==AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour <= :AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! (0==AV69Workhourlogbyemployeeds_11_tfworkhourlogminute) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute >= :AV69Workhourlogbyemployeeds_11_tfworkhourlogminute)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! (0==AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute <= :AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.WorkHourLogDescription) like LOWER(:lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription))");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( StringUtil.StrCmp(AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( ! (0==AV73Workhourlogbyemployeeds_15_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV73Workhourlogbyemployeeds_15_tfemployeeid)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! (0==AV74Workhourlogbyemployeeds_16_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV74Workhourlogbyemployeeds_16_tfemployeeid_to)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Workhourlogbyemployeeds_17_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.EmployeeFirstName) like LOWER(:lV75Workhourlogbyemployeeds_17_tfemployeefirstname))");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeFirstName = ( :AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( StringUtil.StrCmp(AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeFirstName))=0))");
         }
         if ( ! (0==AV77Workhourlogbyemployeeds_19_tfprojectid) )
         {
            AddWhere(sWhereString, "(T1.ProjectId >= :AV77Workhourlogbyemployeeds_19_tfprojectid)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( ! (0==AV78Workhourlogbyemployeeds_20_tfprojectid_to) )
         {
            AddWhere(sWhereString, "(T1.ProjectId <= :AV78Workhourlogbyemployeeds_20_tfprojectid_to)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Workhourlogbyemployeeds_22_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Workhourlogbyemployeeds_21_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.ProjectName) like LOWER(:lV79Workhourlogbyemployeeds_21_tfprojectname))");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Workhourlogbyemployeeds_22_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV80Workhourlogbyemployeeds_22_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProjectName = ( :AV80Workhourlogbyemployeeds_22_tfprojectname_sel))");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( StringUtil.StrCmp(AV80Workhourlogbyemployeeds_22_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProjectName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId, T1.WorkHourLogDuration";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00993( IGxContext context ,
                                             string AV60Workhourlogbyemployeeds_2_filterfulltext ,
                                             long AV61Workhourlogbyemployeeds_3_tfworkhourlogid ,
                                             long AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to ,
                                             DateTime AV63Workhourlogbyemployeeds_5_tfworkhourlogdate ,
                                             DateTime AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to ,
                                             string AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel ,
                                             string AV65Workhourlogbyemployeeds_7_tfworkhourlogduration ,
                                             short AV67Workhourlogbyemployeeds_9_tfworkhourloghour ,
                                             short AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to ,
                                             short AV69Workhourlogbyemployeeds_11_tfworkhourlogminute ,
                                             short AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to ,
                                             string AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel ,
                                             string AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription ,
                                             long AV73Workhourlogbyemployeeds_15_tfemployeeid ,
                                             long AV74Workhourlogbyemployeeds_16_tfemployeeid_to ,
                                             string AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel ,
                                             string AV75Workhourlogbyemployeeds_17_tfemployeefirstname ,
                                             long AV77Workhourlogbyemployeeds_19_tfprojectid ,
                                             long AV78Workhourlogbyemployeeds_20_tfprojectid_to ,
                                             string AV80Workhourlogbyemployeeds_22_tfprojectname_sel ,
                                             string AV79Workhourlogbyemployeeds_21_tfprojectname ,
                                             long A118WorkHourLogId ,
                                             string A120WorkHourLogDuration ,
                                             short A121WorkHourLogHour ,
                                             short A122WorkHourLogMinute ,
                                             string A123WorkHourLogDescription ,
                                             long A106EmployeeId ,
                                             string A107EmployeeFirstName ,
                                             long A102ProjectId ,
                                             string A103ProjectName ,
                                             DateTime A119WorkHourLogDate ,
                                             long A100CompanyId ,
                                             long AV84Udparg24 ,
                                             long AV54EmployeeId ,
                                             long AV59Workhourlogbyemployeeds_1_employeeid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[32];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T2.CompanyId, T1.WorkHourLogDescription, T3.ProjectName, T1.ProjectId, T2.EmployeeFirstName, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogDuration, T1.WorkHourLogDate, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = T1.ProjectId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV59Workhourlogbyemployeeds_1_employeeid)");
         AddWhere(sWhereString, "(T2.CompanyId = :AV84Udparg24)");
         AddWhere(sWhereString, "(T1.EmployeeId = :AV54EmployeeId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.WorkHourLogId,'9999999999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( LOWER(T1.WorkHourLogDuration) like '%' || LOWER(:lV60Workhourlogbyemployeeds_2_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.WorkHourLogHour,'9999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogMinute,'9999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( LOWER(T1.WorkHourLogDescription) like '%' || LOWER(:lV60Workhourlogbyemployeeds_2_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( LOWER(T2.EmployeeFirstName) like '%' || LOWER(:lV60Workhourlogbyemployeeds_2_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.ProjectId,'9999999999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( LOWER(T3.ProjectName) like '%' || LOWER(:lV60Workhourlogbyemployeeds_2_filterfulltext)))");
         }
         else
         {
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
            GXv_int3[9] = 1;
            GXv_int3[10] = 1;
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV61Workhourlogbyemployeeds_3_tfworkhourlogid) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogId >= :AV61Workhourlogbyemployeeds_3_tfworkhourlogid)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogId <= :AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV63Workhourlogbyemployeeds_5_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV63Workhourlogbyemployeeds_5_tfworkhourlogdate)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Workhourlogbyemployeeds_7_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.WorkHourLogDuration) like LOWER(:lV65Workhourlogbyemployeeds_7_tfworkhourlogduration))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( ! (0==AV67Workhourlogbyemployeeds_9_tfworkhourloghour) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour >= :AV67Workhourlogbyemployeeds_9_tfworkhourloghour)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! (0==AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour <= :AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! (0==AV69Workhourlogbyemployeeds_11_tfworkhourlogminute) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute >= :AV69Workhourlogbyemployeeds_11_tfworkhourlogminute)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! (0==AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute <= :AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.WorkHourLogDescription) like LOWER(:lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription))");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( StringUtil.StrCmp(AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( ! (0==AV73Workhourlogbyemployeeds_15_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV73Workhourlogbyemployeeds_15_tfemployeeid)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! (0==AV74Workhourlogbyemployeeds_16_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV74Workhourlogbyemployeeds_16_tfemployeeid_to)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Workhourlogbyemployeeds_17_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.EmployeeFirstName) like LOWER(:lV75Workhourlogbyemployeeds_17_tfemployeefirstname))");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeFirstName = ( :AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( StringUtil.StrCmp(AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeFirstName))=0))");
         }
         if ( ! (0==AV77Workhourlogbyemployeeds_19_tfprojectid) )
         {
            AddWhere(sWhereString, "(T1.ProjectId >= :AV77Workhourlogbyemployeeds_19_tfprojectid)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ! (0==AV78Workhourlogbyemployeeds_20_tfprojectid_to) )
         {
            AddWhere(sWhereString, "(T1.ProjectId <= :AV78Workhourlogbyemployeeds_20_tfprojectid_to)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Workhourlogbyemployeeds_22_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Workhourlogbyemployeeds_21_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.ProjectName) like LOWER(:lV79Workhourlogbyemployeeds_21_tfprojectname))");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Workhourlogbyemployeeds_22_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV80Workhourlogbyemployeeds_22_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProjectName = ( :AV80Workhourlogbyemployeeds_22_tfprojectname_sel))");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( StringUtil.StrCmp(AV80Workhourlogbyemployeeds_22_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProjectName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId, T1.WorkHourLogDescription";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00994( IGxContext context ,
                                             string AV60Workhourlogbyemployeeds_2_filterfulltext ,
                                             long AV61Workhourlogbyemployeeds_3_tfworkhourlogid ,
                                             long AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to ,
                                             DateTime AV63Workhourlogbyemployeeds_5_tfworkhourlogdate ,
                                             DateTime AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to ,
                                             string AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel ,
                                             string AV65Workhourlogbyemployeeds_7_tfworkhourlogduration ,
                                             short AV67Workhourlogbyemployeeds_9_tfworkhourloghour ,
                                             short AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to ,
                                             short AV69Workhourlogbyemployeeds_11_tfworkhourlogminute ,
                                             short AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to ,
                                             string AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel ,
                                             string AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription ,
                                             long AV73Workhourlogbyemployeeds_15_tfemployeeid ,
                                             long AV74Workhourlogbyemployeeds_16_tfemployeeid_to ,
                                             string AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel ,
                                             string AV75Workhourlogbyemployeeds_17_tfemployeefirstname ,
                                             long AV77Workhourlogbyemployeeds_19_tfprojectid ,
                                             long AV78Workhourlogbyemployeeds_20_tfprojectid_to ,
                                             string AV80Workhourlogbyemployeeds_22_tfprojectname_sel ,
                                             string AV79Workhourlogbyemployeeds_21_tfprojectname ,
                                             long A118WorkHourLogId ,
                                             string A120WorkHourLogDuration ,
                                             short A121WorkHourLogHour ,
                                             short A122WorkHourLogMinute ,
                                             string A123WorkHourLogDescription ,
                                             long A106EmployeeId ,
                                             string A107EmployeeFirstName ,
                                             long A102ProjectId ,
                                             string A103ProjectName ,
                                             DateTime A119WorkHourLogDate ,
                                             long A100CompanyId ,
                                             long AV87Udparg25 ,
                                             long AV54EmployeeId ,
                                             long AV59Workhourlogbyemployeeds_1_employeeid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[32];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T2.CompanyId, T3.ProjectName, T1.ProjectId, T2.EmployeeFirstName, T1.WorkHourLogDescription, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogDuration, T1.WorkHourLogDate, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = T1.ProjectId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV59Workhourlogbyemployeeds_1_employeeid)");
         AddWhere(sWhereString, "(T2.CompanyId = :AV87Udparg25)");
         AddWhere(sWhereString, "(T1.EmployeeId = :AV54EmployeeId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.WorkHourLogId,'9999999999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( LOWER(T1.WorkHourLogDuration) like '%' || LOWER(:lV60Workhourlogbyemployeeds_2_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.WorkHourLogHour,'9999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogMinute,'9999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( LOWER(T1.WorkHourLogDescription) like '%' || LOWER(:lV60Workhourlogbyemployeeds_2_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( LOWER(T2.EmployeeFirstName) like '%' || LOWER(:lV60Workhourlogbyemployeeds_2_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.ProjectId,'9999999999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( LOWER(T3.ProjectName) like '%' || LOWER(:lV60Workhourlogbyemployeeds_2_filterfulltext)))");
         }
         else
         {
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
            GXv_int5[9] = 1;
            GXv_int5[10] = 1;
            GXv_int5[11] = 1;
         }
         if ( ! (0==AV61Workhourlogbyemployeeds_3_tfworkhourlogid) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogId >= :AV61Workhourlogbyemployeeds_3_tfworkhourlogid)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (0==AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogId <= :AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV63Workhourlogbyemployeeds_5_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV63Workhourlogbyemployeeds_5_tfworkhourlogdate)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Workhourlogbyemployeeds_7_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.WorkHourLogDuration) like LOWER(:lV65Workhourlogbyemployeeds_7_tfworkhourlogduration))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( ! (0==AV67Workhourlogbyemployeeds_9_tfworkhourloghour) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour >= :AV67Workhourlogbyemployeeds_9_tfworkhourloghour)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! (0==AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour <= :AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! (0==AV69Workhourlogbyemployeeds_11_tfworkhourlogminute) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute >= :AV69Workhourlogbyemployeeds_11_tfworkhourlogminute)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! (0==AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute <= :AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.WorkHourLogDescription) like LOWER(:lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription))");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( StringUtil.StrCmp(AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( ! (0==AV73Workhourlogbyemployeeds_15_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV73Workhourlogbyemployeeds_15_tfemployeeid)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! (0==AV74Workhourlogbyemployeeds_16_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV74Workhourlogbyemployeeds_16_tfemployeeid_to)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Workhourlogbyemployeeds_17_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.EmployeeFirstName) like LOWER(:lV75Workhourlogbyemployeeds_17_tfemployeefirstname))");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeFirstName = ( :AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( StringUtil.StrCmp(AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeFirstName))=0))");
         }
         if ( ! (0==AV77Workhourlogbyemployeeds_19_tfprojectid) )
         {
            AddWhere(sWhereString, "(T1.ProjectId >= :AV77Workhourlogbyemployeeds_19_tfprojectid)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( ! (0==AV78Workhourlogbyemployeeds_20_tfprojectid_to) )
         {
            AddWhere(sWhereString, "(T1.ProjectId <= :AV78Workhourlogbyemployeeds_20_tfprojectid_to)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Workhourlogbyemployeeds_22_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Workhourlogbyemployeeds_21_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.ProjectName) like LOWER(:lV79Workhourlogbyemployeeds_21_tfprojectname))");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Workhourlogbyemployeeds_22_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV80Workhourlogbyemployeeds_22_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProjectName = ( :AV80Workhourlogbyemployeeds_22_tfprojectname_sel))");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( StringUtil.StrCmp(AV80Workhourlogbyemployeeds_22_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProjectName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00995( IGxContext context ,
                                             string AV60Workhourlogbyemployeeds_2_filterfulltext ,
                                             long AV61Workhourlogbyemployeeds_3_tfworkhourlogid ,
                                             long AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to ,
                                             DateTime AV63Workhourlogbyemployeeds_5_tfworkhourlogdate ,
                                             DateTime AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to ,
                                             string AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel ,
                                             string AV65Workhourlogbyemployeeds_7_tfworkhourlogduration ,
                                             short AV67Workhourlogbyemployeeds_9_tfworkhourloghour ,
                                             short AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to ,
                                             short AV69Workhourlogbyemployeeds_11_tfworkhourlogminute ,
                                             short AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to ,
                                             string AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel ,
                                             string AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription ,
                                             long AV73Workhourlogbyemployeeds_15_tfemployeeid ,
                                             long AV74Workhourlogbyemployeeds_16_tfemployeeid_to ,
                                             string AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel ,
                                             string AV75Workhourlogbyemployeeds_17_tfemployeefirstname ,
                                             long AV77Workhourlogbyemployeeds_19_tfprojectid ,
                                             long AV78Workhourlogbyemployeeds_20_tfprojectid_to ,
                                             string AV80Workhourlogbyemployeeds_22_tfprojectname_sel ,
                                             string AV79Workhourlogbyemployeeds_21_tfprojectname ,
                                             long A118WorkHourLogId ,
                                             string A120WorkHourLogDuration ,
                                             short A121WorkHourLogHour ,
                                             short A122WorkHourLogMinute ,
                                             string A123WorkHourLogDescription ,
                                             long A106EmployeeId ,
                                             string A107EmployeeFirstName ,
                                             long A102ProjectId ,
                                             string A103ProjectName ,
                                             DateTime A119WorkHourLogDate ,
                                             long A100CompanyId ,
                                             long AV90Udparg26 ,
                                             long AV54EmployeeId ,
                                             long AV59Workhourlogbyemployeeds_1_employeeid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[32];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T2.CompanyId, T3.ProjectName, T1.ProjectId, T2.EmployeeFirstName, T1.WorkHourLogDescription, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogDuration, T1.WorkHourLogDate, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = T1.ProjectId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV59Workhourlogbyemployeeds_1_employeeid)");
         AddWhere(sWhereString, "(T2.CompanyId = :AV90Udparg26)");
         AddWhere(sWhereString, "(T1.EmployeeId = :AV54EmployeeId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Workhourlogbyemployeeds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.WorkHourLogId,'9999999999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( LOWER(T1.WorkHourLogDuration) like '%' || LOWER(:lV60Workhourlogbyemployeeds_2_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.WorkHourLogHour,'9999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogMinute,'9999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( LOWER(T1.WorkHourLogDescription) like '%' || LOWER(:lV60Workhourlogbyemployeeds_2_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( LOWER(T2.EmployeeFirstName) like '%' || LOWER(:lV60Workhourlogbyemployeeds_2_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.ProjectId,'9999999999'), 2) like '%' || :lV60Workhourlogbyemployeeds_2_filterfulltext) or ( LOWER(T3.ProjectName) like '%' || LOWER(:lV60Workhourlogbyemployeeds_2_filterfulltext)))");
         }
         else
         {
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
            GXv_int7[9] = 1;
            GXv_int7[10] = 1;
            GXv_int7[11] = 1;
         }
         if ( ! (0==AV61Workhourlogbyemployeeds_3_tfworkhourlogid) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogId >= :AV61Workhourlogbyemployeeds_3_tfworkhourlogid)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! (0==AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogId <= :AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV63Workhourlogbyemployeeds_5_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV63Workhourlogbyemployeeds_5_tfworkhourlogdate)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Workhourlogbyemployeeds_7_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.WorkHourLogDuration) like LOWER(:lV65Workhourlogbyemployeeds_7_tfworkhourlogduration))");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( StringUtil.StrCmp(AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( ! (0==AV67Workhourlogbyemployeeds_9_tfworkhourloghour) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour >= :AV67Workhourlogbyemployeeds_9_tfworkhourloghour)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! (0==AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour <= :AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! (0==AV69Workhourlogbyemployeeds_11_tfworkhourlogminute) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute >= :AV69Workhourlogbyemployeeds_11_tfworkhourlogminute)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! (0==AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute <= :AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Workhourlogbyemployeeds_13_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T1.WorkHourLogDescription) like LOWER(:lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription))");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( StringUtil.StrCmp(AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( ! (0==AV73Workhourlogbyemployeeds_15_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV73Workhourlogbyemployeeds_15_tfemployeeid)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ! (0==AV74Workhourlogbyemployeeds_16_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV74Workhourlogbyemployeeds_16_tfemployeeid_to)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Workhourlogbyemployeeds_17_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T2.EmployeeFirstName) like LOWER(:lV75Workhourlogbyemployeeds_17_tfemployeefirstname))");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeFirstName = ( :AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( StringUtil.StrCmp(AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeFirstName))=0))");
         }
         if ( ! (0==AV77Workhourlogbyemployeeds_19_tfprojectid) )
         {
            AddWhere(sWhereString, "(T1.ProjectId >= :AV77Workhourlogbyemployeeds_19_tfprojectid)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( ! (0==AV78Workhourlogbyemployeeds_20_tfprojectid_to) )
         {
            AddWhere(sWhereString, "(T1.ProjectId <= :AV78Workhourlogbyemployeeds_20_tfprojectid_to)");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Workhourlogbyemployeeds_22_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Workhourlogbyemployeeds_21_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(LOWER(T3.ProjectName) like LOWER(:lV79Workhourlogbyemployeeds_21_tfprojectname))");
         }
         else
         {
            GXv_int7[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Workhourlogbyemployeeds_22_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV80Workhourlogbyemployeeds_22_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProjectName = ( :AV80Workhourlogbyemployeeds_22_tfprojectname_sel))");
         }
         else
         {
            GXv_int7[31] = 1;
         }
         if ( StringUtil.StrCmp(AV80Workhourlogbyemployeeds_22_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProjectName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId, T3.ProjectName";
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
                     return conditional_P00992(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (string)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (DateTime)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] );
               case 1 :
                     return conditional_P00993(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (string)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (DateTime)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] );
               case 2 :
                     return conditional_P00994(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (string)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (DateTime)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] );
               case 3 :
                     return conditional_P00995(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (string)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (DateTime)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] );
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
          Object[] prmP00992;
          prmP00992 = new Object[] {
          new ParDef("AV59Workhourlogbyemployeeds_1_employeeid",GXType.Int64,10,0) ,
          new ParDef("AV81Udparg23",GXType.Int64,10,0) ,
          new ParDef("AV54EmployeeId",GXType.Int64,10,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV61Workhourlogbyemployeeds_3_tfworkhourlogid",GXType.Int64,10,0) ,
          new ParDef("AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to",GXType.Int64,10,0) ,
          new ParDef("AV63Workhourlogbyemployeeds_5_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV65Workhourlogbyemployeeds_7_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("AV67Workhourlogbyemployeeds_9_tfworkhourloghour",GXType.Int16,4,0) ,
          new ParDef("AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to",GXType.Int16,4,0) ,
          new ParDef("AV69Workhourlogbyemployeeds_11_tfworkhourlogminute",GXType.Int16,4,0) ,
          new ParDef("AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to",GXType.Int16,4,0) ,
          new ParDef("lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV73Workhourlogbyemployeeds_15_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV74Workhourlogbyemployeeds_16_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV75Workhourlogbyemployeeds_17_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("AV77Workhourlogbyemployeeds_19_tfprojectid",GXType.Int64,10,0) ,
          new ParDef("AV78Workhourlogbyemployeeds_20_tfprojectid_to",GXType.Int64,10,0) ,
          new ParDef("lV79Workhourlogbyemployeeds_21_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV80Workhourlogbyemployeeds_22_tfprojectname_sel",GXType.Char,100,0)
          };
          Object[] prmP00993;
          prmP00993 = new Object[] {
          new ParDef("AV59Workhourlogbyemployeeds_1_employeeid",GXType.Int64,10,0) ,
          new ParDef("AV84Udparg24",GXType.Int64,10,0) ,
          new ParDef("AV54EmployeeId",GXType.Int64,10,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV61Workhourlogbyemployeeds_3_tfworkhourlogid",GXType.Int64,10,0) ,
          new ParDef("AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to",GXType.Int64,10,0) ,
          new ParDef("AV63Workhourlogbyemployeeds_5_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV65Workhourlogbyemployeeds_7_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("AV67Workhourlogbyemployeeds_9_tfworkhourloghour",GXType.Int16,4,0) ,
          new ParDef("AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to",GXType.Int16,4,0) ,
          new ParDef("AV69Workhourlogbyemployeeds_11_tfworkhourlogminute",GXType.Int16,4,0) ,
          new ParDef("AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to",GXType.Int16,4,0) ,
          new ParDef("lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV73Workhourlogbyemployeeds_15_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV74Workhourlogbyemployeeds_16_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV75Workhourlogbyemployeeds_17_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("AV77Workhourlogbyemployeeds_19_tfprojectid",GXType.Int64,10,0) ,
          new ParDef("AV78Workhourlogbyemployeeds_20_tfprojectid_to",GXType.Int64,10,0) ,
          new ParDef("lV79Workhourlogbyemployeeds_21_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV80Workhourlogbyemployeeds_22_tfprojectname_sel",GXType.Char,100,0)
          };
          Object[] prmP00994;
          prmP00994 = new Object[] {
          new ParDef("AV59Workhourlogbyemployeeds_1_employeeid",GXType.Int64,10,0) ,
          new ParDef("AV87Udparg25",GXType.Int64,10,0) ,
          new ParDef("AV54EmployeeId",GXType.Int64,10,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV61Workhourlogbyemployeeds_3_tfworkhourlogid",GXType.Int64,10,0) ,
          new ParDef("AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to",GXType.Int64,10,0) ,
          new ParDef("AV63Workhourlogbyemployeeds_5_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV65Workhourlogbyemployeeds_7_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("AV67Workhourlogbyemployeeds_9_tfworkhourloghour",GXType.Int16,4,0) ,
          new ParDef("AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to",GXType.Int16,4,0) ,
          new ParDef("AV69Workhourlogbyemployeeds_11_tfworkhourlogminute",GXType.Int16,4,0) ,
          new ParDef("AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to",GXType.Int16,4,0) ,
          new ParDef("lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV73Workhourlogbyemployeeds_15_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV74Workhourlogbyemployeeds_16_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV75Workhourlogbyemployeeds_17_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("AV77Workhourlogbyemployeeds_19_tfprojectid",GXType.Int64,10,0) ,
          new ParDef("AV78Workhourlogbyemployeeds_20_tfprojectid_to",GXType.Int64,10,0) ,
          new ParDef("lV79Workhourlogbyemployeeds_21_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV80Workhourlogbyemployeeds_22_tfprojectname_sel",GXType.Char,100,0)
          };
          Object[] prmP00995;
          prmP00995 = new Object[] {
          new ParDef("AV59Workhourlogbyemployeeds_1_employeeid",GXType.Int64,10,0) ,
          new ParDef("AV90Udparg26",GXType.Int64,10,0) ,
          new ParDef("AV54EmployeeId",GXType.Int64,10,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Workhourlogbyemployeeds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV61Workhourlogbyemployeeds_3_tfworkhourlogid",GXType.Int64,10,0) ,
          new ParDef("AV62Workhourlogbyemployeeds_4_tfworkhourlogid_to",GXType.Int64,10,0) ,
          new ParDef("AV63Workhourlogbyemployeeds_5_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV64Workhourlogbyemployeeds_6_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV65Workhourlogbyemployeeds_7_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV66Workhourlogbyemployeeds_8_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("AV67Workhourlogbyemployeeds_9_tfworkhourloghour",GXType.Int16,4,0) ,
          new ParDef("AV68Workhourlogbyemployeeds_10_tfworkhourloghour_to",GXType.Int16,4,0) ,
          new ParDef("AV69Workhourlogbyemployeeds_11_tfworkhourlogminute",GXType.Int16,4,0) ,
          new ParDef("AV70Workhourlogbyemployeeds_12_tfworkhourlogminute_to",GXType.Int16,4,0) ,
          new ParDef("lV71Workhourlogbyemployeeds_13_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV72Workhourlogbyemployeeds_14_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV73Workhourlogbyemployeeds_15_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV74Workhourlogbyemployeeds_16_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV75Workhourlogbyemployeeds_17_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV76Workhourlogbyemployeeds_18_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("AV77Workhourlogbyemployeeds_19_tfprojectid",GXType.Int64,10,0) ,
          new ParDef("AV78Workhourlogbyemployeeds_20_tfprojectid_to",GXType.Int64,10,0) ,
          new ParDef("lV79Workhourlogbyemployeeds_21_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV80Workhourlogbyemployeeds_22_tfprojectname_sel",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00992", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00992,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00993", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00993,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00994", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00994,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00995", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00995,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                return;
       }
    }

 }

}
