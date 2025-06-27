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
   public class employeeleavedetailsexport : GXProcedure
   {
      public employeeleavedetailsexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public employeeleavedetailsexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_CompanyLocationId ,
                           ref GxSimpleCollection<long> aP1_EmployeeIds ,
                           ref DateTime aP2_Date ,
                           ref GXBaseCollection<SdtSDTEmployeeLeaveDetails> aP3_SDTEmployeeLeaveDetailsCollection ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV2CompanyLocationId = aP0_CompanyLocationId;
         this.AV3EmployeeIds = aP1_EmployeeIds;
         this.AV4Date = aP2_Date;
         this.AV5SDTEmployeeLeaveDetailsCollection = aP3_SDTEmployeeLeaveDetailsCollection;
         this.AV6Filename = "" ;
         this.AV7ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP1_EmployeeIds=this.AV3EmployeeIds;
         aP2_Date=this.AV4Date;
         aP3_SDTEmployeeLeaveDetailsCollection=this.AV5SDTEmployeeLeaveDetailsCollection;
         aP4_Filename=this.AV6Filename;
         aP5_ErrorMessage=this.AV7ErrorMessage;
      }

      public string executeUdp( long aP0_CompanyLocationId ,
                                ref GxSimpleCollection<long> aP1_EmployeeIds ,
                                ref DateTime aP2_Date ,
                                ref GXBaseCollection<SdtSDTEmployeeLeaveDetails> aP3_SDTEmployeeLeaveDetailsCollection ,
                                out string aP4_Filename )
      {
         execute(aP0_CompanyLocationId, ref aP1_EmployeeIds, ref aP2_Date, ref aP3_SDTEmployeeLeaveDetailsCollection, out aP4_Filename, out aP5_ErrorMessage);
         return AV7ErrorMessage ;
      }

      public void executeSubmit( long aP0_CompanyLocationId ,
                                 ref GxSimpleCollection<long> aP1_EmployeeIds ,
                                 ref DateTime aP2_Date ,
                                 ref GXBaseCollection<SdtSDTEmployeeLeaveDetails> aP3_SDTEmployeeLeaveDetailsCollection ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         this.AV2CompanyLocationId = aP0_CompanyLocationId;
         this.AV3EmployeeIds = aP1_EmployeeIds;
         this.AV4Date = aP2_Date;
         this.AV5SDTEmployeeLeaveDetailsCollection = aP3_SDTEmployeeLeaveDetailsCollection;
         this.AV6Filename = "" ;
         this.AV7ErrorMessage = "" ;
         SubmitImpl();
         aP1_EmployeeIds=this.AV3EmployeeIds;
         aP2_Date=this.AV4Date;
         aP3_SDTEmployeeLeaveDetailsCollection=this.AV5SDTEmployeeLeaveDetailsCollection;
         aP4_Filename=this.AV6Filename;
         aP5_ErrorMessage=this.AV7ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2CompanyLocationId,(GxSimpleCollection<long>)AV3EmployeeIds,(DateTime)AV4Date,(GXBaseCollection<SdtSDTEmployeeLeaveDetails>)AV5SDTEmployeeLeaveDetailsCollection,(string)AV6Filename,(string)AV7ErrorMessage} ;
         ClassLoader.Execute("aemployeeleavedetailsexport","GeneXus.Programs","aemployeeleavedetailsexport", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 6 ) )
         {
            AV3EmployeeIds = (GxSimpleCollection<long>)(args[1]) ;
            AV4Date = (DateTime)(args[2]) ;
            AV5SDTEmployeeLeaveDetailsCollection = (GXBaseCollection<SdtSDTEmployeeLeaveDetails>)(args[3]) ;
            AV6Filename = (string)(args[4]) ;
            AV7ErrorMessage = (string)(args[5]) ;
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
         AV6Filename = "";
         AV7ErrorMessage = "";
         /* GeneXus formulas. */
      }

      private long AV2CompanyLocationId ;
      private string AV6Filename ;
      private DateTime AV4Date ;
      private string AV7ErrorMessage ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV3EmployeeIds ;
      private GxSimpleCollection<long> aP1_EmployeeIds ;
      private DateTime aP2_Date ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDetails> AV5SDTEmployeeLeaveDetailsCollection ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDetails> aP3_SDTEmployeeLeaveDetailsCollection ;
      private Object[] args ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
   }

}
