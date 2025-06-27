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
   public class convertdate : GXProcedure
   {
      public convertdate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public convertdate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_DateCharacter ,
                           out DateTime aP1_FinalDate )
      {
         this.AV10DateCharacter = aP0_DateCharacter;
         this.AV11FinalDate = DateTime.MinValue ;
         initialize();
         ExecuteImpl();
         aP1_FinalDate=this.AV11FinalDate;
      }

      public DateTime executeUdp( string aP0_DateCharacter )
      {
         execute(aP0_DateCharacter, out aP1_FinalDate);
         return AV11FinalDate ;
      }

      public void executeSubmit( string aP0_DateCharacter ,
                                 out DateTime aP1_FinalDate )
      {
         this.AV10DateCharacter = aP0_DateCharacter;
         this.AV11FinalDate = DateTime.MinValue ;
         SubmitImpl();
         aP1_FinalDate=this.AV11FinalDate;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12FinalDateCharacter = StringUtil.Substring( AV10DateCharacter, 6, 2) + "/" + StringUtil.Substring( AV10DateCharacter, 9, 2) + "/" + StringUtil.Substring( AV10DateCharacter, 1, 4);
         AV11FinalDate = context.localUtil.CToD( AV12FinalDateCharacter, 2);
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
         AV11FinalDate = DateTime.MinValue;
         AV12FinalDateCharacter = "";
         /* GeneXus formulas. */
      }

      private string AV10DateCharacter ;
      private string AV12FinalDateCharacter ;
      private DateTime AV11FinalDate ;
      private DateTime aP1_FinalDate ;
   }

}
