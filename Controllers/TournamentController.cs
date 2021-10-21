using System;
using System.Threading.Tasks;
using campeonato.Data;
using campeonato.Models;
using campeonato.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace campeonato.Controllers
{
    [ApiController]
    [Route("v1")]
    public class TournamentController : ControllerBase
    {
        [HttpGet("tournaments")]
        public async Task<IActionResult> AsyncGet(
            [FromServices] AppDbContext context)
        {
            var tournaments = await context
                .Tournaments
                .AsNoTracking()
                .ToListAsync();


            return Ok(tournaments);
        }

        [HttpGet]
        [Route("tournaments/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var tournament = await context
                .Tournaments
                .AsNoTracking()
                .FirstOrDefaultAsync(tournament => tournament.Id == id);
            return tournament == null
                ? NotFound()
                : Ok(tournament);
        }


        [HttpPost("tournaments")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateTournamentViewModel model)
        {
            Console.WriteLine(model.Start);
            if (!ModelState.IsValid)
                return BadRequest();

            var tournament = new Tournament()
            {
                Name = model.Name
            };

            try
            {
                await context
                    .Tournaments
                    .AddAsync(tournament);
                await context.SaveChangesAsync();
                return Created($"v1/tournaments/{tournament.Id}", tournament);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("tournaments/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateTournamentViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tournament = await context
                .Tournaments
                .FirstOrDefaultAsync(tournament => tournament.Id == id);

            if (tournament == null)
                return NotFound();

            try
            {
                tournament.Name = model.Name;
                context.Tournaments.Update(tournament);

                await context.SaveChangesAsync();

                return Ok(tournament);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("tournaments/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var tournament = await context
                .Tournaments
                .FirstOrDefaultAsync(tournament => tournament.Id == id);

            try
            {
                context.Tournaments.Remove(tournament);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}