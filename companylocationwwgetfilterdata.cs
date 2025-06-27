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
   public class companylocationwwgetfilterdata : GXProcedure
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
            return "companylocationww_Services_Execute" ;
         }

      }

      public companylocationwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public companylocationwwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_COMPANYLOCATIONNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMPANYLOCATIONNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_COMPANYLOCATIONCODE") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMPANYLOCATIONCODEOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV28Session.Get("CompanyLocationWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "CompanyLocationWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("CompanyLocationWWGridState"), null, "", "");
         }
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV40GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCOMPANYLOCATIONNAME") == 0 )
            {
               AV13TFCompanyLocationName = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCOMPANYLOCATIONNAME_SEL") == 0 )
            {
               AV14TFCompanyLocationName_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCOMPANYLOCATIONCODE") == 0 )
            {
               AV15TFCompanyLocationCode = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCOMPANYLOCATIONCODE_SEL") == 0 )
            {
               AV16TFCompanyLocationCode_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV40GXV1 = (int)(AV40GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMPANYLOCATIONNAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFCompanyLocationName = AV17SearchTxt;
         AV14TFCompanyLocationName_Sel = "";
         AV42Companylocationwwds_1_filterfulltext = AV39FilterFullText;
         AV43Companylocationwwds_2_tfcompanylocationname = AV13TFCompanyLocationName;
         AV44Companylocationwwds_3_tfcompanylocationname_sel = AV14TFCompanyLocationName_Sel;
         AV45Companylocationwwds_4_tfcompanylocationcode = AV15TFCompanyLocationCode;
         AV46Companylocationwwds_5_tfcompanylocationcode_sel = AV16TFCompanyLocationCode_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV42Companylocationwwds_1_filterfulltext ,
                                              AV44Companylocationwwds_3_tfcompanylocationname_sel ,
                                              AV43Companylocationwwds_2_tfcompanylocationname ,
                                              AV46Companylocationwwds_5_tfcompanylocationcode_sel ,
                                              AV45Companylocationwwds_4_tfcompanylocationcode ,
                                              A158CompanyLocationName ,
                                              A159CompanyLocationCode } ,
                                              new int[]{
                                              }
         });
         lV42Companylocationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Companylocationwwds_1_filterfulltext), "%", "");
         lV42Companylocationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Companylocationwwds_1_filterfulltext), "%", "");
         lV43Companylocationwwds_2_tfcompanylocationname = StringUtil.PadR( StringUtil.RTrim( AV43Companylocationwwds_2_tfcompanylocationname), 100, "%");
         lV45Companylocationwwds_4_tfcompanylocationcode = StringUtil.PadR( StringUtil.RTrim( AV45Companylocationwwds_4_tfcompanylocationcode), 20, "%");
         /* Using cursor P008Q2 */
         pr_default.execute(0, new Object[] {lV42Companylocationwwds_1_filterfulltext, lV42Companylocationwwds_1_filterfulltext, lV43Companylocationwwds_2_tfcompanylocationname, AV44Companylocationwwds_3_tfcompanylocationname_sel, lV45Companylocationwwds_4_tfcompanylocationcode, AV46Companylocationwwds_5_tfcompanylocationcode_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK8Q2 = false;
            A158CompanyLocationName = P008Q2_A158CompanyLocationName[0];
            A159CompanyLocationCode = P008Q2_A159CompanyLocationCode[0];
            A157CompanyLocationId = P008Q2_A157CompanyLocationId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P008Q2_A158CompanyLocationName[0], A158CompanyLocationName) == 0 ) )
            {
               BRK8Q2 = false;
               A157CompanyLocationId = P008Q2_A157CompanyLocationId[0];
               AV27count = (long)(AV27count+1);
               BRK8Q2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A158CompanyLocationName)) ? "<#Empty#>" : A158CompanyLocationName);
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
            if ( ! BRK8Q2 )
            {
               BRK8Q2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCOMPANYLOCATIONCODEOPTIONS' Routine */
         returnInSub = false;
         AV15TFCompanyLocationCode = AV17SearchTxt;
         AV16TFCompanyLocationCode_Sel = "";
         AV42Companylocationwwds_1_filterfulltext = AV39FilterFullText;
         AV43Companylocationwwds_2_tfcompanylocationname = AV13TFCompanyLocationName;
         AV44Companylocationwwds_3_tfcompanylocationname_sel = AV14TFCompanyLocationName_Sel;
         AV45Companylocationwwds_4_tfcompanylocationcode = AV15TFCompanyLocationCode;
         AV46Companylocationwwds_5_tfcompanylocationcode_sel = AV16TFCompanyLocationCode_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV42Companylocationwwds_1_filterfulltext ,
                                              AV44Companylocationwwds_3_tfcompanylocationname_sel ,
                                              AV43Companylocationwwds_2_tfcompanylocationname ,
                                              AV46Companylocationwwds_5_tfcompanylocationcode_sel ,
                                              AV45Companylocationwwds_4_tfcompanylocationcode ,
                                              A158CompanyLocationName ,
                                              A159CompanyLocationCode } ,
                                              new int[]{
                                              }
         });
         lV42Companylocationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Companylocationwwds_1_filterfulltext), "%", "");
         lV42Companylocationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Companylocationwwds_1_filterfulltext), "%", "");
         lV43Companylocationwwds_2_tfcompanylocationname = StringUtil.PadR( StringUtil.RTrim( AV43Companylocationwwds_2_tfcompanylocationname), 100, "%");
         lV45Companylocationwwds_4_tfcompanylocationcode = StringUtil.PadR( StringUtil.RTrim( AV45Companylocationwwds_4_tfcompanylocationcode), 20, "%");
         /* Using cursor P008Q3 */
         pr_default.execute(1, new Object[] {lV42Companylocationwwds_1_filterfulltext, lV42Companylocationwwds_1_filterfulltext, lV43Companylocationwwds_2_tfcompanylocationname, AV44Companylocationwwds_3_tfcompanylocationname_sel, lV45Companylocationwwds_4_tfcompanylocationcode, AV46Companylocationwwds_5_tfcompanylocationcode_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK8Q4 = false;
            A159CompanyLocationCode = P008Q3_A159CompanyLocationCode[0];
            A158CompanyLocationName = P008Q3_A158CompanyLocationName[0];
            A157CompanyLocationId = P008Q3_A157CompanyLocationId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P008Q3_A159CompanyLocationCode[0], A159CompanyLocationCode) == 0 ) )
            {
               BRK8Q4 = false;
               A157CompanyLocationId = P008Q3_A157CompanyLocationId[0];
               AV27count = (long)(AV27count+1);
               BRK8Q4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A159CompanyLocationCode)) ? "<#Empty#>" : A159CompanyLocationCode);
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
            if ( ! BRK8Q4 )
            {
               BRK8Q4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV39FilterFullText = "";
         AV13TFCompanyLocationName = "";
         AV14TFCompanyLocationName_Sel = "";
         AV15TFCompanyLocationCode = "";
         AV16TFCompanyLocationCode_Sel = "";
         AV42Companylocationwwds_1_filterfulltext = "";
         AV43Companylocationwwds_2_tfcompanylocationname = "";
         AV44Companylocationwwds_3_tfcompanylocationname_sel = "";
         AV45Companylocationwwds_4_tfcompanylocationcode = "";
         AV46Companylocationwwds_5_tfcompanylocationcode_sel = "";
         lV42Companylocationwwds_1_filterfulltext = "";
         lV43Companylocationwwds_2_tfcompanylocationname = "";
         lV45Companylocationwwds_4_tfcompanylocationcode = "";
         A158CompanyLocationName = "";
         A159CompanyLocationCode = "";
         P008Q2_A158CompanyLocationName = new string[] {""} ;
         P008Q2_A159CompanyLocationCode = new string[] {""} ;
         P008Q2_A157CompanyLocationId = new long[1] ;
         AV22Option = "";
         P008Q3_A159CompanyLocationCode = new string[] {""} ;
         P008Q3_A158CompanyLocationName = new string[] {""} ;
         P008Q3_A157CompanyLocationId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.companylocationwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P008Q2_A158CompanyLocationName, P008Q2_A159CompanyLocationCode, P008Q2_A157CompanyLocationId
               }
               , new Object[] {
               P008Q3_A159CompanyLocationCode, P008Q3_A158CompanyLocationName, P008Q3_A157CompanyLocationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private int AV40GXV1 ;
      private long A157CompanyLocationId ;
      private long AV27count ;
      private string AV13TFCompanyLocationName ;
      private string AV14TFCompanyLocationName_Sel ;
      private string AV15TFCompanyLocationCode ;
      private string AV16TFCompanyLocationCode_Sel ;
      private string AV43Companylocationwwds_2_tfcompanylocationname ;
      private string AV44Companylocationwwds_3_tfcompanylocationname_sel ;
      private string AV45Companylocationwwds_4_tfcompanylocationcode ;
      private string AV46Companylocationwwds_5_tfcompanylocationcode_sel ;
      private string lV43Companylocationwwds_2_tfcompanylocationname ;
      private string lV45Companylocationwwds_4_tfcompanylocationcode ;
      private string A158CompanyLocationName ;
      private string A159CompanyLocationCode ;
      private bool returnInSub ;
      private bool BRK8Q2 ;
      private bool BRK8Q4 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV42Companylocationwwds_1_filterfulltext ;
      private string lV42Companylocationwwds_1_filterfulltext ;
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
      private string[] P008Q2_A158CompanyLocationName ;
      private string[] P008Q2_A159CompanyLocationCode ;
      private long[] P008Q2_A157CompanyLocationId ;
      private string[] P008Q3_A159CompanyLocationCode ;
      private string[] P008Q3_A158CompanyLocationName ;
      private long[] P008Q3_A157CompanyLocationId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class companylocationwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008Q2( IGxContext context ,
                                             string AV42Companylocationwwds_1_filterfulltext ,
                                             string AV44Companylocationwwds_3_tfcompanylocationname_sel ,
                                             string AV43Companylocationwwds_2_tfcompanylocationname ,
                                             string AV46Companylocationwwds_5_tfcompanylocationcode_sel ,
                                             string AV45Companylocationwwds_4_tfcompanylocationcode ,
                                             string A158CompanyLocationName ,
                                             string A159CompanyLocationCode )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT CompanyLocationName, CompanyLocationCode, CompanyLocationId FROM CompanyLocation";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Companylocationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CompanyLocationName like '%' || :lV42Companylocationwwds_1_filterfulltext) or ( CompanyLocationCode like '%' || :lV42Companylocationwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Companylocationwwds_3_tfcompanylocationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Companylocationwwds_2_tfcompanylocationname)) ) )
         {
            AddWhere(sWhereString, "(CompanyLocationName like :lV43Companylocationwwds_2_tfcompanylocationname)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Companylocationwwds_3_tfcompanylocationname_sel)) && ! ( StringUtil.StrCmp(AV44Companylocationwwds_3_tfcompanylocationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CompanyLocationName = ( :AV44Companylocationwwds_3_tfcompanylocationname_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV44Companylocationwwds_3_tfcompanylocationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CompanyLocationName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Companylocationwwds_5_tfcompanylocationcode_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Companylocationwwds_4_tfcompanylocationcode)) ) )
         {
            AddWhere(sWhereString, "(CompanyLocationCode like :lV45Companylocationwwds_4_tfcompanylocationcode)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Companylocationwwds_5_tfcompanylocationcode_sel)) && ! ( StringUtil.StrCmp(AV46Companylocationwwds_5_tfcompanylocationcode_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CompanyLocationCode = ( :AV46Companylocationwwds_5_tfcompanylocationcode_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV46Companylocationwwds_5_tfcompanylocationcode_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CompanyLocationCode))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CompanyLocationName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008Q3( IGxContext context ,
                                             string AV42Companylocationwwds_1_filterfulltext ,
                                             string AV44Companylocationwwds_3_tfcompanylocationname_sel ,
                                             string AV43Companylocationwwds_2_tfcompanylocationname ,
                                             string AV46Companylocationwwds_5_tfcompanylocationcode_sel ,
                                             string AV45Companylocationwwds_4_tfcompanylocationcode ,
                                             string A158CompanyLocationName ,
                                             string A159CompanyLocationCode )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT CompanyLocationCode, CompanyLocationName, CompanyLocationId FROM CompanyLocation";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Companylocationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CompanyLocationName like '%' || :lV42Companylocationwwds_1_filterfulltext) or ( CompanyLocationCode like '%' || :lV42Companylocationwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Companylocationwwds_3_tfcompanylocationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Companylocationwwds_2_tfcompanylocationname)) ) )
         {
            AddWhere(sWhereString, "(CompanyLocationName like :lV43Companylocationwwds_2_tfcompanylocationname)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Companylocationwwds_3_tfcompanylocationname_sel)) && ! ( StringUtil.StrCmp(AV44Companylocationwwds_3_tfcompanylocationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CompanyLocationName = ( :AV44Companylocationwwds_3_tfcompanylocationname_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV44Companylocationwwds_3_tfcompanylocationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CompanyLocationName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Companylocationwwds_5_tfcompanylocationcode_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Companylocationwwds_4_tfcompanylocationcode)) ) )
         {
            AddWhere(sWhereString, "(CompanyLocationCode like :lV45Companylocationwwds_4_tfcompanylocationcode)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Companylocationwwds_5_tfcompanylocationcode_sel)) && ! ( StringUtil.StrCmp(AV46Companylocationwwds_5_tfcompanylocationcode_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CompanyLocationCode = ( :AV46Companylocationwwds_5_tfcompanylocationcode_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV46Companylocationwwds_5_tfcompanylocationcode_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CompanyLocationCode))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CompanyLocationCode";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P008Q2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
               case 1 :
                     return conditional_P008Q3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008Q2;
          prmP008Q2 = new Object[] {
          new ParDef("lV42Companylocationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Companylocationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Companylocationwwds_2_tfcompanylocationname",GXType.Char,100,0) ,
          new ParDef("AV44Companylocationwwds_3_tfcompanylocationname_sel",GXType.Char,100,0) ,
          new ParDef("lV45Companylocationwwds_4_tfcompanylocationcode",GXType.Char,20,0) ,
          new ParDef("AV46Companylocationwwds_5_tfcompanylocationcode_sel",GXType.Char,20,0)
          };
          Object[] prmP008Q3;
          prmP008Q3 = new Object[] {
          new ParDef("lV42Companylocationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Companylocationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Companylocationwwds_2_tfcompanylocationname",GXType.Char,100,0) ,
          new ParDef("AV44Companylocationwwds_3_tfcompanylocationname_sel",GXType.Char,100,0) ,
          new ParDef("lV45Companylocationwwds_4_tfcompanylocationcode",GXType.Char,20,0) ,
          new ParDef("AV46Companylocationwwds_5_tfcompanylocationcode_sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Q2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008Q3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Q3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
