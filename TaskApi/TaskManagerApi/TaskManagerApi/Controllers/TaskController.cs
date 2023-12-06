using Microsoft.AspNetCore.Mvc;
using DataBase.Models;
using DataBase;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerApi.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly TaskDbContext _context;

        public TaskController(TaskDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            List<TaskItem> tasks = await _context.TaskItem.ToListAsync();

            return tasks.Any() ? Ok(tasks) : NotFound("Список задач пуст");
        }

        [HttpGet("GetTask/{taskId}")]
        public async Task<IActionResult> GetTaskById(int taskId)
        {
            var task = await _context.TaskItem.FindAsync(taskId);

            if (task == null)
            {
                return NotFound("Задач не найдена");
            }

            return Ok(task);
        }

        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask(TaskBody bodyTask)
        {
            if (bodyTask == null || string.IsNullOrEmpty(bodyTask.Title))
            {
                return BadRequest("Введите название задачи");
            };

            TaskItem taskItem = new()
            {
                Title = bodyTask.Title,
                Description = bodyTask.Description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.TaskItem.Add(taskItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateTask), taskItem);
        }


        [HttpPut("UpdateTask/{taskId}")]
        public async Task<IActionResult> UpdateTask(int taskId, TaskBody updatedTask)
        {
            var taskToUpdate = await _context.TaskItem.FindAsync(taskId);

            if (taskToUpdate == null)
            {
                return NotFound("Задача не найдена");
            }

            taskToUpdate.Title = !string.IsNullOrEmpty(updatedTask.Title) ? updatedTask.Title : taskToUpdate.Title;
            taskToUpdate.Description = !string.IsNullOrEmpty(updatedTask.Description) ? updatedTask.Description : taskToUpdate.Description;
            taskToUpdate.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(taskToUpdate);
        }

        [HttpDelete("DeleteTask/{taskId}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var taskToRemove = await _context.TaskItem.FindAsync(taskId);

            if (taskToRemove == null)
            {
                return NotFound("Задача не найдена");
            }

            _context.TaskItem.Remove(taskToRemove);
            await _context.SaveChangesAsync();

            return Ok("Задача удалена");
        }
    }
}