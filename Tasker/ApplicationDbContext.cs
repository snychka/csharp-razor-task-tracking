using System;
using Microsoft.EntityFrameworkCore;
namespace Tasker
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
