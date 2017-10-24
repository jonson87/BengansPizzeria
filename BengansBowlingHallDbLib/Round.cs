using System;
using System.Collections.Generic;
using System.Text;

namespace BengansBowlingHallDbLib
{
    public class Round
    {
        public int Id { get; set; }
        public int SerieOneId { get; set; }
        public Serie SerieOne { get; set; }
        public int SerieTwoId { get; set; }
        public Serie SerieTwo { get; set; }
    }
}
