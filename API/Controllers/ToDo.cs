using API.Data;
using API.Models;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ToDoController : ControllerBase
    {
        [HttpGet("ToDos")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context
        )
        {
            var ToDos = await context
            .ToDos
            .AsNoTracking()
            .ToListAsync();
            return Ok(ToDos);
        }

        [HttpGet("ToDos/{id}")]
        public async Task<IActionResult> GetByIdAsync(
           [FromServices] AppDbContext context,
           [FromRoute] int id
        )
        {
            var ToDo = await context
            .ToDos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return ToDo == null ? NotFound() : Ok(ToDo);
        }

        [HttpPost("ToDos")]
        public async Task<IActionResult> PostAsync(
           [FromServices] AppDbContext context,
            [FromBody] CreateToDoViewModel model
        )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var todo = new ToDo
            {
                DateTime = DateTime.Now,
                Done = false,
                Title = model.Title,
            };

            try
            {
                await context.ToDos.AddAsync(todo);
                await context.SaveChangesAsync();
                return Created($"v1/todos/{todo.Id}", todo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}