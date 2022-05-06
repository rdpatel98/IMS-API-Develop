CREATE TABLE [dbo].[ItemCategoryCollection] (
    [ItemCategoryCollectionId] INT IDENTITY (1, 1) NOT NULL,
    [ItemCategoryId]           INT NULL,
    [CategoryId]               INT NULL,
    [ItemId]                   INT NULL,
    CONSTRAINT [PK__ItemCate__1935D91C7C9431A8] PRIMARY KEY CLUSTERED ([ItemCategoryCollectionId] ASC),
    CONSTRAINT [FK_ItemCategoryCollection_ItemCategory] FOREIGN KEY ([ItemCategoryId]) REFERENCES [dbo].[ItemCategory] ([ItemCategoryId]) NOT FOR REPLICATION,
    CONSTRAINT [FK_ItemCategoryCollection_Items] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Items] ([ItemId]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[ItemCategoryCollection] NOCHECK CONSTRAINT [FK_ItemCategoryCollection_ItemCategory];


GO
ALTER TABLE [dbo].[ItemCategoryCollection] NOCHECK CONSTRAINT [FK_ItemCategoryCollection_Items];

