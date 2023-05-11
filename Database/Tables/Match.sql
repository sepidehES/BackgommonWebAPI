CREATE TABLE [dbo].[Match]
(
	[MatchId] INT NOT NULL IDENTITY,
	[DateStart] DATETIME2 NOT NULL,
	[DateEnd] DATETIME2 NOT NULL,
	[Player1Id] INT NOT NULL,
	[Player2Id] INT NOT NULL,
	[TournamentId] INT NOT NULL,

	CONSTRAINT PK_Match PRIMARY KEY ([MatchId]),
	CONSTRAINT FK_Match_Tournament FOREIGN KEY ([TournamentId]) REFERENCES Tournament([TournamentId]),
	CONSTRAINT FK_Match_Player1 FOREIGN KEY ([Player1Id]) REFERENCES Player([PlayerId]),
	CONSTRAINT FK_Match_Player2 FOREIGN KEY ([Player2Id]) REFERENCES Player([PlayerId])

);
