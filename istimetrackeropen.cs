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
   public class istimetrackeropen : GXProcedure
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
            return "istimetrackeropen_Services_Execute" ;
         }

      }

      public istimetrackeropen( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public istimetrackeropen( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out bool aP0_isOpen )
      {
         this.AV8isOpen = false ;
         initialize();
         ExecuteImpl();
         aP0_isOpen=this.AV8isOpen;
      }

      public bool executeUdp( )
      {
         execute(out aP0_isOpen);
         return AV8isOpen ;
      }

      public void executeSubmit( out bool aP0_isOpen )
      {
         this.AV8isOpen = false ;
         SubmitImpl();
         aP0_isOpen=this.AV8isOpen;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Udparg1 = new getloggedinusercompanyid(context).executeUdp( );
         /* Using cursor P008M2 */
         pr_default.execute(0, new Object[] {AV10Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P008M2_A100CompanyId[0];
            A161IsLogHourOpen = P008M2_A161IsLogHourOpen[0];
            A160SiteSettingId = P008M2_A160SiteSettingId[0];
            AV8isOpen = A161IsLogHourOpen;
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
         P008M2_A100CompanyId = new long[1] ;
         P008M2_A161IsLogHourOpen = new bool[] {false} ;
         P008M2_A160SiteSettingId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.istimetrackeropen__default(),
            new Object[][] {
                new Object[] {
               P008M2_A100CompanyId, P008M2_A161IsLogHourOpen, P008M2_A160SiteSettingId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV10Udparg1 ;
      private long A100CompanyId ;
      private long A160SiteSettingId ;
      private bool AV8isOpen ;
      private bool A161IsLogHourOpen ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P008M2_A100CompanyId ;
      private bool[] P008M2_A161IsLogHourOpen ;
      private long[] P008M2_A160SiteSettingId ;
      private bool aP0_isOpen ;
   }

   public class istimetrackeropen__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008M2;
          prmP008M2 = new Object[] {
          new ParDef("AV10Udparg1",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008M2", "SELECT CompanyId, IsLogHourOpen, SiteSettingId FROM SiteSetting WHERE CompanyId = :AV10Udparg1 ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008M2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
