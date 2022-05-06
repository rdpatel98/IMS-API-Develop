CREATE TABLE [dbo].[Stock] (
    [StockId]         INT           IDENTITY (1, 1) NOT NULL,
    [ItemId]          INT           CONSTRAINT [DF__Stock__ItemId__4C6B5938] DEFAULT (NULL) NULL,
    [WarehouseId]     INT           CONSTRAINT [DF__Stock__Warehouse__4D5F7D71] DEFAULT (NULL) NULL,
    [WorkerId]        INT           CONSTRAINT [DF__Stock__WorkerId__4E53A1AA] DEFAULT (NULL) NULL,
    [Quantity]        FLOAT (53)    CONSTRAINT [DF__Stock__Quantity__4F47C5E3] DEFAULT (NULL) NULL,
    [OnHandQuantity]  FLOAT (53)    CONSTRAINT [DF__Stock__OnHandQua__503BEA1C] DEFAULT (NULL) NULL,
    [TransactionId]   INT           CONSTRAINT [DF__Stock__Transacti__51300E55] DEFAULT (NULL) NULL,
    [UpdatedUserId]   INT           CONSTRAINT [DF__Stock__UpdatedUs__5224328E] DEFAULT (NULL) NULL,
    [UpdatedDateTime] DATETIME2 (0) CONSTRAINT [DF__Stock__UpdatedDa__531856C7] DEFAULT (NULL) NULL,
    [Status]          SMALLINT      NOT NULL,
    CONSTRAINT [PK__Stock__2C83A9C228C8DF0B] PRIMARY KEY CLUSTERED ([StockId] ASC),
    CONSTRAINT [FK_Stock_Items] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Items] ([ItemId]) NOT FOR REPLICATION,
    CONSTRAINT [FK_Stock_Transactions] FOREIGN KEY ([TransactionId]) REFERENCES [dbo].[Transactions] ([Id]),
    CONSTRAINT [FK_Stock_Warehouse] FOREIGN KEY ([WarehouseId]) REFERENCES [dbo].[Warehouse] ([WarehouseId]) NOT FOR REPLICATION,
    CONSTRAINT [FK_Stock_Worker] FOREIGN KEY ([WorkerId]) REFERENCES [dbo].[Worker] ([WorkerId]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[Stock] NOCHECK CONSTRAINT [FK_Stock_Items];


GO
ALTER TABLE [dbo].[Stock] NOCHECK CONSTRAINT [FK_Stock_Warehouse];


GO
ALTER TABLE [dbo].[Stock] NOCHECK CONSTRAINT [FK_Stock_Worker];

