CREATE TABLE [dbo].[Organization] (
    [OrganizationId]            INT           IDENTITY (1, 1) NOT NULL,
    [Id]                        VARCHAR (10)  CONSTRAINT [DF__Organization__Id__1EA48E88] DEFAULT (NULL) NULL,
    [Name]                      VARCHAR (20)  CONSTRAINT [DF__Organizati__Name__1F98B2C1] DEFAULT (NULL) NULL,
    [Description]               VARCHAR (60)  CONSTRAINT [DF__Organizat__Descr__208CD6FA] DEFAULT (NULL) NULL,
    [PurchaseOrderPrefix]       VARCHAR (15)  CONSTRAINT [DF__Organizat__Purch__2180FB33] DEFAULT (NULL) NULL,
    [ReturnOrderPrefix]         VARCHAR (15)  CONSTRAINT [DF__Organizat__Retur__22751F6C] DEFAULT (NULL) NULL,
    [InventoryAdjustmentPrefix] VARCHAR (15)  CONSTRAINT [DF__Organizat__Inven__236943A5] DEFAULT (NULL) NULL,
    [ItemConsumptionPrefix]     VARCHAR (15)  CONSTRAINT [DF__Organizat__ItemC__245D67DE] DEFAULT (NULL) NULL,
    [TransactionalWarehouseId]  INT           CONSTRAINT [DF__Organizat__Trans__25518C17] DEFAULT ((0)) NULL,
    [TaxRegistrationNumber]     VARCHAR (60)  CONSTRAINT [DF__Organizat__TaxRe__2645B050] DEFAULT (NULL) NULL,
    [UpdatedUserId]             INT           CONSTRAINT [DF__Organizat__Updat__2739D489] DEFAULT (NULL) NULL,
    [UpdatedDateTime]           DATETIME2 (0) CONSTRAINT [DF__Organizat__Updat__282DF8C2] DEFAULT (NULL) NULL,
    [Status]                    SMALLINT      NOT NULL,
    CONSTRAINT [PK__Organiza__CADB0B12F30104D5] PRIMARY KEY CLUSTERED ([OrganizationId] ASC),
    CONSTRAINT [FK_Organization_Warehouse] FOREIGN KEY ([TransactionalWarehouseId]) REFERENCES [dbo].[Warehouse] ([WarehouseId]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[Organization] NOCHECK CONSTRAINT [FK_Organization_Warehouse];

