CREATE TABLE [dbo].[PortfolioPosition]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PortfolioId] INT NOT NULL, 
    [SecurityId] INT NULL, 
    [CostBasis] FLOAT NULL, 
    [Shares] FLOAT NULL
)
