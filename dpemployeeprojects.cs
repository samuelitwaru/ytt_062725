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
   public class dpemployeeprojects : GXProcedure
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

      public dpemployeeprojects( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpemployeeprojects( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           out GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> aP1_Gxm2rootcol )
      {
         this.AV5EmployeeId = aP0_EmployeeId;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem>( context, "SDTEmployeeProjectItem", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> executeUdp( long aP0_EmployeeId )
      {
         execute(aP0_EmployeeId, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 out GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> aP1_Gxm2rootcol )
      {
         this.AV5EmployeeId = aP0_EmployeeId;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem>( context, "SDTEmployeeProjectItem", "YTT_version4") ;
         SubmitImpl();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00112 */
         pr_default.execute(0, new Object[] {AV5EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00112_A106EmployeeId[0];
            A105ProjectStatus = P00112_A105ProjectStatus[0];
            A102ProjectId = P00112_A102ProjectId[0];
            A103ProjectName = P00112_A103ProjectName[0];
            A104ProjectDescription = P00112_A104ProjectDescription[0];
            A105ProjectStatus = P00112_A105ProjectStatus[0];
            A103ProjectName = P00112_A103ProjectName[0];
            A104ProjectDescription = P00112_A104ProjectDescription[0];
            Gxm1sdtemployeeproject = new SdtSDTEmployeeProject_SDTEmployeeProjectItem(context);
            Gxm2rootcol.Add(Gxm1sdtemployeeproject, 0);
            Gxm1sdtemployeeproject.gxTpr_Projectid = A102ProjectId;
            Gxm1sdtemployeeproject.gxTpr_Projectname = A103ProjectName;
            Gxm1sdtemployeeproject.gxTpr_Projectdescription = A104ProjectDescription;
            Gxm1sdtemployeeproject.gxTpr_Projectstatus = A105ProjectStatus;
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
         P00112_A106EmployeeId = new long[1] ;
         P00112_A105ProjectStatus = new string[] {""} ;
         P00112_A102ProjectId = new long[1] ;
         P00112_A103ProjectName = new string[] {""} ;
         P00112_A104ProjectDescription = new string[] {""} ;
         A105ProjectStatus = "";
         A103ProjectName = "";
         A104ProjectDescription = "";
         Gxm1sdtemployeeproject = new SdtSDTEmployeeProject_SDTEmployeeProjectItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpemployeeprojects__default(),
            new Object[][] {
                new Object[] {
               P00112_A106EmployeeId, P00112_A105ProjectStatus, P00112_A102ProjectId, P00112_A103ProjectName, P00112_A104ProjectDescription
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV5EmployeeId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private string A105ProjectStatus ;
      private string A103ProjectName ;
      private string A104ProjectDescription ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private long[] P00112_A106EmployeeId ;
      private string[] P00112_A105ProjectStatus ;
      private long[] P00112_A102ProjectId ;
      private string[] P00112_A103ProjectName ;
      private string[] P00112_A104ProjectDescription ;
      private SdtSDTEmployeeProject_SDTEmployeeProjectItem Gxm1sdtemployeeproject ;
      private GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> aP1_Gxm2rootcol ;
   }

   public class dpemployeeprojects__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00112;
          prmP00112 = new Object[] {
          new ParDef("AV5EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00112", "SELECT T1.EmployeeId, T2.ProjectStatus, T1.ProjectId, T2.ProjectName, T2.ProjectDescription FROM (EmployeeProject T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) WHERE (T1.EmployeeId = :AV5EmployeeId) AND (T2.ProjectStatus = ( 'Active')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00112,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
