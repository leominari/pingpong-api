using System;
using System.Collections.Generic;
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
    public class PlayerController : ControllerBase
    {
        [HttpGet]
        [Route("players")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context)
        {
            var players = await context
                .Players
                .AsNoTracking()
                .ToListAsync();
            return Ok(players);
        }

        [HttpGet]
        [Route("players/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var player = await context
                .Players
                .AsNoTracking()
                .FirstOrDefaultAsync(player => player.Id == id);
            return player == null
                ? NotFound()
                : Ok(player);
        }


        [HttpPost("players")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreatePlayerViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var player = new Player
            {
                Date = DateTime.Now,
                Name = model.Name
            };

            try
            {
                await context
                    .Players
                    .AddAsync(player);
                await context.SaveChangesAsync();
                return Created($"v1/players/{player.Id}", player);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("players/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreatePlayerViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var player = await context
                .Players
                .FirstOrDefaultAsync(player => player.Id == id);

            if (player == null)
                return NotFound();

            try
            {
                player.Name = model.Name;
                context.Players.Update(player);

                await context.SaveChangesAsync();

                return Ok(player);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("players/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var player = await context
                .Players
                .FirstOrDefaultAsync(player => player.Id == id);

            try
            {
                context.Players.Remove(player);
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