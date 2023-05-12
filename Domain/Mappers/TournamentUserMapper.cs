using Domain.DTO.Tournament;
using Domain.DTO.TournamentUser;
using Domain.Forms.TournamentUser;
using Domain.Forms.User;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class TournamentUserMapper
    {
        public static TournamentUserDto ToTournamentUserDTO(this TournamentUser model)
        {
            return new TournamentUserDto(
                model.TournamentId,
                model.PlayerId
                );
        }

        public static IEnumerable<TournamentUserDto> ToTournamentUserDtoList(this IEnumerable<TournamentUser> models)
        {
            foreach (var model in models)
            {
                yield return model.ToTournamentUserDTO();
            }
        }

        public static TournamentUser ToTournamentUser(this CreateTournamentUserForm createForm)
        {
            return new TournamentUser(
                createForm.TournamentId,
                createForm.PlayerId

                 ); 
        }


    }
}
