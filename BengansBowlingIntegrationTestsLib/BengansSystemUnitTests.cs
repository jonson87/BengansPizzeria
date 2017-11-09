using BengansBowlingHallDbLib;
using Xunit;
using BengansBowlingHallDbLib.Repositories;
using System.Collections.Generic;
using System.Linq;
using AccountabilityLib;
using System;

namespace BengansBowlingUnitTestsLib
{
    public class BengansSystemUnitTests
    {
        private BengansSystem _sytem;

        private Match match1;
        private Match match2;
        private Match match3;
        private Match match4;
        private Match match5;
        private Match match6;

        public BengansSystemUnitTests()
        {
            _sytem = new BengansSystem(MemoryRepository.Instance);

            Seed();
        } 

        [Fact]
        public void CheckMatchWinner()
        {
            //Test
            Assert.Equal("Danny", _sytem.GetMatchWinner(match2).Name);
        }

        [Fact]
        public void CheckWinnerOfTheYear()
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

            _sytem.CreateCompetition("Bengans All Star", timePeriod, matches);

            Assert.Equal("Danny", _sytem.GetWinnerOfTheYear(2017).Name);
        }

        public void Seed()
        {
            _sytem.CreateMember("87052060389", "Pelle");
            _sytem.CreateMember("87052234324", "Danny");
            _sytem.CreateMember("87123523122", "Bobby");
            _sytem.CreateMember("87052012312", "Katrine");
            _sytem.CreateMember("87063234112", "Mikael");

            var winner1 = _sytem.GetAllParties().First(player => player.Name == "Danny");
            var winner2 = _sytem.GetAllParties().First(player => player.Name == "Danny");
            var winner3 = _sytem.GetAllParties().First(player => player.Name == "Danny");
            var winner4 = _sytem.GetAllParties().First(player => player.Name == "Pelle");
            var winner5 = _sytem.GetAllParties().First(player => player.Name == "Katrine");
            var winner6 = _sytem.GetAllParties().First(player => player.Name == "Katrine");


            match1 = CreateMatch("Pelle", 220, 300, 95, "Danny", 220, 300, 102, winner1);
            match2 = CreateMatch("Danny", 220, 167, 112, "Mikael", 88, 80, 89, winner2);
            match3 = CreateMatch("Danny", 220, 300, 70, "Bobby", 77, 56, 92, winner3);
            match4 = CreateMatch("Pelle", 280, 300, 140, "Mikael", 300, 282, 75, winner4);
            match5 = CreateMatch("Katrine", 270, 220, 190, "Pelle", 220, 195, 70, winner5);
            match6 = CreateMatch("Mikael", 110, 76, 73, "Katrine", 210, 198, 178, winner6);
        }

        public Match CreateMatch(string player1Name, int player1score1, int player1score2,
            int player1score3, string player2Name, int player2score1, int player2score2,
            int player2score3, Party winner)
        {
            //Create MATCH 1
            //Create series
            var serie1Id = _sut.CreateSerie(_sut.GetAllParties().First(x => x.Name == player1Name), player1score1);
            var serie2Id = _sut.CreateSerie(_sut.GetAllParties().First(x => x.Name == player2Name), player2score1);
            var serie1 = _sut.GetSerie(serie1Id);
            var serie2 = _sut.GetSerie(serie2Id);
            var serie3Id = _sut.CreateSerie(_sut.GetAllParties().First(x => x.Name == player1Name), player1score2);
            var serie4Id = _sut.CreateSerie(_sut.GetAllParties().First(x => x.Name == player2Name), player2score2);
            var serie3 = _sut.GetSerie(serie3Id);
            var serie4 = _sut.GetSerie(serie4Id);
            var serie5Id = _sut.CreateSerie(_sut.GetAllParties().First(x => x.Name == player1Name), player1score3);
            var serie6Id = _sut.CreateSerie(_sut.GetAllParties().First(x => x.Name == player2Name), player2score3);
            var serie5 = _sut.GetSerie(serie5Id);
            var serie6 = _sut.GetSerie(serie6Id);
            //Create lane
            var laneId = _sut.CreateLane(1);
            var lane = _sut.GetLane(1);
            //Create rounds
            var round1Id = _sytem.CreateRound(serie1, serie2);
            var round2Id = _sytem.CreateRound(serie3, serie4);
            var round3Id = _sytem.CreateRound(serie5, serie6);

            var round1 = _sytem.GetRound(round1Id);
            var round2 = _sytem.GetRound(round2Id);
            var round3 = _sytem.GetRound(round3Id);

            var roundList = new List<Round>();
            roundList.Add(round1);
            roundList.Add(round2);
            roundList.Add(round3);

            //Create match
            var matchId = _sut.CreateMatch(roundList,lane, winner);
            return _sut.GetMatch(matchId);
        }

    }
}
