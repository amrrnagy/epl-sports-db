-- ============================================================
-- EPL_DBMS — Stored Procedures
-- Generated from DataAccess layer migration
-- Run this script once against your database before deploying
-- the refactored C# repositories.
-- ============================================================


-- ============================================================
-- SECTION 1: MANAGER_PREVIOUS_TEAMS
-- ============================================================

CREATE PROCEDURE sp_ManagerPreviousTeam_GetByManagerId
    @ManagerId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM   Manager_Previous_Teams
    WHERE  Manager_ID = @ManagerId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_ManagerPreviousTeam_GetViewByManagerId
    @ManagerId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT h.*,
           m.Manager_Name,
           t.Team_Name
    FROM   Manager_Previous_Teams h
    INNER  JOIN Managers m ON h.Manager_ID      = m.Manager_ID
    INNER  JOIN Teams    t ON h.Previous_Team_ID = t.Team_ID
    WHERE  h.Manager_ID = @ManagerId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_ManagerPreviousTeam_Insert
    @ManagerId     INT,
    @PreviousTeamId INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Manager_Previous_Teams (Manager_ID, Previous_Team_ID)
    VALUES (@ManagerId, @PreviousTeamId);
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_ManagerPreviousTeam_Delete
    @ManagerId      INT,
    @PreviousTeamId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Manager_Previous_Teams
    WHERE  Manager_ID      = @ManagerId
      AND  Previous_Team_ID = @PreviousTeamId;
END
GO


-- ============================================================
-- SECTION 2: MANAGERS
-- ============================================================

CREATE PROCEDURE sp_Manager_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Managers;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Manager_GetById
    @ManagerId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM   Managers
    WHERE  Manager_ID = @ManagerId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Manager_Insert
    @ManagerName        NVARCHAR(100),
    @Nationality        NVARCHAR(100),
    @PreferredFormation NVARCHAR(20),
    @TeamId             INT,
    @ExperienceYears    INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Managers
        (Manager_Name, Nationality, Preferred_Formation, Team_ID, Experience_Years)
    VALUES
        (@ManagerName, @Nationality, @PreferredFormation, @TeamId, @ExperienceYears);
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Manager_Update
    @ManagerId          INT,
    @ManagerName        NVARCHAR(100),
    @Nationality        NVARCHAR(100),
    @PreferredFormation NVARCHAR(20),
    @TeamId             INT,
    @ExperienceYears    INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Managers
    SET    Manager_Name        = @ManagerName,
           Nationality         = @Nationality,
           Preferred_Formation = @PreferredFormation,
           Team_ID             = @TeamId,
           Experience_Years    = @ExperienceYears
    WHERE  Manager_ID = @ManagerId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Manager_Delete
    @ManagerId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Managers
    WHERE  Manager_ID = @ManagerId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Manager_GetAllForGrid
AS
BEGIN
    SET NOCOUNT ON;
    SELECT m.*,
           t.Team_Name
    FROM   Managers m
    INNER  JOIN Teams t ON m.Team_ID = t.Team_ID;
END
GO


-- ============================================================
-- SECTION 3: MATCHES
-- ============================================================

CREATE PROCEDURE sp_Match_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Matches;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Match_GetById
    @MatchId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM   Matches
    WHERE  Match_ID = @MatchId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Match_Insert
    @MatchDate   DATETIME,
    @HomeTeamId  INT,
    @AwayTeamId  INT,
    @StadiumId   INT,
    @RefereeId   INT,
    @HomeGoals   INT,
    @AwayGoals   INT,
    @Attendance  INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Matches
        (Match_Date, Home_Team_ID, Away_Team_ID, Stadium_ID,
         Referee_ID, Home_Goals, Away_Goals, Attendance)
    VALUES
        (@MatchDate, @HomeTeamId, @AwayTeamId, @StadiumId,
         @RefereeId, @HomeGoals, @AwayGoals, @Attendance);
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Match_Update
    @MatchId     INT,
    @MatchDate   DATETIME,
    @HomeTeamId  INT,
    @AwayTeamId  INT,
    @StadiumId   INT,
    @RefereeId   INT,
    @HomeGoals   INT,
    @AwayGoals   INT,
    @Attendance  INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Matches
    SET    Match_Date    = @MatchDate,
           Home_Team_ID  = @HomeTeamId,
           Away_Team_ID  = @AwayTeamId,
           Stadium_ID    = @StadiumId,
           Referee_ID    = @RefereeId,
           Home_Goals    = @HomeGoals,
           Away_Goals    = @AwayGoals,
           Attendance    = @Attendance
    WHERE  Match_ID = @MatchId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Match_Delete
    @MatchId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Matches
    WHERE  Match_ID = @MatchId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Match_Count
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) FROM Matches;
END
GO

