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
   public class gamsdupdateregisteruser : GXProcedure
   {
      public gamsdupdateregisteruser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gamsdupdateregisteruser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserGUID ,
                           string aP1_UserName ,
                           string aP2_Email ,
                           string aP3_FirstName ,
                           string aP4_LastName ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages )
      {
         this.AV19UserGUID = aP0_UserGUID;
         this.AV18UserName = aP1_UserName;
         this.AV10Email = aP2_Email;
         this.AV12FirstName = aP3_FirstName;
         this.AV14LastName = aP4_LastName;
         this.AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         ExecuteImpl();
         aP5_Messages=this.AV8Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( string aP0_UserGUID ,
                                                                             string aP1_UserName ,
                                                                             string aP2_Email ,
                                                                             string aP3_FirstName ,
                                                                             string aP4_LastName )
      {
         execute(aP0_UserGUID, aP1_UserName, aP2_Email, aP3_FirstName, aP4_LastName, out aP5_Messages);
         return AV8Messages ;
      }

      public void executeSubmit( string aP0_UserGUID ,
                                 string aP1_UserName ,
                                 string aP2_Email ,
                                 string aP3_FirstName ,
                                 string aP4_LastName ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages )
      {
         this.AV19UserGUID = aP0_UserGUID;
         this.AV18UserName = aP1_UserName;
         this.AV10Email = aP2_Email;
         this.AV12FirstName = aP3_FirstName;
         this.AV14LastName = aP4_LastName;
         this.AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         SubmitImpl();
         aP5_Messages=this.AV8Messages;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV17User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get();
         AV11Errors = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
         if ( AV11Errors.Count == 0 )
         {
            AV17User.gxTpr_Name = AV18UserName;
            AV17User.gxTpr_Email = AV10Email;
            AV17User.gxTpr_Firstname = AV12FirstName;
            AV17User.gxTpr_Lastname = AV14LastName;
            AV13isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).updateuserbykeytocompleteuserdata(AV17User, out  AV11Errors);
            if ( ! AV13isOK )
            {
               GXt_objcol_SdtMessages_Message1 = AV8Messages;
               new gam_converterrorstomessages(context ).execute(  AV11Errors, out  GXt_objcol_SdtMessages_Message1) ;
               AV8Messages = GXt_objcol_SdtMessages_Message1;
            }
         }
         else
         {
            GXt_objcol_SdtMessages_Message1 = AV8Messages;
            new gam_converterrorstomessages(context ).execute(  AV11Errors, out  GXt_objcol_SdtMessages_Message1) ;
            AV8Messages = GXt_objcol_SdtMessages_Message1;
         }
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
         AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV17User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV11Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         /* GeneXus formulas. */
      }

      private string AV19UserGUID ;
      private string AV12FirstName ;
      private string AV14LastName ;
      private bool AV13isOK ;
      private string AV18UserName ;
      private string AV10Email ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV8Messages ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV17User ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11Errors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages ;
   }

}
