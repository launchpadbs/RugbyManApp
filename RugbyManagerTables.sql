DROP TABLE IF EXISTS TournamentHistory;
DROP TABLE TournamentDraw;
DROP TABLE LeagueTeams;
DROP TABLE TeamPlayers;
DROP TABLE Leagues;
DROP TABLE Teams;
DROP TABLE Players;
DROP TABLE Users;
DROP TABLE Stadium;



CREATE TABLE Stadium(
	StadiumId [int] IDENTITY(1,1) NOT NULL,
	Name [varchar](50) NOT NULL,
	Location [varchar](50) NOT NULL,
	
	Active BIT DEFAULT(1) NOT NULL,
 CONSTRAINT [PK_Stadium] PRIMARY KEY CLUSTERED 
(
	StadiumId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

insert into Stadium(Name, Location) values('Greenpoint', 'Cape Town'), ('Kings Park', 'Durban');

CREATE TABLE Users(
	UserId [int] IDENTITY(1,1) NOT NULL,
	Username varchar(100) NOT NULL,
	AccountId nvarchar(100) NULL,
	PasswordHash varchar(100) NULL,
	Active bit default(1) NOT NULL,
	CreateDateTime DateTime Default(GetDate()) NOT NULL,
	UpdateDateTime DateTime NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	UserId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

insert into Users(Username, AccountId, PasswordHash)
values ('TestUser', 'testuser@mailbox.com', 'asjkdfhgadskfjhg')

CREATE TABLE Players(
	PlayerId [int] IDENTITY(1,1) NOT NULL,
	Name [varchar](50) NOT NULL,
	Surname [varchar](50) NOT NULL,
	Height decimal not null,
	Age [int] NOT NULL,
	Position INT NOT NULL,
	Active BIT DEFAULT(1) NOT NULL,
	UserId Int NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	PlayerId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE dbo.Players  WITH CHECK ADD  CONSTRAINT [FK_Players_Users_UserId] FOREIGN KEY(UserId)
REFERENCES [dbo].Users (UserId)
ON DELETE CASCADE
GO


CREATE TABLE Teams(
	TeamId [int] IDENTITY(1,1) NOT NULL,
	Name [varchar](50) NOT NULL,
	Location [varchar](50) NOT NULL,
	Colour varchar(50) not null,
	StadiumId [int] NULL,
	UserId INT NOT NULL,
	Active BIT DEFAULT(1) NOT NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	TeamId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE dbo.Teams  WITH CHECK ADD  CONSTRAINT [FK_Teams_Users_UserId] FOREIGN KEY(UserId)
REFERENCES [dbo].Users (UserId)
ON DELETE CASCADE
GO

CREATE TABLE Leagues(
	LeagueId [int] IDENTITY(1,1) NOT NULL,
	Name [varchar](50) NOT NULL,
	Location [varchar](50) NOT NULL,
	UserId INT NOT NULL,
	Active BIT DEFAULT(1) NOT NULL,
 CONSTRAINT [PK_Leagues] PRIMARY KEY CLUSTERED 
(
	LeagueId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE dbo.Leagues  WITH CHECK ADD  CONSTRAINT [FK_Leagues_Users_UserId] FOREIGN KEY(UserId)
REFERENCES [dbo].Users (UserId)
ON DELETE CASCADE
GO

--TeamPlayers
CREATE TABLE TeamPlayers(
	PlayerId [int] NOT NULL,
	TeamId int NOT NULL,
	Active BIT DEFAULT(1) NOT NULL
	)

ALTER TABLE dbo.TeamPlayers  WITH CHECK ADD  CONSTRAINT [FK_TeamPlayers_Players_PlayerId] FOREIGN KEY(PlayerId)
REFERENCES [dbo].Players (PlayerId)
ON DELETE NO ACTION

ALTER TABLE dbo.TeamPlayers  WITH CHECK ADD  CONSTRAINT [FK_TeamPlayers_Teams_TeamId] FOREIGN KEY(TeamId)
REFERENCES [dbo].Teams (TeamId)
ON DELETE NO ACTION
GO

--TeamPlayers
CREATE TABLE LeagueTeams(
	LeagueId [int] NOT NULL,
	TeamId int NOT NULL,
	Active BIT DEFAULT(1) NOT NULL
	)

ALTER TABLE dbo.LeagueTeams  WITH CHECK ADD  CONSTRAINT [FK_LeagueTeams_Leagues_LeagueId] FOREIGN KEY(LeagueId)
REFERENCES [dbo].Leagues (LeagueId)
ON DELETE NO ACTION

ALTER TABLE dbo.LeagueTeams  WITH CHECK ADD  CONSTRAINT [FK_LeagueTeams_Teams_TeamId] FOREIGN KEY(TeamId)
REFERENCES [dbo].Teams (TeamId)
ON DELETE NO ACTION
GO

CREATE TABLE TournamentDraw(
	TournamentDrawGuid UniqueIdentifier NOT NULL,
	LeagueId int NOT NULL,
	TeamId int NOT NULL,
	Draw int not null,
	Round int NULL,
	ResultPoints int NULL,
	Active BIT DEFAULT(0) NOT NULL,
	CreateDateTime DateTime Default(GetDate()) NOT NULL,
	UpdateDateTime DateTime NULL
	)


Create Table TournamentHistory(
	TournamentDrawGuid UniqueIdentifier NOT NULL,
	LeagueId int NOT NULL,
	TeamIdA int NOT NULL,
	TeamIdB int NOT NULL, 
	ResultA int NOT NULL,
	ResultB int NOT NULL,
	MatchTime varchar(6) NULL,
	CreateDateTime DateTime DEFAULT(GetDate())
	)
