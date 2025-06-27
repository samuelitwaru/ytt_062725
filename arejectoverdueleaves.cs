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
   public class arejectoverdueleaves : GXWebProcedure
   {
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

      public arejectoverdueleaves( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public arejectoverdueleaves( IGxContext context )
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
         /* Using cursor P00982 */
         pr_default.execute(0, new Object[] {Gx_date});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXT982 = 0;
            A124LeaveTypeId = P00982_A124LeaveTypeId[0];
            A132LeaveRequestStatus = P00982_A132LeaveRequestStatus[0];
            A129LeaveRequestStartDate = P00982_A129LeaveRequestStartDate[0];
            A134LeaveRequestRejectionReason = P00982_A134LeaveRequestRejectionReason[0];
            A130LeaveRequestEndDate = P00982_A130LeaveRequestEndDate[0];
            A125LeaveTypeName = P00982_A125LeaveTypeName[0];
            A109EmployeeEmail = P00982_A109EmployeeEmail[0];
            A128LeaveRequestDate = P00982_A128LeaveRequestDate[0];
            A106EmployeeId = P00982_A106EmployeeId[0];
            A127LeaveRequestId = P00982_A127LeaveRequestId[0];
            A125LeaveTypeName = P00982_A125LeaveTypeName[0];
            A109EmployeeEmail = P00982_A109EmployeeEmail[0];
            A132LeaveRequestStatus = "Rejected";
            A134LeaveRequestRejectionReason = "Delayed Response";
            GXt_char1 = A125LeaveTypeName + " rejected";
            GXt_char2 = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#f6d300;color:#000;text-align:center;padding:20px 0\"><h2>Leave Request Rejected</h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear " + AV8Employee.gxTpr_Employeename + ",</p>" + "<p>We regret to inform you that your leave request has been rejected. </p>" + "<p>Start Date: <b>" + context.localUtil.DToC( A129LeaveRequestStartDate, 2, "/") + "</b></p>" + "<p>EndDate: <b>" + context.localUtil.DToC( A130LeaveRequestEndDate, 2, "/") + "</b></p>" + "<p>Reason for Rejection: <b>" + A134LeaveRequestRejectionReason + "</b></p><p>If you have any concerns or need clarification, please reach out to us.</p><p> Best Regards</p><p>The Yukon Time Tracker Team</p></div></div>";
            new sendemail(context).executeSubmit(  A109EmployeeEmail, ref  GXt_char1, ref  GXt_char2) ;
            new sdsendpushnotifications(context ).execute(  "Leave Request Rejected",  "Your leave request made on "+context.localUtil.DToC( A128LeaveRequestDate, 2, "/")+" has been rejected",  A106EmployeeId) ;
            GXT982 = 1;
            /* Using cursor P00983 */
            pr_default.execute(1, new Object[] {A132LeaveRequestStatus, A134LeaveRequestRejectionReason, A127LeaveRequestId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("LeaveRequest");
            if ( GXT982 == 1 )
            {
               context.CommitDataStores("rejectoverdueleaves",pr_default);
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

      public override void cleanup( )
      {
         context.CommitDataStores("rejectoverdueleaves",pr_default);
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
         Gx_date = DateTime.MinValue;
         P00982_A124LeaveTypeId = new long[1] ;
         P00982_A132LeaveRequestStatus = new string[] {""} ;
         P00982_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00982_A134LeaveRequestRejectionReason = new string[] {""} ;
         P00982_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00982_A125LeaveTypeName = new string[] {""} ;
         P00982_A109EmployeeEmail = new string[] {""} ;
         P00982_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         P00982_A106EmployeeId = new long[1] ;
         P00982_A127LeaveRequestId = new long[1] ;
         A132LeaveRequestStatus = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A134LeaveRequestRejectionReason = "";
         A130LeaveRequestEndDate = DateTime.MinValue;
         A125LeaveTypeName = "";
         A109EmployeeEmail = "";
         A128LeaveRequestDate = DateTime.MinValue;
         GXt_char1 = "";
         GXt_char2 = "";
         AV8Employee = new SdtEmployee(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.arejectoverdueleaves__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.arejectoverdueleaves__default(),
            new Object[][] {
                new Object[] {
               P00982_A124LeaveTypeId, P00982_A132LeaveRequestStatus, P00982_A129LeaveRequestStartDate, P00982_A134LeaveRequestRejectionReason, P00982_A130LeaveRequestEndDate, P00982_A125LeaveTypeName, P00982_A109EmployeeEmail, P00982_A128LeaveRequestDate, P00982_A106EmployeeId, P00982_A127LeaveRequestId
               }
               , new Object[] {
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
      private short GXT982 ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long A127LeaveRequestId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A132LeaveRequestStatus ;
      private string A125LeaveTypeName ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private DateTime Gx_date ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A128LeaveRequestDate ;
      private bool entryPointCalled ;
      private string A134LeaveRequestRejectionReason ;
      private string A109EmployeeEmail ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00982_A124LeaveTypeId ;
      private string[] P00982_A132LeaveRequestStatus ;
      private DateTime[] P00982_A129LeaveRequestStartDate ;
      private string[] P00982_A134LeaveRequestRejectionReason ;
      private DateTime[] P00982_A130LeaveRequestEndDate ;
      private string[] P00982_A125LeaveTypeName ;
      private string[] P00982_A109EmployeeEmail ;
      private DateTime[] P00982_A128LeaveRequestDate ;
      private long[] P00982_A106EmployeeId ;
      private long[] P00982_A127LeaveRequestId ;
      private SdtEmployee AV8Employee ;
      private IDataStoreProvider pr_gam ;
   }

   public class arejectoverdueleaves__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class arejectoverdueleaves__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new UpdateCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00982;
        prmP00982 = new Object[] {
        new ParDef("Gx_date",GXType.Date,8,0)
        };
        Object[] prmP00983;
        prmP00983 = new Object[] {
        new ParDef("LeaveRequestStatus",GXType.Char,20,0) ,
        new ParDef("LeaveRequestRejectionReason",GXType.VarChar,200,0) ,
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00982", "SELECT T1.LeaveTypeId, T1.LeaveRequestStatus, T1.LeaveRequestStartDate, T1.LeaveRequestRejectionReason, T1.LeaveRequestEndDate, T2.LeaveTypeName, T3.EmployeeEmail, T1.LeaveRequestDate, T1.EmployeeId, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId) WHERE (T1.LeaveRequestStartDate <= :Gx_date) AND (T1.LeaveRequestStatus = ( 'Pending')) ORDER BY T1.LeaveRequestId  FOR UPDATE OF T1, T1, T1",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00982,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00983", "SAVEPOINT gxupdate;UPDATE LeaveRequest SET LeaveRequestStatus=:LeaveRequestStatus, LeaveRequestRejectionReason=:LeaveRequestRejectionReason  WHERE LeaveRequestId = :LeaveRequestId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00983)
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
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              return;
     }
  }

}

}
