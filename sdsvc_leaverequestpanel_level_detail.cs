using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class sdsvc_leaverequestpanel_level_detail : GXProcedure
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
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public sdsvc_leaverequestpanel_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public sdsvc_leaverequestpanel_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
      }

      public GxJsonArray LeaveTypeId_DL( )
      {
         initialize();
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor SDSVC_LEAV2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            if ( SDSVC_LEAV2_A100CompanyId[0] == new getloggedinusercompanyid(context).executeUdp( ) )
            {
               gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(SDSVC_LEAV2_A124LeaveTypeId[0]), 10, 0, ".", "")));
               gxdynajaxctrldescr.Add(StringUtil.RTrim( SDSVC_LEAV2_A125LeaveTypeName[0]));
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
         return GXUtil.StringCollectionsToJsonObj( gxdynajaxctrlcodr, gxdynajaxctrldescr) ;
         /* End function LeaveTypeId_DL */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         SDSVC_LEAV2_A124LeaveTypeId = new long[1] ;
         SDSVC_LEAV2_A125LeaveTypeName = new string[] {""} ;
         SDSVC_LEAV2_A100CompanyId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sdsvc_leaverequestpanel_level_detail__default(),
            new Object[][] {
                new Object[] {
               SDSVC_LEAV2_A124LeaveTypeId, SDSVC_LEAV2_A125LeaveTypeName, SDSVC_LEAV2_A100CompanyId
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      protected GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected IDataStoreProvider pr_default ;
      protected long[] SDSVC_LEAV2_A124LeaveTypeId ;
      protected string[] SDSVC_LEAV2_A125LeaveTypeName ;
      protected long[] SDSVC_LEAV2_A100CompanyId ;
   }

   public class sdsvc_leaverequestpanel_level_detail__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmSDSVC_LEAV2;
          prmSDSVC_LEAV2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("SDSVC_LEAV2", "SELECT LeaveTypeId, LeaveTypeName, CompanyId FROM LeaveType ORDER BY LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmSDSVC_LEAV2,0, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
