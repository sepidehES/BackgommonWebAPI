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
        public TournamentDto(int tournamentId, string tournamentName, string description, int maxPlayer, bool isStarted, bool isOpen)
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
        public bool IsStarted { get; set; }
        public bool IsOpen { get; set; }
    }
}
