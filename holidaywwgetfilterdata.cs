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
   public class holidaywwgetfilterdata : GXProcedure
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
            return "holidayww_Services_Execute" ;
         }

      }

      public holidaywwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public holidaywwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_HOLIDAYNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADHOLIDAYNAMEOPTIONS' */
            S121 ();
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
         if ( StringUtil.StrCmp(AV36Session.Get("HolidayWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "HolidayWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("HolidayWWGridState"), null, "", "");
         }
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV52GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFHOLIDAYNAME") == 0 )
            {
               AV13TFHolidayName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFHOLIDAYNAME_SEL") == 0 )
            {
               AV14TFHolidayName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFHOLIDAYSTARTDATE") == 0 )
            {
               AV15TFHolidayStartDate = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Value, 2);
               AV16TFHolidayStartDate_To = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFHOLIDAYISACTIVE_SEL") == 0 )
            {
               AV49TFHolidayIsActive_Sel = (short)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADHOLIDAYNAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFHolidayName = AV25SearchTxt;
         AV14TFHolidayName_Sel = "";
         AV54Holidaywwds_1_filterfulltext = AV47FilterFullText;
         AV55Holidaywwds_2_tfholidayname = AV13TFHolidayName;
         AV56Holidaywwds_3_tfholidayname_sel = AV14TFHolidayName_Sel;
         AV57Holidaywwds_4_tfholidaystartdate = AV15TFHolidayStartDate;
         AV58Holidaywwds_5_tfholidaystartdate_to = AV16TFHolidayStartDate_To;
         AV59Holidaywwds_6_tfholidayisactive_sel = AV49TFHolidayIsActive_Sel;
         AV61Udparg7 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV54Holidaywwds_1_filterfulltext ,
                                              AV56Holidaywwds_3_tfholidayname_sel ,
                                              AV55Holidaywwds_2_tfholidayname ,
                                              AV57Holidaywwds_4_tfholidaystartdate ,
                                              AV58Holidaywwds_5_tfholidaystartdate_to ,
                                              AV59Holidaywwds_6_tfholidayisactive_sel ,
                                              A114HolidayName ,
                                              A115HolidayStartDate ,
                                              A139HolidayIsActive ,
                                              Gx_date ,
                                              A100CompanyId ,
                                              AV61Udparg7 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV54Holidaywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Holidaywwds_1_filterfulltext), "%", "");
         lV55Holidaywwds_2_tfholidayname = StringUtil.PadR( StringUtil.RTrim( AV55Holidaywwds_2_tfholidayname), 100, "%");
         /* Using cursor P00412 */
         pr_default.execute(0, new Object[] {Gx_date, Gx_date, AV61Udparg7, lV54Holidaywwds_1_filterfulltext, lV55Holidaywwds_2_tfholidayname, AV56Holidaywwds_3_tfholidayname_sel, AV57Holidaywwds_4_tfholidaystartdate, AV58Holidaywwds_5_tfholidaystartdate_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK412 = false;
            A100CompanyId = P00412_A100CompanyId[0];
            A114HolidayName = P00412_A114HolidayName[0];
            A139HolidayIsActive = P00412_A139HolidayIsActive[0];
            A115HolidayStartDate = P00412_A115HolidayStartDate[0];
            A113HolidayId = P00412_A113HolidayId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00412_A114HolidayName[0], A114HolidayName) == 0 ) )
            {
               BRK412 = false;
               A113HolidayId = P00412_A113HolidayId[0];
               AV35count = (long)(AV35count+1);
               BRK412 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A114HolidayName)) ? "<#Empty#>" : A114HolidayName);
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
            if ( ! BRK412 )
            {
               BRK412 = true;
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
         AV13TFHolidayName = "";
         AV14TFHolidayName_Sel = "";
         AV15TFHolidayStartDate = DateTime.MinValue;
         AV16TFHolidayStartDate_To = DateTime.MinValue;
         AV54Holidaywwds_1_filterfulltext = "";
         AV55Holidaywwds_2_tfholidayname = "";
         AV56Holidaywwds_3_tfholidayname_sel = "";
         AV57Holidaywwds_4_tfholidaystartdate = DateTime.MinValue;
         AV58Holidaywwds_5_tfholidaystartdate_to = DateTime.MinValue;
         lV54Holidaywwds_1_filterfulltext = "";
         lV55Holidaywwds_2_tfholidayname = "";
         A114HolidayName = "";
         A115HolidayStartDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         P00412_A100CompanyId = new long[1] ;
         P00412_A114HolidayName = new string[] {""} ;
         P00412_A139HolidayIsActive = new bool[] {false} ;
         P00412_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P00412_A113HolidayId = new long[1] ;
         AV30Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.holidaywwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00412_A100CompanyId, P00412_A114HolidayName, P00412_A139HolidayIsActive, P00412_A115HolidayStartDate, P00412_A113HolidayId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private short AV49TFHolidayIsActive_Sel ;
      private short AV59Holidaywwds_6_tfholidayisactive_sel ;
      private int AV52GXV1 ;
      private long AV61Udparg7 ;
      private long A100CompanyId ;
      private long A113HolidayId ;
      private long AV35count ;
      private string AV13TFHolidayName ;
      private string AV14TFHolidayName_Sel ;
      private string AV55Holidaywwds_2_tfholidayname ;
      private string AV56Holidaywwds_3_tfholidayname_sel ;
      private string lV55Holidaywwds_2_tfholidayname ;
      private string A114HolidayName ;
      private DateTime AV15TFHolidayStartDate ;
      private DateTime AV16TFHolidayStartDate_To ;
      private DateTime AV57Holidaywwds_4_tfholidaystartdate ;
      private DateTime AV58Holidaywwds_5_tfholidaystartdate_to ;
      private DateTime A115HolidayStartDate ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private bool A139HolidayIsActive ;
      private bool BRK412 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV54Holidaywwds_1_filterfulltext ;
      private string lV54Holidaywwds_1_filterfulltext ;
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
      private IDataStoreProvider pr_default ;
      private long[] P00412_A100CompanyId ;
      private string[] P00412_A114HolidayName ;
      private bool[] P00412_A139HolidayIsActive ;
      private DateTime[] P00412_A115HolidayStartDate ;
      private long[] P00412_A113HolidayId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class holidaywwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00412( IGxContext context ,
                                             string AV54Holidaywwds_1_filterfulltext ,
                                             string AV56Holidaywwds_3_tfholidayname_sel ,
                                             string AV55Holidaywwds_2_tfholidayname ,
                                             DateTime AV57Holidaywwds_4_tfholidaystartdate ,
                                             DateTime AV58Holidaywwds_5_tfholidaystartdate_to ,
                                             short AV59Holidaywwds_6_tfholidayisactive_sel ,
                                             string A114HolidayName ,
                                             DateTime A115HolidayStartDate ,
                                             bool A139HolidayIsActive ,
                                             DateTime Gx_date ,
                                             long A100CompanyId ,
                                             long AV61Udparg7 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT CompanyId, HolidayName, HolidayIsActive, HolidayStartDate, HolidayId FROM Holiday";
         AddWhere(sWhereString, "(date_part('year', HolidayStartDate) = date_part('year', :Gx_date) or date_part('year', HolidayStartDate) = date_part('year', (CAST(:Gx_date AS date) + CAST (1 || ' YEAR' AS INTERVAL))))");
         AddWhere(sWhereString, "(CompanyId = :AV61Udparg7)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Holidaywwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( HolidayName like '%' || :lV54Holidaywwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Holidaywwds_3_tfholidayname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Holidaywwds_2_tfholidayname)) ) )
         {
            AddWhere(sWhereString, "(HolidayName like :lV55Holidaywwds_2_tfholidayname)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Holidaywwds_3_tfholidayname_sel)) && ! ( StringUtil.StrCmp(AV56Holidaywwds_3_tfholidayname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(HolidayName = ( :AV56Holidaywwds_3_tfholidayname_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Holidaywwds_3_tfholidayname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from HolidayName))=0))");
         }
         if ( ! (DateTime.MinValue==AV57Holidaywwds_4_tfholidaystartdate) )
         {
            AddWhere(sWhereString, "(HolidayStartDate >= :AV57Holidaywwds_4_tfholidaystartdate)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Holidaywwds_5_tfholidaystartdate_to) )
         {
            AddWhere(sWhereString, "(HolidayStartDate <= :AV58Holidaywwds_5_tfholidaystartdate_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV59Holidaywwds_6_tfholidayisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(HolidayIsActive = TRUE)");
         }
         if ( AV59Holidaywwds_6_tfholidayisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(HolidayIsActive = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY HolidayName";
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
                     return conditional_P00412(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (bool)dynConstraints[8] , (DateTime)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] );
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
          Object[] prmP00412;
          prmP00412 = new Object[] {
          new ParDef("Gx_date",GXType.Date,8,0) ,
          new ParDef("Gx_date",GXType.Date,8,0) ,
          new ParDef("AV61Udparg7",GXType.Int64,10,0) ,
          new ParDef("lV54Holidaywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Holidaywwds_2_tfholidayname",GXType.Char,100,0) ,
          new ParDef("AV56Holidaywwds_3_tfholidayname_sel",GXType.Char,100,0) ,
          new ParDef("AV57Holidaywwds_4_tfholidaystartdate",GXType.Date,8,0) ,
          new ParDef("AV58Holidaywwds_5_tfholidaystartdate_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00412", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00412,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
