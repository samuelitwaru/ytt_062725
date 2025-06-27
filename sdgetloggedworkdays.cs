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
   public class sdgetloggedworkdays : GXProcedure
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

      public sdgetloggedworkdays( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sdgetloggedworkdays( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( [GxJsonFormat("yyyy-MM-dd")] DateTime aP0_LogDate ,
                           out GXBaseCollection<SdtWorkLogsSDT> aP1_WorkLogCollection )
      {
         this.AV16LogDate = aP0_LogDate;
         this.AV14WorkLogCollection = new GXBaseCollection<SdtWorkLogsSDT>( context, "WorkLogsSDT", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP1_WorkLogCollection=this.AV14WorkLogCollection;
      }

      public GXBaseCollection<SdtWorkLogsSDT> executeUdp( DateTime aP0_LogDate )
      {
         execute(aP0_LogDate, out aP1_WorkLogCollection);
         return AV14WorkLogCollection ;
      }

      public void executeSubmit( DateTime aP0_LogDate ,
                                 out GXBaseCollection<SdtWorkLogsSDT> aP1_WorkLogCollection )
      {
         this.AV16LogDate = aP0_LogDate;
         this.AV14WorkLogCollection = new GXBaseCollection<SdtWorkLogsSDT>( context, "WorkLogsSDT", "YTT_version4") ;
         SubmitImpl();
         aP1_WorkLogCollection=this.AV14WorkLogCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14WorkLogCollection = new GXBaseCollection<SdtWorkLogsSDT>( context, "WorkLogsSDT", "YTT_version4");
         AV19Udparg1 = new getloggedinemployeeid(context).executeUdp( );
         /* Using cursor P00802 */
         pr_default.execute(0, new Object[] {AV16LogDate, AV19Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00802_A106EmployeeId[0];
            A119WorkHourLogDate = P00802_A119WorkHourLogDate[0];
            A107EmployeeFirstName = P00802_A107EmployeeFirstName[0];
            A102ProjectId = P00802_A102ProjectId[0];
            A103ProjectName = P00802_A103ProjectName[0];
            A123WorkHourLogDescription = P00802_A123WorkHourLogDescription[0];
            A120WorkHourLogDuration = P00802_A120WorkHourLogDuration[0];
            A121WorkHourLogHour = P00802_A121WorkHourLogHour[0];
            A122WorkHourLogMinute = P00802_A122WorkHourLogMinute[0];
            A118WorkHourLogId = P00802_A118WorkHourLogId[0];
            A107EmployeeFirstName = P00802_A107EmployeeFirstName[0];
            A103ProjectName = P00802_A103ProjectName[0];
            AV15WorkLogItem = new SdtWorkLogsSDT(context);
            AV15WorkLogItem.gxTpr_Workhourlogdate = A119WorkHourLogDate;
            AV15WorkLogItem.gxTpr_Employeeid = A106EmployeeId;
            AV15WorkLogItem.gxTpr_Employeefirstname = A107EmployeeFirstName;
            AV15WorkLogItem.gxTpr_Projectid = A102ProjectId;
            AV15WorkLogItem.gxTpr_Projectname = A103ProjectName;
            AV15WorkLogItem.gxTpr_Workhourlogdescription = A123WorkHourLogDescription;
            AV15WorkLogItem.gxTpr_Workhourlogduration = A120WorkHourLogDuration;
            AV15WorkLogItem.gxTpr_Workhourloghour = A121WorkHourLogHour;
            AV15WorkLogItem.gxTpr_Workhourlogid = A118WorkHourLogId;
            AV15WorkLogItem.gxTpr_Workhourlogminute = A122WorkHourLogMinute;
            if ( A122WorkHourLogMinute < 10 )
            {
               AV17MinutesVar = "0" + StringUtil.Trim( StringUtil.Str( (decimal)(A122WorkHourLogMinute), 4, 0));
            }
            else
            {
               AV17MinutesVar = StringUtil.Trim( StringUtil.Str( (decimal)(A122WorkHourLogMinute), 4, 0));
            }
            AV15WorkLogItem.gxTpr_Logdetails = "<span>"+StringUtil.Trim( A103ProjectName)+": </span><span>"+StringUtil.Trim( StringUtil.Str( (decimal)(A121WorkHourLogHour), 4, 0))+":"+AV17MinutesVar+"hrs</span>";
            AV14WorkLogCollection.Add(AV15WorkLogItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV14WorkLogCollection = new GXBaseCollection<SdtWorkLogsSDT>( context, "WorkLogsSDT", "YTT_version4");
         P00802_A106EmployeeId = new long[1] ;
         P00802_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00802_A107EmployeeFirstName = new string[] {""} ;
         P00802_A102ProjectId = new long[1] ;
         P00802_A103ProjectName = new string[] {""} ;
         P00802_A123WorkHourLogDescription = new string[] {""} ;
         P00802_A120WorkHourLogDuration = new string[] {""} ;
         P00802_A121WorkHourLogHour = new short[1] ;
         P00802_A122WorkHourLogMinute = new short[1] ;
         P00802_A118WorkHourLogId = new long[1] ;
         A119WorkHourLogDate = DateTime.MinValue;
         A107EmployeeFirstName = "";
         A103ProjectName = "";
         A123WorkHourLogDescription = "";
         A120WorkHourLogDuration = "";
         AV15WorkLogItem = new SdtWorkLogsSDT(context);
         AV17MinutesVar = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sdgetloggedworkdays__default(),
            new Object[][] {
                new Object[] {
               P00802_A106EmployeeId, P00802_A119WorkHourLogDate, P00802_A107EmployeeFirstName, P00802_A102ProjectId, P00802_A103ProjectName, P00802_A123WorkHourLogDescription, P00802_A120WorkHourLogDuration, P00802_A121WorkHourLogHour, P00802_A122WorkHourLogMinute, P00802_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A121WorkHourLogHour ;
      private short A122WorkHourLogMinute ;
      private long AV19Udparg1 ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A118WorkHourLogId ;
      private string A107EmployeeFirstName ;
      private string A103ProjectName ;
      private string AV17MinutesVar ;
      private DateTime AV16LogDate ;
      private DateTime A119WorkHourLogDate ;
      private string A123WorkHourLogDescription ;
      private string A120WorkHourLogDuration ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtWorkLogsSDT> AV14WorkLogCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P00802_A106EmployeeId ;
      private DateTime[] P00802_A119WorkHourLogDate ;
      private string[] P00802_A107EmployeeFirstName ;
      private long[] P00802_A102ProjectId ;
      private string[] P00802_A103ProjectName ;
      private string[] P00802_A123WorkHourLogDescription ;
      private string[] P00802_A120WorkHourLogDuration ;
      private short[] P00802_A121WorkHourLogHour ;
      private short[] P00802_A122WorkHourLogMinute ;
      private long[] P00802_A118WorkHourLogId ;
      private SdtWorkLogsSDT AV15WorkLogItem ;
      private GXBaseCollection<SdtWorkLogsSDT> aP1_WorkLogCollection ;
   }

   public class sdgetloggedworkdays__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00802;
          prmP00802 = new Object[] {
          new ParDef("AV16LogDate",GXType.Date,8,0) ,
          new ParDef("AV19Udparg1",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00802", "SELECT T1.EmployeeId, T1.WorkHourLogDate, T2.EmployeeFirstName, T1.ProjectId, T3.ProjectName, T1.WorkHourLogDescription, T1.WorkHourLogDuration, T1.WorkHourLogHour, T1.WorkHourLogMinute, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = T1.ProjectId) WHERE (T1.WorkHourLogDate = :AV16LogDate) AND (T1.EmployeeId = :AV19Udparg1) ORDER BY T1.WorkHourLogDate, T1.WorkHourLogId DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00802,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
       }
    }

 }

}
