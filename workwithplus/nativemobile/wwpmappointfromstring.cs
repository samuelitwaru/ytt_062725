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
namespace GeneXus.Programs.workwithplus.nativemobile {
   public class wwpmappointfromstring : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "wwpmappointfromstring_Services_Execute" ;
         }

      }

      public wwpmappointfromstring( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwpmappointfromstring( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_SelectedItem ,
                           out Geospatial aP1_Geopoint )
      {
         this.AV12SelectedItem = aP0_SelectedItem;
         this.AV8Geopoint = new Geospatial() ;
         initialize();
         ExecuteImpl();
         aP1_Geopoint=this.AV8Geopoint;
      }

      public Geospatial executeUdp( string aP0_SelectedItem )
      {
         execute(aP0_SelectedItem, out aP1_Geopoint);
         return AV8Geopoint ;
      }

      public void executeSubmit( string aP0_SelectedItem ,
                                 out Geospatial aP1_Geopoint )
      {
         this.AV12SelectedItem = aP0_SelectedItem;
         this.AV8Geopoint = new Geospatial() ;
         SubmitImpl();
         aP1_Geopoint=this.AV8Geopoint;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! StringUtil.Contains( AV12SelectedItem, "POINT") )
         {
            AV10Latitude = "-34";
            AV11Longitude = "-56";
            AV9ItemList = (GxSimpleCollection<string>)(GxRegex.Split(AV12SelectedItem,","));
            if ( AV9ItemList.Count > 1 )
            {
               AV10Latitude = ((string)AV9ItemList.Item(1));
               AV11Longitude = ((string)AV9ItemList.Item(2));
            }
            AV8Geopoint = (Geospatial)(new Geospatial(StringUtil.Format( "POINT (%1 %2)", AV11Longitude, AV10Latitude, "", "", "", "", "", "", "")));
         }
         else
         {
            AV8Geopoint = (Geospatial)(new Geospatial(AV12SelectedItem));
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
         ExitApp();
      }

      public override void initialize( )
      {
         AV8Geopoint = (Geospatial)(new Geospatial());
         AV10Latitude = "";
         AV11Longitude = "";
         AV9ItemList = new GxSimpleCollection<string>();
         /* GeneXus formulas. */
      }

      private string AV12SelectedItem ;
      private string AV10Latitude ;
      private string AV11Longitude ;
      private Geospatial AV8Geopoint ;
      private GxSimpleCollection<string> AV9ItemList ;
      private Geospatial aP1_Geopoint ;
   }

}
