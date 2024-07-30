using Microsoft.EntityFrameworkCore;

namespace OneToManyRelatonship.Model
{
    public class CreateConnection : DbContext
    {
        protected IConfiguration configuration;
        public CreateConnection(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(this.configuration.GetConnectionString("StringForConnection"));
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Manager> Manager { get; set; }
    }
}
