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
   public class prc_icsleaveexport : GXProcedure
   {
      public prc_icsleaveexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prc_icsleaveexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProjectId ,
                           long aP1_LeaveTypeId ,
                           string aP2_Token )
      {
         this.AV2ProjectId = aP0_ProjectId;
         this.AV3LeaveTypeId = aP1_LeaveTypeId;
         this.AV4Token = aP2_Token;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( long aP0_ProjectId ,
                                 long aP1_LeaveTypeId ,
                                 string aP2_Token )
      {
         this.AV2ProjectId = aP0_ProjectId;
         this.AV3LeaveTypeId = aP1_LeaveTypeId;
         this.AV4Token = aP2_Token;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2ProjectId,(long)AV3LeaveTypeId,(string)AV4Token} ;
         ClassLoader.Execute("aprc_icsleaveexport","GeneXus.Programs","aprc_icsleaveexport", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
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

      private long AV2ProjectId ;
      private long AV3LeaveTypeId ;
      private string AV4Token ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
