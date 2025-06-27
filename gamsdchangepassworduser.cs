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
   public class gamsdchangepassworduser : GXProcedure
   {
      public gamsdchangepassworduser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gamsdchangepassworduser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( bool aP0_isPasswordExpires ,
                           string aP1_UserName ,
                           string aP2_UserPassword ,
                           string aP3_UserPasswordNew ,
                           string aP4_UserPasswordNewConf ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages )
      {
         this.AV10isPasswordExpires = aP0_isPasswordExpires;
         this.AV13UserName = aP1_UserName;
         this.AV14UserPassword = aP2_UserPassword;
         this.AV15UserPasswordNew = aP3_UserPasswordNew;
         this.AV16UserPasswordNewConf = aP4_UserPasswordNewConf;
         this.AV12Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         ExecuteImpl();
         aP5_Messages=this.AV12Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( bool aP0_isPasswordExpires ,
                                                                             string aP1_UserName ,
                                                                             string aP2_UserPassword ,
                                                                             string aP3_UserPasswordNew ,
                                                                             string aP4_UserPasswordNewConf )
      {
         execute(aP0_isPasswordExpires, aP1_UserName, aP2_UserPassword, aP3_UserPasswordNew, aP4_UserPasswordNewConf, out aP5_Messages);
         return AV12Messages ;
      }

      public void executeSubmit( bool aP0_isPasswordExpires ,
                                 string aP1_UserName ,
                                 string aP2_UserPassword ,
                                 string aP3_UserPasswordNew ,
                                 string aP4_UserPasswordNewConf ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages )
      {
         this.AV10isPasswordExpires = aP0_isPasswordExpires;
         this.AV13UserName = aP1_UserName;
         this.AV14UserPassword = aP2_UserPassword;
         this.AV15UserPasswordNew = aP3_UserPasswordNew;
         this.AV16UserPasswordNewConf = aP4_UserPasswordNewConf;
         this.AV12Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         SubmitImpl();
         aP5_Messages=this.AV12Messages;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV15UserPasswordNew, AV16UserPasswordNewConf) == 0 )
         {
            if ( AV10isPasswordExpires )
            {
               AV9isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).updateusertochangepassword(AV14UserPassword, AV15UserPasswordNew, out  AV8Errors);
            }
            else
            {
               AV9isOK = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).changeyourpassword(AV14UserPassword, AV15UserPasswordNew, out  AV8Errors);
            }
            if ( AV9isOK )
            {
               context.CommitDataStores("gamsdchangepassworduser",pr_default);
            }
            else
            {
               GXt_objcol_SdtMessages_Message1 = AV12Messages;
               new gam_converterrorstomessages(context ).execute(  AV8Errors, out  GXt_objcol_SdtMessages_Message1) ;
               AV12Messages = GXt_objcol_SdtMessages_Message1;
            }
         }
         else
         {
            AV11Message.gxTpr_Type = 1;
            AV11Message.gxTpr_Description = "The new password and confirmation do not match.";
            AV12Messages.Add(AV11Message, 0);
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
         AV12Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV8Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV11Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamsdchangepassworduser__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamsdchangepassworduser__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV14UserPassword ;
      private string AV15UserPasswordNew ;
      private string AV16UserPasswordNewConf ;
      private bool AV10isPasswordExpires ;
      private bool AV9isOK ;
      private string AV13UserName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV12Messages ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8Errors ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GeneXus.Utils.SdtMessages_Message AV11Message ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages ;
      private IDataStoreProvider pr_gam ;
   }

   public class gamsdchangepassworduser__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamsdchangepassworduser__default : DataStoreHelperBase, IDataStoreHelper
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
