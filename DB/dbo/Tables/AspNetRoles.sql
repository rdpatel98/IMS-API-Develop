CREATE TABLE [dbo].[AspNetRoles] (
    [Id]   INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    [OrganizationId] INT NULL, 
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AspNetRoles_dbo.Organization_OrganizationId] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([OrganizationId]) 
);