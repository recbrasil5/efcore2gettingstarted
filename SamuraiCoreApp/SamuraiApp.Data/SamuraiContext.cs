using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        public SamuraiContext(DbContextOptions<SamuraiContext> options) : base(options)
        {

        }

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Qutoes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        "Server=localhost\\sqlexpress;Database=SamuraiAppData;Trusted_Connection=True");
        //}
    }
}