-- ─────────────────────────────────────────────────────────────
-- Returns all matches with human-readable FK names (for grid display).
CREATE PROCEDURE sp_Match_GetAllForGrid
AS
BEGIN
    SET NOCOUNT ON;
    SELECT m.*,
           ht.Team_Name  AS Home_Team_Name,
           at.Team_Name  AS Away_Team_Name,
           s.Stadium_Name,
           r.Referee_Name
    FROM   Matches   m
    INNER  JOIN Teams    ht ON m.Home_Team_ID = ht.Team_ID
    INNER  JOIN Teams    at ON m.Away_Team_ID = at.Team_ID
    INNER  JOIN Stadiums s  ON m.Stadium_ID   = s.Stadium_ID
    INNER  JOIN Referees r  ON m.Referee_ID   = r.Referee_ID;
END
GO

-- ─────────────────────────────────────────────────────────────
-- Returns a single match with human-readable FK names (for Search button).
CREATE PROCEDURE sp_Match_GetViewById
    @MatchId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT m.*,
           ht.Team_Name  AS Home_Team_Name,
           at.Team_Name  AS Away_Team_Name,
           s.Stadium_Name,
           r.Referee_Name
    FROM   Matches   m
    INNER  JOIN Teams    ht ON m.Home_Team_ID = ht.Team_ID
    INNER  JOIN Teams    at ON m.Away_Team_ID = at.Team_ID
    INNER  JOIN Stadiums s  ON m.Stadium_ID   = s.Stadium_ID
    INNER  JOIN Referees r  ON m.Referee_ID   = r.Referee_ID
    WHERE  m.Match_ID = @MatchId;
END
GO


-- ============================================================
-- SECTION 4: PLAYER_INJURIES
-- ============================================================

CREATE PROCEDURE sp_PlayerInjury_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Player_Injuries;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_PlayerInjury_GetByPlayerId
    @PlayerId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM   Player_Injuries
    WHERE  Player_ID = @PlayerId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_PlayerInjury_Insert
    @PlayerId   INT,
    @InjuryDate DATETIME,
    @InjuryType NVARCHAR(100),
    @DaysOut    INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Player_Injuries (Player_ID, Injury_Date, Injury_Type, Days_Out)
    VALUES (@PlayerId, @InjuryDate, @InjuryType, @DaysOut);
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_PlayerInjury_Update
    @PlayerId   INT,
    @InjuryDate DATETIME,
    @InjuryType NVARCHAR(100),
    @DaysOut    INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Player_Injuries
    SET    Injury_Type = @InjuryType,
           Days_Out    = @DaysOut
    WHERE  Player_ID   = @PlayerId
      AND  Injury_Date = @InjuryDate;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_PlayerInjury_Delete
    @PlayerId   INT,
    @InjuryDate DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Player_Injuries
    WHERE  Player_ID   = @PlayerId
      AND  Injury_Date = @InjuryDate;
END
GO

-- ─────────────────────────────────────────────────────────────
-- Returns all injuries joined with Player_Name (for grid display).
CREATE PROCEDURE sp_PlayerInjury_GetAllWithNames
AS
BEGIN
    SET NOCOUNT ON;
    SELECT pi.*,
           p.Player_Name
    FROM   Player_Injuries pi
    INNER  JOIN Players p ON pi.Player_ID = p.Player_ID;
END
GO

-- ─────────────────────────────────────────────────────────────
-- Returns injuries for a specific player joined with Player_Name.
CREATE PROCEDURE sp_PlayerInjury_GetViewByPlayerId
    @PlayerId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT pi.*,
           p.Player_Name
    FROM   Player_Injuries pi
    INNER  JOIN Players p ON pi.Player_ID = p.Player_ID
    WHERE  pi.Player_ID = @PlayerId;
END
GO

