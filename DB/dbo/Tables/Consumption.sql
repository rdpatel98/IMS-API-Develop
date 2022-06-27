CREATE TABLE [dbo].[Consumption] (
    [ConsumptionId]   INT           IDENTITY (1, 1) NOT NULL,
    [ConsumptionNo]   VARCHAR (10)  CONSTRAINT [DF__Consumpti__Consu__6383C8BA] DEFAULT (NULL) NULL,
    [ConsumptionDate] DATETIME2 (0) CONSTRAINT [DF__Consumpti__Consu__6477ECF3] DEFAULT (NULL) NULL,
    [WarehouseId]     INT           CONSTRAINT [DF__Consumpti__Wareh__656C112C] DEFAULT (NULL) NULL,
    [WorkerId]        INT           CONSTRAINT [DF__Consumpti__Worke__66603565] DEFAULT (NULL) NULL,
    [UpdatedUserId]   INT           CONSTRAINT [DF__Consumpti__Updat__6754599E] DEFAULT (NULL) NULL,
    [UpdatedDateTime] DATETIME2 (0) CONSTRAINT [DF__Consumpti__Updat__68487DD7] DEFAULT (NULL) NULL,
    [Status]          SMALLINT      NOT NULL,
    [OrganizationId]  INT           NULL,
    CONSTRAINT [PK__Consumpt__E3A1C41760A10348] PRIMARY KEY CLUSTERED ([ConsumptionId] ASC),
    CONSTRAINT [FK_Consumption_Warehouse] FOREIGN KEY ([WarehouseId]) REFERENCES [dbo].[Warehouse] ([WarehouseId]) NOT FOR REPLICATION,
    CONSTRAINT [FK_Consumption_Worker] FOREIGN KEY ([WorkerId]) REFERENCES [dbo].[Worker] ([WorkerId]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dbo].[Consumption] NOCHECK CONSTRAINT [FK_Consumption_Warehouse];


GO
ALTER TABLE [dbo].[Consumption] NOCHECK CONSTRAINT [FK_Consumption_Worker];

