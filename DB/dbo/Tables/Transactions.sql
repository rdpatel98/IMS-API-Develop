CREATE TABLE [dbo].[Transactions] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [TransactionId]  VARCHAR (20) CONSTRAINT [DF__Transacti__Trans__540C7B00] DEFAULT (NULL) NULL,
    [Type]           SMALLINT     CONSTRAINT [DF__Transactio__Type__55009F39] DEFAULT (NULL) NULL,
    [RelationId]     INT          CONSTRAINT [DF__Transacti__Relat__55F4C372] DEFAULT (NULL) NULL,
    [OrganizationId] INT          NULL,
    CONSTRAINT [PK__Transact__3214EC07AFA9060F] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Transactions_TransactionType] FOREIGN KEY ([Type]) REFERENCES [dbo].[TransactionType] ([Id])
);

