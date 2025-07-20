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
   public class prc_sendsundayreminder : GXProcedure
   {
      public prc_sendsundayreminder( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_sendsundayreminder( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_CompanyLocationId )
      {
         this.AV2CompanyLocationId = aP0_CompanyLocationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( long aP0_CompanyLocationId )
      {
         this.AV2CompanyLocationId = aP0_CompanyLocationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2CompanyLocationId} ;
         ClassLoader.Execute("aprc_sendsundayreminder","GeneXus.Programs","aprc_sendsundayreminder", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
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
         /* GeneXus formulas. */
      }

      private long AV2CompanyLocationId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
