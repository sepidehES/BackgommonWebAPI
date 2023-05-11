using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Tournament
{
    public class TournamentDto
    {
        public TournamentDto(string tournamentName, string description, int maxPlayer)
        {
            TournamentName = tournamentName;
            Description = description;
            MaxPlayer = maxPlayer;
        }

        public string TournamentName { get; set; }
        public string Description { get; set; }
        public int MaxPlayer { get; set; }
    }
}
