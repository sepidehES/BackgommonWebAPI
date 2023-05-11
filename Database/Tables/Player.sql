CREATE TABLE [dbo].[Player]
(
	[PlayerId] INT NOT NULL IDENTITY,
	[Pseudo] NVARCHAR(50) NULL,
	[Email] NVARCHAR(200) NOT NULL,
	[Password_Hash] VARCHAR(100) NOT NULL, 

	CONSTRAINT PK_Player PRIMARY KEY ([PlayerId])

);

