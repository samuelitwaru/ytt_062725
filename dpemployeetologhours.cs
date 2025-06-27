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
   public class dpemployeetologhours : GXProcedure
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

      public dpemployeetologhours( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpemployeetologhours( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem>( context, "SDTEmployeeToLogHoursItem", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem>( context, "SDTEmployeeToLogHoursItem", "YTT_version4") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV17GXV2 = 1;
         GXt_objcol_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem1 = AV16GXV1;
         new employeetologhoursbyproject(context ).execute( out  GXt_objcol_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem1) ;
         AV16GXV1 = GXt_objcol_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem1;
         while ( AV17GXV2 <= AV16GXV1.Count )
         {
            AV7EmployeeOnProject = ((SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem)AV16GXV1.Item(AV17GXV2));
            Gxm1sdtemployeetologhours = new SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem(context);
            Gxm2rootcol.Add(Gxm1sdtemployeetologhours, 0);
            Gxm1sdtemployeetologhours.gxTpr_Sdtemployeeid = AV7EmployeeOnProject.gxTpr_Sdtemployeeid;
            Gxm1sdtemployeetologhours.gxTpr_Sdtemployeename = AV7EmployeeOnProject.gxTpr_Sdtemployeename;
            AV17GXV2 = (int)(AV17GXV2+1);
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
         AV16GXV1 = new GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem>( context, "SDTEmployeeToLogHoursItem", "YTT_version4");
         GXt_objcol_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem1 = new GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem>( context, "SDTEmployeeToLogHoursItem", "YTT_version4");
         AV7EmployeeOnProject = new SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem(context);
         Gxm1sdtemployeetologhours = new SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem(context);
         /* GeneXus formulas. */
      }

      private int AV17GXV2 ;
      private GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem> Gxm2rootcol ;
      private GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem> AV16GXV1 ;
      private GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem> GXt_objcol_SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem1 ;
      private SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem AV7EmployeeOnProject ;
      private SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem Gxm1sdtemployeetologhours ;
      private GXBaseCollection<SdtSDTEmployeeToLogHours_SDTEmployeeToLogHoursItem> aP0_Gxm2rootcol ;
   }

}
