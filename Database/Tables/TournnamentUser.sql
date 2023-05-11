CREATE TABLE [dbo].[TournamentUser]
(
	[TournamentId] INT NOT NULL,
	[PlayerId] INT NOT NULL,

	CONSTRAINT PK_TournamentUser PRIMARY KEY ([TournamentId], [PlayerId]),
	CONSTRAINT FK_TournamentUser_Tournament FOREIGN KEY ([TournamentId]) REFERENCES Tournament([TournamentId]),
    CONSTRAINT FK_TournamentUser_Player FOREIGN KEY ([PlayerId]) REFERENCES Player([PlayerId])
);
