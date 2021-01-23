CREATE TABLE [dbo].[Security]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Ticker] VARCHAR(8) NULL, 
    [SecurityName] VARCHAR(50) NULL
)
