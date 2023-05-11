using Domain.DTO.Tournament;
using Domain.DTO.User;
using Domain.Forms.User;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
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
                model.TournamentId,
                model.TournamentName,
                model.Description,
                model.MaxPlayer,
                model.IsStarted,
                model.IsOpen
                ); 
        }

        public static IEnumerable<TournamentDto> ToTournamentDtoList(this IEnumerable<Tournament> models)
        {
            foreach (var model in models)
            {
                yield return model.ToTournamentDTO();
            }
        }

        public static Tournament ToTournament(this CreateTournamentForm createForm)
        {
            return new Tournament(
                createForm.TournamentName,
                createForm.Description,
                createForm.MaxPlayer

                 );
        }

        
    }
}
