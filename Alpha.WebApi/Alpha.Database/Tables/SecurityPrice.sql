CREATE TABLE [dbo].[SecurityPrice]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SecurityId] INT NOT NULL, 
    [Date] DATETIME2 NOT NULL, 
    [ClosingPrice] FLOAT NOT NULL
)
