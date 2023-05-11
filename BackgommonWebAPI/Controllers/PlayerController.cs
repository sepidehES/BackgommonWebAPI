
using BackgommonWebAPI.Helper;
using BLL.Interfaces;
using Domain.DTO.User;

using Domain.Forms.User;
using Domain.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;
using System.IdentityModel.Tokens.Jwt;
using Domain.Models;

namespace BackgommonWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        //private readonly JwtHelper _JwtHelper;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
            //_JwtHelper = jwtHelper;
        }


        [HttpGet("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlayerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PlayerDto> GetById([FromRoute] int id)
        {
            Player? model = _playerService.GetById(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model.ToPlayerDTO());
        }

        [HttpPost("register")]
        [AllowAnonymous]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlayerDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PlayerDto> Create([FromBody] CreatePlayerForm createForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            PlayerDto? player = _playerService.Create(createForm.ToPlayer())?.ToPlayerDTO();

            if (player == null) return BadRequest();

            return Created($"/api/player/{player.PlayerId}", player);
        }

    }
}

