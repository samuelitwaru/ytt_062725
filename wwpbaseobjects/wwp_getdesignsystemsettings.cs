using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_getdesignsystemsettings : GXProcedure
   {
      public wwp_getdesignsystemsettings( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getdesignsystemsettings( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings aP0_WWP_DesignSystemSettings )
      {
         this.AV8WWP_DesignSystemSettings = new WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings(context) ;
         initialize();
         ExecuteImpl();
         aP0_WWP_DesignSystemSettings=this.AV8WWP_DesignSystemSettings;
      }

      public WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings executeUdp( )
      {
         execute(out aP0_WWP_DesignSystemSettings);
         return AV8WWP_DesignSystemSettings ;
      }

      public void executeSubmit( out WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings aP0_WWP_DesignSystemSettings )
      {
         this.AV8WWP_DesignSystemSettings = new WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings(context) ;
         SubmitImpl();
         aP0_WWP_DesignSystemSettings=this.AV8WWP_DesignSystemSettings;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV9WWP_DesignSystemSettingsJSON;
         new GeneXus.Programs.wwpbaseobjects.loaduserkeyvalue(context ).execute(  "DesignSystemSettings", out  GXt_char1) ;
         AV9WWP_DesignSystemSettingsJSON = GXt_char1;
         if ( StringUtil.StrCmp(AV9WWP_DesignSystemSettingsJSON, "") != 0 )
         {
            AV8WWP_DesignSystemSettings.FromJSonString(AV9WWP_DesignSystemSettingsJSON, null);
         }
         else
         {
            AV8WWP_DesignSystemSettings = new WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings(context);
            AV8WWP_DesignSystemSettings.gxTpr_Basecolor = "SkyBlue";
            AV8WWP_DesignSystemSettings.gxTpr_Backgroundstyle = "Light";
            new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  "DesignSystemSettings",  AV8WWP_DesignSystemSettings.ToJSonString(false, true)) ;
         }
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
         AV8WWP_DesignSystemSettings = new WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings(context);
         AV9WWP_DesignSystemSettingsJSON = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private string AV9WWP_DesignSystemSettingsJSON ;
      private WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings AV8WWP_DesignSystemSettings ;
      private WorkWithPlus.workwithplus_web.SdtWWP_DesignSystemSettings aP0_WWP_DesignSystemSettings ;
   }

}
