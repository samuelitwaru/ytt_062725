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
   public class gamsdupdateuser_level_detail : GXDataGridProcedure
   {
      public gamsdupdateuser_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public gamsdupdateuser_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_gxid ,
                           out SdtGAMSDUpdateUser_Level_DetailSdt aP1_GXM1GAMSDUpdateUser_Level_DetailSdt )
      {
         this.AV16gxid = aP0_gxid;
         this.AV19GXM1GAMSDUpdateUser_Level_DetailSdt = new SdtGAMSDUpdateUser_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP1_GXM1GAMSDUpdateUser_Level_DetailSdt=this.AV19GXM1GAMSDUpdateUser_Level_DetailSdt;
      }

      public SdtGAMSDUpdateUser_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM1GAMSDUpdateUser_Level_DetailSdt);
         return AV19GXM1GAMSDUpdateUser_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtGAMSDUpdateUser_Level_DetailSdt aP1_GXM1GAMSDUpdateUser_Level_DetailSdt )
      {
         this.AV16gxid = aP0_gxid;
         this.AV19GXM1GAMSDUpdateUser_Level_DetailSdt = new SdtGAMSDUpdateUser_Level_DetailSdt(context) ;
         SubmitImpl();
         aP1_GXM1GAMSDUpdateUser_Level_DetailSdt=this.AV19GXM1GAMSDUpdateUser_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV16gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            AV13User = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbykeytocompleteuserdata(out  AV7Errors);
            AV15UserGUID = AV13User.gxTpr_Guid;
            AV12UserName = AV13User.gxTpr_Name;
            AV6Email = AV13User.gxTpr_Email;
            AV8FirstName = AV13User.gxTpr_Firstname;
            AV9LastName = AV13User.gxTpr_Lastname;
            Gxwebsession.Set(Gxids+"gxvar_Username", AV12UserName);
            Gxwebsession.Set(Gxids+"gxvar_Email", AV6Email);
            Gxwebsession.Set(Gxids+"gxvar_Firstname", AV8FirstName);
            Gxwebsession.Set(Gxids+"gxvar_Lastname", AV9LastName);
            Gxwebsession.Set(Gxids+"gxvar_Userguid", AV15UserGUID);
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV15UserGUID = Gxwebsession.Get(Gxids+"gxvar_Userguid");
            AV12UserName = Gxwebsession.Get(Gxids+"gxvar_Username");
            AV6Email = Gxwebsession.Get(Gxids+"gxvar_Email");
            AV8FirstName = Gxwebsession.Get(Gxids+"gxvar_Firstname");
            AV9LastName = Gxwebsession.Get(Gxids+"gxvar_Lastname");
         }
         AV19GXM1GAMSDUpdateUser_Level_DetailSdt.gxTpr_Username = AV12UserName;
         AV19GXM1GAMSDUpdateUser_Level_DetailSdt.gxTpr_Email = AV6Email;
         AV19GXM1GAMSDUpdateUser_Level_DetailSdt.gxTpr_Firstname = AV8FirstName;
         AV19GXM1GAMSDUpdateUser_Level_DetailSdt.gxTpr_Lastname = AV9LastName;
         AV19GXM1GAMSDUpdateUser_Level_DetailSdt.gxTpr_Userguid = AV15UserGUID;
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
         AV19GXM1GAMSDUpdateUser_Level_DetailSdt = new SdtGAMSDUpdateUser_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV13User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV7Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV15UserGUID = "";
         AV12UserName = "";
         AV6Email = "";
         AV8FirstName = "";
         AV9LastName = "";
         /* GeneXus formulas. */
      }

      private int AV16gxid ;
      private string Gxids ;
      private string AV15UserGUID ;
      private string AV8FirstName ;
      private string AV9LastName ;
      private string AV12UserName ;
      private string AV6Email ;
      private IGxSession Gxwebsession ;
      private SdtGAMSDUpdateUser_Level_DetailSdt AV19GXM1GAMSDUpdateUser_Level_DetailSdt ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV13User ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV7Errors ;
      private SdtGAMSDUpdateUser_Level_DetailSdt aP1_GXM1GAMSDUpdateUser_Level_DetailSdt ;
   }

}
