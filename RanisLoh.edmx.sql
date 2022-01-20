
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/03/2021 02:53:39
-- Generated from EDMX file: E:\oaip8\oaip5\RanisLoh.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [G:\oaip8\oaip5\bin\Debug\UserDB.mdf];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProfessorThesis]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ThesisSet] DROP CONSTRAINT [FK_ProfessorThesis];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentProfessor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentSet] DROP CONSTRAINT [FK_StudentProfessor];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentThesis]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ThesisSet] DROP CONSTRAINT [FK_StudentThesis];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersSet] DROP CONSTRAINT [FK_StudentUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersProfessor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfessorSet] DROP CONSTRAINT [FK_UsersProfessor];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ProfessorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfessorSet];
GO
IF OBJECT_ID(N'[dbo].[StudentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentSet];
GO
IF OBJECT_ID(N'[dbo].[ThesisSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ThesisSet];
GO
IF OBJECT_ID(N'[dbo].[UsersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UsersSet'
CREATE TABLE [dbo].[UsersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Role] nvarchar(max)  NOT NULL,
    [Student_Id] int  NULL
);
GO

-- Creating table 'ProfessorSet'
CREATE TABLE [dbo].[ProfessorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Position] nvarchar(max)  NOT NULL,
    [PersonalData] nvarchar(max)  NULL,
    [Photo] varbinary(max)  NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Otchestvo] nvarchar(max)  NULL,
    [SocialNtork] nvarchar(max)  NULL,
    [Users_Id] int  NULL
);
GO

-- Creating table 'ThesisSet'
CREATE TABLE [dbo].[ThesisSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Annotation] nvarchar(max)  NOT NULL,
    [Professor_Id] int  NOT NULL,
    [Student_Id] int  NULL
);
GO

-- Creating table 'StudentSet'
CREATE TABLE [dbo].[StudentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [NumberGroup] nvarchar(max)  NOT NULL,
    [PersonalData] nvarchar(max)  NULL,
    [Photo] varbinary(max)  NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Otchestvo] nvarchar(max)  NULL,
    [Specialization] nvarchar(max)  NULL,
    [SocialNetork] nvarchar(max)  NULL,
    [Professor_Id] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UsersSet'
ALTER TABLE [dbo].[UsersSet]
ADD CONSTRAINT [PK_UsersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProfessorSet'
ALTER TABLE [dbo].[ProfessorSet]
ADD CONSTRAINT [PK_ProfessorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ThesisSet'
ALTER TABLE [dbo].[ThesisSet]
ADD CONSTRAINT [PK_ThesisSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentSet'
ALTER TABLE [dbo].[StudentSet]
ADD CONSTRAINT [PK_StudentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Student_Id] in table 'UsersSet'
ALTER TABLE [dbo].[UsersSet]
ADD CONSTRAINT [FK_StudentUsers]
    FOREIGN KEY ([Student_Id])
    REFERENCES [dbo].[StudentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentUsers'
CREATE INDEX [IX_FK_StudentUsers]
ON [dbo].[UsersSet]
    ([Student_Id]);
GO

-- Creating foreign key on [Professor_Id] in table 'StudentSet'
ALTER TABLE [dbo].[StudentSet]
ADD CONSTRAINT [FK_StudentProfessor]
    FOREIGN KEY ([Professor_Id])
    REFERENCES [dbo].[ProfessorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentProfessor'
CREATE INDEX [IX_FK_StudentProfessor]
ON [dbo].[StudentSet]
    ([Professor_Id]);
GO

-- Creating foreign key on [Professor_Id] in table 'ThesisSet'
ALTER TABLE [dbo].[ThesisSet]
ADD CONSTRAINT [FK_ProfessorThesis]
    FOREIGN KEY ([Professor_Id])
    REFERENCES [dbo].[ProfessorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfessorThesis'
CREATE INDEX [IX_FK_ProfessorThesis]
ON [dbo].[ThesisSet]
    ([Professor_Id]);
GO

-- Creating foreign key on [Users_Id] in table 'ProfessorSet'
ALTER TABLE [dbo].[ProfessorSet]
ADD CONSTRAINT [FK_UsersProfessor]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[UsersSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersProfessor'
CREATE INDEX [IX_FK_UsersProfessor]
ON [dbo].[ProfessorSet]
    ([Users_Id]);
GO

-- Creating foreign key on [Student_Id] in table 'ThesisSet'
ALTER TABLE [dbo].[ThesisSet]
ADD CONSTRAINT [FK_StudentThesis]
    FOREIGN KEY ([Student_Id])
    REFERENCES [dbo].[StudentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentThesis'
CREATE INDEX [IX_FK_StudentThesis]
ON [dbo].[ThesisSet]
    ([Student_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------