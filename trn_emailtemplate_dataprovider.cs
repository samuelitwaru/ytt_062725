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
   public class trn_emailtemplate_dataprovider : GXProcedure
   {
      public trn_emailtemplate_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public trn_emailtemplate_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBCCollection<SdtTrn_EmailTemplate> aP0_ReturnValue )
      {
         this.AV2ReturnValue = new GXBCCollection<SdtTrn_EmailTemplate>( context, "Trn_EmailTemplate", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      public GXBCCollection<SdtTrn_EmailTemplate> executeUdp( )
      {
         execute(out aP0_ReturnValue);
         return AV2ReturnValue ;
      }

      public void executeSubmit( out GXBCCollection<SdtTrn_EmailTemplate> aP0_ReturnValue )
      {
         this.AV2ReturnValue = new GXBCCollection<SdtTrn_EmailTemplate>( context, "Trn_EmailTemplate", "YTT_version4") ;
         SubmitImpl();
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(GXBCCollection<SdtTrn_EmailTemplate>)AV2ReturnValue} ;
         ClassLoader.Execute("atrn_emailtemplate_dataprovider","GeneXus.Programs","atrn_emailtemplate_dataprovider", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2ReturnValue = (GXBCCollection<SdtTrn_EmailTemplate>)(args[0]) ;
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
      }

      public override void initialize( )
      {
         AV2ReturnValue = new GXBCCollection<SdtTrn_EmailTemplate>( context, "Trn_EmailTemplate", "YTT_version4");
         /* GeneXus formulas. */
      }

      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBCCollection<SdtTrn_EmailTemplate> AV2ReturnValue ;
      private Object[] args ;
      private GXBCCollection<SdtTrn_EmailTemplate> aP0_ReturnValue ;
   }

}
