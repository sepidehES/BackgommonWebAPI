using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Tournament
    {
        public Tournament(string tournamentName, string description, int maxPlayer)
        {
            TournamentId = -1;
            TournamentName = tournamentName;
            Description = description;
            MaxPlayer = maxPlayer;
        }
        public Tournament(int tournamentId, string tournamentName, string description, int maxPlayer)
            :this(tournamentName, description, maxPlayer)
        {
            TournamentId = tournamentId;
        }


        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public string Description { get; set; }
        public int MaxPlayer { get; set; }
    }
}




