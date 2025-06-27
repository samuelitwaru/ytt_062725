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
   public class dpleavereport : GXProcedure
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

      public dpleavereport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpleavereport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( DateTime aP0_StartDate ,
                           DateTime aP1_EndDate ,
                           long aP2_EmployeeId ,
                           long aP3_LocationId ,
                           GxSimpleCollection<long> aP4_ProjectId ,
                           short aP5_PeriodicCategory ,
                           out SdtSDTLeaveReport aP6_Gxm1sdtleavereport )
      {
         this.AV5StartDate = aP0_StartDate;
         this.AV11EndDate = aP1_EndDate;
         this.AV7EmployeeId = aP2_EmployeeId;
         this.AV8LocationId = aP3_LocationId;
         this.AV12ProjectId = aP4_ProjectId;
         this.AV6PeriodicCategory = aP5_PeriodicCategory;
         this.Gxm1sdtleavereport = new SdtSDTLeaveReport(context) ;
         initialize();
         ExecuteImpl();
         aP6_Gxm1sdtleavereport=this.Gxm1sdtleavereport;
      }

      public SdtSDTLeaveReport executeUdp( DateTime aP0_StartDate ,
                                           DateTime aP1_EndDate ,
                                           long aP2_EmployeeId ,
                                           long aP3_LocationId ,
                                           GxSimpleCollection<long> aP4_ProjectId ,
                                           short aP5_PeriodicCategory )
      {
         execute(aP0_StartDate, aP1_EndDate, aP2_EmployeeId, aP3_LocationId, aP4_ProjectId, aP5_PeriodicCategory, out aP6_Gxm1sdtleavereport);
         return Gxm1sdtleavereport ;
      }

      public void executeSubmit( DateTime aP0_StartDate ,
                                 DateTime aP1_EndDate ,
                                 long aP2_EmployeeId ,
                                 long aP3_LocationId ,
                                 GxSimpleCollection<long> aP4_ProjectId ,
                                 short aP5_PeriodicCategory ,
                                 out SdtSDTLeaveReport aP6_Gxm1sdtleavereport )
      {
         this.AV5StartDate = aP0_StartDate;
         this.AV11EndDate = aP1_EndDate;
         this.AV7EmployeeId = aP2_EmployeeId;
         this.AV8LocationId = aP3_LocationId;
         this.AV12ProjectId = aP4_ProjectId;
         this.AV6PeriodicCategory = aP5_PeriodicCategory;
         this.Gxm1sdtleavereport = new SdtSDTLeaveReport(context) ;
         SubmitImpl();
         aP6_Gxm1sdtleavereport=this.Gxm1sdtleavereport;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_objcol_SdtSDTLeaveReport_PeriodCollectionItem1 = AV9Periods;
         new procgetperiodicleavehours(context ).execute(  AV5StartDate,  AV11EndDate,  AV12ProjectId,  AV7EmployeeId,  AV8LocationId,  AV6PeriodicCategory, out  GXt_objcol_SdtSDTLeaveReport_PeriodCollectionItem1) ;
         AV9Periods = GXt_objcol_SdtSDTLeaveReport_PeriodCollectionItem1;
         Gxm1sdtleavereport.gxTpr_Fromdate = AV5StartDate;
         Gxm1sdtleavereport.gxTpr_Todate = AV11EndDate;
         AV15GXV1 = 1;
         while ( AV15GXV1 <= AV9Periods.Count )
         {
            AV10Period = ((SdtSDTLeaveReport_PeriodCollectionItem)AV9Periods.Item(AV15GXV1));
            Gxm2sdtleavereport_periodcollection = new SdtSDTLeaveReport_PeriodCollectionItem(context);
            Gxm1sdtleavereport.gxTpr_Periodcollection.Add(Gxm2sdtleavereport_periodcollection, 0);
            Gxm2sdtleavereport_periodcollection.gxTpr_Fromdate = AV10Period.gxTpr_Fromdate;
            Gxm2sdtleavereport_periodcollection.gxTpr_Todate = AV10Period.gxTpr_Todate;
            Gxm2sdtleavereport_periodcollection.gxTpr_Label = AV10Period.gxTpr_Label;
            Gxm2sdtleavereport_periodcollection.gxTpr_Mean = 0;
            Gxm2sdtleavereport_periodcollection.gxTpr_Number = 0;
            Gxm2sdtleavereport_periodcollection.gxTpr_Totalleave = AV10Period.gxTpr_Totalleave;
            GXt_char2 = "";
            new procformattime(context ).execute(  AV10Period.gxTpr_Totalleave, out  GXt_char2) ;
            Gxm2sdtleavereport_periodcollection.gxTpr_Formattedtotalleave = GXt_char2;
            Gxm2sdtleavereport_periodcollection.gxTpr_Totalwork = AV10Period.gxTpr_Totalwork;
            GXt_char2 = "";
            new procformattime(context ).execute(  AV10Period.gxTpr_Totalwork, out  GXt_char2) ;
            Gxm2sdtleavereport_periodcollection.gxTpr_Formattedtotalwork = GXt_char2;
            AV15GXV1 = (int)(AV15GXV1+1);
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
         AV9Periods = new GXBaseCollection<SdtSDTLeaveReport_PeriodCollectionItem>( context, "SDTLeaveReport.PeriodCollectionItem", "YTT_version4");
         GXt_objcol_SdtSDTLeaveReport_PeriodCollectionItem1 = new GXBaseCollection<SdtSDTLeaveReport_PeriodCollectionItem>( context, "SDTLeaveReport.PeriodCollectionItem", "YTT_version4");
         AV10Period = new SdtSDTLeaveReport_PeriodCollectionItem(context);
         Gxm2sdtleavereport_periodcollection = new SdtSDTLeaveReport_PeriodCollectionItem(context);
         GXt_char2 = "";
         /* GeneXus formulas. */
      }

      private short AV6PeriodicCategory ;
      private int AV15GXV1 ;
      private long AV7EmployeeId ;
      private long AV8LocationId ;
      private string GXt_char2 ;
      private DateTime AV5StartDate ;
      private DateTime AV11EndDate ;
      private GxSimpleCollection<long> AV12ProjectId ;
      private SdtSDTLeaveReport Gxm1sdtleavereport ;
      private GXBaseCollection<SdtSDTLeaveReport_PeriodCollectionItem> AV9Periods ;
      private GXBaseCollection<SdtSDTLeaveReport_PeriodCollectionItem> GXt_objcol_SdtSDTLeaveReport_PeriodCollectionItem1 ;
      private SdtSDTLeaveReport_PeriodCollectionItem AV10Period ;
      private SdtSDTLeaveReport_PeriodCollectionItem Gxm2sdtleavereport_periodcollection ;
      private SdtSDTLeaveReport aP6_Gxm1sdtleavereport ;
   }

}
