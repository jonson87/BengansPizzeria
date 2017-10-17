using AccountabilityLib;
using System;

namespace AccountabilityInterfacesLib
{
    public interface IPartyRepository
    {
        Party RegisterMember(string name, string legalId, string phone, string email);
    }
}
