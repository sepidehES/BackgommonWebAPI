using Domain.DTO.Tournament;
using Domain.DTO.User;
using Domain.Forms.User;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class TournamentMapper
    {
        public static TournamentDto ToTournamentDTO(this Tournament model)
        {
            return new TournamentDto(
                model.PlayerId,
                model.Pseudo,
                model.Email
                ); 
        }

        public static IEnumerable<TournamentDto> ToPlayerDtoList(this IEnumerable<Player> models)
        {
            foreach (var model in models)
            {
                yield return model.ToPlayerDTO();
            }
        }

        public static Player ToPlayer(this CreatePlayerForm createForm)
        {
            return new Player(
                createForm.Pseudo,
                createForm.Email,
                createForm.Password_Hash
                );
        }


    }
}
