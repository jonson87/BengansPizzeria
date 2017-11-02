﻿using AccountabilityLib;

namespace BengansBowlingHallDbLib.Interfaces
{
    public interface IBengansRepository
    {
        void CreateMember(string legalId, string name);
        void CreateMatch(Party player1, Party player2);
        void CreateSerie(Serie serie);
        void CreateRound(Round round);
        void CreateCompetition(Competition competition);
    }
}
