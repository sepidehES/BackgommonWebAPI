CREATE TABLE [dbo].[Tournament]
(
	[TournamentId] INT NOT NULL IDENTITY,
	[TournamentName] VARCHAR (50) NOT NULL, 
    [Description] VARCHAR (500), 
    [MaxPlayer] INT NOT NULL,
	[IsStarted] BIT DEFAULT 0,
	[IsOpen] BIT DEFAULT 0,
	CONSTRAINT PK_Tournament PRIMARY KEY ([TournamentId])
	);
