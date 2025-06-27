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
namespace GeneXus.Programs.workwithplus.nativemobile {
   public class wwpwebserversessionsetnum : GXProcedure
   {
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

      protected override string ExecutePermissionPrefix
      {
         get {
            return "wwpwebserversessionsetnum_Services_Execute" ;
         }

      }

      public wwpwebserversessionsetnum( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwpwebserversessionsetnum( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ParameterKey ,
                           decimal aP1_ParameterValue )
      {
         this.AV8ParameterKey = aP0_ParameterKey;
         this.AV9ParameterValue = aP1_ParameterValue;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_ParameterKey ,
                                 decimal aP1_ParameterValue )
      {
         this.AV8ParameterKey = aP0_ParameterKey;
         this.AV9ParameterValue = aP1_ParameterValue;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10WebSession.Set(AV8ParameterKey, StringUtil.Trim( StringUtil.Str( AV9ParameterValue, 8, 2)));
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
         AV10WebSession = context.GetSession();
         /* GeneXus formulas. */
      }

      private decimal AV9ParameterValue ;
      private string AV8ParameterKey ;
      private IGxSession AV10WebSession ;
   }

}
