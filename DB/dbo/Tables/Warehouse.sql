CREATE TABLE [dbo].[Warehouse] (
    [WarehouseId]     INT           IDENTITY (1, 1) NOT NULL,
    [Id]              VARCHAR (10)  CONSTRAINT [DF__Warehouse__Id__634EBE90] DEFAULT (NULL) NULL,
    [Name]            VARCHAR (20)  CONSTRAINT [DF__Warehouse__Name__6442E2C9] DEFAULT (NULL) NULL,
    [OrganizationId]  INT           CONSTRAINT [DF__Warehouse__Organ__65370702] DEFAULT (NULL) NULL,
    [UpdatedUserId]   INT           CONSTRAINT [DF__Warehouse__Updat__662B2B3B] DEFAULT (NULL) NULL,
    [UpdatedDateTime] DATETIME2 (0) CONSTRAINT [DF__Warehouse__Updat__671F4F74] DEFAULT (NULL) NULL,
    [Status]          SMALLINT      NOT NULL,
    CONSTRAINT [PK__Warehous__2608AFF90AB5721A] PRIMARY KEY CLUSTERED ([WarehouseId] ASC)
);

