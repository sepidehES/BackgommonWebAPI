using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Match
{
    public class MatchDto
    {
        public MatchDto(int matchId, DateTime dateStart, DateTime dateEnd, int player1Id, int player2Id,int tournamentId)
        {
            MatchId = matchId;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Player1Id = player1Id;
            Player2Id = player2Id;
            TournamentId = tournamentId;

        }

        public int MatchId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public int TournamentId { get; set; }
        
    }
}
