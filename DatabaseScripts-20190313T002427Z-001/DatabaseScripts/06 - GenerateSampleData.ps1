$gameCount = 64

$sqlSyntax = "MSSQL" #"MSSQL" #"MySQL"

$selectedAlliance = $null #"Blue" #"Red" #$null

$selectedPosition = $null #1 #2 #3 #$null

# The values above this line can be modified, but you shouldn't modify anything below this line

$Alliances = "Blue", "Red"

$Stations = 1,2,3

$scriptDir = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent

$dtprefix = Get-Date -Format yyyyMMddHHmmss
$outfile  = $dtprefix + "_FRC2019_"
if ($selectedAlliance) {$outfile += $selectedAlliance} else {$outfile += "Both"}
$outfile += "_"
if ($selectedPosition) {$outfile += $selectedPosition} else {$outfile += "All"}
$outfile += "_SampleData.sql"

$outPath = "$scriptDir\$outfile"

$assignedTeams = @{}
$arrayTeams	= @()
$temp = Get-Random -SetSeed 2018 -Maximum 10000 -Minimum 50
for ($Game = 1; $Game -le  $gameCount/2; $Game++) {
	$Team = Get-Random -Maximum 10000 -Minimum 50
	while ($assignedTeams.ContainsValue($Team)) {
		$Team = Get-Random -Maximum 10000 -Minimum 50
	}
	$assignedTeams[$Team] = 1
	$arrayTeams += $Team
}

$datetimefunc = ""
if($sqlSyntax -eq "MSSQL") {
	$datetimefunc = "SYSDATETIME()"
} else {
	$datetimefunc = "SYSDATE()"
}

$GameAllianceStation = @{}

for ($Game = 1; $Game -le $gameCount; $Game++) {
	$Team1 = $arrayTeams[(Get-Random -Maximum $assignedTeams.Count -Minimum 0)]
	$Team2 = $arrayTeams[(Get-Random -Maximum $assignedTeams.Count -Minimum 0)]
	while ($Team2 -eq $Team1) {
		$Team2 = $arrayTeams[(Get-Random -Maximum $assignedTeams.Count -Minimum 0)]
	}
	$Team3 = $arrayTeams[(Get-Random -Maximum $assignedTeams.Count -Minimum 0)]
	while (($Team3 -eq $Team2) -or ($Team3 -eq $Team1)) {
		$Team3 = $arrayTeams[(Get-Random -Maximum $assignedTeams.Count -Minimum 0)]
	}
	$Team4 = $arrayTeams[(Get-Random -Maximum $assignedTeams.Count -Minimum 0)]
	while (($Team4 -eq $Team3) -or ($Team4 -eq $Team2) -or ($Team4 -eq $Team1)) {
		$Team4 = $arrayTeams[(Get-Random -Maximum $assignedTeams.Count -Minimum 0)]
	}
	$Team5 = $arrayTeams[(Get-Random -Maximum $assignedTeams.Count -Minimum 0)]
	while (($Team5 -eq $Team4) -or ($Team5 -eq $Team3) -or ($Team5 -eq $Team2) -or ($Team5 -eq $Team1)) {
		$Team5 = $arrayTeams[(Get-Random -Maximum $assignedTeams.Count -Minimum 0)]
	}
	$Team6 = $arrayTeams[(Get-Random -Maximum $assignedTeams.Count -Minimum 0)]
	while (($Team6 -eq $Team5) -or ($Team6 -eq $Team4) -or ($Team6 -eq $Team3) -or ($Team6 -eq $Team2) -or ($Team6 -eq $Team1)) {
		$Team6 = $arrayTeams[(Get-Random -Maximum $assignedTeams.Count -Minimum 0)]
	}

	$GameAllianceStation[($Game.ToString() + "_" + $Alliances[0] + "_1")] = $Team1
	$GameAllianceStation[($Game.ToString() + "_" + $Alliances[0] + "_2")] = $Team2
	$GameAllianceStation[($Game.ToString() + "_" + $Alliances[0] + "_3")] = $Team3
	$GameAllianceStation[($Game.ToString() + "_" + $Alliances[1] + "_1")] = $Team4
	$GameAllianceStation[($Game.ToString() + "_" + $Alliances[1] + "_2")] = $Team5
	$GameAllianceStation[($Game.ToString() + "_" + $Alliances[1] + "_3")] = $Team6
}

