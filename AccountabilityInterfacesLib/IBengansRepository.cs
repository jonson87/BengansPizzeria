﻿using AccountabilityLib;
using System;

namespace AccountabilityInterfacesLib
{
    public interface IBengansRepository
    {
        Party RegisterMember(string name, string legalId, string phone, string email);
    }
}