CREATE TABLE [dbo].[PermissionEntities]
(
	[Id]   INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
	[PermissionName] NVARCHAR (max) NOT NULL,
	CONSTRAINT [PK_dbo.PermissionEntities] PRIMARY KEY CLUSTERED ([Id] ASC)
)
