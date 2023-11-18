using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

namespace StudentAPI
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Students> Student { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
    }
}