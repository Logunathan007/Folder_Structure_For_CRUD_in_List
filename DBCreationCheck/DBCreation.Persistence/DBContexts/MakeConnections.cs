using DBCreation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCreation.Persistence.DBContexts
{
    public class MakeConnections : DbContext
    {
        public MakeConnections(DbContextOptions option) : base(option)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
