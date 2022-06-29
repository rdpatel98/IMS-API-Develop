CREATE TABLE [dbo].[ItemTypes](
	[ItemTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](60) NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[OrganizationId] [int] NULL,
 CONSTRAINT [PK_ItemTypes] PRIMARY KEY CLUSTERED 
(
	[ItemTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
