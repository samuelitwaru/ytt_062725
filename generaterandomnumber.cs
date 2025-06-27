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
   public class generaterandomnumber : GXProcedure
   {
      public generaterandomnumber( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public generaterandomnumber( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( decimal aP0_MinLimit ,
                           decimal aP1_MaxLimit ,
                           out decimal aP2_Number )
      {
         this.AV2MinLimit = aP0_MinLimit;
         this.AV3MaxLimit = aP1_MaxLimit;
         this.AV4Number = 0 ;
         initialize();
         ExecuteImpl();
         aP2_Number=this.AV4Number;
      }

      public decimal executeUdp( decimal aP0_MinLimit ,
                                 decimal aP1_MaxLimit )
      {
         execute(aP0_MinLimit, aP1_MaxLimit, out aP2_Number);
         return AV4Number ;
      }

      public void executeSubmit( decimal aP0_MinLimit ,
                                 decimal aP1_MaxLimit ,
                                 out decimal aP2_Number )
      {
         this.AV2MinLimit = aP0_MinLimit;
         this.AV3MaxLimit = aP1_MaxLimit;
         this.AV4Number = 0 ;
         SubmitImpl();
         aP2_Number=this.AV4Number;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(decimal)AV2MinLimit,(decimal)AV3MaxLimit,(decimal)AV4Number} ;
         ClassLoader.Execute("ageneraterandomnumber","GeneXus.Programs","ageneraterandomnumber", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
            AV4Number = (decimal)(args[2]) ;
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

      private decimal AV2MinLimit ;
      private decimal AV3MaxLimit ;
      private decimal AV4Number ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private decimal aP2_Number ;
   }

}
