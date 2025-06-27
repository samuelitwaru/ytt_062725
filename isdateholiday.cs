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
   public class isdateholiday : GXProcedure
   {
      public isdateholiday( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public isdateholiday( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_Date ,
                           long aP1_EmployeeId ,
                           out string aP2_HolidayName ,
                           out bool aP3_IsHoliday )
      {
         this.AV2Date = aP0_Date;
         this.AV3EmployeeId = aP1_EmployeeId;
         this.AV4HolidayName = "" ;
         this.AV5IsHoliday = false ;
         initialize();
         ExecuteImpl();
         aP2_HolidayName=this.AV4HolidayName;
         aP3_IsHoliday=this.AV5IsHoliday;
      }

      public bool executeUdp( DateTime aP0_Date ,
                              long aP1_EmployeeId ,
                              out string aP2_HolidayName )
      {
         execute(aP0_Date, aP1_EmployeeId, out aP2_HolidayName, out aP3_IsHoliday);
         return AV5IsHoliday ;
      }

      public void executeSubmit( DateTime aP0_Date ,
                                 long aP1_EmployeeId ,
                                 out string aP2_HolidayName ,
                                 out bool aP3_IsHoliday )
      {
         this.AV2Date = aP0_Date;
         this.AV3EmployeeId = aP1_EmployeeId;
         this.AV4HolidayName = "" ;
         this.AV5IsHoliday = false ;
         SubmitImpl();
         aP2_HolidayName=this.AV4HolidayName;
         aP3_IsHoliday=this.AV5IsHoliday;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(DateTime)AV2Date,(long)AV3EmployeeId,(string)AV4HolidayName,(bool)AV5IsHoliday} ;
         ClassLoader.Execute("aisdateholiday","GeneXus.Programs","aisdateholiday", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 4 ) )
         {
            AV4HolidayName = (string)(args[2]) ;
            AV5IsHoliday = (bool)(args[3]) ;
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
         AV4HolidayName = "";
         /* GeneXus formulas. */
      }

      private long AV3EmployeeId ;
      private string AV4HolidayName ;
      private DateTime AV2Date ;
      private bool AV5IsHoliday ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP2_HolidayName ;
      private bool aP3_IsHoliday ;
   }

}
