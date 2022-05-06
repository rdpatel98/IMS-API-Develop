CREATE TABLE [dbo].[PurchaseOrderItems] (
    [PurchaseOrderItemsId] INT           IDENTITY (1, 1) NOT NULL,
    [PurchaseOrderId]      INT           NOT NULL,
    [LineNo]               SMALLINT      CONSTRAINT [DF__PurchaseO__LineN__41EDCAC5] DEFAULT (NULL) NULL,
    [ItemId]               INT           CONSTRAINT [DF__PurchaseO__ItemI__42E1EEFE] DEFAULT (NULL) NULL,
    [WarehouseId]          INT           CONSTRAINT [DF__PurchaseO__Wareh__43D61337] DEFAULT (NULL) NULL,
    [Quantity]             FLOAT (53)    CONSTRAINT [DF__PurchaseO__Quant__44CA3770] DEFAULT (NULL) NULL,
    [UnitId]               INT           CONSTRAINT [DF__PurchaseO__UnitI__45BE5BA9] DEFAULT (NULL) NULL,
    [UnitPrice]            FLOAT (53)    CONSTRAINT [DF__PurchaseO__UnitP__46B27FE2] DEFAULT (NULL) NULL,
    [NetAmount]            FLOAT (53)    CONSTRAINT [DF__PurchaseO__NetAm__47A6A41B] DEFAULT (NULL) NULL,
    [UpdatedUserId]        INT           CONSTRAINT [DF__PurchaseO__Updat__489AC854] DEFAULT (NULL) NULL,
    [UpdatedDateTime]      DATETIME2 (0) CONSTRAINT [DF__PurchaseO__Updat__498EEC8D] DEFAULT (NULL) NULL,
    CONSTRAINT [PK__Purchase__C4E0F5CCD4FBC3FA] PRIMARY KEY CLUSTERED ([PurchaseOrderItemsId] ASC),
    CONSTRAINT [FK_PurchaseOrderItems_Items] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Items] ([ItemId]) NOT FOR REPLICATION,
    CONSTRAINT [FK_PurchaseOrderItems_Purchaseorder] FOREIGN KEY ([PurchaseOrderId]) REFERENCES [dbo].[PurchaseOrder] ([PurchaseOrderId]),
    CONSTRAINT [FK_PurchaseOrderItems_UomConversion] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[UomConversion] ([Id]),
    CONSTRAINT [FK_PurchaseOrderItems_Warehouse] FOREIGN KEY ([WarehouseId]) REFERENCES [dbo].[Warehouse] ([WarehouseId]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[PurchaseOrderItems] NOCHECK CONSTRAINT [FK_PurchaseOrderItems_Items];


GO
ALTER TABLE [dbo].[PurchaseOrderItems] NOCHECK CONSTRAINT [FK_PurchaseOrderItems_Warehouse];

