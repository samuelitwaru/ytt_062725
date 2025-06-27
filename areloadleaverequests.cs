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
   public class areloadleaverequests : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "FromDate");
            if ( ! entryPointCalled )
            {
               AV10FromDate = context.localUtil.ParseDateParm( gxfirstwebparm);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public areloadleaverequests( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public areloadleaverequests( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate )
      {
         this.AV10FromDate = aP0_FromDate;
         this.AV9ToDate = aP1_ToDate;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate )
      {
         this.AV10FromDate = aP0_FromDate;
         this.AV9ToDate = aP1_ToDate;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV10FromDate ,
                                              AV9ToDate ,
                                              A129LeaveRequestStartDate ,
                                              A100CompanyId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG
                                              }
         });
         /* Using cursor P00AC2 */
         pr_default.execute(0, new Object[] {AV10FromDate, AV9ToDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P00AC2_A124LeaveTypeId[0];
            A129LeaveRequestStartDate = P00AC2_A129LeaveRequestStartDate[0];
            A100CompanyId = P00AC2_A100CompanyId[0];
            A127LeaveRequestId = P00AC2_A127LeaveRequestId[0];
            A130LeaveRequestEndDate = P00AC2_A130LeaveRequestEndDate[0];
            A171LeaveRequestHalfDay = P00AC2_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P00AC2_n171LeaveRequestHalfDay[0];
            A106EmployeeId = P00AC2_A106EmployeeId[0];
            A100CompanyId = P00AC2_A100CompanyId[0];
            AV8LeaveRequest.Load(A127LeaveRequestId);
            GXt_decimal1 = 0;
            new getleaverequestdays(context ).execute(  A129LeaveRequestStartDate,  A130LeaveRequestEndDate,  A171LeaveRequestHalfDay,  A106EmployeeId, out  GXt_decimal1) ;
            AV8LeaveRequest.gxTpr_Leaverequestduration = GXt_decimal1;
            if ( AV8LeaveRequest.Update() )
            {
               context.CommitDataStores("reloadleaverequests",pr_default);
            }
            else
            {
               new logtofile(context ).execute(  AV8LeaveRequest.GetMessages().ToJSonString(false)) ;
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
         A129LeaveRequestStartDate = DateTime.MinValue;
         P00AC2_A124LeaveTypeId = new long[1] ;
         P00AC2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00AC2_A100CompanyId = new long[1] ;
         P00AC2_A127LeaveRequestId = new long[1] ;
         P00AC2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00AC2_A171LeaveRequestHalfDay = new string[] {""} ;
         P00AC2_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00AC2_A106EmployeeId = new long[1] ;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A171LeaveRequestHalfDay = "";
         AV8LeaveRequest = new SdtLeaveRequest(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.areloadleaverequests__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areloadleaverequests__default(),
            new Object[][] {
                new Object[] {
               P00AC2_A124LeaveTypeId, P00AC2_A129LeaveRequestStartDate, P00AC2_A100CompanyId, P00AC2_A127LeaveRequestId, P00AC2_A130LeaveRequestEndDate, P00AC2_A171LeaveRequestHalfDay, P00AC2_n171LeaveRequestHalfDay, P00AC2_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private long A106EmployeeId ;
      private decimal GXt_decimal1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A171LeaveRequestHalfDay ;
      private DateTime AV10FromDate ;
      private DateTime AV9ToDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool entryPointCalled ;
      private bool n171LeaveRequestHalfDay ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00AC2_A124LeaveTypeId ;
      private DateTime[] P00AC2_A129LeaveRequestStartDate ;
      private long[] P00AC2_A100CompanyId ;
      private long[] P00AC2_A127LeaveRequestId ;
      private DateTime[] P00AC2_A130LeaveRequestEndDate ;
      private string[] P00AC2_A171LeaveRequestHalfDay ;
      private bool[] P00AC2_n171LeaveRequestHalfDay ;
      private long[] P00AC2_A106EmployeeId ;
      private SdtLeaveRequest AV8LeaveRequest ;
      private IDataStoreProvider pr_gam ;
   }

   public class areloadleaverequests__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class areloadleaverequests__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P00AC2( IGxContext context ,
                                           DateTime AV10FromDate ,
                                           DateTime AV9ToDate ,
                                           DateTime A129LeaveRequestStartDate ,
                                           long A100CompanyId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int2 = new short[2];
       Object[] GXv_Object3 = new Object[2];
       scmdbuf = "SELECT T1.LeaveTypeId, T1.LeaveRequestStartDate, T2.CompanyId, T1.LeaveRequestId, T1.LeaveRequestEndDate, T1.LeaveRequestHalfDay, T1.EmployeeId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
       AddWhere(sWhereString, "(T2.CompanyId = 1)");
       if ( ! (DateTime.MinValue==AV10FromDate) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestStartDate > :AV10FromDate)");
       }
       else
       {
          GXv_int2[0] = 1;
       }
       if ( ! (DateTime.MinValue==AV9ToDate) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV9ToDate)");
       }
       else
       {
          GXv_int2[1] = 1;
       }
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY T1.LeaveRequestId";
       GXv_Object3[0] = scmdbuf;
       GXv_Object3[1] = GXv_int2;
       return GXv_Object3 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 0 :
                   return conditional_P00AC2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (long)dynConstraints[3] );
       }
       return base.getDynamicStatement(cursor, context, dynConstraints);
    }

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
        Object[] prmP00AC2;
        prmP00AC2 = new Object[] {
        new ParDef("AV10FromDate",GXType.Date,8,0) ,
        new ParDef("AV9ToDate",GXType.Date,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00AC2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AC2,100, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((long[]) buf[7])[0] = rslt.getLong(7);
              return;
     }
  }

}

}
