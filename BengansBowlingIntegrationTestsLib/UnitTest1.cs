using BengansBowlingHallDbLib;
using System;
using AccountabilityLib;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BengansBowlingUnitTestsLib
{
    public class UnitTest1
    {
        private BengansRepository repo;

        public UnitTest1()
        {
            repo = new BengansRepository();
            repo.RegisterMember(1,"Benny", "8705203984", "0708160404", "min@mail.com");
            repo.RegisterMember(2,"Danny", "8705203234", "1293828311", "min@mail.com");
            repo.RegisterMember(3,"Donny", "8123123984", "1239283901", "min@mail.com");
            repo.RegisterMember(4,"Jonny", "8103921914", "1239121211", "min@mail.com");

            var period = new TimePeriod
            {
                Starttime = new DateTime(2017, 01, 01),
                Endtime = new DateTime(2017, 12, 31)
            };

            repo.RegisterCompetition(1, "Bengans Ultra Tävling", period);

            repo.RegisterMatch(1, repo.Parties.Find(x => x.Name == "Benny"), repo.Parties.Find(x => x.Name == "Danny"));
            repo.RegisterMatch(2, repo.Parties.Find(x => x.Name == "Benny"), repo.Parties.Find(x => x.Name == "Donny"));
            repo.RegisterMatch(3, repo.Parties.Find(x => x.Name == "Benny"), repo.Parties.Find(x => x.Name == "Jonny"));
            repo.RegisterMatch(4, repo.Parties.Find(x => x.Name == "Danny"), repo.Parties.Find(x => x.Name == "Donny"));
            repo.RegisterMatch(5, repo.Parties.Find(x => x.Name == "Danny"), repo.Parties.Find(x => x.Name == "Jonny"));
            repo.RegisterMatch(6, repo.Parties.Find(x => x.Name == "Donny"), repo.Parties.Find(x => x.Name == "Jonny"));
            
        }
        [Fact]
        public void Test1()
        {
            var partyList = repo.Parties;
            Assert.Equal(4, partyList.Count);
        }

        [Fact]
        public void TestWinner()
        {
            var match = repo.PlayMatch(1);
            Assert.Equal(repo.Parties[1], match.Winner);
            //Assert.IsType(Party, match.Winner);
        }

        [Fact]
        public void TestWinnerOfTheYear()
        {
            var match = repo.PlayMatch(1);
            var match2 = repo.PlayMatch(2);
            var match3 = repo.PlayMatch(3);
            var match4 = repo.PlayMatch(4);
            var match5 = repo.PlayMatch(5);
            var match6 = repo.PlayMatch(6);
            Assert.Equal(repo.Parties[1], match.Winner);
            //Assert.IsType(Party, match.Winner);
        }
    }
}
