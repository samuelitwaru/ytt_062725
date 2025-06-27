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
   public class gamsdchangepassword_level_detail : GXDataGridProcedure
   {
      public gamsdchangepassword_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public gamsdchangepassword_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_gxid ,
                           out SdtGAMSDChangePassword_Level_DetailSdt aP1_GXM1GAMSDChangePassword_Level_DetailSdt )
      {
         this.AV15gxid = aP0_gxid;
         this.AV18GXM1GAMSDChangePassword_Level_DetailSdt = new SdtGAMSDChangePassword_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP1_GXM1GAMSDChangePassword_Level_DetailSdt=this.AV18GXM1GAMSDChangePassword_Level_DetailSdt;
      }

      public SdtGAMSDChangePassword_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM1GAMSDChangePassword_Level_DetailSdt);
         return AV18GXM1GAMSDChangePassword_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtGAMSDChangePassword_Level_DetailSdt aP1_GXM1GAMSDChangePassword_Level_DetailSdt )
      {
         this.AV15gxid = aP0_gxid;
         this.AV18GXM1GAMSDChangePassword_Level_DetailSdt = new SdtGAMSDChangePassword_Level_DetailSdt(context) ;
         SubmitImpl();
         aP1_GXM1GAMSDChangePassword_Level_DetailSdt=this.AV18GXM1GAMSDChangePassword_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV15gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            AV14isPasswordExpires = false;
            AV10User = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getusertochangepassword();
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10User.gxTpr_Name)) )
            {
               AV14isPasswordExpires = true;
               AV5UserName = AV10User.gxTpr_Name;
            }
            else
            {
               AV10User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get();
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10User.gxTpr_Name)) )
               {
                  AV5UserName = AV10User.gxTpr_Name;
               }
               else
               {
                  cleanup();
                  if (true) return;
               }
            }
            Gxwebsession.Set(Gxids+"gxvar_Username", AV5UserName);
            Gxwebsession.Set(Gxids+"gxvar_Ispasswordexpires", StringUtil.BoolToStr( AV14isPasswordExpires));
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV14isPasswordExpires = BooleanUtil.Val( Gxwebsession.Get(Gxids+"gxvar_Ispasswordexpires"));
            AV5UserName = Gxwebsession.Get(Gxids+"gxvar_Username");
         }
         AV18GXM1GAMSDChangePassword_Level_DetailSdt.gxTpr_Username = AV5UserName;
         AV18GXM1GAMSDChangePassword_Level_DetailSdt.gxTpr_Userpassword = AV6UserPassword;
         AV18GXM1GAMSDChangePassword_Level_DetailSdt.gxTpr_Userpasswordnew = AV7UserPasswordNew;
         AV18GXM1GAMSDChangePassword_Level_DetailSdt.gxTpr_Userpasswordnewconf = AV8UserPasswordNewConf;
         AV18GXM1GAMSDChangePassword_Level_DetailSdt.gxTpr_Ispasswordexpires = AV14isPasswordExpires;
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
         AV18GXM1GAMSDChangePassword_Level_DetailSdt = new SdtGAMSDChangePassword_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV10User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV5UserName = "";
         AV6UserPassword = "";
         AV7UserPasswordNew = "";
         AV8UserPasswordNewConf = "";
         /* GeneXus formulas. */
      }

      private int AV15gxid ;
      private string Gxids ;
      private string AV6UserPassword ;
      private string AV7UserPasswordNew ;
      private string AV8UserPasswordNewConf ;
      private bool AV14isPasswordExpires ;
      private string AV5UserName ;
      private IGxSession Gxwebsession ;
      private SdtGAMSDChangePassword_Level_DetailSdt AV18GXM1GAMSDChangePassword_Level_DetailSdt ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10User ;
      private SdtGAMSDChangePassword_Level_DetailSdt aP1_GXM1GAMSDChangePassword_Level_DetailSdt ;
   }

}
