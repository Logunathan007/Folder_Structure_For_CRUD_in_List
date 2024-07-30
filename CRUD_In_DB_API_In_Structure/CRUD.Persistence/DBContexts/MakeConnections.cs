using CRUD.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Persistence.DBContexts
{
    public class MakeConnections : DbContext
    {
        public MakeConnections(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
