﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISubscriptionRepository
    {
        public TournamentUser? Create(TournamentUser tournamentUser);
    }
}