#echo $GameAllianceStation

if ($sqlSyntax -eq "MSSQL") {
	echo " DECLARE @tmpTable TABLE ([DeviceID] [varchar](100), [ID] [uniqueidentifier], [Team] [int], [Ally1] [int], [Ally2] [int], [Game] [int], [AutoDescendPlatform] [int], [AutoPlaceHatch] [int], [AutoPlaceCargo] [int], [TelePlaceHatchLow] [int], [TelePlaceHatchMed] [int], [TelePlaceHatchHigh] [int], [TelePlaceCargoLow] [int], [TelePlaceCargoMed] [int], [TelePlaceCargoHigh] [int], [TeleHabHeight] [int], [TeleDefensePlayed] [int], [Alliance] [varchar](100), [Station] [int], [CreatedAt] [datetime])" >> $outPath
	echo " INSERT INTO @tmpTable ([DeviceID], [ID], [Team], [Ally1], [Ally2], [Game], [AutoDescendPlatform], [AutoPlaceHatch], [AutoPlaceCargo], [TelePlaceHatchLow], [TelePlaceHatchMed], [TelePlaceHatchHigh], [TelePlaceCargoLow], [TelePlaceCargoMed], [TelePlaceCargoHigh], [TeleHabHeight], [TeleDefensePlayed], [Alliance], [Station], [CreatedAt]) VALUES" >> $outPath
} else {
	echo " REPLACE INTO `FRCScoutingTeam3932` VALUES " >> $outPath
}
$comma = " "

