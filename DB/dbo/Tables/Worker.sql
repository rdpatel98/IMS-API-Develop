CREATE TABLE [dbo].[Worker] (
    [WorkerId]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]            VARCHAR (60)  CONSTRAINT [DF__Worker__Name__69FBBC1F] DEFAULT (NULL) NULL,
    [PersonnelNumber] VARCHAR (15)  CONSTRAINT [DF__Worker__Personne__6AEFE058] DEFAULT (NULL) NULL,
    [DOJ]             DATETIME2 (0) CONSTRAINT [DF__Worker__DOJ__6BE40491] DEFAULT (NULL) NULL,
    [DOB]             DATETIME2 (0) CONSTRAINT [DF__Worker__DOB__6CD828CA] DEFAULT (NULL) NULL,
    [UserId]          VARCHAR (20)  CONSTRAINT [DF__Worker__UserId__6DCC4D03] DEFAULT (NULL) NULL,
    [Password]        VARCHAR (20)  CONSTRAINT [DF__Worker__Password__6EC0713C] DEFAULT (NULL) NULL,
    [UpdatedUserId]   INT           CONSTRAINT [DF__Worker__UpdatedU__6FB49575] DEFAULT (NULL) NULL,
    [UpdatedDateTime] DATETIME2 (0) CONSTRAINT [DF__Worker__UpdatedD__70A8B9AE] DEFAULT (NULL) NULL,
    [Status]          SMALLINT      NOT NULL,
    [IsBlocked]       BIT           CONSTRAINT [DF_Worker_IsBlocked] DEFAULT ((0)) NULL,
    [OrganizationId]  INT           NULL,
    CONSTRAINT [PK__Worker__077C8826EBBA4D00] PRIMARY KEY CLUSTERED ([WorkerId] ASC)
);

