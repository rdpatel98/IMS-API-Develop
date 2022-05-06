CREATE TABLE [dbo].[VendorAddress] (
    [VendorAddressId] INT IDENTITY (1, 1) NOT NULL,
    [VendorId]        INT CONSTRAINT [DF__VendorAdd__Vendo__6166761E] DEFAULT (NULL) NULL,
    [AddressId]       INT CONSTRAINT [DF__VendorAdd__Addre__625A9A57] DEFAULT (NULL) NULL,
    CONSTRAINT [PK__VendorAd__801868DEA3BC8E06] PRIMARY KEY CLUSTERED ([VendorAddressId] ASC),
    CONSTRAINT [FK_VendorAddress_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) NOT FOR REPLICATION,
    CONSTRAINT [FK_VendorAddress_Vendor] FOREIGN KEY ([VendorId]) REFERENCES [dbo].[Vendor] ([VendorId]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[VendorAddress] NOCHECK CONSTRAINT [FK_VendorAddress_Addresses];


GO
ALTER TABLE [dbo].[VendorAddress] NOCHECK CONSTRAINT [FK_VendorAddress_Vendor];

