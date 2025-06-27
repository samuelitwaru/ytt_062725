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
   public class employeeleavereport : GXProcedure
   {
      public employeeleavereport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public employeeleavereport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_CompanyLocationId ,
                           ref GxSimpleCollection<long> aP1_EmployeeIds ,
                           ref DateTime aP2_Date ,
                           out string aP3_Filename ,
                           out string aP4_ErrorMessage )
      {
         this.AV2CompanyLocationId = aP0_CompanyLocationId;
         this.AV3EmployeeIds = aP1_EmployeeIds;
         this.AV4Date = aP2_Date;
         this.AV5Filename = "" ;
         this.AV6ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP1_EmployeeIds=this.AV3EmployeeIds;
         aP2_Date=this.AV4Date;
         aP3_Filename=this.AV5Filename;
         aP4_ErrorMessage=this.AV6ErrorMessage;
      }

      public string executeUdp( long aP0_CompanyLocationId ,
                                ref GxSimpleCollection<long> aP1_EmployeeIds ,
                                ref DateTime aP2_Date ,
                                out string aP3_Filename )
      {
         execute(aP0_CompanyLocationId, ref aP1_EmployeeIds, ref aP2_Date, out aP3_Filename, out aP4_ErrorMessage);
         return AV6ErrorMessage ;
      }

      public void executeSubmit( long aP0_CompanyLocationId ,
                                 ref GxSimpleCollection<long> aP1_EmployeeIds ,
                                 ref DateTime aP2_Date ,
                                 out string aP3_Filename ,
                                 out string aP4_ErrorMessage )
      {
         this.AV2CompanyLocationId = aP0_CompanyLocationId;
         this.AV3EmployeeIds = aP1_EmployeeIds;
         this.AV4Date = aP2_Date;
         this.AV5Filename = "" ;
         this.AV6ErrorMessage = "" ;
         SubmitImpl();
         aP1_EmployeeIds=this.AV3EmployeeIds;
         aP2_Date=this.AV4Date;
         aP3_Filename=this.AV5Filename;
         aP4_ErrorMessage=this.AV6ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2CompanyLocationId,(GxSimpleCollection<long>)AV3EmployeeIds,(DateTime)AV4Date,(string)AV5Filename,(string)AV6ErrorMessage} ;
         ClassLoader.Execute("aemployeeleavereport","GeneXus.Programs","aemployeeleavereport", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 5 ) )
         {
            AV3EmployeeIds = (GxSimpleCollection<long>)(args[1]) ;
            AV4Date = (DateTime)(args[2]) ;
            AV5Filename = (string)(args[3]) ;
            AV6ErrorMessage = (string)(args[4]) ;
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
         AV5Filename = "";
         AV6ErrorMessage = "";
         /* GeneXus formulas. */
      }

      private long AV2CompanyLocationId ;
      private string AV5Filename ;
      private DateTime AV4Date ;
      private string AV6ErrorMessage ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV3EmployeeIds ;
      private GxSimpleCollection<long> aP1_EmployeeIds ;
      private DateTime aP2_Date ;
      private Object[] args ;
      private string aP3_Filename ;
      private string aP4_ErrorMessage ;
   }

}
