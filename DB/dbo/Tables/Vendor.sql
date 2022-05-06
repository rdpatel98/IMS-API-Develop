CREATE TABLE [dbo].[Vendor] (
    [VendorId]        INT           IDENTITY (1, 1) NOT NULL,
    [Id]              VARCHAR (10)  CONSTRAINT [DF__Vendor__Id__5CA1C101] DEFAULT (NULL) NULL,
    [Name]            VARCHAR (60)  CONSTRAINT [DF__Vendor__Name__5D95E53A] DEFAULT (NULL) NULL,
    [AccountNumber]   VARCHAR (10)  CONSTRAINT [DF__Vendor__Account__5E8A0973] DEFAULT (NULL) NULL,
    [UpdatedUserId]   INT           CONSTRAINT [DF__Vendor__UpdatedU__5F7E2DAC] DEFAULT (NULL) NULL,
    [UpdatedDateTime] DATETIME2 (0) CONSTRAINT [DF__Vendor__UpdatedD__607251E5] DEFAULT (NULL) NULL,
    [Status]          SMALLINT      NOT NULL,
    [OrganizationId]  INT           NULL,
    CONSTRAINT [PK__Vendor__FC8618F3920C99BF] PRIMARY KEY CLUSTERED ([VendorId] ASC)
);

