using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;

namespace TodoApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
