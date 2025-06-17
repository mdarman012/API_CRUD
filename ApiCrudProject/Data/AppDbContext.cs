using ApiCrudProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudProject.Data
{
    public class AppDbContext:DbContext
    {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<StudentsDetails> StudentsDetails { get; set; }
    }
}
