CREATE TABLE [dbo].[Addresses] (
    [AddressId]       INT           IDENTITY (1, 1) NOT NULL,
    [Address1]        VARCHAR (300) CONSTRAINT [DF__Addresses__Addre__5629CD9C] DEFAULT (NULL) NULL,
    [Address2]        VARCHAR (300) CONSTRAINT [DF__Addresses__Addre__571DF1D5] DEFAULT (NULL) NULL,
    [State]           VARCHAR (60)  CONSTRAINT [DF__Addresses__State__5812160E] DEFAULT (NULL) NULL,
    [City]            VARCHAR (60)  CONSTRAINT [DF__Addresses__City__59063A47] DEFAULT (NULL) NULL,
    [Pincode]         VARCHAR (10)  CONSTRAINT [DF__Addresses__Pinco__59FA5E80] DEFAULT (NULL) NULL,
    [Phone]           VARCHAR (15)  CONSTRAINT [DF__Addresses__Phone__5AEE82B9] DEFAULT (NULL) NULL,
    [Email]           VARCHAR (255) CONSTRAINT [DF__Addresses__Email__5BE2A6F2] DEFAULT (NULL) NULL,
    [UpdatedUserId]   INT           CONSTRAINT [DF__Addresses__Updat__5CD6CB2B] DEFAULT (NULL) NULL,
    [UpdatedDateTime] DATETIME2 (0) CONSTRAINT [DF__Addresses__Updat__5DCAEF64] DEFAULT (NULL) NULL,
    [Status]          SMALLINT      NOT NULL,
    CONSTRAINT [PK__Addresse__091C2AFB2AC3B7AE] PRIMARY KEY CLUSTERED ([AddressId] ASC)
);

