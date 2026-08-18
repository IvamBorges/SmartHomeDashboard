using Microsoft.EntityFrameworkCore;
using SmartHomeDashboard.Models;

namespace SmartHomeDashboard.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dispositivo> Dispositivos { get; set; }
    }
}