using System;
using System.Collections.Generic;
using System.Text;
//20171212:Cesar - added using statement
using SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace FRCScoutingTeam3932.Models
{
    [Table("RobotGame")]
    public class RobotGame
    {
        [PrimaryKey, AutoIncrement]
        /* Preparing for next year
        public int  idmatch_data { get; set; }
        public int  match_year { get; set; }
        public int  match_venue_id { get; set; }
        public int  registrant_id { get; set; }
        [MaxLength(255)]
        public string registrant_device_id { get; set; }
        public int  match_id { get; set; }
        public int  team_id { get; set; }
        public int  ally1_id { get; set; }
        public int  all2_id { get; set; }
        public int  statistic_int01 { get; set; }
        public int  statistic_int02 { get; set; }
        public int  statistic_int03 { get; set; }
        public int  statistic_int04 { get; set; }
        public int  statistic_int05 { get; set; }
        public int  statistic_int06 { get; set; }
        public int  statistic_int07 { get; set; }
        public int  statistic_int08 { get; set; }
        public int  statistic_int09 { get; set; }
        public int  statistic_int10 { get; set; }
        public int  statistic_int11 { get; set; }
        public int  statistic_int12 { get; set; }
        public int  statistic_int13 { get; set; }
        public int  statistic_int14 { get; set; }
        public int  statistic_int15 { get; set; }
        public int  statistic_int16 { get; set; }
        public int  statistic_int17 { get; set; }
        public int  statistic_int18 { get; set; }
        public int  statistic_int19 { get; set; }
        public int  statistic_int20 { get; set; }
        public bool statistic_bit01 { get; set; }
        public bool statistic_bit02 { get; set; }
        public bool statistic_bit03 { get; set; }
        public bool statistic_bit04 { get; set; }
        public bool statistic_bit05 { get; set; }
        public bool statistic_bit06 { get; set; }
        public bool statistic_bit07 { get; set; }
        public bool statistic_bit08 { get; set; }
        public bool statistic_bit09 { get; set; }
        public bool statistic_bit10 { get; set; }
        */
        public int ID { get; set; }

        public Guid mergedID { get; set; }

        public string deviceID { get; set; }

        //[MaxLength(100)]
        public int Team { get; set; }

        //[MaxLength(100)]
        public int Ally1 { get; set; }

        //[MaxLength(100)]
        public int Ally2 { get; set; }

        //[MaxLength(100)]
        public int Game { get; set; }

        public int AutoDescendPlatform { get; set; }

        public int AutoPlaceHatch { get; set; }

        public int AutoPlaceCargo { get; set; }

        public int TelePlaceHatchLow { get; set; }

        public int TelePlaceHatchMed { get; set; }

        public int TelePlaceHatchHigh { get; set; }

        public int TelePlaceCargoLow { get; set; }

        public int TelePlaceCargoMed { get; set; }

        public int TelePlaceCargoHigh { get; set; }

        public int TeleHabHeight { get; set; }

        public int TeleDefensePlayed { get; set; }

        public string Alliance { get; set; }

        public int Station { get; set; }

        public string CreatedAt { get; set; }

        [MaxLength(1000)]
        public string Comment { get; set; }
    }
}
