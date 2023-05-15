using BackgommonWebAPI.Helper;
using BLL.Interfaces;
using BLL.Services;
using Domain.DTO.Tournament;
using Domain.DTO.TournamentUser;
using Domain.Forms.TournamentUser;
using Domain.Forms.User;
using Domain.Mappers;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Core.Models.Membership;

namespace BackgommonWebAPI.Controllers
{
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly ITournamentService _tournamentService;
        private readonly IPlayerService _playerService;
        private readonly JwtHelper _JwtHelper;
        public SubscriptionController(ISubscriptionService subscriptionService, JwtHelper jwtHelper, ITournamentService tournamentService, IPlayerService playerService)
        {
            _subscriptionService = subscriptionService;
            _JwtHelper = jwtHelper;
            _tournamentService = tournamentService;
            _playerService = playerService;
        }

        private int? PlayerId
        {
            get
            {
                string? tokenId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                return (tokenId is null) ? null : int.Parse(tokenId);
            }
        }


        [HttpPost("tournament/{id:int}/inscription")]
        [Authorize]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TournamentUserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<TournamentUserDto> Create([FromBody] CreateTournamentUserForm createForm,[FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //Check UserId in authentification(by JWT)
            if (PlayerId is null)
            {
                return Forbid();
            }



            
            Tournament? checkTournament = _tournamentService.GetById(createForm.TournamentId);
            Player? checkPlayer = _playerService.GetById((int) PlayerId);
            if (!checkTournament.IsOpen)
            {
                return Problem(detail: "This tournament is not open!", statusCode: StatusCodes.Status400BadRequest);
            }

            TournamentUserDto? tournament = _subscriptionService.Create(createForm.ToTournamentUser(id), id)?.ToTournamentUserDTO();

            if (tournament == null) return BadRequest();

            return Created($"tournament/{tournament.TournamentId}", tournament);
        }
    }
}
