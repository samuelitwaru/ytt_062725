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
   public class prc_icsleaveapi : GXProcedure
   {
      public prc_icsleaveapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_icsleaveapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_ICSLeaveExport )
      {
         this.AV2ICSLeaveExport = "" ;
         initialize();
         ExecuteImpl();
         aP0_ICSLeaveExport=this.AV2ICSLeaveExport;
      }

      public string executeUdp( )
      {
         execute(out aP0_ICSLeaveExport);
         return AV2ICSLeaveExport ;
      }

      public void executeSubmit( out string aP0_ICSLeaveExport )
      {
         this.AV2ICSLeaveExport = "" ;
         SubmitImpl();
         aP0_ICSLeaveExport=this.AV2ICSLeaveExport;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2ICSLeaveExport} ;
         ClassLoader.Execute("aprc_icsleaveapi","GeneXus.Programs","aprc_icsleaveapi", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2ICSLeaveExport = (string)(args[0]) ;
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
         AV2ICSLeaveExport = "";
         /* GeneXus formulas. */
      }

      private string AV2ICSLeaveExport ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP0_ICSLeaveExport ;
   }

}
