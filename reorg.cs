using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class reorg : GXReorganization
   {
      public reorg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public reorg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         SetCreateDataBase( ) ;
         CreateDataBase( ) ;
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void CreateDataBase( )
      {
         DS = (GxDataStore)(context.GetDataStore( "Default"));
         ErrCode = DS.Connection.FullConnect();
         DataBaseName = DS.Connection.Database;
         if ( ErrCode != 0 )
         {
            DS.Connection.Database = "postgres";
            ErrCode = DS.Connection.FullConnect();
            if ( ErrCode == 0 )
            {
               try
               {
                  GeneXus.Reorg.GXReorganization.AddMsg( GXResourceManager.GetMessage("GXM_dbcrea")+ " " +DataBaseName , null);
                  cmdBuffer = "CREATE DATABASE " + "\"" + DataBaseName + "\"";
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
                  Count = 1;
               }
               catch ( Exception ex )
               {
                  ErrCode = 1;
                  GeneXus.Reorg.GXReorganization.AddMsg( ex.Message , null);
                  throw;
               }
               ErrCode = DS.Connection.Disconnect();
               DS.Connection.Database = DataBaseName;
               ErrCode = DS.Connection.FullConnect();
               while ( ( ErrCode != 0 ) && ( Count > 0 ) && ( Count < 30 ) )
               {
                  Res = GXUtil.Sleep( 1);
                  ErrCode = DS.Connection.FullConnect();
                  Count = (short)(Count+1);
               }
            }
            if ( ErrCode != 0 )
            {
               ErrMsg = DS.ErrDescription;
               GeneXus.Reorg.GXReorganization.AddMsg( ErrMsg , null);
               ErrCode = 1;
               throw new Exception( ErrMsg) ;
            }
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void CreateTrnNew( )
      {
         string cmdBuffer = "";
         /* Indices for table TrnNew */
         try
         {
            cmdBuffer=" CREATE SEQUENCE TrnNewId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE TrnNewId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE TrnNewId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE TrnNew (TrnNewId bigint NOT NULL DEFAULT nextval('TrnNewId'), TrnNewName CHAR(100) NOT NULL , TrnNewDate date NOT NULL , TrnNewImage BYTEA NOT NULL , TrnNewImage_GXI VARCHAR(2048) , PRIMARY KEY(TrnNewId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE TrnNew CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW TrnNew CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION TrnNew CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE TrnNew (TrnNewId bigint NOT NULL DEFAULT nextval('TrnNewId'), TrnNewName CHAR(100) NOT NULL , TrnNewDate date NOT NULL , TrnNewImage BYTEA NOT NULL , TrnNewImage_GXI VARCHAR(2048) , PRIMARY KEY(TrnNewId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEmployeeVacationSet( )
      {
         string cmdBuffer = "";
         /* Indices for table EmployeeVacationSet */
         try
         {
            cmdBuffer=" CREATE TABLE EmployeeVacationSet (EmployeeId bigint NOT NULL , VacationSetDate date NOT NULL , VacationSetDays NUMERIC(3,1) NOT NULL , VacationSetDescription VARCHAR(200) , PRIMARY KEY(EmployeeId, VacationSetDate))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE EmployeeVacationSet CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW EmployeeVacationSet CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION EmployeeVacationSet CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE EmployeeVacationSet (EmployeeId bigint NOT NULL , VacationSetDate date NOT NULL , VacationSetDays NUMERIC(3,1) NOT NULL , VacationSetDescription VARCHAR(200) , PRIMARY KEY(EmployeeId, VacationSetDate))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSupportRequest( )
      {
         string cmdBuffer = "";
         /* Indices for table SupportRequest */
         try
         {
            cmdBuffer=" CREATE SEQUENCE SupportRequestId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE SupportRequestId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE SupportRequestId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE SupportRequest (SupportRequestId bigint NOT NULL DEFAULT nextval('SupportRequestId'), SupportRequestSubject VARCHAR(201) NOT NULL , SupportRequestDescription VARCHAR(200) NOT NULL , EmployeeId bigint NOT NULL , PRIMARY KEY(SupportRequestId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE SupportRequest CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW SupportRequest CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION SupportRequest CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE SupportRequest (SupportRequestId bigint NOT NULL DEFAULT nextval('SupportRequestId'), SupportRequestSubject VARCHAR(201) NOT NULL , SupportRequestDescription VARCHAR(200) NOT NULL , EmployeeId bigint NOT NULL , PRIMARY KEY(SupportRequestId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISUPPORTREQUEST1 ON SupportRequest (EmployeeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISUPPORTREQUEST1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISUPPORTREQUEST1 ON SupportRequest (EmployeeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSiteSetting( )
      {
         string cmdBuffer = "";
         /* Indices for table SiteSetting */
         try
         {
            cmdBuffer=" CREATE SEQUENCE SiteSettingId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE SiteSettingId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE SiteSettingId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE SiteSetting (SiteSettingId bigint NOT NULL DEFAULT nextval('SiteSettingId'), CompanyId bigint NOT NULL , IsLogHourOpen BOOLEAN NOT NULL , PRIMARY KEY(SiteSettingId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE SiteSetting CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW SiteSetting CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION SiteSetting CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE SiteSetting (SiteSettingId bigint NOT NULL DEFAULT nextval('SiteSettingId'), CompanyId bigint NOT NULL , IsLogHourOpen BOOLEAN NOT NULL , PRIMARY KEY(SiteSettingId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ISITESETTING1 ON SiteSetting (CompanyId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ISITESETTING1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ISITESETTING1 ON SiteSetting (CompanyId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCompanyLocation( )
      {
         string cmdBuffer = "";
         /* Indices for table CompanyLocation */
         try
         {
            cmdBuffer=" CREATE SEQUENCE CompanyLocationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE CompanyLocationId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE CompanyLocationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE CompanyLocation (CompanyLocationId bigint NOT NULL DEFAULT nextval('CompanyLocationId'), CompanyLocationName CHAR(100) NOT NULL , CompanyLocationCode CHAR(20) NOT NULL , PRIMARY KEY(CompanyLocationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE CompanyLocation CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW CompanyLocation CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION CompanyLocation CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE CompanyLocation (CompanyLocationId bigint NOT NULL DEFAULT nextval('CompanyLocationId'), CompanyLocationName CHAR(100) NOT NULL , CompanyLocationCode CHAR(20) NOT NULL , PRIMARY KEY(CompanyLocationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE INDEX UCOMPANYLOCATION ON CompanyLocation (CompanyLocationName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UCOMPANYLOCATION "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE INDEX UCOMPANYLOCATION ON CompanyLocation (CompanyLocationName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateDevice( )
      {
         string cmdBuffer = "";
         /* Indices for table Device */
         try
         {
            cmdBuffer=" CREATE TABLE Device (DeviceId CHAR(128) NOT NULL , DeviceType smallint NOT NULL , DeviceToken CHAR(1000) NOT NULL , DeviceName CHAR(100) NOT NULL , DeviceUser VARCHAR(100) , PRIMARY KEY(DeviceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Device CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Device CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Device CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Device (DeviceId CHAR(128) NOT NULL , DeviceType smallint NOT NULL , DeviceToken CHAR(1000) NOT NULL , DeviceName CHAR(100) NOT NULL , DeviceUser VARCHAR(100) , PRIMARY KEY(DeviceId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateLeaveRequest( )
      {
         string cmdBuffer = "";
         /* Indices for table LeaveRequest */
         try
         {
            cmdBuffer=" CREATE SEQUENCE LeaveRequestId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE LeaveRequestId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE LeaveRequestId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE LeaveRequest (LeaveRequestId bigint NOT NULL DEFAULT nextval('LeaveRequestId'), LeaveTypeId bigint NOT NULL , LeaveRequestDate date NOT NULL , LeaveRequestStartDate date NOT NULL , LeaveRequestEndDate date NOT NULL , LeaveRequestDuration NUMERIC(3,1) NOT NULL , LeaveRequestStatus CHAR(20) NOT NULL , LeaveRequestDescription VARCHAR(200) NOT NULL , LeaveRequestRejectionReason VARCHAR(200) NOT NULL , EmployeeId bigint NOT NULL , LeaveRequestHalfDay CHAR(20) , PRIMARY KEY(LeaveRequestId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE LeaveRequest CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW LeaveRequest CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION LeaveRequest CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE LeaveRequest (LeaveRequestId bigint NOT NULL DEFAULT nextval('LeaveRequestId'), LeaveTypeId bigint NOT NULL , LeaveRequestDate date NOT NULL , LeaveRequestStartDate date NOT NULL , LeaveRequestEndDate date NOT NULL , LeaveRequestDuration NUMERIC(3,1) NOT NULL , LeaveRequestStatus CHAR(20) NOT NULL , LeaveRequestDescription VARCHAR(200) NOT NULL , LeaveRequestRejectionReason VARCHAR(200) NOT NULL , EmployeeId bigint NOT NULL , LeaveRequestHalfDay CHAR(20) , PRIMARY KEY(LeaveRequestId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ILEAVEREQUEST1 ON LeaveRequest (EmployeeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ILEAVEREQUEST1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ILEAVEREQUEST1 ON LeaveRequest (EmployeeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ILEAVEREQUEST2 ON LeaveRequest (LeaveTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ILEAVEREQUEST2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ILEAVEREQUEST2 ON LeaveRequest (LeaveTypeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateLeaveType( )
      {
         string cmdBuffer = "";
         /* Indices for table LeaveType */
         try
         {
            cmdBuffer=" CREATE SEQUENCE LeaveTypeId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE LeaveTypeId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE LeaveTypeId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE LeaveType (LeaveTypeId bigint NOT NULL DEFAULT nextval('LeaveTypeId'), LeaveTypeName CHAR(100) NOT NULL , CompanyId bigint NOT NULL , LeaveTypeVacationLeave CHAR(20) NOT NULL , LeaveTypeLoggingWorkHours CHAR(20) NOT NULL , LeaveTypeColorPending CHAR(20) , LeaveTypeColorApproved CHAR(20) , PRIMARY KEY(LeaveTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE LeaveType CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW LeaveType CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION LeaveType CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE LeaveType (LeaveTypeId bigint NOT NULL DEFAULT nextval('LeaveTypeId'), LeaveTypeName CHAR(100) NOT NULL , CompanyId bigint NOT NULL , LeaveTypeVacationLeave CHAR(20) NOT NULL , LeaveTypeLoggingWorkHours CHAR(20) NOT NULL , LeaveTypeColorPending CHAR(20) , LeaveTypeColorApproved CHAR(20) , PRIMARY KEY(LeaveTypeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ILEAVETYPE1 ON LeaveType (CompanyId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ILEAVETYPE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ILEAVETYPE1 ON LeaveType (CompanyId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWorkHourLog( )
      {
         string cmdBuffer = "";
         /* Indices for table WorkHourLog */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WorkHourLogId MINVALUE 10000 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WorkHourLogId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WorkHourLogId MINVALUE 10000 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WorkHourLog (WorkHourLogId bigint NOT NULL DEFAULT nextval('WorkHourLogId'), WorkHourLogDate date NOT NULL , WorkHourLogDuration VARCHAR(40) NOT NULL , WorkHourLogHour smallint NOT NULL , WorkHourLogMinute smallint NOT NULL , WorkHourLogDescription TEXT NOT NULL , EmployeeId bigint NOT NULL , ProjectId bigint NOT NULL , PRIMARY KEY(WorkHourLogId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WorkHourLog CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WorkHourLog CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WorkHourLog CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WorkHourLog (WorkHourLogId bigint NOT NULL DEFAULT nextval('WorkHourLogId'), WorkHourLogDate date NOT NULL , WorkHourLogDuration VARCHAR(40) NOT NULL , WorkHourLogHour smallint NOT NULL , WorkHourLogMinute smallint NOT NULL , WorkHourLogDescription TEXT NOT NULL , EmployeeId bigint NOT NULL , ProjectId bigint NOT NULL , PRIMARY KEY(WorkHourLogId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWORKHOURLOG1 ON WorkHourLog (EmployeeId ,ProjectId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWORKHOURLOG1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWORKHOURLOG1 ON WorkHourLog (EmployeeId ,ProjectId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UWORKHOURLOG ON WorkHourLog (WorkHourLogDate ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UWORKHOURLOG "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UWORKHOURLOG ON WorkHourLog (WorkHourLogDate ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateHoliday( )
      {
         string cmdBuffer = "";
         /* Indices for table Holiday */
         try
         {
            cmdBuffer=" CREATE SEQUENCE HolidayId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE HolidayId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE HolidayId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Holiday (HolidayId bigint NOT NULL DEFAULT nextval('HolidayId'), HolidayName CHAR(100) NOT NULL , HolidayStartDate date NOT NULL , HolidayEndDate date , HolidayServiceId CHAR(40) , CompanyId bigint NOT NULL , HolidayIsActive BOOLEAN NOT NULL , PRIMARY KEY(HolidayId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Holiday CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Holiday CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Holiday CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Holiday (HolidayId bigint NOT NULL DEFAULT nextval('HolidayId'), HolidayName CHAR(100) NOT NULL , HolidayStartDate date NOT NULL , HolidayEndDate date , HolidayServiceId CHAR(40) , CompanyId bigint NOT NULL , HolidayIsActive BOOLEAN NOT NULL , PRIMARY KEY(HolidayId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE INDEX UHOLIDAY ON Holiday (HolidayServiceId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UHOLIDAY "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE INDEX UHOLIDAY ON Holiday (HolidayServiceId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IHOLIDAY1 ON Holiday (CompanyId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IHOLIDAY1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IHOLIDAY1 ON Holiday (CompanyId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEmployeeProject( )
      {
         string cmdBuffer = "";
         /* Indices for table EmployeeProject */
         try
         {
            cmdBuffer=" CREATE TABLE EmployeeProject (EmployeeId bigint NOT NULL , ProjectId bigint NOT NULL , EmployeeIsActiveInProject BOOLEAN NOT NULL , PRIMARY KEY(EmployeeId, ProjectId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE EmployeeProject CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW EmployeeProject CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION EmployeeProject CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE EmployeeProject (EmployeeId bigint NOT NULL , ProjectId bigint NOT NULL , EmployeeIsActiveInProject BOOLEAN NOT NULL , PRIMARY KEY(EmployeeId, ProjectId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IEMPLOYEEPROJECT1 ON EmployeeProject (ProjectId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IEMPLOYEEPROJECT1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IEMPLOYEEPROJECT1 ON EmployeeProject (ProjectId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEmployee( )
      {
         string cmdBuffer = "";
         /* Indices for table Employee */
         try
         {
            cmdBuffer=" CREATE SEQUENCE EmployeeId MINVALUE 601 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE EmployeeId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE EmployeeId MINVALUE 601 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Employee (EmployeeId bigint NOT NULL DEFAULT nextval('EmployeeId'), EmployeeFirstName CHAR(100) NOT NULL , EmployeeLastName CHAR(100) NOT NULL , EmployeeEmail VARCHAR(100) NOT NULL , CompanyId bigint NOT NULL , EmployeeIsManager BOOLEAN NOT NULL , GAMUserGUID VARCHAR(100) NOT NULL , EmployeeIsActive BOOLEAN NOT NULL , EmployeeVactionDays NUMERIC(3,1) NOT NULL , EmployeeBalance NUMERIC(3,1) NOT NULL , EmployeeName CHAR(100) NOT NULL , EmployeeVacationDaysSetDate date NOT NULL , EmployeeAPIPassword VARCHAR(40) NOT NULL , EmployeeFTEHours smallint NOT NULL , PRIMARY KEY(EmployeeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Employee CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Employee CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Employee CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Employee (EmployeeId bigint NOT NULL DEFAULT nextval('EmployeeId'), EmployeeFirstName CHAR(100) NOT NULL , EmployeeLastName CHAR(100) NOT NULL , EmployeeEmail VARCHAR(100) NOT NULL , CompanyId bigint NOT NULL , EmployeeIsManager BOOLEAN NOT NULL , GAMUserGUID VARCHAR(100) NOT NULL , EmployeeIsActive BOOLEAN NOT NULL , EmployeeVactionDays NUMERIC(3,1) NOT NULL , EmployeeBalance NUMERIC(3,1) NOT NULL , EmployeeName CHAR(100) NOT NULL , EmployeeVacationDaysSetDate date NOT NULL , EmployeeAPIPassword VARCHAR(40) NOT NULL , EmployeeFTEHours smallint NOT NULL , PRIMARY KEY(EmployeeId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE INDEX UEMPLOYEE ON Employee (EmployeeEmail ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UEMPLOYEE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE INDEX UEMPLOYEE ON Employee (EmployeeEmail ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IEMPLOYEE1 ON Employee (CompanyId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IEMPLOYEE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IEMPLOYEE1 ON Employee (CompanyId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX UEMPLOYEE1 ON Employee (EmployeeName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UEMPLOYEE1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UEMPLOYEE1 ON Employee (EmployeeName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateProject( )
      {
         string cmdBuffer = "";
         /* Indices for table Project */
         try
         {
            cmdBuffer=" CREATE SEQUENCE ProjectId MINVALUE 172 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE ProjectId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE ProjectId MINVALUE 172 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Project (ProjectId bigint NOT NULL DEFAULT nextval('ProjectId'), ProjectName CHAR(100) NOT NULL , ProjectDescription VARCHAR(200) NOT NULL , ProjectStatus CHAR(20) NOT NULL , ProjectManagerId bigint , PRIMARY KEY(ProjectId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Project CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Project CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Project CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Project (ProjectId bigint NOT NULL DEFAULT nextval('ProjectId'), ProjectName CHAR(100) NOT NULL , ProjectDescription VARCHAR(200) NOT NULL , ProjectStatus CHAR(20) NOT NULL , ProjectManagerId bigint , PRIMARY KEY(ProjectId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE INDEX UPROJECT ON Project (ProjectName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UPROJECT "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE INDEX UPROJECT ON Project (ProjectName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IPROJECT1 ON Project (ProjectManagerId ,ProjectId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IPROJECT1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IPROJECT1 ON Project (ProjectManagerId ,ProjectId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCompany( )
      {
         string cmdBuffer = "";
         /* Indices for table Company */
         try
         {
            cmdBuffer=" CREATE SEQUENCE CompanyId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE CompanyId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE CompanyId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE Company (CompanyId bigint NOT NULL DEFAULT nextval('CompanyId'), CompanyName CHAR(100) NOT NULL , CompanyLocationId bigint NOT NULL , PRIMARY KEY(CompanyId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE Company CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW Company CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION Company CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE Company (CompanyId bigint NOT NULL DEFAULT nextval('CompanyId'), CompanyName CHAR(100) NOT NULL , CompanyLocationId bigint NOT NULL , PRIMARY KEY(CompanyId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE INDEX UCOMPANY ON Company (CompanyName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UCOMPANY "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE INDEX UCOMPANY ON Company (CompanyName ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ICOMPANY1 ON Company (CompanyLocationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ICOMPANY1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ICOMPANY1 ON Company (CompanyLocationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateUserCustomizations( )
      {
         string cmdBuffer = "";
         /* Indices for table UserCustomizations */
         try
         {
            cmdBuffer=" CREATE TABLE UserCustomizations (UserCustomizationsId CHAR(40) NOT NULL , UserCustomizationsKey VARCHAR(200) NOT NULL , UserCustomizationsValue TEXT NOT NULL , PRIMARY KEY(UserCustomizationsId, UserCustomizationsKey))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE UserCustomizations CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW UserCustomizations CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION UserCustomizations CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE UserCustomizations (UserCustomizationsId CHAR(40) NOT NULL , UserCustomizationsKey VARCHAR(200) NOT NULL , UserCustomizationsValue TEXT NOT NULL , PRIMARY KEY(UserCustomizationsId, UserCustomizationsKey))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_MailAttachments( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_MailAttachments */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_MailAttachments (WWPMailId bigint NOT NULL , WWPMailAttachmentName VARCHAR(40) NOT NULL , WWPMailAttachmentFile TEXT NOT NULL , PRIMARY KEY(WWPMailId, WWPMailAttachmentName))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_MailAttachments CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_MailAttachments CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_MailAttachments CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_MailAttachments (WWPMailId bigint NOT NULL , WWPMailAttachmentName VARCHAR(40) NOT NULL , WWPMailAttachmentFile TEXT NOT NULL , PRIMARY KEY(WWPMailId, WWPMailAttachmentName))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Mail( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Mail */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPMailId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPMailId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPMailId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Mail (WWPMailId bigint NOT NULL DEFAULT nextval('WWPMailId'), WWPMailSubject VARCHAR(80) NOT NULL , WWPMailBody TEXT NOT NULL , WWPMailTo TEXT , WWPMailCC TEXT , WWPMailBCC TEXT , WWPMailSenderAddress TEXT NOT NULL , WWPMailSenderName TEXT NOT NULL , WWPMailStatus smallint NOT NULL , WWPMailCreated timestamp without time zone NOT NULL , WWPMailScheduled timestamp without time zone NOT NULL , WWPMailProcessed timestamp without time zone , WWPMailDetail TEXT , WWPNotificationId bigint , PRIMARY KEY(WWPMailId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Mail CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Mail CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Mail CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Mail (WWPMailId bigint NOT NULL DEFAULT nextval('WWPMailId'), WWPMailSubject VARCHAR(80) NOT NULL , WWPMailBody TEXT NOT NULL , WWPMailTo TEXT , WWPMailCC TEXT , WWPMailBCC TEXT , WWPMailSenderAddress TEXT NOT NULL , WWPMailSenderName TEXT NOT NULL , WWPMailStatus smallint NOT NULL , WWPMailCreated timestamp without time zone NOT NULL , WWPMailScheduled timestamp without time zone NOT NULL , WWPMailProcessed timestamp without time zone , WWPMailDetail TEXT , WWPNotificationId bigint , PRIMARY KEY(WWPMailId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_MAIL1 ON WWP_Mail (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_MAIL1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_MAIL1 ON WWP_Mail (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_MailTemplate( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_MailTemplate */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_MailTemplate (WWPMailTemplateName VARCHAR(40) NOT NULL , WWPMailTemplateDescription VARCHAR(100) NOT NULL , WWPMailTemplateSubject VARCHAR(80) NOT NULL , WWPMailTemplateBody TEXT NOT NULL , WWPMailTemplateSenderAddress TEXT NOT NULL , WWPMailTemplateSenderName TEXT NOT NULL , PRIMARY KEY(WWPMailTemplateName))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_MailTemplate CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_MailTemplate CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_MailTemplate CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_MailTemplate (WWPMailTemplateName VARCHAR(40) NOT NULL , WWPMailTemplateDescription VARCHAR(100) NOT NULL , WWPMailTemplateSubject VARCHAR(80) NOT NULL , WWPMailTemplateBody TEXT NOT NULL , WWPMailTemplateSenderAddress TEXT NOT NULL , WWPMailTemplateSenderName TEXT NOT NULL , PRIMARY KEY(WWPMailTemplateName))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Notification( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Notification */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPNotificationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPNotificationId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPNotificationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Notification (WWPNotificationId bigint NOT NULL DEFAULT nextval('WWPNotificationId'), WWPNotificationDefinitionId bigint NOT NULL , WWPNotificationCreated timestamp without time zone NOT NULL , WWPNotificationIcon VARCHAR(100) NOT NULL , WWPNotificationTitle VARCHAR(200) NOT NULL , WWPNotificationShortDescriptio VARCHAR(200) NOT NULL , WWPNotificationLink VARCHAR(1000) NOT NULL , WWPNotificationIsRead BOOLEAN NOT NULL , WWPUserExtendedId CHAR(40) , WWPNotificationMetadata TEXT , PRIMARY KEY(WWPNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Notification CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Notification CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Notification CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Notification (WWPNotificationId bigint NOT NULL DEFAULT nextval('WWPNotificationId'), WWPNotificationDefinitionId bigint NOT NULL , WWPNotificationCreated timestamp without time zone NOT NULL , WWPNotificationIcon VARCHAR(100) NOT NULL , WWPNotificationTitle VARCHAR(200) NOT NULL , WWPNotificationShortDescriptio VARCHAR(200) NOT NULL , WWPNotificationLink VARCHAR(1000) NOT NULL , WWPNotificationIsRead BOOLEAN NOT NULL , WWPUserExtendedId CHAR(40) , WWPNotificationMetadata TEXT , PRIMARY KEY(WWPNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATION1 ON WWP_Notification (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_NOTIFICATION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATION1 ON WWP_Notification (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATION2 ON WWP_Notification (WWPNotificationDefinitionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_NOTIFICATION2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATION2 ON WWP_Notification (WWPNotificationDefinitionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX WWP_NOTIFICATIONCREATEDDATE ON WWP_Notification (WWPNotificationCreated DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX WWP_NOTIFICATIONCREATEDDATE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX WWP_NOTIFICATIONCREATEDDATE ON WWP_Notification (WWPNotificationCreated DESC) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_NotificationDefinition( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_NotificationDefinition */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPNotificationDefinitionId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPNotificationDefinitionId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPNotificationDefinitionId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_NotificationDefinition (WWPNotificationDefinitionId bigint NOT NULL DEFAULT nextval('WWPNotificationDefinitionId'), WWPNotificationDefinitionName VARCHAR(100) NOT NULL , WWPNotificationDefinitionAppli smallint NOT NULL , WWPNotificationDefinitionAllow BOOLEAN NOT NULL , WWPNotificationDefinitionDescr VARCHAR(200) NOT NULL , WWPNotificationDefinitionIcon VARCHAR(40) NOT NULL , WWPNotificationDefinitionTitle VARCHAR(200) NOT NULL , WWPNotificationDefinitionShort VARCHAR(200) NOT NULL , WWPNotificationDefinitionLongD VARCHAR(1000) NOT NULL , WWPNotificationDefinitionLink VARCHAR(1000) NOT NULL , WWPEntityId bigint NOT NULL , WWPNotificationDefinitionSecFu VARCHAR(200) NOT NULL , PRIMARY KEY(WWPNotificationDefinitionId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_NotificationDefinition CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_NotificationDefinition CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_NotificationDefinition CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_NotificationDefinition (WWPNotificationDefinitionId bigint NOT NULL DEFAULT nextval('WWPNotificationDefinitionId'), WWPNotificationDefinitionName VARCHAR(100) NOT NULL , WWPNotificationDefinitionAppli smallint NOT NULL , WWPNotificationDefinitionAllow BOOLEAN NOT NULL , WWPNotificationDefinitionDescr VARCHAR(200) NOT NULL , WWPNotificationDefinitionIcon VARCHAR(40) NOT NULL , WWPNotificationDefinitionTitle VARCHAR(200) NOT NULL , WWPNotificationDefinitionShort VARCHAR(200) NOT NULL , WWPNotificationDefinitionLongD VARCHAR(1000) NOT NULL , WWPNotificationDefinitionLink VARCHAR(1000) NOT NULL , WWPEntityId bigint NOT NULL , WWPNotificationDefinitionSecFu VARCHAR(200) NOT NULL , PRIMARY KEY(WWPNotificationDefinitionId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATIONDEFINITION1 ON WWP_NotificationDefinition (WWPEntityId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_NOTIFICATIONDEFINITION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_NOTIFICATIONDEFINITION1 ON WWP_NotificationDefinition (WWPEntityId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_WebClient( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_WebClient */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_WebClient (WWPWebClientId CHAR(100) NOT NULL , WWPWebClientBrowserId smallint NOT NULL , WWPWebClientBrowserVersion TEXT NOT NULL , WWPWebClientFirstRegistered timestamp without time zone NOT NULL , WWPWebClientLastRegistered timestamp without time zone NOT NULL , WWPUserExtendedId CHAR(40) , PRIMARY KEY(WWPWebClientId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_WebClient CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_WebClient CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_WebClient CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_WebClient (WWPWebClientId CHAR(100) NOT NULL , WWPWebClientBrowserId smallint NOT NULL , WWPWebClientBrowserVersion TEXT NOT NULL , WWPWebClientFirstRegistered timestamp without time zone NOT NULL , WWPWebClientLastRegistered timestamp without time zone NOT NULL , WWPUserExtendedId CHAR(40) , PRIMARY KEY(WWPWebClientId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_WEBCLIENT1 ON WWP_WebClient (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_WEBCLIENT1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_WEBCLIENT1 ON WWP_WebClient (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_WebNotification( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_WebNotification */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPWebNotificationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPWebNotificationId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPWebNotificationId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_WebNotification (WWPWebNotificationId bigint NOT NULL DEFAULT nextval('WWPWebNotificationId'), WWPWebNotificationTitle VARCHAR(40) NOT NULL , WWPNotificationId bigint , WWPWebNotificationText VARCHAR(120) NOT NULL , WWPWebNotificationIcon VARCHAR(255) NOT NULL , WWPWebNotificationClientId TEXT NOT NULL , WWPWebNotificationStatus smallint NOT NULL , WWPWebNotificationCreated timestamp without time zone NOT NULL , WWPWebNotificationScheduled timestamp without time zone NOT NULL , WWPWebNotificationProcessed timestamp without time zone NOT NULL , WWPWebNotificationRead timestamp without time zone , WWPWebNotificationDetail TEXT , WWPWebNotificationReceived BOOLEAN , PRIMARY KEY(WWPWebNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_WebNotification CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_WebNotification CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_WebNotification CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_WebNotification (WWPWebNotificationId bigint NOT NULL DEFAULT nextval('WWPWebNotificationId'), WWPWebNotificationTitle VARCHAR(40) NOT NULL , WWPNotificationId bigint , WWPWebNotificationText VARCHAR(120) NOT NULL , WWPWebNotificationIcon VARCHAR(255) NOT NULL , WWPWebNotificationClientId TEXT NOT NULL , WWPWebNotificationStatus smallint NOT NULL , WWPWebNotificationCreated timestamp without time zone NOT NULL , WWPWebNotificationScheduled timestamp without time zone NOT NULL , WWPWebNotificationProcessed timestamp without time zone NOT NULL , WWPWebNotificationRead timestamp without time zone , WWPWebNotificationDetail TEXT , WWPWebNotificationReceived BOOLEAN , PRIMARY KEY(WWPWebNotificationId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_WEBNOTIFICATION1 ON WWP_WebNotification (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_WEBNOTIFICATION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_WEBNOTIFICATION1 ON WWP_WebNotification (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_SMS( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_SMS */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPSMSId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPSMSId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPSMSId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_SMS (WWPSMSId bigint NOT NULL DEFAULT nextval('WWPSMSId'), WWPSMSMessage TEXT NOT NULL , WWPSMSSenderNumber TEXT NOT NULL , WWPSMSRecipientNumbers TEXT NOT NULL , WWPSMSStatus smallint NOT NULL , WWPSMSCreated timestamp without time zone NOT NULL , WWPSMSScheduled timestamp without time zone NOT NULL , WWPSMSProcessed timestamp without time zone , WWPSMSDetail TEXT , WWPNotificationId bigint , PRIMARY KEY(WWPSMSId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_SMS CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_SMS CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_SMS CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_SMS (WWPSMSId bigint NOT NULL DEFAULT nextval('WWPSMSId'), WWPSMSMessage TEXT NOT NULL , WWPSMSSenderNumber TEXT NOT NULL , WWPSMSRecipientNumbers TEXT NOT NULL , WWPSMSStatus smallint NOT NULL , WWPSMSCreated timestamp without time zone NOT NULL , WWPSMSScheduled timestamp without time zone NOT NULL , WWPSMSProcessed timestamp without time zone , WWPSMSDetail TEXT , WWPNotificationId bigint , PRIMARY KEY(WWPSMSId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_SMS1 ON WWP_SMS (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_SMS1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_SMS1 ON WWP_SMS (WWPNotificationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Subscription( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Subscription */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPSubscriptionId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPSubscriptionId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPSubscriptionId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Subscription (WWPSubscriptionId bigint NOT NULL DEFAULT nextval('WWPSubscriptionId'), WWPNotificationDefinitionId bigint NOT NULL , WWPUserExtendedId CHAR(40) , WWPSubscriptionEntityRecordId VARCHAR(2000) NOT NULL , WWPSubscriptionEntityRecordDes VARCHAR(200) NOT NULL , WWPSubscriptionRoleId CHAR(40) , WWPSubscriptionSubscribed BOOLEAN NOT NULL , PRIMARY KEY(WWPSubscriptionId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Subscription CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Subscription CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Subscription CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Subscription (WWPSubscriptionId bigint NOT NULL DEFAULT nextval('WWPSubscriptionId'), WWPNotificationDefinitionId bigint NOT NULL , WWPUserExtendedId CHAR(40) , WWPSubscriptionEntityRecordId VARCHAR(2000) NOT NULL , WWPSubscriptionEntityRecordDes VARCHAR(200) NOT NULL , WWPSubscriptionRoleId CHAR(40) , WWPSubscriptionSubscribed BOOLEAN NOT NULL , PRIMARY KEY(WWPSubscriptionId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_SUBSCRIPTION1 ON WWP_Subscription (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_SUBSCRIPTION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_SUBSCRIPTION1 ON WWP_Subscription (WWPUserExtendedId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX IWWP_SUBSCRIPTION2 ON WWP_Subscription (WWPNotificationDefinitionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX IWWP_SUBSCRIPTION2 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX IWWP_SUBSCRIPTION2 ON WWP_Subscription (WWPNotificationDefinitionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Entity( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Entity */
         try
         {
            cmdBuffer=" CREATE SEQUENCE WWPEntityId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP SEQUENCE WWPEntityId CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE SEQUENCE WWPEntityId MINVALUE 1 INCREMENT 1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Entity (WWPEntityId bigint NOT NULL DEFAULT nextval('WWPEntityId'), WWPEntityName VARCHAR(100) NOT NULL , PRIMARY KEY(WWPEntityId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Entity CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Entity CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Entity CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Entity (WWPEntityId bigint NOT NULL DEFAULT nextval('WWPEntityId'), WWPEntityName VARCHAR(100) NOT NULL , PRIMARY KEY(WWPEntityId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_Parameter( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_Parameter */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_Parameter (WWPParameterKey VARCHAR(300) NOT NULL , WWPParameterCategory VARCHAR(200) NOT NULL , WWPParameterDescription VARCHAR(200) NOT NULL , WWPParameterValue TEXT NOT NULL , WWPParameterDisableDelete BOOLEAN NOT NULL , PRIMARY KEY(WWPParameterKey))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_Parameter CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_Parameter CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_Parameter CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_Parameter (WWPParameterKey VARCHAR(300) NOT NULL , WWPParameterCategory VARCHAR(200) NOT NULL , WWPParameterDescription VARCHAR(200) NOT NULL , WWPParameterValue TEXT NOT NULL , WWPParameterDisableDelete BOOLEAN NOT NULL , PRIMARY KEY(WWPParameterKey))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateWWP_UserExtended( )
      {
         string cmdBuffer = "";
         /* Indices for table WWP_UserExtended */
         try
         {
            cmdBuffer=" CREATE TABLE WWP_UserExtended (WWPUserExtendedId CHAR(40) NOT NULL , WWPUserExtendedPhoto BYTEA NOT NULL , WWPUserExtendedPhoto_GXI VARCHAR(2048) , WWPUserExtendedName VARCHAR(100) NOT NULL , WWPUserExtendedFullName VARCHAR(100) NOT NULL , WWPUserExtendedPhone CHAR(20) NOT NULL , WWPUserExtendedEmail VARCHAR(100) NOT NULL , WWPUserExtendedEmaiNotif BOOLEAN NOT NULL , WWPUserExtendedSMSNotif BOOLEAN NOT NULL , WWPUserExtendedMobileNotif BOOLEAN NOT NULL , WWPUserExtendedDesktopNotif BOOLEAN NOT NULL , WWPUserExtendedDeleted BOOLEAN NOT NULL , WWPUserExtendedDeletedIn timestamp without time zone , PRIMARY KEY(WWPUserExtendedId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE WWP_UserExtended CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW WWP_UserExtended CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION WWP_UserExtended CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE WWP_UserExtended (WWPUserExtendedId CHAR(40) NOT NULL , WWPUserExtendedPhoto BYTEA NOT NULL , WWPUserExtendedPhoto_GXI VARCHAR(2048) , WWPUserExtendedName VARCHAR(100) NOT NULL , WWPUserExtendedFullName VARCHAR(100) NOT NULL , WWPUserExtendedPhone CHAR(20) NOT NULL , WWPUserExtendedEmail VARCHAR(100) NOT NULL , WWPUserExtendedEmaiNotif BOOLEAN NOT NULL , WWPUserExtendedSMSNotif BOOLEAN NOT NULL , WWPUserExtendedMobileNotif BOOLEAN NOT NULL , WWPUserExtendedDesktopNotif BOOLEAN NOT NULL , WWPUserExtendedDeleted BOOLEAN NOT NULL , WWPUserExtendedDeletedIn timestamp without time zone , PRIMARY KEY(WWPUserExtendedId))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_SubscriptionWWP_NotificationDefinition( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_Subscription ADD CONSTRAINT IWWP_SUBSCRIPTION2 FOREIGN KEY (WWPNotificationDefinitionId) REFERENCES WWP_NotificationDefinition (WWPNotificationDefinitionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_Subscription DROP CONSTRAINT IWWP_SUBSCRIPTION2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_Subscription ADD CONSTRAINT IWWP_SUBSCRIPTION2 FOREIGN KEY (WWPNotificationDefinitionId) REFERENCES WWP_NotificationDefinition (WWPNotificationDefinitionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_SubscriptionWWP_UserExtended( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_Subscription ADD CONSTRAINT IWWP_SUBSCRIPTION1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_Subscription DROP CONSTRAINT IWWP_SUBSCRIPTION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_Subscription ADD CONSTRAINT IWWP_SUBSCRIPTION1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_SMSWWP_Notification( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_SMS ADD CONSTRAINT IWWP_SMS1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_SMS DROP CONSTRAINT IWWP_SMS1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_SMS ADD CONSTRAINT IWWP_SMS1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_WebNotificationWWP_Notification( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_WebNotification ADD CONSTRAINT IWWP_WEBNOTIFICATION1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_WebNotification DROP CONSTRAINT IWWP_WEBNOTIFICATION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_WebNotification ADD CONSTRAINT IWWP_WEBNOTIFICATION1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_WebClientWWP_UserExtended( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_WebClient ADD CONSTRAINT IWWP_WEBCLIENT1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_WebClient DROP CONSTRAINT IWWP_WEBCLIENT1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_WebClient ADD CONSTRAINT IWWP_WEBCLIENT1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_NotificationDefinitionWWP_Entity( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_NotificationDefinition ADD CONSTRAINT IWWP_NOTIFICATIONDEFINITION1 FOREIGN KEY (WWPEntityId) REFERENCES WWP_Entity (WWPEntityId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_NotificationDefinition DROP CONSTRAINT IWWP_NOTIFICATIONDEFINITION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_NotificationDefinition ADD CONSTRAINT IWWP_NOTIFICATIONDEFINITION1 FOREIGN KEY (WWPEntityId) REFERENCES WWP_Entity (WWPEntityId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_NotificationWWP_NotificationDefinition( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_Notification ADD CONSTRAINT IWWP_NOTIFICATION2 FOREIGN KEY (WWPNotificationDefinitionId) REFERENCES WWP_NotificationDefinition (WWPNotificationDefinitionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_Notification DROP CONSTRAINT IWWP_NOTIFICATION2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_Notification ADD CONSTRAINT IWWP_NOTIFICATION2 FOREIGN KEY (WWPNotificationDefinitionId) REFERENCES WWP_NotificationDefinition (WWPNotificationDefinitionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_NotificationWWP_UserExtended( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_Notification ADD CONSTRAINT IWWP_NOTIFICATION1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_Notification DROP CONSTRAINT IWWP_NOTIFICATION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_Notification ADD CONSTRAINT IWWP_NOTIFICATION1 FOREIGN KEY (WWPUserExtendedId) REFERENCES WWP_UserExtended (WWPUserExtendedId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_MailWWP_Notification( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_Mail ADD CONSTRAINT IWWP_MAIL1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_Mail DROP CONSTRAINT IWWP_MAIL1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_Mail ADD CONSTRAINT IWWP_MAIL1 FOREIGN KEY (WWPNotificationId) REFERENCES WWP_Notification (WWPNotificationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWWP_MailAttachmentsWWP_Mail( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WWP_MailAttachments ADD CONSTRAINT IWWP_MAILATTACHMENTS1 FOREIGN KEY (WWPMailId) REFERENCES WWP_Mail (WWPMailId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WWP_MailAttachments DROP CONSTRAINT IWWP_MAILATTACHMENTS1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WWP_MailAttachments ADD CONSTRAINT IWWP_MAILATTACHMENTS1 FOREIGN KEY (WWPMailId) REFERENCES WWP_Mail (WWPMailId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICompanyCompanyLocation( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Company ADD CONSTRAINT ICOMPANY1 FOREIGN KEY (CompanyLocationId) REFERENCES CompanyLocation (CompanyLocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Company DROP CONSTRAINT ICOMPANY1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Company ADD CONSTRAINT ICOMPANY1 FOREIGN KEY (CompanyLocationId) REFERENCES CompanyLocation (CompanyLocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIProjectEmployee( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Project ADD CONSTRAINT GX_000F004I FOREIGN KEY (ProjectManagerId) REFERENCES Employee (EmployeeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Project DROP CONSTRAINT GX_000F004I "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Project ADD CONSTRAINT GX_000F004I FOREIGN KEY (ProjectManagerId) REFERENCES Employee (EmployeeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIProjectEmployeeProject( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Project ADD CONSTRAINT IPROJECT1 FOREIGN KEY (ProjectManagerId, ProjectId) REFERENCES EmployeeProject (EmployeeId, ProjectId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Project DROP CONSTRAINT IPROJECT1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Project ADD CONSTRAINT IPROJECT1 FOREIGN KEY (ProjectManagerId, ProjectId) REFERENCES EmployeeProject (EmployeeId, ProjectId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEmployeeCompany( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Employee ADD CONSTRAINT IEMPLOYEE1 FOREIGN KEY (CompanyId) REFERENCES Company (CompanyId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Employee DROP CONSTRAINT IEMPLOYEE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Employee ADD CONSTRAINT IEMPLOYEE1 FOREIGN KEY (CompanyId) REFERENCES Company (CompanyId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEmployeeProjectEmployee( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE EmployeeProject ADD CONSTRAINT IEMPLOYEEPROJECT2 FOREIGN KEY (EmployeeId) REFERENCES Employee (EmployeeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE EmployeeProject DROP CONSTRAINT IEMPLOYEEPROJECT2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE EmployeeProject ADD CONSTRAINT IEMPLOYEEPROJECT2 FOREIGN KEY (EmployeeId) REFERENCES Employee (EmployeeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEmployeeProjectProject( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE EmployeeProject ADD CONSTRAINT IEMPLOYEEPROJECT1 FOREIGN KEY (ProjectId) REFERENCES Project (ProjectId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE EmployeeProject DROP CONSTRAINT IEMPLOYEEPROJECT1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE EmployeeProject ADD CONSTRAINT IEMPLOYEEPROJECT1 FOREIGN KEY (ProjectId) REFERENCES Project (ProjectId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIHolidayCompany( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Holiday ADD CONSTRAINT IHOLIDAY1 FOREIGN KEY (CompanyId) REFERENCES Company (CompanyId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Holiday DROP CONSTRAINT IHOLIDAY1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Holiday ADD CONSTRAINT IHOLIDAY1 FOREIGN KEY (CompanyId) REFERENCES Company (CompanyId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIWorkHourLogEmployeeProject( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE WorkHourLog ADD CONSTRAINT IWORKHOURLOG1 FOREIGN KEY (EmployeeId, ProjectId) REFERENCES EmployeeProject (EmployeeId, ProjectId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE WorkHourLog DROP CONSTRAINT IWORKHOURLOG1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE WorkHourLog ADD CONSTRAINT IWORKHOURLOG1 FOREIGN KEY (EmployeeId, ProjectId) REFERENCES EmployeeProject (EmployeeId, ProjectId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RILeaveTypeCompany( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE LeaveType ADD CONSTRAINT ILEAVETYPE1 FOREIGN KEY (CompanyId) REFERENCES Company (CompanyId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE LeaveType DROP CONSTRAINT ILEAVETYPE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE LeaveType ADD CONSTRAINT ILEAVETYPE1 FOREIGN KEY (CompanyId) REFERENCES Company (CompanyId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RILeaveRequestLeaveType( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE LeaveRequest ADD CONSTRAINT ILEAVEREQUEST2 FOREIGN KEY (LeaveTypeId) REFERENCES LeaveType (LeaveTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE LeaveRequest DROP CONSTRAINT ILEAVEREQUEST2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE LeaveRequest ADD CONSTRAINT ILEAVEREQUEST2 FOREIGN KEY (LeaveTypeId) REFERENCES LeaveType (LeaveTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RILeaveRequestEmployee( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE LeaveRequest ADD CONSTRAINT ILEAVEREQUEST1 FOREIGN KEY (EmployeeId) REFERENCES Employee (EmployeeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE LeaveRequest DROP CONSTRAINT ILEAVEREQUEST1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE LeaveRequest ADD CONSTRAINT ILEAVEREQUEST1 FOREIGN KEY (EmployeeId) REFERENCES Employee (EmployeeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISiteSettingCompany( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SiteSetting ADD CONSTRAINT ISITESETTING1 FOREIGN KEY (CompanyId) REFERENCES Company (CompanyId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SiteSetting DROP CONSTRAINT ISITESETTING1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SiteSetting ADD CONSTRAINT ISITESETTING1 FOREIGN KEY (CompanyId) REFERENCES Company (CompanyId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RISupportRequestEmployee( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE SupportRequest ADD CONSTRAINT ISUPPORTREQUEST1 FOREIGN KEY (EmployeeId) REFERENCES Employee (EmployeeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE SupportRequest DROP CONSTRAINT ISUPPORTREQUEST1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE SupportRequest ADD CONSTRAINT ISUPPORTREQUEST1 FOREIGN KEY (EmployeeId) REFERENCES Employee (EmployeeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEmployeeVacationSetEmployee( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE EmployeeVacationSet ADD CONSTRAINT IEMPLOYEEVACATIONSET1 FOREIGN KEY (EmployeeId) REFERENCES Employee (EmployeeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE EmployeeVacationSet DROP CONSTRAINT IEMPLOYEEVACATIONSET1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE EmployeeVacationSet ADD CONSTRAINT IEMPLOYEEVACATIONSET1 FOREIGN KEY (EmployeeId) REFERENCES Employee (EmployeeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      private void TablesCount( )
      {
      }

      private bool PreviousCheck( )
      {
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         sSchemaVar = GXUtil.UserId( "Server", context, pr_default);
         if ( tableexist("TrnNew",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"TrnNew"}) ) ;
            return false ;
         }
         if ( tableexist("EmployeeVacationSet",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"EmployeeVacationSet"}) ) ;
            return false ;
         }
         if ( tableexist("SupportRequest",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"SupportRequest"}) ) ;
            return false ;
         }
         if ( tableexist("SiteSetting",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"SiteSetting"}) ) ;
            return false ;
         }
         if ( tableexist("CompanyLocation",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"CompanyLocation"}) ) ;
            return false ;
         }
         if ( tableexist("Device",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Device"}) ) ;
            return false ;
         }
         if ( tableexist("LeaveRequest",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"LeaveRequest"}) ) ;
            return false ;
         }
         if ( tableexist("LeaveType",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"LeaveType"}) ) ;
            return false ;
         }
         if ( tableexist("WorkHourLog",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WorkHourLog"}) ) ;
            return false ;
         }
         if ( tableexist("Holiday",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Holiday"}) ) ;
            return false ;
         }
         if ( tableexist("EmployeeProject",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"EmployeeProject"}) ) ;
            return false ;
         }
         if ( tableexist("Employee",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Employee"}) ) ;
            return false ;
         }
         if ( tableexist("Project",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Project"}) ) ;
            return false ;
         }
         if ( tableexist("Company",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Company"}) ) ;
            return false ;
         }
         if ( tableexist("UserCustomizations",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"UserCustomizations"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_MailAttachments",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_MailAttachments"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_Mail",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_Mail"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_MailTemplate",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_MailTemplate"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_Notification",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_Notification"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_NotificationDefinition",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_NotificationDefinition"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_WebClient",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_WebClient"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_WebNotification",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_WebNotification"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_SMS",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_SMS"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_Subscription",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_Subscription"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_Entity",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_Entity"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_Parameter",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_Parameter"}) ) ;
            return false ;
         }
         if ( tableexist("WWP_UserExtended",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"WWP_UserExtended"}) ) ;
            return false ;
         }
         return true ;
      }

      private bool tableexist( string sTableName ,
                               string sMySchemaName )
      {
         bool result;
         result = false;
         /* Using cursor P00012 */
         pr_default.execute(0, new Object[] {sTableName, sMySchemaName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            tablename = P00012_Atablename[0];
            ntablename = P00012_ntablename[0];
            schemaname = P00012_Aschemaname[0];
            nschemaname = P00012_nschemaname[0];
            result = true;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00023 */
         pr_default.execute(1, new Object[] {sTableName, sMySchemaName});
         while ( (pr_default.getStatus(1) != 101) )
         {
            tablename = P00023_Atablename[0];
            ntablename = P00023_ntablename[0];
            schemaname = P00023_Aschemaname[0];
            nschemaname = P00023_nschemaname[0];
            result = true;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         return result ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "CreateTrnNew" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "CreateEmployeeVacationSet" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "CreateSupportRequest" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "CreateSiteSetting" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 5 ,  "CreateCompanyLocation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 6 ,  "CreateDevice" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 7 ,  "CreateLeaveRequest" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 8 ,  "CreateLeaveType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 9 ,  "CreateWorkHourLog" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 10 ,  "CreateHoliday" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 11 ,  "CreateEmployeeProject" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 12 ,  "CreateEmployee" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 13 ,  "CreateProject" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 14 ,  "CreateCompany" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 15 ,  "CreateUserCustomizations" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 16 ,  "CreateWWP_MailAttachments" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 17 ,  "CreateWWP_Mail" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 18 ,  "CreateWWP_MailTemplate" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 19 ,  "CreateWWP_Notification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 20 ,  "CreateWWP_NotificationDefinition" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 21 ,  "CreateWWP_WebClient" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 22 ,  "CreateWWP_WebNotification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 23 ,  "CreateWWP_SMS" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 24 ,  "CreateWWP_Subscription" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 25 ,  "CreateWWP_Entity" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 26 ,  "CreateWWP_Parameter" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 27 ,  "CreateWWP_UserExtended" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 28 ,  "RIWWP_SubscriptionWWP_NotificationDefinition" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 29 ,  "RIWWP_SubscriptionWWP_UserExtended" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 30 ,  "RIWWP_SMSWWP_Notification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 31 ,  "RIWWP_WebNotificationWWP_Notification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 32 ,  "RIWWP_WebClientWWP_UserExtended" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 33 ,  "RIWWP_NotificationDefinitionWWP_Entity" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 34 ,  "RIWWP_NotificationWWP_NotificationDefinition" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 35 ,  "RIWWP_NotificationWWP_UserExtended" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 36 ,  "RIWWP_MailWWP_Notification" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 37 ,  "RIWWP_MailAttachmentsWWP_Mail" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 38 ,  "RICompanyCompanyLocation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 39 ,  "RIProjectEmployee" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 40 ,  "RIProjectEmployeeProject" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 41 ,  "RIEmployeeCompany" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 42 ,  "RIEmployeeProjectEmployee" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 43 ,  "RIEmployeeProjectProject" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 44 ,  "RIHolidayCompany" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 45 ,  "RIWorkHourLogEmployeeProject" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 46 ,  "RILeaveTypeCompany" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 47 ,  "RILeaveRequestLeaveType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 48 ,  "RILeaveRequestEmployee" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 49 ,  "RISiteSettingCompany" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 50 ,  "RISupportRequestEmployee" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 51 ,  "RIEmployeeVacationSetEmployee" , new Object[]{ });
      }

      private void ExecuteTablesReorganization( )
      {
         ExecuteOnlyTablesReorganization( ) ;
         ExecuteOnlyRisReorganization( ) ;
         ReorgExecute.SubmitAll() ;
      }

      private void SetPrecedence( )
      {
         SetPrecedencetables( ) ;
         SetPrecedenceris( ) ;
      }

      private void SetPrecedencetables( )
      {
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TrnNew", ""}) );
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"EmployeeVacationSet", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateEmployeeVacationSet" ,  "CreateEmployee" );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"SupportRequest", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateSupportRequest" ,  "CreateEmployee" );
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"SiteSetting", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateSiteSetting" ,  "CreateCompany" );
         GXReorganization.SetMsg( 5 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"CompanyLocation", ""}) );
         GXReorganization.SetMsg( 6 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Device", ""}) );
         GXReorganization.SetMsg( 7 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"LeaveRequest", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateLeaveRequest" ,  "CreateLeaveType" );
         ReorgExecute.RegisterPrecedence( "CreateLeaveRequest" ,  "CreateEmployee" );
         GXReorganization.SetMsg( 8 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"LeaveType", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateLeaveType" ,  "CreateCompany" );
         GXReorganization.SetMsg( 9 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WorkHourLog", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWorkHourLog" ,  "CreateEmployeeProject" );
         GXReorganization.SetMsg( 10 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Holiday", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateHoliday" ,  "CreateCompany" );
         GXReorganization.SetMsg( 11 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"EmployeeProject", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateEmployeeProject" ,  "CreateEmployee" );
         ReorgExecute.RegisterPrecedence( "CreateEmployeeProject" ,  "CreateProject" );
         GXReorganization.SetMsg( 12 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Employee", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateEmployee" ,  "CreateCompany" );
         GXReorganization.SetMsg( 13 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Project", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateProject" ,  "CreateEmployee" );
         GXReorganization.SetMsg( 14 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Company", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCompany" ,  "CreateCompanyLocation" );
         GXReorganization.SetMsg( 15 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"UserCustomizations", ""}) );
         GXReorganization.SetMsg( 16 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_MailAttachments", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_MailAttachments" ,  "CreateWWP_Mail" );
         GXReorganization.SetMsg( 17 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Mail", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_Mail" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 18 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_MailTemplate", ""}) );
         GXReorganization.SetMsg( 19 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Notification", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_Notification" ,  "CreateWWP_NotificationDefinition" );
         ReorgExecute.RegisterPrecedence( "CreateWWP_Notification" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 20 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_NotificationDefinition", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_NotificationDefinition" ,  "CreateWWP_Entity" );
         GXReorganization.SetMsg( 21 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_WebClient", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_WebClient" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 22 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_WebNotification", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_WebNotification" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 23 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_SMS", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_SMS" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 24 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Subscription", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateWWP_Subscription" ,  "CreateWWP_NotificationDefinition" );
         ReorgExecute.RegisterPrecedence( "CreateWWP_Subscription" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 25 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Entity", ""}) );
         GXReorganization.SetMsg( 26 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_Parameter", ""}) );
         GXReorganization.SetMsg( 27 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"WWP_UserExtended", ""}) );
      }

      private void SetPrecedenceris( )
      {
         GXReorganization.SetMsg( 28 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_SUBSCRIPTION2"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_SubscriptionWWP_NotificationDefinition" ,  "CreateWWP_Subscription" );
         ReorgExecute.RegisterPrecedence( "RIWWP_SubscriptionWWP_NotificationDefinition" ,  "CreateWWP_NotificationDefinition" );
         GXReorganization.SetMsg( 29 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_SUBSCRIPTION1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_SubscriptionWWP_UserExtended" ,  "CreateWWP_Subscription" );
         ReorgExecute.RegisterPrecedence( "RIWWP_SubscriptionWWP_UserExtended" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 30 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_SMS1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_SMSWWP_Notification" ,  "CreateWWP_SMS" );
         ReorgExecute.RegisterPrecedence( "RIWWP_SMSWWP_Notification" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 31 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_WEBNOTIFICATION1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_WebNotificationWWP_Notification" ,  "CreateWWP_WebNotification" );
         ReorgExecute.RegisterPrecedence( "RIWWP_WebNotificationWWP_Notification" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 32 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_WEBCLIENT1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_WebClientWWP_UserExtended" ,  "CreateWWP_WebClient" );
         ReorgExecute.RegisterPrecedence( "RIWWP_WebClientWWP_UserExtended" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 33 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_NOTIFICATIONDEFINITION1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationDefinitionWWP_Entity" ,  "CreateWWP_NotificationDefinition" );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationDefinitionWWP_Entity" ,  "CreateWWP_Entity" );
         GXReorganization.SetMsg( 34 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_NOTIFICATION2"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationWWP_NotificationDefinition" ,  "CreateWWP_Notification" );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationWWP_NotificationDefinition" ,  "CreateWWP_NotificationDefinition" );
         GXReorganization.SetMsg( 35 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_NOTIFICATION1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationWWP_UserExtended" ,  "CreateWWP_Notification" );
         ReorgExecute.RegisterPrecedence( "RIWWP_NotificationWWP_UserExtended" ,  "CreateWWP_UserExtended" );
         GXReorganization.SetMsg( 36 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_MAIL1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_MailWWP_Notification" ,  "CreateWWP_Mail" );
         ReorgExecute.RegisterPrecedence( "RIWWP_MailWWP_Notification" ,  "CreateWWP_Notification" );
         GXReorganization.SetMsg( 37 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWWP_MAILATTACHMENTS1"}) );
         ReorgExecute.RegisterPrecedence( "RIWWP_MailAttachmentsWWP_Mail" ,  "CreateWWP_MailAttachments" );
         ReorgExecute.RegisterPrecedence( "RIWWP_MailAttachmentsWWP_Mail" ,  "CreateWWP_Mail" );
         GXReorganization.SetMsg( 38 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ICOMPANY1"}) );
         ReorgExecute.RegisterPrecedence( "RICompanyCompanyLocation" ,  "CreateCompany" );
         ReorgExecute.RegisterPrecedence( "RICompanyCompanyLocation" ,  "CreateCompanyLocation" );
         GXReorganization.SetMsg( 39 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"GX_000F004I"}) );
         ReorgExecute.RegisterPrecedence( "RIProjectEmployee" ,  "CreateProject" );
         ReorgExecute.RegisterPrecedence( "RIProjectEmployee" ,  "CreateEmployee" );
         GXReorganization.SetMsg( 40 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IPROJECT1"}) );
         ReorgExecute.RegisterPrecedence( "RIProjectEmployeeProject" ,  "CreateProject" );
         ReorgExecute.RegisterPrecedence( "RIProjectEmployeeProject" ,  "CreateEmployeeProject" );
         GXReorganization.SetMsg( 41 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IEMPLOYEE1"}) );
         ReorgExecute.RegisterPrecedence( "RIEmployeeCompany" ,  "CreateEmployee" );
         ReorgExecute.RegisterPrecedence( "RIEmployeeCompany" ,  "CreateCompany" );
         GXReorganization.SetMsg( 42 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IEMPLOYEEPROJECT2"}) );
         ReorgExecute.RegisterPrecedence( "RIEmployeeProjectEmployee" ,  "CreateEmployeeProject" );
         ReorgExecute.RegisterPrecedence( "RIEmployeeProjectEmployee" ,  "CreateEmployee" );
         GXReorganization.SetMsg( 43 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IEMPLOYEEPROJECT1"}) );
         ReorgExecute.RegisterPrecedence( "RIEmployeeProjectProject" ,  "CreateEmployeeProject" );
         ReorgExecute.RegisterPrecedence( "RIEmployeeProjectProject" ,  "CreateProject" );
         GXReorganization.SetMsg( 44 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IHOLIDAY1"}) );
         ReorgExecute.RegisterPrecedence( "RIHolidayCompany" ,  "CreateHoliday" );
         ReorgExecute.RegisterPrecedence( "RIHolidayCompany" ,  "CreateCompany" );
         GXReorganization.SetMsg( 45 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IWORKHOURLOG1"}) );
         ReorgExecute.RegisterPrecedence( "RIWorkHourLogEmployeeProject" ,  "CreateWorkHourLog" );
         ReorgExecute.RegisterPrecedence( "RIWorkHourLogEmployeeProject" ,  "CreateEmployeeProject" );
         GXReorganization.SetMsg( 46 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ILEAVETYPE1"}) );
         ReorgExecute.RegisterPrecedence( "RILeaveTypeCompany" ,  "CreateLeaveType" );
         ReorgExecute.RegisterPrecedence( "RILeaveTypeCompany" ,  "CreateCompany" );
         GXReorganization.SetMsg( 47 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ILEAVEREQUEST2"}) );
         ReorgExecute.RegisterPrecedence( "RILeaveRequestLeaveType" ,  "CreateLeaveRequest" );
         ReorgExecute.RegisterPrecedence( "RILeaveRequestLeaveType" ,  "CreateLeaveType" );
         GXReorganization.SetMsg( 48 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ILEAVEREQUEST1"}) );
         ReorgExecute.RegisterPrecedence( "RILeaveRequestEmployee" ,  "CreateLeaveRequest" );
         ReorgExecute.RegisterPrecedence( "RILeaveRequestEmployee" ,  "CreateEmployee" );
         GXReorganization.SetMsg( 49 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISITESETTING1"}) );
         ReorgExecute.RegisterPrecedence( "RISiteSettingCompany" ,  "CreateSiteSetting" );
         ReorgExecute.RegisterPrecedence( "RISiteSettingCompany" ,  "CreateCompany" );
         GXReorganization.SetMsg( 50 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ISUPPORTREQUEST1"}) );
         ReorgExecute.RegisterPrecedence( "RISupportRequestEmployee" ,  "CreateSupportRequest" );
         ReorgExecute.RegisterPrecedence( "RISupportRequestEmployee" ,  "CreateEmployee" );
         GXReorganization.SetMsg( 51 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"IEMPLOYEEVACATIONSET1"}) );
         ReorgExecute.RegisterPrecedence( "RIEmployeeVacationSetEmployee" ,  "CreateEmployeeVacationSet" );
         ReorgExecute.RegisterPrecedence( "RIEmployeeVacationSetEmployee" ,  "CreateEmployee" );
      }

      private void ExecuteReorganization( )
      {
         if ( ErrCode == 0 )
         {
            TablesCount( ) ;
            if ( ! PrintOnlyRecordCount( ) )
            {
               FirstActions( ) ;
               SetPrecedence( ) ;
               ExecuteTablesReorganization( ) ;
            }
         }
      }

      public void UtilsCleanup( )
      {
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         DS = new GxDataStore();
         ErrMsg = "";
         DataBaseName = "";
         sSchemaVar = "";
         sTableName = "";
         sMySchemaName = "";
         tablename = "";
         ntablename = false;
         schemaname = "";
         nschemaname = false;
         P00012_Atablename = new string[] {""} ;
         P00012_ntablename = new bool[] {false} ;
         P00012_Aschemaname = new string[] {""} ;
         P00012_nschemaname = new bool[] {false} ;
         P00023_Atablename = new string[] {""} ;
         P00023_ntablename = new bool[] {false} ;
         P00023_Aschemaname = new string[] {""} ;
         P00023_nschemaname = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_Atablename, P00012_Aschemaname
               }
               , new Object[] {
               P00023_Atablename, P00023_Aschemaname
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected short Count ;
      protected short Res ;
      protected string ErrMsg ;
      protected string DataBaseName ;
      protected string cmdBuffer ;
      protected string sSchemaVar ;
      protected string sTableName ;
      protected string sMySchemaName ;
      protected bool ntablename ;
      protected bool nschemaname ;
      protected string tablename ;
      protected string schemaname ;
      protected GxDataStore DS ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected string[] P00012_Atablename ;
      protected bool[] P00012_ntablename ;
      protected string[] P00012_Aschemaname ;
      protected bool[] P00012_nschemaname ;
      protected string[] P00023_Atablename ;
      protected bool[] P00023_ntablename ;
      protected string[] P00023_Aschemaname ;
      protected bool[] P00023_nschemaname ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00012;
          prmP00012 = new Object[] {
          new ParDef("sTableName",GXType.Char,255,0) ,
          new ParDef("sMySchemaName",GXType.Char,255,0)
          };
          Object[] prmP00023;
          prmP00023 = new Object[] {
          new ParDef("sTableName",GXType.Char,255,0) ,
          new ParDef("sMySchemaName",GXType.Char,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT TABLENAME, TABLEOWNER FROM PG_TABLES WHERE (UPPER(TABLENAME) = ( UPPER(:sTableName))) AND (UPPER(TABLEOWNER) = ( UPPER(:sMySchemaName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT VIEWNAME, VIEWOWNER FROM PG_VIEWS WHERE (UPPER(VIEWNAME) = ( UPPER(:sTableName))) AND (UPPER(VIEWOWNER) = ( UPPER(:sMySchemaName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
