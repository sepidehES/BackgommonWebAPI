using Domain.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Player
    {
        public Player(string pseudo, string email, string password_Hash)
        {
            PlayerId = -1;
            Pseudo = pseudo;
            Email = email;
            Password_Hash = password_Hash;
        }

        public Player(int playerId, string pseudo, string email, string password_Hash) 
            :this(pseudo, email, password_Hash)
        {
            PlayerId = playerId;
        }

        public int PlayerId { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Password_Hash { get; set; }

    }
}
