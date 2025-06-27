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
   public class procgetemployeeleavetotal : GXProcedure
   {
      public procgetemployeeleavetotal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public procgetemployeeleavetotal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           DateTime aP1_DateFrom ,
                           DateTime aP2_DateTo ,
                           out long aP3_TotalLeaveHours )
      {
         this.AV2EmployeeId = aP0_EmployeeId;
         this.AV3DateFrom = aP1_DateFrom;
         this.AV4DateTo = aP2_DateTo;
         this.AV5TotalLeaveHours = 0 ;
         initialize();
         ExecuteImpl();
         aP3_TotalLeaveHours=this.AV5TotalLeaveHours;
      }

      public long executeUdp( long aP0_EmployeeId ,
                              DateTime aP1_DateFrom ,
                              DateTime aP2_DateTo )
      {
         execute(aP0_EmployeeId, aP1_DateFrom, aP2_DateTo, out aP3_TotalLeaveHours);
         return AV5TotalLeaveHours ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 DateTime aP1_DateFrom ,
                                 DateTime aP2_DateTo ,
                                 out long aP3_TotalLeaveHours )
      {
         this.AV2EmployeeId = aP0_EmployeeId;
         this.AV3DateFrom = aP1_DateFrom;
         this.AV4DateTo = aP2_DateTo;
         this.AV5TotalLeaveHours = 0 ;
         SubmitImpl();
         aP3_TotalLeaveHours=this.AV5TotalLeaveHours;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2EmployeeId,(DateTime)AV3DateFrom,(DateTime)AV4DateTo,(long)AV5TotalLeaveHours} ;
         ClassLoader.Execute("aprocgetemployeeleavetotal","GeneXus.Programs","aprocgetemployeeleavetotal", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 4 ) )
         {
            AV5TotalLeaveHours = (long)(args[3]) ;
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
      private long AV5TotalLeaveHours ;
      private DateTime AV3DateFrom ;
      private DateTime AV4DateTo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private long aP3_TotalLeaveHours ;
   }

}
