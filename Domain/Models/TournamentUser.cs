using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TournamentUser
    {
        public TournamentUser(int playerId)
        {
            TournamentId = -1;
            PlayerId = playerId;
        }

        public TournamentUser(int tournamentId, int playerId)
            : this(playerId)
        {
            TournamentId = tournamentId;
        }

        public int TournamentId {get; set; }
        public int PlayerId {get; set; }

    }
}
