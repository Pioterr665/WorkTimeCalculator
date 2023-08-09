﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace HourCalcMVC.Models
{
    public class DailyHour
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime StartingHour { get; set; }
        public DateTime EndingHour { get; set; }
        public string? Total { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string? Shift { get; set; }
    }
}
