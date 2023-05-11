
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
using Domain.DTO.Tournament;
using BLL.Services;

namespace BackgommonWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;
        //private readonly JwtHelper _JwtHelper;
        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
            //_JwtHelper = jwtHelper;
        }


        //[HttpGet("{id:int}")]
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TournamentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TournamentDto> GetById([FromRoute] int id)
        {
            Tournament? model = _tournamentService.GetById(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model.ToTournamentDTO());
        }


        [HttpGet]
        [AllowAnonymous] // Déactive l'attirubte [Authorize] de la classe
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TournamentDto>))]
        public ActionResult<IEnumerable<TournamentDto>> GetAll()
        {
            return Ok(_tournamentService.GetAll().ToTournamentDtoList());
        }


        [HttpPost]
        [AllowAnonymous]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TournamentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TournamentDto> Create([FromBody] CreateTournamentForm createForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            TournamentDto? tournament = _tournamentService.Create(createForm.ToTournament())?.ToTournamentDTO();

            if (tournament == null) return BadRequest();

            return Created($"tournament/{tournament.TournamentId}", tournament);
        }

    }
}
