CREATE TABLE [dbo].[Transaction]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Date] DATETIME2 NOT NULL, 
    [Action] VARCHAR(15) NOT NULL, 
    [SecurityId] INT NOT NULL, 
    [Description] VARCHAR(60) NULL, 
    [Quantity] FLOAT NULL, 
    [Price] FLOAT NULL, 
    [Fees] FLOAT NOT NULL, 
    [Amount] FLOAT NOT NULL,
	
)
