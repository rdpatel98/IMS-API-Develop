CREATE TABLE [dbo].[PermissionEntityLookUps]
(
	[Id]   INT IDENTITY(1,1) NOT NULL,
	[PermissionEntityId] INT NOT NULL,
	[LookupId] INT NOT NULL,
	CONSTRAINT [PK_dbo.PermissionEntityLookUps] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_dbo.PermissionEntityLookUps_dbo.PermissionEntities_PermissionEntityId] FOREIGN KEY ([PermissionEntityId]) REFERENCES [dbo].[PermissionEntities] ([Id]),
    CONSTRAINT [FK_dbo.PermissionEntityLookUps_dbo.Lookups_LookupId] FOREIGN KEY ([LookupId]) REFERENCES [dbo].[Lookups] ([Id])
)
