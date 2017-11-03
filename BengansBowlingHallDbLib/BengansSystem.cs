using System.Collections.Generic;
using AccountabilityLib;
using System.Linq;
using BengansBowlingHallDbLib.Interfaces;

namespace BengansBowlingHallDbLib
{
    public class BengansSystem
    {
        private IBengansRepository _repository;

        public BengansSystem(IBengansRepository repository)
        {
            _repository = repository;
        }

        //Party management
        public int CreateMember(string legalId, string name)
        {
            return _repository.CreateMember(legalId, name);
        }

        public List<Party> GetAllParties()
        {
            return _repository.GetAllParties();
        }

        public Party GetParty(int id)
        {
            return _repository.GetParty(id);
        }

        public int CreateMatch(List<Round> rounds)
        {
            return _repository.CreateMatch(rounds);
        }

        public List<Match> GetAllMatches()
        {
            return _repository.GetAllMatches();
        }

        public Match GetMatch(int id)
        {
            return _repository.GetMatch(id);
        }

        //Competition management
        public int CreateCompetition(string name, TimePeriod period, List<Match> matches)
        {
            return _repository.CreateCompetition(name, period, matches);
        }

        public List<Competition> GetAllCompetitions()
        {
            return _repository.GetAllCompetitions();
        }

        public Competition GetCompetition(int id)
        {
            return _repository.GetCompetition(id);
        }

        //Round management
        public int CreateRound(Serie serieOne, Serie serieTwo)
        {
            return _repository.CreateRound(serieOne, serieTwo);
        }

        public List<Round> GetAllRounds()
        {
            return _repository.GetAllRounds();
        }

        public Round GetRound(int id)
        {
            return _repository.GetRound(id);
        }

        //Serie management
        public int CreateSerie(Party player, int score = 0)
        {
            return _repository.CreateSerie(player, score);
        }

        public List<Serie> GetAllSeries()
        {
            return _repository.GetAllSeries();
        }

        public Serie GetSerie(int id)
        {
            return _repository.GetSerie(id);
        }

        //Get winner
        public Party GetMatchWinner(Match match)
        {
            int playerOneWonRounds = 0;
            int playerTwoWonRounds = 0;

            foreach (var round in match.Rounds)
            {
                if (round.PlayerOneSerie.Score > round.PlayerTwoSerie.Score)
                    playerOneWonRounds++;
                else if (round.PlayerTwoSerie.Score > round.PlayerOneSerie.Score)
                    playerTwoWonRounds++;
            }

            if (playerOneWonRounds > playerTwoWonRounds)
            {
                return match.Rounds[0].PlayerOneSerie.Player;
            }

            return match.Rounds[0].PlayerTwoSerie.Player;
        }

        public Party GetWinnerOfTheYear(int year)
        {
            var playerList = new List<PlayerStatistics>();
            var allPlayers = new List<Party>();
            allPlayers = _repository.GetAllParties();

            //Move all players to the statistics list
            foreach (var player in allPlayers)
            {
                var playerStatistics = new PlayerStatistics()
                {
                    Player = player
                };

                playerList.Add(playerStatistics);
            }

            var competitionsThisYear = _repository.GetAllCompetitions().Where(x => x.Period.Starttime.Year == year && x.Period.Endtime.Year == year);

            var playerWins = competitionsThisYear.SelectMany(c => c.Matches)
                    .GroupBy(match => new { Match = match, WinnerId = match.WinnerId })
                    .Select(g => new
                    {
                        PlayerId = g.Key.WinnerId,
                        Wins = g.Count(),
                        Played = g.Key.Match.Rounds.Take(1)
                        .Select(r => r.PlayerOneSerie.PlayerId == g.Key.WinnerId || r.PlayerTwoSerie.PlayerId == g.Key.WinnerId)
                        .Count(),
                        Player = allPlayers.Single(p => p.Id == g.Key.WinnerId)
                    });

            var age = 46;

            //foreach (var match in competition.Matches)
            //{
            //    playerList.ForEach(p => { p.Player.Id == match.WinnerId ? p.MatchesWon++ : p.MatchesWon; });
            //}

            //foreach (var rounds in competition.Matches.Select(x => x.Rounds))
            //{
            //    var playerStatistics = new PlayerStatistics();
            //    if (rounds.Select(x => x.PlayerOneSerie.Player.Id) == rounds.Select(x => x.Match.Winner.Id))
            //    {
            //        playerStatistics.MatchesWon += 1;
            //        playerStatistics.Matchesplayed += 1;
            //    }
            //    else if (rounds.Select(x => x.PlayerTwoSerie.Player.Id) == rounds.Select(x => x.Match.Winner.Id))
            //    {

            //    }
            //}    

            return playerWins.OrderByDescending(w => w.Wins).First().Player;
        }
}
}
