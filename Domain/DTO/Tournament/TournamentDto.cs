using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Tournament
{
    public class TournamentDto
    {
        public TournamentDto(int tournamentId, string tournamentName, string description, int maxPlayer, int isStarted, int isOpen)
        {
            TournamentId = tournamentId;
            TournamentName = tournamentName;
            Description = description;
            MaxPlayer = maxPlayer;
            IsStarted = isStarted;
            IsOpen = isOpen;
        }

        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public string Description { get; set; }
        public int MaxPlayer { get; set; }
        public int IsStarted { get; set; }
        public int IsOpen { get; set; }
    }
}
