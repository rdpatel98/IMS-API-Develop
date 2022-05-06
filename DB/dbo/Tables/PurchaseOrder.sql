CREATE TABLE [dbo].[PurchaseOrder] (
    [PurchaseOrderId] INT           IDENTITY (1, 1) NOT NULL,
    [PurchaseOrderNo] VARCHAR (10)  CONSTRAINT [DF__PurchaseO__Purch__3B40CD36] DEFAULT (NULL) NULL,
    [VendorId]        INT           CONSTRAINT [DF__PurchaseO__Vendo__3C34F16F] DEFAULT (NULL) NULL,
    [NetAmount]       FLOAT (53)    CONSTRAINT [DF__PurchaseO__NetAm__3D2915A8] DEFAULT (NULL) NULL,
    [OrderStatus]     SMALLINT      CONSTRAINT [DF__PurchaseO__Order__3E1D39E1] DEFAULT (NULL) NULL,
    [OrderDate]       DATETIME2 (0) CONSTRAINT [DF__PurchaseO__Order__3F115E1A] DEFAULT (NULL) NULL,
    [UpdatedUserId]   INT           CONSTRAINT [DF__PurchaseO__Updat__40058253] DEFAULT (NULL) NULL,
    [UpdatedDateTime] DATETIME2 (0) CONSTRAINT [DF__PurchaseO__Updat__40F9A68C] DEFAULT (NULL) NULL,
    [Status]          SMALLINT      NOT NULL,
    [OrganizationId]  INT           NULL,
    CONSTRAINT [PK__Purchase__036BACA4F0C6FCF7] PRIMARY KEY CLUSTERED ([PurchaseOrderId] ASC),
    CONSTRAINT [FK_PurchaseOrder_Vendor] FOREIGN KEY ([VendorId]) REFERENCES [dbo].[Vendor] ([VendorId]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[PurchaseOrder] NOCHECK CONSTRAINT [FK_PurchaseOrder_Vendor];

