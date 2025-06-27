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
   public class profilepanel_level_detail : GXDataGridProcedure
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
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public profilepanel_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public profilepanel_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_gxid ,
                           out SdtProfilePanel_Level_DetailSdt aP1_GXM7ProfilePanel_Level_DetailSdt )
      {
         this.AV24gxid = aP0_gxid;
         this.AV35GXM7ProfilePanel_Level_DetailSdt = new SdtProfilePanel_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP1_GXM7ProfilePanel_Level_DetailSdt=this.AV35GXM7ProfilePanel_Level_DetailSdt;
      }

      public SdtProfilePanel_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM7ProfilePanel_Level_DetailSdt);
         return AV35GXM7ProfilePanel_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtProfilePanel_Level_DetailSdt aP1_GXM7ProfilePanel_Level_DetailSdt )
      {
         this.AV24gxid = aP0_gxid;
         this.AV35GXM7ProfilePanel_Level_DetailSdt = new SdtProfilePanel_Level_DetailSdt(context) ;
         SubmitImpl();
         aP1_GXM7ProfilePanel_Level_DetailSdt=this.AV35GXM7ProfilePanel_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV24gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            new getloggedinuser(context ).execute( out  AV14GamUser, out  AV18Employee) ;
            AV19Name = StringUtil.Trim( AV18Employee.gxTpr_Employeefirstname) + " " + StringUtil.Trim( AV18Employee.gxTpr_Employeelastname);
            AV21Email = AV18Employee.gxTpr_Employeeemail;
            AV23UserCompany = AV18Employee.gxTpr_Companyname;
            if ( AV14GamUser.checkrole("Employee") )
            {
               AV20Role = "Employee";
            }
            else if ( AV14GamUser.checkrole("Manager") )
            {
               AV20Role = "Manager";
            }
            else if ( AV14GamUser.checkrole("General Manager") )
            {
               AV20Role = "General Manager";
            }
            else
            {
               AV20Role = "N/A";
            }
            Gxwebsession.Set(Gxids+"gxvar_Menuoptions", AV8MenuOptions.ToJSonString(false));
            Gxwebsession.Set(Gxids+"gxvar_Name", AV19Name);
            Gxwebsession.Set(Gxids+"gxvar_Email", AV21Email);
            Gxwebsession.Set(Gxids+"gxvar_Usercompany", AV23UserCompany);
            Gxwebsession.Set(Gxids+"gxvar_Role", AV20Role);
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV8MenuOptions.FromJSonString(Gxwebsession.Get(Gxids+"gxvar_Menuoptions"), null);
            AV19Name = Gxwebsession.Get(Gxids+"gxvar_Name");
            AV21Email = Gxwebsession.Get(Gxids+"gxvar_Email");
            AV23UserCompany = Gxwebsession.Get(Gxids+"gxvar_Usercompany");
            AV20Role = Gxwebsession.Get(Gxids+"gxvar_Role");
         }
         GXt_objcol_SdtMenuOptions_MenuOptionsItem1 = AV8MenuOptions;
         new GeneXus.Programs.workwithplus.nativemobile.templateusersettingsdp(context ).execute( out  GXt_objcol_SdtMenuOptions_MenuOptionsItem1) ;
         AV8MenuOptions = GXt_objcol_SdtMenuOptions_MenuOptionsItem1;
         AV8MenuOptions.Sort("OrderIndex");
         AV9UserInfo_UserImage = context.GetImagePath( "9b60406f-2e43-467c-92b6-b2d04aad0f71", "", context.GetTheme( ));
         AV36Userinfo_userimage_GXI = GXDbFile.PathToUrl( context.GetImagePath( "9b60406f-2e43-467c-92b6-b2d04aad0f71", "", context.GetTheme( )), context);
         AV37GXV1 = 1;
         while ( AV37GXV1 <= AV8MenuOptions.Count )
         {
            AV8MenuOptions.CurrentItem = ((GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem)AV8MenuOptions.Item(AV37GXV1));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( ((GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem)(AV8MenuOptions.CurrentItem)).gxTpr_Fonticon)) )
            {
               Gxdynprop1 = "FontIcon";
               Gxdynpropsdt += ((StringUtil.StrCmp(Gxdynpropsdt, "")==0) ? "" : ", ") + "[\"Gridmenuoptions\",\"Itemlayout\",\"" + StringUtil.JSONEncode( Gxdynprop1) + "\"]";
            }
            else if ( ((GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem)(AV8MenuOptions.CurrentItem)).gxTpr_Type == 2 )
            {
               Gxdynprop2 = "MenuLink";
               Gxdynpropsdt += ((StringUtil.StrCmp(Gxdynpropsdt, "")==0) ? "" : ", ") + "[\"Gridmenuoptions\",\"Itemlayout\",\"" + StringUtil.JSONEncode( Gxdynprop2) + "\"]";
            }
            else if ( ((GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem)(AV8MenuOptions.CurrentItem)).gxTpr_Type == 9 )
            {
               Gxdynprop3 = "EmptyItem";
               Gxdynpropsdt += ((StringUtil.StrCmp(Gxdynpropsdt, "")==0) ? "" : ", ") + "[\"Gridmenuoptions\",\"Itemlayout\",\"" + StringUtil.JSONEncode( Gxdynprop3) + "\"]";
            }
            else
            {
               Gxdynprop4 = "Common";
               Gxdynpropsdt += ((StringUtil.StrCmp(Gxdynpropsdt, "")==0) ? "" : ", ") + "[\"Gridmenuoptions\",\"Itemlayout\",\"" + StringUtil.JSONEncode( Gxdynprop4) + "\"]";
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( ((GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem)(AV8MenuOptions.CurrentItem)).gxTpr_Fonticonclass)) )
            {
               Gxdynprop5 = "MenuIconFontAwesome";
               Gxdynpropsdt += ((StringUtil.StrCmp(Gxdynpropsdt, "")==0) ? "" : ", ") + "[\"Menuoptions__fonticon\",\"Class\",\"" + StringUtil.JSONEncode( Gxdynprop5) + "\"]";
            }
            else
            {
               Gxdynprop6 = ((GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem)(AV8MenuOptions.CurrentItem)).gxTpr_Fonticonclass;
               Gxdynpropsdt += ((StringUtil.StrCmp(Gxdynpropsdt, "")==0) ? "" : ", ") + "[\"Menuoptions__fonticon\",\"Class\",\"" + StringUtil.JSONEncode( Gxdynprop6) + "\"]";
            }
            if ( ((GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem)(AV8MenuOptions.CurrentItem)).gxTpr_Type == 1 )
            {
               Gxdynpropsdt += ((StringUtil.StrCmp(Gxdynpropsdt, "")==0) ? "" : ", ") + "[\"Rowlineseparator\",\"Visible\",\"" + "True" + "\"]";
            }
            else
            {
               Gxdynpropsdt += ((StringUtil.StrCmp(Gxdynpropsdt, "")==0) ? "" : ", ") + "[\"Rowlineseparator\",\"Visible\",\"" + "False" + "\"]";
            }
            Gxdynpropsdt = "[" + Gxdynpropsdt + "]";
            Gxcol_gridmenuoptions_props.Add(Gxdynpropsdt, 0);
            Gxdynpropsdt = "";
            AV37GXV1 = (int)(AV37GXV1+1);
         }
         AV35GXM7ProfilePanel_Level_DetailSdt.gxTpr_Gxprops_menuoptions = Gxcol_gridmenuoptions_props.ToJSonString(false);
         Gxcol_gridmenuoptions_props.Clear();
         AV35GXM7ProfilePanel_Level_DetailSdt.gxTpr_Menuoptions = AV8MenuOptions;
         AV35GXM7ProfilePanel_Level_DetailSdt.gxTpr_Name = AV19Name;
         AV35GXM7ProfilePanel_Level_DetailSdt.gxTpr_Email = AV21Email;
         AV35GXM7ProfilePanel_Level_DetailSdt.gxTpr_Usercompany = AV23UserCompany;
         AV35GXM7ProfilePanel_Level_DetailSdt.gxTpr_Role = AV20Role;
         Gxwebsession.Set(Gxids+"gxvar_Menuoptions", AV8MenuOptions.ToJSonString(false));
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
         AV35GXM7ProfilePanel_Level_DetailSdt = new SdtProfilePanel_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV14GamUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV18Employee = new SdtEmployee(context);
         AV19Name = "";
         AV21Email = "";
         AV23UserCompany = "";
         AV20Role = "";
         AV8MenuOptions = new GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem>( context, "MenuOptionsItem", "YTT_version4");
         GXt_objcol_SdtMenuOptions_MenuOptionsItem1 = new GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem>( context, "MenuOptionsItem", "YTT_version4");
         AV9UserInfo_UserImage = "";
         AV36Userinfo_userimage_GXI = "";
         Gxdynprop1 = "";
         Gxdynpropsdt = "";
         Gxdynprop2 = "";
         Gxdynprop3 = "";
         Gxdynprop4 = "";
         Gxdynprop5 = "";
         Gxdynprop6 = "";
         Gxcol_gridmenuoptions_props = new GxSimpleCollection<string>();
         /* GeneXus formulas. */
      }

      private int AV24gxid ;
      private int AV37GXV1 ;
      private string Gxids ;
      private string AV19Name ;
      private string AV23UserCompany ;
      private string AV20Role ;
      private string Gxdynprop1 ;
      private string Gxdynprop2 ;
      private string Gxdynprop3 ;
      private string Gxdynprop4 ;
      private string Gxdynprop5 ;
      private string AV21Email ;
      private string AV36Userinfo_userimage_GXI ;
      private string Gxdynpropsdt ;
      private string Gxdynprop6 ;
      private string AV9UserInfo_UserImage ;
      private IGxSession Gxwebsession ;
      private SdtProfilePanel_Level_DetailSdt AV35GXM7ProfilePanel_Level_DetailSdt ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV14GamUser ;
      private SdtEmployee AV18Employee ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem> AV8MenuOptions ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtMenuOptions_MenuOptionsItem> GXt_objcol_SdtMenuOptions_MenuOptionsItem1 ;
      private GxSimpleCollection<string> Gxcol_gridmenuoptions_props ;
      private SdtProfilePanel_Level_DetailSdt aP1_GXM7ProfilePanel_Level_DetailSdt ;
   }

}
