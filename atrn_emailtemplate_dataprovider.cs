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
namespace GeneXus.Programs {
   public class atrn_emailtemplate_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new atrn_emailtemplate_dataprovider().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         GXBCCollection<SdtTrn_EmailTemplate> aP0_Gxm2rootcol = new GXBCCollection<SdtTrn_EmailTemplate>()  ;
         execute(out aP0_Gxm2rootcol);
         return GX.GXRuntime.ExitCode ;
      }

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

      public atrn_emailtemplate_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public atrn_emailtemplate_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtTrn_EmailTemplate> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtTrn_EmailTemplate>( context, "Trn_EmailTemplate", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtTrn_EmailTemplate> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtTrn_EmailTemplate> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtTrn_EmailTemplate>( context, "Trn_EmailTemplate", "YTT_version4") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1trn_emailtemplate = new SdtTrn_EmailTemplate(context);
         Gxm2rootcol.Add(Gxm1trn_emailtemplate, 0);
         Gxm1trn_emailtemplate.gxTpr_Emailtemplatename = "SundayEmail";
         Gxm1trn_emailtemplate.gxTpr_Emailtemplatecontent = "";
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
         Gxm1trn_emailtemplate = new SdtTrn_EmailTemplate(context);
         /* GeneXus formulas. */
      }

      private GXBCCollection<SdtTrn_EmailTemplate> Gxm2rootcol ;
      private SdtTrn_EmailTemplate Gxm1trn_emailtemplate ;
      private GXBCCollection<SdtTrn_EmailTemplate> aP0_Gxm2rootcol ;
   }

}
