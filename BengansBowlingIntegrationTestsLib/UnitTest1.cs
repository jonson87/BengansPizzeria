using BengansBowlingHallDbLib;
using System;
using AccountabilityLib;
using Xunit;
using BengansBowlingHallDbLib.Repositories;

namespace BengansBowlingUnitTestsLib
{
    public class UnitTest1
    {
        private BengansSystem _system;

        public UnitTest1()
        {
            _system = new BengansSystem(MemoryRepository.Instance);

            Seed();
        }

        public void Seed()
        {
            _system.RegisterMember("8705203984", "Benny");
            _system.RegisterMember("9105203234", "Danny");
            _system.RegisterMember("9505203234", "Donny");
            _system.RegisterMember("7505203234", "Jonny");

            var period = new TimePeriod
            {
                Starttime = new DateTime(2017, 01, 01),
                Endtime = new DateTime(2017, 12, 31)
            };
        }

        [Fact]
        public void TestWinner()
        {
            //var serie1P1 = new Serie {Score = 100};
            //var serie1P2 = new Serie { Score = 200 };
            //var serie2P1 = new Serie { Score = 300 };
            //var serie2P2 = new Serie { Score = 50 };
            //var serie3P1 = new Serie { Score = 250 };
            //var serie3P2 = new Serie { Score = 100 };
            //var round1 = new Round {SerieOne = serie1P1, SerieTwo = serie1P2};
            //var round2 = new Round { SerieOne = serie2P1, SerieTwo = serie2P2 };
            //var round3 = new Round { SerieOne = serie3P1, SerieTwo = serie3P2 };
            //var rounds = new List<Round>();
            //rounds.Add(round1);
            //rounds.Add(round2);
            //rounds.Add(round3);
            //var match = new Match {Id = 1, PlayerOne = benny, PlayerTwo = danny, Rounds = rounds};
            //var winner = _system.GetMatchWinner(match);
            //Assert.Equal(benny.Name, winner.Name);
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
