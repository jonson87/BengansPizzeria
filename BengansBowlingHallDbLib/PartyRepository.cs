using System;
using System.Collections.Generic;
using System.Text;
using AccountabilityInterfacesLib;
using AccountabilityLib;

namespace BengansBowlingHallDbLib
{
    public class PartyRepository: IPartyRepository
    {
        private BengansBowlingHallDbContext _context;
        public PartyRepository(BengansBowlingHallDbContext context)
        {
            _context = context;
        }

        public Party RegisterMember(string name, string legalId, string phone, string email)
        {
            var party = new Party { Name = name, LegalId = legalId, Email = email, Phone = phone };
            _context.Parties.Add(party);
            _context.SaveChanges();

            return party;
        }

        public Match RegisterMatch(string name, Party playerOne, Party playerTwo, Party winner)
        {
            var match = new Match {Name = name, PlayerOne = playerOne, PlayerTwo = playerTwo, Winner = winner};
            _context.Matches.Add(match);
            _context.SaveChanges();

            return match;
        }

        public Serie RegisterSerie(int score)
        {
            var serie = new Serie {Score = score};
            _context.Series.Add(serie);
            _context.SaveChanges();

            return serie;
        }

        public Round RegisterRound(Serie serieOne, Serie serieTwo, Match match)
        {
            var round = new Round {SerieOne = serieOne, SerieTwo = serieTwo, Match = match };
            _context.Rounds.Add(round);
            _context.SaveChanges();

            return round;
        }
        
    }
}
