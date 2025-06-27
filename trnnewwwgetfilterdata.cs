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
   public class trnnewwwgetfilterdata : GXProcedure
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
            return "trnnewww_Services_Execute" ;
         }

      }

      public trnnewwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trnnewwwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_TRNNEWNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADTRNNEWNAMEOPTIONS' */
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
         if ( StringUtil.StrCmp(AV28Session.Get("TrnNewWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "TrnNewWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("TrnNewWWGridState"), null, "", "");
         }
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV40GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTRNNEWID") == 0 )
            {
               AV11TFTrnNewId = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFTrnNewId_To = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTRNNEWNAME") == 0 )
            {
               AV13TFTrnNewName = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTRNNEWNAME_SEL") == 0 )
            {
               AV14TFTrnNewName_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTRNNEWDATE") == 0 )
            {
               AV15TFTrnNewDate = context.localUtil.CToD( AV31GridStateFilterValue.gxTpr_Value, 2);
               AV16TFTrnNewDate_To = context.localUtil.CToD( AV31GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV40GXV1 = (int)(AV40GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTRNNEWNAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFTrnNewName = AV17SearchTxt;
         AV14TFTrnNewName_Sel = "";
         AV42Trnnewwwds_1_filterfulltext = AV39FilterFullText;
         AV43Trnnewwwds_2_tftrnnewid = AV11TFTrnNewId;
         AV44Trnnewwwds_3_tftrnnewid_to = AV12TFTrnNewId_To;
         AV45Trnnewwwds_4_tftrnnewname = AV13TFTrnNewName;
         AV46Trnnewwwds_5_tftrnnewname_sel = AV14TFTrnNewName_Sel;
         AV47Trnnewwwds_6_tftrnnewdate = AV15TFTrnNewDate;
         AV48Trnnewwwds_7_tftrnnewdate_to = AV16TFTrnNewDate_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV42Trnnewwwds_1_filterfulltext ,
                                              AV43Trnnewwwds_2_tftrnnewid ,
                                              AV44Trnnewwwds_3_tftrnnewid_to ,
                                              AV46Trnnewwwds_5_tftrnnewname_sel ,
                                              AV45Trnnewwwds_4_tftrnnewname ,
                                              AV47Trnnewwwds_6_tftrnnewdate ,
                                              AV48Trnnewwwds_7_tftrnnewdate_to ,
                                              A180TrnNewId ,
                                              A181TrnNewName ,
                                              A182TrnNewDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE
                                              }
         });
         lV42Trnnewwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trnnewwwds_1_filterfulltext), "%", "");
         lV42Trnnewwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Trnnewwwds_1_filterfulltext), "%", "");
         lV45Trnnewwwds_4_tftrnnewname = StringUtil.PadR( StringUtil.RTrim( AV45Trnnewwwds_4_tftrnnewname), 100, "%");
         /* Using cursor P00AP2 */
         pr_default.execute(0, new Object[] {lV42Trnnewwwds_1_filterfulltext, lV42Trnnewwwds_1_filterfulltext, AV43Trnnewwwds_2_tftrnnewid, AV44Trnnewwwds_3_tftrnnewid_to, lV45Trnnewwwds_4_tftrnnewname, AV46Trnnewwwds_5_tftrnnewname_sel, AV47Trnnewwwds_6_tftrnnewdate, AV48Trnnewwwds_7_tftrnnewdate_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAP2 = false;
            A181TrnNewName = P00AP2_A181TrnNewName[0];
            A182TrnNewDate = P00AP2_A182TrnNewDate[0];
            A180TrnNewId = P00AP2_A180TrnNewId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AP2_A181TrnNewName[0], A181TrnNewName) == 0 ) )
            {
               BRKAP2 = false;
               A180TrnNewId = P00AP2_A180TrnNewId[0];
               AV27count = (long)(AV27count+1);
               BRKAP2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A181TrnNewName)) ? "<#Empty#>" : A181TrnNewName);
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
            if ( ! BRKAP2 )
            {
               BRKAP2 = true;
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
         AV13TFTrnNewName = "";
         AV14TFTrnNewName_Sel = "";
         AV15TFTrnNewDate = DateTime.MinValue;
         AV16TFTrnNewDate_To = DateTime.MinValue;
         AV42Trnnewwwds_1_filterfulltext = "";
         AV45Trnnewwwds_4_tftrnnewname = "";
         AV46Trnnewwwds_5_tftrnnewname_sel = "";
         AV47Trnnewwwds_6_tftrnnewdate = DateTime.MinValue;
         AV48Trnnewwwds_7_tftrnnewdate_to = DateTime.MinValue;
         lV42Trnnewwwds_1_filterfulltext = "";
         lV45Trnnewwwds_4_tftrnnewname = "";
         A181TrnNewName = "";
         A182TrnNewDate = DateTime.MinValue;
         P00AP2_A181TrnNewName = new string[] {""} ;
         P00AP2_A182TrnNewDate = new DateTime[] {DateTime.MinValue} ;
         P00AP2_A180TrnNewId = new long[1] ;
         AV22Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trnnewwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00AP2_A181TrnNewName, P00AP2_A182TrnNewDate, P00AP2_A180TrnNewId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private int AV40GXV1 ;
      private long AV11TFTrnNewId ;
      private long AV12TFTrnNewId_To ;
      private long AV43Trnnewwwds_2_tftrnnewid ;
      private long AV44Trnnewwwds_3_tftrnnewid_to ;
      private long A180TrnNewId ;
      private long AV27count ;
      private string AV13TFTrnNewName ;
      private string AV14TFTrnNewName_Sel ;
      private string AV45Trnnewwwds_4_tftrnnewname ;
      private string AV46Trnnewwwds_5_tftrnnewname_sel ;
      private string lV45Trnnewwwds_4_tftrnnewname ;
      private string A181TrnNewName ;
      private DateTime AV15TFTrnNewDate ;
      private DateTime AV16TFTrnNewDate_To ;
      private DateTime AV47Trnnewwwds_6_tftrnnewdate ;
      private DateTime AV48Trnnewwwds_7_tftrnnewdate_to ;
      private DateTime A182TrnNewDate ;
      private bool returnInSub ;
      private bool BRKAP2 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV42Trnnewwwds_1_filterfulltext ;
      private string lV42Trnnewwwds_1_filterfulltext ;
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
      private string[] P00AP2_A181TrnNewName ;
      private DateTime[] P00AP2_A182TrnNewDate ;
      private long[] P00AP2_A180TrnNewId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class trnnewwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AP2( IGxContext context ,
                                             string AV42Trnnewwwds_1_filterfulltext ,
                                             long AV43Trnnewwwds_2_tftrnnewid ,
                                             long AV44Trnnewwwds_3_tftrnnewid_to ,
                                             string AV46Trnnewwwds_5_tftrnnewname_sel ,
                                             string AV45Trnnewwwds_4_tftrnnewname ,
                                             DateTime AV47Trnnewwwds_6_tftrnnewdate ,
                                             DateTime AV48Trnnewwwds_7_tftrnnewdate_to ,
                                             long A180TrnNewId ,
                                             string A181TrnNewName ,
                                             DateTime A182TrnNewDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT TrnNewName, TrnNewDate, TrnNewId FROM TrnNew";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Trnnewwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(TrnNewId,'9999999999'), 2) like '%' || :lV42Trnnewwwds_1_filterfulltext) or ( TrnNewName like '%' || :lV42Trnnewwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV43Trnnewwwds_2_tftrnnewid) )
         {
            AddWhere(sWhereString, "(TrnNewId >= :AV43Trnnewwwds_2_tftrnnewid)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV44Trnnewwwds_3_tftrnnewid_to) )
         {
            AddWhere(sWhereString, "(TrnNewId <= :AV44Trnnewwwds_3_tftrnnewid_to)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Trnnewwwds_5_tftrnnewname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Trnnewwwds_4_tftrnnewname)) ) )
         {
            AddWhere(sWhereString, "(TrnNewName like :lV45Trnnewwwds_4_tftrnnewname)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Trnnewwwds_5_tftrnnewname_sel)) && ! ( StringUtil.StrCmp(AV46Trnnewwwds_5_tftrnnewname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TrnNewName = ( :AV46Trnnewwwds_5_tftrnnewname_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV46Trnnewwwds_5_tftrnnewname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TrnNewName))=0))");
         }
         if ( ! (DateTime.MinValue==AV47Trnnewwwds_6_tftrnnewdate) )
         {
            AddWhere(sWhereString, "(TrnNewDate >= :AV47Trnnewwwds_6_tftrnnewdate)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV48Trnnewwwds_7_tftrnnewdate_to) )
         {
            AddWhere(sWhereString, "(TrnNewDate <= :AV48Trnnewwwds_7_tftrnnewdate_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY TrnNewName";
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
                     return conditional_P00AP2(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] );
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
          Object[] prmP00AP2;
          prmP00AP2 = new Object[] {
          new ParDef("lV42Trnnewwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Trnnewwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV43Trnnewwwds_2_tftrnnewid",GXType.Int64,10,0) ,
          new ParDef("AV44Trnnewwwds_3_tftrnnewid_to",GXType.Int64,10,0) ,
          new ParDef("lV45Trnnewwwds_4_tftrnnewname",GXType.Char,100,0) ,
          new ParDef("AV46Trnnewwwds_5_tftrnnewname_sel",GXType.Char,100,0) ,
          new ParDef("AV47Trnnewwwds_6_tftrnnewdate",GXType.Date,8,0) ,
          new ParDef("AV48Trnnewwwds_7_tftrnnewdate_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AP2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AP2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
