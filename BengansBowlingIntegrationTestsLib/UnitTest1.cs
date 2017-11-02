using BengansBowlingHallDbLib;
using System;
using AccountabilityLib;
using Xunit;
using System.Collections.Generic;
using BengansBowlingHallDbLib.Interfaces;

namespace BengansBowlingUnitTestsLib
{
    public class UnitTest1
    {
        private BengansSystem bengansSystem;
        private IBengansRepository IBR;

        //TODO Bryt ut all datagenerering till testmetoder. Testmetod "CreateMatches" kan t.ex. skapa matcher och kontrollera genom .Count om matcherna är inlagda i repositoryn.

        public UnitTest1()
        {
            bengansSystem = new BengansSystem(IBR);
            var benny = new Party()
            {
                Name = "Benny",
                LegalId = "8705203984",
                Phone = "0708160404",
                Email = "min@mail.com"
            };

            var danny = new Party()
            {
                Name = "Danny",
                LegalId = "9105203234",
                Phone = "1293828311",
                Email = "min@mail.com"
            };

            var donny = new Party()
            {
                Name = "Donny",
                LegalId = "9505203234",
                Phone = "1239283901",
                Email = "min@mail.com"
            };

            var johny = new Party()
            {
                Name = "Jonny",
                LegalId = "7505203234",
                Phone = "1239121211",
                Email = "min@mail.com"
            };

            //repo.RegisterMember(benny);
            //repo.RegisterMember(danny);
            //repo.RegisterMember(donny);
            //repo.RegisterMember(johny);

            var period = new TimePeriod
            {
                Starttime = new DateTime(2017, 01, 01),
                Endtime = new DateTime(2017, 12, 31)
            };         

            var match1 = new Match()
            {
                Id = 1,
                PlayerOne = benny,
                PlayerOneId = 1,
                PlayerTwo = danny,
                PlayerTwoId = 2,
            };

            var match2 = new Match()
            {
                Id = 2,
                PlayerOne = benny,
                PlayerOneId = 1,
                PlayerTwo = danny,
                PlayerTwoId = 2,
            };

            var match3 = new Match()
            {
                Id = 3,
                PlayerOne = benny,
                PlayerOneId = 1,
                PlayerTwo = danny,
                PlayerTwoId = 2,
            };

            var match4 = new Match()
            {
                Id = 4,
                PlayerOne = benny,
                PlayerOneId = 1,
                PlayerTwo = danny,
                PlayerTwoId = 2,
            };

            var match5 = new Match()
            {
                Id = 5,
                PlayerOne = benny,
                PlayerOneId = 1,
                PlayerTwo = danny,
                PlayerTwoId = 2,
            };

            var match6 = new Match()
            {
                Id = 6,
                PlayerOne = benny,
                PlayerOneId = 1,
                PlayerTwo = danny,
                PlayerTwoId = 2,
            };

            //repo.RegisterMatch(match1);
            //repo.RegisterMatch(match2);
            //repo.RegisterMatch(match3);
            //repo.RegisterMatch(match4);
            //repo.RegisterMatch(match5);
            //repo.RegisterMatch(match6);

            var matchList = new List<Match>();
            matchList.Add(match1);
            matchList.Add(match2);
            matchList.Add(match3);
            matchList.Add(match4);
            matchList.Add(match5);
            matchList.Add(match6);

            var competition = new Competition()
            {
                Name = "BengansTävling",
                Period = period,
                Matches = matchList
            };

            //repo.RegisterCompetition(competition);
        }

        [Fact]
        public void TestWinner()
        {
            var benny = new Party()
            {
                Name = "Benny",
                LegalId = "8705203984",
                Phone = "0708160404",
                Email = "min@mail.com"
            };

            var danny = new Party()
            {
                Name = "Danny",
                LegalId = "9105203234",
                Phone = "1293828311",
                Email = "min@mail.com"
            };
            var serie1P1 = new Serie {Score = 100};
            var serie1P2 = new Serie { Score = 200 };
            var serie2P1 = new Serie { Score = 300 };
            var serie2P2 = new Serie { Score = 50 };
            var serie3P1 = new Serie { Score = 250 };
            var serie3P2 = new Serie { Score = 100 };
            var round1 = new Round {SerieOne = serie1P1, SerieTwo = serie1P2};
            var round2 = new Round { SerieOne = serie2P1, SerieTwo = serie2P2 };
            var round3 = new Round { SerieOne = serie3P1, SerieTwo = serie3P2 };
            var rounds = new List<Round>();
            rounds.Add(round1);
            rounds.Add(round2);
            rounds.Add(round3);
            var match = new Match {Id = 1, PlayerOne = benny, PlayerTwo = danny, Rounds = rounds};
            var winner = bengansSystem.GetMatchWinner(match);
            Assert.Equal(benny.Name, winner.Name);
            //Assert.IsType(Party, match.Winner);
        }

        [Fact]
        public void TestWinnerOfTheYear()
        {
            //var match = repo.PlayMatch(1);
            //var match2 = repo.PlayMatch(2);
            //var match3 = repo.PlayMatch(3);
            //var match4 = repo.PlayMatch(4);
            //var match5 = repo.PlayMatch(5);
            //var match6 = repo.PlayMatch(6);
            //Assert.Equal(repo.Parties[1], match.Winner);
            //Assert.IsType(Party, match.Winner);
        }
    }
}
