using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return Ok(task);
        }


        [Authorize(Roles = "Admin,User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            return task == null ? NotFound() : Ok(task);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var tasks = await _context.Tasks.Where(t => t.AssignedUserId == userId).ToListAsync();
            return Ok(tasks);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskItem task)
        {
            if (id != task.Id) return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingTask = await _context.Tasks.FindAsync(id);
            if (existingTask == null) return NotFound();

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.AssignedUserId = task.AssignedUserId;

            await _context.SaveChangesAsync();

            return Ok(existingTask);  
        }



        [Authorize(Roles = "Admin,User")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)

        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        


    }
}