-- ─────────────────────────────────────────────────────────────
-- Aggregated league-wide injury statistics, ranked by total days out.
CREATE PROCEDURE sp_PlayerInjury_GetLeagueStatistics
AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.Player_Name,
           COUNT(pi.Player_ID) AS TotalInjuries,
           SUM(pi.Days_Out)    AS TotalDaysOut,
           MAX(pi.Injury_Date) AS LastInjuryDate
    FROM   Players p
    INNER  JOIN Player_Injuries pi ON p.Player_ID = pi.Player_ID
    GROUP  BY p.Player_Name
    ORDER  BY TotalDaysOut DESC;
END
GO


-- ============================================================
-- SECTION 5: PLAYERS
-- ============================================================

CREATE PROCEDURE sp_Player_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Players;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Player_GetAllForGrid
AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.*,
           t.Team_Name
    FROM   Players p
    INNER  JOIN Teams t ON p.Team_ID = t.Team_ID;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Player_GetById
    @PlayerId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM   Players
    WHERE  Player_ID = @PlayerId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Player_GetDistinctPositions
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DISTINCT Position
    FROM   Players
    WHERE  Position IS NOT NULL;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Player_Insert
    @PlayerName  NVARCHAR(100),
    @Position    NVARCHAR(50),
    @Age         INT,
    @Nationality NVARCHAR(100),
    @TeamId      INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Players (Player_Name, Position, Age, Nationality, Team_ID)
    VALUES (@PlayerName, @Position, @Age, @Nationality, @TeamId);
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Player_Update
    @PlayerId    INT,
    @PlayerName  NVARCHAR(100),
    @Position    NVARCHAR(50),
    @Age         INT,
    @Nationality NVARCHAR(100),
    @TeamId      INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Players
    SET    Player_Name = @PlayerName,
           Position    = @Position,
           Age         = @Age,
           Nationality = @Nationality,
           Team_ID     = @TeamId
    WHERE  Player_ID = @PlayerId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Player_Delete
    @PlayerId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Players
    WHERE  Player_ID = @PlayerId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Player_Count
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) FROM Players;
END
GO


-- ============================================================
-- SECTION 6: PLAYER_STATS
-- ============================================================

CREATE PROCEDURE sp_PlayerStat_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Player_Stats;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_PlayerStat_GetById
    @PlayerStatId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM   Player_Stats
    WHERE  Player_Stat_ID = @PlayerStatId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_PlayerStat_Insert
    @MatchId       INT,
    @PlayerId      INT,
    @GoalsScored   INT,
    @Assists       INT,
    @YellowCards   INT,
    @RedCards      INT,
    @MinutesPlayed INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Player_Stats
        (Match_ID, Player_ID, Goals_Scored, Assists,
         Yellow_Cards, Red_Cards, Minutes_Played)
    VALUES
        (@MatchId, @PlayerId, @GoalsScored, @Assists,
         @YellowCards, @RedCards, @MinutesPlayed);
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_PlayerStat_Update
    @PlayerStatId  INT,
    @MatchId       INT,
    @PlayerId      INT,
    @GoalsScored   INT,
    @Assists       INT,
    @YellowCards   INT,
    @RedCards      INT,
    @MinutesPlayed INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Player_Stats
    SET    Match_ID       = @MatchId,
           Player_ID      = @PlayerId,
           Goals_Scored   = @GoalsScored,
           Assists        = @Assists,
           Yellow_Cards   = @YellowCards,
           Red_Cards      = @RedCards,
           Minutes_Played = @MinutesPlayed
    WHERE  Player_Stat_ID = @PlayerStatId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_PlayerStat_Delete
    @PlayerStatId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Player_Stats
    WHERE  Player_Stat_ID = @PlayerStatId;
END
GO

-- ─────────────────────────────────────────────────────────────
-- Returns all player stats with names and match context (for grid).
CREATE PROCEDURE sp_PlayerStat_GetAllForGrid
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ps.*,
           p.Player_Name,
           m.Match_Date,
           ht.Team_Name AS HomeTeam,
           at.Team_Name AS AwayTeam
    FROM   Player_Stats ps
    INNER  JOIN Players p  ON ps.Player_ID    = p.Player_ID
    INNER  JOIN Matches m  ON ps.Match_ID     = m.Match_ID
    INNER  JOIN Teams   ht ON m.Home_Team_ID  = ht.Team_ID
    INNER  JOIN Teams   at ON m.Away_Team_ID  = at.Team_ID;
