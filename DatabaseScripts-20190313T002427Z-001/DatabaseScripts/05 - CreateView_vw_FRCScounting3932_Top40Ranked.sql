USE [FRCScouting2019]
GO

/****** Object:  View [dbo].[vw_FRCScounting2018_Ranked]    Script Date: 3/10/2019 10:01:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_FRCScounting3932_Top40Ranked]

AS

--EXEC sp_columns [vw_FRCScounting3932_GameTeam]

SELECT TOP 40
	  Team
	, SUM(AutoDescendPlatform) AS AutoDescendPlatform
	, SUM(AutoPlaceHatch) AS AutoPlaceHatch
	, SUM(AutoPlaceCargo) AS AutoPlaceCargo
	, SUM(TelePlaceHatchLow) AS TelePlaceHatchLow
	, SUM(TelePlaceHatchMed) AS TelePlaceHatchMed
	, SUM(TelePlaceHatchHigh) AS TelePlaceHatchHigh
	, SUM(TelePlaceCargoLow) AS TelePlaceCargoLow
	, SUM(TelePlaceCargoMed) AS TelePlaceCargoMed
	, SUM(TelePlaceCargoHigh) AS TelePlaceCargoHigh
	, SUM(TeleHabHeight) AS TeleHabHeight
	, SUM(TeleDefensePlayed) AS TeleDefensePlayed
	, SUM(AutonomousAggregate) AS AutonomousAggregate
	, SUM(TeleOpAggregate) AS TeleOpAggregate
	, SUM(OverallAggregate) AS OverallAggregate
FROM vw_FRCScounting3932_GameTeam 
GROUP BY Team
ORDER BY
	  SUM(OverallAggregate) DESC
	, SUM(TeleOpAggregate) DESC
	, SUM(AutonomousAggregate) DESC

GO