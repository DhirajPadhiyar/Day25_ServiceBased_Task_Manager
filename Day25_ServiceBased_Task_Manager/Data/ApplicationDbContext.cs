using Day25_ServiceBased_Task_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Day25_ServiceBased_Task_Manager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
