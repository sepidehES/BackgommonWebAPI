using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.User
{
    public class PlayerDto
    {
      public PlayerDto(int playerId, string pseudo, string email) 
        {
            PlayerId = playerId;
            Pseudo = pseudo;
            Email = email;
        }

        public int PlayerId { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }

    }
}
