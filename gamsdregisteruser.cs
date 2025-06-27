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
   public class gamsdregisteruser : GXProcedure
   {
      public gamsdregisteruser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gamsdregisteruser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserName ,
                           string aP1_Email ,
                           string aP2_FirstName ,
                           string aP3_LastName ,
                           string aP4_Password ,
                           string aP5_ConfirmPassword ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP6_Messages )
      {
         this.AV18UserName = aP0_UserName;
         this.AV9Email = aP1_Email;
         this.AV11FirstName = aP2_FirstName;
         this.AV12LastName = aP3_LastName;
         this.AV16Password = aP4_Password;
         this.AV8ConfirmPassword = aP5_ConfirmPassword;
         this.AV15Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         ExecuteImpl();
         aP6_Messages=this.AV15Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( string aP0_UserName ,
                                                                             string aP1_Email ,
                                                                             string aP2_FirstName ,
                                                                             string aP3_LastName ,
                                                                             string aP4_Password ,
                                                                             string aP5_ConfirmPassword )
      {
         execute(aP0_UserName, aP1_Email, aP2_FirstName, aP3_LastName, aP4_Password, aP5_ConfirmPassword, out aP6_Messages);
         return AV15Messages ;
      }

      public void executeSubmit( string aP0_UserName ,
                                 string aP1_Email ,
                                 string aP2_FirstName ,
                                 string aP3_LastName ,
                                 string aP4_Password ,
                                 string aP5_ConfirmPassword ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP6_Messages )
      {
         this.AV18UserName = aP0_UserName;
         this.AV9Email = aP1_Email;
         this.AV11FirstName = aP2_FirstName;
         this.AV12LastName = aP3_LastName;
         this.AV16Password = aP4_Password;
         this.AV8ConfirmPassword = aP5_ConfirmPassword;
         this.AV15Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         SubmitImpl();
         aP6_Messages=this.AV15Messages;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18UserName)) )
         {
            AV14Message.gxTpr_Type = 1;
            AV14Message.gxTpr_Description = "User name must be entered.";
            AV15Messages.Add(AV14Message, 0);
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV16Password, AV8ConfirmPassword) != 0 )
         {
            AV14Message.gxTpr_Type = 1;
            AV14Message.gxTpr_Description = "Passwords don't match.";
            AV15Messages.Add(AV14Message, 0);
            cleanup();
            if (true) return;
         }
         AV17User.gxTpr_Name = AV18UserName;
         AV17User.gxTpr_Email = AV9Email;
         AV17User.gxTpr_Firstname = AV11FirstName;
         AV17User.gxTpr_Lastname = AV12LastName;
         AV17User.gxTpr_Password = AV16Password;
         AV17User.save();
         if ( AV17User.success() )
         {
            context.CommitDataStores("gamsdregisteruser",pr_default);
            AV13LinkURL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).applicationgetaccountactivationurl("");
            new gam_checkuseractivationmethod(context ).execute(  AV17User.gxTpr_Guid,  AV13LinkURL, out  AV15Messages) ;
         }
         else
         {
            AV10Errors = AV17User.geterrors();
            GXt_objcol_SdtMessages_Message1 = AV15Messages;
            new gam_converterrorstomessages(context ).execute(  AV10Errors, out  GXt_objcol_SdtMessages_Message1) ;
            AV15Messages = GXt_objcol_SdtMessages_Message1;
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
         AV15Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV17User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV13LinkURL = "";
         AV10Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamsdregisteruser__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamsdregisteruser__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV11FirstName ;
      private string AV12LastName ;
      private string AV16Password ;
      private string AV8ConfirmPassword ;
      private string AV18UserName ;
      private string AV9Email ;
      private string AV13LinkURL ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV15Messages ;
      private GeneXus.Utils.SdtMessages_Message AV14Message ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV17User ;
      private IDataStoreProvider pr_default ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10Errors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP6_Messages ;
      private IDataStoreProvider pr_gam ;
   }

   public class gamsdregisteruser__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamsdregisteruser__default : DataStoreHelperBase, IDataStoreHelper
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
