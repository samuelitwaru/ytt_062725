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
   public class prc_getweeklyhours : GXProcedure
   {
      public prc_getweeklyhours( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getweeklyhours( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( DateTime aP0_WeekDate ,
                           long aP1_EmployeeId ,
                           out string aP2_WeeklyTotal ,
                           out string aP3_DailyTotal ,
                           out string aP4_MonthlyTotal )
      {
         this.AV8WeekDate = aP0_WeekDate;
         this.AV9EmployeeId = aP1_EmployeeId;
         this.AV10WeeklyTotal = "" ;
         this.AV11DailyTotal = "" ;
         this.AV12MonthlyTotal = "" ;
         initialize();
         ExecuteImpl();
         aP2_WeeklyTotal=this.AV10WeeklyTotal;
         aP3_DailyTotal=this.AV11DailyTotal;
         aP4_MonthlyTotal=this.AV12MonthlyTotal;
      }

      public string executeUdp( DateTime aP0_WeekDate ,
                                long aP1_EmployeeId ,
                                out string aP2_WeeklyTotal ,
                                out string aP3_DailyTotal )
      {
         execute(aP0_WeekDate, aP1_EmployeeId, out aP2_WeeklyTotal, out aP3_DailyTotal, out aP4_MonthlyTotal);
         return AV12MonthlyTotal ;
      }

      public void executeSubmit( DateTime aP0_WeekDate ,
                                 long aP1_EmployeeId ,
                                 out string aP2_WeeklyTotal ,
                                 out string aP3_DailyTotal ,
                                 out string aP4_MonthlyTotal )
      {
         this.AV8WeekDate = aP0_WeekDate;
         this.AV9EmployeeId = aP1_EmployeeId;
         this.AV10WeeklyTotal = "" ;
         this.AV11DailyTotal = "" ;
         this.AV12MonthlyTotal = "" ;
         SubmitImpl();
         aP2_WeeklyTotal=this.AV10WeeklyTotal;
         aP3_DailyTotal=this.AV11DailyTotal;
         aP4_MonthlyTotal=this.AV12MonthlyTotal;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
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
         AV10WeeklyTotal = "";
         AV11DailyTotal = "";
         AV12MonthlyTotal = "";
         /* GeneXus formulas. */
      }

      private long AV9EmployeeId ;
      private string AV10WeeklyTotal ;
      private string AV11DailyTotal ;
      private string AV12MonthlyTotal ;
      private DateTime AV8WeekDate ;
      private string aP2_WeeklyTotal ;
      private string aP3_DailyTotal ;
      private string aP4_MonthlyTotal ;
   }

}
