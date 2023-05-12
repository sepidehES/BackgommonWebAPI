using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.TournamentUser
{
    public class TournamentUserDto
    {
        public TournamentUserDto(int tournamentId, int playerId)
        {
            TournamentId = tournamentId;
            PlayerId = playerId;
        }

        public int TournamentId { get; set; }
        public int PlayerId { get; set; }

    }
}

