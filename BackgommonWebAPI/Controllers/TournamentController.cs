
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
using Umbraco.Core.Models.Membership;

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

        [HttpDelete("{id:int}")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromRoute] int id)
        {
            if (_tournamentService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPut("{id:int}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TournamentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TournamentDto> Update([FromRoute] int id, [FromBody] CreateTournamentForm updateForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Tournament? existingTournament = _tournamentService.GetById(id);

            if (existingTournament == null)
                return NotFound();

            existingTournament.TournamentName = updateForm.TournamentName;
            existingTournament.Description = updateForm.Description;
            existingTournament.MaxPlayer = updateForm.MaxPlayer;


            bool updateResult = _tournamentService.Update(id, existingTournament);

            if (!updateResult) return BadRequest();
            TournamentDto updateTournamentDto = existingTournament.ToTournamentDTO();
            return Ok(updateTournamentDto);
        }

        [HttpPatch("{id:int}/Inscription/open")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateOpen([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_tournamentService.UpdateOpen(id))
            {
                return NoContent();
            }

            return BadRequest();
        }


        [HttpPatch("{id:int}/Inscription/Close")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateClose([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_tournamentService.UpdateClose(id))
            {
                return NoContent();
            }

            return BadRequest();
        }



        [HttpPatch("{id:int}/Start")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateStart([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_tournamentService.UpdateStart(id))
            {
                return NoContent();
            }

            return BadRequest();
        }

    }
}
