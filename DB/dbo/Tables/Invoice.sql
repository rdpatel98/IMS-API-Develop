CREATE TABLE [dbo].[Invoice] (
    [InvoiceId]       INT           IDENTITY (1, 1) NOT NULL,
    [InvoiceNo]       VARCHAR (10)  CONSTRAINT [DF__Invoice__Invoice__7C4F7684] DEFAULT (NULL) NULL,
    [PurchaseOrderId] INT           CONSTRAINT [DF__Invoice__Purchas__7D439ABD] DEFAULT (NULL) NULL,
    [VendorId]        INT           CONSTRAINT [DF__Invoice__VendorI__7E37BEF6] DEFAULT (NULL) NULL,
    [NetAmount]       FLOAT (53)    CONSTRAINT [DF__Invoice__NetAmou__7F2BE32F] DEFAULT (NULL) NULL,
    [InvoiceStatus]   SMALLINT      CONSTRAINT [DF__Invoice__Invoice__00200768] DEFAULT (NULL) NULL,
    [InvoiceDate]     DATETIME2 (0) CONSTRAINT [DF__Invoice__Invoice__01142BA1] DEFAULT (NULL) NULL,
    [UpdatedUserId]   INT           CONSTRAINT [DF__Invoice__Updated__02084FDA] DEFAULT (NULL) NULL,
    [UpdatedDateTime] DATETIME2 (0) CONSTRAINT [DF__Invoice__Updated__02FC7413] DEFAULT (NULL) NULL,
    [Status]          SMALLINT      NOT NULL,
    [OrganizationId]  INT           NULL,
    CONSTRAINT [PK__Invoice__D796AAB55C0DBBBE] PRIMARY KEY CLUSTERED ([InvoiceId] ASC),
    CONSTRAINT [FK_Invoice_Purchaseorder] FOREIGN KEY ([PurchaseOrderId]) REFERENCES [dbo].[PurchaseOrder] ([PurchaseOrderId]),
    CONSTRAINT [FK_Invoice_Vendor] FOREIGN KEY ([VendorId]) REFERENCES [dbo].[Vendor] ([VendorId]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[Invoice] NOCHECK CONSTRAINT [FK_Invoice_Vendor];

