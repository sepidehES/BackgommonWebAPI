using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITournamentService
    {
        public IEnumerable<Tournament> GetAll();
        public Tournament? GetById(int id);
        public Tournament? Create(Tournament tournament);
        public bool Update(int tournamentId, Tournament tournament);
        public bool Delete(int id);
        public bool UpdateOpen(int tournamentId);
        public bool UpdateClose(int tournamentId);
        public bool UpdateStart(int tournamentId);

    }
}
