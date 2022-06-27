CREATE TABLE [dbo].[ConsumptionItems] (
    [ConsumptionItemsId] INT           IDENTITY (1, 1) NOT NULL,
    [LineNo]             SMALLINT      CONSTRAINT [DF__Consumpti__LineN__693CA210] DEFAULT (NULL) NULL,
    [ItemId]             INT           CONSTRAINT [DF__Consumpti__ItemI__6A30C649] DEFAULT (NULL) NULL,
    [UnitId]             INT           CONSTRAINT [DF__Consumpti__UnitI__6B24EA82] DEFAULT (NULL) NULL,
    [Quantity]           FLOAT (53)    CONSTRAINT [DF__Consumpti__Quant__6C190EBB] DEFAULT (NULL) NULL,
    [UpdatedUserId]      INT           CONSTRAINT [DF__Consumpti__Updat__6D0D32F4] DEFAULT (NULL) NULL,
    [UpdatedDateTime]    DATETIME2 (0) CONSTRAINT [DF__Consumpti__Updat__6E01572D] DEFAULT (NULL) NULL,
    [ConsumptionId]      INT           CONSTRAINT [DF__Consumpti__Consu__6EF57B66] DEFAULT (NULL) NULL,
    CONSTRAINT [PK__Consumpt__7E427DCF82DC8827] PRIMARY KEY CLUSTERED ([ConsumptionItemsId] ASC),
    CONSTRAINT [FK_ConsumptionItems_Consumption] FOREIGN KEY ([ConsumptionId]) REFERENCES [dbo].[Consumption] ([ConsumptionId]),
    CONSTRAINT [FK_ConsumptionItems_Items] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Items] ([ItemId]) NOT FOR REPLICATION,
    CONSTRAINT [FK_ConsumptionItems_UomConversion] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[UomConversion] ([Id])
);


GO
ALTER TABLE [dbo].[ConsumptionItems] NOCHECK CONSTRAINT [FK_ConsumptionItems_Items];

