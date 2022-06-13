
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/13/2022 11:37:39
-- Generated from EDMX file: C:\Users\leman\Desktop\Новая папка (4)\HoveWork17\HoveWork17\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MSSQLLocalDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[InfoTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InfoTable];
GO
IF OBJECT_ID(N'[dbo].[ObjectsInfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ObjectsInfoSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'InfoTable'
CREATE TABLE [dbo].[InfoTable] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Surname] nvarchar(20)  NOT NULL,
    [NAME] nvarchar(20)  NOT NULL,
    [LASTNAME] nvarchar(max)  NOT NULL,
    [NUMBER] nvarchar(max)  NULL,
    [EMAIL] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ObjectsInfoSet'
CREATE TABLE [dbo].[ObjectsInfoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Cod] int  NOT NULL,
    [objectName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id], [Surname], [NAME] in table 'InfoTable'
ALTER TABLE [dbo].[InfoTable]
ADD CONSTRAINT [PK_InfoTable]
    PRIMARY KEY CLUSTERED ([Id], [Surname], [NAME] ASC);
GO

-- Creating primary key on [Id] in table 'ObjectsInfoSet'
ALTER TABLE [dbo].[ObjectsInfoSet]
ADD CONSTRAINT [PK_ObjectsInfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------