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
   public class dpemployeetologhoursprojects : GXProcedure
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

      public dpemployeetologhoursprojects( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpemployeetologhoursprojects( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_EmployeeId ,
                           out GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> aP1_Gxm2rootcol )
      {
         this.AV6EmployeeId = aP0_EmployeeId;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem>( context, "SDTEmployeeProjectItem", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> executeUdp( long aP0_EmployeeId )
      {
         execute(aP0_EmployeeId, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 out GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> aP1_Gxm2rootcol )
      {
         this.AV6EmployeeId = aP0_EmployeeId;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem>( context, "SDTEmployeeProjectItem", "YTT_version4") ;
         SubmitImpl();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10GXV2 = 1;
         GXt_objcol_SdtSDTEmployeeProject_SDTEmployeeProjectItem1 = AV9GXV1;
         new getemployeetologhoursprojects(context ).execute(  AV6EmployeeId, out  GXt_objcol_SdtSDTEmployeeProject_SDTEmployeeProjectItem1) ;
         AV9GXV1 = GXt_objcol_SdtSDTEmployeeProject_SDTEmployeeProjectItem1;
         while ( AV10GXV2 <= AV9GXV1.Count )
         {
            AV5EmployeeProject = ((SdtSDTEmployeeProject_SDTEmployeeProjectItem)AV9GXV1.Item(AV10GXV2));
            Gxm1sdtemployeeproject = new SdtSDTEmployeeProject_SDTEmployeeProjectItem(context);
            Gxm2rootcol.Add(Gxm1sdtemployeeproject, 0);
            Gxm1sdtemployeeproject.gxTpr_Projectid = AV5EmployeeProject.gxTpr_Projectid;
            Gxm1sdtemployeeproject.gxTpr_Projectname = AV5EmployeeProject.gxTpr_Projectname;
            Gxm1sdtemployeeproject.gxTpr_Projectdescription = AV5EmployeeProject.gxTpr_Projectdescription;
            Gxm1sdtemployeeproject.gxTpr_Projectstatus = AV5EmployeeProject.gxTpr_Projectstatus;
            AV10GXV2 = (int)(AV10GXV2+1);
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
         AV9GXV1 = new GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem>( context, "SDTEmployeeProjectItem", "YTT_version4");
         GXt_objcol_SdtSDTEmployeeProject_SDTEmployeeProjectItem1 = new GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem>( context, "SDTEmployeeProjectItem", "YTT_version4");
         AV5EmployeeProject = new SdtSDTEmployeeProject_SDTEmployeeProjectItem(context);
         Gxm1sdtemployeeproject = new SdtSDTEmployeeProject_SDTEmployeeProjectItem(context);
         /* GeneXus formulas. */
      }

      private int AV10GXV2 ;
      private long AV6EmployeeId ;
      private GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> Gxm2rootcol ;
      private GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> AV9GXV1 ;
      private GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> GXt_objcol_SdtSDTEmployeeProject_SDTEmployeeProjectItem1 ;
      private SdtSDTEmployeeProject_SDTEmployeeProjectItem AV5EmployeeProject ;
      private SdtSDTEmployeeProject_SDTEmployeeProjectItem Gxm1sdtemployeeproject ;
      private GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> aP1_Gxm2rootcol ;
   }

}
