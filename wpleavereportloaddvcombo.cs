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
   public class wpleavereportloaddvcombo : GXProcedure
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
            return "wpleavereport_Services_Execute" ;
         }

      }

      public wpleavereportloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpleavereportloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           string aP2_SearchTxtParms ,
                           out string aP3_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19SearchTxtParms = aP2_SearchTxtParms;
         this.AV20Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_Combo_DataJson=this.AV20Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                string aP2_SearchTxtParms )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_SearchTxtParms, out aP3_Combo_DataJson);
         return AV20Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 string aP2_SearchTxtParms ,
                                 out string aP3_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19SearchTxtParms = aP2_SearchTxtParms;
         this.AV20Combo_DataJson = "" ;
         SubmitImpl();
         aP3_Combo_DataJson=this.AV20Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11MaxItems = 10;
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV19SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV19SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV19SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? AV19SearchTxtParms : StringUtil.Substring( AV19SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV17ComboName, "EmployeeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_EMPLOYEEID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "ProjectId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PROJECTID' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "CompanyLocationId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_COMPANYLOCATIONID' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_EMPLOYEEID' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") != 0 )
         {
            GXPagingFrom2 = AV12SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A107EmployeeFirstName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P006F2 */
            pr_default.execute(0, new Object[] {lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A107EmployeeFirstName = P006F2_A107EmployeeFirstName[0];
               A106EmployeeId = P006F2_A106EmployeeId[0];
               AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0));
               AV16Combo_DataItem.gxTpr_Title = A107EmployeeFirstName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV20Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            AV22EmployeeIdKey = (long)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
            /* Using cursor P006F3 */
            pr_default.execute(1, new Object[] {AV22EmployeeIdKey});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A106EmployeeId = P006F3_A106EmployeeId[0];
               A107EmployeeFirstName = P006F3_A107EmployeeFirstName[0];
               AV20Combo_DataJson = A107EmployeeFirstName;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_PROJECTID' Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") != 0 ) && ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC_TEXT") != 0 ) )
         {
            GXPagingFrom4 = AV12SkipItems;
            GXPagingTo4 = AV11MaxItems;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A103ProjectName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P006F4 */
            pr_default.execute(2, new Object[] {lV14SearchTxt, GXPagingFrom4, GXPagingTo4, GXPagingTo4});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A103ProjectName = P006F4_A103ProjectName[0];
               A102ProjectId = P006F4_A102ProjectId[0];
               AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A102ProjectId), 10, 0));
               AV16Combo_DataItem.gxTpr_Title = A103ProjectName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV20Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            AV27ProjectId.FromJSonString(AV14SearchTxt, null);
            AV34GXV1 = 1;
            while ( AV34GXV1 <= AV27ProjectId.Count )
            {
               AV26ProjectIdKey = (long)(AV27ProjectId.GetNumeric(AV34GXV1));
               AV35GXLvl77 = 0;
               /* Using cursor P006F5 */
               pr_default.execute(3, new Object[] {AV26ProjectIdKey});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A102ProjectId = P006F5_A102ProjectId[0];
                  A103ProjectName = P006F5_A103ProjectName[0];
                  AV35GXLvl77 = 1;
                  AV28SelectedTextCol.Add(A103ProjectName, 0);
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(3);
               if ( AV35GXLvl77 == 0 )
               {
                  AV28SelectedTextCol.Add(StringUtil.Trim( StringUtil.Str( (decimal)(AV26ProjectIdKey), 10, 0)), 0);
               }
               AV34GXV1 = (int)(AV34GXV1+1);
            }
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC_TEXT") == 0 )
            {
               GXt_char1 = AV20Combo_DataJson;
               new WorkWithPlus.workwithplus_web.wwp_textlisttostring(context ).execute( ref  AV28SelectedTextCol,  false, out  GXt_char1) ;
               AV20Combo_DataJson = GXt_char1;
            }
            else
            {
               AV20Combo_DataJson = AV28SelectedTextCol.ToJSonString(false);
            }
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_COMPANYLOCATIONID' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") != 0 )
         {
            GXPagingFrom6 = AV12SkipItems;
            GXPagingTo6 = AV11MaxItems;
            pr_default.dynParam(4, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A158CompanyLocationName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P006F6 */
            pr_default.execute(4, new Object[] {lV14SearchTxt, GXPagingFrom6, GXPagingTo6, GXPagingTo6});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A158CompanyLocationName = P006F6_A158CompanyLocationName[0];
               A157CompanyLocationId = P006F6_A157CompanyLocationId[0];
               AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A157CompanyLocationId), 10, 0));
               AV16Combo_DataItem.gxTpr_Title = A158CompanyLocationName;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(4);
            }
            pr_default.close(4);
            AV20Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            AV29CompanyLocationIdKey = (long)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
            /* Using cursor P006F7 */
            pr_default.execute(5, new Object[] {AV29CompanyLocationIdKey});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A157CompanyLocationId = P006F7_A157CompanyLocationId[0];
               A158CompanyLocationName = P006F7_A158CompanyLocationName[0];
               AV20Combo_DataJson = A158CompanyLocationName;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(5);
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
         AV20Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         lV14SearchTxt = "";
         A107EmployeeFirstName = "";
         P006F2_A107EmployeeFirstName = new string[] {""} ;
         P006F2_A106EmployeeId = new long[1] ;
         AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P006F3_A106EmployeeId = new long[1] ;
         P006F3_A107EmployeeFirstName = new string[] {""} ;
         A103ProjectName = "";
         P006F4_A103ProjectName = new string[] {""} ;
         P006F4_A102ProjectId = new long[1] ;
         AV27ProjectId = new GxSimpleCollection<long>();
         P006F5_A102ProjectId = new long[1] ;
         P006F5_A103ProjectName = new string[] {""} ;
         AV28SelectedTextCol = new GxSimpleCollection<string>();
         GXt_char1 = "";
         A158CompanyLocationName = "";
         P006F6_A158CompanyLocationName = new string[] {""} ;
         P006F6_A157CompanyLocationId = new long[1] ;
         P006F7_A157CompanyLocationId = new long[1] ;
         P006F7_A158CompanyLocationName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpleavereportloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006F2_A107EmployeeFirstName, P006F2_A106EmployeeId
               }
               , new Object[] {
               P006F3_A106EmployeeId, P006F3_A107EmployeeFirstName
               }
               , new Object[] {
               P006F4_A103ProjectName, P006F4_A102ProjectId
               }
               , new Object[] {
               P006F5_A102ProjectId, P006F5_A103ProjectName
               }
               , new Object[] {
               P006F6_A158CompanyLocationName, P006F6_A157CompanyLocationId
               }
               , new Object[] {
               P006F7_A157CompanyLocationId, P006F7_A158CompanyLocationName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private short AV35GXLvl77 ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GXPagingFrom4 ;
      private int GXPagingTo4 ;
      private int AV34GXV1 ;
      private int GXPagingFrom6 ;
      private int GXPagingTo6 ;
      private long A106EmployeeId ;
      private long AV22EmployeeIdKey ;
      private long A102ProjectId ;
      private long AV26ProjectIdKey ;
      private long A157CompanyLocationId ;
      private long AV29CompanyLocationIdKey ;
      private string AV18TrnMode ;
      private string A107EmployeeFirstName ;
      private string A103ProjectName ;
      private string GXt_char1 ;
      private string A158CompanyLocationName ;
      private bool returnInSub ;
      private string AV20Combo_DataJson ;
      private string AV17ComboName ;
      private string AV19SearchTxtParms ;
      private string AV14SearchTxt ;
      private string lV14SearchTxt ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P006F2_A107EmployeeFirstName ;
      private long[] P006F2_A106EmployeeId ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private long[] P006F3_A106EmployeeId ;
      private string[] P006F3_A107EmployeeFirstName ;
      private string[] P006F4_A103ProjectName ;
      private long[] P006F4_A102ProjectId ;
      private GxSimpleCollection<long> AV27ProjectId ;
      private long[] P006F5_A102ProjectId ;
      private string[] P006F5_A103ProjectName ;
      private GxSimpleCollection<string> AV28SelectedTextCol ;
      private string[] P006F6_A158CompanyLocationName ;
      private long[] P006F6_A157CompanyLocationId ;
      private long[] P006F7_A157CompanyLocationId ;
      private string[] P006F7_A158CompanyLocationName ;
      private string aP3_Combo_DataJson ;
   }

   public class wpleavereportloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006F2( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A107EmployeeFirstName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " DISTINCT EmployeeFirstName, EmployeeId";
         sFromString = " FROM Employee";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(EmployeeFirstName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         sOrderString += " ORDER BY EmployeeFirstName";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P006F4( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A103ProjectName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " DISTINCT ProjectName, ProjectId";
         sFromString = " FROM Project";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(ProjectName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         sOrderString += " ORDER BY ProjectName";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom4" + " LIMIT CASE WHEN " + ":GXPagingTo4" + " > 0 THEN " + ":GXPagingTo4" + " ELSE 1e9 END";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P006F6( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A158CompanyLocationName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[4];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " DISTINCT CompanyLocationName, CompanyLocationId";
         sFromString = " FROM CompanyLocation";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(CompanyLocationName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         sOrderString += " ORDER BY CompanyLocationName";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom6" + " LIMIT CASE WHEN " + ":GXPagingTo6" + " > 0 THEN " + ":GXPagingTo6" + " ELSE 1e9 END";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006F2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 2 :
                     return conditional_P006F4(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 4 :
                     return conditional_P006F6(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006F3;
          prmP006F3 = new Object[] {
          new ParDef("AV22EmployeeIdKey",GXType.Int64,10,0)
          };
          Object[] prmP006F5;
          prmP006F5 = new Object[] {
          new ParDef("AV26ProjectIdKey",GXType.Int64,10,0)
          };
          Object[] prmP006F7;
          prmP006F7 = new Object[] {
          new ParDef("AV29CompanyLocationIdKey",GXType.Int64,10,0)
          };
          Object[] prmP006F2;
          prmP006F2 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP006F4;
          prmP006F4 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom4",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo4",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo4",GXType.Int32,9,0)
          };
          Object[] prmP006F6;
          prmP006F6 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom6",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo6",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo6",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006F2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006F3", "SELECT EmployeeId, EmployeeFirstName FROM Employee WHERE EmployeeId = :AV22EmployeeIdKey ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006F3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006F4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006F4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006F5", "SELECT ProjectId, ProjectName FROM Project WHERE ProjectId = :AV26ProjectIdKey ORDER BY ProjectId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006F5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006F6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006F6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006F7", "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation WHERE CompanyLocationId = :AV29CompanyLocationIdKey ORDER BY CompanyLocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006F7,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
