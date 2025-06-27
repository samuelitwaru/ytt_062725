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
   public class leavetypewwgetfilterdata : GXProcedure
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
            return "leavetypeww_Services_Execute" ;
         }

      }

      public leavetypewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leavetypewwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_LEAVETYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVETYPENAMEOPTIONS' */
            S121 ();
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
         if ( StringUtil.StrCmp(AV28Session.Get("LeaveTypeWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "LeaveTypeWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("LeaveTypeWWGridState"), null, "", "");
         }
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV13TFLeaveTypeName = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV14TFLeaveTypeName_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLEAVETYPEVACATIONLEAVE_SEL") == 0 )
            {
               AV40TFLeaveTypeVacationLeave_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV41TFLeaveTypeVacationLeave_Sels.FromJSonString(AV40TFLeaveTypeVacationLeave_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFLEAVETYPELOGGINGWORKHOURS_SEL") == 0 )
            {
               AV42TFLeaveTypeLoggingWorkHours_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV43TFLeaveTypeLoggingWorkHours_Sels.FromJSonString(AV42TFLeaveTypeLoggingWorkHours_SelsJson, null);
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADLEAVETYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFLeaveTypeName = AV17SearchTxt;
         AV14TFLeaveTypeName_Sel = "";
         AV52Leavetypewwds_1_filterfulltext = AV39FilterFullText;
         AV53Leavetypewwds_2_tfleavetypename = AV13TFLeaveTypeName;
         AV54Leavetypewwds_3_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV55Leavetypewwds_4_tfleavetypevacationleave_sels = AV41TFLeaveTypeVacationLeave_Sels;
         AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels = AV43TFLeaveTypeLoggingWorkHours_Sels;
         AV57Udparg6 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A144LeaveTypeVacationLeave ,
                                              AV55Leavetypewwds_4_tfleavetypevacationleave_sels ,
                                              A145LeaveTypeLoggingWorkHours ,
                                              AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels ,
                                              AV52Leavetypewwds_1_filterfulltext ,
                                              AV54Leavetypewwds_3_tfleavetypename_sel ,
                                              AV53Leavetypewwds_2_tfleavetypename ,
                                              AV55Leavetypewwds_4_tfleavetypevacationleave_sels.Count ,
                                              AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels.Count ,
                                              A125LeaveTypeName ,
                                              A100CompanyId ,
                                              AV57Udparg6 } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV52Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext), "%", "");
         lV53Leavetypewwds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV53Leavetypewwds_2_tfleavetypename), 100, "%");
         /* Using cursor P005C2 */
         pr_default.execute(0, new Object[] {AV57Udparg6, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV52Leavetypewwds_1_filterfulltext, lV53Leavetypewwds_2_tfleavetypename, AV54Leavetypewwds_3_tfleavetypename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5C2 = false;
            A100CompanyId = P005C2_A100CompanyId[0];
            A125LeaveTypeName = P005C2_A125LeaveTypeName[0];
            A145LeaveTypeLoggingWorkHours = P005C2_A145LeaveTypeLoggingWorkHours[0];
            A144LeaveTypeVacationLeave = P005C2_A144LeaveTypeVacationLeave[0];
            A124LeaveTypeId = P005C2_A124LeaveTypeId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005C2_A125LeaveTypeName[0], A125LeaveTypeName) == 0 ) )
            {
               BRK5C2 = false;
               A124LeaveTypeId = P005C2_A124LeaveTypeId[0];
               AV27count = (long)(AV27count+1);
               BRK5C2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A125LeaveTypeName)) ? "<#Empty#>" : A125LeaveTypeName);
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
            if ( ! BRK5C2 )
            {
               BRK5C2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV13TFLeaveTypeName = "";
         AV14TFLeaveTypeName_Sel = "";
         AV40TFLeaveTypeVacationLeave_SelsJson = "";
         AV41TFLeaveTypeVacationLeave_Sels = new GxSimpleCollection<string>();
         AV42TFLeaveTypeLoggingWorkHours_SelsJson = "";
         AV43TFLeaveTypeLoggingWorkHours_Sels = new GxSimpleCollection<string>();
         AV52Leavetypewwds_1_filterfulltext = "";
         AV53Leavetypewwds_2_tfleavetypename = "";
         AV54Leavetypewwds_3_tfleavetypename_sel = "";
         AV55Leavetypewwds_4_tfleavetypevacationleave_sels = new GxSimpleCollection<string>();
         AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels = new GxSimpleCollection<string>();
         lV52Leavetypewwds_1_filterfulltext = "";
         lV53Leavetypewwds_2_tfleavetypename = "";
         A144LeaveTypeVacationLeave = "";
         A145LeaveTypeLoggingWorkHours = "";
         A125LeaveTypeName = "";
         P005C2_A100CompanyId = new long[1] ;
         P005C2_A125LeaveTypeName = new string[] {""} ;
         P005C2_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         P005C2_A144LeaveTypeVacationLeave = new string[] {""} ;
         P005C2_A124LeaveTypeId = new long[1] ;
         AV22Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leavetypewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005C2_A100CompanyId, P005C2_A125LeaveTypeName, P005C2_A145LeaveTypeLoggingWorkHours, P005C2_A144LeaveTypeVacationLeave, P005C2_A124LeaveTypeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private int AV50GXV1 ;
      private int AV55Leavetypewwds_4_tfleavetypevacationleave_sels_Count ;
      private int AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels_Count ;
      private long AV57Udparg6 ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private long AV27count ;
      private string AV13TFLeaveTypeName ;
      private string AV14TFLeaveTypeName_Sel ;
      private string AV53Leavetypewwds_2_tfleavetypename ;
      private string AV54Leavetypewwds_3_tfleavetypename_sel ;
      private string lV53Leavetypewwds_2_tfleavetypename ;
      private string A144LeaveTypeVacationLeave ;
      private string A145LeaveTypeLoggingWorkHours ;
      private string A125LeaveTypeName ;
      private bool returnInSub ;
      private bool BRK5C2 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV40TFLeaveTypeVacationLeave_SelsJson ;
      private string AV42TFLeaveTypeLoggingWorkHours_SelsJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV52Leavetypewwds_1_filterfulltext ;
      private string lV52Leavetypewwds_1_filterfulltext ;
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
      private GxSimpleCollection<string> AV41TFLeaveTypeVacationLeave_Sels ;
      private GxSimpleCollection<string> AV43TFLeaveTypeLoggingWorkHours_Sels ;
      private GxSimpleCollection<string> AV55Leavetypewwds_4_tfleavetypevacationleave_sels ;
      private GxSimpleCollection<string> AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P005C2_A100CompanyId ;
      private string[] P005C2_A125LeaveTypeName ;
      private string[] P005C2_A145LeaveTypeLoggingWorkHours ;
      private string[] P005C2_A144LeaveTypeVacationLeave ;
      private long[] P005C2_A124LeaveTypeId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class leavetypewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005C2( IGxContext context ,
                                             string A144LeaveTypeVacationLeave ,
                                             GxSimpleCollection<string> AV55Leavetypewwds_4_tfleavetypevacationleave_sels ,
                                             string A145LeaveTypeLoggingWorkHours ,
                                             GxSimpleCollection<string> AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels ,
                                             string AV52Leavetypewwds_1_filterfulltext ,
                                             string AV54Leavetypewwds_3_tfleavetypename_sel ,
                                             string AV53Leavetypewwds_2_tfleavetypename ,
                                             int AV55Leavetypewwds_4_tfleavetypevacationleave_sels_Count ,
                                             int AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels_Count ,
                                             string A125LeaveTypeName ,
                                             long A100CompanyId ,
                                             long AV57Udparg6 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT CompanyId, LeaveTypeName, LeaveTypeLoggingWorkHours, LeaveTypeVacationLeave, LeaveTypeId FROM LeaveType";
         AddWhere(sWhereString, "(CompanyId = :AV57Udparg6)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Leavetypewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LeaveTypeName like '%' || :lV52Leavetypewwds_1_filterfulltext) or ( 'no' like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext) and LeaveTypeVacationLeave = ( 'No')) or ( 'yes' like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext) and LeaveTypeVacationLeave = ( 'Yes')) or ( 'no' like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext) and LeaveTypeLoggingWorkHours = ( 'No')) or ( 'yes' like '%' || LOWER(:lV52Leavetypewwds_1_filterfulltext) and LeaveTypeLoggingWorkHours = ( 'Yes')))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Leavetypewwds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Leavetypewwds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LeaveTypeName like :lV53Leavetypewwds_2_tfleavetypename)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Leavetypewwds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV54Leavetypewwds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LeaveTypeName = ( :AV54Leavetypewwds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV54Leavetypewwds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LeaveTypeName))=0))");
         }
         if ( AV55Leavetypewwds_4_tfleavetypevacationleave_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV55Leavetypewwds_4_tfleavetypevacationleave_sels, "LeaveTypeVacationLeave IN (", ")")+")");
         }
         if ( AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV56Leavetypewwds_5_tfleavetypeloggingworkhours_sels, "LeaveTypeLoggingWorkHours IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY LeaveTypeName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P005C2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005C2;
          prmP005C2 = new Object[] {
          new ParDef("AV57Udparg6",GXType.Int64,10,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Leavetypewwds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV54Leavetypewwds_3_tfleavetypename_sel",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005C2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
