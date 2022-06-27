CREATE TABLE [dbo].[PurchaseReceiveItems] (
    [PurchaseReceiveItemsId] INT           IDENTITY (1, 1) NOT NULL,
    [PurchaseReceiveId]      INT           NOT NULL,
    [LineNo]                 SMALLINT      CONSTRAINT [DF__PurchaseR__LineN__41EDCAC5] DEFAULT (NULL) NULL,
    [ItemId]                 INT           CONSTRAINT [DF__PurchaseR__ItemI__42E1EEFE] DEFAULT (NULL) NULL,
    [WarehouseId]            INT           CONSTRAINT [DF__PurchaseR__Wareh__43D61337] DEFAULT (NULL) NULL,
    [Quantity]               FLOAT (53)    CONSTRAINT [DF__PurchaseR__Quant__44CA3770] DEFAULT (NULL) NULL,
    [ReceiveQuantity]        FLOAT (53)    CONSTRAINT [DF__PurchaseR__Retur__45BE5BA9] DEFAULT (NULL) NULL,
    [UnitId]                 INT           CONSTRAINT [DF__PurchaseR__UnitI__46B27FE2] DEFAULT (NULL) NULL,
    [UnitPrice]              FLOAT (53)    CONSTRAINT [DF__PurchaseR__UnitP__47A6A41B] DEFAULT (NULL) NULL,
    [NetAmount]              FLOAT (53)    CONSTRAINT [DF__PurchaseR__NetAm__489AC854] DEFAULT (NULL) NULL,
    [BatchNo]                VARCHAR (10)  CONSTRAINT [DF__PurchaseR__Batch__498EEC8D] DEFAULT (NULL) NULL,
    [UpdatedUserId]          INT           CONSTRAINT [DF__PurchaseR__Updat__4A8310C6] DEFAULT (NULL) NULL,
    [UpdatedDateTime]        DATETIME2 (0) CONSTRAINT [DF__PurchaseR__Updat__4B7734FF] DEFAULT (NULL) NULL,
    [PurchaseOrderItemsId]   INT           DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK__Purchase__0AD1898BA1F05BF4] PRIMARY KEY CLUSTERED ([PurchaseReceiveItemsId] ASC),
    CONSTRAINT [FK_PurchaseReturnItems_Items] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Items] ([ItemId]) NOT FOR REPLICATION,
    CONSTRAINT [FK_PurchaseReturnItems_PurchaseReturn] FOREIGN KEY ([PurchaseReceiveId]) REFERENCES [dbo].[PurchaseReceive] ([PurchaseReceiveId]),
    CONSTRAINT [FK_PurchaseReturnItems_UomConversion] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[UomConversion] ([Id]),
    CONSTRAINT [FK_PurchaseReturnItems_Warehouse] FOREIGN KEY ([WarehouseId]) REFERENCES [dbo].[Warehouse] ([WarehouseId]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[PurchaseReceiveItems] NOCHECK CONSTRAINT [FK_PurchaseReturnItems_Items];


GO
ALTER TABLE [dbo].[PurchaseReceiveItems] NOCHECK CONSTRAINT [FK_PurchaseReturnItems_Warehouse];

