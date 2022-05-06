CREATE TABLE [dbo].[Items] (
    [ItemId]          INT           IDENTITY (1, 1) NOT NULL,
    [Id]              VARCHAR (10)  CONSTRAINT [DF__Items__Id__151B244E] DEFAULT (NULL) NULL,
    [ItemNo]          VARCHAR (20)  CONSTRAINT [DF__Items__ItemNo__160F4887] DEFAULT (NULL) NULL,
    [Name]            VARCHAR (60)  CONSTRAINT [DF__Items__Name__17036CC0] DEFAULT (NULL) NULL,
    [Description]     VARCHAR (MAX) CONSTRAINT [DF__Items__Descripti__17F790F9] DEFAULT (NULL) NULL,
    [PurchaseUnitId]  INT           CONSTRAINT [DF__Items__PurchaseU__18EBB532] DEFAULT (NULL) NULL,
    [InventoryUnitId] INT           CONSTRAINT [DF__Items__Inventory__19DFD96B] DEFAULT (NULL) NULL,
    [MinStock]        FLOAT (53)    CONSTRAINT [DF__Items__MinStock__1AD3FDA4] DEFAULT (NULL) NULL,
    [MaxStock]        FLOAT (53)    CONSTRAINT [DF__Items__MaxStock__1BC821DD] DEFAULT (NULL) NULL,
    [UpdatedUserId]   INT           CONSTRAINT [DF__Items__UpdatedUs__1CBC4616] DEFAULT (NULL) NULL,
    [UpdatedDateTime] DATETIME2 (0) CONSTRAINT [DF__Items__UpdatedDa__1DB06A4F] DEFAULT (NULL) NULL,
    [Status]          SMALLINT      NOT NULL,
    [SourceOfOrigin]  INT           NULL,
    [OrganizationId]  INT           NULL,
    CONSTRAINT [PK__Items__727E838B4386E4BD] PRIMARY KEY CLUSTERED ([ItemId] ASC),
    CONSTRAINT [FK_Items_UomConversion_InventoryUnitId] FOREIGN KEY ([InventoryUnitId]) REFERENCES [dbo].[UomConversion] ([Id]) NOT FOR REPLICATION,
    CONSTRAINT [FK_Items_UomConversion_PurchaseUnitId] FOREIGN KEY ([PurchaseUnitId]) REFERENCES [dbo].[UomConversion] ([Id]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[Items] NOCHECK CONSTRAINT [FK_Items_UomConversion_InventoryUnitId];


GO
ALTER TABLE [dbo].[Items] NOCHECK CONSTRAINT [FK_Items_UomConversion_PurchaseUnitId];