for ($Game = 1; $Game -le $gameCount; $Game++) {

	for($a = 0; $a -lt $Alliances.Count; $a++) {

		if (!$selectedAlliance -or $Alliances[$a] -eq $selectedAlliance) {

			for($Station = 1; $Station -le $Stations.Count; $Station++) {

				if (!$selectedPosition -or $Station -eq $selectedPosition) {

					$Alliance             = $Alliances[$a]

					$DeviceID             = "Android" + $Alliance + $Station

					$ID                   = New-Guid

					$Team                 = $GameAllianceStation[($Game.ToString() + "_" + $Alliance + "_" + $Station.ToString())]

					$Ally1                = if ($Station -eq 1) { $GameAllianceStation[($Game.ToString() + "_" + $Alliance + "_2")] } else { $GameAllianceStation[($Game.ToString() + "_" + $Alliance + "_1")] }

					$Ally2                = if ($Station -eq 3) { $GameAllianceStation[($Game.ToString() + "_" + $Alliance + "_2")] } else { $GameAllianceStation[($Game.ToString() + "_" + $Alliance + "_3")] }

					$AutoDescendPlatform    = Get-Random -Maximum 3 -Minimum 0 #Use 2, 0 for BIT values

					$AutoPlaceHatch         = Get-Random -Maximum 3 -Minimum 0

					$AutoPlaceCargo         = Get-Random -Maximum 3 -Minimum 0

					$TelePlaceHatchLow      = Get-Random -Maximum 9 -Minimum 0

					$TelePlaceHatchMed      = Get-Random -Maximum 5 -Minimum 0

					$TelePlaceHatchHigh     = Get-Random -Maximum 5 -Minimum 0

					$TelePlaceCargoLow      = Get-Random -Maximum 9 -Minimum 0

					$TelePlaceCargoMed      = Get-Random -Maximum 5 -Minimum 0

					$TelePlaceCargoHigh     = Get-Random -Maximum 5 -Minimum 0

					$TeleHabHeight          = if ((Get-Random -Maximum 6 -Minimum 0) -eq 0) {
						0
					} else {
						if ((Get-Random -Maximum 5 -Minimum 0) -eq 0) {
							3
						} else {
							if ((Get-Random -Maximum 2 -Minimum 0) -eq 0) {
								1
							} else {
								2
							}
						}
					} # On average, 1 of every 6 rows will have this set to 0, from the remainder, 1 will have it set to 3, and the other will be evenly split at 1 or 2

					$TeleDefensePlayed      = Get-Random -Maximum 5 -Minimum 0

					#Write-Host "$DeviceID`t$ID`t$Team`t$Ally1`t$Ally2`t$Game`t$AutoDescendPlatform`t$AutoPlaceHatch`t$AutoPlaceCargo`t$TelePlaceHatchLow`t$TelePlaceHatchMed`t$TelePlaceHatchHigh`t$TelePlaceCargoLow`t$TelePlaceCargoMed`t$TelePlaceCargoHigh`t$TeleHabHeight`t$TeleDefensePlayed`t$Alliance`t$Station"

					echo "$comma ('$DeviceID', '$ID', $Team, $Ally1, $Ally2, $Game, $AutoDescendPlatform, $AutoPlaceHatch, $AutoPlaceCargo, $TelePlaceHatchLow, $TelePlaceHatchMed, $TelePlaceHatchHigh, $TelePlaceCargoLow, $TelePlaceCargoMed, $TelePlaceCargoHigh, $TeleHabHeight, $TeleDefensePlayed, '$Alliance', $Station, $datetimefunc)" >> $outPath

					$comma = ","

				}

			}

		}

	}

}
if ($sqlSyntax -eq "MSSQL") {
	echo " MERGE FRCScoutingTeam3932 AS T USING @tmpTable AS S ON (T.ID = S.ID)" >> $outPath
	echo " WHEN NOT MATCHED BY TARGET THEN" >> $outPath
	echo " INSERT ([DeviceID], [ID], [Team], [Ally1], [Ally2], [Game], [AutoDescendPlatform], [AutoPlaceHatch], [AutoPlaceCargo], [TelePlaceHatchLow], [TelePlaceHatchMed], [TelePlaceHatchHigh], [TelePlaceCargoLow], [TelePlaceCargoMed], [TelePlaceCargoHigh], [TeleHabHeight], [TeleDefensePlayed], [Alliance], [Station], [CreatedAt]) VALUES" >> $outPath
	echo " (s.[DeviceID], s.[ID], s.[Team], s.[Ally1], s.[Ally2], s.[Game], s.[AutoDescendPlatform], s.[AutoPlaceHatch], s.[AutoPlaceCargo], s.[TelePlaceHatchLow], s.[TelePlaceHatchMed], s.[TelePlaceHatchHigh], s.[TelePlaceCargoLow], s.[TelePlaceCargoMed], s.[TelePlaceCargoHigh], s.[TeleHabHeight], s.[TeleDefensePlayed], s.[Alliance], s.[Station], s.[CreatedAt])" >> $outPath
	echo " WHEN MATCHED THEN" >> $outPath
	echo " UPDATE SET  T.[DeviceID] = S.[DeviceID], T.[ID] = S.[ID], T.[Team] = S.[Team], T.[Ally1] = S.[Ally1], T.[Ally2] = S.[Ally2], T.[Game] = S.[Game], T.[AutoDescendPlatform] = S.[AutoDescendPlatform], T.[AutoPlaceHatch] = S.[AutoPlaceHatch], T.[AutoPlaceCargo] = S.[AutoPlaceCargo], T.[TelePlaceHatchLow] = S.[TelePlaceHatchLow], T.[TelePlaceHatchMed] = S.[TelePlaceHatchMed], T.[TelePlaceHatchHigh] = S.[TelePlaceHatchHigh], T.[TelePlaceCargoLow] = S.[TelePlaceCargoLow], T.[TelePlaceCargoMed] = S.[TelePlaceCargoMed], T.[TelePlaceCargoHigh] = S.[TelePlaceCargoHigh], T.[TeleHabHeight] = S.[TeleHabHeight], T.[TeleDefensePlayed] = S.[TeleDefensePlayed], T.[Alliance] = S.[Alliance], T.[Station] = S.[Station], T.[CreatedAt] = S.[CreatedAt]" >> $outPath
}
echo ";" >> $outPath