using System;
using System.Collections.Generic;
using System.Text;

namespace BengansBowlingHallDbLib
{
    public class Round
    {
        public int Id { get; set; }
        public int PlayerOneSerieId { get; set; }
        public Serie PlayerOneSerie { get; set; }
        public int PlayerTwoSerieId { get; set; }
        public Serie PlayerTwoSerie { get; set; }
    }
}
