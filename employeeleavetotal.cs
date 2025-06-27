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
   public class employeeleavetotal : GXProcedure
   {
      public employeeleavetotal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public employeeleavetotal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           DateTime aP1_FromDate ,
                           DateTime aP2_ToDate ,
                           out short aP3_Duration )
      {
         this.AV2EmployeeId = aP0_EmployeeId;
         this.AV3FromDate = aP1_FromDate;
         this.AV4ToDate = aP2_ToDate;
         this.AV5Duration = 0 ;
         initialize();
         ExecuteImpl();
         aP3_Duration=this.AV5Duration;
      }

      public short executeUdp( long aP0_EmployeeId ,
                               DateTime aP1_FromDate ,
                               DateTime aP2_ToDate )
      {
         execute(aP0_EmployeeId, aP1_FromDate, aP2_ToDate, out aP3_Duration);
         return AV5Duration ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 DateTime aP1_FromDate ,
                                 DateTime aP2_ToDate ,
                                 out short aP3_Duration )
      {
         this.AV2EmployeeId = aP0_EmployeeId;
         this.AV3FromDate = aP1_FromDate;
         this.AV4ToDate = aP2_ToDate;
         this.AV5Duration = 0 ;
         SubmitImpl();
         aP3_Duration=this.AV5Duration;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2EmployeeId,(DateTime)AV3FromDate,(DateTime)AV4ToDate,(short)AV5Duration} ;
         ClassLoader.Execute("aemployeeleavetotal","GeneXus.Programs","aemployeeleavetotal", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 4 ) )
         {
            AV5Duration = (short)(args[3]) ;
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

      private short AV5Duration ;
      private long AV2EmployeeId ;
      private DateTime AV3FromDate ;
      private DateTime AV4ToDate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private short aP3_Duration ;
   }

}
