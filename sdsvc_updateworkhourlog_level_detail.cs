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
   public class sdsvc_updateworkhourlog_level_detail : GXProcedure
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
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public sdsvc_updateworkhourlog_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public sdsvc_updateworkhourlog_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
      }

      public GxJsonArray WorkLogProject_DS( )
      {
         initialize();
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> gxcolvWORKLOGPROJECT;
         SdtSDTEmployeeProject_SDTEmployeeProjectItem gxcolitemvWORKLOGPROJECT;
         GXt_objcol_SdtSDTEmployeeProject_SDTEmployeeProjectItem1 = new GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem>();
         new dpemployeeprojects(context ).execute(  (long)(gxcolvWORKLOGPROJECT), out  GXt_objcol_SdtSDTEmployeeProject_SDTEmployeeProjectItem1) ;
         gxcolvWORKLOGPROJECT.Sort("Projectname");
         int gxindex = 1;
         while ( gxindex <= gxcolvWORKLOGPROJECT.Count )
         {
            gxcolitemvWORKLOGPROJECT = ((SdtSDTEmployeeProject_SDTEmployeeProjectItem)gxcolvWORKLOGPROJECT.Item(gxindex));
            gxdynajaxctrlcodr.Add(StringUtil.LTrimStr( (decimal)(gxcolitemvWORKLOGPROJECT.gxTpr_Projectid), 10, 0));
            gxdynajaxctrldescr.Add(gxcolitemvWORKLOGPROJECT.gxTpr_Projectname);
            gxindex = (int)(gxindex+1);
         }
         cleanup();
         return GXUtil.StringCollectionsToJsonObj( gxdynajaxctrlcodr, gxdynajaxctrldescr) ;
         /* End function WorkLogProject_DS */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         GXt_objcol_SdtSDTEmployeeProject_SDTEmployeeProjectItem1 = new GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem>( context, "SDTEmployeeProjectItem", "YTT_version4");
         /* GeneXus formulas. */
      }

      protected GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      protected GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      protected GXBaseCollection<SdtSDTEmployeeProject_SDTEmployeeProjectItem> GXt_objcol_SdtSDTEmployeeProject_SDTEmployeeProjectItem1 ;
   }

}
