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
    public static class PlayerMapper
    {
        public static PlayerDto ToPlayerDTO(this Player model)
        {
            return new PlayerDto(
                model.PlayerId,
                model.Pseudo,
                model.Email
                ); 
        }

        public static IEnumerable<PlayerDto> ToPlayerDtoList(this IEnumerable<Player> models)
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
