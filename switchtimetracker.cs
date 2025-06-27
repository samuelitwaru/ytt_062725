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
   public class switchtimetracker : GXProcedure
   {
      public switchtimetracker( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public switchtimetracker( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( bool aP0_isSwtiched )
      {
         this.AV8isSwtiched = aP0_isSwtiched;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( bool aP0_isSwtiched )
      {
         this.AV8isSwtiched = aP0_isSwtiched;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9GXLvl1 = 0;
         AV10Udparg1 = new getloggedinusercompanyid(context).executeUdp( );
         /* Optimized UPDATE. */
         /* Using cursor P008L2 */
         pr_default.execute(0, new Object[] {AV8isSwtiched, AV10Udparg1});
         if ( (pr_default.getStatus(0) != 101) )
         {
            AV9GXLvl1 = 1;
         }
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("SiteSetting");
         /* End optimized UPDATE. */
         if ( AV9GXLvl1 == 0 )
         {
            /*
               INSERT RECORD ON TABLE SiteSetting

            */
            GXt_int1 = A100CompanyId;
            new getloggedinusercompanyid(context ).execute( out  GXt_int1) ;
            A100CompanyId = GXt_int1;
            A161IsLogHourOpen = AV8isSwtiched;
            /* Using cursor P008L3 */
            pr_default.execute(1, new Object[] {A100CompanyId, A161IsLogHourOpen});
            pr_default.close(1);
            /* Retrieving last key number assigned */
            /* Using cursor P008L4 */
            pr_default.execute(2);
            A160SiteSettingId = P008L4_A160SiteSettingId[0];
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("SiteSetting");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("switchtimetracker",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P008L4_A160SiteSettingId = new long[1] ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.switchtimetracker__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P008L4_A160SiteSettingId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9GXLvl1 ;
      private int GX_INS25 ;
      private long AV10Udparg1 ;
      private long A100CompanyId ;
      private long GXt_int1 ;
      private long A160SiteSettingId ;
      private string Gx_emsg ;
      private bool AV8isSwtiched ;
      private bool A161IsLogHourOpen ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P008L4_A160SiteSettingId ;
   }

   public class switchtimetracker__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008L2;
          prmP008L2 = new Object[] {
          new ParDef("IsLogHourOpen",GXType.Boolean,4,0) ,
          new ParDef("AV10Udparg1",GXType.Int64,10,0)
          };
          Object[] prmP008L3;
          prmP008L3 = new Object[] {
          new ParDef("CompanyId",GXType.Int64,10,0) ,
          new ParDef("IsLogHourOpen",GXType.Boolean,4,0)
          };
          Object[] prmP008L4;
          prmP008L4 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P008L2", "UPDATE SiteSetting SET IsLogHourOpen=:IsLogHourOpen  WHERE CompanyId = :AV10Udparg1", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP008L2)
             ,new CursorDef("P008L3", "SAVEPOINT gxupdate;INSERT INTO SiteSetting(CompanyId, IsLogHourOpen) VALUES(:CompanyId, :IsLogHourOpen);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP008L3)
             ,new CursorDef("P008L4", "SELECT currval('SiteSettingId') ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008L4,1, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
