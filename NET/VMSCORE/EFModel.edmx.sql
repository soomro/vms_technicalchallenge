-- --------------------------------------------------
-- Date Created: 03/21/2010 22:39:43
-- Generated from EDMX file: D:\apollovms\NET\VMSCORE\EFModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
GO

USE [vmsdb]
GO
IF SCHEMA_ID('dbo') IS NULL EXECUTE('CREATE SCHEMA [dbo]')
GO

-- --------------------------------------------------
-- Dropping existing FK constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CrisisSet'
CREATE TABLE [dbo].[CrisisSet] (
    [Id] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Explanation] nvarchar(max)  NOT NULL,
    [Status] smallint  NOT NULL,
    [CrisisType] smallint  NOT NULL,
    [LocationType] nvarchar(max)  NOT NULL,
    [LocationCoordinatesStr] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [DateClosed] datetime  NULL
);
GO
-- Creating table 'IncidentSet'
CREATE TABLE [dbo].[IncidentSet] (
    [Id] int  NOT NULL,
    [ShortDescription] nvarchar(max)  NOT NULL,
    [LocationType] smallint  NOT NULL,
    [LocationCoordinates] nvarchar(max)  NOT NULL,
    [Explanation] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [DateClosed] datetime  NULL,
    [Severity] smallint  NOT NULL,
    [IncidentType] smallint  NOT NULL,
    [IncidentStatus] smallint  NOT NULL,
    [ShortAddress] nvarchar(max)  NOT NULL,
    [Crisis_Id] int  NOT NULL
);
GO
-- Creating table 'VolunteerSet'
CREATE TABLE [dbo].[VolunteerSet] (
    [Id] int  NOT NULL,
    [NameLastName] nvarchar(max)  NOT NULL,
    [DateBirth] datetime  NULL,
    [Gender] smallint  NOT NULL,
    [Occupation] nvarchar(max)  NOT NULL,
    [Specifications] nvarchar(max)  NOT NULL,
    [Coordinates] nvarchar(max)  NOT NULL,
    [CoordinateLastUpdateTime] datetime  NOT NULL,
    [LastAccessTime] datetime  NOT NULL,
    [Address_Id] int  NOT NULL
);
GO
-- Creating table 'AddressSet'
CREATE TABLE [dbo].[AddressSet] (
    [Id] int  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [FlatNumber] nvarchar(max)  NOT NULL,
    [HouseNumber] nvarchar(max)  NOT NULL,
    [PostalCode] nvarchar(max)  NOT NULL,
    [Street] nvarchar(max)  NOT NULL
);
GO
-- Creating table 'AlertSet'
CREATE TABLE [dbo].[AlertSet] (
    [Id] int  NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [SearchCriteria] nvarchar(max)  NOT NULL,
    [DateSent] datetime  NOT NULL,
    [Crisis_Id] int  NOT NULL
);
GO
-- Creating table 'IncidentReportSet'
CREATE TABLE [dbo].[IncidentReportSet] (
    [Id] int  NOT NULL,
    [IncidentType] smallint  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ImageFile] nvarchar(max)  NOT NULL,
    [VideoFile] nvarchar(max)  NOT NULL,
    [Location] nvarchar(max)  NOT NULL,
    [LocationCoordinates] nvarchar(max)  NOT NULL,
    [Incident_Id] int  NOT NULL
);
GO
-- Creating table 'ManagerSet'
CREATE TABLE [dbo].[ManagerSet] (
    [Id] int  NOT NULL,
    [NameLastName] nvarchar(max)  NOT NULL,
    [ExpertiseCrisisTypes] nvarchar(max)  NOT NULL,
    [DateBirth] datetime  NOT NULL,
    [Gender] smallint  NOT NULL,
    [Address_Id] int  NOT NULL
);
GO
-- Creating table 'NeedItemSet'
CREATE TABLE [dbo].[NeedItemSet] (
    [Id] bigint  NOT NULL,
    [ItemType] nvarchar(max)  NOT NULL,
    [ItemAmount] nvarchar(max)  NOT NULL,
    [MetricType] smallint  NOT NULL,
    [SuppliedAmount] float  NOT NULL,
    [Request_Id] int  NULL,
    [RequestResponse_Id] int  NULL,
    [Incident_Id] int  NULL
);
GO
-- Creating table 'ProgressReportSet'
CREATE TABLE [dbo].[ProgressReportSet] (
    [Id] int  NOT NULL,
    [ReportText] nvarchar(max)  NOT NULL,
    [ImageFile] nvarchar(max)  NOT NULL,
    [VideoFile] nvarchar(max)  NOT NULL,
    [Status] smallint  NOT NULL,
    [Volunteer_Id] int  NOT NULL,
    [Incident_Id] int  NOT NULL
);
GO
-- Creating table 'RequestSet'
CREATE TABLE [dbo].[RequestSet] (
    [Id] int  NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [SearchAreaCoordinates] nvarchar(max)  NOT NULL,
    [Incident_Id] int  NOT NULL
);
GO
-- Creating table 'RequestResponseSet'
CREATE TABLE [dbo].[RequestResponseSet] (
    [Id] int  NOT NULL,
    [DateShowed] datetime  NULL,
    [DateResponded] datetime  NULL,
    [Answer] varbinary(max)  NOT NULL,
    [Status] smallint  NOT NULL,
    [Volunteer_Id] int  NOT NULL,
    [Request_Id] int  NOT NULL
);
GO
-- Creating table 'StuffItemSet'
CREATE TABLE [dbo].[StuffItemSet] (
    [Id] int  NOT NULL,
    [ItemType] nvarchar(max)  NOT NULL,
    [MetricType] smallint  NOT NULL,
    [Amount] smallint  NOT NULL,
    [Volunteer_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all Primary Key Constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CrisisSet'
ALTER TABLE [dbo].[CrisisSet] WITH NOCHECK
ADD CONSTRAINT [PK_CrisisSet]
    PRIMARY KEY CLUSTERED ([Id] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Id] in table 'IncidentSet'
ALTER TABLE [dbo].[IncidentSet] WITH NOCHECK
ADD CONSTRAINT [PK_IncidentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Id] in table 'VolunteerSet'
ALTER TABLE [dbo].[VolunteerSet] WITH NOCHECK
ADD CONSTRAINT [PK_VolunteerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Id] in table 'AddressSet'
ALTER TABLE [dbo].[AddressSet] WITH NOCHECK
ADD CONSTRAINT [PK_AddressSet]
    PRIMARY KEY CLUSTERED ([Id] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Id] in table 'AlertSet'
ALTER TABLE [dbo].[AlertSet] WITH NOCHECK
ADD CONSTRAINT [PK_AlertSet]
    PRIMARY KEY CLUSTERED ([Id] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Id] in table 'IncidentReportSet'
ALTER TABLE [dbo].[IncidentReportSet] WITH NOCHECK
ADD CONSTRAINT [PK_IncidentReportSet]
    PRIMARY KEY CLUSTERED ([Id] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Id] in table 'ManagerSet'
ALTER TABLE [dbo].[ManagerSet] WITH NOCHECK
ADD CONSTRAINT [PK_ManagerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Id] in table 'NeedItemSet'
ALTER TABLE [dbo].[NeedItemSet] WITH NOCHECK
ADD CONSTRAINT [PK_NeedItemSet]
    PRIMARY KEY CLUSTERED ([Id] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Id] in table 'ProgressReportSet'
ALTER TABLE [dbo].[ProgressReportSet] WITH NOCHECK
ADD CONSTRAINT [PK_ProgressReportSet]
    PRIMARY KEY CLUSTERED ([Id] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Id] in table 'RequestSet'
ALTER TABLE [dbo].[RequestSet] WITH NOCHECK
ADD CONSTRAINT [PK_RequestSet]
    PRIMARY KEY CLUSTERED ([Id] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Id] in table 'RequestResponseSet'
ALTER TABLE [dbo].[RequestResponseSet] WITH NOCHECK
ADD CONSTRAINT [PK_RequestResponseSet]
    PRIMARY KEY CLUSTERED ([Id] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Id] in table 'StuffItemSet'
ALTER TABLE [dbo].[StuffItemSet] WITH NOCHECK
ADD CONSTRAINT [PK_StuffItemSet]
    PRIMARY KEY CLUSTERED ([Id] ASC)
    ON [PRIMARY]
GO

-- --------------------------------------------------
-- Creating all Foreign Key Constraints
-- --------------------------------------------------

-- Creating foreign key on [Crisis_Id] in table 'AlertSet'
ALTER TABLE [dbo].[AlertSet] WITH NOCHECK
ADD CONSTRAINT [FK_CrisisAlert]
    FOREIGN KEY ([Crisis_Id])
    REFERENCES [dbo].[CrisisSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Crisis_Id] in table 'IncidentSet'
ALTER TABLE [dbo].[IncidentSet] WITH NOCHECK
ADD CONSTRAINT [FK_CrisisIncident]
    FOREIGN KEY ([Crisis_Id])
    REFERENCES [dbo].[CrisisSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Incident_Id] in table 'IncidentReportSet'
ALTER TABLE [dbo].[IncidentReportSet] WITH NOCHECK
ADD CONSTRAINT [FK_IncidentIncidentReport]
    FOREIGN KEY ([Incident_Id])
    REFERENCES [dbo].[IncidentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Address_Id] in table 'ManagerSet'
ALTER TABLE [dbo].[ManagerSet] WITH NOCHECK
ADD CONSTRAINT [FK_ManagerAddress]
    FOREIGN KEY ([Address_Id])
    REFERENCES [dbo].[AddressSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Volunteer_Id] in table 'ProgressReportSet'
ALTER TABLE [dbo].[ProgressReportSet] WITH NOCHECK
ADD CONSTRAINT [FK_ProgressReportVolunteer]
    FOREIGN KEY ([Volunteer_Id])
    REFERENCES [dbo].[VolunteerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Incident_Id] in table 'ProgressReportSet'
ALTER TABLE [dbo].[ProgressReportSet] WITH NOCHECK
ADD CONSTRAINT [FK_ProgressReportIncident]
    FOREIGN KEY ([Incident_Id])
    REFERENCES [dbo].[IncidentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Incident_Id] in table 'RequestSet'
ALTER TABLE [dbo].[RequestSet] WITH NOCHECK
ADD CONSTRAINT [FK_RequestIncident]
    FOREIGN KEY ([Incident_Id])
    REFERENCES [dbo].[IncidentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Request_Id] in table 'NeedItemSet'
ALTER TABLE [dbo].[NeedItemSet] WITH NOCHECK
ADD CONSTRAINT [FK_RequestNeedItem]
    FOREIGN KEY ([Request_Id])
    REFERENCES [dbo].[RequestSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Volunteer_Id] in table 'RequestResponseSet'
ALTER TABLE [dbo].[RequestResponseSet] WITH NOCHECK
ADD CONSTRAINT [FK_RequestResponseVolunteer]
    FOREIGN KEY ([Volunteer_Id])
    REFERENCES [dbo].[VolunteerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Request_Id] in table 'RequestResponseSet'
ALTER TABLE [dbo].[RequestResponseSet] WITH NOCHECK
ADD CONSTRAINT [FK_RequestResponseRequest]
    FOREIGN KEY ([Request_Id])
    REFERENCES [dbo].[RequestSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Address_Id] in table 'VolunteerSet'
ALTER TABLE [dbo].[VolunteerSet] WITH NOCHECK
ADD CONSTRAINT [FK_VolunteerAddress]
    FOREIGN KEY ([Address_Id])
    REFERENCES [dbo].[AddressSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Volunteer_Id] in table 'StuffItemSet'
ALTER TABLE [dbo].[StuffItemSet] WITH NOCHECK
ADD CONSTRAINT [FK_VolunteerStuffItem]
    FOREIGN KEY ([Volunteer_Id])
    REFERENCES [dbo].[VolunteerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [RequestResponse_Id] in table 'NeedItemSet'
ALTER TABLE [dbo].[NeedItemSet] WITH NOCHECK
ADD CONSTRAINT [FK_RequestResponseNeedItem]
    FOREIGN KEY ([RequestResponse_Id])
    REFERENCES [dbo].[RequestResponseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Incident_Id] in table 'NeedItemSet'
ALTER TABLE [dbo].[NeedItemSet] WITH NOCHECK
ADD CONSTRAINT [FK_NeedItemIncident]
    FOREIGN KEY ([Incident_Id])
    REFERENCES [dbo].[IncidentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

