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
   public class dpleavetype : GXProcedure
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

      public dpleavetype( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpleavetype( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_CompanyLocationId ,
                           bool aP1_IsColored ,
                           out GXBaseCollection<SdtSDTLeaveType> aP2_Gxm2rootcol )
      {
         this.AV6CompanyLocationId = aP0_CompanyLocationId;
         this.AV7IsColored = aP1_IsColored;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTLeaveType>( context, "SDTLeaveType", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP2_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTLeaveType> executeUdp( long aP0_CompanyLocationId ,
                                                           bool aP1_IsColored )
      {
         execute(aP0_CompanyLocationId, aP1_IsColored, out aP2_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( long aP0_CompanyLocationId ,
                                 bool aP1_IsColored ,
                                 out GXBaseCollection<SdtSDTLeaveType> aP2_Gxm2rootcol )
      {
         this.AV6CompanyLocationId = aP0_CompanyLocationId;
         this.AV7IsColored = aP1_IsColored;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTLeaveType>( context, "SDTLeaveType", "YTT_version4") ;
         SubmitImpl();
         aP2_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV7IsColored ,
                                              A173LeaveTypeColorApproved ,
                                              AV6CompanyLocationId ,
                                              A100CompanyId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P00162 */
         pr_default.execute(0, new Object[] {AV6CompanyLocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A173LeaveTypeColorApproved = P00162_A173LeaveTypeColorApproved[0];
            n173LeaveTypeColorApproved = P00162_n173LeaveTypeColorApproved[0];
            A100CompanyId = P00162_A100CompanyId[0];
            A124LeaveTypeId = P00162_A124LeaveTypeId[0];
            A125LeaveTypeName = P00162_A125LeaveTypeName[0];
            A144LeaveTypeVacationLeave = P00162_A144LeaveTypeVacationLeave[0];
            A145LeaveTypeLoggingWorkHours = P00162_A145LeaveTypeLoggingWorkHours[0];
            A172LeaveTypeColorPending = P00162_A172LeaveTypeColorPending[0];
            n172LeaveTypeColorPending = P00162_n172LeaveTypeColorPending[0];
            Gxm1sdtleavetype = new SdtSDTLeaveType(context);
            Gxm2rootcol.Add(Gxm1sdtleavetype, 0);
            Gxm1sdtleavetype.gxTpr_Leavetypeid = A124LeaveTypeId;
            Gxm1sdtleavetype.gxTpr_Leavetypename = A125LeaveTypeName;
            Gxm1sdtleavetype.gxTpr_Leavetypevacationleave = A144LeaveTypeVacationLeave;
            Gxm1sdtleavetype.gxTpr_Leavetypeloggingworkhours = A145LeaveTypeLoggingWorkHours;
            Gxm1sdtleavetype.gxTpr_Leavetypecolorpending = A172LeaveTypeColorPending;
            Gxm1sdtleavetype.gxTpr_Leavetypecolorapproved = A173LeaveTypeColorApproved;
            Gxm1sdtleavetype.gxTpr_Companyid = A100CompanyId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
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
         A173LeaveTypeColorApproved = "";
         P00162_A173LeaveTypeColorApproved = new string[] {""} ;
         P00162_n173LeaveTypeColorApproved = new bool[] {false} ;
         P00162_A100CompanyId = new long[1] ;
         P00162_A124LeaveTypeId = new long[1] ;
         P00162_A125LeaveTypeName = new string[] {""} ;
         P00162_A144LeaveTypeVacationLeave = new string[] {""} ;
         P00162_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         P00162_A172LeaveTypeColorPending = new string[] {""} ;
         P00162_n172LeaveTypeColorPending = new bool[] {false} ;
         A125LeaveTypeName = "";
         A144LeaveTypeVacationLeave = "";
         A145LeaveTypeLoggingWorkHours = "";
         A172LeaveTypeColorPending = "";
         Gxm1sdtleavetype = new SdtSDTLeaveType(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpleavetype__default(),
            new Object[][] {
                new Object[] {
               P00162_A173LeaveTypeColorApproved, P00162_n173LeaveTypeColorApproved, P00162_A100CompanyId, P00162_A124LeaveTypeId, P00162_A125LeaveTypeName, P00162_A144LeaveTypeVacationLeave, P00162_A145LeaveTypeLoggingWorkHours, P00162_A172LeaveTypeColorPending, P00162_n172LeaveTypeColorPending
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV6CompanyLocationId ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private string A173LeaveTypeColorApproved ;
      private string A125LeaveTypeName ;
      private string A144LeaveTypeVacationLeave ;
      private string A145LeaveTypeLoggingWorkHours ;
      private string A172LeaveTypeColorPending ;
      private bool AV7IsColored ;
      private bool n173LeaveTypeColorApproved ;
      private bool n172LeaveTypeColorPending ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTLeaveType> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private string[] P00162_A173LeaveTypeColorApproved ;
      private bool[] P00162_n173LeaveTypeColorApproved ;
      private long[] P00162_A100CompanyId ;
      private long[] P00162_A124LeaveTypeId ;
      private string[] P00162_A125LeaveTypeName ;
      private string[] P00162_A144LeaveTypeVacationLeave ;
      private string[] P00162_A145LeaveTypeLoggingWorkHours ;
      private string[] P00162_A172LeaveTypeColorPending ;
      private bool[] P00162_n172LeaveTypeColorPending ;
      private SdtSDTLeaveType Gxm1sdtleavetype ;
      private GXBaseCollection<SdtSDTLeaveType> aP2_Gxm2rootcol ;
   }

   public class dpleavetype__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00162( IGxContext context ,
                                             bool AV7IsColored ,
                                             string A173LeaveTypeColorApproved ,
                                             long AV6CompanyLocationId ,
                                             long A100CompanyId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT LeaveTypeColorApproved, CompanyId, LeaveTypeId, LeaveTypeName, LeaveTypeVacationLeave, LeaveTypeLoggingWorkHours, LeaveTypeColorPending FROM LeaveType";
         AddWhere(sWhereString, "(CompanyId = :AV6CompanyLocationId)");
         if ( AV7IsColored )
         {
            AddWhere(sWhereString, "(Not (char_length(trim(trailing ' ' from LeaveTypeColorApproved))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CompanyId";
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
                     return conditional_P00162(context, (bool)dynConstraints[0] , (string)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] );
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
          Object[] prmP00162;
          prmP00162 = new Object[] {
          new ParDef("AV6CompanyLocationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00162", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00162,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 100);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
