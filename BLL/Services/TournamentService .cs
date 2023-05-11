using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using Domain.Models;
using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace BLL.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _TournamentRepository;

        public TournamentService(ITournamentRepository tournamentRepository)
        {
            _TournamentRepository = tournamentRepository;
        }

        public Tournament? Create(Tournament tournament)
        {
            Tournament tournamentSecure = new Tournament(
                tournament.TournamentName, 
                tournament.Description,
                tournament.MaxPlayer
                );
            return _TournamentRepository.Create(tournamentSecure);
        }

        public bool Delete(int tournamentId)
        {
            return _TournamentRepository.Delete(tournamentId);
        }

        public IEnumerable<Tournament> GetAll()
        {
            return _TournamentRepository.GetAll();
        }

        public Tournament? GetById(int tournamentId)
        {
            return  _TournamentRepository.GetById(tournamentId);
        }

       
    }
}
