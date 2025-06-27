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
   public class webpanel1loaddvcombo : GXProcedure
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
            return "webpanel1_Services_Execute" ;
         }

      }

      public webpanel1loaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public webpanel1loaddvcombo( IGxContext context )
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
         if ( StringUtil.StrCmp(AV17ComboName, "ProjectId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PROJECTID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "EmployeeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_EMPLOYEEID' */
            S121 ();
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
         /* 'LOADCOMBOITEMS_PROJECTID' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") != 0 )
         {
            GXPagingFrom2 = AV12SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A103ProjectName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P006E2 */
            pr_default.execute(0, new Object[] {lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A103ProjectName = P006E2_A103ProjectName[0];
               A102ProjectId = P006E2_A102ProjectId[0];
               AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A102ProjectId), 10, 0));
               AV16Combo_DataItem.gxTpr_Title = A103ProjectName;
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
            AV22ProjectIdKey = (long)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
            /* Using cursor P006E3 */
            pr_default.execute(1, new Object[] {AV22ProjectIdKey});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A102ProjectId = P006E3_A102ProjectId[0];
               A103ProjectName = P006E3_A103ProjectName[0];
               AV20Combo_DataJson = A103ProjectName;
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
         /* 'LOADCOMBOITEMS_EMPLOYEEID' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") != 0 )
         {
            GXPagingFrom4 = AV12SkipItems;
            GXPagingTo4 = AV11MaxItems;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A107EmployeeFirstName } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P006E4 */
            pr_default.execute(2, new Object[] {lV14SearchTxt, GXPagingFrom4, GXPagingTo4, GXPagingTo4});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A107EmployeeFirstName = P006E4_A107EmployeeFirstName[0];
               A106EmployeeId = P006E4_A106EmployeeId[0];
               AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0));
               AV16Combo_DataItem.gxTpr_Title = A107EmployeeFirstName;
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
            AV24EmployeeIdKey = (long)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
            /* Using cursor P006E5 */
            pr_default.execute(3, new Object[] {AV24EmployeeIdKey});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A106EmployeeId = P006E5_A106EmployeeId[0];
               A107EmployeeFirstName = P006E5_A107EmployeeFirstName[0];
               AV20Combo_DataJson = A107EmployeeFirstName;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
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
         A103ProjectName = "";
         P006E2_A103ProjectName = new string[] {""} ;
         P006E2_A102ProjectId = new long[1] ;
         AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P006E3_A102ProjectId = new long[1] ;
         P006E3_A103ProjectName = new string[] {""} ;
         A107EmployeeFirstName = "";
         P006E4_A107EmployeeFirstName = new string[] {""} ;
         P006E4_A106EmployeeId = new long[1] ;
         P006E5_A106EmployeeId = new long[1] ;
         P006E5_A107EmployeeFirstName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.webpanel1loaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006E2_A103ProjectName, P006E2_A102ProjectId
               }
               , new Object[] {
               P006E3_A102ProjectId, P006E3_A103ProjectName
               }
               , new Object[] {
               P006E4_A107EmployeeFirstName, P006E4_A106EmployeeId
               }
               , new Object[] {
               P006E5_A106EmployeeId, P006E5_A107EmployeeFirstName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GXPagingFrom4 ;
      private int GXPagingTo4 ;
      private long A102ProjectId ;
      private long AV22ProjectIdKey ;
      private long A106EmployeeId ;
      private long AV24EmployeeIdKey ;
      private string AV18TrnMode ;
      private string A103ProjectName ;
      private string A107EmployeeFirstName ;
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
      private string[] P006E2_A103ProjectName ;
      private long[] P006E2_A102ProjectId ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private long[] P006E3_A102ProjectId ;
      private string[] P006E3_A103ProjectName ;
      private string[] P006E4_A107EmployeeFirstName ;
      private long[] P006E4_A106EmployeeId ;
      private long[] P006E5_A106EmployeeId ;
      private string[] P006E5_A107EmployeeFirstName ;
      private string aP3_Combo_DataJson ;
   }

   public class webpanel1loaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006E2( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A103ProjectName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
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
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY ProjectName";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006E4( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A107EmployeeFirstName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
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
            GXv_int3[0] = 1;
         }
         sOrderString += " ORDER BY EmployeeFirstName";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom4" + " LIMIT CASE WHEN " + ":GXPagingTo4" + " > 0 THEN " + ":GXPagingTo4" + " ELSE 1e9 END";
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
                     return conditional_P006E2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 2 :
                     return conditional_P006E4(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP006E3;
          prmP006E3 = new Object[] {
          new ParDef("AV22ProjectIdKey",GXType.Int64,10,0)
          };
          Object[] prmP006E5;
          prmP006E5 = new Object[] {
          new ParDef("AV24EmployeeIdKey",GXType.Int64,10,0)
          };
          Object[] prmP006E2;
          prmP006E2 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP006E4;
          prmP006E4 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom4",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo4",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo4",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006E2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006E3", "SELECT ProjectId, ProjectName FROM Project WHERE ProjectId = :AV22ProjectIdKey ORDER BY ProjectId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006E3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006E4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006E4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006E5", "SELECT EmployeeId, EmployeeFirstName FROM Employee WHERE EmployeeId = :AV24EmployeeIdKey ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006E5,1, GxCacheFrequency.OFF ,false,true )
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
       }
    }

 }

}
