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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aprc_requestaccesstoken : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_requestaccesstoken().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         execute();
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

      public aprc_requestaccesstoken( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_requestaccesstoken( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9clientId = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).getclientid();
         AV16username = "samuel.itwaru@example.ug";
         AV17password = "user123";
         if ( StringUtil.StrCmp(AV10HttpRequest.ServerHost, "localhost") == 0 )
         {
            AV11baseUrl = "http://localhost:8082/YTT_version4NETPostgreSQL14";
         }
         else
         {
            AV11baseUrl = "https://staging.timetracker.yukon.software";
         }
         AV12url = AV11baseUrl + "/oauth/access_token";
         new logtofile(context ).execute(  AV12url) ;
         new logtofile(context ).execute(  "client id:"+AV9clientId) ;
         new logtofile(context ).execute(  "BASE URL:"+AV10HttpRequest.BaseURL) ;
         new logtofile(context ).execute(  "Key:"+AV19secretKey) ;
         new logtofile(context ).execute(  "user:"+AV16username) ;
         new logtofile(context ).execute(  "pwd:"+AV17password) ;
         AV13httpclient.AddHeader("Content-Type", "application/x-www-form-urlencoded");
         AV13httpclient.AddVariable("client_id", AV9clientId);
         AV13httpclient.AddVariable("grant_type", "password");
         AV13httpclient.AddVariable("scope", "gam_user_data");
         AV13httpclient.AddVariable("username", AV16username);
         AV13httpclient.AddVariable("password", AV17password);
         AV13httpclient.Execute("POST", AV12url);
         AV14result = AV13httpclient.ToString();
         new logtofile(context ).execute(  ">>>"+AV14result) ;
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
         AV9clientId = "";
         AV16username = "";
         AV17password = "";
         AV10HttpRequest = new GxHttpRequest( context);
         AV11baseUrl = "";
         AV12url = "";
         AV19secretKey = "";
         AV13httpclient = new GxHttpClient( context);
         AV14result = "";
         /* GeneXus formulas. */
      }

      private string AV14result ;
      private string AV9clientId ;
      private string AV16username ;
      private string AV17password ;
      private string AV11baseUrl ;
      private string AV12url ;
      private string AV19secretKey ;
      private GxHttpClient AV13httpclient ;
      private GxHttpRequest AV10HttpRequest ;
   }

}
