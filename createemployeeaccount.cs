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
   public class createemployeeaccount : GXProcedure
   {
      public createemployeeaccount( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public createemployeeaccount( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_EmployeeEmail ,
                           string aP1_EmployeeFirstName ,
                           string aP2_EmployeeLastName ,
                           out string aP3_GAMUserGUID ,
                           out string aP4_Password )
      {
         this.A109EmployeeEmail = aP0_EmployeeEmail;
         this.A107EmployeeFirstName = aP1_EmployeeFirstName;
         this.A108EmployeeLastName = aP2_EmployeeLastName;
         this.AV11GAMUserGUID = "" ;
         this.AV12Password = "" ;
         initialize();
         ExecuteImpl();
         aP3_GAMUserGUID=this.AV11GAMUserGUID;
         aP4_Password=this.AV12Password;
      }

      public string executeUdp( string aP0_EmployeeEmail ,
                                string aP1_EmployeeFirstName ,
                                string aP2_EmployeeLastName ,
                                out string aP3_GAMUserGUID )
      {
         execute(aP0_EmployeeEmail, aP1_EmployeeFirstName, aP2_EmployeeLastName, out aP3_GAMUserGUID, out aP4_Password);
         return AV12Password ;
      }

      public void executeSubmit( string aP0_EmployeeEmail ,
                                 string aP1_EmployeeFirstName ,
                                 string aP2_EmployeeLastName ,
                                 out string aP3_GAMUserGUID ,
                                 out string aP4_Password )
      {
         this.A109EmployeeEmail = aP0_EmployeeEmail;
         this.A107EmployeeFirstName = aP1_EmployeeFirstName;
         this.A108EmployeeLastName = aP2_EmployeeLastName;
         this.AV11GAMUserGUID = "" ;
         this.AV12Password = "" ;
         SubmitImpl();
         aP3_GAMUserGUID=this.AV11GAMUserGUID;
         aP4_Password=this.AV12Password;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV10GAMUser.gxTpr_Name = A109EmployeeEmail;
         AV10GAMUser.gxTpr_Firstname = A107EmployeeFirstName;
         AV10GAMUser.gxTpr_Lastname = A108EmployeeLastName;
         AV10GAMUser.gxTpr_Email = A109EmployeeEmail;
         AV10GAMUser.gxTpr_Mustchangepassword = false;
         GXt_char1 = AV12Password;
         new generatepassword(context ).execute( out  GXt_char1) ;
         AV12Password = GXt_char1;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12Password)) )
         {
            AV12Password = StringUtil.Trim( GxRegex.Split(AV9Employee.gxTpr_Employeeemail,"@").GetString(1)) + StringUtil.Str( (decimal)(StringUtil.Len( AV9Employee.gxTpr_Employeeemail)), 10, 0);
         }
         AV10GAMUser.gxTpr_Password = AV12Password;
         AV10GAMUser.gxTpr_Authenticationtypename = "local";
         AV10GAMUser.gxTpr_Namespace = "YTT_version4";
         AV10GAMUser.save();
         if ( AV10GAMUser.success() )
         {
            AV11GAMUserGUID = AV10GAMUser.gxTpr_Guid;
            context.CommitDataStores("createemployeeaccount",pr_default);
         }
         else
         {
            AV8GAMErrorCollection = AV10GAMUser.geterrors();
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
         AV11GAMUserGUID = "";
         AV12Password = "";
         AV10GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GXt_char1 = "";
         AV9Employee = new SdtEmployee(context);
         AV8GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.createemployeeaccount__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.createemployeeaccount__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string A107EmployeeFirstName ;
      private string A108EmployeeLastName ;
      private string AV12Password ;
      private string GXt_char1 ;
      private string A109EmployeeEmail ;
      private string AV11GAMUserGUID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV10GAMUser ;
      private SdtEmployee AV9Employee ;
      private IDataStoreProvider pr_default ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8GAMErrorCollection ;
      private string aP3_GAMUserGUID ;
      private string aP4_Password ;
      private IDataStoreProvider pr_gam ;
   }

   public class createemployeeaccount__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class createemployeeaccount__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
