using System;
using System.Collections.Generic;
using System.Text;
using AccountabilityLib;

namespace BengansBowlingHallDbLib
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PeriodId { get; set; }
        public TimePeriod Period { get; set; }
    }
}
