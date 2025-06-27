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
   public class createemployeeaccount1 : GXProcedure
   {
      public createemployeeaccount1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public createemployeeaccount1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_EmployeeEmail ,
                           string aP1_EmployeeFirstName ,
                           string aP2_EmployeeLastName ,
                           string aP3_RolesString ,
                           out string aP4_GAMUserGUID )
      {
         this.A109EmployeeEmail = aP0_EmployeeEmail;
         this.A107EmployeeFirstName = aP1_EmployeeFirstName;
         this.A108EmployeeLastName = aP2_EmployeeLastName;
         this.AV15RolesString = aP3_RolesString;
         this.AV12GAMUserGUID = "" ;
         initialize();
         ExecuteImpl();
         aP4_GAMUserGUID=this.AV12GAMUserGUID;
      }

      public string executeUdp( string aP0_EmployeeEmail ,
                                string aP1_EmployeeFirstName ,
                                string aP2_EmployeeLastName ,
                                string aP3_RolesString )
      {
         execute(aP0_EmployeeEmail, aP1_EmployeeFirstName, aP2_EmployeeLastName, aP3_RolesString, out aP4_GAMUserGUID);
         return AV12GAMUserGUID ;
      }

      public void executeSubmit( string aP0_EmployeeEmail ,
                                 string aP1_EmployeeFirstName ,
                                 string aP2_EmployeeLastName ,
                                 string aP3_RolesString ,
                                 out string aP4_GAMUserGUID )
      {
         this.A109EmployeeEmail = aP0_EmployeeEmail;
         this.A107EmployeeFirstName = aP1_EmployeeFirstName;
         this.A108EmployeeLastName = aP2_EmployeeLastName;
         this.AV15RolesString = aP3_RolesString;
         this.AV12GAMUserGUID = "" ;
         SubmitImpl();
         aP4_GAMUserGUID=this.AV12GAMUserGUID;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getbylogin("local", A109EmployeeEmail, out  AV9GAMErrorCollection);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11GAMUser.gxTpr_Guid)) )
         {
            AV12GAMUserGUID = AV11GAMUser.gxTpr_Guid;
         }
         else
         {
            AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
            AV11GAMUser.gxTpr_Name = A109EmployeeEmail;
            AV11GAMUser.gxTpr_Firstname = A107EmployeeFirstName;
            AV11GAMUser.gxTpr_Lastname = A108EmployeeLastName;
            AV11GAMUser.gxTpr_Email = A109EmployeeEmail;
            AV13Password = "user123";
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13Password)) )
            {
               AV13Password = StringUtil.Trim( GxRegex.Split(AV8Employee.gxTpr_Employeeemail,"@").GetString(1)) + StringUtil.Str( (decimal)(StringUtil.Len( AV8Employee.gxTpr_Employeeemail)), 10, 0);
            }
            AV11GAMUser.gxTpr_Password = AV13Password;
            AV11GAMUser.gxTpr_Authenticationtypename = "local";
            AV11GAMUser.gxTpr_Namespace = "YTTV3";
            AV11GAMUser.deleteallroles();
            AV11GAMUser.save();
            if ( AV11GAMUser.success() )
            {
               AV12GAMUserGUID = AV11GAMUser.gxTpr_Guid;
               AV14RoleNames = GxRegex.Split(AV15RolesString,",");
               AV19GXV1 = 1;
               while ( AV19GXV1 <= AV14RoleNames.Count )
               {
                  AV17RoleName = AV14RoleNames.GetString(AV19GXV1);
                  AV10GAMRole = AV16GAMRepository.getrolebyexternalid(AV17RoleName, out  AV9GAMErrorCollection);
                  AV11GAMUser.addrolebyid( AV10GAMRole.gxTpr_Id, out  AV9GAMErrorCollection);
                  context.CommitDataStores("createemployeeaccount1",pr_default);
                  AV19GXV1 = (int)(AV19GXV1+1);
               }
            }
            else
            {
               AV9GAMErrorCollection = AV11GAMUser.geterrors();
            }
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
         AV12GAMUserGUID = "";
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV9GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV13Password = "";
         AV8Employee = new SdtEmployee(context);
         AV14RoleNames = new GxSimpleCollection<string>();
         AV17RoleName = "";
         AV10GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV16GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.createemployeeaccount1__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.createemployeeaccount1__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV19GXV1 ;
      private string A107EmployeeFirstName ;
      private string A108EmployeeLastName ;
      private string AV13Password ;
      private string AV17RoleName ;
      private string A109EmployeeEmail ;
      private string AV15RolesString ;
      private string AV12GAMUserGUID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV11GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9GAMErrorCollection ;
      private SdtEmployee AV8Employee ;
      private GxSimpleCollection<string> AV14RoleNames ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV10GAMRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV16GAMRepository ;
      private IDataStoreProvider pr_default ;
      private string aP4_GAMUserGUID ;
      private IDataStoreProvider pr_gam ;
   }

   public class createemployeeaccount1__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class createemployeeaccount1__default : DataStoreHelperBase, IDataStoreHelper
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
