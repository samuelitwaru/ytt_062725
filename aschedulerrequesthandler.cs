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
   public class aschedulerrequesthandler : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aschedulerrequesthandler( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aschedulerrequesthandler( IGxContext context )
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
         AV21queryString = AV20httpRequest.QueryString;
         if ( ( StringUtil.StringSearch( AV21queryString, "&from=", 1) > 0 ) && ( StringUtil.StringSearch( AV21queryString, "&to=", 1) > 0 ) )
         {
            AV10callbackIndex = (short)(StringUtil.StringSearch( AV21queryString, "&callback=", 1));
            AV8auxIndex = (short)(StringUtil.StringSearch( AV21queryString, "&", AV10callbackIndex+10));
            AV9callback = StringUtil.Substring( AV21queryString, AV10callbackIndex+10, AV8auxIndex-(AV10callbackIndex+10));
            AV12fromIndex = (short)(StringUtil.StringSearch( AV21queryString, "&from=", 1));
            AV8auxIndex = (short)(StringUtil.StringSearch( AV21queryString, "&", AV12fromIndex+6));
            AV11from = StringUtil.Substring( AV21queryString, AV12fromIndex+6, AV8auxIndex-(AV12fromIndex+6));
            AV15toIndex = (short)(StringUtil.StringSearch( AV21queryString, "&to=", 1));
            AV14to = StringUtil.Substring( AV21queryString, AV15toIndex+4, StringUtil.Len( AV21queryString));
            AV19fromCollection = GxRegex.Split(AV11from,"-");
            AV22toCollection = GxRegex.Split(AV14to,"-");
            AV16dateFrom = context.localUtil.YMDToD( (int)(Math.Round(NumberUtil.Val( AV19fromCollection.GetString(1), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( AV19fromCollection.GetString(2), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( AV19fromCollection.GetString(3), "."), 18, MidpointRounding.ToEven)));
            AV17dateTo = context.localUtil.YMDToD( (int)(Math.Round(NumberUtil.Val( AV22toCollection.GetString(1), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( AV22toCollection.GetString(2), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( AV22toCollection.GetString(3), "."), 18, MidpointRounding.ToEven)));
            try {
               args = new Object[] {(DateTime)AV16dateFrom,(DateTime)AV17dateTo,(SdtSchedulerEvents)AV18events} ;
               ClassLoader.WebExecute(AV9callback,"GeneXus.Programs",AV9callback.ToLower().Trim(), new Object[] {context }, "execute", args);
               if ( ( args != null ) && ( args.Length == 3 ) )
               {
                  AV16dateFrom = (DateTime)(args[0]) ;
                  AV17dateTo = (DateTime)(args[1]) ;
                  AV18events = (SdtSchedulerEvents)(args[2]) ;
               }
            }
            catch (GxClassLoaderException) {
               if ( AV9callback .Trim().Length < 6 || AV9callback .Substring( AV9callback .Trim().Length - 5, 5) != ".aspx")
               {
                  context.wjLoc = formatLink(AV9callback+".aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV16dateFrom)),UrlEncode(DateTimeUtil.FormatDateParm(AV17dateTo))}, new string[] {}) ;
               }
               else
               {
                  context.wjLoc = formatLink(AV9callback, new object[] {UrlEncode(DateTimeUtil.FormatDateParm(AV16dateFrom)),UrlEncode(DateTimeUtil.FormatDateParm(AV17dateTo))}, new string[] {}) ;
               }
            }
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV13httpResponse.AppendHeader("Content-Type", "text/xml");
         }
         AV13httpResponse.AddString(AV18events.ToXml(false, true, "", ""));
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV21queryString = "";
         AV20httpRequest = new GxHttpRequest( context);
         AV9callback = "";
         AV11from = "";
         AV14to = "";
         AV19fromCollection = new GxSimpleCollection<string>();
         AV22toCollection = new GxSimpleCollection<string>();
         AV16dateFrom = DateTime.MinValue;
         AV17dateTo = DateTime.MinValue;
         AV18events = new SdtSchedulerEvents(context);
         AV13httpResponse = new GxHttpResponse( context);
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV10callbackIndex ;
      private short AV8auxIndex ;
      private short AV12fromIndex ;
      private short AV15toIndex ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV21queryString ;
      private string AV9callback ;
      private string AV11from ;
      private string AV14to ;
      private DateTime AV16dateFrom ;
      private DateTime AV17dateTo ;
      private bool entryPointCalled ;
      private GxHttpRequest AV20httpRequest ;
      private GxHttpResponse AV13httpResponse ;
      private GxSimpleCollection<string> AV19fromCollection ;
      private GxSimpleCollection<string> AV22toCollection ;
      private SdtSchedulerEvents AV18events ;
      private Object[] args ;
   }

}
