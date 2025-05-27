using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public class TaskService
    {
        private readonly DbContext _dbContext;

        public TaskService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskItem> GetTask(int id)
        {
            return await _dbContext.Set<TaskItem>().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<TaskItem>> GetAllTasks()
        {
            return await _dbContext.Set<TaskItem>().ToListAsync();
        }
    }
}
