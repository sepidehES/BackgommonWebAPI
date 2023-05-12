using BackgommonWebAPI.Helper;
using BLL.Interfaces;
using BLL.Services;
using Domain.DTO.Match;
using Domain.DTO.Tournament;
using Domain.Mappers;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackgommonWebAPI.Controllers
{
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }


        //[HttpGet("{id:int}/tournament/{id}/match/")]
        [HttpGet("tournament/{id:int}/match")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MatchDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MatchDto> GetById([FromRoute] int id)
        {
            Match? model = _matchService.GetById(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model.ToMatchDTO());
        }
    }
}
