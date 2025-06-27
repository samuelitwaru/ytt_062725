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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_getnotificationsforuser : GXProcedure
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

      public wwp_getnotificationsforuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getnotificationsforuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "YTT_version4") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Udparg3 = new WorkWithPlus.workwithplus_commongam.wwp_getloggeduserid(context).executeUdp( );
         /* Using cursor P000C2 */
         pr_default.execute(0, new Object[] {AV9Udparg3});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A82WWPNotificationIsRead = P000C2_A82WWPNotificationIsRead[0];
            A7WWPUserExtendedId = P000C2_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = P000C2_n7WWPUserExtendedId[0];
            A22WWPNotificationId = P000C2_A22WWPNotificationId[0];
            A76WWPNotificationIcon = P000C2_A76WWPNotificationIcon[0];
            A77WWPNotificationTitle = P000C2_A77WWPNotificationTitle[0];
            A78WWPNotificationShortDescriptio = P000C2_A78WWPNotificationShortDescriptio[0];
            A79WWPNotificationLink = P000C2_A79WWPNotificationLink[0];
            A24WWPNotificationCreated = P000C2_A24WWPNotificationCreated[0];
            Gxm1wwp_sdtnotificationsdata = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem(context);
            Gxm2rootcol.Add(Gxm1wwp_sdtnotificationsdata, 0);
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationid = (int)(A22WWPNotificationId);
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationiconclass = "NotificationFontIcon"+" "+A76WWPNotificationIcon;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationtitle = A77WWPNotificationTitle;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationdescription = A78WWPNotificationShortDescriptio;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationdatetime = A24WWPNotificationCreated;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationlink = A79WWPNotificationLink;
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
         AV9Udparg3 = "";
         P000C2_A82WWPNotificationIsRead = new bool[] {false} ;
         P000C2_A7WWPUserExtendedId = new string[] {""} ;
         P000C2_n7WWPUserExtendedId = new bool[] {false} ;
         P000C2_A22WWPNotificationId = new long[1] ;
         P000C2_A76WWPNotificationIcon = new string[] {""} ;
         P000C2_A77WWPNotificationTitle = new string[] {""} ;
         P000C2_A78WWPNotificationShortDescriptio = new string[] {""} ;
         P000C2_A79WWPNotificationLink = new string[] {""} ;
         P000C2_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         A7WWPUserExtendedId = "";
         A76WWPNotificationIcon = "";
         A77WWPNotificationTitle = "";
         A78WWPNotificationShortDescriptio = "";
         A79WWPNotificationLink = "";
         A24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Gxm1wwp_sdtnotificationsdata = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_getnotificationsforuser__default(),
            new Object[][] {
                new Object[] {
               P000C2_A82WWPNotificationIsRead, P000C2_A7WWPUserExtendedId, P000C2_n7WWPUserExtendedId, P000C2_A22WWPNotificationId, P000C2_A76WWPNotificationIcon, P000C2_A77WWPNotificationTitle, P000C2_A78WWPNotificationShortDescriptio, P000C2_A79WWPNotificationLink, P000C2_A24WWPNotificationCreated
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A22WWPNotificationId ;
      private string AV9Udparg3 ;
      private string A7WWPUserExtendedId ;
      private DateTime A24WWPNotificationCreated ;
      private bool A82WWPNotificationIsRead ;
      private bool n7WWPUserExtendedId ;
      private string A76WWPNotificationIcon ;
      private string A77WWPNotificationTitle ;
      private string A78WWPNotificationShortDescriptio ;
      private string A79WWPNotificationLink ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private bool[] P000C2_A82WWPNotificationIsRead ;
      private string[] P000C2_A7WWPUserExtendedId ;
      private bool[] P000C2_n7WWPUserExtendedId ;
      private long[] P000C2_A22WWPNotificationId ;
      private string[] P000C2_A76WWPNotificationIcon ;
      private string[] P000C2_A77WWPNotificationTitle ;
      private string[] P000C2_A78WWPNotificationShortDescriptio ;
      private string[] P000C2_A79WWPNotificationLink ;
      private DateTime[] P000C2_A24WWPNotificationCreated ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem Gxm1wwp_sdtnotificationsdata ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol ;
   }

   public class wwp_getnotificationsforuser__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000C2;
          prmP000C2 = new Object[] {
          new ParDef("AV9Udparg3",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000C2", "SELECT WWPNotificationIsRead, WWPUserExtendedId, WWPNotificationId, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationCreated FROM WWP_Notification WHERE (Not WWPNotificationIsRead) AND (WWPUserExtendedId = ( :AV9Udparg3)) ORDER BY WWPNotificationCreated DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000C2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8, true);
                return;
       }
    }

 }

}
