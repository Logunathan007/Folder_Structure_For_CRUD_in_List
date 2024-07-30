
using Microsoft.EntityFrameworkCore;

namespace CRUD.Services.Model
{
    public class DbConnections:DbContext
    {
        public DbConnections(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
