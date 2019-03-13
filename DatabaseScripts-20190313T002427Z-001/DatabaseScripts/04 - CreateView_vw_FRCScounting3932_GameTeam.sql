USE [FRCScouting2019]
GO

/****** Object:  View [dbo].[vw_FRCScounting2018_GameTeam]    Script Date: 3/10/2019 8:37:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_FRCScounting3932_GameTeam]

AS

WITH cteView AS (

	SELECT
		  s.Game
		, s.Team
		, CAST(s.Game AS VARCHAR(10)) + '-' + CAST(s.Team AS VARCHAR(10))           AS [GameTeam]
		, CASE
			WHEN s.[AutoDescendPlatform] = 1 THEN p.[PointsAutoDescendPlatform1]
			WHEN s.[AutoDescendPlatform] = 2 THEN p.[PointsAutoDescendPlatform2]
			ELSE 0
		END                                                                         AS [AutoDescendPlatform]
		, ISNULL(s.[AutoPlaceHatch], 0) * p.[PointsAutoPlaceHatch]                  AS [AutoPlaceHatch]
		, ISNULL(s.[AutoPlaceCargo], 0) * p.[PointsAutoPlaceCargo]                  AS [AutoPlaceCargo]
		, ISNULL(s.[TelePlaceHatchLow], 0) * p.[PointsTelePlaceHatchLow]            AS [TelePlaceHatchLow]
		, ISNULL(s.[TelePlaceHatchMed], 0) * p.[PointsTelePlaceHatchMed]            AS [TelePlaceHatchMed]
		, ISNULL(s.[TelePlaceHatchHigh], 0) * p.[PointsTelePlaceHatchHigh]          AS [TelePlaceHatchHigh]
		, ISNULL(s.[TelePlaceCargoLow], 0) * p.[PointsTelePlaceCargoLow]            AS [TelePlaceCargoLow]
		, ISNULL(s.[TelePlaceCargoMed], 0) * p.[PointsTelePlaceCargoMed]            AS [TelePlaceCargoMed]
		, ISNULL(s.[TelePlaceCargoHigh], 0) * p.[PointsTelePlaceCargoHigh]          AS [TelePlaceCargoHigh]
		, CASE
			WHEN s.[TeleHabHeight] = 1 THEN p.[PointsTeleHabHeight1]
			WHEN s.[TeleHabHeight] = 2 THEN p.[PointsTeleHabHeight2]
			WHEN s.[TeleHabHeight] = 3 THEN p.[PointsTeleHabHeight3]
			ELSE 0
		END                                                                         AS [TeleHabHeight]
		, ISNULL(s.[TeleDefensePlayed], 0) * p.[PointsTeleDefensePlayed]            AS [TeleDefensePlayed]

	FROM dbo.FRCScoutingTeam3932 AS s WITH (NOLOCK)

	INNER JOIN FRCScoutingTeam3932_AttributeWeights AS p WITH (NOLOCK) ON p.ID = (SELECT TOP 1 ID FROM FRCScoutingTeam3932_AttributeWeights WITH (NOLOCK) ORDER BY ID DESC)
)

SELECT
	  cte.Team
	, cte.[AutoDescendPlatform]
	, cte.[AutoPlaceHatch]
	, cte.[AutoPlaceCargo]
	, cte.[TelePlaceHatchLow]
	, cte.[TelePlaceHatchMed]
	, cte.[TelePlaceHatchHigh]
	, cte.[TelePlaceCargoLow]
	, cte.[TelePlaceCargoMed]
	, cte.[TelePlaceCargoHigh]
	, cte.[TeleHabHeight]
	, cte.[TeleDefensePlayed]
	, (cte.[AutoDescendPlatform] + cte.[AutoPlaceHatch] + cte.[AutoPlaceCargo]) AS [AutonomousAggregate]
	, (cte.[TelePlaceHatchLow] + cte.[TelePlaceHatchMed] + cte.[TelePlaceHatchHigh] + cte.[TelePlaceCargoLow] + cte.[TelePlaceCargoMed] + cte.[TelePlaceCargoHigh] + cte.[TeleHabHeight] + cte.[TeleDefensePlayed]) AS [TeleOpAggregate]
	, (cte.[AutoDescendPlatform] + cte.[AutoPlaceHatch] + cte.[AutoPlaceCargo] + cte.[TelePlaceHatchLow] + cte.[TelePlaceHatchMed] + cte.[TelePlaceHatchHigh] + cte.[TelePlaceCargoLow] + cte.[TelePlaceCargoMed] + cte.[TelePlaceCargoHigh] + cte.[TeleHabHeight] + cte.[TeleDefensePlayed]) AS [OverallAggregate]

FROM cteView AS cte

GO