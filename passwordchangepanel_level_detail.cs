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
   public class passwordchangepanel_level_detail : GXDataGridProcedure
   {
      public passwordchangepanel_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public passwordchangepanel_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_gxid ,
                           out SdtPasswordChangePanel_Level_DetailSdt aP1_GXM1PasswordChangePanel_Level_DetailSdt )
      {
         this.AV18gxid = aP0_gxid;
         this.AV22GXM1PasswordChangePanel_Level_DetailSdt = new SdtPasswordChangePanel_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP1_GXM1PasswordChangePanel_Level_DetailSdt=this.AV22GXM1PasswordChangePanel_Level_DetailSdt;
      }

      public SdtPasswordChangePanel_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM1PasswordChangePanel_Level_DetailSdt);
         return AV22GXM1PasswordChangePanel_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtPasswordChangePanel_Level_DetailSdt aP1_GXM1PasswordChangePanel_Level_DetailSdt )
      {
         this.AV18gxid = aP0_gxid;
         this.AV22GXM1PasswordChangePanel_Level_DetailSdt = new SdtPasswordChangePanel_Level_DetailSdt(context) ;
         SubmitImpl();
         aP1_GXM1PasswordChangePanel_Level_DetailSdt=this.AV22GXM1PasswordChangePanel_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV18gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            AV16isPasswordExpires = false;
            AV10User = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getusertochangepassword();
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10User.gxTpr_Name)) )
            {
               AV16isPasswordExpires = true;
               AV17UserName = AV10User.gxTpr_Name;
            }
            else
            {
               AV10User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get();
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10User.gxTpr_Name)) )
               {
                  AV17UserName = AV10User.gxTpr_Name;
               }
               else
               {
                  cleanup();
                  if (true) return;
               }
            }
            Gxwebsession.Set(Gxids+"gxvar_Ispasswordexpires", StringUtil.BoolToStr( AV16isPasswordExpires));
            Gxwebsession.Set(Gxids+"gxvar_Username", AV17UserName);
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV16isPasswordExpires = BooleanUtil.Val( Gxwebsession.Get(Gxids+"gxvar_Ispasswordexpires"));
            AV17UserName = Gxwebsession.Get(Gxids+"gxvar_Username");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7OldPassword)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV8NewPassword)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV9ConfirmPassword)) )
         {
            Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Btnsubmitbutton\",\"Enabled\",\"" + "True" + "\"]";
         }
         AV22GXM1PasswordChangePanel_Level_DetailSdt.gxTpr_Oldpassword = AV7OldPassword;
         AV22GXM1PasswordChangePanel_Level_DetailSdt.gxTpr_Newpassword = AV8NewPassword;
         AV22GXM1PasswordChangePanel_Level_DetailSdt.gxTpr_Confirmpassword = AV9ConfirmPassword;
         AV22GXM1PasswordChangePanel_Level_DetailSdt.gxTpr_Ispasswordexpires = AV16isPasswordExpires;
         AV22GXM1PasswordChangePanel_Level_DetailSdt.gxTpr_Username = AV17UserName;
         AV22GXM1PasswordChangePanel_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
         Gxdynprop = "";
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
         AV22GXM1PasswordChangePanel_Level_DetailSdt = new SdtPasswordChangePanel_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV10User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV17UserName = "";
         AV7OldPassword = "";
         AV8NewPassword = "";
         AV9ConfirmPassword = "";
         Gxdynprop = "";
         /* GeneXus formulas. */
      }

      private int AV18gxid ;
      private string Gxids ;
      private bool AV16isPasswordExpires ;
      private string AV17UserName ;
      private string AV7OldPassword ;
      private string AV8NewPassword ;
      private string AV9ConfirmPassword ;
      private string Gxdynprop ;
      private IGxSession Gxwebsession ;
      private SdtPasswordChangePanel_Level_DetailSdt AV22GXM1PasswordChangePanel_Level_DetailSdt ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10User ;
      private SdtPasswordChangePanel_Level_DetailSdt aP1_GXM1PasswordChangePanel_Level_DetailSdt ;
   }

}
