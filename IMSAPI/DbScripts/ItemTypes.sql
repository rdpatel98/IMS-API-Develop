GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemTypes](
	[ItemTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](60) NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL)
	ALTER TABLE ItemTypes
ADD CONSTRAINT PK_ItemTypes PRIMARY KEY (ItemTypeId);
ALTER TABLE [dbo].[ItemTypes] ADD  CONSTRAINT [DF__ItemTypes__Name__17036CC0]  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[ItemTypes] ADD  CONSTRAINT [DF__ItemTypes__UpdatedUs__1CBC4616]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[ItemTypes] ADD  CONSTRAINT [DF__ItemTypes__UpdatedDa__1DB06A4F]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO



Alter Table Items
Add ItemTypeId int
ALTER TABLE Items 
ADD  CONSTRAINT [DF__Items__ItemTypeId__1DB06A4F]  DEFAULT (NULL) FOR [ItemTypeId]
GO