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
   public class wwp_aigetnlfilterfromai : GXProcedure
   {
      public wwp_aigetnlfilterfromai( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_aigetnlfilterfromai( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ListName ,
                           string aP1_UserQuery ,
                           out string aP2_Link ,
                           out string aP3_ErrorMessage )
      {
         this.AV19ListName = aP0_ListName;
         this.AV25UserQuery = aP1_UserQuery;
         this.AV18Link = "" ;
         this.AV9ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP2_Link=this.AV18Link;
         aP3_ErrorMessage=this.AV9ErrorMessage;
      }

      public string executeUdp( string aP0_ListName ,
                                string aP1_UserQuery ,
                                out string aP2_Link )
      {
         execute(aP0_ListName, aP1_UserQuery, out aP2_Link, out aP3_ErrorMessage);
         return AV9ErrorMessage ;
      }

      public void executeSubmit( string aP0_ListName ,
                                 string aP1_UserQuery ,
                                 out string aP2_Link ,
                                 out string aP3_ErrorMessage )
      {
         this.AV19ListName = aP0_ListName;
         this.AV25UserQuery = aP1_UserQuery;
         this.AV18Link = "" ;
         this.AV9ErrorMessage = "" ;
         SubmitImpl();
         aP2_Link=this.AV18Link;
         aP3_ErrorMessage=this.AV9ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Execute user subroutine: 'GET SYSTEM CONTENT' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9ErrorMessage)) )
         {
            GXt_char1 = AV22ResponseText;
            new GeneXus.Programs.workwithplus.ai.wwp_aigetairesponse(context ).execute(  AV24SystemContent,  AV25UserQuery, out  AV9ErrorMessage, out  GXt_char1) ;
            AV22ResponseText = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9ErrorMessage)) )
            {
               AV21ParseResult = AV29WWPNLQueryResponse.FromJSonString(AV22ResponseText, null);
               if ( ! AV21ParseResult )
               {
                  AV22ResponseText = StringUtil.Trim( StringUtil.StringReplace( AV22ResponseText, "`", ""));
                  if ( StringUtil.StartsWith( StringUtil.Lower( AV22ResponseText), "json") )
                  {
                     AV22ResponseText = StringUtil.Substring( AV22ResponseText, 5, -1);
                  }
                  AV21ParseResult = AV29WWPNLQueryResponse.FromJSonString(AV22ResponseText, null);
               }
               if ( ! AV21ParseResult )
               {
                  AV9ErrorMessage = "An internal error ocurred while trying to analyze the query.";
                  new GeneXus.Core.genexus.common.SdtLog(context).error(StringUtil.Format( "Error parsing response: %1", AV22ResponseText, "", "", "", "", "", "", "", ""), AV36Pgmname) ;
               }
               else
               {
                  AV16GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV19ListName+"GridState"), null, "", "");
                  if ( ! (0==AV29WWPNLQueryResponse.gxTpr_Sort.gxTpr_Index) )
                  {
                     AV16GridState.gxTpr_Orderedby = AV29WWPNLQueryResponse.gxTpr_Sort.gxTpr_Index;
                     AV16GridState.gxTpr_Ordereddsc = AV29WWPNLQueryResponse.gxTpr_Sort.gxTpr_Descending;
                  }
                  if ( ( AV29WWPNLQueryResponse.gxTpr_Userintent > 1 ) && ( AV29WWPNLQueryResponse.gxTpr_Userintent <= 5 ) )
                  {
                     AV23Session.Set(AV19ListName+"QueryIntent", StringUtil.Trim( StringUtil.Str( (decimal)(AV29WWPNLQueryResponse.gxTpr_Userintent), 4, 0)));
                  }
                  else
                  {
                     AV23Session.Remove(AV19ListName+"QueryIntent");
                  }
                  AV37GXV1 = 1;
                  while ( AV37GXV1 <= AV29WWPNLQueryResponse.gxTpr_Filtervalues.Count )
                  {
                     AV13FilterValue = ((GeneXus.Programs.workwithplus.ai.SdtWWP_AINLQueryResponse_FilterValue)AV29WWPNLQueryResponse.gxTpr_Filtervalues.Item(AV37GXV1));
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV13FilterValue.gxTpr_Valueto))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV13FilterValue.gxTpr_Value))) )
                     {
                        AV13FilterValue.gxTpr_Valueto = AV13FilterValue.gxTpr_Value;
                     }
                     else if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV13FilterValue.gxTpr_Value))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV13FilterValue.gxTpr_Valuefrom))) )
                     {
                        AV13FilterValue.gxTpr_Value = AV13FilterValue.gxTpr_Valuefrom;
                     }
                     AV37GXV1 = (int)(AV37GXV1+1);
                  }
                  AV16GridState.gxTpr_Filtervalues.FromJSonString(AV29WWPNLQueryResponse.gxTpr_Filtervalues.ToJSonString(false), null);
                  AV16GridState.gxTpr_Dynamicfilters.Clear();
                  /* Execute user subroutine: 'FIX FILTERS VALUES' */
                  S111 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
                  new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV19ListName+"GridState",  AV16GridState.ToXml(false, true, "", "")) ;
                  new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV19ListName+"NLQuery",  AV25UserQuery) ;
               }
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'FIX FILTERS VALUES' Routine */
         returnInSub = false;
         AV38GXV2 = 1;
         while ( AV38GXV2 <= AV12FiltersFixes.Count )
         {
            AV10FilterFix = ((GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData_ListQuery_FiltersToFixItem)AV12FiltersFixes.Item(AV38GXV2));
            AV14Found = false;
            AV20OptionsToRemove = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
            AV11FilterIndex = 1;
            AV39GXV3 = 1;
            while ( AV39GXV3 <= AV16GridState.gxTpr_Filtervalues.Count )
            {
               AV17GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV16GridState.gxTpr_Filtervalues.Item(AV39GXV3));
               if ( ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, AV10FilterFix.gxTpr_Name) == 0 ) || ( AV10FilterFix.gxTpr_Fixtype != 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( AV17GridStateFilterValue.gxTpr_Name, 1, StringUtil.Len( AV17GridStateFilterValue.gxTpr_Name)-2), AV10FilterFix.gxTpr_Name+"_") == 0 ) )
               {
                  if ( AV10FilterFix.gxTpr_Fixtype == 0 )
                  {
                     if ( StringUtil.StrCmp(AV10FilterFix.gxTpr_Type, "DATETIME") == 0 )
                     {
                        if ( StringUtil.StrCmp(StringUtil.Trim( AV17GridStateFilterValue.gxTpr_Value), "*") == 0 )
                        {
                           AV17GridStateFilterValue.gxTpr_Value = "";
                        }
                        if ( StringUtil.StrCmp(StringUtil.Trim( AV17GridStateFilterValue.gxTpr_Valueto), "*") == 0 )
                        {
                           AV17GridStateFilterValue.gxTpr_Valueto = "";
                        }
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV17GridStateFilterValue.gxTpr_Value))) )
                        {
                           AV32DateTimeAux = (DateTime)(DateTime.MinValue);
                           AV32DateTimeAux = context.localUtil.CToT( AV17GridStateFilterValue.gxTpr_Value, 2);
                           if ( ! (DateTime.MinValue==AV32DateTimeAux) )
                           {
                              AV32DateTimeAux = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV32DateTimeAux)), (short)(DateTimeUtil.Month( AV32DateTimeAux)), (short)(DateTimeUtil.Day( AV32DateTimeAux)), 0, 0, 0);
                              AV17GridStateFilterValue.gxTpr_Value = StringUtil.Trim( context.localUtil.TToC( AV32DateTimeAux, 8, 5, 1, 3, "/", ":", " "));
                           }
                        }
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV17GridStateFilterValue.gxTpr_Valueto))) )
                        {
                           AV32DateTimeAux = (DateTime)(DateTime.MinValue);
                           AV32DateTimeAux = context.localUtil.CToT( AV17GridStateFilterValue.gxTpr_Valueto, 2);
                           if ( ! (DateTime.MinValue==AV32DateTimeAux) )
                           {
                              AV32DateTimeAux = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV32DateTimeAux)), (short)(DateTimeUtil.Month( AV32DateTimeAux)), (short)(DateTimeUtil.Day( AV32DateTimeAux)), 23, 59, 59);
                              AV17GridStateFilterValue.gxTpr_Valueto = StringUtil.Trim( context.localUtil.TToC( AV32DateTimeAux, 8, 5, 1, 3, "/", ":", " "));
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(AV10FilterFix.gxTpr_Type, "DATE") == 0 )
                     {
                        if ( StringUtil.StrCmp(StringUtil.Trim( AV17GridStateFilterValue.gxTpr_Value), "*") == 0 )
                        {
                           AV17GridStateFilterValue.gxTpr_Value = "";
                        }
                        if ( StringUtil.StrCmp(StringUtil.Trim( AV17GridStateFilterValue.gxTpr_Valueto), "*") == 0 )
                        {
                           AV17GridStateFilterValue.gxTpr_Valueto = "";
                        }
                     }
                     else if ( StringUtil.StrCmp(AV10FilterFix.gxTpr_Type, "NUMERIC") == 0 )
                     {
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV17GridStateFilterValue.gxTpr_Value))) && ( NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, ".") < Convert.ToDecimal( 0 )) && ( NumberUtil.Val( StringUtil.Substring( AV17GridStateFilterValue.gxTpr_Value, 2, -1), ".") > Convert.ToDecimal( 0 )) )
                        {
                           AV17GridStateFilterValue.gxTpr_Value = StringUtil.Substring( AV17GridStateFilterValue.gxTpr_Value, 2, -1);
                        }
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV17GridStateFilterValue.gxTpr_Valueto))) && ( NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Valueto, ".") < Convert.ToDecimal( 0 )) && ( NumberUtil.Val( StringUtil.Substring( AV17GridStateFilterValue.gxTpr_Valueto, 2, -1), ".") > Convert.ToDecimal( 0 )) )
                        {
                           AV17GridStateFilterValue.gxTpr_Valueto = StringUtil.Substring( AV17GridStateFilterValue.gxTpr_Valueto, 2, -1);
                        }
                     }
                     else if ( StringUtil.StrCmp(AV10FilterFix.gxTpr_Type, "VARCHAR") == 0 )
                     {
                        if ( AV10FilterFix.gxTpr_Multiplevalues )
                        {
                           AV26VarCharList = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                           if ( AV14Found )
                           {
                              AV20OptionsToRemove.Add(AV11FilterIndex, 0);
                              AV26VarCharList.FromJSonString(AV15FoundGridStateFilterValue.gxTpr_Value, null);
                           }
                           if ( ! AV10FilterFix.gxTpr_Valueshascomma && StringUtil.Contains( AV17GridStateFilterValue.gxTpr_Value, ",") )
                           {
                              AV41GXV5 = 1;
                              AV40GXV4 = GxRegex.Split(AV17GridStateFilterValue.gxTpr_Value,",");
                              while ( AV41GXV5 <= AV40GXV4.Count )
                              {
                                 AV31AuxText = AV40GXV4.GetString(AV41GXV5);
                                 if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV31AuxText))) )
                                 {
                                    AV26VarCharList.Add(StringUtil.Trim( AV31AuxText), 0);
                                 }
                                 AV41GXV5 = (int)(AV41GXV5+1);
                              }
                           }
                           else
                           {
                              AV26VarCharList.Add(AV17GridStateFilterValue.gxTpr_Value, 0);
                              if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17GridStateFilterValue.gxTpr_Valueto)) && ( StringUtil.StrCmp(StringUtil.Trim( AV17GridStateFilterValue.gxTpr_Value), StringUtil.Trim( AV17GridStateFilterValue.gxTpr_Valueto)) != 0 ) )
                              {
                                 AV26VarCharList.Add(AV17GridStateFilterValue.gxTpr_Valueto, 0);
                              }
                           }
                           if ( AV14Found )
                           {
                              AV15FoundGridStateFilterValue.gxTpr_Value = AV26VarCharList.ToJSonString(false);
                           }
                           else
                           {
                              AV17GridStateFilterValue.gxTpr_Value = AV26VarCharList.ToJSonString(false);
                           }
                        }
                     }
                  }
                  else if ( AV10FilterFix.gxTpr_Fixtype == 1 )
                  {
                     AV17GridStateFilterValue.gxTpr_Operator = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV17GridStateFilterValue.gxTpr_Name, StringUtil.Len( AV17GridStateFilterValue.gxTpr_Name)-1, -1), "."), 18, MidpointRounding.ToEven));
                     AV17GridStateFilterValue.gxTpr_Operator = (short)(AV17GridStateFilterValue.gxTpr_Operator-1);
                     AV17GridStateFilterValue.gxTpr_Name = StringUtil.Substring( AV17GridStateFilterValue.gxTpr_Name, 1, StringUtil.Len( AV17GridStateFilterValue.gxTpr_Name)-3);
                  }
                  if ( ! AV14Found )
                  {
                     AV14Found = true;
                     AV15FoundGridStateFilterValue = AV17GridStateFilterValue;
                  }
               }
               AV11FilterIndex = (short)(AV11FilterIndex+1);
               AV39GXV3 = (int)(AV39GXV3+1);
            }
            /* Execute user subroutine: 'REMOVE FILTER VALUES' */
            S131 ();
            if (returnInSub) return;
            AV38GXV2 = (int)(AV38GXV2+1);
         }
         AV20OptionsToRemove = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         AV11FilterIndex = 1;
         AV33FullTextFilter = "";
         AV42GXV6 = 1;
         while ( AV42GXV6 <= AV16GridState.gxTpr_Filtervalues.Count )
         {
            AV17GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV16GridState.gxTpr_Filtervalues.Item(AV42GXV6));
            if ( StringUtil.StartsWith( AV17GridStateFilterValue.gxTpr_Name, "DYN") )
            {
               AV34DynFilter = new WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter(context);
               AV34DynFilter.FromJSonString(AV17GridStateFilterValue.ToJSonString(false, true), null);
               AV34DynFilter.gxTpr_Selected = StringUtil.Substring( AV17GridStateFilterValue.gxTpr_Name, 4, -1);
               AV16GridState.gxTpr_Dynamicfilters.Add(AV34DynFilter, 0);
               AV20OptionsToRemove.Add(AV11FilterIndex, 0);
            }
            else if ( StringUtil.StartsWith( AV17GridStateFilterValue.gxTpr_Name, "FTF") )
            {
               AV20OptionsToRemove.Add(AV11FilterIndex, 0);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33FullTextFilter)) )
               {
                  AV33FullTextFilter = AV17GridStateFilterValue.gxTpr_Value;
               }
            }
            else if ( StringUtil.StartsWith( AV17GridStateFilterValue.gxTpr_Name, "OTF") )
            {
               AV17GridStateFilterValue.gxTpr_Name = StringUtil.Substring( AV17GridStateFilterValue.gxTpr_Name, 2, -1);
               AV17GridStateFilterValue.gxTpr_Operator = (short)(Math.Round(NumberUtil.Val( AV17GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV11FilterIndex = (short)(AV11FilterIndex+1);
            AV42GXV6 = (int)(AV42GXV6+1);
         }
         /* Execute user subroutine: 'REMOVE FILTER VALUES' */
         S131 ();
         if (returnInSub) return;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33FullTextFilter)) )
         {
            AV17GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
            AV17GridStateFilterValue.gxTpr_Name = "FILTERFULLTEXT";
            AV17GridStateFilterValue.gxTpr_Value = AV33FullTextFilter;
            AV16GridState.gxTpr_Filtervalues.Add(AV17GridStateFilterValue, 0);
         }
      }

      protected void S121( )
      {
         /* 'GET SYSTEM CONTENT' Routine */
         returnInSub = false;
         AV24SystemContent = "";
         AV32DateTimeAux = DateTimeUtil.Now( context);
         AV35DateStr = DateTimeUtil.CDow( Gx_date, "eng");
         AV35DateStr += StringUtil.Format( " %1/%2/%3 (%4:%5)", StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( Gx_date)), 10, 0)), 2, "0"), StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( Gx_date)), 10, 0)), 2, "0"), StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( Gx_date)), 10, 0)), StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( AV32DateTimeAux)), 10, 0)), 2, "0"), StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( AV32DateTimeAux)), 10, 0)), 2, "0"), "", "", "", "");
         AV24SystemContent += "You are a JSON generator that transforms natural language queries into JSON format. Today is " + AV35DateStr + " and if no year is specified in the query, the current one must be assumed." + StringUtil.NewLine( );
         AV24SystemContent += "You respond only in the following format:" + StringUtil.NewLine( );
         AV24SystemContent += "{" + StringUtil.NewLine( );
         AV24SystemContent += "  \"Sort\":" + StringUtil.NewLine( );
         AV24SystemContent += "    {" + StringUtil.NewLine( );
         AV24SystemContent += "       \"Index\": Number - Sort index (default index is 0)" + StringUtil.NewLine( );
         AV24SystemContent += "       \"Descending\": Boolean" + StringUtil.NewLine( );
         AV24SystemContent += "    }," + StringUtil.NewLine( );
         AV24SystemContent += "  \"FilterValues\":" + StringUtil.NewLine( );
         AV24SystemContent += "    [" + StringUtil.NewLine( );
         AV24SystemContent += "      {" + StringUtil.NewLine( );
         AV24SystemContent += "        \"Name\": Text - filter name," + StringUtil.NewLine( );
         AV24SystemContent += "        \"Value\": Text - exact value," + StringUtil.NewLine( );
         AV24SystemContent += "        \"ValueFrom\": Text - filter start range," + StringUtil.NewLine( );
         AV24SystemContent += "        \"ValueTo\": Text - filter finish range" + StringUtil.NewLine( );
         AV24SystemContent += "      }" + StringUtil.NewLine( );
         AV24SystemContent += "    ]," + StringUtil.NewLine( );
         AV24SystemContent += "  \"UserIntent\": 1 (list records), 2 (view one record), 3 (edit a record), 4 (delete a record), 5 (add a new record)" + StringUtil.NewLine( );
         AV24SystemContent += "}" + StringUtil.NewLine( );
         AV24SystemContent += "You have the following filters available:" + StringUtil.NewLine( );
         GXt_objcol_SdtWWP_AIListData2 = AV28WWP_AIListDatas;
         GXt_objcol_SdtWWP_AIListData3 = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>();
         new GeneXus.Programs.workwithplus.ai.wwp_aigetlistdata(context ).execute(  "ListQuery",  AV19ListName,  (GXProperties)(GXt_objcol_SdtWWP_AIListData2), out  GXt_objcol_SdtWWP_AIListData3) ;
         AV28WWP_AIListDatas = GXt_objcol_SdtWWP_AIListData2;
         if ( AV28WWP_AIListDatas.Count > 0 )
         {
            AV27WWP_AIListData = ((GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData)AV28WWP_AIListDatas.Item(1));
            AV24SystemContent += AV27WWP_AIListData.gxTpr_Listquery.gxTpr_Contextinfo;
            AV12FiltersFixes = AV27WWP_AIListData.gxTpr_Listquery.gxTpr_Filterstofix;
            AV18Link = AV27WWP_AIListData.gxTpr_Listquery.gxTpr_Link;
         }
         else
         {
            AV9ErrorMessage = "No ListData found for: " + AV19ListName;
         }
      }

      protected void S131( )
      {
         /* 'REMOVE FILTER VALUES' Routine */
         returnInSub = false;
         AV30Removed = 0;
         AV44GXV7 = 1;
         while ( AV44GXV7 <= AV20OptionsToRemove.Count )
         {
            AV11FilterIndex = (short)(AV20OptionsToRemove.GetNumeric(AV44GXV7));
            AV16GridState.gxTpr_Filtervalues.RemoveItem(AV11FilterIndex-AV30Removed);
            AV30Removed = (short)(AV30Removed+1);
            AV44GXV7 = (int)(AV44GXV7+1);
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
         AV18Link = "";
         AV9ErrorMessage = "";
         AV22ResponseText = "";
         GXt_char1 = "";
         AV24SystemContent = "";
         AV29WWPNLQueryResponse = new GeneXus.Programs.workwithplus.ai.SdtWWP_AINLQueryResponse(context);
         AV36Pgmname = "";
         AV16GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV23Session = context.GetSession();
         AV13FilterValue = new GeneXus.Programs.workwithplus.ai.SdtWWP_AINLQueryResponse_FilterValue(context);
         AV12FiltersFixes = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData_ListQuery_FiltersToFixItem>( context, "WWP_AIListData.ListQuery.FiltersToFixItem", "");
         AV10FilterFix = new GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData_ListQuery_FiltersToFixItem(context);
         AV20OptionsToRemove = new GxSimpleCollection<short>();
         AV17GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV32DateTimeAux = (DateTime)(DateTime.MinValue);
         AV26VarCharList = new GxSimpleCollection<string>();
         AV15FoundGridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV40GXV4 = new GxSimpleCollection<string>();
         AV31AuxText = "";
         AV33FullTextFilter = "";
         AV34DynFilter = new WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter(context);
         AV35DateStr = "";
         Gx_date = DateTime.MinValue;
         AV28WWP_AIListDatas = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>( context, "WWP_AIListData", "YTT_version4");
         GXt_objcol_SdtWWP_AIListData2 = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>( context, "WWP_AIListData", "YTT_version4");
         GXt_objcol_SdtWWP_AIListData3 = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>( context, "WWP_AIListData", "YTT_version4");
         AV27WWP_AIListData = new GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData(context);
         Gx_date = DateTimeUtil.Today( context);
         AV36Pgmname = "WorkWithPlus.AI.WWP_AIGetNLFilterFromAI";
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV36Pgmname = "WorkWithPlus.AI.WWP_AIGetNLFilterFromAI";
      }

      private short AV11FilterIndex ;
      private short AV30Removed ;
      private int AV37GXV1 ;
      private int AV38GXV2 ;
      private int AV39GXV3 ;
      private int AV41GXV5 ;
      private int AV42GXV6 ;
      private int AV44GXV7 ;
      private string GXt_char1 ;
      private string AV36Pgmname ;
      private DateTime AV32DateTimeAux ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private bool AV21ParseResult ;
      private bool AV14Found ;
      private string AV25UserQuery ;
      private string AV19ListName ;
      private string AV18Link ;
      private string AV9ErrorMessage ;
      private string AV22ResponseText ;
      private string AV24SystemContent ;
      private string AV31AuxText ;
      private string AV33FullTextFilter ;
      private string AV35DateStr ;
      private IGxSession AV23Session ;
      private GeneXus.Programs.workwithplus.ai.SdtWWP_AINLQueryResponse AV29WWPNLQueryResponse ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV16GridState ;
      private GeneXus.Programs.workwithplus.ai.SdtWWP_AINLQueryResponse_FilterValue AV13FilterValue ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData_ListQuery_FiltersToFixItem> AV12FiltersFixes ;
      private GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData_ListQuery_FiltersToFixItem AV10FilterFix ;
      private GxSimpleCollection<short> AV20OptionsToRemove ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV17GridStateFilterValue ;
      private GxSimpleCollection<string> AV26VarCharList ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV15FoundGridStateFilterValue ;
      private GxSimpleCollection<string> AV40GXV4 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_DynamicFilter AV34DynFilter ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> AV28WWP_AIListDatas ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> GXt_objcol_SdtWWP_AIListData2 ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> GXt_objcol_SdtWWP_AIListData3 ;
      private GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData AV27WWP_AIListData ;
      private string aP2_Link ;
      private string aP3_ErrorMessage ;
   }

}
