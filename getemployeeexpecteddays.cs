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
   public class getemployeeexpecteddays : GXProcedure
   {
      public getemployeeexpecteddays( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public getemployeeexpecteddays( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_EmployeeId ,
                           ref DateTime aP1_FromDate ,
                           ref DateTime aP2_ToDate ,
                           out decimal aP3_ExpectedWorkDays )
      {
         this.AV2EmployeeId = aP0_EmployeeId;
         this.AV3FromDate = aP1_FromDate;
         this.AV4ToDate = aP2_ToDate;
         this.AV5ExpectedWorkDays = 0 ;
         initialize();
         ExecuteImpl();
         aP0_EmployeeId=this.AV2EmployeeId;
         aP1_FromDate=this.AV3FromDate;
         aP2_ToDate=this.AV4ToDate;
         aP3_ExpectedWorkDays=this.AV5ExpectedWorkDays;
      }

      public decimal executeUdp( ref long aP0_EmployeeId ,
                                 ref DateTime aP1_FromDate ,
                                 ref DateTime aP2_ToDate )
      {
         execute(ref aP0_EmployeeId, ref aP1_FromDate, ref aP2_ToDate, out aP3_ExpectedWorkDays);
         return AV5ExpectedWorkDays ;
      }

      public void executeSubmit( ref long aP0_EmployeeId ,
                                 ref DateTime aP1_FromDate ,
                                 ref DateTime aP2_ToDate ,
                                 out decimal aP3_ExpectedWorkDays )
      {
         this.AV2EmployeeId = aP0_EmployeeId;
         this.AV3FromDate = aP1_FromDate;
         this.AV4ToDate = aP2_ToDate;
         this.AV5ExpectedWorkDays = 0 ;
         SubmitImpl();
         aP0_EmployeeId=this.AV2EmployeeId;
         aP1_FromDate=this.AV3FromDate;
         aP2_ToDate=this.AV4ToDate;
         aP3_ExpectedWorkDays=this.AV5ExpectedWorkDays;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2EmployeeId,(DateTime)AV3FromDate,(DateTime)AV4ToDate,(decimal)AV5ExpectedWorkDays} ;
         ClassLoader.Execute("agetemployeeexpecteddays","GeneXus.Programs","agetemployeeexpecteddays", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 4 ) )
         {
            AV2EmployeeId = (long)(args[0]) ;
            AV3FromDate = (DateTime)(args[1]) ;
            AV4ToDate = (DateTime)(args[2]) ;
            AV5ExpectedWorkDays = (decimal)(args[3]) ;
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
         /* GeneXus formulas. */
      }

      private long AV2EmployeeId ;
      private decimal AV5ExpectedWorkDays ;
      private DateTime AV3FromDate ;
      private DateTime AV4ToDate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_EmployeeId ;
      private DateTime aP1_FromDate ;
      private DateTime aP2_ToDate ;
      private Object[] args ;
      private decimal aP3_ExpectedWorkDays ;
   }

}
