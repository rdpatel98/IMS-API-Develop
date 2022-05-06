CREATE TABLE [dbo].[ItemCategory] (
    [ItemCategoryId]  INT      IDENTITY (1, 1) NOT NULL,
    [CategoryId]      INT      NULL,
    [UpdatedUserId]   INT      NULL,
    [UpdatedDateTime] DATETIME NULL,
    [Status]          SMALLINT CONSTRAINT [DF_ItemCategory_Status] DEFAULT ((1)) NOT NULL,
    [OrganizationId]  INT      NULL,
    CONSTRAINT [PK__ItemCate__C24A29255944101A] PRIMARY KEY CLUSTERED ([ItemCategoryId] ASC),
    CONSTRAINT [FK_ItemCategory_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[ItemCategory] NOCHECK CONSTRAINT [FK_ItemCategory_Category];

