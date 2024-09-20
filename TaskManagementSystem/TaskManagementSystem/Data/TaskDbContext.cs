using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models.Entities;

namespace TaskManagementSystem.Data
{
    // Database context for the task management system
    public class TaskDbContext : DbContext
    {
        // Constructor for the database context
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        // DbSet for the Work entity, representing a collection of tasks
        public DbSet<Work> Tasks { get; set; }
    }
}