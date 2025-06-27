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
namespace GeneXus.Programs.workwithplus.ai {
   public class wwp_aigetqueryredirectionmenuoptions : GXProcedure
   {
      public wwp_aigetqueryredirectionmenuoptions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_aigetqueryredirectionmenuoptions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> aP0_MenuOptions ,
                           string aP1_MenuOptionPrefix ,
                           ref GxSimpleCollection<string> aP2_LinkedPages ,
                           ref string aP3_SystemContent )
      {
         this.AV11MenuOptions = aP0_MenuOptions;
         this.AV10MenuOptionPrefix = aP1_MenuOptionPrefix;
         this.AV13LinkedPages = aP2_LinkedPages;
         this.AV12SystemContent = aP3_SystemContent;
         initialize();
         ExecuteImpl();
         aP2_LinkedPages=this.AV13LinkedPages;
         aP3_SystemContent=this.AV12SystemContent;
      }

      public string executeUdp( GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> aP0_MenuOptions ,
                                string aP1_MenuOptionPrefix ,
                                ref GxSimpleCollection<string> aP2_LinkedPages )
      {
         execute(aP0_MenuOptions, aP1_MenuOptionPrefix, ref aP2_LinkedPages, ref aP3_SystemContent);
         return AV12SystemContent ;
      }

      public void executeSubmit( GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> aP0_MenuOptions ,
                                 string aP1_MenuOptionPrefix ,
                                 ref GxSimpleCollection<string> aP2_LinkedPages ,
                                 ref string aP3_SystemContent )
      {
         this.AV11MenuOptions = aP0_MenuOptions;
         this.AV10MenuOptionPrefix = aP1_MenuOptionPrefix;
         this.AV13LinkedPages = aP2_LinkedPages;
         this.AV12SystemContent = aP3_SystemContent;
         SubmitImpl();
         aP2_LinkedPages=this.AV13LinkedPages;
         aP3_SystemContent=this.AV12SystemContent;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14GXV1 = 1;
         while ( AV14GXV1 <= AV11MenuOptions.Count )
         {
            AV8MenuOption = ((WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item)AV11MenuOptions.Item(AV14GXV1));
            if ( StringUtil.Len( AV12SystemContent) > 55000 )
            {
               if (true) break;
            }
            AV9MenuOptionCaption = AV10MenuOptionPrefix + (String.IsNullOrEmpty(StringUtil.RTrim( AV10MenuOptionPrefix))||String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV8MenuOption.gxTpr_Caption))) ? "" : " > ") + StringUtil.Trim( AV8MenuOption.gxTpr_Caption);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV8MenuOption.gxTpr_Caption))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV8MenuOption.gxTpr_Tooltip))) && ( StringUtil.StrCmp(StringUtil.Trim( AV8MenuOption.gxTpr_Caption), StringUtil.Trim( AV8MenuOption.gxTpr_Tooltip)) != 0 ) )
            {
               AV9MenuOptionCaption += StringUtil.Format( " (%1)", StringUtil.Trim( AV8MenuOption.gxTpr_Tooltip), "", "", "", "", "", "", "", "");
            }
            if ( AV8MenuOption.gxTpr_Subitems.Count > 0 )
            {
               new GeneXus.Programs.workwithplus.ai.wwp_aigetqueryredirectionmenuoptions(context ).execute(  AV8MenuOption.gxTpr_Subitems,  AV9MenuOptionCaption, ref  AV13LinkedPages, ref  AV12SystemContent) ;
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV8MenuOption.gxTpr_Link))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV8MenuOption.gxTpr_Id))) && ( AV13LinkedPages.IndexOf(StringUtil.Trim( StringUtil.Lower( AV8MenuOption.gxTpr_Link))) <= 0 ) )
               {
                  AV13LinkedPages.Add(StringUtil.Trim( StringUtil.Lower( AV8MenuOption.gxTpr_Link)), 0);
                  AV12SystemContent += StringUtil.Format( "Page_%1%2: %3", StringUtil.StringReplace( StringUtil.Trim( AV8MenuOption.gxTpr_Caption), " ", ""), StringUtil.Trim( AV8MenuOption.gxTpr_Id), AV9MenuOptionCaption, "", "", "", "", "", "") + StringUtil.NewLine( );
               }
            }
            AV14GXV1 = (int)(AV14GXV1+1);
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
         AV8MenuOption = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         AV9MenuOptionCaption = "";
         /* GeneXus formulas. */
      }

      private int AV14GXV1 ;
      private string AV10MenuOptionPrefix ;
      private string AV12SystemContent ;
      private string AV9MenuOptionCaption ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> AV11MenuOptions ;
      private GxSimpleCollection<string> AV13LinkedPages ;
      private GxSimpleCollection<string> aP2_LinkedPages ;
      private string aP3_SystemContent ;
      private WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item AV8MenuOption ;
   }

}
