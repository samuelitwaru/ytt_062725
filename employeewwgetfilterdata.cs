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
   public class employeewwgetfilterdata : GXProcedure
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
            return "employeeww_Services_Execute" ;
         }

      }

      public employeewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeewwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_EMPLOYEENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_EMPLOYEEEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEEEMAILOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV42Session.Get("EmployeeWWGridState"), "") == 0 )
         {
            AV44GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "EmployeeWWGridState"), null, "", "");
         }
         else
         {
            AV44GridState.FromXml(AV42Session.Get("EmployeeWWGridState"), null, "", "");
         }
         AV58GXV1 = 1;
         while ( AV58GXV1 <= AV44GridState.gxTpr_Filtervalues.Count )
         {
            AV45GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV44GridState.gxTpr_Filtervalues.Item(AV58GXV1));
            if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV53FilterFullText = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV54TFEmployeeName = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV55TFEmployeeName_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL") == 0 )
            {
               AV17TFEmployeeEmail = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL_SEL") == 0 )
            {
               AV18TFEmployeeEmail_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISMANAGER_SEL") == 0 )
            {
               AV23TFEmployeeIsManager_Sel = (short)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISACTIVE_SEL") == 0 )
            {
               AV26TFEmployeeIsActive_Sel = (short)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV58GXV1 = (int)(AV58GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADEMPLOYEENAMEOPTIONS' Routine */
         returnInSub = false;
         AV54TFEmployeeName = AV31SearchTxt;
         AV55TFEmployeeName_Sel = "";
         AV60Employeewwds_1_filterfulltext = AV53FilterFullText;
         AV61Employeewwds_2_tfemployeename = AV54TFEmployeeName;
         AV62Employeewwds_3_tfemployeename_sel = AV55TFEmployeeName_Sel;
         AV63Employeewwds_4_tfemployeeemail = AV17TFEmployeeEmail;
         AV64Employeewwds_5_tfemployeeemail_sel = AV18TFEmployeeEmail_Sel;
         AV65Employeewwds_6_tfemployeeismanager_sel = AV23TFEmployeeIsManager_Sel;
         AV66Employeewwds_7_tfemployeeisactive_sel = AV26TFEmployeeIsActive_Sel;
         AV67Udparg8 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV56EmployeeIds ,
                                              AV60Employeewwds_1_filterfulltext ,
                                              AV62Employeewwds_3_tfemployeename_sel ,
                                              AV61Employeewwds_2_tfemployeename ,
                                              AV64Employeewwds_5_tfemployeeemail_sel ,
                                              AV63Employeewwds_4_tfemployeeemail ,
                                              AV65Employeewwds_6_tfemployeeismanager_sel ,
                                              AV66Employeewwds_7_tfemployeeisactive_sel ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive ,
                                              A100CompanyId ,
                                              AV67Udparg8 } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV60Employeewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Employeewwds_1_filterfulltext), "%", "");
         lV60Employeewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Employeewwds_1_filterfulltext), "%", "");
         lV61Employeewwds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV61Employeewwds_2_tfemployeename), 100, "%");
         lV63Employeewwds_4_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV63Employeewwds_4_tfemployeeemail), "%", "");
         /* Using cursor P006B2 */
         pr_default.execute(0, new Object[] {lV60Employeewwds_1_filterfulltext, lV60Employeewwds_1_filterfulltext, lV61Employeewwds_2_tfemployeename, AV62Employeewwds_3_tfemployeename_sel, lV63Employeewwds_4_tfemployeeemail, AV64Employeewwds_5_tfemployeeemail_sel, AV67Udparg8});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6B2 = false;
            A148EmployeeName = P006B2_A148EmployeeName[0];
            A106EmployeeId = P006B2_A106EmployeeId[0];
            A100CompanyId = P006B2_A100CompanyId[0];
            A112EmployeeIsActive = P006B2_A112EmployeeIsActive[0];
            A110EmployeeIsManager = P006B2_A110EmployeeIsManager[0];
            A109EmployeeEmail = P006B2_A109EmployeeEmail[0];
            AV41count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006B2_A148EmployeeName[0], A148EmployeeName) == 0 ) )
            {
               BRK6B2 = false;
               A106EmployeeId = P006B2_A106EmployeeId[0];
               AV41count = (long)(AV41count+1);
               BRK6B2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A148EmployeeName)) ? "<#Empty#>" : A148EmployeeName);
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
            if ( ! BRK6B2 )
            {
               BRK6B2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADEMPLOYEEEMAILOPTIONS' Routine */
         returnInSub = false;
         AV17TFEmployeeEmail = AV31SearchTxt;
         AV18TFEmployeeEmail_Sel = "";
         AV60Employeewwds_1_filterfulltext = AV53FilterFullText;
         AV61Employeewwds_2_tfemployeename = AV54TFEmployeeName;
         AV62Employeewwds_3_tfemployeename_sel = AV55TFEmployeeName_Sel;
         AV63Employeewwds_4_tfemployeeemail = AV17TFEmployeeEmail;
         AV64Employeewwds_5_tfemployeeemail_sel = AV18TFEmployeeEmail_Sel;
         AV65Employeewwds_6_tfemployeeismanager_sel = AV23TFEmployeeIsManager_Sel;
         AV66Employeewwds_7_tfemployeeisactive_sel = AV26TFEmployeeIsActive_Sel;
         AV67Udparg8 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV56EmployeeIds ,
                                              AV60Employeewwds_1_filterfulltext ,
                                              AV62Employeewwds_3_tfemployeename_sel ,
                                              AV61Employeewwds_2_tfemployeename ,
                                              AV64Employeewwds_5_tfemployeeemail_sel ,
                                              AV63Employeewwds_4_tfemployeeemail ,
                                              AV65Employeewwds_6_tfemployeeismanager_sel ,
                                              AV66Employeewwds_7_tfemployeeisactive_sel ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive ,
                                              A100CompanyId ,
                                              AV67Udparg8 } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV60Employeewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Employeewwds_1_filterfulltext), "%", "");
         lV60Employeewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Employeewwds_1_filterfulltext), "%", "");
         lV61Employeewwds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV61Employeewwds_2_tfemployeename), 100, "%");
         lV63Employeewwds_4_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV63Employeewwds_4_tfemployeeemail), "%", "");
         /* Using cursor P006B3 */
         pr_default.execute(1, new Object[] {lV60Employeewwds_1_filterfulltext, lV60Employeewwds_1_filterfulltext, lV61Employeewwds_2_tfemployeename, AV62Employeewwds_3_tfemployeename_sel, lV63Employeewwds_4_tfemployeeemail, AV64Employeewwds_5_tfemployeeemail_sel, AV67Udparg8});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6B4 = false;
            A109EmployeeEmail = P006B3_A109EmployeeEmail[0];
            A106EmployeeId = P006B3_A106EmployeeId[0];
            A100CompanyId = P006B3_A100CompanyId[0];
            A112EmployeeIsActive = P006B3_A112EmployeeIsActive[0];
            A110EmployeeIsManager = P006B3_A110EmployeeIsManager[0];
            A148EmployeeName = P006B3_A148EmployeeName[0];
            AV41count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006B3_A109EmployeeEmail[0], A109EmployeeEmail) == 0 ) )
            {
               BRK6B4 = false;
               A106EmployeeId = P006B3_A106EmployeeId[0];
               AV41count = (long)(AV41count+1);
               BRK6B4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A109EmployeeEmail)) ? "<#Empty#>" : A109EmployeeEmail);
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
            if ( ! BRK6B4 )
            {
               BRK6B4 = true;
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
         AV54TFEmployeeName = "";
         AV55TFEmployeeName_Sel = "";
         AV17TFEmployeeEmail = "";
         AV18TFEmployeeEmail_Sel = "";
         AV60Employeewwds_1_filterfulltext = "";
         AV61Employeewwds_2_tfemployeename = "";
         AV62Employeewwds_3_tfemployeename_sel = "";
         AV63Employeewwds_4_tfemployeeemail = "";
         AV64Employeewwds_5_tfemployeeemail_sel = "";
         lV60Employeewwds_1_filterfulltext = "";
         lV61Employeewwds_2_tfemployeename = "";
         lV63Employeewwds_4_tfemployeeemail = "";
         AV56EmployeeIds = new GxSimpleCollection<long>();
         A148EmployeeName = "";
         A109EmployeeEmail = "";
         P006B2_A148EmployeeName = new string[] {""} ;
         P006B2_A106EmployeeId = new long[1] ;
         P006B2_A100CompanyId = new long[1] ;
         P006B2_A112EmployeeIsActive = new bool[] {false} ;
         P006B2_A110EmployeeIsManager = new bool[] {false} ;
         P006B2_A109EmployeeEmail = new string[] {""} ;
         AV36Option = "";
         P006B3_A109EmployeeEmail = new string[] {""} ;
         P006B3_A106EmployeeId = new long[1] ;
         P006B3_A100CompanyId = new long[1] ;
         P006B3_A112EmployeeIsActive = new bool[] {false} ;
         P006B3_A110EmployeeIsManager = new bool[] {false} ;
         P006B3_A148EmployeeName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006B2_A148EmployeeName, P006B2_A106EmployeeId, P006B2_A100CompanyId, P006B2_A112EmployeeIsActive, P006B2_A110EmployeeIsManager, P006B2_A109EmployeeEmail
               }
               , new Object[] {
               P006B3_A109EmployeeEmail, P006B3_A106EmployeeId, P006B3_A100CompanyId, P006B3_A112EmployeeIsActive, P006B3_A110EmployeeIsManager, P006B3_A148EmployeeName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV34MaxItems ;
      private short AV33PageIndex ;
      private short AV32SkipItems ;
      private short AV23TFEmployeeIsManager_Sel ;
      private short AV26TFEmployeeIsActive_Sel ;
      private short AV65Employeewwds_6_tfemployeeismanager_sel ;
      private short AV66Employeewwds_7_tfemployeeisactive_sel ;
      private int AV58GXV1 ;
      private long AV67Udparg8 ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long AV41count ;
      private string AV54TFEmployeeName ;
      private string AV55TFEmployeeName_Sel ;
      private string AV61Employeewwds_2_tfemployeename ;
      private string AV62Employeewwds_3_tfemployeename_sel ;
      private string lV61Employeewwds_2_tfemployeename ;
      private string A148EmployeeName ;
      private bool returnInSub ;
      private bool A110EmployeeIsManager ;
      private bool A112EmployeeIsActive ;
      private bool BRK6B2 ;
      private bool BRK6B4 ;
      private string AV50OptionsJson ;
      private string AV51OptionsDescJson ;
      private string AV52OptionIndexesJson ;
      private string AV47DDOName ;
      private string AV48SearchTxtParms ;
      private string AV49SearchTxtTo ;
      private string AV31SearchTxt ;
      private string AV53FilterFullText ;
      private string AV17TFEmployeeEmail ;
      private string AV18TFEmployeeEmail_Sel ;
      private string AV60Employeewwds_1_filterfulltext ;
      private string AV63Employeewwds_4_tfemployeeemail ;
      private string AV64Employeewwds_5_tfemployeeemail_sel ;
      private string lV60Employeewwds_1_filterfulltext ;
      private string lV63Employeewwds_4_tfemployeeemail ;
      private string A109EmployeeEmail ;
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
      private GxSimpleCollection<long> AV56EmployeeIds ;
      private IDataStoreProvider pr_default ;
      private string[] P006B2_A148EmployeeName ;
      private long[] P006B2_A106EmployeeId ;
      private long[] P006B2_A100CompanyId ;
      private bool[] P006B2_A112EmployeeIsActive ;
      private bool[] P006B2_A110EmployeeIsManager ;
      private string[] P006B2_A109EmployeeEmail ;
      private string[] P006B3_A109EmployeeEmail ;
      private long[] P006B3_A106EmployeeId ;
      private long[] P006B3_A100CompanyId ;
      private bool[] P006B3_A112EmployeeIsActive ;
      private bool[] P006B3_A110EmployeeIsManager ;
      private string[] P006B3_A148EmployeeName ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class employeewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006B2( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV56EmployeeIds ,
                                             string AV60Employeewwds_1_filterfulltext ,
                                             string AV62Employeewwds_3_tfemployeename_sel ,
                                             string AV61Employeewwds_2_tfemployeename ,
                                             string AV64Employeewwds_5_tfemployeeemail_sel ,
                                             string AV63Employeewwds_4_tfemployeeemail ,
                                             short AV65Employeewwds_6_tfemployeeismanager_sel ,
                                             short AV66Employeewwds_7_tfemployeeisactive_sel ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive ,
                                             long A100CompanyId ,
                                             long AV67Udparg8 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT EmployeeName, EmployeeId, CompanyId, EmployeeIsActive, EmployeeIsManager, EmployeeEmail FROM Employee";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Employeewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( EmployeeName like '%' || :lV60Employeewwds_1_filterfulltext) or ( EmployeeEmail like '%' || :lV60Employeewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Employeewwds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Employeewwds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(EmployeeName like :lV61Employeewwds_2_tfemployeename)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Employeewwds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV62Employeewwds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmployeeName = ( :AV62Employeewwds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV62Employeewwds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Employeewwds_5_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Employeewwds_4_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(EmployeeEmail like :lV63Employeewwds_4_tfemployeeemail)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Employeewwds_5_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV64Employeewwds_5_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmployeeEmail = ( :AV64Employeewwds_5_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV64Employeewwds_5_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from EmployeeEmail))=0))");
         }
         if ( AV65Employeewwds_6_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(EmployeeIsManager = TRUE)");
         }
         if ( AV65Employeewwds_6_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(EmployeeIsManager = FALSE)");
         }
         if ( AV66Employeewwds_7_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(EmployeeIsActive = TRUE)");
         }
         if ( AV66Employeewwds_7_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(EmployeeIsActive = FALSE)");
         }
         if ( new userhasrole(context).executeUdp(  "Manager") && ! new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "(CompanyId = :AV67Udparg8)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV56EmployeeIds, "EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmployeeName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006B3( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV56EmployeeIds ,
                                             string AV60Employeewwds_1_filterfulltext ,
                                             string AV62Employeewwds_3_tfemployeename_sel ,
                                             string AV61Employeewwds_2_tfemployeename ,
                                             string AV64Employeewwds_5_tfemployeeemail_sel ,
                                             string AV63Employeewwds_4_tfemployeeemail ,
                                             short AV65Employeewwds_6_tfemployeeismanager_sel ,
                                             short AV66Employeewwds_7_tfemployeeisactive_sel ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive ,
                                             long A100CompanyId ,
                                             long AV67Udparg8 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT EmployeeEmail, EmployeeId, CompanyId, EmployeeIsActive, EmployeeIsManager, EmployeeName FROM Employee";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Employeewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( EmployeeName like '%' || :lV60Employeewwds_1_filterfulltext) or ( EmployeeEmail like '%' || :lV60Employeewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Employeewwds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Employeewwds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(EmployeeName like :lV61Employeewwds_2_tfemployeename)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Employeewwds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV62Employeewwds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmployeeName = ( :AV62Employeewwds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV62Employeewwds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Employeewwds_5_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Employeewwds_4_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(EmployeeEmail like :lV63Employeewwds_4_tfemployeeemail)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Employeewwds_5_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV64Employeewwds_5_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmployeeEmail = ( :AV64Employeewwds_5_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV64Employeewwds_5_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from EmployeeEmail))=0))");
         }
         if ( AV65Employeewwds_6_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(EmployeeIsManager = TRUE)");
         }
         if ( AV65Employeewwds_6_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(EmployeeIsManager = FALSE)");
         }
         if ( AV66Employeewwds_7_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(EmployeeIsActive = TRUE)");
         }
         if ( AV66Employeewwds_7_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(EmployeeIsActive = FALSE)");
         }
         if ( new userhasrole(context).executeUdp(  "Manager") && ! new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "(CompanyId = :AV67Udparg8)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV56EmployeeIds, "EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmployeeEmail";
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
                     return conditional_P006B2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (bool)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] );
               case 1 :
                     return conditional_P006B3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (bool)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] );
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
          Object[] prmP006B2;
          prmP006B2 = new Object[] {
          new ParDef("lV60Employeewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Employeewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Employeewwds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV62Employeewwds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV63Employeewwds_4_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV64Employeewwds_5_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV67Udparg8",GXType.Int64,10,0)
          };
          Object[] prmP006B3;
          prmP006B3 = new Object[] {
          new ParDef("lV60Employeewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Employeewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Employeewwds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV62Employeewwds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV63Employeewwds_4_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV64Employeewwds_5_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV67Udparg8",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B3,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                return;
       }
    }

 }

}
