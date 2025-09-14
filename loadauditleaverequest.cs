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
   public class loadauditleaverequest : GXProcedure
   {
      public loadauditleaverequest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditleaverequest( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref WorkWithPlus.workwithplus_web.SdtAuditingObject aP1_AuditingObject ,
                           long aP2_LeaveRequestId ,
                           string aP3_ActualMode )
      {
         this.AV13SaveOldValues = aP0_SaveOldValues;
         this.AV10AuditingObject = aP1_AuditingObject;
         this.AV16LeaveRequestId = aP2_LeaveRequestId;
         this.AV14ActualMode = aP3_ActualMode;
         initialize();
         ExecuteImpl();
         aP1_AuditingObject=this.AV10AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref WorkWithPlus.workwithplus_web.SdtAuditingObject aP1_AuditingObject ,
                                 long aP2_LeaveRequestId ,
                                 string aP3_ActualMode )
      {
         this.AV13SaveOldValues = aP0_SaveOldValues;
         this.AV10AuditingObject = aP1_AuditingObject;
         this.AV16LeaveRequestId = aP2_LeaveRequestId;
         this.AV14ActualMode = aP3_ActualMode;
         SubmitImpl();
         aP1_AuditingObject=this.AV10AuditingObject;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV13SaveOldValues, "Y") == 0 )
         {
            if ( ( StringUtil.StrCmp(AV14ActualMode, "DLT") == 0 ) || ( StringUtil.StrCmp(AV14ActualMode, "UPD") == 0 ) )
            {
               /* Execute user subroutine: 'LOADOLDVALUES' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         else
         {
            /* Execute user subroutine: 'LOADNEWVALUES' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADOLDVALUES' Routine */
         returnInSub = false;
         /* Using cursor P00BX2 */
         pr_default.execute(0, new Object[] {AV16LeaveRequestId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127LeaveRequestId = P00BX2_A127LeaveRequestId[0];
            A124LeaveTypeId = P00BX2_A124LeaveTypeId[0];
            A125LeaveTypeName = P00BX2_A125LeaveTypeName[0];
            A128LeaveRequestDate = P00BX2_A128LeaveRequestDate[0];
            A129LeaveRequestStartDate = P00BX2_A129LeaveRequestStartDate[0];
            A130LeaveRequestEndDate = P00BX2_A130LeaveRequestEndDate[0];
            A171LeaveRequestHalfDay = P00BX2_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P00BX2_n171LeaveRequestHalfDay[0];
            A131LeaveRequestDuration = P00BX2_A131LeaveRequestDuration[0];
            A132LeaveRequestStatus = P00BX2_A132LeaveRequestStatus[0];
            A133LeaveRequestDescription = P00BX2_A133LeaveRequestDescription[0];
            A134LeaveRequestRejectionReason = P00BX2_A134LeaveRequestRejectionReason[0];
            A106EmployeeId = P00BX2_A106EmployeeId[0];
            A148EmployeeName = P00BX2_A148EmployeeName[0];
            A147EmployeeBalance = P00BX2_A147EmployeeBalance[0];
            A144LeaveTypeVacationLeave = P00BX2_A144LeaveTypeVacationLeave[0];
            A145LeaveTypeLoggingWorkHours = P00BX2_A145LeaveTypeLoggingWorkHours[0];
            A125LeaveTypeName = P00BX2_A125LeaveTypeName[0];
            A144LeaveTypeVacationLeave = P00BX2_A144LeaveTypeVacationLeave[0];
            A145LeaveTypeLoggingWorkHours = P00BX2_A145LeaveTypeLoggingWorkHours[0];
            A148EmployeeName = P00BX2_A148EmployeeName[0];
            A147EmployeeBalance = P00BX2_A147EmployeeBalance[0];
            AV10AuditingObject = new WorkWithPlus.workwithplus_web.SdtAuditingObject(context);
            AV10AuditingObject.gxTpr_Mode = AV14ActualMode;
            AV11AuditingObjectRecordItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem(context);
            AV11AuditingObjectRecordItem.gxTpr_Tablename = "LeaveRequest";
            AV11AuditingObjectRecordItem.gxTpr_Mode = AV14ActualMode;
            AV10AuditingObject.gxTpr_Record.Add(AV11AuditingObjectRecordItem, 0);
            AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestId";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Request Id";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A127LeaveRequestId), 10, 0);
            AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
            AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveTypeId";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Leave Types";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A124LeaveTypeId), 10, 0);
            AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
            AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveTypeName";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Leave Type Name";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A125LeaveTypeName;
            AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
            AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestDate";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Request Date";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A128LeaveRequestDate, 2, "/");
            AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
            AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestStartDate";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Start Date";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A129LeaveRequestStartDate, 2, "/");
            AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
            AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestEndDate";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "End Date";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A130LeaveRequestEndDate, 2, "/");
            AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
            AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestHalfDay";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Half Day";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A171LeaveRequestHalfDay;
            AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
            AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestDuration";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Request Duration";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( A131LeaveRequestDuration, 4, 1);
            AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
            AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestStatus";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Request Status";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A132LeaveRequestStatus;
            AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
            AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestDescription";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Leave Description";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A133LeaveRequestDescription;
            AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
            AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestRejectionReason";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Rejection Reason";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A134LeaveRequestRejectionReason;
            AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
            AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "EmployeeId";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Employees";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A106EmployeeId), 10, 0);
            AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
            AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "EmployeeName";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Employee Name";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A148EmployeeName;
            AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
            AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "EmployeeBalance";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Employee Balance";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( A147EmployeeBalance, 4, 1);
            AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
            AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveTypeVacationLeave";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Leave Type Vacation Leave";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A144LeaveTypeVacationLeave;
            AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
            AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveTypeLoggingWorkHours";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Leave Type Logging Work Hours";
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV12AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A145LeaveTypeLoggingWorkHours;
            AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'LOADNEWVALUES' Routine */
         returnInSub = false;
         /* Using cursor P00BX3 */
         pr_default.execute(1, new Object[] {AV16LeaveRequestId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A127LeaveRequestId = P00BX3_A127LeaveRequestId[0];
            A124LeaveTypeId = P00BX3_A124LeaveTypeId[0];
            A125LeaveTypeName = P00BX3_A125LeaveTypeName[0];
            A128LeaveRequestDate = P00BX3_A128LeaveRequestDate[0];
            A129LeaveRequestStartDate = P00BX3_A129LeaveRequestStartDate[0];
            A130LeaveRequestEndDate = P00BX3_A130LeaveRequestEndDate[0];
            A171LeaveRequestHalfDay = P00BX3_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P00BX3_n171LeaveRequestHalfDay[0];
            A131LeaveRequestDuration = P00BX3_A131LeaveRequestDuration[0];
            A132LeaveRequestStatus = P00BX3_A132LeaveRequestStatus[0];
            A133LeaveRequestDescription = P00BX3_A133LeaveRequestDescription[0];
            A134LeaveRequestRejectionReason = P00BX3_A134LeaveRequestRejectionReason[0];
            A106EmployeeId = P00BX3_A106EmployeeId[0];
            A148EmployeeName = P00BX3_A148EmployeeName[0];
            A147EmployeeBalance = P00BX3_A147EmployeeBalance[0];
            A144LeaveTypeVacationLeave = P00BX3_A144LeaveTypeVacationLeave[0];
            A145LeaveTypeLoggingWorkHours = P00BX3_A145LeaveTypeLoggingWorkHours[0];
            A125LeaveTypeName = P00BX3_A125LeaveTypeName[0];
            A144LeaveTypeVacationLeave = P00BX3_A144LeaveTypeVacationLeave[0];
            A145LeaveTypeLoggingWorkHours = P00BX3_A145LeaveTypeLoggingWorkHours[0];
            A148EmployeeName = P00BX3_A148EmployeeName[0];
            A147EmployeeBalance = P00BX3_A147EmployeeBalance[0];
            if ( StringUtil.StrCmp(AV14ActualMode, "INS") == 0 )
            {
               AV10AuditingObject = new WorkWithPlus.workwithplus_web.SdtAuditingObject(context);
               AV10AuditingObject.gxTpr_Mode = AV14ActualMode;
               AV11AuditingObjectRecordItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem(context);
               AV11AuditingObjectRecordItem.gxTpr_Tablename = "LeaveRequest";
               AV10AuditingObject.gxTpr_Record.Add(AV11AuditingObjectRecordItem, 0);
               AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestId";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Request Id";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A127LeaveRequestId), 10, 0);
               AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
               AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveTypeId";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Leave Types";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A124LeaveTypeId), 10, 0);
               AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
               AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveTypeName";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Leave Type Name";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A125LeaveTypeName;
               AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
               AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestDate";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Request Date";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A128LeaveRequestDate, 2, "/");
               AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
               AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestStartDate";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Start Date";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A129LeaveRequestStartDate, 2, "/");
               AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
               AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestEndDate";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "End Date";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A130LeaveRequestEndDate, 2, "/");
               AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
               AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestHalfDay";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Half Day";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A171LeaveRequestHalfDay;
               AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
               AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestDuration";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Request Duration";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A131LeaveRequestDuration, 4, 1);
               AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
               AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestStatus";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Request Status";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A132LeaveRequestStatus;
               AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
               AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestDescription";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Leave Description";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A133LeaveRequestDescription;
               AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
               AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveRequestRejectionReason";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Rejection Reason";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A134LeaveRequestRejectionReason;
               AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
               AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "EmployeeId";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Employees";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A106EmployeeId), 10, 0);
               AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
               AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "EmployeeName";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Employee Name";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A148EmployeeName;
               AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
               AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "EmployeeBalance";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Employee Balance";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A147EmployeeBalance, 4, 1);
               AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
               AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveTypeVacationLeave";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Leave Type Vacation Leave";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A144LeaveTypeVacationLeave;
               AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
               AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LeaveTypeLoggingWorkHours";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Leave Type Logging Work Hours";
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A145LeaveTypeLoggingWorkHours;
               AV11AuditingObjectRecordItem.gxTpr_Attribute.Add(AV12AuditingObjectRecordItemAttributeItem, 0);
            }
            if ( StringUtil.StrCmp(AV14ActualMode, "UPD") == 0 )
            {
               AV19GXV1 = 1;
               while ( AV19GXV1 <= AV10AuditingObject.gxTpr_Record.Count )
               {
                  AV11AuditingObjectRecordItem = ((WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem)AV10AuditingObject.gxTpr_Record.Item(AV19GXV1));
                  AV20GXV2 = 1;
                  while ( AV20GXV2 <= AV11AuditingObjectRecordItem.gxTpr_Attribute.Count )
                  {
                     AV12AuditingObjectRecordItemAttributeItem = ((WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem)AV11AuditingObjectRecordItem.gxTpr_Attribute.Item(AV20GXV2));
                     if ( StringUtil.StrCmp(AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name, "LeaveRequestId") == 0 )
                     {
                        AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A127LeaveRequestId), 10, 0);
                     }
                     else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name, "LeaveTypeId") == 0 )
                     {
                        AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A124LeaveTypeId), 10, 0);
                     }
                     else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name, "LeaveTypeName") == 0 )
                     {
                        AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A125LeaveTypeName;
                     }
                     else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name, "LeaveRequestDate") == 0 )
                     {
                        AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A128LeaveRequestDate, 2, "/");
                     }
                     else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name, "LeaveRequestStartDate") == 0 )
                     {
                        AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A129LeaveRequestStartDate, 2, "/");
                     }
                     else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name, "LeaveRequestEndDate") == 0 )
                     {
                        AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A130LeaveRequestEndDate, 2, "/");
                     }
                     else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name, "LeaveRequestHalfDay") == 0 )
                     {
                        AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A171LeaveRequestHalfDay;
                     }
                     else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name, "LeaveRequestDuration") == 0 )
                     {
                        AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A131LeaveRequestDuration, 4, 1);
                     }
                     else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name, "LeaveRequestStatus") == 0 )
                     {
                        AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A132LeaveRequestStatus;
                     }
                     else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name, "LeaveRequestDescription") == 0 )
                     {
                        AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A133LeaveRequestDescription;
                     }
                     else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name, "LeaveRequestRejectionReason") == 0 )
                     {
                        AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A134LeaveRequestRejectionReason;
                     }
                     else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name, "EmployeeId") == 0 )
                     {
                        AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A106EmployeeId), 10, 0);
                     }
                     else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name, "EmployeeName") == 0 )
                     {
                        AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A148EmployeeName;
                     }
                     else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name, "EmployeeBalance") == 0 )
                     {
                        AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A147EmployeeBalance, 4, 1);
                     }
                     else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name, "LeaveTypeVacationLeave") == 0 )
                     {
                        AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A144LeaveTypeVacationLeave;
                     }
                     else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItemAttributeItem.gxTpr_Name, "LeaveTypeLoggingWorkHours") == 0 )
                     {
                        AV12AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A145LeaveTypeLoggingWorkHours;
                     }
                     AV20GXV2 = (int)(AV20GXV2+1);
                  }
                  AV19GXV1 = (int)(AV19GXV1+1);
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
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
         P00BX2_A127LeaveRequestId = new long[1] ;
         P00BX2_A124LeaveTypeId = new long[1] ;
         P00BX2_A125LeaveTypeName = new string[] {""} ;
         P00BX2_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         P00BX2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00BX2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00BX2_A171LeaveRequestHalfDay = new string[] {""} ;
         P00BX2_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00BX2_A131LeaveRequestDuration = new decimal[1] ;
         P00BX2_A132LeaveRequestStatus = new string[] {""} ;
         P00BX2_A133LeaveRequestDescription = new string[] {""} ;
         P00BX2_A134LeaveRequestRejectionReason = new string[] {""} ;
         P00BX2_A106EmployeeId = new long[1] ;
         P00BX2_A148EmployeeName = new string[] {""} ;
         P00BX2_A147EmployeeBalance = new decimal[1] ;
         P00BX2_A144LeaveTypeVacationLeave = new string[] {""} ;
         P00BX2_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         A125LeaveTypeName = "";
         A128LeaveRequestDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A171LeaveRequestHalfDay = "";
         A132LeaveRequestStatus = "";
         A133LeaveRequestDescription = "";
         A134LeaveRequestRejectionReason = "";
         A148EmployeeName = "";
         A144LeaveTypeVacationLeave = "";
         A145LeaveTypeLoggingWorkHours = "";
         AV11AuditingObjectRecordItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem(context);
         AV12AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
         P00BX3_A127LeaveRequestId = new long[1] ;
         P00BX3_A124LeaveTypeId = new long[1] ;
         P00BX3_A125LeaveTypeName = new string[] {""} ;
         P00BX3_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         P00BX3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00BX3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00BX3_A171LeaveRequestHalfDay = new string[] {""} ;
         P00BX3_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00BX3_A131LeaveRequestDuration = new decimal[1] ;
         P00BX3_A132LeaveRequestStatus = new string[] {""} ;
         P00BX3_A133LeaveRequestDescription = new string[] {""} ;
         P00BX3_A134LeaveRequestRejectionReason = new string[] {""} ;
         P00BX3_A106EmployeeId = new long[1] ;
         P00BX3_A148EmployeeName = new string[] {""} ;
         P00BX3_A147EmployeeBalance = new decimal[1] ;
         P00BX3_A144LeaveTypeVacationLeave = new string[] {""} ;
         P00BX3_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.loadauditleaverequest__default(),
            new Object[][] {
                new Object[] {
               P00BX2_A127LeaveRequestId, P00BX2_A124LeaveTypeId, P00BX2_A125LeaveTypeName, P00BX2_A128LeaveRequestDate, P00BX2_A129LeaveRequestStartDate, P00BX2_A130LeaveRequestEndDate, P00BX2_A171LeaveRequestHalfDay, P00BX2_n171LeaveRequestHalfDay, P00BX2_A131LeaveRequestDuration, P00BX2_A132LeaveRequestStatus,
               P00BX2_A133LeaveRequestDescription, P00BX2_A134LeaveRequestRejectionReason, P00BX2_A106EmployeeId, P00BX2_A148EmployeeName, P00BX2_A147EmployeeBalance, P00BX2_A144LeaveTypeVacationLeave, P00BX2_A145LeaveTypeLoggingWorkHours
               }
               , new Object[] {
               P00BX3_A127LeaveRequestId, P00BX3_A124LeaveTypeId, P00BX3_A125LeaveTypeName, P00BX3_A128LeaveRequestDate, P00BX3_A129LeaveRequestStartDate, P00BX3_A130LeaveRequestEndDate, P00BX3_A171LeaveRequestHalfDay, P00BX3_n171LeaveRequestHalfDay, P00BX3_A131LeaveRequestDuration, P00BX3_A132LeaveRequestStatus,
               P00BX3_A133LeaveRequestDescription, P00BX3_A134LeaveRequestRejectionReason, P00BX3_A106EmployeeId, P00BX3_A148EmployeeName, P00BX3_A147EmployeeBalance, P00BX3_A144LeaveTypeVacationLeave, P00BX3_A145LeaveTypeLoggingWorkHours
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV19GXV1 ;
      private int AV20GXV2 ;
      private long AV16LeaveRequestId ;
      private long A127LeaveRequestId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private decimal A131LeaveRequestDuration ;
      private decimal A147EmployeeBalance ;
      private string AV13SaveOldValues ;
      private string AV14ActualMode ;
      private string A125LeaveTypeName ;
      private string A171LeaveRequestHalfDay ;
      private string A132LeaveRequestStatus ;
      private string A148EmployeeName ;
      private string A144LeaveTypeVacationLeave ;
      private string A145LeaveTypeLoggingWorkHours ;
      private DateTime A128LeaveRequestDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool returnInSub ;
      private bool n171LeaveRequestHalfDay ;
      private string A133LeaveRequestDescription ;
      private string A134LeaveRequestRejectionReason ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject AV10AuditingObject ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private long[] P00BX2_A127LeaveRequestId ;
      private long[] P00BX2_A124LeaveTypeId ;
      private string[] P00BX2_A125LeaveTypeName ;
      private DateTime[] P00BX2_A128LeaveRequestDate ;
      private DateTime[] P00BX2_A129LeaveRequestStartDate ;
      private DateTime[] P00BX2_A130LeaveRequestEndDate ;
      private string[] P00BX2_A171LeaveRequestHalfDay ;
      private bool[] P00BX2_n171LeaveRequestHalfDay ;
      private decimal[] P00BX2_A131LeaveRequestDuration ;
      private string[] P00BX2_A132LeaveRequestStatus ;
      private string[] P00BX2_A133LeaveRequestDescription ;
      private string[] P00BX2_A134LeaveRequestRejectionReason ;
      private long[] P00BX2_A106EmployeeId ;
      private string[] P00BX2_A148EmployeeName ;
      private decimal[] P00BX2_A147EmployeeBalance ;
      private string[] P00BX2_A144LeaveTypeVacationLeave ;
      private string[] P00BX2_A145LeaveTypeLoggingWorkHours ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem AV11AuditingObjectRecordItem ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem AV12AuditingObjectRecordItemAttributeItem ;
      private long[] P00BX3_A127LeaveRequestId ;
      private long[] P00BX3_A124LeaveTypeId ;
      private string[] P00BX3_A125LeaveTypeName ;
      private DateTime[] P00BX3_A128LeaveRequestDate ;
      private DateTime[] P00BX3_A129LeaveRequestStartDate ;
      private DateTime[] P00BX3_A130LeaveRequestEndDate ;
      private string[] P00BX3_A171LeaveRequestHalfDay ;
      private bool[] P00BX3_n171LeaveRequestHalfDay ;
      private decimal[] P00BX3_A131LeaveRequestDuration ;
      private string[] P00BX3_A132LeaveRequestStatus ;
      private string[] P00BX3_A133LeaveRequestDescription ;
      private string[] P00BX3_A134LeaveRequestRejectionReason ;
      private long[] P00BX3_A106EmployeeId ;
      private string[] P00BX3_A148EmployeeName ;
      private decimal[] P00BX3_A147EmployeeBalance ;
      private string[] P00BX3_A144LeaveTypeVacationLeave ;
      private string[] P00BX3_A145LeaveTypeLoggingWorkHours ;
   }

   public class loadauditleaverequest__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BX2;
          prmP00BX2 = new Object[] {
          new ParDef("AV16LeaveRequestId",GXType.Int64,10,0)
          };
          Object[] prmP00BX3;
          prmP00BX3 = new Object[] {
          new ParDef("AV16LeaveRequestId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BX2", "SELECT T1.LeaveRequestId, T1.LeaveTypeId, T2.LeaveTypeName, T1.LeaveRequestDate, T1.LeaveRequestStartDate, T1.LeaveRequestEndDate, T1.LeaveRequestHalfDay, T1.LeaveRequestDuration, T1.LeaveRequestStatus, T1.LeaveRequestDescription, T1.LeaveRequestRejectionReason, T1.EmployeeId, T3.EmployeeName, T3.EmployeeBalance, T2.LeaveTypeVacationLeave, T2.LeaveTypeLoggingWorkHours FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId) WHERE T1.LeaveRequestId = :AV16LeaveRequestId ORDER BY T1.LeaveRequestId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BX2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BX3", "SELECT T1.LeaveRequestId, T1.LeaveTypeId, T2.LeaveTypeName, T1.LeaveRequestDate, T1.LeaveRequestStartDate, T1.LeaveRequestEndDate, T1.LeaveRequestHalfDay, T1.LeaveRequestDuration, T1.LeaveRequestStatus, T1.LeaveRequestDescription, T1.LeaveRequestRejectionReason, T1.EmployeeId, T3.EmployeeName, T3.EmployeeBalance, T2.LeaveTypeVacationLeave, T2.LeaveTypeLoggingWorkHours FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId) WHERE T1.LeaveRequestId = :AV16LeaveRequestId ORDER BY T1.LeaveRequestId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BX3,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((long[]) buf[12])[0] = rslt.getLong(12);
                ((string[]) buf[13])[0] = rslt.getString(13, 100);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((string[]) buf[15])[0] = rslt.getString(15, 20);
                ((string[]) buf[16])[0] = rslt.getString(16, 20);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((long[]) buf[12])[0] = rslt.getLong(12);
                ((string[]) buf[13])[0] = rslt.getString(13, 100);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((string[]) buf[15])[0] = rslt.getString(15, 20);
                ((string[]) buf[16])[0] = rslt.getString(16, 20);
                return;
       }
    }

 }

}
