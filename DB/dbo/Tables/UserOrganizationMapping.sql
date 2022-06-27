CREATE TABLE [dbo].[UserOrganizations]
(
	[Id]   INT IDENTITY(1,1) NOT NULL,
	[UserId] INT NOT NULL,
	[OrganizationId] INT NOT NULL,
	CONSTRAINT [PK_dbo.UserOrganizations] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_dbo.UserOrganizations_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_dbo.UserOrganizations_dbo.Organization_OrganizationId] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([OrganizationId])
)