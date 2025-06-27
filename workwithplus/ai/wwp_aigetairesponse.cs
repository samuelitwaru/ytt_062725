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
namespace GeneXus.Programs.workwithplus.ai {
   public class wwp_aigetairesponse : GXProcedure
   {
      public wwp_aigetairesponse( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_aigetairesponse( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_SystemContent ,
                           string aP1_UserContent ,
                           out string aP2_ErrorMessage ,
                           out string aP3_ResponseText )
      {
         this.AV15SystemContent = aP0_SystemContent;
         this.AV16UserContent = aP1_UserContent;
         this.AV11ErrorMessage = "" ;
         this.AV14ResponseText = "" ;
         initialize();
         ExecuteImpl();
         aP2_ErrorMessage=this.AV11ErrorMessage;
         aP3_ResponseText=this.AV14ResponseText;
      }

      public string executeUdp( string aP0_SystemContent ,
                                string aP1_UserContent ,
                                out string aP2_ErrorMessage )
      {
         execute(aP0_SystemContent, aP1_UserContent, out aP2_ErrorMessage, out aP3_ResponseText);
         return AV14ResponseText ;
      }

      public void executeSubmit( string aP0_SystemContent ,
                                 string aP1_UserContent ,
                                 out string aP2_ErrorMessage ,
                                 out string aP3_ResponseText )
      {
         this.AV15SystemContent = aP0_SystemContent;
         this.AV16UserContent = aP1_UserContent;
         this.AV11ErrorMessage = "" ;
         this.AV14ResponseText = "" ;
         SubmitImpl();
         aP2_ErrorMessage=this.AV11ErrorMessage;
         aP3_ResponseText=this.AV14ResponseText;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8ChatCompletionRequestSDT = new GeneXus.Programs.workwithplus.ai.SdtWWP_AIChatCompletionRequest(context);
         AV8ChatCompletionRequestSDT.gxTpr_Model = "gpt-3.5-turbo-1106";
         AV9ChatCompletionRequestSDTMessage = new GeneXus.Programs.workwithplus.ai.SdtWWP_AIChatCompletionRequest_messagesItem(context);
         AV9ChatCompletionRequestSDTMessage.gxTpr_Role = "system";
         AV9ChatCompletionRequestSDTMessage.gxTpr_Content = AV15SystemContent;
         AV8ChatCompletionRequestSDT.gxTpr_Messages.Add(AV9ChatCompletionRequestSDTMessage, 0);
         AV9ChatCompletionRequestSDTMessage = new GeneXus.Programs.workwithplus.ai.SdtWWP_AIChatCompletionRequest_messagesItem(context);
         AV9ChatCompletionRequestSDTMessage.gxTpr_Role = "user";
         AV9ChatCompletionRequestSDTMessage.gxTpr_Content = AV16UserContent;
         AV8ChatCompletionRequestSDT.gxTpr_Messages.Add(AV9ChatCompletionRequestSDTMessage, 0);
         AV19MaxAttempts = 3;
         while ( AV19MaxAttempts > 0 )
         {
            /* Execute user subroutine: 'SET SAIA PARAMETERS' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            AV12HttpClient.AddString(AV8ChatCompletionRequestSDT.ToJSonString(false, true));
            AV12HttpClient.Execute("POST", "chat/completions");
            if ( AV12HttpClient.StatusCode == 200 )
            {
               AV19MaxAttempts = 0;
            }
            else
            {
               AV19MaxAttempts = (short)(AV19MaxAttempts-1);
            }
         }
         if ( ( AV12HttpClient.ErrCode != 0 ) || ( AV12HttpClient.StatusCode != 200 ) )
         {
            AV11ErrorMessage = "An internal error ocurred while trying to analyze the query.";
            new GeneXus.Core.genexus.common.SdtLog(context).error(StringUtil.Format( "ErrCode: %1", StringUtil.Trim( StringUtil.Str( (decimal)(AV12HttpClient.ErrCode), 10, 2)), "", "", "", "", "", "", "", ""), AV20Pgmname) ;
            new GeneXus.Core.genexus.common.SdtLog(context).error(StringUtil.Format( "ErrDescription: %1", AV12HttpClient.ErrDescription, "", "", "", "", "", "", "", ""), AV20Pgmname) ;
            new GeneXus.Core.genexus.common.SdtLog(context).error(StringUtil.Format( "StatusCode: %1", StringUtil.Trim( StringUtil.Str( (decimal)(AV12HttpClient.StatusCode), 10, 2)), "", "", "", "", "", "", "", ""), AV20Pgmname) ;
            new GeneXus.Core.genexus.common.SdtLog(context).error(StringUtil.Format( "Response: %1", AV12HttpClient.ToString(), "", "", "", "", "", "", "", ""), AV20Pgmname) ;
         }
         else
         {
            AV13ParseResult = AV10ChatCompletionResponseSDT.FromJSonString(AV12HttpClient.ToString(), null);
            if ( ! AV13ParseResult )
            {
               AV11ErrorMessage = "An internal error ocurred while trying to analyze the query.";
               new GeneXus.Core.genexus.common.SdtLog(context).error(StringUtil.Format( "Error parsing response: %1", AV12HttpClient.ToString(), "", "", "", "", "", "", "", ""), AV20Pgmname) ;
            }
            else
            {
               AV14ResponseText = ((GeneXus.Programs.workwithplus.ai.SdtWWP_AIChatCompletionResponse_choicesItem)AV10ChatCompletionResponseSDT.gxTpr_Choices.Item(1)).gxTpr_Message.gxTpr_Content;
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11ErrorMessage)) )
         {
            AV14ResponseText = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'SET SAIA PARAMETERS' Routine */
         returnInSub = false;
         AV12HttpClient = new GxHttpClient( context);
         AV12HttpClient.Secure = 1;
         AV12HttpClient.Host = "api.saia.ai";
         AV12HttpClient.Port = 443;
         AV12HttpClient.BaseURL = "proxy/openai/v1";
         AV12HttpClient.AddHeader("Content-Type", "application/json");
         AV12HttpClient.AddHeader("Authorization", new GeneXus.Programs.workwithplus.wwp_getsystemparameter(context).executeUdp(  "AI_SAIAAuthorizationToken"));
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
         AV11ErrorMessage = "";
         AV14ResponseText = "";
         AV8ChatCompletionRequestSDT = new GeneXus.Programs.workwithplus.ai.SdtWWP_AIChatCompletionRequest(context);
         AV9ChatCompletionRequestSDTMessage = new GeneXus.Programs.workwithplus.ai.SdtWWP_AIChatCompletionRequest_messagesItem(context);
         AV12HttpClient = new GxHttpClient( context);
         AV20Pgmname = "";
         AV10ChatCompletionResponseSDT = new GeneXus.Programs.workwithplus.ai.SdtWWP_AIChatCompletionResponse(context);
         AV20Pgmname = "WorkWithPlus.AI.WWP_AIGetAIResponse";
         /* GeneXus formulas. */
         AV20Pgmname = "WorkWithPlus.AI.WWP_AIGetAIResponse";
      }

      private short AV19MaxAttempts ;
      private string AV20Pgmname ;
      private bool returnInSub ;
      private bool AV13ParseResult ;
      private string AV15SystemContent ;
      private string AV16UserContent ;
      private string AV11ErrorMessage ;
      private string AV14ResponseText ;
      private GxHttpClient AV12HttpClient ;
      private GeneXus.Programs.workwithplus.ai.SdtWWP_AIChatCompletionRequest AV8ChatCompletionRequestSDT ;
      private GeneXus.Programs.workwithplus.ai.SdtWWP_AIChatCompletionRequest_messagesItem AV9ChatCompletionRequestSDTMessage ;
      private GeneXus.Programs.workwithplus.ai.SdtWWP_AIChatCompletionResponse AV10ChatCompletionResponseSDT ;
      private string aP2_ErrorMessage ;
      private string aP3_ResponseText ;
   }

}
