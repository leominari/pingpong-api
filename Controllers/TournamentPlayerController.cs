using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campeonato.Data;
using campeonato.ViewModels.TournamentPlayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using campeonato.Models;
using campeonato.ViewModels.TournamentPlayers.Response;

namespace campeonato.Controllers
{
    [ApiController]
    [Route("v1/player-tournaments")]
    public class TournamentPlayerController : ControllerBase
    {
        private readonly IMapper _mapper;

        public TournamentPlayerController(IMapper mapper) : base()
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var tournamentPlayers = await context
                .Tournaments
                .Include(t => t.Players)
                .ThenInclude(tp => tp.Player)
                .AsNoTracking()
                .FirstAsync(tournamentPlayer => tournamentPlayer.Id == id);


            return Ok(_mapper.Map<Tournament, DetailsTournamentPlayerViewModel>(tournamentPlayers));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateTournamentPlayerViewModel model)
        {
            var tournamentPlayer = _mapper.Map<CreateTournamentPlayerViewModel, TournamentPlayer>(model);

            try
            {
                await context
                    .TournamentPlayers
                    .AddAsync(tournamentPlayer);
                await context.SaveChangesAsync();
                return Created($"v1/tournament-player", tournamentPlayer);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}