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
   public class getemployeelastloggedprojectweb : GXProcedure
   {
      public getemployeelastloggedprojectweb( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public getemployeelastloggedprojectweb( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           out long aP1_ProjectId )
      {
         this.AV2EmployeeId = aP0_EmployeeId;
         this.AV3ProjectId = 0 ;
         initialize();
         ExecuteImpl();
         aP1_ProjectId=this.AV3ProjectId;
      }

      public long executeUdp( long aP0_EmployeeId )
      {
         execute(aP0_EmployeeId, out aP1_ProjectId);
         return AV3ProjectId ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 out long aP1_ProjectId )
      {
         this.AV2EmployeeId = aP0_EmployeeId;
         this.AV3ProjectId = 0 ;
         SubmitImpl();
         aP1_ProjectId=this.AV3ProjectId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2EmployeeId,(long)AV3ProjectId} ;
         ClassLoader.Execute("agetemployeelastloggedprojectweb","GeneXus.Programs","agetemployeelastloggedprojectweb", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
            AV3ProjectId = (long)(args[1]) ;
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
      private long AV3ProjectId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private long aP1_ProjectId ;
   }

}
