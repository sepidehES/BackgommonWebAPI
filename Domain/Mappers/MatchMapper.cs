using Domain.DTO.Match;
using Domain.DTO.Tournament;
using Domain.Forms.Match;
using Domain.Forms.User;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class MatchMapper
    {
        public static MatchDto ToMatchDTO(this Match model)
        {
            return new MatchDto(
                model.MatchId,
                model.DateStart,
                model.DateEnd,
                model.Player1Id,
                model.Player2Id,
                model.TournamentId
                );
        }

        public static IEnumerable<MatchDto> ToMatchDTOList(this IEnumerable<Match> models)
        {
            foreach (var model in models)
            {
                yield return model.ToMatchDTO();
            }
        }

        //public static Match ToMatch(this CreateMatchForm createForm)
        //{
        //    return new Match(
        //        createForm.DateStart,
        //        createForm.DateEnd

        //         );
        //}


    }

}

