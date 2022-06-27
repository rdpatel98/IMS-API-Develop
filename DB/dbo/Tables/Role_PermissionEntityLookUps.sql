CREATE TABLE [dbo].[Role_PermissionEntityLookUps]
(
	[Id]   INT IDENTITY(1,1) NOT NULL,
	[PermissionEntityLookUpId] INT NOT NULL,
	[RoleId] INT NOT NULL,
	CONSTRAINT [PK_dbo.Role_PermissionEntityLookUps] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_dbo.Role_PermissionEntityLookUps_dbo.PermissionEntityLookUps_PermissionEntityLookUpId] FOREIGN KEY ([PermissionEntityLookUpId]) REFERENCES [dbo].[PermissionEntityLookUps] ([Id]),
	CONSTRAINT [FK_dbo.Role_PermissionEntityLookUps_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
)