END
GO

-- ─────────────────────────────────────────────────────────────
-- Returns stats for a specific player with names and match context.
CREATE PROCEDURE sp_PlayerStat_GetByPlayerId
    @PlayerId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ps.*,
           p.Player_Name,
           m.Match_Date,
           ht.Team_Name AS HomeTeam,
           at.Team_Name AS AwayTeam
    FROM   Player_Stats ps
    INNER  JOIN Players p  ON ps.Player_ID    = p.Player_ID
    INNER  JOIN Matches m  ON ps.Match_ID     = m.Match_ID
    INNER  JOIN Teams   ht ON m.Home_Team_ID  = ht.Team_ID
    INNER  JOIN Teams   at ON m.Away_Team_ID  = at.Team_ID
    WHERE  ps.Player_ID = @PlayerId;
END
GO

-- ─────────────────────────────────────────────────────────────
-- Aggregated season totals per player, ranked by Golden Boot rules.
CREATE PROCEDURE sp_PlayerStat_GetLeagueTopPerformers
AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.Player_Name,
           SUM(ps.Goals_Scored)   AS TotalGoals,
           SUM(ps.Assists)        AS TotalAssists,
           SUM(ps.Yellow_Cards)   AS TotalYellowCards,
           SUM(ps.Red_Cards)      AS TotalRedCards,
           SUM(ps.Minutes_Played) AS TotalMinutes
    FROM   Players p
    INNER  JOIN Player_Stats ps ON p.Player_ID = ps.Player_ID
    GROUP  BY p.Player_Name
    ORDER  BY TotalGoals DESC, TotalAssists DESC;
END
GO


-- ============================================================
-- SECTION 7: REFEREES
-- ============================================================

CREATE PROCEDURE sp_Referee_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Referees;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Referee_GetById
    @RefereeId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM   Referees
    WHERE  Referee_ID = @RefereeId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Referee_Insert
    @RefereeName NVARCHAR(100),
    @Nationality NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Referees (Referee_Name, Nationality)
    VALUES (@RefereeName, @Nationality);
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Referee_Update
    @RefereeId   INT,
    @RefereeName NVARCHAR(100),
    @Nationality NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Referees
    SET    Referee_Name = @RefereeName,
           Nationality  = @Nationality
    WHERE  Referee_ID = @RefereeId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Referee_Delete
    @RefereeId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Referees
    WHERE  Referee_ID = @RefereeId;
END
GO


-- ============================================================
-- SECTION 8: STADIUMS
-- ============================================================

CREATE PROCEDURE sp_Stadium_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Stadiums;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Stadium_GetById
    @StadiumId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM   Stadiums
    WHERE  Stadium_ID = @StadiumId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Stadium_Insert
    @StadiumName NVARCHAR(100),
    @City        NVARCHAR(100),
    @Capacity    INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Stadiums (Stadium_Name, City, Capacity)
    VALUES (@StadiumName, @City, @Capacity);
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Stadium_Update
    @StadiumId   INT,
    @StadiumName NVARCHAR(100),
    @City        NVARCHAR(100),
    @Capacity    INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Stadiums
    SET    Stadium_Name = @StadiumName,
           City         = @City,
           Capacity     = @Capacity
    WHERE  Stadium_ID = @StadiumId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Stadium_Delete
    @StadiumId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Stadiums
    WHERE  Stadium_ID = @StadiumId;
END
GO


-- ============================================================
-- SECTION 9: TEAMS
-- ============================================================

CREATE PROCEDURE sp_Team_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Teams;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Team_GetById
    @TeamId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM   Teams
    WHERE  Team_ID = @TeamId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Team_Insert
    @TeamName     NVARCHAR(100),
    @YearFounded  INT,
    @HomeKitColor NVARCHAR(50),
    @StadiumId    INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Teams (Team_Name, Year_Founded, Home_Kit_Color, Stadium_ID)
    VALUES (@TeamName, @YearFounded, @HomeKitColor, @StadiumId);
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Team_Update
    @TeamId       INT,
    @TeamName     NVARCHAR(100),
    @YearFounded  INT,
    @HomeKitColor NVARCHAR(50),
    @StadiumId    INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Teams
    SET    Team_Name     = @TeamName,
           Year_Founded  = @YearFounded,
           Home_Kit_Color = @HomeKitColor,
           Stadium_ID    = @StadiumId
    WHERE  Team_ID = @TeamId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Team_Delete
    @TeamId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Teams
    WHERE  Team_ID = @TeamId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_Team_Count
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) FROM Teams;
END
GO

