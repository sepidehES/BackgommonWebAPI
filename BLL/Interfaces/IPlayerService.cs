using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPlayerService
    {
        public int? Login(string playerName, string password_Hash);
        public Player? Create(Player player);
        public bool Delete(int PlayerId);
        Player? GetById(int PlayerId);
    }
}
