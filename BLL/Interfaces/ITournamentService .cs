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
        public Tournament? Create(Tournament user);
        public bool Delete(int id);
    }
}
