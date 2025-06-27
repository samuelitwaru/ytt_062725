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
   public class userhasrole : GXProcedure
   {
      public userhasrole( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public userhasrole( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Role ,
                           out bool aP1_HasRole )
      {
         this.AV12Role = aP0_Role;
         this.AV11HasRole = false ;
         initialize();
         ExecuteImpl();
         aP1_HasRole=this.AV11HasRole;
      }

      public bool executeUdp( string aP0_Role )
      {
         execute(aP0_Role, out aP1_HasRole);
         return AV11HasRole ;
      }

      public void executeSubmit( string aP0_Role ,
                                 out bool aP1_HasRole )
      {
         this.AV12Role = aP0_Role;
         this.AV11HasRole = false ;
         SubmitImpl();
         aP1_HasRole=this.AV11HasRole;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV8GAMErrors);
         AV10GAMUser = AV9GAMSession.gxTpr_User;
         AV11HasRole = AV10GAMUser.checkrole(AV12Role);
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
         AV9GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV8GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         /* GeneXus formulas. */
      }

      private string AV12Role ;
      private bool AV11HasRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV9GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10GAMUser ;
      private bool aP1_HasRole ;
   }

}
