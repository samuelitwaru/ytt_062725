using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class po_leaverequestsgridpaneldata_level_detail : GXDataGridProcedure
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
            return "po_leaverequestsgridpaneldata_Execute" ;
         }

      }

      public po_leaverequestsgridpaneldata_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public po_leaverequestsgridpaneldata_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_TrnMode ,
                           long aP1_LeaveRequestId ,
                           string aP2_TrnContextJson ,
                           int aP3_gxid ,
                           out SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt aP4_GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt )
      {
         this.AV11TrnMode = aP0_TrnMode;
         this.AV15LeaveRequestId = aP1_LeaveRequestId;
         this.AV10TrnContextJson = aP2_TrnContextJson;
         this.AV18gxid = aP3_gxid;
         this.AV22GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt = new SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP4_GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt=this.AV22GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt;
      }

      public SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt executeUdp( string aP0_TrnMode ,
                                                                          long aP1_LeaveRequestId ,
                                                                          string aP2_TrnContextJson ,
                                                                          int aP3_gxid )
      {
         execute(aP0_TrnMode, aP1_LeaveRequestId, aP2_TrnContextJson, aP3_gxid, out aP4_GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt);
         return AV22GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt ;
      }

      public void executeSubmit( string aP0_TrnMode ,
                                 long aP1_LeaveRequestId ,
                                 string aP2_TrnContextJson ,
                                 int aP3_gxid ,
                                 out SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt aP4_GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt )
      {
         this.AV11TrnMode = aP0_TrnMode;
         this.AV15LeaveRequestId = aP1_LeaveRequestId;
         this.AV10TrnContextJson = aP2_TrnContextJson;
         this.AV18gxid = aP3_gxid;
         this.AV22GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt = new SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt(context) ;
         SubmitImpl();
         aP4_GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt=this.AV22GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV18gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            AV12LoadSuccess = true;
            if ( ( ( StringUtil.StrCmp(AV11TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV11TrnMode, "INS") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "po_leaverequestsgridpaneldata_Insert") ) || ( ( StringUtil.StrCmp(AV11TrnMode, "UPD") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "po_leaverequestsgridpaneldata_Update") ) || ( ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "po_leaverequestsgridpaneldata_Delete") ) )
            {
               if ( StringUtil.StrCmp(AV11TrnMode, "INS") != 0 )
               {
                  AV7LeaveRequest.Load(AV15LeaveRequestId);
                  AV12LoadSuccess = AV7LeaveRequest.Success();
                  if ( ! AV12LoadSuccess )
                  {
                     AV6Messages = AV7LeaveRequest.GetMessages();
                     /* Execute user subroutine: 'SHOW MESSAGES' */
                     S121 ();
                     if ( returnInSub )
                     {
                        cleanup();
                        if (true) return;
                     }
                  }
                  if ( ( StringUtil.StrCmp(AV11TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 ) )
                  {
                     Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Leaverequest_leavetypeid\",\"Enabled\",\"" + "False" + "\"]";
                     Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Leaverequest_leaverequestdate\",\"Enabled\",\"" + "False" + "\"]";
                     Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Leaverequest_leaverequeststartdate\",\"Enabled\",\"" + "False" + "\"]";
                     Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Leaverequest_leaverequestenddate\",\"Enabled\",\"" + "False" + "\"]";
                     Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Leaverequest_leaverequesthalfday\",\"Enabled\",\"" + "False" + "\"]";
                     Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Leaverequest_leaverequestduration\",\"Enabled\",\"" + "False" + "\"]";
                     Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Leaverequest_leaverequeststatus\",\"Enabled\",\"" + "False" + "\"]";
                     Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Leaverequest_leaverequestdescription\",\"Enabled\",\"" + "False" + "\"]";
                     Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Leaverequest_leaverequestrejectionreason\",\"Enabled\",\"" + "False" + "\"]";
                     Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Leaverequest_employeeid\",\"Enabled\",\"" + "False" + "\"]";
                  }
               }
               else
               {
                  AV8TrnContext.FromJSonString(AV10TrnContextJson, null);
                  if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Transactionname, "LeaveRequest") == 0 )
                  {
                     AV23GXV1 = 1;
                     while ( AV23GXV1 <= AV8TrnContext.gxTpr_Attributes.Count )
                     {
                        AV9TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV8TrnContext.gxTpr_Attributes.Item(AV23GXV1));
                        if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "LeaveTypeId") == 0 )
                        {
                           AV16Insert_LeaveTypeId = (long)(Math.Round(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                           if ( ! (0==AV16Insert_LeaveTypeId) )
                           {
                              AV7LeaveRequest.gxTpr_Leavetypeid = AV16Insert_LeaveTypeId;
                              AV7LeaveRequest.Check();
                              Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Leaverequest_leavetypeid\",\"Enabled\",\"" + "False" + "\"]";
                           }
                        }
                        else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "EmployeeId") == 0 )
                        {
                           AV17Insert_EmployeeId = (long)(Math.Round(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                           if ( ! (0==AV17Insert_EmployeeId) )
                           {
                              AV7LeaveRequest.gxTpr_Employeeid = AV17Insert_EmployeeId;
                              AV7LeaveRequest.Check();
                              Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Leaverequest_employeeid\",\"Enabled\",\"" + "False" + "\"]";
                           }
                        }
                        AV23GXV1 = (int)(AV23GXV1+1);
                     }
                  }
               }
            }
            else
            {
               AV12LoadSuccess = false;
               cleanup();
               if (true) return;
            }
            if ( AV12LoadSuccess )
            {
               if ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 )
               {
                  GX_msglist.addItem("Confirm deletion.");
               }
            }
            Gxwebsession.Set(Gxids+"gxvar_Leaverequest", AV7LeaveRequest.ToJSonString(true, true));
            Gxwebsession.Set(Gxids+"gxvar_Messages", AV6Messages.ToJSonString(false));
            Gxwebsession.Set(Gxids, "true");
         }
         else
         {
            AV7LeaveRequest.FromJSonString(Gxwebsession.Get(Gxids+"gxvar_Leaverequest"), null);
            AV6Messages.FromJSonString(Gxwebsession.Get(Gxids+"gxvar_Messages"), null);
         }
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV22GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt.gxTpr_Leaverequest = AV7LeaveRequest;
         AV22GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt.gxTpr_Trnmode = AV11TrnMode;
         AV22GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt.gxTpr_Leaverequestid = AV15LeaveRequestId;
         AV22GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt.gxTpr_Messages = AV6Messages;
         AV22GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
         Gxdynprop = "";
         cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV11TrnMode, "DSP") != 0 ) ) )
         {
            Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Btn_panelenter\",\"Visible\",\"" + "False" + "\"]";
         }
      }

      protected void S121( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV24GXV2 = 1;
         while ( AV24GXV2 <= AV6Messages.Count )
         {
            AV5Message = ((GeneXus.Utils.SdtMessages_Message)AV6Messages.Item(AV24GXV2));
            GX_msglist.addItem(AV5Message.gxTpr_Description);
            AV24GXV2 = (int)(AV24GXV2+1);
         }
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
         AV22GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt = new SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV7LeaveRequest = new SdtLeaveRequest(context);
         AV6Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         Gxdynprop = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV5Message = new GeneXus.Utils.SdtMessages_Message(context);
         /* GeneXus formulas. */
      }

      private int AV18gxid ;
      private int AV23GXV1 ;
      private int AV24GXV2 ;
      private long AV15LeaveRequestId ;
      private long AV16Insert_LeaveTypeId ;
      private long AV17Insert_EmployeeId ;
      private string AV11TrnMode ;
      private string Gxids ;
      private bool AV12LoadSuccess ;
      private bool returnInSub ;
      private string AV10TrnContextJson ;
      private string Gxdynprop ;
      private IGxSession Gxwebsession ;
      private SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt AV22GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt ;
      private SdtLeaveRequest AV7LeaveRequest ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV6Messages ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV9TrnContextAtt ;
      private GeneXus.Utils.SdtMessages_Message AV5Message ;
      private SdtPO_LeaveRequestsGridPanelData_Level_DetailSdt aP4_GXM1PO_LeaveRequestsGridPanelData_Level_DetailSdt ;
   }

}
