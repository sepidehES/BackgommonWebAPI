
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
using Domain.DTO.Jwt;
using Domain.Forms.Player;

namespace BackgommonWebAPI.Controllers
{
    [Route("Auth")]
    [ApiController]
    [Authorize]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly JwtHelper _JwtHelper;
        public PlayerController(IPlayerService playerService, JwtHelper jwtHelper)
        {
            _playerService = playerService;
            _JwtHelper = jwtHelper;
        }

        private int? PlayerId
        {
            get
            {
                string? tokenId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                return (tokenId is null) ? null : int.Parse(tokenId);
            }
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

        [HttpPost("login")]
        [AllowAnonymous]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JwtDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login([FromBody] LoginPlayerForm loginForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            int? playerId = _playerService.Login(loginForm.Pseudo, loginForm.Password_Hash);

            if (playerId is null)
            {
                return Problem(
                    detail: "Credential invalide",
                    statusCode: 400
                );
            }

            Player? playerModel = _playerService.GetById((int)playerId);

            if (playerModel is null)
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError);
            }
            string token = _JwtHelper.CreateToken(playerModel);

            // Envoi d'un JWT avec les informations de l'utilisateur
            return Ok(new JwtDto() { Token = token });
        }

    }
}

