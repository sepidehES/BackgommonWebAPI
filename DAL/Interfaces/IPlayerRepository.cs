using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPlayerRepository
    {
        public Player? GetById(int playerId);
        public Player? GetByName(string name);
        public Player? Create(Player player);
        public bool Delete(int playerId);

    }
}
