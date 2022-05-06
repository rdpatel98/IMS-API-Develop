CREATE TABLE [dbo].[WorkerAddress] (
    [WorkerAddressId] INT IDENTITY (1, 1) NOT NULL,
    [WorkerId]        INT CONSTRAINT [DF__WorkerAdd__Worke__719CDDE7] DEFAULT (NULL) NULL,
    [AddressId]       INT CONSTRAINT [DF__WorkerAdd__Addre__72910220] DEFAULT (NULL) NULL,
    CONSTRAINT [PK__WorkerAd__D051F16BED494771] PRIMARY KEY CLUSTERED ([WorkerAddressId] ASC),
    CONSTRAINT [FK_WorkerAddress_Addresses] FOREIGN KEY ([WorkerAddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) NOT FOR REPLICATION,
    CONSTRAINT [FK_WorkerAddress_Worker] FOREIGN KEY ([WorkerId]) REFERENCES [dbo].[Worker] ([WorkerId]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[WorkerAddress] NOCHECK CONSTRAINT [FK_WorkerAddress_Addresses];


GO
ALTER TABLE [dbo].[WorkerAddress] NOCHECK CONSTRAINT [FK_WorkerAddress_Worker];

