using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class GxFullTextSearchReindexer
   {
      public static int Reindex( IGxContext context )
      {
         GxSilentTrnSdt obj;
         IGxSilentTrn trn;
         bool result;
         obj = new GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtDevice(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.workwithplus.SdtWWP_Parameter(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtProject(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtCompany(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtWorkHourLog(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtLeaveType(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtCompanyLocation(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtEmployee(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtLeaveRequest(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         return 1 ;
      }

   }

}
