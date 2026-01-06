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
   public class dp_hourfilledstatuscollection : GXProcedure
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

      public dp_hourfilledstatuscollection( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dp_hourfilledstatuscollection( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem>( context, "SDT_HoursFilledStatusCollectionItem", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem>( context, "SDT_HoursFilledStatusCollectionItem", "YTT_version4") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1sdt_hoursfilledstatuscollection = new SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem(context);
         Gxm2rootcol.Add(Gxm1sdt_hoursfilledstatuscollection, 0);
         Gxm1sdt_hoursfilledstatuscollection.gxTpr_Value = 0;
         Gxm1sdt_hoursfilledstatuscollection.gxTpr_Description = "All";
         Gxm1sdt_hoursfilledstatuscollection = new SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem(context);
         Gxm2rootcol.Add(Gxm1sdt_hoursfilledstatuscollection, 0);
         Gxm1sdt_hoursfilledstatuscollection.gxTpr_Value = 1;
         Gxm1sdt_hoursfilledstatuscollection.gxTpr_Description = "Below Expected";
         Gxm1sdt_hoursfilledstatuscollection = new SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem(context);
         Gxm2rootcol.Add(Gxm1sdt_hoursfilledstatuscollection, 0);
         Gxm1sdt_hoursfilledstatuscollection.gxTpr_Value = 2;
         Gxm1sdt_hoursfilledstatuscollection.gxTpr_Description = "Unfilled";
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
         Gxm1sdt_hoursfilledstatuscollection = new SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem(context);
         /* GeneXus formulas. */
      }

      private GXBaseCollection<SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem> Gxm2rootcol ;
      private SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem Gxm1sdt_hoursfilledstatuscollection ;
      private GXBaseCollection<SdtSDT_HoursFilledStatusCollection_SDT_HoursFilledStatusCollectionItem> aP0_Gxm2rootcol ;
   }

}
