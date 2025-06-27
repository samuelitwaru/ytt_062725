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
   public class getloggedinusercompanyid : GXProcedure
   {
      public getloggedinusercompanyid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getloggedinusercompanyid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out long aP0_EmployeeCompanyId )
      {
         this.AV10EmployeeCompanyId = 0 ;
         initialize();
         ExecuteImpl();
         aP0_EmployeeCompanyId=this.AV10EmployeeCompanyId;
      }

      public long executeUdp( )
      {
         execute(out aP0_EmployeeCompanyId);
         return AV10EmployeeCompanyId ;
      }

      public void executeSubmit( out long aP0_EmployeeCompanyId )
      {
         this.AV10EmployeeCompanyId = 0 ;
         SubmitImpl();
         aP0_EmployeeCompanyId=this.AV10EmployeeCompanyId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new getloggedinuser(context ).execute( out  AV8GAMUser, out  AV9Employee) ;
         AV10EmployeeCompanyId = AV9Employee.gxTpr_Companyid;
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
         AV8GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV9Employee = new SdtEmployee(context);
         /* GeneXus formulas. */
      }

      private long AV10EmployeeCompanyId ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV8GAMUser ;
      private SdtEmployee AV9Employee ;
      private long aP0_EmployeeCompanyId ;
   }

}
