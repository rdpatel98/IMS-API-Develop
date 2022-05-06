CREATE TABLE [dbo].[InvoiceItems] (
    [InvoiceItemsId]       INT           IDENTITY (1, 1) NOT NULL,
    [InvoiceId]            INT           NOT NULL,
    [LineNo]               SMALLINT      CONSTRAINT [DF__InvoiceIt__LineN__03F0984C] DEFAULT (NULL) NULL,
    [ItemId]               INT           CONSTRAINT [DF__InvoiceIt__ItemI__04E4BC85] DEFAULT (NULL) NULL,
    [WarehouseId]          INT           CONSTRAINT [DF__InvoiceIt__Wareh__05D8E0BE] DEFAULT (NULL) NULL,
    [Quantity]             FLOAT (53)    CONSTRAINT [DF__InvoiceIt__Quant__06CD04F7] DEFAULT (NULL) NULL,
    [ReceivedQuantity]     FLOAT (53)    CONSTRAINT [DF__InvoiceIt__Recei__07C12930] DEFAULT (NULL) NULL,
    [UnitId]               INT           CONSTRAINT [DF__InvoiceIt__UnitI__08B54D69] DEFAULT (NULL) NULL,
    [UnitPrice]            FLOAT (53)    CONSTRAINT [DF__InvoiceIt__UnitP__09A971A2] DEFAULT (NULL) NULL,
    [NetAmount]            FLOAT (53)    CONSTRAINT [DF__InvoiceIt__NetAm__0A9D95DB] DEFAULT (NULL) NULL,
    [BatchNo]              VARCHAR (10)  CONSTRAINT [DF__InvoiceIt__Batch__0B91BA14] DEFAULT (NULL) NULL,
    [InvoiceNo]            VARCHAR (10)  CONSTRAINT [DF__InvoiceIt__Invoi__0C85DE4D] DEFAULT (NULL) NULL,
    [InvoiceDate]          DATETIME2 (0) CONSTRAINT [DF__InvoiceIt__Invoi__0D7A0286] DEFAULT (NULL) NULL,
    [UpdatedUserId]        INT           CONSTRAINT [DF__InvoiceIt__Updat__0E6E26BF] DEFAULT (NULL) NULL,
    [UpdatedDateTime]      DATETIME2 (0) CONSTRAINT [DF__InvoiceIt__Updat__0F624AF8] DEFAULT (NULL) NULL,
    [PurchaseOrderItemsId] INT           DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK__InvoiceI__29E41A69899F7204] PRIMARY KEY CLUSTERED ([InvoiceItemsId] ASC),
    CONSTRAINT [FK_InvoiceItems_Invoice] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoice] ([InvoiceId]),
    CONSTRAINT [FK_InvoiceItems_Items] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Items] ([ItemId]) NOT FOR REPLICATION,
    CONSTRAINT [FK_InvoiceItems_UomConversion] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[UomConversion] ([Id]),
    CONSTRAINT [FK_InvoiceItems_Warehouse] FOREIGN KEY ([WarehouseId]) REFERENCES [dbo].[Warehouse] ([WarehouseId]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[InvoiceItems] NOCHECK CONSTRAINT [FK_InvoiceItems_Items];


GO
ALTER TABLE [dbo].[InvoiceItems] NOCHECK CONSTRAINT [FK_InvoiceItems_Warehouse];

