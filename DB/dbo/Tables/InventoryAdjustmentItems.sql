CREATE TABLE [dbo].[InventoryAdjustmentItems] (
    [InventoryAdjustmentItemsId] INT           IDENTITY (1, 1) NOT NULL,
    [LineNo]                     SMALLINT      CONSTRAINT [DF__Inventory__LineN__73BA3083] DEFAULT (NULL) NULL,
    [ItemId]                     INT           CONSTRAINT [DF__Inventory__ItemI__74AE54BC] DEFAULT (NULL) NULL,
    [WarehouseId]                INT           CONSTRAINT [DF__Inventory__Wareh__75A278F5] DEFAULT (NULL) NULL,
    [WorkerId]                   INT           CONSTRAINT [DF__Inventory__Worke__76969D2E] DEFAULT (NULL) NULL,
    [Quantity]                   FLOAT (53)    CONSTRAINT [DF__Inventory__Quant__778AC167] DEFAULT (NULL) NULL,
    [ReasonCode]                 TINYINT       NULL,
    [Reason]                     VARCHAR (60)  CONSTRAINT [DF__Inventory__Reaso__787EE5A0] DEFAULT (NULL) NULL,
    [UpdatedUserId]              INT           CONSTRAINT [DF__Inventory__Updat__797309D9] DEFAULT (NULL) NULL,
    [UpdatedDateTime]            DATETIME2 (0) CONSTRAINT [DF__Inventory__Updat__7A672E12] DEFAULT (NULL) NULL,
    [InventoryAdjustmentId]      INT           CONSTRAINT [DF__Inventory__Inven__7B5B524B] DEFAULT (NULL) NULL,
    CONSTRAINT [PK__Inventor__75C6156F052262ED] PRIMARY KEY CLUSTERED ([InventoryAdjustmentItemsId] ASC),
    CONSTRAINT [FK_InventoryAdjustmentItems_InventoryAdjustment] FOREIGN KEY ([InventoryAdjustmentId]) REFERENCES [dbo].[InventoryAdjustment] ([InventoryAdjustmentId]),
    CONSTRAINT [FK_InventoryAdjustmentItems_Items] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Items] ([ItemId]) NOT FOR REPLICATION,
    CONSTRAINT [FK_InventoryAdjustmentItems_Warehouse] FOREIGN KEY ([WarehouseId]) REFERENCES [dbo].[Warehouse] ([WarehouseId]) NOT FOR REPLICATION,
    CONSTRAINT [FK_InventoryAdjustmentItems_Worker] FOREIGN KEY ([WorkerId]) REFERENCES [dbo].[Worker] ([WorkerId]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[InventoryAdjustmentItems] NOCHECK CONSTRAINT [FK_InventoryAdjustmentItems_Items];


GO
ALTER TABLE [dbo].[InventoryAdjustmentItems] NOCHECK CONSTRAINT [FK_InventoryAdjustmentItems_Warehouse];


GO
ALTER TABLE [dbo].[InventoryAdjustmentItems] NOCHECK CONSTRAINT [FK_InventoryAdjustmentItems_Worker];

