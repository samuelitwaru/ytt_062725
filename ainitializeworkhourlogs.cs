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
   public class ainitializeworkhourlogs : GXWebProcedure
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
            return "initializeworkhourlogs_Execute" ;
         }

      }

      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public ainitializeworkhourlogs( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ainitializeworkhourlogs( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11Descriptions = "Integrate third-party APIs,Implement file upload functionality,Set up user roles and permissions," + "Implement session management,Optimize database queries,Implement search functionality," + "Set up automated testing,Implement caching mechanisms";
         /* Execute user subroutine: 'POPULATEHOLIDAYDATES' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV12DescriptionSet = (GxSimpleCollection<string>)(GxRegex.Split(AV11Descriptions,","));
         AV20Index = 1;
         AV25Count = AV12DescriptionSet.Count;
         /* Using cursor P005B2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P005B2_A106EmployeeId[0];
            AV8Date = context.localUtil.YMDToD( 2023, 1, 1);
            while ( DateTimeUtil.ResetTime ( AV8Date ) < DateTimeUtil.ResetTime ( Gx_date ) )
            {
               if ( DateTimeUtil.Dow( AV8Date) == 6 )
               {
                  AV8Date = DateTimeUtil.DAdd( AV8Date, (2));
               }
               else if ( ( DateTimeUtil.Dow( AV8Date) == 7 ) || (AV21HolidayDates.IndexOf(AV8Date)>0) )
               {
                  AV8Date = DateTimeUtil.DAdd( AV8Date, (1));
               }
               AV18SDate = context.localUtil.DToC( AV8Date, 2, "/");
               AV14Hour = 8;
               AV15Minute = 0;
               AV10Description = ((string)AV12DescriptionSet.Item(AV20Index));
               AV20Index = (short)(AV20Index+1);
               if ( AV20Index > AV25Count )
               {
                  AV20Index = 1;
               }
               AV17ProjectId = 1;
               AV13EmployeeId = A106EmployeeId;
               AV22WorkHourLog = new SdtWorkHourLog(context);
               AV22WorkHourLog.gxTpr_Employeeid = A106EmployeeId;
               AV22WorkHourLog.gxTpr_Workhourlogdate = AV8Date;
               AV22WorkHourLog.gxTpr_Workhourlogdescription = AV10Description;
               AV22WorkHourLog.gxTpr_Workhourloghour = AV14Hour;
               AV22WorkHourLog.gxTpr_Workhourlogminute = AV15Minute;
               AV22WorkHourLog.gxTpr_Projectid = AV17ProjectId;
               AV22WorkHourLog.Save();
               if ( AV22WorkHourLog.Success() )
               {
                  context.CommitDataStores("initializeworkhourlogs",pr_default);
               }
               else
               {
                  AV23Messages = AV22WorkHourLog.GetMessages();
                  AV28GXV1 = 1;
                  while ( AV28GXV1 <= AV23Messages.Count )
                  {
                     AV24Message = ((GeneXus.Utils.SdtMessages_Message)AV23Messages.Item(AV28GXV1));
                     AV28GXV1 = (int)(AV28GXV1+1);
                  }
               }
               AV8Date = DateTimeUtil.DAdd( AV8Date, (1));
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'POPULATEHOLIDAYDATES' Routine */
         returnInSub = false;
         /* Using cursor P005B3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A115HolidayStartDate = P005B3_A115HolidayStartDate[0];
            A113HolidayId = P005B3_A113HolidayId[0];
            AV21HolidayDates.Add(A115HolidayStartDate, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV11Descriptions = "";
         AV12DescriptionSet = new GxSimpleCollection<string>();
         P005B2_A106EmployeeId = new long[1] ;
         AV8Date = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         AV21HolidayDates = new GxSimpleCollection<DateTime>();
         AV18SDate = "";
         AV10Description = "";
         AV22WorkHourLog = new SdtWorkHourLog(context);
         AV23Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV24Message = new GeneXus.Utils.SdtMessages_Message(context);
         P005B3_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P005B3_A113HolidayId = new long[1] ;
         A115HolidayStartDate = DateTime.MinValue;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.ainitializeworkhourlogs__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ainitializeworkhourlogs__default(),
            new Object[][] {
                new Object[] {
               P005B2_A106EmployeeId
               }
               , new Object[] {
               P005B3_A115HolidayStartDate, P005B3_A113HolidayId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV20Index ;
      private short AV14Hour ;
      private short AV15Minute ;
      private int AV25Count ;
      private int AV28GXV1 ;
      private long A106EmployeeId ;
      private long AV17ProjectId ;
      private long AV13EmployeeId ;
      private long A113HolidayId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private DateTime AV8Date ;
      private DateTime Gx_date ;
      private DateTime A115HolidayStartDate ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private string AV11Descriptions ;
      private string AV18SDate ;
      private string AV10Description ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV12DescriptionSet ;
      private IDataStoreProvider pr_default ;
      private long[] P005B2_A106EmployeeId ;
      private GxSimpleCollection<DateTime> AV21HolidayDates ;
      private SdtWorkHourLog AV22WorkHourLog ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV23Messages ;
      private GeneXus.Utils.SdtMessages_Message AV24Message ;
      private DateTime[] P005B3_A115HolidayStartDate ;
      private long[] P005B3_A113HolidayId ;
      private IDataStoreProvider pr_gam ;
   }

   public class ainitializeworkhourlogs__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class ainitializeworkhourlogs__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP005B2;
        prmP005B2 = new Object[] {
        };
        Object[] prmP005B3;
        prmP005B3 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("P005B2", "SELECT EmployeeId FROM Employee ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005B2,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P005B3", "SELECT HolidayStartDate, HolidayId FROM Holiday ORDER BY HolidayId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005B3,100, GxCacheFrequency.OFF ,false,false )
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
              return;
           case 1 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
     }
  }

}

}
