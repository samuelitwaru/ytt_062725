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
   public class audittransaction : GXProcedure
   {
      public audittransaction( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public audittransaction( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( WorkWithPlus.workwithplus_web.SdtAuditingObject aP0_AuditingObject ,
                           string aP1_CallerName )
      {
         this.AV8AuditingObject = aP0_AuditingObject;
         this.AV11CallerName = aP1_CallerName;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( WorkWithPlus.workwithplus_web.SdtAuditingObject aP0_AuditingObject ,
                                 string aP1_CallerName )
      {
         this.AV8AuditingObject = aP0_AuditingObject;
         this.AV11CallerName = aP1_CallerName;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_int1 = AV22EmployeeId;
         new getloggedinemployeeid(context ).execute( out  GXt_int1) ;
         AV22EmployeeId = GXt_int1;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV19WWPContext) ;
         AV18AuditPrimaryKey = "";
         AV20FirstRecord = true;
         AV23GXV1 = 1;
         while ( AV23GXV1 <= AV8AuditingObject.gxTpr_Record.Count )
         {
            AV9AuditingObjectRecordItem = ((WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem)AV8AuditingObject.gxTpr_Record.Item(AV23GXV1));
            AV12Audit = new SdtAudit(context);
            AV12Audit.gxTpr_Auditdate = DateTimeUtil.Now( context);
            AV12Audit.gxTpr_Employeeid = AV22EmployeeId;
            AV12Audit.gxTpr_Audittablename = AV9AuditingObjectRecordItem.gxTpr_Tablename;
            if ( AV20FirstRecord )
            {
               AV17AuditShortDescription = "Record '";
               AV16AuditDescription = "Record '";
               AV21ActualMode = AV8AuditingObject.gxTpr_Mode;
            }
            else
            {
               AV17AuditShortDescription = AV18AuditPrimaryKey;
               AV16AuditDescription = AV18AuditPrimaryKey;
               AV21ActualMode = AV9AuditingObjectRecordItem.gxTpr_Mode;
            }
            if ( StringUtil.StrCmp(AV21ActualMode, "INS") == 0 )
            {
               AV12Audit.gxTpr_Auditaction = "Insert";
            }
            else if ( StringUtil.StrCmp(AV21ActualMode, "UPD") == 0 )
            {
               AV12Audit.gxTpr_Auditaction = "Update";
            }
            else if ( StringUtil.StrCmp(AV21ActualMode, "DLT") == 0 )
            {
               AV12Audit.gxTpr_Auditaction = "Delete";
            }
            AV24GXV2 = 1;
            while ( AV24GXV2 <= AV9AuditingObjectRecordItem.gxTpr_Attribute.Count )
            {
               AV10AuditingObjectRecordItemAttributeItem = ((WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem)AV9AuditingObjectRecordItem.gxTpr_Attribute.Item(AV24GXV2));
               if ( AV10AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey )
               {
                  if ( StringUtil.StrCmp(AV21ActualMode, "INS") == 0 )
                  {
                     AV16AuditDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue + " ";
                     AV12Audit.gxTpr_Trn_id = AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue;
                  }
                  else
                  {
                     AV16AuditDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue + " ";
                     AV12Audit.gxTpr_Trn_id = AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue;
                  }
               }
               if ( AV10AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute )
               {
                  if ( StringUtil.StrCmp(AV21ActualMode, "INS") == 0 )
                  {
                     AV17AuditShortDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue + " ";
                     AV16AuditDescription += "- " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue + " ";
                  }
                  else
                  {
                     AV17AuditShortDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue + " ";
                     AV16AuditDescription += "- " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue + " ";
                  }
               }
               AV24GXV2 = (int)(AV24GXV2+1);
            }
            if ( AV20FirstRecord )
            {
               AV20FirstRecord = false;
               AV18AuditPrimaryKey = AV17AuditShortDescription;
            }
            AV17AuditShortDescription += "' was ";
            AV16AuditDescription += "' was ";
            if ( StringUtil.StrCmp(AV21ActualMode, "INS") == 0 )
            {
               AV17AuditShortDescription += "inserted";
               AV16AuditDescription += "inserted." + StringUtil.NewLine( ) + " Attributes:" + StringUtil.NewLine( );
            }
            else if ( StringUtil.StrCmp(AV21ActualMode, "UPD") == 0 )
            {
               AV17AuditShortDescription += "updated";
               AV16AuditDescription += "updated." + StringUtil.NewLine( ) + " Modified attributes:" + StringUtil.NewLine( );
            }
            else if ( StringUtil.StrCmp(AV21ActualMode, "DLT") == 0 )
            {
               AV17AuditShortDescription += "deleted";
               AV16AuditDescription += "deleted." + StringUtil.NewLine( ) + " Attributes:" + StringUtil.NewLine( );
            }
            AV17AuditShortDescription += ".";
            AV25GXV3 = 1;
            while ( AV25GXV3 <= AV9AuditingObjectRecordItem.gxTpr_Attribute.Count )
            {
               AV10AuditingObjectRecordItemAttributeItem = ((WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem)AV9AuditingObjectRecordItem.gxTpr_Attribute.Item(AV25GXV3));
               if ( ! ( AV10AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey ) )
               {
                  if ( StringUtil.StrCmp(AV21ActualMode, "INS") == 0 )
                  {
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue)) )
                     {
                        AV16AuditDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue + StringUtil.NewLine( );
                     }
                  }
                  else if ( StringUtil.StrCmp(AV21ActualMode, "UPD") == 0 )
                  {
                     if ( StringUtil.StrCmp(AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue, AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue) != 0 )
                     {
                        AV16AuditDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue + " (Old value = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue + ")" + StringUtil.NewLine( );
                     }
                  }
                  else if ( StringUtil.StrCmp(AV21ActualMode, "DLT") == 0 )
                  {
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue)) ) )
                     {
                        AV16AuditDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue + StringUtil.NewLine( );
                     }
                  }
               }
               AV25GXV3 = (int)(AV25GXV3+1);
            }
            AV12Audit.gxTpr_Auditdescription = AV16AuditDescription;
            AV12Audit.gxTpr_Auditshortdescription = AV17AuditShortDescription;
            AV12Audit.Save();
            if ( AV12Audit.Success() )
            {
               context.CommitDataStores("wwpbaseobjects.audittransaction",pr_default);
            }
            AV23GXV1 = (int)(AV23GXV1+1);
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
         AV19WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV18AuditPrimaryKey = "";
         AV9AuditingObjectRecordItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem(context);
         AV12Audit = new SdtAudit(context);
         AV17AuditShortDescription = "";
         AV16AuditDescription = "";
         AV21ActualMode = "";
         AV10AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.audittransaction__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.audittransaction__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV23GXV1 ;
      private int AV24GXV2 ;
      private int AV25GXV3 ;
      private long AV22EmployeeId ;
      private long GXt_int1 ;
      private string AV21ActualMode ;
      private bool AV20FirstRecord ;
      private string AV11CallerName ;
      private string AV18AuditPrimaryKey ;
      private string AV17AuditShortDescription ;
      private string AV16AuditDescription ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject AV8AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV19WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem AV9AuditingObjectRecordItem ;
      private SdtAudit AV12Audit ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem AV10AuditingObjectRecordItemAttributeItem ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
   }

   public class audittransaction__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class audittransaction__default : DataStoreHelperBase, IDataStoreHelper
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
