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
    }
}
