using System;
using System.Collections.Generic;
using System.Text;
//20171212:Cesar - added using statement
using SQLite;
using FRCScoutingTeam3932.Models;
using System.Linq;
using System.Threading.Tasks;

namespace FRCScoutingTeam3932.Data
{
    public class RobotGameDatabase
    {

        readonly SQLiteAsyncConnection database;

        public RobotGameDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            /* Preparing for next year
            database.CreateTableAsync<GameColumns>().Wait();
            */
            database.CreateTableAsync<RobotGame>().Wait();
        }

        /* Preparing for next year
        public Task<List<GameColumns>> GetColumnsByYearAsync(int year)
        {
            return database.Table<GameColumns>().Where(c => c.match_year == year).ToListAsync();
        }
        */

        /*
        public Task<int> EmptyDatabase()
        {
            return database.DropTableAsync<RobotGame>();
        }
        */

        public Task<List<RobotGame>> GetGamesAsync()
        {
            return database.Table<RobotGame>().ToListAsync();
        }

        public Task<List<RobotGame>> GetGamesByTeamAsync(int year, int venue, int team)
        {
            return database.Table<RobotGame>().Where(t => t.Team == team).ToListAsync();
            /* Preparing for next year
            return database.Table<RobotGame>().Where(t => t.match_year == year && t.match_venue_id == venue && t.team_id == team).ToListAsync();
            */
        }

        public Task<List<RobotGame>> GetGamesByMatchAsync(int year, int venue, int match)
        {
            return database.Table<RobotGame>().Where(t => t.Game == match).ToListAsync();
            /* Preparing for next year
            return database.Table<RobotGame>().Where(t => t.match_year == year && t.match_venue_id == venue && t.match_id == match).ToListAsync();
            */
        }

        public Task<RobotGame> GetGameAsync(int ID)
        {
            return database.Table<RobotGame>().Where(t => t.ID == ID).FirstOrDefaultAsync();
            /* Preparing for next year
            return database.Table<RobotGame>().Where(t => t.idmatch_data == ID).FirstOrDefaultAsync();
            */
        }

        public Task<int> SaveGameAsync(RobotGame robotGame)
        {
            if (robotGame.ID != 0)
            /* Preparing for next year
            if (robotGame.idmatch_data != 0)
            */
            {
                return database.UpdateAsync(robotGame);
            }
            else
            {
                return database.InsertAsync(robotGame);
            }
        }

        public Task<int> DeleteGameAsync(RobotGame robotGame)
        {
            return database.DeleteAsync(robotGame);
        }

        public Task<int> BulkImportAsync(string qryBulkImport)
        {
            return database.ExecuteAsync(qryBulkImport);
        }

