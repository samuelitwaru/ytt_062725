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
   public class procformattime : GXProcedure
   {
      public procformattime( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public procformattime( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_TimeInMins ,
                           out string aP1_FormattedTime )
      {
         this.AV9TimeInMins = aP0_TimeInMins;
         this.AV8FormattedTime = "" ;
         initialize();
         ExecuteImpl();
         aP1_FormattedTime=this.AV8FormattedTime;
      }

      public string executeUdp( long aP0_TimeInMins )
      {
         execute(aP0_TimeInMins, out aP1_FormattedTime);
         return AV8FormattedTime ;
      }

      public void executeSubmit( long aP0_TimeInMins ,
                                 out string aP1_FormattedTime )
      {
         this.AV9TimeInMins = aP0_TimeInMins;
         this.AV8FormattedTime = "" ;
         SubmitImpl();
         aP1_FormattedTime=this.AV8FormattedTime;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Hours = (long)(AV9TimeInMins/ (decimal)(60));
         AV11Minutes = ((int)((AV9TimeInMins) % (60)));
         if ( AV11Minutes < 10 )
         {
            AV8FormattedTime = StringUtil.Str( (decimal)(AV10Hours), 10, 0) + ":0" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Minutes), 10, 0));
         }
         else
         {
            AV8FormattedTime = StringUtil.Str( (decimal)(AV10Hours), 10, 0) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Minutes), 10, 0));
         }
         if ( ! ( AV9TimeInMins > 0 ) )
         {
            AV8FormattedTime = "";
         }
         AV8FormattedTime = StringUtil.Trim( AV8FormattedTime);
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
         AV8FormattedTime = "";
         /* GeneXus formulas. */
      }

      private long AV9TimeInMins ;
      private long AV10Hours ;
      private long AV11Minutes ;
      private string AV8FormattedTime ;
      private string aP1_FormattedTime ;
   }

}
