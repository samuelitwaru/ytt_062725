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
   public class workhourlogloaddvcombo : GXProcedure
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
            return "workhourlog_Services_Execute" ;
         }

      }

      public workhourlogloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workhourlogloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           long aP3_WorkHourLogId ,
                           long aP4_Cond_EmployeeId ,
                           string aP5_SearchTxtParms ,
                           out string aP6_SelectedValue ,
                           out string aP7_SelectedText ,
                           out string aP8_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20WorkHourLogId = aP3_WorkHourLogId;
         this.AV29Cond_EmployeeId = aP4_Cond_EmployeeId;
         this.AV21SearchTxtParms = aP5_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP6_SelectedValue=this.AV22SelectedValue;
         aP7_SelectedText=this.AV23SelectedText;
         aP8_Combo_DataJson=this.AV24Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                long aP3_WorkHourLogId ,
                                long aP4_Cond_EmployeeId ,
                                string aP5_SearchTxtParms ,
                                out string aP6_SelectedValue ,
                                out string aP7_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_WorkHourLogId, aP4_Cond_EmployeeId, aP5_SearchTxtParms, out aP6_SelectedValue, out aP7_SelectedText, out aP8_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 long aP3_WorkHourLogId ,
                                 long aP4_Cond_EmployeeId ,
                                 string aP5_SearchTxtParms ,
                                 out string aP6_SelectedValue ,
                                 out string aP7_SelectedText ,
                                 out string aP8_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20WorkHourLogId = aP3_WorkHourLogId;
         this.AV29Cond_EmployeeId = aP4_Cond_EmployeeId;
         this.AV21SearchTxtParms = aP5_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         SubmitImpl();
         aP6_SelectedValue=this.AV22SelectedValue;
         aP7_SelectedText=this.AV23SelectedText;
         aP8_Combo_DataJson=this.AV24Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11MaxItems = 10;
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV21SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? AV21SearchTxtParms : StringUtil.Substring( AV21SearchTxtParms, 3, -1));
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
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_EMPLOYEEID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
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
            /* Using cursor P006C2 */
            pr_default.execute(0, new Object[] {lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A107EmployeeFirstName = P006C2_A107EmployeeFirstName[0];
               A106EmployeeId = P006C2_A106EmployeeId[0];
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
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P006C3 */
                  pr_default.execute(1, new Object[] {AV20WorkHourLogId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A118WorkHourLogId = P006C3_A118WorkHourLogId[0];
                     A106EmployeeId = P006C3_A106EmployeeId[0];
                     A107EmployeeFirstName = P006C3_A107EmployeeFirstName[0];
                     A107EmployeeFirstName = P006C3_A107EmployeeFirstName[0];
                     AV22SelectedValue = ((0==A106EmployeeId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0)));
                     AV23SelectedText = A107EmployeeFirstName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV28EmployeeId = (long)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P006C4 */
                  pr_default.execute(2, new Object[] {AV28EmployeeId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A106EmployeeId = P006C4_A106EmployeeId[0];
                     A107EmployeeFirstName = P006C4_A107EmployeeFirstName[0];
                     AV23SelectedText = A107EmployeeFirstName;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_PROJECTID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom5 = AV12SkipItems;
            GXPagingTo5 = AV11MaxItems;
            /* Using cursor P006C5 */
            pr_default.execute(3, new Object[] {AV29Cond_EmployeeId, GXPagingFrom5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A106EmployeeId = P006C5_A106EmployeeId[0];
               A102ProjectId = P006C5_A102ProjectId[0];
               A184EmployeeIsActiveInProject = P006C5_A184EmployeeIsActiveInProject[0];
               AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A102ProjectId), 10, 0));
               AV16Combo_DataItem.gxTpr_Title = StringUtil.Trim( StringUtil.BoolToStr( A184EmployeeIsActiveInProject));
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P006C6 */
                  pr_default.execute(4, new Object[] {AV20WorkHourLogId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A106EmployeeId = P006C6_A106EmployeeId[0];
                     A162ProjectManagerId = P006C6_A162ProjectManagerId[0];
                     n162ProjectManagerId = P006C6_n162ProjectManagerId[0];
                     A118WorkHourLogId = P006C6_A118WorkHourLogId[0];
                     A102ProjectId = P006C6_A102ProjectId[0];
                     A184EmployeeIsActiveInProject = P006C6_A184EmployeeIsActiveInProject[0];
                     A162ProjectManagerId = P006C6_A162ProjectManagerId[0];
                     n162ProjectManagerId = P006C6_n162ProjectManagerId[0];
                     A184EmployeeIsActiveInProject = P006C6_A184EmployeeIsActiveInProject[0];
                     /* Using cursor P006C7 */
                     pr_default.execute(5, new Object[] {n162ProjectManagerId, A162ProjectManagerId, A102ProjectId});
                     A184EmployeeIsActiveInProject = P006C7_A184EmployeeIsActiveInProject[0];
                     pr_default.close(5);
                     AV22SelectedValue = ((0==A102ProjectId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A102ProjectId), 10, 0)));
                     AV23SelectedText = StringUtil.Trim( StringUtil.BoolToStr( A184EmployeeIsActiveInProject));
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV30ProjectId = (long)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P006C8 */
                  pr_default.execute(6, new Object[] {AV29Cond_EmployeeId, AV30ProjectId});
                  while ( (pr_default.getStatus(6) != 101) )
                  {
                     A106EmployeeId = P006C8_A106EmployeeId[0];
                     A102ProjectId = P006C8_A102ProjectId[0];
                     A184EmployeeIsActiveInProject = P006C8_A184EmployeeIsActiveInProject[0];
                     AV23SelectedText = StringUtil.Trim( StringUtil.BoolToStr( A184EmployeeIsActiveInProject));
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(6);
               }
            }
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

      protected override void CloseCursors( )
      {
         pr_default.close(5);
      }

      public override void initialize( )
      {
         AV22SelectedValue = "";
         AV23SelectedText = "";
         AV24Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         lV14SearchTxt = "";
         A107EmployeeFirstName = "";
         P006C2_A107EmployeeFirstName = new string[] {""} ;
         P006C2_A106EmployeeId = new long[1] ;
         AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P006C3_A118WorkHourLogId = new long[1] ;
         P006C3_A106EmployeeId = new long[1] ;
         P006C3_A107EmployeeFirstName = new string[] {""} ;
         P006C4_A106EmployeeId = new long[1] ;
         P006C4_A107EmployeeFirstName = new string[] {""} ;
         P006C5_A106EmployeeId = new long[1] ;
         P006C5_A102ProjectId = new long[1] ;
         P006C5_A184EmployeeIsActiveInProject = new bool[] {false} ;
         P006C6_A106EmployeeId = new long[1] ;
         P006C6_A162ProjectManagerId = new long[1] ;
         P006C6_n162ProjectManagerId = new bool[] {false} ;
         P006C6_A118WorkHourLogId = new long[1] ;
         P006C6_A102ProjectId = new long[1] ;
         P006C6_A184EmployeeIsActiveInProject = new bool[] {false} ;
         P006C7_A184EmployeeIsActiveInProject = new bool[] {false} ;
         P006C8_A106EmployeeId = new long[1] ;
         P006C8_A102ProjectId = new long[1] ;
         P006C8_A184EmployeeIsActiveInProject = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workhourlogloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006C2_A107EmployeeFirstName, P006C2_A106EmployeeId
               }
               , new Object[] {
               P006C3_A118WorkHourLogId, P006C3_A106EmployeeId, P006C3_A107EmployeeFirstName
               }
               , new Object[] {
               P006C4_A106EmployeeId, P006C4_A107EmployeeFirstName
               }
               , new Object[] {
               P006C5_A106EmployeeId, P006C5_A102ProjectId, P006C5_A184EmployeeIsActiveInProject
               }
               , new Object[] {
               P006C6_A106EmployeeId, P006C6_A162ProjectManagerId, P006C6_n162ProjectManagerId, P006C6_A118WorkHourLogId, P006C6_A102ProjectId, P006C6_A184EmployeeIsActiveInProject
               }
               , new Object[] {
               P006C7_A184EmployeeIsActiveInProject
               }
               , new Object[] {
               P006C8_A106EmployeeId, P006C8_A102ProjectId, P006C8_A184EmployeeIsActiveInProject
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
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private long AV20WorkHourLogId ;
      private long AV29Cond_EmployeeId ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private long AV28EmployeeId ;
      private long A102ProjectId ;
      private long A162ProjectManagerId ;
      private long AV30ProjectId ;
      private string AV18TrnMode ;
      private string A107EmployeeFirstName ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private bool A184EmployeeIsActiveInProject ;
      private bool n162ProjectManagerId ;
      private string AV24Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21SearchTxtParms ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string AV14SearchTxt ;
      private string lV14SearchTxt ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P006C2_A107EmployeeFirstName ;
      private long[] P006C2_A106EmployeeId ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private long[] P006C3_A118WorkHourLogId ;
      private long[] P006C3_A106EmployeeId ;
      private string[] P006C3_A107EmployeeFirstName ;
      private long[] P006C4_A106EmployeeId ;
      private string[] P006C4_A107EmployeeFirstName ;
      private long[] P006C5_A106EmployeeId ;
      private long[] P006C5_A102ProjectId ;
      private bool[] P006C5_A184EmployeeIsActiveInProject ;
      private long[] P006C6_A106EmployeeId ;
      private long[] P006C6_A162ProjectManagerId ;
      private bool[] P006C6_n162ProjectManagerId ;
      private long[] P006C6_A118WorkHourLogId ;
      private long[] P006C6_A102ProjectId ;
      private bool[] P006C6_A184EmployeeIsActiveInProject ;
      private bool[] P006C7_A184EmployeeIsActiveInProject ;
      private long[] P006C8_A106EmployeeId ;
      private long[] P006C8_A102ProjectId ;
      private bool[] P006C8_A184EmployeeIsActiveInProject ;
      private string aP6_SelectedValue ;
      private string aP7_SelectedText ;
      private string aP8_Combo_DataJson ;
   }

   public class workhourlogloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006C2( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A107EmployeeFirstName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " EmployeeFirstName, EmployeeId";
         sFromString = " FROM Employee";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(EmployeeFirstName like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY EmployeeFirstName, EmployeeId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
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
                     return conditional_P006C2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
         ,new ForEachCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006C3;
          prmP006C3 = new Object[] {
          new ParDef("AV20WorkHourLogId",GXType.Int64,10,0)
          };
          Object[] prmP006C4;
          prmP006C4 = new Object[] {
          new ParDef("AV28EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP006C5;
          prmP006C5 = new Object[] {
          new ParDef("AV29Cond_EmployeeId",GXType.Int64,10,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          Object[] prmP006C6;
          prmP006C6 = new Object[] {
          new ParDef("AV20WorkHourLogId",GXType.Int64,10,0)
          };
          Object[] prmP006C7;
          prmP006C7 = new Object[] {
          new ParDef("ProjectManagerId",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("ProjectId",GXType.Int64,10,0)
          };
          Object[] prmP006C8;
          prmP006C8 = new Object[] {
          new ParDef("AV29Cond_EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV30ProjectId",GXType.Int64,10,0)
          };
          Object[] prmP006C2;
          prmP006C2 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006C3", "SELECT T1.WorkHourLogId, T1.EmployeeId, T2.EmployeeFirstName FROM (WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) WHERE T1.WorkHourLogId = :AV20WorkHourLogId ORDER BY T1.WorkHourLogId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006C4", "SELECT EmployeeId, EmployeeFirstName FROM Employee WHERE EmployeeId = :AV28EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006C5", "SELECT EmployeeId, ProjectId, EmployeeIsActiveInProject FROM EmployeeProject WHERE EmployeeId = :AV29Cond_EmployeeId ORDER BY EmployeeIsActiveInProject, EmployeeId, ProjectId  OFFSET :GXPagingFrom5 LIMIT CASE WHEN :GXPagingTo5 > 0 THEN :GXPagingTo5 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006C6", "SELECT T1.EmployeeId, T2.ProjectManagerId, T1.WorkHourLogId, T1.ProjectId, T3.EmployeeIsActiveInProject FROM ((WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) INNER JOIN EmployeeProject T3 ON T3.EmployeeId = T1.EmployeeId AND T3.ProjectId = T1.ProjectId) WHERE T1.WorkHourLogId = :AV20WorkHourLogId ORDER BY T1.WorkHourLogId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006C7", "SELECT EmployeeIsActiveInProject FROM EmployeeProject WHERE EmployeeId = :ProjectManagerId AND ProjectId = :ProjectId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P006C8", "SELECT EmployeeId, ProjectId, EmployeeIsActiveInProject FROM EmployeeProject WHERE EmployeeId = :AV29Cond_EmployeeId and ProjectId = :AV30ProjectId ORDER BY EmployeeId, ProjectId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C8,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((bool[]) buf[5])[0] = rslt.getBool(5);
                return;
             case 5 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
       }
    }

 }

}
