using Microsoft.EntityFrameworkCore;

namespace APIwebPET.Models
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            options.UseSqlServer(connectionString);
        }
        protected DbSet<Passageiro>? Passageiros { get; set; }

        
    }
}
