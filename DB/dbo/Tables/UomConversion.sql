CREATE TABLE [dbo].[UomConversion] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (10) NULL,
    [Description]    VARCHAR (60) CONSTRAINT [DF__UomConver__Descr__58D1301D] DEFAULT (NULL) NULL,
    [FromUnitId]     INT          CONSTRAINT [DF__UomConver__FromU__59C55456] DEFAULT (NULL) NULL,
    [ToUnitId]       INT          CONSTRAINT [DF__UomConver__ToUni__5AB9788F] DEFAULT (NULL) NULL,
    [Ratio]          FLOAT (53)   CONSTRAINT [DF__UomConver__Ratio__5BAD9CC8] DEFAULT (NULL) NULL,
    [OrganizationId] INT          NULL,
    CONSTRAINT [PK__UomConve__3214EC076F54833D] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UomConversion_UomFromUnitId] FOREIGN KEY ([FromUnitId]) REFERENCES [dbo].[Unit] ([Id]) NOT FOR REPLICATION,
    CONSTRAINT [FK_UomConversion_UomToUnitId] FOREIGN KEY ([ToUnitId]) REFERENCES [dbo].[Unit] ([Id]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[UomConversion] NOCHECK CONSTRAINT [FK_UomConversion_UomFromUnitId];


GO
ALTER TABLE [dbo].[UomConversion] NOCHECK CONSTRAINT [FK_UomConversion_UomToUnitId];

