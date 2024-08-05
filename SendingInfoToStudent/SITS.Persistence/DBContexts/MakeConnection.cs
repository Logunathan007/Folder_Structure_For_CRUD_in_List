using Microsoft.EntityFrameworkCore;
using SITS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS.Persistence.DBContexts
{
    public class MakeConnection : DbContext
    {
        public MakeConnection(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentDetail> StudentDetails { get; set; } 
    }
}
