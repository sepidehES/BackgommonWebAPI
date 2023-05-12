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
    public class MatchService : IMatchService
    {

        private readonly IMatchRepository _matchRepository;

        public MatchService(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public Match? GetById(int matchId)
        {
            return _matchRepository.GetById(matchId);
        }
    }
}
