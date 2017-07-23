
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/06/2017 18:24:12
-- Generated from EDMX file: E:\ASP.Net\HealthyInfomation\HealthyInfomation\HealthyInformation.Model\HealthyInformation.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HealthyInformation];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Aircrew]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Aircrew];
GO
IF OBJECT_ID(N'[dbo].[AviationMedicine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AviationMedicine];
GO
IF OBJECT_ID(N'[dbo].[CommonDisease]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommonDisease];
GO
IF OBJECT_ID(N'[dbo].[FlightRecord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FlightRecord];
GO
IF OBJECT_ID(N'[dbo].[MedicalIdentification]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MedicalIdentification];
GO
IF OBJECT_ID(N'[dbo].[MedicalTreatment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MedicalTreatment];
GO
IF OBJECT_ID(N'[dbo].[PhysicalExamMinRecord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhysicalExamMinRecord];
GO
IF OBJECT_ID(N'[dbo].[Sanatorium]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sanatorium];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Aircrew'
CREATE TABLE [dbo].[Aircrew] (
    [TransactionNumber] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(20)  NOT NULL,
    [BirthDay] datetime  NOT NULL,
    [Sex] char(1)  NOT NULL,
    [Nation] varchar(10)  NOT NULL,
    [Photo] varchar(max)  NULL,
    [Degree] varchar(10)  NOT NULL,
    [EnlistmentTime] datetime  NOT NULL,
    [PartyTime] datetime  NOT NULL,
    [NativePlace] nvarchar(100)  NOT NULL,
    [TroopsType] varchar(10)  NOT NULL,
    [TroopsTel] varchar(50)  NOT NULL,
    [JobTitle] varchar(10)  NOT NULL,
    [MilitaryRank] varchar(10)  NOT NULL,
    [GraduationJuniorDate] datetime  NOT NULL,
    [GraduationDate] datetime  NOT NULL,
    [PilotPlaneDate] datetime  NOT NULL,
    [TerminateContractDetail] nvarchar(4000)  NULL,
    [InDate] datetime  NOT NULL,
    [InUser] varchar(15)  NULL,
    [LastEditDate] datetime  NOT NULL,
    [LastEditUser] varchar(15)  NULL,
    [AdmissionJuniorCollege] nvarchar(1000)  NOT NULL,
    [AdmissionCollege] nvarchar(1000)  NOT NULL
);
GO

-- Creating table 'AviationMedicine'
CREATE TABLE [dbo].[AviationMedicine] (
    [TransactionNumber] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(10)  NOT NULL,
    [Sex] char(1)  NOT NULL,
    [GraduationSchool] nvarchar(100)  NOT NULL,
    [Professional] nvarchar(100)  NOT NULL,
    [EmploymentDate] datetime  NOT NULL,
    [ContactPhone] varchar(50)  NOT NULL,
    [Qualifications] nvarchar(4000)  NULL,
    [InDate] datetime  NOT NULL,
    [InUser] varchar(50)  NULL,
    [LastEditDate] datetime  NOT NULL,
    [LastEditUser] varchar(50)  NULL
);
GO

-- Creating table 'CommonDisease'
CREATE TABLE [dbo].[CommonDisease] (
    [TransactionNumber] int IDENTITY(1,1) NOT NULL,
    [SymptomName] nvarchar(100)  NOT NULL,
    [SymptomDetail] nvarchar(1000)  NOT NULL,
    [Medication] nvarchar(500)  NOT NULL,
    [TreatmentPlan] nvarchar(4000)  NOT NULL,
    [InDate] datetime  NOT NULL,
    [InUser] varchar(15)  NULL,
    [LastEditDate] datetime  NOT NULL,
    [LastEditUser] varchar(15)  NULL
);
GO

-- Creating table 'FlightRecord'
CREATE TABLE [dbo].[FlightRecord] (
    [TransactionNumber] int IDENTITY(1,1) NOT NULL,
    [AircrewID] int  NOT NULL,
    [FlightType] varchar(10)  NOT NULL,
    [FlightTime] decimal(10,2)  NOT NULL,
    [RegisterDate] datetime  NOT NULL,
    [InDate] datetime  NOT NULL,
    [InUser] varchar(15)  NULL,
    [LastEditDate] datetime  NOT NULL,
    [LastEditUser] varchar(15)  NULL
);
GO

-- Creating table 'MedicalTreatment'
CREATE TABLE [dbo].[MedicalTreatment] (
    [TransactionNumber] int IDENTITY(1,1) NOT NULL,
    [AircrewID] int  NOT NULL,
    [HospitalizationDate] datetime  NOT NULL,
    [DischargeDate] datetime  NOT NULL,
    [HospitalLocation] nvarchar(100)  NOT NULL,
    [HospitalReason] nvarchar(500)  NOT NULL,
    [CheckSituation] nvarchar(4000)  NOT NULL,
    [Diagnosis] nvarchar(4000)  NOT NULL,
    [Conclusion] nvarchar(4000)  NOT NULL,
    [NeedObservation] char(1)  NOT NULL,
    [ObservationStartDate] datetime  NULL,
    [ObservationEndDate] datetime  NULL,
    [InDate] datetime  NOT NULL,
    [InUser] varchar(15)  NULL,
    [LastEditDate] datetime  NOT NULL,
    [LastEditUser] varchar(15)  NULL,
    [RecordDate] datetime  NOT NULL
);
GO

-- Creating table 'PhysicalExamMinRecord'
CREATE TABLE [dbo].[PhysicalExamMinRecord] (
    [TransactionNumber] int IDENTITY(1,1) NOT NULL,
    [AircrewID] int  NOT NULL,
    [Weight] decimal(10,2)  NOT NULL,
    [Pulse] int  NOT NULL,
    [BloodPressure] decimal(10,2)  NOT NULL,
    [VisionLeft] decimal(10,1)  NOT NULL,
    [VisionRight] decimal(10,1)  NOT NULL,
    [Conclusion] nvarchar(4000)  NOT NULL,
    [AviationMedicineID] int  NOT NULL,
    [RecordDate] datetime  NOT NULL,
    [InDate] datetime  NOT NULL,
    [InUser] varchar(15)  NULL,
    [LastEditDate] datetime  NOT NULL,
    [LastEditUser] varchar(15)  NULL
);
GO

-- Creating table 'Sanatorium'
CREATE TABLE [dbo].[Sanatorium] (
    [TransactionNumber] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Address] nvarchar(100)  NOT NULL,
    [RecommendTravelMode] nvarchar(100)  NOT NULL,
    [ContactPhone] varchar(50)  NOT NULL,
    [InDate] datetime  NOT NULL,
    [InUser] varchar(15)  NULL,
    [LastEditDate] datetime  NOT NULL,
    [LastEditUser] varchar(15)  NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [TransactionNumber] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(50)  NOT NULL,
    [PassWord] nvarchar(200)  NOT NULL,
    [InDate] datetime  NULL,
    [InUser] varchar(50)  NULL
);
GO

-- Creating table 'MedicalIdentification'
CREATE TABLE [dbo].[MedicalIdentification] (
    [TransactionNumber] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(4000)  NOT NULL,
    [AviationMedicineID] int  NOT NULL,
    [RecordDate] datetime  NOT NULL,
    [InDate] datetime  NOT NULL,
    [InUser] varchar(15)  NULL,
    [LastEditDate] datetime  NOT NULL,
    [LastEditUser] varchar(15)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [TransactionNumber] in table 'Aircrew'
ALTER TABLE [dbo].[Aircrew]
ADD CONSTRAINT [PK_Aircrew]
    PRIMARY KEY CLUSTERED ([TransactionNumber] ASC);
GO

-- Creating primary key on [TransactionNumber] in table 'AviationMedicine'
ALTER TABLE [dbo].[AviationMedicine]
ADD CONSTRAINT [PK_AviationMedicine]
    PRIMARY KEY CLUSTERED ([TransactionNumber] ASC);
GO

-- Creating primary key on [TransactionNumber] in table 'CommonDisease'
ALTER TABLE [dbo].[CommonDisease]
ADD CONSTRAINT [PK_CommonDisease]
    PRIMARY KEY CLUSTERED ([TransactionNumber] ASC);
GO

-- Creating primary key on [TransactionNumber] in table 'FlightRecord'
ALTER TABLE [dbo].[FlightRecord]
ADD CONSTRAINT [PK_FlightRecord]
    PRIMARY KEY CLUSTERED ([TransactionNumber] ASC);
GO

-- Creating primary key on [TransactionNumber] in table 'MedicalTreatment'
ALTER TABLE [dbo].[MedicalTreatment]
ADD CONSTRAINT [PK_MedicalTreatment]
    PRIMARY KEY CLUSTERED ([TransactionNumber] ASC);
GO

-- Creating primary key on [TransactionNumber] in table 'PhysicalExamMinRecord'
ALTER TABLE [dbo].[PhysicalExamMinRecord]
ADD CONSTRAINT [PK_PhysicalExamMinRecord]
    PRIMARY KEY CLUSTERED ([TransactionNumber] ASC);
GO

-- Creating primary key on [TransactionNumber] in table 'Sanatorium'
ALTER TABLE [dbo].[Sanatorium]
ADD CONSTRAINT [PK_Sanatorium]
    PRIMARY KEY CLUSTERED ([TransactionNumber] ASC);
GO

-- Creating primary key on [TransactionNumber] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([TransactionNumber] ASC);
GO

-- Creating primary key on [TransactionNumber] in table 'MedicalIdentification'
ALTER TABLE [dbo].[MedicalIdentification]
ADD CONSTRAINT [PK_MedicalIdentification]
    PRIMARY KEY CLUSTERED ([TransactionNumber] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------