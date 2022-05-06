CREATE TABLE [dbo].[Category] (
    [CategoryId]      INT           IDENTITY (1, 1) NOT NULL,
    [Id]              VARCHAR (10)  CONSTRAINT [DF__Category__Id__5EBF139D] DEFAULT (NULL) NULL,
    [Name]            VARCHAR (60)  CONSTRAINT [DF__Category__Name__5FB337D6] DEFAULT (NULL) NULL,
    [Description]     VARCHAR (MAX) CONSTRAINT [DF__Category__Descri__60A75C0F] DEFAULT (NULL) NULL,
    [UpdatedUserId]   INT           CONSTRAINT [DF__Category__Update__619B8048] DEFAULT (NULL) NULL,
    [UpdatedDateTime] DATETIME2 (0) CONSTRAINT [DF__Category__Update__628FA481] DEFAULT (NULL) NULL,
    [Status]          SMALLINT      NOT NULL,
    [OrganizationId]  INT           NULL,
    CONSTRAINT [PK__Category__19093A0B618BEDF1] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

