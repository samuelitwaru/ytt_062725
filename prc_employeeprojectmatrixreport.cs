using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
   public class prc_employeeprojectmatrixreport : GXProcedure
   {
      public prc_employeeprojectmatrixreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_employeeprojectmatrixreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           GxSimpleCollection<long> aP2_ProjectIdCollection ,
                           GxSimpleCollection<long> aP3_CompanyLocationIdCollection ,
                           GxSimpleCollection<long> aP4_EmployeeIdCollection ,
                           GxSimpleCollection<long> aP5_UserEmployeeIdCollection ,
                           bool aP6_ShowLeave ,
                           out long aP7_OverallTotalHours ,
                           out GXBaseCollection<SdtSDT_EmployeeProjectMatrix> aP8_SDT_EmployeeProjectMatrixCollection )
      {
         this.AV2FromDate = aP0_FromDate;
         this.AV3ToDate = aP1_ToDate;
         this.AV4ProjectIdCollection = aP2_ProjectIdCollection;
         this.AV5CompanyLocationIdCollection = aP3_CompanyLocationIdCollection;
         this.AV6EmployeeIdCollection = aP4_EmployeeIdCollection;
         this.AV7UserEmployeeIdCollection = aP5_UserEmployeeIdCollection;
         this.AV8ShowLeave = aP6_ShowLeave;
         this.AV9OverallTotalHours = 0 ;
         this.AV10SDT_EmployeeProjectMatrixCollection = new GXBaseCollection<SdtSDT_EmployeeProjectMatrix>( context, "SDT_EmployeeProjectMatrix", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP7_OverallTotalHours=this.AV9OverallTotalHours;
         aP8_SDT_EmployeeProjectMatrixCollection=this.AV10SDT_EmployeeProjectMatrixCollection;
      }

      public GXBaseCollection<SdtSDT_EmployeeProjectMatrix> executeUdp( DateTime aP0_FromDate ,
                                                                        DateTime aP1_ToDate ,
                                                                        GxSimpleCollection<long> aP2_ProjectIdCollection ,
                                                                        GxSimpleCollection<long> aP3_CompanyLocationIdCollection ,
                                                                        GxSimpleCollection<long> aP4_EmployeeIdCollection ,
                                                                        GxSimpleCollection<long> aP5_UserEmployeeIdCollection ,
                                                                        bool aP6_ShowLeave ,
                                                                        out long aP7_OverallTotalHours )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_ProjectIdCollection, aP3_CompanyLocationIdCollection, aP4_EmployeeIdCollection, aP5_UserEmployeeIdCollection, aP6_ShowLeave, out aP7_OverallTotalHours, out aP8_SDT_EmployeeProjectMatrixCollection);
         return AV10SDT_EmployeeProjectMatrixCollection ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<long> aP2_ProjectIdCollection ,
                                 GxSimpleCollection<long> aP3_CompanyLocationIdCollection ,
                                 GxSimpleCollection<long> aP4_EmployeeIdCollection ,
                                 GxSimpleCollection<long> aP5_UserEmployeeIdCollection ,
                                 bool aP6_ShowLeave ,
                                 out long aP7_OverallTotalHours ,
                                 out GXBaseCollection<SdtSDT_EmployeeProjectMatrix> aP8_SDT_EmployeeProjectMatrixCollection )
      {
         this.AV2FromDate = aP0_FromDate;
         this.AV3ToDate = aP1_ToDate;
         this.AV4ProjectIdCollection = aP2_ProjectIdCollection;
         this.AV5CompanyLocationIdCollection = aP3_CompanyLocationIdCollection;
         this.AV6EmployeeIdCollection = aP4_EmployeeIdCollection;
         this.AV7UserEmployeeIdCollection = aP5_UserEmployeeIdCollection;
         this.AV8ShowLeave = aP6_ShowLeave;
         this.AV9OverallTotalHours = 0 ;
         this.AV10SDT_EmployeeProjectMatrixCollection = new GXBaseCollection<SdtSDT_EmployeeProjectMatrix>( context, "SDT_EmployeeProjectMatrix", "YTT_version4") ;
         SubmitImpl();
         aP7_OverallTotalHours=this.AV9OverallTotalHours;
         aP8_SDT_EmployeeProjectMatrixCollection=this.AV10SDT_EmployeeProjectMatrixCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(DateTime)AV2FromDate,(DateTime)AV3ToDate,(GxSimpleCollection<long>)AV4ProjectIdCollection,(GxSimpleCollection<long>)AV5CompanyLocationIdCollection,(GxSimpleCollection<long>)AV6EmployeeIdCollection,(GxSimpleCollection<long>)AV7UserEmployeeIdCollection,(bool)AV8ShowLeave,(long)AV9OverallTotalHours,(GXBaseCollection<SdtSDT_EmployeeProjectMatrix>)AV10SDT_EmployeeProjectMatrixCollection} ;
         ClassLoader.Execute("aprc_employeeprojectmatrixreport","GeneXus.Programs","aprc_employeeprojectmatrixreport", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 9 ) )
         {
            AV9OverallTotalHours = (long)(args[7]) ;
            AV10SDT_EmployeeProjectMatrixCollection = (GXBaseCollection<SdtSDT_EmployeeProjectMatrix>)(args[8]) ;
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
      }

      public override void initialize( )
      {
         AV10SDT_EmployeeProjectMatrixCollection = new GXBaseCollection<SdtSDT_EmployeeProjectMatrix>( context, "SDT_EmployeeProjectMatrix", "YTT_version4");
         /* GeneXus formulas. */
      }

      private long AV9OverallTotalHours ;
      private DateTime AV2FromDate ;
      private DateTime AV3ToDate ;
      private bool AV8ShowLeave ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV4ProjectIdCollection ;
      private GxSimpleCollection<long> AV5CompanyLocationIdCollection ;
      private GxSimpleCollection<long> AV6EmployeeIdCollection ;
      private GxSimpleCollection<long> AV7UserEmployeeIdCollection ;
      private GXBaseCollection<SdtSDT_EmployeeProjectMatrix> AV10SDT_EmployeeProjectMatrixCollection ;
      private Object[] args ;
      private long aP7_OverallTotalHours ;
      private GXBaseCollection<SdtSDT_EmployeeProjectMatrix> aP8_SDT_EmployeeProjectMatrixCollection ;
   }

}
