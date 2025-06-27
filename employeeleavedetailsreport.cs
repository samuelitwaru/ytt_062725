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
   public class employeeleavedetailsreport : GXProcedure
   {
      public employeeleavedetailsreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public employeeleavedetailsreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           GxSimpleCollection<long> aP2_EmployeeIdCollection ,
                           long aP3_CompanyLocationId ,
                           out GXBaseCollection<SdtSDTEmployeeLeaveDetails> aP4_SDTEmployeeLeaveDetailsCollection )
      {
         this.AV2FromDate = aP0_FromDate;
         this.AV3ToDate = aP1_ToDate;
         this.AV4EmployeeIdCollection = aP2_EmployeeIdCollection;
         this.AV5CompanyLocationId = aP3_CompanyLocationId;
         this.AV6SDTEmployeeLeaveDetailsCollection = new GXBaseCollection<SdtSDTEmployeeLeaveDetails>( context, "SDTEmployeeLeaveDetails", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP4_SDTEmployeeLeaveDetailsCollection=this.AV6SDTEmployeeLeaveDetailsCollection;
      }

      public GXBaseCollection<SdtSDTEmployeeLeaveDetails> executeUdp( DateTime aP0_FromDate ,
                                                                      DateTime aP1_ToDate ,
                                                                      GxSimpleCollection<long> aP2_EmployeeIdCollection ,
                                                                      long aP3_CompanyLocationId )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_EmployeeIdCollection, aP3_CompanyLocationId, out aP4_SDTEmployeeLeaveDetailsCollection);
         return AV6SDTEmployeeLeaveDetailsCollection ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<long> aP2_EmployeeIdCollection ,
                                 long aP3_CompanyLocationId ,
                                 out GXBaseCollection<SdtSDTEmployeeLeaveDetails> aP4_SDTEmployeeLeaveDetailsCollection )
      {
         this.AV2FromDate = aP0_FromDate;
         this.AV3ToDate = aP1_ToDate;
         this.AV4EmployeeIdCollection = aP2_EmployeeIdCollection;
         this.AV5CompanyLocationId = aP3_CompanyLocationId;
         this.AV6SDTEmployeeLeaveDetailsCollection = new GXBaseCollection<SdtSDTEmployeeLeaveDetails>( context, "SDTEmployeeLeaveDetails", "YTT_version4") ;
         SubmitImpl();
         aP4_SDTEmployeeLeaveDetailsCollection=this.AV6SDTEmployeeLeaveDetailsCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(DateTime)AV2FromDate,(DateTime)AV3ToDate,(GxSimpleCollection<long>)AV4EmployeeIdCollection,(long)AV5CompanyLocationId,(GXBaseCollection<SdtSDTEmployeeLeaveDetails>)AV6SDTEmployeeLeaveDetailsCollection} ;
         ClassLoader.Execute("aemployeeleavedetailsreport","GeneXus.Programs","aemployeeleavedetailsreport", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 5 ) )
         {
            AV6SDTEmployeeLeaveDetailsCollection = (GXBaseCollection<SdtSDTEmployeeLeaveDetails>)(args[4]) ;
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
         AV6SDTEmployeeLeaveDetailsCollection = new GXBaseCollection<SdtSDTEmployeeLeaveDetails>( context, "SDTEmployeeLeaveDetails", "YTT_version4");
         /* GeneXus formulas. */
      }

      private long AV5CompanyLocationId ;
      private DateTime AV2FromDate ;
      private DateTime AV3ToDate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV4EmployeeIdCollection ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDetails> AV6SDTEmployeeLeaveDetailsCollection ;
      private Object[] args ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDetails> aP4_SDTEmployeeLeaveDetailsCollection ;
   }

}
