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
   public class ageneraterandomnumber : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new ageneraterandomnumber().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
          decimal aP0_MinLimit ;
          decimal aP1_MaxLimit ;
          decimal aP2_Number ;
         if ( 0 < args.Length )
         {
            aP0_MinLimit=((decimal)(NumberUtil.Val( (string)(args[0]), ".")));
         }
         else
         {
            aP0_MinLimit=0;
         }
         if ( 1 < args.Length )
         {
            aP1_MaxLimit=((decimal)(NumberUtil.Val( (string)(args[1]), ".")));
         }
         else
         {
            aP1_MaxLimit=0;
         }
         if ( 2 < args.Length )
         {
            aP2_Number=((decimal)(NumberUtil.Val( (string)(args[2]), ".")));
         }
         else
         {
            aP2_Number=0;
         }
         execute(aP0_MinLimit, aP1_MaxLimit, out aP2_Number);
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

      public ageneraterandomnumber( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ageneraterandomnumber( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( decimal aP0_MinLimit ,
                           decimal aP1_MaxLimit ,
                           out decimal aP2_Number )
      {
         this.AV8MinLimit = aP0_MinLimit;
         this.AV9MaxLimit = aP1_MaxLimit;
         this.AV10Number = 0 ;
         initialize();
         ExecuteImpl();
         aP2_Number=this.AV10Number;
      }

      public decimal executeUdp( decimal aP0_MinLimit ,
                                 decimal aP1_MaxLimit )
      {
         execute(aP0_MinLimit, aP1_MaxLimit, out aP2_Number);
         return AV10Number ;
      }

      public void executeSubmit( decimal aP0_MinLimit ,
                                 decimal aP1_MaxLimit ,
                                 out decimal aP2_Number )
      {
         this.AV8MinLimit = aP0_MinLimit;
         this.AV9MaxLimit = aP1_MaxLimit;
         this.AV10Number = 0 ;
         SubmitImpl();
         aP2_Number=this.AV10Number;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11Dec = (decimal)(NumberUtil.Random( ));
         AV10Number = (decimal)(AV8MinLimit+(AV11Dec*(AV9MaxLimit-AV8MinLimit)));
         AV10Number = NumberUtil.Round( AV10Number, 0);
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
         /* GeneXus formulas. */
      }

      private decimal AV8MinLimit ;
      private decimal AV9MaxLimit ;
      private decimal AV10Number ;
      private decimal AV11Dec ;
      private decimal aP2_Number ;
   }

}
