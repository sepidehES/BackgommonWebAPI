using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Match
    {

        public Match(DateTime dateStart, DateTime dateEnd, int player1Id, int player2Id, int tournamentId)
        {
            MatchId = -1;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Player1Id = player1Id;
            Player2Id = player2Id;
            TournamentId = tournamentId;
        }

        public Match(int matchId, DateTime dateStart, DateTime dateEnd, int player1Id, int player2Id, int tournamentId)
            :this(dateStart, dateEnd, player1Id, player2Id, tournamentId)
        {
            MatchId = matchId;
        }



        public int MatchId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public int TournamentId { get; set; }


    }
}
