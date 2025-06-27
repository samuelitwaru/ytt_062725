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
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel ApiIntegratedSecurityLevel( string permissionMethod )
      {
         if ( StringUtil.StrCmp(permissionMethod, "gxep_api_icsleaveapi") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         return GAMSecurityLevel.SecurityLow ;
      }

      protected override string ApiExecutePermissionPrefix( string permissionMethod )
      {
         return "" ;
      }

      public api_timetracker( )
      {
         context = new GxContext(  );
         IsMain = true;
         IsApiObject = true;
      }

      public api_timetracker( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
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

      public void gxep_api_icsleaveapi( string aP0_Username ,
                                        string aP1_Password ,
                                        out string aP2_ICSLeaveExport )
      {
         this.AV12Username = aP0_Username;
         this.AV11Password = aP1_Password;
         initialize();
         /* API_ICSLeaveAPI Constructor */
         context.wjLoc = "aprc_icsleaveapi.aspx"+ "?" + GXUtil.UrlEncode(StringUtil.RTrim(AV12Username)) + "," + GXUtil.UrlEncode(StringUtil.RTrim(AV11Password)) + "," + GXUtil.UrlEncode(StringUtil.RTrim(AV10ICSLeaveExport));
         aP2_ICSLeaveExport=this.AV10ICSLeaveExport;
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         AV10ICSLeaveExport = "";
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected string AV10ICSLeaveExport ;
      protected string AV12Username ;
      protected string AV11Password ;
      protected string aP2_ICSLeaveExport ;
   }

}
