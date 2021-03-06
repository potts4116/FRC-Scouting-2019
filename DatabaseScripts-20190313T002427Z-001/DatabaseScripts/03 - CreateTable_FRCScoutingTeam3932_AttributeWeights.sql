USE [FRCScouting2019]
GO
/****** Object:  Table [dbo].[FRCScoutingTeam3932_AttributeWeights]    Script Date: 3/10/2019 10:28:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FRCScoutingTeam3932_AttributeWeights](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PointsAutoDescendPlatform1] [int] NULL,
	[PointsAutoDescendPlatform2] [int] NULL,
	[PointsAutoPlaceHatch] [int] NULL,
	[PointsAutoPlaceCargo] [int] NULL,
	[PointsTelePlaceHatchLow] [int] NULL,
	[PointsTelePlaceHatchMed] [int] NULL,
	[PointsTelePlaceHatchHigh] [int] NULL,
	[PointsTelePlaceCargoLow] [int] NULL,
	[PointsTelePlaceCargoMed] [int] NULL,
	[PointsTelePlaceCargoHigh] [int] NULL,
	[PointsTeleHabHeight1] [int] NULL,
	[PointsTeleHabHeight2] [int] NULL,
	[PointsTeleHabHeight3] [int] NULL,
	[PointsTeleDefensePlayed] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[FRCScoutingTeam3932_AttributeWeights] ON 

INSERT [dbo].[FRCScoutingTeam3932_AttributeWeights] ([ID], [PointsAutoDescendPlatform1], [PointsAutoDescendPlatform2], [PointsAutoPlaceHatch], [PointsAutoPlaceCargo], [PointsTelePlaceHatchLow], [PointsTelePlaceHatchMed], [PointsTelePlaceHatchHigh], [PointsTelePlaceCargoLow], [PointsTelePlaceCargoMed], [PointsTelePlaceCargoHigh], [PointsTeleHabHeight1], [PointsTeleHabHeight2], [PointsTeleHabHeight3], [PointsTeleDefensePlayed]) VALUES (1, 10, 20, 15, 15, 8, 10, 12, 10, 12, 15, 10, 20, 40, 5)

SET IDENTITY_INSERT [dbo].[FRCScoutingTeam3932_AttributeWeights] OFF
