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
namespace GeneXus.Programs.workwithplus {
   public class wwp_parameterwwgetfilterdata : GXProcedure
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
            return "wwp_parameterww_Services_Execute" ;
         }

      }

      public wwp_parameterwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_parameterwwgetfilterdata( IGxContext context )
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
         this.AV34DDOName = aP0_DDOName;
         this.AV35SearchTxtParms = aP1_SearchTxtParms;
         this.AV36SearchTxtTo = aP2_SearchTxtTo;
         this.AV37OptionsJson = "" ;
         this.AV38OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV37OptionsJson;
         aP4_OptionsDescJson=this.AV38OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV39OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV34DDOName = aP0_DDOName;
         this.AV35SearchTxtParms = aP1_SearchTxtParms;
         this.AV36SearchTxtTo = aP2_SearchTxtTo;
         this.AV37OptionsJson = "" ;
         this.AV38OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV37OptionsJson;
         aP4_OptionsDescJson=this.AV38OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV24Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV21MaxItems = 10;
         AV20PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV35SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV35SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV18SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV35SearchTxtParms)) ? "" : StringUtil.Substring( AV35SearchTxtParms, 3, -1));
         AV19SkipItems = (short)(AV20PageIndex*AV21MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_WWPPARAMETERKEY") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPPARAMETERKEYOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_WWPPARAMETERCATEGORY") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPPARAMETERCATEGORYOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_WWPPARAMETERDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPPARAMETERDESCRIPTIONOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_WWPPARAMETERVALUETRIMMED") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPPARAMETERVALUETRIMMEDOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV37OptionsJson = AV24Options.ToJSonString(false);
         AV38OptionsDescJson = AV26OptionsDesc.ToJSonString(false);
         AV39OptionIndexesJson = AV27OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV29Session.Get("WorkWithPlus.WWP_ParameterWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WorkWithPlus.WWP_ParameterWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("WorkWithPlus.WWP_ParameterWWGridState"), null, "", "");
         }
         AV41GXV1 = 1;
         while ( AV41GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV41GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV40FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERKEY") == 0 )
            {
               AV10TFWWPParameterKey = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERKEY_SEL") == 0 )
            {
               AV11TFWWPParameterKey_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERCATEGORY") == 0 )
            {
               AV12TFWWPParameterCategory = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERCATEGORY_SEL") == 0 )
            {
               AV13TFWWPParameterCategory_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERDESCRIPTION") == 0 )
            {
               AV14TFWWPParameterDescription = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERDESCRIPTION_SEL") == 0 )
            {
               AV15TFWWPParameterDescription_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERVALUETRIMMED") == 0 )
            {
               AV16TFWWPParameterValueTrimmed = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERVALUETRIMMED_SEL") == 0 )
            {
               AV17TFWWPParameterValueTrimmed_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            AV41GXV1 = (int)(AV41GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADWWPPARAMETERKEYOPTIONS' Routine */
         returnInSub = false;
         AV10TFWWPParameterKey = AV18SearchTxt;
         AV11TFWWPParameterKey_Sel = "";
         AV43Workwithplus_wwp_parameterwwds_1_filterfulltext = AV40FilterFullText;
         AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV10TFWWPParameterKey;
         AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV11TFWWPParameterKey_Sel;
         AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV12TFWWPParameterCategory;
         AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV13TFWWPParameterCategory_Sel;
         AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV14TFWWPParameterDescription;
         AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV15TFWWPParameterDescription_Sel;
         AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV16TFWWPParameterValueTrimmed;
         AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV17TFWWPParameterValueTrimmed_Sel;
         GXPagingFrom2 = AV19SkipItems;
         GXPagingTo2 = AV21MaxItems;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV43Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                              AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                              AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                              AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                              AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                              AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                              AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                              AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                              AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                              A1WWPParameterKey ,
                                              A3WWPParameterCategory ,
                                              A4WWPParameterDescription ,
                                              A2WWPParameterValue } ,
                                              new int[]{
                                              }
         });
         lV43Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV43Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV43Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV43Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = StringUtil.Concat( StringUtil.RTrim( AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey), "%", "");
         lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = StringUtil.Concat( StringUtil.RTrim( AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory), "%", "");
         lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = StringUtil.Concat( StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription), "%", "");
         lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = StringUtil.Concat( StringUtil.RTrim( AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed), "%", "");
         /* Using cursor P00292 */
         pr_default.execute(0, new Object[] {lV43Workwithplus_wwp_parameterwwds_1_filterfulltext, lV43Workwithplus_wwp_parameterwwds_1_filterfulltext, lV43Workwithplus_wwp_parameterwwds_1_filterfulltext, lV43Workwithplus_wwp_parameterwwds_1_filterfulltext, lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey, AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory, AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription, AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed, AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4WWPParameterDescription = P00292_A4WWPParameterDescription[0];
            A3WWPParameterCategory = P00292_A3WWPParameterCategory[0];
            A1WWPParameterKey = P00292_A1WWPParameterKey[0];
            A2WWPParameterValue = P00292_A2WWPParameterValue[0];
            if ( StringUtil.Len( A2WWPParameterValue) <= 30 )
            {
               A6WWPParameterValueTrimmed = A2WWPParameterValue;
            }
            else
            {
               A6WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A2WWPParameterValue, 1, 27)) + "...";
            }
            AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A1WWPParameterKey)) ? "<#Empty#>" : A1WWPParameterKey);
            AV24Options.Add(AV23Option, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADWWPPARAMETERCATEGORYOPTIONS' Routine */
         returnInSub = false;
         AV12TFWWPParameterCategory = AV18SearchTxt;
         AV13TFWWPParameterCategory_Sel = "";
         AV43Workwithplus_wwp_parameterwwds_1_filterfulltext = AV40FilterFullText;
         AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV10TFWWPParameterKey;
         AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV11TFWWPParameterKey_Sel;
         AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV12TFWWPParameterCategory;
         AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV13TFWWPParameterCategory_Sel;
         AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV14TFWWPParameterDescription;
         AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV15TFWWPParameterDescription_Sel;
         AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV16TFWWPParameterValueTrimmed;
         AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV17TFWWPParameterValueTrimmed_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV43Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                              AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                              AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                              AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                              AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                              AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                              AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                              AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                              AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                              A1WWPParameterKey ,
                                              A3WWPParameterCategory ,
                                              A4WWPParameterDescription ,
                                              A2WWPParameterValue } ,
                                              new int[]{
                                              }
         });
         lV43Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV43Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV43Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV43Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = StringUtil.Concat( StringUtil.RTrim( AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey), "%", "");
         lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = StringUtil.Concat( StringUtil.RTrim( AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory), "%", "");
         lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = StringUtil.Concat( StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription), "%", "");
         lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = StringUtil.Concat( StringUtil.RTrim( AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed), "%", "");
         /* Using cursor P00293 */
         pr_default.execute(1, new Object[] {lV43Workwithplus_wwp_parameterwwds_1_filterfulltext, lV43Workwithplus_wwp_parameterwwds_1_filterfulltext, lV43Workwithplus_wwp_parameterwwds_1_filterfulltext, lV43Workwithplus_wwp_parameterwwds_1_filterfulltext, lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey, AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory, AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription, AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed, AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK293 = false;
            A3WWPParameterCategory = P00293_A3WWPParameterCategory[0];
            A4WWPParameterDescription = P00293_A4WWPParameterDescription[0];
            A1WWPParameterKey = P00293_A1WWPParameterKey[0];
            A2WWPParameterValue = P00293_A2WWPParameterValue[0];
            if ( StringUtil.Len( A2WWPParameterValue) <= 30 )
            {
               A6WWPParameterValueTrimmed = A2WWPParameterValue;
            }
            else
            {
               A6WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A2WWPParameterValue, 1, 27)) + "...";
            }
            AV28count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00293_A3WWPParameterCategory[0], A3WWPParameterCategory) == 0 ) )
            {
               BRK293 = false;
               A1WWPParameterKey = P00293_A1WWPParameterKey[0];
               AV28count = (long)(AV28count+1);
               BRK293 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A3WWPParameterCategory)) ? "<#Empty#>" : A3WWPParameterCategory);
               AV24Options.Add(AV23Option, 0);
               AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV24Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV19SkipItems = (short)(AV19SkipItems-1);
            }
            if ( ! BRK293 )
            {
               BRK293 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADWWPPARAMETERDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV14TFWWPParameterDescription = AV18SearchTxt;
         AV15TFWWPParameterDescription_Sel = "";
         AV43Workwithplus_wwp_parameterwwds_1_filterfulltext = AV40FilterFullText;
         AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV10TFWWPParameterKey;
         AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV11TFWWPParameterKey_Sel;
         AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV12TFWWPParameterCategory;
         AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV13TFWWPParameterCategory_Sel;
         AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV14TFWWPParameterDescription;
         AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV15TFWWPParameterDescription_Sel;
         AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV16TFWWPParameterValueTrimmed;
         AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV17TFWWPParameterValueTrimmed_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV43Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                              AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                              AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                              AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                              AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                              AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                              AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                              AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                              AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                              A1WWPParameterKey ,
                                              A3WWPParameterCategory ,
                                              A4WWPParameterDescription ,
                                              A2WWPParameterValue } ,
                                              new int[]{
                                              }
         });
         lV43Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV43Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV43Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV43Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = StringUtil.Concat( StringUtil.RTrim( AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey), "%", "");
         lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = StringUtil.Concat( StringUtil.RTrim( AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory), "%", "");
         lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = StringUtil.Concat( StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription), "%", "");
         lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = StringUtil.Concat( StringUtil.RTrim( AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed), "%", "");
         /* Using cursor P00294 */
         pr_default.execute(2, new Object[] {lV43Workwithplus_wwp_parameterwwds_1_filterfulltext, lV43Workwithplus_wwp_parameterwwds_1_filterfulltext, lV43Workwithplus_wwp_parameterwwds_1_filterfulltext, lV43Workwithplus_wwp_parameterwwds_1_filterfulltext, lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey, AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory, AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription, AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed, AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK295 = false;
            A4WWPParameterDescription = P00294_A4WWPParameterDescription[0];
            A3WWPParameterCategory = P00294_A3WWPParameterCategory[0];
            A1WWPParameterKey = P00294_A1WWPParameterKey[0];
            A2WWPParameterValue = P00294_A2WWPParameterValue[0];
            if ( StringUtil.Len( A2WWPParameterValue) <= 30 )
            {
               A6WWPParameterValueTrimmed = A2WWPParameterValue;
            }
            else
            {
               A6WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A2WWPParameterValue, 1, 27)) + "...";
            }
            AV28count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00294_A4WWPParameterDescription[0], A4WWPParameterDescription) == 0 ) )
            {
               BRK295 = false;
               A1WWPParameterKey = P00294_A1WWPParameterKey[0];
               AV28count = (long)(AV28count+1);
               BRK295 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A4WWPParameterDescription)) ? "<#Empty#>" : A4WWPParameterDescription);
               AV24Options.Add(AV23Option, 0);
               AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV24Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV19SkipItems = (short)(AV19SkipItems-1);
            }
            if ( ! BRK295 )
            {
               BRK295 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADWWPPARAMETERVALUETRIMMEDOPTIONS' Routine */
         returnInSub = false;
         AV16TFWWPParameterValueTrimmed = AV18SearchTxt;
         AV17TFWWPParameterValueTrimmed_Sel = "";
         AV43Workwithplus_wwp_parameterwwds_1_filterfulltext = AV40FilterFullText;
         AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV10TFWWPParameterKey;
         AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV11TFWWPParameterKey_Sel;
         AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV12TFWWPParameterCategory;
         AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV13TFWWPParameterCategory_Sel;
         AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV14TFWWPParameterDescription;
         AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV15TFWWPParameterDescription_Sel;
         AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV16TFWWPParameterValueTrimmed;
         AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV17TFWWPParameterValueTrimmed_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV43Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                              AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                              AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                              AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                              AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                              AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                              AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                              AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                              AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                              A1WWPParameterKey ,
                                              A3WWPParameterCategory ,
                                              A4WWPParameterDescription ,
                                              A2WWPParameterValue } ,
                                              new int[]{
                                              }
         });
         lV43Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV43Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV43Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV43Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = StringUtil.Concat( StringUtil.RTrim( AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey), "%", "");
         lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = StringUtil.Concat( StringUtil.RTrim( AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory), "%", "");
         lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = StringUtil.Concat( StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription), "%", "");
         lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = StringUtil.Concat( StringUtil.RTrim( AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed), "%", "");
         /* Using cursor P00295 */
         pr_default.execute(3, new Object[] {lV43Workwithplus_wwp_parameterwwds_1_filterfulltext, lV43Workwithplus_wwp_parameterwwds_1_filterfulltext, lV43Workwithplus_wwp_parameterwwds_1_filterfulltext, lV43Workwithplus_wwp_parameterwwds_1_filterfulltext, lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey, AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory, AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription, AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed, AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A4WWPParameterDescription = P00295_A4WWPParameterDescription[0];
            A3WWPParameterCategory = P00295_A3WWPParameterCategory[0];
            A1WWPParameterKey = P00295_A1WWPParameterKey[0];
            A2WWPParameterValue = P00295_A2WWPParameterValue[0];
            if ( StringUtil.Len( A2WWPParameterValue) <= 30 )
            {
               A6WWPParameterValueTrimmed = A2WWPParameterValue;
            }
            else
            {
               A6WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A2WWPParameterValue, 1, 27)) + "...";
            }
            AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A6WWPParameterValueTrimmed)) ? "<#Empty#>" : A6WWPParameterValueTrimmed);
            AV22InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV23Option, "<#Empty#>") != 0 ) && ( AV22InsertIndex <= AV24Options.Count ) && ( ( StringUtil.StrCmp(((string)AV24Options.Item(AV22InsertIndex)), AV23Option) < 0 ) || ( StringUtil.StrCmp(((string)AV24Options.Item(AV22InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV22InsertIndex = (int)(AV22InsertIndex+1);
            }
            if ( ( AV22InsertIndex <= AV24Options.Count ) && ( StringUtil.StrCmp(((string)AV24Options.Item(AV22InsertIndex)), AV23Option) == 0 ) )
            {
               AV28count = (long)(Math.Round(NumberUtil.Val( ((string)AV27OptionIndexes.Item(AV22InsertIndex)), "."), 18, MidpointRounding.ToEven));
               AV28count = (long)(AV28count+1);
               AV27OptionIndexes.RemoveItem(AV22InsertIndex);
               AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), AV22InsertIndex);
            }
            else
            {
               AV24Options.Add(AV23Option, AV22InsertIndex);
               AV27OptionIndexes.Add("1", AV22InsertIndex);
            }
            if ( AV24Options.Count == AV19SkipItems + 11 )
            {
               AV24Options.RemoveItem(AV24Options.Count);
               AV27OptionIndexes.RemoveItem(AV27OptionIndexes.Count);
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         while ( AV19SkipItems > 0 )
         {
            AV24Options.RemoveItem(1);
            AV27OptionIndexes.RemoveItem(1);
            AV19SkipItems = (short)(AV19SkipItems-1);
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
         AV37OptionsJson = "";
         AV38OptionsDescJson = "";
         AV39OptionIndexesJson = "";
         AV24Options = new GxSimpleCollection<string>();
         AV26OptionsDesc = new GxSimpleCollection<string>();
         AV27OptionIndexes = new GxSimpleCollection<string>();
         AV18SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV29Session = context.GetSession();
         AV31GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV32GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV40FilterFullText = "";
         AV10TFWWPParameterKey = "";
         AV11TFWWPParameterKey_Sel = "";
         AV12TFWWPParameterCategory = "";
         AV13TFWWPParameterCategory_Sel = "";
         AV14TFWWPParameterDescription = "";
         AV15TFWWPParameterDescription_Sel = "";
         AV16TFWWPParameterValueTrimmed = "";
         AV17TFWWPParameterValueTrimmed_Sel = "";
         AV43Workwithplus_wwp_parameterwwds_1_filterfulltext = "";
         AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = "";
         AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = "";
         AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = "";
         AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = "";
         AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = "";
         AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = "";
         AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = "";
         AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = "";
         lV43Workwithplus_wwp_parameterwwds_1_filterfulltext = "";
         lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = "";
         lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = "";
         lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = "";
         lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = "";
         A1WWPParameterKey = "";
         A3WWPParameterCategory = "";
         A4WWPParameterDescription = "";
         A2WWPParameterValue = "";
         P00292_A4WWPParameterDescription = new string[] {""} ;
         P00292_A3WWPParameterCategory = new string[] {""} ;
         P00292_A1WWPParameterKey = new string[] {""} ;
         P00292_A2WWPParameterValue = new string[] {""} ;
         A6WWPParameterValueTrimmed = "";
         AV23Option = "";
         P00293_A3WWPParameterCategory = new string[] {""} ;
         P00293_A4WWPParameterDescription = new string[] {""} ;
         P00293_A1WWPParameterKey = new string[] {""} ;
         P00293_A2WWPParameterValue = new string[] {""} ;
         P00294_A4WWPParameterDescription = new string[] {""} ;
         P00294_A3WWPParameterCategory = new string[] {""} ;
         P00294_A1WWPParameterKey = new string[] {""} ;
         P00294_A2WWPParameterValue = new string[] {""} ;
         P00295_A4WWPParameterDescription = new string[] {""} ;
         P00295_A3WWPParameterCategory = new string[] {""} ;
         P00295_A1WWPParameterKey = new string[] {""} ;
         P00295_A2WWPParameterValue = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_parameterwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00292_A4WWPParameterDescription, P00292_A3WWPParameterCategory, P00292_A1WWPParameterKey, P00292_A2WWPParameterValue
               }
               , new Object[] {
               P00293_A3WWPParameterCategory, P00293_A4WWPParameterDescription, P00293_A1WWPParameterKey, P00293_A2WWPParameterValue
               }
               , new Object[] {
               P00294_A4WWPParameterDescription, P00294_A3WWPParameterCategory, P00294_A1WWPParameterKey, P00294_A2WWPParameterValue
               }
               , new Object[] {
               P00295_A4WWPParameterDescription, P00295_A3WWPParameterCategory, P00295_A1WWPParameterKey, P00295_A2WWPParameterValue
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21MaxItems ;
      private short AV20PageIndex ;
      private short AV19SkipItems ;
      private int AV41GXV1 ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV22InsertIndex ;
      private long AV28count ;
      private bool returnInSub ;
      private bool BRK293 ;
      private bool BRK295 ;
      private string AV37OptionsJson ;
      private string AV38OptionsDescJson ;
      private string AV39OptionIndexesJson ;
      private string A2WWPParameterValue ;
      private string AV34DDOName ;
      private string AV35SearchTxtParms ;
      private string AV36SearchTxtTo ;
      private string AV18SearchTxt ;
      private string AV40FilterFullText ;
      private string AV10TFWWPParameterKey ;
      private string AV11TFWWPParameterKey_Sel ;
      private string AV12TFWWPParameterCategory ;
      private string AV13TFWWPParameterCategory_Sel ;
      private string AV14TFWWPParameterDescription ;
      private string AV15TFWWPParameterDescription_Sel ;
      private string AV16TFWWPParameterValueTrimmed ;
      private string AV17TFWWPParameterValueTrimmed_Sel ;
      private string AV43Workwithplus_wwp_parameterwwds_1_filterfulltext ;
      private string AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ;
      private string AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ;
      private string AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ;
      private string AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ;
      private string AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ;
      private string AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ;
      private string AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ;
      private string AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ;
      private string lV43Workwithplus_wwp_parameterwwds_1_filterfulltext ;
      private string lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ;
      private string lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ;
      private string lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ;
      private string lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ;
      private string A1WWPParameterKey ;
      private string A3WWPParameterCategory ;
      private string A4WWPParameterDescription ;
      private string A6WWPParameterValueTrimmed ;
      private string AV23Option ;
      private IGxSession AV29Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV24Options ;
      private GxSimpleCollection<string> AV26OptionsDesc ;
      private GxSimpleCollection<string> AV27OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV31GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00292_A4WWPParameterDescription ;
      private string[] P00292_A3WWPParameterCategory ;
      private string[] P00292_A1WWPParameterKey ;
      private string[] P00292_A2WWPParameterValue ;
      private string[] P00293_A3WWPParameterCategory ;
      private string[] P00293_A4WWPParameterDescription ;
      private string[] P00293_A1WWPParameterKey ;
      private string[] P00293_A2WWPParameterValue ;
      private string[] P00294_A4WWPParameterDescription ;
      private string[] P00294_A3WWPParameterCategory ;
      private string[] P00294_A1WWPParameterKey ;
      private string[] P00294_A2WWPParameterValue ;
      private string[] P00295_A4WWPParameterDescription ;
      private string[] P00295_A3WWPParameterCategory ;
      private string[] P00295_A1WWPParameterKey ;
      private string[] P00295_A2WWPParameterValue ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wwp_parameterwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00292( IGxContext context ,
                                             string AV43Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                             string AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                             string AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                             string AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                             string AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                             string AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                             string AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                             string AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                             string AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                             string A1WWPParameterKey ,
                                             string A3WWPParameterCategory ,
                                             string A4WWPParameterDescription ,
                                             string A2WWPParameterValue )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[15];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " DISTINCT NULL AS WWPParameterDescription, NULL AS WWPParameterCategory, WWPParameterKey, NULL AS WWPParameterValue FROM ( SELECT WWPParameterDescription, WWPParameterCategory, WWPParameterKey, WWPParameterValue";
         sFromString = " FROM WWP_Parameter";
         sOrderString = "";
         string sOrderStringT;
         sOrderStringT = " ORDER BY WWPParameterKey";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( WWPParameterKey like '%' || :lV43Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( WWPParameterCategory like '%' || :lV43Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( WWPParameterDescription like '%' || :lV43Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like '%' || :lV43Workwithplus_wwp_parameterwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey like :lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ! ( StringUtil.StrCmp(AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey = ( :AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory like :lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ! ( StringUtil.StrCmp(AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory = ( :AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterCategory))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription like :lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ! ( StringUtil.StrCmp(AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription = ( :AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)) ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like :lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ! ( StringUtil.StrCmp(AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) = ( :AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END)))=0))");
         }
         sOrderString += " ORDER BY WWPParameterKey";
         sOrderStringT = " ORDER BY WWPParameterKey";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + ") DistinctT" + sOrderStringT + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00293( IGxContext context ,
                                             string AV43Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                             string AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                             string AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                             string AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                             string AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                             string AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                             string AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                             string AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                             string AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                             string A1WWPParameterKey ,
                                             string A3WWPParameterCategory ,
                                             string A4WWPParameterDescription ,
                                             string A2WWPParameterValue )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT WWPParameterCategory, WWPParameterDescription, WWPParameterKey, WWPParameterValue FROM WWP_Parameter";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( WWPParameterKey like '%' || :lV43Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( WWPParameterCategory like '%' || :lV43Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( WWPParameterDescription like '%' || :lV43Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like '%' || :lV43Workwithplus_wwp_parameterwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey like :lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ! ( StringUtil.StrCmp(AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey = ( :AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory like :lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ! ( StringUtil.StrCmp(AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory = ( :AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterCategory))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription like :lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ! ( StringUtil.StrCmp(AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription = ( :AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)) ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like :lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ! ( StringUtil.StrCmp(AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) = ( :AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END)))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPParameterCategory";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00294( IGxContext context ,
                                             string AV43Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                             string AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                             string AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                             string AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                             string AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                             string AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                             string AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                             string AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                             string AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                             string A1WWPParameterKey ,
                                             string A3WWPParameterCategory ,
                                             string A4WWPParameterDescription ,
                                             string A2WWPParameterValue )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[12];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT WWPParameterDescription, WWPParameterCategory, WWPParameterKey, WWPParameterValue FROM WWP_Parameter";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( WWPParameterKey like '%' || :lV43Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( WWPParameterCategory like '%' || :lV43Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( WWPParameterDescription like '%' || :lV43Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like '%' || :lV43Workwithplus_wwp_parameterwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey like :lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ! ( StringUtil.StrCmp(AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey = ( :AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory like :lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ! ( StringUtil.StrCmp(AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory = ( :AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterCategory))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription like :lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ! ( StringUtil.StrCmp(AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription = ( :AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)) ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like :lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ! ( StringUtil.StrCmp(AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) = ( :AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END)))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPParameterDescription";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00295( IGxContext context ,
                                             string AV43Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                             string AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                             string AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                             string AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                             string AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                             string AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                             string AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                             string AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                             string AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                             string A1WWPParameterKey ,
                                             string A3WWPParameterCategory ,
                                             string A4WWPParameterDescription ,
                                             string A2WWPParameterValue )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[12];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT WWPParameterDescription, WWPParameterCategory, WWPParameterKey, WWPParameterValue FROM WWP_Parameter";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Workwithplus_wwp_parameterwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( WWPParameterKey like '%' || :lV43Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( WWPParameterCategory like '%' || :lV43Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( WWPParameterDescription like '%' || :lV43Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like '%' || :lV43Workwithplus_wwp_parameterwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey like :lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ! ( StringUtil.StrCmp(AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey = ( :AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory like :lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ! ( StringUtil.StrCmp(AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory = ( :AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterCategory))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription like :lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ! ( StringUtil.StrCmp(AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription = ( :AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)) ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like :lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ! ( StringUtil.StrCmp(AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) = ( :AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END)))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPParameterKey";
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
                     return conditional_P00292(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 1 :
                     return conditional_P00293(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 2 :
                     return conditional_P00294(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 3 :
                     return conditional_P00295(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
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
          Object[] prmP00292;
          prmP00292 = new Object[] {
          new ParDef("lV43Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey",GXType.VarChar,300,0) ,
          new ParDef("AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel",GXType.VarChar,300,0) ,
          new ParDef("lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory",GXType.VarChar,200,0) ,
          new ParDef("AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel",GXType.VarChar,200,0) ,
          new ParDef("lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription",GXType.VarChar,200,0) ,
          new ParDef("AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_",GXType.VarChar,200,0) ,
          new ParDef("lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed",GXType.VarChar,30,0) ,
          new ParDef("AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed",GXType.VarChar,30,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP00293;
          prmP00293 = new Object[] {
          new ParDef("lV43Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey",GXType.VarChar,300,0) ,
          new ParDef("AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel",GXType.VarChar,300,0) ,
          new ParDef("lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory",GXType.VarChar,200,0) ,
          new ParDef("AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel",GXType.VarChar,200,0) ,
          new ParDef("lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription",GXType.VarChar,200,0) ,
          new ParDef("AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_",GXType.VarChar,200,0) ,
          new ParDef("lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed",GXType.VarChar,30,0) ,
          new ParDef("AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed",GXType.VarChar,30,0)
          };
          Object[] prmP00294;
          prmP00294 = new Object[] {
          new ParDef("lV43Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey",GXType.VarChar,300,0) ,
          new ParDef("AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel",GXType.VarChar,300,0) ,
          new ParDef("lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory",GXType.VarChar,200,0) ,
          new ParDef("AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel",GXType.VarChar,200,0) ,
          new ParDef("lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription",GXType.VarChar,200,0) ,
          new ParDef("AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_",GXType.VarChar,200,0) ,
          new ParDef("lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed",GXType.VarChar,30,0) ,
          new ParDef("AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed",GXType.VarChar,30,0)
          };
          Object[] prmP00295;
          prmP00295 = new Object[] {
          new ParDef("lV43Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey",GXType.VarChar,300,0) ,
          new ParDef("AV45Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel",GXType.VarChar,300,0) ,
          new ParDef("lV46Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory",GXType.VarChar,200,0) ,
          new ParDef("AV47Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel",GXType.VarChar,200,0) ,
          new ParDef("lV48Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription",GXType.VarChar,200,0) ,
          new ParDef("AV49Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_",GXType.VarChar,200,0) ,
          new ParDef("lV50Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed",GXType.VarChar,30,0) ,
          new ParDef("AV51Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed",GXType.VarChar,30,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00292", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00292,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00293", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00293,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00294", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00294,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00295", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00295,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                return;
       }
    }

 }

}
