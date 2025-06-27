using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class api_timetracker : GXProcedure
   {
      public api_timetracker( )
      {
         context = new GxContext(  );
         IsMain = true;
         IsApiObject = true;
         initialize();
      }

      public api_timetracker( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         initialize();
         if ( context.HttpContext != null )
         {
            Gx_restmethod = (string)(context.HttpContext.Request.Method);
         }
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cleanup();
      }

      public void InitLocation( )
      {
         restLocation = new GxLocation();
         restLocation.Host = "localhost";
         restLocation.Port = 8082;
         restLocation.BaseUrl = "YTT_version4NETPostgreSQL14/api";
         gxProperties = new GxObjectProperties();
      }

      public GxObjectProperties ObjProperties
      {
         get {
            return gxProperties ;
         }

         set {
            gxProperties = value ;
         }

      }

      public void SetObjectProperties( GxObjectProperties gxobjppt )
      {
         gxProperties = gxobjppt ;
         restLocation = gxobjppt.Location ;
      }

      public void gxep_api_icsleaveapi( string aP0_Username ,
                                        string aP1_Password ,
                                        out string aP2_ICSLeaveExport )
      {
         restCliAPI_ICSLeaveAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/export-ics-leaves";
         restCliAPI_ICSLeaveAPI.Location = restLocation;
         restCliAPI_ICSLeaveAPI.HttpMethod = "POST";
         restCliAPI_ICSLeaveAPI.AddBodyVar("Username", (string)(aP0_Username));
         restCliAPI_ICSLeaveAPI.AddBodyVar("Password", (string)(aP1_Password));
         restCliAPI_ICSLeaveAPI.RestExecute();
         if ( restCliAPI_ICSLeaveAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliAPI_ICSLeaveAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliAPI_ICSLeaveAPI.ErrorMessage;
            gxProperties.StatusCode = restCliAPI_ICSLeaveAPI.StatusCode;
            aP2_ICSLeaveExport = "";
         }
         else
         {
            aP2_ICSLeaveExport = restCliAPI_ICSLeaveAPI.GetBodyString("ICSLeaveExport");
         }
         /* API_ICSLeaveAPI Constructor */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         gxProperties = new GxObjectProperties();
         restCliAPI_ICSLeaveAPI = new GXRestAPIClient();
         aP2_ICSLeaveExport = "";
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected GXRestAPIClient restCliAPI_ICSLeaveAPI ;
      protected GxLocation restLocation ;
      protected GxObjectProperties gxProperties ;
      protected string aP2_ICSLeaveExport ;
   }

}
