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
namespace GeneXus.Programs.workwithplus.nativemobile {
   public class templateusersettingsdp : GXProcedure
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

      public templateusersettingsdp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public templateusersettingsdp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem>( context, "MenuOptionsItem", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem>( context, "MenuOptionsItem", "YTT_version4") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1menuoptions = new GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem(context);
         Gxm2rootcol.Add(Gxm1menuoptions, 0);
         Gxm1menuoptions.gxTpr_Orderindex = 3;
         Gxm1menuoptions.gxTpr_Title = "Change Password";
         GXt_char1 = "";
         new GeneXus.Programs.workwithplus.nativemobile.wwpgetunicodefromhex(context ).execute(  "f502", out  GXt_char1) ;
         Gxm1menuoptions.gxTpr_Fonticon = GXt_char1;
         Gxm1menuoptions.gxTpr_Componenttocall = formatLink("sd:passwordchangepanel") ;
         Gxm1menuoptions.gxTpr_Type = 0;
         Gxm1menuoptions.gxTpr_Type = 1;
         Gxm1menuoptions = new GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem(context);
         Gxm2rootcol.Add(Gxm1menuoptions, 0);
         Gxm1menuoptions.gxTpr_Orderindex = 4;
         Gxm1menuoptions.gxTpr_Title = "Logout";
         GXt_char1 = "";
         new GeneXus.Programs.workwithplus.nativemobile.wwpgetunicodefromhex(context ).execute(  "f08b", out  GXt_char1) ;
         Gxm1menuoptions.gxTpr_Fonticon = GXt_char1;
         Gxm1menuoptions.gxTpr_Componenttocall = "sub:logout";
         Gxm1menuoptions.gxTpr_Type = 0;
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
         Gxm1menuoptions = new GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem(context);
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem> Gxm2rootcol ;
      private GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem Gxm1menuoptions ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem> aP0_Gxm2rootcol ;
   }

}
