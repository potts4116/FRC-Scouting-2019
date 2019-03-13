USE [FRCScouting2019]
GO

/****** Object:  Table [dbo].[FRCScoutingTeam3932]    Script Date: 3/10/2019 8:19:13 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FRCScoutingTeam3932] (
	[DeviceID] [varchar](100) NOT NULL,
	[ID] [uniqueidentifier] NOT NULL,
	[Team] [int] NOT NULL,
	[Ally1] [int] NOT NULL,
	[Ally2] [int] NOT NULL,
	[Game] [int] NOT NULL,
	[AutoDescendPlatform] [int] NULL,
	[AutoPlaceHatch] [int] NULL,
	[AutoPlaceCargo] [int] NULL,
	[TelePlaceHatchLow] [int] NULL,
	[TelePlaceHatchMed] [int] NULL,
	[TelePlaceHatchHigh] [int] NULL,
	[TelePlaceCargoLow] [int] NULL,
	[TelePlaceCargoMed] [int] NULL,
	[TelePlaceCargoHigh] [int] NULL,
	[TeleHabHeight] [int] NULL,
	[TeleDefensePlayed] [int] NULL,
	[Alliance] [varchar](100) NULL,
	[Station] [int] NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_FRCScoutingTeam3932] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO