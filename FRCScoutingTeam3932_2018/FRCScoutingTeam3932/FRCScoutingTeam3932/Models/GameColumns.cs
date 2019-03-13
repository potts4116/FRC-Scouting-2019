using System;
using System.Collections.Generic;
using System.Text;
//20171212:Cesar - added using statement
using SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace FRCScoutingTeam3932.Models
{
    [Table("GameColumns")]
    public class GameColumns
    {
        [PrimaryKey, AutoIncrement]
        public int idmatch_columns { get; set; }
        public int match_year { get; set; }
        public int statistic_int01_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int01_header { get; set; }
        [MaxLength(255)]
        public string statistic_int01_descri { get; set; }
        public int statistic_int02_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int02_header { get; set; }
        [MaxLength(255)]
        public string statistic_int02_descri { get; set; }
        public int statistic_int03_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int03_header { get; set; }
        [MaxLength(255)]
        public string statistic_int03_descri { get; set; }
        public int statistic_int04_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int04_header { get; set; }
        [MaxLength(255)]
        public string statistic_int04_descri { get; set; }
        public int statistic_int05_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int05_header { get; set; }
        [MaxLength(255)]
        public string statistic_int05_descri { get; set; }
        public int statistic_int06_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int06_header { get; set; }
        [MaxLength(255)]
        public string statistic_int06_descri { get; set; }
        public int statistic_int07_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int07_header { get; set; }
        [MaxLength(255)]
        public string statistic_int07_descri { get; set; }
        public int statistic_int08_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int08_header { get; set; }
        [MaxLength(255)]
        public string statistic_int08_descri { get; set; }
        public int statistic_int09_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int09_header { get; set; }
        [MaxLength(255)]
        public string statistic_int09_descri { get; set; }
        public int statistic_int10_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int10_header { get; set; }
        [MaxLength(255)]
        public string statistic_int10_descri { get; set; }
        public int statistic_int11_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int11_header { get; set; }
        [MaxLength(255)]
        public string statistic_int11_descri { get; set; }
        public int statistic_int12_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int12_header { get; set; }
        [MaxLength(255)]
        public string statistic_int12_descri { get; set; }
        public int statistic_int13_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int13_header { get; set; }
        [MaxLength(255)]
        public string statistic_int13_descri { get; set; }
        public int statistic_int14_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int14_header { get; set; }
        [MaxLength(255)]
        public string statistic_int14_descri { get; set; }
        public int statistic_int15_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int15_header { get; set; }
        [MaxLength(255)]
        public string statistic_int15_descri { get; set; }
        public int statistic_int16_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int16_header { get; set; }
        [MaxLength(255)]
        public string statistic_int16_descri { get; set; }
        public int statistic_int17_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int17_header { get; set; }
        [MaxLength(255)]
        public string statistic_int17_descri { get; set; }
        public int statistic_int18_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int18_header { get; set; }
        [MaxLength(255)]
        public string statistic_int18_descri { get; set; }
        public int statistic_int19_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int19_header { get; set; }
        [MaxLength(255)]
        public string statistic_int19_descri { get; set; }
        public int statistic_int20_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_int20_header { get; set; }
        [MaxLength(255)]
        public string statistic_int20_descri { get; set; }
        public int statistic_bit01_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_bit01_header { get; set; }
        [MaxLength(255)]
        public string statistic_bit01_descri { get; set; }
        public int statistic_bit02_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_bit02_header { get; set; }
        [MaxLength(255)]
        public string statistic_bit02_descri { get; set; }
        public int statistic_bit03_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_bit03_header { get; set; }
        [MaxLength(255)]
        public string statistic_bit03_descri { get; set; }
        public int statistic_bit04_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_bit04_header { get; set; }
        [MaxLength(255)]
        public string statistic_bit04_descri { get; set; }
        public int statistic_bit05_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_bit05_header { get; set; }
        [MaxLength(255)]
        public string statistic_bit05_descri { get; set; }
        public int statistic_bit06_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_bit06_header { get; set; }
        public string statistic_bit07_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_bit07_header { get; set; }
        [MaxLength(255)]
        public string statistic_bit07_descri { get; set; }
        public string statistic_bit08_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_bit08_header { get; set; }
        [MaxLength(255)]
        public string statistic_bit08_descri { get; set; }
        public string statistic_bit09_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_bit09_header { get; set; }
        [MaxLength(255)]
        public string statistic_bit09_descri { get; set; }
        public string statistic_bit10_sequence { get; set; }
        [MaxLength(40)]
        public string statistic_bit10_header { get; set; }
        [MaxLength(255)]
        public string statistic_bit10_descri { get; set; }
    }
}
