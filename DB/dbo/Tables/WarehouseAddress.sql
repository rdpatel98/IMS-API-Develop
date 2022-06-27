CREATE TABLE [dbo].[WarehouseAddress] (
    [WarehouseAddressId] INT IDENTITY (1, 1) NOT NULL,
    [WarehouseId]        INT CONSTRAINT [DF__Warehouse__Wareh__681373AD] DEFAULT (NULL) NULL,
    [AddressId]          INT CONSTRAINT [DF__Warehouse__Addre__690797E6] DEFAULT (NULL) NULL,
    CONSTRAINT [PK__Warehous__275276B6409AE71F] PRIMARY KEY CLUSTERED ([WarehouseAddressId] ASC),
    CONSTRAINT [FK_WarehouseAddress_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) NOT FOR REPLICATION,
    CONSTRAINT [FK_WarehouseAddress_Warehouse] FOREIGN KEY ([WarehouseId]) REFERENCES [dbo].[Warehouse] ([WarehouseId]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[WarehouseAddress] NOCHECK CONSTRAINT [FK_WarehouseAddress_Addresses];


GO
ALTER TABLE [dbo].[WarehouseAddress] NOCHECK CONSTRAINT [FK_WarehouseAddress_Warehouse];

