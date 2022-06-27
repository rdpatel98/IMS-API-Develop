CREATE TABLE [dbo].[OrganizationAddress] (
    [OrganizationAddressId] INT IDENTITY (1, 1) NOT NULL,
    [OrganizationId]        INT CONSTRAINT [DF__Organizat__Organ__29221CFB] DEFAULT (NULL) NULL,
    [AddressId]             INT CONSTRAINT [DF__Organizat__Addre__2A164134] DEFAULT (NULL) NULL,
    CONSTRAINT [PK__Organiza__4386CABBC0F0B5DD] PRIMARY KEY CLUSTERED ([OrganizationAddressId] ASC),
    CONSTRAINT [FK_OrganizationAddress_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) NOT FOR REPLICATION,
    CONSTRAINT [FK_OrganizationAddress_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([OrganizationId]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[OrganizationAddress] NOCHECK CONSTRAINT [FK_OrganizationAddress_Addresses];


GO
ALTER TABLE [dbo].[OrganizationAddress] NOCHECK CONSTRAINT [FK_OrganizationAddress_Organization];

