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
   public class aformatdatetime : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aformatdatetime().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         DateTime aP0_Date = new DateTime()  ;
         string aP1_DateTimeFormat = new string(' ',0)  ;
         string aP2_FinalDateString = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_Date=((DateTime)(context.localUtil.CToD( (string)(args[0]), 2)));
         }
         else
         {
            aP0_Date=DateTime.MinValue;
         }
         if ( 1 < args.Length )
         {
            aP1_DateTimeFormat=((string)(args[1]));
         }
         else
         {
            aP1_DateTimeFormat="";
         }
         if ( 2 < args.Length )
         {
            aP2_FinalDateString=((string)(args[2]));
         }
         else
         {
            aP2_FinalDateString="";
         }
         execute(aP0_Date, aP1_DateTimeFormat, out aP2_FinalDateString);
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

      public aformatdatetime( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aformatdatetime( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( DateTime aP0_Date ,
                           string aP1_DateTimeFormat ,
                           out string aP2_FinalDateString )
      {
         this.AV8Date = aP0_Date;
         this.AV9DateTimeFormat = aP1_DateTimeFormat;
         this.AV21FinalDateString = "" ;
         initialize();
         ExecuteImpl();
         aP2_FinalDateString=this.AV21FinalDateString;
      }

      public string executeUdp( DateTime aP0_Date ,
                                string aP1_DateTimeFormat )
      {
         execute(aP0_Date, aP1_DateTimeFormat, out aP2_FinalDateString);
         return AV21FinalDateString ;
      }

      public void executeSubmit( DateTime aP0_Date ,
                                 string aP1_DateTimeFormat ,
                                 out string aP2_FinalDateString )
      {
         this.AV8Date = aP0_Date;
         this.AV9DateTimeFormat = aP1_DateTimeFormat;
         this.AV21FinalDateString = "" ;
         SubmitImpl();
         aP2_FinalDateString=this.AV21FinalDateString;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16Year = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( AV8Date)), 10, 0));
         AV17Month = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( AV8Date)), 10, 0));
         AV18Day = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( AV8Date)), 10, 0));
         if ( StringUtil.Contains( AV9DateTimeFormat, "YYYY") )
         {
            AV9DateTimeFormat = StringUtil.StringReplace( AV9DateTimeFormat, "YYYY", AV16Year);
         }
         else if ( StringUtil.Contains( AV9DateTimeFormat, "YY") )
         {
            AV9DateTimeFormat = StringUtil.StringReplace( AV9DateTimeFormat, "YY", StringUtil.Substring( AV16Year, 3, 2));
         }
         else
         {
            AV19Message = "No year format found";
         }
         if ( StringUtil.Contains( AV9DateTimeFormat, "MMMM") )
         {
            AV9DateTimeFormat = StringUtil.StringReplace( AV9DateTimeFormat, "MMMM", DateTimeUtil.CMonth( AV8Date, "eng"));
         }
         else if ( StringUtil.Contains( AV9DateTimeFormat, "MM") )
         {
            AV17Month = ((StringUtil.Len( AV17Month)==2) ? AV17Month : "0"+AV17Month);
            AV9DateTimeFormat = StringUtil.StringReplace( AV9DateTimeFormat, "MM", AV17Month);
         }
         else
         {
            AV19Message = "No month format Found";
         }
         if ( StringUtil.Contains( AV9DateTimeFormat, "DD") )
         {
            AV18Day = ((StringUtil.Len( AV18Day)==2) ? AV18Day : "0"+AV18Day);
            AV9DateTimeFormat = StringUtil.StringReplace( AV9DateTimeFormat, "DD", AV18Day);
         }
         else
         {
            AV19Message = "No day format found";
         }
         AV21FinalDateString = AV9DateTimeFormat;
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
         AV21FinalDateString = "";
         AV16Year = "";
         AV17Month = "";
         AV18Day = "";
         AV19Message = "";
         /* GeneXus formulas. */
      }

      private string AV9DateTimeFormat ;
      private string AV21FinalDateString ;
      private string AV16Year ;
      private string AV17Month ;
      private string AV18Day ;
      private string AV19Message ;
      private DateTime AV8Date ;
      private string aP2_FinalDateString ;
   }

}
