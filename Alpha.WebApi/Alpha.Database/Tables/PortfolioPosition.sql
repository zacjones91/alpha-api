CREATE TABLE [dbo].[PortfolioPosition]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PortfolioId] INT NOT NULL, 
    [SecurityId] INT NULL, 
    [Shares] FLOAT NULL
)
