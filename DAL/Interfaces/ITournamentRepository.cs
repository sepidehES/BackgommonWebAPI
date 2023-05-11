using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITournamentRepository
    {
        public Tournament? Create(Tournament tournament);
        public IEnumerable<Tournament> GetAll();
        public Tournament? GetById(int tournamentId);
        public bool Delete(int tournamentId);

    }
}

