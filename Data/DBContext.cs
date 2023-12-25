using Microsoft.EntityFrameworkCore;
namespace congrr.Data
{
    public class DBContext : DbContext
    {
        private readonly IConfiguration configuration1;
        public DbSet<model> birth { get; set; }
        public DBContext(IConfiguration configuration)
        {
            configuration1 = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration1.GetConnectionString("EFDemo"));
        }
    }
}
