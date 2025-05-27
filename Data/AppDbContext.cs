using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "admin", Role = Role.Admin },
                new User { Id = 2, Username = "user1", Password = "user", Role = Role.User }
            );

            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, Title = "First Task", Description = "Seeded Task", AssignedUserId = 2 }
            );
        }
    }
}
