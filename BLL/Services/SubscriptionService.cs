using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _SubscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _SubscriptionRepository = subscriptionRepository;
        }
        public TournamentUser? Create(TournamentUser tournamentUser)
        {
            TournamentUser tournamentSecure = new TournamentUser(
                tournamentUser.TournamentId,
                tournamentUser.PlayerId
                );
            return _SubscriptionRepository.Create(tournamentSecure);
        }
    }
}
