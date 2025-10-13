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
   public class alogtofile : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new alogtofile().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         string aP0_Message = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_Message=((string)(args[0]));
         }
         else
         {
            aP0_Message="";
         }
         execute(aP0_Message);
         return GX.GXRuntime.ExitCode ;
      }

      public alogtofile( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public alogtofile( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Message )
      {
         this.AV8Message = aP0_Message;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_Message )
      {
         this.AV8Message = aP0_Message;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9File.Source = "Data.txt";
         AV9File.Open("");
         AV9File.WriteLine(AV8Message);
         AV9File.Close();
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
         AV9File = new GxFile(context.GetPhysicalPath());
         /* GeneXus formulas. */
      }

      private string AV8Message ;
      private GxFile AV9File ;
   }

}
