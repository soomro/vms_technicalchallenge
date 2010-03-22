
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/22/2010 09:49:19
-- Generated from EDMX file: D:\apollovms\NET\VMSCORE\EntityModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [vms];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Aso_AlertCrisis]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Alerts] DROP CONSTRAINT [FK_Aso_AlertCrisis];
GO
IF OBJECT_ID(N'[dbo].[FK_Aso_RequestResponseNeedItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NeedItems] DROP CONSTRAINT [FK_Aso_RequestResponseNeedItem];
GO
IF OBJECT_ID(N'[dbo].[FK_Aso_RequestResponseRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RequestResponses] DROP CONSTRAINT [FK_Aso_RequestResponseRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_Aso_RequestResponseVolunteer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RequestResponses] DROP CONSTRAINT [FK_Aso_RequestResponseVolunteer];
GO
IF OBJECT_ID(N'[dbo].[FK_Aso_CrisisIncident]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Incidents] DROP CONSTRAINT [FK_Aso_CrisisIncident];
GO
IF OBJECT_ID(N'[dbo].[FK_Aso_VolunteerAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Volunteers] DROP CONSTRAINT [FK_Aso_VolunteerAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_Aso_VolunteerStuffItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StuffItems] DROP CONSTRAINT [FK_Aso_VolunteerStuffItem];
GO
IF OBJECT_ID(N'[dbo].[FK_Aso_VolunteerProgressReport]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProgressReports] DROP CONSTRAINT [FK_Aso_VolunteerProgressReport];
GO
IF OBJECT_ID(N'[dbo].[FK_Aso_ManagerAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Managers] DROP CONSTRAINT [FK_Aso_ManagerAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_Aso_IncidentProgressReport]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProgressReports] DROP CONSTRAINT [FK_Aso_IncidentProgressReport];
GO
IF OBJECT_ID(N'[dbo].[FK_Aso_IncidentRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Requests] DROP CONSTRAINT [FK_Aso_IncidentRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_Aso_IncidentAlert]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Alerts] DROP CONSTRAINT [FK_Aso_IncidentAlert];
GO
IF OBJECT_ID(N'[dbo].[FK_Aso_RequestNeedItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NeedItems] DROP CONSTRAINT [FK_Aso_RequestNeedItem];
GO
IF OBJECT_ID(N'[dbo].[FK_Aso_IncidentNeedItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NeedItems] DROP CONSTRAINT [FK_Aso_IncidentNeedItem];
GO
IF OBJECT_ID(N'[dbo].[FK_Aso_IncidentReportVolunteer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IncidentReports] DROP CONSTRAINT [FK_Aso_IncidentReportVolunteer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Crises]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Crises];
GO
IF OBJECT_ID(N'[dbo].[Alerts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Alerts];
GO
IF OBJECT_ID(N'[dbo].[Incidents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Incidents];
GO
IF OBJECT_ID(N'[dbo].[IncidentReports]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IncidentReports];
GO
IF OBJECT_ID(N'[dbo].[ProgressReports]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProgressReports];
GO
IF OBJECT_ID(N'[dbo].[Managers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Managers];
GO
IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[StuffItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StuffItems];
GO
IF OBJECT_ID(N'[dbo].[Volunteers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Volunteers];
GO
IF OBJECT_ID(N'[dbo].[Requests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Requests];
GO
IF OBJECT_ID(N'[dbo].[NeedItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NeedItems];
GO
IF OBJECT_ID(N'[dbo].[RequestResponses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RequestResponses];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Crises'
CREATE TABLE [dbo].[Crises] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Explanation] nvarchar(max)  NOT NULL,
    [StatusVal] smallint  NOT NULL,
    [CrisisTypeVal] smallint  NOT NULL,
    [LocationTypeVal] smallint  NOT NULL,
    [LocationCoordinatesStr] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [DateClosed] datetime  NULL
);
GO

-- Creating table 'Alerts'
CREATE TABLE [dbo].[Alerts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [SearchCriteriaStr] nvarchar(max)  NOT NULL,
    [DateSent] datetime  NULL,
    [IncidentId] int  NULL,
    [Crisis_Id] int  NOT NULL
);
GO

-- Creating table 'Incidents'
CREATE TABLE [dbo].[Incidents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShortDescription] nvarchar(max)  NOT NULL,
    [LocationTypeVal] smallint  NOT NULL,
    [LocationCoordinatesStr] nvarchar(max)  NOT NULL,
    [Explanation] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [DateClosed] datetime  NULL,
    [SeverityVal] smallint  NOT NULL,
    [IncidentTypeVal] smallint  NOT NULL,
    [IncidentStatusVal] smallint  NOT NULL,
    [ShortAddress] nvarchar(max)  NOT NULL,
    [CrisisId] int  NOT NULL
);
GO

-- Creating table 'IncidentReports'
CREATE TABLE [dbo].[IncidentReports] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IncidentTypeVal] smallint  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ImageFile] nvarchar(max)  NOT NULL,
    [VideoFile] nvarchar(max)  NOT NULL,
    [Location] nvarchar(max)  NOT NULL,
    [LocationCoordinatesStr] nvarchar(max)  NOT NULL,
    [IncidentId] int  NOT NULL,
    [Volunteer_Id] int  NOT NULL
);
GO

-- Creating table 'ProgressReports'
CREATE TABLE [dbo].[ProgressReports] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ReportText] nvarchar(max)  NOT NULL,
    [ImageFile] nvarchar(max)  NOT NULL,
    [VideoFile] nvarchar(max)  NOT NULL,
    [StatusVal] smallint  NOT NULL,
    [VolunteerId] int  NOT NULL,
    [IncidentId] int  NOT NULL
);
GO

-- Creating table 'Managers'
CREATE TABLE [dbo].[Managers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NameLastName] nvarchar(max)  NOT NULL,
    [ExpertiseCrisisTypesStr] nvarchar(max)  NOT NULL,
    [DateBirth] datetime  NOT NULL,
    [GenderVal] smallint  NOT NULL,
    [Address_Id] int  NOT NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [FlatNumber] nvarchar(max)  NOT NULL,
    [HouseNumber] nvarchar(max)  NOT NULL,
    [PostalCode] nvarchar(max)  NOT NULL,
    [Street] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StuffItems'
CREATE TABLE [dbo].[StuffItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ItemType] nvarchar(max)  NOT NULL,
    [MetricTypeVal] smallint  NOT NULL,
    [Amount] float  NOT NULL,
    [VolunteerId] int  NOT NULL
);
GO

-- Creating table 'Volunteers'
CREATE TABLE [dbo].[Volunteers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NameLastName] nvarchar(max)  NOT NULL,
    [DateBirth] datetime  NULL,
    [GenderVal] smallint  NOT NULL,
    [Occupation] nvarchar(max)  NOT NULL,
    [SpecificationsStr] nvarchar(max)  NOT NULL,
    [CoordinatesStr] nvarchar(max)  NOT NULL,
    [CoordinateLastUpdateTime] datetime  NOT NULL,
    [LastAccessTime] datetime  NOT NULL,
    [Address_Id] int  NOT NULL
);
GO

-- Creating table 'Requests'
CREATE TABLE [dbo].[Requests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [SearchAreaCoordinatesStr] nvarchar(max)  NOT NULL,
    [IncidentId] int  NOT NULL
);
GO

-- Creating table 'NeedItems'
CREATE TABLE [dbo].[NeedItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ItemType] nvarchar(max)  NOT NULL,
    [ItemAmount] float  NOT NULL,
    [MetricTypeVal] smallint  NOT NULL,
    [SuppliedAmount] float  NOT NULL,
    [RequestResponseId] int  NULL,
    [RequestId] int  NULL,
    [IncidentId] int  NULL
);
GO

-- Creating table 'RequestResponses'
CREATE TABLE [dbo].[RequestResponses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateShowed] datetime  NULL,
    [DateResponded] datetime  NULL,
    [Answer] varbinary(max)  NOT NULL,
    [StatusVal] smallint  NOT NULL,
    [Request_Id] int  NULL,
    [Volunteer_Id] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Crises'
ALTER TABLE [dbo].[Crises]
ADD CONSTRAINT [PK_Crises]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Alerts'
ALTER TABLE [dbo].[Alerts]
ADD CONSTRAINT [PK_Alerts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Incidents'
ALTER TABLE [dbo].[Incidents]
ADD CONSTRAINT [PK_Incidents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IncidentReports'
ALTER TABLE [dbo].[IncidentReports]
ADD CONSTRAINT [PK_IncidentReports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProgressReports'
ALTER TABLE [dbo].[ProgressReports]
ADD CONSTRAINT [PK_ProgressReports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Managers'
ALTER TABLE [dbo].[Managers]
ADD CONSTRAINT [PK_Managers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StuffItems'
ALTER TABLE [dbo].[StuffItems]
ADD CONSTRAINT [PK_StuffItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Volunteers'
ALTER TABLE [dbo].[Volunteers]
ADD CONSTRAINT [PK_Volunteers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Requests'
ALTER TABLE [dbo].[Requests]
ADD CONSTRAINT [PK_Requests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NeedItems'
ALTER TABLE [dbo].[NeedItems]
ADD CONSTRAINT [PK_NeedItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RequestResponses'
ALTER TABLE [dbo].[RequestResponses]
ADD CONSTRAINT [PK_RequestResponses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Crisis_Id] in table 'Alerts'
ALTER TABLE [dbo].[Alerts]
ADD CONSTRAINT [FK_Aso_AlertCrisis]
    FOREIGN KEY ([Crisis_Id])
    REFERENCES [dbo].[Crises]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Aso_AlertCrisis'
CREATE INDEX [IX_FK_Aso_AlertCrisis]
ON [dbo].[Alerts]
    ([Crisis_Id]);
GO

-- Creating foreign key on [RequestResponseId] in table 'NeedItems'
ALTER TABLE [dbo].[NeedItems]
ADD CONSTRAINT [FK_Aso_RequestResponseNeedItem]
    FOREIGN KEY ([RequestResponseId])
    REFERENCES [dbo].[RequestResponses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Aso_RequestResponseNeedItem'
CREATE INDEX [IX_FK_Aso_RequestResponseNeedItem]
ON [dbo].[NeedItems]
    ([RequestResponseId]);
GO

-- Creating foreign key on [Request_Id] in table 'RequestResponses'
ALTER TABLE [dbo].[RequestResponses]
ADD CONSTRAINT [FK_Aso_RequestResponseRequest]
    FOREIGN KEY ([Request_Id])
    REFERENCES [dbo].[Requests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Aso_RequestResponseRequest'
CREATE INDEX [IX_FK_Aso_RequestResponseRequest]
ON [dbo].[RequestResponses]
    ([Request_Id]);
GO

-- Creating foreign key on [Volunteer_Id] in table 'RequestResponses'
ALTER TABLE [dbo].[RequestResponses]
ADD CONSTRAINT [FK_Aso_RequestResponseVolunteer]
    FOREIGN KEY ([Volunteer_Id])
    REFERENCES [dbo].[Volunteers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Aso_RequestResponseVolunteer'
CREATE INDEX [IX_FK_Aso_RequestResponseVolunteer]
ON [dbo].[RequestResponses]
    ([Volunteer_Id]);
GO

-- Creating foreign key on [CrisisId] in table 'Incidents'
ALTER TABLE [dbo].[Incidents]
ADD CONSTRAINT [FK_Aso_CrisisIncident]
    FOREIGN KEY ([CrisisId])
    REFERENCES [dbo].[Crises]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Aso_CrisisIncident'
CREATE INDEX [IX_FK_Aso_CrisisIncident]
ON [dbo].[Incidents]
    ([CrisisId]);
GO

-- Creating foreign key on [Address_Id] in table 'Volunteers'
ALTER TABLE [dbo].[Volunteers]
ADD CONSTRAINT [FK_Aso_VolunteerAddress]
    FOREIGN KEY ([Address_Id])
    REFERENCES [dbo].[Addresses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Aso_VolunteerAddress'
CREATE INDEX [IX_FK_Aso_VolunteerAddress]
ON [dbo].[Volunteers]
    ([Address_Id]);
GO

-- Creating foreign key on [VolunteerId] in table 'StuffItems'
ALTER TABLE [dbo].[StuffItems]
ADD CONSTRAINT [FK_Aso_VolunteerStuffItem]
    FOREIGN KEY ([VolunteerId])
    REFERENCES [dbo].[Volunteers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Aso_VolunteerStuffItem'
CREATE INDEX [IX_FK_Aso_VolunteerStuffItem]
ON [dbo].[StuffItems]
    ([VolunteerId]);
GO

-- Creating foreign key on [VolunteerId] in table 'ProgressReports'
ALTER TABLE [dbo].[ProgressReports]
ADD CONSTRAINT [FK_Aso_VolunteerProgressReport]
    FOREIGN KEY ([VolunteerId])
    REFERENCES [dbo].[Volunteers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Aso_VolunteerProgressReport'
CREATE INDEX [IX_FK_Aso_VolunteerProgressReport]
ON [dbo].[ProgressReports]
    ([VolunteerId]);
GO

-- Creating foreign key on [Address_Id] in table 'Managers'
ALTER TABLE [dbo].[Managers]
ADD CONSTRAINT [FK_Aso_ManagerAddress]
    FOREIGN KEY ([Address_Id])
    REFERENCES [dbo].[Addresses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Aso_ManagerAddress'
CREATE INDEX [IX_FK_Aso_ManagerAddress]
ON [dbo].[Managers]
    ([Address_Id]);
GO

-- Creating foreign key on [IncidentId] in table 'ProgressReports'
ALTER TABLE [dbo].[ProgressReports]
ADD CONSTRAINT [FK_Aso_IncidentProgressReport]
    FOREIGN KEY ([IncidentId])
    REFERENCES [dbo].[Incidents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Aso_IncidentProgressReport'
CREATE INDEX [IX_FK_Aso_IncidentProgressReport]
ON [dbo].[ProgressReports]
    ([IncidentId]);
GO

-- Creating foreign key on [IncidentId] in table 'Requests'
ALTER TABLE [dbo].[Requests]
ADD CONSTRAINT [FK_Aso_IncidentRequest]
    FOREIGN KEY ([IncidentId])
    REFERENCES [dbo].[Incidents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Aso_IncidentRequest'
CREATE INDEX [IX_FK_Aso_IncidentRequest]
ON [dbo].[Requests]
    ([IncidentId]);
GO

-- Creating foreign key on [IncidentId] in table 'Alerts'
ALTER TABLE [dbo].[Alerts]
ADD CONSTRAINT [FK_Aso_IncidentAlert]
    FOREIGN KEY ([IncidentId])
    REFERENCES [dbo].[Incidents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Aso_IncidentAlert'
CREATE INDEX [IX_FK_Aso_IncidentAlert]
ON [dbo].[Alerts]
    ([IncidentId]);
GO

-- Creating foreign key on [RequestId] in table 'NeedItems'
ALTER TABLE [dbo].[NeedItems]
ADD CONSTRAINT [FK_Aso_RequestNeedItem]
    FOREIGN KEY ([RequestId])
    REFERENCES [dbo].[Requests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Aso_RequestNeedItem'
CREATE INDEX [IX_FK_Aso_RequestNeedItem]
ON [dbo].[NeedItems]
    ([RequestId]);
GO

-- Creating foreign key on [IncidentId] in table 'NeedItems'
ALTER TABLE [dbo].[NeedItems]
ADD CONSTRAINT [FK_Aso_IncidentNeedItem]
    FOREIGN KEY ([IncidentId])
    REFERENCES [dbo].[Incidents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Aso_IncidentNeedItem'
CREATE INDEX [IX_FK_Aso_IncidentNeedItem]
ON [dbo].[NeedItems]
    ([IncidentId]);
GO

-- Creating foreign key on [Volunteer_Id] in table 'IncidentReports'
ALTER TABLE [dbo].[IncidentReports]
ADD CONSTRAINT [FK_Aso_IncidentReportVolunteer]
    FOREIGN KEY ([Volunteer_Id])
    REFERENCES [dbo].[Volunteers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Aso_IncidentReportVolunteer'
CREATE INDEX [IX_FK_Aso_IncidentReportVolunteer]
ON [dbo].[IncidentReports]
    ([Volunteer_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------