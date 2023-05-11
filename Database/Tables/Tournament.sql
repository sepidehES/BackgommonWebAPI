CREATE TABLE [dbo].[Tournament]
(
	[TournamentId] INT NOT NULL IDENTITY,
	[TournamentName] VARCHAR (50) NOT NULL, 
    [Description] VARCHAR (500), 
    [MaxPlayer] INT NOT NULL,

	CONSTRAINT PK_Tournament PRIMARY KEY ([TournamentId])
	);
