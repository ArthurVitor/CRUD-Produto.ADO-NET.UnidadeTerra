CREATE TABLE [dbo].[Product] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (255) NOT NULL,
    [IsPerishable] BIT            NOT NULL,
    [ValidDate]    DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);