using BengansBowlingHallDbLib;
using Xunit;
using BengansBowlingHallDbLib.Repositories;
using System.Collections.Generic;
using System.Linq;
using AccountabilityLib;
using System;

namespace BengansBowlingUnitTestsLib
{
    public class UnitTest1
    {
        private BengansSystem _system;

        private Match match1;
        private Match match2;
        private Match match3;
        private Match match4;
        private Match match5;
        private Match match6;

        public UnitTest1()
        {
            _system = new BengansSystem(MemoryRepository.Instance);

            Seed();
        }

        public void Seed()
        {
            _system.CreateMember("87052060389", "Benny");
            _system.CreateMember("87052234324", "Danny");
            _system.CreateMember("87123523122", "Jonny");
            _system.CreateMember("87052012312", "Donny");
            _system.CreateMember("87063234112", "Fanny");

            var winner1 = _system.GetAllParties().First(player => player.Name == "Danny");
            var winner2 = _system.GetAllParties().First(player => player.Name == "Danny");
            var winner3 = _system.GetAllParties().First(player => player.Name == "Donny");
            var winner4 = _system.GetAllParties().First(player => player.Name == "Danny");
            var winner5 = _system.GetAllParties().First(player => player.Name == "Fanny");
            var winner6 = _system.GetAllParties().First(player => player.Name == "Fanny");


            match1 = CreateMatch("Benny", 220, 300, 95, "Danny", 220, 300, 102, winner1);
            match2 = CreateMatch("Danny", 220, 167, 112, "Jonny", 88, 80, 89, winner2);
            match3 = CreateMatch("Donny", 220, 300, 70, "Jonny", 77, 56, 92, winner3);
            match4 = CreateMatch("Danny", 280, 300, 140, "Fanny", 300, 282, 75, winner4);
            match5 = CreateMatch("Fanny", 270, 220, 190, "Benny", 220, 195, 70, winner5);
            match6 = CreateMatch("Jonny", 110, 76, 73, "Fanny", 210, 198, 178, winner6);
        }

        [Fact]
        public void TestWinner()
        {
            //Test
            Assert.Equal("Danny", _system.GetMatchWinner(match2).Name);
        }

        [Fact]
        public void TestWinnerOfTheYear()
        {

            var matches = new List<Match>();
            matches.Add(match1);
            matches.Add(match2);
            matches.Add(match3);
            matches.Add(match4);
            matches.Add(match5);
            matches.Add(match6);

            TimePeriod timePeriod = new TimePeriod();
            timePeriod.Starttime = new DateTime(2017, 01, 05);
            timePeriod.Endtime = new DateTime(2017, 12, 30);

            _system.CreateCompetition("Bengans All Star", timePeriod, matches);
            var champion = _system.GetWinnerOfTheYear(2017);
            Assert.Equal("Danny", champion.Name);
        }

        public Match CreateMatch(string player1Name, int player1score1, int player1score2,
            int player1score3, string player2Name, int player2score1, int player2score2,
            int player2score3, Party winner)
        {
            //Create MATCH 1
            //Create series
            var serie1Id = _system.CreateSerie(_system.GetAllParties().First(x => x.Name == player1Name), player1score1);
            var serie2Id = _system.CreateSerie(_system.GetAllParties().First(x => x.Name == player2Name), player2score1);
            var serie1 = _system.GetSerie(serie1Id);
            var serie2 = _system.GetSerie(serie2Id);
            var serie3Id = _system.CreateSerie(_system.GetAllParties().First(x => x.Name == player1Name), player1score2);
            var serie4Id = _system.CreateSerie(_system.GetAllParties().First(x => x.Name == player2Name), player2score2);
            var serie3 = _system.GetSerie(serie3Id);
            var serie4 = _system.GetSerie(serie4Id);
            var serie5Id = _system.CreateSerie(_system.GetAllParties().First(x => x.Name == player1Name), player1score3);
            var serie6Id = _system.CreateSerie(_system.GetAllParties().First(x => x.Name == player2Name), player2score3);
            var serie5 = _system.GetSerie(serie5Id);
            var serie6 = _system.GetSerie(serie6Id);

            //Create rounds
            var round1Id = _system.CreateRound(serie1, serie2);
            var round2Id = _system.CreateRound(serie3, serie4);
            var round3Id = _system.CreateRound(serie5, serie6);

            var round1 = _system.GetRound(round1Id);
            var round2 = _system.GetRound(round2Id);
            var round3 = _system.GetRound(round3Id);

            var roundList = new List<Round>();
            roundList.Add(round1);
            roundList.Add(round2);
            roundList.Add(round3);

            //Create match
            var matchId = _system.CreateMatch(roundList, winner);
            return _system.GetMatch(matchId);
        }

    }
}
