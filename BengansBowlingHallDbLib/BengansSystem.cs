using System.Collections.Generic;
using AccountabilityLib;
using System.Linq;
using BengansBowlingHallDbLib.Interfaces;
using System;

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

        public int CreateMatch(List<Round> rounds, Party winner = null)
        {
            return _repository.CreateMatch(rounds, winner);
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

        //Gets a specific match's winner
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

        //Gets the player with the best win/played ratio of a given year
        public Party GetWinnerOfTheYear(int year)
        {
            var competitionsThisYear = _repository.GetAllCompetitions().Where(x => x.Period.Starttime.Year == year && x.Period.Endtime.Year == year);

            Dictionary<int, decimal> playersWinRatio = new Dictionary<int, decimal>();

            foreach (var competition in competitionsThisYear)
            {
                var playersWithWins = competition.Matches.Select(pw => pw.WinnerId).ToList();
                var playersWithPlayedMatches = competition.Matches.SelectMany(pp => pp.Rounds.Take(1).Select(p => p.PlayerOneSerie.PlayerId)).ToList();
                playersWithPlayedMatches.AddRange(competition.Matches.SelectMany(pp => pp.Rounds.Take(1).Select(p => p.PlayerTwoSerie.PlayerId)));

                foreach (var playerId in playersWithWins.Distinct())
                {
                    var wonMatches = playersWithWins.Count(x => x == playerId);
                    var playedMatches = playersWithPlayedMatches.Count(p => p == playerId);
                    var winRatio = wonMatches / (decimal)playedMatches;
                    playersWinRatio.Add(playerId, winRatio);
                }
            }

            playersWinRatio.OrderByDescending(x => x);
            var winnerOfTheYearId = playersWinRatio.First().Key;

            return _repository.GetParty(winnerOfTheYearId);
        }
    }
}
