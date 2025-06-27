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
namespace GeneXus.Programs.wwpbaseobjects {
   public class saveuserkeyvalue : GXProcedure
   {
      public saveuserkeyvalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public saveuserkeyvalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserCustomizationsKey ,
                           string aP1_UserCustomizationsValue )
      {
         this.AV29UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV30UserCustomizationsValue = aP1_UserCustomizationsValue;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_UserCustomizationsKey ,
                                 string aP1_UserCustomizationsValue )
      {
         this.AV29UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV30UserCustomizationsValue = aP1_UserCustomizationsValue;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30UserCustomizationsValue)) )
         {
            AV28Session.Remove(AV29UserCustomizationsKey);
         }
         else
         {
            AV28Session.Set(AV29UserCustomizationsKey, AV30UserCustomizationsValue);
         }
         AV31UserCustomizations.Load(new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid(), AV29UserCustomizationsKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30UserCustomizationsValue)) )
         {
            if ( AV31UserCustomizations.Success() )
            {
               AV31UserCustomizations.Delete();
               context.CommitDataStores("wwpbaseobjects.saveuserkeyvalue",pr_default);
            }
         }
         else
         {
            if ( ! AV31UserCustomizations.Success() )
            {
               AV31UserCustomizations = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
               AV31UserCustomizations.gxTpr_Usercustomizationsid = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
               AV31UserCustomizations.gxTpr_Usercustomizationskey = AV29UserCustomizationsKey;
            }
            AV31UserCustomizations.gxTpr_Usercustomizationsvalue = AV30UserCustomizationsValue;
            AV31UserCustomizations.Save();
            context.CommitDataStores("wwpbaseobjects.saveuserkeyvalue",pr_default);
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
         AV28Session = context.GetSession();
         AV31UserCustomizations = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV30UserCustomizationsValue ;
      private string AV29UserCustomizationsKey ;
      private IGxSession AV28Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations AV31UserCustomizations ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
   }

   public class saveuserkeyvalue__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class saveuserkeyvalue__default : DataStoreHelperBase, IDataStoreHelper
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
