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
   public class companywwgetfilterdata : GXProcedure
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
            return "companyww_Services_Execute" ;
         }

      }

      public companywwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public companywwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_COMPANYNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMPANYNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_COMPANYLOCATIONNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMPANYLOCATIONNAMEOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV30Session.Get("CompanyWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "CompanyWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("CompanyWWGridState"), null, "", "");
         }
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV44GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMPANYNAME") == 0 )
            {
               AV13TFCompanyName = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMPANYNAME_SEL") == 0 )
            {
               AV14TFCompanyName_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMPANYLOCATIONNAME") == 0 )
            {
               AV42TFCompanyLocationName = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMPANYLOCATIONNAME_SEL") == 0 )
            {
               AV43TFCompanyLocationName_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV44GXV1 = (int)(AV44GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMPANYNAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFCompanyName = AV19SearchTxt;
         AV14TFCompanyName_Sel = "";
         AV46Companywwds_1_filterfulltext = AV41FilterFullText;
         AV47Companywwds_2_tfcompanyname = AV13TFCompanyName;
         AV48Companywwds_3_tfcompanyname_sel = AV14TFCompanyName_Sel;
         AV49Companywwds_4_tfcompanylocationname = AV42TFCompanyLocationName;
         AV50Companywwds_5_tfcompanylocationname_sel = AV43TFCompanyLocationName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV46Companywwds_1_filterfulltext ,
                                              AV48Companywwds_3_tfcompanyname_sel ,
                                              AV47Companywwds_2_tfcompanyname ,
                                              AV50Companywwds_5_tfcompanylocationname_sel ,
                                              AV49Companywwds_4_tfcompanylocationname ,
                                              A101CompanyName ,
                                              A158CompanyLocationName } ,
                                              new int[]{
                                              }
         });
         lV46Companywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Companywwds_1_filterfulltext), "%", "");
         lV46Companywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Companywwds_1_filterfulltext), "%", "");
         lV47Companywwds_2_tfcompanyname = StringUtil.PadR( StringUtil.RTrim( AV47Companywwds_2_tfcompanyname), 100, "%");
         lV49Companywwds_4_tfcompanylocationname = StringUtil.PadR( StringUtil.RTrim( AV49Companywwds_4_tfcompanylocationname), 100, "%");
         /* Using cursor P00692 */
         pr_default.execute(0, new Object[] {lV46Companywwds_1_filterfulltext, lV46Companywwds_1_filterfulltext, lV47Companywwds_2_tfcompanyname, AV48Companywwds_3_tfcompanyname_sel, lV49Companywwds_4_tfcompanylocationname, AV50Companywwds_5_tfcompanylocationname_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK692 = false;
            A157CompanyLocationId = P00692_A157CompanyLocationId[0];
            A101CompanyName = P00692_A101CompanyName[0];
            A158CompanyLocationName = P00692_A158CompanyLocationName[0];
            A100CompanyId = P00692_A100CompanyId[0];
            A158CompanyLocationName = P00692_A158CompanyLocationName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00692_A101CompanyName[0], A101CompanyName) == 0 ) )
            {
               BRK692 = false;
               A100CompanyId = P00692_A100CompanyId[0];
               AV29count = (long)(AV29count+1);
               BRK692 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A101CompanyName)) ? "<#Empty#>" : A101CompanyName);
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
            if ( ! BRK692 )
            {
               BRK692 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCOMPANYLOCATIONNAMEOPTIONS' Routine */
         returnInSub = false;
         AV42TFCompanyLocationName = AV19SearchTxt;
         AV43TFCompanyLocationName_Sel = "";
         AV46Companywwds_1_filterfulltext = AV41FilterFullText;
         AV47Companywwds_2_tfcompanyname = AV13TFCompanyName;
         AV48Companywwds_3_tfcompanyname_sel = AV14TFCompanyName_Sel;
         AV49Companywwds_4_tfcompanylocationname = AV42TFCompanyLocationName;
         AV50Companywwds_5_tfcompanylocationname_sel = AV43TFCompanyLocationName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV46Companywwds_1_filterfulltext ,
                                              AV48Companywwds_3_tfcompanyname_sel ,
                                              AV47Companywwds_2_tfcompanyname ,
                                              AV50Companywwds_5_tfcompanylocationname_sel ,
                                              AV49Companywwds_4_tfcompanylocationname ,
                                              A101CompanyName ,
                                              A158CompanyLocationName } ,
                                              new int[]{
                                              }
         });
         lV46Companywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Companywwds_1_filterfulltext), "%", "");
         lV46Companywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Companywwds_1_filterfulltext), "%", "");
         lV47Companywwds_2_tfcompanyname = StringUtil.PadR( StringUtil.RTrim( AV47Companywwds_2_tfcompanyname), 100, "%");
         lV49Companywwds_4_tfcompanylocationname = StringUtil.PadR( StringUtil.RTrim( AV49Companywwds_4_tfcompanylocationname), 100, "%");
         /* Using cursor P00693 */
         pr_default.execute(1, new Object[] {lV46Companywwds_1_filterfulltext, lV46Companywwds_1_filterfulltext, lV47Companywwds_2_tfcompanyname, AV48Companywwds_3_tfcompanyname_sel, lV49Companywwds_4_tfcompanylocationname, AV50Companywwds_5_tfcompanylocationname_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK694 = false;
            A157CompanyLocationId = P00693_A157CompanyLocationId[0];
            A158CompanyLocationName = P00693_A158CompanyLocationName[0];
            A101CompanyName = P00693_A101CompanyName[0];
            A100CompanyId = P00693_A100CompanyId[0];
            A158CompanyLocationName = P00693_A158CompanyLocationName[0];
            AV29count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00693_A157CompanyLocationId[0] == A157CompanyLocationId ) )
            {
               BRK694 = false;
               A100CompanyId = P00693_A100CompanyId[0];
               AV29count = (long)(AV29count+1);
               BRK694 = true;
               pr_default.readNext(1);
            }
            AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A158CompanyLocationName)) ? "<#Empty#>" : A158CompanyLocationName);
            AV23InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV24Option, "<#Empty#>") != 0 ) && ( AV23InsertIndex <= AV25Options.Count ) && ( ( StringUtil.StrCmp(((string)AV25Options.Item(AV23InsertIndex)), AV24Option) < 0 ) || ( StringUtil.StrCmp(((string)AV25Options.Item(AV23InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV23InsertIndex = (int)(AV23InsertIndex+1);
            }
            AV25Options.Add(AV24Option, AV23InsertIndex);
            AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), AV23InsertIndex);
            if ( AV25Options.Count == AV20SkipItems + 11 )
            {
               AV25Options.RemoveItem(AV25Options.Count);
               AV28OptionIndexes.RemoveItem(AV28OptionIndexes.Count);
            }
            if ( ! BRK694 )
            {
               BRK694 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV20SkipItems > 0 )
         {
            AV25Options.RemoveItem(1);
            AV28OptionIndexes.RemoveItem(1);
            AV20SkipItems = (short)(AV20SkipItems-1);
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
         AV13TFCompanyName = "";
         AV14TFCompanyName_Sel = "";
         AV42TFCompanyLocationName = "";
         AV43TFCompanyLocationName_Sel = "";
         AV46Companywwds_1_filterfulltext = "";
         AV47Companywwds_2_tfcompanyname = "";
         AV48Companywwds_3_tfcompanyname_sel = "";
         AV49Companywwds_4_tfcompanylocationname = "";
         AV50Companywwds_5_tfcompanylocationname_sel = "";
         lV46Companywwds_1_filterfulltext = "";
         lV47Companywwds_2_tfcompanyname = "";
         lV49Companywwds_4_tfcompanylocationname = "";
         A101CompanyName = "";
         A158CompanyLocationName = "";
         P00692_A157CompanyLocationId = new long[1] ;
         P00692_A101CompanyName = new string[] {""} ;
         P00692_A158CompanyLocationName = new string[] {""} ;
         P00692_A100CompanyId = new long[1] ;
         AV24Option = "";
         P00693_A157CompanyLocationId = new long[1] ;
         P00693_A158CompanyLocationName = new string[] {""} ;
         P00693_A101CompanyName = new string[] {""} ;
         P00693_A100CompanyId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.companywwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00692_A157CompanyLocationId, P00692_A101CompanyName, P00692_A158CompanyLocationName, P00692_A100CompanyId
               }
               , new Object[] {
               P00693_A157CompanyLocationId, P00693_A158CompanyLocationName, P00693_A101CompanyName, P00693_A100CompanyId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private int AV44GXV1 ;
      private int AV23InsertIndex ;
      private long A157CompanyLocationId ;
      private long A100CompanyId ;
      private long AV29count ;
      private string AV13TFCompanyName ;
      private string AV14TFCompanyName_Sel ;
      private string AV42TFCompanyLocationName ;
      private string AV43TFCompanyLocationName_Sel ;
      private string AV47Companywwds_2_tfcompanyname ;
      private string AV48Companywwds_3_tfcompanyname_sel ;
      private string AV49Companywwds_4_tfcompanylocationname ;
      private string AV50Companywwds_5_tfcompanylocationname_sel ;
      private string lV47Companywwds_2_tfcompanyname ;
      private string lV49Companywwds_4_tfcompanylocationname ;
      private string A101CompanyName ;
      private string A158CompanyLocationName ;
      private bool returnInSub ;
      private bool BRK692 ;
      private bool BRK694 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV46Companywwds_1_filterfulltext ;
      private string lV46Companywwds_1_filterfulltext ;
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
      private long[] P00692_A157CompanyLocationId ;
      private string[] P00692_A101CompanyName ;
      private string[] P00692_A158CompanyLocationName ;
      private long[] P00692_A100CompanyId ;
      private long[] P00693_A157CompanyLocationId ;
      private string[] P00693_A158CompanyLocationName ;
      private string[] P00693_A101CompanyName ;
      private long[] P00693_A100CompanyId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class companywwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00692( IGxContext context ,
                                             string AV46Companywwds_1_filterfulltext ,
                                             string AV48Companywwds_3_tfcompanyname_sel ,
                                             string AV47Companywwds_2_tfcompanyname ,
                                             string AV50Companywwds_5_tfcompanylocationname_sel ,
                                             string AV49Companywwds_4_tfcompanylocationname ,
                                             string A101CompanyName ,
                                             string A158CompanyLocationName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.CompanyLocationId, T1.CompanyName, T2.CompanyLocationName, T1.CompanyId FROM (Company T1 INNER JOIN CompanyLocation T2 ON T2.CompanyLocationId = T1.CompanyLocationId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Companywwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.CompanyName like '%' || :lV46Companywwds_1_filterfulltext) or ( T2.CompanyLocationName like '%' || :lV46Companywwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Companywwds_3_tfcompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Companywwds_2_tfcompanyname)) ) )
         {
            AddWhere(sWhereString, "(T1.CompanyName like :lV47Companywwds_2_tfcompanyname)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Companywwds_3_tfcompanyname_sel)) && ! ( StringUtil.StrCmp(AV48Companywwds_3_tfcompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CompanyName = ( :AV48Companywwds_3_tfcompanyname_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV48Companywwds_3_tfcompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Companywwds_5_tfcompanylocationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Companywwds_4_tfcompanylocationname)) ) )
         {
            AddWhere(sWhereString, "(T2.CompanyLocationName like :lV49Companywwds_4_tfcompanylocationname)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Companywwds_5_tfcompanylocationname_sel)) && ! ( StringUtil.StrCmp(AV50Companywwds_5_tfcompanylocationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CompanyLocationName = ( :AV50Companywwds_5_tfcompanylocationname_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV50Companywwds_5_tfcompanylocationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CompanyLocationName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.CompanyName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00693( IGxContext context ,
                                             string AV46Companywwds_1_filterfulltext ,
                                             string AV48Companywwds_3_tfcompanyname_sel ,
                                             string AV47Companywwds_2_tfcompanyname ,
                                             string AV50Companywwds_5_tfcompanylocationname_sel ,
                                             string AV49Companywwds_4_tfcompanylocationname ,
                                             string A101CompanyName ,
                                             string A158CompanyLocationName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.CompanyLocationId, T2.CompanyLocationName, T1.CompanyName, T1.CompanyId FROM (Company T1 INNER JOIN CompanyLocation T2 ON T2.CompanyLocationId = T1.CompanyLocationId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Companywwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.CompanyName like '%' || :lV46Companywwds_1_filterfulltext) or ( T2.CompanyLocationName like '%' || :lV46Companywwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Companywwds_3_tfcompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Companywwds_2_tfcompanyname)) ) )
         {
            AddWhere(sWhereString, "(T1.CompanyName like :lV47Companywwds_2_tfcompanyname)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Companywwds_3_tfcompanyname_sel)) && ! ( StringUtil.StrCmp(AV48Companywwds_3_tfcompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CompanyName = ( :AV48Companywwds_3_tfcompanyname_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV48Companywwds_3_tfcompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CompanyName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Companywwds_5_tfcompanylocationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Companywwds_4_tfcompanylocationname)) ) )
         {
            AddWhere(sWhereString, "(T2.CompanyLocationName like :lV49Companywwds_4_tfcompanylocationname)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Companywwds_5_tfcompanylocationname_sel)) && ! ( StringUtil.StrCmp(AV50Companywwds_5_tfcompanylocationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CompanyLocationName = ( :AV50Companywwds_5_tfcompanylocationname_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV50Companywwds_5_tfcompanylocationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CompanyLocationName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.CompanyLocationId";
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
                     return conditional_P00692(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
               case 1 :
                     return conditional_P00693(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] );
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
          Object[] prmP00692;
          prmP00692 = new Object[] {
          new ParDef("lV46Companywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Companywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Companywwds_2_tfcompanyname",GXType.Char,100,0) ,
          new ParDef("AV48Companywwds_3_tfcompanyname_sel",GXType.Char,100,0) ,
          new ParDef("lV49Companywwds_4_tfcompanylocationname",GXType.Char,100,0) ,
          new ParDef("AV50Companywwds_5_tfcompanylocationname_sel",GXType.Char,100,0)
          };
          Object[] prmP00693;
          prmP00693 = new Object[] {
          new ParDef("lV46Companywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Companywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Companywwds_2_tfcompanyname",GXType.Char,100,0) ,
          new ParDef("AV48Companywwds_3_tfcompanyname_sel",GXType.Char,100,0) ,
          new ParDef("lV49Companywwds_4_tfcompanylocationname",GXType.Char,100,0) ,
          new ParDef("AV50Companywwds_5_tfcompanylocationname_sel",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00692", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00692,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00693", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00693,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
