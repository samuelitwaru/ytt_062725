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
   public class formatdatetime : GXProcedure
   {
      public formatdatetime( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public formatdatetime( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_Date ,
                           string aP1_DateTimeFormat ,
                           out string aP2_FinalDateString )
      {
         this.AV2Date = aP0_Date;
         this.AV3DateTimeFormat = aP1_DateTimeFormat;
         this.AV4FinalDateString = "" ;
         initialize();
         ExecuteImpl();
         aP2_FinalDateString=this.AV4FinalDateString;
      }

      public string executeUdp( DateTime aP0_Date ,
                                string aP1_DateTimeFormat )
      {
         execute(aP0_Date, aP1_DateTimeFormat, out aP2_FinalDateString);
         return AV4FinalDateString ;
      }

      public void executeSubmit( DateTime aP0_Date ,
                                 string aP1_DateTimeFormat ,
                                 out string aP2_FinalDateString )
      {
         this.AV2Date = aP0_Date;
         this.AV3DateTimeFormat = aP1_DateTimeFormat;
         this.AV4FinalDateString = "" ;
         SubmitImpl();
         aP2_FinalDateString=this.AV4FinalDateString;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(DateTime)AV2Date,(string)AV3DateTimeFormat,(string)AV4FinalDateString} ;
         ClassLoader.Execute("aformatdatetime","GeneXus.Programs","aformatdatetime", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
            AV4FinalDateString = (string)(args[2]) ;
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
         AV4FinalDateString = "";
         /* GeneXus formulas. */
      }

      private string AV3DateTimeFormat ;
      private string AV4FinalDateString ;
      private DateTime AV2Date ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP2_FinalDateString ;
   }

}
