
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/09/2016 14:04:57
-- Generated from EDMX file: C:\Users\Bwalters.COLLOID\Source\Repos\Slapp\Slashboard\Datality\BootyCheeks.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AshleyGrahamTest];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BlendFormulino]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Basses_Formulino] DROP CONSTRAINT [FK_BlendFormulino];
GO
IF OBJECT_ID(N'[dbo].[FK_RawFormulino]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Basses_Formulino] DROP CONSTRAINT [FK_RawFormulino];
GO
IF OBJECT_ID(N'[dbo].[FK_BrandPro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Basses_Pro] DROP CONSTRAINT [FK_BrandPro];
GO
IF OBJECT_ID(N'[dbo].[FK_BlendPro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Basses_Pro] DROP CONSTRAINT [FK_BlendPro];
GO
IF OBJECT_ID(N'[dbo].[FK_BlendSafety]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Basses_Blend] DROP CONSTRAINT [FK_BlendSafety];
GO
IF OBJECT_ID(N'[dbo].[FK_ChemicalToxicity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Basses_Toxicity] DROP CONSTRAINT [FK_ChemicalToxicity];
GO
IF OBJECT_ID(N'[dbo].[FK_Chemical_inherits_Bass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Basses_Chemical] DROP CONSTRAINT [FK_Chemical_inherits_Bass];
GO
IF OBJECT_ID(N'[dbo].[FK_Blend_inherits_Chemical]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Basses_Blend] DROP CONSTRAINT [FK_Blend_inherits_Chemical];
GO
IF OBJECT_ID(N'[dbo].[FK_Formulino_inherits_Bass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Basses_Formulino] DROP CONSTRAINT [FK_Formulino_inherits_Bass];
GO
IF OBJECT_ID(N'[dbo].[FK_Raw_inherits_Chemical]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Basses_Raw] DROP CONSTRAINT [FK_Raw_inherits_Chemical];
GO
IF OBJECT_ID(N'[dbo].[FK_Brand_inherits_Bass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Basses_Brand] DROP CONSTRAINT [FK_Brand_inherits_Bass];
GO
IF OBJECT_ID(N'[dbo].[FK_Pro_inherits_Bass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Basses_Pro] DROP CONSTRAINT [FK_Pro_inherits_Bass];
GO
IF OBJECT_ID(N'[dbo].[FK_Safety_inherits_Bass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Basses_Safety] DROP CONSTRAINT [FK_Safety_inherits_Bass];
GO
IF OBJECT_ID(N'[dbo].[FK_Toxicity_inherits_Bass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Basses_Toxicity] DROP CONSTRAINT [FK_Toxicity_inherits_Bass];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Basses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Basses];
GO
IF OBJECT_ID(N'[dbo].[Basses_Chemical]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Basses_Chemical];
GO
IF OBJECT_ID(N'[dbo].[Basses_Blend]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Basses_Blend];
GO
IF OBJECT_ID(N'[dbo].[Basses_Formulino]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Basses_Formulino];
GO
IF OBJECT_ID(N'[dbo].[Basses_Raw]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Basses_Raw];
GO
IF OBJECT_ID(N'[dbo].[Basses_Brand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Basses_Brand];
GO
IF OBJECT_ID(N'[dbo].[Basses_Pro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Basses_Pro];
GO
IF OBJECT_ID(N'[dbo].[Basses_Safety]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Basses_Safety];
GO
IF OBJECT_ID(N'[dbo].[Basses_Toxicity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Basses_Toxicity];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Basses'
CREATE TABLE [dbo].[Basses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Note] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Basses_Chemical'
CREATE TABLE [dbo].[Basses_Chemical] (
    [Name] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Basses_Blend'
CREATE TABLE [dbo].[Basses_Blend] (
    [Id] int  NOT NULL,
    [Safety_Id] int  NOT NULL
);
GO

-- Creating table 'Basses_Formulino'
CREATE TABLE [dbo].[Basses_Formulino] (
    [Low] nvarchar(max)  NOT NULL,
    [High] nvarchar(max)  NOT NULL,
    [Actual] nvarchar(max)  NOT NULL,
    [Range] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL,
    [Blend_Id] int  NOT NULL,
    [Raw_Id] int  NOT NULL
);
GO

-- Creating table 'Basses_Raw'
CREATE TABLE [dbo].[Basses_Raw] (
    [StockConcentration] int IDENTITY(1,1) NOT NULL,
    [Cas] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Basses_Brand'
CREATE TABLE [dbo].[Basses_Brand] (
    [Name] nvarchar(max)  NOT NULL,
    [FullName] nvarchar(max)  NOT NULL,
    [WebSite] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Basses_Pro'
CREATE TABLE [dbo].[Basses_Pro] (
    [Name] nvarchar(max)  NOT NULL,
    [Class] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [IssueDate] nvarchar(max)  NOT NULL,
    [RevisionDate] nvarchar(max)  NOT NULL,
    [Version] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL,
    [Brand_Id] int  NOT NULL,
    [Blend_Id] int  NOT NULL
);
GO

-- Creating table 'Basses_Safety'
CREATE TABLE [dbo].[Basses_Safety] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Basses_Toxicity'
CREATE TABLE [dbo].[Basses_Toxicity] (
    [Type] nvarchar(max)  NOT NULL,
    [Test] nvarchar(max)  NOT NULL,
    [Result] nvarchar(max)  NOT NULL,
    [Source] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL,
    [Chemical_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Basses'
ALTER TABLE [dbo].[Basses]
ADD CONSTRAINT [PK_Basses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Basses_Chemical'
ALTER TABLE [dbo].[Basses_Chemical]
ADD CONSTRAINT [PK_Basses_Chemical]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Basses_Blend'
ALTER TABLE [dbo].[Basses_Blend]
ADD CONSTRAINT [PK_Basses_Blend]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Basses_Formulino'
ALTER TABLE [dbo].[Basses_Formulino]
ADD CONSTRAINT [PK_Basses_Formulino]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Basses_Raw'
ALTER TABLE [dbo].[Basses_Raw]
ADD CONSTRAINT [PK_Basses_Raw]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Basses_Brand'
ALTER TABLE [dbo].[Basses_Brand]
ADD CONSTRAINT [PK_Basses_Brand]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Basses_Pro'
ALTER TABLE [dbo].[Basses_Pro]
ADD CONSTRAINT [PK_Basses_Pro]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Basses_Safety'
ALTER TABLE [dbo].[Basses_Safety]
ADD CONSTRAINT [PK_Basses_Safety]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Basses_Toxicity'
ALTER TABLE [dbo].[Basses_Toxicity]
ADD CONSTRAINT [PK_Basses_Toxicity]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Blend_Id] in table 'Basses_Formulino'
ALTER TABLE [dbo].[Basses_Formulino]
ADD CONSTRAINT [FK_BlendFormulino]
    FOREIGN KEY ([Blend_Id])
    REFERENCES [dbo].[Basses_Blend]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BlendFormulino'
CREATE INDEX [IX_FK_BlendFormulino]
ON [dbo].[Basses_Formulino]
    ([Blend_Id]);
GO

-- Creating foreign key on [Raw_Id] in table 'Basses_Formulino'
ALTER TABLE [dbo].[Basses_Formulino]
ADD CONSTRAINT [FK_RawFormulino]
    FOREIGN KEY ([Raw_Id])
    REFERENCES [dbo].[Basses_Raw]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RawFormulino'
CREATE INDEX [IX_FK_RawFormulino]
ON [dbo].[Basses_Formulino]
    ([Raw_Id]);
GO

-- Creating foreign key on [Brand_Id] in table 'Basses_Pro'
ALTER TABLE [dbo].[Basses_Pro]
ADD CONSTRAINT [FK_BrandPro]
    FOREIGN KEY ([Brand_Id])
    REFERENCES [dbo].[Basses_Brand]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BrandPro'
CREATE INDEX [IX_FK_BrandPro]
ON [dbo].[Basses_Pro]
    ([Brand_Id]);
GO

-- Creating foreign key on [Blend_Id] in table 'Basses_Pro'
ALTER TABLE [dbo].[Basses_Pro]
ADD CONSTRAINT [FK_BlendPro]
    FOREIGN KEY ([Blend_Id])
    REFERENCES [dbo].[Basses_Blend]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BlendPro'
CREATE INDEX [IX_FK_BlendPro]
ON [dbo].[Basses_Pro]
    ([Blend_Id]);
GO

-- Creating foreign key on [Safety_Id] in table 'Basses_Blend'
ALTER TABLE [dbo].[Basses_Blend]
ADD CONSTRAINT [FK_BlendSafety]
    FOREIGN KEY ([Safety_Id])
    REFERENCES [dbo].[Basses_Safety]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BlendSafety'
CREATE INDEX [IX_FK_BlendSafety]
ON [dbo].[Basses_Blend]
    ([Safety_Id]);
GO

-- Creating foreign key on [Chemical_Id] in table 'Basses_Toxicity'
ALTER TABLE [dbo].[Basses_Toxicity]
ADD CONSTRAINT [FK_ChemicalToxicity]
    FOREIGN KEY ([Chemical_Id])
    REFERENCES [dbo].[Basses_Chemical]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChemicalToxicity'
CREATE INDEX [IX_FK_ChemicalToxicity]
ON [dbo].[Basses_Toxicity]
    ([Chemical_Id]);
GO

-- Creating foreign key on [Id] in table 'Basses_Chemical'
ALTER TABLE [dbo].[Basses_Chemical]
ADD CONSTRAINT [FK_Chemical_inherits_Bass]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Basses]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Basses_Blend'
ALTER TABLE [dbo].[Basses_Blend]
ADD CONSTRAINT [FK_Blend_inherits_Chemical]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Basses_Chemical]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Basses_Formulino'
ALTER TABLE [dbo].[Basses_Formulino]
ADD CONSTRAINT [FK_Formulino_inherits_Bass]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Basses]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Basses_Raw'
ALTER TABLE [dbo].[Basses_Raw]
ADD CONSTRAINT [FK_Raw_inherits_Chemical]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Basses_Chemical]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Basses_Brand'
ALTER TABLE [dbo].[Basses_Brand]
ADD CONSTRAINT [FK_Brand_inherits_Bass]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Basses]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Basses_Pro'
ALTER TABLE [dbo].[Basses_Pro]
ADD CONSTRAINT [FK_Pro_inherits_Bass]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Basses]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Basses_Safety'
ALTER TABLE [dbo].[Basses_Safety]
ADD CONSTRAINT [FK_Safety_inherits_Bass]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Basses]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Basses_Toxicity'
ALTER TABLE [dbo].[Basses_Toxicity]
ADD CONSTRAINT [FK_Toxicity_inherits_Bass]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Basses]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------