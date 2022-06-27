CREATE TABLE [dbo].[InventoryAdjustment] (
    [InventoryAdjustmentId] INT           IDENTITY (1, 1) NOT NULL,
    [InventoryAdjustmentNo] VARCHAR (10)  CONSTRAINT [DF__Inventory__Inven__6FE99F9F] DEFAULT (NULL) NULL,
    [AdjustmentDate]        DATETIME2 (0) CONSTRAINT [DF__Inventory__Adjus__70DDC3D8] DEFAULT (NULL) NULL,
    [UpdatedUserId]         INT           CONSTRAINT [DF__Inventory__Updat__71D1E811] DEFAULT (NULL) NULL,
    [UpdatedDateTime]       DATETIME2 (0) CONSTRAINT [DF__Inventory__Updat__72C60C4A] DEFAULT (NULL) NULL,
    [Status]                SMALLINT      NOT NULL,
    [OrganizationId]        INT           NULL,
    [WarehouseId]           INT           DEFAULT ((0)) NOT NULL,
    [WorkerId]              INT           DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK__Inventor__E7407FFC25FBB5A0] PRIMARY KEY CLUSTERED ([InventoryAdjustmentId] ASC)
);

