using BLL.Interfaces;
using BLL.Services;
using Domain.DTO.Tournament;
using Domain.DTO.TournamentUser;
using Domain.Forms.TournamentUser;
using Domain.Forms.User;
using Domain.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackgommonWebAPI.Controllers
{

    [ApiController]
    public class SubscriptionConroller : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        //private readonly JwtHelper _JwtHelper;
        public SubscriptionConroller(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
            //_JwtHelper = jwtHelper;
        }


        [HttpPost("tournament/{id:int}/inscription")]
        [Authorize]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TournamentUserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TournamentUserDto> Create([FromRoute] int id, [FromBody] CreateTournamentUserForm createForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            TournamentUserDto? tournament = _subscriptionService.Create(createForm.ToTournamentUser())?.ToTournamentUserDTO();

            if (tournament == null) return BadRequest();

            return Created($"tournament/{tournament.TournamentId}", tournament);
        }
    }
}
