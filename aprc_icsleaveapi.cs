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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aprc_icsleaveapi : GXWebProcedure
   {
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
               GXSoapXMLWriter.WriteAttribute("name", "Prc_ICSLeaveAPI");
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
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Prc_ICSLeaveAPI.Execute");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "Prc_ICSLeaveAPI.ExecuteResponse");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Icsleaveexport");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "Prc_ICSLeaveAPI.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:Prc_ICSLeaveAPI.Execute");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "Prc_ICSLeaveAPI.ExecuteSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:Prc_ICSLeaveAPI.ExecuteResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "Prc_ICSLeaveAPISoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"Prc_ICSLeaveAPI.ExecuteSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"Prc_ICSLeaveAPI.ExecuteSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "Prc_ICSLeaveAPISoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"Prc_ICSLeaveAPISoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "Execute");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "YTT_version4action/"+"APRC_ICSLEAVEAPI.Execute");
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
               GXSoapXMLWriter.WriteAttribute("name", "Prc_ICSLeaveAPI");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "Prc_ICSLeaveAPISoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"Prc_ICSLeaveAPISoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "http://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"aprc_icsleaveapi.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "http://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "aprc_icsleaveapi.aspx" + "?wsdl to get the WSDL.";
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
            GXSoapXMLWriter.WriteStartElement("Prc_ICSLeaveAPI.ExecuteResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "YTT_version4");
            if ( currSoapErr == 0 )
            {
               GXSoapXMLWriter.WriteElement("Icsleaveexport", AV8ICSLeaveExport);
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

      public aprc_icsleaveapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_icsleaveapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_ICSLeaveExport )
      {
         this.AV8ICSLeaveExport = "" ;
         initialize();
         ExecuteImpl();
         aP0_ICSLeaveExport=this.AV8ICSLeaveExport;
      }

      public string executeUdp( )
      {
         execute(out aP0_ICSLeaveExport);
         return AV8ICSLeaveExport ;
      }

      public void executeSubmit( out string aP0_ICSLeaveExport )
      {
         this.AV8ICSLeaveExport = "" ;
         SubmitImpl();
         aP0_ICSLeaveExport=this.AV8ICSLeaveExport;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV17AuthorizationValue = StringUtil.FromBase64( StringUtil.StringReplace( AV16httprequest.GetHeader("Authorization"), "Basic ", ""));
         AV21CredsCollection = (GxSimpleCollection<string>)(GxRegex.Split(AV17AuthorizationValue,":"));
         AV14EmployeeEmail = ((string)AV21CredsCollection.Item(1));
         AV15EmployeeAPIPassword = ((string)AV21CredsCollection.Item(2));
         AV29GXLvl7 = 0;
         /* Using cursor P00B92 */
         pr_default.execute(0, new Object[] {AV14EmployeeEmail, AV15EmployeeAPIPassword});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00B92_A106EmployeeId[0];
            A148EmployeeName = P00B92_A148EmployeeName[0];
            A187EmployeeAPIPassword = P00B92_A187EmployeeAPIPassword[0];
            A109EmployeeEmail = P00B92_A109EmployeeEmail[0];
            AV29GXLvl7 = 1;
            AV8ICSLeaveExport = "";
            AV8ICSLeaveExport += "BEGIN:VCALENDAR" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "PRODID:-//Yukon Software//APiCalConverter//EN" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "VERSION:2.0" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "CALSCALE:GREGORIAN" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "BEGIN:VTIMEZONE" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZID:EET" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "LAST-MODIFIED:20240422T053450Z" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZURL:https://www.tzurl.org/zoneinfo/EET" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "X-LIC-LOCATION:EET" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "X-PROLEPTIC-TZNAME;X-NO-BIG-BANG=TRUE:EET" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "BEGIN:DAYLIGHT" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZNAME:EEST" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETFROM:+0200" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETTO:+0300" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "DTSTART:19770403T030000" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "RRULE:FREQ=YEARLY;UNTIL=19800406T010000Z;BYMONTH=4;BYDAY=1SU" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "END:DAYLIGHT" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "BEGIN:STANDARD" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZNAME:EET" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETFROM:+0300" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETTO:+0200" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "DTSTART:19770925T040000" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "RDATE:19781001T040000" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "END:STANDARD" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "BEGIN:STANDARD" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZNAME:EET" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETFROM:+0300" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETTO:+0200" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "DTSTART:19790930T040000" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "RRULE:FREQ=YEARLY;UNTIL=19950924T010000Z;BYMONTH=9;BYDAY=-1SU" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "END:STANDARD" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "BEGIN:DAYLIGHT" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZNAME:EEST" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETFROM:+0200" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETTO:+0300" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "DTSTART:19810329T030000" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "RRULE:FREQ=YEARLY;BYMONTH=3;BYDAY=-1SU" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "END:DAYLIGHT" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "BEGIN:STANDARD" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZNAME:EET" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETFROM:+0300" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "TZOFFSETTO:+0200" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "DTSTART:19961027T040000" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "RRULE:FREQ=YEARLY;BYMONTH=10;BYDAY=-1SU" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "END:STANDARD" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "END:VTIMEZONE" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "X-WR-TIMEZONE:Europe/Bucharest" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "X-WR-CALNAME:Absence" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "X-WR-CALDESC:" + StringUtil.NewLine( );
            AV8ICSLeaveExport += "METHOD:PUBLISH" + StringUtil.NewLine( );
            /* Using cursor P00B93 */
            pr_default.execute(1, new Object[] {A106EmployeeId, A109EmployeeEmail, AV14EmployeeEmail});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A124LeaveTypeId = P00B93_A124LeaveTypeId[0];
               A128LeaveRequestDate = P00B93_A128LeaveRequestDate[0];
               A129LeaveRequestStartDate = P00B93_A129LeaveRequestStartDate[0];
               A130LeaveRequestEndDate = P00B93_A130LeaveRequestEndDate[0];
               A125LeaveTypeName = P00B93_A125LeaveTypeName[0];
               A127LeaveRequestId = P00B93_A127LeaveRequestId[0];
               A125LeaveTypeName = P00B93_A125LeaveTypeName[0];
               AV8ICSLeaveExport += "BEGIN:VEVENT" + StringUtil.NewLine( );
               GXt_char1 = AV8ICSLeaveExport;
               new formatdatetime(context ).execute(  A128LeaveRequestDate,  "YYYYMMDD", out  GXt_char1) ;
               AV8ICSLeaveExport += "DTSTAMP:" + GXt_char1 + "T000000Z" + StringUtil.NewLine( );
               GXt_char1 = AV8ICSLeaveExport;
               new formatdatetime(context ).execute(  A129LeaveRequestStartDate,  "YYYYMMDD", out  GXt_char1) ;
               AV8ICSLeaveExport += "DTSTART;VALUE=DATE:" + GXt_char1 + StringUtil.NewLine( );
               GXt_char1 = AV8ICSLeaveExport;
               new formatdatetime(context ).execute(  A130LeaveRequestEndDate,  "YYYYMMDD", out  GXt_char1) ;
               AV8ICSLeaveExport += "DTEND;VALUE=DATE:" + GXt_char1 + StringUtil.NewLine( );
               AV8ICSLeaveExport += "SUMMARY:" + StringUtil.Trim( A148EmployeeName) + " | " + StringUtil.Trim( A125LeaveTypeName) + StringUtil.NewLine( );
               AV8ICSLeaveExport += "UID:" + StringUtil.Trim( StringUtil.Str( (decimal)(A127LeaveRequestId), 10, 0)) + StringUtil.Trim( A109EmployeeEmail) + StringUtil.NewLine( );
               AV8ICSLeaveExport += "END:VEVENT" + StringUtil.NewLine( );
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV8ICSLeaveExport += "END:VCALENDAR" + StringUtil.NewLine( );
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV29GXLvl7 == 0 )
         {
            AV27ErrorMessage = "Employee not found";
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

      public override void initialize( )
      {
         GXSoapHTTPRequest = new GxSoapRequest(context) ;
         GXSoapXMLReader = new GXXMLReader(context.GetPhysicalPath());
         GXSoapHTTPResponse = new GxHttpResponse(context) ;
         GXSoapXMLWriter = new GXXMLWriter(context.GetPhysicalPath());
         currSoapErrmsg = "";
         currMethod = "";
         AV17AuthorizationValue = "";
         AV16httprequest = new GxSoapRequest( context);
         AV21CredsCollection = new GxSimpleCollection<string>();
         AV14EmployeeEmail = "";
         AV15EmployeeAPIPassword = "";
         P00B92_A106EmployeeId = new long[1] ;
         P00B92_A148EmployeeName = new string[] {""} ;
         P00B92_A187EmployeeAPIPassword = new string[] {""} ;
         P00B92_A109EmployeeEmail = new string[] {""} ;
         A148EmployeeName = "";
         A187EmployeeAPIPassword = "";
         A109EmployeeEmail = "";
         P00B93_A124LeaveTypeId = new long[1] ;
         P00B93_A106EmployeeId = new long[1] ;
         P00B93_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         P00B93_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00B93_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00B93_A125LeaveTypeName = new string[] {""} ;
         P00B93_A127LeaveRequestId = new long[1] ;
         A128LeaveRequestDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A125LeaveTypeName = "";
         GXt_char1 = "";
         AV27ErrorMessage = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_icsleaveapi__default(),
            new Object[][] {
                new Object[] {
               P00B92_A106EmployeeId, P00B92_A148EmployeeName, P00B92_A187EmployeeAPIPassword, P00B92_A109EmployeeEmail
               }
               , new Object[] {
               P00B93_A124LeaveTypeId, P00B93_A106EmployeeId, P00B93_A128LeaveRequestDate, P00B93_A129LeaveRequestStartDate, P00B93_A130LeaveRequestEndDate, P00B93_A125LeaveTypeName, P00B93_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXSoapError ;
      private short currSoapErr ;
      private short AV29GXLvl7 ;
      private long A106EmployeeId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string A148EmployeeName ;
      private string A125LeaveTypeName ;
      private string GXt_char1 ;
      private DateTime A128LeaveRequestDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool sIncludeState ;
      private string AV8ICSLeaveExport ;
      private string AV17AuthorizationValue ;
      private string AV27ErrorMessage ;
      private string AV14EmployeeEmail ;
      private string AV15EmployeeAPIPassword ;
      private string A187EmployeeAPIPassword ;
      private string A109EmployeeEmail ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxSoapRequest AV16httprequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV21CredsCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P00B92_A106EmployeeId ;
      private string[] P00B92_A148EmployeeName ;
      private string[] P00B92_A187EmployeeAPIPassword ;
      private string[] P00B92_A109EmployeeEmail ;
      private long[] P00B93_A124LeaveTypeId ;
      private long[] P00B93_A106EmployeeId ;
      private DateTime[] P00B93_A128LeaveRequestDate ;
      private DateTime[] P00B93_A129LeaveRequestStartDate ;
      private DateTime[] P00B93_A130LeaveRequestEndDate ;
      private string[] P00B93_A125LeaveTypeName ;
      private long[] P00B93_A127LeaveRequestId ;
      private string aP0_ICSLeaveExport ;
   }

   public class aprc_icsleaveapi__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00B92;
          prmP00B92 = new Object[] {
          new ParDef("AV14EmployeeEmail",GXType.VarChar,100,0) ,
          new ParDef("AV15EmployeeAPIPassword",GXType.VarChar,40,0)
          };
          Object[] prmP00B93;
          prmP00B93 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0) ,
          new ParDef("EmployeeEmail",GXType.VarChar,100,0) ,
          new ParDef("AV14EmployeeEmail",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B92", "SELECT EmployeeId, EmployeeName, EmployeeAPIPassword, EmployeeEmail FROM Employee WHERE (EmployeeEmail = ( :AV14EmployeeEmail)) AND (EmployeeAPIPassword = ( :AV15EmployeeAPIPassword)) ORDER BY EmployeeEmail ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B92,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00B93", "SELECT T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestDate, T1.LeaveRequestStartDate, T1.LeaveRequestEndDate, T2.LeaveTypeName, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :EmployeeId) AND (:EmployeeEmail = ( :AV14EmployeeEmail)) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B93,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
       }
    }

 }

}
