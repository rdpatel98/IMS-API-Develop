CREATE TABLE [dbo].[Unit] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (60) CONSTRAINT [DF__Uom__Name__57DD0BE4] DEFAULT (NULL) NULL,
    [OrganizationId] INT          NULL,
    CONSTRAINT [PK__Uom__3214EC074140BB3F] PRIMARY KEY CLUSTERED ([Id] ASC)
);

