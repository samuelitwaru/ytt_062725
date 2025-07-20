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
   public class secgamisauthbyfunctionalitykeyservice : GXProcedure
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
            return "secgamisauthbyfunctionalitykeyservice_Services_Execute" ;
         }

      }

      public secgamisauthbyfunctionalitykeyservice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secgamisauthbyfunctionalitykeyservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_SecGAMFunctionalityKey ,
                           out bool aP1_IsAuthorized )
      {
         this.AV9SecGAMFunctionalityKey = aP0_SecGAMFunctionalityKey;
         this.AV8IsAuthorized = false ;
         initialize();
         ExecuteImpl();
         aP1_IsAuthorized=this.AV8IsAuthorized;
      }

      public bool executeUdp( string aP0_SecGAMFunctionalityKey )
      {
         execute(aP0_SecGAMFunctionalityKey, out aP1_IsAuthorized);
         return AV8IsAuthorized ;
      }

      public void executeSubmit( string aP0_SecGAMFunctionalityKey ,
                                 out bool aP1_IsAuthorized )
      {
         this.AV9SecGAMFunctionalityKey = aP0_SecGAMFunctionalityKey;
         this.AV8IsAuthorized = false ;
         SubmitImpl();
         aP1_IsAuthorized=this.AV8IsAuthorized;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_boolean1 = AV8IsAuthorized;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  AV9SecGAMFunctionalityKey, out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
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

      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private string AV9SecGAMFunctionalityKey ;
      private bool aP1_IsAuthorized ;
   }

}
