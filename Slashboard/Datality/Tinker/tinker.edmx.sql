
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/08/2016 12:57:22
-- Generated from EDMX file: C:\Users\Bwalters.COLLOID\Source\Repos\Slapp\Slashboard\Datality\tinker.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Tinker];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PersonButt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[People] DROP CONSTRAINT [FK_PersonButt];
GO
IF OBJECT_ID(N'[dbo].[FK_ButtCheek]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MirrorOrgans_Cheek] DROP CONSTRAINT [FK_ButtCheek];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonFeet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MirrorOrgans_Feet] DROP CONSTRAINT [FK_PersonFeet];
GO
IF OBJECT_ID(N'[dbo].[FK_Cheek_inherits_MirrorOrgan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MirrorOrgans_Cheek] DROP CONSTRAINT [FK_Cheek_inherits_MirrorOrgan];
GO
IF OBJECT_ID(N'[dbo].[FK_Feet_inherits_MirrorOrgan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MirrorOrgans_Feet] DROP CONSTRAINT [FK_Feet_inherits_MirrorOrgan];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[People]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People];
GO
IF OBJECT_ID(N'[dbo].[Butts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Butts];
GO
IF OBJECT_ID(N'[dbo].[MirrorOrgans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MirrorOrgans];
GO
IF OBJECT_ID(N'[dbo].[MirrorOrgans_Cheek]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MirrorOrgans_Cheek];
GO
IF OBJECT_ID(N'[dbo].[MirrorOrgans_Feet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MirrorOrgans_Feet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Butt_Id] int  NOT NULL
);
GO

-- Creating table 'Butts'
CREATE TABLE [dbo].[Butts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BootyFactor] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MirrorOrgans'
CREATE TABLE [dbo].[MirrorOrgans] (
    [WhichSide] nvarchar(max)  NOT NULL,
    [Id] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MirrorOrgans_Cheek'
CREATE TABLE [dbo].[MirrorOrgans_Cheek] (
    [TattooCount] nvarchar(max)  NOT NULL,
    [Id] nvarchar(max)  NOT NULL,
    [Butt_Id] int  NOT NULL
);
GO

-- Creating table 'MirrorOrgans_Feet'
CREATE TABLE [dbo].[MirrorOrgans_Feet] (
    [Shoe] nvarchar(max)  NOT NULL,
    [Id] nvarchar(max)  NOT NULL,
    [Person_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Butts'
ALTER TABLE [dbo].[Butts]
ADD CONSTRAINT [PK_Butts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MirrorOrgans'
ALTER TABLE [dbo].[MirrorOrgans]
ADD CONSTRAINT [PK_MirrorOrgans]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MirrorOrgans_Cheek'
ALTER TABLE [dbo].[MirrorOrgans_Cheek]
ADD CONSTRAINT [PK_MirrorOrgans_Cheek]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MirrorOrgans_Feet'
ALTER TABLE [dbo].[MirrorOrgans_Feet]
ADD CONSTRAINT [PK_MirrorOrgans_Feet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Butt_Id] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [FK_PersonButt]
    FOREIGN KEY ([Butt_Id])
    REFERENCES [dbo].[Butts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonButt'
CREATE INDEX [IX_FK_PersonButt]
ON [dbo].[People]
    ([Butt_Id]);
GO

-- Creating foreign key on [Butt_Id] in table 'MirrorOrgans_Cheek'
ALTER TABLE [dbo].[MirrorOrgans_Cheek]
ADD CONSTRAINT [FK_ButtCheek]
    FOREIGN KEY ([Butt_Id])
    REFERENCES [dbo].[Butts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ButtCheek'
CREATE INDEX [IX_FK_ButtCheek]
ON [dbo].[MirrorOrgans_Cheek]
    ([Butt_Id]);
GO

-- Creating foreign key on [Person_Id] in table 'MirrorOrgans_Feet'
ALTER TABLE [dbo].[MirrorOrgans_Feet]
ADD CONSTRAINT [FK_PersonFeet]
    FOREIGN KEY ([Person_Id])
    REFERENCES [dbo].[People]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonFeet'
CREATE INDEX [IX_FK_PersonFeet]
ON [dbo].[MirrorOrgans_Feet]
    ([Person_Id]);
GO

-- Creating foreign key on [Id] in table 'MirrorOrgans_Cheek'
ALTER TABLE [dbo].[MirrorOrgans_Cheek]
ADD CONSTRAINT [FK_Cheek_inherits_MirrorOrgan]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[MirrorOrgans]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'MirrorOrgans_Feet'
ALTER TABLE [dbo].[MirrorOrgans_Feet]
ADD CONSTRAINT [FK_Feet_inherits_MirrorOrgan]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[MirrorOrgans]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------