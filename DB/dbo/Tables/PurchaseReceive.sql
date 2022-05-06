CREATE TABLE [dbo].[PurchaseReceive] (
    [PurchaseReceiveId]     INT           IDENTITY (1, 1) NOT NULL,
    [PurchaseReceiveNo]     VARCHAR (10)  CONSTRAINT [DF__PurchaseR__Purch__3A4CA8FD] DEFAULT (NULL) NULL,
    [PurchaseOrderId]       INT           CONSTRAINT [DF__PurchaseR__Purch__3B40CD36] DEFAULT (NULL) NULL,
    [VendorId]              INT           CONSTRAINT [DF__PurchaseR__Vendo__3C34F16F] DEFAULT (NULL) NULL,
    [NetAmount]             FLOAT (53)    CONSTRAINT [DF__PurchaseR__NetAm__3D2915A8] DEFAULT (NULL) NULL,
    [PurchaseReceiveStatus] SMALLINT      CONSTRAINT [DF__PurchaseR__Purch__3E1D39E1] DEFAULT (NULL) NULL,
    [PurchaseReceiveDate]   DATETIME2 (0) CONSTRAINT [DF__PurchaseR__Purch__3F115E1A] DEFAULT (NULL) NULL,
    [UpdatedUserId]         INT           CONSTRAINT [DF__PurchaseR__Updat__40058253] DEFAULT (NULL) NULL,
    [UpdatedDateTime]       DATETIME2 (0) CONSTRAINT [DF__PurchaseR__Updat__40F9A68C] DEFAULT (NULL) NULL,
    [Status]                SMALLINT      NOT NULL,
    [OrganizationId]        INT           NULL,
    CONSTRAINT [PK__Purchase__2C33C6E8498F0EB3] PRIMARY KEY CLUSTERED ([PurchaseReceiveId] ASC),
    CONSTRAINT [FK_PurchaseReturn_Purchaseorder] FOREIGN KEY ([PurchaseOrderId]) REFERENCES [dbo].[PurchaseOrder] ([PurchaseOrderId]),
    CONSTRAINT [FK_PurchaseReturn_Vendor] FOREIGN KEY ([VendorId]) REFERENCES [dbo].[Vendor] ([VendorId]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[PurchaseReceive] NOCHECK CONSTRAINT [FK_PurchaseReturn_Vendor];

