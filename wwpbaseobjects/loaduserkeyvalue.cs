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
namespace GeneXus.Programs.wwpbaseobjects {
   public class loaduserkeyvalue : GXProcedure
   {
      public loaduserkeyvalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loaduserkeyvalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserCustomizationsKey ,
                           out string aP1_UserCustomizationsValue )
      {
         this.AV32UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV33UserCustomizationsValue = "" ;
         initialize();
         ExecuteImpl();
         aP1_UserCustomizationsValue=this.AV33UserCustomizationsValue;
      }

      public string executeUdp( string aP0_UserCustomizationsKey )
      {
         execute(aP0_UserCustomizationsKey, out aP1_UserCustomizationsValue);
         return AV33UserCustomizationsValue ;
      }

      public void executeSubmit( string aP0_UserCustomizationsKey ,
                                 out string aP1_UserCustomizationsValue )
      {
         this.AV32UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV33UserCustomizationsValue = "" ;
         SubmitImpl();
         aP1_UserCustomizationsValue=this.AV33UserCustomizationsValue;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV33UserCustomizationsValue = AV31Session.Get(AV32UserCustomizationsKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33UserCustomizationsValue)) )
         {
            AV35UserCustomizations.Load(new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid(), AV32UserCustomizationsKey);
            if ( AV35UserCustomizations.Success() )
            {
               AV33UserCustomizationsValue = AV35UserCustomizations.gxTpr_Usercustomizationsvalue;
            }
            else
            {
               AV33UserCustomizationsValue = "";
            }
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
         AV33UserCustomizationsValue = "";
         AV31Session = context.GetSession();
         AV35UserCustomizations = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
         /* GeneXus formulas. */
      }

      private string AV33UserCustomizationsValue ;
      private string AV32UserCustomizationsKey ;
      private IGxSession AV31Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations AV35UserCustomizations ;
      private string aP1_UserCustomizationsValue ;
   }

}