-- ─────────────────────────────────────────────────────────────
-- Returns all teams with Stadium_Name resolved via INNER JOIN.
CREATE PROCEDURE sp_Team_GetAllForGrid
AS
BEGIN
    SET NOCOUNT ON;
    SELECT t.*,
           s.Stadium_Name
    FROM   Teams t
    INNER  JOIN Stadiums s ON t.Stadium_ID = s.Stadium_ID;
END
GO


-- ============================================================
-- SECTION 10: TEAM_STATS
-- ============================================================

CREATE PROCEDURE sp_TeamStat_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Team_Stats;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_TeamStat_GetById
    @TeamStatId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM   Team_Stats
    WHERE  Team_Stat_ID = @TeamStatId;
END
GO

-- ─────────────────────────────────────────────────────────────
-- Aggregated league-wide standings, ranked by possession then shots.
CREATE PROCEDURE sp_TeamStat_GetLeagueStandings
AS
BEGIN
    SET NOCOUNT ON;
    SELECT t.Team_Name,
           COUNT(ts.Match_ID)                                     AS MatchesPlayed,
           CAST(ROUND(AVG(ts.Possession_Percentage), 2) AS DECIMAL(5,2)) AS AvgPossession,
           SUM(ts.Shots_On_Target)                                AS TotalShots,
           SUM(ts.Corners)                                        AS TotalCorners,
           SUM(ts.Fouls)                                          AS TotalFouls
    FROM   Teams t
    INNER  JOIN Team_Stats ts ON t.Team_ID = ts.Team_ID
    GROUP  BY t.Team_Name
    ORDER  BY AvgPossession DESC, TotalShots DESC;
END
GO

-- ─────────────────────────────────────────────────────────────
-- Returns team stats for a specific team with readable names and match context.
CREATE PROCEDURE sp_TeamStat_GetByTeamId
    @TeamId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ts.*,
           t.Team_Name,
           m.Match_Date,
           ht.Team_Name AS HomeTeam,
           at.Team_Name AS AwayTeam
    FROM   Team_Stats ts
    INNER  JOIN Teams   t  ON ts.Team_ID      = t.Team_ID
    INNER  JOIN Matches m  ON ts.Match_ID     = m.Match_ID
    INNER  JOIN Teams   ht ON m.Home_Team_ID  = ht.Team_ID
    INNER  JOIN Teams   at ON m.Away_Team_ID  = at.Team_ID
    WHERE  ts.Team_ID = @TeamId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_TeamStat_Insert
    @MatchId              INT,
    @TeamId               INT,
    @PossessionPercentage DECIMAL(5,2),
    @ShotsOnTarget        INT,
    @Corners              INT,
    @Fouls                INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Team_Stats
        (Match_ID, Team_ID, Possession_Percentage, Shots_On_Target, Corners, Fouls)
    VALUES
        (@MatchId, @TeamId, @PossessionPercentage, @ShotsOnTarget, @Corners, @Fouls);
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_TeamStat_Update
    @TeamStatId           INT,
    @MatchId              INT,
    @TeamId               INT,
    @PossessionPercentage DECIMAL(5,2),
    @ShotsOnTarget        INT,
    @Corners              INT,
    @Fouls                INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Team_Stats
    SET    Match_ID              = @MatchId,
           Team_ID               = @TeamId,
           Possession_Percentage = @PossessionPercentage,
           Shots_On_Target       = @ShotsOnTarget,
           Corners               = @Corners,
           Fouls                 = @Fouls
    WHERE  Team_Stat_ID = @TeamStatId;
END
GO

-- ─────────────────────────────────────────────────────────────
CREATE PROCEDURE sp_TeamStat_Delete
    @TeamStatId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Team_Stats
    WHERE  Team_Stat_ID = @TeamStatId;
END
GO

-- ============================================================
-- END OF SCRIPT  (38 stored procedures total)
-- ============================================================
