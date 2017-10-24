using System;
using System.Collections.Generic;
using System.Text;
using AccountabilityLib;

namespace BengansBowlingHallDbLib
{
    public class Match
    {
        public int Id { get; set; }
        public int PlayerOneId { get; set; }
        public Party PlayerOne { get; set; }
        public int PlayerTwoId { get; set; }
        public Party PlayerTwo { get; set; }
        public int WinnerId { get; set; }
        public Party Winner { get; set; }
        public List<Round> Rounds { get; set; }
    }
}
