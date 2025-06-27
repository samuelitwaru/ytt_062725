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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.workwithplus.nativemobile {
   public class wwpproductslisttodoubleoptionssdt : GXWebProcedure
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
            return "wwpproductslisttodoubleoptionssdt_Services_Execute" ;
         }

      }

      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         AV11DoubleMenuOptions = new GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtDoubleItemListData_DoubleItemListDataItem>( context, "DoubleItemListDataItem", "YTT_version4") ;
         if ( ! context.isAjaxRequest( ) )
         {
            GXSoapHTTPResponse.AppendHeader("Content-type", "text/xml;charset=utf-8");
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapHTTPRequest.Method), "get") == 0 )
         {
            if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapHTTPRequest.QueryString), "wsdl") == 0 )
            {
               GXSoapXMLWriter.OpenResponse(GXSoapHTTPResponse);
               GXSoapXMLWriter.WriteStartDocument("utf-8", 0);
               GXSoapXMLWriter.WriteStartElement("definitions");
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPProductsListToDoubleOptionsSDT");
               GXSoapXMLWriter.WriteAttribute("targetNamespace", "YTT_version4");
               GXSoapXMLWriter.WriteAttribute("xmlns:wsdlns", "YTT_version4");
               GXSoapXMLWriter.WriteAttribute("xmlns:soap", "http://schemas.xmlsoap.org/wsdl/soap/");
               GXSoapXMLWriter.WriteAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
               GXSoapXMLWriter.WriteAttribute("xmlns", "http://schemas.xmlsoap.org/wsdl/");
               GXSoapXMLWriter.WriteAttribute("xmlns:tns", "YTT_version4");
               GXSoapXMLWriter.WriteStartElement("types");
               GXSoapXMLWriter.WriteStartElement("schema");
               GXSoapXMLWriter.WriteAttribute("targetNamespace", "YTT_version4");
               GXSoapXMLWriter.WriteAttribute("xmlns", "http://www.w3.org/2001/XMLSchema");
               GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENC", "http://schemas.xmlsoap.org/soap/encoding/");
               GXSoapXMLWriter.WriteAttribute("elementFormDefault", "qualified");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "ArrayOfWWPProductData");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "0");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "unbounded");
               GXSoapXMLWriter.WriteAttribute("name", "WWPProductData");
               GXSoapXMLWriter.WriteAttribute("type", "tns:WWPProductData");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "WWPProductData");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Id");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Type");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:short");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Title");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Description");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Image");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Image_GXI");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Subtitle");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Information1");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Information2");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "ComponentToCall");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "DoubleItemListData");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "0");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "unbounded");
               GXSoapXMLWriter.WriteAttribute("name", "DoubleItemListDataItem");
               GXSoapXMLWriter.WriteAttribute("type", "tns:WorkWithPlus.NativeMobile.DoubleItemListData.DoubleItemListDataItem");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.DoubleItemListData.DoubleItemListDataItem");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Type");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:short");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Option1Title");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Option1Image");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Option1Image_GXI");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Option1Subtitle");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Option1Information1");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Option1Information2");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Option1Id");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Option1ComponentToCall");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Option2Title");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Option2Image");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Option2Image_GXI");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Option2Subtitle");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Option2Id");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Option2ComponentToCall");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Option2Information1");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Option2Information2");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPProductsListToDoubleOptionsSDT.Execute");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Productdatalist");
               GXSoapXMLWriter.WriteAttribute("type", "tns:ArrayOfWWPProductData");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPProductsListToDoubleOptionsSDT.ExecuteResponse");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Doublemenuoptions");
               GXSoapXMLWriter.WriteAttribute("type", "tns:DoubleItemListData");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPProductsListToDoubleOptionsSDT.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WorkWithPlus.NativeMobile.WWPProductsListToDoubleOptionsSDT.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPProductsListToDoubleOptionsSDT.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WorkWithPlus.NativeMobile.WWPProductsListToDoubleOptionsSDT.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPProductsListToDoubleOptionsSDTSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WorkWithPlus.NativeMobile.WWPProductsListToDoubleOptionsSDT.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WorkWithPlus.NativeMobile.WWPProductsListToDoubleOptionsSDT.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPProductsListToDoubleOptionsSDTSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"WorkWithPlus.NativeMobile.WWPProductsListToDoubleOptionsSDTSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "YTT_version4action/"+"workwithplus.nativemobile.AWWPPRODUCTSLISTTODOUBLEOPTIONSSDT.Execute");
               GXSoapXMLWriter.WriteStartElement("input");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("output");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("service");
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPProductsListToDoubleOptionsSDT");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPProductsListToDoubleOptionsSDTSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"WorkWithPlus.NativeMobile.WWPProductsListToDoubleOptionsSDTSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "http://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"workwithplus.nativemobile.wwpproductslisttodoubleoptionssdt.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "http://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "workwithplus.nativemobile.wwpproductslisttodoubleoptionssdt.aspx" + "?wsdl to get the WSDL.";
            }
         }
         if ( currSoapErr == 0 )
         {
            GXSoapXMLReader.OpenRequest(GXSoapHTTPRequest);
            GXSoapXMLReader.ReadExternalEntities = 0;
            GXSoapXMLReader.IgnoreComments = 1;
            GXSoapError = GXSoapXMLReader.Read();
            while ( GXSoapError > 0 )
            {
               if ( StringUtil.StringSearch( GXSoapXMLReader.Name, "Envelope", 1) > 0 )
               {
                  this.SetPrefixesFromReader( GXSoapXMLReader);
               }
               if ( StringUtil.StringSearch( GXSoapXMLReader.Name, "Body", 1) > 0 )
               {
                  this.SetPrefixesFromReader( GXSoapXMLReader);
                  if (true) break;
               }
               GXSoapError = GXSoapXMLReader.Read();
            }
            if ( GXSoapError > 0 )
            {
               GXSoapError = GXSoapXMLReader.Read();
               if ( GXSoapError > 0 )
               {
                  this.SetPrefixesFromReader( GXSoapXMLReader);
                  currMethod = GXSoapXMLReader.Name;
                  if ( ( StringUtil.StringSearch( currMethod+"&", "Execute&", 1) > 0 ) || ( currSoapErr != 0 ) )
                  {
                     if ( currSoapErr == 0 )
                     {
                        AV14ProductDataList = new GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPProductData>( context, "WWPProductData", "YTT_version4");
                        AV11DoubleMenuOptions = new GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtDoubleItemListData_DoubleItemListDataItem>( context, "DoubleItemListDataItem", "YTT_version4");
                        formatError = false;
                        sTagName = GXSoapXMLReader.Name;
                        if ( GXSoapXMLReader.IsSimple == 0 )
                        {
                           GXSoapError = GXSoapXMLReader.Read();
                           nOutParmCount = 0;
                           while ( ( ( StringUtil.StrCmp(GXSoapXMLReader.Name, sTagName) != 0 ) || ( GXSoapXMLReader.NodeType == 1 ) ) && ( GXSoapError > 0 ) )
                           {
                              readOk = 0;
                              readElement = false;
                              this.SetNamedPrefixesFromReader( GXSoapXMLReader);
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Productdatalist") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "YTT_version4") == 0 ) )
                              {
                                 if ( AV14ProductDataList == null )
                                 {
                                    AV14ProductDataList = new GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPProductData>( context, "WWPProductData", "YTT_version4");
                                 }
                                 if ( GXSoapXMLReader.IsSimple == 0 )
                                 {
                                    AV14ProductDataList.SetPrefixes( GetPrefixesInContext(), GXSoapXMLReader);
                                    GXSoapError = AV14ProductDataList.readxmlcollection(GXSoapXMLReader, "Productdatalist", "WWPProductData");
                                 }
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Productdatalist") )
                                 {
                                    GXSoapError = GXSoapXMLReader.Read();
                                 }
                              }
                              if ( ! readElement )
                              {
                                 readOk = 1;
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              nOutParmCount = (short)(nOutParmCount+1);
                              if ( ( readOk == 0 ) || formatError )
                              {
                                 context.sSOAPErrMsg += "Error reading " + sTagName + StringUtil.NewLine( );
                                 context.sSOAPErrMsg += "Message: " + GXSoapXMLReader.ReadRawXML();
                                 GXSoapError = (short)(nOutParmCount*-1);
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     currSoapErr = (short)(-20002);
                     currSoapErrmsg = "Wrong method called. Expected method: " + "Execute";
                  }
               }
            }
            GXSoapXMLReader.Close();
         }
         if ( currSoapErr == 0 )
         {
            if ( GXSoapError < 0 )
            {
               currSoapErr = (short)(GXSoapError*-1);
               currSoapErrmsg = context.sSOAPErrMsg;
            }
            else
            {
               if ( GXSoapXMLReader.ErrCode > 0 )
               {
                  currSoapErr = (short)(GXSoapXMLReader.ErrCode*-1);
                  currSoapErrmsg = GXSoapXMLReader.ErrDescription;
               }
               else
               {
                  if ( GXSoapError == 0 )
                  {
                     currSoapErr = (short)(-20001);
                     currSoapErrmsg = "Malformed SOAP message.";
                  }
                  else
                  {
                     currSoapErr = 0;
                     currSoapErrmsg = "No error.";
                  }
               }
            }
         }
         if ( currSoapErr == 0 )
         {
            ExecutePrivate();
         }
         context.CloseConnections();
         sIncludeState = true;
         GXSoapXMLWriter.OpenResponse(GXSoapHTTPResponse);
         GXSoapXMLWriter.WriteStartDocument("utf-8", 0);
         GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Envelope");
         GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENV", "http://schemas.xmlsoap.org/soap/envelope/");
         GXSoapXMLWriter.WriteAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
         GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENC", "http://schemas.xmlsoap.org/soap/encoding/");
         GXSoapXMLWriter.WriteAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
         if ( ( StringUtil.StringSearch( currMethod+"&", "Execute&", 1) > 0 ) || ( currSoapErr != 0 ) )
         {
            GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Body");
            GXSoapXMLWriter.WriteStartElement("WorkWithPlus.NativeMobile.WWPProductsListToDoubleOptionsSDT.ExecuteResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "YTT_version4");
            if ( currSoapErr == 0 )
            {
               if ( AV11DoubleMenuOptions != null )
               {
                  AV11DoubleMenuOptions.writexmlcollection(GXSoapXMLWriter, "Doublemenuoptions", "YTT_version4", "DoubleItemListDataItem", "YTT_version4");
               }
            }
            else
            {
               GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Fault");
               GXSoapXMLWriter.WriteElement("faultcode", "SOAP-ENV:Client");
               GXSoapXMLWriter.WriteElement("faultstring", currSoapErrmsg);
               GXSoapXMLWriter.WriteElement("detail", StringUtil.Trim( StringUtil.Str( (decimal)(currSoapErr), 10, 0)));
               GXSoapXMLWriter.WriteEndElement();
            }
            GXSoapXMLWriter.WriteEndElement();
            GXSoapXMLWriter.WriteEndElement();
         }
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.Close();
         cleanup();
      }

      public wwpproductslisttodoubleoptionssdt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwpproductslisttodoubleoptionssdt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPProductData> aP0_ProductDataList ,
                           out GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtDoubleItemListData_DoubleItemListDataItem> aP1_DoubleMenuOptions )
      {
         this.AV14ProductDataList = aP0_ProductDataList;
         this.AV11DoubleMenuOptions = new GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtDoubleItemListData_DoubleItemListDataItem>( context, "DoubleItemListDataItem", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP1_DoubleMenuOptions=this.AV11DoubleMenuOptions;
      }

      public GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtDoubleItemListData_DoubleItemListDataItem> executeUdp( GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPProductData> aP0_ProductDataList )
      {
         execute(aP0_ProductDataList, out aP1_DoubleMenuOptions);
         return AV11DoubleMenuOptions ;
      }

      public void executeSubmit( GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPProductData> aP0_ProductDataList ,
                                 out GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtDoubleItemListData_DoubleItemListDataItem> aP1_DoubleMenuOptions )
      {
         this.AV14ProductDataList = aP0_ProductDataList;
         this.AV11DoubleMenuOptions = new GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtDoubleItemListData_DoubleItemListDataItem>( context, "DoubleItemListDataItem", "YTT_version4") ;
         SubmitImpl();
         aP1_DoubleMenuOptions=this.AV11DoubleMenuOptions;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9IsFirstItem = true;
         AV15GXV1 = 1;
         while ( AV15GXV1 <= AV14ProductDataList.Count )
         {
            AV8ProductData = ((GeneXus.Programs.workwithplus.nativemobile.SdtWWPProductData)AV14ProductDataList.Item(AV15GXV1));
            if ( AV9IsFirstItem )
            {
               AV12DoubleMenuOptionsItem = new GeneXus.Programs.workwithplus.nativemobile.SdtDoubleItemListData_DoubleItemListDataItem(context);
               AV12DoubleMenuOptionsItem.gxTpr_Option1componenttocall = AV13ProductDataItem.gxTpr_Componenttocall;
               AV12DoubleMenuOptionsItem.gxTpr_Option1id = AV13ProductDataItem.gxTpr_Id;
               AV12DoubleMenuOptionsItem.gxTpr_Option1image = AV13ProductDataItem.gxTpr_Image;
               AV12DoubleMenuOptionsItem.gxTpr_Option1image_gxi = AV13ProductDataItem.gxTpr_Image_gxi;
               AV12DoubleMenuOptionsItem.gxTpr_Option1information1 = AV13ProductDataItem.gxTpr_Information1;
               AV12DoubleMenuOptionsItem.gxTpr_Option1information2 = AV13ProductDataItem.gxTpr_Information2;
               AV12DoubleMenuOptionsItem.gxTpr_Option1subtitle = AV13ProductDataItem.gxTpr_Subtitle;
               AV12DoubleMenuOptionsItem.gxTpr_Option1title = AV13ProductDataItem.gxTpr_Title;
               AV11DoubleMenuOptions.Add(AV12DoubleMenuOptionsItem, 0);
               AV9IsFirstItem = false;
            }
            else
            {
               AV12DoubleMenuOptionsItem.gxTpr_Option2componenttocall = AV13ProductDataItem.gxTpr_Componenttocall;
               AV12DoubleMenuOptionsItem.gxTpr_Option2id = AV13ProductDataItem.gxTpr_Id;
               AV12DoubleMenuOptionsItem.gxTpr_Option2image = AV13ProductDataItem.gxTpr_Image;
               AV12DoubleMenuOptionsItem.gxTpr_Option2image_gxi = AV13ProductDataItem.gxTpr_Image_gxi;
               AV12DoubleMenuOptionsItem.gxTpr_Option2information1 = AV13ProductDataItem.gxTpr_Information1;
               AV12DoubleMenuOptionsItem.gxTpr_Option2information2 = AV13ProductDataItem.gxTpr_Information2;
               AV12DoubleMenuOptionsItem.gxTpr_Option2subtitle = AV13ProductDataItem.gxTpr_Subtitle;
               AV12DoubleMenuOptionsItem.gxTpr_Option2title = AV13ProductDataItem.gxTpr_Title;
               AV9IsFirstItem = true;
            }
            AV15GXV1 = (int)(AV15GXV1+1);
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         GXSoapHTTPRequest = new GxSoapRequest(context) ;
         GXSoapXMLReader = new GXXMLReader(context.GetPhysicalPath());
         GXSoapHTTPResponse = new GxHttpResponse(context) ;
         GXSoapXMLWriter = new GXXMLWriter(context.GetPhysicalPath());
         currSoapErrmsg = "";
         currMethod = "";
         sTagName = "";
         AV8ProductData = new GeneXus.Programs.workwithplus.nativemobile.SdtWWPProductData(context);
         AV12DoubleMenuOptionsItem = new GeneXus.Programs.workwithplus.nativemobile.SdtDoubleItemListData_DoubleItemListDataItem(context);
         AV13ProductDataItem = new GeneXus.Programs.workwithplus.nativemobile.SdtWWPProductData(context);
         /* GeneXus formulas. */
      }

      private short GXSoapError ;
      private short currSoapErr ;
      private short readOk ;
      private short nOutParmCount ;
      private int AV15GXV1 ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private bool AV9IsFirstItem ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtWWPProductData> AV14ProductDataList ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtDoubleItemListData_DoubleItemListDataItem> AV11DoubleMenuOptions ;
      private GeneXus.Programs.workwithplus.nativemobile.SdtWWPProductData AV8ProductData ;
      private GeneXus.Programs.workwithplus.nativemobile.SdtDoubleItemListData_DoubleItemListDataItem AV12DoubleMenuOptionsItem ;
      private GeneXus.Programs.workwithplus.nativemobile.SdtWWPProductData AV13ProductDataItem ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.nativemobile.SdtDoubleItemListData_DoubleItemListDataItem> aP1_DoubleMenuOptions ;
   }

}
