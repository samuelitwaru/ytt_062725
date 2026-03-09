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
   public class projectloaddvcombo : GXProcedure
   {
      public projectloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public projectloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           long aP2_ProjectId ,
                           out string aP3_SelectedValue ,
                           out string aP4_SelectedText ,
                           out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP5_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15ProjectId = aP2_ProjectId;
         this.AV16SelectedValue = "" ;
         this.AV17SelectedText = "" ;
         this.AV11Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecuteImpl();
         aP3_SelectedValue=this.AV16SelectedValue;
         aP4_SelectedText=this.AV17SelectedText;
         aP5_Combo_Data=this.AV11Combo_Data;
      }

      public GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                  string aP1_TrnMode ,
                                                                                                  long aP2_ProjectId ,
                                                                                                  out string aP3_SelectedValue ,
                                                                                                  out string aP4_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_ProjectId, out aP3_SelectedValue, out aP4_SelectedText, out aP5_Combo_Data);
         return AV11Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 long aP2_ProjectId ,
                                 out string aP3_SelectedValue ,
                                 out string aP4_SelectedText ,
                                 out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP5_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15ProjectId = aP2_ProjectId;
         this.AV16SelectedValue = "" ;
         this.AV17SelectedText = "" ;
         this.AV11Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         SubmitImpl();
         aP3_SelectedValue=this.AV16SelectedValue;
         aP4_SelectedText=this.AV17SelectedText;
         aP5_Combo_Data=this.AV11Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV23ProjectIds.Add(AV15ProjectId, 0);
         new getemployeeidsbyproject(context ).execute(  AV23ProjectIds, out  AV22EmployeeIds) ;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         if ( StringUtil.StrCmp(AV13ComboName, "EmployeeId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_EMPLOYEEID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV13ComboName, "ProjectManagerId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PROJECTMANAGERID' */
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
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV22EmployeeIds } ,
                                              new int[]{
                                              TypeConstants.LONG
                                              }
         });
         /* Using cursor P00A32 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00A32_A106EmployeeId[0];
            A148EmployeeName = P00A32_A148EmployeeName[0];
            AV12Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0));
            AV12Combo_DataItem.gxTpr_Title = A148EmployeeName;
            AV11Combo_Data.Add(AV12Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_PROJECTMANAGERID' Routine */
         returnInSub = false;
         /* Using cursor P00A33 */
         pr_default.execute(1, new Object[] {AV15ProjectId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A102ProjectId = P00A33_A102ProjectId[0];
            A106EmployeeId = P00A33_A106EmployeeId[0];
            AV22EmployeeIds.Add(A106EmployeeId, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV27GXV2 = 1;
         GXt_objcol_SdtSDTEmployee1 = AV26GXV1;
         new dpemployeesbyproject(context ).execute(  AV22EmployeeIds, out  GXt_objcol_SdtSDTEmployee1) ;
         AV26GXV1 = GXt_objcol_SdtSDTEmployee1;
         while ( AV27GXV2 <= AV26GXV1.Count )
         {
            AV20ProjectManagerId_DPItem = ((SdtSDTEmployee)AV26GXV1.Item(AV27GXV2));
            AV12Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ProjectManagerId_DPItem.gxTpr_Employeeid), 10, 0));
            AV12Combo_DataItem.gxTpr_Title = AV20ProjectManagerId_DPItem.gxTpr_Employeename;
            AV11Combo_Data.Add(AV12Combo_DataItem, 0);
            AV27GXV2 = (int)(AV27GXV2+1);
         }
         AV11Combo_Data.Sort("Title");
         if ( StringUtil.StrCmp(AV14TrnMode, "INS") != 0 )
         {
            /* Using cursor P00A34 */
            pr_default.execute(2, new Object[] {AV15ProjectId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A102ProjectId = P00A34_A102ProjectId[0];
               A162ProjectManagerId = P00A34_A162ProjectManagerId[0];
               n162ProjectManagerId = P00A34_n162ProjectManagerId[0];
               AV16SelectedValue = ((0==A162ProjectManagerId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A162ProjectManagerId), 10, 0)));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            if ( StringUtil.StrCmp(AV14TrnMode, "GET_DSC") == 0 )
            {
               AV29GXV3 = 1;
               while ( AV29GXV3 <= AV11Combo_Data.Count )
               {
                  AV12Combo_DataItem = ((WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item)AV11Combo_Data.Item(AV29GXV3));
                  if ( StringUtil.StrCmp(AV12Combo_DataItem.gxTpr_Id, AV16SelectedValue) == 0 )
                  {
                     AV17SelectedText = AV12Combo_DataItem.gxTpr_Title;
                     if (true) break;
                  }
                  AV29GXV3 = (int)(AV29GXV3+1);
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

      public override void initialize( )
      {
         AV16SelectedValue = "";
         AV17SelectedText = "";
         AV11Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV23ProjectIds = new GxSimpleCollection<long>();
         AV22EmployeeIds = new GxSimpleCollection<long>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00A32_A106EmployeeId = new long[1] ;
         P00A32_A148EmployeeName = new string[] {""} ;
         A148EmployeeName = "";
         AV12Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         P00A33_A102ProjectId = new long[1] ;
         P00A33_A106EmployeeId = new long[1] ;
         AV26GXV1 = new GXBaseCollection<SdtSDTEmployee>( context, "SDTEmployee", "YTT_version4");
         GXt_objcol_SdtSDTEmployee1 = new GXBaseCollection<SdtSDTEmployee>( context, "SDTEmployee", "YTT_version4");
         AV20ProjectManagerId_DPItem = new SdtSDTEmployee(context);
         P00A34_A102ProjectId = new long[1] ;
         P00A34_A162ProjectManagerId = new long[1] ;
         P00A34_n162ProjectManagerId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.projectloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00A32_A106EmployeeId, P00A32_A148EmployeeName
               }
               , new Object[] {
               P00A33_A102ProjectId, P00A33_A106EmployeeId
               }
               , new Object[] {
               P00A34_A102ProjectId, P00A34_A162ProjectManagerId, P00A34_n162ProjectManagerId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV27GXV2 ;
      private int AV29GXV3 ;
      private long AV15ProjectId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A162ProjectManagerId ;
      private string AV14TrnMode ;
      private string A148EmployeeName ;
      private bool returnInSub ;
      private bool n162ProjectManagerId ;
      private string AV13ComboName ;
      private string AV16SelectedValue ;
      private string AV17SelectedText ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV11Combo_Data ;
      private GxSimpleCollection<long> AV23ProjectIds ;
      private GxSimpleCollection<long> AV22EmployeeIds ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private long[] P00A32_A106EmployeeId ;
      private string[] P00A32_A148EmployeeName ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV12Combo_DataItem ;
      private long[] P00A33_A102ProjectId ;
      private long[] P00A33_A106EmployeeId ;
      private GXBaseCollection<SdtSDTEmployee> AV26GXV1 ;
      private GXBaseCollection<SdtSDTEmployee> GXt_objcol_SdtSDTEmployee1 ;
      private SdtSDTEmployee AV20ProjectManagerId_DPItem ;
      private long[] P00A34_A102ProjectId ;
      private long[] P00A34_A162ProjectManagerId ;
      private bool[] P00A34_n162ProjectManagerId ;
      private string aP3_SelectedValue ;
      private string aP4_SelectedText ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> aP5_Combo_Data ;
   }

   public class projectloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00A32( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV22EmployeeIds )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT EmployeeId, EmployeeName FROM Employee";
         AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV22EmployeeIds, "EmployeeId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmployeeName";
         GXv_Object2[0] = scmdbuf;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00A32(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00A33;
          prmP00A33 = new Object[] {
          new ParDef("AV15ProjectId",GXType.Int64,10,0)
          };
          Object[] prmP00A34;
          prmP00A34 = new Object[] {
          new ParDef("AV15ProjectId",GXType.Int64,10,0)
          };
          Object[] prmP00A32;
          prmP00A32 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00A32", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A32,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00A33", "SELECT ProjectId, EmployeeId FROM EmployeeProject WHERE ProjectId = :AV15ProjectId ORDER BY ProjectId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A33,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00A34", "SELECT ProjectId, ProjectManagerId FROM Project WHERE ProjectId = :AV15ProjectId ORDER BY ProjectId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A34,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