        public Task<string> ExportGamesAsync()
        {
            string tbl = "' DECLARE @tmpTable TABLE ([DeviceID] NVARCHAR(255), [ID] UNIQUEIDENTIFIER, [Team] INT, [Ally1] INT, [Ally2] INT, [Game] INT, [AutoDescendPlatform] INT, [AutoPlaceHatch] INT, [AutoPlaceCargo] INT, [TelePlaceHatchLow] INT, [TelePlaceHatchMed] INT, [TelePlaceHatchHigh] INT, [TelePlaceCargoLow] INT, [TelePlaceCargoMed] INT, [TelePlaceCargoHigh] INT, [TeleHabHeight] INT, [TeleDefensePlayed] INT, [Alliance] [varchar](100), [Station] INT, [CreatedAt] DATETIME)' ||x'0d'||x'0a' ||x'0d'||x'0a'";

            string ins = " ' INSERT INTO @tmpTable ([DeviceID], [ID], [Team], [Ally1], [Ally2], [Game], [AutoDescendPlatform], [AutoPlaceHatch], [AutoPlaceCargo], [TelePlaceHatchLow], [TelePlaceHatchMed], [TelePlaceHatchHigh], [TelePlaceCargoLow], [TelePlaceCargoMed], [TelePlaceCargoHigh], [TeleHabHeight], [TeleDefensePlayed], [Alliance], [Station], [CreatedAt]) VALUES ' ||x'0d'||x'0a' ||x'0d'||x'0a'";

            string sel = " group_concat('(''' || CAST([deviceID] AS NVARCHAR(100)) || '''' || ', ''' || CAST([mergedID] AS NVARCHAR(100)) || '''' || ', ' || CAST(COALESCE([Team], 0) AS VARCHAR(4)) || ', ' || CAST(COALESCE([Ally1], 0) AS VARCHAR(4)) || ', ' || CAST(COALESCE([Ally2], 0) AS VARCHAR(4)) || ', ' || CAST(COALESCE([Game], 0) AS VARCHAR(4)) || ', ' || CAST(COALESCE([AutoDescendPlatform], 0) AS VARCHAR(4)) || ', ' || CAST(COALESCE([AutoPlaceHatch], 0) AS VARCHAR(4)) || ', ' || CAST(COALESCE([AutoPlaceCargo], 0) AS VARCHAR(4)) || ', ' || CAST(COALESCE([TelePlaceHatchLow], 0) AS VARCHAR(4)) || ', ' || CAST(COALESCE([TelePlaceHatchMed], 0) AS VARCHAR(4)) || ', ' || CAST(COALESCE([TelePlaceHatchHigh], 0) AS VARCHAR(4)) || ', ' || CAST(COALESCE([TelePlaceCargoLow], 0) AS VARCHAR(4)) || ', ' || CAST(COALESCE([TelePlaceCargoMed], 0) AS VARCHAR(4)) || ', ' || CAST(COALESCE([TelePlaceCargoHigh], 0) AS VARCHAR(4)) || ', ' || CAST(COALESCE([TeleHabHeight], 0) AS VARCHAR(4)) || ', ' || CAST(COALESCE([TeleDefensePlayed], 0) AS VARCHAR(4)) || ', ''' || COALESCE([Alliance], '') || '''' || ', ' || CAST(COALESCE([Station], 0) AS VARCHAR(4)) || ', ''' || CAST([CreatedAt] AS NVARCHAR(100)) || ''')', x'0d'||x'0a'||',')";

            string mrg = "  x'0d'||x'0a'|| x'0d'||x'0a'|| ' MERGE FRCScoutingTeam3932 AS T USING @tmpTable AS S ON (T.ID = S.ID)' ||x'0d'||x'0a'";

            string nom = " x'0d'||x'0a'|| ' WHEN NOT MATCHED BY TARGET THEN ' ||x'0d'||x'0a'|| 'INSERT ([DeviceID], [ID], [Team], [Ally1], [Ally2], [Game], [AutoDescendPlatform], [AutoPlaceHatch], [AutoPlaceCargo], [TelePlaceHatchLow], [TelePlaceHatchMed], [TelePlaceHatchHigh], [TelePlaceCargoLow], [TelePlaceCargoMed], [TelePlaceCargoHigh], [TeleHabHeight], [TeleDefensePlayed], [Alliance], [Station], [CreatedAt]) VALUES ' ||x'0d'||x'0a'|| ' (S.[DeviceID], S.[ID], S.[Team], S.[Ally1], S.[Ally2], S.[Game], S.[AutoDescendPlatform], S.[AutoPlaceHatch], S.[AutoPlaceCargo], S.[TelePlaceHatchLow], S.[TelePlaceHatchMed], S.[TelePlaceHatchHigh], S.[TelePlaceCargoLow], S.[TelePlaceCargoMed], S.[TelePlaceCargoHigh], S.[TeleHabHeight], S.[TeleDefensePlayed], S.[Alliance], S.[Station], S.[CreatedAt])'";

            string mat = " x'0d'||x'0a'|| ' WHEN MATCHED THEN ' ||x'0d'||x'0a'|| ' UPDATE SET  T.[DeviceID] = S.[DeviceID], T.[ID] = S.[ID], T.[Team] = S.[Team], T.[Ally1] = S.[Ally1], T.[Ally2] = S.[Ally2], T.[Game] = S.[Game], T.[AutoDescendPlatform] = S.[AutoDescendPlatform], T.[AutoPlaceHatch] = S.[AutoPlaceHatch], T.[AutoPlaceCargo] = S.[AutoPlaceCargo], T.[TelePlaceHatchLow] = S.[TelePlaceHatchLow], T.[TelePlaceHatchMed] = S.[TelePlaceHatchMed], T.[TelePlaceHatchHigh] = S.[TelePlaceHatchHigh], T.[TelePlaceCargoLow] = S.[TelePlaceCargoLow], T.[TelePlaceCargoMed] = S.[TelePlaceCargoMed], T.[TelePlaceCargoHigh] = S.[TelePlaceCargoHigh], T.[TeleHabHeight] = S.[TeleHabHeight], T.[TeleDefensePlayed] = S.[TeleDefensePlayed], T.[Alliance] = S.[Alliance], T.[Station] = S.[Station], T.[CreatedAt] = S.[CreatedAt];'";

            return database.ExecuteScalarAsync<string>("SELECT " + tbl + " || " + ins + " || " + sel + " || " + mrg + " || " + nom + " || " + mat + " FROM RobotGame");
        }


    }
}
