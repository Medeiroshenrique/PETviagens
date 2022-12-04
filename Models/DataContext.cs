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
        protected DbSet<Passageiro> Passageiros { get; set; }

        
    }
}
