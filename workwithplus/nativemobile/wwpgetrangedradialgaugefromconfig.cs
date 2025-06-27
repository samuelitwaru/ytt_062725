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
   public class wwpgetrangedradialgaugefromconfig : GXWebProcedure
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
            return "wwpgetrangedradialgaugefromconfig_Services_Execute" ;
         }

      }

      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
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
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPGetRangedRadialGaugeFromConfig");
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
               GXSoapXMLWriter.WriteAttribute("name", "RangedRadialGaugeConfig");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Value");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:short");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Text");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Width");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:short");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Height");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:short");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Range1ColorStart");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Range1ColorEnd");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Range2ColorStart");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Range2ColorEnd");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Range3ColorStart");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Range3ColorEnd");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Range4ColorStart");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Range4ColorEnd");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Range5ColorStart");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Range5ColorEnd");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "ValueMarkerColor");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPGetRangedRadialGaugeFromConfig.Execute");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Gaugeconfig");
               GXSoapXMLWriter.WriteAttribute("type", "tns:RangedRadialGaugeConfig");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPGetRangedRadialGaugeFromConfig.ExecuteResponse");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Html");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPGetRangedRadialGaugeFromConfig.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WorkWithPlus.NativeMobile.WWPGetRangedRadialGaugeFromConfig.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPGetRangedRadialGaugeFromConfig.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:WorkWithPlus.NativeMobile.WWPGetRangedRadialGaugeFromConfig.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPGetRangedRadialGaugeFromConfigSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WorkWithPlus.NativeMobile.WWPGetRangedRadialGaugeFromConfig.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"WorkWithPlus.NativeMobile.WWPGetRangedRadialGaugeFromConfig.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPGetRangedRadialGaugeFromConfigSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"WorkWithPlus.NativeMobile.WWPGetRangedRadialGaugeFromConfigSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "YTT_version4action/"+"workwithplus.nativemobile.AWWPGETRANGEDRADIALGAUGEFROMCONFIG.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPGetRangedRadialGaugeFromConfig");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "WorkWithPlus.NativeMobile.WWPGetRangedRadialGaugeFromConfigSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"WorkWithPlus.NativeMobile.WWPGetRangedRadialGaugeFromConfigSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "http://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"workwithplus.nativemobile.wwpgetrangedradialgaugefromconfig.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "http://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "workwithplus.nativemobile.wwpgetrangedradialgaugefromconfig.aspx" + "?wsdl to get the WSDL.";
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
                        AV9GaugeConfig = new GeneXus.Programs.workwithplus.nativemobile.SdtRangedRadialGaugeConfig(context);
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
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Gaugeconfig") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "YTT_version4") == 0 ) )
                              {
                                 if ( AV9GaugeConfig == null )
                                 {
                                    AV9GaugeConfig = new GeneXus.Programs.workwithplus.nativemobile.SdtRangedRadialGaugeConfig(context);
                                 }
                                 AV9GaugeConfig.SetPrefixes( GetPrefixesInContext(), GXSoapXMLReader);
                                 GXSoapError = AV9GaugeConfig.readxml(GXSoapXMLReader, "Gaugeconfig");
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
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
            GXSoapXMLWriter.WriteStartElement("WorkWithPlus.NativeMobile.WWPGetRangedRadialGaugeFromConfig.ExecuteResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "YTT_version4");
            if ( currSoapErr == 0 )
            {
               GXSoapXMLWriter.WriteElement("Html", AV8HTML);
               GXSoapXMLWriter.WriteAttribute("xmlns", "YTT_version4");
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

      public wwpgetrangedradialgaugefromconfig( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwpgetrangedradialgaugefromconfig( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.workwithplus.nativemobile.SdtRangedRadialGaugeConfig aP0_GaugeConfig ,
                           out string aP1_HTML )
      {
         this.AV9GaugeConfig = aP0_GaugeConfig;
         this.AV8HTML = "" ;
         initialize();
         ExecuteImpl();
         aP1_HTML=this.AV8HTML;
      }

      public string executeUdp( GeneXus.Programs.workwithplus.nativemobile.SdtRangedRadialGaugeConfig aP0_GaugeConfig )
      {
         execute(aP0_GaugeConfig, out aP1_HTML);
         return AV8HTML ;
      }

      public void executeSubmit( GeneXus.Programs.workwithplus.nativemobile.SdtRangedRadialGaugeConfig aP0_GaugeConfig ,
                                 out string aP1_HTML )
      {
         this.AV9GaugeConfig = aP0_GaugeConfig;
         this.AV8HTML = "" ;
         SubmitImpl();
         aP1_HTML=this.AV8HTML;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8HTML = "<meta name=\"viewport\" content= \"width=device-width, user-scalable=no\"><style>text{font-size:40px;font-family:Arial,Helvetica,sans-serif;fill:black}div{text-align:center}#valuePoint{stroke:white;fill:%valuecolor%;stroke-width:10px}g{stroke-width:15}</style>";
         AV8HTML += "<div><svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\" width=\"%width%\" height=\"%height%\" viewBox=\"-20 -20 240 240\"> <defs> <linearGradient id=\"firstSection\" gradientUnits=\"objectBoundingBox\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"> <stop offset=\"0%\" stop-color=\"%firstColorStart%\"/> <stop offset=\"100%\" stop-color=\"%firstColorEnd%\"/> </linearGradient> <linearGradient id=\"secondSection\" gradientUnits=\"objectBoundingBox\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"> <stop offset=\"0%\" stop-color=\"%secondColorStart%\"/> <stop offset=\"100%\" stop-color=\"%secondColorEnd%\"/> </linearGradient> <linearGradient id=\"thirdSection\" gradientUnits=\"objectBoundingBox\" x1=\"1\" y1=\"0\" x2=\"0\" y2=\"1\"> <stop offset=\"0%\" stop-color=\"%thirdColorStart%\"/> <stop offset=\"100%\" stop-color=\"%thirdColorEnd%\"/> </linearGradient> <linearGradient id=\"fourthSection\" gradientUnits=\"objectBoundingBox\" x1=\"1\" y1=\"1\" x2=\"0\" y2=\"0\"> <stop offset=\"0%\" stop-color=\"%fourthColorStart%\"/> <stop offset=\"100%\" stop-color=\"%fourthColorEnd%\"/> </linearGradient> <linearGradient id=\"fiveSection\" gradientUnits=\"objectBoundingBox\" x1=\"0\" y1=\"1\" x2=\"0\" y2=\"0\"> <stop offset=\"0%\" stop-color=\"%fiveColorStart%\"/> <stop offset=\"100%\" stop-color=\"%fiveColorEnd%\"/> </linearGradient> </defs><g fill=\"none\" transform=\"translate(100,100), rotate(210)\"> <path d=\"M 0,-100 A 100,100 0 0,1 86.6,-50\" stroke=\"url(#firstSection)\" style=\"stroke-linecap: round;\"/> <path d=\"M 86.6,-50 A 100,100 0 0,1 86.6,50\" stroke=\"url(#secondSection)\"/> <path d=\"M 86.6,50 A 100,100 0 0,1 0,100\" stroke=\"url(#thirdSection)\"/> <path d=\"M 0,100 A 100,100 0 0,1 -86.6,50\" stroke=\"url(#fourthSection)\"/> <path d=\"M -86.6,50 A 100,100 0 0,1 -86.6,-50\" stroke=\"url(#fiveSection)\" style=\"stroke-linecap: round;\"/> </g> <circle id=\"valuePoint\" cx=\"170\" cy=\"170\" r=\"20\" /> <text x=\"100\" y=\"100\" dominant-baseline=\"middle\" text-anchor=\"middle\">%text%</text> </svg></div>";
         AV8HTML += "<script>var degrees=%degrees%+90;var radians=degrees_to_radians(degrees);var radius=100;var x=Math.cos(radians)*radius+100;var y=Math.sin(radians)*radius+100;setPosition(\"valuePoint\",x,y);function setPosition(id,x,y){var ctrl=document.getElementById(id);ctrl.setAttribute(\"cx\",x);ctrl.setAttribute(\"cy\",y);} function degrees_to_radians(degrees) {var pi=Math.PI;return degrees*(pi/180);}</script>";
         AV10propertyName = "height";
         AV11propertyValue = StringUtil.Str( (decimal)(AV9GaugeConfig.gxTpr_Height), 4, 0);
         /* Execute user subroutine: 'REPLACETEMPLATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV10propertyName = "width";
         AV11propertyValue = StringUtil.Str( (decimal)(AV9GaugeConfig.gxTpr_Width), 4, 0);
         /* Execute user subroutine: 'REPLACETEMPLATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV10propertyName = "degrees";
         AV12ValueNumeric = (int)(AV9GaugeConfig.gxTpr_Value*3+30);
         AV11propertyValue = StringUtil.Str( (decimal)(AV12ValueNumeric), 6, 0);
         /* Execute user subroutine: 'REPLACETEMPLATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV10propertyName = "valuecolor";
         AV11propertyValue = "blue";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV9GaugeConfig.gxTpr_Valuemarkercolor))) )
         {
            AV11propertyValue = AV9GaugeConfig.gxTpr_Valuemarkercolor;
         }
         /* Execute user subroutine: 'REPLACETEMPLATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV10propertyName = "text";
         AV11propertyValue = AV9GaugeConfig.gxTpr_Text;
         /* Execute user subroutine: 'REPLACETEMPLATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV10propertyName = "firstColorStart";
         AV11propertyValue = AV9GaugeConfig.gxTpr_Range1colorstart;
         /* Execute user subroutine: 'REPLACETEMPLATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV10propertyName = "firstColorEnd";
         AV11propertyValue = AV9GaugeConfig.gxTpr_Range1colorend;
         /* Execute user subroutine: 'REPLACETEMPLATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV10propertyName = "secondColorStart";
         AV11propertyValue = AV9GaugeConfig.gxTpr_Range2colorstart;
         /* Execute user subroutine: 'REPLACETEMPLATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV10propertyName = "secondColorEnd";
         AV11propertyValue = AV9GaugeConfig.gxTpr_Range2colorend;
         /* Execute user subroutine: 'REPLACETEMPLATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV10propertyName = "thirdColorStart";
         AV11propertyValue = AV9GaugeConfig.gxTpr_Range3colorstart;
         /* Execute user subroutine: 'REPLACETEMPLATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV10propertyName = "thirdColorEnd";
         AV11propertyValue = AV9GaugeConfig.gxTpr_Range3colorend;
         /* Execute user subroutine: 'REPLACETEMPLATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV10propertyName = "fourthColorStart";
         AV11propertyValue = AV9GaugeConfig.gxTpr_Range4colorstart;
         /* Execute user subroutine: 'REPLACETEMPLATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV10propertyName = "fourthColorEnd";
         AV11propertyValue = AV9GaugeConfig.gxTpr_Range4colorend;
         /* Execute user subroutine: 'REPLACETEMPLATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV10propertyName = "fiveColorStart";
         AV11propertyValue = AV9GaugeConfig.gxTpr_Range5colorstart;
         /* Execute user subroutine: 'REPLACETEMPLATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV10propertyName = "fiveColorEnd";
         AV11propertyValue = AV9GaugeConfig.gxTpr_Range5colorend;
         /* Execute user subroutine: 'REPLACETEMPLATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'REPLACETEMPLATE' Routine */
         returnInSub = false;
         AV8HTML = StringUtil.StringReplace( AV8HTML, "%"+StringUtil.Trim( AV10propertyName)+"%", StringUtil.Trim( AV11propertyValue));
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

      public override void initialize( )
      {
         GXSoapHTTPRequest = new GxSoapRequest(context) ;
         GXSoapXMLReader = new GXXMLReader(context.GetPhysicalPath());
         GXSoapHTTPResponse = new GxHttpResponse(context) ;
         GXSoapXMLWriter = new GXXMLWriter(context.GetPhysicalPath());
         currSoapErrmsg = "";
         currMethod = "";
         sTagName = "";
         AV10propertyName = "";
         AV11propertyValue = "";
         /* GeneXus formulas. */
      }

      private short GXSoapError ;
      private short currSoapErr ;
      private short readOk ;
      private short nOutParmCount ;
      private int AV12ValueNumeric ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private bool returnInSub ;
      private string AV8HTML ;
      private string AV10propertyName ;
      private string AV11propertyValue ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private GeneXus.Programs.workwithplus.nativemobile.SdtRangedRadialGaugeConfig AV9GaugeConfig ;
      private string aP1_HTML ;
   }

}
