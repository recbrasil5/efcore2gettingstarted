using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using Microsoft.Extensions.DependencyInjection; //<-- part of the new logging implementation
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        public static readonly LoggerFactory MyConsoleLoggerFactory
            = new LoggerFactory(new[] {
              new ConsoleLoggerProvider((category, level)
                => category == DbLoggerCategory.Database.Command.Name
               && level == LogLevel.Information, true) });

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Qutoes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyConsoleLoggerFactory)
                .EnableSensitiveDataLogging(true) //view parameter values in the console logs
                .UseSqlServer(
                    "Server=localhost\\sqlexpress;Database=SamuraiAppData;Trusted_Connection=True");
                //.UseSqlServer(
                //"Server=localhost\\sqlexpress;Database=SamuraiAppData;Trusted_Connection=True", 
                //options => options.MaxBatchSize(150)); //set match batch size of commands to be sent to SQL server at once.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(s => new {s.BattleId, s.SamuraiId });
        }
    }
}
